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


public partial class frmLotes
{
    public frmLotes(int Ordem = -1)
    {
        cmdUpdate = new MySql.Data.MySqlClient.MySqlCommand();
        cmdDelete = new MySql.Data.MySqlClient.MySqlCommand();

        // Essa Chamada é necessária pelo sistema.
        InitializeComponent();

        // Se recebeu alguma ordem de produção como parâmetro então atribui
        if (Ordem > -1)
            Ordem_Producao = Ordem;
    }

    private System.Drawing.Color Old_Color = new System.Drawing.Color();
    private string varRepicador;
    private MySql.Data.MySqlClient.MySqlConnection MyCON = new MySql.Data.MySqlClient.MySqlConnection(Biblioteca.MY_SQL_CONNECTION);
    private MySql.Data.MySqlClient.MySqlDataAdapter MyADA;
    private DataSet dsDados = new DataSet();
    private DataTable dtDados = new DataTable();

    // Define os comandos
    private MySql.Data.MySqlClient.MySqlCommand _cmdUpdate;

    internal MySql.Data.MySqlClient.MySqlCommand cmdUpdate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdUpdate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdUpdate != null)
            {
            }

            _cmdUpdate = value;
            if (_cmdUpdate != null)
            {
            }
        }
    }

    private MySql.Data.MySqlClient.MySqlCommand _cmdDelete;

    internal MySql.Data.MySqlClient.MySqlCommand cmdDelete
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cmdDelete;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cmdDelete != null)
            {
            }

            _cmdDelete = value;
            if (_cmdDelete != null)
            {
            }
        }
    }

    // Variavel global que guarda o n do lote
    private int LoteID;
    // flag de impressão
    private bool ImpFLAG = false;
    // Variável que recebe a ordem de Produção caso seja informada
    private int Ordem_Producao = -1;

    private void Atualiza_Grid_Frascos(string ID)
    {
        try
        {
            // Renova o DataSet
            taFrascos.Fill(DsFrascos.aux_frascos);
            // Limpa o filtro
            bsFrascos.RemoveFilter();
            // aplica o novo filtro
            bsFrascos.Filter = "lote=" + ID;
            // atualiza o grid dos frascos
            dgFrascos.Refresh();
            // Formata o grid com as colunas
            dgFrascos.RowHeadersWidth = 15;
            // Id (0) e Lote (1) são escondidos, e não aparecem no grid
            dgFrascos.Columns[0].Visible = false;
            dgFrascos.Columns[1].Visible = false;
            dgFrascos.Columns[2].HeaderText = "Vidro";
            dgFrascos.Columns[2].Width = 40;
            dgFrascos.Columns[3].HeaderText = "Nº Mudas";
            dgFrascos.Columns[3].Width = 30;
            dgFrascos.Columns[4].Visible = false;
            dgFrascos.Columns[5].Visible = false;
        }
        // MyCON.Open()
        catch (MySqlException ex)
        {
            Interaction.MsgBox("Erro inesperado ao abrir a base de dados !" + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro nº " + ex.Number);
        }
    }

    private void frmLotes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void frmLotes_Load(System.Object sender, System.EventArgs e)
    {

        // Mercadorias
        Biblioteca.Carrega_Lista(ref cmbMercadoria, "Mercadoria_num", "id", "Nome", true);
        // Repicadores
        Biblioteca.Carrega_Lista(ref lstRepicador, "Repicador", "id", "Nome", true, "Ativo=1");
        // Fases de Reprodução
        Biblioteca.Carrega_Lista(ref cmbFase, "Fases", "id", "Fase");
        // Meios de Cultura
        Biblioteca.Carrega_Lista(ref cmbMeio, "Meio", "id", "meio", true);
        // dgFrascos.DataSource = bsFrascos
        Atualiza_Grid_Frascos("0");
        tbFrascos.Enabled = false;

        // Verifica se recebeu como parâmetro alguma ordem de produção então já inicia o Preenchimento
        if (Ordem_Producao > -1)
            Carrega_Ordem();

        // move o foco para o codigo
        txtCodigo.Focus();
    }

    public void Carrega_Info_Lote(int LoteID)
    {
    }

    private void Carrega_Ordem()
    {
        this.Cursor = Cursors.WaitCursor;
        DataRow DR;
        // Pega os dados da Ordem de Produção e Preenche na ficha
        DR = Biblioteca.DLookupRow("programacao", "id=" + Ordem_Producao);

        // Se não achou nada e DR está vazio sai da rotina
        if (Information.IsDBNull(DR) | Information.IsNothing(DR))
        {
            Interaction.MsgBox("Não foi possível localizar a Ordem de Produção Nº: " + Ordem_Producao, MsgBoxStyle.Critical + Constants.vbOKOnly, "Erro");
            this.Cursor = Cursors.Arrow;
            return;
        }

        // Muda a cor de fundo dos dados que devem ser preenchidos
        System.Drawing.Color cor;
        cor = Color.Khaki;

        cmbOrigem.BackColor = cor;
        txtNOrigem.BackColor = cor;
        txtNFrascos.BackColor = cor;
        txtTempo.BackColor = cor;
        txtData.BackColor = cor;
        txtEstIni.BackColor = cor;
        cmbExplante.BackColor = cor;
        txtDias.BackColor = cor;
        lstRepicador.BackColor = cor;

        cmbFrasco.Text = "Frasco de Vidro";
        // *** Preenche o formulário com os dados pré cadastrados da Ordem de Produção
        txtCodigo.Text = DR["Codigo"];
        Verifica_Num_Lote(false);  // Não avisa, simplesmente corrige o número do lote
        Biblioteca.Localiza_Item(ref cmbFase, DR["Fase"]);
        Biblioteca.Localiza_Item(ref cmbMeio, DR["Meio"]);
        txtM_F.Text = DR["Mds_frasco"];
        cmbExplante.Text = "Plântula";
        txtDias.Text = "45";
        this.Cursor = Cursors.Arrow;
    }

    private void txtCodigo_LostFocus(object sender, System.EventArgs e)
    {
        Verifica_Num_Lote(true);
    }

    private void Verifica_Num_Lote(bool Aviso)
    {
        string Cod;
        int nLote;
        // Se houver algo digitado
        if (Strings.Len(txtCodigo.Text))
        {

            // Verifica se tem duas posições com ponto
            if ((txtCodigo.Text.Length < 5) | (txtCodigo.Text.IndexOf(".") == -1) | (txtCodigo.Text.LastIndexOf(".") == -1) | (txtCodigo.Text.LastIndexOf(".") == txtCodigo.Text.Length))
            {
                Interaction.MsgBox("Formato do código digitado de forma incorreta. Usar o formato 99.999.9999", MsgBoxStyle.Critical, "Erro");
                return;
            }

            // Declara as variaveis
            string[] Partes;
            // Divide a string em partes no "."
            Partes = txtCodigo.Text.Split(".");
            // Parte0=Mercadoria
            // Localiza o item na combo box
            Biblioteca.Localiza_Item(ref cmbMercadoria, Partes[0]);
            // Parte1=Codlote
            txtLote.Text = Partes[1];
            // Parte2=Clone
            txtClone.Text = Partes[2];
            // Procura se já existe o lote
            Cod = Biblioteca.DLookup("id", "lotes", "mercadoria=" + Partes[0] + " and lote=" + Partes[1] + " and clone=" + Partes[2] + " and ativo=1");
            if (Cod != "")
            {
                nLote = Biblioteca.DMax("lote", "Lotes", "mercadoria=" + Partes[0] + " AND Clone=" + Partes[2] + " AND ativo=1");
                if (Aviso)
                    Interaction.MsgBox("Já existe um lote ativo com este código!" + Constants.vbCrLf + "Lote: " + Cod + Constants.vbCrLf + "Próximo lote: " + nLote + 1, MsgBoxStyle.Exclamation, "Aviso");
                txtCodigo.Text = Partes[0] + "." + nLote + 1 + "." + Partes[2];
                txtLote.Text = nLote + 1;
                txtCodigo.Focus();
                return;
            }
            // Povoar o combo origem com os lotes disponíveis
            Biblioteca.Carrega_Lista(ref cmbOrigem, "id_codigo", "id", "Codigo", true, "Mercadoria=" + Partes[0] + " AND Clone=" + Partes[2] + " AND Ativo=1");
            // Move o foco para o combo origem
            cmbOrigem.Focus();
        }
    }

    private void txtM_F_Enter(object sender, System.EventArgs e)
    {
        txtM_F.SelectAll();
    }


    private void txtM_F_LostFocus(object sender, System.EventArgs e)
    {
        // Se o número de frascos foi preenchido
        if (Strings.Len(txtNFrascos.Text) & Conversion.Val(txtNFrascos.Text) > 0)
        {
            if (Strings.Len(txtM_F.Text) & Conversion.Val(txtM_F.Text) > 0)
            {
                // Calcula o número estimado de mudas
                txtEstIni.Text = (Conversion.Val(txtNFrascos.Text) * Conversion.Val(txtM_F.Text)).ToString();
                // O Estoque inicial vai ser esse mesmo numero
                txtEstoque.Text = txtEstIni.Text;
                // O estoque em frascos é o mesmo número de frascos
                txtEstFrascos.Text = txtNFrascos.Text;
            }
        }
    }

    private void txtEstIni_Enter(object sender, System.EventArgs e)
    {
        txtEstIni.SelectAll();
    }

    private void txtEstoque_GotFocus(object sender, System.EventArgs e)
    {
        // Salva a cor anterior
        Old_Color = txtEstIni.BackColor;
        // Faz o fundo ficar vermelho para conferir o valor
        txtEstIni.BackColor = Color.DarkSalmon;
    }

    private void txtEstoque_LostFocus(object sender, System.EventArgs e)
    {
        // restaura a cor anterior
        txtEstIni.BackColor = Old_Color;
        // Se foi alterado já arruma no estoque inicial também
        txtEstoque.Text = txtEstIni.Text;
    }

    private void btFechar_Click(System.Object sender, System.EventArgs e)
    {
        int a;
        // Se já existir um lote digitado
        if (Strings.Len(txtCodigo.Text) > 0)
        {
            // Que não teve as etiquetas impressas
            if (ImpFLAG == false)
            {
                a = Interaction.MsgBox("As etiquetas deste lote ainda não foram impressas." + Strings.Chr(13) + "Imprimir agora?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmação");
                if (a == Constants.vbYes)
                    // Manda executar a rotina de incluir as etiquetas, o Sender e o "e" são os mesmos!
                    btImpEtiquetas_Click(sender, e);
            }
        }
        // Fecha o formulário
        this.Close();
    }


    private void lstRepicador_LostFocus(object sender, System.EventArgs e)
    {
        varRepicador = Biblioteca.valRepicador(ref lstRepicador);
    }


    private void btIncluir_Click(System.Object sender, System.EventArgs e)
    {
        string SQL;
        int Resp;

        if (!Validacao())
        {
            Interaction.MsgBox("Verifique os erros no preenchimento do formulário.", MsgBoxStyle.Critical, "Erro");
            return;
        }

        // Se ele tiver como botão "Novo"
        if (btIncluir.Text == "Novo")
        {
            // Verifica se os dados ficam ou não
            Resp = Interaction.MsgBox("Deseja manter os dados do lote atual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");
            // Se desejar limpar tudo
            if (Resp == Constants.vbNo)
            {
                // Aciona o click no botão novo
                btNovo_Click(sender, e);
                // Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0;
                // Move o foco para o campo do código
                txtCodigo.Focus();
                goto finaliza;
            }
            else
            {
                // Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0;
                txtCodigo.Text = string.Empty;
                cmbOrigem.Items.Clear();
                cmbMercadoria.Text = string.Empty;
                txtClone.Text = string.Empty;
                txtLote.Text = string.Empty;
                txtNOrigem.Text = "0";
                txtNFrascos.Text = "0";
                txtTempo.Text = string.Empty;
                // Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0;
                // Move o foco para o campo do código
                txtCodigo.Focus();
                goto finaliza;
            }

        Finaliza:
            ;

            // Volta o label do botão para incluir
            btIncluir.Text = "Incluir";
            // Apaga a mensagem de etiquetas impressas
            lblEtiquetas.Text = string.Empty;
            // Sai da sub e não realiza a inclusão
            return;
        }

        SQL = "INSERT INTO Lotes (id,Mercadoria,Lote,Clone,Origem,Numero_Origem,Frascos,Mudas_frasco,Tempo,Repicador,Fase,Meio,Data,Est_Inicial,Estoque,Est_Frascos,Anotacoes,Ativo,Frasco,Explante,dias,Mark,Local,criacao) VALUES (" + "NULL," + Biblioteca.cmbVal(ref cmbMercadoria) + "," + txtLote.Text + "," + txtClone.Text + "," + Biblioteca.cmbVal(ref cmbOrigem) + "," + txtNOrigem.Text + "," + txtNFrascos.Text + "," + txtM_F.Text + ",'" + txtTempo.Text.ToString() + "'," + Biblioteca.Texto_Vazio(varRepicador) + "," + Biblioteca.cmbVal(ref cmbFase) + "," + Biblioteca.cmbVal(ref cmbMeio) + ",'" + Strings.Format((DateTime)txtData.Text, "yyyy-MM-dd") + "'," + txtEstIni.Text + "," + txtEstoque.Text + "," + txtEstFrascos.Text + ",'" + txtAnotacoes.Text + "'," + chkAtivo.Checked + ",'" + cmbFrasco.Text + "','" + cmbExplante.Text + "'," + txtDias.Text + ",0,1,CURRENT_TIMESTAMP)";

        try
        {
            // Tenta executar a consulta sql
            Resp = Biblioteca.ExecutaSQL(SQL);
            if (Resp)
            {
                // Pega o ID do ultimo lote
                LoteID = Biblioteca.DMax("id", "Lotes");
                Interaction.MsgBox("Dados gravados com sucesso!" + Constants.vbCrLf + "ID do novo Lote: " + LoteID, Constants.vbOKCancel + Constants.vbInformation, "Aviso");

                // Se esse lote veio de uma ordem de produção então dá baixa da Ordem de Produção também
                if (Ordem_Producao != -1)
                    Biblioteca.ExecutaSQL("UPDATE Programacao SET DataBaixa='" + Strings.Format((DateTime)txtData.Text, "yyyy-MM-dd") + "' WHERE id=" + Ordem_Producao);

                // Habilita segunda aba
                // move para segunda Aba (index baseado em 0) 
                tbFrascos.Enabled = true;
                tabLotes.SelectedIndex = 1;
                // Desabilita o botão de incluir para não fazer a inclusão 2 vezes
                btIncluir.Enabled = false;
                // Limpa o Grid de Frascos
                Atualiza_Grid_Frascos(LoteID.ToString());
                // Foco no botão 2 - Incluir etiquetas
                Button2.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }
    }


    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        grpInclusao.Visible = true;
        if (txtNFrascos.Text == 1)
        {
            // muda para o modo de adição unico
            opFrascos2.Checked = true;
            opFrascos_Click(1);
            txtFrascoINI.Text = 0;
            txtFrascosQuebra.Text = txtEstoque.Text;
        }
        else
        {
            // muda para o modo de adição multiplo
            opFrascos1.Checked = true;
            opFrascos_Click(1);
            // Iguala os campos chave que serão utilizados
            txtFrascoINI.Text = 0;
            txtFrascosTOTAL.Text = txtNFrascos.Text;
            txtFrascosM_F.Text = txtM_F.Text;
            // Calcula o numero de mudas no frasco de quebra
            txtFrascosQuebra.Text = Conversion.Val(txtM_F.Text) - ((Conversion.Val(txtM_F.Text) * Conversion.Val(txtNFrascos.Text)) - Conversion.Val(txtEstIni.Text));
        }
        btIncluiFrascos.Focus();
    }


    private void opFrascos_Click(int Index)
    {
        // Opção de vário
        if (opFrascos1.Checked == true)
        {
            txtFrascosTOTAL.Enabled = true;
            txtFrascoINI.Enabled = true;
            txtFrascosM_F.Enabled = true;
            txtFrascosQuebra.Enabled = true;
            lblFrascoINI.Text = "Frasco Inicial:";
            grpInclusao.Text = "Nº Mudas no Frasco Quebra:";
            Label24.Enabled = true;
            Label25.Enabled = true;
        }
        else if (opFrascos2.Checked == true)
        {
            txtFrascosTOTAL.Enabled = false;
            txtFrascoINI.Enabled = true;
            lblFrascoINI.Text = "Nº do Frasco:";
            txtFrascosM_F.Enabled = false;
            txtFrascosQuebra.Enabled = true;
            grpInclusao.Text = "Nº de Mudas no Frasco:";
            Label24.Enabled = false;
            Label25.Enabled = false;
        }
    }

    private void Button6_Click(System.Object sender, System.EventArgs e)
    {
        grpInclusao.Visible = false;
    }

    private void btIncluiFrascos_Click(System.Object sender, System.EventArgs e)
    {
        object a;
        string SQL;
        float i;
        // Dimensiona as variáveis
        int n;
        // Pede confirmação
        a = Interaction.MsgBox("Os dados estão conferidos?" + Strings.Chr(13) + "Deseja continuar?", Constants.vbYesNo + Constants.vbQuestion, "Confirmação");

        // Se a resposta for SIM
        if (a == Constants.vbYes)
        {

            // Monta a SQL base para inclusão
            SQL = "INSERT INTO aux_frascos (id,Lote,Vidro,NMudas,Impresso,Selecao) VALUES ";

            // se a opção vários está selecionada
            if (opFrascos1.Checked == true)
            {
                // tem que descontar o frasco de quebra também
                n = Conversion.Val((txtFrascosTOTAL.Text)) - 2;
                // Faz o looping para inclusão
                for (i = 0; i <= n; i++)
                {
                    // quando for a segunda vez que passa aqui, coloca a virgula
                    if (i > 0)
                        SQL = SQL + ",";
                    // Substitui pelo SQL
                    SQL = SQL + "(null," + LoteID + "," + Conversion.Val(txtFrascoINI.Text) + i + "," + txtFrascosM_F.Text + ",0,0)";
                }

                // insere um vidro avulso que é o da quebra
                SQL = SQL + ",(null," + LoteID + "," + Conversion.Val(txtFrascoINI.Text) + i + "," + txtFrascosQuebra.Text + ",0,0)";
                // Executa a SQL de inclusão
                Biblioteca.ExecutaSQL(SQL);
            }
            else if (opFrascos2.Checked == true)
            {
                // Faz a inclusão unica
                SQL = SQL + "(null," + LoteID + "," + Conversion.Val(txtFrascoINI.Text) + "," + txtFrascosQuebra.Text + ",0,0)";
                // Executa a SQL de inclusão
                Biblioteca.ExecutaSQL(SQL);
            }
            // atualiza o recordset
            Atualiza_Grid_Frascos(LoteID.ToString());
            // Desliga a exibição da inclusão
            grpInclusao.Visible = false;
            // Habilita o botão de inclusão e troca o label dele
            btIncluir.Enabled = true;
            btIncluir.Text = "Novo";
            // Move o foco para o botaõ de impressão de etiquetas
            btImpEtiquetas.Focus();
        }
    }

    private void btImpEtiquetas_Click(System.Object sender, System.EventArgs e)
    {
        string Data;
        string Descricao;
        string SQL;
        string CodBase;
        // Dimensiona as variáveis
        string Mercadoria;
        int ct;

        // Veriica se existem etiquetas para imprimir
        if (dgFrascos.RowCount <= 0)
        {
            Interaction.MsgBox("Não existem frascos cadastrados ainda!" + Constants.vbCrLf + "Favor Cadastrar depois solicitar a impressão!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro");
            // move o foco para o botão 2
            Button2.Focus();
            return;
        }

        // Obtem as informacoes no formulário de inclusão
        Data = Strings.Format((DateTime)txtData.Text, "dd/MM/yy");
        Mercadoria = Strings.Format((int)Biblioteca.cmbVal(ref cmbMercadoria), "000");
        // mota a descrição baseado nos campos do formulário
        Descricao = Mercadoria + "." + Strings.Format((int)txtLote.Text, "000") + "." + Strings.Format((int)txtClone.Text, "0000");
        // Monta o codigo base desmontando o código do lote
        CodBase = Mercadoria + Strings.Format((int)txtLote.Text, "000") + Strings.Format((int)txtClone.Text, "0000");

        // Monta a SQL padrão
        SQL = "INSERT INTO etiquetas_prn VALUES ";
        try
        {
            // Faz o looping com todos as etiquetas deste lote(datagrid)
            for (ct = 0; ct <= dgFrascos.RowCount - 1; ct++)
            {
                // Se for a segunda vez que passa aqui poe uma virgula
                if (ct > 0)
                    SQL = SQL + ",";
                // Vai montando a SQL
                SQL = SQL + "(null,'" + Descricao + "','" + CodBase + Strings.Format((int)dgFrascos.Rows[ct].Cells[2].Value, "000") + "','" + Data + "','" + Strings.Format((int)dgFrascos.Rows[ct].Cells[3].Value, "000") + "')";
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro na geração das etiquetas!" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }

        // Tenta Executar a SQL montada
        try
        {
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao enviar as etiquetas para impressão!" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Exclamation, "Erro");
            return;
        }
        // Se deu tudo certo vai adiante
        Interaction.MsgBox(Strings.Format(ct, "000") + " Etiquetas enviadas para impressão!", MsgBoxStyle.OkOnly, "Confirmação");
        // Marca todas as etiquetas desta lote como impressas
        lblEtiquetas.Text = "Etiquetas impressas";

        try
        {
            SQL = "UPDATE aux_frascos SET Impresso=1 WHERE Lote=" + LoteID;
            // Tenta marcar os frascos
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao marcar as etiquetas como impressas!" + Strings.Chr(13) + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Exclamation, "Erro");
            return;
        }
        // Só para DEBUG
        Console.WriteLine(this.Name + ": " + SQL);
        // Informa que as etiquetas foram impressas com sucesso
        ImpFLAG = true;
        // Habilita o botão de incluir novo registro
        btIncluir.Text = "Novo";
        btIncluir.Enabled = true;
    }

    private void btNovo_Click(System.Object sender, System.EventArgs e)
    {
        int a;
        // Se já existir um lote digitado
        // Que não teve as etiquetas impressas
        if (ImpFLAG == false)
        {
            a = Interaction.MsgBox("As etiquetas deste lote ainda não foram impressas." + Strings.Chr(13) + "Imprimir agora?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmação");
            if (a == Constants.vbYes)
            {
                // Manda executar a rotina de incluir as etiquetas, o Sender e o "e" são os mesmos!
                btImpEtiquetas_Click(sender, e);
                goto Novo;
            }
            // Se os lotes já tiverem sido impressos
            goto Novo;
        }

    Novo:
        ;

        // Limpa os campos
        txtCodigo.Text = string.Empty;
        cmbMercadoria.Text = string.Empty;
        txtLote.Text = string.Empty;
        txtClone.Text = string.Empty;
        cmbOrigem.Items.Clear();
        txtNOrigem.Text = "0";
        txtNFrascos.Text = "0";
        txtM_F.Text = "0";
        txtTempo.Text = string.Empty;
        cmbFase.Text = string.Empty;
        cmbMeio.Text = string.Empty;
        txtData.Text = string.Empty;
        txtEstIni.Text = "0";
        txtEstoque.Text = "0";
        txtEstFrascos.Text = "0";
        cmbFrasco.SelectedIndex = -1;
        cmbExplante.SelectedIndex = -1;
        txtDias.Text = "0";
        txtAnotacoes.Text = string.Empty;

        // Limpa a seleção dos repicadores
        lstRepicador.ClearSelected();
        // Limpa o grid frascos
        Atualiza_Grid_Frascos("0");
        // Habilita o botão de incluir
        btIncluir.Enabled = true;
        btIncluir.Text = "Incluir";
        tabLotes.SelectedIndex = 0;
        // Move o foco para o campo código
        txtCodigo.Focus();
    }

    private void txtAnotacoes_LostFocus(object sender, System.EventArgs e)
    {
        // Move o foco para o botão incluir
        btIncluir.Focus();
    }


    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        // Apaga somenteo o mínio para continuar incluindo com a ficha atual
        txtCodigo.Text = string.Empty;
        txtNOrigem.Text = 0;
        txtNFrascos.Text = 0;
        txtTempo.Text = string.Empty;
        cmbOrigem.Text = string.Empty;
        // Move o foco
        txtCodigo.Focus();
    }

    private void txtNOrigem_Enter(object sender, System.EventArgs e)
    {
        txtNOrigem.SelectAll();
    }

    private void txtNFrascos_Enter(object sender, System.EventArgs e)
    {
        txtNFrascos.SelectAll();
    }

    private void txtTempo_Enter(object sender, System.EventArgs e)
    {
        txtTempo.SelectAll();
    }

    private void txtData_Enter(object sender, System.EventArgs e)
    {
        txtData.SelectAll();
    }

    private void txtDias_Enter(object sender, System.EventArgs e)
    {
        txtDias.SelectAll();
    }

    private void txtEstFrascos_Enter(object sender, System.EventArgs e)
    {
        txtEstFrascos.SelectAll();
    }

    private void txtEstoque_Enter(object sender, System.EventArgs e)
    {
        txtEstoque.SelectAll();
    }

    private void txtLote_Enter(object sender, System.EventArgs e)
    {
        txtLote.SelectAll();
    }

    private void dgFrascos_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        // Célula começou a ser modificada, habilita o botão de salvar
        btSalvar.Enabled = true;
    }

    private void DefineComandos()
    {
        MySql.Data.MySqlClient.MySqlCommandBuilder myCMB = new MySql.Data.MySqlClient.MySqlCommandBuilder(MyADA);
        MyADA.UpdateCommand = myCMB.GetUpdateCommand();
    }

    private void btSalvar_Click(System.Object sender, System.EventArgs e)
    {
        // Executa o método update definido na Sub DefineComandos()
        try
        {
            bsFrascos.EndEdit();
            taFrascos.Update(DsFrascos.aux_frascos);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar atualizar a tabela de Frascos!" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
        }
    }

    private void cmbOrigem_Leave(System.Object sender, System.EventArgs e)
    {
        // Faz a verificação se o lote de orígem está preenchido  

        // Se estiver prreenchido é obrigado a ter escolhido um lote de orígem
        if (cmbOrigem.Text.Length > 0)
        {
            // Verifica se foi escolhido
            if (cmbOrigem.SelectedIndex == -1)
            {
                Interaction.MsgBox("Verifique o lote de orígem! Ele não foi preenchido adequadamente." + Constants.vbCrLf + "Opte por escolher uma opção da lista.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }
    }

    private bool Validacao()
    {
        bool ret = true;

        // Verifica o código
        if (txtCodigo.Text.Length <= 0)
        {
            epErro.SetError(txtCodigo, "Digite o código do lote");
            ret = false;
        }

        // Verifica o lote de origem
        if (cmbOrigem.Text.Length > 0)
        {
            // Verifica se foi escolhido
            if (cmbOrigem.SelectedIndex == -1)
            {
                epErro.SetError(cmbOrigem, "Verifique o lote de orígem!");
                ret = false;
            }
        }
        // Verifica a mercadoria
        if (cmbMercadoria.SelectedIndex == -1 | cmbMercadoria.Text.Length <= 0)
        {
            epErro.SetError(cmbMercadoria, "Selecione o código da mercadoria na lista");
            ret = false;
        }
        // Verifia o clone
        if (txtClone.Text.Length <= 0)
        {
            epErro.SetError(txtClone, "Clone está em branco");
            ret = false;
        }
        // Verifica o lote
        if (txtLote.Text.Length <= 0)
        {
            epErro.SetError(txtLote, "O Lote está em branco");
            ret = false;
        }


        return ret;
    }


    private void txtCodigo_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // troca ponto por virgula
        if (e.KeyChar == ",")
        {
            e.Handled = true;
            // envia a nova tecla
            SendKeys.Send(".");
        }
    }
}
