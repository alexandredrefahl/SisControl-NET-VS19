<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecuperacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecuperacao))
        Me.TabRecuperacao = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNCont = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btConfirma = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New System.Windows.Forms.ComboBox()
        Me.grpFrascos = New System.Windows.Forms.GroupBox()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.ColMERDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLOTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCLODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMUDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMOTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoCODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.dtNovos = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtM_f = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblInstruções = New System.Windows.Forms.Label()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.dgRecuperados = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNFrascos = New System.Windows.Forms.TextBox()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.lblImpressas = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblPasso1 = New System.Windows.Forms.Label()
        Me.lblPasso2 = New System.Windows.Forms.Label()
        Me.lblPasso3 = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.ColFrascoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMudasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabRecuperacao.SuspendLayout()
        Me.Tab1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFrascos.SuspendLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNovos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRecuperados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabRecuperacao
        '
        Me.TabRecuperacao.Controls.Add(Me.Tab1)
        Me.TabRecuperacao.Controls.Add(Me.Tab2)
        Me.TabRecuperacao.Controls.Add(Me.Tab3)
        Me.TabRecuperacao.Location = New System.Drawing.Point(12, 47)
        Me.TabRecuperacao.Name = "TabRecuperacao"
        Me.TabRecuperacao.SelectedIndex = 0
        Me.TabRecuperacao.Size = New System.Drawing.Size(546, 473)
        Me.TabRecuperacao.TabIndex = 6
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.Label7)
        Me.Tab1.Controls.Add(Me.txtNCont)
        Me.Tab1.Controls.Add(Me.txtTotal)
        Me.Tab1.Controls.Add(Me.PictureBox1)
        Me.Tab1.Controls.Add(Me.Label4)
        Me.Tab1.Controls.Add(Me.Button1)
        Me.Tab1.Controls.Add(Me.btConfirma)
        Me.Tab1.Controls.Add(Me.Label3)
        Me.Tab1.Controls.Add(Me.cmbMotivo)
        Me.Tab1.Controls.Add(Me.grpFrascos)
        Me.Tab1.Controls.Add(Me.Label2)
        Me.Tab1.Controls.Add(Me.txtCodigoBarras)
        Me.Tab1.Controls.Add(Me.txtData)
        Me.Tab1.Controls.Add(Me.Label1)
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(538, 447)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "1 - Estoque"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(227, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Nº Contaminadas"
        '
        'txtNCont
        '
        Me.txtNCont.Location = New System.Drawing.Point(326, 47)
        Me.txtNCont.Name = "txtNCont"
        Me.txtNCont.Size = New System.Drawing.Size(46, 20)
        Me.txtNCont.TabIndex = 3
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotal.Location = New System.Drawing.Point(101, 415)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(11, 13)
        Me.txtTotal.TabIndex = 24
        Me.txtTotal.Text = " "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(403, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 413)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Nº de Frascos:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(446, 410)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btConfirma
        '
        Me.btConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConfirma.Location = New System.Drawing.Point(345, 410)
        Me.btConfirma.Name = "btConfirma"
        Me.btConfirma.Size = New System.Drawing.Size(95, 23)
        Me.btConfirma.TabIndex = 4
        Me.btConfirma.Text = "AVANÇAR >>"
        Me.btConfirma.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Motivo"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMotivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.Items.AddRange(New Object() {"Fungo", "Bactéria", "Oxidação", "Plantio", "Repicagem"})
        Me.cmbMotivo.Location = New System.Drawing.Point(272, 12)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(104, 21)
        Me.cmbMotivo.TabIndex = 2
        '
        'grpFrascos
        '
        Me.grpFrascos.Controls.Add(Me.dgFrascos)
        Me.grpFrascos.Location = New System.Drawing.Point(15, 119)
        Me.grpFrascos.Name = "grpFrascos"
        Me.grpFrascos.Size = New System.Drawing.Size(506, 285)
        Me.grpFrascos.TabIndex = 18
        Me.grpFrascos.TabStop = False
        Me.grpFrascos.Text = " Frascos Processados "
        '
        'dgFrascos
        '
        Me.dgFrascos.AllowUserToAddRows = False
        Me.dgFrascos.AutoGenerateColumns = False
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMERDataGridViewTextBoxColumn, Me.ColLOTDataGridViewTextBoxColumn, Me.ColCLODataGridViewTextBoxColumn, Me.ColFRADataGridViewTextBoxColumn, Me.ColMUDDataGridViewTextBoxColumn, Me.ColMOTDataGridViewTextBoxColumn, Me.CoIDDataGridViewTextBoxColumn, Me.CoCODDataGridViewTextBoxColumn})
        Me.dgFrascos.DataMember = "tblFrascos"
        Me.dgFrascos.DataSource = Me.dsFrascos
        Me.dgFrascos.Location = New System.Drawing.Point(6, 19)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgFrascos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFrascos.Size = New System.Drawing.Size(492, 260)
        Me.dgFrascos.TabIndex = 4
        '
        'ColMERDataGridViewTextBoxColumn
        '
        Me.ColMERDataGridViewTextBoxColumn.DataPropertyName = "colMER"
        Me.ColMERDataGridViewTextBoxColumn.HeaderText = "colMER"
        Me.ColMERDataGridViewTextBoxColumn.Name = "ColMERDataGridViewTextBoxColumn"
        '
        'ColLOTDataGridViewTextBoxColumn
        '
        Me.ColLOTDataGridViewTextBoxColumn.DataPropertyName = "colLOT"
        Me.ColLOTDataGridViewTextBoxColumn.HeaderText = "colLOT"
        Me.ColLOTDataGridViewTextBoxColumn.Name = "ColLOTDataGridViewTextBoxColumn"
        '
        'ColCLODataGridViewTextBoxColumn
        '
        Me.ColCLODataGridViewTextBoxColumn.DataPropertyName = "colCLO"
        Me.ColCLODataGridViewTextBoxColumn.HeaderText = "colCLO"
        Me.ColCLODataGridViewTextBoxColumn.Name = "ColCLODataGridViewTextBoxColumn"
        '
        'ColFRADataGridViewTextBoxColumn
        '
        Me.ColFRADataGridViewTextBoxColumn.DataPropertyName = "colFRA"
        Me.ColFRADataGridViewTextBoxColumn.HeaderText = "colFRA"
        Me.ColFRADataGridViewTextBoxColumn.Name = "ColFRADataGridViewTextBoxColumn"
        '
        'ColMUDDataGridViewTextBoxColumn
        '
        Me.ColMUDDataGridViewTextBoxColumn.DataPropertyName = "colMUD"
        Me.ColMUDDataGridViewTextBoxColumn.HeaderText = "colMUD"
        Me.ColMUDDataGridViewTextBoxColumn.Name = "ColMUDDataGridViewTextBoxColumn"
        '
        'ColMOTDataGridViewTextBoxColumn
        '
        Me.ColMOTDataGridViewTextBoxColumn.DataPropertyName = "colMOT"
        Me.ColMOTDataGridViewTextBoxColumn.HeaderText = "colMOT"
        Me.ColMOTDataGridViewTextBoxColumn.Name = "ColMOTDataGridViewTextBoxColumn"
        '
        'CoIDDataGridViewTextBoxColumn
        '
        Me.CoIDDataGridViewTextBoxColumn.DataPropertyName = "coID"
        Me.CoIDDataGridViewTextBoxColumn.HeaderText = "coID"
        Me.CoIDDataGridViewTextBoxColumn.Name = "CoIDDataGridViewTextBoxColumn"
        '
        'CoCODDataGridViewTextBoxColumn
        '
        Me.CoCODDataGridViewTextBoxColumn.DataPropertyName = "coCOD"
        Me.CoCODDataGridViewTextBoxColumn.HeaderText = "coCOD"
        Me.CoCODDataGridViewTextBoxColumn.Name = "CoCODDataGridViewTextBoxColumn"
        '
        'dsFrascos
        '
        Me.dsFrascos.DataSetName = "NewDataSet"
        Me.dsFrascos.Tables.AddRange(New System.Data.DataTable() {Me.dtFrascos, Me.dtNovos})
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
        'dtNovos
        '
        Me.dtNovos.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
        Me.dtNovos.TableName = "tblNovos"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Nº Frasco"
        Me.DataColumn1.ColumnName = "colFrasco"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Nº Mudas"
        Me.DataColumn2.ColumnName = "colMudas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Código de Barras"
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarras.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigoBarras.Location = New System.Drawing.Point(15, 75)
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(187, 31)
        Me.txtCodigoBarras.TabIndex = 1
        Me.txtCodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData
        '
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.Location = New System.Drawing.Point(65, 12)
        Me.txtData.Mask = "99/99/9999"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(88, 26)
        Me.txtData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Data:"
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.Label6)
        Me.Tab2.Controls.Add(Me.txtM_f)
        Me.Tab2.Controls.Add(Me.PictureBox2)
        Me.Tab2.Controls.Add(Me.Button2)
        Me.Tab2.Controls.Add(Me.lblInstruções)
        Me.Tab2.Controls.Add(Me.btIncluir)
        Me.Tab2.Controls.Add(Me.dgRecuperados)
        Me.Tab2.Controls.Add(Me.Label5)
        Me.Tab2.Controls.Add(Me.txtNFrascos)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(538, 447)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "2 - Inclusão"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Nº Mudas/Frasco"
        '
        'txtM_f
        '
        Me.txtM_f.Location = New System.Drawing.Point(140, 58)
        Me.txtM_f.Name = "txtM_f"
        Me.txtM_f.Size = New System.Drawing.Size(49, 20)
        Me.txtM_f.TabIndex = 1
        Me.txtM_f.Text = "0"
        Me.txtM_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(403, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(437, 418)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "AVANÇAR >>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblInstruções
        '
        Me.lblInstruções.Location = New System.Drawing.Point(313, 132)
        Me.lblInstruções.Name = "lblInstruções"
        Me.lblInstruções.Size = New System.Drawing.Size(209, 271)
        Me.lblInstruções.TabIndex = 4
        Me.lblInstruções.Text = "Na tabela ao lado digite o número de mudas em cada frasco." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fique atento à nume" & _
            "ração para que ela corresponda ao frasco no qual será colada a etiqueta."
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(203, 56)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btIncluir.TabIndex = 2
        Me.btIncluir.Text = "Adicionar"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'dgRecuperados
        '
        Me.dgRecuperados.AllowUserToAddRows = False
        Me.dgRecuperados.AllowUserToDeleteRows = False
        Me.dgRecuperados.AutoGenerateColumns = False
        Me.dgRecuperados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgRecuperados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColFrascoDataGridViewTextBoxColumn, Me.ColMudasDataGridViewTextBoxColumn})
        Me.dgRecuperados.DataMember = "tblNovos"
        Me.dgRecuperados.DataSource = Me.dsFrascos
        Me.dgRecuperados.Enabled = False
        Me.dgRecuperados.Location = New System.Drawing.Point(23, 104)
        Me.dgRecuperados.Name = "dgRecuperados"
        Me.dgRecuperados.RowHeadersWidth = 25
        Me.dgRecuperados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgRecuperados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRecuperados.Size = New System.Drawing.Size(255, 322)
        Me.dgRecuperados.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nº Frascos Produzidos:"
        '
        'txtNFrascos
        '
        Me.txtNFrascos.Location = New System.Drawing.Point(140, 32)
        Me.txtNFrascos.Name = "txtNFrascos"
        Me.txtNFrascos.Size = New System.Drawing.Size(49, 20)
        Me.txtNFrascos.TabIndex = 0
        Me.txtNFrascos.Text = "0"
        Me.txtNFrascos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.lblImpressas)
        Me.Tab3.Controls.Add(Me.Button4)
        Me.Tab3.Controls.Add(Me.Button3)
        Me.Tab3.Controls.Add(Me.PictureBox3)
        Me.Tab3.Location = New System.Drawing.Point(4, 22)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Size = New System.Drawing.Size(538, 447)
        Me.Tab3.TabIndex = 2
        Me.Tab3.Text = "3 - Impressão"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'lblImpressas
        '
        Me.lblImpressas.AutoSize = True
        Me.lblImpressas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpressas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblImpressas.Location = New System.Drawing.Point(57, 88)
        Me.lblImpressas.Name = "lblImpressas"
        Me.lblImpressas.Size = New System.Drawing.Size(19, 13)
        Me.lblImpressas.TabIndex = 25
        Me.lblImpressas.Text = "   "
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(55, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(147, 23)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Enviar para impressão"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(440, 421)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(95, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "CONCLUIR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(403, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 24
        Me.PictureBox3.TabStop = False
        '
        'lblPasso1
        '
        Me.lblPasso1.AutoSize = True
        Me.lblPasso1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasso1.ForeColor = System.Drawing.Color.Blue
        Me.lblPasso1.Location = New System.Drawing.Point(12, 9)
        Me.lblPasso1.Name = "lblPasso1"
        Me.lblPasso1.Size = New System.Drawing.Size(93, 23)
        Me.lblPasso1.TabIndex = 1
        Me.lblPasso1.Text = "1º Passo"
        '
        'lblPasso2
        '
        Me.lblPasso2.AutoSize = True
        Me.lblPasso2.Enabled = False
        Me.lblPasso2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasso2.ForeColor = System.Drawing.Color.Blue
        Me.lblPasso2.Location = New System.Drawing.Point(125, 9)
        Me.lblPasso2.Name = "lblPasso2"
        Me.lblPasso2.Size = New System.Drawing.Size(93, 23)
        Me.lblPasso2.TabIndex = 2
        Me.lblPasso2.Text = "2º Passo"
        '
        'lblPasso3
        '
        Me.lblPasso3.AutoSize = True
        Me.lblPasso3.Enabled = False
        Me.lblPasso3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasso3.ForeColor = System.Drawing.Color.Blue
        Me.lblPasso3.Location = New System.Drawing.Point(242, 9)
        Me.lblPasso3.Name = "lblPasso3"
        Me.lblPasso3.Size = New System.Drawing.Size(93, 23)
        Me.lblPasso3.TabIndex = 3
        Me.lblPasso3.Text = "3º Passo"
        '
        'lblLote
        '
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblLote.Location = New System.Drawing.Point(420, 9)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(138, 23)
        Me.lblLote.TabIndex = 4
        Me.lblLote.Text = "000.0000.000"
        Me.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblID
        '
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblID.Location = New System.Drawing.Point(516, 34)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(38, 10)
        Me.lblID.TabIndex = 5
        Me.lblID.Text = "0000"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblData
        '
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblData.Location = New System.Drawing.Point(428, 34)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(48, 10)
        Me.lblData.TabIndex = 7
        Me.lblData.Text = "00/00/0000"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColFrascoDataGridViewTextBoxColumn
        '
        Me.ColFrascoDataGridViewTextBoxColumn.DataPropertyName = "colFrasco"
        Me.ColFrascoDataGridViewTextBoxColumn.HeaderText = "Nº Frasco"
        Me.ColFrascoDataGridViewTextBoxColumn.Name = "ColFrascoDataGridViewTextBoxColumn"
        '
        'ColMudasDataGridViewTextBoxColumn
        '
        Me.ColMudasDataGridViewTextBoxColumn.DataPropertyName = "colMudas"
        Me.ColMudasDataGridViewTextBoxColumn.HeaderText = "Nº Mudas"
        Me.ColMudasDataGridViewTextBoxColumn.Name = "ColMudasDataGridViewTextBoxColumn"
        '
        'frmRecuperacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 534)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblLote)
        Me.Controls.Add(Me.lblPasso3)
        Me.Controls.Add(Me.lblPasso2)
        Me.Controls.Add(Me.lblPasso1)
        Me.Controls.Add(Me.TabRecuperacao)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecuperacao"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recuperação de Frascos"
        Me.TabRecuperacao.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFrascos.ResumeLayout(False)
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtNovos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        Me.Tab2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRecuperados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.Tab3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabRecuperacao As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btConfirma As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents grpFrascos As System.Windows.Forms.GroupBox
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPasso1 As System.Windows.Forms.Label
    Friend WithEvents lblPasso2 As System.Windows.Forms.Label
    Friend WithEvents lblPasso3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNFrascos As System.Windows.Forms.TextBox
    Friend WithEvents dgRecuperados As System.Windows.Forms.DataGridView
    Friend WithEvents lblInstruções As System.Windows.Forms.Label
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lblData As System.Windows.Forms.Label
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
    Friend WithEvents ColMERDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLOTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCLODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMUDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMOTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoCODDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtM_f As System.Windows.Forms.TextBox
    Friend WithEvents dtNovos As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNCont As System.Windows.Forms.TextBox
    Friend WithEvents lblImpressas As System.Windows.Forms.Label
    Friend WithEvents ColFrascoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMudasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
