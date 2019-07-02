'Importa algumas variaveis do sistema
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Data
Imports Microsoft.Win32

'Imports System.Windows.Forms.Ribbon


Public Class frmMenu


    Private Sub mniSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSair.Click
        'Fecha o programa
        Application.Exit()
    End Sub

    Private Sub mniConfiguracao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniConfiguracao.Click
        'Cria uma nova instancia do objeto frmConfig
        Dim Child As New frmConfig
        'Define quem � o parent
        Child.MdiParent = Me
        'Centraliza formulario
        Child.StartPosition = FormStartPosition.CenterParent
        'Mostra o formul�rio
        Child.Show()
    End Sub



    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Pega a informa��o da vers�o do arquivo
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        'Painel de Versao
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version

        sbpVersao.Text = "Vers�o: " & version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision

        'Monta Conection string
        MY_SQL_CONNECTION = "server=" & myIP & ";" & _
            "user id=" & My.Settings.MyUsername & ";" & _
            "password=" & My.Settings.MyPassword & ";" & _
            "database=" & My.Settings.MyDB

        '* Faz os procedimentos de login
        Dim log As New frmLogin
        log.Parent = Me.Parent
        'Mostra de forma modal obrigando a pessoa a digitar aqui
        log.ShowDialog()
        'Libera memoria
        log = Nothing
        sbpUser.Text = "Usu�rio: " & User.Nome.Substring(0, User.Nome.IndexOf(" "))


        'Painel de IP
        sbpIP.Text = "IP Servidor: " & myIP

        If Conectado Then
            Dim nfeAmbiente As UInteger = 0
            'Verifica no Banco de dados qual o ambiente
            nfeAmbiente = DLookup("Valor", "Parametros", "Nome='NFeAmbiente'")
            'Mostra na barra de status e tamb�m defini isso na vari�vel de ambiente.
            sbpNFe.Text = "NFe: " & IIf(nfeAmbiente = 1, "Produ��o", "Homologa��o")
            My.Settings.NFeAmbiente = nfeAmbiente
        End If

        'Definido no arquivo de configura��o
        MY_SQL_CONNECTION_WEB = My.Settings.MyRemote
        DS_MYSQL_CONNECTION = "server=" & myIP & ";user id=" & My.Settings.MyUsername & ";database=" & My.Settings.MyDB & ";persist security info=True;password=" & My.Settings.MyPassword
        'Para Debug tem que deixar, mas para compila��o tem que colocar
        My.Settings.csControle = DS_MYSQL_CONNECTION

        'Aplica as permiss�es nos menus
        aplica_permissao()

        'Verifica se vai mostrar a agenda de isolamentos ou n�o
        If My.Settings.ShowSchl Then
            Dim frm As New frmAgendaIsol
            'Define que � mdichild
            frm.MdiParent = Me
            'Mostra formul�rio
            frm.Show()
        End If
    End Sub

    Private Sub mniLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cria um novo formul�rio Lotes
        Dim Child As New frmLotes
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub


    Private Sub mniPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPesquisa.Click
        'Cria um novo formul�rio Pesquisa
        Dim Child As New frmPesquisa
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub Impress�oDeEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Impress�oDeEtiquetasToolStripMenuItem.Click
        'Cria um novo formul�rio Pesquisa
        Dim Child As New frmEtiquetas
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub MeiosDeCulturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeiosDeCulturaToolStripMenuItem.Click
        'Cria um novo formul�rio Pesquisa
        Dim Child As New frmMeios
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub MercadoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MercadoriasToolStripMenuItem.Click
        'Cria um novo formul�rio Pesquisa
        Dim Child As New frmMercadoria
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub ferLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cria um novo formul�rio Lotes
        Dim Child As New frmLotes
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroToolStripMenuItem.Click
        'Cria um novo formul�rio Lotes
        Dim Child As New frmClientes
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub ferClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cria um novo formul�rio Lotes
        Dim Child As New frmClientes
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub Impress�oDeFichasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Impress�oDeFichasToolStripMenuItem.Click
        'Cria um novo formul�rio Lotes
        Dim Child As New frmOLEFichas
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub Servi�osPorC�digoDeBarrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servi�osPorC�digoDeBarrasToolStripMenuItem.Click
        'Cria um novo formul�rio Lotes
        Dim Child As New frmServCodBar
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub ferBarras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cria um novo formul�rio Lotes
        Dim Child As New frmServCodBar
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub CadastroDeFuncion�riosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroDeFuncion�riosToolStripMenuItem.Click
        'Cria um novo formul�rio Lotes
        Dim Child As New frmFuncionario
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub CadastroDeProdutosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroDeProdutosToolStripMenuItem.Click
        'Cria um novo formul�rio Lotes
        Dim Child As New frmWEBProdutos
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra formul�rio
        Child.Show()
    End Sub

    Private Sub MenuDeRelat�risoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDeRelat�risoToolStripMenuItem.Click
        Dim child As New frmRelatorios
        'Define que � mdichild
        child.MdiParent = Me
        'Mostra formul�rio
        child.Show()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim child As New frmEtiquetas
        'Define que � mdichild
        child.MdiParent = Me
        'Mostra formul�rio
        child.Show()
    End Sub

    Private Sub mniPlantio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPlantio.Click
        Dim child As New frmPlantio
        'Define que � mdichild
        child.MdiParent = Me
        'Mostra formul�rio
        child.Show()
    End Sub

    Private Sub ferPlantio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Usa a sub definida no menu
        mniPlantio_Click(sender, e)
    End Sub

    Private Sub RepicadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepicadoresToolStripMenuItem.Click
        Dim child As New frmRepicadores
        'Define que � mdiChild
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Condi��eDePagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Condi��eDePagamentoToolStripMenuItem.Click
        Dim child As New frmForPag
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub FornecedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FornecedoresToolStripMenuItem.Click
        Dim child As New frmFornecedores
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub CategoriasFinanceirasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriasFinanceirasToolStripMenuItem.Click
        Dim child As New frmCategoriasFin
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub ContasAPagarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContasAPagarToolStripMenuItem.Click
        Dim child As New frmContasPagar
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub ContasAReceberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContasAReceberToolStripMenuItem.Click
        Dim child As New frmContasReceber
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub PlanoDeContasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanoDeContasToolStripMenuItem.Click
        Dim child As New frmPlanoContas
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BaixaDeLan�amentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaixaDeLan�amentosToolStripMenuItem.Click
        Dim child As New frmBaixaLancamentos
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub CalculadoraDeHorm�niosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculadoraDeHorm�niosToolStripMenuItem.Click
        Dim child As New frmHormonios
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub CalculadoraDeConcentra��esToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculadoraDeConcentra��esToolStripMenuItem.Click
        Dim child As New frmConcentracoes
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Atribui��oDeLotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Atribui��oDeLotesToolStripMenuItem.Click
        Dim child As New frmAplicaClientes
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()

    End Sub

    Private Sub RrecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RrecToolStripMenuItem.Click
        Dim child As New frmRecuperacao
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub ProdutividadeDeRepicadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProdutividadeDeRepicadoresToolStripMenuItem.Click
        Dim child As New frmProdutividade
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub ResumoPedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumoPedidosToolStripMenuItem.Click
        'Chama direto a SUB que faz o resumo. Sem precisar de Interface
        Resumo_Pedidos()
    End Sub

    Private Sub Digita��oDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Digita��oDePedidosToolStripMenuItem.Click
        Dim child As New frmPedidos
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Altera��oDeLotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Altera��oDeLotesToolStripMenuItem.Click
        Dim child As New frmAlteracaoLote
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Lan�amentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lan�amentosToolStripMenuItem.Click
        Dim child As New frmLancamentoContab
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Altera��oSalarialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Altera��oSalarialToolStripMenuItem.Click
        Dim child As New frmAltSalarial
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub MapaDeProdu��oToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MapaDeProdu��oToolStripMenuItem.Click
        'Executa a Rotina de Exporta��o para Excel
        Resumo_Producao()
    End Sub

    Private Sub ControleDeEntregasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControleDeEntregasToolStripMenuItem.Click
        Dim child As New frmEntregas
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub TesteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TesteToolStripMenuItem.Click
        Dim child As New frmEtiquetaORQ
        'Define que � MDI child
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub Germina��oDeOrqu�deasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Germina��oDeOrqu�deasToolStripMenuItem1.Click
        'Cria um novo form orquideas
        Dim Child As New frmOrquideas
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub Rec�lculoDoEstoqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rec�lculoDoEstoqueToolStripMenuItem.Click
        Dim SQL As String, a As Integer
        SQL = "UPDATE germinacao SET NSementes=(SELECT COUNT(id) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='S'),Nmudas=(SELECT SUM(nmudas) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='M'),Frascos=(SELECT COUNT(id) FROM aux_germinacao WHERE lote=germinacao.id AND tipo='M')"
        a = MsgBox("Tem certeza de que quer recalcular o estoque de orqu�deas baseando-se" & vbCrLf & "em seus frascos em estoque?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
        If a = vbYes Then
            'Tenta executar a sql padr�o
            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar recalcular o estoque de orqu�deas. Verifique o banco de dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub RepicagemDeOrqu�deasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepicagemDeOrqu�deasToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmOrquideasMan
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ConsultaDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDePedidosToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmManutPedidos
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ClonesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClonesToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmCadastroClones
        'Define que � mdichild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ConsultaDeLan�amentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDeLan�amentosToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmVisualizaLancamentos
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub BandejaMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BandejaMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetasBDJ
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub FaturarPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaturarPedidoToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFeFatura
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub DocumentoDeSa�daToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentoDeSa�daToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFeDocumento(1)   '1-Saida 0-Entrada
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ConsultarNFeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarNFeToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFEConsulta
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub PlantioDeOrqu�deasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantioDeOrqu�deasToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmPlantioOrquideas
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ManejoDaEstufaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManejoDaEstufaToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmTratosCulturais
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub FechamentoDeM�sToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FechamentoDeM�sToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFEFechamento
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub DocumentoDeEntradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentoDeEntradaToolStripMenuItem.Click
        'Cria um novo form orquideas
        'Como parametro 1-Saida 0-Entrada
        Dim Child As New frmNFeDocumento(0)
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetaORQ
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs)
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetasBDJ
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs)
        'Cria um novo form orquideas
        Dim Child As New frmRelatorios
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        'Cria um novo form orquideas
        Dim Child As New frmOrquideas
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub BackupDoBancoDeDadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BackupDoBancoDeDadosToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmBackup
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub FluxoDeCaixaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FluxoDeCaixaToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmFluxo_Caixa
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub Hist�ricosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Hist�ricosToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmHistoricos
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsPlantio_Click(sender As System.Object, e As System.EventArgs) Handles tsPlantio.Click
        'Cria um novo form orquideas
        Dim Child As New frmPlantio
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsbLotes_Click(sender As System.Object, e As System.EventArgs) Handles tsbLotes.Click
        'Cria um novo form orquideas
        Dim Child As New frmNovoLotes
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsbCodServ_Click(sender As System.Object, e As System.EventArgs) Handles tsbCodServ.Click
        'Cria um novo form orquideas
        Dim Child As New frmServCodBar
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsAlteracao_Click(sender As System.Object, e As System.EventArgs) Handles tsAlteracao.Click
        'Cria um novo form orquideas
        Dim Child As New frmAlteracaoLote
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles tsPrint_Lotes.Click
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetas
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsbOrquideas_Click(sender As System.Object, e As System.EventArgs) Handles tbPrint_Orquideas.Click
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetaORQ
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsbBandejas_Click(sender As System.Object, e As System.EventArgs) Handles tsPrint_Bandejas.Click
        'Cria um novo form orquideas
        Dim Child As New frmEtiquetasBDJ
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As System.Object, e As System.EventArgs) Handles tsClientes.Click
        'Cria um novo form orquideas
        Dim Child As New frmClientes
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub tsRelatorios_Click(sender As System.Object, e As System.EventArgs) Handles tsRelatorios.Click
        'Cria um novo form orquideas
        Dim Child As New frmRelatorios
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ContasAPagarToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ContasAPagarToolStripMenuItem1.Click
        'Cria um novo form orquideas
        Dim Child As New frmContasPagar
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ContasAReceberToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ContasAReceberToolStripMenuItem1.Click
        'Cria um novo form orquideas
        Dim Child As New frmContasReceber
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub DocumentosDeEntradaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentosDeEntradaToolStripMenuItem.Click
        'Cria um novo form orquideas
        'Como parametro 1-Saida 0-Entrada
        Dim Child As New frmNFeDocumento(0)
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub DocumentosDeSa�daToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentosDeSa�daToolStripMenuItem.Click
        'Cria um novo form orquideas
        'Como parametro 1-Saida 0-Entrada
        Dim Child As New frmNFeDocumento(1)
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub


    Private Sub GerenciamentoDeNFeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GerenciamentoDeNFeToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFeFatura
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub FechamentoDeM�sToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles FechamentoDeM�sToolStripMenuItem1.Click
        'Cria um novo form orquideas
        Dim Child As New frmNFEFechamento
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub ContatosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContatosToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmContatos
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub GerarBoletosBanc�riosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GerarBoletosBanc�riosToolStripMenuItem.Click

    End Sub

    Private Sub ImportarArquivoDoBancoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportarArquivoDoBancoToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmImportOFXData
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub SimuladorDeProdu��oToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SimuladorDeProdu��oToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmSimulador
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub TransportadorasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TransportadorasToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmTransportadoras
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub

    Private Sub aplica_permissao()

        'Se n�o estiver conectado j� aborta o processo
        If Not Conectado Then
            MsgBox("N�o � poss�vel aplicar as restri��es, pois o servidor n�o est� conectado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Desabilita todos
        For i As Integer = 0 To msMenu_Principal.Items.Count - 1
            msMenu_Principal.Items(i).Enabled = False
        Next
        'Pega a permiss�o do usu�rio e come�a a habilitar somente os que s�o permitidos
        Dim per As String = ""
        'Procura no banco de dados o que pode
        per = DLookup("Principal", "permissoes", "id=" & User.Permissao)
        'Tem que ver se o comprimento � igual ao n�mero de �tens
        If (per.Length = msMenu_Principal.Items.Count) Then
            'vai atribuindo as permissoes ao menu principal
            For i As Integer = 0 To per.Length - 1
                msMenu_Principal.Items(i).Enabled = IIf(per.Substring(i, 1) = 1, True, False)
            Next
        Else
            Exit Sub
        End If

        'Percorre cada um dos submenus
        Sub_Menu("Arquivo", mnpArquivo)
        Sub_Menu("Producao", mnpProducao)
        Sub_Menu("Clientes", mnpClientes)
        Sub_Menu("Pedidos", mnpPedidos)
        Sub_Menu("RH", mnpRH)
        Sub_Menu("Financeiro", mnpFinanceiro)
        Sub_Menu("Ferramentas", mnpFerramentas)
        Sub_Menu("Relatorios", mnpRelatorios)
        Sub_Menu("Sistema", mnpSistema)
        Sub_Menu("web", mnpWEB)

        '*
        '* Aplica as permissoes na barra de menu
        '*

        per = DLookup("Barra", "permissoes", "id=" & User.Permissao)
        If (per.Length = tsMenu.Items.Count) Then
            For i As Integer = 0 To tsMenu.Items.Count - 1
                'Procura a permissao da barra para os usu�rios
                tsMenu.Items(i).Enabled = IIf(per.Substring(i, 1) = 1, True, False)
            Next
        End If
    End Sub

    Private Sub Sub_Menu(ByVal Menu As String, ByRef objMenu As ToolStripMenuItem)
        Dim per As String
        per = DLookup(Menu, "permissoes", "id=" & User.Permissao)
        'Tem que ver se o comprimento � igual ao n�mero de �tens
        If (per.Length = objMenu.DropDownItems.Count) Then
            'vai atribuindo as permissoes ao menu principal
            For i As Integer = 0 To per.Length - 1
                objMenu.DropDownItems(i).Enabled = IIf(per.Substring(i, 1) = 1, True, False)
            Next
        End If
    End Sub

    Private Sub CadastroDePermiss�esToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CadastroDePermiss�esToolStripMenuItem.Click
        Dim Child As New frmCadastroGrupos
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub EtiquetasParaClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EtiquetasParaClientesToolStripMenuItem.Click
        Dim Child As New frmSelecaoClientesEtiquetas
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub RastreamentoDeLotesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RastreamentoDeLotesToolStripMenuItem.Click
        Dim Child As New frmRastreamentoLotes
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub OrdensDeProdu��oToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles OrdensDeProdu��oToolStripMenuItem1.Click
        Dim Child As New frmProgramacaoSemanal
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub RetornoDeFrascosParaEstoqueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RetornoDeFrascosParaEstoqueToolStripMenuItem.Click
        Dim Child As New frmEntrada_Frascos
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub Programa��oSemanalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Programa��oSemanalToolStripMenuItem.Click
        Dim Child As New frmRelProgramacao
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub Manuten��oDeLan�amentosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Manuten��oDeLan�amentosToolStripMenuItem.Click
        Dim Child As New frmManutLancam
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub ReservasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReservasToolStripMenuItem.Click
        Dim Child As New frmReservas
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub Invent�rioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Invent�rioToolStripMenuItem.Click
        Dim Child As New frmInventario
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub txtOrdemProducao_Leave(sender As System.Object, e As System.EventArgs) Handles txtOrdemProducao.Leave
        Dim DR As DataRow, OP As Integer = -1

        'Se houver algo v�lido digitado
        If txtOrdemProducao.Text.Length > 3 And IsNumeric(txtOrdemProducao.Text) Then
            OP = txtOrdemProducao.Text
            txtOrdemProducao.Text = String.Empty
            'Coloca o cursor em posi��o de espera
            Me.Cursor = Cursors.WaitCursor
            Try
                'Pega os dados da Ordem de Produ��o e Preenche na ficha
                DR = DLookupRow("programacao", "id=" & Int(OP))
                'Se n�o achou nada e DR est� vazio sai da rotina
                If IsDBNull(DR) Or IsNothing(DR) Then
                    MsgBox("N�o foi poss�vel localizar a Ordem de Produ��o N�: " & OP, MsgBoxStyle.Critical + vbOKOnly, "Erro")
                    txtOrdemProducao.Text = String.Empty
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar localizar a ordem de produ��o" & vbCrLf & ex.Message, MsgBoxStyle.Critical + vbOKOnly, "Erro")
                txtOrdemProducao.Text = String.Empty
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try

            'Se deu certo segue vendo que tipo de OP se trata

            If DR("Tipo") = "R" Then            'Se for uma ordem de Produ��o (R)epicagem
                Dim child As New frmNovoLotes("O", OP)
                child.MdiParent = Me
                'Mostra o formul�rio
                child.Show()
                Me.Cursor = Cursors.Arrow
            ElseIf DR("Tipo") = "P" Then        'Se por uma ordem de (P)lantio
                Dim child As New frmPlantio(OP)
                child.MdiParent = Me
                'Mostra o formul�rio
                child.Show()
            ElseIf DR("Tipo") = "G" Then        'Se for uma ordem (G)eral
                Dim a As String
                a = InputBox("Esta � uma ordem de Servi�os Direta." & vbCrLf & "Digite a data da Baixa no campo abaixo para concluir esta Ordem de Servi�o", "Data da Baixa")
                'Se o usu�rio colocou alguma informa��o
                If a <> String.Empty Then
                    ExecutaSQL("UPDATE Programacao SET DataBaixa='" & Format(CDate(a), "yyyy-MM-dd") & "' WHERE id=" & OP)
                    MsgBox("Ordem de produ��o conclu�da com sucesso!")
                    Me.Cursor = Cursors.Arrow
                End If
            End If
        End If
    End Sub


    Private Sub txtOrdemProducao_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOrdemProducao.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub PlanejamentoDeProdu��oToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlanejamentoDeProdu��oToolStripMenuItem.Click
        Dim Child As New frmPlanejamentoProducao
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub tsPesquisa_Lotes_Click(sender As System.Object, e As System.EventArgs) Handles tsPesquisa_Lotes.Click
        Dim Child As New frmPesquisa
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub Emiss�oDeReciboDePagamentoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Emiss�oDeReciboDePagamentoToolStripMenuItem.Click
        Dim Child As New frmRecibo
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub FunilDeVendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FunilDeVendasToolStripMenuItem.Click
        Dim Child As New frmCRMVendas
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub MapaProdu��oComercializa��oToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapaProdu��oComercializa��oToolStripMenuItem.Click
        Dim Child As New frmMapa_Comercializacao
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub NovoLotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovoLotesToolStripMenuItem.Click
        Dim Child As New frmNovoLotes
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub NovoLotesidToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim Child As New frmNovoLotes("L", 8605)
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub CRMTrelloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CRMTrelloToolStripMenuItem.Click
        Dim Child As New frmWEB_Trello
        Child.MdiParent = Me
        Child.Show()
    End Sub

    Private Sub Impress�oToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Impress�oToolStripMenuItem.Click
        'Cria um novo form orquideas
        Dim Child As New frmEmissaoBoletos
        'Define que � MDIChild
        Child.MdiParent = Me
        'Mostra o formul�rio
        Child.Show()
    End Sub
End Class
