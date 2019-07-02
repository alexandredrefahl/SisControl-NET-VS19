<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmbClientes = New System.Windows.Forms.ComboBox
        Me.txtData = New System.Windows.Forms.DateTimePicker
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtEntregue = New System.Windows.Forms.TextBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.txtClone = New System.Windows.Forms.TextBox
        Me.txtCodPro = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.dgItens = New System.Windows.Forms.DataGridView
        Me.btPesquisaPedidos = New System.Windows.Forms.Button
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_2 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.pnPedidos = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.btPedido = New System.Windows.Forms.Button
        Me.dgPedidos = New System.Windows.Forms.DataGridView
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPedidos.SuspendLayout()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(65, 41)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(500, 21)
        Me.cmbClientes.TabIndex = 1
        '
        'txtData
        '
        Me.txtData.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtData.CustomFormat = "dd/MM/yyyy"
        Me.txtData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(65, 10)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(95, 20)
        Me.txtData.TabIndex = 0
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFechar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFechar.Location = New System.Drawing.Point(508, 385)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFechar.Size = New System.Drawing.Size(65, 25)
        Me.cmdFechar.TabIndex = 11
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmdOK)
        Me.Frame2.Controls.Add(Me.txtEntregue)
        Me.Frame2.Controls.Add(Me.txtDescricao)
        Me.Frame2.Controls.Add(Me.txtClone)
        Me.Frame2.Controls.Add(Me.txtCodPro)
        Me.Frame2.Controls.Add(Me.txtID)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(12, 305)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(561, 73)
        Me.Frame2.TabIndex = 29
        Me.Frame2.TabStop = False
        Me.Frame2.Text = " Dado do Item "
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(504, 40)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(49, 19)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'txtEntregue
        '
        Me.txtEntregue.AcceptsReturn = True
        Me.txtEntregue.BackColor = System.Drawing.SystemColors.Window
        Me.txtEntregue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntregue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtEntregue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEntregue.Location = New System.Drawing.Point(440, 40)
        Me.txtEntregue.MaxLength = 0
        Me.txtEntregue.Name = "txtEntregue"
        Me.txtEntregue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEntregue.Size = New System.Drawing.Size(57, 20)
        Me.txtEntregue.TabIndex = 9
        Me.txtEntregue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescricao
        '
        Me.txtDescricao.AcceptsReturn = True
        Me.txtDescricao.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescricao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDescricao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescricao.Location = New System.Drawing.Point(144, 40)
        Me.txtDescricao.MaxLength = 0
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ReadOnly = True
        Me.txtDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescricao.Size = New System.Drawing.Size(289, 20)
        Me.txtDescricao.TabIndex = 8
        '
        'txtClone
        '
        Me.txtClone.AcceptsReturn = True
        Me.txtClone.BackColor = System.Drawing.SystemColors.Window
        Me.txtClone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtClone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClone.Location = New System.Drawing.Point(104, 40)
        Me.txtClone.MaxLength = 0
        Me.txtClone.Name = "txtClone"
        Me.txtClone.ReadOnly = True
        Me.txtClone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtClone.Size = New System.Drawing.Size(33, 20)
        Me.txtClone.TabIndex = 7
        Me.txtClone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCodPro
        '
        Me.txtCodPro.AcceptsReturn = True
        Me.txtCodPro.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodPro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodPro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCodPro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCodPro.Location = New System.Drawing.Point(64, 40)
        Me.txtCodPro.MaxLength = 0
        Me.txtCodPro.Name = "txtCodPro"
        Me.txtCodPro.ReadOnly = True
        Me.txtCodPro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCodPro.Size = New System.Drawing.Size(33, 20)
        Me.txtCodPro.TabIndex = 6
        Me.txtCodPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtID
        '
        Me.txtID.AcceptsReturn = True
        Me.txtID.BackColor = System.Drawing.SystemColors.Window
        Me.txtID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtID.Location = New System.Drawing.Point(16, 40)
        Me.txtID.MaxLength = 0
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtID.Size = New System.Drawing.Size(41, 20)
        Me.txtID.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(440, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Entregue"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(144, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(289, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Descrição"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(104, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(33, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Clone"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(64, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Cód"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dgItens)
        Me.Frame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 113)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(561, 185)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = " Itens do Pedido "
        '
        'dgItens
        '
        Me.dgItens.AllowUserToAddRows = False
        Me.dgItens.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgItens.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgItens.Location = New System.Drawing.Point(6, 19)
        Me.dgItens.MultiSelect = False
        Me.dgItens.Name = "dgItens"
        Me.dgItens.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgItens.RowHeadersWidth = 20
        Me.dgItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItens.Size = New System.Drawing.Size(547, 160)
        Me.dgItens.TabIndex = 4
        '
        'btPesquisaPedidos
        '
        Me.btPesquisaPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.btPesquisaPedidos.Cursor = System.Windows.Forms.Cursors.Default
        Me.btPesquisaPedidos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btPesquisaPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btPesquisaPedidos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btPesquisaPedidos.Location = New System.Drawing.Point(120, 73)
        Me.btPesquisaPedidos.Name = "btPesquisaPedidos"
        Me.btPesquisaPedidos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btPesquisaPedidos.Size = New System.Drawing.Size(17, 17)
        Me.btPesquisaPedidos.TabIndex = 3
        Me.btPesquisaPedidos.Text = "..."
        Me.btPesquisaPedidos.UseVisualStyleBackColor = False
        '
        'txtPedido
        '
        Me.txtPedido.AcceptsReturn = True
        Me.txtPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtPedido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPedido.Location = New System.Drawing.Point(65, 72)
        Me.txtPedido.MaxLength = 0
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPedido.Size = New System.Drawing.Size(49, 20)
        Me.txtPedido.TabIndex = 2
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Pedido:"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.AutoSize = True
        Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_2.Location = New System.Drawing.Point(12, 44)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(42, 13)
        Me._lblLabels_2.TabIndex = 24
        Me._lblLabels_2.Text = "Cliente:"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_1.Location = New System.Drawing.Point(12, 14)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(47, 13)
        Me._lblLabels_1.TabIndex = 23
        Me._lblLabels_1.Text = "Entrega:"
        '
        'pnPedidos
        '
        Me.pnPedidos.Controls.Add(Me.Button1)
        Me.pnPedidos.Controls.Add(Me.btPedido)
        Me.pnPedidos.Controls.Add(Me.dgPedidos)
        Me.pnPedidos.Location = New System.Drawing.Point(120, 94)
        Me.pnPedidos.Name = "pnPedidos"
        Me.pnPedidos.Size = New System.Drawing.Size(389, 179)
        Me.pnPedidos.TabIndex = 34
        Me.pnPedidos.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 20)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cancela"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btPedido
        '
        Me.btPedido.Location = New System.Drawing.Point(271, 156)
        Me.btPedido.Name = "btPedido"
        Me.btPedido.Size = New System.Drawing.Size(56, 20)
        Me.btPedido.TabIndex = 1
        Me.btPedido.Text = "OK"
        Me.btPedido.UseVisualStyleBackColor = True
        '
        'dgPedidos
        '
        Me.dgPedidos.AllowUserToAddRows = False
        Me.dgPedidos.AllowUserToDeleteRows = False
        Me.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPedidos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgPedidos.Location = New System.Drawing.Point(3, 3)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.ReadOnly = True
        Me.dgPedidos.RowHeadersWidth = 20
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgPedidos.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPedidos.Size = New System.Drawing.Size(383, 150)
        Me.dgPedidos.TabIndex = 0
        '
        'frmEntregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 423)
        Me.Controls.Add(Me.pnPedidos)
        Me.Controls.Add(Me.cmbClientes)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.cmdFechar)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.btPesquisaPedidos)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEntregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Entregas"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPedidos.ResumeLayout(False)
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Public WithEvents cmdFechar As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents txtEntregue As System.Windows.Forms.TextBox
    Public WithEvents txtDescricao As System.Windows.Forms.TextBox
    Public WithEvents txtClone As System.Windows.Forms.TextBox
    Public WithEvents txtCodPro As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgItens As System.Windows.Forms.DataGridView
    Public WithEvents btPesquisaPedidos As System.Windows.Forms.Button
    Public WithEvents txtPedido As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Friend WithEvents pnPedidos As System.Windows.Forms.Panel
    Friend WithEvents btPedido As System.Windows.Forms.Button
    Friend WithEvents dgPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
