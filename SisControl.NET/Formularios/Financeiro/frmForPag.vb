Public Class frmForPag

    Private Sub ForpagBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForpagBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ForpagBindingSource.EndEdit()
        Me.ForpagTableAdapter.Update(Me.DsCadastro.forpag)

    End Sub

    Private Sub frmForPag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCadastro.forpag' table. You can move, or remove it, as needed.
        Me.ForpagTableAdapter.Fill(Me.DsCadastro.forpag)

        'Carrega o combo com as formas já cadastradas
        Carrega_Lista(cmbForma, "Forpag", "id", "Descricao", True)
    End Sub

    Private Sub cmbForma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForma.SelectedIndexChanged
        'Move o registro para que coincida com a Combo
        ForpagBindingSource.Position = ForpagBindingSource.Find("id", cmbVal(cmbForma))
    End Sub
End Class