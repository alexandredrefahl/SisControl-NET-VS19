<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCNPJ = New System.Windows.Forms.TextBox()
        Me.txtIE = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.txtOBS = New System.Windows.Forms.TextBox()
        Me.txtContrato = New System.Windows.Forms.TextBox()
        Me.txtProdutos = New System.Windows.Forms.TextBox()
        Me.txtContato = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCodPais = New System.Windows.Forms.TextBox()
        Me.rdPF = New System.Windows.Forms.RadioButton()
        Me.rdPJ = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtCidade = New System.Windows.Forms.ComboBox()
        Me.txtCodMun = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btBuscaCEP = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(560, 14)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(32, 20)
        Me.txtCodigo.TabIndex = 28
        Me.txtCodigo.TabStop = False
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(85, 70)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(376, 20)
        Me.txtNome.TabIndex = 1
        '
        'txtEndereco
        '
        Me.txtEndereco.Location = New System.Drawing.Point(85, 96)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(286, 20)
        Me.txtEndereco.TabIndex = 2
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(422, 96)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(39, 20)
        Me.txtNum.TabIndex = 3
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(85, 122)
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(125, 20)
        Me.txtBairro.TabIndex = 4
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(85, 148)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(39, 20)
        Me.txtEstado.TabIndex = 6
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(271, 122)
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(77, 20)
        Me.txtCEP.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(511, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Código:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nome"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Endereço"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(387, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Núm"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Bairro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(237, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "CEP"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCNPJ
        '
        Me.txtCNPJ.Location = New System.Drawing.Point(85, 225)
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(169, 20)
        Me.txtCNPJ.TabIndex = 13
        '
        'txtIE
        '
        Me.txtIE.Location = New System.Drawing.Point(331, 225)
        Me.txtIE.Name = "txtIE"
        Me.txtIE.Size = New System.Drawing.Size(130, 20)
        Me.txtIE.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(12, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "CNPJ"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(275, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Inscrição"
        '
        'txtFone
        '
        Me.txtFone.Location = New System.Drawing.Point(85, 251)
        Me.txtFone.Name = "txtFone"
        Me.txtFone.Size = New System.Drawing.Size(125, 20)
        Me.txtFone.TabIndex = 15
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(263, 251)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(130, 20)
        Me.txtFax.TabIndex = 16
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(456, 251)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(125, 20)
        Me.txtCelular.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Telefone"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(411, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Celular"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(233, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Fax"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(85, 277)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(240, 20)
        Me.txtEmail.TabIndex = 18
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(85, 303)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(240, 20)
        Me.txtSite.TabIndex = 19
        '
        'txtOBS
        '
        Me.txtOBS.Location = New System.Drawing.Point(85, 329)
        Me.txtOBS.Multiline = True
        Me.txtOBS.Name = "txtOBS"
        Me.txtOBS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOBS.Size = New System.Drawing.Size(496, 76)
        Me.txtOBS.TabIndex = 20
        '
        'txtContrato
        '
        Me.txtContrato.Location = New System.Drawing.Point(85, 411)
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.Size = New System.Drawing.Size(125, 20)
        Me.txtContrato.TabIndex = 21
        '
        'txtProdutos
        '
        Me.txtProdutos.Location = New System.Drawing.Point(85, 437)
        Me.txtProdutos.Name = "txtProdutos"
        Me.txtProdutos.Size = New System.Drawing.Size(376, 20)
        Me.txtProdutos.TabIndex = 22
        '
        'txtContato
        '
        Me.txtContato.Location = New System.Drawing.Point(85, 463)
        Me.txtContato.Name = "txtContato"
        Me.txtContato.Size = New System.Drawing.Size(240, 20)
        Me.txtContato.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 280)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "e-mail"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 306)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Site"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 332)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Observações"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 414)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Contrato"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 440)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Produtos"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 466)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Contato(s)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(111, 14)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(261, 21)
        Me.cmbCliente.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 13)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Localize o Cliente:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(493, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 25)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Ver Pedidos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(85, 174)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(39, 20)
        Me.txtPais.TabIndex = 9
        Me.txtPais.Text = "Brasil"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 177)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "País"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodPais
        '
        Me.txtCodPais.Location = New System.Drawing.Point(129, 174)
        Me.txtCodPais.Name = "txtCodPais"
        Me.txtCodPais.Size = New System.Drawing.Size(39, 20)
        Me.txtCodPais.TabIndex = 10
        Me.txtCodPais.Text = "1058"
        '
        'rdPF
        '
        Me.rdPF.AutoSize = True
        Me.rdPF.Checked = True
        Me.rdPF.ForeColor = System.Drawing.Color.Blue
        Me.rdPF.Location = New System.Drawing.Point(15, 200)
        Me.rdPF.Name = "rdPF"
        Me.rdPF.Size = New System.Drawing.Size(92, 17)
        Me.rdPF.TabIndex = 11
        Me.rdPF.TabStop = True
        Me.rdPF.Text = "Pessoa Física"
        Me.rdPF.UseVisualStyleBackColor = True
        '
        'rdPJ
        '
        Me.rdPJ.AutoSize = True
        Me.rdPJ.ForeColor = System.Drawing.Color.Blue
        Me.rdPJ.Location = New System.Drawing.Point(120, 200)
        Me.rdPJ.Name = "rdPJ"
        Me.rdPJ.Size = New System.Drawing.Size(101, 17)
        Me.rdPJ.TabIndex = 12
        Me.rdPJ.TabStop = True
        Me.rdPJ.Text = "Pessoa Jurídica"
        Me.rdPJ.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(436, 476)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Novo"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(517, 476)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(355, 476)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Incluir"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtCidade
        '
        Me.txtCidade.DropDownHeight = 150
        Me.txtCidade.DropDownWidth = 180
        Me.txtCidade.FormattingEnabled = True
        Me.txtCidade.IntegralHeight = False
        Me.txtCidade.Location = New System.Drawing.Point(271, 148)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(92, 21)
        Me.txtCidade.TabIndex = 7
        '
        'txtCodMun
        '
        Me.txtCodMun.Location = New System.Drawing.Point(369, 149)
        Me.txtCodMun.MaxLength = 7
        Me.txtCodMun.Name = "txtCodMun"
        Me.txtCodMun.Size = New System.Drawing.Size(62, 20)
        Me.txtCodMun.TabIndex = 8
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label23.Location = New System.Drawing.Point(222, 152)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 13)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "Cidade:"
        '
        'Button5
        '
        Me.Button5.Image = Global.SisControl.NET.My.Resources.Resources.opencart_logo
        Me.Button5.Location = New System.Drawing.Point(493, 97)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 25)
        Me.Button5.TabIndex = 56
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btBuscaCEP
        '
        Me.btBuscaCEP.Image = Global.SisControl.NET.My.Resources.Resources.zoom
        Me.btBuscaCEP.Location = New System.Drawing.Point(354, 119)
        Me.btBuscaCEP.Name = "btBuscaCEP"
        Me.btBuscaCEP.Size = New System.Drawing.Size(23, 23)
        Me.btBuscaCEP.TabIndex = 55
        Me.btBuscaCEP.UseVisualStyleBackColor = True
        '
        'frmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 511)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btBuscaCEP)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtCodMun)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.rdPJ)
        Me.Controls.Add(Me.rdPF)
        Me.Controls.Add(Me.txtCodPais)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPais)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmbCliente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtContato)
        Me.Controls.Add(Me.txtProdutos)
        Me.Controls.Add(Me.txtContrato)
        Me.Controls.Add(Me.txtOBS)
        Me.Controls.Add(Me.txtSite)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtFone)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIE)
        Me.Controls.Add(Me.txtCNPJ)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtCodigo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtEndereco As System.Windows.Forms.TextBox
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents txtBairro As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCNPJ As System.Windows.Forms.TextBox
    Friend WithEvents txtIE As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents txtOBS As System.Windows.Forms.TextBox
    Friend WithEvents txtContrato As System.Windows.Forms.TextBox
    Friend WithEvents txtProdutos As System.Windows.Forms.TextBox
    Friend WithEvents txtContato As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCodPais As System.Windows.Forms.TextBox
    Friend WithEvents rdPF As System.Windows.Forms.RadioButton
    Friend WithEvents rdPJ As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtCidade As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodMun As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btBuscaCEP As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
