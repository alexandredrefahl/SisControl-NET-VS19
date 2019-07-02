Imports System.Security.Cryptography.X509Certificates
Imports System.Xml

Public Class C_WebService
    'VARIAVEL QUE IRA RECEBER O RETORNO DO ENVIO DO LOTE

    Private Const VersaoAtualNfe As String = "4.00"

    Public Structure RetEnvio
        Dim verAplic As String
        Dim cStat As String
        Dim xMotivo As String
        Dim cUF As String
        Dim nRec As String
        Dim dhRecbto As String
        Dim tMed As String
        Dim XmlRecibo As String
    End Structure

    'VARIAVEL COM AS INFORMACOES DA NFE PARA USAR NA CONSULTA RETORNO
    Public Structure RetRecibo
        Dim Id As String
        Dim tpAmb As String
        Dim verAplic As String
        Dim chNFe As String
        Dim dhRecbto As String
        Dim digVal As String
        Dim cStat As String
        Dim xMotivo As String
        Dim nProt As String
        Dim XmlRecibo As String
    End Structure

    'VARIAVEL QUE VAI RECEBER O RETORNO DA CONSULTA DE ENVIO
    Public Structure RetRetorno
        Dim tpAmb As String
        Dim verAplic As String
        Dim cStat As String
        Dim xMotivo As String
        Dim cUF As String
        Dim nRec As String
        Dim dhRecbto As String
        Dim tMed As String
        Dim L_Retornos As List(Of RetRecibo) 'LISTA DE NOTAS PARA QUANDO MAIS DE UMA NOTA FOI ENVIADA NO LOTE
    End Structure

    Public Structure SEvento
        Dim Id As String
        Dim tpAmb As String
        Dim verAplic As String
        Dim cOrgao As String
        Dim cStat As String
        Dim xMotivo As String
        Dim chNfe As String
        Dim tpEvento As String
        Dim xEvento As String
        Dim nSeqEvento As String
        Dim CNPJDest As String
        Dim CPFDest As String
        Dim emailDest As String
        Dim dhRetEvento As String
        Dim nProt As String
    End Structure

    Public Structure RetornoEvento
        Dim versao As String
        Dim IdLote As String
        Dim tpAmb As String
        Dim verAplic As String
        Dim cOrgao As String
        Dim cStat As String
        Dim xMotivo As String
        Dim infEvento As SEvento
        Dim XmlRecibo As String
    End Structure


    Public Structure ListaUrl
        Dim UrlNfeRecepcao As String
        Dim UrlNfeRetRecepcao As String
        Dim UrlNfeCancelamento As String
        Dim UrlNfeInutilizacao As String
        Dim UrlNfeConsultaProtocolo As String
        Dim UrlNfeStatusServico As String
        Dim UrlNfeRecepcaoEvento As String
        Dim UrlNFeAutorizacao400 As String
        Dim UrlNFeRetAutorizacao400 As String
        Dim CodigoUF As String
    End Structure

    Private S_Url As ListaUrl
    Public Sub New(ByVal ListadeUrl As ListaUrl)
        S_Url = ListadeUrl
    End Sub

    Public Function EnviaLote400(ByVal EndArquivoXml As String) As RetEnvio
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        xmldoc.Load(EndArquivoXml) 'Carrega o arquivo XML 
        Dim CERT As X509Certificate2
        CERT = SelecionarCertificado("")
        Try
            Dim wsMsg As New NFeAutorizacaoV4.NFeAutorizacao4(S_Url.UrlNFeAutorizacao400)


            Dim Notas As String

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(CERT)
            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'NOVO PROTOCOLO
            Notas = xmldoc.OuterXml

            'RETORNO DA SEFAZ
            strRetorno = wsMsg.nfeAutorizacaoLote(xmldoc)

            'DESMEMBRA RETORNO XML
            Dim StrRetNota As RetEnvio = Nothing
            Dim XmlText As XmlDocument = New XmlDocument

            For Each outerNode As XmlNode In strRetorno
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    If (InnerNode.Name = "verAplic" Or outerNode.Name = "verAplic") Then
                        StrRetNota.verAplic = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cStat" Or outerNode.Name = "cStat") Then
                        StrRetNota.cStat = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "xMotivo" Or outerNode.Name = "xMotivo") Then
                        StrRetNota.xMotivo = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cUF" Or outerNode.Name = "cUF") Then
                        StrRetNota.cUF = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "nRec" Or outerNode.Name = "nRec") Then
                        StrRetNota.nRec = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "dhRecbto" Or outerNode.Name = "dhRecbto") Then
                        StrRetNota.dhRecbto = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "tMed" Or outerNode.Name = "tMed") Then
                        StrRetNota.tMed = InnerNode.InnerText
                    End If
                Next
            Next

            Return StrRetNota
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
            Return Nothing
        End Try
    End Function
    Public Function ConsultaRecLote400(ByVal NAutorizacao As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim CERT As X509Certificate2
        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS
        CERT = SelecionarCertificado("")
        Try
            Dim wsMsg As NFeRetAutorizacaoV4.NFeRetAutorizacao4

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NFeRetAutorizacaoV4.NFeRetAutorizacao4(S_Url.UrlNFeRetAutorizacao400)

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'NOVO PROTOCOLO

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(CERT)

            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument

            'ASSOCIA O NOVO XML COM A VARIAVEL DE RETORNO DA SEFAZ
            dados.LoadXml("<?xml version=""1.0"" encoding=""utf-8""?><consReciNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00""><tpAmb>2</tpAmb><nRec>" & NAutorizacao & "</nRec></consReciNFe>")

            'ENVIA CONSULTA PARA SEFAZ E OBTEM RETORNO EM FORMATO STRING
            strRetorno = wsMsg.nfeRetAutorizacaoLote(dados)

            'DESMEMBRA RETORNO XML
            '-----------------------------------------------------------------------------------
            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno
            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)
            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    VarRecibo.XmlRecibo = InnerNode.OuterXml

                    'SE O NOME DO NO FOR infProt ENTRA NO MESMO
                    If InnerNode.Name = "infProt" Then
                        'PEGA A VARIAVEL ID QUE É UM ATRIBUTO E NAO UM ITEM
                        VarRecibo.Id = "" 'InnerNode.Attributes.ItemOf("Id").InnerText
                        'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                        For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                            If (InnerNode2.Name = "tpAmb") Then
                                VarRecibo.tpAmb = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "verAplic") Then
                                VarRecibo.verAplic = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "dhRecbto") Then
                                VarRecibo.dhRecbto = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "nProt") Then
                                VarRecibo.nProt = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "digVal") Then
                                VarRecibo.digVal = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "cStat") Then
                                VarRecibo.cStat = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "xMotivo") Then
                                VarRecibo.xMotivo = InnerNode2.InnerText
                            End If
                        Next
                        'ADICIONA A NOTA NA LISTA DE RETORNO
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
            Return Nothing
        End Try
    End Function

    Public Function ConsultaStatusWs() As RetRetorno
        Dim strRetorno As XmlElement
        Dim CERT As X509Certificate2
        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS
        CERT = SelecionarCertificado("")
        Try
            Dim wsMsg As NFeStatusServicoV4.NFeStatusServico4

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NFeStatusServicoV4.NFeStatusServico4(S_Url.UrlNfeStatusServico)

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'NOVO PROTOCOLO

            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(CERT)

            'DEFINE PROTOCOLO USADO NA CONEXÃO
            'wsMsg.SoapVersion = SoapProtocolVersion.Soap12

            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument

            'ASSOCIA O NOVO XML COM A VARIAVEL DE RETORNO DA SEFAZ
            dados.LoadXml("<?xml version=""1.0"" encoding=""UTF-8"" ?><consStatServ xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""3.10""><tpAmb>2</tpAmb><cUF>43</cUF><xServ>STATUS</xServ></consStatServ>")

            'ENVIA CONSULTA PARA SEFAZ E OBTEM RETORNO EM FORMATO STRING
            strRetorno = wsMsg.nfeStatusServicoNF(dados)

            'DESMEMBRA RETORNO XML
            '-----------------------------------------------------------------------------------
            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno
            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)
            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    'SE O NOME DO NO FOR infProt ENTRA NO MESMO
                    If InnerNode.Name = "infProt" Then
                        'PEGA A VARIAVEL ID QUE É UM ATRIBUTO E NAO UM ITEM
                        VarRecibo.Id = "" 'InnerNode.Attributes.ItemOf("Id").InnerText
                        'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                        For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                            If (InnerNode2.Name = "tpAmb") Then
                                VarRecibo.tpAmb = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "verAplic") Then
                                VarRecibo.verAplic = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "dhRecbto") Then
                                VarRecibo.dhRecbto = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "digVal") Then
                                VarRecibo.digVal = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "cStat") Then
                                VarRecibo.cStat = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "xMotivo") Then
                                VarRecibo.xMotivo = InnerNode2.InnerText
                            End If
                        Next
                        'ADICIONA A NOTA NA LISTA DE RETORNO
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
            Return Nothing
        End Try
    End Function
    Public Function ConsultaNfe(ByVal IDNFe As String) As RetRetorno
        Dim strRetorno As XmlElement
        Dim CERT As X509Certificate2
        'BUSCA CERTIFICADO SE DEIXAR EM BRANCO ABRE JANELA DE SELEÇÃO DO WINDOWS
        CERT = SelecionarCertificado("")
        Try
            Dim wsMsg As NFeConsultaProtocoloV4.NFeConsultaProtocolo4

            'CRIA UMA INSTANCIA DA CONEXÃO COM O WEBSERVICE
            wsMsg = New NFeConsultaProtocoloV4.NFeConsultaProtocolo4(S_Url.UrlNfeConsultaProtocolo)



            'DEFINE TEMPO MAXIMO DE ESPERA POR RETORNO
            wsMsg.Timeout = 100000

            'ASSOCIA CERTIFICADO A CONEXAO WEBSERVICE
            wsMsg.ClientCertificates.Add(CERT)

            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'NOVO PROTOCOLO

            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument
            dados.LoadXml("<?xml version=""1.0"" encoding=""UTF-8""?><consSitNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00""><tpAmb>2</tpAmb><xServ>CONSULTAR</xServ><chNFe>" & IDNFe & "</chNFe></consSitNFe>")

            'ENVIA CONSULTA PARA SEFAZ E OBTEM RETORNO EM FORMATO STRING
            strRetorno = wsMsg.nfeConsultaNF(dados)

            'DESMEMBRA RETORNO XML
            '-----------------------------------------------------------------------------------
            'VARIAVER QUE VAI RECEBER O RETORNO
            Dim Retornos As New RetRetorno
            'CRIA LISTA PARA RECEBER RETORNOS
            Retornos.L_Retornos = New List(Of RetRecibo)
            'VARIAVEL QUE VAI RECEBER A LISTA ANTES DE SER COLOCADA NO RETORNO
            Dim VarRecibo As New RetRecibo

            'PERCORRE TODOS OS NOS DO XML E PROCURA A TAG DE RETORNO infProt
            For Each outerNode As XmlNode In strRetorno
                'PARA CADA NO VERIFICA SE O MESMO POSSUI FILHOS E VARRE OS MESMOS
                If (outerNode.Name = "tpAmb") Then
                    Retornos.tpAmb = outerNode.InnerText
                End If
                If (outerNode.Name = "verAplic") Then
                    Retornos.verAplic = outerNode.InnerText
                End If
                If (outerNode.Name = "nRec") Then
                    Retornos.nRec = outerNode.InnerText
                End If
                If (outerNode.Name = "cStat") Then
                    Retornos.cStat = outerNode.InnerText
                End If
                If (outerNode.Name = "xMotivo") Then
                    Retornos.xMotivo = outerNode.InnerText
                End If
                If (outerNode.Name = "cUF") Then
                    Retornos.cUF = outerNode.InnerText
                End If
                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    'SE O NOME DO NO FOR infProt ENTRA NO MESMO
                    If InnerNode.Name = "infProt" Then
                        'PEGA A VARIAVEL ID QUE É UM ATRIBUTO E NAO UM ITEM
                        VarRecibo.Id = "" 'InnerNode.Attributes.ItemOf("Id").InnerText
                        'PERCORRE CAMPOS DO RETORNO PARA CAPTURAR AS INFORMAÇÕES
                        For Each InnerNode2 As XmlNode In InnerNode.ChildNodes
                            If (InnerNode2.Name = "tpAmb") Then
                                VarRecibo.tpAmb = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "verAplic") Then
                                VarRecibo.verAplic = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "chNFe") Then
                                VarRecibo.chNFe = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "dhRecbto") Then
                                VarRecibo.dhRecbto = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "digVal") Then
                                VarRecibo.digVal = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "cStat") Then
                                VarRecibo.cStat = InnerNode2.InnerText
                            End If
                            If (InnerNode2.Name = "xMotivo") Then
                                VarRecibo.xMotivo = InnerNode2.InnerText
                            End If
                        Next
                        'ADICIONA A NOTA NA LISTA DE RETORNO
                        Retornos.L_Retornos.Add(VarRecibo)
                    End If
                Next
            Next

            Return Retornos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
            Return Nothing
        End Try
    End Function

    Public Function TransmitirEvento(ByVal CartaCorrecao As String) As RetornoEvento
        Dim strRetorno As XmlElement
        Dim xmldoc = New XmlDocument()

        'Carrega o arquivo XML 
        xmldoc.LoadXml(CartaCorrecao)
        Dim CERT As X509Certificate2
        CERT = SelecionarCertificado("")
        Try
            Dim wsMsg As NFeRecepcaoEventoV4.NFeRecepcaoEvento4

            'CABEÇALHO USADA PARA ENVIO DE LOTE
            wsMsg = New NFeRecepcaoEventoV4.NFeRecepcaoEvento4(S_Url.UrlNfeRecepcaoEvento)

            wsMsg.Timeout = 100000
            wsMsg.ClientCertificates.Add(CERT)
            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'NOVO PROTOCOLO

            'RETORNO DA SEFAZ

            strRetorno = wsMsg.nfeRecepcaoEvento(xmldoc)

            'DESMEMBRA RETORNO XML
            Dim StrRetCarta As RetornoEvento = Nothing
            Dim XmlText As XmlDocument = New XmlDocument

            Dim nodelist As XmlNodeList = strRetorno.ChildNodes


            For Each outerNode As XmlNode In nodelist

                For Each InnerNode As XmlNode In outerNode.ChildNodes
                    If (InnerNode.Name = "versao" Or outerNode.Name = "versao") Then
                        StrRetCarta.versao = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "idLote" Or outerNode.Name = "idLote") Then
                        StrRetCarta.IdLote = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "tpAmb" Or outerNode.Name = "tbAmb") Then
                        StrRetCarta.tpAmb = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "verAplic" Or outerNode.Name = "verAplic") Then
                        StrRetCarta.verAplic = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cOrgao" Or outerNode.Name = "cOrgao") Then
                        StrRetCarta.cOrgao = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "cStat" Or outerNode.Name = "cStat") Then
                        StrRetCarta.cStat = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "xMotivo" Or outerNode.Name = "xMotivo") Then
                        StrRetCarta.xMotivo = InnerNode.InnerText
                    End If
                    If (InnerNode.Name = "retEvento" Or outerNode.Name = "retEvento") Then
                        StrRetCarta.XmlRecibo = outerNode.OuterXml
                        For Each n As XmlNode In InnerNode

                            If (n.Name = "infEvento" Or InnerNode.Name = "infEvento") Then
                                For Each n2 As XmlNode In n
                                    If (n2.Name = "Id" Or n.Name = "Id") Then
                                        StrRetCarta.infEvento.Id = n.InnerText
                                    End If
                                    If (n2.Name = "tpAmb" Or n.Name = "tpAmb") Then
                                        StrRetCarta.infEvento.tpAmb = n.InnerText
                                    End If
                                    If (n2.Name = "verAplic" Or n.Name = "verAplic") Then
                                        StrRetCarta.infEvento.verAplic = n.InnerText
                                    End If
                                    If (n2.Name = "cOrgao" Or n.Name = "cOrgao") Then
                                        StrRetCarta.infEvento.cOrgao = n.InnerText
                                    End If
                                    If (n2.Name = "cStat" Or n.Name = "cStat") Then
                                        StrRetCarta.infEvento.cStat = n.InnerText
                                    End If
                                    If (n2.Name = "xMotivo" Or n.Name = "xMotivo") Then
                                        StrRetCarta.infEvento.xMotivo = n.InnerText
                                    End If
                                    If (n2.Name = "chNFe" Or n.Name = "chNFe") Then
                                        StrRetCarta.infEvento.chNfe = n.InnerText
                                    End If
                                    If (n2.Name = "tpEvento" Or n.Name = "tpEvento") Then
                                        StrRetCarta.infEvento.tpEvento = n.InnerText
                                    End If
                                    If (n2.Name = "xEvento" Or n.Name = "xEvento") Then
                                        StrRetCarta.infEvento.xEvento = n.InnerText
                                    End If
                                    If (n2.Name = "nSeqEvento" Or n.Name = "nSeqEvento") Then
                                        StrRetCarta.infEvento.nSeqEvento = n.InnerText
                                    End If
                                    If (n2.Name = "CNPJDest" Or n.Name = "CNPJDest") Then
                                        StrRetCarta.infEvento.CNPJDest = n.InnerText
                                    End If
                                    If (n2.Name = "CPFDest" Or n.Name = "CPFDest") Then
                                        StrRetCarta.infEvento.CPFDest = n.InnerText
                                    End If
                                    If (n2.Name = "emailDest" Or n.Name = "emailDest") Then
                                        StrRetCarta.infEvento.emailDest = n.InnerText
                                    End If
                                    If (n2.Name = "dhRegEvento" Or n.Name = "dhRegEvento") Then
                                        StrRetCarta.infEvento.dhRetEvento = n.InnerText
                                    End If
                                    If (n2.Name = "nProt" Or n.Name = "nProt") Then
                                        StrRetCarta.infEvento.nProt = n.InnerText
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next

            Return StrRetCarta

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
            Return Nothing
        End Try
    End Function
End Class
