Imports System.Xml
Imports System.IO

Public Class CancelamentoEvento

    Private VId As String
    Public Property Id() As String
        Get
            Id = VId
        End Get
        Set(ByVal value As String)
            VId = value
        End Set
    End Property
    Private VcOrgao As String
    Public Property cOrgao() As String
        Get
            cOrgao = VcOrgao
        End Get
        Set(ByVal value As String)
            VcOrgao = value
        End Set
    End Property
    Private VtpAMB As String
    Public Property tpAMB() As String
        Get
            tpAMB = VtpAMB
        End Get
        Set(ByVal value As String)
            VtpAMB = value
        End Set
    End Property
    Private VCNPJ As String
    Public Property CNPJ() As String
        Get
            CNPJ = VCNPJ
        End Get
        Set(ByVal value As String)
            VCNPJ = value
        End Set
    End Property
    Private VCPF As String
    Public Property CPF() As String
        Get
            CPF = VCPF
        End Get
        Set(ByVal value As String)
            VCPF = value
        End Set
    End Property
    Private VchNFe As String
    Public Property chNFe() As String
        Get
            chNFe = VchNFe
        End Get
        Set(ByVal value As String)
            VchNFe = value
        End Set
    End Property
    Private VdhEvento As Date
    Public Property dhEvento() As DateTime
        Get
            dhEvento = VdhEvento
        End Get
        Set(ByVal value As DateTime)
            VdhEvento = value
        End Set
    End Property
    Private VtpEvento As String
    Public Property tpEvento()
        Get
            tpEvento = VtpEvento
        End Get
        Set(ByVal value)
            VtpEvento = value
        End Set
    End Property
    Private VnSeqEvento As String
    Public Property nSeqEvento() As String
        Get
            nSeqEvento = VnSeqEvento
        End Get
        Set(ByVal value As String)
            VnSeqEvento = value
        End Set
    End Property
    Private VverEvento As String
    Public Property verEvento() As String
        Get
            verEvento = VverEvento
        End Get
        Set(ByVal value As String)
            VverEvento = value
        End Set
    End Property
    Private VdetEvento As String
    Public Property detEvento() As String
        Get
            detEvento = VdetEvento
        End Get
        Set(ByVal value As String)
            VdetEvento = value
        End Set
    End Property
    Private Vversao As String
    Public Property versao() As String
        Get
            versao = Vversao
        End Get
        Set(ByVal value As String)
            Vversao = value
        End Set
    End Property
    Private VdescEvento As String
    Public Property descEvento() As String
        Get
            descEvento = VdescEvento
        End Get
        Set(ByVal value As String)
            VdescEvento = value
        End Set
    End Property

    Private VnProt As String
    Public Property nProt() As String
        Get
            nProt = VnProt
        End Get
        Set(ByVal value As String)
            VnProt = value
        End Set

    End Property
    Private VxJust As String
    Public Property xJust() As String
        Get
            xJust = VxJust
        End Get
        Set(ByVal value As String)
            VxJust = value
        End Set

    End Property
    Sub New()
        dhEvento = Now
        tpEvento = "110111"
        verEvento = "1.00"
        versao = "1.00"
    End Sub

    Public Function GeraXML() As XmlDocument
        Dim configXML As New XmlWriterSettings()
        configXML.Indent = True
        configXML.IndentChars = ""
        configXML.NewLineOnAttributes = False
        configXML.OmitXmlDeclaration = False
        configXML.Encoding = System.Text.UTF8Encoding.UTF8

        Dim xmlSaida As Stream = New MemoryStream()

        Dim oXmlGravar As XmlWriter = XmlWriter.Create(xmlSaida, configXML)

        With oXmlGravar
            'inicio do arquivo
            .WriteStartDocument()
            .WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe")
            .WriteAttributeString("versao", "1.00")
            .WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")

            .WriteStartElement("infEvento")
            .WriteAttributeString("Id", Id)
            .WriteElementString("cOrgao", cOrgao)
            .WriteElementString("tpAmb", tpAMB)

            If CNPJ.Length > 0 Then
                .WriteElementString("CNPJ", CNPJ)
            Else
                .WriteElementString("CPF", CPF)
            End If

            .WriteElementString("chNFe", chNFe)
            .WriteElementString("dhEvento", Format(dhEvento, "yyyy-MM-ddTHH:mm:ss") & "-03:00")
            .WriteElementString("tpEvento", tpEvento)
            .WriteElementString("nSeqEvento", nSeqEvento)
            .WriteElementString("verEvento", verEvento)

            .WriteStartElement("detEvento")
            .WriteAttributeString("versao", versao)
            .WriteElementString("descEvento", "Cancelamento")
            .WriteElementString("nProt", VnProt)
            .WriteElementString("xJust", VxJust)
            .WriteEndElement() 'fecha o detEvento

            .WriteEndElement() 'Fecha o evento
            .WriteEndElement() 'Fecha o infEvento

            .Flush()
        End With

        xmlSaida.Flush()
        xmlSaida.Position = 0

        Dim documento As New XmlDocument()
        documento.Load(xmlSaida)
        oXmlGravar.Close()
        Return documento

    End Function

    Public Sub GerarLote(ByRef documentoXML As XmlDocument)
        Dim cVersaoDados As String = "1.00"

        'Montar a string da CCe a ser montado o Lote
        Dim vCancDadosMsg As String = documentoXML.OuterXml

        'Pegar o último número de lote de CCe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryCancLote.xml"
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

        'Salvar o número de lote de CCe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryCancLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteCanNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vCancDadosMsg.IndexOf("<evento")
        Dim nPosF As Int32 = vCancDadosMsg.Length - nPosI
        Dim vStringCanc As String = vCancDadosMsg.Substring(nPosI, nPosF)

        'Montar a parte do XML referente ao Lote e acrescentar a CCe
        Dim vStringLoteCCe As String = String.Empty
        vStringLoteCCe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteCCe += "<envEvento versao =""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteCCe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteCCe += vStringCanc
        vStringLoteCCe += "</envEvento>"

        documentoXML.LoadXml(vStringLoteCCe)
    End Sub
    Public Function GerarNotaProcCancE(ByVal caminho As String, ByVal NomeArquivoNovo As String, ByVal retorno As C_WebService.RetornoEvento) As String
        Dim cabecalho_envio As String
        Dim arquivo As String
        Dim novo As New Xml.XmlDocument

        novo.Load(caminho)
        arquivo = novo.OuterXml

        cabecalho_envio = "<?xml version=""1.0"" encoding=""UTF-8""?>"
        cabecalho_envio += "<procEventoNFe versao=""1.00"" xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        cabecalho_envio += Replace(arquivo, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")
        cabecalho_envio += retorno.XmlRecibo
        cabecalho_envio += "</procEventoNFe>"

        Dim xmldoc As New Xml.XmlDocument

        xmldoc.LoadXml(cabecalho_envio)
        xmldoc.Save(NomeArquivoNovo)

        Return NomeArquivoNovo

    End Function

End Class
