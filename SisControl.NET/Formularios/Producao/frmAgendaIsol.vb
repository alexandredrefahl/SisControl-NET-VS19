Public Class frmAgendaIsol
    Private Sub frmAgendaIsol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQL As String, DT As DataTable
        SQL = "SELECT * FROM isolamentos_vencidos"
        Try
            DT = SQLQuery(SQL)
            dgAgenda.DataSource = DT
            Formata_Grid()
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar os isolamentos vencidos" & vbCrLf & ex.Message & vbCrLf & ex.ToString & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub chkShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShow.CheckedChanged
        'quando mudar o estado desta caixinha
        My.Settings.ShowSchl = chkShow.Checked
        My.Settings.Save()
    End Sub

    Private Sub Formata_Grid()
        Dim Textos() As String = {"ID", "Código", "Data", "Dias", "Venceu"}
        Dim Larguras() As Integer = {0, 71, 71, 37, 71}
        Dim Visiveis() As Integer = {0, 1, 1, 1, 1}
        Formata_Datagrid(dgAgenda, Textos, Larguras, Visiveis)
    End Sub
End Class