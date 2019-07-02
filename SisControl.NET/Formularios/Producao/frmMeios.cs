using System.Drawing;
using System.Data;
using Microsoft.VisualBasic;
using System;

public partial class frmMeios
{
    private void frmMeios_Load(System.Object sender, System.EventArgs e)
    {
        // Carrega a lista de meio de cultura
        Biblioteca.Carrega_Lista(ref cmbMeio, "meio", "id", "meio", true);
        Biblioteca.Carrega_Lista(ref cmbBase, "meiosbase", "id", "Nome");
    }

    private void btCor1_Click(System.Object sender, System.EventArgs e)
    {
        Color Cor;
        cdCores.ShowDialog();
        Cor = cdCores.Color;
        lblCor1.BackColor = Cor;
        txtCor1.Text = Cor.R.ToString("000") + ";" + Cor.G.ToString("000") + ";" + Cor.B.ToString("000");
    }

    private void btCor2_Click(System.Object sender, System.EventArgs e)
    {
        Color Cor;
        cdCores.ShowDialog();
        Cor = cdCores.Color;
        lblCor2.BackColor = Cor;
        txtCor2.Text = Cor.R.ToString("000") + ";" + Cor.G.ToString("000") + ";" + Cor.B.ToString("000");
    }

    private void Button3_Click(System.Object sender, System.EventArgs e)
    {
        Limpa_Campos();
    }

    private void Limpa_Campos()
    {
        txtDescricao.Text = "";
        txtConstituicao.Text = "";
        cmbBase.SelectedIndex = -1;
        cmbBase.Text = "";
        txtPH.Text = "";
        txt24D.Text = "";
        txt2IP.Text = "";
        txtABA.Text = "";
        txtAIA.Text = "";
        txtAIB.Text = "";
        txtANA.Text = "";
        txtBAP.Text = "";
        txtCor1.Text = "";
        txtCor2.Text = "";
        txtOutros.Text = "";
        lblCor1.BackColor = Color.White;
        lblCor2.BackColor = Color.White;
        TabControl1.TabIndex = 0;
        txtDescricao.Focus();
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string SQL;
        // Se for um meio novo Que ainda não tem código
        if (cmbMeio.SelectedIndex == -1)
            SQL = Monta_SQL("INSERT");
        else
            // Se for um meio que já existe e só é preciso alterar
            SQL = Monta_SQL("UPDATE");

        try
        {
            Biblioteca.ExecutaSQL(SQL);
            if (cmbMeio.SelectedIndex == -1)
                Interaction.MsgBox("Meio de cultura incluído com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação");
            else
                Interaction.MsgBox("Meio de cultura salvo com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar salvar o meio de cultura atual." + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical);
            return;
        }
    }

    private string Monta_SQL(string Tipo)
    {
        string SQL = string.Empty;
        if (!Tipo == string.Empty)
        {
            // Verifica qual o tipo de SQL que se precisa
            if (Tipo == "INSERT")
                SQL = "INSERT INTO Meio SET ";
            else if (Tipo == "UPDATE")
                SQL = "UPDATE Meio SET ";
            // Monta a parte comum às duas operações
            SQL += "Meio='" + txtDescricao.Text + "', ";
            SQL += "Constituicao='" + txtConstituicao.Text + "', ";
            SQL += "ph=" + Biblioteca.Numero_to_SQL(txtPH.Text) + ", ";
            SQL += "MeioBase=" + Biblioteca.cmbVal(ref cmbBase) + ", ";
            SQL += "ANA=" + Biblioteca.Numero_to_SQL(txtANA.Text) + ", ";
            SQL += "BAP=" + Biblioteca.Numero_to_SQL(txtBAP.Text) + ", ";
            SQL += "24D=" + Biblioteca.Numero_to_SQL(txt24D.Text) + ", ";
            SQL += "KIN=" + Biblioteca.Numero_to_SQL(txtKIN.Text) + ", ";
            SQL += "2iP=" + Biblioteca.Numero_to_SQL(txt2IP.Text) + ", ";
            SQL += "ABA=" + Biblioteca.Numero_to_SQL(txtABA.Text) + ", ";
            SQL += "TDZ=" + Biblioteca.Numero_to_SQL(txtTDZ.Text) + ", ";
            SQL += "AIB=" + Biblioteca.Numero_to_SQL(txtAIB.Text) + ", ";
            SQL += "AIA=" + Biblioteca.Numero_to_SQL(txtAIA.Text) + ", ";
            SQL += "GA3=" + Biblioteca.Numero_to_SQL(txtGA3.Text) + ", ";
            SQL += "Outros=" + Biblioteca.Texto_Vazio(txtOutros.Text) + ",";
            SQL += "Cor1=" + Biblioteca.Texto_Vazio(txtCor1.Text) + ",";
            SQL += "Cor2=" + Biblioteca.Texto_Vazio(txtCor2.Text);
            // Se for do tipo UPDATE tem que definir o ID para alteração
            if (Tipo == "UPDATE")
                SQL += " WHERE id=" + Biblioteca.cmbVal(ref cmbMeio);
        }
        return SQL;
    }

    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmbMeio_Leave(System.Object sender, System.EventArgs e)
    {
        // Se tiver algo selecionado....
        if (cmbMeio.SelectedIndex > -1)
        {
            DataRow Lin;
            // Pega a linha de dados correspondente ao registro localizado
            Lin = Biblioteca.DLookupRow("meio", "id=" + Biblioteca.cmbVal(ref cmbMeio));
            // Começa a preencher os campos
            txtDescricao.Text = Lin.Item["Meio"];
            txtConstituicao.Text = Biblioteca.NaoNulo(Lin.Item["Constituicao"]);
            Biblioteca.Localiza_Item(ref cmbBase, Lin.Item["MeioBase"]);
            txtPH.Text = Strings.Format(Lin.Item["ph"], "N2");
            txt24D.Text = Biblioteca.NaoNulo(Lin.Item["24D"]);
            txt2IP.Text = Biblioteca.NaoNulo(Lin.Item["2IP"]);
            txtABA.Text = Biblioteca.NaoNulo(Lin.Item["ABA"]);
            txtAIA.Text = Biblioteca.NaoNulo(Lin.Item["AIA"]);
            txtAIB.Text = Biblioteca.NaoNulo(Lin.Item["AIB"]);
            txtANA.Text = Biblioteca.NaoNulo(Lin.Item["ANA"]);
            txtBAP.Text = Biblioteca.NaoNulo(Lin.Item["BAP"]);
            txtGA3.Text = Biblioteca.NaoNulo(Lin.Item["GA3"]);
            txtTDZ.Text = Biblioteca.NaoNulo(Lin.Item["TDZ"]);
            txtKIN.Text = Biblioteca.NaoNulo(Lin.Item["KIN"]);
            txtCor1.Text = Biblioteca.NaoNulo(Lin.Item["Cor1"]);
            txtCor2.Text = Biblioteca.NaoNulo(Lin.Item["Cor2"]);
            txtOutros.Text = Biblioteca.NaoNulo(Lin.Item["Outros"]);
            // Verifica se o meio tem alguma cor cadastrada
            string[] divideCOR1;
            if (!Information.IsDBNull(Lin.Item["Cor1"]) & !Lin.Item["Cor1"].ToString() == string.Empty)
            {
                divideCOR1 = Lin.Item["Cor1"].ToString().Split(";");
                lblCor1.BackColor = Color.FromArgb(divideCOR1[0], divideCOR1[1], divideCOR1[2]);
            }
            string[] divideCOR2;
            if (!Information.IsDBNull(Lin.Item["Cor2"]) & !Lin.Item["Cor2"].ToString() == string.Empty)
            {
                divideCOR2 = Lin.Item["Cor2"].ToString().Split(";");
                lblCor2.BackColor = Color.FromArgb(divideCOR2[0], divideCOR2[1], divideCOR2[2]);
            }
            TabControl1.TabIndex = 0;
            txtDescricao.Focus();
        }
    }

    private void cmbBase_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
    }
}
