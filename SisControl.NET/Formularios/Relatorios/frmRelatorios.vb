Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.ReportSource

Public Class frmRelatorios

    Private Sub Atualiza_Relatorio(ByVal rptNome As String, Optional ByVal Parametro As Object = Nothing, Optional ByVal Parametro_Nome As String = Nothing)
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\"
        strReportPath = strReportPath & rptNome

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath)
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        'Se existirem parametros informados
        If Not IsNothing(Parametro) Then
        End If

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()
    End Sub
    'Verifica quais parametros vão ser atualizados
    Private Sub Atualiza_Parametros(ByVal Relatorio As String)
        grpParametros.Enabled = True
        'Desabilita todos os controles primeiro
        Dim n As Control
        'Pega cada um
        For Each n In grpParametros.Controls
            n.Enabled = False
        Next
        'Habilita o botão de atualizar
        btAtualizar.Enabled = True
        lblNome.Text = "Nome"
        'Depois seleciona para ver qual vai ficar ativo
        Select Case Relatorio
            Case "proVencidas"
                lblNome.Enabled = True
                lblNome.Text = "Mercadoria:"
                cmbNome.Enabled = True
                Carrega_Lista(cmbNome, "mercadoria_num", "id", "Nome", True)
                GoTo Fim
            Case "pedExpedicao"
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "proProgramacao"
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "proProdutividade"
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "proRelOrquideas"
                lblNome.Enabled = True
                lblNome.Text = "Cliente:"
                cmbNome.Enabled = True
                Carrega_Lista(cmbNome, "Clientes", "id", "Nome", True)
                GoTo Fim
            Case "proProdPeriodo"
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "rhFicha"
                crViewer.Enabled = True
                'Carrega os dados do combo
                Carrega_Lista(cmbNome, "Funcionarios", "id", "Nome", True)
                Localiza_Item(cmbNome, "1")
                lblNome.Text = "Funcionário:"
                lblNome.Enabled = True
                cmbNome.Enabled = True
                GoTo Fim
            Case "rhValeTransporte"
                grpParametros.Enabled = True
                Label3.Enabled = True
                txtNum.Enabled = True
                txtData.Enabled = True
                Label4.Enabled = True
                GoTo Fim
            Case "finLancamentos"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "finPlanodecontas"
                'grpParametros.Enabled = False
                GoTo Fim
            Case "finHistoricoContabil"
                'grpParametros.Enabled = False
                GoTo Fim
            Case "finMovimento"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "finCompras"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "finPagar"
                Label2.Enabled = True
                txtDataFIM.Enabled = True
                Label1.Enabled = True
                txtDataINI.Enabled = True
                GoTo Fim
            Case "finPagamento"
                Label2.Enabled = True
                txtDataFIM.Enabled = True
                Label1.Enabled = True
                txtDataINI.Enabled = True
                GoTo Fim
            Case "finNFEPeriodo"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
            Case "finRoyalties"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                lblNome.Enabled = True
                cmbNome.Enabled = True
                lblNome.Text = "Mercadoria"
                Carrega_Lista(cmbNome, "mercadoria_com_royalties", "id", "Codigo")
                GoTo Fim
            Case "finVenda_Cliente"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                lblNome.Enabled = True
                lblNome.Text = "Cliente:"
                cmbNome.Enabled = True
                Carrega_Lista(cmbNome, "Clientes", "id", "Nome", True)
                GoTo Fim
            Case "finFrete"
                Label1.Enabled = True
                Label2.Enabled = True
                txtDataINI.Enabled = True
                txtDataFIM.Enabled = True
                GoTo Fim
        End Select
        btAtualizar.Enabled = False
        grpParametros.Enabled = False
Fim:
        Exit Sub
    End Sub
    Private Sub tvRelatorios_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvRelatorios.AfterSelect
        'Verifica qual o nome do nó selecionado
        Dim Nomes() As String
        Dim Valores() As Object
        Select Case tvRelatorios.SelectedNode.Name
            'Cadastros
            Case "cadMeios"
                Atualiza_Relatorio("proLista_Meios_de_Cultura.rpt")
                'Producao
            Case "proProdutividade"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("rptPR_Produtividade.rpt")
            Case "proLotes"
                Atualiza_Relatorio("crPRO_Lista_Lotes.rpt")
            Case "proVencidas"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Arrays dos parametros
                Nomes = {"Codigo"}
                Valores = {cmbVal(cmbNome)}
                Relatorio_Multiparametro("crLotesVencidos.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "proBiorreatores"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("proBiorreatores_Lista_Inspecao.rpt")
            Case "proRelOrquideas"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Arrays dos parametros
                Nomes = {"txtCliente", "Nome"}
                Valores = {cmbVal(cmbNome), cmbNome.Text}
                Relatorio_Multiparametro("crRelatorio_Orquideas.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "proProdPeriodo"   'Esse relatório é diferente pois tem que produzir o próprio DataSET
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                rptProducao_por_periodo()
            Case "proProgramacao"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Array com os valores dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("crPRO_Ordem_de_Producao.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
                'Pedidos
            Case "pedLista"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("crLista_Pedidos.rpt")
            Case "pedReservas"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("pedReservas.rpt")
            Case "pedExpedicao"
                'Array com os valores dos parametros
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Text}
                Relatorio_Multiparametro("crPedExpedicao.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "pedNegocios"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("pedNegocios.rpt")
                'Clientes
            Case "cliLista"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("crLista_Clientes.rpt")
            Case "cliEtiquetas"
            Case "pedPedido"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("crPedido.rpt")
            Case "finLancamentos"
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Visualiza_Financeiro("crFIN_Movimento de Caixa.rpt")
            Case "finMovimento"
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Visualiza_Financeiro("rptFIN_Caixa.rpt")
            Case "finValEstoque"
                Atualiza_Relatorio("rptFIN_ValorEstoque.rpt")
            Case "finPagar"
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("rptContasPagar.rpt", txtDataFIM.Text, "txtDataFIM")
            Case "finPagarDet"
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("rptContasPagarDet.rpt", txtDataFIM.Text, "txtDataFIM")
            Case "finNFEPeriodo"
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                rptFinNFePeriodo()
            Case "finCompras"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Coloca os valores do mes corrente
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                'Array com os valores dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Text}
                'Chama o relatorio multiparametro
                Relatorio_Multiparametro("rptFIN_Compras.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "finHistoricoContabil"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("rptFINHistoricosContabeis.rpt")
            Case "finPlanoContas"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("rptFINPlanodecontas.rpt")
            Case "finListaPreco"
                'Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("crFIN_Lista_de_Precos.rpt")
            Case "finRoyalties"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Coloca os valores do mes corrente
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                'Array com os valores dos parametros
                Nomes = {"DataINI", "DataFIM", "CodPro", "Clone"}
                Valores = {txtDataINI.Value, txtDataFIM.Value, 15, 1}
                'Chama o relatorio multiparametro
                Relatorio_Multiparametro("rptFINRoyalties.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "finVenda_Cliente"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Coloca os valores do mes corrente
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                'Arrays dos parametros
                Nomes = {"CodCli", "txtDataINI", "txtDataFIM"}
                Valores = {0, txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("rptFINVendas_Cliente.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "finFrete"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Coloca os valores do mes corrente
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                'Arrays dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("rptFINFrete.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "rhFicha"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                Atualiza_Relatorio("crFichaFuncionario.rpt", cmbVal(cmbNome), "txtID")
            Case "rhValeTransporte"
                Atualiza_Parametros(tvRelatorios.SelectedNode.Name)
                'Coloca os valores do mes corrente
                txtDataINI.Text = Format(CDate("01/" & Date.Today.Month.ToString & "/" & Date.Today.Year.ToString), "dd/MM/yy")
                txtDataFIM.Text = Format(Now, "dd/MM/yy")
                'Array com os valores dos parametros
                txtNum.Text = DiasUteis(CDate(txtDataINI.Value), CDate(txtDataFIM.Value))
                Nomes = {"Data_Vale", "Num_Dias", "Valor_Vale"}
                Valores = {CDate(txtData.Text), Int(txtNum.Text), String_to_Numero(DLookup("Valor", "Parametros", "Nome='ValorVT'"))}
                'Chama o relatorio multiparametro
                Relatorio_Multiparametro("rhValeTransporte.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
        End Select
    End Sub

    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        'Verifica qual o nome do nó selecionado
        Dim Nomes() As String
        Dim Valores() As Object
        Select Case tvRelatorios.SelectedNode.Name
            'PRODUÇÃO
            Case "proProdutividade"
                Atualiza_Relatorio("crGrafico_Contaminacao.rpt")
            Case "proLotes"
                Atualiza_Relatorio("crPRO_Lista_Lotes.rpt")
                'Relatório de Orquídeas
            Case "proVencidas"
                'Arrays dos parametros
                Nomes = {"Codigo"}
                Valores = {cmbVal(cmbNome)}
                Relatorio_Multiparametro("crLotesVencidos.rpt", Nomes, Valores)
            Case "proRelOrquideas"
                'Arrays dos parametros
                Nomes = {"txtCliente", "Nome"}
                Valores = {cmbVal(cmbNome), cmbNome.Text}
                Relatorio_Multiparametro("crRelatorio_Orquideas.rpt", Nomes, Valores)
            Case "proProdPeriodo"
                'Array com os valores dos parametros
                rptProducao_por_periodo()
            Case "proProgramacao"
                'Array com os valores dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("rptPROProgramacao.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
                'PEDIDOS
            Case "pedLista"
                Atualiza_Relatorio("crLista_Pedidos.rpt")
            Case "pedReservas"
                Atualiza_Relatorio("pedReservas.rpt")
            Case "pedExpedicao"
                'Array com os valores dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("crPedExpedicao.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
                'CLIENTES
            Case "cliLista"
                Atualiza_Relatorio("crLista_Clientes.rpt")
            Case "cliEtiquetas"
                'FINANCEIRO
            Case "finLancamentos"
                Visualiza_Financeiro("crFIN_Movimento de Caixa.rpt")
            Case "finPagar"
                Atualiza_Relatorio("rptContasPagar.rpt", txtDataFIM.Text, "txtDataFIM")
            Case "finCompras"
                'Array com os valores dos parametros
                Nomes = {"txtDataINI", "txtDataFIM"}
                Valores = {txtDataINI.Value, txtDataFIM.Value}
                Relatorio_Multiparametro("rptFIN_Compras.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
            Case "finPagarDet"
                Atualiza_Relatorio("rptContasPagarDet.rpt", txtDataFIM.Text, "txtDataFIM")
            Case "finMovimento"
                Visualiza_Financeiro("rptFIN_Caixa.rpt")
            Case "finRoyalties"
                If cmbNome.SelectedIndex <> -1 Then
                    'Array com os valores dos parametros
                    Nomes = {"DataINI", "DataFIM", "CodPro", "Clone"}
                    Valores = {txtDataINI.Value, txtDataFIM.Value, Int(cmbNome.Text.Substring(0, 3)), Int(cmbNome.Text.Substring(4, 4))}
                    'Chama o relatorio multiparametro
                    Relatorio_Multiparametro("rptFINRoyalties.rpt", Nomes, Valores)
                    Nomes = Nothing
                    Valores = Nothing
                Else
                    MsgBox("Selecione o produto primeiro!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Select
                End If
            Case "finVenda_Cliente"
                If cmbNome.SelectedIndex <> -1 Then
                    'Arrays dos parametros
                    Nomes = {"CodCli", "txtDataINI", "txtDataFIM"}
                    Valores = {cmbVal(cmbNome), txtDataINI.Value, txtDataFIM.Value}
                    Relatorio_Multiparametro("rptFINVendas_Cliente.rpt", Nomes, Valores)
                    Nomes = Nothing
                    Valores = Nothing
                End If
                '*
                '* RH
                '*
            Case "rhFicha"
                Atualiza_Relatorio("crFichaFuncionario.rpt", cmbVal(cmbNome), "txtID")
            Case "rhValeTransporte"
                'Array com os valores dos parametros
                Nomes = {"Data_Vale", "Num_Dias", "Valor_Vale"}
                Valores = {CDate(txtData.Text), Int(txtNum.Text), String_to_Numero(DLookup("Valor", "Parametros", "Nome='ValorVT'"))}
                'Chama o relatorio multiparametro
                Relatorio_Multiparametro("rhValeTransporte.rpt", Nomes, Valores)
                Nomes = Nothing
                Valores = Nothing
        End Select
    End Sub

    Private Sub Visualiza_Financeiro(ByVal rptNome As String)

        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & rptNome
        Dim SQL As String, varSaldo As Double = 0, DT As DataTable, DR As DataRow

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Relatório não localizado :" & vbCrLf & strReportPath))
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        'Se existirem parametros informados
        If (Not txtDataINI.Text = String.Empty) And (Not txtDataFIM.Text = String.Empty) Then
            'Atribui os parametros declarados aos objetos relacionados [ANTIGO]
            'Dim crParameterDiscreteValue As ParameterDiscreteValue
            'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            'Dim crParameterFieldLocation As ParameterFieldDefinition
            'Dim crParameterValues As ParameterValues

            'Descobre o saldo antes de emitir o relatório
            SQL = "SELECT SUM(credito)-SUM(debito) AS saldo FROM lancamentos WHERE pagamento < '" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "' AND MID(cdcomp,1,1)='1'"
            DT = SQLQuery(SQL)
            'Se retornou algum resultado
            If DT.Rows.Count <> 0 Then
                DR = DT.Rows(0)
                'converte o valor em double (se for nulo em Zero)
                If Not IsDBNull(DR("saldo")) Then
                    varSaldo = NaoNulo(Convert.ToDouble(DR("Saldo")))
                Else
                    varSaldo = 0
                End If
            End If

            'Libera memoria
            DT.Dispose()
            DT = Nothing
            DR = Nothing

            Console.WriteLine(Me.Name & " Saldo:" & varSaldo.ToString)

            ' Pega a coleção de parametros do relatorio
            'crParameterFieldDefinitions = CR.DataDefinition.ParameterFields

            'Console.WriteLine(Me.Name & " Nº Paramentros: " & CR.ParameterFields.Count)

            ' define o primeiro parametro
            '    - pega o parametro e diz a ela para usar os valores atuais
            '    - define o valor do parametro
            '    - inclui e aplica o valor
            '    - repete para cada parametro se for o caso

            'Tem um relatório que só tem 2 parametros o outro tem 3
            If Not tvRelatorios.SelectedNode.Name = "finMovimento" Then

                'Repete para o saldo inicial
                CR.SetParameterValue("SaldoINI", varSaldo)

            End If

            'Repete para data inicial
            CR.SetParameterValue("txtDataINI", txtDataINI.Value)

            'Repete para data Final
            CR.SetParameterValue("txtDataFIM", txtDataFIM.Value)

        End If

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()
    End Sub

    Private Sub rptFinNFePeriodo()
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "rptFIN_NFe_Periodo.rpt"

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Relatório não localizado :" & vbCrLf & strReportPath))
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        CR.SetParameterValue("txtDataINI", txtDataINI.Value)
        CR.SetParameterValue("txtDataFIM", txtDataFIM.Value)

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()
    End Sub

    Private Sub Relatorio_Multiparametro(ByVal nomeREL As String, Optional ByVal arrayNomes() As String = Nothing, Optional ByVal arrayValores() As Object = Nothing)
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & nomeREL
        Dim i As Integer

        If IsNothing(arrayNomes) Or IsNothing(arrayValores) Then
            MsgBox("Erro no fornecimento dos parâmetros do relatório.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Relatório não localizado :" & vbCrLf & strReportPath))
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        For i = 0 To arrayNomes.Length - 1
            CR.SetParameterValue(arrayNomes(i), arrayValores(i))
        Next

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()
    End Sub

    Private Sub frmRelatorios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDataINI.Text = Format(CDate("01/" & Today.Date.Month.ToString & "/" & Today.Date.Year), "dd/MM/yy")
        txtDataFIM.Text = Format(CDate(Date.DaysInMonth(Today.Date.Year, Today.Date.Month) & "/" & Today.Date.Month.ToString & "/" & Today.Date.Year), "dd/MM/yy")
        txtData.Text = Format(Date.Now.Date, "dd/MM/yy")
    End Sub

    Private Sub frmRelatorios_SizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        'Muda a janela de vizualização do relatório
        crViewer.Size = New System.Drawing.Size(Me.Size.Width - 242, Me.Size.Height - 165)
        'Muda a janela de Treenode
        tvRelatorios.Size = New System.Drawing.Size(tvRelatorios.Size.Width, Me.Size.Height - 165)
        'Muda o grupo de parametros
        grpParametros.Location = New System.Drawing.Point(11, Me.Height - 145)
        grpParametros.Size = New System.Drawing.Size(Me.Size.Width - 32, grpParametros.Size.Height)
        'Muda a posição do botão de atualizar
        btAtualizar.Location = New System.Drawing.Point(grpParametros.Size.Width - 81, 17)
    End Sub

    Private Sub txtDataINI_Leave(sender As System.Object, e As System.EventArgs)
        If tvRelatorios.SelectedNode.Name = "proProducao" Then
            Dim Dat As Date
            Dat = CDate(txtDataINI.Text)
            Dat = DateAdd(DateInterval.Day, 7, Dat)
            txtDataFIM.Text = Dat
        End If
    End Sub

    '****************************************
    '**
    '** Relatórios com DATASET Exclusivos
    '**
    '****************************************

    Private Sub rptProducao_por_periodo()

        'Dimensiona a conexão com o banco de dados
        Dim conn As New MySqlConnection

        'cursor de Espera
        Me.Cursor = Cursors.WaitCursor

        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION
        'Abre a conexão com o banco de dados
        conn.Open()

        Dim SQL As String = String.Empty
        'Monta a SQL de seleção de tudo o que foi repicado no período vigente
        SQL = "SELECT DISTINCT mercadoria,clone FROM lotes WHERE (data BETWEEN '" & Format(txtDataINI.Value, "yyyy-MM-dd") & "' and '" & Format(txtDataFIM.Value, "yyyy-MM-dd") & "') and (ativo=1) ORDER BY mercadoria,clone"
        'Busca os dados no Banco de Dados
        Dim DT As New DataTable
        Dim DTtmp As New DataTable
        DT = SQLQuery(SQL)

        'MsgBox("Nº " & DT.Rows.Count & vbCrLf & SQL)
        'Antes de começar a popular a tabela novamente, tem que limpar o DataSet
        dsProducao_por_periodo.Tables(0).Clear()

        Dim cd As Short = 0
        'Para cada linha do resultado obtido processa a seguinte soma
        For Each dr As DataRow In DT.Rows
            Dim myCommand As New MySqlCommand
            'Atribui a conexão ao comando
            myCommand.Connection = conn
            'Executa uma Stored Procedure no MySQL que já resume tudo no Banco de Dados evitando inúmeros Selects
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandText = "get_Producao_por_Periodo"
            '(@cod_Merc,@cod_Clone,@DataINI,@DataFIM,@varIsolamento,@varMultiplicacao,@varAlongamento,@varEnraizamento,@varPlantio)
            'Define todos os parametros de entrada
            myCommand.Parameters.AddWithValue("@cod_Merc", dr.Item("Mercadoria"))
            myCommand.Parameters.AddWithValue("@cod_Clone", dr.Item("Clone"))
            myCommand.Parameters.AddWithValue("@DataINI", txtDataINI.Value)
            myCommand.Parameters.AddWithValue("@DataFIM", txtDataFIM.Value)
            'Define os parametros de saída
            myCommand.Parameters.Add("@varIsolamento", MySqlDbType.Int32).Direction = ParameterDirection.Output
            myCommand.Parameters.Add("@varMultiplicacao", MySqlDbType.Int32).Direction = ParameterDirection.Output
            myCommand.Parameters.Add("@varAlongamento", MySqlDbType.Int32).Direction = ParameterDirection.Output
            myCommand.Parameters.Add("@varEnraizamento", MySqlDbType.Int32).Direction = ParameterDirection.Output
            myCommand.Parameters.Add("@varPlantio", MySqlDbType.Int32).Direction = ParameterDirection.Output
            'Executa o comando
            myCommand.ExecuteNonQuery()
            'Pega o resultado
            'Dim SQL_SP As String
            'SQL_SP = "get_Producao_por_Periodo(" & dr.Item("mercadoria") & "," & dr.Item("clone") & ",'" & Format(txtDataINI.Value, "yyyy-MM-dd") & "','" & Format(txtDataFIM.Value, "yyyy-MM-dd") & "',@varIsolamento,@varMultiplicacao,@varAlongamento,@varEnraizamento,@varPlantio)"
            'MsgBox("Mult:" & myCommand.Parameters(5).Value.ToString)
            With myCommand
                dsProducao_por_periodo.Tables(0).Rows.Add(dr.Item("Mercadoria"), dr.Item("Clone"), .Parameters(4).Value, .Parameters(5).Value, .Parameters(6).Value, .Parameters(7).Value, .Parameters(8).Value)
            End With
            cd += 1
            myCommand = Nothing
        Next
        'dsProducao_por_periodo.WriteXmlSchema("d:\Schema.xml")
        'dsProducao_por_periodo.WriteXml("d:\dados.xml")

        'Se passou então segue com a montagem do relatório
        Dim NomeRel As String = "rptProd_por_Periodo.rpt"
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & NomeRel

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Arquivo do Relatório não localizado", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument

        'Carrega o lay-out a partir do arquivo
        CR.Load(strReportPath)

        'Define a fonte de dados como sendo a planilha montada pelo progama
        CR.SetDataSource(dsProducao_por_periodo.Tables(0))

        'Informa os parametros de data
        CR.SetParameterValue("txtDataINI", txtDataINI.Value)
        CR.SetParameterValue("txtDataFIM", txtDataFIM.Value)

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()

        'Fecha a conexão aticva
        conn.Close()
        'Volta o cursor para Seta
        Me.Cursor = Cursors.Arrow
    End Sub
End Class