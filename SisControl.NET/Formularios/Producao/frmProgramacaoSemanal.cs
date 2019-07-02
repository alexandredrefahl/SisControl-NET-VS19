using CrystalDecisions.Windows.Forms.Internal.Win32;
using CrystalDecisions;
using CrystalDecisions.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using CrystalDecisions.Windows;
using System.Collections.Generic;
using System.Collections;
using System;
using CrystalDecisions.Windows.Forms.Internal;
using MySql.Data.MySqlClient;

public partial class frmProgramacaoSemanal
{
    private int ProgID;

    private void frmProgramacaoSemanal_Load(System.Object sender, System.EventArgs e)
    {
    }

    private void cmbProduto_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        // Se não houver produto selecionado
        if (cmbProduto.SelectedIndex == -1)
            return;
        // Carrega os clones assim que a caixa de produtos for alterada
        Biblioteca.Carrega_Lista(ref cmbClone, "clones_num", "id", "nome", true, "Mercadoria=" + Biblioteca.cmbVal(ref cmbProduto));
        cmbClone.Items.Add(new MeuItemData("9999", "XXXX - Todos"));
    }

    private void cmbClone_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        // Se houver algum clone selecionado
        if (cmbClone.SelectedIndex == -1)
            return;

        if (Biblioteca.cmbVal(ref cmbClone) == "9999")
            return;

        // não precisa procurar os lotes de origem se não for repicagem
        if (rdPlantio.Checked | rdGeral.Checked)
            return;
        MySqlConnection myConn = new MySqlConnection();

        // Cria uma conexao temporaria para criar um TableAdapter
        string SQL;
        myConn.ConnectionString = Biblioteca.MY_SQL_CONNECTION;
        // Cria um Table Adapter
        SQL = "SELECT Codigo as colCodigo,Fase as colFase,Est_Frascos as colEstoque,Repicagem as colDataRep,Data as colData,Vencido as colVencido FROM lotes_vencidos WHERE Mercadoria=" + Biblioteca.cmbVal(ref cmbProduto) + " AND Clone=" + cmbClone.Text.Substring(0, 4) + " ORDER BY Vencido DESC ,Codigo";
        Console.WriteLine("SQL: " + SQL);
        MySqlDataAdapter myTa = new MySqlDataAdapter(SQL, myConn);
        // Se o table adapter tiver funcional
        if (!Information.IsNothing(myTa))
        {
            // Limpa o DataSet Primeiro
            dsLotesVencidos.Tables.Clear();
            // Preenche o DataSet com os novos valores
            myTa.Fill(dsLotesVencidos);
            // Nomeia a tabela
            dsLotesVencidos.Tables[0].TableName = "LotesV";
            // Atribui ao datagrig
            dgProducao.DataSource = dsLotesVencidos.Tables[0];
        }
    }

    private void Recalcula()
    {

        // Se a opção TODOS estiver selecionada
        if (Biblioteca.cmbVal(ref cmbClone) == "9999" & txtQtdeMudas.Text > 0 & txtQtdeMudas.Text != "" & txtM_F.Text > 0 & txtM_F.Text != "")
        {
            txtQtdeMeio.Text = txtQtdeMudas.Text / (double)txtM_F.Text / 50;
            return;
        }

        // Se estiver tudo selecionado
        if (txtQtdeMudas.Text > 0 & txtQtdeMudas.Text != "" & txtM_F.Text > 0 & txtM_F.Text != "" & cmbProduto.SelectedIndex > -1 & cmbClone.SelectedIndex > -1 & cmbFase.SelectedIndex > -1)
        {
            // Quantidade de mudas / Num de mudas por frasco / 50 frascos em 1 litro
            txtQtdeMeio.Text = txtQtdeMudas.Text / (double)txtM_F.Text / 50;
            // Busca o meio de cultura
            int meio = -1;
            switch (cmbFase.Text)
            {
                case "Isolamento":
                    {
                        meio = Biblioteca.DLookup("MeioISO", "Mercadoria", "id=" + Biblioteca.cmbVal(ref cmbProduto));
                        break;
                    }

                case "Multiplicação":
                    {
                        meio = Biblioteca.DLookup("MeioMUL", "Mercadoria", "id=" + Biblioteca.cmbVal(ref cmbProduto));
                        break;
                    }

                case "Alongamento":
                    {
                        meio = Biblioteca.DLookup("MeioALO", "Mercadoria", "id=" + Biblioteca.cmbVal(ref cmbProduto));
                        break;
                    }

                case "Enraizamento":
                    {
                        meio = Biblioteca.DLookup("MeioENR", "Mercadoria", "id=" + Biblioteca.cmbVal(ref cmbProduto));
                        break;
                    }

                case "Manutenção":
                    {
                        meio = Biblioteca.DLookup("MeioMAN", "Mercadoria", "id=" + Biblioteca.cmbVal(ref cmbProduto));
                        break;
                    }
            }
            // Se localizou alguma coisa
            if (meio != -1)
                // Localiza o ítem cujo id é o que foi localizado
                Biblioteca.Localiza_Item(ref cmbMeios, meio);
            // Calcula o próximo lote
            int MaxLote = -1;
            MaxLote = Biblioteca.DMax("lote", "Lotes", "Mercadoria=" + Biblioteca.cmbVal(ref cmbProduto) + " AND Clone=" + cmbClone.Text.Substring(0, 4));
            // Se retornou algo
            if (MaxLote > -1 & !Information.IsDBNull(MaxLote))
                // Calcula o próximo lote da sequencia
                txtProximoLote.Text = Strings.Format(Biblioteca.cmbVal(ref cmbProduto), "000") + "." + Strings.Format(MaxLote + 1, "000") + "." + cmbClone.Text.Substring(0, 4);
        }
    }

    private void txtQtdeMudas_Leave(System.Object sender, System.EventArgs e)
    {
        Recalcula();
    }

    private void cmbFase_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        Recalcula();
    }

    private void txtM_F_Leave(System.Object sender, System.EventArgs e)
    {
        Recalcula();
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string SQL = "";

        // Monta a SQL da Inclusão ou de Alteração
        string varOrigem = string.Empty;

        if (Button1.Text == "Incluir")
            // SQL geral
            SQL = "INSERT INTO programacao SET ";
        else if (Button1.Text == "Salvar")
            // SQL geral
            SQL = "UPDATE programacao SET ";


        // Muda para cada tipo

        // Repicagem
        if (rdRepicagem.Checked)
        {
            varOrigem = lista_lotes();
            SQL += "Tipo='R',";
            SQL += "Data='" + Strings.Format(txtData.Value, "yyyy-MM-dd") + "',";
            SQL += "Mercadoria=" + Biblioteca.cmbVal(ref cmbProduto) + ",";
            SQL += "Clone='" + cmbClone.Text.Substring(0, 4) + "',";
            SQL += "Mudas=" + txtQtdeMudas.Text + ",";
            SQL += "Fase=" + Biblioteca.cmbVal(ref cmbFase) + ",";
            SQL += "Mds_Frasco=" + txtM_F.Text + ",";
            SQL += "Meio=" + Biblioteca.cmbVal(ref cmbMeios) + ",";
            SQL += "Meio_Desc='" + cmbMeios.Text + "',";
            SQL += "Meio_Qtde=" + Biblioteca.Numero_to_SQL(txtQtdeMeio.Text) + ",";
            SQL += "Meio_S_L='" + Interaction.IIf(rdLiquido.Checked, "L", "S") + "'" + ",";
            SQL += "Observacao='" + txtObs.Text + "',";
            SQL += "Codigo='" + txtProximoLote.Text + "',";
            SQL += "Origem='" + varOrigem + "',";
            SQL += "Frasco='" + cmbFrasco.Text + "'";
        }
        // Plantio
        if (rdPlantio.Checked)
        {
            SQL += "Tipo='P',";
            SQL += "Data='" + Strings.Format(txtData.Value, "yyyy-MM-dd") + "',";
            SQL += "Mercadoria=" + Biblioteca.cmbVal(ref cmbProduto) + ",";
            SQL += "Clone='" + cmbClone.Text.Substring(0, 4) + "',";
            SQL += "Mudas=" + txtQtdeMudas.Text + ",";
            SQL += "Fase=" + Biblioteca.cmbVal(ref cmbFase) + ",";
            SQL += "Observacao='" + txtObs.Text + "'";
        }
        // Geral
        if (rdGeral.Checked)
        {
            SQL += "Tipo='G',";
            SQL += "Data='" + Strings.Format(txtData.Value, "yyyy-MM-dd") + "',";
            SQL += "Observacao='" + txtObs.Text + "'";
        }

        string Mensagem = string.Empty;
        // Acrescenta o identificador par que não altere todos os registros.
        if (Button1.Text == "Salvar")
        {
            SQL += " WHERE id=" + Conversion.Int(lblID.Text);
            Mensagem = "Alteração da Ordem de Produção nº: " + lblID.Text + " realizada com sucesso";
        }
        else if (Button1.Text == "Incluir")
            Mensagem = "Inclusão da Ordem de Produção no dia " + txtData.Value.Date + " realizada com sucesso";

        try
        {
            Console.WriteLine("Progamação: " + SQL);
            // Tenta executar a inclusão
            Biblioteca.ExecutaSQL(SQL);
            // Se der certo envia a mensagem conforme o tipo de operação (definidas acima)
            Interaction.MsgBox(Mensagem, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação");
            // Limpa para próxima inclusão
            Biblioteca.Limpa_Campos(ref this);
            dsLotesVencidos.Clear();
            txtProximoLote.Text = "000.000.0000";
            rdSolido.Checked = true;
            rdRepicagem.Checked = true;
            cmbFrasco.Text = "Frasco de Vidro";
            Button1.Text = "Incluir";
            lblID.Text = "";
            lblID.Visible = false;
            txtData.Focus();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar incluir programação" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            return;
        }
    }

    private void RadioButton3_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        Muda_Tipo();
    }

    private void RadioButton2_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        Muda_Tipo();
    }

    private void RadioButton1_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        Muda_Tipo();
    }

    private void Muda_Tipo()
    {
        string[] Nomes;
        // Se for uma ordem de repicagem
        if (rdRepicagem.Checked)
        {
            Nomes = new[] { "Nulo" };
            Biblioteca.Desabilita_Campos(ref this, Nomes);
        }
        // Se for uma ordem de plantio
        if (rdPlantio.Checked)
        {
            Nomes = new[] { "txtM_F", "grpLotesOrigem", "txtQtdeMeio", "cmbMeios", "rdSolido", "rdLiquido", "txtProximoLote", "dgProducao" };
            Biblioteca.Desabilita_Campos(ref this, Nomes);
        }
        // Se for uma ordem Geral (limpeza, arrumação etc...)
        if (rdGeral.Checked)
        {
            Nomes = new[] { "cmbProduto", "cmbClone", "txtQtdeMudas", "cmbFase", "txtM_F", "grpLotesOrigem", "txtQtdeMeio", "cmbMeios", "rdSolido", "rdLiquido", "txtProximoLote", "dgProducao" };
            Biblioteca.Desabilita_Campos(ref this, Nomes);
        }
    }

    private string lista_lotes()
    {
        string ret = string.Empty;
        if (dgProducao.SelectedRows.Count > 0)
        {
            // Percorre todas as linhas selecionadas
            for (int i = 0; i <= dgProducao.SelectedRows.Count - 1; i++)
            {
                if (i > 0)
                    ret += "/";
                ret += dgProducao.SelectedRows[i].Cells[0].Value;
            }
        }
        // Se não tiver nada selecionado volta uma string vazia
        return ret;
    }

    public frmProgramacaoSemanal(int ID = -1)
    {

        // This call is required by the designer.
        // Add any initialization after the InitializeComponent() call.
        InitializeComponent();

        // Atualiza a Data
        txtData.Value = DateTime.Now;
        // Carrega os combos
        Biblioteca.Carrega_Lista(ref cmbProduto, "mercadoria_num", "id", "Nome", true);
        // Carrega a lista dos meios
        Biblioteca.Carrega_Lista(ref cmbMeios, "Meio", "id", "meio", true);
        // Carrega lista das fases
        Biblioteca.Carrega_Lista(ref cmbFase, "Fases", "id", "Fase", true);

        // Se foi passado algum parametro então carrega os dados
        if (ID != -1)
        {
            ProgID = ID;
            Carrega_Programacao();
        }
    }

    private void Carrega_Programacao()
    {
        DataRow DR;

        lblID.Visible = true;
        lblID.Text = ProgID.ToString("0000000");
        Button1.Text = "Salvar";

        try
        {
            DR = Biblioteca.DLookupRow("Programacao", "id=" + ProgID);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar recuperar a Ordem de Produção núm " + ProgID + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
            return;
        }
        // Não é possível carregar a programação ou ela não existe mais
        if (Information.IsNothing(DR) | Information.IsDBNull(DR))
            return;

        {
            var withBlock = DR;
            // Primeiro carrega os check box baseado no DR
            switch (withBlock.Item["Tipo"])
            {
                case "R":
                    {
                        rdRepicagem.Checked = true;
                        break;
                    }

                case "P":
                    {
                        // Plantio carrega somente alguns ítens
                        rdPlantio.Checked = true;
                        break;
                    }

                case "G":
                    {
                        // Geral carrega somente observações
                        rdGeral.Checked = true;
                        break;
                    }
            }
            // *
            // * 1ª ETAPA - Verifica as informações que são comuns aos três tipos
            // *
            // * Data; Observações
            // *

            // Observações
            txtObs.Text = withBlock.Item["Observacao"];
            // Data
            txtData.Text = withBlock.Item["Data"];

            // Se for uma ordem Geral, já sai aqui
            if (rdGeral.Checked == true)
                return;

            // *
            // * 2ª ETAPA - Verifica o que é tem também no plantio
            // *
            // * Mercadoria; Clone; Quantidade; Fase;
            // *

            // Define o produto a ser Trabalhado
            Biblioteca.Localiza_Item(ref cmbProduto, withBlock.Item["Mercadoria"]);
            cmbProduto.Refresh();
            // Localiza e define o clone
            Biblioteca.Localiza_Item(ref cmbClone, withBlock.Item["Clone"]);
            cmbClone.Text = withBlock.Item["Clone"];
            cmbClone.Refresh();
            // Quantidade
            txtQtdeMudas.Text = withBlock.Item["Mudas"];
            // Fase
            Biblioteca.Localiza_Item(ref cmbFase, withBlock.Item["Fase"]);

            // Se for uma ordem de plantio já sai aqui e não termina de carregar o resto
            if (rdPlantio.Checked)
                return;

            // *
            // * 3ª ETAPA - Se é uma ordem de Repicagem termina de carregar todo o resto
            // *
            // * Mds/Frasco; Codigo; Quantidade; Tipo meio;
            // *

            // Mudas por frasco
            txtM_F.Text = withBlock.Item["Mds_frasco"];
            // Codigo do novo lote
            txtProximoLote.Text = withBlock.Item["Codigo"];
            // Quantidade de Meio
            txtQtdeMeio.Text = withBlock.Item["Meio_Qtde"];
            // Tipo de meio
            Biblioteca.Localiza_Item(ref cmbMeios, withBlock.Item["Meio"]);
            cmbMeios.Refresh();
            // Sólido ou líquido
            if (withBlock.Item["Meio_S_L"] == "S")
                rdSolido.Checked = true;
            else
                rdLiquido.Checked = true;
            cmbFrasco.Text = withBlock.Item["Frasco"];
        }
    }
}
