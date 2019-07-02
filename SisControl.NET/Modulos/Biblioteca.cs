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
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.ComponentModel;


static class Constantes
{
    // Definição ds constantes do programa

    public static System.Drawing.Color Cor_Digitada = Color.White;
    public static System.Drawing.Color Cor_Gerada = Color.Yellow;
    public static System.Drawing.Color Cor_Transmitida = Color.LimeGreen;
    public static System.Drawing.Color Cor_Danfe = Color.DodgerBlue;
    public static System.Drawing.Color Cor_Cancelada = Color.Crimson;
    public static System.Drawing.Color Cor_Inutilizada = Color.DarkKhaki;

    public static bool Conectado = true;      // False = Desconectado   True = Conectado

    // Códigos dos lancamentos contábeis
    public const static int CTB_AVISTA_CAIXA_D = 259;
    public const static int CTB_AVISTA_CAIXA_C = 602;

    public const static int CTB_AVISTA_BANCO_D = 259;
    public const static int CTB_AVISTA_BANCO_C = 33;

    public const static int CTB_APRAZO_CAIXA_D = 311;
    public const static int CTB_APRAZO_CAIXA_C = 602;

    public const static int CTB_APRAZO_BANCO_D = 311;
    public const static int CTB_APRAZO_BANCO_C = 33;

    public const static int CTB_APRAZO_MES_D = 260;
    public const static int CTB_APRAZO_MES_C = 311;

    public const static string E_CNPJ = "07727715000190";
    public const static string E_RAZAO = "CLONA-GEN Comercio de Mudas de Plantas Ltda.";
    public const static string E_IE = "255097050";
    public const static string E_ENDERECO = "Rua Ottokar Doerffel";
    public const static string E_NUM = "534";
    public const static string E_BAIRRO = "Atiradores";
    public const static string E_CIDADE = "Joinville";
    public const static string E_UF = "SC";
    public const static string E_CEP = "89203001";
    public const static string E_FONE = "04734396607";

    public const static string E_MailServer = "mail.clona-gen.com.br";
    public const static string E_MailUser = "comercial@clona-gen.com.br";
    public const static string E_MailPass = "16240423";
    public const static string E_MailFrom = "CLONA-GEN Comercial<comercial@clona-gen.com.br>";
    public const static int E_MailPort = 25;
    public const static bool E_EnableSsl = false;

    public static Usuario User = new Usuario();

    public static int MY_TIMEOUT = 20;

    public static string myIP = "10.1.1.254";

    // *
    // * CONCENTRAÇÕES PADRONIZADAS DOS HORMONIOS (mg/ml)
    // *

    public static decimal MGL_BAP = 1;   // BAP
    public static decimal MGL_24D = 0.5; // 2,4D
    public static decimal MGL_KIN = 1;   // KIN
    public static decimal MGL_AIB = 1;   // AIB
    public static decimal MGL_ANA = 1;   // ANA
    public static decimal MGL_AIA = 1;   // AIA
    public static decimal MGL_ABA = 0.5; // ABA
    public static decimal MGL_TDZ = 0.5; // TDZ
    public static decimal MGL_GA3 = 0.5; // GA3
    public static decimal MGL_2IP = 0.5; // 2iP
}

static class Generico
{

    // **********************************************************************************
    // *  Modulo genérico que é utilizado tanto pelo ervido de de código de barras      *
    // *  quanto pela recuperação de frascos                                            *
    // **********************************************************************************

    // ** São várias funções para isso e por isso estão em módulo

    public static int Adiciona_Frasco(ref DataGridView dgFrascos, ref DataSet dsFrascos, ref TextBox txtCodigoBarras, ref ComboBox cmbMotivo, ref Label txtTotal)
    {
        object CodVidro;
        object CodLote = null;
        int codMER, codLOT, codCLON, codFRA, Mudas;
        bool flagPresente = false;

        // Se não houver codigo de barras então sair
        if (Strings.Len(txtCodigoBarras.Text) < 1)
            return;

        // Resolver o problema dos números irem parar no combo de motivo
        // Se for detectados números nas primeiras posções do combo
        if (char.IsDigit(Strings.Mid(cmbMotivo.Text, 1, 3)))
        {
            Interaction.MsgBox("Erro de código de barras ou motivo" + Constants.vbCrLf + "Passe o último frasco novamente", MsgBoxStyle.Critical, "Erro");
            // Zera as opções novamente
            txtCodigoBarras.Text = string.Empty;
            cmbMotivo.Text = "Fungo";
            txtCodigoBarras.Focus();
            // Sai da funcao sem fazer nada
            return;
        }

        // Se o tamanho do código não bater sai para não dar erro
        if (Strings.Len(txtCodigoBarras.Text) < 12)
        {
            Interaction.MsgBox("Código de barras incorreto!" + Constants.vbCrLf + " Verificar!", Constants.vbOKOnly + Constants.vbExclamation, "AVISO");
            goto Fim;
            return;
        }

        // Ajusta para ler os dois padrões de código de barras
        if (txtCodigoBarras.Text.Length == 14)
        {
            // Separa o lote em partes
            // 0001112222333
            codMER = Conversion.Val(txtCodigoBarras.Text.Substring(1, 3)).ToString();
            codLOT = Conversion.Val(txtCodigoBarras.Text.Substring(4, 3)).ToString();
            codCLON = Conversion.Val(txtCodigoBarras.Text.Substring(7, 4)).ToString();
            codFRA = Conversion.Val(txtCodigoBarras.Text.Substring(11, 3)).ToString();
        }
        else if (txtCodigoBarras.Text.Length == 13)
        {
            // Separa o lote em partes
            // 0001112222333
            codMER = Conversion.Val(txtCodigoBarras.Text.Substring(0, 3)).ToString();
            codLOT = Conversion.Val(txtCodigoBarras.Text.Substring(3, 3)).ToString();
            codCLON = Conversion.Val(txtCodigoBarras.Text.Substring(6, 4)).ToString();
            codFRA = Conversion.Val(txtCodigoBarras.Text.Substring(10, 3)).ToString();
        }
        else if (txtCodigoBarras.Text.Length == 12)
        {
            // Separa o lote em partes
            // 001112222333
            codMER = Conversion.Val(txtCodigoBarras.Text.Substring(0, 2)).ToString();
            codLOT = Conversion.Val(txtCodigoBarras.Text.Substring(2, 3)).ToString();
            codCLON = Conversion.Val(txtCodigoBarras.Text.Substring(5, 4)).ToString();
            codFRA = Conversion.Val(txtCodigoBarras.Text.Substring(9, 3)).ToString();
        }

        // Debug
        // MsgBox("Comp" & txtCodigoBarras.Text.Length & vbCrLf & codMER & " " & codLOT & " " & codCLON & " " & codFRA)

        // Zera o código do lote 
        CodLote = null;

        // Localizar o lote - Se achar retorno o ID senão retorna NULL
        CodLote = Biblioteca.DLookup("id", "Lotes", "(Mercadoria=" + codMER + ") AND (Lote=" + codLOT + ") AND (Clone=" + codCLON + ") AND (ativo=1)");

        // Se for NULL é porque não achou
        if (Information.IsNothing(CodLote) | CodLote == string.Empty | Information.IsDBNull(CodLote))
        {
            Interaction.MsgBox("Lote não encontrado!", Constants.vbExclamation, "AVISO");
            CodLote = -1;
            goto Fim;
        }

        // Se encontrou o lote agora procura o frasco
        // Pegar os identificadores do vidro
        // Se achar retorno o ID senão retorna NULL
        CodVidro = Biblioteca.DLookup("id", "Aux_Frascos", "(Lote=" + CodLote + ") AND (Vidro=" + codFRA + ") AND (ISNULL(bxExclusao))");
        // Se for NULL é porque não achou
        if (Information.IsNothing(CodVidro) | CodVidro == string.Empty | Information.IsDBNull(CodVidro))
        {
            Interaction.MsgBox("Frasco não encontrado!", Constants.vbExclamation, "AVISO");
            CodLote = -1;
            goto Fim;
        }
        // Com o parametro especificado
        {
            var withBlock = dgFrascos;
            // Procura pelo frasco existente
            for (int i = 0; i <= withBlock.RowCount - 1; i++)
            {
                // se achar o id coincidente
                if (withBlock.Rows[i].Cells[6].Value == CodVidro)
                {
                    Interaction.MsgBox("Este frasco já está na lista!", Constants.vbExclamation, "AVISO");
                    goto Fim;
                }
            }
        }

        // Se achou o vidro agora pega o número de mudas
        Mudas = Biblioteca.DLookup("NMudas", "Aux_Frascos", "ID=" + CodVidro);

        // Verifica se o frasco que está vindo faz parte desse lote
        // If dgFrascos.RowCount > 0 Then
        // 'Pode pegar o que está na primeira linha mesmo (Todo tem que ser iguais)
        // If CodLote <> dgFrascos.Rows(0).Cells(7).Value Then
        // MsgBox("O frasco que você está tentando adicionar não faz parte deste lote" & Chr(13) & Chr(13) & "Passe todos os frascos do mesmo lote" & Chr(13) & Chr(13) & "Quando terminar clique em CONFIRMAR para então passar outro lote", vbInformation, "AVISO")
        // GoTo Fim
        // End If
        // End If

        // inclui a linha no DATA SET e por consequencia no datagrid
        dsFrascos.Tables[0].Rows.Add(codMER, codLOT, codCLON, codFRA, Mudas, cmbMotivo.Text.Substring(0, 1), CodVidro, CodLote);
        // Conta o número de frascos
        txtTotal.Text = dsFrascos.Tables[0].Rows.Count;
    Fim:
        ;
        txtCodigoBarras.Text = null;
        txtCodigoBarras.Focus();
        // Se não localizar ou não achar retorna Nothing
        return CodLote;
    }

    public static bool Baixa_Frascos(ref DataGridView dgFrascos, ref DataSet dsFrascos, ref MaskedTextBox txtData, int Operador)
    {
        float Plantio;
        float Repicagem;
        float Fungo;
        float Bacteria;
        float Oxidacao;
        float Mudas;

        // Dim SQL As String, Tabela As Variant, CodLote As Single, CodVidro As Single, Mudas As Single
        float Contaminacao;
        float QtF;
        float QtB;
        float QtO;
        float QtP;
        float QtR;
        float Num;
        string SQL;
        string lote_atual = "";
        string Motivo;
        int LoteOLD = 0;
        int Frascos;
        string SQLExclusao;

        // Conta quantas entradas tem
        Num = dgFrascos.RowCount;

        if (Num <= 0)
        {
            Interaction.MsgBox("Não há elementos na lista para serem processados", Constants.vbOKCancel + Constants.vbCritical, "Erro");
            return false;
            return;
        }

        // monta o resumo
        Fungo = 0;
        Bacteria = 0;
        Oxidacao = 0;
        Plantio = 0;
        Repicagem = 0;
        Contaminacao = 0;
        Frascos = 0;
        Mudas = 0;

        LoteOLD = 0;
        SQLExclusao = string.Empty;

        // Organiza as entradas por código do lote
        dgFrascos.Sort(dgFrascos.Columns[7], System.ComponentModel.ListSortDirection.Ascending);

        for (int i = 0; i <= Num - 1; i++)
        {
            // Lote anterior no primeiro caso é o primeiro lote
            if (i == 0)
                LoteOLD = dgFrascos.Rows[i].Cells[7].Value;
            {
                var withBlock = dgFrascos.Rows[i];
                // se Vai trocar o lote, antes tem que processar o lote anterior
                if (withBlock.Cells[7].Value == LoteOLD)
                {
                    // Usa a funcao desenvolvida para fazer o resumo
                    Motivo = withBlock.Cells[5].Value.ToString();
                    Soma_lotes(ref dgFrascos, i, Motivo, ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref Contaminacao, ref Mudas, ref Frascos, ref QtF, ref QtB, ref QtO, ref QtP, ref QtR);
                    // Acrescenta na lista de ID a serem excluidos
                    if (SQLExclusao == string.Empty)
                        // Se for a primeira vez que passa aqui
                        SQLExclusao = dgFrascos.Rows[i].Cells[6].Value.ToString();
                    else
                        // Se for segunda já coloca a virgula
                        SQLExclusao += "," + dgFrascos.Rows[i].Cells[6].Value.ToString();
                }
                else
                {
                    // Se o lote atual for diferente do anterior
                    // Processa os frascos do lote
                    if (!Aux_Processa_Frasco(ref dgFrascos, LoteOLD, ref Contaminacao, ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref Frascos, ref Mudas, ref QtP, ref QtR, txtData.Text))
                        return;
                    // Reinicia as variáveis
                    Fungo = 0;
                    Bacteria = 0;
                    Oxidacao = 0;
                    Plantio = 0;
                    Repicagem = 0;
                    Contaminacao = 0;
                    Frascos = 0;
                    Mudas = 0;
                    QtF = 0;
                    QtB = 0;
                    QtO = 0;
                    QtP = 0;
                    QtR = 0;
                    // Zera a SQL de exclusão e começa com o valor da linha atual
                    SQLExclusao = dgFrascos.Rows[i].Cells[6].Value.ToString();
                    // Soma o lote atual
                    Motivo = withBlock.Cells[5].Value.ToString();
                    Soma_lotes(ref dgFrascos, i, Motivo, ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref Contaminacao, ref Mudas, ref Frascos, ref QtF, ref QtB, ref QtO, ref QtP, ref QtR);
                    // Lote atual fica sendo o loteOLD
                    LoteOLD = withBlock.Cells[7].Value;
                }
                if (i == Num - 1)
                {
                    // Processa os frascos do lote
                    if (!Aux_Processa_Frasco(ref dgFrascos, LoteOLD, ref Contaminacao, ref Fungo, ref Bacteria, ref Oxidacao, ref Plantio, ref Repicagem, ref Frascos, ref Mudas, ref QtP, ref QtR, txtData.Text))
                        return;
                }
            }
        }

        // Agora por ultimo tem que apagar os frascos
        // Todo servico esta acabado

        // SQL = "DELETE FROM Aux_Frascos WHERE id IN("
        SQL = "UPDATE aux_frascos SET bxExclusao=CURRENT_TIMESTAMP, bxOperador=" + Operador + " WHERE id IN(";
        for (int i = 0; i <= Num - 1; i++)
        {
            {
                var withBlock = dgFrascos.Rows[i];
                // Se for o primeiro valor
                if (i == 0)
                    // Monta a SQL
                    SQL = SQL + withBlock.Cells[6].Value.ToString();
                else
                    SQL = SQL + "," + withBlock.Cells[6].Value.ToString();
            }
        }
        // Finaliza a SQL
        SQL = SQL + ")";
        // Tenta excluir
        try
        {
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar excluir os frascos !" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), Constants.vbCritical);
            return false;
            return;
        }
        // Tudo acabado pode-se limpar o listview para a proxima etapa
        dsFrascos.Tables[0].Clear();
    Fim:
        ;
        return true;
    }

    private static void Soma_lotes(ref object dgFrascos, int Linha, string Motivo, ref int Fungo, ref int Bacteria, ref int Oxidacao, ref int Plantio, ref int Repicagem, ref int Contaminacao, ref int Mudas, ref int Frascos, ref int QtF, ref int QtB, ref int QtO, ref int QtP, ref int QtR)
    {
        switch (Motivo)     // Motivo
        {
            case "F":
                {
                    Fungo = Fungo + dgFrascos.Rows(Linha).Cells(4).Value;
                    QtF = QtF + 1; // Vai contando quantos frascos em cada motivo
                    break;
                }

            case "B":
                {
                    Bacteria = Bacteria + dgFrascos.Rows(Linha).Cells(4).Value;
                    QtB = QtB + 1;
                    break;
                }

            case "O":
                {
                    Oxidacao = Oxidacao + dgFrascos.Rows(Linha).Cells(4).Value;
                    QtO = QtO + 1;
                    break;
                }

            case "P":
                {
                    Plantio = Plantio + dgFrascos.Rows(Linha).Cells(4).Value;
                    QtP = QtP + 1;
                    break;
                }

            case "R":
                {
                    Repicagem = Repicagem + dgFrascos.Rows(Linha).Cells(4).Value;
                    QtR = QtR + 1;
                    break;
                }
        }
        Contaminacao = Fungo + Bacteria + Oxidacao;
        Mudas = Mudas + dgFrascos.Rows(Linha).Cells(4).Value;
        Frascos += 1;
    }

    public static bool Aux_Processa_Frasco(ref object dgfrascos, int Lote_ID, ref int Contaminacao, ref int Fungo, ref int Bacteria, ref int Oxidacao, ref int Plantio, ref int Repicagem, ref int Frascos, ref int Mudas, ref int QtP, ref int QtR, string Data)
    {
        string SQL;
        string Lote_atual;
        // Atualiza o estoque da tabela dos lotes
        // Monta a SQL
        SQL = "UPDATE Lotes SET Contaminacao=Contaminacao+" + Contaminacao + ", Fungo=Fungo+" + Fungo + ",Bacteria=Bacteria+" + Bacteria + ",Oxidacao=Oxidacao+" + Oxidacao + ",Est_Frascos=Est_Frascos-" + Frascos + ", Estoque=Estoque-" + Mudas + " WHERE Id=" + Lote_ID;
        // Executa a SQL
        try
        {
            // Tenta executar a operação
            Biblioteca.ExecutaSQL(SQL);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao atualizar o Estoque/Contaminação no banco de dados!" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
            return false;
        }

        // Pega o código textual do lote selecionado em cmbLote
        Lote_atual = Biblioteca.Procura_Lote(Lote_ID);

        // Registra o plantio e a repicagem no histórico
        SQL = "INSERT INTO Historico (lote,data,Descricao,retirada,frascos) VALUES ";
        SQL += "(" + Lote_ID + ",";
        SQL += "'" + Strings.Format((DateTime)Data, "yyyy-MM-dd") + "',";
        // Faz uma SQL por motivo
        if (Plantio > 0)
        {
            string SQLpl;
            SQLpl = SQL + "'Plantio do lote " + Lote_atual + "',";
            SQLpl += Plantio + ",";
            SQLpl += QtP + ")";
            try
            {
                Biblioteca.ExecutaSQL(SQLpl);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro na inclusão dos dados de plantio no histórico" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
                return false;
            }
        }
        if (Repicagem > 0)
        {
            string SQLre;
            SQLre = SQL + "'Repicagem do lote " + Lote_atual + "',";
            SQLre += Repicagem + ",";
            SQLre += QtR + ")";
            try
            {
                Biblioteca.ExecutaSQL(SQLre);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro na inclusão dos dados de repicagem no histórico" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
                return false;
            }
        }

        // Pega o estoque atual e ve se é zero
        int tmpEstoque = 0;

        tmpEstoque = Biblioteca.DLookup("Estoque", "Lotes", "id=" + Lote_ID);
        // Verifica se o estoque atual é zero ou negativo
        if (tmpEstoque <= 0)
        {
            // Verifica se o usuário deseja que o lote seja inativado em função disso
            int a;
            a = Interaction.MsgBox("Lote atual com estoque menor ou igual a ZERO (" + tmpEstoque.ToString() + ")" + Strings.Chr(13) + "Deseja desativar o lote " + Lote_atual + "?", Constants.vbYesNo + Constants.vbQuestion, "Aviso");
            // Em caso positivo cria a rotina para desativar o lote
            if (a == Constants.vbYes)
            {
                // Monta a SQL para desativar
                SQL = "UPDATE Lotes SET Ativo=0, estoque=0 ,est_frascos=0,inativado=CURRENT_TIMESTAMP WHERE Id=" + Lote_ID;
                // Executa a ação
                try
                {
                    Biblioteca.ExecutaSQL(SQL);
                    // Para garantir se o lote for desativado então apagar todos os frascos daquele lote
                    // So pode aqui em baixo porque vai precisar dos frascos antes para fazer os relatorios
                    // Monta a SQL para excluir todos os frascos
                    SQL = "UPDATE Aux_Frascos SET bxExclusao=CURRENT_TIMESTAMP WHERE Lote=" + Lote_ID;
                    // Executa a SQL
                    Biblioteca.ExecutaSQL(SQL);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Erro ao tentar inativar o lote ou apagar seus frascos: " + Lote_atual + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), Constants.vbCritical);
                    return false;
                }
            }
        }
        // Zera as variáveis novamente
        Fungo = 0;
        Bacteria = 0;
        Oxidacao = 0;
        Plantio = 0;
        Repicagem = 0;
        Contaminacao = 0;
        Frascos = 0;
        Mudas = 0;
        return true;
    }
}

static class Biblioteca
{
    // Declara a variavel global de conexao com MySQL
    internal static string IP_SQL_CONNECTION = "10.1.1.254";
    internal static string IP_SQL_CONNECTION_WEB = "187.59.80.163";
    internal static string MY_SQL_CONNECTION = null;
    internal static string MY_SQL_CONNECTION_WEB = null;
    internal static string DS_MYSQL_CONNECTION = null;

    // Declara variável Global
    internal static string GENERALID;
    // Variáveis utilizadas na impressão
    public static IntPtr PTR1 = default(IntPtr);
    public static System.IO.FileStream wFILE = null;
    public static string Porta = "LPT1";

    // Declara as constantes que serão usadas na Função Createfile
    const static var GENERIC_READ = 0x80000000;
    const static var GENERIC_WRITE = 0x40000000;
    const static var OPEN_EXISTING = 3;
    const static var FILE_SHARE_READ = 0x1;
    const static var FILE_SHARE_WRITE = 0x2;
    const static var FILE_ATTRIBUTE_NORMAL = 0x80;
    const static var FILE_FLAG_NO_BUFFERING = 0x20000000;

    // Declara uma função da própria API do Windows para poder acessar a lpt1
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

    // Troca o enter pelo tab em controles do tipo textbox
    public static void MoverFoco(Form formulario, object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // Verifica a tecla pressionada e obtem o proximo controle ou o anterior, dependendo da tecla pressionada
        if (e.KeyCode == Keys.Enter)
        {
            if (!formulario.GetNextControl(sender, true) == null)
                formulario.GetNextControl(sender, true).Focus();
        }
    }

    public static T NotNull<T>(T Value, T DefaultValue)
    {
        if (value == null || Information.IsDBNull(value))
            return DefaultValue;
        else
            return value;
    }

    // Preenche um listbox ou um combobox com valores
    public static void Carrega_Lista(ref object Lista, string Tabela, string Dados, string Items, bool Indexado = false, string Criterio = "", bool WEB = false)
    {

        // Se não estiver conectado já sai
        if (!Constantes.Conectado)
            return;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        string SQL;
        // Define a conexao
        conn = new MySqlConnection();
        // Se não for passado ou se for false (usa Conexão local)
        if ((WEB == default(Boolean)) | (WEB == false))
            // Usa a string de conexao atribuida na primeira janela
            conn.ConnectionString = MY_SQL_CONNECTION;
        else
            conn.ConnectionString = MY_SQL_CONNECTION_WEB;
        // Monta a SQL com os parametros
        SQL = "SELECT " + Dados + "," + Items + " FROM " + Tabela;
        // Se houver critério informado então usa
        if (Strings.Len(Criterio))
            SQL = SQL + " WHERE " + Criterio;
        if (Indexado)
            // Organiza os dados
            SQL = SQL + " ORDER BY " + Items;

        Console.WriteLine("Carrega_Lista: " + SQL);

        // Tenta conectar e ver se dá erro
        try
        {
            conn.Open();
            // Se abriu, Executa os comandos
            // Define quem é a conexao ativa
            myCommand.Connection = conn;
            // Qual a SQL a ser usada
            myCommand.CommandText = SQL;
            // Monta o data reader
            MySqlDataReader dr = myCommand.ExecuteReader();
            // Define que a string vai ser o resultado
            string str = dr.ToString();
            // Limpa a lista primeiro
            Lista.items.clear();
            Lista.beginupdate();
            while ((dr.Read()))
                // Classe criada pelo Marcorati para substituir o Item Data antigo
                // Outra coisa. é usado o número dos campos para não dar problema com o nome
                // Em caso de usar "Campo as Alexandre"
                Lista.Items.Add(new MeuItemData(dr[0], dr[1]));
            Lista.endupdate();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            goto Fim;
        }
        // Fecha conexao
        conn.Close();

    Fim:
        ;
        conn.Dispose();
    }

    // Clone da função enter as tab
    public static void EnterAsTab(object sender, ref System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SendKeys.Send("{Tab}");
            e.Handled = true;
        }
    }

    // Função que executa instruções SQL de Inclusão, Exclusão e Update (sem retorno)
    public static int ExecutaSQL(string SQL, bool Onde = false)
    {

        // Se não estiver conectado já sai
        if (!Constantes.Conectado)
            return -1;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        int varRetorno;

        // Valor padrão
        varRetorno = 0;

        // Define a conexao
        conn = new MySqlConnection();
        // False = Local / True = Remoto
        if (Onde == false)
            // Usa a string de conexao atribuida na primeira janela
            conn.ConnectionString = MY_SQL_CONNECTION;
        else
            // Usa string de conexao remota
            conn.ConnectionString = MY_SQL_CONNECTION_WEB;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
        }
        catch (MySqlException myerror)
        {
            Interaction.MsgBox("Erro ao connectar: " + Constants.vbCrLf + myerror.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            goto FIM;
        }
        // Se conseguiu abrir a conexao então executa o resto

        // Define quem é a conexao ativa
        myCommand.Connection = conn;
        // Qual a SQL a ser usada
        myCommand.CommandText = SQL;
        // Para desenvolvimento
        Console.WriteLine("ExecutaSQL: " + SQL);
        try
        {
            // Retorna o valor que deu ao executar a query
            varRetorno = myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao executar o comando SQL" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            varRetorno = -1;
        }

    FIM:
        ;

        // Libera a variável e o servidor
        conn.Close();
        conn.Dispose();
        conn = null;
        // Retorna o valor da função 
        return varRetorno;
    }

    // Limpa todos os campos de um formulário
    public static void Limpa_Campos(ref Form formulario)
    {
        Control c;
        // Varre todos os controles do formulario
        foreach (var c in formulario.Controls)
        {
            // Se for textbox, combobox, ou maskeditbox então limpa o texto
            if (c is MaskedTextBox | c is TextBox | c is ComboBox)
                // Limpa o texto
                c.Text = string.Empty;
            // Se for um groupBox limpa tudo o que tiver dentro
            if (c is GroupBox)
            {
                for (int i = 0; i <= c.Controls.Count - 1; i++)
                {
                    if (c is MaskedTextBox | c is TextBox | c is ComboBox)
                        c.Text = string.Empty;
                }
            }
            if (c is TabControl)
            {
                // para cada tabpage neste tabControl
                // Dim col As TabControl = c
                // Para cada tabpage no tabcontrol
                foreach (TabPage t in c.Controls)
                {
                    // Para cada controle nessa tabpage
                    foreach (Control ct in t.Controls)
                    {
                        // Verifica se é um destes tipos e apaga
                        if (ct is MaskedTextBox | ct is TextBox | ct is ComboBox)
                            ct.Text = string.Empty;
                    }
                }
            }
        }
    }

    // Autocompletar para comboboxes
    public static void AutoCompleteCombo_KeyUp(ComboBox cbo, KeyEventArgs e)
    {
        string sTypedText;
        int iFoundIndex;
        object oFoundItem;
        string sFoundText;
        string sAppendText;

        // Allow select keys without Autocompleting
        switch (e.KeyCode)
        {
            case Keys.Back:
            case Keys.Left:
            case Keys.Right:
            case Keys.Up:
            case Keys.Delete:
            case Keys.Down:
                {
                    return;
                }
        }

        // Get the Typed Text and Find it in the list
        sTypedText = cbo.Text;
        iFoundIndex = cbo.FindString(sTypedText);

        // If we found the Typed Text in the list then Autocomplete
        if (iFoundIndex >= 0)
        {

            // Get the Item from the list (Return Type depends if Datasource was bound 
            // or List Created)
            oFoundItem = cbo.Items[iFoundIndex];

            // Use the ListControl.GetItemText to resolve the Name in case the Combo 
            // was Data bound
            sFoundText = cbo.GetItemText(oFoundItem);

            // Append then found text to the typed text to preserve case
            sAppendText = sFoundText.Substring(sTypedText.Length);
            cbo.Text = sTypedText + sAppendText;

            // Select the Appended Text
            cbo.SelectionStart = sTypedText.Length;
            cbo.SelectionLength = sAppendText.Length;
        }
    }

    public static void AutoCompleteCombo_Leave(ComboBox cbo)
    {
        int iFoundIndex;
        iFoundIndex = cbo.FindStringExact(cbo.Text);
        cbo.SelectedIndex = iFoundIndex;
    }

    public static object DLookupBLOB(string FieldName, string RecSource, string Criteria)
    {
        // Se não estiver conectado pelo IP já 
        if (!Constantes.Conectado)
            return string.Empty;
        string SQL;

        // Define a variavel que contera a sql
        object varRetorno;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();

        // Monta a SQL baseado nos dados passados
        SQL = "SELECT " + FieldName + " FROM " + RecSource + " WHERE " + Criteria;

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return null;
            return;
        }
        // Se conseguiu abrir a conexao então executa o resto

        // Define quem é a conexao ativa
        myCommand.Connection = conn;
        // Qual a SQL a ser usada
        myCommand.CommandText = SQL;
        myCommand.CommandTimeout = Constantes.MY_TIMEOUT;

        Console.WriteLine("DLookup: " + SQL);
        // Armazena a variável antes de fechar a conexão
        varRetorno = myCommand.ExecuteScalar();

        // Fecha e libera
        // Libera a variável e o servidor
        conn.Close();
        conn.Dispose();
        conn = null;

        // Retorna o valor que deu ao executar a query
        if (Information.IsDBNull(varRetorno) | Information.IsNothing(varRetorno))
            varRetorno = null;
        return varRetorno;
    }

    public static string DLookup(string FieldName, string RecSource, string Criteria)
    {

        // Se não estiver conectado pelo IP já 
        if (!Constantes.Conectado)
            return string.Empty;
        string SQL;

        // Define a variavel que contera a sql
        object varRetorno;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        // Dim myAdapter As New MySqlDataAdapter
        // Dim myData As New DataTable

        // Monta a SQL baseado nos dados passados
        SQL = "SELECT " + FieldName + " FROM " + RecSource + " WHERE " + Criteria;

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return string.Empty;
            return;
        }
        // Se conseguiu abrir a conexao então executa o resto

        // Define quem é a conexao ativa
        myCommand.Connection = conn;
        // Qual a SQL a ser usada
        myCommand.CommandText = SQL;
        myCommand.CommandTimeout = Constantes.MY_TIMEOUT;

        Console.WriteLine("DLookup: " + SQL);
        // Armazena a variável antes de fechar a conexão
        varRetorno = myCommand.ExecuteScalar();

        // Fecha e libera
        // Libera a variável e o servidor
        conn.Close();
        conn.Dispose();
        conn = null;

        // Retorna o valor que deu ao executar a query
        if (Information.IsDBNull(varRetorno) | Information.IsNothing(varRetorno))
            varRetorno = string.Empty;
        return varRetorno;
    }

    public static DataRow DLookupRow(string Tabela, string Criterio, bool Remoto = false)
    {
        DataRow DR;

        // Se não estiver conectado pelo IP já 
        if (!Constantes.Conectado)
            return null;

        // Define a variavel que contera a sql
        string SQL;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection myConn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataReader myRead;
        DataTable myData = new DataTable();

        // Monta a SQL baseado nos dados passados
        SQL = "SELECT * FROM " + Tabela + " WHERE " + Criterio;
        Console.WriteLine(SQL);

        // Usa a string de conexao atribuida na primeira janela
        // Se for para acesso remoto usa a string WEB se for para acesso local usa a Local
        if (Remoto)
            myConn.ConnectionString = MY_SQL_CONNECTION_WEB;
        else
            myConn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            myConn.Open();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + Constants.vbCrLf + myerror.Message);
            myConn.Close();
            myConn.Dispose();
            return null;
            return;
        }
        // Se conseguiu abrir a conexao então executa o resto

        try
        {
            // Define o tipo de comando - TEXT = SQL
            myCommand.Connection = myConn;
            // Define o tipo do comando
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandTimeout = Constantes.MY_TIMEOUT;
            // Define a SQL em si
            myCommand.CommandText = SQL;
            // Executa o DataReader
            myRead = myCommand.ExecuteReader();
            // Carrega a(s) linha(s) no DataTable

            if (!myRead.HasRows)
                Interaction.MsgBox("Não foram encontradas linhas que satisfaçam a condição.");

            myData.Load(myRead);

            // Libera a Memoria
            myCommand.Dispose();
            myConn.Close();
            myConn.Dispose();

            // Retorna a linha desejada
            DR = myData.Rows[0];
            // Se não for em branco
            if (!Information.IsNothing(DR))
                return DR;
            else
                return null;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao abrir a conexão: " + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
            // Libera a memoria
            myCommand.Dispose();
            myConn.Close();
            myConn.Dispose();
            return null;
        }
    }

    public static int Last_ID()
    {
        if (!Constantes.Conectado)
            return -1;

        // Sintaxe var=Last_ID()
        // Define a variavel que contera a sql
        string SQL;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        int Retorno;

        SQL = "SELECT LAST_INSERT_ID() AS Ultimo";

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
            // Se conseguiu abrir a conexao então executa o resto
            // Define quem é a conexao ativa
            myCommand.Connection = conn;
            // Qual a SQL a ser usada
            myCommand.CommandText = SQL;
            // Retorna o valor que deu ao executar a query
            // Libera a variável e o servidor
            Retorno = myCommand.ExecuteScalar();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return -1;
            return;
        }

        // Fecha e libera
        conn.Close();
        conn.Dispose();
        conn = null;
        return Retorno;
    }

    public static int DCount(string Campo, string Tabela, string Criterio = "")
    {
        // Se não estiver conectado
        if (!Constantes.Conectado)
            return 0;
        string SQL;

        // Sintaxe DMax("Vidro", "Aux_frascos", "Lote=" & LoteID)
        // Define a variavel que contera a sql
        object Resposta;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        int Retorno = -1;

        // Monta a SQL baseado nos dados passados
        if (!Criterio == "")
            // Com critério
            SQL = "SELECT COUNT(" + Campo + ") as Conta FROM " + Tabela + " WHERE " + Criterio;
        else
            // Sem critério definido
            SQL = "SELECT COUNT(" + Campo + ") as Conta FROM " + Tabela;

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
            // Se conseguiu abrir a conexao então executa o resto
            // Define quem é a conexao ativa
            myCommand.Connection = conn;
            // Qual a SQL a ser usada
            myCommand.CommandText = SQL;
            // Retorna o valor que deu ao executar a query
            // Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar();
            if (!Information.IsDBNull(Resposta))
                return Conversion.Val(Resposta);
            else
                return 0;
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return -1;
            return;
        }

        // Fecha e libera
        conn.Close();
        conn.Dispose();
        conn = null;
        return Retorno;
    }

    public static int DNextID(string Tabela)
    {
        // Se não estiver conectado
        if (!Constantes.Conectado)
            return 0;
        string SQL;

        // Define a variavel que conterá a sql
        object Resposta;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        int Retorno = -1;

        // Monta a SQL que pega o próximo ID da tabela informada
        SQL = "SELECT `AUTO_INCREMENT` FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'controle' AND TABLE_NAME = '" + Tabela + "'";

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
            // Se conseguiu abrir a conexao então executa o resto
            // Define quem é a conexao ativa
            myCommand.Connection = conn;
            // Qual a SQL a ser usada
            myCommand.CommandText = SQL;
            // Retorna o valor que deu ao executar a query
            // Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar();
            if (!Information.IsDBNull(Resposta))
                return Conversion.Val(Resposta);
            else
                return -1;
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return -1;
            return;
        }

        // Fecha e libera
        conn.Close();
        conn.Dispose();
        conn = null;
        return Retorno;
    }


    public static int DMax(string Campo, string Tabela, string Criterio = "")
    {
        // Se não estiver conectado
        if (!Constantes.Conectado)
            return 0;
        string SQL;

        // Sintaxe DMax("Vidro", "Aux_frascos", "Lote=" & LoteID)
        // Define a variavel que contera a sql
        object Resposta;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        int Retorno = -1;

        // Monta a SQL baseado nos dados passados
        if (!Criterio == "")
            // Com critério
            SQL = "SELECT MAX(" + Campo + ") as Maximo FROM " + Tabela + " WHERE " + Criterio;
        else
            // Sem critério definido
            SQL = "SELECT MAX(" + Campo + ") as Maximo FROM " + Tabela;

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
            // Se conseguiu abrir a conexao então executa o resto
            // Define quem é a conexao ativa
            myCommand.Connection = conn;
            // Qual a SQL a ser usada
            myCommand.CommandText = SQL;
            // Retorna o valor que deu ao executar a query
            // Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar();
            if (!Information.IsDBNull(Resposta))
                return Conversion.Val(Resposta);
            else
                return 0;
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            return -1;
            return;
        }

        // Fecha e libera
        conn.Close();
        conn.Dispose();
        conn = null;
        return Retorno;
    }
    public static void Localiza_Item(ref object Lista, string Valor)
    {
        // *
        // * Localiza e seleciona um item em um ComboBox ou ListBox baseado em um Index
        // *

        int aIndex;
        // Usando o objeto lista
        {
            var withBlock = Lista;
            // Para cada item da lista
            for (var aIndex = 0; aIndex <= withBlock.Items.Count - 1; aIndex++)
            {
                // Verifica se a propriedade de valor é igual ao Valor fornecido
                try
                {
                    if ((MeuItemData)withBlock.items(aIndex).Valor == Valor)
                    {
                        // Se for seleciona o item
                        withBlock.SelectedIndex = aIndex;
                        withBlock.Text = withBlock.SelectedItem.ToString();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            // Se não encontrar nenhum então não seleciona nada
            if (aIndex >= withBlock.Items.Count)
                withBlock.SelectedIndex = -1;
        }
    }

    // retorna o Value Item de uma lista qualquer
    public static object cmbVal(ref object Lista)
    {
        int num;
        object Ret;
        {
            var withBlock = Lista;
            num = withBlock.SelectedIndex;
            if (num == -1)
            {
                return -1;
                return;
            }
            try
            {
                Ret = (MeuItemData)withBlock.Items(withBlock.SelectedIndex).Valor;
                return Ret;
            }
            catch (InvalidCastException ex)
            {
                Interaction.MsgBox("Não há valor numérico associado à caixa de combinação!" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return -1;
            }
        }
    }
    // Preenche uma sequencia com determinado número de zeros
    public static string StrZero(object nNumero, int nCasas)
    {
        string Retorno;
        Retorno = Strings.Right("000000000000" + Strings.LTrim(nNumero), nCasas);
        return Retorno;
    }

    // Retorna o código de um lote baseado em seu código
    public static string Procura_Lote(int IdLote)
    {
        string Retorno;
        // Define a variavel que contera a sql
        string SQL;

        // Define as variaveis da biblioteca MySQL
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        DataTable myData = new DataTable();
        MySqlDataReader dr;

        // Monta a SQL baseado nos dados passados
        SQL = "SELECT id,Mercadoria,Lote,Clone FROM Lotes WHERE id=" + IdLote.ToString();

        // Define a conexao
        conn = new MySqlConnection();
        // Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION;

        // Tenta abrir a conexao
        try
        {
            conn.Open();
        }
        catch (MySqlException myerror)
        {
            MessageBox.Show("Erro ao connectar: " + myerror.Message);
            conn.Close();
            conn.Dispose();
            conn = null;
            return "";
            return;
        }
        // Se conseguiu abrir a conexao então executa o resto

        // Define quem é a conexao ativa
        myCommand.Connection = conn;
        // Qual a SQL a ser usada
        myCommand.CommandText = SQL;
        // Retorna o valor que deu ao executar a query
        dr = myCommand.ExecuteReader();
        Retorno = "";
        if (dr.Read())
            Retorno = Strings.Format(dr.GetInt16("Mercadoria"), "000") + "." + Strings.Format(dr.GetInt16("Lote"), "000") + "." + Strings.Format(dr.GetInt16("Clone"), "0000");
        else
            Retorno = string.Empty;
        conn.Close();
        // Libera a variável e o servidor
        conn.Dispose();
        conn = null;
        return Retorno;
    }

    public static void UpLoadArquivo(string FTP, string Arquivo, string ftpUser, string ftpPass)
    {

        // FTP = "ftp://ftp.provedor.com/pasta/arquivo.gif"
        // Arquivo = "d:\Meus documentos\arquivo.gif"
        // ftpUser = "Usuário do FTP"
        // ftpPass = "Senha do FTP"

        // Dimensiona as variáveis
        Uri target = new Uri(FTP);
        string fileName = Arquivo;

        FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(target);
        // Faz o acesso ao ftp
        request.Method = WebRequestMethods.Ftp.UploadFile;
        // Modo binario
        request.UseBinary = true;
        // Dimensiona as variáveis de acesso ao arquivo local
        FileStream FS = new FileStream(Arquivo, FileMode.Open);
        BinaryReader br = new BinaryReader(FS);
        byte[] buffer = br.ReadBytes(System.Convert.ToInt32(FS.Length));
        br.Close();
        FS.Close();
        request.ContentLength = buffer.Length;
        request.Credentials = new NetworkCredential(ftpUser, ftpPass);

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(buffer, 0, buffer.Length);
        requestStream.Close();

        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        if (response.ToString() == "System.Net.FtpWebResponse")
            // Se a sresposta do servidor foi OK então!
            Interaction.MsgBox("Arquivo enviado com sucesso!", Constants.vbOKOnly, "Sucesso");
        else
            Interaction.MsgBox("Erro ao enviar o arquivo! Tente novamente!", Constants.vbOKOnly, "Erro");
        response.Close();
    }
    public static bool SQLTransacao(string[] SQLs, bool Local = false)
    {

        // Usa a técnica de transação, ou TUDO dá certo ou não inclui nada para que não haja erro
        MySqlConnection myConnection = new MySqlConnection();
        // Define a Connection String
        if (Local == false)
            // FALSE = Conexão Local
            myConnection.ConnectionString = MY_SQL_CONNECTION;
        else
            // TRUE = Conexão Remota com o Site
            myConnection.ConnectionString = MY_SQL_CONNECTION_WEB;

        // Abre a conexão
        myConnection.Open();

        // Cria uma nova transação
        MySqlTransaction myTrans;
        // Inicia a transação localmente
        myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);

        // Cria um novo comando
        MySqlCommand myCommand = new MySqlCommand();
        myCommand.Connection = myConnection;
        // Adiciona o objeto transação como pendente
        myCommand.Transaction = myTrans;

        try
        {
            // Para cada SQL do conjunto monta a transação
            for (int i = 0; i <= SQLs.GetUpperBound(0); i++)   // Upper Bound da dimensão 0
            {
                // Executa cada tarefa da transação
                // Auxiliar para Debug
                Console.WriteLine("Array SQL Transação (" + i + "): " + SQLs[i]);
                myCommand.CommandText = SQLs[i];
                myCommand.ExecuteNonQuery();
            }
            // Tenta verificar se deu certo (ou seja se todas foram executadas sem nenhum erro)
            myTrans.Commit();
            // Finaliza a conexão e fecha a transação.
            myConnection.Close();
            // Se deu tudo certo
            return true;
        }
        catch (Exception ex)
        {
            // Desfaz a transação inteira e nada acontece.
            myTrans.Rollback();
            Interaction.MsgBox("Erro na transação SQL:" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
            // Finaliza a conexão e fecha a transação.
            myConnection.Close();
            return false;
        }
    }


    public static DataTable SQLQuery(string SQL, bool Local = false)
    {

        // Verifica se está conectado ao BD
        if (!Constantes.Conectado)
            return null;
        // Verifica se o parametro passado é válido
        if (SQL == string.Empty | Information.IsDBNull(SQL))
            return null;

        MySqlCommand myComm = new MySqlCommand();
        MySqlConnection myConn = new MySqlConnection();
        MySqlDataAdapter myAda = new MySqlDataAdapter();
        DataSet myDS = new DataSet();
        DataTable myTab = new DataTable();

        // Verifica se é qualquer otra query que não seja selecao
        if (SQL.Substring(0, 6) != "SELECT")
        {
            Interaction.MsgBox("Esta função executa apenas SQL's que retornem dados", Constants.vbCritical, "Erro");
            myConn.Close();
            myConn.Dispose();
            return null;
            return;
        }

        // Verifica se a base de dados é local ou remota
        if (Local == false)
            myConn.ConnectionString = MY_SQL_CONNECTION;
        else
            myConn.ConnectionString = MY_SQL_CONNECTION_WEB;
        // tenta abrir a conexao
        try
        {
            myConn.Open();
            // Define o tipo de comando - TEXT = SQL
            myComm.Connection = myConn;
            // Define o tipo do comando
            myComm.CommandType = CommandType.Text;
            // Define a SQL em si
            myComm.CommandText = SQL;
            // define o adaptador
            myAda.SelectCommand = myComm;
            // Preenche o dataset
            myAda.Fill(myTab);
            // Retorna a tabela desejada
            myComm.Dispose();
            myConn.Close();
            myConn.Dispose();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao abrir a conexão: " + ex.Message, MsgBoxStyle.Critical, "Erro");
            myComm.Dispose();
            myConn.Close();
            myConn.Dispose();
        }
        return myTab;
    }

    // Public Sub Imprime_Etiqueta(ByVal Cod_Esq As String, ByVal Des_Esq As String, ByVal Dat_Esq As String, ByVal Cod_Dir As String, ByVal Des_Dir As String, ByVal Dat_Dir As String)
    // A variável Porta é Global e é usada para a definição da porta de Impressão
    // Cria um arquivo virtual usando a API do windows
    // Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    // Dim handle As SafeFileHandle
    // Dim S1 As String
    // Tenta imprimir as etiquetas
    // Try
    // tenta criar o arquivos
    // Dim wFile As System.IO.FileStream
    // Dim byteData() As Byte, impTemp As Integer = 10
    // 
    // Abre o arquivo LPT1
    // wFile = New FileStream(ptr, FileAccess.Write)

    // Prepara a etiqueta
    // S1 = Chr(2) & "c0000" & Chr(13)        ' Midia não continua
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "O0220" & Chr(13)        ' Posicao inicial da impressora
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KW0335" & Chr(13)       '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KI7" & Chr(1) & Chr(13) '1 - Termal Transfer 0- Direct Transfer
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "V0" & Chr(13)           '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "L" & Chr(13)            'Manda padrão da etiqueta
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "H" & Trim(impTemp) & Chr(13)      'Temperatura de 10 a 20
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "PC" & Chr(13)                    'Velocidade de Impressão A/B/C/D/E
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "A2" & Chr(13)                     '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "D11" & Chr(13)                    ' Tamanho do pixel
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 
    // Etiqueta 01
    // S1 = "191100200260018" & "Lote:" & Chr(13)       'Label do lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "1D3101500520017" & Cod_Esq & Chr(13)       'Codigo de Barras do Lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100200030017" & "Data:" & Chr(13)       'Label Data
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100300260049" & Des_Esq & Chr(13)       'Descricao do lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100200030048" & Dat_Esq & Chr(13)       'Data em si
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 
    // Etiqueta 02
    // S1 = "191100200260181" & "Lote:" & Chr(13)       'Label do lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "1D3101500520180" & Cod_Dir & Chr(13)       'Codigo de Barras do Lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100200030180" & "Data:" & Chr(13)       'Label Data
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100300260212" & Des_Dir & Chr(13)       'Descricao do lote
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "191100200030211" & Dat_Dir & Chr(13)       'Data em si
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 
    // 'Comandos de finalização
    // '           S1 = "^02" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "Q0001" & Chr(13)                           ' Contador de cópia
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "E" & Chr(13)                               ' Fim do servico
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Fecha o arquivo
    // wFile.Close()
    // 
    // Catch ex As IOException
    // 'se houver uma excessão mosta a mensagem
    // MsgBox(ex.Message & vbCrLf & ex.ToString)
    // End Try
    // End Sub
    // 
    // Public Sub Volta_Etiqueta_Serial(ByRef Porta As SerialPort)
    // Envia o comando para dar um backfeed
    // Porta.WriteLine(Chr(2) & "f320")
    // End Sub

    // Public Sub Volta_Etiqueta()
    // Le as definicoes do arquivo INI
    // A variável Porta é Global e é usada para a definição da porta de Impressão
    // Cria um arquivo virtual usando a API do windows
    // Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    // Dim S1 As String
    // Tenta imprimir as etiquetas
    // Try
    // tenta criar o arquivos
    // Dim wFile As System.IO.FileStream
    // Dim byteData() As Byte, impTemp As Integer = 10

    // Abre o arquivo LPT1
    // wFile = New FileStream(ptr, FileAccess.Write)

    // Prepara a etiqueta
    // S1 = Chr(2) & "f320" & Chr(13)          ' Back Feed de 1 polegada antes da impressão
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Fecha o arquivos
    // wFile.Close()
    // Catch ex As Exception
    // Mostra a mensagem
    // MsgBox(ex.Message & vbCrLf & ex.ToString)
    // End Try
    // End Sub

    // Sub Imprime_Etiqueta_Orquidea(ByVal E_varCodBar As String, ByVal E_varDataH As String, ByVal E_varDataLote As String, ByVal E_varEspecie As String, ByVal E_varDataC As String, ByVal E_varDataS As String, ByVal E_varDesc As String, ByVal E_varDataR As String, ByVal E_varFrasco As String, ByVal E_varNMudas As String, ByVal D_varCodBar As String, ByVal D_varDataH As String, ByVal D_varDataLote As String, ByVal D_varEspecie As String, ByVal D_varDataC As String, ByVal D_varDataS As String, ByVal D_varDesc As String, ByVal D_varDataR As String, ByVal D_varFrasco As String, ByVal D_varNmudas As String)
    // 'Cria um arquivo virtual usando a API do windows
    // 'A variável Porta é Global e é usada para a definição da porta de Impressão
    // Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    // 'Dim handle As SafeFileHandle
    // Dim S1 As String
    // 'Tenta imprimir as etiquetas
    // Try
    // 'tenta criar o arquivos
    // Dim wFile As System.IO.FileStream
    // 'Dim byteData() As Byte, impTemp As Integer = 10
    // 
    // 'Abre o arquivo LPT1
    // wFile = New FileStream(ptr, FileAccess.Write)
    // 
    // Prepara a etiqueta
    // S1 = Chr(2) & "c0000" & Chr(13)        ' Midia não continua
    // byteData = Encoding.ASCII.GetBytes(S1)
    // '       wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "O0220" & Chr(13)        ' Posicao inicial da impressora
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KW0335" & Chr(13)       '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KI7" & Chr(1) & Chr(13) '1 - Termal Transfer 0- Direct Transfer
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "V0" & Chr(13)           '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "L" & Chr(13)            'Manda padrão da etiqueta
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "H" & Trim(impTemp) & Chr(13)      'Temperatura de 10 a 20
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "PC" & Chr(13)                    'Velocidade de Impressão A/B/C/D/E
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "A2" & Chr(13)                     '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "D11" & Chr(13)                    ' Tamanho do pixel
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 
    // '*
    // '* ETIQUETA 01 (DIREITA)
    // '*
    // 
    // Cabecalho do lote
    // S1 = "191100200730016Lote:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Codigo de barras ou ID da semeadura
    // S1 = "1D3101500590112" & E_varCodBar & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Cabecalho Colheita (Harvest)
    // S1 = "191100100160017C:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Data da Colheita
    // S1 = "191100100160027" & E_varDataH & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Data que indica o lote
    // S1 = "191100200730043" & E_varDataLote & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Nome da Especie
    // S1 = "191100100380016" & E_varEspecie & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Data do cruzamento
    // S1 = "191100100160087" & E_varDataC & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Cabecalho cruzamento
    // S1 = "191100100160077P:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data da semeadura
    // S1 = "191100100040027" & E_varDataS & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // cabecalho da Semeadura
    // S1 = "191100100040017S:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // '        wFile.Write(byteData, 0, byteData.Length)
    // Descricao
    // S1 = "191100100270016" & E_varDesc & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Cabecalho repicagem
    // S1 = "191100100040077R:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Data da Repicagem
    // S1 = "191100100040087" & E_varDataR & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Cabecalho Frasco
    // S1 = "191100200580016Frasco:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // 'Número do frasco
    // S1 = "191100200580056" & E_varFrasco & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Verifica se tem mudas
    // If E_varNMudas <> "000" Then
    // Número de mudas
    // S1 = "191100200370113" & E_varNMudas & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Número de mudas
    // S1 = "191100200370133Mds" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Else
    // Frasco de semente
    // S1 = "191100200370113" & "Sem" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // End If
    // 
    // *
    // * ETIQUETA 02 (DIREITA)
    // *
    // 
    // Cabecalho do lote
    // S1 = "191100200730179Lote:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Codigo de barras ou ID da semeadura
    // S1 = "1D3101500590282" & D_varCodBar & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Cabecalho Colheita (Harvest)
    // S1 = "191100100160180C:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data da Colheita
    // S1 = "191100100160190" & D_varDataH & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data que indica o lote
    // S1 = "191100200730206" & D_varDataLote & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Nome da Especie
    // S1 = "191100100380179" & D_varEspecie & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data do cruzamento
    // S1 = "191100100160250" & D_varDataC & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Cabecalho cruzamento
    // S1 = "191100100160240P:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data da semeadura
    // S1 = "191100100040190" & D_varDataS & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // cabecalho da Semeadura
    // S1 = "191100100040180S:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Descricao
    // S1 = "191100100270179" & D_varDesc & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Cabecalho repicagem
    // S1 = "191100100040240R:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Data da Repicagem
    // S1 = "191100100040250" & D_varDataR & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Cabecalho Frasco
    // S1 = "191100200580179Frasco:" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Número do frasco
    // S1 = "191100200580219" & D_varFrasco & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Se for frasco com sementes não poe o numero de mudas
    // If D_varNmudas <> "000" Then
    // Número de mudas
    // S1 = "191100200370276" & D_varNmudas & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Número de mudas
    // S1 = "191100200370296Mds" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Else
    // Número de mudas
    // S1 = "191100200370276" & "Sem" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // End If

    // Comandos de finalização das Etiquetas
    // S1 = "^02" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "Q0001" & Chr(13)                           ' Contador de cópia
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // S1 = "E" & Chr(13)                               ' Fim do servico
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFile.Write(byteData, 0, byteData.Length)
    // Fecha o arquivo
    // wFile.Close()
    // Catch ex As Exception
    // MsgBox("Erro na impressão de etiquetas de Orquídeas" & vbCrLf & ex.Message & vbCrLf & ex.ToString)
    // Exit Sub
    // End Try
    // 
    // End Sub

    // Public Sub Abre_Impressora()

    // Cria um arquivo virtual usando a API do windows

    // PTR1 = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    // Dim S1 As String, byteData() As Byte
    // Try
    // Abre o arquivo LPT1
    // wFILE = New FileStream(PTR1, FileAccess.Write)

    // Comandos de ROM
    // Ficam gravados mesmo depois que se desliga a impressora

    // S1 = Chr(2) & "KI7" & Chr(1) & Chr(13)  '0- Transferencia Direta
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)

    // S1 = Chr(2) & "KW0335" & Chr(13)       '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)

    // S1 = Chr(2) & "V0" & Chr(13)           '
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)

    // Catch ex As IOException
    // MsgBox("Erro ao tentar criar abertura na LPT1!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
    // Exit Sub
    // End Try

    // End Sub

    // Public Sub Fecha_Impressora()
    // 'Fecha o arquivo
    // wFILE.Close()
    // 'Elimina da memória os registrdores
    // PTR1 = Nothing
    // wFILE = Nothing
    // End Sub

    // Public Sub Cabecalho_Etiqueta()
    // Define as variáveis
    private static byte[] byteData;
    private static int impTemp = 10;
    private static string S1;

    // Prepara a etiqueta com comandos Temporários

    // S1 = Chr(2) & "c0000" & Chr(13)        ' Midia Contínua (bobina em Rolo)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // S1 = Chr(2) & "O0220" & Chr(13)        ' Ajusta a posição do início (O220 - Sem margem)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // End Sub

    // Public Sub Finaliza_Etiqueta()
    // 'Define as variáveis
    // Dim byteData() As Byte, impTemp As Integer = 10
    // Dim S1 As String
    // 
    // 'Comandos de finalização
    // S1 = "^02" & Chr(13)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // S1 = "Q0001" & Chr(13)                           ' Contador de cópia (01 cópia de cada)
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // S1 = "E" & Chr(13)                               ' Fim da formatação e Imprime
    // byteData = Encoding.ASCII.GetBytes(S1)
    // wFILE.Write(byteData, 0, byteData.Length)
    // End Sub

    public static void Imprime_Etiqueta_Bandeja(string E_CodBar, string E_Mercad, string E_Data, string E_Tipo, string D_CodBar, string D_Mercad, string D_Data, string D_Tipo)
    {
        byte[] byteData;
        // Define as variáveis 
        int impTemp = 10;
        string S1;
        // Tenta imprimir as etiquetas
        try
        {

            // *
            // * Começa o envio das configurações da etiqueta
            // * 
            S1 = Strings.Chr(2) + "L" + Strings.Chr(13);            // Manda padrão da etiqueta
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "H" + Strings.Trim(impTemp) + Strings.Chr(13);      // Temperatura de 10 a 20
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "PD" + Strings.Chr(13);                    // Velocidade de Impressão A/B/C/D (D=76,2 mm/s)
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "A2" + Strings.Chr(13);                     // 
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "D11" + Strings.Chr(13);                    // Tamanho do pixel (1x1 -> D11)
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);

            // *
            // * Etiqueta 01
            // *

            S1 = "1D4201300150018" + E_CodBar + Strings.Chr(13);             // Código Barras
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100400160085" + E_Mercad + Strings.Chr(13);             // Mercadoria
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100100030109" + E_Data + Strings.Chr(13);               // Data
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100000030021" + "Tipo:" + E_Tipo + Strings.Chr(13);      // Tipo
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);

            // *
            // * Etiqueta 02
            // *

            S1 = "1D4201300150168" + D_CodBar + Strings.Chr(13);             // Código de Barras
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100400160235" + D_Mercad + Strings.Chr(13);             // Mercadoria
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100100030259" + D_Data + Strings.Chr(13);               // Data
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
            S1 = "191100000030171" + "Tipo:" + D_Tipo + Strings.Chr(13);      // Tipo
            byteData = Encoding.ASCII.GetBytes(S1);
            wFILE.Write(byteData, 0, byteData.Length);
        }
        catch (IOException ex)
        {
            // se houver uma excessão mosta a mensagem
            Interaction.MsgBox(ex.Message + Constants.vbCrLf + ex.ToString());
        }
    }


    public static void IP_Barra_Status()
    {
        // Define todas as variáveis e os tipos
        // Todoas estas informações estão numa XML que é a configuração do projeto
        // As configurações My estão todas nesse XML
        TcpClient tcpClient = new TcpClient();
        string IP = My.Settings.MyServer;
        Int32 Port = My.Settings.MyPort;
        IPAddress Endereco;
        // Converte o endereço em ip válido
        Endereco = IPAddress.Parse(IP);

        // Tenta conectar
        try
        {
            tcpClient.Connect(IP, Port);
            frmMenu.sbpStatus.ForeColor = Color.DarkGreen;
            frmMenu.sbpStatus.Text = "Status: Conectado";
            frmMenu.sbpIP.Text = "IP Servidor: " + IP;
            Constantes.Conectado = true;
        }
        catch (Exception err)
        {
            frmMenu.sbpStatus.ForeColor = Color.DarkRed;
            frmMenu.sbpStatus.Text = "Status: Desconectado";
            frmMenu.sbpIP.Text = "IP Servidor: " + IP;
            Constantes.Conectado = false;
        }
    }

    public static string Troca_Ponto(double num)
    {
        string Resposta;
        // Recebe um número com vírgula e transforma ele em ponto
        Resposta = num.ToString();
        // Efetua a troca com a função
        Resposta = Resposta.Replace(",", ".");
        // Retorna uma string
        return Resposta;
    }

    public static void Formata_Datagrid(ref object dataGrid, string[] Cabecalhos, int[] Larguras, int[] Visiveis = null)
    {
        int Num;
        // Conta o número de colunas baseado no tamanho do array
        Num = Cabecalhos.Length;
        if (Num != dataGrid.columns.count)
        {
            Console.WriteLine("Número de parametros passados:" + Num + " | Núm Colunas no Datagrid:" + dataGrid.columns.count);
            Interaction.MsgBox("Erro ao formatar o datagrid:" + Constants.vbCrLf + "O número de colunas não coincide com o informado.", MsgBoxStyle.Critical, "Erro");
            return;
        }
        // Formata datagrid (Num Colunas)
        for (int i = 0; i <= Num - 1; i++)
        {
            // usa o vetor de tamanhos e textos
            {
                var withBlock = dataGrid.Columns(i);
                withBlock.Width = Larguras[i];
                withBlock.HeaderText = Cabecalhos[i];
                // se foi definido pelo usuário
                if (Visiveis.Length > 0)
                {
                    // Faz a conversao de tipos
                    if (Visiveis[i] == 1)
                        withBlock.Visible = true;
                    else if (Visiveis[i] == 0)
                        withBlock.Visible = false;
                }
            }
        }
    }
    // função para eliminar o erro de dbnull em pesquisas a banco de dados
    public static string NaoNulo(object Campo)
    {
        if (Information.IsDBNull(Campo))
            return string.Empty;
        else
            return Campo;
    }

    // Função que transforma o valor para poder ser gravado no banco de dados
    public static void Transforma_Valor(string Valor)
    {
        string STR;
        long i;
        STR = System.Convert.ToString(Valor);
        // Tira as os pontos de milhar
        STR = STR.Replace(".", "");
        // Procura a vírgula
        i = Strings.InStr(1, STR, ",");
        if (i == 0)
        {
            Transforma_Valor = STR;
            return;
        }
        else
        {
            Transforma_Valor = STR.Replace(",", ".");
            return;
        }
    }

    public static System.Drawing.Color Cor_Pedido(string Status)
    {
        switch (Status)
        {
            case "1":
                {
                    // Autorizado (1) - Branco
                    return Color.LightGray;
                }

            case "2":
                {
                    // Produzindo (2) - Amarelo
                    return Color.Yellow;
                }

            case "3":
                {
                    // Cancelado (3) - Vermelho
                    return Color.Red;
                }

            case "4":
                {
                    // Atendido (4) - Verde
                    return Color.GreenYellow;
                }

            default:
                {
                    // Se não for nenhum destes acima
                    return Color.White;
                }
        }
    }

    public static Hashtable BuscaCep(string cep)
    {
        DataSet ds;
        string _resultado;
        System.Collections.Hashtable ht = null;
        try
        {
            ds = new DataSet();
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml");
            if (!Information.IsNothing(ds))
            {
                if ((ds.Tables[0].Rows.Count > 0))
                {
                    _resultado = ds.Tables[0].Rows[0].Item["resultado"].ToString();
                    ht = new Hashtable();
                    switch (_resultado)
                    {
                        case "1":
                            {
                                ht.Add("UF", ds.Tables[0].Rows[0].Item["uf"].ToString().Trim());
                                ht.Add("cidade", ds.Tables[0].Rows[0].Item["cidade"].ToString().Trim());
                                ht.Add("bairro", ds.Tables[0].Rows[0].Item["bairro"].ToString().Trim());
                                ht.Add("tipologradouro", ds.Tables[0].Rows[0].Item["tipo_logradouro"].ToString().Trim());
                                ht.Add("logradouro", ds.Tables[0].Rows[0].Item["logradouro"].ToString().Trim());
                                ht.Add("tipo", 1);
                                break;
                            }

                        case "2":
                            {
                                ht.Add("UF", ds.Tables[0].Rows[0].Item["uf"].ToString().Trim());
                                ht.Add("cidade", ds.Tables[0].Rows[0].Item["cidade"].ToString().Trim());
                                ht.Add("tipo", 2);
                                break;
                            }

                        default:
                            {
                                ht.Add("tipo", 0);
                                break;
                            }
                    }
                }
            }
            return ht;
        }
        catch (Exception ex)
        {
            throw new Exception("Falha ao Buscar o Cep" + Constants.vbCrLf + ex.ToString());
            return null;
        }
    }

    public static double Converte_Numero(string Numero)
    {
        // Se não for informado, ou for vazio
        if (Numero == string.Empty | Numero == "" | Numero == Constants.vbNull)
            // Retorna zero
            return 0;
        try
        {
            double Val;
            Val = String_to_Numero(Numero);
            return Val;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao converter número na rotina Converte_Numero" + Constants.vbCrLf + ex.Message + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical, "Erro");
            return 0;
        }
    }

    public static string Texto_Vazio(string Texto)
    {
        if (Texto == "" | Texto == string.Empty)
            return "NULL";
        else
            return "'" + Texto + "'";
    }

    // * 
    // * Função que Gera o Codigo SQL Baseado nos campos
    // *
    public static string Gera_SQL(Form frm, string Tabela, string Tipo, string Especial = "", int id = -1)
    {
        string Retorno = string.Empty;
        // *
        // * Especial = string contendo algum campo especial que precise de processamento foras
        // *            do convencional que não possa ser tratado pelo looping
        // *
        // * ID       = No caso de um update, o ID serve para selecionar o registro a ser alterado
        // *
        // * TAG      = O campo tag do formulário deve ser preenchido com o o tipo de dados underline
        // *            em seguida o nome do campo no bando de dados. Ex: T_NomeCli
        // *            Se o campo não precisar ser registrado, então preenche-se com 0_
        // *          

        string SQL = string.Empty;
        Control Ctrl;
        int ct = 0;

        // Monta a SQL Base
        if (Tipo == "INSERT")
            SQL = "INSERT INTO " + Tabela + " SET ";
        else if (Tipo == "UPDATE")
            SQL = "UPDATE " + Tabela + " SET ";

        // Percorre todos os controles procurando a as TAGS
        foreach (var Ctrl in frm.Controls)
        {
            if (Ctrl.GetType().ToString() == "System.Windows.Forms.MaskedTextBox" | Ctrl.GetType().ToString() == "System.Windows.Forms.TextBox" | Ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                // Se o campo TAG estiver preenchido se não for computado preencher com 0_
                if (Ctrl.Tag.ToString().Length > 2)
                {
                    // Se a lista for maior que 1 então
                    if (ct > 0)
                        SQL += ",";
                    // Começa com o nome do campo (Tirando os 2 char do tipo)
                    SQL += Ctrl.Tag.ToString().Remove(0, 2) + "=";
                    // Se for do tipo texto 
                    switch (Ctrl.Tag.ToString().Substring(0, 2))
                    {
                        case "T_"   // Texto
                       :
                            {
                                SQL += Texto_Vazio(Ctrl.Text);
                                break;
                            }

                        case "I_"   // Numero Inteiro
                 :
                            {
                                SQL += Ctrl.Text;
                                break;
                            }

                        case "F_"   // Numero flutuante
                 :
                            {
                                SQL += Troca_Ponto(Converte_Numero(Ctrl.Text));
                                break;
                            }

                        case "D_"   // Data
                 :
                            {
                                SQL += "'" + Strings.Format((DateTime)Ctrl.Text, "yyyy-MM-dd");
                                break;
                            }
                    }
                }
                ct += 1;
            }
        }
        // Se foi fornecido algum campo especial
        if (Especial != "" & ct > 0)
            SQL += "," + Especial;
        else if (Especial != "")
            SQL += Especial;
        // Se for fornecido algum ID
        if (Tipo == "UPDATE" & id != -1)
            SQL += " WHERE id=" + id;
        // Maior que 8 porque é o comprimento dos comandos básicos
        if (SQL.Length > 8)
            return SQL;
        // Se não aconteceu nada retorna string.empty
        return string.Empty;
    }

    public static string valRepicador(ref object Lista)
    {
        object o;
        string varRepicador;
        ListBox.SelectedObjectCollection m = Lista.SelectedItems;

        // Se não tiver nada selecionado
        if (m.Count <= 0)
            // sai da rotina
            return string.Empty;
        // Senão processa cada item da lista
        varRepicador = "";
        foreach (var o in m)
        {
            // soma os numeros em varRepicador
            if (varRepicador.Length > 0)
                varRepicador += ";" + o.valor;
            else
                varRepicador = o.valor;
        }
        // debug
        Console.WriteLine(Constants.vbCrLf + "VarRepicador=" + varRepicador.ToString());
        // Verifica qual o retorno se deve dar
        if (varRepicador.Length > 0)
            return varRepicador;
        else
            return string.Empty;
    }

    public static double String_to_Numero(string Numero)
    {
        double Ret;
        // Converte Numero em uma string
        if (string.IsNullOrEmpty(Numero))
            return 0;

        // Converter string em número
        try
        {
            Ret = double.Parse(Numero, System.Globalization.NumberStyles.Any);
        }
        catch (FormatException ex)
        {
            Interaction.MsgBox("O Número não está em um formato válido!" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
            return;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Não foi possível converter uma string em Número com vírgula" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
            return;
        }

        return Ret;
    }

    public static string Numero_to_String(double Numero)
    {
        string Ret;
        Ret = Strings.Format(Numero, "N2");
        return Ret;
    }

    public static string Numero_to_SQL(string Numero)
    {
        string Ret;
        if (Numero == "" | Numero == "0,00" | Information.IsDBNull(Numero))
            return "0";
        Ret = Numero.Replace(".", "");
        Ret = Ret.Replace(",", ".");
        return Ret;
    }

    public static string Limpa_Formatacao(string Texto)
    {
        string Remover;
        int i;
        // Caracteres que devem ser removidos
        Remover = @"()*/-+_.,\";
        for (i = 1; i <= Strings.Len(Remover); i++)
            Texto = Texto.Replace(Strings.Mid(Remover, i, 1), "");
        return Texto;
    }

    public static bool ValidaCPF(string CPF)
    {
        int i, x, n1, n2;
        string[] dadosArray = new[] { "111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99" };
        CPF = CPF.Trim();
        for (i = 0; i <= dadosArray.Length - 1; i++)
        {
            if (CPF.Length < 11 | dadosArray[i].Equals(CPF))
                return false;
        }

        // Verifica se tem formatação
        if (CPF.IndexOf(".") > 0 | CPF.IndexOf("-") > 0)
            CPF = funcoesNfe.removeFormatacao(CPF);

        // Calcula o DV Módulo 10
        for (x = 0; x <= 1; x++)
        {
            n1 = 0;
            for (i = 0; i <= 8 + x; i++)
                n1 = n1 + Conversion.Val(CPF.Substring(i, 1)) * (10 + x - i);
            n2 = 11 - (n1 - (Conversion.Int(n1 / (double)11) * 11));
            if (n2 == 10 | n2 == 11)
                n2 = 0;
            if (n2 != Conversion.Val(CPF.Substring(9 + x, 1)))
                return false;
        }
        // Se validou retorna verdadeiro
        return true;
    }

    public static bool ValidaCNPJ(string CNPJ)
    {
        bool valida;
        CNPJ = CNPJ.Trim();

        // Limpa a formatação
        CNPJ = Limpa_Formatacao(CNPJ);

        valida = efetivaValidacao(CNPJ);

        if (valida)
            ValidaCNPJ = true;
        else
            ValidaCNPJ = false;
    }

    private static bool efetivaValidacao(string cnpj)
    {
        int[] Numero = new int[14];
        int soma;
        int i;
        int resultado1;
        int resultado2;
        for (i = 0; i <= Numero.Length - 1; i++)
            Numero[i] = System.Convert.ToInt32(cnpj.Substring(i, 1));
        soma = Numero[0] * 5 + Numero[1] * 4 + Numero[2] * 3 + Numero[3] * 2 + Numero[4] * 9 + Numero[5] * 8 + Numero[6] * 7 + Numero[7] * 6 + Numero[8] * 5 + Numero[9] * 4 + Numero[10] * 3 + Numero[11] * 2;
        soma = soma - (11 * (Conversion.Int(soma / (double)11)));
        if (soma == 0 | soma == 1)
            resultado1 = 0;
        else
            resultado1 = 11 - soma;

        if (resultado1 == Numero[12])
        {
            soma = Numero[0] * 6 + Numero[1] * 5 + Numero[2] * 4 + Numero[3] * 3 + Numero[4] * 2 + Numero[5] * 9 + Numero[6] * 8 + Numero[7] * 7 + Numero[8] * 6 + Numero[9] * 5 + Numero[10] * 4 + Numero[11] * 3 + Numero[12] * 2;
            soma = soma - (11 * (Conversion.Int(soma / (double)11)));
            if (soma == 0 | soma == 1)
                resultado2 = 0;
            else
                resultado2 = 11 - soma;
            if (resultado2 == Numero[13])
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static string FormataCpfCnpj(string strCpfCnpj)
    {
        if ((strCpfCnpj.Length <= 11))
        {
            MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00");
            mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11));
            return mtpCpf.ToString();
        }
        else
        {
            MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00");
            mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11));
            return mtpCnpj.ToString();
        }
    }

    public static string ZerosEsquerda(string strString, UInt16 intTamanho)
    {
        string strResult = "";
        for (UInt16 intCont = 1; intCont <= (intTamanho - strString.Length); intCont++)
            strResult += "0";
        return strResult + strString;
    }

    public static int DiasUteis(DateTime dataINI, DateTime dataFIM)
    {
        DateTime dtInicio;
        DateTime dtFinal;

        if (dataINI > dataFIM)
        {
            dtInicio = dataINI;
            dtFinal = dataFIM;
        }

        if (!Information.IsDate(dtInicio) | !Information.IsDate(dtFinal))
            return 0;
        int diff;
        int i;
        int intFimDias;

        diff = DateTime.DateDiff(DateInterval.Day, dtFinal, dtInicio);
        intFimDias = 0;

        for (i = 0; i <= diff; i += 1)
        {
            if ((DateTime.Weekday(DateTime.DateAdd(DateInterval.Day, i, dtInicio)) == Constants.vbSaturday) | (DateTime.Weekday(DateTime.DateAdd(DateInterval.Day, i, dtInicio)) != Constants.vbSunday))
                intFimDias += 1;
        }
        return intFimDias;
    }

    public static void Truncar(object Texto, object Tamanho)
    {
        // Se for vazio ou nulo
        if (Texto == string.Empty)
            return string.Empty;
        else if (Information.IsDBNull(Texto))
            return string.Empty;

        // Limita um texto à uma determinada quantidade de caracteres
        if ((Texto.Length <= Tamanho))
            return Texto;
        else
            return string.Format("{0}...", Texto.Substring(0, Tamanho));
    }
    public static string Nome_Repicadores(string Lista, bool Completo = false)
    {
        // Se for vazio
        if (Lista.Length <= 0 | Information.IsDBNull(Lista))
            return string.Empty;

        string Retorno = string.Empty;

        // Separa os nomes por vírgula
        string[] Rep;
        Rep = Lista.Split(";");
        int i = 1;
        string Nam = string.Empty;

        // Para cada Nome
        foreach (string Nome in Rep)
        {
            if (Completo)
            {
                if (i > 1)
                    Retorno += "/";
                Retorno += DLookup("Nome", "Repicador", "id=" + Nome);
            }
            else
            {
                if (i > 1)
                    Retorno += "/";
                Nam = DLookup("Nome", "Repicador", "id=" + Nome);
                Retorno += Interaction.IIf((Nam == "") | (Information.IsNothing(Nam)), "", Strings.Mid(Nam, 1, Strings.InStr(Nam, " ") - 1));
            }
            i += 1;
        }

        return Retorno;
    }

    public static string E_Vazio_Nulo(object Variavel)
    {

        // Verifica se é nulo
        if (Information.IsDBNull(Variavel))
            return string.Empty;
        else if (Information.IsNothing(Variavel))
            return string.Empty;
        else
            return Variavel.ToString();// Se não cair em nenhum dos casos, retorna o proprio valor convertido em string
    }

    public static void Desabilita_Campos(ref Form Formulario, string[] Nomes)
    {
        // Primeiro varre o formulário habilitando todos
        Control C;
        // Varre todos os controles do formulario
        foreach (var C in Formulario.Controls)
        {
            C.Enabled = true;
            // Se for um GroupBox faz a recursividade
            if (C is GroupBox)
            {
                for (int i = 0; i <= C.Controls.Count - 1; i++)
                    C.Controls[i].Enabled = true;
            }
        }

        // Agora varre novamente desabilitando o que não precisa ficar aceso
        // Varre todos os controles do formulario
        foreach (var C in Formulario.Controls)
        {
            if (Procura_Array(C.Name, ref Nomes))
                C.Enabled = false;
            // Se for um GroupBox faz a recursividade
            if (C is GroupBox)
            {
                for (int i = 0; i <= C.Controls.Count - 1; i++)
                {
                    if (Procura_Array(C.Controls[i].Name, ref Nomes))
                        C.Controls[i].Enabled = false;
                }
            }
        }
    }

    private static bool Procura_Array(string Nome, ref string[] Nomes)
    {
        for (int i = 0; i <= Nomes.Length - 1; i++)
        {
            if (Nome == Nomes[i])
                return true;
        }
        return false;
    }

    public static void Busca_Endereco(string CEP, ref EnderecoWEB Address)
    {
        try
        {
            // Dimensiona um novo DataSet
            DataSet ds = new DataSet();
            // Define o string do endereço de busca do CEP
            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
            ds.ReadXml(xml);
            Address.Tipo_Logradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString();
            Address.Logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString();
            Address.Bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
            Address.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
            Address.Uf = ds.Tables[0].Rows[0]["uf"].ToString();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Erro ao tentar localizar CEP" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical, "Erro");
        }
    }

    /// <summary>
    /// Função principal que recolhe o valor e chama as duas funções
    /// auxiliares para a parte inteira e para a parte decimal
    /// </summary>
    /// <param name="number">Número a converter para extenso (Reais)</param>
    public static string NumeroToExtenso(decimal number)
    {
        int cent;
        try
        {
            // se for =0 retorna 0 reais
            if (number == 0)
                return "Zero Reais";
            // Verifica a parte decimal, ou seja, os centavos
            cent = decimal.Round((number - Conversion.Int(number)) * 100, MidpointRounding.ToEven);
            // Verifica apenas a parte inteira
            number = Conversion.Int(number);
            // Caso existam centavos
            if (cent > 0)
            {
                // Caso seja 1 não coloca "Reais" mas sim "Real"
                if (number == 1)
                    return "Um Real e " + getDecimal(cent) + "centavos";
                else if (number == 0)
                    return getDecimal(cent) + "centavos";
                else
                    return getInteger(number) + "Reais e " + getDecimal(cent) + "centavos";
            }
            else
                // Caso seja 1 não coloca "Reais" mas sim "Real"
                if (number == 1)
                return "Um Real";
            else
                return getInteger(number) + "Reais";
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    /// <summary>
    /// Função auxiliar - Parte decimal a converter
    /// </summary>
    /// <param name="number">Parte decimal a converter</param>
    public static string getDecimal(byte number)
    {
        try
        {
            switch (number)
            {
                case 0:
                    {
                        return "";
                    }

                case object _ when 1 <= number && number <= 19:
                    {
                        string[] strArray = new[] { "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
                        return strArray[number - 1] + " ";
                    }

                case object _ when 20 <= number && number <= 99:
                    {
                        string[] strArray = new[] { "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };
                        if ((number % 10) == 0)
                            return strArray[number / 10 - 2] + " ";
                        else
                            return strArray[number / 10 - 2] + " e " + getDecimal(number % 10) + " ";
                        break;
                    }

                default:
                    {
                        return "";
                    }
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    /// <summary>
    /// Função auxiliar - Parte inteira a converter
    /// </summary>
    /// <param name="number">Parte inteira a converter</param>
    public static string getInteger(decimal number)
    {
        try
        {
            number = Conversion.Int(number);
            switch (number)
            {
                case object _ when number < 0:
                    {
                        return "-" + getInteger(-number);
                    }

                case 0:
                    {
                        return "";
                    }

                case object _ when 1 <= number && number <= 19:
                    {
                        string[] strArray = new[] { "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
                        return strArray[number - 1] + " ";
                    }

                case object _ when 20 <= number && number <= 99:
                    {
                        string[] strArray = new[] { "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };
                        if ((number % 10) == 0)
                            return strArray[number / 10 - 2];
                        else
                            return strArray[number / 10 - 2] + " e " + getInteger(number % 10);
                        break;
                    }

                case 100:
                    {
                        return "Cem";
                    }

                case object _ when 101 <= number && number <= 999:
                    {
                        string[] strArray = new[] { "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };
                        if ((number % 100) == 0)
                            return strArray[number / 100 - 1] + " ";
                        else
                            return strArray[number / 100 - 1] + " e " + getInteger(number % 100);
                        break;
                    }

                case object _ when 1000 <= number && number <= 1999:
                    {
                        switch ((number % 1000))
                        {
                            case 0:
                                {
                                    return "Mil";
                                }

                            case object _ when (number % 1000) <= 100:
                                {
                                    return "Mil e " + getInteger(number % 1000);
                                }

                            default:
                                {
                                    return "Mil, " + getInteger(number % 1000);
                                }
                        }

                        break;
                    }

                case object _ when 2000 <= number && number <= 999999:
                    {
                        switch ((number % 1000))
                        {
                            case 0:
                                {
                                    return getInteger(number / 1000) + "Mil";
                                }

                            case object _ when (number % 1000) <= 100:
                                {
                                    return getInteger(number / 1000) + "Mil e " + getInteger(number % 1000);
                                }

                            default:
                                {
                                    return getInteger(number / 1000) + "Mil, " + getInteger(number % 1000);
                                }
                        }

                        break;
                    }

                case object _ when 1000000 <= number && number <= 1999999:
                    {
                        switch ((number % 1000000))
                        {
                            case 0:
                                {
                                    return "Um Milhão";
                                }

                            case object _ when (number % 1000000) <= 100:
                                {
                                    return getInteger(number / 1000000) + "Milhão e " + getInteger(number % 1000000);
                                }

                            default:
                                {
                                    return getInteger(number / 1000000) + "Milhão, " + getInteger(number % 1000000);
                                }
                        }

                        break;
                    }

                case object _ when 2000000 <= number && number <= 999999999:
                    {
                        switch ((number % 1000000))
                        {
                            case 0:
                                {
                                    return getInteger(number / 1000000) + " Milhões";
                                }

                            case object _ when (number % 1000000) <= 100:
                                {
                                    return getInteger(number / 1000000) + "Milhões e " + getInteger(number % 1000000);
                                }

                            default:
                                {
                                    return getInteger(number / 1000000) + "Milhões, " + getInteger(number % 1000000);
                                }
                        }

                        break;
                    }

                case object _ when 1000000000 <= number && number <= 1999999999:
                    {
                        switch ((number % 1000000000))
                        {
                            case 0:
                                {
                                    return "Um Bilhão";
                                }

                            case object _ when (number % 1000000000) <= 100:
                                {
                                    return getInteger(number / 1000000000) + "Bilhão e " + getInteger(number % 1000000000);
                                }

                            default:
                                {
                                    return getInteger(number / 1000000000) + "Bilhão, " + getInteger(number % 1000000000);
                                }
                        }

                        break;
                    }

                default:
                    {
                        switch ((number % 1000000000))
                        {
                            case 0:
                                {
                                    return getInteger(number / 1000000000) + " Bilhões";
                                }

                            case object _ when (number % 1000000000) <= 100:
                                {
                                    return getInteger(number / 1000000000) + "Bilhões e " + getInteger(number % 1000000000);
                                }

                            default:
                                {
                                    return getInteger(number / 1000000000) + "Bilhões, " + getInteger(number % 1000000000);
                                }
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static string HoraFormatoUTC(DateTime DataHora)
    {
        string UTC = string.Empty;
        string fusoHorario = string.Empty;
        // informar a data de emissão do Documento Fiscal no padrão UTC - Universal Coordinated Time
        // onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00(Manaus)
        // no horário de verão serão - 01:00, -02:00 e -03:00
        // Ex.: 2010-08-19T13:00:15-03:00.

        if (DLookup("valor", "parametros", "Nome='NFeHoraVerao'") == 1)
            fusoHorario = "-02:00";
        else
            fusoHorario = "-03:00";
        // Monta a string no formato correto
        UTC = Strings.Format(DataHora, "yyy-MM-dd") + "T" + Strings.Format(DataHora, "HH:mm:ss") + fusoHorario;
        // retorna
        // Debug
        Console.WriteLine("UTC: " + UTC);
        return UTC;
    }

    // Função que pega a stream de uma imagem e salva no Banco de dados para ser usado
    public static System.Drawing.Image GetImage(string URL)
    {
        // Um objeto para mandar a requisição para o servidor
        System.Net.HttpWebRequest Request;
        // Um objeto para pegar o retorno
        System.Net.HttpWebResponse Response;
        System.Drawing.Image Retorno;

        // Contactar o servidor para tentar pegar a imagem que precisamos
        try
        {
            // Criar o objeto Request com a url recebida como parâmetro
            Request = System.Net.WebRequest.Create(URL);
            // Pega o retorno do servidor e faz um cast para transformar no formato do objeto que precisamos
            Response = (System.Net.WebResponse)Request.GetResponse();

            if (Request.HaveResponse)
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Se a resposta estiver OK (código 200) então podemos carregar a imagem
                    // A Função FROMSTREAM cria uma imagem a partir da stream recebida
                    Retorno = System.Drawing.Image.FromStream(Response.GetResponseStream());
                    return Retorno;
                }
            }
        }
        catch (WebException e)
        {
            Interaction.MsgBox("Ocorreu um erro ao pegar o endereço [" + URL + "]." + Constants.vbCrLf + " O sistema retornou: " + e.Message, MsgBoxStyle.Exclamation, "Erro!");
            break;
        }
        catch (ProtocolViolationException e)
        {
            Interaction.MsgBox("Uma violação de protocolo ocorreu [" + URL + "]." + Constants.vbCrLf + "  O sistema retornou: " + e.Message, MsgBoxStyle.Exclamation, "Erro!");
            break;
        }
        catch (SocketException e)
        {
            Interaction.MsgBox("Erro de soquete [" + URL + "]." + Constants.vbCrLf + "  O sistema retornou: " + e.Message, MsgBoxStyle.Exclamation, "Erro!");
            break;
        }
        catch (EndOfStreamException e)
        {
            Interaction.MsgBox("Ocorreu um erro de IO. O sistema retornou: " + e.Message, MsgBoxStyle.Exclamation, "Erro!");
            break;
        }
        finally
        {
        }
        return null;
    }
}



