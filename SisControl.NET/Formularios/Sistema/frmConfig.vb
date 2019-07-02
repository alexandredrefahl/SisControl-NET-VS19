Option Strict Off
Option Explicit On
Imports System.Xml

Friend Class frmConfig
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'For the start-up form, the first instance created is the default instance.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
        Me.Show()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkagenda As System.Windows.Forms.CheckBox
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPorta As System.Windows.Forms.TextBox
    Friend WithEvents cntTemp As System.Windows.Forms.NumericUpDown
    Public WithEvents cmbPorta As System.Windows.Forms.ComboBox
    Public WithEvents txtIP As System.Windows.Forms.TextBox
    Public WithEvents txtConRemoto As System.Windows.Forms.TextBox
    Public WithEvents lblProduto As System.Windows.Forms.Label
    Public WithEvents lblVersao As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Line2 As System.Windows.Forms.Label
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNumNFe As System.Windows.Forms.TextBox
    Friend WithEvents txtPasta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAliquota As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCaminho As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdHomologacao As System.Windows.Forms.RadioButton
    Friend WithEvents rdProducao As System.Windows.Forms.RadioButton
    Friend WithEvents fbdPastaNFe As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btPastaNFe As System.Windows.Forms.Button
    Friend WithEvents btUniDNF As System.Windows.Forms.Button
    Friend WithEvents ofdUniDanfe As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEmailContador As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtWinZIP As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtBaud As System.Windows.Forms.ComboBox
    Friend WithEvents chkHoraVerao As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNumEvento As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents btGravar As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btSair = New System.Windows.Forms.Button()
        Me.btGravar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBaud = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkagenda = New System.Windows.Forms.CheckBox()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPorta = New System.Windows.Forms.TextBox()
        Me.cntTemp = New System.Windows.Forms.NumericUpDown()
        Me.cmbPorta = New System.Windows.Forms.ComboBox()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.txtConRemoto = New System.Windows.Forms.TextBox()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.lblVersao = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Line2 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNumEvento = New System.Windows.Forms.NumericUpDown()
        Me.chkHoraVerao = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtWinZIP = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmailContador = New System.Windows.Forms.TextBox()
        Me.btUniDNF = New System.Windows.Forms.Button()
        Me.btPastaNFe = New System.Windows.Forms.Button()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCaminho = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAliquota = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.rdHomologacao = New System.Windows.Forms.RadioButton()
        Me.rdProducao = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumNFe = New System.Windows.Forms.TextBox()
        Me.txtPasta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.fbdPastaNFe = New System.Windows.Forms.FolderBrowserDialog()
        Me.ofdUniDanfe = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.cntTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.txtNumEvento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.SystemColors.Control
        Me.btSair.Cursor = System.Windows.Forms.Cursors.Default
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btSair.Location = New System.Drawing.Point(462, 423)
        Me.btSair.Name = "btSair"
        Me.btSair.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btSair.Size = New System.Drawing.Size(65, 21)
        Me.btSair.TabIndex = 2
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = False
        '
        'btGravar
        '
        Me.btGravar.BackColor = System.Drawing.SystemColors.Control
        Me.btGravar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btGravar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGravar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btGravar.Location = New System.Drawing.Point(382, 423)
        Me.btGravar.Name = "btGravar"
        Me.btGravar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btGravar.Size = New System.Drawing.Size(73, 21)
        Me.btGravar.TabIndex = 1
        Me.btGravar.Text = "Gravar"
        Me.btGravar.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(515, 405)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtBaud)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.chkagenda)
        Me.TabPage1.Controls.Add(Me.txtBanco)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPorta)
        Me.TabPage1.Controls.Add(Me.cntTemp)
        Me.TabPage1.Controls.Add(Me.cmbPorta)
        Me.TabPage1.Controls.Add(Me.txtIP)
        Me.TabPage1.Controls.Add(Me.txtConRemoto)
        Me.TabPage1.Controls.Add(Me.lblProduto)
        Me.TabPage1.Controls.Add(Me.lblVersao)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Line2)
        Me.TabPage1.Controls.Add(Me.Line1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(507, 378)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Geral"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtBaud
        '
        Me.txtBaud.FormattingEnabled = True
        Me.txtBaud.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400"})
        Me.txtBaud.Location = New System.Drawing.Point(328, 277)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(67, 22)
        Me.txtBaud.TabIndex = 45
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(401, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Envia"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(230, 280)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 14)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Velocidade (bps):"
        '
        'chkagenda
        '
        Me.chkagenda.AutoSize = True
        Me.chkagenda.Location = New System.Drawing.Point(24, 343)
        Me.chkagenda.Name = "chkagenda"
        Me.chkagenda.Size = New System.Drawing.Size(223, 18)
        Me.chkagenda.TabIndex = 41
        Me.chkagenda.Text = "Mostrar agenda de isolamentos ao iniciar"
        Me.chkagenda.UseVisualStyleBackColor = True
        '
        'txtBanco
        '
        Me.txtBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanco.Location = New System.Drawing.Point(167, 164)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(73, 20)
        Me.txtBanco.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(29, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Banco de Dados:"
        '
        'txtPorta
        '
        Me.txtPorta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorta.Location = New System.Drawing.Point(167, 136)
        Me.txtPorta.Name = "txtPorta"
        Me.txtPorta.Size = New System.Drawing.Size(53, 20)
        Me.txtPorta.TabIndex = 38
        '
        'cntTemp
        '
        Me.cntTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cntTemp.Location = New System.Drawing.Point(191, 304)
        Me.cntTemp.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.cntTemp.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.cntTemp.Name = "cntTemp"
        Me.cntTemp.Size = New System.Drawing.Size(43, 20)
        Me.cntTemp.TabIndex = 37
        Me.cntTemp.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'cmbPorta
        '
        Me.cmbPorta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPorta.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPorta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPorta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPorta.Location = New System.Drawing.Point(167, 277)
        Me.cmbPorta.Name = "cmbPorta"
        Me.cmbPorta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPorta.Size = New System.Drawing.Size(57, 21)
        Me.cmbPorta.TabIndex = 32
        '
        'txtIP
        '
        Me.txtIP.AcceptsReturn = True
        Me.txtIP.BackColor = System.Drawing.SystemColors.Window
        Me.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIP.Location = New System.Drawing.Point(167, 109)
        Me.txtIP.MaxLength = 0
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(97, 20)
        Me.txtIP.TabIndex = 27
        Me.txtIP.Text = "000.000.000.000"
        Me.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConRemoto
        '
        Me.txtConRemoto.AcceptsReturn = True
        Me.txtConRemoto.BackColor = System.Drawing.SystemColors.Window
        Me.txtConRemoto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConRemoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConRemoto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConRemoto.Location = New System.Drawing.Point(167, 193)
        Me.txtConRemoto.MaxLength = 0
        Me.txtConRemoto.Multiline = True
        Me.txtConRemoto.Name = "txtConRemoto"
        Me.txtConRemoto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConRemoto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConRemoto.Size = New System.Drawing.Size(318, 41)
        Me.txtConRemoto.TabIndex = 26
        '
        'lblProduto
        '
        Me.lblProduto.AutoSize = True
        Me.lblProduto.BackColor = System.Drawing.Color.Transparent
        Me.lblProduto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProduto.Location = New System.Drawing.Point(25, 17)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProduto.Size = New System.Drawing.Size(180, 13)
        Me.lblProduto.TabIndex = 34
        Me.lblProduto.Text = "Configuração do sistema de Controle"
        '
        'lblVersao
        '
        Me.lblVersao.AutoSize = True
        Me.lblVersao.BackColor = System.Drawing.Color.Transparent
        Me.lblVersao.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersao.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersao.Location = New System.Drawing.Point(29, 41)
        Me.lblVersao.Name = "lblVersao"
        Me.lblVersao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersao.Size = New System.Drawing.Size(43, 13)
        Me.lblVersao.TabIndex = 33
        Me.lblVersao.Text = "Versão:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(25, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(157, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Intensidade Impressora Térmica"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(25, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Porta da Impressora"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(25, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(141, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Configurações de Impressão"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(25, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(173, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Configurações de Conexão MySQL"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line2.Location = New System.Drawing.Point(21, 73)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(464, 1)
        Me.Line2.TabIndex = 35
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line1.Location = New System.Drawing.Point(21, 249)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(464, 1)
        Me.Line1.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(29, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Porta de Conexão:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(29, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "String de Conexão remota:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(29, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "IP do Servidor Local:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtNumEvento)
        Me.TabPage2.Controls.Add(Me.chkHoraVerao)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtWinZIP)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtEmailContador)
        Me.TabPage2.Controls.Add(Me.btUniDNF)
        Me.TabPage2.Controls.Add(Me.btPastaNFe)
        Me.TabPage2.Controls.Add(Me.txtSerie)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtCaminho)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtAliquota)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtNumNFe)
        Me.TabPage2.Controls.Add(Me.txtPasta)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(507, 378)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "NFe"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 117)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 14)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Número Evento:"
        '
        'txtNumEvento
        '
        Me.txtNumEvento.Location = New System.Drawing.Point(110, 115)
        Me.txtNumEvento.Name = "txtNumEvento"
        Me.txtNumEvento.Size = New System.Drawing.Size(63, 20)
        Me.txtNumEvento.TabIndex = 17
        '
        'chkHoraVerao
        '
        Me.chkHoraVerao.AutoSize = True
        Me.chkHoraVerao.Location = New System.Drawing.Point(179, 39)
        Me.chkHoraVerao.Name = "chkHoraVerao"
        Me.chkHoraVerao.Size = New System.Drawing.Size(108, 18)
        Me.chkHoraVerao.TabIndex = 2
        Me.chkHoraVerao.Text = "Horário de Verão"
        Me.chkHoraVerao.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 196)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 14)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Compactador de Arquivos:"
        '
        'txtWinZIP
        '
        Me.txtWinZIP.Location = New System.Drawing.Point(141, 193)
        Me.txtWinZIP.Name = "txtWinZIP"
        Me.txtWinZIP.Size = New System.Drawing.Size(285, 20)
        Me.txtWinZIP.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 14)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "E-mail Contador p/ XML's:"
        '
        'txtEmailContador
        '
        Me.txtEmailContador.Location = New System.Drawing.Point(141, 167)
        Me.txtEmailContador.Name = "txtEmailContador"
        Me.txtEmailContador.Size = New System.Drawing.Size(285, 20)
        Me.txtEmailContador.TabIndex = 6
        '
        'btUniDNF
        '
        Me.btUniDNF.Location = New System.Drawing.Point(432, 138)
        Me.btUniDNF.Name = "btUniDNF"
        Me.btUniDNF.Size = New System.Drawing.Size(24, 23)
        Me.btUniDNF.TabIndex = 12
        Me.btUniDNF.Text = "..."
        Me.btUniDNF.UseVisualStyleBackColor = True
        '
        'btPastaNFe
        '
        Me.btPastaNFe.Location = New System.Drawing.Point(432, 10)
        Me.btPastaNFe.Name = "btPastaNFe"
        Me.btPastaNFe.Size = New System.Drawing.Size(24, 23)
        Me.btPastaNFe.TabIndex = 11
        Me.btPastaNFe.Text = "..."
        Me.btPastaNFe.UseVisualStyleBackColor = True
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(110, 63)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(39, 20)
        Me.txtSerie.TabIndex = 3
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 14)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Série NFe:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 144)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 14)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Caminho UniDanfe:"
        '
        'txtCaminho
        '
        Me.txtCaminho.Location = New System.Drawing.Point(110, 141)
        Me.txtCaminho.Name = "txtCaminho"
        Me.txtCaminho.Size = New System.Drawing.Size(316, 20)
        Me.txtCaminho.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 14)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Alíquota ICMS:"
        '
        'txtAliquota
        '
        Me.txtAliquota.Location = New System.Drawing.Point(110, 89)
        Me.txtAliquota.Name = "txtAliquota"
        Me.txtAliquota.Size = New System.Drawing.Size(63, 20)
        Me.txtAliquota.TabIndex = 4
        Me.txtAliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.rdHomologacao)
        Me.GroupBox1.Controls.Add(Me.rdProducao)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 317)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 55)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Tipo do Ambiente "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(434, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "NFe 4.00"
        '
        'rdHomologacao
        '
        Me.rdHomologacao.AutoSize = True
        Me.rdHomologacao.Location = New System.Drawing.Point(103, 19)
        Me.rdHomologacao.Name = "rdHomologacao"
        Me.rdHomologacao.Size = New System.Drawing.Size(90, 18)
        Me.rdHomologacao.TabIndex = 1
        Me.rdHomologacao.TabStop = True
        Me.rdHomologacao.Text = "Homologação"
        Me.rdHomologacao.UseVisualStyleBackColor = True
        '
        'rdProducao
        '
        Me.rdProducao.AutoSize = True
        Me.rdProducao.Location = New System.Drawing.Point(6, 19)
        Me.rdProducao.Name = "rdProducao"
        Me.rdProducao.Size = New System.Drawing.Size(71, 18)
        Me.rdProducao.TabIndex = 0
        Me.rdProducao.TabStop = True
        Me.rdProducao.Text = "Produção"
        Me.rdProducao.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Nº da NFe:"
        '
        'txtNumNFe
        '
        Me.txtNumNFe.Location = New System.Drawing.Point(110, 37)
        Me.txtNumNFe.Name = "txtNumNFe"
        Me.txtNumNFe.Size = New System.Drawing.Size(63, 20)
        Me.txtNumNFe.TabIndex = 1
        Me.txtNumNFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPasta
        '
        Me.txtPasta.Location = New System.Drawing.Point(110, 11)
        Me.txtPasta.Name = "txtPasta"
        Me.txtPasta.Size = New System.Drawing.Size(316, 20)
        Me.txtPasta.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Pasta Base NFe:"
        '
        'fbdPastaNFe
        '
        Me.fbdPastaNFe.Description = "Selecione a pasta base das NFe"
        Me.fbdPastaNFe.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.fbdPastaNFe.ShowNewFolderButton = False
        '
        'ofdUniDanfe
        '
        Me.ofdUniDanfe.FileName = "Unidanfe.exe"
        Me.ofdUniDanfe.Filter = "UniDanfe|Unidanfe.exe"
        Me.ofdUniDanfe.Title = "Caminho do UniDanfe"
        '
        'frmConfig
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(541, 456)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btGravar)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(386, 210)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração do Sistema"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.cntTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.txtNumEvento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As frmConfig
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmConfig
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmConfig()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As frmConfig)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btGravar.Click
        Dim txtAmbiente As String

        'Grava os valores dos campos nas variaveis de configuração do programa
        My.Settings.MyServer = txtIP.Text
        My.Settings.MyPort = txtPorta.Text
        My.Settings.MyDB = txtBanco.Text
        My.Settings.MyRemote = txtConRemoto.Text
        My.Settings.MyPrintPort = cmbPorta.Text
        My.Settings.MyBaud = txtBaud.Text
        My.Settings.MyTemp = cntTemp.Value.ToString
        My.Settings.ShowSchl = chkagenda.Checked
        My.Settings.PastaNFe = txtPasta.Text
        My.Settings.CaminhoZIP = txtWinZIP.Text

        'Estes são gravados no Banco de Dados
        Dim Nome() As String, Valor() As String
        Dim i As Integer = 0, SQL As String = String.Empty

        txtAmbiente = IIf(rdHomologacao.Checked = True, "2", "1")
        '1 - Produção   2 - Homologacao

        Dim txtPath As String = txtCaminho.Text.Replace("\", "\\")

        Nome = {"NFeNum", "NFESerie", "NFEAliquota", "NFEUnidanfe", "emailContador", "NFeAmbiente", "NFeHoraVerao", "NFeNumEvento"}
        Valor = {txtNumNFe.Text, txtSerie.Text, txtAliquota.Text, txtPath, txtEmailContador.Text, txtAmbiente, IIf(chkHoraVerao.Checked, "1", "0"), txtNumEvento.Value}

        If Conectado Then
            Try
                For i = 0 To Nome.Length - 1
                    SQL &= "UPDATE Parametros SET Valor='" & Valor(i) & "' WHERE Nome='" & Nome(i) & "'; "
                Next
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar gravar os parâmetros no servidor" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            End Try
        End If

        Try
            'Salva as propriedades no arquivo XML
            My.Settings.Save()
            'Altera as Connection Strings para os valores atuais
            MY_SQL_CONNECTION = "server=" & txtIP.Text & ";" &
            "user id=" & My.Settings.MyUsername & ";" &
           "password=" & My.Settings.MyPassword & ";" &
           "database=" & My.Settings.MyDB
            'DataSet Conection string
            DS_MYSQL_CONNECTION = "server=" & txtIP.Text & ";user id=" & My.Settings.MyUsername & ";database=" & My.Settings.MyDB & ";persist security info=True;password=" & My.Settings.MyPassword
            'Para Debug tem que deixar, mas para compilação tem que colocar
            My.Settings.csControle = DS_MYSQL_CONNECTION

            MsgBox("Configurações salvas com sucesso!", MsgBoxStyle.Exclamation, "Confirmação")
        Catch err As Exception
            MsgBox("Erro ao salvar as configurações: " & err.Message, MsgBoxStyle.Critical, "Aviso")
            GoTo FIM
        End Try
        'Atualiza a barra de status do formulario principal
        frmMenu.sbpNFe.Text = "NFe: " & IIf(My.Settings.NFeAmbiente = "1", "Produção", "Homologação")
FIM:

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btSair.Click
        'Funcao que dá um ping no servidor e atualiza os dados na barra de status
        IP_Barra_Status()
        Me.Close()
    End Sub

    Private Sub frmConfig_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Funcao que dá um ping no servidor e atualiza os dados na barra de status
        IP_Barra_Status()
    End Sub

    Private Sub frmConfig_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Atribui os textos aos valores configurados no arquivo XML de Configuração do programa
        txtIP.Text = My.Settings.MyServer
        txtPorta.Text = My.Settings.MyPort
        txtBanco.Text = My.Settings.MyDB
        txtConRemoto.Text = My.Settings.MyRemote
        cmbPorta.Text = My.Settings.MyPrintPort
        txtPasta.Text = My.Settings.PastaNFe
        txtWinZIP.Text = My.Settings.CaminhoZIP
        txtBaud.Text = My.Settings.MyBaud

        If Conectado Then
            'Itens que devem ser pegos no Servidor
            txtAliquota.Text = DLookup("Valor", "Parametros", "Nome='NFeAliquota'")
            txtNumNFe.Text = DLookup("Valor", "Parametros", "Nome='NFeNum'")
            txtCaminho.Text = DLookup("Valor", "Parametros", "Nome='NFEUnidanfe'")
            txtSerie.Text = DLookup("Valor", "Parametros", "Nome='NFESerie'")
            rdHomologacao.Checked = IIf(DLookup("Valor", "Parametros", "Nome='NFeAmbiente'") = "2", True, False)
            rdProducao.Checked = IIf(DLookup("Valor", "Parametros", "Nome='NFeAmbiente'") = "1", True, False)
            txtEmailContador.Text = DLookup("Valor", "Parametros", "Nome='emailContador'")
            txtNumEvento.Value = DLookup("Valor", "Parametros", "Nome='NFeNumEvento'")
            chkHoraVerao.Checked = IIf(DLookup("Valor", "Parametros", "Nome='NFeHoraVerao'") = 1, True, False)
        End If

        cntTemp.Value = CDbl(My.Settings.MyTemp.ToString)

        'Pega a lista das portas disponíveis
        Dim Lista_portas() As String = System.IO.Ports.SerialPort.GetPortNames

        For Each Item As String In Lista_portas
            cmbPorta.Items.Add(Item)
        Next

    End Sub


    Private Sub btPastaNFe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPastaNFe.Click
        'mostra a caixa de seleção
        fbdPastaNFe.ShowDialog()
        txtPasta.Text = fbdPastaNFe.SelectedPath
    End Sub

    Private Sub btUniDNF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUniDNF.Click
        ofdUniDanfe.ShowDialog()
        txtCaminho.Text = ofdUniDanfe.FileName
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Cod As Char
        'Se a porta está preenchida e a velocidade também então
        If cmbPorta.Text <> String.Empty And txtBaud.Text <> String.Empty Then
            Dim Porta_Serial As New System.IO.Ports.SerialPort
            Select Case txtBaud.Text
                Case "2400"
                    Cod = Chr(2)
                Case "4800"
                    Cod = Chr(4)
                Case "9600"
                    Cod = Chr(7)
                Case "19200"
                    Cod = Chr(3)
                Case "38400"
                    Cod = Chr(5)
            End Select
            Try
                'Define os parametros antigos para poder mandar os novos
                With Porta_Serial
                    .PortName = My.Settings.MyPrintPort
                    .BaudRate = Int(My.Settings.MyBaud)
                    .Parity = System.IO.Ports.Parity.None
                    .DataBits = 8
                    .StopBits = System.IO.Ports.StopBits.One
                    .Close()
                    .Open()
                    .WriteLine(Chr(2) & "KI8" & Cod)
                    .Close()
                End With
            Catch ex As Exception

            End Try
            MsgBox("Comando enviado... Agora desligue a impressora aguarde 10 segundos" & vbCrLf & "Então ligue novamente para que as alterações tenham efeito", vbOKOnly, "Aviso")
        End If
    End Sub

    Private Sub chkHoraVerao_CheckedChanged(sender As Object, e As EventArgs) Handles chkHoraVerao.CheckedChanged

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub
End Class