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
using MailKit.Net.Pop3;
using MimeKit;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;

namespace SisControl.NET
{
    public partial class aux_Processa_Email
    {
        public frmReservas frmPai;

        private string varLogin = "comercial@clona-gen.com.br";
        private string varPass = "clona@2018";

        private struct InfoEmail
        {
            public string Nome;
            public string Fone;
            public string Email;
            public string Data;
            public List<string> Variedades;
            // Cria uma estrutura já com o nome
            public InfoEmail(string vNome)
            {
                Nome = vNome;
                Variedades = new List<string>();
            }
            public void Clear()
            {
                Nome = string.Empty;
                Fone = string.Empty;
                Email = string.Empty;
                Data = string.Empty;
                Variedades.Clear();
            }
        }

        private int Altura_Cond = 262;
        private int Altura_Expa = 455;

        private InfoEmail Atual = new InfoEmail(".");

        public aux_Processa_Email(ref frmReservas Pai)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            frmPai = Pai;
        }

        private void msg(string texto)
        {
            tsMsg.Text = texto;
            ssStatus.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Pop3Client client = new Pop3Client();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                msg("Conectando ao servidor...");
                client.Connect("uscentral30.myserverhosts.com", 995, true);
                // Note: since we don't have an OAuth2 token, disable the XOAUTH2 authentication mechanism.
                // client.AuthenticationMechanisms.Remove("XOAUTH2")
                msg("Autenticando...");
                client.Authenticate(varLogin, varPass);
                msg("Conectado ao servidor de e-mail");
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao conectar com servidor de e-mail" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
                return;
            }

            msg("Verificando mensagens...");
            msg("O servidor possui: " + client.Count + " mensagens");

            if (client.Count == 0)
            {
                Interaction.MsgBox("Não há e-mail a serem recuperados.", MsgBoxStyle.OkOnly, "Aviso");
                client.Disconnect(true);
                return;
            }

            msg("Processando mensagens...");
            tsProgress.Minimum = 0;
            tsProgress.Maximum = client.Count - 1;

            for (int i = 0; i <= client.Count - 1; i++)
            {
                // Atualiza a barra de progresso
                tsProgress.Value = i;
                ssStatus.Refresh();
                MimeMessage Mensagem = client.GetMessage(i);
                lstEmails.Items.Add(Mensagem.Subject);
                msg("Processando mensagem " + i + 1 + " de " + client.Count - 1);
            }
            tsProgress.Value = 0;
            msg("Desconectando...");
            client.Disconnect(true);
            msg("...");
        }
        private void Processa_Anexo(MimeMessage mensagem, ref InfoEmail inf)
        {
            foreach (MimePart anexo in mensagem.Attachments)
                anexo.WriteTo(@"d:\" + anexo.FileName);
        }


        private void Processa_Email(MimeMessage Mensagem, ref InfoEmail Info)
        {
            string varNome = "";
            string varEmail = "";
            string varFone = "";
            string varVariedades = "";
            string varData = Mensagem.Date.ToString("yyyy-MM-dd");
            string varFrom = Mensagem.From.ToString();
            string varMensagem = Mensagem.HtmlBody;

            // ## Define a Data da Reserva
            txtData.Text = varData;

            // ## Extração do Nome/Telefone
            string padraoRegex = @"(?:Nome:<\/b>)(.*?)(?:<br>)";
            Regex rgNome = new Regex(padraoRegex);
            // variavel boolean para tratar o status
            MatchCollection Matches = rgNome.Matches(varMensagem);
            // Se encontrou pelo menos um
            if (Matches.Count > 0)
            {
                // ## Extração do Nome
                // Dentro do Match o Grupo 1 (do meio) dos caracteres separados
                varNome = Matches.Item[0].Groups[1].Value;
                // Remove o espaço em branco do primeiro caractere
                varNome = varNome.Remove(0, 1);
                txtNome.Text = varNome;
                Info.Nome = varNome;
            }

            // ## Extração do Telefone
            padraoRegex = @"(?:Telefone:<\/b>)(.*?)(?:<\/p>)";
            Regex rgFone = new Regex(padraoRegex);
            Matches = rgFone.Matches(varMensagem);
            // Se encontrou pelo menos um
            if (Matches.Count > 0)
            {
                // Dentro do Match o Grupo 1 (do meio) dos caracteres separados
                varFone = Matches.Item[0].Groups[1].Value;
                varFone = varFone.Remove(0, 1);
                txtFone.Text = varFone;
                Info.Fone = varFone;
            }

            // ## Extração E-Mail
            padraoRegex = @"[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})";
            Regex rgEmail = new Regex(padraoRegex);
            Matches = rgEmail.Matches(varMensagem);
            // Se encontrou pelo menos um
            if (Matches.Count > 0)
            {
                varEmail = Matches.Item[0].Value;
                txtEmail.Text = varEmail;
                Info.Email = varEmail;
            }

            // ## Extração das variedades
            padraoRegex = @"(mandioca-brs-)(\d\d\d)";
            Regex rgVariedades = new Regex(padraoRegex);
            Matches = rgVariedades.Matches(varMensagem);
            // Se encontrou pelo menos um
            if (Matches.Count > 0)
            {
                foreach (Match varBRS in Matches)
                {
                    lblVariedades.Text += (varBRS.Groups[2].Value + ";");
                    Info.Variedades.Add(new string(varBRS.Groups[2].Value.ToString()));
                }
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            // Pega o íten selecionado
            int n = lstEmails.SelectedIndex;

            // Dimensiona a conexão pop3
            Pop3Client client = new Pop3Client();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                msg("Conectando ao servidor...");
                client.Connect("uscentral30.myserverhosts.com", 995, true);
                msg("Autenticando...");
                client.Authenticate(varLogin, varPass);
                msg("Conectado ao servidor de e-mail");
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao conectar com servidor de e-mail" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
                return;
            }
            // Depois de ter conseguido conectar pega a mensagem específica
            MimeMessage Mensagem = client.GetMessage(n);

            lblVariedades.Text = "";
            // Envia a mensagem inteira como referência e recebe de volta por valor o atual preenchido
            // Processa_Email(Mensagem, Atual)
            Processa_Anexo(Mensagem, ref Atual);
            // aumenta o form

            this.Size = new System.Drawing.Size(390, Altura_Expa);
            // Desconecta do provedor
            client.Disconnect(true);
        }

        private void aux_Processa_Email_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(390, Altura_Cond);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string SQL_Reserva;
            string SQL_Itens;
            int id = -1;

            // Pega o próximo ID do Auto_Increment da tabela
            id = Biblioteca.DNextID("reservas");

            // Com as informações no objeto e-mail é possível criar as duas SQL
            // Monta a SQL de inclusão da Reserva
            SQL_Reserva = "INSERT INTO reservas SET ";
            SQL_Reserva += "id=" + id + ",";
            SQL_Reserva += "Data='" + txtData.Text + "',";
            SQL_Reserva += "Nome='" + txtNome.Text + "',";
            SQL_Reserva += "Fone=" + Biblioteca.Texto_Vazio(txtFone.Text) + ",";
            SQL_Reserva += "Email=" + Biblioteca.Texto_Vazio(txtEmail.Text) + ",";
            SQL_Reserva += "Atendido=0";
            int Mercadoria;
            int Clone;
            string Descricao;

            // Define a mercadoria = Mandioca
            Mercadoria = 45;

            SQL_Itens = "INSERT INTO reservas_itens (Doc_Id,Mercadoria,Clone,Descricao,Quantidade,Forma,Preco) VALUES ";
            for (int i = 0; i <= Atual.Variedades.Count - 1; i++)
            {
                // Se for a segunda vez que passa aqui cria a lista.
                if (i > 0)
                    SQL_Itens += ",";
                // Preenche as variáveis auxiliares
                Clone = Atual.Variedades[i];
                Descricao = Biblioteca.DLookup("Cientifico", "Mercadoria", "id=" + Mercadoria) + " cv. " + Biblioteca.DLookup("Nome", "Clones", "Mercadoria=" + Mercadoria + " AND Clone=" + Clone);
                // Monta a SQL de inclusão
                SQL_Itens += "(" + id + ",";
                SQL_Itens += Mercadoria + ",";
                SQL_Itens += Clone + ",";
                SQL_Itens += "'" + Descricao + "',";
                SQL_Itens += txtQtdePadrao.Text + ",";
                SQL_Itens += "'Muda Aclimatizada',";
                SQL_Itens += Biblioteca.Numero_to_SQL(txtValor.Text) + ")";
            }

            Console.WriteLine(SQL_Reserva);
            Console.WriteLine(SQL_Itens);

            // Monta um Array de SQLs para fazer o lote em transação (ou tudo ou nada
            string[] SQL_Transacao = new string[2];
            // Atribui as duas SQLs na transação
            SQL_Transacao[0] = SQL_Reserva;
            SQL_Transacao[1] = SQL_Itens;
            // Tenta executar a transação
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // tenta executar a transação SQL
                if (Biblioteca.SQLTransacao(SQL_Transacao))
                {
                    Interaction.MsgBox("A reserva e seus ítens foram incluídos com sucesso!", MsgBoxStyle.OkOnly, "Confirmação");
                    msg("Enviando e-mail para o cliente...");
                    if (chkEmail.Checked)
                        Envia_Email();
                    this.Cursor = Cursors.Arrow;
                    this.Size = new System.Drawing.Size(390, Altura_Cond);
                    Atual.Clear();
                    msg("...");
                }
                else
                {
                    Interaction.MsgBox("Erro desconhecido ao incluir a reserva ou seus ítens", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Erro");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao incluir a reserva ou seus ítens" + Constants.vbCrLf + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Erro");
                this.Cursor = Cursors.Arrow;
                return;
            }
        }

        private void limpa_campos()
        {
            txtNome.Text = string.Empty;
            txtData.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtQtdePadrao.Text = "20";
            txtValor.Text = "2,00";
        }

        private void Envia_Email()
        {
            Email eml = new Email();

            if (txtEmail.Text == string.Empty)
            {
                Interaction.MsgBox("Não é possível enviar e-mail pois o campo não foi preenchido", MsgBoxStyle.OkOnly, "Aviso");
                return;
            }

            // Dimensiona variáveis usadas no cabeçalho do e-mail
            string mlBody = string.Empty;

            mlBody = Gera_Body();

            // Preenche os dados de envio
            Email.enviaMensagemEmail(Constantes.E_MailFrom, txtEmail.Text, "", "alexandre@clona-gen.com.br", "[Clona-Gen] Interessado em mudas de Mandioca", mlBody, Constantes.E_MailServer);
        }

        private string Gera_Body()
        {
            string Body = string.Empty;
            string strModeloPath = My.Application.Info.DirectoryPath + @"\modelos\confirmacao_reserva.html";

            var varPrimeiroNome = txtNome.Text.Substring(0, txtNome.Text.IndexOf(" "));
            var varSaudacao = Interaction.IIf(DateTime.Now.TimeOfDay.Hours > 12, "Boa tarde", "Bom dia");
            var varVariedades = string.Empty;

            for (int i = 0; i <= Atual.Variedades.Count - 1; i++)
            {
                if (i > 0)
                {
                    // Se for o último boa "E"
                    if (i == Atual.Variedades.Count - 1)
                        varVariedades += " e ";
                    else
                        varVariedades += ", ";
                }
                varVariedades += "BRS-" + Atual.Variedades[i];
            }

            // Carrega arquivo de modelo de e-mail
            // Lê o arquivo de modelo
            Body = File.ReadAllText(strModeloPath);
            // Define os campos que serão substituidos no modelo
            string[] Campos = new[] { "[Primeiro_Nome]", "[Saudacao]", "[variedades]" };
            // Cria um array com todas as informações coletadas
            string[] Valores = new[] { varPrimeiroNome, varSaudacao, varVariedades };

            // Substitui os campos do HTML gerando o corpo do e-mail
            for (int i = 0; i <= Campos.Length - 1; i++)
                Body = Body.Replace(Campos[i], Valores[i]);
            // Retorna 
            return Body;
        }

        private void aux_Processa_Email_Closing(object sender, CancelEventArgs e)
        {
            frmPai.DataGridRefresh();
        }
    }
}
