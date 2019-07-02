<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServCodBar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServCodBar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpFrascos = New System.Windows.Forms.GroupBox()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.ColMER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMUD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoCOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dsFrascos = New System.Data.DataSet()
        Me.dtFrascos = New System.Data.DataTable()
        Me.dcMER = New System.Data.DataColumn()
        Me.dcLOT = New System.Data.DataColumn()
        Me.dcCLO = New System.Data.DataColumn()
        Me.dcFRA = New System.Data.DataColumn()
        Me.dcMUD = New System.Data.DataColumn()
        Me.dcMOT = New System.Data.DataColumn()
        Me.dcID = New System.Data.DataColumn()
        Me.dcCOD = New System.Data.DataColumn()
        Me.dtOrquideas = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.cmbMotivo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btConfirma = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabLotes = New System.Windows.Forms.TabPage()
        Me.pbProgresso = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.TabOrquideas = New System.Windows.Forms.TabPage()
        Me.pgProcesso = New System.Windows.Forms.ProgressBar()
        Me.chkAutoO = New System.Windows.Forms.CheckBox()
        Me.txtTotalO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgFrascosO = New System.Windows.Forms.DataGridView()
        Me.ColIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLoteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTipoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNMudasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVidroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMotivoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btFechaO = New System.Windows.Forms.Button()
        Me.btConfirmaO = New System.Windows.Forms.Button()
        Me.cmbMotivoO = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDataO = New System.Windows.Forms.MaskedTextBox()
        Me.txtCodBarO = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpFrascos.SuspendLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtOrquideas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabLotes.SuspendLayout()
        Me.TabOrquideas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgFrascosO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data:"
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Location = New System.Drawing.Point(60, 15)
        Me.txtData.Mask = "99/99/9999"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(88, 26)
        Me.txtData.TabIndex = 1
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarras.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigoBarras.Location = New System.Drawing.Point(10, 78)
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(187, 31)
        Me.txtCodigoBarras.TabIndex = 2
        Me.txtCodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Código de Barras"
        '
        'grpFrascos
        '
        Me.grpFrascos.Controls.Add(Me.dgFrascos)
        Me.grpFrascos.Location = New System.Drawing.Point(10, 122)
        Me.grpFrascos.Name = "grpFrascos"
        Me.grpFrascos.Size = New System.Drawing.Size(506, 285)
        Me.grpFrascos.TabIndex = 4
        Me.grpFrascos.TabStop = False
        Me.grpFrascos.Text = " Frascos Processados "
        '
        'dgFrascos
        '
        Me.dgFrascos.AllowUserToAddRows = False
        Me.dgFrascos.AllowUserToOrderColumns = True
        Me.dgFrascos.AutoGenerateColumns = False
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMER, Me.ColLOT, Me.ColCLO, Me.ColFRA, Me.ColMUD, Me.colMotivo, Me.CoID, Me.CoCOD})
        Me.dgFrascos.DataMember = "tblFrascos"
        Me.dgFrascos.DataSource = Me.dsFrascos
        Me.dgFrascos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFrascos.Location = New System.Drawing.Point(3, 16)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgFrascos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFrascos.Size = New System.Drawing.Size(500, 266)
        Me.dgFrascos.TabIndex = 0
        '
        'ColMER
        '
        Me.ColMER.DataPropertyName = "colMER"
        Me.ColMER.HeaderText = "colMER"
        Me.ColMER.Name = "ColMER"
        '
        'ColLOT
        '
        Me.ColLOT.DataPropertyName = "colLOT"
        Me.ColLOT.HeaderText = "colLOT"
        Me.ColLOT.Name = "ColLOT"
        '
        'ColCLO
        '
        Me.ColCLO.DataPropertyName = "colCLO"
        Me.ColCLO.HeaderText = "colCLO"
        Me.ColCLO.Name = "ColCLO"
        '
        'ColFRA
        '
        Me.ColFRA.DataPropertyName = "colFRA"
        Me.ColFRA.HeaderText = "colFRA"
        Me.ColFRA.Name = "ColFRA"
        '
        'ColMUD
        '
        Me.ColMUD.DataPropertyName = "colMUD"
        Me.ColMUD.HeaderText = "colMUD"
        Me.ColMUD.Name = "ColMUD"
        '
        'colMotivo
        '
        Me.colMotivo.DataPropertyName = "colMOT"
        Me.colMotivo.HeaderText = "colMOT"
        Me.colMotivo.Name = "colMotivo"
        '
        'CoID
        '
        Me.CoID.DataPropertyName = "coID"
        Me.CoID.HeaderText = "coID"
        Me.CoID.Name = "CoID"
        '
        'CoCOD
        '
        Me.CoCOD.DataPropertyName = "coCOD"
        Me.CoCOD.HeaderText = "coCOD"
        Me.CoCOD.Name = "CoCOD"
        '
        'dsFrascos
        '
        Me.dsFrascos.DataSetName = "NewDataSet"
        Me.dsFrascos.Tables.AddRange(New System.Data.DataTable() {Me.dtFrascos, Me.dtOrquideas})
        '
        'dtFrascos
        '
        Me.dtFrascos.Columns.AddRange(New System.Data.DataColumn() {Me.dcMER, Me.dcLOT, Me.dcCLO, Me.dcFRA, Me.dcMUD, Me.dcMOT, Me.dcID, Me.dcCOD})
        Me.dtFrascos.TableName = "tblFrascos"
        '
        'dcMER
        '
        Me.dcMER.Caption = "Merc"
        Me.dcMER.ColumnName = "colMER"
        Me.dcMER.DataType = GetType(Short)
        '
        'dcLOT
        '
        Me.dcLOT.Caption = "Lote"
        Me.dcLOT.ColumnName = "colLOT"
        Me.dcLOT.DataType = GetType(Short)
        '
        'dcCLO
        '
        Me.dcCLO.Caption = "Clone"
        Me.dcCLO.ColumnName = "colCLO"
        Me.dcCLO.DataType = GetType(Short)
        '
        'dcFRA
        '
        Me.dcFRA.Caption = "Frasco"
        Me.dcFRA.ColumnName = "colFRA"
        Me.dcFRA.DataType = GetType(Short)
        '
        'dcMUD
        '
        Me.dcMUD.Caption = "Mudas"
        Me.dcMUD.ColumnName = "colMUD"
        Me.dcMUD.DataType = GetType(Short)
        '
        'dcMOT
        '
        Me.dcMOT.Caption = "Motivo"
        Me.dcMOT.ColumnName = "colMOT"
        Me.dcMOT.MaxLength = 1
        '
        'dcID
        '
        Me.dcID.Caption = "ID"
        Me.dcID.ColumnName = "coID"
        Me.dcID.DataType = GetType(Integer)
        '
        'dcCOD
        '
        Me.dcCOD.Caption = "Cód"
        Me.dcCOD.ColumnName = "coCOD"
        Me.dcCOD.DataType = GetType(Integer)
        '
        'dtOrquideas
        '
        Me.dtOrquideas.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6})
        Me.dtOrquideas.TableName = "tblOrquideas"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "ID"
        Me.DataColumn1.ColumnName = "colID"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Lote"
        Me.DataColumn2.ColumnName = "colLote"
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "Tipo"
        Me.DataColumn3.ColumnName = "colTipo"
        Me.DataColumn3.MaxLength = 1
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "Nº Mudas"
        Me.DataColumn4.ColumnName = "colNMudas"
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "Vidro"
        Me.DataColumn5.ColumnName = "colVidro"
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "Motivo"
        Me.DataColumn6.ColumnName = "colMotivo"
        Me.DataColumn6.MaxLength = 1
        '
        'cmbMotivo
        '
        Me.cmbMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMotivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.Items.AddRange(New Object() {"Fungo", "Bactéria", "Oxidação", "Plantio", "Repicagem"})
        Me.cmbMotivo.Location = New System.Drawing.Point(267, 54)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(104, 21)
        Me.cmbMotivo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(222, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Motivo"
        '
        'btConfirma
        '
        Me.btConfirma.Location = New System.Drawing.Point(340, 413)
        Me.btConfirma.Name = "btConfirma"
        Me.btConfirma.Size = New System.Drawing.Size(95, 23)
        Me.btConfirma.TabIndex = 5
        Me.btConfirma.Text = "Confirmar - F12"
        Me.btConfirma.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(441, 413)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "&Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nº de Frascos:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(395, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(113, 113)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotal.Location = New System.Drawing.Point(98, 418)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(11, 13)
        Me.txtTotal.TabIndex = 12
        Me.txtTotal.Text = " "
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Location = New System.Drawing.Point(267, 91)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(79, 17)
        Me.chkAuto.TabIndex = 13
        Me.chkAuto.Text = "Automático"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabLotes)
        Me.TabControl1.Controls.Add(Me.TabOrquideas)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(536, 470)
        Me.TabControl1.TabIndex = 14
        '
        'TabLotes
        '
        Me.TabLotes.Controls.Add(Me.pbProgresso)
        Me.TabLotes.Controls.Add(Me.Label8)
        Me.TabLotes.Controls.Add(Me.cmbOperador)
        Me.TabLotes.Controls.Add(Me.Label1)
        Me.TabLotes.Controls.Add(Me.chkAuto)
        Me.TabLotes.Controls.Add(Me.txtData)
        Me.TabLotes.Controls.Add(Me.txtTotal)
        Me.TabLotes.Controls.Add(Me.txtCodigoBarras)
        Me.TabLotes.Controls.Add(Me.PictureBox1)
        Me.TabLotes.Controls.Add(Me.Label2)
        Me.TabLotes.Controls.Add(Me.Label4)
        Me.TabLotes.Controls.Add(Me.grpFrascos)
        Me.TabLotes.Controls.Add(Me.Button1)
        Me.TabLotes.Controls.Add(Me.cmbMotivo)
        Me.TabLotes.Controls.Add(Me.btConfirma)
        Me.TabLotes.Controls.Add(Me.Label3)
        Me.TabLotes.Location = New System.Drawing.Point(4, 22)
        Me.TabLotes.Name = "TabLotes"
        Me.TabLotes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLotes.Size = New System.Drawing.Size(528, 444)
        Me.TabLotes.TabIndex = 0
        Me.TabLotes.Text = "Lotes"
        Me.TabLotes.UseVisualStyleBackColor = True
        '
        'pbProgresso
        '
        Me.pbProgresso.Location = New System.Drawing.Point(135, 413)
        Me.pbProgresso.Name = "pbProgresso"
        Me.pbProgresso.Size = New System.Drawing.Size(190, 23)
        Me.pbProgresso.TabIndex = 16
        Me.pbProgresso.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(207, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Operador:"
        '
        'cmbOperador
        '
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(267, 17)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(121, 21)
        Me.cmbOperador.TabIndex = 14
        '
        'TabOrquideas
        '
        Me.TabOrquideas.Controls.Add(Me.pgProcesso)
        Me.TabOrquideas.Controls.Add(Me.chkAutoO)
        Me.TabOrquideas.Controls.Add(Me.txtTotalO)
        Me.TabOrquideas.Controls.Add(Me.Label9)
        Me.TabOrquideas.Controls.Add(Me.GroupBox1)
        Me.TabOrquideas.Controls.Add(Me.btFechaO)
        Me.TabOrquideas.Controls.Add(Me.btConfirmaO)
        Me.TabOrquideas.Controls.Add(Me.cmbMotivoO)
        Me.TabOrquideas.Controls.Add(Me.Label7)
        Me.TabOrquideas.Controls.Add(Me.Label5)
        Me.TabOrquideas.Controls.Add(Me.txtDataO)
        Me.TabOrquideas.Controls.Add(Me.txtCodBarO)
        Me.TabOrquideas.Controls.Add(Me.PictureBox2)
        Me.TabOrquideas.Controls.Add(Me.Label6)
        Me.TabOrquideas.Location = New System.Drawing.Point(4, 22)
        Me.TabOrquideas.Name = "TabOrquideas"
        Me.TabOrquideas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOrquideas.Size = New System.Drawing.Size(528, 444)
        Me.TabOrquideas.TabIndex = 1
        Me.TabOrquideas.Text = "Orquídeas"
        Me.TabOrquideas.UseVisualStyleBackColor = True
        '
        'pgProcesso
        '
        Me.pgProcesso.Location = New System.Drawing.Point(113, 417)
        Me.pgProcesso.Name = "pgProcesso"
        Me.pgProcesso.Size = New System.Drawing.Size(218, 15)
        Me.pgProcesso.TabIndex = 25
        '
        'chkAutoO
        '
        Me.chkAutoO.AutoSize = True
        Me.chkAutoO.Location = New System.Drawing.Point(267, 53)
        Me.chkAutoO.Name = "chkAutoO"
        Me.chkAutoO.Size = New System.Drawing.Size(79, 17)
        Me.chkAutoO.TabIndex = 5
        Me.chkAutoO.Text = "Automático"
        Me.chkAutoO.UseVisualStyleBackColor = True
        '
        'txtTotalO
        '
        Me.txtTotalO.AutoSize = True
        Me.txtTotalO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalO.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotalO.Location = New System.Drawing.Point(90, 418)
        Me.txtTotalO.Name = "txtTotalO"
        Me.txtTotalO.Size = New System.Drawing.Size(11, 13)
        Me.txtTotalO.TabIndex = 24
        Me.txtTotalO.Text = " "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 418)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Nº de Frascos:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgFrascosO)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(506, 285)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Frascos Processados "
        '
        'dgFrascosO
        '
        Me.dgFrascosO.AllowUserToAddRows = False
        Me.dgFrascosO.AllowUserToOrderColumns = True
        Me.dgFrascosO.AutoGenerateColumns = False
        Me.dgFrascosO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascosO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIDDataGridViewTextBoxColumn, Me.ColLoteDataGridViewTextBoxColumn, Me.ColTipoDataGridViewTextBoxColumn, Me.ColNMudasDataGridViewTextBoxColumn, Me.ColVidroDataGridViewTextBoxColumn, Me.ColMotivoDataGridViewTextBoxColumn})
        Me.dgFrascosO.DataMember = "tblOrquideas"
        Me.dgFrascosO.DataSource = Me.dsFrascos
        Me.dgFrascosO.Location = New System.Drawing.Point(6, 17)
        Me.dgFrascosO.Name = "dgFrascosO"
        Me.dgFrascosO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgFrascosO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFrascosO.Size = New System.Drawing.Size(492, 260)
        Me.dgFrascosO.TabIndex = 0
        '
        'ColIDDataGridViewTextBoxColumn
        '
        Me.ColIDDataGridViewTextBoxColumn.DataPropertyName = "colID"
        Me.ColIDDataGridViewTextBoxColumn.HeaderText = "colID"
        Me.ColIDDataGridViewTextBoxColumn.Name = "ColIDDataGridViewTextBoxColumn"
        '
        'ColLoteDataGridViewTextBoxColumn
        '
        Me.ColLoteDataGridViewTextBoxColumn.DataPropertyName = "colLote"
        Me.ColLoteDataGridViewTextBoxColumn.HeaderText = "colLote"
        Me.ColLoteDataGridViewTextBoxColumn.Name = "ColLoteDataGridViewTextBoxColumn"
        '
        'ColTipoDataGridViewTextBoxColumn
        '
        Me.ColTipoDataGridViewTextBoxColumn.DataPropertyName = "colTipo"
        Me.ColTipoDataGridViewTextBoxColumn.HeaderText = "colTipo"
        Me.ColTipoDataGridViewTextBoxColumn.Name = "ColTipoDataGridViewTextBoxColumn"
        '
        'ColNMudasDataGridViewTextBoxColumn
        '
        Me.ColNMudasDataGridViewTextBoxColumn.DataPropertyName = "colNMudas"
        Me.ColNMudasDataGridViewTextBoxColumn.HeaderText = "colNMudas"
        Me.ColNMudasDataGridViewTextBoxColumn.Name = "ColNMudasDataGridViewTextBoxColumn"
        '
        'ColVidroDataGridViewTextBoxColumn
        '
        Me.ColVidroDataGridViewTextBoxColumn.DataPropertyName = "colVidro"
        Me.ColVidroDataGridViewTextBoxColumn.HeaderText = "colVidro"
        Me.ColVidroDataGridViewTextBoxColumn.Name = "ColVidroDataGridViewTextBoxColumn"
        '
        'ColMotivoDataGridViewTextBoxColumn
        '
        Me.ColMotivoDataGridViewTextBoxColumn.DataPropertyName = "colMotivo"
        Me.ColMotivoDataGridViewTextBoxColumn.HeaderText = "colMotivo"
        Me.ColMotivoDataGridViewTextBoxColumn.Name = "ColMotivoDataGridViewTextBoxColumn"
        '
        'btFechaO
        '
        Me.btFechaO.Location = New System.Drawing.Point(441, 413)
        Me.btFechaO.Name = "btFechaO"
        Me.btFechaO.Size = New System.Drawing.Size(75, 23)
        Me.btFechaO.TabIndex = 21
        Me.btFechaO.Text = "&Fechar"
        Me.btFechaO.UseVisualStyleBackColor = True
        '
        'btConfirmaO
        '
        Me.btConfirmaO.Location = New System.Drawing.Point(340, 413)
        Me.btConfirmaO.Name = "btConfirmaO"
        Me.btConfirmaO.Size = New System.Drawing.Size(95, 23)
        Me.btConfirmaO.TabIndex = 20
        Me.btConfirmaO.Text = "Confirmar - F12"
        Me.btConfirmaO.UseVisualStyleBackColor = True
        '
        'cmbMotivoO
        '
        Me.cmbMotivoO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMotivoO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMotivoO.FormattingEnabled = True
        Me.cmbMotivoO.Items.AddRange(New Object() {"Fungo", "Bactéria", "Oxidação", "Plantio", "Repicagem"})
        Me.cmbMotivoO.Location = New System.Drawing.Point(267, 15)
        Me.cmbMotivoO.Name = "cmbMotivoO"
        Me.cmbMotivoO.Size = New System.Drawing.Size(104, 21)
        Me.cmbMotivoO.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(222, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Motivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Data:"
        '
        'txtDataO
        '
        Me.txtDataO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataO.Location = New System.Drawing.Point(60, 15)
        Me.txtDataO.Mask = "99/99/9999"
        Me.txtDataO.Name = "txtDataO"
        Me.txtDataO.Size = New System.Drawing.Size(88, 26)
        Me.txtDataO.TabIndex = 1
        '
        'txtCodBarO
        '
        Me.txtCodBarO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarO.ForeColor = System.Drawing.Color.Blue
        Me.txtCodBarO.Location = New System.Drawing.Point(10, 78)
        Me.txtCodBarO.Name = "txtCodBarO"
        Me.txtCodBarO.Size = New System.Drawing.Size(138, 31)
        Me.txtCodBarO.TabIndex = 2
        Me.txtCodBarO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(395, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(113, 113)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Código de Barras"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DataGridView1.DataMember = "tblFrascos"
        Me.DataGridView1.DataSource = Me.dsFrascos
        Me.DataGridView1.Location = New System.Drawing.Point(6, 17)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(492, 260)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "colMER"
        Me.DataGridViewTextBoxColumn1.HeaderText = "colMER"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "colLOT"
        Me.DataGridViewTextBoxColumn2.HeaderText = "colLOT"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "colCLO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "colCLO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "colFRA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "colFRA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "colMUD"
        Me.DataGridViewTextBoxColumn5.HeaderText = "colMUD"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "colMOT"
        Me.DataGridViewTextBoxColumn6.HeaderText = "colMOT"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "coID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "coID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "coCOD"
        Me.DataGridViewTextBoxColumn8.HeaderText = "coCOD"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'frmServCodBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServCodBar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serviços - Código de Barras"
        Me.grpFrascos.ResumeLayout(False)
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtOrquideas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabLotes.ResumeLayout(False)
        Me.TabLotes.PerformLayout()
        Me.TabOrquideas.ResumeLayout(False)
        Me.TabOrquideas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgFrascosO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpFrascos As System.Windows.Forms.GroupBox
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents cmbMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btConfirma As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dsFrascos As System.Data.DataSet
    Friend WithEvents dtFrascos As System.Data.DataTable
    Friend WithEvents dcMER As System.Data.DataColumn
    Friend WithEvents dcLOT As System.Data.DataColumn
    Friend WithEvents dcCLO As System.Data.DataColumn
    Friend WithEvents dcFRA As System.Data.DataColumn
    Friend WithEvents dcMUD As System.Data.DataColumn
    Friend WithEvents dcMOT As System.Data.DataColumn
    Friend WithEvents dcID As System.Data.DataColumn
    Friend WithEvents dcCOD As System.Data.DataColumn
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabLotes As System.Windows.Forms.TabPage
    Friend WithEvents TabOrquideas As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataO As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCodBarO As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivoO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btFechaO As System.Windows.Forms.Button
    Friend WithEvents btConfirmaO As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalO As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgFrascosO As System.Windows.Forms.DataGridView
    Friend WithEvents dtOrquideas As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents ColIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLoteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTipoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNMudasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVidroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMotivoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAutoO As System.Windows.Forms.CheckBox
    Friend WithEvents pgProcesso As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbOperador As ComboBox
    Friend WithEvents ColMER As DataGridViewTextBoxColumn
    Friend WithEvents ColLOT As DataGridViewTextBoxColumn
    Friend WithEvents ColCLO As DataGridViewTextBoxColumn
    Friend WithEvents ColFRA As DataGridViewTextBoxColumn
    Friend WithEvents ColMUD As DataGridViewTextBoxColumn
    Friend WithEvents colMotivo As DataGridViewTextBoxColumn
    Friend WithEvents CoID As DataGridViewTextBoxColumn
    Friend WithEvents CoCOD As DataGridViewTextBoxColumn
    Friend WithEvents pbProgresso As ProgressBar
End Class
