using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using QRCoder;
using MySql.Data.MySqlClient;

public partial class frmNovoLotes
{
    // Define os tipos aceitos pela função
    enum Tipo_SQL
    {
        Insert,
        Update,
        Delete
    }

    // Variável que recebe a ordem de Produção caso seja informada
    private int Ordem_Producao = -1;
    private int LoteID = -1;

    public frmNovoLotes(char Tipo = "N", int Numero = -1)
    {
        // Esse foi o jeito para ter 2 opções para NEW
        // L -> Carrega Lote e Número fica sendo ID do Lote
        // O -> Carrega Ordem de Produção e o Número fica sendo o número da Ordem

        // This call is required by the designer.
        InitializeComponent();

        switch (Tipo)
        {
            case "L":
                {
                    // Se recebeu alguma ordem de produção como parâmetro então atribui
                    if (Numero > -1)
                        // Em caso de alteração carrega a informação do Lote
                        LoteID = Numero;
                    break;
                }

            case "O":
                {
                    if (Numero > -1)
                        Ordem_Producao = Numero;
                    break;
                }
        }
    }

    private void frmNovoLotes_Load(object sender, EventArgs e)
    {
        // Mercadorias
        Biblioteca.Carrega_Lista(ref cmbMercadoria, "Mercadoria_num", "id", "Nome", true);
        // Repicadores
        Biblioteca.Carrega_Lista(ref cmbRepicador, "Repicador", "id", "Nome", true, "Ativo=1");
        // Fases de Reprodução
        Biblioteca.Carrega_Lista(ref cmbFase, "Fases", "id", "Fase");
        // Meios de Cultura
        Biblioteca.Carrega_Lista(ref cmbMeio, "Meio", "id", "meio", true);
        // Tipos de Frascos
        Biblioteca.Carrega_Lista(ref cmbFrasco, "Tipo_Frasco", "tipo_frasco", "tipo_frasco", true);
        // Tipos de Explante
        Biblioteca.Carrega_Lista(ref cmbExplante, "Tipo_Explante", "tipo_explante", "tipo_explante", true);
        // Acerta a data do Date picker
        txtData.Value = DateTime.Today();
        // Preenche os combos do grid
        Create_DataSet();
        // Verifica se é um carregamento de lote
        if (LoteID > -1)
            Carrega_Info_Lote(LoteID);
        // Verifica se recebeu como parâmetro alguma ordem de produção então já inicia o Preenchimento
        if (Ordem_Producao > -1)
            Carrega_Info_Ordem();
    }

    private void Create_DataSet()
    {
        // Cria o DataTable REPICADOR
        DataTable DTRepicador = Biblioteca.SQLQuery("SELECT id,Nome FROM repicador WHERE Ativo=1");
        // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        this.colRepicador.DataSource = DTRepicador;
        this.colRepicador.ValueMember = "id";
        this.colRepicador.DisplayMember = "Nome";

        // Cria o DataTable MEIO
        DataTable DTMeio = Biblioteca.SQLQuery("SELECT * FROM meio");
        // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        this.colMeio.ValueMember = "id";
        this.colMeio.DisplayMember = "Meio";
        this.colMeio.DataSource = DTMeio;

        // Cria o DataTable TIPO FRASCO
        DataTable DTTipoFrasco = Biblioteca.SQLQuery("SELECT Tipo_Frasco FROM Tipo_Frasco");
        // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        this.colTipo.ValueMember = "Tipo_Frasco";
        this.colTipo.DisplayMember = "Tipo_Frasco";
        this.colTipo.DataSource = DTTipoFrasco;

        // Cria o DataTable TIPO EXPLANTE
        DataTable DTTipoExplante = Biblioteca.SQLQuery("SELECT Tipo_Explante FROM Tipo_Explante");
        // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        this.colExplante.ValueMember = "Tipo_Explante";
        this.colExplante.DisplayMember = "Tipo_Explante";
        this.colExplante.DataSource = DTTipoExplante;
    }

    private void QRCode_CSharp(int varID)
    {
        // Criar o QR Code usando a biblioteca em C# Baixada do GitHub
        string Level;
        // Define o Nível do QR Code (L H Q M)
        Level = "L";
        // "Traduz" o Level para número
        QRCodeGenerator.ECCLevel ECCLevel = 1;
        // Cria o objeto QRCode Generator
        QRCodeGenerator GeradorQR = new QRCodeGenerator();
        // Define o URL Base
        string urlBase = "http://10.1.1.254/index3.php?id=";
        // Cria o binário do QR Code
        QRCodeData qrCodeData = GeradorQR.CreateQrCode(urlBase + varID, ECCLevel);
        QRCode qrCode = new QRCode(qrCodeData);
        // Usa o criador para colocar isso na imagem.
        pbQrCode.Image = qrCode.GetGraphic(3, Color.Black, Color.White, false);
    }

    private void Atualiza_Totais()
    {
        int soma = 0;
        for (int i = 0; i <= dgFrascos.RowCount - 1; i++)
            soma += dgFrascos.Rows[i].Cells[2].Value;
        txtEstIni.Text = Strings.Format(soma, "n0");
        txtEstFrascos.Text = Strings.Format(dgFrascos.RowCount, "n0");
    }

    private void dgFrascos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        Atualiza_Totais();
    }

    private void dgFrascos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        Atualiza_Totais();
    }

    private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
    {
        // troca ponto por virgula
        if (e.KeyChar == ",")
        {
            e.Handled = true;
            // envia a nova tecla
            SendKeys.Send(".");
        }
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
            txtLote.Text = Biblioteca.ZerosEsquerda(Partes[1], 3);
            // Parte2=Clone
            txtClone.Text = Biblioteca.ZerosEsquerda(Partes[2], 4);
            // Procura se já existe o lote
            Cod = Biblioteca.DLookup("id", "lotes", "mercadoria=" + Partes[0] + " and lote=" + Partes[1] + " and clone=" + Partes[2] + " and ativo=1");
            if (Cod != "")
            {
                nLote = Biblioteca.DMax("lote", "Lotes", "mercadoria=" + Partes[0] + " AND Clone=" + Partes[2] + " AND ativo=1");
                if (Aviso)
                    Interaction.MsgBox("Já existe um lote ativo com este código!" + Constants.vbCrLf + "Lote: " + Cod + Constants.vbCrLf + "Próximo lote: " + nLote + 1, MsgBoxStyle.Exclamation, "Aviso");
                txtCodigo.Text = Partes[0] + "." + nLote + 1 + "." + Partes[2];
                txtLote.Text = Strings.Format(nLote + 1, "000");
                txtNOrigem.Focus();
            }

            // *** Depois de Tudo verificado coleta os parâmetros ***

            // Verifica qual o próximo ID de Inserção
            string SQL = "SELECT Auto_increment as nextID FROM information_schema.tables WHERE table_name='lotes'";
            try
            {
                DataTable dtResult;
                dtResult = Biblioteca.SQLQuery(SQL);
                // Verifica se retornou resultado
                if (dtResult.Rows.Count > 0)
                {
                    txtID.Text = dtResult.Rows[0].Item["nextID"];
                    dtResult = null;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar localizar o ID de Inserção" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
                return;
            }
            // Povoar o combo origem com os lotes disponíveis
            Biblioteca.Carrega_Lista(ref cmbOrigem, "id_codigo", "id", "Codigo", true, "Mercadoria=" + Partes[0] + " AND Clone=" + Partes[2] + " AND Ativo=1");

            // Preenche o Combo de Origem do DataGridView Também para não dar Erro

            // Cria o DataTable ORIGEM
            DataTable DTOrigem = Biblioteca.SQLQuery("SELECT id,Codigo FROM id_codigo WHERE Mercadoria=" + Partes[0] + " AND Clone=" + Partes[2] + " AND Ativo=1");
            // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
            this.colOrigem.ValueMember = "id";
            this.colOrigem.DisplayMember = "codigo";
            this.colOrigem.DataSource = DTOrigem;

            // Gera o QR Code do Lote
            if (Information.IsNumeric(txtID.Text))
                QRCode_CSharp(txtID.Text);

            // Move o foco para o combo origem
            txtNOrigem.Focus();
        }
    }

    private void txtCodigo_Leave(object sender, EventArgs e)
    {
        // Se é alteração não passa por essa rotina
        if (btIncluir.Text == "Incluir")
            Verifica_Num_Lote(true);
    }

    private void btFrascos_Click(object sender, EventArgs e)
    {
        // Faz a verificação e validação dos campos
        if (!valida_campos())
            return;

        // Verifica se já existem frascos cadastrados
        int varVidro;
        if (dgFrascos.RowCount <= 0)
            varVidro = 1;
        else
            // Organiza os frascos em ordem
            // dgFrascos.Sort(colVidro, System.ComponentModel.ListSortDirection.Ascending)
            // Pega o número do último frasco
            varVidro = dgFrascos.Rows[dgFrascos.Rows.Count - 1].Cells[1].Value + 1;

        // Faz a inserção dos frascos no grid
        for (int i = varVidro; i <= varVidro + Conversion.Int(txtNFrascos.Text) - 1; i++)
        {
            {
                var withBlock = DsFrascosAux.Tables["aux_frascos"];
                DataRow Row = withBlock.NewRow();
                Row["Lote"] = txtID.Text;
                Row["vidro"] = i;
                Row["nMudas"] = txtM_F.Text;
                Row["impresso"] = 0;
                Row["selecao"] = 0;
                Row["Variedade"] = Biblioteca.cmbVal(ref cmbMercadoria);
                Row["Clone"] = txtClone.Text;
                Row["Origem"] = Biblioteca.cmbVal(ref cmbOrigem);
                Row["Repicador"] = Biblioteca.cmbVal(ref cmbRepicador);
                Row["Meio"] = Biblioteca.cmbVal(ref cmbMeio);
                Row["Data"] = txtData.Text;
                Row["frTipo"] = cmbFrasco.Text;
                Row["Explante"] = cmbExplante.Text;
                Row["Dias"] = txtDias.Text;
                Row["criacao"] = DateTime.Now();
                // Adiciona a linha no DataRow
                try
                {
                    withBlock.Rows.Add(Row);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Erro ao tentar incluir frasco no DataGris" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
                    return;
                }
            }
        }
    }

    private bool valida_campos()
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
            epErro.SetError(cmbMercadoria, "Selecione o código da variedade na lista");
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

        if (cmbFase.SelectedIndex == -1 | cmbFase.Text.Length <= 0)
        {
            epErro.SetError(cmbFase, "Selecione a fase da cultura");
            ret = false;
        }
        // Verifica o prazo de repicagem
        if (txtDias.Text.Length <= 0)
        {
            epErro.SetError(txtDias, "Defina o prazo de repicagem do material");
            ret = false;
        }
        // Verifica o número de frascos
        if (txtNFrascos.Text.Length <= 0 | txtNFrascos.Text == "0")
        {
            epErro.SetError(txtNFrascos, "Digite a quantidade de frascos a acrescentar");
            ret = false;
        }
        // Verifica o número de mudas
        if (txtM_F.Text.Length <= 0 | txtM_F.Text == "0")
        {
            epErro.SetError(txtM_F, "Defina o número de mudas por frasco");
            ret = false;
        }
        // Verifica o Repicador
        if (cmbRepicador.SelectedIndex == -1 | cmbRepicador.Text.Length <= 0)
        {
            epErro.SetError(cmbRepicador, "Selecione um repicador");
            ret = false;
        }
        // Verifica o Meio de Cultura
        if (cmbMeio.SelectedIndex == -1 | cmbMeio.Text.Length <= 0)
        {
            epErro.SetError(cmbMeio, "Selecione o meio de Cultura");
            ret = false;
        }
        // Verifica o Tipo do Frasco
        if (cmbFrasco.SelectedIndex == -1 | cmbFrasco.Text.Length <= 0)
        {
            epErro.SetError(cmbFrasco, "Selecione o tipo do frasco");
            ret = false;
        }
        // Verifica o Tipo do Explante
        if (cmbExplante.SelectedIndex == -1 | cmbExplante.Text.Length <= 0)
        {
            epErro.SetError(cmbMercadoria, "Selecione o tipo do explante");
            ret = false;
        }
        return ret;
    }

    private void btIncluir_Click(object sender, EventArgs e)
    {
        // Dependendo do comportamento, faz de um ou de outro jeito
        if (btIncluir.Text == "Incluir")
            Salva_Info_Lote(Tipo_SQL.Insert);
        else if (btIncluir.Text == "Salvar")
            Salva_Info_Lote(Tipo_SQL.Update);
    }

    private void Salva_Info_Lote(Tipo_SQL Tipo)
    {
        MySqlConnection conn = new MySqlConnection(Biblioteca.MY_SQL_CONNECTION);

        // Cria o comando MySQL
        MySqlCommand SQL = new MySqlCommand();
        SQL.Connection = conn;

        // Monta a SQL Base dependendo do tipo de operação
        switch (Tipo)
        {
            case Tipo_SQL.Insert:
                {
                    SQL.CommandText = "INSERT INTO lotes SET id=@id, Mercadoria=@merc, Lote=@lote, Clone=@clone, Origem=@origem, Numero_Origem=@norigem, Frascos=@nfrascos, Mudas_frasco=@M_F, Tempo=@tempo, Repicador=@repicador, Fase=@fase, Meio=@meio, Data=@data, Est_Inicial=@estIni, Estoque=@estoque, Est_Frascos=@estfrascos, Anotacoes=@anotacoes, Ativo=@ativo, Frasco=@frasco,Explante=@explante,dias=@dias,Mark=@mark,Local=1,ordem_producao=@op,criacao=CURRENT_TIMESTAMP,QRCode=@qrcode";
                    break;
                }

            case Tipo_SQL.Update:
                {
                    SQL.CommandText = "UPDATE lotes SET Mercadoria=@merc, Lote=@lote, Clone=@clone, Origem=@origem, Numero_Origem=@norigem, Frascos=@nfrascos, Mudas_frasco=@M_F, Tempo=@tempo, Repicador=@repicador, Fase=@fase, Meio=@meio, Data=@data, Est_Inicial=@estIni, Estoque=@estoque, Est_Frascos=@estfrascos, Anotacoes=@anotacoes, Ativo=@ativo, Frasco=@frasco,Explante=@explante,dias=@dias,Mark=@mark,ordem_producao=@op WHERE id=@id";
                    break;
                }
        }

        // Preenche os parametros (teve que ser feito dessa forma por conta do QRCode que não dá para incluir direto
        {
            var withBlock = SQL.Parameters;
            withBlock.AddWithValue("@id", txtID.Text);
            withBlock.AddWithValue("@merc", Biblioteca.cmbVal(ref cmbMercadoria));
            withBlock.AddWithValue("@lote", txtLote.Text);
            withBlock.AddWithValue("@clone", txtClone.Text);
            withBlock.AddWithValue("@origem", Biblioteca.cmbVal(ref cmbOrigem));
            withBlock.AddWithValue("@norigem", txtNOrigem.Text);
            withBlock.AddWithValue("@nfrascos", txtEstFrascos.Text);
            withBlock.AddWithValue("@M_F", txtM_F.Text);
            withBlock.AddWithValue("@tempo", txtTempo.Text.ToString());
            withBlock.AddWithValue("@repicador", Biblioteca.cmbVal(ref cmbRepicador));
            withBlock.AddWithValue("@fase", Biblioteca.cmbVal(ref cmbFase));
            withBlock.AddWithValue("@meio", Biblioteca.cmbVal(ref cmbMeio));
            withBlock.AddWithValue("@data", (DateTime)txtData.Text);
            withBlock.AddWithValue("@estini", int.Parse(txtEstIni.Text, System.Globalization.NumberStyles.Any));
            withBlock.AddWithValue("@estoque", int.Parse(txtEstIni.Text, System.Globalization.NumberStyles.Any));
            withBlock.AddWithValue("@estfrascos", int.Parse(txtEstFrascos.Text, System.Globalization.NumberStyles.Any));
            withBlock.AddWithValue("@anotacoes", txtAnotacoes.Text);
            withBlock.AddWithValue("@ativo", chkAtivo.Checked);
            withBlock.AddWithValue("@frasco", cmbFrasco.Text);
            withBlock.AddWithValue("@explante", cmbExplante.Text);
            withBlock.AddWithValue("@dias", txtDias.Text);
            withBlock.AddWithValue("@mark", 0);
            withBlock.AddWithValue("@local", 1);
            if (txtNumOP.Text == string.Empty)
                withBlock.AddWithValue("@op", -1);
            else
                withBlock.AddWithValue("@op", txtNumOP.Text);
            if (Tipo == Tipo_SQL.Insert)
            {
                // Prepara imagem para inclusão
                Image picture = pbQrCode.Image;
                // Cria uma stream em memória
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                // Preenche a stream com a imagem do picturebox
                picture.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Cria o parametro para inclusão do QRCode
                withBlock.Add("@QRCode", MySqlDbType.VarBinary).Value = stream.GetBuffer();
            }
        }
        try
        {
            // abre a conexão
            conn.Open();
            // Executa o comando de inserção
            SQL.ExecuteNonQuery();
            // Fecha a conexão
            conn.Close();
            // Uma vez incluido o lote, é a vez de incluir os frascos
            taAux_frascos.Update(DsFrascosAux.aux_frascos);
            // Se não houve nenhum erro
            string msg = string.Empty;
            // Verifica qual a mensagem com base no tipo de operação
            if (Tipo == Tipo_SQL.Insert)
                msg = " incluído com sucesso!";
            else if (Tipo == Tipo_SQL.Update)
                msg = " atualizado com sucesso!";
            else if (Tipo == Tipo_SQL.Delete)
                msg = " eliminado com sucesso!";

            // Emite a mensagem para o usuário
            Interaction.MsgBox("Lote " + txtID.Text + msg, MsgBoxStyle.OkOnly, "Aviso");

            // Verifica diretamente no banco de dados se tem algum frasco nessa situação.
            if (Biblioteca.DCount("id", "aux_frascos", "(lote=" + txtID.Text + ") AND (impresso=0)") > 0)
            {
                // Em caso de alteração nos frascos perguntar se envia os frascos para impressão
                int resp = Interaction.MsgBox("Enviar as etiquetas não impressas para lista de impressão?", Constants.vbQuestion + Constants.vbYesNo, "Confirmação");
                if (resp == Constants.vbYes)
                    Envia_Etiquetas_Impressao();
            }

            if (Tipo == Tipo_SQL.Insert)
            {
                // Habilita os campos que podem ter ficado "presos"
                btIncluir.Text = "Incluir";
                txtCodigo.Enabled = true;
                cmbMercadoria.Enabled = true;
                txtLote.Enabled = true;
                txtClone.Enabled = true;
                // Limpa os campos e prepara para nova inclusão
                Limpa_Campos();
            }
            else if (Tipo == Tipo_SQL.Update)
                // Fecha o formulário para não hever risco de acrescentar informação novamente
                this.Close();
        }
        catch (MySqlException ex)
        {
            // Valor duplicado para chave primária (Erro 1062)
            if (ex.Number == MySqlErrorCode.DuplicateKeyEntry)
            {
                Interaction.MsgBox("O lote já foi incluído ou já existe um lote com o ID " + txtID.Text + Constants.vbCr + "Tente Gerar um outro ID", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
            // Algum outro tipo de erro não classificado
            MessageBox.Show("Erro ao tentar incluir o Lote " + Constants.vbCr + ex.Number + " ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao tentar incluir o Lote " + Constants.vbCr + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void Envia_Etiquetas_Impressao()
    {
        string SQL = string.Empty;
        // Monta o código do lote que será impresso
        string varCodigo = Strings.Format(Biblioteca.cmbVal(ref cmbMercadoria), "000") + "." + txtLote.Text + "." + txtClone.Text;
        // Monta a SQL de transferencia de etiquetas
        SQL = "INSERT INTO etiquetas_prn (`Desc`,`Codigo`,`Data`,`nMudas`,`vidro`) (SELECT '" + varCodigo + "',lpad(id,13,'0') as Cod,date_format(`data`, '%d/%m/%y') as dataf,nmudas,vidro FROM aux_frascos WHERE (lote=" + txtID.Text + ") AND (impresso=0))";
        Console.WriteLine(SQL);
        try
        {
            Biblioteca.ExecutaSQL(SQL);
            Interaction.MsgBox("Frascos enviados para lista de impressão com sucesso!", MsgBoxStyle.OkOnly, "Confirmação");
        }
        catch (MySqlException ex)
        {
            Interaction.MsgBox("Erro ao enviar frascos para impressão" + Constants.vbCr + ex.Message + "(" + ex.Number + ")", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            return;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao enviar frascos para impressão" + Constants.vbCr + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            return;
        }

        // ****** Marcar Frascos como Impresso *******
        try
        {
            // Tem que marcar os frascos como impresso
            SQL = "UPDATE aux_frascos SET impresso=1 WHERE lote=" + txtID.Text;
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (MySqlException ex)
        {
            Interaction.MsgBox("Erro ao marcar frascos como Impressos" + Constants.vbCr + ex.Message + "(" + ex.Number + ")", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            return;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao marcar frascos como Impressos" + Constants.vbCr + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            return;
        }
    }

    private void dgFrascos_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        // Para prevenir o erro de quando o combobox não está preenchido.
        if (((e.Exception) is ConstraintException))
        {
            DataGridView view = (DataGridView)sender;
            view.Rows[e.RowIndex].ErrorText = "an error";
            view.Rows[e.RowIndex].Cells[e.ColumnIndex]
                .ErrorText = "an error";
            e.ThrowException = false;
        }
    }

    private void Limpa_Campos()
    {
        // Limpa os campos
        txtCodigo.Text = string.Empty;
        cmbMercadoria.Text = string.Empty;
        txtLote.Text = string.Empty;
        txtClone.Text = string.Empty;
        cmbOrigem.Items.Clear();
        cmbOrigem.Text = string.Empty;
        txtNOrigem.Text = "0";
        txtNFrascos.Text = "0";
        txtM_F.Text = "0";
        txtTempo.Text = string.Empty;
        cmbFase.Text = string.Empty;
        cmbMeio.Text = string.Empty;
        txtData.Text = string.Empty;
        txtEstIni.Text = "0";
        txtEstFrascos.Text = "0";
        cmbFrasco.SelectedIndex = -1;
        cmbExplante.SelectedIndex = -1;
        txtDias.Text = "0";
        txtAnotacoes.Text = string.Empty;
        pbQrCode.Image = null;
        cmbRepicador.Text = string.Empty;
        txtID.Text = "...";
        // Limpa o DataSet Associado ao DatagridView
        DsFrascosAux.aux_frascos.Clear();
        btIncluir.Text = "Incluir";
        // Move o foco para o campo código
        txtCodigo.Focus();
    }

    public void Carrega_Info_Lote(int LoteID)
    {
        Atualiza_Dados(LoteID);
        this.Text = "Alteração de Lotes";
        btIncluir.Text = "Salvar";
    }

    // Sub que faz a procura do LOTE e preenche os dados nos campos
    public void Atualiza_Dados(int id)
    {
        string SQL;
        DataTable Tabela;
        DataRow DR;
        // Monta a SQL para localizar o lote
        SQL = "SELECT * FROM Lotes WHERE Id=" + id;
        // Tenta preencher a tabela com os dados do lote
        try
        {
            // Preenche a tabela com o lote que foi pedido
            Tabela = Biblioteca.SQLQuery(SQL);
            // Verifica se o lote foi encontrado e se a Query não voltou vazia
            if (Tabela.Rows.Count == 0)
            {
                // Não há linhas nessa tabela
                Interaction.MsgBox("Lote não encontrado!", MsgBoxStyle.Critical, "Erro");
                return;
            }
            // mostra o id do lote
            txtID.Text = id;
            // Extrai a linha (a unica linha)
            DR = Tabela.Rows[0];
            // Se tudo estiver certo, agora preenche os campos
            // Função para localizar no combo onde está a mercadoria
            Biblioteca.Localiza_Item(ref cmbMercadoria, DR["Mercadoria"]);
            txtLote.Text = Strings.Format(DR["Lote"], "000");
            txtClone.Text = Strings.Format(DR["Clone"], "0000");
            // Se a origem é nula
            if (Information.IsDBNull(DR["origem"]))
            {
                // Limpa a lista
                cmbOrigem.Items.Clear();
                // Carrega lista com os lotes inativos
                Biblioteca.Carrega_Lista(ref cmbOrigem, "id_codigo", "id", "Codigo", true, "((Mercadoria=" + DR["Mercadoria"] + ") and (Ativo=0) and (Clone=" + DR["Clone"] + "))");
                // Limpa o combo
                cmbOrigem.Text = string.Empty;
            }
            else
            {
                // Carrega a lista com os lotes de origem
                Biblioteca.Carrega_Lista(ref cmbOrigem, "id_codigo", "id", "Codigo", true, "((Mercadoria=" + DR["Mercadoria"] + ") and (Ativo=1) and (Clone=" + DR["Clone"] + ")) OR (Id=" + DR["Origem"] + ") ");
                // Depois de carregado localiza o item
                Biblioteca.Localiza_Item(ref cmbOrigem, DR["origem"]);
            }

            // Atualiza também o DataSet de Origem do Datagrid

            // Cria o DataTable ORIGEM
            DataTable DTOrigem = Biblioteca.SQLQuery("SELECT id,Codigo FROM id_codigo WHERE Mercadoria=" + DR["Mercadoria"] + " AND Clone=" + DR["Clone"] + " AND Ativo=1");
            // Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
            this.colOrigem.ValueMember = "id";
            this.colOrigem.DisplayMember = "codigo";
            this.colOrigem.DataSource = DTOrigem;

            txtCodigo.Text = Strings.Format(DR["Mercadoria"], "000") + "." + Strings.Format(DR["Lote"], "000") + "." + Strings.Format(DR["clone"], "0000");
            // Por conta dos lotes antigos que tem os dois repicadores (se existe o ";")
            if (DR["Repicador"].ToString().IndexOf(";") > 0)
                // Pega somente o primeiro repicador
                Biblioteca.Localiza_Item(ref cmbRepicador, DR["Repicador"].ToString().Substring(0, DR["Repicador"].ToString().IndexOf(";") - 1));
            else
                // Pega o único repicador
                Biblioteca.Localiza_Item(ref cmbRepicador, DR["Repicador"]);
            txtNOrigem.Text = DR["numero_origem"];
            // txtNFrascos.Text = DR("Frascos")
            txtTempo.Text = DR["Tempo"].ToString();
            Biblioteca.Localiza_Item(ref cmbFase, DR["Fase"]);
            Biblioteca.Localiza_Item(ref cmbMeio, DR["Meio"]);
            txtM_F.Text = DR["Mudas_frasco"];
            txtData.Value = DR["data"];
            txtEstIni.Text = DR["Est_inicial"];
            // txtEstoque.Text = DR("Estoque")
            txtEstFrascos.Text = DR["Est_Frascos"];
            cmbFrasco.Text = DR["Frasco"];
            cmbExplante.Text = DR["Explante"];
            txtDias.Text = DR["dias"];
            txtAnotacoes.Text = DR["anotacoes"];
            txtNumOP.Text = Interaction.IIf(DR["ordem_producao"] == -1, string.Empty, DR["ordem_producao"]);
            chkAtivo.Checked = DR["ativo"];
            // Recupera o QR Code Também
            try
            {
                byte[] Codigo2D = Biblioteca.DLookupBLOB("Qrcode", "lotes", "id=" + id);
                System.IO.MemoryStream lstr = new System.IO.MemoryStream(Codigo2D);
                pbQrCode.Image = Image.FromStream(lstr);
                pbQrCode.SizeMode = PictureBoxSizeMode.StretchImage;
                lstr.Close();
            }
            catch (Exception ex)
            {
            }

            // Pega os dados dos frasocs
            taAux_frascos.Fill(DsFrascosAux.aux_frascos, id);

            // imobiliza alguns campos para não mexer pois não podem ser alterados
            txtCodigo.Enabled = false;
            cmbMercadoria.Enabled = false;
            txtLote.Enabled = false;
            txtClone.Enabled = false;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar recuperar os dados do lote:" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }
    }

    private void Carrega_Info_Ordem()
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
        // txtEstIni.BackColor = cor
        cmbExplante.BackColor = cor;
        txtDias.BackColor = cor;
        cmbRepicador.BackColor = cor;

        cmbFrasco.Text = "Frasco de Vidro";
        // *** Preenche o formulário com os dados pré cadastrados da Ordem de Produção
        txtCodigo.Text = DR["Codigo"];
        Verifica_Num_Lote(false);  // Não avisa, simplesmente corrige o número do lote
        Biblioteca.Localiza_Item(ref cmbFase, DR["Fase"]);
        Biblioteca.Localiza_Item(ref cmbMeio, DR["Meio"]);
        txtM_F.Text = DR["Mds_frasco"];
        cmbExplante.Text = "Plântula";
        txtDias.Text = "30";
        txtNumOP.Text = DR["id"];
        this.Cursor = Cursors.Arrow;
    }

    private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbMercadoria_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtLote_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtClone_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtNOrigem_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtTempo_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbFase_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtDias_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtNFrascos_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void txtM_F_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbOrigem_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbRepicador_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbMeio_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbFrasco_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbExplante_KeyDown(object sender, KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
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

    private void txtDias_Enter(object sender, System.EventArgs e)
    {
        txtDias.SelectAll();
    }

    private void txtLote_Enter(object sender, System.EventArgs e)
    {
        txtLote.SelectAll();
    }

    private void dgFrascos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        // Se o número de mudas mudar, recalcula os totais para não dar furo no estoque.
        if (e.ColumnIndex == 2)
            Atualiza_Totais();
    }

    private void dgFrascos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (Information.IsDBNull(dgFrascos.Rows[e.RowIndex].Cells["bxExclusao"].Value))
            dgFrascos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        else
            dgFrascos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
    }

    private void btFechar_Click(object sender, EventArgs e)
    {
        pnlInfo.Visible = false;
    }

    private void dgFrascos_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F3)
        {
            pnlInfo.Visible = true;
            int FrascoID = dgFrascos.Rows[dgFrascos.SelectedRows[0].Index].Cells["colId"].Value;
            lblFrascoID.Text = FrascoID;

            DataRow DR = Biblioteca.DLookupRow("aux_frascos", "id=" + FrascoID);

            // Se o frasco tiver sido excluido mostra as informações da exclusão
            if (!Information.IsDBNull(DR["bxExclusao"]))
            {
                lblStatus.Text = "[ INATIVO ]";
                lblStatus.BackColor = Color.IndianRed;
                lblCriado.Text = Strings.Format(DR["criacao"], "dd/MM/yyyy");
                lblDataBaixa.Text = Strings.Format(DR["bxExclusao"], "dd/MM/yyyy");
                lblBaixadoPor.Text = Biblioteca.DLookup("Nome", "Repicador", "numero=" + DR["bxOperador"]);
                switch (DR["bxMotivo"])
                {
                    case "O":
                        {
                            lblMotivoBaixa.Text = "Oxidação";
                            break;
                        }

                    case "F":
                        {
                            lblMotivoBaixa.Text = "Fungo";
                            break;
                        }

                    case "B":
                        {
                            lblMotivoBaixa.Text = "Bactéria";
                            break;
                        }

                    case "P":
                        {
                            lblMotivoBaixa.Text = "Plantio";
                            break;
                        }

                    case "R":
                        {
                            lblMotivoBaixa.Text = "Repicagem";
                            break;
                        }

                    default:
                        {
                            lblMotivoBaixa.Text = "Não Registrado ou Desconhecido";
                            break;
                        }
                }
            }
            else
            {
                lblStatus.Text = "[ ATIVO ]";
                lblStatus.BackColor = Color.LightGreen;
                lblCriado.Text = Strings.Format(DR["criacao"], "dd/MM/yyyy");
                lblDataBaixa.Text = "...";
                lblBaixadoPor.Text = "...";
                lblMotivoBaixa.Text = "...";
            }
        }
        if (e.KeyCode == Keys.Escape)
            pnlInfo.Visible = false;
    }
}
