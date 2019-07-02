<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRastreamentoLotes
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgRastro = New System.Windows.Forms.DataGridView()
        Me.ColIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datMudas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datContaminados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datCont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datTaxa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datFase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dsRastreio = New System.Data.DataSet()
        Me.tbRastro = New System.Data.DataTable()
        Me.dtColID = New System.Data.DataColumn()
        Me.dtcolCODIGO = New System.Data.DataColumn()
        Me.dtcolMUDAS = New System.Data.DataColumn()
        Me.dtcolTAXA = New System.Data.DataColumn()
        Me.dtcolCONT = New System.Data.DataColumn()
        Me.dtcolDATA = New System.Data.DataColumn()
        Me.dtcolFASE = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMercadoria = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.Label()
        Me.txtClone = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgRastro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsRastreio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRastro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Digite o código do lote ou passe o código de Barras"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigo.Location = New System.Drawing.Point(15, 43)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(169, 29)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(210, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Iniciar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgRastro
        '
        Me.dgRastro.AllowUserToAddRows = False
        Me.dgRastro.AllowUserToDeleteRows = False
        Me.dgRastro.AutoGenerateColumns = False
        Me.dgRastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRastro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIDDataGridViewTextBoxColumn, Me.datData, Me.datCodigo, Me.datMudas, Me.datContaminados, Me.datCont, Me.datSaldo, Me.datTaxa, Me.datFase})
        Me.dgRastro.DataMember = "tbRastro"
        Me.dgRastro.DataSource = Me.dsRastreio
        Me.dgRastro.Location = New System.Drawing.Point(15, 81)
        Me.dgRastro.MultiSelect = False
        Me.dgRastro.Name = "dgRastro"
        Me.dgRastro.ReadOnly = True
        Me.dgRastro.RowHeadersWidth = 21
        Me.dgRastro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRastro.Size = New System.Drawing.Size(560, 244)
        Me.dgRastro.TabIndex = 2
        '
        'ColIDDataGridViewTextBoxColumn
        '
        Me.ColIDDataGridViewTextBoxColumn.DataPropertyName = "colID"
        Me.ColIDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.ColIDDataGridViewTextBoxColumn.Name = "ColIDDataGridViewTextBoxColumn"
        Me.ColIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColIDDataGridViewTextBoxColumn.Visible = False
        '
        'datData
        '
        Me.datData.DataPropertyName = "colDATA"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.datData.DefaultCellStyle = DataGridViewCellStyle9
        Me.datData.HeaderText = "Data"
        Me.datData.Name = "datData"
        Me.datData.ReadOnly = True
        Me.datData.Width = 75
        '
        'datCodigo
        '
        Me.datCodigo.DataPropertyName = "colCODIGO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.datCodigo.DefaultCellStyle = DataGridViewCellStyle10
        Me.datCodigo.HeaderText = "Código"
        Me.datCodigo.MaxInputLength = 15
        Me.datCodigo.Name = "datCodigo"
        Me.datCodigo.ReadOnly = True
        Me.datCodigo.Width = 70
        '
        'datMudas
        '
        Me.datMudas.DataPropertyName = "colMUDAS"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N0"
        Me.datMudas.DefaultCellStyle = DataGridViewCellStyle11
        Me.datMudas.HeaderText = "Nº Mudas"
        Me.datMudas.Name = "datMudas"
        Me.datMudas.ReadOnly = True
        Me.datMudas.Width = 60
        '
        'datContaminados
        '
        Me.datContaminados.DataPropertyName = "colCONTAMINADOS"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.datContaminados.DefaultCellStyle = DataGridViewCellStyle12
        Me.datContaminados.HeaderText = "Contaminados"
        Me.datContaminados.Name = "datContaminados"
        Me.datContaminados.ReadOnly = True
        Me.datContaminados.Width = 80
        '
        'datCont
        '
        Me.datCont.DataPropertyName = "colCONT"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N1"
        DataGridViewCellStyle13.NullValue = "0"
        Me.datCont.DefaultCellStyle = DataGridViewCellStyle13
        Me.datCont.HeaderText = "Contaminação"
        Me.datCont.Name = "datCont"
        Me.datCont.ReadOnly = True
        Me.datCont.Width = 80
        '
        'datSaldo
        '
        Me.datSaldo.DataPropertyName = "colSALDO"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.datSaldo.DefaultCellStyle = DataGridViewCellStyle14
        Me.datSaldo.HeaderText = "Saldo"
        Me.datSaldo.Name = "datSaldo"
        Me.datSaldo.ReadOnly = True
        Me.datSaldo.Width = 60
        '
        'datTaxa
        '
        Me.datTaxa.DataPropertyName = "colTAXA"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0,00"
        Me.datTaxa.DefaultCellStyle = DataGridViewCellStyle15
        Me.datTaxa.HeaderText = "Taxa"
        Me.datTaxa.Name = "datTaxa"
        Me.datTaxa.ReadOnly = True
        Me.datTaxa.Width = 60
        '
        'datFase
        '
        Me.datFase.DataPropertyName = "colFASE"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = "0"
        Me.datFase.DefaultCellStyle = DataGridViewCellStyle16
        Me.datFase.HeaderText = "Fase"
        Me.datFase.Name = "datFase"
        Me.datFase.ReadOnly = True
        Me.datFase.Width = 35
        '
        'dsRastreio
        '
        Me.dsRastreio.DataSetName = "Rastreio"
        Me.dsRastreio.Tables.AddRange(New System.Data.DataTable() {Me.tbRastro})
        '
        'tbRastro
        '
        Me.tbRastro.Columns.AddRange(New System.Data.DataColumn() {Me.dtColID, Me.dtcolCODIGO, Me.dtcolMUDAS, Me.dtcolTAXA, Me.dtcolCONT, Me.dtcolDATA, Me.dtcolFASE, Me.DataColumn1, Me.DataColumn2})
        Me.tbRastro.TableName = "tbRastro"
        '
        'dtColID
        '
        Me.dtColID.Caption = "id"
        Me.dtColID.ColumnName = "colID"
        Me.dtColID.DataType = GetType(Integer)
        Me.dtColID.DefaultValue = -1
        '
        'dtcolCODIGO
        '
        Me.dtcolCODIGO.Caption = "Código"
        Me.dtcolCODIGO.ColumnName = "colCODIGO"
        Me.dtcolCODIGO.DefaultValue = ""
        '
        'dtcolMUDAS
        '
        Me.dtcolMUDAS.Caption = "Nº Mudas"
        Me.dtcolMUDAS.ColumnName = "colMUDAS"
        Me.dtcolMUDAS.DataType = GetType(Integer)
        Me.dtcolMUDAS.DefaultValue = 0
        '
        'dtcolTAXA
        '
        Me.dtcolTAXA.Caption = "Taxa"
        Me.dtcolTAXA.ColumnName = "colTAXA"
        Me.dtcolTAXA.DataType = GetType(Double)
        Me.dtcolTAXA.DefaultValue = 0.0R
        '
        'dtcolCONT
        '
        Me.dtcolCONT.Caption = "Contaminação"
        Me.dtcolCONT.ColumnName = "colCONT"
        Me.dtcolCONT.DataType = GetType(Decimal)
        Me.dtcolCONT.DefaultValue = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'dtcolDATA
        '
        Me.dtcolDATA.Caption = "Data"
        Me.dtcolDATA.ColumnName = "colDATA"
        Me.dtcolDATA.DataType = GetType(Date)
        Me.dtcolDATA.DateTimeMode = System.Data.DataSetDateTime.Local
        '
        'dtcolFASE
        '
        Me.dtcolFASE.Caption = "Fase"
        Me.dtcolFASE.ColumnName = "colFASE"
        Me.dtcolFASE.DataType = GetType(Short)
        Me.dtcolFASE.DefaultValue = CType(-1, Short)
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Contaminados"
        Me.DataColumn1.ColumnName = "colCONTAMINADOS"
        Me.DataColumn1.DataType = GetType(Integer)
        Me.DataColumn1.DefaultValue = 0
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Saldo"
        Me.DataColumn2.ColumnName = "colSALDO"
        Me.DataColumn2.DefaultValue = "0"
        Me.DataColumn2.ReadOnly = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(505, 395)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Fechar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(463, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mercadoria:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(463, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Clone:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(463, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Lote:"
        '
        'txtMercadoria
        '
        Me.txtMercadoria.AutoSize = True
        Me.txtMercadoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMercadoria.ForeColor = System.Drawing.Color.Blue
        Me.txtMercadoria.Location = New System.Drawing.Point(532, 11)
        Me.txtMercadoria.Name = "txtMercadoria"
        Me.txtMercadoria.Size = New System.Drawing.Size(31, 15)
        Me.txtMercadoria.TabIndex = 7
        Me.txtMercadoria.Text = "000"
        '
        'txtLote
        '
        Me.txtLote.AutoSize = True
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.ForeColor = System.Drawing.Color.Blue
        Me.txtLote.Location = New System.Drawing.Point(532, 30)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(31, 15)
        Me.txtLote.TabIndex = 8
        Me.txtLote.Text = "000"
        '
        'txtClone
        '
        Me.txtClone.AutoSize = True
        Me.txtClone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClone.ForeColor = System.Drawing.Color.Blue
        Me.txtClone.Location = New System.Drawing.Point(532, 49)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(39, 15)
        Me.txtClone.TabIndex = 9
        Me.txtClone.Text = "0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Formato para digitação 999.999.9999"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(506, 366)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Limpar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 333)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 85)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Estatísticas "
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(287, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "..."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(218, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Média Dias:"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(287, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "..."
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(152, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "..."
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(152, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "..."
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(152, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(218, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Níveis:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Média de Multiplicação:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Média de contaminação:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total de mudas produzidas:"
        '
        'frmRastreamentoLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 430)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtClone)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.txtMercadoria)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgRastro)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRastreamentoLotes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rastreamento de Lotes"
        CType(Me.dgRastro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsRastreio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRastro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgRastro As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dsRastreio As System.Data.DataSet
    Friend WithEvents tbRastro As System.Data.DataTable
    Friend WithEvents dtColID As System.Data.DataColumn
    Friend WithEvents dtcolCODIGO As System.Data.DataColumn
    Friend WithEvents dtcolMUDAS As System.Data.DataColumn
    Friend WithEvents dtcolTAXA As System.Data.DataColumn
    Friend WithEvents dtcolCONT As System.Data.DataColumn
    Friend WithEvents dtcolDATA As System.Data.DataColumn
    Friend WithEvents dtcolFASE As System.Data.DataColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMercadoria As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.Label
    Friend WithEvents txtClone As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents ColIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datMudas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datContaminados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datCont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datTaxa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datFase As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
