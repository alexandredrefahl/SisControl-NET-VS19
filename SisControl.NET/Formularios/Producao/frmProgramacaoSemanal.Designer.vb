<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacaoSemanal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProducao = New System.Windows.Forms.DataGridView()
        Me.ColCodigoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFaseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEstoqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDataRepDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDataDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVencidoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dsLotesVencidos = New System.Data.DataSet()
        Me.tblLotes = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.grpLotes = New System.Windows.Forms.GroupBox()
        Me.txtProximoLote = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProduto = New System.Windows.Forms.ComboBox()
        Me.txtM_F = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbClone = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQtdeMudas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFase = New System.Windows.Forms.ComboBox()
        Me.grpMeios = New System.Windows.Forms.GroupBox()
        Me.rdLiquido = New System.Windows.Forms.RadioButton()
        Me.rdSolido = New System.Windows.Forms.RadioButton()
        Me.cmbMeios = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtQtdeMeio = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rdRepicagem = New System.Windows.Forms.RadioButton()
        Me.rdPlantio = New System.Windows.Forms.RadioButton()
        Me.rdGeral = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tcInformacoes = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbFrasco = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblID = New System.Windows.Forms.Label()
        CType(Me.dgProducao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsLotesVencidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLotes.SuspendLayout()
        Me.grpMeios.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tcInformacoes.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(77, 78)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data:"
        '
        'dgProducao
        '
        Me.dgProducao.AllowUserToAddRows = False
        Me.dgProducao.AllowUserToDeleteRows = False
        Me.dgProducao.AllowUserToResizeColumns = False
        Me.dgProducao.AllowUserToResizeRows = False
        Me.dgProducao.AutoGenerateColumns = False
        Me.dgProducao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProducao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodigoDataGridViewTextBoxColumn, Me.ColFaseDataGridViewTextBoxColumn, Me.ColEstoqueDataGridViewTextBoxColumn, Me.ColDataRepDataGridViewTextBoxColumn, Me.ColDataDataGridViewTextBoxColumn, Me.ColVencidoDataGridViewTextBoxColumn})
        Me.dgProducao.DataMember = "Lotes"
        Me.dgProducao.DataSource = Me.dsLotesVencidos
        Me.dgProducao.Location = New System.Drawing.Point(4, 6)
        Me.dgProducao.Name = "dgProducao"
        Me.dgProducao.ReadOnly = True
        Me.dgProducao.RowHeadersWidth = 21
        Me.dgProducao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProducao.Size = New System.Drawing.Size(553, 181)
        Me.dgProducao.TabIndex = 0
        '
        'ColCodigoDataGridViewTextBoxColumn
        '
        Me.ColCodigoDataGridViewTextBoxColumn.DataPropertyName = "colCodigo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColCodigoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColCodigoDataGridViewTextBoxColumn.HeaderText = "Código"
        Me.ColCodigoDataGridViewTextBoxColumn.Name = "ColCodigoDataGridViewTextBoxColumn"
        Me.ColCodigoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColCodigoDataGridViewTextBoxColumn.Width = 95
        '
        'ColFaseDataGridViewTextBoxColumn
        '
        Me.ColFaseDataGridViewTextBoxColumn.DataPropertyName = "colFase"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.ColFaseDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColFaseDataGridViewTextBoxColumn.HeaderText = "Fase"
        Me.ColFaseDataGridViewTextBoxColumn.Name = "ColFaseDataGridViewTextBoxColumn"
        Me.ColFaseDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColFaseDataGridViewTextBoxColumn.Width = 90
        '
        'ColEstoqueDataGridViewTextBoxColumn
        '
        Me.ColEstoqueDataGridViewTextBoxColumn.DataPropertyName = "colEstoque"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ColEstoqueDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColEstoqueDataGridViewTextBoxColumn.HeaderText = "Frascos"
        Me.ColEstoqueDataGridViewTextBoxColumn.Name = "ColEstoqueDataGridViewTextBoxColumn"
        Me.ColEstoqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColEstoqueDataGridViewTextBoxColumn.Width = 55
        '
        'ColDataRepDataGridViewTextBoxColumn
        '
        Me.ColDataRepDataGridViewTextBoxColumn.DataPropertyName = "colDataRep"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        Me.ColDataRepDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColDataRepDataGridViewTextBoxColumn.HeaderText = "Repicagem"
        Me.ColDataRepDataGridViewTextBoxColumn.Name = "ColDataRepDataGridViewTextBoxColumn"
        Me.ColDataRepDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColDataRepDataGridViewTextBoxColumn.Width = 80
        '
        'ColDataDataGridViewTextBoxColumn
        '
        Me.ColDataDataGridViewTextBoxColumn.DataPropertyName = "colData"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        Me.ColDataDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColDataDataGridViewTextBoxColumn.HeaderText = "Data"
        Me.ColDataDataGridViewTextBoxColumn.Name = "ColDataDataGridViewTextBoxColumn"
        Me.ColDataDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColDataDataGridViewTextBoxColumn.Width = 95
        '
        'ColVencidoDataGridViewTextBoxColumn
        '
        Me.ColVencidoDataGridViewTextBoxColumn.DataPropertyName = "colVencido"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ColVencidoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColVencidoDataGridViewTextBoxColumn.HeaderText = "Venc."
        Me.ColVencidoDataGridViewTextBoxColumn.Name = "ColVencidoDataGridViewTextBoxColumn"
        Me.ColVencidoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColVencidoDataGridViewTextBoxColumn.Width = 55
        '
        'dsLotesVencidos
        '
        Me.dsLotesVencidos.DataSetName = "NewDataSet"
        Me.dsLotesVencidos.Tables.AddRange(New System.Data.DataTable() {Me.tblLotes})
        '
        'tblLotes
        '
        Me.tblLotes.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6})
        Me.tblLotes.TableName = "Lotes"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Código"
        Me.DataColumn1.ColumnName = "colCodigo"
        Me.DataColumn1.DefaultValue = ""
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Fase"
        Me.DataColumn2.ColumnName = "colFase"
        Me.DataColumn2.DefaultValue = ""
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "Estoque"
        Me.DataColumn3.ColumnName = "colEstoque"
        Me.DataColumn3.DefaultValue = "0"
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "Repicagem"
        Me.DataColumn4.ColumnName = "colDataRep"
        Me.DataColumn4.DataType = GetType(Date)
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "Data"
        Me.DataColumn5.ColumnName = "colData"
        Me.DataColumn5.DataType = GetType(Date)
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "Vencido"
        Me.DataColumn6.ColumnName = "colVencido"
        Me.DataColumn6.DataType = GetType(Short)
        Me.DataColumn6.DefaultValue = CType(0, Short)
        '
        'grpLotes
        '
        Me.grpLotes.Controls.Add(Me.txtProximoLote)
        Me.grpLotes.Controls.Add(Me.Label9)
        Me.grpLotes.Controls.Add(Me.Label2)
        Me.grpLotes.Controls.Add(Me.Label3)
        Me.grpLotes.Controls.Add(Me.cmbProduto)
        Me.grpLotes.Controls.Add(Me.txtM_F)
        Me.grpLotes.Controls.Add(Me.Label8)
        Me.grpLotes.Controls.Add(Me.cmbClone)
        Me.grpLotes.Controls.Add(Me.txtData)
        Me.grpLotes.Controls.Add(Me.Label4)
        Me.grpLotes.Controls.Add(Me.Label1)
        Me.grpLotes.Controls.Add(Me.txtQtdeMudas)
        Me.grpLotes.Controls.Add(Me.Label5)
        Me.grpLotes.Controls.Add(Me.cmbFase)
        Me.grpLotes.Location = New System.Drawing.Point(12, 63)
        Me.grpLotes.Name = "grpLotes"
        Me.grpLotes.Size = New System.Drawing.Size(571, 107)
        Me.grpLotes.TabIndex = 0
        Me.grpLotes.TabStop = False
        Me.grpLotes.Text = " Ordem de Produção "
        '
        'txtProximoLote
        '
        Me.txtProximoLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProximoLote.ForeColor = System.Drawing.Color.Blue
        Me.txtProximoLote.Location = New System.Drawing.Point(411, 78)
        Me.txtProximoLote.Name = "txtProximoLote"
        Me.txtProximoLote.Size = New System.Drawing.Size(100, 20)
        Me.txtProximoLote.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(361, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Mds/Fr:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Produto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Clone:"
        '
        'cmbProduto
        '
        Me.cmbProduto.DropDownHeight = 53
        Me.cmbProduto.FormattingEnabled = True
        Me.cmbProduto.IntegralHeight = False
        Me.cmbProduto.Location = New System.Drawing.Point(77, 25)
        Me.cmbProduto.Name = "cmbProduto"
        Me.cmbProduto.Size = New System.Drawing.Size(271, 21)
        Me.cmbProduto.TabIndex = 0
        '
        'txtM_F
        '
        Me.txtM_F.Location = New System.Drawing.Point(411, 53)
        Me.txtM_F.Name = "txtM_F"
        Me.txtM_F.Size = New System.Drawing.Size(31, 20)
        Me.txtM_F.TabIndex = 4
        Me.txtM_F.Text = "10"
        Me.txtM_F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(323, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Código do Lote:"
        '
        'cmbClone
        '
        Me.cmbClone.DropDownWidth = 150
        Me.cmbClone.FormattingEnabled = True
        Me.cmbClone.Location = New System.Drawing.Point(411, 25)
        Me.cmbClone.Name = "cmbClone"
        Me.cmbClone.Size = New System.Drawing.Size(138, 21)
        Me.cmbClone.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Quantidade:"
        '
        'txtQtdeMudas
        '
        Me.txtQtdeMudas.Location = New System.Drawing.Point(77, 52)
        Me.txtQtdeMudas.Name = "txtQtdeMudas"
        Me.txtQtdeMudas.Size = New System.Drawing.Size(68, 20)
        Me.txtQtdeMudas.TabIndex = 2
        Me.txtQtdeMudas.Text = "0"
        Me.txtQtdeMudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fase:"
        '
        'cmbFase
        '
        Me.cmbFase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFase.FormattingEnabled = True
        Me.cmbFase.Items.AddRange(New Object() {"Isolamento", "Multiplicação", "Alongamento", "Enraizamento", "Manutenção"})
        Me.cmbFase.Location = New System.Drawing.Point(204, 52)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(144, 21)
        Me.cmbFase.TabIndex = 3
        '
        'grpMeios
        '
        Me.grpMeios.Controls.Add(Me.rdLiquido)
        Me.grpMeios.Controls.Add(Me.rdSolido)
        Me.grpMeios.Controls.Add(Me.cmbMeios)
        Me.grpMeios.Controls.Add(Me.Label7)
        Me.grpMeios.Controls.Add(Me.Label6)
        Me.grpMeios.Controls.Add(Me.txtQtdeMeio)
        Me.grpMeios.Location = New System.Drawing.Point(6, 6)
        Me.grpMeios.Name = "grpMeios"
        Me.grpMeios.Size = New System.Drawing.Size(551, 73)
        Me.grpMeios.TabIndex = 1
        Me.grpMeios.TabStop = False
        Me.grpMeios.Text = " Meio de Cultura "
        '
        'rdLiquido
        '
        Me.rdLiquido.AutoSize = True
        Me.rdLiquido.Location = New System.Drawing.Point(89, 46)
        Me.rdLiquido.Name = "rdLiquido"
        Me.rdLiquido.Size = New System.Drawing.Size(61, 17)
        Me.rdLiquido.TabIndex = 3
        Me.rdLiquido.TabStop = True
        Me.rdLiquido.Text = "Líquido"
        Me.rdLiquido.UseVisualStyleBackColor = True
        '
        'rdSolido
        '
        Me.rdSolido.AutoSize = True
        Me.rdSolido.Location = New System.Drawing.Point(18, 46)
        Me.rdSolido.Name = "rdSolido"
        Me.rdSolido.Size = New System.Drawing.Size(54, 17)
        Me.rdSolido.TabIndex = 2
        Me.rdSolido.TabStop = True
        Me.rdSolido.Text = "Sólido"
        Me.rdSolido.UseVisualStyleBackColor = True
        '
        'cmbMeios
        '
        Me.cmbMeios.FormattingEnabled = True
        Me.cmbMeios.Location = New System.Drawing.Point(198, 19)
        Me.cmbMeios.Name = "cmbMeios"
        Me.cmbMeios.Size = New System.Drawing.Size(337, 21)
        Me.cmbMeios.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(160, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Meio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Quantidade (L):"
        '
        'txtQtdeMeio
        '
        Me.txtQtdeMeio.Location = New System.Drawing.Point(101, 19)
        Me.txtQtdeMeio.Name = "txtQtdeMeio"
        Me.txtQtdeMeio.Size = New System.Drawing.Size(49, 20)
        Me.txtQtdeMeio.TabIndex = 0
        Me.txtQtdeMeio.Text = "0"
        Me.txtQtdeMeio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(427, 484)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Incluir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(508, 484)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(12, 418)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(571, 60)
        Me.txtObs.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 402)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Observações"
        '
        'rdRepicagem
        '
        Me.rdRepicagem.AutoSize = True
        Me.rdRepicagem.Checked = True
        Me.rdRepicagem.Location = New System.Drawing.Point(6, 18)
        Me.rdRepicagem.Name = "rdRepicagem"
        Me.rdRepicagem.Size = New System.Drawing.Size(79, 17)
        Me.rdRepicagem.TabIndex = 0
        Me.rdRepicagem.TabStop = True
        Me.rdRepicagem.Text = "Repicagem"
        Me.rdRepicagem.UseVisualStyleBackColor = True
        '
        'rdPlantio
        '
        Me.rdPlantio.AutoSize = True
        Me.rdPlantio.Location = New System.Drawing.Point(91, 18)
        Me.rdPlantio.Name = "rdPlantio"
        Me.rdPlantio.Size = New System.Drawing.Size(57, 17)
        Me.rdPlantio.TabIndex = 1
        Me.rdPlantio.Text = "Plantio"
        Me.rdPlantio.UseVisualStyleBackColor = True
        '
        'rdGeral
        '
        Me.rdGeral.AutoSize = True
        Me.rdGeral.Location = New System.Drawing.Point(153, 18)
        Me.rdGeral.Name = "rdGeral"
        Me.rdGeral.Size = New System.Drawing.Size(115, 17)
        Me.rdGeral.TabIndex = 2
        Me.rdGeral.Text = "Orientações Gerais"
        Me.rdGeral.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Controls.Add(Me.rdGeral)
        Me.GroupBox1.Controls.Add(Me.rdRepicagem)
        Me.GroupBox1.Controls.Add(Me.rdPlantio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Tipo "
        '
        'tcInformacoes
        '
        Me.tcInformacoes.Controls.Add(Me.TabPage1)
        Me.tcInformacoes.Controls.Add(Me.TabPage2)
        Me.tcInformacoes.Location = New System.Drawing.Point(12, 176)
        Me.tcInformacoes.Name = "tcInformacoes"
        Me.tcInformacoes.SelectedIndex = 0
        Me.tcInformacoes.Size = New System.Drawing.Size(571, 219)
        Me.tcInformacoes.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.cmbFrasco)
        Me.TabPage1.Controls.Add(Me.grpMeios)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(563, 193)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Informações"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(6, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Tipo do Frasco:"
        '
        'cmbFrasco
        '
        Me.cmbFrasco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFrasco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFrasco.FormattingEnabled = True
        Me.cmbFrasco.Items.AddRange(New Object() {"Frasco de Vidro", "Tubo de Ensaio", "Erlenmeyer", "Pote plástico 500g", "Pote plástico 250g", "Biorreator", "Especial"})
        Me.cmbFrasco.Location = New System.Drawing.Point(93, 86)
        Me.cmbFrasco.Name = "cmbFrasco"
        Me.cmbFrasco.Size = New System.Drawing.Size(119, 21)
        Me.cmbFrasco.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgProducao)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(563, 193)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Lotes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblID.Location = New System.Drawing.Point(476, 16)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(84, 19)
        Me.lblID.TabIndex = 3
        Me.lblID.Text = "..."
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblID.Visible = False
        '
        'frmProgramacaoSemanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 521)
        Me.Controls.Add(Me.grpLotes)
        Me.Controls.Add(Me.tcInformacoes)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgramacaoSemanal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ordens de Produção"
        CType(Me.dgProducao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsLotesVencidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLotes.ResumeLayout(False)
        Me.grpLotes.PerformLayout()
        Me.grpMeios.ResumeLayout(False)
        Me.grpMeios.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tcInformacoes.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProducao As System.Windows.Forms.DataGridView
    Friend WithEvents grpLotes As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFase As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQtdeMudas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbClone As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProduto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpMeios As System.Windows.Forms.GroupBox
    Friend WithEvents rdLiquido As System.Windows.Forms.RadioButton
    Friend WithEvents rdSolido As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMeios As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtQtdeMeio As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dsLotesVencidos As System.Data.DataSet
    Friend WithEvents tblLotes As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtM_F As System.Windows.Forms.TextBox
    Friend WithEvents rdRepicagem As System.Windows.Forms.RadioButton
    Friend WithEvents rdPlantio As System.Windows.Forms.RadioButton
    Friend WithEvents rdGeral As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tcInformacoes As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ColCodigoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFaseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEstoqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDataRepDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDataDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVencidoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbFrasco As System.Windows.Forms.ComboBox
    Friend WithEvents txtProximoLote As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
End Class
