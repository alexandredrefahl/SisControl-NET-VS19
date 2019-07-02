<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantio
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
        Me.grpOrigem = New System.Windows.Forms.GroupBox()
        Me.dgOrigem = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMudas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.grpBandejas = New System.Windows.Forms.GroupBox()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.dgBandejas = New System.Windows.Forms.DataGridView()
        Me.lblPlantio = New System.Windows.Forms.Label()
        Me.grpPlantio = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNMudas = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNBandejas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSubstrato = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstPlantador = New System.Windows.Forms.ListBox()
        Me.grpTipo = New System.Windows.Forms.GroupBox()
        Me.rd70 = New System.Windows.Forms.RadioButton()
        Me.rd450 = New System.Windows.Forms.RadioButton()
        Me.rd255 = New System.Windows.Forms.RadioButton()
        Me.rd128 = New System.Windows.Forms.RadioButton()
        Me.rd72 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.txtClone = New System.Windows.Forms.TextBox()
        Me.txtMercadoria = New System.Windows.Forms.TextBox()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.lblMudasOrigem = New System.Windows.Forms.Label()
        Me.grpOrigem.SuspendLayout()
        CType(Me.dgOrigem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBandejas.SuspendLayout()
        CType(Me.dgBandejas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPlantio.SuspendLayout()
        Me.grpTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOrigem
        '
        Me.grpOrigem.Controls.Add(Me.dgOrigem)
        Me.grpOrigem.Controls.Add(Me.Button1)
        Me.grpOrigem.Controls.Add(Me.Label10)
        Me.grpOrigem.Controls.Add(Me.txtMudas)
        Me.grpOrigem.Controls.Add(Me.Label9)
        Me.grpOrigem.Controls.Add(Me.txtCodigo)
        Me.grpOrigem.Enabled = False
        Me.grpOrigem.Location = New System.Drawing.Point(12, 326)
        Me.grpOrigem.Name = "grpOrigem"
        Me.grpOrigem.Size = New System.Drawing.Size(220, 245)
        Me.grpOrigem.TabIndex = 2
        Me.grpOrigem.TabStop = False
        Me.grpOrigem.Text = " Dados de Origem "
        '
        'dgOrigem
        '
        Me.dgOrigem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrigem.Location = New System.Drawing.Point(15, 66)
        Me.dgOrigem.Name = "dgOrigem"
        Me.dgOrigem.RowHeadersWidth = 25
        Me.dgOrigem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgOrigem.Size = New System.Drawing.Size(196, 173)
        Me.dgOrigem.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(165, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Incluir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(99, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Nº de Mudas:"
        '
        'txtMudas
        '
        Me.txtMudas.Location = New System.Drawing.Point(102, 39)
        Me.txtMudas.Name = "txtMudas"
        Me.txtMudas.Size = New System.Drawing.Size(57, 20)
        Me.txtMudas.TabIndex = 1
        Me.txtMudas.Text = "0"
        Me.txtMudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Lote:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(14, 39)
        Me.txtCodigo.Mask = "000.000.0000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(82, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpBandejas
        '
        Me.grpBandejas.Controls.Add(Me.btSalvar)
        Me.grpBandejas.Controls.Add(Me.dgBandejas)
        Me.grpBandejas.Enabled = False
        Me.grpBandejas.Location = New System.Drawing.Point(257, 326)
        Me.grpBandejas.Name = "grpBandejas"
        Me.grpBandejas.Size = New System.Drawing.Size(221, 245)
        Me.grpBandejas.TabIndex = 3
        Me.grpBandejas.TabStop = False
        Me.grpBandejas.Text = " Dados das Bandejas "
        '
        'btSalvar
        '
        Me.btSalvar.Location = New System.Drawing.Point(157, 15)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(52, 21)
        Me.btSalvar.TabIndex = 0
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'dgBandejas
        '
        Me.dgBandejas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBandejas.Location = New System.Drawing.Point(14, 42)
        Me.dgBandejas.Name = "dgBandejas"
        Me.dgBandejas.RowHeadersWidth = 25
        Me.dgBandejas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgBandejas.Size = New System.Drawing.Size(195, 197)
        Me.dgBandejas.TabIndex = 1
        '
        'lblPlantio
        '
        Me.lblPlantio.AutoSize = True
        Me.lblPlantio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlantio.ForeColor = System.Drawing.Color.Blue
        Me.lblPlantio.Location = New System.Drawing.Point(15, 300)
        Me.lblPlantio.Name = "lblPlantio"
        Me.lblPlantio.Size = New System.Drawing.Size(115, 18)
        Me.lblPlantio.TabIndex = 1
        Me.lblPlantio.Text = "Plantio: 00000"
        Me.lblPlantio.Visible = False
        '
        'grpPlantio
        '
        Me.grpPlantio.Controls.Add(Me.Label8)
        Me.grpPlantio.Controls.Add(Me.txtNMudas)
        Me.grpPlantio.Controls.Add(Me.Button2)
        Me.grpPlantio.Controls.Add(Me.btIncluir)
        Me.grpPlantio.Controls.Add(Me.cmbCliente)
        Me.grpPlantio.Controls.Add(Me.Label7)
        Me.grpPlantio.Controls.Add(Me.Label6)
        Me.grpPlantio.Controls.Add(Me.txtNBandejas)
        Me.grpPlantio.Controls.Add(Me.Label5)
        Me.grpPlantio.Controls.Add(Me.txtSubstrato)
        Me.grpPlantio.Controls.Add(Me.Label4)
        Me.grpPlantio.Controls.Add(Me.lstPlantador)
        Me.grpPlantio.Controls.Add(Me.grpTipo)
        Me.grpPlantio.Controls.Add(Me.Label3)
        Me.grpPlantio.Controls.Add(Me.Label2)
        Me.grpPlantio.Controls.Add(Me.Label1)
        Me.grpPlantio.Controls.Add(Me.txtData)
        Me.grpPlantio.Controls.Add(Me.txtClone)
        Me.grpPlantio.Controls.Add(Me.txtMercadoria)
        Me.grpPlantio.Location = New System.Drawing.Point(12, 12)
        Me.grpPlantio.Name = "grpPlantio"
        Me.grpPlantio.Size = New System.Drawing.Size(466, 278)
        Me.grpPlantio.TabIndex = 0
        Me.grpPlantio.TabStop = False
        Me.grpPlantio.Text = " Dados do Plantio "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(12, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nº de Mudas:"
        '
        'txtNMudas
        '
        Me.txtNMudas.Location = New System.Drawing.Point(102, 123)
        Me.txtNMudas.Name = "txtNMudas"
        Me.txtNMudas.Size = New System.Drawing.Size(48, 20)
        Me.txtNMudas.TabIndex = 4
        Me.txtNMudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(379, 244)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Limpar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(298, 244)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btIncluir.TabIndex = 9
        Me.btIncluir.Text = "Incluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.DropDownWidth = 250
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(102, 245)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(172, 21)
        Me.cmbCliente.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cliente:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(12, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Nº de Bandejas:"
        '
        'txtNBandejas
        '
        Me.txtNBandejas.Location = New System.Drawing.Point(102, 97)
        Me.txtNBandejas.Name = "txtNBandejas"
        Me.txtNBandejas.Size = New System.Drawing.Size(48, 20)
        Me.txtNBandejas.TabIndex = 3
        Me.txtNBandejas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Substrato:"
        '
        'txtSubstrato
        '
        Me.txtSubstrato.Location = New System.Drawing.Point(317, 159)
        Me.txtSubstrato.Name = "txtSubstrato"
        Me.txtSubstrato.Size = New System.Drawing.Size(137, 20)
        Me.txtSubstrato.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(256, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Plantado por:"
        '
        'lstPlantador
        '
        Me.lstPlantador.FormattingEnabled = True
        Me.lstPlantador.Location = New System.Drawing.Point(259, 48)
        Me.lstPlantador.Name = "lstPlantador"
        Me.lstPlantador.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstPlantador.Size = New System.Drawing.Size(195, 95)
        Me.lstPlantador.TabIndex = 7
        '
        'grpTipo
        '
        Me.grpTipo.Controls.Add(Me.rd70)
        Me.grpTipo.Controls.Add(Me.rd450)
        Me.grpTipo.Controls.Add(Me.rd255)
        Me.grpTipo.Controls.Add(Me.rd128)
        Me.grpTipo.Controls.Add(Me.rd72)
        Me.grpTipo.Location = New System.Drawing.Point(6, 149)
        Me.grpTipo.Name = "grpTipo"
        Me.grpTipo.Size = New System.Drawing.Size(205, 90)
        Me.grpTipo.TabIndex = 5
        Me.grpTipo.TabStop = False
        Me.grpTipo.Text = "Tipo da Bandeja"
        '
        'rd70
        '
        Me.rd70.AutoSize = True
        Me.rd70.Location = New System.Drawing.Point(8, 42)
        Me.rd70.Name = "rd70"
        Me.rd70.Size = New System.Drawing.Size(74, 17)
        Me.rd70.TabIndex = 1
        Me.rd70.TabStop = True
        Me.rd70.Text = "70 Células"
        Me.rd70.UseVisualStyleBackColor = True
        '
        'rd450
        '
        Me.rd450.AutoSize = True
        Me.rd450.Location = New System.Drawing.Point(117, 42)
        Me.rd450.Name = "rd450"
        Me.rd450.Size = New System.Drawing.Size(80, 17)
        Me.rd450.TabIndex = 4
        Me.rd450.TabStop = True
        Me.rd450.Text = "450 Células"
        Me.rd450.UseVisualStyleBackColor = True
        '
        'rd255
        '
        Me.rd255.AutoSize = True
        Me.rd255.Location = New System.Drawing.Point(117, 19)
        Me.rd255.Name = "rd255"
        Me.rd255.Size = New System.Drawing.Size(80, 17)
        Me.rd255.TabIndex = 3
        Me.rd255.TabStop = True
        Me.rd255.Text = "255 Células"
        Me.rd255.UseVisualStyleBackColor = True
        '
        'rd128
        '
        Me.rd128.AutoSize = True
        Me.rd128.Location = New System.Drawing.Point(8, 64)
        Me.rd128.Name = "rd128"
        Me.rd128.Size = New System.Drawing.Size(80, 17)
        Me.rd128.TabIndex = 2
        Me.rd128.TabStop = True
        Me.rd128.Text = "128 Células"
        Me.rd128.UseVisualStyleBackColor = True
        '
        'rd72
        '
        Me.rd72.AutoSize = True
        Me.rd72.Location = New System.Drawing.Point(8, 19)
        Me.rd72.Name = "rd72"
        Me.rd72.Size = New System.Drawing.Size(74, 17)
        Me.rd72.TabIndex = 0
        Me.rd72.TabStop = True
        Me.rd72.Text = "72 Células"
        Me.rd72.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(12, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Data:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Clone:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Mercadoria:"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(81, 74)
        Me.txtData.Mask = "00/00/00"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(55, 20)
        Me.txtData.TabIndex = 2
        Me.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtClone
        '
        Me.txtClone.Location = New System.Drawing.Point(81, 48)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(32, 20)
        Me.txtClone.TabIndex = 1
        Me.txtClone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMercadoria
        '
        Me.txtMercadoria.Location = New System.Drawing.Point(81, 22)
        Me.txtMercadoria.Name = "txtMercadoria"
        Me.txtMercadoria.Size = New System.Drawing.Size(32, 20)
        Me.txtMercadoria.TabIndex = 0
        Me.txtMercadoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(332, 577)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 23)
        Me.btNovo.TabIndex = 4
        Me.btNovo.Text = "Novo"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.Location = New System.Drawing.Point(413, 577)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(65, 23)
        Me.btSair.TabIndex = 5
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'lblMudasOrigem
        '
        Me.lblMudasOrigem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMudasOrigem.Location = New System.Drawing.Point(99, 574)
        Me.lblMudasOrigem.Name = "lblMudasOrigem"
        Me.lblMudasOrigem.Size = New System.Drawing.Size(100, 16)
        Me.lblMudasOrigem.TabIndex = 6
        Me.lblMudasOrigem.Text = "0"
        Me.lblMudasOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPlantio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 606)
        Me.Controls.Add(Me.lblMudasOrigem)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.grpPlantio)
        Me.Controls.Add(Me.lblPlantio)
        Me.Controls.Add(Me.grpBandejas)
        Me.Controls.Add(Me.grpOrigem)
        Me.KeyPreview = True
        Me.Name = "frmPlantio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastramento de Plantio"
        Me.grpOrigem.ResumeLayout(False)
        Me.grpOrigem.PerformLayout()
        CType(Me.dgOrigem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBandejas.ResumeLayout(False)
        CType(Me.dgBandejas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPlantio.ResumeLayout(False)
        Me.grpPlantio.PerformLayout()
        Me.grpTipo.ResumeLayout(False)
        Me.grpTipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpOrigem As System.Windows.Forms.GroupBox
    Friend WithEvents grpBandejas As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlantio As System.Windows.Forms.Label
    Friend WithEvents grpPlantio As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNBandejas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubstrato As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstPlantador As System.Windows.Forms.ListBox
    Friend WithEvents grpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rd450 As System.Windows.Forms.RadioButton
    Friend WithEvents rd255 As System.Windows.Forms.RadioButton
    Friend WithEvents rd128 As System.Windows.Forms.RadioButton
    Friend WithEvents rd72 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtClone As System.Windows.Forms.TextBox
    Friend WithEvents txtMercadoria As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNMudas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dgOrigem As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMudas As System.Windows.Forms.TextBox
    Friend WithEvents dgBandejas As System.Windows.Forms.DataGridView
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents rd70 As System.Windows.Forms.RadioButton
    Friend WithEvents lblMudasOrigem As System.Windows.Forms.Label
End Class
