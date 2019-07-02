using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;

public partial class frmPlantio
{
    public string varPlantador;
    public double varID;

    // Variáveis utilizadas na conexão mysql
    private MySql.Data.MySqlClient.MySqlConnection MyCON;
    private MySql.Data.MySqlClient.MySqlCommand MyCMD;
    private MySql.Data.MySqlClient.MySqlDataAdapter MyADA;

    private int Ordem_Producao;

    private void frmPlantio_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void frmPlantio_Load(System.Object sender, System.EventArgs e)
    {
        // Carrega lista de funcionários
        Biblioteca.Carrega_Lista(ref lstPlantador, "Repicador", "id", "Nome", true, "Ativo=1");
        // Carrega lista de clientes no combo
        Biblioteca.Carrega_Lista(ref cmbCliente, "Clientes", "id", "Nome", true);

        if (!Ordem_Producao == -1)
            Carrega_Ordem();
    }

    private void Carrega_Ordem()
    {
        DataRow DR;

        // Recupera os dados da ordem de produção que vai ser preenchida
        try
        {
            DR = Biblioteca.DLookupRow("programacao", "id=" + Ordem_Producao);
            if (!Information.IsDBNull(DR) & !Information.IsNothing(DR))
            {
                // Preenche os dados que vieram da programação
                txtMercadoria.Text = DR["Mercadoria"];
                txtClone.Text = DR["Clone"];
                txtNMudas.Text = DR["Mudas"];
                txtSubstrato.Text = "Casca de Pinus";
            }
        }
        catch (Exception ex)
        {
        }

        // Troca a cor dos campos que devem ser preenchidos
        // Muda a cor de fundo dos dados que devem ser preenchidos
        System.Drawing.Color cor;
        cor = Color.Khaki;

        txtData.BackColor = cor;
        txtNBandejas.BackColor = cor;
        lstPlantador.BackColor = cor;
    }

    private void txtMercadoria_Enter(object sender, System.EventArgs e)
    {
        txtMercadoria.SelectAll();
    }

    private void txtClone_Enter(object sender, System.EventArgs e)
    {
        txtClone.SelectAll();
    }

    private void txtSubstrato_Enter(object sender, System.EventArgs e)
    {
        txtSubstrato.SelectAll();
    }

    private void lstPlantador_Leave(object sender, System.EventArgs e)
    {
        object o;
        int num;
        ListBox.SelectedObjectCollection m = lstPlantador.SelectedItems;

        // Se não tiver nada selecionado
        if (Information.IsDBNull(m))
            // sai da rotina
            return;
        // senão processa cada item da lista
        varPlantador = string.Empty;
        num = m.Count;
        // Define um contador
        int i = 1;
        foreach (var o in m)
        {
            if (i < num)
                // soma os numeros em varRepicador
                varPlantador = varPlantador + o.valor.ToString() + ";";
            else
                // soma os numeros em varRepicador
                varPlantador = varPlantador + o.valor.ToString();
            i = i + 1;
        }
        // debug
        Console.WriteLine("VarPlantador=" + varPlantador);
    }

    private void btIncluir_Click(System.Object sender, System.EventArgs e)
    {

        // *
        // * FAZ ALGUMAS VERIFICAÇÕES
        // *

        if (txtMercadoria.Text == string.Empty | txtMercadoria.Text == "0")
        {
            Interaction.MsgBox("O código da mercadoria deve ser infomado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        if (txtClone.Text == string.Empty)
        {
            Interaction.MsgBox("O código do clone deve ser informado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        if (txtNBandejas.Text == string.Empty | txtNBandejas.Text == "0")
        {
            Interaction.MsgBox("O número de bandejas deve ser informado e não pode ser Zero", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        if (txtNMudas.Text == string.Empty | txtNMudas.Text == "0")
        {
            Interaction.MsgBox("O número de mudas deve ser informado e não pode ser zero", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        if (lstPlantador.SelectedItems.Count <= 0)
        {
            Interaction.MsgBox("É necessário informar a pessoa que plantou o lote.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        string SQL;
        int i;

        SQL = "INSERT INTO plantio (Data,Num_Mudas,Bandeja,Mercadoria,Substrato,Cliente,Plantador,Num_Bandejas,Clone) VALUES ";
        SQL = SQL + "('" + Strings.Format((DateTime)txtData.Text, "yyyy-MM-dd") + "'," + txtNMudas.Text + "," + Retorna_Bandeja() + "," + txtMercadoria.Text;
        SQL = SQL + ",'" + txtSubstrato.Text + "'," + Biblioteca.cmbVal(ref cmbCliente) + ",'" + varPlantador + "'," + txtNBandejas.Text + "," + txtClone.Text + ")";

        try
        {
            // Tenta incluir os dados
            Biblioteca.ExecutaSQL(SQL);

            // Se esse lote veio de uma ordem de produção então dá baixa da Ordem de Produção também
            if (Ordem_Producao != -1)
                Biblioteca.SQLQuery("UPDATE Programacao SET DataBaixa='" + Strings.Format((DateTime)txtData.Text, "yyyy-MM-dd") + "' WHERE id=" + Ordem_Producao);

            // Se conseguir segue adiante
            varID = Biblioteca.DMax("id", "plantio");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar incluir o plantio" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Exclamation);
            return;
        }

        // Habilita os dois quadros
        grpPlantio.Enabled = false;
        lblPlantio.Visible = true;
        lblPlantio.Text = "Plantio: " + Biblioteca.StrZero(varID, 4);
        grpBandejas.Enabled = true;
        grpOrigem.Enabled = true;

        // Inclui as bandejas automaticamente no cadastro de bandejas
        SQL = "INSERT INTO aux_bandejas (Tipo,Mudas,NAtual,Ativo,Mercadoria,Clone,Plantio,Data) VALUES ";
        int n = Conversion.Val(txtNBandejas.Text);
        int nMudas;
        for (i = 1; i <= n; i++)
        {
            nMudas = Retorna_Bandeja();
            // se for a última passada
            if (i == n)
                // Quanto seria todas as bandejas completas - o que falta para o informado
                nMudas = Retorna_Bandeja() - ((Conversion.Val(txtNBandejas.Text) * Retorna_Bandeja()) - Conversion.Val(txtNMudas.Text));
            SQL = SQL + "(" + Retorna_Bandeja() + "," + nMudas + "," + nMudas + ",1," + txtMercadoria.Text + "," + txtClone.Text + "," + varID + ",'" + Strings.Format((DateTime)txtData.Text, "yyyy-MM-dd") + "')";
            // Se não for a ultima acrescenta uma vírgula para montar a SQL
            if (i < n)
                SQL = SQL + ",";
        }
        try
        {
            // Tenta fazer a inclusão
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            // Manda mensagem caso de errado
            Interaction.MsgBox("Erro ao tentar incluir as bandejas no banco de dados" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
            return;
        }
        // Atualiza o grid de bandejas
        Atualiza_Grid_Bandejas("SELECT id,tipo,mudas FROM aux_bandejas WHERE Plantio=" + varID);
        // Debug
        // Console.WriteLine(SQL)
        txtCodigo.Focus();
        txtCodigo.SelectAll();
    }
    private bool valida_inclusao()
    {
        if (txtMercadoria.Text.Length == 0 | txtMercadoria.Text == "0")
        {
            Interaction.MsgBox("É necessário informar o código da mercadoria", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (txtClone.Text.Length == 0)
        {
            Interaction.MsgBox("É necessário informar o código do clone", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (txtData.Text == "__/__/__")
        {
            Interaction.MsgBox("É necessário informar a data do plantio", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        try
        {
            DateTime tData = (DateTime)txtData.Text;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("A data digitada não é uma data válida. Verifique a digitação novamente", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }
        if (txtNMudas.Text.Length == 0 | txtNMudas.Text == "0")
        {
            Interaction.MsgBox("É necessário que seja digitada a quantidade de mudas", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (txtNBandejas.Text.Length == 0 | txtNBandejas.Text == "0")
        {
            Interaction.MsgBox("É necessário que seja digitada a quantidade de bandejas", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (cmbCliente.Text.Length == 0)
        {
            Interaction.MsgBox("É necessário informar o cliente", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (txtSubstrato.Text.Length == 0 | txtSubstrato.Text == "0")
        {
            Interaction.MsgBox("É necessário informar o tipo de substrato utilizado", MsgBoxStyle.Exclamation, "Aviso");
            goto falso;
        }
        if (rd72.Checked == false & rd128.Checked == false & rd255.Checked == false & rd450.Checked == false)
        {
            Interaction.MsgBox("É necessário informar qual o tipo de bandeja utilizado no plantio!", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }

        // Se passou por todas as regras
        goto Verdadeiro;
    Falso:
        ;
        valida_inclusao = false;
        return;

    Verdadeiro:
        ;
        valida_inclusao = true;
        return;
    }
    private string Retorna_Bandeja()
    {
        // Valor padrão Vazio
        Retorna_Bandeja = string.Empty;
        // Verifica qual Radio está selecionado e retorna como strign
        if (rd70.Checked == true)
        {
            Retorna_Bandeja = "70";
            goto fim;
        }
        if (rd72.Checked == true)
        {
            Retorna_Bandeja = "72";
            goto fim;
        }
        if (rd128.Checked == true)
        {
            Retorna_Bandeja = "128";
            goto fim;
        }
        if (rd255.Checked == true)
        {
            Retorna_Bandeja = "255";
            goto fim;
        }
        if (rd450.Checked == true)
        {
            Retorna_Bandeja = "450";
            goto fim;
        }

    FIM:
        ;
    }

    private void txtNMudas_Leave(object sender, System.EventArgs e)
    {
        // Tenta calcular o tipo da bandeja utilizada
        if ((Conversion.Val(txtNMudas.Text) % 70) == 0)
            rd70.Checked = true;
        if ((Conversion.Val(txtNMudas.Text) % 72) == 0)
            rd72.Checked = true;
        if ((Conversion.Val(txtNMudas.Text) % 128) == 0)
            rd128.Checked = true;
        if ((Conversion.Val(txtNMudas.Text) % 255) == 0)
            rd255.Checked = true;
        if ((Conversion.Val(txtNMudas.Text) % 450) == 0)
            rd450.Checked = true;
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        string SQL;
        // Se a inclusão não passar nas regras de validação
        if (!valida_codigo())
            return;

        // Verifica se o campo com o código do lote não está vazio
        if (txtCodigo.Text != "___.___.____")
        {
            SQL = "INSERT INTO sub_plantio (Lote,Origem,Origem_num) VALUES (" + varID + ",'" + txtCodigo.Text.Replace(",", ".") + "'," + txtMudas.Text + ")";
            Console.WriteLine(SQL);
            try
            {
                // Tenta fazer a inclusão
                Biblioteca.ExecutaSQL(SQL);
            }
            catch (Exception ex)
            {
                // Se der erro envia a mensagem
                Interaction.MsgBox("Erro ao tentar incluir lote de origem." + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
                return;
            }
        }
        else
        {
            // Se estiver vazio Avisa
            Interaction.MsgBox("O Código do lote tem que ser preenchido!", MsgBoxStyle.Exclamation);
            return;
        }
        // Atualiza o datagrid
        Atualiza_Grid_Historico("SELECT Origem,Origem_num FROM sub_plantio WHERE lote=" + varID);
        txtCodigo.Text = string.Empty;
        txtMudas.Text = 0;
        txtCodigo.Focus();
    }

    private void Totaliza_Origem()
    {
        uint Total = 0;
        {
            var withBlock = dgOrigem;
            for (int i = 0; i <= withBlock.RowCount - 1; i++)
                Total += withBlock.Rows[i].Cells[1].Value;
        }
        lblMudasOrigem.Text = Strings.Format(Total, "N0");
    }


    public bool valida_codigo()
    {
        if (txtCodigo.Text.Length < 12)
        {
            Interaction.MsgBox("O tamanho do código é imcompatível com o sistema adotado!", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }
        if (Conversion.Val(txtCodigo.Text.Substring(0, 3)) != Conversion.Val(txtMercadoria.Text))
        {
            Interaction.MsgBox("Há uma divergência no código da mercadoria informado!", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }
        if (Conversion.Val(txtCodigo.Text.Substring(8, 4)) != Conversion.Val(txtClone.Text))
        {
            Interaction.MsgBox("Há uma divergência no clone informado!", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }
        string[] Codigo = new string[4];
        // Divide o código nos 3 pedacos
        // Uso a vírgula porque o maskeditbox troca sozinho o ponto pela vírgula
        Codigo = txtCodigo.Text.Split(",");
        // Verifica se localiza (O lote não precisa estar ativo)
        // Localizar o lote - Se achar retorno o ID senão retorna NULL
        object CodLote = Biblioteca.DLookup("id", "Lotes", "(Mercadoria=" + Conversion.Val(Codigo[0]).ToString() + ") AND (Lote=" + Conversion.Val(Codigo[1]).ToString() + ") AND (Clone=" + Conversion.Val(Codigo[2]).ToString() + ")");

        // Se for NULL é porque não achou
        if (CodLote == null == true)
        {
            Interaction.MsgBox("Lote não Encontrado, verifique se é um lote existente ou não houve erro de digitação", MsgBoxStyle.Exclamation, "Aviso");
            goto Falso;
        }
        // Se passar por todas estas regras é verdadeiro
        goto Verdadeiro;

    Falso:
        ;
        valida_codigo = false;
        return;
    Verdadeiro:
        ;
        valida_codigo = true;
        return;
    }

    private void Atualiza_Grid_Historico(string SQL)
    {
        try
        {
            MyCON = new MySql.Data.MySqlClient.MySqlConnection(Biblioteca.MY_SQL_CONNECTION);
            MyADA = new MySql.Data.MySqlClient.MySqlDataAdapter(SQL, MyCON);
            DataSet dsDados = new DataSet();
            MyADA.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, MyCON);
            MyADA.Fill(dsDados);
            dgOrigem.DataSource = dsDados.Tables[0];
            dgOrigem.RowHeadersWidth = 25;
            dgOrigem.Columns[0].HeaderText = "Lote";
            dgOrigem.Columns[0].Width = 100;
            dgOrigem.Columns[1].HeaderText = "Mudas";
            dgOrigem.Columns[1].Width = 45;
            MyCON.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Interaction.MsgBox("Erro inesperado ao abrir a base de dados !" + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro nº " + ex.Number);
            MyCON.Close();
        }
        // Totaliza as bandejas de origem
        Totaliza_Origem();
    }

    private void Atualiza_Grid_Bandejas(string SQL)
    {
        try
        {
            MyCON = new MySql.Data.MySqlClient.MySqlConnection(Biblioteca.MY_SQL_CONNECTION);
            MyADA = new MySql.Data.MySqlClient.MySqlDataAdapter(SQL, MyCON);
            DataSet dsDados = new DataSet();
            MyADA.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, MyCON);
            MyADA.Fill(dsDados);
            dgBandejas.DataSource = dsDados.Tables[0];
            dgBandejas.RowHeadersWidth = 25;
            dgBandejas.Columns[0].HeaderText = "Bandeja";
            dgBandejas.Columns[0].Width = 65;
            dgBandejas.Columns[1].HeaderText = "Células";
            dgBandejas.Columns[1].Width = 45;
            dgBandejas.Columns[2].HeaderText = "Mudas";
            dgBandejas.Columns[2].Width = 45;
            MyCON.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Interaction.MsgBox("Erro inesperado ao abrir a base de dados !" + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro nº " + ex.Number);
            MyCON.Close();
        }
    }

    private void dgBandejas_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        // Habilita o botão de salvar
        btSalvar.Enabled = true;
    }


    private void btSalvar_Click(System.Object sender, System.EventArgs e)
    {
        int num = dgBandejas.RowCount;
        int i;
        string SQL;
        // Pega o grid bandejas
        {
            var withBlock = dgBandejas;
            // Tem que ser -2 porque começa em 0 e ainda tem a linha do add New
            for (var i = 0; i <= num - 2; i++)
            {
                // Fixa na linha em questão
                {
                    var withBlock1 = withBlock.Rows[i];
                    // Se a primeira célula não for vazia
                    if (withBlock1.Cells[0].Value.ToString() != string.Empty)
                    {
                        // Monta a SQL
                        SQL = "UPDATE aux_bandejas SET Tipo=" + withBlock1.Cells[1].Value + ", Mudas=" + withBlock1.Cells[2].Value + ", NAtual=" + withBlock1.Cells[2].Value + " WHERE id=" + withBlock1.Cells[0].Value;
                        // Tenta salvar os dados no servidor
                        try
                        {
                            Biblioteca.ExecutaSQL(SQL);
                        }
                        catch (Exception ex)
                        {
                            Interaction.MsgBox("Erro ao tentar salvar dados nas bandejas!" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
                            return;
                        }
                    }
                }
            }
        }
    }

    private void txtMudas_Enter(object sender, System.EventArgs e)
    {
        txtMudas.SelectAll();
    }


    private void btNovo_Click(System.Object sender, System.EventArgs e)
    {
        // Se não passar pela checagem das quantidades não vai adiante
        if (!Valida_Campos())
            return;

        // Limpa os campos da mercadoria
        txtMercadoria.Text = string.Empty;
        txtClone.Text = string.Empty;
        txtData.Text = string.Empty;
        rd72.Checked = true;
        txtNMudas.Text = 0;
        txtNBandejas.Text = 0;
        cmbCliente.Text = string.Empty;
        lstPlantador.ClearSelected();
        txtSubstrato.Text = string.Empty;
        lblPlantio.Text = "Plantio: 00000";
        // Desabilita os grupos
        grpPlantio.Enabled = true;
        grpBandejas.Enabled = false;
        grpOrigem.Enabled = false;
        // Limpa os grids de bandejas
        Atualiza_Grid_Historico("SELECT Origem,Origem_num FROM sub_plantio WHERE lote=0");
        Atualiza_Grid_Bandejas("SELECT id,tipo,mudas FROM aux_bandejas WHERE Plantio=0");
        // Move o foco para as mercadorias
        txtMercadoria.Focus();
    }

    public bool Valida_Campos()
    {
        int i;
        int BandejasTotal;
        int OrigemTotal;
        BandejasTotal = 0;
        OrigemTotal = 0;
        // Soma as mudas nas bandejas
        {
            var withBlock = dgBandejas;
            for (var i = 0; i <= withBlock.RowCount - 1; i++)
                BandejasTotal += Conversion.Val(withBlock.Rows[i].Cells[2].Value);
        }
        // Debug
        Console.WriteLine(this.Name + ": Mudas em Bandejas:" + BandejasTotal);
        // Soma as mudas na orígem
        {
            var withBlock = dgOrigem;
            for (var i = 0; i <= withBlock.RowCount - 1; i++)
                OrigemTotal += Conversion.Val(withBlock.Rows[i].Cells[1].Value);
        }
        // Debug
        Console.WriteLine(this.Name + ": Mudas de Orígem:" + OrigemTotal);

        // Faz a validação do número de mudas
        if (BandejasTotal != Conversion.Val(txtNMudas.Text))
        {
            Interaction.MsgBox("O número de mudas informado e o número de mudas em bandejas divegem!" + Constants.vbCrLf + "Mudas totais: " + txtNMudas.Text + Constants.vbCrLf + "Mudas em bandejas: " + BandejasTotal.ToString(), MsgBoxStyle.Exclamation);
            Valida_Campos = false;
            return;
        }
        // Faz a validação do número de mudas de origem
        if (OrigemTotal != Conversion.Val(txtNMudas.Text))
        {
            Interaction.MsgBox("O número de mudas informado e o número de mudas de orígem divergem!" + Constants.vbCrLf + "Mudas totais: " + txtNMudas.Text + Constants.vbCrLf + "Mudas de Orígem: " + OrigemTotal.ToString(), MsgBoxStyle.Exclamation);
            Valida_Campos = false;
            return;
        }
        // Se passou por todos sem sair então é verdadeiro
        Valida_Campos = true;
    }

    private void btSair_Click(System.Object sender, System.EventArgs e)
    {
        // Se passar no teste de validação deixa fechar
        if (Valida_Campos())
            this.Close();
    }

    public frmPlantio(int Ordem = -1)
    {

        // This call is required by the designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call.

        Ordem_Producao = Ordem;
    }
}
