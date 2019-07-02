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
using System.Globalization;

public partial class frmClientes
{
    private int IDCliente = 0;
    private int IDModo = 0;
    private string SQL;

    public frmClientes(int ClienteID = 0, int Modo = 0)
    {
        // Modo=0 -> Editar, Modo=1 -> Visualizar

        // This call is required by the designer.
        InitializeComponent();

        // Se for informado carrega a ficha do cliente
        if (ClienteID != 0)
        {
            IDCliente = ClienteID;
            if (Modo != 0)
                IDModo = 1;
            else
                IDModo = 0;
        }
    }

    private void frmClientes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == 13)
            Biblioteca.EnterAsTab(sender, ref e);
    }

    private void frmClientes_Load(System.Object sender, System.EventArgs e)
    {
        // Preenche o Combo com o nome dos clientes
        Biblioteca.Carrega_Lista(ref cmbCliente, "Clientes", "id", "Nome", true);
        // Se foi informado um cliente
        if (IDCliente != 0)
            Carrega_Cliente();
    }

    private void Carrega_Cliente()
    {
        string SQL = string.Empty;
        // Clientes
        SQL = "SELECT * FROM Clientes WHERE id=" + IDCliente;

        try
        {
            DataTable DT;
            DT = Biblioteca.SQLQuery(SQL);
            // Se encontrou um resultado
            if (DT.Rows.Count > 0)
            {
                {
                    var withBlock = DT.Rows[0];
                    txtCodigo.Text = withBlock.Item["id"];
                    txtNome.Text = Biblioteca.NaoNulo(withBlock.Item["Nome"]);
                    txtEndereco.Text = Biblioteca.NaoNulo(withBlock.Item["Endereco"]);
                    txtNum.Text = Biblioteca.NaoNulo(withBlock.Item["Num"]);
                    txtBairro.Text = Biblioteca.NaoNulo(withBlock.Item["Bairro"]);
                    txtCEP.Text = Biblioteca.NaoNulo(withBlock.Item["CEP"]);
                    txtCidade.Text = Biblioteca.NaoNulo(withBlock.Item["Cidade"]);
                    txtCodMun.Text = Biblioteca.NaoNulo(withBlock.Item["CodMun"]);
                    txtEstado.Text = Biblioteca.NaoNulo(withBlock.Item["Estado"]);
                    txtPais.Text = Biblioteca.NaoNulo(withBlock.Item["Pais"]);
                    txtCodPais.Text = Biblioteca.NaoNulo(withBlock.Item["codPais"]);
                    if (!Information.IsDBNull(withBlock.Item["PFPJ"]))
                    {
                        Interaction.IIf(withBlock.Item["PFPJ"] == "F", rdPF.Checked == true, rdPJ.Checked == true);
                        Interaction.IIf(withBlock.Item["PFPJ"] == "F", Label9.Text == "CPF", "CNPJ");
                    }
                    txtCNPJ.Text = Biblioteca.NaoNulo(withBlock.Item["cpf_cnpj"]);
                    txtIE.Text = Biblioteca.NaoNulo(withBlock.Item["RG_IE"]);
                    txtFone.Text = Biblioteca.NaoNulo(withBlock.Item["Fone"]);
                    txtFax.Text = Biblioteca.NaoNulo(withBlock.Item["Fax"]);
                    txtCelular.Text = Biblioteca.NaoNulo(withBlock.Item["Celular"]);
                    txtEmail.Text = Biblioteca.NaoNulo(withBlock.Item["email"]);
                    txtSite.Text = Biblioteca.NaoNulo(withBlock.Item["site"]);
                    txtOBS.Text = Biblioteca.NaoNulo(withBlock.Item["Observacoes"]);
                    txtContrato.Text = Biblioteca.NaoNulo(withBlock.Item["Contrato"]);
                    txtProdutos.Text = Biblioteca.NaoNulo(withBlock.Item["Produtos"]);
                    txtContato.Text = Biblioteca.NaoNulo(withBlock.Item["Contato"]);
                }
                Button4.Text = "Salvar";
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar localizar dados do cliente." + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        if (txtCodigo.Text != "")
        {
            auxPedidos Form = new auxPedidos(txtCodigo.Text);
            // Define que é mdichild
            Form.MdiParent = My.MyProject.MyForms.frmMenu;
            // Mostra formulário
            Form.Show();
        }
    }

    private void cmbCliente_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        // Atualiza clientes
        IDCliente = Biblioteca.cmbVal(ref cmbCliente);
        Carrega_Cliente();
    }


    private void Button4_Click(System.Object sender, System.EventArgs e)
    {
        if (Button4.Text == "Incluir")
            Inclui_Cliente();
        else if (Button4.Text == "Salvar")
            Salva_Cliente();
    }

    private void Inclui_Cliente()
    {
        string SQL;

        SQL = "INSERT INTO Clientes SET ";

        // Rotina que monta a SQL dos campos
        SQL += Monta_SQL();

        try
        {
            Biblioteca.ExecutaSQL(SQL);
            Interaction.MsgBox("Inclusão do cliente realizada com sucesso!", MsgBoxStyle.Information, "Confirmação");
            Biblioteca.Limpa_Campos(ref this);
            txtNome.Focus();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar incluir a ficha do cliente." + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }
    }

    private void Salva_Cliente()
    {
        string SQL;

        SQL = "UPDATE Clientes SET ";

        // Rotina que monta a SQL dos campos
        SQL += Monta_SQL();

        SQL += " WHERE id=" + txtCodigo.Text;

        try
        {
            Biblioteca.ExecutaSQL(SQL);
            Interaction.MsgBox("Alteração do cliente realizada com sucesso!", MsgBoxStyle.Information, "Confirmação");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar salvar a ficha do cliente." + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return;
        }
    }

    private void Monta_SQL()
    {
        string SQL;

        // Monta a SQL com os nomes dos campos (usado na rotina de INCLUSÃO/ALTERAÇÃO)
        SQL = "Nome='" + txtNome.Text + "',";
        SQL += "Endereco=" + Biblioteca.Texto_Vazio(txtEndereco.Text) + ",";
        SQL += "Num=" + Biblioteca.Texto_Vazio(txtNum.Text) + ",";
        SQL += "Bairro=" + Biblioteca.Texto_Vazio(txtBairro.Text) + ",";
        SQL += "Cidade=" + Biblioteca.Texto_Vazio(txtCidade.Text) + ",";
        SQL += "CodMun=" + Biblioteca.Texto_Vazio(txtCodMun.Text) + ",";
        SQL += "Estado=" + Biblioteca.Texto_Vazio(txtEstado.Text) + ",";
        SQL += "Pais=" + Biblioteca.Texto_Vazio(txtPais.Text) + ",";
        SQL += "CodPais=" + Biblioteca.Texto_Vazio(txtCodPais.Text) + ",";
        SQL += "CEP=" + Biblioteca.Texto_Vazio(txtCEP.Text) + ",";
        SQL += "PFPJ='" + Interaction.IIf(rdPF.Checked, "F", "J") + "',";
        SQL += "CPF_CNPJ=" + Biblioteca.Texto_Vazio(txtCNPJ.Text) + ",";
        SQL += "RG_IE=" + Biblioteca.Texto_Vazio(txtIE.Text) + ",";
        SQL += "Fone=" + Biblioteca.Texto_Vazio(txtFone.Text) + ",";
        SQL += "Fax=" + Biblioteca.Texto_Vazio(txtFax.Text) + ",";
        SQL += "Celular=" + Biblioteca.Texto_Vazio(txtCelular.Text) + ",";
        SQL += "email=" + Biblioteca.Texto_Vazio(txtEmail.Text) + ",";
        SQL += "Site=" + Biblioteca.Texto_Vazio(txtSite.Text) + ",";
        SQL += "Observacoes=" + Biblioteca.Texto_Vazio(txtOBS.Text) + ",";
        SQL += "Contrato=" + Biblioteca.Texto_Vazio(txtContrato.Text) + ",";
        SQL += "Produtos=" + Biblioteca.Texto_Vazio(txtProdutos.Text) + ",";
        SQL += "Contato=" + Biblioteca.Texto_Vazio(txtContato.Text);

        return SQL;
    }

    private void Button3_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        Biblioteca.Limpa_Campos(ref this);
        txtPais.Text = "Brasil";
        txtCodPais.Text = "1058";
        txtNome.Focus();
        Button4.Text = "Incluir";
    }

    private void rdPF_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (rdPF.Checked)
            Label9.Text = "CPF:";
        else
            Label9.Text = "CNPJ:";
    }

    private void txtEstado_LostFocus(object sender, System.EventArgs e)
    {
        // Preenche o combobox com o nome dos municipios 
        if (txtEstado.Text.Length == 2)
            Biblioteca.Carrega_Lista(ref txtCidade, "Rais", "Cod", "Municipio", true, "Estado='" + txtEstado.Text + "'");
    }

    private void txtCidade_LostFocus(object sender, System.EventArgs e)
    {
        // Preenche o codigo do municipio
        if (txtCidade.SelectedIndex != -1)
            txtCodMun.Text = Biblioteca.cmbVal(ref txtCidade);
    }

    private void btBuscaCEP_Click(System.Object sender, System.EventArgs e)
    {
        // Muda o cursor
        this.Cursor = Cursors.WaitCursor;
        // Define a estrutura de retorno do endereço
        EnderecoWEB Address = new EnderecoWEB();
        // Busca o endereço pelo CEP
        Biblioteca.Busca_Endereco(txtCEP.Text, ref Address);
        // Preenche os campos com o retorno da função
        txtEndereco.Text = Address.Tipo_Logradouro + " " + Address.Logradouro;
        txtBairro.Text = Address.Bairro;
        txtCidade.Text = Address.Cidade;
        txtEstado.Text = Address.Uf;
        // Retorna o cursos para o modo tradicional
        this.Cursor = Cursors.Arrow;
    }

    private void Button5_Click(System.Object sender, System.EventArgs e)
    {
        frmAux_Clientes_WEB auxForm = new frmAux_Clientes_WEB();
        int varID;
        // Abre a janela auxiliar para escolher o cliente Cadastrado na WEB
        auxForm.ShowDialog();
        // Pega o ID do cliente cadastrado
        varID = auxForm.ClienteID;
        // Se vier algum registro que não for zero
        if (varID != 0)
        {
            Cliente_WEB Cliente = new Cliente_WEB();
            this.Cursor = Cursors.WaitCursor;
            // Procura o cliente pelo ID recebido
            Cliente.Carrega_Dados_Cliente(varID);

            // Procura os dados no banco de dados remoto
            // DT = recupera_dados_cliente_web(varID)
            // se não achou, ou não concluiu a operação
            // If IsNothing(DT) Then
            // Exit Sub
            // End If
            // Caso tenha dado certo, processa o retorno para pegar os dados do cliente
            // Processa_dados_recebidos(DT)
            Preenche_Campos_Dados_Cliente(ref Cliente);
            this.Cursor = Cursors.Arrow;
        }
    }

    private void Preenche_Campos_Dados_Cliente(ref Cliente_WEB Cli)
    {
        {
            var withBlock = Cli;
            txtNome.Text = withBlock.Nome + " " + withBlock.Sobrenome;
            txtEndereco.Text = withBlock.Endereco;
            txtBairro.Text = withBlock.Bairro;
            txtCEP.Text = withBlock.CEP;
            txtEstado.Text = withBlock.Estado;
            txtCidade.Text = withBlock.Cidade;
            txtCNPJ.Text = withBlock.CPF_CNPJ;
            // Verifica se é pessoa física ou jurídica
            Interaction.IIf(txtCNPJ.Text.Length > 9, rdPJ.Checked == true, rdPF.Checked == true);
            txtIE.Text = withBlock.RG_IE;
            txtFone.Text = withBlock.Telefone;
            txtFax.Text = withBlock.Fax;
            txtEmail.Text = withBlock.Email;
            txtContato.Text = withBlock.Nome;
        }
    }

    private DataTable recupera_dados_cliente_web(object id)
    {
        DataTable DT;
        string SQL;
        // Monta a SQL de recuperação
        SQL = "SELECT name,value FROM vtex_facileforms_subrecords WHERE Record=" + id;
        // Mostra na tela de Debug
        Console.WriteLine("SQL Cliente WEB: " + SQL);
        // Tenta recuperar a linha na forma de DataTable
        if (Constantes.Conectado)
        {
            try
            {
                // Tenta fazer a conexao com o banco de dados remoto
                this.Cursor = Cursors.WaitCursor;
                DT = Biblioteca.SQLQuery(SQL, true);
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar se comunicar com o banco de dados remoto." + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly);
                this.Cursor = Cursors.Arrow;
                return null;
            }
        }
        else
            return null;
        return DT;
    }

    private void Processa_dados_recebidos(ref DataTable Tabela)
    {
        DataRow DR;
        // Para cada linha de dados em Tabela (DT) processar
        foreach (var DR in Tabela.Rows)
        {
            // Pega o nome do campo e verifica onde vai colocar
            switch (DR.Item["name"])
            {
                case "txtNome":
                    {
                        // Essa função faz com que a primeira letra de cada palavra seja Maiuscula e o resto minuscula
                        txtNome.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtEndereco":
                    {
                        txtEndereco.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtNumero":
                    {
                        txtNum.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtBairro":
                    {
                        txtBairro.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtCEP":
                    {
                        txtCEP.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtCidade":
                    {
                        txtCidade.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtEstado":
                    {
                        txtEstado.Text = Biblioteca.NaoNulo(DR.Item["value"]).ToUpper();
                        break;
                    }

                case "txtPais":
                    {
                        txtPais.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtCPFCNPJ":
                    {
                        txtCNPJ.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtIE":
                    {
                        txtIE.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtPessoa":
                    {
                        txtContato.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Biblioteca.NaoNulo(DR.Item["value"]));
                        break;
                    }

                case "txtFone":
                    {
                        txtFone.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtFax":
                    {
                        txtFax.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtCelular":
                    {
                        txtCelular.Text = Biblioteca.NaoNulo(DR.Item["value"]);
                        break;
                    }

                case "txtEmail":
                    {
                        txtEmail.Text = Biblioteca.NaoNulo(DR.Item["value"]).ToLower();
                        break;
                    }
            }
        }
    }
}
