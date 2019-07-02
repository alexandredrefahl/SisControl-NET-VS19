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

public partial class frmRecuperacao
{
    // Flag para determinar o lote ativo
    private bool FLAG = false;

    private void frmRecuperacao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void frmRecuperacao_Load(System.Object sender, System.EventArgs e)
    {
        // Dimensiona os vetores para formatação do datagrid
        string[] heaFrascos = new[] { "Merc", "Lote", "Clone", "Frasco", "Nº Mudas", "Motivo", "ID", "Cód" };
        int[] widFrascos = new[] { 50, 50, 50, 50, 77, 50, 50, 50 };
        int[] visFrascos = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        string[] heaRecuperados = new[] { "Nº Frasco", "Nº Mudas" };
        int[] widRecuperados = new[] { 70, 70 };
        int[] visRecuperados = new[] { 1, 1 };

        // Preenche a data no campo data
        txtData.Text = Strings.Format(DateTime.Today(), "dd/MM/yyyy");
        cmbMotivo.Text = "Fungo";
        // Formata o datagrid com os headers e tamahos

        // Define a primeira coluna (morta)
        dgFrascos.RowHeadersWidth = 20;
        dgRecuperados.RowHeadersWidth = 20;

        // Usa a funcao genérica para formatar o datagrid
        Biblioteca.Formata_Datagrid(ref dgFrascos, heaFrascos, widFrascos, visFrascos);
        Biblioteca.Formata_Datagrid(ref dgRecuperados, heaRecuperados, widRecuperados, visRecuperados);

        // Move o posicionamento para a primeira aba
        TabRecuperacao.SelectedTab = Tab1;
        // Move o foco para o código de barras
        txtCodigoBarras.Focus();
    }

    private void btConfirma_Click(System.Object sender, System.EventArgs e)
    {
        bool Resp;
        // Tenta a fazer a exclusão 
        Resp = Generico.Baixa_Frascos(ref dgFrascos, ref dsFrascos, ref txtData, 1);
        if (Resp)
        {
            // Atualiza as labels e move a tab para o controle
            lblPasso1.Enabled = false;
            lblPasso2.Enabled = true;
            lblPasso3.Enabled = false;
            TabRecuperacao.SelectedTab = Tab2;
            // Move o foco para a caixa de texto nFrascos
            txtNFrascos.Focus();
        }
        else
        {
            txtCodigoBarras.Text = string.Empty;
            txtCodigoBarras.Focus();
        }
    }

    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        if (dgRecuperados.Rows.Count > 0)
        {
            string SQL;
            string SQLLotes;
            int NMudas;
            // monta a SQL base
            SQL = "INSERT INTO aux_frascos (Lote,Vidro,NMudas,Impresso,Selecao) VALUES ";
            // Com o grid de recuperados
            {
                var withBlock = dgRecuperados;
                // Roda todas as linhas para pegar os valores
                for (int i = 0; i <= dgRecuperados.Rows.Count - 1; i++)
                {
                    // Se for a primeira vez que passa aqui não usa virgula
                    if (i == 0)
                        SQL += "(" + lblID.Text + "," + withBlock.Rows[i].Cells[0].Value + "," + withBlock.Rows[i].Cells[1].Value + ",0,0)";
                    else
                        SQL += ",(" + lblID.Text + "," + withBlock.Rows[i].Cells[0].Value + "," + withBlock.Rows[i].Cells[1].Value + ",0,0)";
                    // Vai somando o número total de mudas
                    NMudas += withBlock.Rows[i].Cells[1].Value;
                }
            }
            // Monta a SQL para atualizar o estoque no cadastro de lotes
            SQLLotes = "UPDATE Lotes SET Estoque=Estoque+" + NMudas.ToString() + ",Est_frascos=Est_Frascos+" + dgRecuperados.Rows.Count + " WHERE id=" + lblID.Text;

            // Debug
            Console.WriteLine(SQL);
            Console.WriteLine(SQLLotes);
            try
            {
                // Executa a sql de inserção
                Biblioteca.ExecutaSQL(SQL);
                Biblioteca.ExecutaSQL(SQLLotes);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao atualizar o banco de dados." + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString());
                return;
            }

            // Atualiza as labels
            lblPasso1.Enabled = false;
            lblPasso2.Enabled = false;
            lblPasso3.Enabled = true;
            // Altera a TAB ativa
            TabRecuperacao.SelectedTab = Tab3;
        }
        else
        {
            Interaction.MsgBox("É necessário incluir pelo menos um frasco.", MsgBoxStyle.Critical, "Erro");
            return;
        }
    }

    private void Button3_Click(System.Object sender, System.EventArgs e)
    {
        int a;
        // Pergunta ao usuario se ele quer recuperar mais algum lote
        a = Interaction.MsgBox("Deseja recuperar algum outro lote?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação");
        if (a == Constants.vbYes)
        {
            // Utiliza a função para finalizar a edição
            Finaliza_Edicao();
            // Move o foco para a caixa do código de barras
            txtCodigoBarras.Focus();
        }
        else
            // Fecha o formulario
            this.Close();
        Finaliza_Edicao();
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void txtNFrascos_Enter(object sender, System.EventArgs e)
    {
        // Seleciona todo o texto
        txtNFrascos.SelectAll();
    }

    private void btIncluir_Click(System.Object sender, System.EventArgs e)
    {
        int i;
        int Max;

        // Verifica qual o maior numero de frasco desde lote
        Max = Biblioteca.DMax("Vidro", "aux_frascos", "Lote=" + lblID.Text);
        // Se o lote não tiver mais frascos
        if (Information.IsDBNull(Max) | Information.IsNothing(Max))
            // Então zera o número de frascos
            Max = 0;
        // Se retornou alguma coisa
        // If Max <> Nothing Then
        for (i = (Max + 1); i <= (Max + Conversion.Int(txtNFrascos.Text)); i++)
            // inclui a linha no DATA SET e por conseguencia no datagrid
            dsFrascos.Tables[1].Rows.Add(i, txtM_f.Text);
        // End If
        dgRecuperados.Enabled = true;
    }


    private void Button4_Click(System.Object sender, System.EventArgs e)
    {
        string SQL;
        int ct;
        string Descricao;
        string CodBase;
        string Data;
        // Descrição já está pronta no cabecalho
        Descricao = lblLote.Text;
        // Separa o código em pedaços
        CodBase = Descricao;
        // usa o artificio para retirar os pontos do código
        CodBase = CodBase.Replace(".", "");

        Data = Strings.Format((DateTime)lblData.Text, "dd/MM/yy");

        // Monta a SQL padrão
        SQL = "INSERT INTO etiquetas_prn VALUES ";
        try
        {
            // Faz o looping com todos as etiquetas deste lote(datagrid)
            for (ct = 0; ct <= dgRecuperados.RowCount - 1; ct++)
            {
                // Se for a segunda vez que passa aqui poe uma virgula
                if (ct > 0)
                    SQL = SQL + ",";
                // Vai montando a SQL
                SQL = SQL + "(null,'" + Descricao + "','" + CodBase + Strings.Format((int)dgRecuperados.Rows[ct].Cells[0].Value, "000") + "','" + Data + "'," + Strings.Format((int)dgRecuperados.Rows[ct].Cells[1].Value, "000") + ")";
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro na geração das etiquetas!" + Constants.vbCr + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }

        // Tenta Executar a SQL montada
        try
        {
            Biblioteca.ExecutaSQL(SQL);
            // Se deu tudo certo vai adiante
            Interaction.MsgBox(Strings.Format(ct, "000") + " Etiquetas enviadas para impressão!", MsgBoxStyle.OkOnly, "Confirmação");
            lblImpressas.Text = "Etiquetas Impressas - OK";
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao enviar as etiquetas para impressão!" + Constants.vbCr + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Exclamation, "Erro");
            return;
        }
        // Marca todas as etiquetas desta lote como impressas
        try
        {
            SQL = "UPDATE aux_frascos SET Impresso=1 WHERE Lote=" + lblID.Text;
            // Tenta marcar os frascos
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao marcar as etiquetas como impressas!" + Constants.vbCr + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Exclamation, "Erro");
            return;
        }
    }

    public void Finaliza_Edicao()
    {
        // Atualiza os rótulos de dados
        lblLote.Text = "000.000.0000";
        lblID.Text = "0000";
        lblData.Text = "00/00/0000";
        // Muda para aba 1 e atualiza os rótulos de dados
        lblPasso1.Enabled = true;
        lblPasso2.Enabled = false;
        lblPasso3.Enabled = false;
        TabRecuperacao.SelectedTab = Tab1;
        // Apaga todas as caixas de texto
        txtData.Text = Strings.Format(DateTime.Today, "dd/MM/yyyy");
        txtCodigoBarras.Text = string.Empty;
        cmbMotivo.Text = "Fungos";
        txtNFrascos.Text = "0";
        txtM_f.Text = "0";
        // Apaga os dados contidos nas duas tabelas
        dsFrascos.Tables[0].Clear();
        dsFrascos.Tables[1].Clear();
        // Label de etiquestas impressas
        lblImpressas.Text = "  ";
        // Dasabilita a edição dos frascos
        dgRecuperados.Enabled = false;
        // Define a flag para o novo lote
        FLAG = false;
    }

    private void txtNCont_LostFocus(object sender, System.EventArgs e)
    {
        int Resposta = default(Integer);
        // Coloca o cursor em espera
        this.Cursor = Cursors.WaitCursor;
        // Usa a função compartilhada no Modulo Generico arquivo Biblioteca.vb
        Resposta = Generico.Adiciona_Frasco(ref dgFrascos, ref dsFrascos, ref txtCodigoBarras, ref cmbMotivo, ref txtTotal);
        // se for a primeira vez que passa aqui
        if ((!FLAG) & (Resposta != -1))
        {
            // Coloca o código do lote na label
            lblID.Text = Strings.Format(Resposta, "####");
            // Retorna o código do lote em forma de texto
            lblLote.Text = Biblioteca.Procura_Lote(Conversion.Int(lblID.Text));
            // Já procura a data do lote na primeira passada
            lblData.Text = Biblioteca.DLookup("Data", "lotes", "id=" + Resposta);
            // Seta a flag para que ele não tenha que ficar procurando toda vez
            FLAG = true;
        }
        // Corrige os frascos contaminados
        if ((Resposta != -1))
            // Vai na última linha e troca o valor do frasco
            dgFrascos.Rows[dgFrascos.Rows.Count - 1].Cells[4].Value = txtNCont.Text;
        // Volta o cursor ao normal
        this.Cursor = Cursors.Arrow;
        // Limpa a caixa de texto 
        txtNCont.Text = string.Empty;
    }
}
