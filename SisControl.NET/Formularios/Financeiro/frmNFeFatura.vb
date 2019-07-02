Imports NFe.Utils.Excecoes
Imports SisControl.NET.C_WebService
Imports System.Xml
Imports System.IO
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine


Public Class frmNFeFatura
    Public UrlAcesso As ListaUrl
    Dim Etapa As Integer, Arquivo As String = String.Empty, ChaveNf As String
    Dim Limite As Integer, Lote As String, Protocolo As String, nRec As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btTransmitir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTransmitir.Click
        '* Aqui depois sera colocado o procedimento para pegar o arquivo a partir do doc de saida
        '* por hora vamos selecionar o arquivo gerado nos pedidos

        Dim Arquivo As String, ArqBD As String
        Arquivo = My.Settings.PastaNFe & "\Gerados\"
        'Se houver o nome do arquivo registrado no BD
        ArqBD = DLookup("Arquivo", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("ID").Value)
        If ArqBD.Length > 0 Then
            Arquivo &= ArqBD
            ChaveNf = DLookup("chNFe", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("ID").Value)
        Else
            MsgBox("Nome do arquivo de nota não registrado no Banco de Dados!" & vbCrLf & "Este problema pode ser resolvido gerando o arquivo novamente", MsgBoxStyle.Critical, "Erro")
        End If

        'Checagem dupla para ver se o arquivo exites
        If System.IO.File.Exists(Arquivo) Then
            Dim arqDestino As String = String.Empty
            'Gera o arquivo de destino
            arqDestino = My.Settings.PastaNFe & "\Envio-Simples\" & ArqBD

            'Antes de copiar o arquivo de destino remover todos os retornos da pasta retorno
            Kill(My.Settings.PastaNFe & "\Retorno\*.*")

            'Copia o arquivo
            System.IO.File.Copy(Arquivo, arqDestino)
            'Limpa a janela de retorno de mensagens
            txtMensagem.Text = String.Empty
            'dispara o Timer para aguardar o retorno
            Etapa = 1
            tmrAguarda.Enabled = True
        Else
            'Se não existe
            MsgBox("Arquivo XML da Nota Fiscal nº " & dgNFs.SelectedRows(0).Cells("Documento").Value & " não encontrado!" & vbCrLf & "Gerar o arquivo novamente!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
    End Sub

    Private Sub tmrAguarda_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAguarda.Tick
        If Limite > 30 Then     'Mais de 30 segundos - 1 Tick a cada 1000 milissegundos
            tmrAguarda.Enabled = False
            MsgBox("Erro: Estourou o tempo limite para esta operação", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        Else
            Select Case Etapa
                Case 1  'Assinatura e validação do arquivo
                    fnEtapa1()
                Case 2  'Transmite e verifica se há erro
                    fnEtapa2()
                Case 3  'Pega os dados do lote para localizar o protocolo
                    fnEtapa3()

                    '**** Outra etapa independente da transmissão acima
                Case 10 'Manda para Validação APENAS
                    fnValidaNFe()
                Case 20 'Cancelamento da NF
                    fnCancelaNFe()
                Case 30 'Inutilização de Numeração
                    fnInutilizaNFe()
            End Select
            Limite += 1
        End If
    End Sub

    '* ETAPA 1 - VALIDAÇÃO, ASSINATURA E PRODUCAO DO LOTE PARA ENVIO.
    Private Sub fnEtapa1()
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\" & ChaveNf

        'Verifica se o sistema retornou um erro
        If System.IO.File.Exists(ArquivoBase & "-nfe.err") Then
            'Para o processo e mostra o erro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-nfe.err")
            MsgBox("Erro ao processar o arquivo de lote de NFe!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoBase & "-num-lot.xml") Then
            'Se seu certo a geração do lote
            'Vai aparecer um arquivo assim: 42100907727715000190550010000000051864175410-num-lot.xml

            'Para o cronometro
            tmrAguarda.Enabled = False
            'Zera o limite novamente
            Limite = 0
            'Avisa no quadro de mensagem que o lote foi gerado com sucesso
            txtMensagem.Text &= "Geração do Lote concluída com sucesso!" & vbCrLf

            '*
            '* Desmembra o Retorno do XML do Lote para pegar o número do lote
            '*

            Lote = getInfoLote(ArquivoBase & "-num-lot.xml")

            'Se encontrou algum lote que não seja -1
            If Lote <> -1 Then
                txtMensagem.Text &= "Nº do lote Gerado: " & Lote & vbCrLf
                'Passa para proxima etapa DEU CERTO --> ETAPA 2
                Etapa = 2
                'Reativa o Timer
                tmrAguarda.Enabled = True
                'Limite zerado
                Limite = 0
                'Sai da sub
                Exit Sub
            End If
        End If
    End Sub

    '* ETAPA 2 - NÚMERO DO RECIBO QUE O WEBSERVICE DEVOLVE
    Private Sub fnEtapa2()
        'Dimensiona as variaveis
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\"
        'Cria o string do arquivo base
        ArquivoBase &= Format(Val(Lote), "000000000000000")

        'Verifica os arquivos - Primeiro o arquivo de erro
        If System.IO.File.Exists(ArquivoBase & "-rec.err") Then
            'Para o processo e mostra o erro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-rec.err") & vbCrLf
            MsgBox("Erro ao processar o arquivo de Recibo de lote", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoBase & "-rec.xml") Then
            'Se seu TUDO CERTO então processa o arquivo de recibo
            'Se encontrar desse tipo 000000000000015-rec.xml

            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa no quadro de mensagem que o lote foi gerado com sucesso
            txtMensagem.Text &= "Recibo de NFe localizado com sucesso!" & vbCrLf
            'Processa o arquivo do recibo para pegar o número do recibo
            nRec = getInfoRecibo(ArquivoBase & "-rec.xml")
            'Processa o retorno da funcao - Primeiro se deu ERRO
            If nRec = String.Empty Then
                txtMensagem.Text &= "Erro no processamento do número do recibo!"
                MsgBox("Erro ao processar o arquivo com o número do Recibo!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            Else
                'Informa o número do Recibo
                txtMensagem.Text &= "Nº do Recibo do SEFAZ: " & nRec & vbCrLf
                'Deu certo --> Etapa 3
                Etapa = 3
                tmrAguarda.Enabled = True
                Limite = 0
            End If
        End If
    End Sub

    '* ETAPA 3 - PEGA O ARQUIVO DO RECIBO E VERIFICA OS MOTIVOS DE ACEITE OU DEVOLUÇÃO
    Private Sub fnEtapa3()
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\"

        'Mensagem que aguarda o arquivo do lote
        ArquivoBase &= nRec

        'Se deu erro na geração do arquivo de Protocolo
        If System.IO.File.Exists(ArquivoBase & "-pro-rec.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa do ERRO no quadro de mensagens
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-pro-rec.err") & vbCrLf
            MsgBox("Erro ao processar arquivo de protocolo!", MsgBoxStyle.Critical, "Erro")
            Exit Sub

        ElseIf System.IO.File.Exists(ArquivoBase & "-pro-rec.xml") Then
            'Se encontrar desse tipo 423000007172396-pro-rec.xml
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= "Processando arquivo de protocolo recebido pelo SEFAZ!" & vbCrLf
            Dim RetC As New RetRecibo, SQL As String
            getInfoProtocolo(ArquivoBase & "-pro-rec.xml", RetC)

            If RetC.cStat = "100" Then
                txtMensagem.Text &= "Impressão da DANFE autorizada!"
                btDanfe.Enabled = True

                'Tentat atualizar o banco de dados
                Try
                    'Atualiza os dados do recibo no arquivo da Nota Fiscal
                    SQL = "UPDATE Docs SET "
                    SQL &= "Status=2,"
                    SQL &= "procNFe='" & RetC.nProt & "',"
                    SQL &= "digVal='" & RetC.digVal & "',"
                    SQL &= "DataNFE='" & RetC.dhRecbto.Substring(0, 10) & "',"
                    SQL &= "HoraNFE='" & RetC.dhRecbto.Substring(11, 8) & "'"
                    SQL &= " WHERE id=" & dgNFs.SelectedRows(0).Cells("id").Value

                    Dim itm_atual As Integer
                    itm_atual = dgNFs.CurrentRow.Index

                    'Executa a SQL gerada
                    ExecutaSQL(SQL)
                    If MsgBox("Deseja lançar a NFe no registro de Contas à Receber?", MsgBoxStyle.Question + vbYesNo, "Confirmação") = vbYes Then
                        lanca_contas_receber(dgNFs.SelectedRows(0).Cells("id").Value)
                    End If
                    'Depois de tudo lançado refaz o grid
                    Formata_Grid()
                    'Seleciona a linha que estava antes do grid ser reformulado
                    'dgNFs.Rows(itm_atual).Selected = True
                    'Posiciona no local que estava já selecionado
                    dgNFs.CurrentCell = dgNFs.Rows(itm_atual).Cells(1)
                Catch ex As Exception
                    MsgBox("Erro ao atualizar os dados do Recibo da NFe no banco de dados" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub

                End Try
            Else

            End If
        End If
    End Sub


    '* ETAPA 10 - VALIDAÇÃO DO XML A SER ENVIADO PARA RECEITA ANTES PARA VER SE HÁ ERRO
    Private Sub fnValidaNFe()
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\"

        'Mensagem que aguarda o arquivo do lote
        ArquivoBase &= ChaveNf

        'Se deu erro na geração do arquivo de Protocolo
        If System.IO.File.Exists(ArquivoBase & "-nfe-ret.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa do ERRO no quadro de mensagens
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-nfe-ret.err") & vbCrLf
            MsgBox("Erro ao validar o arquivo da nota fiscal eletrônica!", MsgBoxStyle.Critical, "Erro")
            Exit Sub

        ElseIf System.IO.File.Exists(ArquivoBase & "-nfe-ret.xml") Then
            'Se encontrar desse tipo 42100907727715000190550010000000051753699845-nfe-ret.xml
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= "Processando retorno da Validação:" & vbCrLf
            Dim Retorno As String = getValidacao(ArquivoBase & "-nfe-ret.xml")
            If Retorno = "1" Then
                txtMensagem.Text &= "Validação completa com sucesso: Validado e Assinado!"
            ElseIf Retorno = "2" Then
                txtMensagem.Text &= "Ocorreu um erro ao assinar o arquivo digitalmente!"
            ElseIf Retorno = "3" Or Retorno = "4" Then
                txtMensagem.Text &= "Ocorreu um erro ao validar o aquivo"
            End If
        End If
    End Sub

    '* ETAPA 20 - CANCELALENTO DO XML A SER ENVIADO PARA RECEITA
    Sub fnCancelaNFe()
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\"

        'Mensagem que aguarda o arquivo do lote
        ArquivoBase &= ChaveNf

        'Se deu erro na geração do arquivo de Protocolo
        '42170807727715000190550010000004501492084245-ret-env-canc.err
        If System.IO.File.Exists(ArquivoBase & "-can.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa do ERRO no quadro de mensagens
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-can.err") & vbCrLf
            MsgBox("Erro ao solicitar o cancelamento da nota fiscal eletrônica!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoBase & "-ret-env-canc.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa do ERRO no quadro de mensagens
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-ret-env-canc.err") & vbCrLf
            MsgBox("Erro ao solicitar o cancelamento da nota fiscal eletrônica!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoBase & "-ret-env-canc.xml") Then
            'Se encontrar desse tipo 42101007727715000190550010000000211387406693-can.xml
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= "Processando retorno do Cancelamento:" & vbCrLf
            'Dim RetC As New RetRecibo
            Dim RetC As New RetornoEvento
            getCancelamento(ArquivoBase & "-ret-env-canc.xml", RetC)
            txtMensagem.Text &= "Status do retorno: " & RetC.cStat & vbCrLf
            'Le o retorno do arquivo
            If RetC.cStat = "135" Then      'Cancelamento Homologado
                txtMensagem.Text &= "Evento registrado e vinculado a NF-e" & vbCrLf
                Dim SQL As String, rData As String, rHora As String
                rData = RetC.infEvento.dhRetEvento.Substring(0, 10)
                rHora = RetC.infEvento.dhRetEvento.Substring(11, 8)
                SQL = "UPDATE Docs SET Status=4,DataCancelamento='" & rData & "',HoraCancelamento='" & rHora & "',protCancelamento='" & RetC.infEvento.nProt & "' WHERE id=" & dgNFs.Rows(0).Cells("id").Value
                Try
                    ExecutaSQL(SQL)
                    MsgBox("Cancelamento da NFe nº " & dgNFs.SelectedRows(0).Cells(3).Value & " executado com sucesso.", MsgBoxStyle.Information, "Confirmação")
                    Formata_Grid()
                Catch ex As Exception
                    MsgBox("Erro ao gravar o cancelamento no banco de dados." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    '* ETAPA 30 - INUTILIZA FAIXA DE NUMERAÇÃO PARA NFe
    Sub fnInutilizaNFe()
        Dim ArquivoBase As String = My.Settings.PastaNFe & "\Retorno\"

        'Mensagem que aguarda o arquivo do lote
        ArquivoBase &= ChaveNf

        'Se deu erro na geração do arquivo de Protocolo
        If System.IO.File.Exists(ArquivoBase & "-inu.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            'Avisa do ERRO no quadro de mensagens
            txtMensagem.Text &= Mostra_Erro(ArquivoBase & "-inu.err") & vbCrLf
            MsgBox("Erro ao solicitar a inutilização de número da nota fiscal eletrônica!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoBase & "-inu.xml") Then
            'Se encontrar desse tipo 51080662675686000166550010000001041671821888-inu.xml
            'Para o cronometro
            tmrAguarda.Enabled = False
            Limite = 0
            txtMensagem.Text &= "Processando retorno da Inutilização:" & vbCrLf
            Dim RetC As New RetRecibo
            getInutilizacao(ArquivoBase & "-inu.xml", RetC)

            'Le o retorno do arquivo
            If RetC.cStat = "102" Then      'Inutilização Homologada
                txtMensagem.Text &= vbCrLf & "Consulte: http://www.nfe.fazenda.gov.br/PORTAL/NFeInutilizacao/FormularioDePesquisaInut.aspx" & vbCrLf
                txtMensagem.Text &= "para verificar se a numeração foi inutilizada e imprimir o comprovante." & vbCrLf
                txtMensagem.Text &= vbCrLf & "Protocolo: " & RetC.nProt & vbCrLf
                txtMensagem.Text &= "Data: " & Format(CDate(RetC.dhRecbto.Substring(0, 10)), "dd/MM/yyyy") & " "
                txtMensagem.Text &= "Hora: " & RetC.dhRecbto.Substring(11, 8)
            End If
        End If
    End Sub

    '*
    '* FUNCOES AUXILIARES PARA PEGAR AS INFORMAÇÕES DO XML
    '*

    'Pega a informação do LOTE para a ETAPA 1
    Private Function getInfoLote(ByVal ArquivoXML As String) As Integer

        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument

        'Le o arquivo da XML do Lote Geral
        dados.Load(ArquivoXML)

        'Percorre os nós da XML procurando a informação desejada
        For Each outerNode As XmlNode In dados
            If outerNode.Name = "DadosLoteNfe" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "NumeroLoteGerado" Then
                        'Retorna o valor lido na chave do XML
                        Return Int(Val(InnerNode.ChildNodes(0).InnerText))
                    End If
                Next
            End If
        Next
        'Se não encontrou
        Return -1
    End Function

    '* Le o arquivo de lote e extrai as informações - ETAPA 2
    Private Function getInfoRecibo(ByVal ArquivoXML As String) As String

        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument

        'Le o arquivo da XML do Lote Geral
        dados.Load(ArquivoXML)

        'Percorre os nós da XML procurando a informação desejada
        For Each outerNode As XmlNode In dados
            If outerNode.Name = "retEnviNFe" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "cStat" Then
                        'Retorna o valor lido na chave do XML
                        txtMensagem.Text &= InnerNode.ChildNodes(0).InnerText & " - "
                    End If
                    If InnerNode.Name = "xMotivo" Then
                        'Retorna o motivo
                        txtMensagem.Text &= InnerNode.ChildNodes(0).InnerText & vbCrLf
                    End If
                    If InnerNode.Name = "infRec" Then
                        For Each NoNivel_2 As XmlNode In InnerNode
                            If NoNivel_2.Name = "nRec" Then
                                Return InnerNode.ChildNodes(0).InnerText
                            End If
                        Next
                    End If
                Next
            End If
        Next
        'Se não achou nada
        Return String.Empty
    End Function

    '* Le o arquvo e extrai informações - ETAPA 3
    Private Sub getInfoProtocolo(ByVal ArquivoXML As String, ByRef RetC As Object)
        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument, cStat As String = String.Empty

        'Le o arquivo da XML do Lote Geral
        dados.Load(ArquivoXML)

        'Percorre os nós da XML procurando a informação desejada
        For Each outerNode As XmlNode In dados
            If outerNode.Name = "retConsReciNFe" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "cStat" Then
                        'Retorna o valor lido na chave do XML
                        txtMensagem.Text &= InnerNode.ChildNodes(0).InnerText & " - "
                        If InnerNode.ChildNodes(0).InnerText = "105" Then
                            txtMensagem.Text &= "Lote em Processamento..." & vbCrLf
                            tmrAguarda.Enabled = True
                            Limite += 1
                        End If
                    End If
                    If InnerNode.Name = "xMotivo" Then
                        'Retorna o motivo
                        txtMensagem.Text &= InnerNode.ChildNodes(0).InnerText & vbCrLf
                    End If
                    If InnerNode.Name = "protNFe" Then
                        For Each NoInterno As XmlNode In InnerNode
                            If NoInterno.Name = "infProt" Then
                                For Each Nointerno2 As XmlNode In NoInterno
                                    Select Case Nointerno2.Name
                                        Case "cStat"
                                            txtMensagem.Text &= Nointerno2.ChildNodes(0).InnerText & " - "
                                            RetC.cStat = Nointerno2.ChildNodes(0).InnerText
                                        Case "xMotivo"
                                            txtMensagem.Text &= Nointerno2.ChildNodes(0).InnerText & vbCrLf
                                            RetC.xMotivo = Nointerno2.ChildNodes(0).InnerText
                                        Case "digVal"
                                            RetC.digVal = Nointerno2.ChildNodes(0).InnerText
                                        Case "nProt"
                                            RetC.nProt = Nointerno2.ChildNodes(0).InnerText
                                        Case "dhRecbto"
                                            RetC.dhRecbto = Nointerno2.ChildNodes(0).InnerText
                                        Case "chNFe"
                                            RetC.chNFe = Nointerno2.ChildNodes(0).InnerText
                                        Case "verAplic"
                                            RetC.verAplic = Nointerno2.ChildNodes(0).InnerText
                                        Case "tpAmb"
                                            RetC.tpAmb = Nointerno2.ChildNodes(0).InnerText
                                    End Select
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    '* Le o arquvo e extrai informações - ETAPA 10
    Private Function getValidacao(ByVal ArquivoXML As String) As String
        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument
        Dim Ret As String = String.Empty

        'Le o arquivo da XML do Lote Geral
        dados.Load(ArquivoXML)

        'Percorre os nós da XML procurando a informação desejada
        For Each NoNivel1 As XmlNode In dados
            If NoNivel1.Name = "Validacao" Then
                For Each NoNivel2 As XmlNode In NoNivel1
                    If NoNivel2.Name = "cStat" Then
                        'Retorna o valor lido na chave do XML
                        Ret = Int(Val(NoNivel2.ChildNodes(0).InnerText))
                    End If
                    If NoNivel2.Name = "xMotivo" Then
                        'Retorno do motivo
                        txtMensagem.Text = NoNivel2.ChildNodes(0).InnerText & vbCrLf
                    End If
                Next
            End If
        Next
        'Se não encontrou
        Return Ret
    End Function

    '* Le o arquivo e extrai informaçõex do cancelamento - ETAPA 20
    Private Function getCancelamento(ByVal ArquivoXML As String, ByRef RetC As RetornoEvento) As String
        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument
        Dim Ret As String = String.Empty

        'Le o arquivo da XML do Lote Geral
        dados.Load(ArquivoXML)
        'Percorre os nós da XML procurando a informação desejada
        For Each NoNivel1 As XmlNode In dados
            If NoNivel1.Name = "retEnvEvento" Then
                For Each NoNivel2 As XmlNode In NoNivel1
                    Select Case NoNivel2.Name
                        Case "idLote"
                            RetC.IdLote = NoNivel2.ChildNodes(0).InnerText
                            txtMensagem.Text &= NoNivel2.Name & " - " & NoNivel2.ChildNodes(0).InnerText & vbCrLf
                        Case "retEvento"
                            For Each NoNivel3 As XmlNode In NoNivel2
                                If NoNivel3.Name = "infEvento" Then
                                    For Each NoNivel4 As XmlNode In NoNivel3
                                        Select Case NoNivel4.Name
                                            Case "tpAmb"
                                                RetC.tpAmb = NoNivel4.ChildNodes(0).InnerText
                                                txtMensagem.Text &= NoNivel4.Name & " - " & NoNivel4.ChildNodes(0).InnerText & vbCrLf
                                            Case "verAplic"
                                                RetC.verAplic = NoNivel4.ChildNodes(0).InnerText
                                                txtMensagem.Text &= NoNivel4.Name & " - " & NoNivel4.ChildNodes(0).InnerText & vbCrLf
                                            Case "cOrgao"
                                                RetC.cOrgao = NoNivel4.ChildNodes(0).InnerText
                                                txtMensagem.Text &= NoNivel4.Name & " - " & NoNivel4.ChildNodes(0).InnerText & vbCrLf
                                            Case "cStat"
                                                RetC.cStat = NoNivel4.ChildNodes(0).InnerText
                                                txtMensagem.Text &= NoNivel4.Name & " - " & NoNivel4.ChildNodes(0).InnerText & vbCrLf
                                            Case "xMotivo"
                                                RetC.xMotivo = NoNivel4.ChildNodes(0).InnerText
                                                txtMensagem.Text &= NoNivel4.Name & " - " & NoNivel4.ChildNodes(0).InnerText & vbCrLf
                                        End Select
                                    Next
                                End If
                            Next
                    End Select
                Next
            End If
        Next

        'Se não encontrou
        Return Ret
    End Function

    '* Le o arquivo e extrai informações da Inutilização - ETAPA 30
    Private Function getInutilizacao(ByVal arquivoXML As String, ByRef RetC As Object) As String
        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument
        Dim Ret As String = String.Empty

        'Le o arquivo da XML do Lote Geral
        dados.Load(arquivoXML)

        'Percorre os nós da XML procurando a informação desejada
        For Each NoNivel1 As XmlNode In dados
            If NoNivel1.Name = "retInutNFe" Then
                For Each NoNivel2 As XmlNode In NoNivel1
                    If NoNivel2.Name = "infInut" Then
                        For Each NoNivel3 As XmlNode In NoNivel2
                            Select Case NoNivel3.Name
                                Case "tpAmb"
                                    RetC.tpamb = NoNivel3.ChildNodes(0).InnerText
                                Case "verAplic"
                                    RetC.verAplic = NoNivel3.ChildNodes(0).InnerText
                                Case "cStat"
                                    txtMensagem.Text &= NoNivel3.ChildNodes(0).InnerText & " - "
                                    RetC.cstat = NoNivel3.ChildNodes(0).InnerText
                                    Ret = NoNivel3.ChildNodes(0).InnerText
                                Case "xMotivo"
                                    txtMensagem.Text &= NoNivel3.ChildNodes(0).InnerText & vbCrLf
                                    RetC.xmotivo = NoNivel3.ChildNodes(0).InnerText
                                Case "cUF"
                                Case "ano"
                                Case "CNPJ"
                                Case "mod"
                                Case "serie"
                                Case "nNFIni"
                                Case "nNFFin"
                                Case "dhRecbto"
                                    RetC.dhrecbto = NoNivel3.ChildNodes(0).InnerText
                                Case "nProt"
                                    RetC.nProt = NoNivel3.ChildNodes(0).InnerText
                            End Select
                        Next
                    End If
                Next
            End If
        Next
        'Se não encontrou
        Return Ret
    End Function

    '* Rotina que le o arquivo .ERR e devolve seu texto
    Function Mostra_Erro(ByVal Arquivo As String) As String
        'Cria as variáveis
        Dim fluxoTexto As IO.StreamReader
        Dim linhaTexto As String, vRetorno As String = String.Empty

        If IO.File.Exists(Arquivo) Then
            'Faz a leitura do arquivo
            fluxoTexto = New IO.StreamReader(Arquivo)
            'Le linha por linha
            linhaTexto = fluxoTexto.ReadLine
            While linhaTexto <> Nothing
                vRetorno &= linhaTexto & vbCrLf
                'Tenta pegar a proxima linha
                linhaTexto = fluxoTexto.ReadLine
            End While
            'Fecha fluxo de texto
            fluxoTexto.Close()
            Return vRetorno
        Else
            MsgBox("Arquivo de erro não encontrado", MsgBoxStyle.Critical, "Erro")
            'Se não achou nada retorna vazio
            Return String.Empty
        End If
        'Se não achou nada retorna vazio
        Return String.Empty
    End Function

    Private Sub frmFaturaNFe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Sincroniza a cor dos Labels da Legenda, Com as cores definidas nas Configurações.
        lblCORDigitada.BackColor = Cor_Digitada
        lblCORGerada.BackColor = Cor_Gerada
        lblCORImpressa.BackColor = Cor_Danfe
        lblCORTransmitida.BackColor = Cor_Transmitida
        lblCORCancelada.BackColor = Cor_Cancelada
        lblCORInutilizada.BackColor = Cor_Inutilizada

        'Limpa os ítens do ComboBox
        cmbAno.Items.Clear()
        'Preenche o ComboBox com as datas
        For ano As Integer = 2010 To Year(Now())
            cmbAno.Items.Add(ano)
        Next
        'Coloca como padrão o ano atual
        cmbAno.Text = Year(Now())

        dgNFs.RowsDefaultCellStyle.BackColor = Color.White
        dgNFs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Formata_Grid()
    End Sub

    '*
    '*  PROCEDIMENTOS DOS BOTOES
    '*

    '* VALIDAÇÃO DO XML
    Private Sub btValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btValidar.Click

        Dim Arquivo As String, ArqBD As String
        Arquivo = My.Settings.PastaNFe & "\Gerados\"

        'Limpa o campo de mensagens
        txtMensagem.Text = String.Empty

        'Se houver o nome do arquivo registrado no BD
        ArqBD = DLookup("Arquivo", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("ID").Value)
        If ArqBD.Length > 0 Then
            Arquivo &= ArqBD
            ChaveNf = DLookup("chNFe", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("ID").Value)
        Else
            MsgBox("Nome do arquivo de nota não registrado no Banco de Dados!" & vbCrLf & "Este problema pode ser resolvido gerando o arquivo novamente", MsgBoxStyle.Critical, "Erro")
        End If

        'Checagem dupla para ver se o arquivo exites
        If System.IO.File.Exists(Arquivo) Then
            Dim arqDestino As String = String.Empty
            'Gera o arquivo de destino
            arqDestino = My.Settings.PastaNFe & "\Validar\" & ArqBD
            'Copia o arquivo
            System.IO.File.Copy(Arquivo, arqDestino)
            'dispara o Timer para aguardar o retorno
            Etapa = 10
            tmrAguarda.Enabled = True
        Else
            MsgBox("Arquivo correspondente à Nota Fiscal não foi encontrado!" & vbCrLf & "Esse problema pode ser resolvido gerando-se o arquivo novamente.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
    End Sub

    '* GERACAO DO XML
    Private Sub btGerarXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGerarXML.Click
        'Gera O arquivo XML baseado na nota fiscal

        'Verifica se o usuário clicou em alguma nota
        If dgNFs.SelectedRows.Count <= 0 Then
            MsgBox("Não há nota selecionada. Antes de gerar o arquivo selecione uma NF.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        'Se clicou então pode executar as tarefas para geração
        'Pega o ID da nota fiscal
        Dim varID As String = dgNFs.SelectedRows(0).Cells("id").Value.ToString, SQL As String
        Dim DT As DataTable
        Dim _dhSaiEnt As DateTime


        'Pega os dados da nota
        SQL = "SELECT * FROM Docs WHERE id=" & varID
        Try
            DT = SQLQuery(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar os dados da Nota Fiscal!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        ' Caso contrario tenta montar a NF
        Try
            Dim Versao_Lay_Out As String = "4.00"

            'Cria a variável para incluir os dados no XML
            'Versão do lay out XML
            Dim XMLPed As New NFe With {
                .versao = Versao_Lay_Out
            }

            XMLPed.infNFE.Ide.cUF = 42 'CÓDIGO IBGE UF DO EMITENTE

            'GERA NUMERO ALEATÓRIO caso seja uma nota nova, se o arquivo já existir pego o existente
            If DT.Rows(0).Item("Arquivo").ToString.Length > 0 Then
                XMLPed.infNFE.Ide.cNF = DT.Rows(0).Item("chNFe").ToString.Substring(35, 8)
            Else
                XMLPed.infNFE.Ide.cNF = String.Format("{0:00000000}", RandomNumber(99999999, 9))
            End If

            With DT.Rows(0)

                _dhSaiEnt = DateTime.Parse(.Item("Data") & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second)

                XMLPed.infNFE.Ide.natOp = .Item("NatOP")                            'Natureza da Operação (Descrição)
                'XMLPed.infNFE.Ide.indPag = IIf(.Item("FormaPgto") = "1", "0", "1")  '0 – pagamento à vista; 1 – pagamento à prazo; 2 - outros.
                XMLPed.infNFE.Ide.[mod] = "55"                                      'Modelo 55 em substituicao ao bloco Série 1
                XMLPed.infNFE.Ide.serie = My.Settings.NFeSerie                      'Série da NFe
                XMLPed.infNFE.Ide.nNF = Val(.Item("Documento"))                     'Numero sequencial das notas
                XMLPed.infNFE.Ide.dhEmi = HoraFormatoUTC(DateTime.Now)              'Na NFe 3.1 o formato da data foi unificado
                XMLPed.infNFE.Ide.dhSaiEnt = HoraFormatoUTC(_dhSaiEnt)              'Data da Entrada/Saida
                XMLPed.infNFE.Ide.tpNF = .Item("TipoDOC")                           '1- Saída, 0-Entrada
                'Item novo na versão 3.1
                XMLPed.infNFE.Ide.idDest = IIf(.Item("Estado") = "SC", 1, 2)        '1 = Op Interna, 2 = Op Externa, 3 = Op Exterior
                XMLPed.infNFE.Ide.cMunFG = 4209102                                  'CÓDIGO IBGE MUNICIPIO DO EMITENTE
                XMLPed.infNFE.Ide.tpImp = 1                                         '1-Retrato, 2-Paisagem
                XMLPed.infNFE.Ide.tpEmis = "1"                                      '1–Normal, 2–Contingência FS, 3–Contingência SCAN, 4–Contingência DPEC, 5–Contingência FS-DA
                XMLPed.infNFE.Ide.tpAmb = My.Settings.NFeAmbiente                   '1-Produção 2-Homologação
                XMLPed.infNFE.Ide.finNFe = .Item("Tipo")                            '1- NF-e normal/ 2-NF-e complementar / 3 – NF-e de ajuste / 4- Devolução
                'Item novo na versão 3.1
                If .Item("indIEDest") = 9 Then                                          '9 - Consumidor Final sem Inscrição Estadual
                    XMLPed.infNFE.Ide.indFinal = 1                                      '0 = Normal, 1 = Consumidor Final
                Else
                    XMLPed.infNFE.Ide.indFinal = 0                                      '0 = Normal, 1 = Consumidor Final
                End If
                'Item novo na versão 3.1 (Verificar se é nota de Ajuste ou Devolução)
                If XMLPed.infNFE.Ide.finNFe = 1 Then                               ' Se for venda normal, preenche 
                    XMLPed.infNFE.Ide.indPres = .Item("indPres")
                Else                                                                ' Senão preenche com ZERO (Não se aplica)
                    XMLPed.infNFE.Ide.indPres = 0
                End If
                XMLPed.infNFE.Ide.procEmi = "0"                                     '0 emissão de NF-e com aplicativo do contribuinte;
                XMLPed.infNFE.Ide.verProc = Versao_Lay_Out                          'Versão do emissor
                txtMensagem.Text &= "Cabecalho da Nota...[ OK ]" & vbCrLf

                '*
                '* DADOS DO EMITENTE
                '*
                XMLPed.infNFE.Emit.CNPJ = E_CNPJ                                    'CNPJ DA EMPRESA
                'Verifica se é Produção ou Homologação
                If XMLPed.infNFE.Ide.tpAmb = 1 Then                                 'Se for Em 1=Produção
                    XMLPed.infNFE.Emit.xNome = E_RAZAO                                  'Razão Social
                    XMLPed.infNFE.Emit.xFant = E_RAZAO
                Else                                                                'Se for Em 2=Homologação
                    'Na NFe 3.1 a Razão Social é obrigatóriamente esta para ambiente de Homologação
                    XMLPed.infNFE.Emit.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                    XMLPed.infNFE.Emit.xFant = XMLPed.infNFE.Emit.xNome
                End If

                XMLPed.infNFE.Emit.IE = E_IE                                        'IE DA EMPRESA

                Dim _codUF As String = XMLPed.infNFE.Ide.cUF.ToString()
                Dim _dEmi As String = XMLPed.infNFE.Ide.dhEmi.Substring(2, 2) & XMLPed.infNFE.Ide.dhEmi.Substring(5, 2)      ' ano e mes da NFe YYMM
                Console.WriteLine(_dEmi)
                Dim _cnpj As String = funcoesNfe.removeFormatacao(XMLPed.infNFE.Emit.CNPJ)
                Dim _mod As String = XMLPed.infNFE.Ide.[mod]

                Dim _serie As String = String.Format("{0:000}", Int32.Parse(XMLPed.infNFE.Ide.serie))
                Dim _numNF As String = String.Format("{0:000000000}", Int32.Parse(XMLPed.infNFE.Ide.nNF))
                Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(XMLPed.infNFE.Ide.cNF))
                Dim chaveNF As String = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + XMLPed.infNFE.Ide.tpEmis + _codigo
                Dim _dv As Integer = funcoesNfe.modulo11(chaveNF)

                XMLPed.Id = chaveNF + _dv.ToString()
                XMLPed.infNFE.Ide.cDV = _dv.ToString()

                '*
                '*  DADOS DO EMISSOR
                '*
                XMLPed.infNFE.Emit.EnderEmit.xLgr = E_ENDERECO              'Logradouro
                XMLPed.infNFE.Emit.EnderEmit.nro = E_NUM                    'Número
                XMLPed.infNFE.Emit.EnderEmit.xBairro = E_BAIRRO             'Bairro  
                XMLPed.infNFE.Emit.EnderEmit.cMun = 4209102                 'Código do Municipio
                XMLPed.infNFE.Emit.EnderEmit.xMun = E_CIDADE                'Municipio
                XMLPed.infNFE.Emit.EnderEmit.UF = E_UF                      'Estado
                XMLPed.infNFE.Emit.EnderEmit.CEP = E_CEP                    'CEP
                XMLPed.infNFE.Emit.EnderEmit.cPais = 1058                   'Cód Pais
                XMLPed.infNFE.Emit.EnderEmit.xPais = "BRASIL"               'Pais
                XMLPed.infNFE.Emit.EnderEmit.fone = E_FONE                  'Fone Emitente
                XMLPed.infNFE.Emit.CRT = 1                                  'Código de Regime Tributário (1 = Simples Nacional)
                txtMensagem.Text &= "Dados do Emitente...[ OK ]" & vbCrLf

                '*
                '*  DADOS DO CLIENTE (DESTINATÁRIO)
                '*
                If .Item("pfpj") = "J" Then
                    XMLPed.infNFE.Dest.CNPJ = funcoesNfe.removeFormatacao(.Item("CNPJ_CPF"))   'CNPJ CLIENTE
                ElseIf .Item("pfpj") = "F" Then
                    XMLPed.infNFE.Dest.CPF = funcoesNfe.removeFormatacao(.Item("CNPJ_CPF"))    'CPF do cliente
                End If

                If XMLPed.infNFE.Ide.tpAmb = 1 Then                                 'Em Ambiente de 1=Produção usa o nome correto
                    XMLPed.infNFE.Dest.xNome = .Item("Cliente")                     'Nome do Cliente
                Else
                    'Exigência da NFe em ambiente de homologação o nome do Destinatário tem que ser esse
                    XMLPed.infNFE.Dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                End If

                ' *** GRUPO enderDest ***
                XMLPed.infNFE.Dest.EnderDest.xLgr = .Item("Endereco")               'Endereco
                XMLPed.infNFE.Dest.EnderDest.nro = .Item("Num")                     'Num
                XMLPed.infNFE.Dest.EnderDest.xBairro = .Item("Bairro")              'Bairro
                XMLPed.infNFE.Dest.EnderDest.cMun = .Item("CodCidade")              'Cod Cidade
                XMLPed.infNFE.Dest.EnderDest.xMun = .Item("Cidade")                 'Cidade
                XMLPed.infNFE.Dest.EnderDest.UF = .Item("Estado")                   'Estado
                XMLPed.infNFE.Dest.EnderDest.CEP = removeFormatacao(.Item("CEP"))   'CEP
                XMLPed.infNFE.Dest.EnderDest.cPais = .Item("CodPais")               'Cod Pais
                XMLPed.infNFE.Dest.EnderDest.xPais = .Item("Pais")                  'Pais
                XMLPed.infNFE.Dest.EnderDest.fone = funcoesNfe.removeFormatacao(E_Vazio_Nulo(.Item("Fone")))     'IIf(IsDBNull(.Item("Fone")), "", removeFormatacao(.Item("Fone"))) 'Telefone

                ' INFORMAÇÕES ADICIONAIS
                XMLPed.infNFE.Dest.indIEDest = .Item("indIEDest")                   'Situação do Contribuinte ICMS
                If .Item("indIEDest").ToString.Substring(0, 1) = "1" Then           'Se for 1 (Contribuinte)
                    XMLPed.infNFE.Dest.IE = removeFormatacao(.Item("Inscricao"))    'Inscricao Estadual
                    'Não cria o campo da Inscrição estadual
                End If
                'Caso seja 2 (Isento) ou 9 (Não contribuinte), não gera Inscrição Estadual
                XMLPed.infNFE.Dest.email = E_Vazio_Nulo(.Item("email"))             'Email

                txtMensagem.Text &= "Dados do Cliente...[ OK ]" & vbCrLf

                '*
                '* DETALHAMENTO DOS ÍTENS DA NOTA
                '*

                Dim DTItens As DataTable
                SQL = "SELECT * FROM Docs_itens WHERE Doc_ID=" & varID
                Dim i As Integer
                Dim _vFreteIND As Double

                'Pega os itens da nota
                Try
                    DTItens = SQLQuery(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar recuperar os ítens da Nota Fiscal" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try

                '** Prepara para os totais que serão necessários no ICMS TOTAL
                Dim _vTOT_FCPUFDest As Double = 0
                Dim _vTOT_vICMSUFDest As Double = 0
                Dim _vTOT_vICMSUFRemet As Double = 0

                'Circula entre os vários ítens do pedido
                For i = 0 To DTItens.Rows.Count - 1
                    'DETALHAMENTO DE PLANTAS

                    '* Produto XX
                    Dim detalhamento As New det()
                    With DTItens.Rows(i)
                        detalhamento.nItem = i + 1
                        detalhamento.Prod.cProd = Format(Val(.Item("CodPro")), "000") & "." & Format(Val(.Item("Clone")), "0000")
                        detalhamento.Prod.cEAN = ""                                 'Código EAN
                        detalhamento.Prod.cEANTrib = ""                             'Cód Trib EAN
                        detalhamento.Prod.xProd = .Item("Descricao")                'Descricao
                        detalhamento.Prod.NCM = .Item("NCM")                        'NCM
                        detalhamento.Prod.CFOP = .Item("cfop")                      'CFOP
                        detalhamento.Prod.uCom = .Item("Unid")                      'Unidade
                        detalhamento.Prod.qCom = .Item("Quantidade")                'Quantidade
                        detalhamento.Prod.vUnCom = .Item("Unitario")                'Unitário
                        detalhamento.Prod.vProd = .Item("Total")                    'Total do Iten
                        detalhamento.Prod.uTrib = .Item("unid")                     'Unidade Tributada
                        'Se houver frete na nota
                        If DT.Rows(0).Item("vFrete") > 0 Then
                            'tem que detalhar o frete também
                            'Para isso detalha-se o cálculo do frete da seguinte forma
                            'Divide-se o valor proporcional do frete pelos produtos
                            _vFreteIND = DT.Rows(0).Item("vFrete") / DT.Rows(0).Item("NMudas") * .Item("Quantidade")
                            detalhamento.Prod.vFrete = _vFreteIND
                        End If
                        'detalhamento.Prod.qTrib = .Item("Quantidade")               'Quantidade Tributada
                        detalhamento.Prod.qTrib = detalhamento.Prod.qCom
                        'detalhamento.Prod.vUnTrib = .Item("Unitario")               'Valor da unidade tributada
                        detalhamento.Prod.vUnTrib = detalhamento.Prod.vUnCom         'Valor da unidade tributada
                        detalhamento.Prod.indTot = 1                                 '0–valor do item (vProd) compõe o valor total da NF-e, 1–o valor do item (vProd) não compõe o valor total da NF-e
                    End With

                    '*
                    '* IMPOSTOS POR ÍTEM
                    '*

                    '*
                    '* ICMS
                    '*
                    detalhamento.Imposto.Icms = New ICMS()

                    '** Na Versão 3.1 agora tem diferença entre consumidor final e Contribuinte
                    ' Se o indIEDest = 1 ou 2 - ICMSSN101 
                    ' Se o indIEDest = 9 - ICMSSN102
                    If .Item("indIEDest") = 9 Then                                  'Indica operação com consumidor final
                        'Indica operação com Não contribuinte
                        detalhamento.Imposto.Icms.ICMSSN102 = New ICMSSN102()
                        With detalhamento.Imposto.Icms.ICMSSN102
                            .orig = 0       '0 - Nacional, 1 - Importada, 2 - Importada adquirida no mercado interno
                            .CSOSN = 102    '102 - Tributada pelo Simples Nacional
                        End With
                    Else                                                            'Se for Inscrito ou Isento Fica com esse
                        detalhamento.Imposto.Icms.ICMSSN101 = New ICMSSN101()

                        'Pega a aliquita no banco de dados
                        Dim varAliquota As Double
                        varAliquota = CDbl(DLookup("valor", "parametros", "nome='NFEAliquota'"))

                        With detalhamento.Imposto.Icms.ICMSSN101
                            .orig = 0       '0 - Nacional, 1 - Importada, 2 - Importada adquirida no mercado interno
                            .CSOSN = 101    '101 - Tributada pelo Simples Nacional com permissão de Crédito
                            .pCredSN = Transforma_Valor(Format(varAliquota, "N2"))
                            .vCredICMSSN = Format(detalhamento.Prod.vProd * varAliquota / 100, "N2").Replace(",", ".")  'O crédito é calculado depois do total da nota
                        End With
                    End If

                    '*
                    '* PIS
                    '*

                    detalhamento.Imposto.Pis = New PIS()
                    detalhamento.Imposto.Pis.PisNT = New PISNT

                    'Para optantes pelo SIMPLES o PIS é não Tributável
                    detalhamento.Imposto.Pis.PisNT.CST = "08"

                    '*
                    '* COFINS
                    '*

                    detalhamento.Imposto.Cofins = New COFINS()
                    detalhamento.Imposto.Cofins.CofinsNT = New COFINSNT

                    'Para optantes pelo simples o COFINS não é Tributável
                    detalhamento.Imposto.Cofins.CofinsNT.CST = "08"

                    '*
                    '* DIFAL -  Cálculo Diferencial de Alíquota Exige estes campos para operação interestadual
                    '*          Por decisão legal atualmente estes campos são Zerados pois não é necessário pagamento
                    '*
                    '* Calculado apenas se for Não Contribuinte Fora do Estado
                    If (.Item("indIEDest") = 9) And (.Item("Estado") <> E_UF) Then                             ' Se o estado destino for diferente do estado Origem
                        ' Acrescenta um novo grupo de imposto
                        detalhamento.Imposto.ICMSUFDest = New ICMSUFDest

                        'Acrescenta os detalhes de alíquota
                        With DTItens.Rows(i)
                            'Recupera no banco de dados a tabela das Aliquotas
                            Dim DIF As DataRow = DLookupRow("difal", "UFDest='" & XMLPed.infNFE.Dest.EnderDest.UF & "'")
                            If IsNothing(DIF) Then
                                MsgBox("Erro ao recuperar as alíquotas de imposto no Banco de dados")
                                Exit Sub
                            End If
                            ' Como no Simples ainda não precisa pagar, zera-se a base de cálculo
                            '******* Zerado por conta da Legislação *********
                            detalhamento.Imposto.ICMSUFDest.vBCUFDest = 0
                            detalhamento.Imposto.ICMSUFDest.pFCPUFDest = DIF("pFCPUFDest")      ' Percentual máximo de 2%, conforme a legislação.
                            detalhamento.Imposto.ICMSUFDest.pICMSUFDest = DIF("pICMSUFDest")    ' Alíquota adotada nas operações internas na UF de destino para o produto
                            detalhamento.Imposto.ICMSUFDest.pICMSInter = DIF("pICMSInter")      ' Alíquota interestadual das UF envolvidas
                            ' Percentual de ICMS Interestadual para a UF de destino: 40% em 2016; 60% em 2017; 80% em 2018; 100% a partir de 2019
                            If Year(Now()) = 2017 Then
                                detalhamento.Imposto.ICMSUFDest.pICMSInterPart = 60
                            ElseIf Year(Now()) = 2018 Then
                                detalhamento.Imposto.ICMSUFDest.pICMSInterPart = 80
                            ElseIf Year(Now()) >= 2019 Then
                                detalhamento.Imposto.ICMSUFDest.pICMSInterPart = 100
                            End If

                            '******* Zerado por Conta da Legislação *********
                            'Calcula a partilha preenchendo os campos restantes (Calculados)
                            'vFCPUFDest | vICMSUFDest | vICMSUFRemet
                            detalhamento.Imposto.ICMSUFDest.Calcula_Partilha()
                            ' Acumula os valores para totalizar o Imposto Partilhado no resumo da NFe
                            _vTOT_FCPUFDest += detalhamento.Imposto.ICMSUFDest.vFCPUFDest
                            _vTOT_vICMSUFDest += detalhamento.Imposto.ICMSUFDest.vICMSUFDest
                            _vTOT_vICMSUFRemet += detalhamento.Imposto.ICMSUFDest.vICMSUFRemet
                        End With
                    End If

                    '*
                    '* Acrescenta o detalhamento de Imposto ao XML Global da Nota
                    '*

                    XMLPed.infNFE.Det.Add(detalhamento)
                Next
                txtMensagem.Text &= "Dados dos Itens...[ OK ]" & vbCrLf

                '*
                '*  FECHAMENTO DA NOTA FISCAL GRUPO ICMStot
                '*
                'Pega as variáveis chave
                Dim _vProd As Double = .Item("vProd")
                Dim _vFrete As Double = .Item("vFrete")
                Dim _vSeg As Double = .Item("vSeg")
                Dim _vDesc As Double = .Item("vDesc")
                Dim _vNF As Double = _vProd + _vFrete + _vSeg - _vDesc

                XMLPed.infNFE.Total = New total()
                XMLPed.infNFE.Total.IcmsTot = New ICMSTot()
                XMLPed.infNFE.Total.IcmsTot.vBC = 0                             'Base de Calculo
                XMLPed.infNFE.Total.IcmsTot.vICMSDeson = 0                      'ICMS Desonerado
                If (.Item("indIEDest") = 9) And (.Item("Estado") <> E_UF) Then
                    '************ Tudo Zerado em Função da Legislação Vigente
                    XMLPed.infNFE.Total.IcmsTot.vFCPUFDest = _vTOT_FCPUFDest        'Fundo Combate Pobreza Destino
                    XMLPed.infNFE.Total.IcmsTot.vICMSUFDest = _vTOT_vICMSUFDest     'ICMS do Estado Destino
                    XMLPed.infNFE.Total.IcmsTot.vICMSUFRemet = _vTOT_vICMSUFRemet   'ICMS do Estado Origem
                    '************
                End If
                XMLPed.infNFE.Total.IcmsTot.vBCST = 0                           'Base Calc Subst Tributaria
                XMLPed.infNFE.Total.IcmsTot.vST = 0                             'Situação Tributaria
                XMLPed.infNFE.Total.IcmsTot.vProd = _vProd                      'Total de Produtos
                XMLPed.infNFE.Total.IcmsTot.vFrete = _vFrete                    'Total do Frete
                XMLPed.infNFE.Total.IcmsTot.vSeg = _vSeg                        'Seguro
                XMLPed.infNFE.Total.IcmsTot.vDesc = _vDesc                      'Desconto
                XMLPed.infNFE.Total.IcmsTot.vII = 0                             'Valor total o Imposto Importação
                XMLPed.infNFE.Total.IcmsTot.vIPI = 0                            'IPI
                XMLPed.infNFE.Total.IcmsTot.vPIS = 0                            'PIS
                XMLPed.infNFE.Total.IcmsTot.vCOFINS = 0                         'Cofins
                XMLPed.infNFE.Total.IcmsTot.vOutro = 0                          'Outras Despesas Acessorias
                XMLPed.infNFE.Total.IcmsTot.vNF = _vNF                          'Total da Nota
                txtMensagem.Text &= "Dados do Fechamento...[ OK ]" & vbCrLf

                '*
                '* DADOS DO TRANSPORTE
                '*

                XMLPed.infNFE.Transp = New transp()
                XMLPed.infNFE.Transp.modFrete = .Item("ModFr")
                XMLPed.infNFE.Transp.Transporta = New transporta()
                If .Item("Transportadora").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Transporta.xNome = .Item("Transportadora")
                    If .Item("traCNPJ").ToString.Length > 0 Then
                        XMLPed.infNFE.Transp.Transporta.CNPJ = removeFormatacao(.Item("traCNPJ"))
                    End If
                    If .Item("traIE").ToString.Length > 0 Then
                        XMLPed.infNFE.Transp.Transporta.IE = removeFormatacao(.Item("traIE"))
                    End If
                    If .Item("veiPlaca").ToString.Length > 0 Then
                        XMLPed.infNFE.Transp.VeicTransp = New veicTransp()
                        XMLPed.infNFE.Transp.VeicTransp.placa = removeFormatacao(.Item("veiPLaca"))
                        XMLPed.infNFE.Transp.VeicTransp.UF = .Item("veiUF")
                    End If
                End If
                If .Item("traEndereco").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Transporta.xEnder = .Item("traEndereco")
                End If
                If .Item("traMunicipio").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Transporta.xMun = .Item("traMunicipio")
                End If
                If .Item("traUF").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Transporta.UF = .Item("traUF")
                End If
                If .Item("traQtde").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Vol = New vol
                    XMLPed.infNFE.Transp.Vol.qVol = .Item("traQtde")
                End If
                If (.Item("PesoBruto") > 0) And (.Item("PesoLiquido") > 0) Then
                    XMLPed.infNFE.Transp.Vol.pesoB = Format(.Item("PesoBruto"), "N3")
                    XMLPed.infNFE.Transp.Vol.pesoL = Format(.Item("PesoLiquido"), "N3")
                    Console.WriteLine("PesoL:   " & XMLPed.infNFE.Transp.Vol.pesoL & " PesoB: " & XMLPed.infNFE.Transp.Vol.pesoB)
                End If
                If .Item("traEspecie").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Vol.esp = .Item("traEspecie")
                End If
                If .Item("traNumeracao").ToString.Length > 0 Then
                    XMLPed.infNFE.Transp.Vol.nVol = .Item("traNumeracao")
                End If
                txtMensagem.Text &= "Dados do transporte...[ OK ]" & vbCrLf


                If .Item("TipoDoc") = 1 Then   'Se for uma nota de saída

                    '*
                    '* MENSAGENS DA NOTA
                    '*

                    'Calcula o percentual de aproveitamento do ICMS
                    Dim AproveitaICMS As Double
                    AproveitaICMS = My.Settings.Aliquota * XMLPed.infNFE.Total.IcmsTot.vNF / 100

                    XMLPed.infNFE.InfAdic = New infAdic

                    'Mensagem para o Fisco
                    XMLPed.infNFE.InfAdic.infAdFisco = "Empresa optante do SIMPLES NACIONAL permite o aproveitamento de credito de ICMS no valor de R$ " & Format(AproveitaICMS, "N2") & " correspondente a aliquota de " & My.Settings.Aliquota & "% nos termos do ART.23 DA LC 123/2006"

                    'Verifica se existe alguma mensagem personalizada para a NFe
                    If Not IsDBNull(.Item("Obs")) Then
                        XMLPed.infNFE.InfAdic.infCpl = .Item("Obs")
                    End If

                    txtMensagem.Text &= "Dados Adicionais...[ OK ]" & vbCrLf

                    '*
                    '* DUPLICATAS - SE EXISTIREM
                    '*

                    Dim DTDuplicatas As DataTable
                    SQL = "SELECT * FROM Duplicatas WHERE Doc_ID=" & varID
                    Try
                        DTDuplicatas = SQLQuery(SQL)
                    Catch ex As Exception
                        MsgBox("Erro ao recuperar as duplicadas da Nota Fiscal" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try

                    'Se existirem duplicadas então acrescenta à nota
                    If DTDuplicatas.Rows.Count > 0 Then
                        Dim vLiq_Total As Double = 0
                        Dim cobranca As New cobr()
                        Dim pagamento As New pag()

                        For i = 0 To DTDuplicatas.Rows.Count - 1
                            With DTDuplicatas.Rows(i)
                                Dim DUPLICATA As New dup
                                Dim detalhePag As New detPag
                                Dim fatura As New fat
                                DUPLICATA.dVenc = Format(CDate(.Item("Vencimento")), "dd/MM/yyyy")
                                'DUPLICATA.nDup = Format(Val(.Item("id")), "0000")
                                DUPLICATA.nDup = Format(i + 1, "000")
                                DUPLICATA.vDup = .Item("Valor")
                                detalhePag.tPag = .Item("formaPag")
                                detalhePag.vPag = .Item("Valor")
                                vLiq_Total += .Item("Valor")
                                fatura.vDesc = 0
                                fatura.nFat = i + 1
                                fatura.vLiq = .Item("Valor")
                                fatura.vOrig = .Item("Valor")
                                'Adiciona a forma de pagmento 
                                pagamento.detPag.Add(detalhePag)
                                cobranca.Fat.Add(fatura)
                                'Adiciona as duplicatas
                                cobranca.Dup.Add(DUPLICATA)
                            End With
                        Next

                        'Acrescenta as duplicatas
                        XMLPed.infNFE.Cobr = cobranca
                        'Acrescenta as formas de Pagamento
                        XMLPed.infNFE.Pag = pagamento

                    End If

                    txtMensagem.Text &= "Dados das Duplicatas...[ OK ]" & vbCrLf
                End If  'Fecha If do documento de saida

                txtMensagem.Text &= "Dados da Forma de Pagamento [ OK ]" & vbCrLf

                txtMensagem.Text &= "Geração do Arquivo Finalizada, SALVANDO XML..." & vbCrLf


                '*
                '* GERAÇÃO DO ARQUIVO XML
                '*

                'Gera o XML
                Dim xmlGerado As XmlDocument = XMLPed.GerarXML(), NomeArquivo As String

                'Gera o nome do arquivo com base no ID da nota
                NomeArquivo = XMLPed.Id.ToString & "-nfe.xml"

                '*
                '* NAO PRECISA ASSINAR POIS O UNINFE FAZ TUDO ENTÃO SÓ É PRECISO GERAR
                '* O ARQUIVO XML SEM O LOTE
                '* 
                '* Neste ponto só vou gerar o arquivo, a parte da transmissão fica para depois
                '*

                Try
                    'Antes de Gerar verifica se o arquivo já existe
                    If System.IO.File.Exists(My.Settings.PastaNFe & "\Gerados\" & NomeArquivo) Then
                        'Apaga o arquivo antes de Escrever o novo
                        System.IO.File.Delete(My.Settings.PastaNFe & "\Gerados\" & NomeArquivo)
                        'Salva uma cópia do XML não assinado
                        xmlGerado.Save(My.Settings.PastaNFe & "\Gerados\" & NomeArquivo)
                    Else
                        'Salva uma cópia do XML não assinado
                        xmlGerado.Save(My.Settings.PastaNFe & "\Gerados\" & NomeArquivo)
                    End If
                    Dim itm_atual As Integer
                    'itm_atual = Int(dgNFs.SelectedRows(0).Index.ToString)
                    itm_atual = dgNFs.CurrentRow.Index

                    'Atualiza o banco de dados com as informações da Nota
                    'Grava o nome do arquivo na Nota
                    SQL = "UPDATE Docs SET Status=1,ChNFE='" & XMLPed.Id.ToString & "',Arquivo='" & XMLPed.Id.ToString & "-nfe.xml" & "' WHERE id=" & varID
                                'Executa a SQL para fazer a atualizacao
                                ExecutaSQL(SQL)
                    MsgBox("Arquivo de nota fiscal gerado com sucesso!" & vbCrLf & "Nome do Arquivo: " & NomeArquivo, MsgBoxStyle.Information)
                    Formata_Grid()
                    'Volta para linha selecionada
                    dgNFs.CurrentCell = dgNFs.Rows(itm_atual).Cells(1)
                Catch ex As Exception
                    MsgBox("Erro ao gerar aquivo da nota fiscal!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End With
        Catch ex As Exception
            MsgBox("Erro na Geração do Arquivo" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    '* CANCELAMENTO DE NF
    Private Sub btCancelamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelamento.Click
        Dim a As Integer
        a = MsgBox("Deseja realmente cancelar o Documento de Saída nº " & dgNFs.SelectedRows(0).Cells(3).Value & " junto ao SEFAZ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        If a = vbYes Then
            Dim varID As String
            'Pega o ID da nota selecionada
            varID = dgNFs.SelectedRows(0).Cells("id").Value

            'Colhendo o motivo do cancelamento
            Dim Motivo As String = InputBox("Digite abaixo o motivo do cancelamento.", "Motivo")
            If Motivo = String.Empty Then
                MsgBox("Motivo não digitado, processo de Cancelamento abortado.", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If

            'Se foi adiante, consulta o banco de dados para pegar os dados da nota
            Dim vProt As String = String.Empty
            vProt = NaoNulo(DLookup("procNFE", "Docs", "id=" & varID))
            'Nota ainda não transmitida

            If vProt.Trim.Length < 14 Then
                MsgBox("Este Documento ainda não foi transmitido ou não tem um Protocolo e portanto não pode ser cancelado!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If

            'Se está tudo OK pode prosseguir com o cancelamento
            ChaveNf = DLookup("chNFE", "Docs", "id=" & varID)

            '*
            '* A partir de 01-04-2013 o Cancelamento só é permitido por eventos
            '*

            'Dim StrRetorno As RetornoEvento
            Dim CancelarEvento As New CancelamentoEvento

            'Montando o Cancelamento por Evento
            With CancelarEvento
                .cOrgao = "42"                          'Orgão que vai receber o XML - Código do estado de SC
                .tpAMB = My.Settings.NFeAmbiente        'Ambiente 1=Produção 2=Homologação
                .CNPJ = E_CNPJ                          'Constante que contém o CNPJ
                .chNFe = ChaveNf                        'Numero da chave da NFe
                .dhEvento = Now                         'Data e Hora do evento
                .tpEvento = "110111"                    'Código do Tipo do Evento
                '.nSeqEvento = DLookup("Valor", "Parametros", "Nome='NFeNumEvento'")                       'Número sequencial do evento
                .nSeqEvento = 1
                .verEvento = "1.00"                     'Versão XML do evento
                .descEvento = "Cancelamento"            'Tipo do Evento (Opcional)
                .Id = "ID" & "110111" & ChaveNf & .nSeqEvento.PadLeft(2, "0") 'Montagem do ID completo
                .nProt = vProt                          'Protocolo de autorização original da NFe
                .xJust = Motivo                         'Motivo do cancelamento da NFe
            End With

            'Gerando Arquivo XML de cancelamento
            '-------------------------------------------------------------------------------------------------------------------------
            'Importante:
            'Salvar através do TextWriter evita que o XML saia formatado no arquivo, desta forma o mesmo
            'pode ser rejeitado por alguns estados e/ou não validar nos programas teste

            Dim xmlGerado As XmlDocument = CancelarEvento.GeraXML, NomeArquivo As String
            'Dim xmlGerado As XmlDocument = CancelarDocumento.GerarXMLCancelamento, NomeArquivo As String

            'Transforma o XML Gerado em formato do arquivo de lote
            CancelarEvento.GerarLote(xmlGerado)

            Try
                'Tenta gerar o arquivo d cancelamento (Ja no formato de lote)
                NomeArquivo = My.Settings.PastaNFe & "\Gerados\" & CancelarEvento.chNFe & "-env-canc.xml"
                'NomeArquivo = My.Settings.PastaNFe & "\Gerados\" & Cancelardocumento.Id & "-ped-can.xml"
                xmlGerado.Save(NomeArquivo)
            Catch ex As Exception
                MsgBox("Erro ao tentar gerar o arquivo XML de Cancelamento" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
                Exit Sub
            End Try

            Try
                'Se foi gerado com sucesso aumenta o número do evento.
                Dim SQL As String = ""
                SQL = "UPDATE Parametros SET Valor=" & CancelarEvento.nSeqEvento + 1 & " WHERE Nome='NFeNumEvento'"
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar o número Sequencial do Evento no Banco de Dados" & ex.Message & vbCrLf & ex.ToString, "Erro")
                Exit Sub
            End Try

            'Com o arquivo Gerado pode-se proceder o envio para o SEFAZ
            Dim ArquivoDestino As String = My.Settings.PastaNFe & "\Envio-Simples\" & CancelarEvento.chNFe & "-env-canc.xml"
            'Dim ArquivoDestino As String = My.Settings.PastaNFe & "\Envio-Simples\" & CancelarDocumento.Id & "-ped-can.xml"

            txtMensagem.Text = "Enviando pedido de Cancelamento..." & vbCrLf

            'Coloca o arquivo na fila de envio (PASTA ENVIO-SIMPLES)
            Try
                System.IO.File.Copy(NomeArquivo, ArquivoDestino)
            Catch ex As Exception
                MsgBox("Erro ao tentar colocar o arquivo na fila de envio.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End Try

            'Aguarda o retorno do arquivo
            Etapa = 20
            tmrAguarda.Enabled = True
        End If
    End Sub

    '* GERACAO DA DANFE
    Private Sub btDanfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDanfe.Click
        Dim Arquivo As String = String.Empty, SQL As String = String.Empty, PastaDoMes As String = String.Empty
        'Se não houver nota selecionada sai da funcao
        If dgNFs.SelectedRows.Count <= 0 Then
            Exit Sub
        End If

        ChaveNf = DLookup("ChNFe", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("id").Value)
        'Verifica o mes e ano da emissão da nota para localizar a pasta
        With dgNFs.SelectedRows(0).Cells("Data")
            PastaDoMes = Format(CDate(.Value).Year, "0000") & Format(CDate(.Value).Month, "00")
        End With
        'Verifica se a chave é válida
        If ChaveNf.Length > 0 Then

            Arquivo = My.Settings.PastaNFe & "\" & "Enviado\Autorizados\" & PastaDoMes & "\" & ChaveNf & "-procNFe.xml"
            'Verifica de fato a existência do arquivo
            If System.IO.File.Exists(Arquivo) Then
                Try
                    Dim CaminhoUNIDNF As String = DLookup("Valor", "parametros", "nome='NFEUnidanfe'")
                    'Executa o Unidanfe com o parametro especificado
                    Shell(CaminhoUNIDNF & " arquivo=" & Arquivo & " Configuracao=Retrato")
                    'Guarda o item atual
                    Dim itm_atual As Integer
                    itm_atual = dgNFs.CurrentRow.Index
                    SQL = "UPDATE Docs SET Status=3 WHERE id=" & dgNFs.SelectedRows(0).Cells("ID").Value
                    ExecutaSQL(SQL)
                    Formata_Grid()
                    'Volta ao ítem selecionado
                    dgNFs.CurrentCell = dgNFs.Rows(itm_atual).Cells(1)

                Catch ex As Exception
                    MsgBox("Erro na impressão da DANFE!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            Else
                MsgBox("O arquivo de autorização da NFe com o Protocolo de Recepção não foi localizado", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If
        Else
            MsgBox("A Chave de Acesso de 44 dígitos não está registrada no Banco de dados" & vbCrLf & "Impossível localizar arquivo para impressão da DANFE", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
    End Sub

    '* INUTILIZAÇÃO DE NUMERAÇÃO DE NF
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim a As Integer
        a = MsgBox("Deseja realmente inutilizar as NFe's " & txtNFeINI.Text & " até " & txtNFeFIM.Text & " junto ao SEFAZ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        If a = vbYes Then
            'Gera o cancelamento da NF
            Dim oNFE As New NFe

            'Define o ambiente em que a nota vai ser transmitida
            Dim varAmbiente As Integer
            varAmbiente = DLookup("valor", "parametros", "nome='NFeAmbiente'")


            'Preparando Informações de Inutilização
            '-------------------------------------------------------------------------------------------------------------------------
            oNFE.versao = "2.00"                                'Versão da NFe
            oNFE.infNFE.Ide.cUF = 42                            'UF do emitente
            oNFE.infNFE.Ide.tpAmb = varAmbiente                 'Ambiente
            oNFE.ano = Date.Now.Year.ToString.Substring(2, 2)   'Ano da unutilização
            oNFE.infNFE.Emit.CNPJ = "07727715000190"            'CNPJ do emitente
            oNFE.infNFE.Ide.mod = "55"                          'Mod
            oNFE.infNFE.Ide.serie = Val(txtSerie.Text)          'Serie da NFe
            oNFE.NumNf_Ini = Int32.Parse(txtNFeINI.Text)        'Faixa inicial
            oNFE.NumNf_Fin = Int32.Parse(txtNFeFIM.Text)        'Faixa Final
            oNFE.xJust = txtJust.Text                           'Justificativa para inutilização

            Dim _codUF As String = oNFE.infNFE.Ide.cUF.ToString()
            Dim _ano As String = oNFE.ano
            Dim _cnpj As String = funcoesNfe.removeFormatacao(oNFE.infNFE.Emit.CNPJ)
            Dim _mod As String = oNFE.infNFE.Ide.mod
            Dim _serie As String = String.Format("{0:000}", Int32.Parse(oNFE.infNFE.Ide.serie))
            Dim _numNFIni As String = String.Format("{0:000000000}", oNFE.NumNf_Ini)
            Dim _numNFFin As String = String.Format("{0:000000000}", oNFE.NumNf_Fin)

            oNFE.Id = _codUF + _ano + _cnpj + _mod + _serie + _numNFIni + _numNFFin
            'NFe 51 76472345670530 55 001 000000101 000000101

            ChaveNf = oNFE.Id

            'Gerando arquivo XML de inutilização
            '-------------------------------------------------------------------------------------------------------------------------
            'Importante:
            'Salvar através do TextWriter evita que o XML saia formatado no arquivo, desta forma o mesmo
            'pode ser rejeitado por alguns estados e/ou não validar nos programas teste
            Dim xmlGerado As XmlDocument = oNFE.GerarXMLInutilizacao, NomeArquivo As String
            Try
                'Tenta gerar o arquivo d cancelamento
                NomeArquivo = My.Settings.PastaNFe & "\Gerados\"
                NomeArquivo &= oNFE.Id

                xmlGerado.Save(NomeArquivo & "-ped-inu.xml")
            Catch ex As Exception
                MsgBox("Erro ao tentar gerar o arquivo XML de Inutilização" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
                Exit Sub
            End Try

            'Com o arquivo Gerado pode-se proceder o envio para o SEFAZ
            Dim ArquivoDestino As String = My.Settings.PastaNFe & "\Envio-Simples\" & oNFE.Id & "-ped-inu.xml"
            txtMensagem.Text = "Enviando pedido de Inutilização..." & vbCrLf
            'Coloca o arquivo na fila de envio
            System.IO.File.Copy(NomeArquivo & "-ped-inu.xml", ArquivoDestino)
            'Desbilita o painel de envio
            pnlInutilizacao.Visible = False
            'Aguarda o retorno do arquivo
            Etapa = 30
            tmrAguarda.Enabled = True
        End If
    End Sub

    '*
    '* FUNCOES AUXILIARES AOS PROCESSOA
    '*
    Private Sub dgNFs_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgNFs.RowPrePaint
        Dim i As Int16 = 0
        i = e.RowIndex
        Select Case dgNFs.Rows(i).Cells("status").Value.ToString
            Case "0"    'DIGITADA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Digitada
            Case "1"    'GERADO XML
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Gerada
            Case "2"    'TRANSMITIDA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Transmitida
            Case "3"    'DANFE Impressa
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Danfe
            Case "4"    'CANCELADA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Cancelada
            Case "5"    'INUTILIZADA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Inutilizada
        End Select

    End Sub

    Private Sub dgNFs_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgNFs.SelectionChanged
        'Quando a selecao mudar verifica o status do item e habilita os botoes de acordo
        'Se realmente existir algo selecionado
        Try
            If dgNFs.SelectedRows.Count > 0 Then
                Atualiza_Botoes(dgNFs.SelectedRows(0).Cells("Status").Value.ToString)
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar os botoes segundo o Status da NFe" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Atualiza_Botoes(ByVal status As String)
        Dim Termo As Integer = dgNFs.SelectedRows(0).Cells("Termo").Value
        '0-Digitada, 1-XML Gerado ,2-Transmitida, 3-Danfe Impressa
        Select Case status
            Case 0 ' Digitada
                btGerarXML.Enabled = True
                btValidar.Enabled = False
                btTransmitir.Enabled = False
                btDanfe.Enabled = False
                btAlterar.Enabled = True
                btCancelamento.Enabled = False
            Case 1 'Arquivo Gerado
                btGerarXML.Enabled = True
                btValidar.Enabled = True
                btTransmitir.Enabled = True
                btDanfe.Enabled = False
                btAlterar.Enabled = True
                btCancelamento.Enabled = False
            Case 2 'Transmitida
                btGerarXML.Enabled = False
                btValidar.Enabled = False
                btTransmitir.Enabled = True
                btDanfe.Enabled = True
                btAlterar.Enabled = False
                btCancelamento.Enabled = True
            Case 3 'Danfe Impressa
                'Só pra Debug
                btGerarXML.Enabled = True
                btValidar.Enabled = False
                btTransmitir.Enabled = False
                btDanfe.Enabled = True
                btAlterar.Enabled = True
                btCancelamento.Enabled = True
            Case 4 'CANCELADA
                btGerarXML.Enabled = False
                btValidar.Enabled = False
                btTransmitir.Enabled = False
                btDanfe.Enabled = False
                btAlterar.Enabled = False
                btCancelamento.Enabled = False
            Case Else
                btGerarXML.Enabled = False
                btValidar.Enabled = False
                btTransmitir.Enabled = False
                btDanfe.Enabled = False
                btAlterar.Enabled = False
                btCancelamento.Enabled = False
        End Select
        'Quanto ao termo de Conformidade
        '0 = Termo não Emitido 1 = Termo Emitido e pode ser impresso
        If Termo = 0 Then
            btTermo.Enabled = True
            btPrintTermo.Enabled = False
        ElseIf Termo = -1 Then
            btTermo.Enabled = True
            btPrintTermo.Enabled = True
        End If

        'Atualiza também o menu de contexto
        mnuGerarXML.Enabled = btGerarXML.Enabled
        mnuValidar.Enabled = btValidar.Enabled
        mnuTransmitir.Enabled = btTransmitir.Enabled
        mnuDanfe.Enabled = btDanfe.Enabled
        mnuAlterar.Enabled = btAlterar.Enabled
        mnuCancelar.Enabled = btCancelamento.Enabled
        mnuTermo.Enabled = btTermo.Enabled
        mnuPrintTermo.Enabled = btPrintTermo.Enabled

        'Verifica o rastreador
        Dim rastreador As String = DLookup("Rastreador", "docs", "id=" & dgNFs.SelectedRows(0).Cells("id").Value)
        Dim site As String = DLookup("siteRastreador", "docs", "id=" & dgNFs.SelectedRows(0).Cells("id").Value)
        'Se tem o rastreador pode enviar
        If Not IsDBNull(rastreador) And Not rastreador = String.Empty Then
            mnuEnviarReg.Enabled = True
            mnuRastrear.Enabled = True
        Else
            mnuEnviarReg.Enabled = False
            mnuRastrear.Enabled = False
        End If
    End Sub

    Private Sub Formata_Grid()
        Dim DT As DataTable = Nothing, SQL As String = String.Empty
        Dim Cabecalhos() As String, Larguras() As Integer, Visiveis() As Integer

        'Guarda a posição atual para poder voltar na mesma posição
        Dim Lin As Integer

        If dgNFs.Rows.Count > 0 Then
            Lin = dgNFs.CurrentRow.Index
        Else
            Lin = 0
        End If

        SQL = "SELECT id,Data,Serie,Documento,Cliente,CNPJ_CPF,vTotal,Status,termo FROM Docs WHERE YEAR(Data)=" & cmbAno.Text & " ORDER BY Documento"
        Try
            'Coloca os dados da tabela no grid
            DT = SQLQuery(SQL)
            dgNFs.DataSource = DT
        Catch ex As Exception
            MsgBox("Erro ao recuperar as informações das Notas Fiscais!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        Cabecalhos = {"ID", "Data", "S", "Nº Doc", "Cliente", "CNPJ/CPF", "Total", "Sit", "TC"}
        Larguras = {0, 80, 30, 90, 200, 110, 80, 30, 0}
        Visiveis = {0, 1, 1, 1, 1, 1, 1, 1, 0}
        Formata_Datagrid(dgNFs, Cabecalhos, Larguras, Visiveis)

        'formatos específicos para cada coluna
        With dgNFs
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0000"
            End With
            With .Columns("Data").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "dd/MM/yyyy"
            End With
            With .Columns("Serie").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Documento").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With .Columns("Cliente").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("CNPJ_CPF").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("vTotal").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            With .Columns("status").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0"
            End With
        End With

        'Verifica se tem linhas suficientes para retornar
        If dgNFs.Rows.Count <> 0 Then
            If dgNFs.Rows.Count >= Lin Then
                'Retorna à linha que estava antes de atualizar o banco de dados
                dgNFs.CurrentCell = dgNFs.Rows(Lin).Cells(1)
            End If
        End If

    End Sub

    Private Sub btAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAlterar.Click

        If dgNFs.SelectedRows.Count > 0 Then
            Dim TipoDOC As UInt16 = 1, docID As Integer = 0
            docID = dgNFs.SelectedRows(0).Cells(0).Value
            TipoDOC = DLookup("TipoDOC", "Docs", "id=" & docID)

            Dim Form2 As New frmNFeDocumento(TipoDOC, docID)
            Form2.MdiParent = frmMenu
            Form2.Show()

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Inutilizacao.Click
        pnlInutilizacao.Visible = True
        txtNFeFIM.Focus()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        pnlInutilizacao.Visible = False
    End Sub

    Private Sub lanca_contas_receber(ByVal DocID As Integer)
        Dim SQL As String, DT As DataTable, NomeCli As String
        Dim DR As DataRow, DataNFe As Date, ForPagNFe As Integer

        'Cursor em modo de espera
        Me.Cursor = Cursors.WaitCursor

        'O documento vem do lançamento
        NomeCli = DLookup("Cliente", "docs", "id=" & DocID)
        DataNFe = DLookup("Data", "docs", "id=" & DocID)
        ForPagNFe = DLookup("FormaPgto", "docs", "id=" & DocID)

        'Verifica se ele tem duplicatas
        SQL = "SELECT * FROM Duplicatas WHERE Doc_id=" & DocID

        'Verifica se existem duplicatas registradas

        'Monta a SQL para procurar os dados da NF
        DT = SQLQuery(SQL)

        If DT.Rows.Count <= 0 Then
            MsgBox("Não existem duplicatas registradas para essa NFe! Não é possível fazer o lançamento automático.", MsgBoxStyle.Critical)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        Else
            'Se existirem duplicatas Faz a inclusão
            'Para cada duplicata
            For Each DR In DT.Rows
                '*
                '*  INCLUI CONTA A RECEBER
                '*

                'Monta a SQL das contas a receber
                SQL = "INSERT INTO pagarreceber SET "
                SQL &= "Vencimento='" & Format(DR.Item("Vencimento"), "yyyy-MM-dd") & "',"
                SQL &= "Pessoa='" & NomeCli & "',"
                SQL &= "Emissao='" & Format(DataNFe, "yyyy-MM-dd") & "',"
                SQL &= "EntSai='" & Format(DataNFe, "yyyy-MM-dd") & "',"
                SQL &= "Descricao='Rec. NFe " & Format(Int(DocID), "000000") & " - " & NomeCli & "',"
                SQL &= "Documento='" & Format(Int(DocID), "000000") & "',"
                SQL &= "TipoDoc='NFe',"
                SQL &= "Valor=" & Numero_to_SQL(DR.Item("valor")) & ","
                SQL &= "Previsao=0,"
                SQL &= "Mensal=0,"
                SQL &= "TipoPR='R',"
                If DT.Rows.Count = 1 Then
                    SQL &= "Parcela='Unica',"
                ElseIf DT.Rows.Count > 1 Then
                    SQL &= "Parcela='" & DR.Item("Parcela") & "',"
                End If
                SQL &= "compra=0"

                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar lançar a Conta a Receber ref. duplicata (" & DR.Item("id") & ")" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End Try

                '*
                '*  INCLUI CONTABILIZAÇÃO
                '*

                Dim lancID As Integer
                lancID = Int(DMax("id", "Pagarreceber"))
                Dim dataDup As Date
                dataDup = CDate(DR.Item("Vencimento"))
                Dim varHistorico As String = ""
                Dim setPrazo As Boolean = False


                'Se deu tudo certo lança a contabilização
                SQL = "INSERT INTO pr_lancamentos SET "

                'Temos algumas situações possíveis

                '*
                '* A VISTA (DENTRO DO MÊS) RECEBIDO VIA CAIXA
                '*
                '*      (Caso das notas de Roberto Drefahl)
                '*      Forma de Pagamento = 1 "A vista"

                If ForPagNFe = 1 And (dataDup.Month = DataNFe.Month And dataDup.Year = DataNFe.Year) Then
                    'Se a forma de pagamento for A VISTA e o Mês da Nota for igual ao Mês do vencimento
                    SQL &= "CDHist=1,"
                    varHistorico = "Rec. NFe " & Format(Int(DocID), "000000") & " - " & NomeCli
                    SQL &= "Historico='" & Truncar(varHistorico, 120) & "',"
                    SQL &= "Data='" & Format(DR.Item("Vencimento"), "yyyy-MM-dd") & "',"
                    SQL &= "Valor=" & Numero_to_SQL(DR.Item("valor")) & ","
                    SQL &= "CTCred=" & CTB_AVISTA_CAIXA_C & "," '602
                    SQL &= "CTDeb=" & CTB_AVISTA_CAIXA_D & ","  '259
                    SQL &= "idDoc=" & lancID & ","
                    SQL &= "Lancado=0"
                    'Vai para o final e executa a SQL
                    GoTo Executa
                End If

                '*
                '* A VISTA (DENTRO DO MÊS) RECEBIDO VIA BANCO
                '*
                '*      (Caso de Boletos ou depósitos pagos dentro do Mes)
                '*

                If ForPagNFe <> 1 And (dataDup.Month = DataNFe.Month And dataDup.Year = DataNFe.Year) Then
                    'Se a forma de pagamento for qualquer outra que não A vista e o Vencimento for dentro do mês
                    'Se a forma de pagamento for A VISTA e o Mês da Nota for igual ao Mês do vencimento
                    SQL &= "CDHist=1,"
                    varHistorico = "Créd. Cob. NFe " & Format(Int(DocID), "000000") & " - " & NomeCli
                    SQL &= "Historico='" & Truncar(varHistorico, 120) & "',"
                    SQL &= "Data='" & Format(DR.Item("Vencimento"), "yyyy-MM-dd") & "',"
                    SQL &= "Valor=" & Numero_to_SQL(DR.Item("valor")) & ","
                    SQL &= "CTCred=" & CTB_AVISTA_BANCO_C & "," '259
                    SQL &= "CTDeb=" & CTB_AVISTA_BANCO_D & ","  '33
                    SQL &= "idDoc=" & lancID & ","
                    SQL &= "Lancado=0"
                    'Vai para o final e executa a SQL
                    GoTo Executa
                End If

                '*
                '* A PRAZO (FORA DO MÊS) RECEBIDO VIA CAIXA
                '*
                '*      (Caso de pagamentos feitos em carteira ou com cheque em meses após a nota)
                '*


                '*
                '* A PRAZO (FORA DO MÊS) RECEBIDO VIA BANCO
                '*

                If (ForPagNFe <> 1) And ((dataDup.Month <> DataNFe.Month And dataDup.Year = DataNFe.Year) Or (dataDup.Month = DataNFe.Month And dataDup.Year <> DataNFe.Year)) Then
                    'Se a forma de pagamento for
                    SQL &= "CDHist=1,"
                    varHistorico = "Créd. Cob. NFe " & Format(Int(DocID), "000000") & " - " & NomeCli
                    SQL &= "Historico='" & Truncar(varHistorico, 120) & "',"
                    SQL &= "Data='" & Format(DR.Item("Vencimento"), "yyyy-MM-dd") & "',"
                    SQL &= "Valor=" & Numero_to_SQL(DR.Item("valor")) & ","
                    SQL &= "CTCred=" & CTB_APRAZO_BANCO_C & "," '311
                    SQL &= "CTDeb=" & CTB_APRAZO_BANCO_D & ","  '33
                    SQL &= "idDoc=" & lancID & ","
                    SQL &= "Lancado=0"
                    'Vai para o final e executa a SQL
                    setPrazo = True
                    GoTo Prazo
                End If

Prazo:
                If setPrazo Then
                    'Lançamento contábil dentro do mês para aguardar o A Prazo
                    Dim LancCred As New Lancamentos, lancDeb As New Lancamentos

                    '*
                    '* CRÉDITO - LANCAMENTO DENTRO DO MES
                    '*
                    LancCred.cod_Reduzido = CTB_APRAZO_MES_C    '260
                    LancCred.PreencheCodCompleto()
                    LancCred.Documento = Format(Int(DocID), "000000")
                    LancCred.Historico = ""
                    LancCred.Lanc_ID = lancID
                    LancCred.Mensal = False
                    LancCred.Pagamento = DataNFe
                    LancCred.Pessoa = NomeCli
                    LancCred.Prev = False
                    LancCred.Tipo = "C"
                    LancCred.valCred = DR.Item("Valor")
                    LancCred.valDeb = "0"

                    '*
                    '* DÉBITO - LANCAMENTO DENTRO DO MES
                    '*

                    LancCred.cod_Reduzido = CTB_APRAZO_MES_C    '311
                    LancCred.PreencheCodCompleto()
                    LancCred.Documento = Format(Int(DocID), "000000")
                    LancCred.Historico = ""
                    LancCred.Lanc_ID = lancID
                    LancCred.Mensal = False
                    LancCred.Pagamento = DataNFe
                    LancCred.Pessoa = NomeCli
                    LancCred.Prev = False
                    LancCred.Tipo = "C"
                    LancCred.valCred = "0"
                    LancCred.valDeb = DR.Item("Valor")

                    'Faz a inclusão do lancamento
                    LancCred.Incluir()
                    lancDeb.Incluir()
                End If

Executa:
                Try
                    'Se foi completada a SQL com mais informações
                    Console.WriteLine("Contabilização: " & SQL)
                    'If SQL.Length > 32 Then
                    'Executa a SQL
                    ExecutaSQL(SQL)
                    'End If
                Catch ex As Exception
                    MsgBox("Erro ao tentar lançar a Contabilização ref. duplicata (" & DR.Item("id") & ")" & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End Try
            Next    'Next das duplicatas.

            MsgBox("Duplicatas lançadas com sucesso no Contas à Receber", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")
            Me.Cursor = Cursors.Arrow
        End If
        'Retorna o cursor à seta
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btLancar.Click
        lanca_contas_receber(dgNFs.SelectedRows(0).Cells(0).Value)
    End Sub

    Private Sub btExportar_Click(sender As System.Object, e As System.EventArgs) Handles btExportar.Click
        '* Verifica se o arquivo existe e depois salva ele em um local escolhido

        'Muda o cursor para ampulheta
        Me.Cursor = Cursors.WaitCursor
        txtMensagem.Text = String.Empty

        Dim Arquivo As String, ArqBD As String
        Arquivo = My.Settings.PastaNFe & "\Gerados\"
        'Se houver o nome do arquivo registrado no BD
        ArqBD = DLookup("Arquivo", "Docs", "id=" & dgNFs.SelectedRows(0).Cells("ID").Value)
        If ArqBD.Length > 0 Then
            Arquivo &= ArqBD
            txtMensagem.Text = "Arquivo: " & Arquivo & " Recuperado." & vbCrLf
        Else
            MsgBox("Nome do arquivo de nota não registrado no Banco de Dados!" & vbCrLf & "Este problema pode ser resolvido gerando o arquivo novamente", MsgBoxStyle.Critical, "Erro")
        End If

        'Checagem para ver se o arquivo exites
        If System.IO.File.Exists(Arquivo) Then
            Dim arqDestino As String = String.Empty
            fbPasta.ShowDialog()
            'Monta o nome do arquivo de destino
            arqDestino = fbPasta.SelectedPath & "\" & ArqBD
            Try
                'Copia o arquivo
                System.IO.File.Copy(Arquivo, arqDestino)
                'Limpa a janela de retorno de mensagens
                txtMensagem.Text &= "Arquivo exportado com sucesso..."
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                MsgBox("Erro na exportação do arquivo..." & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try
        Else
            'Se não existe
            MsgBox("Arquivo XML da Nota Fiscal nº " & dgNFs.SelectedRows(0).Cells("Documento").Value & " não encontrado!" & vbCrLf & "Gerar o arquivo novamente!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
    End Sub

    Private Sub btTermo_Click(sender As System.Object, e As System.EventArgs) Handles btTermo.Click
        'Primeiro verifica se a NFe já tem o termo ou não
        Dim Termo As Integer = dgNFs.SelectedRows(0).Cells("Termo").Value
        Dim docID As Integer = dgNFs.SelectedRows(0).Cells("id").Value
        Dim SQL As String

        'Já tem o termo
        If Termo = -1 Then
            'Se desejar reemitir, primeiro tem que eliminar tudo o que já tinha
            Dim a As DialogResult = MsgBox("O Termo de Conformidade já foi Emitido para esta NFe." & vbCrLf & "Deseja Reemitir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            'Se desejar reemitir
            If a = vbYes Then
                'Se deseja reemitir tem que apagar tudo o que tinha anteriormente.
                SQL = "DELETE FROM Termo_Conformidade WHERE Doc_ID=" & docID
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar limpar as informações para gerar o novo termo." & vbCr & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            ElseIf a = vbNo Then
                'Se naõ deseja reemitir pode sair.
                Exit Sub
            End If
        End If
        'Emite o termo de conformidade
        Me.Cursor = Cursors.WaitCursor

        'Monta a SQL
        SQL = "SELECT CodPro,Clone,quantidade FROM docs_itens WHERE doc_id=" & docID
        Dim Result As DataTable
        Try
            Result = SQLQuery(SQL)
        Catch ex As Exception
            MsgBox("Erro ao pesquisar ítens da NFe no banco de dados" & vbCr & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
        If Result.Rows.Count <= 0 Then
            MsgBox("Não foram encontrados os ítens desta NFe no banco de dados", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        'Variável para contar quantas linhas precisam de RENASEM
        Dim CT As Integer = 0
        'Para cada linha do resultado
        For Each DR As DataRow In Result.Rows
            'Verifica se o ítem atual necessita de Termo de Conformidade
            Dim Ren As String
            Ren = DLookup("RENASEM", "Clones", "Mercadoria=" & DR.Item("CodPro") & " AND Clone=" & DR.Item("Clone"))
            'Se retornou algo que não é vazio (ou seja Precisa de Termo de Conformidade)
            If Ren <> String.Empty Then
                'Soma o contador de ítens
                CT += 1
                SQL = "INSERT INTO termo_conformidade SET "
                SQL &= "Doc_ID=" & docID & ","
                SQL &= "Mercadoria='" & DLookup("Cientifico", "Mercadoria", "id=" & DR.Item("CodPro")) & "',"
                SQL &= "Clone='" & DLookup("Nome", "clones", "Mercadoria=" & DR.Item("CodPro") & " AND Clone=" & DR.Item("Clone")) & "',"
                SQL &= "codMer=" & DR.Item("CodPro") & ","
                SQL &= "codClone=" & DR.Item("Clone") & ","
                SQL &= "Lote='" & DR.Item("CodPro") & "." & docID & "." & DR.Item("Clone") & "',"
                SQL &= "Quantidade=" & DR.Item("Quantidade") & ","
                SQL &= "Data='" & Format(CDate(dgNFs.SelectedRows(0).Cells(1).Value), "yyyy-MM-dd") & "'"
                'Tenta incluir o registro no banco de dados.
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir o registro de Termo de Conformidade" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End Try
            End If
        Next
        'Se passou por todos os ítens e não aumentou é porque nenhum precisava do RENASEM
        If CT = 0 Then
            MsgBox("Esta NFe não possui ítems que necessitam da Emissão do Termo de Conformidade", MsgBoxStyle.Information, "Informação")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        ElseIf CT > 0 Then
            SQL = "UPDATE docs SET Termo=1 WHERE id=" & docID
            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao atualizar a NFe quanto ao Termo de Conformidade" & ex.Message, MsgBoxStyle.Critical, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try
            MsgBox("Termo de Conformidade Gerado com Sucesso", MsgBoxStyle.Information, "Aviso")

            Dim a As Integer
            a = MsgBox("Deseja imprimir o termo agora?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            If a = vbYes Then
                Imprime_Termo()
            End If
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Imprime_Termo()
        Me.Cursor = Cursors.WaitCursor
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "proTermo_de_Conformidade.rpt"

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument

            CR.Load(strReportPath)
            'Define o parameter field
            CR.SetParameterValue("DocID", dgNFs.SelectedRows(0).Cells("id").Value)

            'Escolhe a impressora
            Dim digRes As DialogResult = pdImpressora.ShowDialog

            If digRes = System.Windows.Forms.DialogResult.OK Then
                'Define esta impressora no relatorio
                CR.PrintOptions.PrinterName = pdImpressora.PrinterSettings.PrinterName
                'Manda o relatório para impressoa
                CR.PrintToPrinter(1, False, 0, 0)
                MsgBox("Termo de Conformidade enviado para impressão com sucesso.", MsgBoxStyle.Information, "Confirmação")
            End If

        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o Termo de Conformidade para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Registra_Frete()

        'Se não estiver selecionado sai da rotina
        If dgNFs.SelectedRows.Count <= 0 Then Return

        'Pega o ID na NFe selecionada
        Dim NFeID As Integer = dgNFs.SelectedRows(0).Cells("id").Value
        Dim SQL As String = String.Empty

        Dim siteRastreador As String = String.Empty

        Select Case txtTransporte.Text
            Case "Correios"
                siteRastreador = "http://websro.correios.com.br/sro_bin/txect01$.QueryList?P_LINGUA=001&P_TIPO=001&P_COD_UNI=" & txtRastreador.Text
            Case "JadLog"
                siteRastreador = "https://www.jadlog.com.br/siteDpd/tracking.jad?cte=" & txtRastreador.Text & "&lang=pt_br"
            Case "Reunidas"
                siteRastreador = ""
        End Select

        'Monta a SQL de atualização
        SQL = "UPDATE docs SET "
        SQL &= "Rastreador=" & Texto_Vazio(txtRastreador.Text) & ","
        SQL &= "valFrete=" & Numero_to_SQL(txtVFrete.Text) & ","
        SQL &= "dataFrete='" & Format(txtDataFrete.Value, "yyyy-MM-dd") & "',"
        SQL &= "siteRastreador='" & siteRastreador & "'"
        SQL &= " WHERE id=" & NFeID

        Try
            'Acrescenta a informação de frete ao documento
            ExecutaSQL(SQL)
            'Informa que deu tudo certo
            MsgBox("Informação de frete Salva com Sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")
            pnlFrete.Visible = False
            txtRastreador.Text = String.Empty
            txtVFrete.Text = "0,00"
            txtDataFrete.Value = Today.Date
        Catch ex As Exception
            MsgBox("Erro ao anexar a informação de frete a NFE " & NFeID & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            pnlFrete.Visible = False
            txtRastreador.Text = String.Empty
            txtVFrete.Text = "0,00"
            txtDataFrete.Value = Today.Date
            Exit Sub
        End Try
    End Sub

    Private Sub btPrintTermo_click(sender As System.Object, e As System.EventArgs) Handles btPrintTermo.Click
        Imprime_Termo()
    End Sub

    Private Sub btOKFrete_Click(sender As Object, e As EventArgs) Handles btOKFrete.Click
        Registra_Frete()
    End Sub

    Private Sub Rastrear_Objeto()
        Dim URLBase As String, NFEId As Integer

        'Verifica se existe alguma linha selecionada
        If dgNFs.SelectedRows.Count <= 0 Then Return

        'Se existir então prossegue
        NFEId = dgNFs.SelectedRows(0).Cells("id").Value

        'Pega as informações do rastreador se houver
        Dim Rastreador As String
        'Busca o Rastreador no Banco de dados
        Rastreador = DLookup("Rastreador", "docs", "id=" & NFEId)

        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(Rastreador) Or Rastreador = String.Empty Then
            pnlCorreio.Visible = False
            MsgBox("Esta NFe não possui informações de frete associadas a ela.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        'Agora testa se tem algum site relacionada a ela

        URLBase = DLookup("siteRastreador", "docs", "id=" & NFEId)
        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(URLBase) Or URLBase = String.Empty Then
            'Se não tem o site, mas tem o rastreador, tenta os correios
            If Not IsDBNull(Rastreador) And Not Rastreador = String.Empty Then
                'Rastreador no padrão do correio
                If Rastreador.Length = 13 Then
                    URLBase = "http://websro.correios.com.br/sro_bin/txect01$.QueryList?P_LINGUA=001&P_TIPO=001&P_COD_UNI=" & Rastreador
                    pnlCorreio.Visible = True
                    webRastreador.Navigate(New Uri(URLBase))
                End If
            Else
                pnlCorreio.Visible = False
                MsgBox("Esta NFe não possui um endereço WEB para rastreamento associado à ela.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End If
        End If

        'Se passou por todas as informações então tenta verificar
        Try
            pnlCorreio.Visible = True
            webRastreador.Navigate(New Uri(URLBase))
        Catch ex As Exception
        End Try

    End Sub


    '*******************************************************
    '*
    '*  FUNÇÕES DO MENU DE CONTEXTO
    '*
    '*******************************************************

    Private Sub mnuAlterar_Click(sender As Object, e As EventArgs) Handles mnuAlterar.Click
        btAlterar_Click(sender, e)
    End Sub

    Private Sub GerarArquivoXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuGerarXML.Click
        btGerarXML_Click(sender, e)
    End Sub

    Private Sub mnuValidar_Click(sender As Object, e As EventArgs) Handles mnuValidar.Click
        btValidar_Click(sender, e)
    End Sub

    Private Sub mnuTransmitir_Click(sender As Object, e As EventArgs) Handles mnuTransmitir.Click
        btTransmitir_Click(sender, e)
    End Sub

    Private Sub mnuDanfe_Click(sender As Object, e As EventArgs) Handles mnuDanfe.Click
        btDanfe_Click(sender, e)
    End Sub


    Private Sub mnuCancelar_Click(sender As Object, e As EventArgs) Handles mnuCancelar.Click
        btCancelamento_Click(sender, e)
    End Sub


    Private Sub ExportarXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExportar.Click
        btExportar_Click(sender, e)
    End Sub

    Private Sub EmitirTermoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuTermo.Click
        btTermo_Click(sender, e)
    End Sub


    Private Sub ImprimirTermoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuPrintTermo.Click
        btPrintTermo_click(sender, e)
    End Sub

    Private Sub RegistrarFreteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuRegFrete.Click
        pnlFrete.Visible = True
        txtRastreador.Text = String.Empty
        txtVFrete.Text = "0,00"
        txtDataFrete.Value = Today.Date
        txtRastreador.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btCancela_Frete.Click
        pnlFrete.Visible = False
        txtRastreador.Text = String.Empty
        txtVFrete.Text = "0,00"
    End Sub

    Private Sub btCorrecao_Click(sender As Object, e As EventArgs) Handles btCorrecao.Click
        Try
            Dim idLote As String
            idLote = InputBox("Identificador de controle do Lote de envio:", "Carta de Correção")
            If (String.IsNullOrEmpty(idLote)) Then Throw New Exception("A Id do Lote deve ser informada!")

            Dim sequenciaEvento As String
            sequenciaEvento = InputBox("Número sequencial do evento:", "Carta de correção")
            If (String.IsNullOrEmpty(sequenciaEvento)) Then Throw New Exception("O número sequencial deve ser informado!")

            Dim chave As String = InputBox("Chave da NFe:", "Carta de correção")
            If (String.IsNullOrEmpty(chave)) Then Throw New Exception("A Chave deve ser informada!")
            If (chave.Length <> 44) Then Throw New Exception("Chave deve conter 44 caracteres!")

            Dim correcao As String = InputBox("Correção", "Carta de correção")
            If (String.IsNullOrEmpty(correcao)) Then Throw New Exception("A Correção deve ser informada!")

            'Dim servicoNFe As ServicosNFe = New ServicosNFe(_configuracoes.CfgServico)

            Dim CNPJ = "07727715000190"

            'Dim retornoCartaCorrecao As RetornoBasico = NFe.Classes.Servicos.Tipos.servicoNFe.RecepcaoEventoCartaCorrecao(Convert.ToInt32(idLote), Convert.ToInt16(sequenciaEvento), chave, correcao, CNPJ)

        Catch ex As ComunicacaoException
            MsgBox("Erro ao enviar carta de correção" & vbCr & ex.Message)
            Exit Sub
        Catch ex As ValidacaoSchemaException
            MsgBox("Erro ao enviar carta de correção" & vbCr & ex.Message)
            Exit Sub
        Catch ex As Exception
            MsgBox("Erro ao enviar carta de correção" & vbCr & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub txtVFrete_Leave(sender As Object, e As EventArgs) Handles txtVFrete.Leave
        txtVFrete.Text = Format(String_to_Numero(txtVFrete.Text), "N2")
    End Sub

    Private Sub RastrearObjetoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuRastrear.Click
        Rastrear_Objeto()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles bt_Fecha_Browser.Click
        pnlCorreio.Visible = False
    End Sub

    Private Sub EnviarRastreadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEnviarReg.Click
        'Define o arquivo que vai ser usado como modelo no e-mail

        Dim strModeloPath As String = My.Application.Info.DirectoryPath & "\modelos\envio_rastreador.html"

        'Verifica a existência do arquivo de modelo
        If Not IO.File.Exists(strModeloPath) Then
            MsgBox("Arquivo de modelo de e-mail não encontrado :" & vbCrLf & strModeloPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'Cria as variáveis para coletar todas as informações
        Dim txtData As String
        Dim txtRastreador As String
        Dim txtSite As String
        Dim txtPedido As String
        Dim txtNFe As String
        Dim txtCliente As String
        Dim txtEmail As String

        ' *** Coleta as informações do cliente e do rastreamento ***

        'Verifica se existe alguma linha selecionada
        If dgNFs.SelectedRows.Count <= 0 Then Return

        'Se existir então prossegue
        txtNFe = dgNFs.SelectedRows(0).Cells("id").Value

        'Pega as informações do rastreador se houver
        txtRastreador = DLookup("Rastreador", "docs", "id=" & txtNFe)

        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(txtRastreador) Or txtRastreador = String.Empty Then
            MsgBox("Esta NFe não possui informações de frete associadas a ela.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        'Se houver então continua
        txtData = DLookup("dataFrete", "docs", "id=" & txtNFe)

        'Pega o site se houver
        txtSite = DLookup("siteRastreador", "docs", "id=" & txtNFe)
        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(txtSite) Or txtSite = String.Empty Then
            txtSite = String.Empty
        End If

        txtPedido = DLookup("numPedido", "docs", "id=" & txtNFe)
        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(txtPedido) Or txtPedido = String.Empty Then
            txtPedido = "Não Informado"
        End If

        'Pega o nome do cliente
        txtCliente = DLookup("Cliente", "docs", "id=" & txtNFe)

        'Pega o email do cliente
        txtEmail = (DLookup("email", "docs", "id=" & txtNFe))
        'Se o retorno é vazio ou nulo, informa e sai da rotina
        If IsDBNull(txtEmail) Or txtEmail = String.Empty Then
            MsgBox("Não é possível enviar o rastreador por e-mail, pois o cliente não possui um e-mail cadastrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        'Teste de envio só para mim!
        'txtEmail = "alexandredrefahl@gmail.com"

        'Com todas informações em mãos agora é hora de montar o e-mail

        'Lê o arquivo de modelo
        Dim Corpo As String = File.ReadAllText(strModeloPath)
        'Define os campos que serão substituidos no modelo
        Dim Campos() As String = {"[data]", "[rastreador]", "[site]", "[pedido]", "[nfe]", "[cliente]"}

        'Troca o cursor
        Me.Cursor = Cursors.WaitCursor

        'Cria um array com todas as informações coletadas
        Dim Valores() As String = {txtData, txtRastreador, txtSite, txtPedido, txtNFe, txtCliente}

        'Percorre todos os campos fazendo as substituições
        For i As Integer = 0 To Campos.Length - 1
            Corpo = Corpo.Replace(Campos(i), Valores(i))
        Next

        'Prepara o envio do e-mail
        Dim mlFrom As String
        Dim mlTO As String
        Dim mlCC As String
        Dim mlSubject As String
        Dim mlBody As String = String.Empty
        Dim mlSMTP As String

        'Preenche os dados de envio
        mlFrom = E_MailFrom
        mlTO = txtEmail
        mlCC = "alexandre@clona-gen.com.br"
        mlSubject = "Envio do Pedido núm: " & txtPedido
        mlSMTP = E_MailServer

        'Começa a montar o envio do e-mail
        Dim Mailmsg As New System.Net.Mail.MailMessage()

        'endereca o recipiente
        Mailmsg.To.Add(New MailAddress(mlTO))
        Mailmsg.CC.Add(New MailAddress(mlCC))
        Mailmsg.From = New MailAddress(mlFrom)
        Mailmsg.ReplyToList.Add(New MailAddress(mlFrom))

        Dim mSmtpCliente As New SmtpClient(mlSMTP)
        'Especifica o formato 
        Mailmsg.IsBodyHtml = True
        'define o assunto
        Mailmsg.Subject = mlSubject

        'Corpo do EMail
        Mailmsg.Body = Corpo

        'Envia o email
        mSmtpCliente.Timeout = 40000
        Dim credential As New System.Net.NetworkCredential(E_MailUser, E_MailPass)
        mSmtpCliente.Credentials = credential
        Try
            mSmtpCliente.Send(Mailmsg)
            MsgBox("Rastreador do pedido enviado com sucesso", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o rastreador pedido por e-mail" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub cmbAno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAno.SelectedIndexChanged
        'Atualiza as notas fiscais
        Formata_Grid()
    End Sub
End Class