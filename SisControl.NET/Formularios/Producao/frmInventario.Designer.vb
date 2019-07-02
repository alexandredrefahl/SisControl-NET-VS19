<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventario
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtArquivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pbProgresso = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.fileExcel = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCodigoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMdsFrascoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEstoqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMercadoriaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLoteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCloneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFrascosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DsInventario = New SisControl.NET.dsInventario()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEstoqueTotal = New System.Windows.Forms.Label()
        Me.lblFrascosProcessados = New System.Windows.Forms.Label()
        Me.lblLotesProcessados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkErro = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtArquivo
        '
        Me.txtArquivo.Location = New System.Drawing.Point(15, 25)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(472, 20)
        Me.txtArquivo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selecione o Arquivo do Inventário (Excel)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(493, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pbProgresso
        '
        Me.pbProgresso.Location = New System.Drawing.Point(12, 495)
        Me.pbProgresso.Name = "pbProgresso"
        Me.pbProgresso.Size = New System.Drawing.Size(508, 21)
        Me.pbProgresso.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(404, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Processar Dados"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.Location = New System.Drawing.Point(12, 474)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(442, 18)
        Me.lblMsg.TabIndex = 5
        Me.lblMsg.Text = "..."
        '
        'fileExcel
        '
        Me.fileExcel.Filter = "Arquivos Excel|*.xls|Arquivos Excel 2010|*.xlsx"
        Me.fileExcel.FilterIndex = 2
        Me.fileExcel.InitialDirectory = "c:\"
        Me.fileExcel.Title = "Selecione o arquivo do Inventário"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIDDataGridViewTextBoxColumn, Me.ColCodigoDataGridViewTextBoxColumn, Me.ColMdsFrascoDataGridViewTextBoxColumn, Me.ColEstoqueDataGridViewTextBoxColumn, Me.ColMercadoriaDataGridViewTextBoxColumn, Me.ColLoteDataGridViewTextBoxColumn, Me.ColCloneDataGridViewTextBoxColumn, Me.ColFrascosDataGridViewTextBoxColumn})
        Me.DataGridView1.DataMember = "dtLotes"
        Me.DataGridView1.DataSource = Me.DsInventario
        Me.DataGridView1.Location = New System.Drawing.Point(15, 109)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(505, 272)
        Me.DataGridView1.TabIndex = 6
        '
        'ColIDDataGridViewTextBoxColumn
        '
        Me.ColIDDataGridViewTextBoxColumn.DataPropertyName = "colID"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle20.Format = "0000000"
        DataGridViewCellStyle20.NullValue = "0"
        Me.ColIDDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.ColIDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.ColIDDataGridViewTextBoxColumn.Name = "ColIDDataGridViewTextBoxColumn"
        Me.ColIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColIDDataGridViewTextBoxColumn.Width = 60
        '
        'ColCodigoDataGridViewTextBoxColumn
        '
        Me.ColCodigoDataGridViewTextBoxColumn.DataPropertyName = "colCodigo"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColCodigoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.ColCodigoDataGridViewTextBoxColumn.HeaderText = "Código"
        Me.ColCodigoDataGridViewTextBoxColumn.Name = "ColCodigoDataGridViewTextBoxColumn"
        Me.ColCodigoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ColMdsFrascoDataGridViewTextBoxColumn
        '
        Me.ColMdsFrascoDataGridViewTextBoxColumn.DataPropertyName = "colMds_Frasco"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.Format = "N0"
        DataGridViewCellStyle22.NullValue = "0"
        Me.ColMdsFrascoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle22
        Me.ColMdsFrascoDataGridViewTextBoxColumn.HeaderText = "Mds Frasco"
        Me.ColMdsFrascoDataGridViewTextBoxColumn.Name = "ColMdsFrascoDataGridViewTextBoxColumn"
        Me.ColMdsFrascoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColMdsFrascoDataGridViewTextBoxColumn.Width = 50
        '
        'ColEstoqueDataGridViewTextBoxColumn
        '
        Me.ColEstoqueDataGridViewTextBoxColumn.DataPropertyName = "colEstoque"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "N0"
        DataGridViewCellStyle23.NullValue = "0"
        Me.ColEstoqueDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle23
        Me.ColEstoqueDataGridViewTextBoxColumn.HeaderText = "Estoque"
        Me.ColEstoqueDataGridViewTextBoxColumn.Name = "ColEstoqueDataGridViewTextBoxColumn"
        Me.ColEstoqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColEstoqueDataGridViewTextBoxColumn.Width = 50
        '
        'ColMercadoriaDataGridViewTextBoxColumn
        '
        Me.ColMercadoriaDataGridViewTextBoxColumn.DataPropertyName = "colMercadoria"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.Format = "000"
        DataGridViewCellStyle24.NullValue = "0"
        Me.ColMercadoriaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle24
        Me.ColMercadoriaDataGridViewTextBoxColumn.HeaderText = "Merc"
        Me.ColMercadoriaDataGridViewTextBoxColumn.Name = "ColMercadoriaDataGridViewTextBoxColumn"
        Me.ColMercadoriaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColMercadoriaDataGridViewTextBoxColumn.Width = 50
        '
        'ColLoteDataGridViewTextBoxColumn
        '
        Me.ColLoteDataGridViewTextBoxColumn.DataPropertyName = "colLote"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.Format = "000"
        DataGridViewCellStyle25.NullValue = "0"
        Me.ColLoteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle25
        Me.ColLoteDataGridViewTextBoxColumn.HeaderText = "Lote"
        Me.ColLoteDataGridViewTextBoxColumn.Name = "ColLoteDataGridViewTextBoxColumn"
        Me.ColLoteDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColLoteDataGridViewTextBoxColumn.Width = 50
        '
        'ColCloneDataGridViewTextBoxColumn
        '
        Me.ColCloneDataGridViewTextBoxColumn.DataPropertyName = "colClone"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.Format = "0000"
        DataGridViewCellStyle26.NullValue = "0"
        Me.ColCloneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle26
        Me.ColCloneDataGridViewTextBoxColumn.HeaderText = "Clone"
        Me.ColCloneDataGridViewTextBoxColumn.Name = "ColCloneDataGridViewTextBoxColumn"
        Me.ColCloneDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColCloneDataGridViewTextBoxColumn.Width = 50
        '
        'ColFrascosDataGridViewTextBoxColumn
        '
        Me.ColFrascosDataGridViewTextBoxColumn.DataPropertyName = "colFrascos"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N0"
        DataGridViewCellStyle27.NullValue = "0"
        Me.ColFrascosDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle27
        Me.ColFrascosDataGridViewTextBoxColumn.HeaderText = "Nº Frascos"
        Me.ColFrascosDataGridViewTextBoxColumn.Name = "ColFrascosDataGridViewTextBoxColumn"
        Me.ColFrascosDataGridViewTextBoxColumn.ReadOnly = True
        Me.ColFrascosDataGridViewTextBoxColumn.Width = 50
        '
        'DsInventario
        '
        Me.DsInventario.DataSetName = "dsInventario"
        Me.DsInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lotes Processados"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.lblEstoqueTotal)
        Me.GroupBox1.Controls.Add(Me.lblFrascosProcessados)
        Me.GroupBox1.Controls.Add(Me.lblLotesProcessados)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 389)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 81)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Resumo do Inventário "
        '
        'lblEstoqueTotal
        '
        Me.lblEstoqueTotal.AutoSize = True
        Me.lblEstoqueTotal.Location = New System.Drawing.Point(88, 59)
        Me.lblEstoqueTotal.Name = "lblEstoqueTotal"
        Me.lblEstoqueTotal.Size = New System.Drawing.Size(16, 13)
        Me.lblEstoqueTotal.TabIndex = 5
        Me.lblEstoqueTotal.Text = "..."
        '
        'lblFrascosProcessados
        '
        Me.lblFrascosProcessados.AutoSize = True
        Me.lblFrascosProcessados.Location = New System.Drawing.Point(123, 39)
        Me.lblFrascosProcessados.Name = "lblFrascosProcessados"
        Me.lblFrascosProcessados.Size = New System.Drawing.Size(16, 13)
        Me.lblFrascosProcessados.TabIndex = 4
        Me.lblFrascosProcessados.Text = "..."
        '
        'lblLotesProcessados
        '
        Me.lblLotesProcessados.AutoSize = True
        Me.lblLotesProcessados.Location = New System.Drawing.Point(103, 20)
        Me.lblLotesProcessados.Name = "lblLotesProcessados"
        Me.lblLotesProcessados.Size = New System.Drawing.Size(16, 13)
        Me.lblLotesProcessados.TabIndex = 3
        Me.lblLotesProcessados.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Estoque Total:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Frascos Processados:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Lotes Processados:"
        '
        'chkErro
        '
        Me.chkErro.AutoSize = True
        Me.chkErro.Location = New System.Drawing.Point(16, 54)
        Me.chkErro.Name = "chkErro"
        Me.chkErro.Size = New System.Drawing.Size(217, 17)
        Me.chkErro.TabIndex = 9
        Me.chkErro.Text = "Criar registro de Erros de Processamento"
        Me.chkErro.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(370, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 27)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Atualizar Estoque"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 521)
        Me.Controls.Add(Me.chkErro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pbProgresso)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArquivo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventário de Frascos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtArquivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbProgresso As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents fileExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DsInventario As SisControl.NET.dsInventario
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEstoqueTotal As System.Windows.Forms.Label
    Friend WithEvents lblFrascosProcessados As System.Windows.Forms.Label
    Friend WithEvents lblLotesProcessados As System.Windows.Forms.Label
    Friend WithEvents ColIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMdsFrascoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEstoqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMercadoriaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLoteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCloneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFrascosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkErro As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
