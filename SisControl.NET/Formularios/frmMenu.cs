// Importa algumas variaveis do sistema
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
using System.Net;
using System.Net.Sockets;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Win32;

// Imports System.Windows.Forms.Ribbon


public partial class frmMenu
{
    private void mniSair_Click(System.Object sender, System.EventArgs e)
    {
        // Fecha o programa
        Application.Exit();
    }

    private void mniConfiguracao_Click(System.Object sender, System.EventArgs e)
    {
        // Cria uma nova instancia do objeto frmConfig
        frmConfig Child = new frmConfig();
        // Define quem é o parent
        Child.MdiParent = this;
        // Centraliza formulario
        Child.StartPosition = FormStartPosition.CenterParent;
        // Mostra o formulário
        Child.Show();
    }



    private void frmMenu_Load(System.Object sender, System.EventArgs e)
    {

        // Pega a informação da versão do arquivo
        FileVersionInfo myBuildInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
        // Painel de Versao
        System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        sbpVersao.Text = "Versão: " + version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;

        // Monta Conection string
        Biblioteca.MY_SQL_CONNECTION = "server=" + Constantes.myIP + ";" + "user id=" + My.Settings.MyUsername + ";" + "password=" + My.Settings.MyPassword + ";" + "database=" + My.Settings.MyDB;

        // * Faz os procedimentos de login
        frmLogin log = new frmLogin();
        log.Parent = this.Parent;
        // Mostra de forma modal obrigando a pessoa a digitar aqui
        log.ShowDialog();
        // Libera memoria
        log = null;
        sbpUser.Text = "Usuário: " + Constantes.User.Nome.Substring(0, Constantes.User.Nome.IndexOf(" "));


        // Painel de IP
        sbpIP.Text = "IP Servidor: " + Constantes.myIP;

        if (Constantes.Conectado)
        {
            uint nfeAmbiente = 0;
            // Verifica no Banco de dados qual o ambiente
            nfeAmbiente = Biblioteca.DLookup("Valor", "Parametros", "Nome='NFeAmbiente'");
            // Mostra na barra de status e também defini isso na variável de ambiente.
            sbpNFe.Text = "NFe: " + Interaction.IIf(nfeAmbiente == 1, "Produção", "Homologação");
            My.Settings.NFeAmbiente = nfeAmbiente;
        }

        // Definido no arquivo de configuração
        Biblioteca.MY_SQL_CONNECTION_WEB = My.Settings.MyRemote;
        Biblioteca.DS_MYSQL_CONNECTION = "server=" + Constantes.myIP + ";user id=" + My.Settings.MyUsername + ";database=" + My.Settings.MyDB + ";persist security info=True;password=" + My.Settings.MyPassword;
        // Para Debug tem que deixar, mas para compilação tem que colocar
        My.Settings.csControle = Biblioteca.DS_MYSQL_CONNECTION;

        // Aplica as permissões nos menus
        aplica_permissao();

        // Verifica se vai mostrar a agenda de isolamentos ou não
        if (My.Settings.ShowSchl)
        {
            frmAgendaIsol frm = new frmAgendaIsol();
            // Define que é mdichild
            frm.MdiParent = this;
            // Mostra formulário
            frm.Show();
        }
    }

    private void mniLotes_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmLotes Child = new frmLotes();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }


    private void mniPesquisa_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Pesquisa
        frmPesquisa Child = new frmPesquisa();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ImpressãoDeEtiquetasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Pesquisa
        frmEtiquetas Child = new frmEtiquetas();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void MeiosDeCulturaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Pesquisa
        frmMeios Child = new frmMeios();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void MercadoriasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Pesquisa
        frmMercadoria Child = new frmMercadoria();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ferLotes_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmLotes Child = new frmLotes();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void CadastroToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmClientes Child = new frmClientes();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ferClientes_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmClientes Child = new frmClientes();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ImpressãoDeFichasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmOLEFichas Child = new frmOLEFichas();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ServiçosPorCódigoDeBarrasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmServCodBar Child = new frmServCodBar();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void ferBarras_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmServCodBar Child = new frmServCodBar();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void CadastroDeFuncionáriosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmFuncionario Child = new frmFuncionario();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void CadastroDeProdutosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo formulário Lotes
        frmWEBProdutos Child = new frmWEBProdutos();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra formulário
        Child.Show();
    }

    private void MenuDeRelatórisoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRelatorios child = new frmRelatorios();
        // Define que é mdichild
        child.MdiParent = this;
        // Mostra formulário
        child.Show();
    }

    private void ToolStripButton1_Click(System.Object sender, System.EventArgs e)
    {
        frmEtiquetas child = new frmEtiquetas();
        // Define que é mdichild
        child.MdiParent = this;
        // Mostra formulário
        child.Show();
    }

    private void mniPlantio_Click(System.Object sender, System.EventArgs e)
    {
        frmPlantio child = new frmPlantio();
        // Define que é mdichild
        child.MdiParent = this;
        // Mostra formulário
        child.Show();
    }

    private void ferPlantio_Click(System.Object sender, System.EventArgs e)
    {
        // Usa a sub definida no menu
        mniPlantio_Click(sender, e);
    }

    private void RepicadoresToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRepicadores child = new frmRepicadores();
        // Define que é mdiChild
        child.MdiParent = this;
        child.Show();
    }

    private void CondiçõeDePagamentoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmForPag child = new frmForPag();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void FornecedoresToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmFornecedores child = new frmFornecedores();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void CategoriasFinanceirasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmCategoriasFin child = new frmCategoriasFin();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void ContasAPagarToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmContasPagar child = new frmContasPagar();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void ContasAReceberToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmContasReceber child = new frmContasReceber();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void PlanoDeContasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmPlanoContas child = new frmPlanoContas();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void BaixaDeLançamentosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmBaixaLancamentos child = new frmBaixaLancamentos();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void CalculadoraDeHormôniosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmHormonios child = new frmHormonios();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void CalculadoraDeConcentraçõesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmConcentracoes child = new frmConcentracoes();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void AtribuiçãoDeLotesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmAplicaClientes child = new frmAplicaClientes();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void RrecToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRecuperacao child = new frmRecuperacao();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void ProdutividadeDeRepicadoresToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmProdutividade child = new frmProdutividade();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void ResumoPedidosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Chama direto a SUB que faz o resumo. Sem precisar de Interface
        ExportExcel.Resumo_Pedidos();
    }

    private void DigitaçãoDePedidosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmPedidos child = new frmPedidos();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void AlteraçãoDeLotesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmAlteracaoLote child = new frmAlteracaoLote();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void LançamentosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmLancamentoContab child = new frmLancamentoContab();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void AlteraçãoSalarialToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmAltSalarial child = new frmAltSalarial();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void MapaDeProduçãoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Executa a Rotina de Exportação para Excel
        ExportExcel.Resumo_Producao();
    }

    private void ControleDeEntregasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmEntregas child = new frmEntregas();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void TesteToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmEtiquetaORQ child = new frmEtiquetaORQ();
        // Define que é MDI child
        child.MdiParent = this;
        child.Show();
    }

    private void GerminaçãoDeOrquídeasToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmOrquideas Child = new frmOrquideas();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void RecálculoDoEstoqueToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        string SQL;
        int a;
        SQL = "UPDATE germinacao SET NSementes=(SELECT COUNT(id) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='S'),Nmudas=(SELECT SUM(nmudas) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='M'),Frascos=(SELECT COUNT(id) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='M')";
        a = Interaction.MsgBox("Tem certeza de que quer recalcular o estoque de orquídeas baseando-se" + Constants.vbCrLf + "em seus frascos em estoque?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação");
        if (a == Constants.vbYes)
        {
            // Tenta executar a sql padrão
            try
            {
                Biblioteca.ExecutaSQL(SQL);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar recalcular o estoque de orquídeas. Verifique o banco de dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro");
                return;
            }
        }
    }

    private void RepicagemDeOrquídeasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmOrquideasMan Child = new frmOrquideasMan();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ConsultaDePedidosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmManutPedidos Child = new frmManutPedidos();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ClonesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmCadastroClones Child = new frmCadastroClones();
        // Define que é mdichild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ConsultaDeLançamentosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmVisualizaLancamentos Child = new frmVisualizaLancamentos();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void BandejaMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetasBDJ Child = new frmEtiquetasBDJ();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void FaturarPedidoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFeFatura Child = new frmNFeFatura();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void DocumentoDeSaídaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFeDocumento Child = new frmNFeDocumento(1);   // 1-Saida 0-Entrada
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ConsultarNFeToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFEConsulta Child = new frmNFEConsulta();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void PlantioDeOrquídeasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmPlantioOrquideas Child = new frmPlantioOrquideas();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ManejoDaEstufaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmTratosCulturais Child = new frmTratosCulturais();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void FechamentoDeMêsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFEFechamento Child = new frmNFEFechamento();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void DocumentoDeEntradaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        // Como parametro 1-Saida 0-Entrada
        frmNFeDocumento Child = new frmNFeDocumento(0);
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton2_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetaORQ Child = new frmEtiquetaORQ();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton3_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetasBDJ Child = new frmEtiquetasBDJ();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton5_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmRelatorios Child = new frmRelatorios();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton4_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmOrquideas Child = new frmOrquideas();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void BackupDoBancoDeDadosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmBackup Child = new frmBackup();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void FluxoDeCaixaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmFluxo_Caixa Child = new frmFluxo_Caixa();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void HistóricosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmHistoricos Child = new frmHistoricos();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsPlantio_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmPlantio Child = new frmPlantio();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsbLotes_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNovoLotes Child = new frmNovoLotes();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsbCodServ_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmServCodBar Child = new frmServCodBar();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsAlteracao_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmAlteracaoLote Child = new frmAlteracaoLote();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton1_Click_1(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetas Child = new frmEtiquetas();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsbOrquideas_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetaORQ Child = new frmEtiquetaORQ();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsbBandejas_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmEtiquetasBDJ Child = new frmEtiquetasBDJ();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ToolStripButton2_Click_1(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmClientes Child = new frmClientes();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void tsRelatorios_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmRelatorios Child = new frmRelatorios();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ContasAPagarToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmContasPagar Child = new frmContasPagar();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ContasAReceberToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmContasReceber Child = new frmContasReceber();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void DocumentosDeEntradaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        // Como parametro 1-Saida 0-Entrada
        frmNFeDocumento Child = new frmNFeDocumento(0);
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void DocumentosDeSaídaToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        // Como parametro 1-Saida 0-Entrada
        frmNFeDocumento Child = new frmNFeDocumento(1);
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }


    private void GerenciamentoDeNFeToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFeFatura Child = new frmNFeFatura();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void FechamentoDeMêsToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmNFEFechamento Child = new frmNFEFechamento();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void ContatosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmContatos Child = new frmContatos();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void GerarBoletosBancáriosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
    }

    private void ImportarArquivoDoBancoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmImportOFXData Child = new frmImportOFXData();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void SimuladorDeProduçãoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmSimulador Child = new frmSimulador();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void TransportadorasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        // Cria um novo form orquideas
        frmTransportadoras Child = new frmTransportadoras();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }

    private void aplica_permissao()
    {

        // Se não estiver conectado já aborta o processo
        if (!Constantes.Conectado)
        {
            Interaction.MsgBox("Não é possível aplicar as restrições, pois o servidor não está conectado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly);
            return;
        }

        // Desabilita todos
        for (int i = 0; i <= msMenu_Principal.Items.Count - 1; i++)
            ;/* Cannot convert AssignmentStatementSyntax, System.ArgumentOutOfRangeException: O índice estava fora do intervalo. Ele deve ser não-negativo e menor que o tamanho da coleção.
Nome do parâmetro: index
   em System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<>c__DisplayClass83_0.<ConvertArguments>b__0(ArgumentSyntax a, Int32 i)
   em System.Linq.Enumerable.<SelectIterator>d__5`2.MoveNext()
   em System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   em Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitAssignmentStatement(AssignmentStatementSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.AssignmentStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
            msMenu_Principal.Items(i).Enabled = False

 */
        // Pega a permissão do usuário e começa a habilitar somente os que são permitidos
        string per = "";
        // Procura no banco de dados o que pode
        per = Biblioteca.DLookup("Principal", "permissoes", "id=" + Constantes.User.Permissao);
        // Tem que ver se o comprimento é igual ao número de ítens
        if ((per.Length == msMenu_Principal.Items.Count))
        {
            // vai atribuindo as permissoes ao menu principal
            for (int i = 0; i <= per.Length - 1; i++)
                ;/* Cannot convert AssignmentStatementSyntax, System.ArgumentOutOfRangeException: O índice estava fora do intervalo. Ele deve ser não-negativo e menor que o tamanho da coleção.
Nome do parâmetro: index
   em System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<>c__DisplayClass83_0.<ConvertArguments>b__0(ArgumentSyntax a, Int32 i)
   em System.Linq.Enumerable.<SelectIterator>d__5`2.MoveNext()
   em System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   em Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitAssignmentStatement(AssignmentStatementSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.AssignmentStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
                msMenu_Principal.Items(i).Enabled = IIf(per.Substring(i, 1) = 1, True, False)

 */
        }
        else
            return;

        // Percorre cada um dos submenus
        Sub_Menu("Arquivo", ref mnpArquivo);
        Sub_Menu("Producao", ref mnpProducao);
        Sub_Menu("Clientes", ref mnpClientes);
        Sub_Menu("Pedidos", ref mnpPedidos);
        Sub_Menu("RH", ref mnpRH);
        Sub_Menu("Financeiro", ref mnpFinanceiro);
        Sub_Menu("Ferramentas", ref mnpFerramentas);
        Sub_Menu("Relatorios", ref mnpRelatorios);
        Sub_Menu("Sistema", ref mnpSistema);
        Sub_Menu("web", ref mnpWEB);

        // *
        // * Aplica as permissoes na barra de menu
        // *

        per = Biblioteca.DLookup("Barra", "permissoes", "id=" + Constantes.User.Permissao);
        if ((per.Length == tsMenu.Items.Count))
        {
            for (int i = 0; i <= tsMenu.Items.Count - 1; i++)
                ;/* Cannot convert AssignmentStatementSyntax, System.ArgumentOutOfRangeException: O índice estava fora do intervalo. Ele deve ser não-negativo e menor que o tamanho da coleção.
Nome do parâmetro: index
   em System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitSimpleArgument(SimpleArgumentSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.SimpleArgumentSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<>c__DisplayClass83_0.<ConvertArguments>b__0(ArgumentSyntax a, Int32 i)
   em System.Linq.Enumerable.<SelectIterator>d__5`2.MoveNext()
   em System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   em Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitArgumentList(ArgumentListSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.ArgumentListSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitInvocationExpression(InvocationExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitAssignmentStatement(AssignmentStatementSyntax node)
   em Microsoft.CodeAnalysis.VisualBasic.Syntax.AssignmentStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   em Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   em ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
                'Procura a permissao da barra para os usuários
                tsMenu.Items(i).Enabled = IIf(per.Substring(i, 1) = 1, True, False)

 */
        }
    }

    private void Sub_Menu(string Menu, ref ToolStripMenuItem objMenu)
    {
        string per;
        per = Biblioteca.DLookup(Menu, "permissoes", "id=" + Constantes.User.Permissao);
        // Tem que ver se o comprimento é igual ao número de ítens
        if ((per.Length == objMenu.DropDownItems.Count))
        {
            // vai atribuindo as permissoes ao menu principal
            for (int i = 0; i <= per.Length - 1; i++)
                objMenu.DropDownItems[i].Enabled = Interaction.IIf(per.Substring(i, 1) == 1, true, false);
        }
    }

    private void CadastroDePermissõesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmCadastroGrupos Child = new frmCadastroGrupos();
        Child.MdiParent = this;
        Child.Show();
    }

    private void EtiquetasParaClientesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmSelecaoClientesEtiquetas Child = new frmSelecaoClientesEtiquetas();
        Child.MdiParent = this;
        Child.Show();
    }

    private void RastreamentoDeLotesToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRastreamentoLotes Child = new frmRastreamentoLotes();
        Child.MdiParent = this;
        Child.Show();
    }

    private void OrdensDeProduçãoToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        frmProgramacaoSemanal Child = new frmProgramacaoSemanal();
        Child.MdiParent = this;
        Child.Show();
    }

    private void RetornoDeFrascosParaEstoqueToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmEntrada_Frascos Child = new frmEntrada_Frascos();
        Child.MdiParent = this;
        Child.Show();
    }

    private void ProgramaçãoSemanalToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRelProgramacao Child = new frmRelProgramacao();
        Child.MdiParent = this;
        Child.Show();
    }

    private void ManutençãoDeLançamentosToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmManutLancam Child = new frmManutLancam();
        Child.MdiParent = this;
        Child.Show();
    }

    private void ReservasToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmReservas Child = new frmReservas();
        Child.MdiParent = this;
        Child.Show();
    }

    private void InventárioToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmInventario Child = new frmInventario();
        Child.MdiParent = this;
        Child.Show();
    }

    private void txtOrdemProducao_Leave(System.Object sender, System.EventArgs e)
    {
        DataRow DR;
        int OP = -1;

        // Se houver algo válido digitado
        if (txtOrdemProducao.Text.Length > 3 & IsNumeric(txtOrdemProducao.Text))
        {
            OP = txtOrdemProducao.Text;
            txtOrdemProducao.Text = string.Empty;
            // Coloca o cursor em posição de espera
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Pega os dados da Ordem de Produção e Preenche na ficha
                DR = Biblioteca.DLookupRow("programacao", "id=" + Conversion.Int(OP));
                // Se não achou nada e DR está vazio sai da rotina
                if (Information.IsDBNull(DR) | Information.IsNothing(DR))
                {
                    Interaction.MsgBox("Não foi possível localizar a Ordem de Produção Nº: " + OP, MsgBoxStyle.Critical + Constants.vbOKOnly, "Erro");
                    txtOrdemProducao.Text = string.Empty;
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Erro ao tentar localizar a ordem de produção" + Constants.vbCrLf + ex.Message, MsgBoxStyle.Critical + Constants.vbOKOnly, "Erro");
                txtOrdemProducao.Text = string.Empty;
                this.Cursor = Cursors.Arrow;
                return;
            }

            // Se deu certo segue vendo que tipo de OP se trata

            if (DR["Tipo"] == "R")
            {
                frmNovoLotes child = new frmNovoLotes("O", OP);
                child.MdiParent = this;
                // Mostra o formulário
                child.Show();
                this.Cursor = Cursors.Arrow;
            }
            else if (DR["Tipo"] == "P")
            {
                frmPlantio child = new frmPlantio(OP);
                child.MdiParent = this;
                // Mostra o formulário
                child.Show();
            }
            else if (DR["Tipo"] == "G")
            {
                string a;
                a = Interaction.InputBox("Esta é uma ordem de Serviços Direta." + Constants.vbCrLf + "Digite a data da Baixa no campo abaixo para concluir esta Ordem de Serviço", "Data da Baixa");
                // Se o usuário colocou alguma informação
                if (a != string.Empty)
                {
                    Biblioteca.ExecutaSQL("UPDATE Programacao SET DataBaixa='" + Strings.Format((DateTime)a, "yyyy-MM-dd") + "' WHERE id=" + OP);
                    Interaction.MsgBox("Ordem de produção concluída com sucesso!");
                    this.Cursor = Cursors.Arrow;
                }
            }
        }
    }


    private void txtOrdemProducao_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        Biblioteca.EnterAsTab(sender, ref e);
    }

    private void PlanejamentoDeProduçãoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmPlanejamentoProducao Child = new frmPlanejamentoProducao();
        Child.MdiParent = this;
        Child.Show();
    }

    private void tsPesquisa_Lotes_Click(System.Object sender, System.EventArgs e)
    {
        frmPesquisa Child = new frmPesquisa();
        Child.MdiParent = this;
        Child.Show();
    }

    private void EmissãoDeReciboDePagamentoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
    {
        frmRecibo Child = new frmRecibo();
        Child.MdiParent = this;
        Child.Show();
    }

    private void FunilDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmCRMVendas Child = new frmCRMVendas();
        Child.MdiParent = this;
        Child.Show();
    }

    private void MapaProduçãoComercializaçãoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmMapa_Comercializacao Child = new frmMapa_Comercializacao();
        Child.MdiParent = this;
        Child.Show();
    }

    private void NovoLotesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmNovoLotes Child = new frmNovoLotes();
        Child.MdiParent = this;
        Child.Show();
    }

    private void NovoLotesidToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmNovoLotes Child = new frmNovoLotes("L", 8605);
        Child.MdiParent = this;
        Child.Show();
    }

    private void CRMTrelloToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmWEB_Trello Child = new frmWEB_Trello();
        Child.MdiParent = this;
        Child.Show();
    }

    private void ImpressãoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Cria um novo form orquideas
        frmEmissaoBoletos Child = new frmEmissaoBoletos();
        // Define que é MDIChild
        Child.MdiParent = this;
        // Mostra o formulário
        Child.Show();
    }
}

