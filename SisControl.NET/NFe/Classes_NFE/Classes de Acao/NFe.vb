Imports System.Xml
Imports System.IO
Imports System.Reflection
Imports System.Globalization

Public Class NFe
    Public Function GerarDPEC() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("envDPEC", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", "1.01")
        oXmlGravar.WriteStartElement("infDPEC")
        'oXmlGravar.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        oXmlGravar.WriteAttributeString("Id", "DPEC" & funcoesNfe.removeFormatacao(infNFE.Emit.CNPJ))

        oXmlGravar.WriteStartElement("ideDec")
        oXmlGravar.WriteElementString("cUF", infNFE.Ide.cUF.ToString())
        oXmlGravar.WriteElementString("tpAmb", infNFE.Ide.tpAmb.ToString())
        oXmlGravar.WriteElementString("verProc", infNFE.Ide.verProc.ToString())
        oXmlGravar.WriteElementString("CNPJ", funcoesNfe.removeFormatacao(infNFE.Emit.CNPJ))
        oXmlGravar.WriteElementString("IE", funcoesNfe.removeFormatacao(infNFE.Emit.IE))
        oXmlGravar.WriteEndElement()
        'fecha ideDec
        oXmlGravar.WriteStartElement("resNFe")
        oXmlGravar.WriteElementString("chNFe", Id)

        If (infNFE.Dest.CNPJ IsNot Nothing) AndAlso (infNFE.Dest.CNPJ.Length > 0) Then
            oXmlGravar.WriteElementString("CNPJ", funcoesNfe.removeFormatacao(infNFE.Dest.CNPJ))
        Else
            oXmlGravar.WriteElementString("CPF", funcoesNfe.removeFormatacao(infNFE.Dest.CPF))
        End If

        oXmlGravar.WriteElementString("UF", infNFE.Dest.EnderDest.UF)
        Dim cultura As New CultureInfo("en-US")
        oXmlGravar.WriteElementString("vNF", infNFE.Total.IcmsTot.vNF.ToString("#0.00", cultura.NumberFormat))
        oXmlGravar.WriteElementString("vICMS", infNFE.Total.IcmsTot.vICMS.ToString("#0.00", cultura.NumberFormat))
        oXmlGravar.WriteElementString("vST", infNFE.Total.IcmsTot.vST.ToString("#0.00", cultura.NumberFormat))
        oXmlGravar.WriteEndElement()
        'fecha resNFe
        oXmlGravar.WriteEndElement()
        'fecha infDPEC
        oXmlGravar.WriteEndElement()
        'fecha envDPEC
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)

        oXmlGravar.Close()


        Return documento
    End Function

    'FUNÇÃO QUE POR RECURSIVIDADE PREENCHE ESCREVE OS DADOS DO XML
    Private Sub objetoParaXML(ByVal xmlWriter As XmlWriter, ByVal objeto As Object, ByVal ignorarDeclaracaoElemento As Boolean)
        If objeto Is Nothing Then
            Exit Sub
        End If

        Dim tipoObjeto As Type
        tipoObjeto = objeto.[GetType]()
        Dim propriedades As PropertyInfo()
        propriedades = tipoObjeto.GetProperties()

        'VERIFICA SE É UM CAMPO DO TIPO LIST
        'SE FOR ADICIONA NOVO ELEMENTE
        If Not ignorarDeclaracaoElemento And tipoObjeto.Name <> "List`1" Then
            xmlWriter.WriteStartElement(tipoObjeto.Name)
        End If

        'SE FORM UMA LISTA CHAMA FUNÇÃO NOVAMENTE PARA PREENCHER ELEMENTOS DA LISTA
        If tipoObjeto.Name = "List`1" Then
            If objeto.ToString.Contains("fat") Then
                For Each dfat As fat In objeto
                    objetoParaXML(xmlWriter, dfat, False)
                    Continue For
                Next
            ElseIf objeto.ToString.Contains("dup") Then
                For Each Ddup As dup In objeto
                        objetoParaXML(xmlWriter, Ddup, False)
                        Continue For
                    Next
                ElseIf objeto.ToString.Contains("med") Then
                    For Each Dmed As med In objeto
                        objetoParaXML(xmlWriter, Dmed, False)
                        Continue For
                    Next
                ElseIf objeto.ToString.Contains("rastro") Then
                    For Each Drastro As rastro In objeto
                        objetoParaXML(xmlWriter, Drastro, False)
                        Continue For
                    Next
                ElseIf objeto.ToString.Contains("detPag") Then
                    For Each DPag As detPag In objeto
                        objetoParaXML(xmlWriter, DPag, False)
                        Continue For
                    Next
                Else
                    For Each DNFref As NFref In objeto
                        objetoParaXML(xmlWriter, DNFref, False)
                        Continue For
                    Next
                End If
                Exit Sub
            End If

            'VERIFICA CAMPOS E ADICIONA TAGS E ELEMENTOS XML
            For Each propriedade As PropertyInfo In propriedades

            If funcoesNfe.novaTag(propriedade) AndAlso Not (propriedade.GetValue(objeto, Nothing) Is Nothing) Then
                'VERIFICA É UMA LISTA DE NOTAS REFERENCIADAS
                'SE FOR VERIFICA SÉ É NOTA PAPEL OU NOTA ELETRONICA
                If propriedade.Name = "RefNF" AndAlso objeto.refNFE <> "" Then
                Else
                    objetoParaXML(xmlWriter, propriedade.GetValue(objeto, Nothing), False)
                    Continue For
                End If
            End If

            Dim obj As Object() = propriedade.GetCustomAttributes(False)
            funcoesNfe.gravarElemento(xmlWriter, propriedade.Name, propriedade.GetValue(objeto, Nothing), obj)
        Next
        If Not ignorarDeclaracaoElemento Then
            xmlWriter.WriteEndElement()
        End If
    End Sub

    Public Sub GerarLoteNfe(ByRef documentoXML As XmlDocument)
        Dim cVersaoDados As String = "1.07"

        'Montar a string da Nfe a ser montado o Lote
        Dim vNfeDadosMsg As String = documentoXML.OuterXml

        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote.xml"
        Dim nNumeroLote As Int32 = 1

        If File.Exists(vArqXmlLote) Then
            Dim oLerXml As New XmlTextReader(vArqXmlLote)

            While oLerXml.Read()
                If oLerXml.NodeType = XmlNodeType.Element Then
                    If oLerXml.Name = "UltimoLoteEnviado" Then
                        oLerXml.Read()
                        nNumeroLote = Convert.ToInt32(oLerXml.Value) + 1
                        Exit While
                    End If
                End If
            End While
            oLerXml.Close()
        End If

        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF)

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"

        vStringLoteNfe += "<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00"">"
        vStringLoteNfe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteNfe += "<indSinc>0</indSinc>"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</enviNFe>"

        documentoXML.LoadXml(vStringLoteNfe)
    End Sub

    Public Function GerarXML() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("NFe", "http://www.portalfiscal.inf.br/nfe")
        'abre nfe
        oXmlGravar.WriteStartElement("infNFe")
        oXmlGravar.WriteAttributeString("Id", "NFe" & Id.ToString())
        oXmlGravar.WriteAttributeString("versao", versao.ToString())

        Dim tipoObjeto As Type
        tipoObjeto = infNFE.Ide.[GetType]()
        Dim propriedades As PropertyInfo()
        propriedades = tipoObjeto.GetProperties()

        objetoParaXML(oXmlGravar, infNFE.Ide, False)
        objetoParaXML(oXmlGravar, infNFE.Emit, False)
        objetoParaXML(oXmlGravar, infNFE.Dest, False)


        For Each detalhe As det In infNFE.Det
            oXmlGravar.WriteStartElement("det")
            oXmlGravar.WriteAttributeString("nItem", detalhe.nItem.ToString())

            objetoParaXML(oXmlGravar, detalhe.Prod, False)

            oXmlGravar.WriteStartElement("imposto")
            objetoParaXML(oXmlGravar, detalhe.Imposto.Icms, False)
            objetoParaXML(oXmlGravar, detalhe.Imposto.Ii, False)
            objetoParaXML(oXmlGravar, detalhe.Imposto.Ipi, False)
            objetoParaXML(oXmlGravar, detalhe.Imposto.Pis, False)
            objetoParaXML(oXmlGravar, detalhe.Imposto.Cofins, False)

            'fecha TAG imposto...
            oXmlGravar.WriteEndElement()
            'oXmlGravar.WriteStartElement("infAdProd")
            'oXmlGravar.WriteString(detalhe.infAdProd)
            'oXmlGravar.WriteEndElement()
            'fecha TAG det...
            oXmlGravar.WriteEndElement()
        Next

        objetoParaXML(oXmlGravar, infNFE.Total, False)
        objetoParaXML(oXmlGravar, infNFE.Transp, False)
        objetoParaXML(oXmlGravar, infNFE.Cobr, False)
        objetoParaXML(oXmlGravar, infNFE.Pag, False)
        'If infNFE.Cobr IsNot Nothing Then
        'oXmlGravar.WriteStartElement("cobr")
        'For Each duplicata As dup In infNFE.Cobr.Dup
        'objetoParaXML(oXmlGravar, duplicata, False)
        'Next

        'fecha tag cobr
        'oXmlGravar.WriteEndElement()
        'End If

        objetoParaXML(oXmlGravar, infNFE.InfAdic, False)

        oXmlGravar.WriteEndElement()
        'fecha infNFe
        oXmlGravar.WriteEndElement()
        'fecha NFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)

        'documento.Save("c:\\testeXML.xml");

        oXmlGravar.Close()

        Return documento
    End Function

    Public Function GerarXMLRecibo() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("consReciNFe", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao)
        oXmlGravar.WriteElementString("tpAmb", infNFE.Ide.tpAmb.ToString())
        oXmlGravar.WriteElementString("nRec", nRec)


        oXmlGravar.WriteEndElement()
        'Fecha elemento consReciNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function

    Public Function GerarXMLCancelamento() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("cancNFe", "http://www.portalfiscal.inf.br/nfe")
        'oXmlGravar.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        oXmlGravar.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infCanc")
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)

        oXmlGravar.WriteElementString("tpAmb", "2")
        oXmlGravar.WriteElementString("xServ", "CANCELAR")
        oXmlGravar.WriteElementString("chNFe", Id)
        oXmlGravar.WriteElementString("nProt", nProt)
        oXmlGravar.WriteElementString("xJust", xJust)


        oXmlGravar.WriteEndElement()
        'Fecha elemento infCanc
        oXmlGravar.WriteEndElement()
        'Fecha elemento cancNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()
        'documento.Save("c:\\testeXML.xml")
        Return documento
    End Function

    Public Function GerarXMLStatusNfe() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("consSitNFe", "http://www.portalfiscal.inf.br/nfe")
        'oXmlGravar.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())

        oXmlGravar.WriteElementString("tpAmb", "1")
        oXmlGravar.WriteElementString("xServ", "CONSULTAR")
        oXmlGravar.WriteElementString("chNFe", Id)

        oXmlGravar.WriteEndElement()
        'Fecha elemento consSitNFe

        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()
        'documento.Save("c:\\testeXML.xml")
        Return documento
    End Function

    Public Function GerarXMLInutilizacao() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("inutNFe", "http://www.portalfiscal.inf.br/nfe")
        oXmlGravar.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        oXmlGravar.WriteAttributeString("versao", versao.ToString())
        oXmlGravar.WriteStartElement("infInut")
        If Id.ToString().Trim().Length = 0 Then
            'Se a chave não foi gerada no ERP... gerar aqui
            Dim _codUF As String = infNFE.Ide.cUF.ToString()
            Dim _cnpj As String = funcoesNfe.removeFormatacao(infNFE.Emit.CNPJ)
            Dim _mod As String = infNFE.Ide.[mod]

            Dim _serie As String = String.Format("{0:000}", Int32.Parse(infNFE.Ide.serie))
            Dim _numNFIni As String = String.Format("{0:000000000}", NumNf_Ini)
            Dim _numNFFin As String = String.Format("{0:000000000}", NumNf_Fin)

            Id = _codUF + _cnpj + _mod + _serie + _numNFIni + _numNFFin
        End If
        oXmlGravar.WriteAttributeString("Id", "ID" & Id)

        oXmlGravar.WriteElementString("tpAmb", infNFE.Ide.tpAmb.ToString())
        oXmlGravar.WriteElementString("xServ", "INUTILIZAR")
        oXmlGravar.WriteElementString("cUF", infNFE.Ide.cUF.ToString())
        oXmlGravar.WriteElementString("ano", ano)
        oXmlGravar.WriteElementString("CNPJ", infNFE.Emit.CNPJ)
        oXmlGravar.WriteElementString("mod", infNFE.Ide.[mod])
        oXmlGravar.WriteElementString("serie", infNFE.Ide.serie)
        oXmlGravar.WriteElementString("nNFIni", NumNf_Ini.ToString())
        oXmlGravar.WriteElementString("nNFFin", NumNf_Fin.ToString())
        oXmlGravar.WriteElementString("xJust", xJust)

        oXmlGravar.WriteEndElement()
        'Fecha Tag infInut
        oXmlGravar.WriteEndElement()
        'Fecha Tag inutNFe
        oXmlGravar.Flush()
        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()

        Return documento
    End Function


    Private _infNFE As InfNFE

    'private string _Id;

    Private _versao As String
    Public Property versao() As String
        Get
            Return _versao
        End Get
        Set(ByVal value As String)
            _versao = value
        End Set
    End Property

    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
    ''' <summary>
    ''' Utilizado na geração de XML para consulta de recibo
    ''' </summary>
    Private _nRec As String
    Public Property nRec() As String
        Get
            Return _nRec
        End Get
        Set(ByVal value As String)
            _nRec = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o número do Protocolo de Autorização da NF-e a ser Cancelada.
    ''' 1 posição (1 – Secretaria de Fazenda Estadual
    ''' 2 – Receita Federal); 2 posições para código da UF;
    ''' 2 posições ano;
    ''' 10 seqüencial no ano
    ''' </summary>
    Private _nProt As String
    Public Property nProt() As String
        Get
            Return _nProt
        End Get
        Set(ByVal value As String)
            _nProt = value
        End Set
    End Property
    Private _xJust As String
    Public Property xJust() As String
        Get
            Return _xJust
        End Get
        Set(ByVal value As String)
            _xJust = value
        End Set
    End Property
    Private _ano As String
    Public Property ano() As String
        Get
            Return _ano
        End Get
        Set(ByVal value As String)
            _ano = value
        End Set
    End Property
    Private _NumNf_Ini As Integer
    Public Property NumNf_Ini() As Integer
        Get
            Return _NumNf_Ini
        End Get
        Set(ByVal value As Integer)
            _NumNf_Ini = value
        End Set
    End Property
    Private _NumNf_Fin As Integer
    Public Property NumNf_Fin() As Integer
        Get
            Return _NumNf_Fin
        End Get
        Set(ByVal value As Integer)
            _NumNf_Fin = value
        End Set
    End Property

    Public ReadOnly Property infNFE() As InfNFE
        Get
            Return _infNFE
        End Get
    End Property

    Public Sub New()
        _infNFE = New InfNFE()
    End Sub
End Class