Public Class frmPlantioOrquideas

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbLote.Text.Length = 0 Then
            Exit Sub
        End If

        Dim a As Integer
        a = MsgBox("Confirma a inclusão de mudas de plantio no lote " & cmbLote.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        If a = vbYes Then
            Dim SQL As String
            SQL = "UPDATE Germinacao SET NPlantadas=NPlantadas+" & txtQuantidade.Text & " WHERE id=" & cmbVal(cmbLote)
            Try
                ExecutaSQL(SQL)
                MsgBox("Nº de mudas plantadas registrado com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
            Catch ex As Exception
                MsgBox("Erro ao tentar registrar o número de mudas plantadas do lote " & cmbLote.Text & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub frmPlantioOrquideas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carrega_Lista(cmbLote, "Germinacao", "ID", "Cod", True, "Ativo=1")
    End Sub
End Class