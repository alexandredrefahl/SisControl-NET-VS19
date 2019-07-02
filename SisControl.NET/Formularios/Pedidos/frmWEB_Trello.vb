Public Class frmWEB_Trello
    Private Sub frmWEB_Trello_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Endereco As String = "https://trello.com/b/TMq7enaD/acompanhamento-clientes"
        wbBrowser.Navigate(New Uri(Endereco))
    End Sub
End Class