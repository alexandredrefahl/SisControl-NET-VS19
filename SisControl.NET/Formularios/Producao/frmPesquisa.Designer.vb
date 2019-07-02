<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesquisa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesquisa))
        Me.dgLotes = New System.Windows.Forms.DataGridView()
        Me.grpResumo = New System.Windows.Forms.GroupBox()
        Me.btCopiar = New System.Windows.Forms.Button()
        Me.txtSelecionados = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btInativar = New System.Windows.Forms.Button()
        Me.txtTotLotes = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbRepicador = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkFrascos = New System.Windows.Forms.CheckBox()
        Me.chkEstoque = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDataFIM = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataINI = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClone = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtMercadoria = New System.Windows.Forms.TextBox()
        Me.chkBiorreator = New System.Windows.Forms.CheckBox()
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResumo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgLotes
        '
        Me.dgLotes.AllowUserToAddRows = False
        Me.dgLotes.AllowUserToDeleteRows = False
        Me.dgLotes.AllowUserToResizeRows = False
        Me.dgLotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLotes.Location = New System.Drawing.Point(7, 121)
        Me.dgLotes.Name = "dgLotes"
        Me.dgLotes.RowHeadersWidth = 20
        Me.dgLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLotes.ShowCellToolTips = False
        Me.dgLotes.ShowEditingIcon = False
        Me.dgLotes.Size = New System.Drawing.Size(956, 333)
        Me.dgLotes.TabIndex = 1
        '
        'grpResumo
        '
        Me.grpResumo.Controls.Add(Me.btCopiar)
        Me.grpResumo.Controls.Add(Me.txtSelecionados)
        Me.grpResumo.Controls.Add(Me.Label10)
        Me.grpResumo.Controls.Add(Me.btInativar)
        Me.grpResumo.Controls.Add(Me.txtTotLotes)
        Me.grpResumo.Controls.Add(Me.txtTotal)
        Me.grpResumo.Controls.Add(Me.Label9)
        Me.grpResumo.Controls.Add(Me.Label1)
        Me.grpResumo.Location = New System.Drawing.Point(7, 460)
        Me.grpResumo.Name = "grpResumo"
        Me.grpResumo.Size = New System.Drawing.Size(956, 52)
        Me.grpResumo.TabIndex = 1
        Me.grpResumo.TabStop = False
        Me.grpResumo.Text = " Resumo "
        '
        'btCopiar
        '
        Me.btCopiar.Location = New System.Drawing.Point(760, 17)
        Me.btCopiar.Name = "btCopiar"
        Me.btCopiar.Size = New System.Drawing.Size(90, 23)
        Me.btCopiar.TabIndex = 0
        Me.btCopiar.Text = "Copiar Seleção"
        Me.btCopiar.UseVisualStyleBackColor = True
        '
        'txtSelecionados
        '
        Me.txtSelecionados.AutoSize = True
        Me.txtSelecionados.Location = New System.Drawing.Point(532, 20)
        Me.txtSelecionados.Name = "txtSelecionados"
        Me.txtSelecionados.Size = New System.Drawing.Size(10, 13)
        Me.txtSelecionados.TabIndex = 24
        Me.txtSelecionados.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(393, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Nº de Lotes Selecionados:"
        '
        'btInativar
        '
        Me.btInativar.Location = New System.Drawing.Point(856, 17)
        Me.btInativar.Name = "btInativar"
        Me.btInativar.Size = New System.Drawing.Size(90, 23)
        Me.btInativar.TabIndex = 1
        Me.btInativar.Text = "Inativar"
        Me.btInativar.UseVisualStyleBackColor = True
        Me.btInativar.Visible = False
        '
        'txtTotLotes
        '
        Me.txtTotLotes.AutoSize = True
        Me.txtTotLotes.Location = New System.Drawing.Point(291, 22)
        Me.txtTotLotes.Name = "txtTotLotes"
        Me.txtTotLotes.Size = New System.Drawing.Size(10, 13)
        Me.txtTotLotes.TabIndex = 5
        Me.txtTotLotes.Text = " "
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Location = New System.Drawing.Point(133, 22)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(10, 13)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = " "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(219, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Nº de Lotes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total de Mudas:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkBiorreator)
        Me.GroupBox1.Controls.Add(Me.cmbRepicador)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.chkFrascos)
        Me.GroupBox1.Controls.Add(Me.chkEstoque)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtDataFIM)
        Me.GroupBox1.Controls.Add(Me.txtDataINI)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbFase)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtClone)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Controls.Add(Me.txtMercadoria)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "  Critérios de Seleção "
        '
        'cmbRepicador
        '
        Me.cmbRepicador.FormattingEnabled = True
        Me.cmbRepicador.Location = New System.Drawing.Point(421, 24)
        Me.cmbRepicador.Name = "cmbRepicador"
        Me.cmbRepicador.Size = New System.Drawing.Size(154, 21)
        Me.cmbRepicador.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(356, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Repicador"
        '
        'chkFrascos
        '
        Me.chkFrascos.AutoSize = True
        Me.chkFrascos.Location = New System.Drawing.Point(359, 77)
        Me.chkFrascos.Name = "chkFrascos"
        Me.chkFrascos.Size = New System.Drawing.Size(130, 17)
        Me.chkFrascos.TabIndex = 10
        Me.chkFrascos.Text = "Nº de Frascos Zerado"
        Me.chkFrascos.UseVisualStyleBackColor = True
        '
        'chkEstoque
        '
        Me.chkEstoque.AutoSize = True
        Me.chkEstoque.Location = New System.Drawing.Point(359, 52)
        Me.chkEstoque.Name = "chkEstoque"
        Me.chkEstoque.Size = New System.Drawing.Size(102, 17)
        Me.chkEstoque.TabIndex = 8
        Me.chkEstoque.Text = "Estoque Zerado"
        Me.chkEstoque.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(856, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Limpar Filtro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btFiltrar
        '
        Me.btFiltrar.Image = CType(resources.GetObject("btFiltrar.Image"), System.Drawing.Image)
        Me.btFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btFiltrar.Location = New System.Drawing.Point(856, 17)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(89, 23)
        Me.btFiltrar.TabIndex = 11
        Me.btFiltrar.Text = "Filtrar"
        Me.btFiltrar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(261, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "a"
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Location = New System.Drawing.Point(280, 24)
        Me.txtDataFIM.Mask = "99/99/99"
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(54, 20)
        Me.txtDataFIM.TabIndex = 4
        '
        'txtDataINI
        '
        Me.txtDataINI.Location = New System.Drawing.Point(201, 24)
        Me.txtDataINI.Mask = "99/99/99"
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(54, 20)
        Me.txtDataINI.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Implantação"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(151, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Cliente"
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(201, 75)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(133, 21)
        Me.cmbCliente.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(160, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Fase"
        '
        'cmbFase
        '
        Me.cmbFase.FormattingEnabled = True
        Me.cmbFase.Location = New System.Drawing.Point(201, 49)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(133, 21)
        Me.cmbFase.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Clone"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Lote"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mercadoria"
        '
        'txtClone
        '
        Me.txtClone.Location = New System.Drawing.Point(79, 76)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(32, 20)
        Me.txtClone.TabIndex = 2
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(79, 50)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(32, 20)
        Me.txtLote.TabIndex = 1
        '
        'txtMercadoria
        '
        Me.txtMercadoria.Location = New System.Drawing.Point(79, 24)
        Me.txtMercadoria.Name = "txtMercadoria"
        Me.txtMercadoria.Size = New System.Drawing.Size(32, 20)
        Me.txtMercadoria.TabIndex = 0
        '
        'chkBiorreator
        '
        Me.chkBiorreator.AutoSize = True
        Me.chkBiorreator.Location = New System.Drawing.Point(504, 51)
        Me.chkBiorreator.Name = "chkBiorreator"
        Me.chkBiorreator.Size = New System.Drawing.Size(71, 17)
        Me.chkBiorreator.TabIndex = 9
        Me.chkBiorreator.Text = "Biorreator"
        Me.chkBiorreator.UseVisualStyleBackColor = True
        '
        'frmPesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 525)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpResumo)
        Me.Controls.Add(Me.dgLotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPesquisa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa de Lotes"
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResumo.ResumeLayout(False)
        Me.grpResumo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgLotes As System.Windows.Forms.DataGridView
    Friend WithEvents grpResumo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClone As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtMercadoria As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFase As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDataFIM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataINI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotLotes As System.Windows.Forms.Label
    Friend WithEvents btInativar As System.Windows.Forms.Button
    Friend WithEvents txtSelecionados As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkFrascos As System.Windows.Forms.CheckBox
    Friend WithEvents chkEstoque As System.Windows.Forms.CheckBox
    Friend WithEvents btCopiar As System.Windows.Forms.Button
    Friend WithEvents cmbRepicador As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents chkBiorreator As CheckBox
End Class
