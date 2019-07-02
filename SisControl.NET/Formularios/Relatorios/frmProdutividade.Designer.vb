<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutividade
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btVer = New System.Windows.Forms.Button()
        Me.btExcel = New System.Windows.Forms.Button()
        Me.dgProdutividade = New System.Windows.Forms.DataGridView()
        Me.MesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProduzidoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContaminadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MdsHoraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dsResultado = New System.Data.DataSet()
        Me.Prod = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.txtAno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMesINI = New System.Windows.Forms.TextBox()
        Me.txtMesFIM = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.grpResumo = New System.Windows.Forms.GroupBox()
        Me.lblMedHoras = New System.Windows.Forms.Label()
        Me.lblMedProd = New System.Windows.Forms.Label()
        Me.lblMedCont = New System.Windows.Forms.Label()
        Me.lblMedPercent = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotPercent = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTotHoras = New System.Windows.Forms.Label()
        Me.lblTotCont = New System.Windows.Forms.Label()
        Me.lblTotProd = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgProdutividade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpResumo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mês Inicial"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Mês Final"
        '
        'btVer
        '
        Me.btVer.Location = New System.Drawing.Point(522, 330)
        Me.btVer.Name = "btVer"
        Me.btVer.Size = New System.Drawing.Size(88, 23)
        Me.btVer.TabIndex = 4
        Me.btVer.Text = "Ver Resultado"
        Me.btVer.UseVisualStyleBackColor = True
        '
        'btExcel
        '
        Me.btExcel.Location = New System.Drawing.Point(522, 359)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(88, 23)
        Me.btExcel.TabIndex = 5
        Me.btExcel.Text = "Gerar no Excel"
        Me.btExcel.UseVisualStyleBackColor = True
        '
        'dgProdutividade
        '
        Me.dgProdutividade.AllowUserToAddRows = False
        Me.dgProdutividade.AllowUserToDeleteRows = False
        Me.dgProdutividade.AllowUserToOrderColumns = True
        Me.dgProdutividade.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProdutividade.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProdutividade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProdutividade.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MesDataGridViewTextBoxColumn, Me.CodDataGridViewTextBoxColumn, Me.NomeDataGridViewTextBoxColumn, Me.ProduzidoDataGridViewTextBoxColumn, Me.ContaminadoDataGridViewTextBoxColumn, Me.PercentDataGridViewTextBoxColumn, Me.HorasDataGridViewTextBoxColumn, Me.MdsHoraDataGridViewTextBoxColumn})
        Me.dgProdutividade.DataMember = "Prod"
        Me.dgProdutividade.DataSource = Me.dsResultado
        Me.dgProdutividade.Location = New System.Drawing.Point(11, 12)
        Me.dgProdutividade.Name = "dgProdutividade"
        Me.dgProdutividade.ReadOnly = True
        Me.dgProdutividade.RowHeadersWidth = 20
        Me.dgProdutividade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgProdutividade.Size = New System.Drawing.Size(483, 286)
        Me.dgProdutividade.TabIndex = 6
        '
        'MesDataGridViewTextBoxColumn
        '
        Me.MesDataGridViewTextBoxColumn.DataPropertyName = "mes"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.MesDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MesDataGridViewTextBoxColumn.HeaderText = "Mês"
        Me.MesDataGridViewTextBoxColumn.Name = "MesDataGridViewTextBoxColumn"
        Me.MesDataGridViewTextBoxColumn.ReadOnly = True
        Me.MesDataGridViewTextBoxColumn.Width = 40
        '
        'CodDataGridViewTextBoxColumn
        '
        Me.CodDataGridViewTextBoxColumn.DataPropertyName = "Cod"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.CodDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CodDataGridViewTextBoxColumn.HeaderText = "Cód"
        Me.CodDataGridViewTextBoxColumn.Name = "CodDataGridViewTextBoxColumn"
        Me.CodDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodDataGridViewTextBoxColumn.Width = 40
        '
        'NomeDataGridViewTextBoxColumn
        '
        Me.NomeDataGridViewTextBoxColumn.DataPropertyName = "Nome"
        Me.NomeDataGridViewTextBoxColumn.HeaderText = "Nome"
        Me.NomeDataGridViewTextBoxColumn.Name = "NomeDataGridViewTextBoxColumn"
        Me.NomeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProduzidoDataGridViewTextBoxColumn
        '
        Me.ProduzidoDataGridViewTextBoxColumn.DataPropertyName = "Produzido"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ProduzidoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ProduzidoDataGridViewTextBoxColumn.HeaderText = "Prod"
        Me.ProduzidoDataGridViewTextBoxColumn.Name = "ProduzidoDataGridViewTextBoxColumn"
        Me.ProduzidoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProduzidoDataGridViewTextBoxColumn.Width = 50
        '
        'ContaminadoDataGridViewTextBoxColumn
        '
        Me.ContaminadoDataGridViewTextBoxColumn.DataPropertyName = "Contaminado"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ContaminadoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ContaminadoDataGridViewTextBoxColumn.HeaderText = "Cont"
        Me.ContaminadoDataGridViewTextBoxColumn.Name = "ContaminadoDataGridViewTextBoxColumn"
        Me.ContaminadoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ContaminadoDataGridViewTextBoxColumn.Width = 50
        '
        'PercentDataGridViewTextBoxColumn
        '
        Me.PercentDataGridViewTextBoxColumn.DataPropertyName = "Percent"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "P1"
        DataGridViewCellStyle6.NullValue = "0"
        Me.PercentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.PercentDataGridViewTextBoxColumn.HeaderText = "%"
        Me.PercentDataGridViewTextBoxColumn.Name = "PercentDataGridViewTextBoxColumn"
        Me.PercentDataGridViewTextBoxColumn.ReadOnly = True
        Me.PercentDataGridViewTextBoxColumn.Width = 50
        '
        'HorasDataGridViewTextBoxColumn
        '
        Me.HorasDataGridViewTextBoxColumn.DataPropertyName = "Horas"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N1"
        DataGridViewCellStyle7.NullValue = "0"
        Me.HorasDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.HorasDataGridViewTextBoxColumn.HeaderText = "Horas"
        Me.HorasDataGridViewTextBoxColumn.Name = "HorasDataGridViewTextBoxColumn"
        Me.HorasDataGridViewTextBoxColumn.ReadOnly = True
        Me.HorasDataGridViewTextBoxColumn.Width = 50
        '
        'MdsHoraDataGridViewTextBoxColumn
        '
        Me.MdsHoraDataGridViewTextBoxColumn.DataPropertyName = "Mds_Hora"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N1"
        DataGridViewCellStyle8.NullValue = "0"
        Me.MdsHoraDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.MdsHoraDataGridViewTextBoxColumn.HeaderText = "Mds/Hora"
        Me.MdsHoraDataGridViewTextBoxColumn.Name = "MdsHoraDataGridViewTextBoxColumn"
        Me.MdsHoraDataGridViewTextBoxColumn.ReadOnly = True
        Me.MdsHoraDataGridViewTextBoxColumn.Width = 60
        '
        'dsResultado
        '
        Me.dsResultado.DataSetName = "dsResult"
        Me.dsResultado.Tables.AddRange(New System.Data.DataTable() {Me.Prod})
        '
        'Prod
        '
        Me.Prod.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8})
        Me.Prod.TableName = "Prod"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Mês"
        Me.DataColumn1.ColumnName = "mes"
        Me.DataColumn1.DataType = GetType(Integer)
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Cód"
        Me.DataColumn2.ColumnName = "Cod"
        Me.DataColumn2.DefaultValue = "-1"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Nome"
        Me.DataColumn3.MaxLength = 60
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Produzido"
        Me.DataColumn4.DataType = GetType(Integer)
        Me.DataColumn4.DefaultValue = 0
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "Cont"
        Me.DataColumn5.ColumnName = "Contaminado"
        Me.DataColumn5.DataType = GetType(Integer)
        Me.DataColumn5.DefaultValue = 0
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "%"
        Me.DataColumn6.ColumnName = "Percent"
        Me.DataColumn6.DataType = GetType(Double)
        Me.DataColumn6.DefaultValue = 0R
        '
        'DataColumn7
        '
        Me.DataColumn7.Caption = "Horas"
        Me.DataColumn7.ColumnName = "Horas"
        Me.DataColumn7.DataType = GetType(Integer)
        '
        'DataColumn8
        '
        Me.DataColumn8.Caption = "Mds/Hora"
        Me.DataColumn8.ColumnName = "Mds_Hora"
        Me.DataColumn8.DataType = GetType(Double)
        Me.DataColumn8.DefaultValue = 0R
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(11, 42)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(57, 20)
        Me.txtAno.TabIndex = 7
        Me.txtAno.Text = "2011"
        Me.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ano Base"
        '
        'txtMesINI
        '
        Me.txtMesINI.Location = New System.Drawing.Point(11, 87)
        Me.txtMesINI.Name = "txtMesINI"
        Me.txtMesINI.Size = New System.Drawing.Size(30, 20)
        Me.txtMesINI.TabIndex = 9
        Me.txtMesINI.Text = "1"
        Me.txtMesINI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMesFIM
        '
        Me.txtMesFIM.Location = New System.Drawing.Point(11, 126)
        Me.txtMesFIM.Name = "txtMesFIM"
        Me.txtMesFIM.Size = New System.Drawing.Size(30, 20)
        Me.txtMesFIM.TabIndex = 10
        Me.txtMesFIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(15, 414)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(25, 13)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "   ..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMesFIM)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMesINI)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Location = New System.Drawing.Point(512, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(99, 164)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parâmetros"
        '
        'btPrint
        '
        Me.btPrint.Location = New System.Drawing.Point(523, 388)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(87, 23)
        Me.btPrint.TabIndex = 13
        Me.btPrint.Text = "Imprimir"
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'grpResumo
        '
        Me.grpResumo.Controls.Add(Me.lblMedHoras)
        Me.grpResumo.Controls.Add(Me.lblMedProd)
        Me.grpResumo.Controls.Add(Me.lblMedCont)
        Me.grpResumo.Controls.Add(Me.lblMedPercent)
        Me.grpResumo.Controls.Add(Me.Label12)
        Me.grpResumo.Controls.Add(Me.lblTotPercent)
        Me.grpResumo.Controls.Add(Me.Label10)
        Me.grpResumo.Controls.Add(Me.lblTotHoras)
        Me.grpResumo.Controls.Add(Me.lblTotCont)
        Me.grpResumo.Controls.Add(Me.lblTotProd)
        Me.grpResumo.Controls.Add(Me.Label7)
        Me.grpResumo.Controls.Add(Me.Label8)
        Me.grpResumo.Controls.Add(Me.Label9)
        Me.grpResumo.Controls.Add(Me.Label6)
        Me.grpResumo.Controls.Add(Me.Label5)
        Me.grpResumo.Controls.Add(Me.Label4)
        Me.grpResumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpResumo.Location = New System.Drawing.Point(11, 304)
        Me.grpResumo.Name = "grpResumo"
        Me.grpResumo.Size = New System.Drawing.Size(483, 107)
        Me.grpResumo.TabIndex = 14
        Me.grpResumo.TabStop = False
        Me.grpResumo.Text = " Resumo do Período "
        '
        'lblMedHoras
        '
        Me.lblMedHoras.AutoSize = True
        Me.lblMedHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedHoras.Location = New System.Drawing.Point(326, 83)
        Me.lblMedHoras.Name = "lblMedHoras"
        Me.lblMedHoras.Size = New System.Drawing.Size(16, 13)
        Me.lblMedHoras.TabIndex = 15
        Me.lblMedHoras.Text = "..."
        '
        'lblMedProd
        '
        Me.lblMedProd.AutoSize = True
        Me.lblMedProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedProd.Location = New System.Drawing.Point(326, 26)
        Me.lblMedProd.Name = "lblMedProd"
        Me.lblMedProd.Size = New System.Drawing.Size(16, 13)
        Me.lblMedProd.TabIndex = 14
        Me.lblMedProd.Text = "..."
        '
        'lblMedCont
        '
        Me.lblMedCont.AutoSize = True
        Me.lblMedCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedCont.Location = New System.Drawing.Point(326, 44)
        Me.lblMedCont.Name = "lblMedCont"
        Me.lblMedCont.Size = New System.Drawing.Size(16, 13)
        Me.lblMedCont.TabIndex = 13
        Me.lblMedCont.Text = "..."
        '
        'lblMedPercent
        '
        Me.lblMedPercent.AutoSize = True
        Me.lblMedPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedPercent.Location = New System.Drawing.Point(326, 65)
        Me.lblMedPercent.Name = "lblMedPercent"
        Me.lblMedPercent.Size = New System.Drawing.Size(16, 13)
        Me.lblMedPercent.TabIndex = 12
        Me.lblMedPercent.Text = "..."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(221, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "% Contaminado:"
        '
        'lblTotPercent
        '
        Me.lblTotPercent.AutoSize = True
        Me.lblTotPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotPercent.Location = New System.Drawing.Point(111, 64)
        Me.lblTotPercent.Name = "lblTotPercent"
        Me.lblTotPercent.Size = New System.Drawing.Size(16, 13)
        Me.lblTotPercent.TabIndex = 10
        Me.lblTotPercent.Text = "..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "% Contaminado:"
        '
        'lblTotHoras
        '
        Me.lblTotHoras.AutoSize = True
        Me.lblTotHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHoras.Location = New System.Drawing.Point(111, 83)
        Me.lblTotHoras.Name = "lblTotHoras"
        Me.lblTotHoras.Size = New System.Drawing.Size(16, 13)
        Me.lblTotHoras.TabIndex = 8
        Me.lblTotHoras.Text = "..."
        '
        'lblTotCont
        '
        Me.lblTotCont.AutoSize = True
        Me.lblTotCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotCont.Location = New System.Drawing.Point(111, 45)
        Me.lblTotCont.Name = "lblTotCont"
        Me.lblTotCont.Size = New System.Drawing.Size(16, 13)
        Me.lblTotCont.TabIndex = 7
        Me.lblTotCont.Text = "..."
        '
        'lblTotProd
        '
        Me.lblTotProd.AutoSize = True
        Me.lblTotProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotProd.Location = New System.Drawing.Point(111, 26)
        Me.lblTotProd.Name = "lblTotProd"
        Me.lblTotProd.Size = New System.Drawing.Size(16, 13)
        Me.lblTotProd.TabIndex = 6
        Me.lblTotProd.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(221, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Média de Horas:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(221, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Média Contaminado:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(221, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Média Produzida:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total de Horas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Contaminado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total Produzido:"
        '
        'frmProdutividade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 436)
        Me.Controls.Add(Me.grpResumo)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.dgProdutividade)
        Me.Controls.Add(Me.btExcel)
        Me.Controls.Add(Me.btVer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProdutividade"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtividade de Repicadores"
        CType(Me.dgProdutividade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpResumo.ResumeLayout(False)
        Me.grpResumo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btVer As System.Windows.Forms.Button
    Friend WithEvents btExcel As System.Windows.Forms.Button
    Friend WithEvents dgProdutividade As System.Windows.Forms.DataGridView
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMesINI As System.Windows.Forms.TextBox
    Friend WithEvents txtMesFIM As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents Prod As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents dsResultado As System.Data.DataSet
    Friend WithEvents grpResumo As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotHoras As System.Windows.Forms.Label
    Friend WithEvents lblTotCont As System.Windows.Forms.Label
    Friend WithEvents lblTotProd As System.Windows.Forms.Label
    Friend WithEvents lblTotPercent As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMedHoras As System.Windows.Forms.Label
    Friend WithEvents lblMedProd As System.Windows.Forms.Label
    Friend WithEvents lblMedCont As System.Windows.Forms.Label
    Friend WithEvents lblMedPercent As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProduzidoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContaminadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HorasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MdsHoraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
