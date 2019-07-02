<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorios
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Lotes", 1, 3)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contaminações do Período", 1, 3)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Produtividade de Repicadores", 1, 3)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Repicagens Vencidas", 1, 3)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Histórico de Serviços", 1, 3)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Biorreatores - Inspeção", 1, 3)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estoque Orquídeas por Cliente", 1, 3)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Produção do Período", 1, 3)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ordens de Produção", 1, 3)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Produção", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ficha do Funcionário", 1, 3)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recibo de Vale Transporte")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recursos Humanos", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Pedidos", 1, 3)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Conciliação de Pedidos", 1, 3)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Espelho de Pedido", 1, 3)
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Expedição por Período", 1, 3)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Reservas", 1, 3)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista Negócios", 1, 3)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pedidos", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Clientes", 1, 3)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Etiquetas para Clientes", 1, 3)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22})
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lançamentos de Caixa - Diário")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Históricos Contábeis")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Plano de Contas")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Valorização do Estoque")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contabilidade", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode24, TreeNode25, TreeNode26, TreeNode27})
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contas a Pagar")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contas a Pagar - Detalhado")
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Preços")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras por Período")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("NFe por Período")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendas por Cliente")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Relatório de Royalties")
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("NFe e Frete")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Financeiro", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32, TreeNode33, TreeNode34, TreeNode35, TreeNode36})
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Meios de Cultura", 1, 3)
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cadastros", 0, 2, New System.Windows.Forms.TreeNode() {TreeNode38})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatorios))
        Me.tvRelatorios = New System.Windows.Forms.TreeView()
        Me.ilIcones = New System.Windows.Forms.ImageList(Me.components)
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.txtDataFIM = New System.Windows.Forms.DateTimePicker()
        Me.txtDataINI = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btAtualizar = New System.Windows.Forms.Button()
        Me.cmbNome = New System.Windows.Forms.ComboBox()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.dsProducao_por_periodo = New System.Data.DataSet()
        Me.Resumo = New System.Data.DataTable()
        Me.Mercadoria = New System.Data.DataColumn()
        Me.Clone = New System.Data.DataColumn()
        Me.Isolamento = New System.Data.DataColumn()
        Me.Multiplicacao = New System.Data.DataColumn()
        Me.Alongamento = New System.Data.DataColumn()
        Me.Enraizamento = New System.Data.DataColumn()
        Me.Plantio = New System.Data.DataColumn()
        Me.grpParametros.SuspendLayout()
        CType(Me.dsProducao_por_periodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Resumo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvRelatorios
        '
        Me.tvRelatorios.ImageKey = "Closed-Folder.ico"
        Me.tvRelatorios.ImageList = Me.ilIcones
        Me.tvRelatorios.Location = New System.Drawing.Point(8, 12)
        Me.tvRelatorios.Name = "tvRelatorios"
        TreeNode1.ImageIndex = 1
        TreeNode1.Name = "proLotes"
        TreeNode1.SelectedImageIndex = 3
        TreeNode1.Text = "Lista de Lotes"
        TreeNode2.ImageIndex = 1
        TreeNode2.Name = "proContaminacao"
        TreeNode2.SelectedImageIndex = 3
        TreeNode2.Text = "Contaminações do Período"
        TreeNode2.ToolTipText = "Contaminação de Lotes no Período (Detalhado)"
        TreeNode3.ImageIndex = 1
        TreeNode3.Name = "proProdutividade"
        TreeNode3.SelectedImageIndex = 3
        TreeNode3.Text = "Produtividade de Repicadores"
        TreeNode4.ImageIndex = 1
        TreeNode4.Name = "proVencidas"
        TreeNode4.SelectedImageIndex = 3
        TreeNode4.Text = "Repicagens Vencidas"
        TreeNode5.ImageIndex = 1
        TreeNode5.Name = "proServicos"
        TreeNode5.SelectedImageIndex = 3
        TreeNode5.Text = "Histórico de Serviços"
        TreeNode6.ImageIndex = 1
        TreeNode6.Name = "proBiorreatores"
        TreeNode6.SelectedImageIndex = 3
        TreeNode6.Text = "Biorreatores - Inspeção"
        TreeNode7.ImageIndex = 1
        TreeNode7.Name = "proRelOrquideas"
        TreeNode7.SelectedImageIndex = 3
        TreeNode7.Text = "Estoque Orquídeas por Cliente"
        TreeNode8.ImageIndex = 1
        TreeNode8.Name = "proProdPeriodo"
        TreeNode8.SelectedImageIndex = 3
        TreeNode8.Text = "Produção do Período"
        TreeNode8.ToolTipText = "Produção de Lotes, Plantio e Orquídeas em um determinado período"
        TreeNode9.ImageIndex = 1
        TreeNode9.Name = "proProgramacao"
        TreeNode9.SelectedImageIndex = 3
        TreeNode9.Text = "Ordens de Produção"
        TreeNode10.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode10.ImageIndex = 0
        TreeNode10.Name = "nodProducao"
        TreeNode10.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode10.SelectedImageIndex = 2
        TreeNode10.Text = "Produção"
        TreeNode10.ToolTipText = "Relatórios de Produção"
        TreeNode11.ImageIndex = 1
        TreeNode11.Name = "rhFicha"
        TreeNode11.SelectedImageIndex = 3
        TreeNode11.Text = "Ficha do Funcionário"
        TreeNode12.Name = "rhValeTransporte"
        TreeNode12.Text = "Recibo de Vale Transporte"
        TreeNode13.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode13.ImageIndex = 0
        TreeNode13.Name = "nodRH"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode13.SelectedImageIndex = 2
        TreeNode13.Text = "Recursos Humanos"
        TreeNode13.ToolTipText = "Informações Relacionadas a Funcionários"
        TreeNode14.ImageIndex = 1
        TreeNode14.Name = "pedLista"
        TreeNode14.SelectedImageIndex = 3
        TreeNode14.Text = "Lista de Pedidos"
        TreeNode15.ImageIndex = 1
        TreeNode15.Name = "pedConciliacao"
        TreeNode15.SelectedImageIndex = 3
        TreeNode15.Text = "Conciliação de Pedidos"
        TreeNode16.ImageIndex = 1
        TreeNode16.Name = "pedPedido"
        TreeNode16.SelectedImageIndex = 3
        TreeNode16.Text = "Espelho de Pedido"
        TreeNode17.ImageIndex = 1
        TreeNode17.Name = "pedExpedicao"
        TreeNode17.SelectedImageIndex = 3
        TreeNode17.Text = "Expedição por Período"
        TreeNode17.ToolTipText = "Expedições programadas por período"
        TreeNode18.ImageIndex = 1
        TreeNode18.Name = "pedReservas"
        TreeNode18.SelectedImageIndex = 3
        TreeNode18.Text = "Lista de Reservas"
        TreeNode19.ImageIndex = 1
        TreeNode19.Name = "pedNegocios"
        TreeNode19.SelectedImageIndex = 3
        TreeNode19.Text = "Lista Negócios"
        TreeNode20.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode20.ImageIndex = 0
        TreeNode20.Name = "nodPedidos"
        TreeNode20.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode20.SelectedImageIndex = 2
        TreeNode20.Text = "Pedidos"
        TreeNode21.ImageIndex = 1
        TreeNode21.Name = "cliLista"
        TreeNode21.SelectedImageIndex = 3
        TreeNode21.Text = "Lista de Clientes"
        TreeNode22.ImageIndex = 1
        TreeNode22.Name = "cliEtiquetas"
        TreeNode22.SelectedImageIndex = 3
        TreeNode22.Text = "Etiquetas para Clientes"
        TreeNode23.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode23.ImageIndex = 0
        TreeNode23.Name = "nodClientes"
        TreeNode23.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode23.SelectedImageIndex = 2
        TreeNode23.Text = "Clientes"
        TreeNode24.ImageIndex = 1
        TreeNode24.Name = "finLancamentos"
        TreeNode24.Text = "Lançamentos de Caixa - Diário"
        TreeNode25.ImageIndex = 1
        TreeNode25.Name = "finHistoricoContabil"
        TreeNode25.Text = "Históricos Contábeis"
        TreeNode26.ImageIndex = 1
        TreeNode26.Name = "finPlanoContas"
        TreeNode26.Text = "Plano de Contas"
        TreeNode27.ImageIndex = 1
        TreeNode27.Name = "finValEstoque"
        TreeNode27.Text = "Valorização do Estoque"
        TreeNode28.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode28.ImageIndex = 0
        TreeNode28.Name = "Node3"
        TreeNode28.SelectedImageIndex = 2
        TreeNode28.Text = "Contabilidade"
        TreeNode29.ImageIndex = 1
        TreeNode29.Name = "finPagar"
        TreeNode29.Text = "Contas a Pagar"
        TreeNode30.ImageIndex = 1
        TreeNode30.Name = "finPagarDet"
        TreeNode30.Text = "Contas a Pagar - Detalhado"
        TreeNode31.ImageIndex = 1
        TreeNode31.Name = "finListaPreco"
        TreeNode31.Text = "Lista de Preços"
        TreeNode32.ImageIndex = 1
        TreeNode32.Name = "finCompras"
        TreeNode32.Text = "Compras por Período"
        TreeNode33.ImageIndex = 1
        TreeNode33.Name = "finNFEPeriodo"
        TreeNode33.Text = "NFe por Período"
        TreeNode34.ImageIndex = 1
        TreeNode34.Name = "finVenda_Cliente"
        TreeNode34.Text = "Vendas por Cliente"
        TreeNode35.ImageIndex = 1
        TreeNode35.Name = "finRoyalties"
        TreeNode35.Text = "Relatório de Royalties"
        TreeNode36.ImageIndex = 1
        TreeNode36.Name = "finFrete"
        TreeNode36.Text = "NFe e Frete"
        TreeNode37.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode37.ImageIndex = 0
        TreeNode37.Name = "NodFinanceiro"
        TreeNode37.SelectedImageIndex = 2
        TreeNode37.Text = "Financeiro"
        TreeNode38.ImageIndex = 1
        TreeNode38.Name = "cadMeios"
        TreeNode38.SelectedImageIndex = 3
        TreeNode38.Text = "Meios de Cultura"
        TreeNode39.ForeColor = System.Drawing.Color.SteelBlue
        TreeNode39.ImageIndex = 0
        TreeNode39.Name = "NodCadastro"
        TreeNode39.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode39.SelectedImageIndex = 2
        TreeNode39.Text = "Cadastros"
        Me.tvRelatorios.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode13, TreeNode20, TreeNode23, TreeNode37, TreeNode39})
        Me.tvRelatorios.SelectedImageIndex = 0
        Me.tvRelatorios.Size = New System.Drawing.Size(202, 413)
        Me.tvRelatorios.TabIndex = 0
        '
        'ilIcones
        '
        Me.ilIcones.ImageStream = CType(resources.GetObject("ilIcones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilIcones.TransparentColor = System.Drawing.Color.Transparent
        Me.ilIcones.Images.SetKeyName(0, "Closed-Folder.ico")
        Me.ilIcones.Images.SetKeyName(1, "Default-Icon.ico")
        Me.ilIcones.Images.SetKeyName(2, "Open-Folder.ico")
        Me.ilIcones.Images.SetKeyName(3, "Text-Document.ico")
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.txtData)
        Me.grpParametros.Controls.Add(Me.txtDataFIM)
        Me.grpParametros.Controls.Add(Me.txtDataINI)
        Me.grpParametros.Controls.Add(Me.Label4)
        Me.grpParametros.Controls.Add(Me.txtNum)
        Me.grpParametros.Controls.Add(Me.Label3)
        Me.grpParametros.Controls.Add(Me.btAtualizar)
        Me.grpParametros.Controls.Add(Me.cmbNome)
        Me.grpParametros.Controls.Add(Me.lblNome)
        Me.grpParametros.Controls.Add(Me.Label2)
        Me.grpParametros.Controls.Add(Me.Label1)
        Me.grpParametros.Enabled = False
        Me.grpParametros.Location = New System.Drawing.Point(11, 433)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(896, 97)
        Me.grpParametros.TabIndex = 2
        Me.grpParametros.TabStop = False
        Me.grpParametros.Text = " Parâmetros "
        '
        'txtData
        '
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(70, 71)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(95, 20)
        Me.txtData.TabIndex = 4
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataFIM.Location = New System.Drawing.Point(199, 19)
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(96, 20)
        Me.txtDataFIM.TabIndex = 1
        '
        'txtDataINI
        '
        Me.txtDataINI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataINI.Location = New System.Drawing.Point(70, 19)
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(95, 20)
        Me.txtDataINI.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Data:"
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(70, 45)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(55, 20)
        Me.txtNum.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Num.:"
        '
        'btAtualizar
        '
        Me.btAtualizar.Location = New System.Drawing.Point(815, 19)
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizar.TabIndex = 5
        Me.btAtualizar.Text = "Aplicar"
        Me.btAtualizar.UseVisualStyleBackColor = True
        '
        'cmbNome
        '
        Me.cmbNome.FormattingEnabled = True
        Me.cmbNome.Location = New System.Drawing.Point(404, 19)
        Me.cmbNome.Name = "cmbNome"
        Me.cmbNome.Size = New System.Drawing.Size(405, 21)
        Me.cmbNome.TabIndex = 2
        '
        'lblNome
        '
        Me.lblNome.Location = New System.Drawing.Point(309, 22)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(91, 13)
        Me.lblNome.TabIndex = 4
        Me.lblNome.Text = "Nome:"
        Me.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "até"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Data: de"
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crViewer.Location = New System.Drawing.Point(216, 12)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.ShowCloseButton = False
        Me.crViewer.ShowGroupTreeButton = False
        Me.crViewer.ShowParameterPanelButton = False
        Me.crViewer.Size = New System.Drawing.Size(691, 413)
        Me.crViewer.TabIndex = 1
        Me.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'dsProducao_por_periodo
        '
        Me.dsProducao_por_periodo.DataSetName = "NewDataSet"
        Me.dsProducao_por_periodo.Tables.AddRange(New System.Data.DataTable() {Me.Resumo})
        '
        'Resumo
        '
        Me.Resumo.Columns.AddRange(New System.Data.DataColumn() {Me.Mercadoria, Me.Clone, Me.Isolamento, Me.Multiplicacao, Me.Alongamento, Me.Enraizamento, Me.Plantio})
        Me.Resumo.TableName = "Resumo"
        '
        'Mercadoria
        '
        Me.Mercadoria.AllowDBNull = False
        Me.Mercadoria.ColumnName = "Mercadoria"
        Me.Mercadoria.DefaultValue = "0"
        '
        'Clone
        '
        Me.Clone.ColumnName = "Clone"
        Me.Clone.DefaultValue = ""
        '
        'Isolamento
        '
        Me.Isolamento.ColumnName = "Isolamento"
        Me.Isolamento.DataType = GetType(Integer)
        Me.Isolamento.DefaultValue = 0
        '
        'Multiplicacao
        '
        Me.Multiplicacao.Caption = "Multiplicação"
        Me.Multiplicacao.ColumnName = "Multiplicacao"
        Me.Multiplicacao.DataType = GetType(Integer)
        Me.Multiplicacao.DefaultValue = 0
        '
        'Alongamento
        '
        Me.Alongamento.ColumnName = "Alongamento"
        Me.Alongamento.DataType = GetType(Integer)
        Me.Alongamento.DefaultValue = "0"
        '
        'Enraizamento
        '
        Me.Enraizamento.ColumnName = "Enraizamento"
        Me.Enraizamento.DataType = GetType(Integer)
        Me.Enraizamento.DefaultValue = 0
        '
        'Plantio
        '
        Me.Plantio.ColumnName = "Plantio"
        Me.Plantio.DataType = GetType(Integer)
        Me.Plantio.DefaultValue = 0
        '
        'frmRelatorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 540)
        Me.Controls.Add(Me.crViewer)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.tvRelatorios)
        Me.MinimizeBox = False
        Me.Name = "frmRelatorios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualizador de Relatórios"
        Me.grpParametros.ResumeLayout(False)
        Me.grpParametros.PerformLayout()
        CType(Me.dsProducao_por_periodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Resumo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvRelatorios As System.Windows.Forms.TreeView
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNome As System.Windows.Forms.ComboBox
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents btAtualizar As System.Windows.Forms.Button
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ilIcones As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataFIM As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDataINI As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents dsProducao_por_periodo As DataSet
    Friend WithEvents Resumo As DataTable
    Friend WithEvents Mercadoria As DataColumn
    Friend WithEvents Clone As DataColumn
    Friend WithEvents Isolamento As DataColumn
    Friend WithEvents Multiplicacao As DataColumn
    Friend WithEvents Alongamento As DataColumn
    Friend WithEvents Enraizamento As DataColumn
    Friend WithEvents Plantio As DataColumn
End Class
