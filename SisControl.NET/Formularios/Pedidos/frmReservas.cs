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
using System.ComponentModel;

namespace SisControl.NET
{
    public partial class frmReservas
    {
        public frmReservas()
        {

            // This call is required by the designer.
            InitializeComponent();
        }

        private void frmReservas_Load(System.Object sender, System.EventArgs e)
        {
            // Atualiza DataGrig
            Atualiza_Datagrid();
            // Carrega o nome das mercadorias
            Biblioteca.Carrega_Lista(ref cmbMercadoria, "mercadoria_num", "id", "Nome", true);
            // Atualiza para data de hoje
            txtData.Value = DateTime.Today.Date;
        }

        private void ReservasDataGridView_SelectionChanged(System.Object sender, System.EventArgs e)
        {
            Aplica_Filtro();
        }

        private void Atualiza_Datagrid()
        {
            try
            {
                // Preenche novamente
                taReservas.Fill(DsReserva.reservas);
            }
            catch (Exception ex)
            {
                // MsgBox("Erro" & vbCrLf & ex.Message)
                Console.WriteLine("Erro Popular Reservas" + ex.Message);
                return;
            }
        }

        private void Aplica_Filtro()
        {
            // Se existir alguma linha selecionada aplica o filtro
            if (dgReservas.SelectedRows.Count > 0)
            {
                // Filtra os sub ítens das reservas selecionadas
                string Criterio = string.Empty;
                // Pega o ID da linha selecionada
                Criterio = "Doc_ID=" + dgReservas.SelectedRows[0].Cells[0].Value;
                // Aplica o filtro no BindingSource dos ítens
                DataTable DT = new DataTable();
                try
                {
                    DT = Biblioteca.SQLQuery("SELECT * FROM reservas_itens WHERE " + Criterio);
                    dgItens.DataSource = DT;
                    DT.Dispose();
                    Formata_Grid_Itens();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Erro ao tentar recuperar os ítens da reserva" + Constants.vbCrLf + ex.Message);
                    return;
                }
            }
        }

        private void Formata_Grid_Itens()
        {
            {
                var withBlock = dgItens;
                {
                    var withBlock1 = withBlock.Columns["id"];
                    withBlock1.Visible = false;
                }
                {
                    var withBlock1 = withBlock.Columns["Doc_Id"];
                    withBlock1.Visible = false;
                }
                {
                    var withBlock1 = withBlock.Columns["Mercadoria"];
                    withBlock1.Width = 65;
                    withBlock1.HeaderText = "Mercadoria";
                    withBlock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    withBlock1.DefaultCellStyle.Format = "000";
                }
                {
                    var withBlock1 = withBlock.Columns["Clone"];
                    withBlock1.HeaderText = "Clone";
                    withBlock1.Width = 65;
                    withBlock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    withBlock1.DefaultCellStyle.Format = "0000";
                }
                {
                    var withBlock1 = withBlock.Columns["Descricao"];
                    withBlock1.HeaderText = "Descrição";
                    withBlock1.Width = 200;
                }
                {
                    var withBlock1 = withBlock.Columns["Quantidade"];
                    withBlock1.HeaderText = "Quantidade";
                    withBlock1.Width = 70;
                    withBlock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    withBlock1.DefaultCellStyle.Format = "N0";
                }
                {
                    var withBlock1 = withBlock.Columns["Preco"];
                    withBlock1.HeaderText = "Valor";
                    withBlock1.Width = 50;
                    withBlock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    withBlock1.DefaultCellStyle.Format = "N2";
                }
                {
                    var withBlock1 = withBlock.Columns["Forma"];
                    withBlock1.HeaderText = "Forma";
                    withBlock1.Width = 135;
                    withBlock1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void btAtendida_Click(System.Object sender, System.EventArgs e)
        {
            // Verifica se existe alguma linha selecionada
            if (dgReservas.SelectedRows.Count <= 0)
            {
                Interaction.MsgBox("Não existe nenhuma reserva selecionada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }

            // Se houver alguma linha selecionada continua
            int IDReserva;
            // Pega o id da reserva
            IDReserva = dgReservas.SelectedRows[0].Cells[0].Value;
            // monta a SQL de atualização
            string SQL;
            SQL = "UPDATE Reservas SET Atendido=1 WHERE id=" + IDReserva;

            try
            {
                // Executa a Atualização
                Biblioteca.ExecutaSQL(SQL);
                // Se Deu certo, atualiza o Datagrid
                Atualiza_Datagrid();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar atualizar as informações da Reserva", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }

        private void btExcluir_Click(System.Object sender, System.EventArgs e)
        {
            // Verifica se existe alguma linha selecionada
            if (dgReservas.SelectedRows.Count <= 0)
            {
                Interaction.MsgBox("Não existe nenhuma reserva selecionada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }

            int resp = Interaction.MsgBox("Deseja realmente excluir a Reserva Selecionada e todos os seus ítens?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");

            // Verifica confirmação
            if (resp != Constants.vbYes)
                return;

            // Se o usuário confirmar então exclui

            int IDReserva;
            // Pega o id da reserva
            IDReserva = dgReservas.SelectedRows[0].Cells[0].Value;
            string SQL;
            // monta a SQL de atualização
            var SQL_Itens;
            SQL = "DELETE FROM Reservas WHERE id=" + IDReserva;
            SQL_Itens = "DELETE FROM reservas_itens WHERE Doc_Id=" + IDReserva;
            // Tenta excluir os ítens da reserva
            try
            {
                // Exclui o ítens da reserva
                Biblioteca.ExecutaSQL(SQL_Itens);
                Atualiza_Datagrid();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar excluir os Ítens da Reserva Núm: " + IDReserva, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
            // Tenta excluir a reserva em sí
            try
            {
                // Exclui a reserva em sí
                Biblioteca.ExecutaSQL(SQL);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar excluir a Reserva de Núm: " + IDReserva, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }

        private void cboMercadoria_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // Se não houver produto selecionado
            if (cmbMercadoria.SelectedIndex == -1)
                return;
            // Carrega os clones assim que a caixa de produtos for alterada
            Biblioteca.Carrega_Lista(ref cmbClone, "clones_num", "id", "nome", true, "Mercadoria=" + Biblioteca.cmbVal(ref cmbMercadoria));
        }

        private void txtQuantidade_Leave(System.Object sender, System.EventArgs e)
        {
            txtQuantidade.Text = Strings.Format(Biblioteca.String_to_Numero(txtQuantidade.Text), "N0");
        }

        private void TextBox1_Leave(System.Object sender, System.EventArgs e)
        {
            txtValor.Text = Strings.Format(Biblioteca.String_to_Numero(txtValor.Text), "N2");
        }

        private void ToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
        {
            string email;
            // Pega o e-mail do cliente da linha selecionada
            email = dgReservas.SelectedRows[0].Cells[4].Value;
            // Copia para o clipboard
            Clipboard.SetText(email, TextDataFormat.Text);
        }

        private void btIncluir_Click(System.Object sender, System.EventArgs e)
        {
            string SQL = string.Empty;
            // Monta a SQL de inclusão
            SQL = "INSERT INTO reservas SET ";
            SQL += "Data='" + Strings.Format(txtData.Value, "yyyy-MM-dd") + "',";
            SQL += "Nome='" + txtNome.Text + "',";
            SQL += "Fone=" + Biblioteca.Texto_Vazio(txtFone.Text) + ",";
            SQL += "Email=" + Biblioteca.Texto_Vazio(txtEmail.Text) + ",";
            SQL += "Atendido=0";

            if (Valida_Campos())
            {
                // Tenta fazer a inclusão
                try
                {
                    Biblioteca.ExecutaSQL(SQL);
                    DataGridRefresh();
                    // Posiciona a seleção no último ítem
                    dgReservas.Rows[dgReservas.Rows.Count - 1].Selected = true;
                    Limpa_Campos();
                    Interaction.MsgBox("Reserva incluída com sucesso. Utilize o campo abaixo para incluir os ítens da Reserva", MsgBoxStyle.OkOnly);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Erro ao tentar incluir Reserva", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                    return;
                }
            }
            else
            {
            }
        }

        private bool Valida_Campos()
        {
            string msg = string.Empty;

            // Verifica o nome que não pode ser  nulo
            if (txtNome.Text == string.Empty)
                msg += "Nome não pode estar em branco" + Constants.vbCrLf;

            // Deu erro em algum campo
            if (msg.Length > 0)
            {
                Interaction.MsgBox("O preenchimento dos campos está incorreto, verifique:" + Constants.vbCrLf + msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso");
                return false;
            }
            else
                return true;
        }

        private void Limpa_Campos()
        {
            txtData.Value = DateTime.Today;
            txtNome.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btAdd_Item_Click(System.Object sender, System.EventArgs e)
        {
            string SQL = string.Empty;
            string Descricao;
            int Mercadoria;
            int Clone;

            Mercadoria = Biblioteca.cmbVal(ref cmbMercadoria);
            Clone = Conversion.Int(cmbClone.Text.Substring(0, 4));
            Descricao = Biblioteca.DLookup("Cientifico", "Mercadoria", "id=" + Mercadoria) + " cv. " + Biblioteca.DLookup("Nome", "Clones", "Mercadoria=" + Mercadoria + " AND Clone=" + Clone);

            SQL = "INSERT INTO reservas_itens SET ";
            SQL += "Doc_ID=" + dgReservas.SelectedRows[0].Cells[0].Value + ",";
            SQL += "Mercadoria=" + Mercadoria + ",";
            SQL += "Clone=" + Clone + ",";
            SQL += "Descricao='" + Descricao + "',";
            SQL += "Quantidade=" + Biblioteca.Numero_to_SQL(txtQuantidade.Text) + ",";
            SQL += "Forma='Muda Aclimatizada',";
            SQL += "Preco=" + Biblioteca.Numero_to_SQL(txtValor.Text);

            try
            {
                Biblioteca.ExecutaSQL(SQL);
                Interaction.MsgBox("Item acrescentado com sucesso!");
                Aplica_Filtro();
                cmbMercadoria.Text = "";
                cmbClone.Text = "";
                txtQuantidade.Text = "0";
                txtValor.Text = "0,00";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar incluir item na reserva" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }

        private void btRemove_Item_Click(System.Object sender, System.EventArgs e)
        {
            string SQL;

            // Monta a SQL de exclusão
            SQL = "DELETE FROM reservas_itens WHERE id=" + dgItens.SelectedRows[0].Cells[0].Value;

            try
            {
                Biblioteca.ExecutaSQL(SQL);
                Interaction.MsgBox("Item excluído com sucesso!");
                Aplica_Filtro();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar excluir item da reserva" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }

        private void btEdit_Click(System.Object sender, System.EventArgs e)
        {
            // Prevê as duas situações
            if (btEdit.Text == "Alterar")
                // Pega as informações no banco de dados e muda o texto do botão para Salvar

                btEdit.Text = "Salvar";
            else if (btEdit.Text == "Salvar")
            {
            }
        }

        private void btEmail_Click(object sender, EventArgs e)
        {
            aux_Processa_Email Aux_Email = new aux_Processa_Email(ref this);
            // Define a mesma janela parente
            Aux_Email.MdiParent = this.MdiParent;
            // Mostra como uma caixa de diálogo
            Aux_Email.Show();
        }

        public void DataGridRefresh()
        {
            // Depois de sair do diálogo atualiza o datagrid
            Atualiza_Datagrid();
            // Posiciona a seleção no último ítem
            dgReservas.Rows[dgReservas.Rows.Count - 1].Selected = true;
            dgReservas.CurrentCell = dgReservas.Rows[dgReservas.Rows.Count - 1].Cells[0];
        }
    }
}
