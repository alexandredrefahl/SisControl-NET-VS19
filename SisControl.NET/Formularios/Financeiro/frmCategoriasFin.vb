Public Class frmCategoriasFin

    Private Sub CategoriasfinBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriasfinBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CategoriasfinBindingSource.EndEdit()
        Me.CategoriasfinTableAdapter.Update(Me.DsCadastro.categoriasfin)

    End Sub

    Private Sub frmCategoriasFin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCadastro.categoriasfin' table. You can move, or remove it, as needed.
        Me.CategoriasfinTableAdapter.Fill(Me.DsCadastro.categoriasfin)

        'Preenche o combo com as categorias cadastradas
        Carrega_Lista(cmbCategoria, "CategoriasFin", "id", "Descricao", True)

    End Sub


    Private Sub cmbCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria.SelectedIndexChanged
        'Localiza o registro selecionado na Combo
        CategoriasfinBindingSource.Position = CategoriasfinBindingSource.Find("id", cmbVal(cmbCategoria))

    End Sub
End Class