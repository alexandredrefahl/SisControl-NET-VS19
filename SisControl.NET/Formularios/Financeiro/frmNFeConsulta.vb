Imports System.Xml
Public Class frmNFEConsulta
    Dim Limite As Integer = 0

    Private Sub frmNFeConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista com as NFe já emitidas
        Carrega_Lista(txtChaveNFe, "Docs", "id", "chNFe")

    End Sub

    Private Sub btConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConsulta.Click
        If txtChaveNFe.Text.Length > 0 And txtChaveNFe.Text.Length < 44 Then
            MsgBox("Chave de NFe inválida, não é possível realizar a consulta!", MsgBoxStyle.Exclamation, "Alerta")
            Exit Sub
        End If
        If txtChaveNFe.Text.Length = 0 Or txtChaveNFe.Text.Length > 44 Then
            MsgBox("É necessário informar uma chave e NFe válida (44 caracteres)!", MsgBoxStyle.Exclamation, "Alerta")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        'Se passou pelas verificações anteriores então pode fazer a checagem
        If txtChaveNFe.Text.Length = 44 Then
            'Gera o Pedido de Situação da NF
            Dim oNFE As New NFe

            'Preparando Informações de Pedido
            '-------------------------------------------------------------------------------------------------------------------------
            oNFE.versao = "2.00"
            oNFE.Id = txtChaveNFe.Text

            'Gerando arquivo XML de Pedido de Status
            '-------------------------------------------------------------------------------------------------------------------------
            'Importante:
            'Salvar através do TextWriter evita que o XML saia formatado no arquivo, desta forma o mesmo
            'pode ser rejeitado por alguns estados e/ou não validar nos programas teste
            Dim xmlGerado As XmlDocument = oNFE.GerarXMLStatusNfe(), NomeArquivo As String

            Try
                'Tenta gerar o arquivo d cancelamento
                NomeArquivo = My.Settings.PastaNFe & "\Gerados\" & oNFE.Id & "-ped-sit.xml"
                xmlGerado.Save(NomeArquivo)

                'Copia o arquivo para o diretório de envio
                If System.IO.File.Exists(NomeArquivo) Then
                    Dim NomeDestino As String
                    'Apaga também o retorno caso exista
                    If System.IO.File.Exists(My.Settings.PastaNFe & "\Retorno\" & oNFE.Id & "-sit.xml") Then
                        System.IO.File.Delete(My.Settings.PastaNFe & "\Retorno\" & oNFE.Id & "-sit.xml")
                    End If
                    If System.IO.File.Exists(My.Settings.PastaNFe & "\Retorno\" & oNFE.Id & "-sit.err") Then
                        System.IO.File.Delete(My.Settings.PastaNFe & "\Retorno\" & oNFE.Id & "-sit.err")
                    End If

                    NomeDestino = My.Settings.PastaNFe & "\Envio-Simples\" & oNFE.Id & "-ped-sit.xml"
                    'Se exisitir o arquivo ou está preso na fila
                    If System.IO.File.Exists(NomeDestino) Then
                        System.IO.File.Delete(NomeDestino)
                    End If
                    'Copia o arquivo na pasta de envio
                    System.IO.File.Copy(NomeArquivo, NomeDestino)
                End If
                Limite = 0
                tmrAguarda.Enabled = True
            Catch ex As Exception
                MsgBox("Erro ao tentar gerar o arquivo XML de Pedido de Situação!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub tmrAguarda_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAguarda.Tick
        If Limite >= 30 Then
            tmrAguarda.Enabled = False
            MsgBox("Tempo limite para operação está esgotado sem retorno do sistema", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.WaitCursor
            Exit Sub
        End If
        fnVerificaStatus()
        Limite += 1
    End Sub

    Private Sub fnVerificaStatus()
        Dim Chave As String = txtChaveNFe.Text
        Dim ArquivoXML As String = My.Settings.PastaNFe & "\Retorno\" & Chave

        '51080662675686000166550010000001041671821888-sit.err
        If System.IO.File.Exists(ArquivoXML & "-sit.err") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            MsgBox("Erro ao tentar enviar o pedido de situação ao SEFAZ", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        ElseIf System.IO.File.Exists(ArquivoXML & "-sit.xml") Then
            'Para o cronometro
            tmrAguarda.Enabled = False
            getConsultaInfo(ArquivoXML & "-sit.xml")
        End If
    End Sub

    Private Sub getConsultaInfo(ByVal ArquivoXML)
        'Verifica se realmente existe o arquivo de retorno
        If System.IO.File.Exists(ArquivoXML) Then
            'CRIA UM NOVO DOCUMENTO XML
            Dim dados As XmlDocument = New XmlDocument

            'Le o arquivo da XML da Consulta
            dados.Load(ArquivoXML)

            'Percorre os nós da XML procurando a informação desejada
            For Each NoNivel1 As XmlNode In dados
                If NoNivel1.Name = "retConsSitNFe" Then
                    For Each NoNivel2 As XmlNode In NoNivel1
                        Select Case NoNivel2.Name
                            Case "tpAmb"
                                lblAmbiente.Text = NoNivel2.ChildNodes(0).InnerText
                            Case "cStat"
                                lblStatus.Text = NoNivel2.ChildNodes(0).InnerText
                            Case "xMotivo"
                                lblMotivo.Text = NoNivel2.ChildNodes(0).InnerText
                            Case "cUF"
                                lblEstado.Text = NoNivel2.ChildNodes(0).InnerText
                            Case "chNFe"
                                lblChaveNFe.Text = NoNivel2.ChildNodes(0).InnerText
                            Case "protNFe"
                                For Each NoNivel3 As XmlNode In NoNivel2
                                    If NoNivel3.Name = "infProt" Then
                                        For Each NoNivel4 As XmlNode In NoNivel3
                                            Select Case NoNivel4.Name
                                                Case "dhRecbto"
                                                    lblData.Text = NoNivel4.ChildNodes(0).InnerText.Substring(0, 10)
                                                    lblHora.Text = NoNivel4.ChildNodes(0).InnerText.Substring(11, 8)
                                                Case "nProt"
                                                    lblProtocolo.Text = NoNivel4.ChildNodes(0).InnerText
                                                Case "digVal"
                                                    lblDigest.Text = NoNivel4.ChildNodes(0).InnerText
                                                Case "cStat"
                                                    lblStatus1.Text = NoNivel4.ChildNodes(0).InnerText
                                                Case "xMotivo"
                                                    lblMotivo1.Text = NoNivel4.ChildNodes(0).InnerText
                                            End Select
                                        Next
                                    End If
                                Next
                        End Select
                    Next
                End If
            Next
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtChaveNFe.Text = String.Empty
        lblAmbiente.Text = "..."
        lblAmbText.Text = "..."
        lblChaveNFe.Text = "..."
        lblData.Text = "..."
        lblDigest.Text = "..."
        lblEstado.Text = "..."
        lblHora.Text = "..."
        lblMotivo.Text = "..."
        lblMotivo1.Text = "..."
        lblProtocolo.Text = "..."
        lblStatus.Text = "..."
        lblStatus1.Text = "..."
        txtChaveNFe.Focus()
    End Sub

    Private Sub lblAmbiente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAmbiente.TextChanged
        lblAmbText.Text = IIf(lblAmbiente.Text = "1", "Produção", "Homologação")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Clipboard.Clear()
        Clipboard.SetText(lblProtocolo.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clipboard.Clear()
        Clipboard.SetText(lblDigest.Text)
    End Sub
End Class