public partial class frmRepicadores
{
    private void RepicadorBindingNavigatorSaveItem_Click(System.Object sender, System.EventArgs e)
    {
        this.Validate();
        this.RepicadorBindingSource.EndEdit();
        this.RepicadorTableAdapter.Update(this.DsCadastro.repicador);
    }

    private void frmRepicadores_Load(System.Object sender, System.EventArgs e)
    {
        // TODO: This line of code loads data into the 'DsCadastro.repicador' table. You can move, or remove it, as needed.
        this.RepicadorTableAdapter.Fill(this.DsCadastro.repicador);

        // Carrega o combo com a lista dos Repicadores
        Biblioteca.Carrega_Lista(ref cmbRepicador, "Repicador", "id", "Nome", true);
    }

    private void cmbRepicador_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        // move o registro atual para coincidir com a Combobox
        RepicadorBindingSource.Position = RepicadorBindingSource.Find("id", Biblioteca.cmbVal(ref cmbRepicador));
    }
}
