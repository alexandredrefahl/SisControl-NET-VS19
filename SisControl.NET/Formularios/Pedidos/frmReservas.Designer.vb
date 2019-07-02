<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgReservas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmReservas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.bsReservas = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsReserva = New SisControl.NET.dsReserva()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.btAtendida = New System.Windows.Forms.Button()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgItens = New System.Windows.Forms.DataGridView()
        Me.btEdit = New System.Windows.Forms.Button()
        Me.btRemove_Item = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.cmbClone = New System.Windows.Forms.ComboBox()
        Me.cmbMercadoria = New System.Windows.Forms.ComboBox()
        Me.btAdd_Item = New System.Windows.Forms.Button()
        Me.taReservas = New SisControl.NET.dsReservaTableAdapters.reservasTableAdapter()
        Me.TableAdapterManager = New SisControl.NET.dsReservaTableAdapters.TableAdapterManager()
        Me.btEmail = New System.Windows.Forms.Button()
        CType(Me.dgReservas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmReservas.SuspendLayout()
        CType(Me.bsReservas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReserva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgReservas
        '
        Me.dgReservas.AllowUserToAddRows = False
        Me.dgReservas.AllowUserToDeleteRows = False
        Me.dgReservas.AllowUserToOrderColumns = True
        Me.dgReservas.AutoGenerateColumns = False
        Me.dgReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReservas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn1})
        Me.dgReservas.ContextMenuStrip = Me.cmReservas
        Me.dgReservas.DataSource = Me.bsReservas
        Me.dgReservas.Location = New System.Drawing.Point(12, 15)
        Me.dgReservas.Name = "dgReservas"
        Me.dgReservas.ReadOnly = True
        Me.dgReservas.RowHeadersWidth = 21
        Me.dgReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReservas.Size = New System.Drawing.Size(656, 133)
        Me.dgReservas.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.Format = "00000"
        DataGridViewCellStyle4.NullValue = "0"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Núm"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Número da Reserva"
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Data"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Nome"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nome"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 210
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Fone"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fone"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Email"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 130
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Observacoes"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Observacoes"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Atendido"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "At"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 25
        '
        'cmReservas
        '
        Me.cmReservas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.cmReservas.Name = "cmReservas"
        Me.cmReservas.Size = New System.Drawing.Size(147, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItem1.Text = "Copiar E-mail"
        Me.ToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bsReservas
        '
        Me.bsReservas.DataMember = "reservas"
        Me.bsReservas.DataSource = Me.DsReserva
        '
        'DsReserva
        '
        Me.DsReserva.DataSetName = "dsReserva"
        Me.DsReserva.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btExcluir
        '
        Me.btExcluir.Location = New System.Drawing.Point(593, 183)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 7
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'btAtendida
        '
        Me.btAtendida.Location = New System.Drawing.Point(593, 154)
        Me.btAtendida.Name = "btAtendida"
        Me.btAtendida.Size = New System.Drawing.Size(75, 23)
        Me.btAtendida.TabIndex = 6
        Me.btAtendida.Text = "Atendida"
        Me.btAtendida.UseVisualStyleBackColor = True
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(512, 154)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btIncluir.TabIndex = 5
        Me.btIncluir.Text = "Incluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.CustomFormat = "dd/MM/yyyy"
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtData.Location = New System.Drawing.Point(54, 157)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 1
        Me.txtData.Value = New Date(2014, 7, 29, 11, 16, 19, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(156, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(197, 157)
        Me.txtNome.MaxLength = 130
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(309, 20)
        Me.txtNome.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Fone"
        '
        'txtFone
        '
        Me.txtFone.Location = New System.Drawing.Point(54, 185)
        Me.txtFone.MaxLength = 60
        Me.txtFone.Name = "txtFone"
        Me.txtFone.Size = New System.Drawing.Size(145, 20)
        Me.txtFone.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(205, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "E-Mail"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(247, 183)
        Me.txtEmail.MaxLength = 80
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(259, 20)
        Me.txtEmail.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btEmail)
        Me.GroupBox1.Controls.Add(Me.dgItens)
        Me.GroupBox1.Controls.Add(Me.btEdit)
        Me.GroupBox1.Controls.Add(Me.btRemove_Item)
        Me.GroupBox1.Controls.Add(Me.txtValor)
        Me.GroupBox1.Controls.Add(Me.txtQuantidade)
        Me.GroupBox1.Controls.Add(Me.cmbClone)
        Me.GroupBox1.Controls.Add(Me.cmbMercadoria)
        Me.GroupBox1.Controls.Add(Me.btAdd_Item)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 212)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 229)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Itens da Reserva "
        '
        'dgItens
        '
        Me.dgItens.AllowUserToAddRows = False
        Me.dgItens.AllowUserToDeleteRows = False
        Me.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItens.Location = New System.Drawing.Point(7, 19)
        Me.dgItens.Name = "dgItens"
        Me.dgItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItens.Size = New System.Drawing.Size(644, 145)
        Me.dgItens.TabIndex = 0
        '
        'btEdit
        '
        Me.btEdit.Location = New System.Drawing.Point(494, 197)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(75, 23)
        Me.btEdit.TabIndex = 6
        Me.btEdit.Text = "Alterar"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'btRemove_Item
        '
        Me.btRemove_Item.Location = New System.Drawing.Point(575, 197)
        Me.btRemove_Item.Name = "btRemove_Item"
        Me.btRemove_Item.Size = New System.Drawing.Size(75, 23)
        Me.btRemove_Item.TabIndex = 7
        Me.btRemove_Item.Text = "Remover"
        Me.btRemove_Item.UseVisualStyleBackColor = True
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(486, 171)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(58, 20)
        Me.txtValor.TabIndex = 4
        Me.txtValor.Text = "0,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(412, 171)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(69, 20)
        Me.txtQuantidade.TabIndex = 3
        Me.txtQuantidade.Text = "0"
        Me.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbClone
        '
        Me.cmbClone.FormattingEnabled = True
        Me.cmbClone.Location = New System.Drawing.Point(240, 171)
        Me.cmbClone.Name = "cmbClone"
        Me.cmbClone.Size = New System.Drawing.Size(149, 21)
        Me.cmbClone.TabIndex = 2
        '
        'cmbMercadoria
        '
        Me.cmbMercadoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMercadoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMercadoria.DropDownHeight = 100
        Me.cmbMercadoria.FormattingEnabled = True
        Me.cmbMercadoria.IntegralHeight = False
        Me.cmbMercadoria.Location = New System.Drawing.Point(6, 170)
        Me.cmbMercadoria.MaximumSize = New System.Drawing.Size(228, 0)
        Me.cmbMercadoria.Name = "cmbMercadoria"
        Me.cmbMercadoria.Size = New System.Drawing.Size(228, 21)
        Me.cmbMercadoria.TabIndex = 1
        '
        'btAdd_Item
        '
        Me.btAdd_Item.Location = New System.Drawing.Point(575, 168)
        Me.btAdd_Item.Name = "btAdd_Item"
        Me.btAdd_Item.Size = New System.Drawing.Size(75, 23)
        Me.btAdd_Item.TabIndex = 5
        Me.btAdd_Item.Text = "Adicionar"
        Me.btAdd_Item.UseVisualStyleBackColor = True
        '
        'taReservas
        '
        Me.taReservas.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.reservas_itensTableAdapter = Nothing
        Me.TableAdapterManager.reservasTableAdapter = Me.taReservas
        Me.TableAdapterManager.UpdateOrder = SisControl.NET.dsReservaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'btEmail
        '
        Me.btEmail.Location = New System.Drawing.Point(7, 197)
        Me.btEmail.Name = "btEmail"
        Me.btEmail.Size = New System.Drawing.Size(96, 23)
        Me.btEmail.TabIndex = 8
        Me.btEmail.Text = "Processa E-Mail"
        Me.btEmail.UseVisualStyleBackColor = True
        '
        'frmReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 452)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btAtendida)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFone)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.btExcluir)
        Me.Controls.Add(Me.dgReservas)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReservas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reservas de Mercadorias"
        CType(Me.dgReservas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmReservas.ResumeLayout(False)
        CType(Me.bsReservas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReserva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsReserva As SisControl.NET.dsReserva
    Friend WithEvents bsReservas As System.Windows.Forms.BindingSource
    Friend WithEvents taReservas As SisControl.NET.dsReservaTableAdapters.reservasTableAdapter
    Friend WithEvents TableAdapterManager As SisControl.NET.dsReservaTableAdapters.TableAdapterManager
    Friend WithEvents dgReservas As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btExcluir As System.Windows.Forms.Button
    Friend WithEvents btAtendida As System.Windows.Forms.Button
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFone As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMercadoria As System.Windows.Forms.ComboBox
    Friend WithEvents btAdd_Item As System.Windows.Forms.Button
    Friend WithEvents cmbClone As System.Windows.Forms.ComboBox
    Friend WithEvents btEdit As System.Windows.Forms.Button
    Friend WithEvents btRemove_Item As System.Windows.Forms.Button
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantidade As System.Windows.Forms.TextBox
    Friend WithEvents dgItens As System.Windows.Forms.DataGridView
    Friend WithEvents cmReservas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btEmail As Button
End Class
