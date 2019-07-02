<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNovoLotes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pbQrCode = New System.Windows.Forms.PictureBox()
        Me.grpFrascos = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNumOP = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtAnotacoes = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFase = New System.Windows.Forms.ComboBox()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTempo = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNOrigem = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.cmbMercadoria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEstIni = New System.Windows.Forms.Label()
        Me.txtEstFrascos = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.lblFrascoID = New System.Windows.Forms.Label()
        Me.lblMotivoBaixa = New System.Windows.Forms.Label()
        Me.lblDataBaixa = New System.Windows.Forms.Label()
        Me.lblBaixadoPor = New System.Windows.Forms.Label()
        Me.lblCriado = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbOrigem = New System.Windows.Forms.ComboBox()
        Me.btFrascos = New System.Windows.Forms.Button()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVidro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMudas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrigem = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colRepicador = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMeio = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colExplante = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SelecaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpressoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bxExclusao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DsFrascosAux = New SisControl.NET.dsFrascosAux()
        Me.cmbRepicador = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbExplante = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbFrasco = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNFrascos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMeio = New System.Windows.Forms.ComboBox()
        Me.txtM_F = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.epErro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.taAux_frascos = New SisControl.NET.dsFrascosAuxTableAdapters.TA_aux_frascos
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.pbQrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFrascos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFrascosAux, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbQrCode
        '
        Me.pbQrCode.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pbQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbQrCode.Location = New System.Drawing.Point(679, 57)
        Me.pbQrCode.Name = "pbQrCode"
        Me.pbQrCode.Size = New System.Drawing.Size(89, 89)
        Me.pbQrCode.TabIndex = 0
        Me.pbQrCode.TabStop = False
        '
        'grpFrascos
        '
        Me.grpFrascos.Controls.Add(Me.Label15)
        Me.grpFrascos.Controls.Add(Me.txtNumOP)
        Me.grpFrascos.Controls.Add(Me.txtID)
        Me.grpFrascos.Controls.Add(Me.Label20)
        Me.grpFrascos.Controls.Add(Me.txtAnotacoes)
        Me.grpFrascos.Controls.Add(Me.Label11)
        Me.grpFrascos.Controls.Add(Me.cmbFase)
        Me.grpFrascos.Controls.Add(Me.txtDias)
        Me.grpFrascos.Controls.Add(Me.Label19)
        Me.grpFrascos.Controls.Add(Me.txtTempo)
        Me.grpFrascos.Controls.Add(Me.pbQrCode)
        Me.grpFrascos.Controls.Add(Me.Label9)
        Me.grpFrascos.Controls.Add(Me.txtNOrigem)
        Me.grpFrascos.Controls.Add(Me.Label6)
        Me.grpFrascos.Controls.Add(Me.Label4)
        Me.grpFrascos.Controls.Add(Me.txtClone)
        Me.grpFrascos.Controls.Add(Me.Label3)
        Me.grpFrascos.Controls.Add(Me.txtLote)
        Me.grpFrascos.Controls.Add(Me.cmbMercadoria)
        Me.grpFrascos.Controls.Add(Me.Label2)
        Me.grpFrascos.Controls.Add(Me.Label1)
        Me.grpFrascos.Controls.Add(Me.txtCodigo)
        Me.grpFrascos.Location = New System.Drawing.Point(12, 12)
        Me.grpFrascos.Name = "grpFrascos"
        Me.grpFrascos.Size = New System.Drawing.Size(845, 165)
        Me.grpFrascos.TabIndex = 0
        Me.grpFrascos.TabStop = False
        Me.grpFrascos.Text = "Dados do Lote"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(513, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 13)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Nº Ordem Produção:"
        '
        'txtNumOP
        '
        Me.txtNumOP.Location = New System.Drawing.Point(624, 133)
        Me.txtNumOP.Name = "txtNumOP"
        Me.txtNumOP.Size = New System.Drawing.Size(49, 20)
        Me.txtNumOP.TabIndex = 9
        Me.txtNumOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtID.Location = New System.Drawing.Point(763, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(74, 21)
        Me.txtID.TabIndex = 43
        Me.txtID.Text = "..."
        Me.txtID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(272, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Anotações:"
        '
        'txtAnotacoes
        '
        Me.txtAnotacoes.AcceptsReturn = True
        Me.txtAnotacoes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnotacoes.Location = New System.Drawing.Point(339, 57)
        Me.txtAnotacoes.Multiline = True
        Me.txtAnotacoes.Name = "txtAnotacoes"
        Me.txtAnotacoes.Size = New System.Drawing.Size(334, 70)
        Me.txtAnotacoes.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(11, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Fase:"
        '
        'cmbFase
        '
        Me.cmbFase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFase.FormattingEnabled = True
        Me.cmbFase.Location = New System.Drawing.Point(133, 106)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(120, 21)
        Me.cmbFase.TabIndex = 6
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(133, 133)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(35, 20)
        Me.txtDias.TabIndex = 7
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(11, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 13)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Dias para Repicagem:"
        '
        'txtTempo
        '
        Me.txtTempo.Location = New System.Drawing.Point(133, 80)
        Me.txtTempo.Mask = "00:00"
        Me.txtTempo.Name = "txtTempo"
        Me.txtTempo.Size = New System.Drawing.Size(35, 20)
        Me.txtTempo.TabIndex = 5
        Me.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTempo.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(11, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Tempo:"
        '
        'txtNOrigem
        '
        Me.txtNOrigem.Location = New System.Drawing.Point(133, 54)
        Me.txtNOrigem.Name = "txtNOrigem"
        Me.txtNOrigem.Size = New System.Drawing.Size(35, 20)
        Me.txtNOrigem.TabIndex = 4
        Me.txtNOrigem.Text = "0"
        Me.txtNOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Nº Frascos de Orígem:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(655, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Clone:"
        '
        'txtClone
        '
        Me.txtClone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClone.Location = New System.Drawing.Point(698, 21)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(59, 20)
        Me.txtClone.TabIndex = 3
        Me.txtClone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(541, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Lote:"
        '
        'txtLote
        '
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLote.Location = New System.Drawing.Point(578, 21)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(59, 20)
        Me.txtLote.TabIndex = 2
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbMercadoria
        '
        Me.cmbMercadoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMercadoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMercadoria.FormattingEnabled = True
        Me.cmbMercadoria.Location = New System.Drawing.Point(313, 21)
        Me.cmbMercadoria.Name = "cmbMercadoria"
        Me.cmbMercadoria.Size = New System.Drawing.Size(213, 21)
        Me.cmbMercadoria.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(249, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Variedade:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Código do Lote:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigo.Location = New System.Drawing.Point(100, 21)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(119, 21)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(580, 481)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Estoque em Frascos:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(422, 481)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Estoque Inicial:"
        '
        'txtEstIni
        '
        Me.txtEstIni.Location = New System.Drawing.Point(507, 481)
        Me.txtEstIni.Name = "txtEstIni"
        Me.txtEstIni.Size = New System.Drawing.Size(43, 15)
        Me.txtEstIni.TabIndex = 35
        Me.txtEstIni.Text = "0"
        '
        'txtEstFrascos
        '
        Me.txtEstFrascos.Location = New System.Drawing.Point(692, 481)
        Me.txtEstFrascos.Name = "txtEstFrascos"
        Me.txtEstFrascos.Size = New System.Drawing.Size(43, 15)
        Me.txtEstFrascos.TabIndex = 36
        Me.txtEstFrascos.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlInfo)
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbOrigem)
        Me.GroupBox1.Controls.Add(Me.btFrascos)
        Me.GroupBox1.Controls.Add(Me.dgFrascos)
        Me.GroupBox1.Controls.Add(Me.cmbRepicador)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cmbExplante)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbFrasco)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtNFrascos)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmbMeio)
        Me.GroupBox1.Controls.Add(Me.txtM_F)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(845, 287)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados dos Frascos"
        '
        'pnlInfo
        '
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.lblFrascoID)
        Me.pnlInfo.Controls.Add(Me.lblMotivoBaixa)
        Me.pnlInfo.Controls.Add(Me.lblDataBaixa)
        Me.pnlInfo.Controls.Add(Me.lblBaixadoPor)
        Me.pnlInfo.Controls.Add(Me.lblCriado)
        Me.pnlInfo.Controls.Add(Me.Label26)
        Me.pnlInfo.Controls.Add(Me.Label25)
        Me.pnlInfo.Controls.Add(Me.Label24)
        Me.pnlInfo.Controls.Add(Me.Label23)
        Me.pnlInfo.Controls.Add(Me.lblStatus)
        Me.pnlInfo.Controls.Add(Me.Label21)
        Me.pnlInfo.Controls.Add(Me.btFechar)
        Me.pnlInfo.Location = New System.Drawing.Point(275, 122)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(297, 143)
        Me.pnlInfo.TabIndex = 46
        Me.pnlInfo.Visible = False
        '
        'lblFrascoID
        '
        Me.lblFrascoID.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblFrascoID.Location = New System.Drawing.Point(206, 6)
        Me.lblFrascoID.Name = "lblFrascoID"
        Me.lblFrascoID.Size = New System.Drawing.Size(83, 23)
        Me.lblFrascoID.TabIndex = 11
        Me.lblFrascoID.Text = "..."
        Me.lblFrascoID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMotivoBaixa
        '
        Me.lblMotivoBaixa.AutoSize = True
        Me.lblMotivoBaixa.Location = New System.Drawing.Point(101, 103)
        Me.lblMotivoBaixa.Name = "lblMotivoBaixa"
        Me.lblMotivoBaixa.Size = New System.Drawing.Size(16, 13)
        Me.lblMotivoBaixa.TabIndex = 10
        Me.lblMotivoBaixa.Text = "..."
        Me.lblMotivoBaixa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDataBaixa
        '
        Me.lblDataBaixa.AutoSize = True
        Me.lblDataBaixa.Location = New System.Drawing.Point(101, 80)
        Me.lblDataBaixa.Name = "lblDataBaixa"
        Me.lblDataBaixa.Size = New System.Drawing.Size(16, 13)
        Me.lblDataBaixa.TabIndex = 9
        Me.lblDataBaixa.Text = "..."
        Me.lblDataBaixa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBaixadoPor
        '
        Me.lblBaixadoPor.AutoSize = True
        Me.lblBaixadoPor.Location = New System.Drawing.Point(101, 57)
        Me.lblBaixadoPor.Name = "lblBaixadoPor"
        Me.lblBaixadoPor.Size = New System.Drawing.Size(16, 13)
        Me.lblBaixadoPor.TabIndex = 8
        Me.lblBaixadoPor.Text = "..."
        Me.lblBaixadoPor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCriado
        '
        Me.lblCriado.AutoSize = True
        Me.lblCriado.Location = New System.Drawing.Point(101, 34)
        Me.lblCriado.Name = "lblCriado"
        Me.lblCriado.Size = New System.Drawing.Size(16, 13)
        Me.lblCriado.TabIndex = 7
        Me.lblCriado.Text = "..."
        Me.lblCriado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 103)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(86, 13)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Motivo da Baixa:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Baixado em:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(13, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Baixado por:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 34)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Criado por:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(59, 11)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(31, 13)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Ativo"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Status:"
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(234, 116)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(55, 20)
        Me.btFechar.TabIndex = 0
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.CustomFormat = "dd/MM/yyyy"
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtData.Location = New System.Drawing.Point(510, 52)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(82, 20)
        Me.txtData.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(127, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Lote de Orígem:"
        '
        'cmbOrigem
        '
        Me.cmbOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrigem.DropDownHeight = 100
        Me.cmbOrigem.FormattingEnabled = True
        Me.cmbOrigem.IntegralHeight = False
        Me.cmbOrigem.Location = New System.Drawing.Point(130, 52)
        Me.cmbOrigem.Name = "cmbOrigem"
        Me.cmbOrigem.Size = New System.Drawing.Size(100, 21)
        Me.cmbOrigem.TabIndex = 2
        '
        'btFrascos
        '
        Me.btFrascos.Location = New System.Drawing.Point(766, 17)
        Me.btFrascos.Name = "btFrascos"
        Me.btFrascos.Size = New System.Drawing.Size(67, 25)
        Me.btFrascos.TabIndex = 8
        Me.btFrascos.Text = "Adicionar"
        Me.btFrascos.UseVisualStyleBackColor = True
        '
        'dgFrascos
        '
        Me.dgFrascos.AllowUserToAddRows = False
        Me.dgFrascos.AutoGenerateColumns = False
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colVidro, Me.colMudas, Me.colOrigem, Me.colRepicador, Me.colMeio, Me.colData, Me.colTipo, Me.colExplante, Me.SelecaoDataGridViewTextBoxColumn, Me.ImpressoDataGridViewTextBoxColumn, Me.bxExclusao})
        Me.dgFrascos.DataMember = "aux_frascos"
        Me.dgFrascos.DataSource = Me.DsFrascosAux
        Me.dgFrascos.Location = New System.Drawing.Point(8, 81)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.RowHeadersWidth = 21
        Me.dgFrascos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFrascos.Size = New System.Drawing.Size(828, 195)
        Me.dgFrascos.TabIndex = 9
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "id"
        Me.colID.Name = "colID"
        Me.colID.Visible = False
        '
        'colVidro
        '
        Me.colVidro.DataPropertyName = "Vidro"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colVidro.DefaultCellStyle = DataGridViewCellStyle4
        Me.colVidro.HeaderText = "Nº Vidro"
        Me.colVidro.Name = "colVidro"
        Me.colVidro.Width = 50
        '
        'colMudas
        '
        Me.colMudas.DataPropertyName = "NMudas"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colMudas.DefaultCellStyle = DataGridViewCellStyle5
        Me.colMudas.HeaderText = "Nº Mudas"
        Me.colMudas.Name = "colMudas"
        Me.colMudas.Width = 50
        '
        'colOrigem
        '
        Me.colOrigem.DataPropertyName = "Origem"
        Me.colOrigem.HeaderText = "Origem"
        Me.colOrigem.Name = "colOrigem"
        Me.colOrigem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOrigem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOrigem.Width = 110
        '
        'colRepicador
        '
        Me.colRepicador.DataPropertyName = "Repicador"
        Me.colRepicador.HeaderText = "Repicador"
        Me.colRepicador.Name = "colRepicador"
        Me.colRepicador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRepicador.Width = 140
        '
        'colMeio
        '
        Me.colMeio.DataPropertyName = "Meio"
        Me.colMeio.HeaderText = "Meio"
        Me.colMeio.Name = "colMeio"
        Me.colMeio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMeio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colMeio.Width = 130
        '
        'colData
        '
        Me.colData.DataPropertyName = "Data"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colData.DefaultCellStyle = DataGridViewCellStyle6
        Me.colData.HeaderText = "Data"
        Me.colData.Name = "colData"
        Me.colData.Width = 85
        '
        'colTipo
        '
        Me.colTipo.DataPropertyName = "frTipo"
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTipo.Width = 107
        '
        'colExplante
        '
        Me.colExplante.DataPropertyName = "Explante"
        Me.colExplante.HeaderText = "Explante"
        Me.colExplante.Name = "colExplante"
        Me.colExplante.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colExplante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExplante.Width = 107
        '
        'SelecaoDataGridViewTextBoxColumn
        '
        Me.SelecaoDataGridViewTextBoxColumn.DataPropertyName = "Selecao"
        Me.SelecaoDataGridViewTextBoxColumn.HeaderText = "Selecao"
        Me.SelecaoDataGridViewTextBoxColumn.Name = "SelecaoDataGridViewTextBoxColumn"
        Me.SelecaoDataGridViewTextBoxColumn.Visible = False
        '
        'ImpressoDataGridViewTextBoxColumn
        '
        Me.ImpressoDataGridViewTextBoxColumn.DataPropertyName = "Impresso"
        Me.ImpressoDataGridViewTextBoxColumn.HeaderText = "Impresso"
        Me.ImpressoDataGridViewTextBoxColumn.Name = "ImpressoDataGridViewTextBoxColumn"
        Me.ImpressoDataGridViewTextBoxColumn.Visible = False
        '
        'bxExclusao
        '
        Me.bxExclusao.DataPropertyName = "bxExclusao"
        Me.bxExclusao.HeaderText = "bxExclusao"
        Me.bxExclusao.Name = "bxExclusao"
        Me.bxExclusao.Visible = False
        '
        'DsFrascosAux
        '
        'Me.DsFrascosAux.DataSetName = "dsFrascosAux"
        'Me.DsFrascosAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbRepicador
        '
        Me.cmbRepicador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbRepicador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRepicador.FormattingEnabled = True
        Me.cmbRepicador.Items.AddRange(New Object() {"Calos", "Embrião", "Folha", "Fragmento Rizoma", "Gema Apical", "Gema Lateral", "Meristema", "Plântula", "Segmento Nodal", "Sementes", "Tufos"})
        Me.cmbRepicador.Location = New System.Drawing.Point(240, 52)
        Me.cmbRepicador.Name = "cmbRepicador"
        Me.cmbRepicador.Size = New System.Drawing.Size(133, 21)
        Me.cmbRepicador.Sorted = True
        Me.cmbRepicador.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(237, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Repicador"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(700, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Explante:"
        '
        'cmbExplante
        '
        Me.cmbExplante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbExplante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbExplante.FormattingEnabled = True
        Me.cmbExplante.Items.AddRange(New Object() {"Calos", "Embrião", "Folha", "Fragmento Rizoma", "Gema Apical", "Gema Lateral", "Meristema", "Plântula", "Segmento Nodal", "Sementes", "Tufos"})
        Me.cmbExplante.Location = New System.Drawing.Point(703, 52)
        Me.cmbExplante.Name = "cmbExplante"
        Me.cmbExplante.Size = New System.Drawing.Size(106, 21)
        Me.cmbExplante.Sorted = True
        Me.cmbExplante.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(596, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Tipo do Frasco:"
        '
        'cmbFrasco
        '
        Me.cmbFrasco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFrasco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFrasco.FormattingEnabled = True
        Me.cmbFrasco.Items.AddRange(New Object() {"Frasco de Vidro", "Tubo de Ensaio", "Erlenmeyer", "Pote plástico 500g", "Pote plástico 250g", "Biorreator", "Especial"})
        Me.cmbFrasco.Location = New System.Drawing.Point(596, 52)
        Me.cmbFrasco.Name = "cmbFrasco"
        Me.cmbFrasco.Size = New System.Drawing.Size(101, 21)
        Me.cmbFrasco.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(508, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Data:"
        '
        'txtNFrascos
        '
        Me.txtNFrascos.Location = New System.Drawing.Point(29, 52)
        Me.txtNFrascos.Name = "txtNFrascos"
        Me.txtNFrascos.Size = New System.Drawing.Size(35, 20)
        Me.txtNFrascos.TabIndex = 0
        Me.txtNFrascos.Text = "0"
        Me.txtNFrascos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(26, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 36)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Nº de Frascos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(376, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Meio:"
        '
        'cmbMeio
        '
        Me.cmbMeio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMeio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMeio.FormattingEnabled = True
        Me.cmbMeio.Location = New System.Drawing.Point(379, 52)
        Me.cmbMeio.Name = "cmbMeio"
        Me.cmbMeio.Size = New System.Drawing.Size(126, 21)
        Me.cmbMeio.TabIndex = 4
        '
        'txtM_F
        '
        Me.txtM_F.Location = New System.Drawing.Point(81, 52)
        Me.txtM_F.Name = "txtM_F"
        Me.txtM_F.Size = New System.Drawing.Size(35, 20)
        Me.txtM_F.TabIndex = 1
        Me.txtM_F.Text = "0"
        Me.txtM_F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(78, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 27)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Nº Mudas"
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(773, 476)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btIncluir.TabIndex = 0
        Me.btIncluir.Text = "Incluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'epErro
        '
        Me.epErro.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epErro.ContainerControl = Me
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.Location = New System.Drawing.Point(12, 480)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 41
        Me.chkAtivo.TabStop = False
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        Me.chkAtivo.Visible = False
        '
        'taAux_frascos
        '
        'Me.taAux_frascos.ClearBeforeFill = True

        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(71, 481)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(148, 13)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "[ F3 ] - Informações do Frasco"
        '
        'frmNovoLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 506)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtEstFrascos)
        Me.Controls.Add(Me.txtEstIni)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.grpFrascos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNovoLotes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Lotes"
        CType(Me.pbQrCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFrascos.ResumeLayout(False)
        Me.grpFrascos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFrascosAux, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbQrCode As PictureBox
    Friend WithEvents grpFrascos As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtClone As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLote As TextBox
    Friend WithEvents cmbMercadoria As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNOrigem As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTempo As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDias As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbFase As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtAnotacoes As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEstIni As Label
    Friend WithEvents txtEstFrascos As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtM_F As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbMeio As ComboBox
    Friend WithEvents txtNFrascos As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbRepicador As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbExplante As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbFrasco As ComboBox
    Friend WithEvents btFrascos As Button
    Friend WithEvents dgFrascos As DataGridView
    Friend WithEvents btIncluir As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbOrigem As ComboBox
    Friend WithEvents txtID As Label
    Friend WithEvents DsFrascosAux As dsFrascosAux
    Friend WithEvents epErro As ErrorProvider
    Friend WithEvents chkAtivo As CheckBox
    Friend WithEvents txtData As DateTimePicker
    Friend WithEvents VidroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NMudasDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents taAux_frascos As dsFrascosAuxTableAdapters.TA_aux_frascos
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNumOP As TextBox
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colVidro As DataGridViewTextBoxColumn
    Friend WithEvents colMudas As DataGridViewTextBoxColumn
    Friend WithEvents colOrigem As DataGridViewComboBoxColumn
    Friend WithEvents colRepicador As DataGridViewComboBoxColumn
    Friend WithEvents colMeio As DataGridViewComboBoxColumn
    Friend WithEvents colData As DataGridViewTextBoxColumn
    Friend WithEvents colTipo As DataGridViewComboBoxColumn
    Friend WithEvents colExplante As DataGridViewComboBoxColumn
    Friend WithEvents SelecaoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImpressoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents bxExclusao As DataGridViewTextBoxColumn
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents btFechar As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblMotivoBaixa As Label
    Friend WithEvents lblDataBaixa As Label
    Friend WithEvents lblBaixadoPor As Label
    Friend WithEvents lblCriado As Label
    Friend WithEvents lblFrascoID As Label
    Friend WithEvents Label22 As Label
End Class
