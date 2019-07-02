using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;

public partial class frmServCodBar
{
    private void cmbMotivo_GotFocus(object sender, System.EventArgs e)
    {
        // Se o automático estiver pressionado não há necessidade de ativar o enter
        if (chkAuto.Checked)
            // Procura o próximo controle
            SendKeys.Send("{TAB}");
    }

    private void cmbMotivo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.MoverFoco(this, sender, e);
    }

    private void cmbMotivo_LostFocus(object sender, System.EventArgs e)
    {
        if (txtCodigoBarras.Text == string.Empty)
            return;

        if (cmbOperador.SelectedIndex == -1)
        {
            Interaction.MsgBox("Selecione um operador para a baixa.", MsgBoxStyle.OkOnly, "Aviso");
            return;
        }

        // Gambiarra para poder migrar de sistema pois todas as novas etiquetas não começam com o número do lote
        if ((Strings.Len(txtCodigoBarras.Text) == 13) & (txtCodigoBarras.Text.Substring(0, 4) == "0000"))
        {
            Nova_Baixa();
            return;
        }
        // Usa a função compartilhada no Modulo Generico arquivo Biblioteca.vb
        Generico.Adiciona_Frasco(ref dgFrascos, ref dsFrascos, ref txtCodigoBarras, ref cmbMotivo, ref txtTotal);
    }

    private void Nova_Baixa()
    {
        int codMer;
        int codLOT;
        int codCLON;
        int codFRA;
        int Mudas;
        int codVidro;
        int codLote;
        DataRow DR;
        // Localiza o frasco scaneado
        DR = Biblioteca.DLookupRow("aux_frascos", "(ISNULL(bxExclusao)) AND (id=" + txtCodigoBarras.Text + ")");

        // Verifica se veio a linha
        if (Information.IsNothing(DR))
        {
            // Pesquisa o ID
            DR = Biblioteca.DLookupRow("aux_frascos", "(id=" + txtCodigoBarras.Text + ")");
            // Se não achou nem o ID então avisa que o frasco naõ existe mais
            if (Information.IsNothing(DR))
            {
                Interaction.MsgBox("Frasco não encontrado ou não cadastrado!");
                goto Fim;
            }
            else
            {
                Interaction.MsgBox("Este frasco já foi baixado em: " + DR["bxExclusao"] + Constants.vbCrLf + "Operador: " + Biblioteca.DLookup("Nome", "repicador", "id=" + DR["bxoperador"]) + Constants.vbCrLf + "Motivo:   " + DR["bxmotivo"]);
                goto Fim;
            }
        }

        // ## Acrescentar verificação se o frasco já consta.
        // ##
        // ** Tem que fazer manualmente mesmo para não alterar a ordem

        string frascoID = DR["id"];
        // Pega o ID e verifica em todas as linhas
        for (int i = 0; i <= dgFrascos.RowCount - 1; i++)
        {
            // Se encontrar então avisa a mensagem
            if (dgFrascos.Rows[i].Cells["CoID"].Value == frascoID)
            {
                Interaction.MsgBox("Este frasco já está na lista!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Aviso");
                goto Fim;
            }
        }

        // Tendo os dados em mãos, é só pegar na linha e ver o que precisa
        codLOT = Biblioteca.DLookup("lote", "lotes", "id=" + DR["Lote"]);
        if (Information.IsDBNull(DR["Variedade"]) | Information.IsDBNull(DR["clone"]))
        {
            DataRow DRL;
            DRL = Biblioteca.DLookupRow("lotes", "id=" + DR["Lote"]);
            codMer = DRL["Mercadoria"];
            codCLON = DRL["Clone"];
            DRL = null;
        }
        else
        {
            codMer = DR["Variedade"];
            codCLON = DR["Clone"];
        }

        codFRA = DR["Vidro"];
        Mudas = DR["NMudas"];
        codVidro = DR["id"];
        codLote = DR["Lote"];
        dsFrascos.Tables[0].Rows.Add(codMer, codLOT, codCLON, codFRA, Mudas, cmbMotivo.Text.Substring(0, 1), codVidro, codLote);
        // Conta o número de frascos
        txtTotal.Text = dsFrascos.Tables[0].Rows.Count;

    Fim:
        ;

        // Limpa o campo
        txtCodigoBarras.Text = string.Empty;
        // Devolve o foco para ó código de barras 
        txtCodigoBarras.Focus();
    }


    private void frmServCodBar_Load(System.Object sender, System.EventArgs e)
    {
        // Dimensiona os vetores para formatação do datagrid
        string[] Textos = new[] { "Merc", "Lote", "Clone", "Frasco", "Nº Mudas", "Motivo", "ID", "Cód" };
        int[] Tamanhos = new[] { 50, 50, 50, 50, 77, 50, 50, 50 };
        int[] visiveis = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };

        // Formata o grid das orquideas
        string[] TextosO = new[] { "Id", "Lote", "Tipo", "Nº Mudas", "Vidro", "Motivo" };
        int[] TamanhosO = new[] { 70, 70, 70, 77, 70, 70 };
        int[] VisiveisO = new[] { 1, 1, 1, 1, 1, 1 };

        // Preenche a data no campo data
        txtData.Text = Strings.Format(DateTime.Today(), "dd/MM/yyyy");
        txtDataO.Text = txtData.Text;

        cmbMotivo.Text = "Fungo";
        cmbMotivoO.Text = "Fungo";

        // Formata o datagrid com os headers e tamahos
        // Define a primeira coluna (morta)
        dgFrascos.RowHeadersWidth = 20;
        // Define a primeira coluna (morta)
        dgFrascosO.RowHeadersWidth = 20;

        // Usa a funcao genérica para formatar o datagrid
        Biblioteca.Formata_Datagrid(ref dgFrascos, Textos, Tamanhos, visiveis);
        Biblioteca.Formata_Datagrid(ref dgFrascosO, TextosO, TamanhosO, VisiveisO);

        // Carrega a lista de quem está dando baixa
        Biblioteca.Carrega_Lista(ref cmbOperador, "repicador", "id", "Nome", true, "Ativo=1");

        // Move o foco para o código de barras
        txtCodigoBarras.Focus();
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void txtCodigoBarras_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F12)
        {
            // Se pressionou F12 quando o código estava vazio então...
            if (Strings.Len(txtCodigoBarras.Text) <= 0)
            {
                // Chama o procedimento de encerrar
                btConfirma_Click(sender, e);
                goto fim;
            }
        }
        if (e.KeyCode == Keys.Enter)
            // se recebeu um enter então move o foco para o combo
            cmbMotivo.Focus();
        Fim:
        ;
    }

    private void txtData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.MoverFoco(this, sender, e);
    }

    private void btConfirma_Click(System.Object sender, System.EventArgs e)
    {
        // Dimensiona a variavel resposta
        bool Resp;
        // Utiliza as funções compartilhadas no arquivo Biblioteca.vb módulo Genérico
        // Estas funções são compartilhadas pela baixa de Frascos e pela recuperação de Frascos
        // Resp = Baixa_Frascos(dgFrascos, dsFrascos, txtData, cmbVal(cmbOperador))
        Baixa_Frascos_Novo();
        if (Resp)
        {
            // Atualiza a contagem de frascos que vai ser Zero
            txtTotal.Text = dgFrascos.RowCount;
            // Esvazia a caixa do código de barras
            txtCodigoBarras.Text = string.Empty;
            // Move o foco para ela
            txtCodigoBarras.Focus();
        }
        else
        {
            // Esvazia a caixa do código de barras
            txtCodigoBarras.Text = string.Empty;
            // Move o foco para ela
            txtCodigoBarras.Focus();
            return;
        }
    }

    private void Baixa_Frascos_Novo()
    {
        // Conta quantas entradas tem
        int Num = dgFrascos.RowCount;

        if (Num <= 0)
        {
            Interaction.MsgBox("Não há elementos na lista para serem processados", Constants.vbOKCancel + Constants.vbCritical, "Erro");
            return;
        }
        // processa todos os frascos

        // String que irá guardar a lista de todos os lotes processados
        string Lista_Lotes = string.Empty;

        for (int i = 0; i <= Num - 1; i++)
        {
            // Lote anterior no primeiro caso é o primeiro lote
            int frascoID = dgFrascos.Rows[i].Cells["coID"].Value;
            // Atualiza a baixa do frasco com o motivo e a contaminação
            string SQL = "UPDATE aux_frascos SET bxExclusao=CURRENT_TIMESTAMP, bxMotivo='" + dgFrascos.Rows[i].Cells["colMotivo"].Value + "', bxOperador=" + Biblioteca.cmbVal(ref cmbOperador) + " WHERE id=" + frascoID;
            // Console.WriteLine(SQL)
            // Consolida no Banco de Dados
            Biblioteca.ExecutaSQL(SQL);
            // Atualiza o estoque do lote reduzindo o número de frascos e atualizando o estoque.
            SQL = "UPDATE lotes SET Est_frascos=est_frascos-1, Estoque=Estoque-" + dgFrascos.Rows[i].Cells["colMUD"].Value;
            // Inclui a contaminação específica (Motivo)
            switch (dgFrascos.Rows[i].Cells["colMotivo"].Value)
            {
                case "F":
                    {
                        SQL += ", fungo=fungo+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        SQL += ", Contaminacao=Contaminacao+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        break;
                    }

                case "B":
                    {
                        SQL += ", bacteria=bacteria+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        SQL += ", Contaminacao=Contaminacao+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        break;
                    }

                case "O":
                    {
                        SQL += ", oxidacao=oxidacao+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        SQL += ", Contaminacao=Contaminacao+" + dgFrascos.Rows[i].Cells["colMUD"].Value;
                        break;
                    }
            }
            // Acrescenta a clausula condicinal
            SQL += " WHERE id=" + dgFrascos.Rows[i].Cells["coCOD"].Value;
            // Efetiva no Banco de dados
            Biblioteca.ExecutaSQL(SQL);

            // Reune a lista de todos os lotes processados.
            // Procura o lote atual dentro da string, se não houver, acrescenta
            if (Lista_Lotes.IndexOf(dgFrascos.Rows[i].Cells["coCOD"].Value) < 0)
            {
                // Se não for a primeira vez que passa aqui
                if (Lista_Lotes.Length > 0)
                    // Se não for a primeira então vai colocando a virgula.
                    Lista_Lotes += "," + dgFrascos.Rows[i].Cells["coCOD"].Value;
                else
                    // Se for a primeira vez
                    Lista_Lotes = dgFrascos.Rows[i].Cells["coCOD"].Value;
            }
        }


        dsFrascos.Tables[0].Clear();
        txtTotal.Text = 0;
        txtCodigoBarras.Text = string.Empty;
        txtCodigoBarras.Focus();
    }


    private void cmbMotivo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        int a;
        // Se quando for selecionado Plantio ou Repicagem perguntar se quer
        // Ativar o modo automático
        if ((Strings.Mid(cmbMotivo.Text, 1, 1) == "P") | (Strings.Mid(cmbMotivo.Text, 1, 1) == "P"))
        {
            a = Interaction.MsgBox("Verificação de modo Plantio ou Repicagem" + Constants.vbCrLf + "Deseja ativar o modo automático?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Sugestão");
            // Se sim então
            if (a == Constants.vbYes)
            {
                // Ativo o checkbox
                chkAuto.Checked = true;
                // Move o foco para o campo de código de barras
                txtCodigoBarras.Focus();
            }
            else
            {
                // Move o foco para o campo de código de barras
                txtCodigoBarras.Focus();
                return;
            }
        }
    }

    private void btFechaO_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmbMotivoO_GotFocus(object sender, System.EventArgs e)
    {
        // Se o automático estiver pressionado não há necessidade de ativar o enter
        if (chkAutoO.Checked)
            // Procura o próximo controle
            SendKeys.Send("{TAB}");
    }

    private void cmbMotivoO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            Biblioteca.EnterAsTab(sender, ref e);
    }

    private void cmbMotivoO_LostFocus(object sender, System.EventArgs e)
    {
        DataTable DT;
        DataRow DR;
        // Agora quando perde o foco é que preenche o datagrid
        // se houver código de barras
        if (!txtCodBarO.Text == string.Empty)
        {
            // verifica se ó código é válido
            if (txtCodBarO.Text.Length > 7 | txtCodBarO.Text.Length < 5)
            {
                Interaction.MsgBox("Código de barras incorreto, favor verificar", MsgBoxStyle.Critical, "Erro");
                goto fim;
                return;
            }
            // Pega os dados da linha selecionada
            DT = Biblioteca.SQLQuery("SELECT * FROM aux_germinacao WHERE Id=" + Conversion.Val(txtCodBarO.Text));
            // Tenta pegar a linha selecionada
            try
            {
                // Pega a linha
                DR = DT.Rows[0];
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Frasco não encontrado!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro");
                goto fim;
                return;
            }
            // Faz a verificação para atestar se o frasco já está na lista

            // Com o parametro especificado
            {
                var withBlock = dgFrascosO;
                // Procura pelo frasco existente
                for (int i = 0; i <= withBlock.RowCount - 1; i++)
                {
                    // se achar o id coincidente
                    if (withBlock.Rows[i].Cells[0].Value == Conversion.Val(txtCodBarO.Text))
                    {
                        Interaction.MsgBox("Este frasco já está na lista!", Constants.vbExclamation, "AVISO");
                        goto fim;
                    }
                }
            }

            // Preenche uma nova linha no datagrid
            // inclui a linha no DATA SET e por conseguencia no datagrid
            dsFrascos.Tables[1].Rows.Add(DR["id"], DR["Lote"], DR["Tipo"], DR["nMudas"], DR["Vidro"], cmbMotivoO.Text.Substring(0, 1));
            DR = null;
            DT = null;
            // Conta o número de frascos
            txtTotalO.Text = dsFrascos.Tables[1].Rows.Count;
        }

    fim:
        ;

        // Limpa o código de barras
        txtCodBarO.Text = string.Empty;
        // move o foco para lá
        txtCodBarO.Focus();
    }

    private void cmbMotivoO_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        int a;
        // Verifica se é repicagem e pergunta Se deve ser ativado o automático
        if (chkAutoO.Checked == false)
        {
            // Se o motivo for Repicagem ou plantio
            if (cmbMotivoO.Text.StartsWith("R") | cmbMotivoO.Text.StartsWith("P"))
            {
                a = Interaction.MsgBox("Verificação de modo Plantio ou Repicagem" + Constants.vbCrLf + "Deseja ativar o modo automático?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");
                // Se sim então
                if (a == Constants.vbYes)
                {
                    // Ativo o checkbox
                    chkAutoO.Checked = true;
                    // Move o foco para o campo de código de barras
                    txtCodBarO.Focus();
                }
                else
                {
                    // Move o foco para o campo de código de barras
                    txtCodBarO.Focus();
                    return;
                }
            }
        }
    }

    private void txtCodBarO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F12)
        {
            // Se pressionou F12 quando o código estava vazio então...
            if (txtCodigoBarras.Text.Length <= 0)
            {
                // Chama o procedimento de encerrar
                btConfirmaO_Click(sender, e);
                goto fim;
            }
        }
        Biblioteca.MoverFoco(this, sender, e);
    Fim:
        ;
    }


    private void btConfirmaO_Click(System.Object sender, System.EventArgs e)
    {
        int Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, NS;
        int SF, SB, SO, SR;
        string SQL_Exclusao;
        Int16 i;
        string LoteOLD;
        bool a;

        // Inicializa as variáveis
        Fungo = 0;
        Bacteria = 0;
        Oxidacao = 0;
        Plantio = 0;
        Repicagem = 0;
        SF = 0;
        SB = 0;
        SO = 0;
        SR = 0;
        NF = 0;
        NS = 0;
        LoteOLD = string.Empty;
        SQL_Exclusao = string.Empty;

        // Primeiro ordenar por lote (para fazer os descontos e acrescimos por lote
        dgFrascosO.Sort(dgFrascosO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);

        pgProcesso.Minimum = 0;
        pgProcesso.Maximum = dgFrascosO.RowCount - 1;
        pgProcesso.Value = 0;

        // Passa por todos os registros
        for (i = 0; i <= dgFrascosO.RowCount - 1; i++)
        {
            {
                var withBlock = dgFrascosO.Rows[i];
                if (i == 0)
                    LoteOLD = withBlock.Cells[1].Value.ToString();
                // Se estamos trabalhando no lote atural
                if (withBlock.Cells[1].Value.ToString() == LoteOLD)
                {
                    // Usa a funcao de soma desenvolvida para fazer o resumo
                    Soma(ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref SF, ref SB, ref SO, ref SR, ref NF, ref NS, i);
                    // Acrescenta na lista de ID que serão excluidos
                    if (SQL_Exclusao == string.Empty)
                        // Se for a primeira vez deixa assim
                        SQL_Exclusao += withBlock.Cells[0].Value.ToString();
                    else
                        // Se já for mais vezes tem que por a virgula antes
                        SQL_Exclusao += "," + withBlock.Cells[0].Value.ToString();
                }
                else
                {
                    // Se o lote atual for diferente do anterior
                    // Processa o lote faz as inclusoes necessárias e reinicializa as variáveis
                    a = Processa_Frascos(LoteOLD, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, SF, SB, SO, ref SR, NS, SQL_Exclusao);
                    // Reinicializa as variáveis
                    Fungo = 0;
                    Bacteria = 0;
                    Oxidacao = 0;
                    Plantio = 0;
                    Repicagem = 0;
                    SF = 0;
                    SB = 0;
                    SO = 0;
                    SR = 0;
                    NF = 0;
                    NS = 0;
                    // Zera a sql de exclusao e comeca com o valor do lote atual
                    SQL_Exclusao = withBlock.Cells[0].Value.ToString();
                    // Soma o do lote atual
                    Soma(ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref SF, ref SB, ref SO, ref SR, ref NF, ref NS, i);
                    // Loteold fica sendo o lote atual
                    LoteOLD = withBlock.Cells[1].Value.ToString();
                }
                if (i == dgFrascosO.RowCount - 1)
                    a = Processa_Frascos(LoteOLD, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, SF, SB, SO, ref SR, NS, SQL_Exclusao);
                // Verifica se o lote é o mesmo do anterior
                // Atualiza a barra de progresso
                pgProcesso.Value = i;
                // Garante a atualização da barra de progresso na hora
                pgProcesso.Refresh();
            }
        }
        // Limpa o datagrid
        // Tudo acabado pode-se limpar o datagrid para a proxima etapa
        dsFrascos.Tables[1].Clear();
        txtTotalO.Text = 0;
        pgProcesso.Value = 0;
    }
    // Esta sub faz a soma das variáveis que é utilizada várias vezes
    private void Soma(ref object fungo, ref object bacteria, ref object oxidacao, ref object plantio, ref object repicagem, ref object SF, ref object SB, ref object SO, ref object SR, ref object Nf, ref object Ns, object i)
    {
        {
            var withBlock = dgFrascosO.Rows[i];
            // Se for um frasco com mudas então ve que tipo de contaminacao e desconta as mudas
            if (withBlock.Cells[2].Value.ToString() == "M")
            {
                switch (withBlock.Cells[5].Value.ToString())
                {
                    case "F":
                        {
                            fungo += Conversion.Val(withBlock.Cells[3].Value.ToString());
                            break;
                        }

                    case "B":
                        {
                            bacteria += Conversion.Val(withBlock.Cells[3].Value.ToString());
                            break;
                        }

                    case "O":
                        {
                            oxidacao += Conversion.Val(withBlock.Cells[3].Value.ToString());
                            break;
                        }

                    case "P":
                        {
                            plantio += Conversion.Val(withBlock.Cells[3].Value.ToString());
                            break;
                        }

                    case "R":
                        {
                            repicagem += Conversion.Val(withBlock.Cells[3].Value.ToString());
                            break;
                        }
                }
                // Um frasco a mais processado
                Nf += 1;
            }
            else if (withBlock.Cells[2].Value.ToString() == "S")
            {
                switch (withBlock.Cells[5].Value.ToString())
                {
                    case "F":
                        {
                            SF += 1;
                            break;
                        }

                    case "B":
                        {
                            SB += 1;
                            break;
                        }

                    case "O":
                        {
                            SO += 1;
                            break;
                        }

                    case "R":
                        {
                            SR += 1;
                            break;
                        }
                }
                // Um frasco de semente processado
                Ns += 1;
            }
        }
    }

    private bool Processa_Frascos(string Lote, int Fungo, int Bacteria, int Oxidacao, int Plantio, int Repicagem, int NF, int SF, int SB, int SO, ref int SR, int NS, string SQL_Exclusao)
    {
        string SQL;
        int TotalMudas;
        // Primeiramente monta a SQL para atualizar o estoque do lote de germinação
        int a;
        Int16 Est_F, Est_S, Est_P;
        string Cod;

        Cod = string.Empty;

        SQL = "UPDATE Germinacao SET ";
        TotalMudas = Fungo + Bacteria + Oxidacao + Plantio + Repicagem;
        SQL += "NMudas=Nmudas-" + TotalMudas + ",";
        SQL += "NSementes=NSementes-" + NS + ",";
        SQL += "Frascos=Frascos-" + NF + ",";
        SQL += "F=F+" + Fungo + ",";
        SQL += "B=B+" + Bacteria + ",";
        SQL += "O=O+" + Oxidacao + ",";
        SQL += "P=P+" + Plantio + ",";
        SQL += "R=R+" + Repicagem + ",";
        SQL += "SF=SF+" + SF + ",";
        SQL += "SB=SB+" + SB + ",";
        SQL += "SO=SO+" + SO + ",";
        SQL += "SR=SR+" + SR + "";
        SQL += " WHERE(Id=" + Lote + ");";
        SQL_Exclusao = "DELETE FROM aux_germinacao WHERE id IN(" + SQL_Exclusao + ");";
        // Debug
        Console.WriteLine(this.Name + ": " + SQL);
        Console.WriteLine(this.Name + ": " + SQL_Exclusao);
        // Executa a SQL de processamento dos frascos
        try
        {
            Biblioteca.ExecutaSQL(SQL);
            Biblioteca.ExecutaSQL(SQL_Exclusao);
            // Consulta o lote para ver como estão os estoques
            // Se tiver algum estoque zerado tem de inativar o lote.
            Est_S = Biblioteca.DLookup("NSementes", "germinacao", "id=" + Lote);
            Est_F = Biblioteca.DLookup("Frascos", "germinacao", "id=" + Lote);
            Est_P = Biblioteca.DLookup("NPlantadas", "germinacao", "id=" + Lote);
            Cod = Biblioteca.DLookup("Cod", "germinacao", "id=" + Lote);
            // Se todos os estoques estiverem zerados então anula o lote
            if (Est_S <= 0 & Est_F <= 0 & Est_P <= 0)
            {
                a = Interaction.MsgBox("O estoque do lote " + Cod + " (" + Lote + ") é menor ou igua a ZERO" + Constants.vbCrLf + "Sementes: " + Est_S + Constants.vbCrLf + "Mudas: " + Est_F + Constants.vbCrLf + "Plantadas: " + Est_P + Constants.vbCrLf + "Deseja desativar o lote?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");
                // Se for confirmado
                if (a == Constants.vbYes)
                {
                    SQL = "UPDATE Germinacao SET Ativo=0,Inativado=NOW() WHERE id=" + Lote;
                    try
                    {
                        // Tenta executar a SQL
                        Biblioteca.ExecutaSQL(SQL);
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox("Erro ao tentar inativar o lote " + Cod + " (" + Lote + ")" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly);
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar atualizar o estoque de frascos de orquídeas no lote " + Cod + " (" + Lote + ")" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly);
            // se deu erro já retorna por aqui como falso
            return false;
        }
        // Se deu tudo certo retorna verdadeiro
        return true;
    }

    private void TabLotes_Click(object sender, EventArgs e)
    {
    }
}
