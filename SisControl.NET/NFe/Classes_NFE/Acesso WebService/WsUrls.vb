Module WsUrls
    Public Function BuscaURL(ByVal Sigla As String, ByVal AmbienteNFe As String) As C_WebService.ListaUrl
        Dim UrlWs As C_WebService.ListaUrl = Nothing
        Select Case Sigla
            Case Is = "AC" 'AC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.UrlNfeRecepcaoEvento = "https://hom.sefazvirtual.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"
                    UrlWs.CodigoUF = 12
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.UrlNfeRecepcaoEvento = "https://hom.sefazvirtual.fazenda.gov.br/RecepcaoEvento/RecepcaoEvento.asmx"
                    UrlWs.CodigoUF = 12
                End If
            Case Is = "AL" 'AC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 27
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 27
                End If
            Case Is = "AP" 'AC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 16
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 16
                End If
            Case Is = "BA" 'BA USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hnfe.sefaz.ba.gov.br/webservices/nfenw/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 29
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.ba.gov.br/webservices/nfenw/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 29
                End If
            Case Is = "CE" 'CE USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://nfeh.sefaz.ce.gov.br/nfe2/services/NfeStatusServico2"
                    UrlWs.CodigoUF = 23
                Else
                    UrlWs.UrlNfeRecepcao = ""
                    UrlWs.UrlNfeRetRecepcao = ""
                    UrlWs.UrlNfeCancelamento = ""
                    UrlWs.UrlNfeInutilizacao = ""
                    UrlWs.UrlNfeConsultaProtocolo = ""
                    UrlWs.UrlNfeStatusServico = ""
                    UrlWs.CodigoUF = 23
                End If
            Case Is = "DF" 'DF USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 53
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 53
                End If
            Case Is = "ES" 'ES USA SEFAZ VIRTUAL DO AMBIENTE NACIONAL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hom.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 32
                Else
                    UrlWs.UrlNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://www.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 32
                End If
            Case Is = "GO" 'GO USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://homolog.sefaz.go.gov.br/nfe/services/v2/NfeStatusServico2"
                    UrlWs.CodigoUF = 52
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefaz.go.gov.br/nfe/services/v2/NfeStatusServico2"
                    UrlWs.CodigoUF = 52
                End If
            Case Is = "MA" 'MA USA SEFAZ VIRTUAL DO AMBIENTE NACIONAL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hom.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 21
                Else
                    UrlWs.UrlNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://www.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 21
                End If
            Case Is = "MG" 'MG USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeStatus2"
                    UrlWs.CodigoUF = 31
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeStatus2"
                    UrlWs.CodigoUF = 31
                End If
            Case Is = "MS" 'MS USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.ms.gov.br/homologacao/services2/NfeStatusServico2"
                    UrlWs.CodigoUF = 50
                Else
                    UrlWs.UrlNfeRecepcao = ""
                    UrlWs.UrlNfeRetRecepcao = ""
                    UrlWs.UrlNfeCancelamento = ""
                    UrlWs.UrlNfeInutilizacao = ""
                    UrlWs.UrlNfeConsultaProtocolo = ""
                    UrlWs.UrlNfeStatusServico = ""
                    UrlWs.CodigoUF = 50
                End If
            Case Is = "MT" 'MT USA SEFAZ PROPRIA
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.sefaz.mt.gov.br/nfews/NfeRecepcao2"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.sefaz.mt.gov.br/nfews/NfeRetRecepcao2"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.sefaz.mt.gov.br/nfews/NfeCancelamento2"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.sefaz.mt.gov.br/nfews/NfeInutilizacao2"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.sefaz.mt.gov.br/nfews/NfeConsulta2"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.sefaz.mt.gov.br/nfews/NfeStatusServico2"
                    UrlWs.CodigoUF = 50
                Else
                    UrlWs.UrlNfeRecepcao = ""
                    UrlWs.UrlNfeRetRecepcao = ""
                    UrlWs.UrlNfeCancelamento = ""
                    UrlWs.UrlNfeInutilizacao = ""
                    UrlWs.UrlNfeConsultaProtocolo = ""
                    UrlWs.UrlNfeStatusServico = ""
                    UrlWs.CodigoUF = 50
                End If
            Case Is = "PA" 'PA USA SEFAZ VIRTUAL DO AMBIENTE NACIONAL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hom.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 15
                Else
                    UrlWs.UrlNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://www.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 15
                End If
            Case Is = "PI" 'PA USA SEFAZ VIRTUAL DO AMBIENTE NACIONAL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hom.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 22
                Else
                    UrlWs.UrlNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://www.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 22
                End If
            Case Is = "PB" 'PB USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 25
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 25
                End If
            Case Is = "RJ" 'RJ USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 33
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 33
                End If
            Case Is = "RO" 'RO USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 11
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 11
                End If
            Case Is = "RN" 'RN USA SEFAZ VIRTUAL DO AMBIENTE NACIONAL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://hom.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://hom.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 24
                Else
                    UrlWs.UrlNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NfeRecepcao2/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetRecepcao2/NFeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://www.sefazvirtual.fazenda.gov.br/NFeCancelamento2/NFeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao2/NFeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/nfeconsulta2/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico2/NFeStatusServico2.asmx"
                    UrlWs.CodigoUF = 24
                End If
            Case Is = "RS" 'RS USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeInutilizacao = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx"
                    UrlWs.UrlNfeRecepcaoEvento = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx"
                    UrlWs.UrlNFeAutorizacao400 = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
                    UrlWs.UrlNFeRetAutorizacao400 = "	https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx"

                    UrlWs.CodigoUF = 43
                Else
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefaz.rs.gov.br/ws/Nferecepcao/NFeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefaz.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefaz.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefaz.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefaz.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefaz.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.UrlNfeRecepcaoEvento = "https://homologacao.nfe.sefaz.rs.gov.br/ws/recepcaoevento/recepcaoevento.asmx"
                    UrlWs.UrlNFeAutorizacao400 = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx"
                    UrlWs.UrlNFeRetAutorizacao400 = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeRetAutorizacao.asmx"

                    UrlWs.CodigoUF = 43
                End If
            Case Is = "SC" 'SC USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 42
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 42
                End If
            Case Is = "SE" 'SE USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 28
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 28
                End If
            Case Is = "SP" 'SP USA SEFAZ PROPRIO
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 35
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nferecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nferetrecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nfecancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nfeinutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nfeconsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.fazenda.sp.gov.br/nfeweb/services/nfestatusservico2.asmx"
                    UrlWs.CodigoUF = 35
                End If
            Case Is = "TO" 'TO USA SEFAZ VIRTUAL DO RIO GRANDE DO SUL
                If AmbienteNFe.ToUpper <> "PRODUCAO" Then
                    UrlWs.UrlNfeRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://homologacao.nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 17
                Else
                    UrlWs.UrlNfeRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferecepcao/NfeRecepcao2.asmx"
                    UrlWs.UrlNfeRetRecepcao = "https://nfe.sefazvirtual.rs.gov.br/ws/nferetrecepcao/NfeRetRecepcao2.asmx"
                    UrlWs.UrlNfeCancelamento = "https://nfe.sefazvirtual.rs.gov.br/ws/nfecancelamento/NfeCancelamento2.asmx"
                    UrlWs.UrlNfeInutilizacao = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeinutilizacao/NfeInutilizacao2.asmx"
                    UrlWs.UrlNfeConsultaProtocolo = "https://nfe.sefazvirtual.rs.gov.br/ws/nfeconsulta/NfeConsulta2.asmx"
                    UrlWs.UrlNfeStatusServico = "https://nfe.sefazvirtual.rs.gov.br/ws/nfestatusservico/NfeStatusServico2.asmx"
                    UrlWs.CodigoUF = 17
                End If
        End Select
        Return UrlWs
    End Function

End Module
