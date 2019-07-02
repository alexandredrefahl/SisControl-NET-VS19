Imports System.Net.Mail

Public Class frmNFEFechamento

    Private Sub frmNFEFechamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMesAno.Text = Format(Date.Today, "MM/yyyy")
        txtEmail.Text = DLookup("valor", "parametros", "Nome='emailContador'")
        txtMesAno.Focus()
    End Sub

    Private Sub txtMesAno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesAno.Leave
        'Quando sai verifica o mes e ano para ver o que há
        Dim DT As DataTable
        Dim SQL As String, s() As String

        'Valida a data
        If txtMesAno.Text = "__/" Then
            MsgBox("Digite o mes e o ano no formato 99/9999", MsgBoxStyle.Critical, "Erro")
        End If


        SQL = "SELECT SUM(vtotal) as Total, count(vtotal) as Numero FROM Docs WHERE Month(Data)=" & txtMesAno.Text.Substring(0, 2) & " AND Year(Data)=" & txtMesAno.Text.Substring(3, 4)
        Try
            'Verifica os arquivos das notas 
            s = System.IO.Directory.GetFiles(My.Settings.PastaNFe & "\Enviado\Autorizados\" & txtMesAno.Text.Substring(3, 4) & txtMesAno.Text.Substring(0, 2) & "\", "*-procNfe.xml")
            lblNArq.Text = s.Length
            'Verifica as notas no banco de dados
            DT = SQLQuery(SQL)
            If DT.Rows.Count > 0 Then
                lblValSai.Text = Format(DT.Rows(0).Item("Total"), "N2")
                lblNSai.Text = Format(CDbl(DT.Rows(0).Item("Numero")), "N0")
                'Totaliza
                lblTotal.Text = Format(CDbl(lblValSai.Text) + CDbl(lblValEnt.Text), "N2")
                lblNEmi.Text = Format(CDbl(lblNSai.Text) + CDbl(lblNEnt.Text), "N0")
            End If
        Catch ex As Exception
            MsgBox("Não foi possível resgatar os dados das NFe do período" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Arquivo As String
        Dim email As New MailMessage()              'Criar o objeto email
        email.From = New MailAddress("comercial@clona-gen.com.br") 'Informar quem esta enviando o e-mail
        email.To.Add(txtEmail.Text)                 'Para quem eu quero mandar o e-mail
        email.CC.Add("comercial@clona-gen.com.br")  'Com cópia

        'Cursor de espera
        Me.Cursor = Cursors.WaitCursor

        msg("Criando arquivo...")
        'Arquivo em anexo
        Arquivo = "NFe-" & txtMesAno.Text.Substring(0, 2) & "-" & txtMesAno.Text.Substring(3, 4)
        'Pega o nome do arquivo
        sfdArquivo.FileName = Arquivo & ".zip"
        'Pede interação do usuário
        sfdArquivo.ShowDialog()
        'Criar o arquivo ZIP
        msg("Localizando NFEs arquivo...")
        'Dim ZipFile = "C:\" & Arquivo & ".zip"
        Dim ZipFile = sfdArquivo.FileName
        Dim Comando As String, Pasta As String
        Pasta = "\Enviado\Autorizados\" & txtMesAno.Text.Substring(3, 4) & txtMesAno.Text.Substring(0, 2) & "\"
        'Verifica se existe o diretorio
        If System.IO.Directory.Exists(My.Settings.PastaNFe & Pasta) Then
            Pasta &= "*-procNfe.xml"
            Comando = My.Settings.CaminhoZIP & " -a -r " & ZipFile & " " & My.Settings.PastaNFe & Pasta
            Try
                msg("Compactando XMLs...")
                Shell(Comando, AppWinStyle.Hide, True, 60000)
                email.Attachments.Add(New Attachment(ZipFile))
            Catch ex As Exception
                MsgBox("Não foi possível encontrar o Compactador de Arquivos", MsgBoxStyle.Critical, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try
        Else
            MsgBox("Não foi possível encontrar a pasta das NFe", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        msg("Compondo E-mail...")
        email.Subject = "CLONA-GEN NFe Emitidas em " & txtMesAno.Text  'Asssunto

        'Conteudo
        email.Body = Cria_Body()
        email.IsBodyHtml = True 'HTML ou não
        email.Priority = MailPriority.Normal 'Prioridade

        Dim mlSMTP As String = "mail.clona-gen.com.br"
        Dim smtpClient As New SmtpClient(mlSMTP)
        Try
            'ENvia o email
            msg("Enviando E-mail...")
            smtpClient.Timeout = 100
            Dim credential As New System.Net.NetworkCredential("comercial+clona-gen.com.br", "16240423")
            smtpClient.Credentials = credential
            smtpClient.Send(email)
            MsgBox("E-mail enviado com sucesso", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow
            Me.Close()
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o e-mail contendo as NFe" & vbCrLf & ex.Message & vbCrLf & ex.ToString & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub msg(ByVal txt As String)
        lblMsg.Text = txt
        lblMsg.Refresh()
    End Sub

    Private Function Cria_Body() As String
        Dim Corpo As String
        Dim S() As String
        S = System.IO.Directory.GetFiles(My.Settings.PastaNFe & "\Enviado\Autorizados\" & txtMesAno.Text.Substring(3, 4) & txtMesAno.Text.Substring(0, 2) & "\", "*-procNfe.xml")

        Corpo = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        Corpo &= "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' />"
        Corpo &= "<title>Envio de NFe</title>"
        Corpo &= "<style type='text/css'>"
        Corpo &= "body {background-color: #666;}"
        Corpo &= "#apDiv1 {position:absolute;width:700px;height:auto;z-index:1;overflow:visible;background-color: #FFFFFF;text-align: center;font-family: Verdana, Geneva, sans-serif;left: 15%;border: solid;border-width: 1px;}"
        Corpo &= "#apDiv1 p {text-align: center;}"
        Corpo &= "#apDiv1 p.Corpo {text-align: justify;font-size:11px;margin-left:10px;margin-right:10px;}"
        Corpo &= "#apDiv1 table {text-align: center;font-family:Arial, Helvetica, sans-serif;font-size:15px;font-weight:bold;color: #F0FBF0;text-align: center;background-color: #C1EABD;}"
        Corpo &= "#apDiv1 .aviso {font-size:11px;color:#900;text-align:justify;font-weight: bold;padding-right: 4px;}"
        Corpo &= "</style></head><body><center><div id='apDiv1' align='center'>"
        Corpo &= "<img src='http://www.clona-gen.com.br/Cabecalho.jpg' alt='Logotipo' width='700' height='132'/><br/><br/>"
        Corpo &= "<table width='95%' border='0' align='center' cellpadding='0' cellspacing='0'>"
        Corpo &= "<tr><td bgcolor='#00923F'>NFe referentes à " & txtMesAno.Text & "</td></tr></table>"
        Corpo &= "<p class='Corpo'>Prezado Contador,</p><p class='Corpo'>Você está recebendo os arquivos XML das NFe emitidas no período de " & txtMesAno.Text & ". Em anexo um arquivo ZIP contendo as Notas Fiscais eletrônicas.</p>"
        Corpo &= "<p class='Corpo'>Abaixo a relação dos arquivos:</p>"
        Corpo &= "<p class='Corpo'>"
        Dim Ponto As Integer
        'Relaciona todas as notas
        For Each Arq As String In S
            Ponto = Arq.IndexOf(".")
            Corpo &= Arq.Substring(Ponto - 27, 9) & " - (" & Arq.Substring(Ponto - 52, 44) & ")<br/>"
        Next
        Corpo &= "</p>"
        Corpo &= "<p class='Corpo'>Atenciosamente,<br/>CLONA-GEN</p><p class='Corpo'>&nbsp;</p>"
        Corpo &= "<span class='aviso'>CLONA-GEN - Mensagem automática, favor não responder este   e-mail.</span></div>"
        Corpo &= "</center></body></html>"
        Return Corpo
    End Function

End Class