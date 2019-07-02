Imports System.Diagnostics.Process

Public Class frmBackup

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Ativa a caixa de diálogo
        dlgFolder.ShowDialog()
        'Captura o caminho
        txtCaminho.Text = dlgFolder.SelectedPath & "\"
    End Sub

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btBackup_Click(sender As System.Object, e As System.EventArgs) Handles btBackup.Click

        Dim Arquivo As String

        Arquivo = "Backup-" & Format(Today.Date, "dd-MM-yyyy") & ".sql"
        'Arquivo = "Backup.sql"
        'Options = "--host=" & My.Settings.MyServer & " --user=" & My.Settings.MyUsername & " --password=" & My.Settings.MyPassword & " --database " & My.Settings.MyDB & " > " & txtCaminho.Text & Arquivo
        'Console.WriteLine(Options)
        'Process.Start("C:\mysqldump.exe", "--host=10.1.1.254 --user=root --password=db0102 --database Controle > c:\backup.sql")
        If Not System.IO.File.Exists("c:\mysqldump.exe") Then
            MsgBox("Ferramenta de Backup não localizada (MySQLDump)" & vbCrLf & "Não é possível realizar o backup", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        Else
            'Se for possível executa o backup
            Shell("C:\mysqldump.exe --host=" & My.Settings.MyServer & " --user=" & My.Settings.MyUsername & " --password=" & My.Settings.MyPassword & " --database Controle -r " & txtCaminho.Text & Arquivo, AppWinStyle.Hide, True, 10000)
        End If
        If System.IO.File.Exists(txtCaminho.Text & Arquivo) Then
            MsgBox("Backup efetuado com sucesso!" & vbCrLf & "Arquivo Gerado: " & txtCaminho.Text & Arquivo)
            Exit Sub
        Else
            MsgBox("Erro ao efetuar o backup. Arquivo: " & txtCaminho.Text & Arquivo & " não localizado!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
        Exit Sub
    End Sub

    Private Sub frmBackup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtCaminho.Text = "C:\"
    End Sub
End Class