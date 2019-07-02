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

public partial class frmRastreamentoLotes
{
    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        // Primeiro verifica se não está vazio
        if (txtCodigo.Text == string.Empty)
            return;
        // Se o código for muito curto
        if (txtCodigo.Text.Length < 11)
        {
            Interaction.MsgBox("Código do lote inválido", MsgBoxStyle.Critical, "Erro");
            txtCodigo.Text = string.Empty;
            txtCodigo.Focus();
            return;
        }

        // Agora tira todos os pontos do código
        string Codigo;
        Codigo = txtCodigo.Text.Replace(".", "");

        // Verifica como é que o usuário digitou, ou se ele scaneou o código
        switch (Codigo.Length)
        {
            case 14 // 00230580000067 (Lido com código de barras)
           :
                {
                    // Separa as porções de código
                    txtMercadoria.Text = Conversion.Int(Codigo.Substring(1, 3));
                    txtLote.Text = Conversion.Int(Codigo.Substring(4, 3));
                    txtClone.Text = Conversion.Int(Codigo.Substring(7, 4));
                    break;
                }

            case 9  // 230580000 (Digitado à mão, mas já sem os pontos)
     :
                {
                    // Separa as porções de código
                    txtMercadoria.Text = Conversion.Int(Codigo.Substring(0, 2));
                    txtLote.Text = Conversion.Int(Codigo.Substring(2, 3));
                    txtClone.Text = Conversion.Int(Codigo.Substring(5, 4));
                    break;
                }

            case 10  // 0230580000 (Digitado à mão, mas já sem os pontos)
     :
                {
                    // Separa as porções de código
                    txtMercadoria.Text = Conversion.Int(Codigo.Substring(0, 3));
                    txtLote.Text = Conversion.Int(Codigo.Substring(3, 3));
                    txtClone.Text = Conversion.Int(Codigo.Substring(6, 4));
                    break;
                }

            default:
                {
                    Interaction.MsgBox("O código não pode ser identificado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                    return;
                }
        }

        // Localizar o ID do lote em questão
        DataTable DT;
        DT = Biblioteca.SQLQuery("SELECT id,origem,mercadoria,lote,clone,Est_Inicial,Contaminacao, DATA, fase, (SELECT est_inicial-contaminacao AS nmudas FROM lotes AS lotes2 WHERE id=lotes.origem) AS mudas_ori FROM lotes WHERE Mercadoria=" + txtMercadoria.Text + " AND Lote=" + txtLote.Text + " AND Clone=" + txtClone.Text + " AND Ativo=1");
        // Se não foi localizado nenhuma linha
        if (DT.Rows.Count <= 0)
        {
            Interaction.MsgBox("Nenhum lote ativo encontrado paara este código!", MsgBoxStyle.Critical, "Erro");
            txtCodigo.Text = string.Empty;
            txtCodigo.Focus();
            return;
        }
        // Pega a linha que foi localizada
        DataRow DR = DT.Rows[0];

        double varNOrigem = 0;

        if (!Information.IsDBNull(DR["mudas_ori"]) & !Information.IsDBNull(DR["est_inicial"]))
            varNOrigem = DR["est_inicial"] / (double)DR["mudas_ori"];
        else
            varNOrigem = 0;

        // Primeira linha
        dsRastreio.Tables[0].Rows.Add(DR["id"], DR["Mercadoria"] + "." + DR["Lote"] + "." + DR["Clone"], DR["Est_Inicial"], varNOrigem, DR["Contaminacao"] / (double)DR["Est_inicial"] * 100, DR["Data"], DR["Fase"], DR["Contaminacao"], DR["Est_inicial"] - DR["Contaminacao"]);

        int varOrigem = DR["Origem"];
        // Agora começa a procurar os demais lotes
        while (varOrigem > 0)
        {
            var varEstoque = 0;
            Console.WriteLine("Origem=" + varOrigem);
            DT = Biblioteca.SQLQuery("SELECT id,origem,mercadoria,lote,clone,Est_Inicial,Contaminacao, DATA, fase, (SELECT est_inicial-contaminacao AS nmudas FROM lotes AS lotes2 WHERE id=lotes.origem) AS mudas_ori FROM lotes WHERE id=" + varOrigem);
            // Se não foi localizado nenhuma linha
            if (DT.Rows.Count <= 0)
                goto fim;
            // Pega a linha que foi localizada
            DR = DT.Rows[0];

            if (!Information.IsDBNull(DR["mudas_ori"]) & !Information.IsDBNull(DR["est_inicial"]))
                varNOrigem = DR["est_inicial"] / (double)DR["mudas_ori"];
            else
                varNOrigem = 0;

            // Mostra o que restou para que desse aqueles valores
            varEstoque = DR["Est_Inicial"] - DR["Contaminacao"];

            // Linhas sequenciais
            dsRastreio.Tables[0].Rows.Add(DR["id"], DR["Mercadoria"] + "." + DR["Lote"] + "." + DR["Clone"], DR["est_inicial"], varNOrigem, DR["Contaminacao"] / (double)DR["Est_inicial"] * 100, DR["Data"], DR["Fase"], DR["Contaminacao"], DR["Est_inicial"] - DR["Contaminacao"]);
            varOrigem = Interaction.IIf(Information.IsDBNull(DR["Origem"]), -1, DR["Origem"]);
        }

    Fim:
        ;

        // Fecha as estatisticas para o lote rastreado.
        Estatisticas();
    }

    private void Estatisticas()
    {
        // Se tiver algo na tabela
        if (dgRastro.Rows.Count > 0)
        {
            int varMudas = 0;
            double varMult = 0;
            double varCont = 0;
            // Percorre todos os resultados fazendo as somas
            int varDias = 0;
            for (int i = 0; i <= dgRastro.Rows.Count - 1; i++)
            {
                {
                    var withBlock = dgRastro.Rows[i];
                    varMudas += withBlock.Cells[datMudas.Index].Value;
                    varMult += withBlock.Cells[datTaxa.Index].Value;
                    varCont += withBlock.Cells[datCont.Index].Value;
                    // Conta os dias entre as datas (a partir da segunda linha)
                    if (i > 0)
                    {
                        DateTime Data_Atu;
                        DateTime Data_Ant;
                        TimeSpan Horas;
                        Data_Atu = withBlock.Cells[datData.Index].Value;
                        Data_Ant = dgRastro.Rows[i - 1].Cells[datData.Index].Value;
                        // subtrai a data da data atual
                        Horas = Data_Ant.Subtract(Data_Atu);
                        // Calcula o número de dias entre as datas
                        varDias += Horas.Days;
                    }
                }
            }
            // Preenche os resultados
            Label10.Text = Strings.Format(varMudas, "N0");
            Label11.Text = Strings.Format(varCont / dgRastro.Rows.Count, "N1");
            Label12.Text = Strings.Format(varMult / dgRastro.Rows.Count, "N2");
            Label13.Text = dgRastro.Rows.Count;
            Label15.Text = Conversion.Int(varDias / (double)dgRastro.Rows.Count);
        }
    }


    private void txtCodigo_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // Muda para o controle seguinte
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void Button3_Click(System.Object sender, System.EventArgs e)
    {
        // Limpa todos os resultados
        txtCodigo.Text = string.Empty;
        txtMercadoria.Text = "000";
        txtLote.Text = "000";
        txtClone.Text = "0000";
        Label10.Text = "...";
        Label11.Text = "...";
        Label12.Text = "...";
        Label13.Text = "...";
        Label15.Text = "...";
        txtCodigo.Focus();
        // Apaga todos os registros contidos no DataSet
        dsRastreio.Tables[0].Rows.Clear();
    }

    private void dgRastro_CellContentDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;

        int ID = -1;
        // Pega o ID do Lote
        ID = dgRastro.SelectedRows[0].Cells[0].Value;

        // Monta uma nova instancia da Tela de Lotes
        frmNovoLotes viewDetalhe = new frmNovoLotes("L", ID);
        // Define o MDI parent
        viewDetalhe.MdiParent = this.MdiParent;
        this.Cursor = Cursors.Arrow;
        // Por fim mostra o lote
        viewDetalhe.Show();
    }
}
