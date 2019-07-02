using Microsoft.VisualBasic;
using System;

public partial class frmPlantioOrquideas
{
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        if (cmbLote.Text.Length == 0)
            return;

        int a;
        a = Interaction.MsgBox("Confirma a inclusão de mudas de plantio no lote " + cmbLote.Text + "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");
        if (a == Constants.vbYes)
        {
            string SQL;
            SQL = "UPDATE Germinacao SET NPlantadas=NPlantadas+" + txtQuantidade.Text + " WHERE id=" + Biblioteca.cmbVal(ref cmbLote);
            try
            {
                Biblioteca.ExecutaSQL(SQL);
                Interaction.MsgBox("Nº de mudas plantadas registrado com sucesso!", MsgBoxStyle.OkOnly, "Confirmação");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar registrar o número de mudas plantadas do lote " + cmbLote.Text + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
                return;
            }
        }
    }

    private void frmPlantioOrquideas_Load(System.Object sender, System.EventArgs e)
    {
        Biblioteca.Carrega_Lista(ref cmbLote, "Germinacao", "ID", "Cod", true, "Ativo=1");
    }
}
