Public Class frmRepicadores

    Private Sub RepicadorBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepicadorBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.RepicadorBindingSource.EndEdit()
        Me.RepicadorTableAdapter.Update(Me.DsCadastro.repicador)

    End Sub

    Private Sub frmRepicadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCadastro.repicador' table. You can move, or remove it, as needed.
        Me.RepicadorTableAdapter.Fill(Me.DsCadastro.repicador)

        'Carrega o combo com a lista dos Repicadores
        Carrega_Lista(cmbRepicador, "Repicador", "id", "Nome", True)
    End Sub

    Private Sub cmbRepicador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRepicador.SelectedIndexChanged
        'move o registro atual para coincidir com a Combobox
        RepicadorBindingSource.Position = RepicadorBindingSource.Find("id", cmbVal(cmbRepicador))
    End Sub
End Class