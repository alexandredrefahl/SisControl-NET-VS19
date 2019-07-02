<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotes
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
        Me.components = New System.ComponentModel.Container()
        Me.tabLotes = New System.Windows.Forms.TabControl()
        Me.tbLote = New System.Windows.Forms.TabPage()
        Me.lstRepicador = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtAnotacoes = New System.Windows.Forms.TextBox()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbExplante = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbFrasco = New System.Windows.Forms.ComboBox()
        Me.txtEstFrascos = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEstoque = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEstIni = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMeio = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFase = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTempo = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtM_F = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNFrascos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNOrigem = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOrigem = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.cmbMercadoria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.tbFrascos = New System.Windows.Forms.TabPage()
        Me.lblEtiquetas = New System.Windows.Forms.Label()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btImpEtiquetas = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grpInclusao = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btIncluiFrascos = New System.Windows.Forms.Button()
        Me.txtFrascosQuebra = New System.Windows.Forms.TextBox()
        Me.txtFrascosM_F = New System.Windows.Forms.TextBox()
        Me.txtFrascosTOTAL = New System.Windows.Forms.TextBox()
        Me.txtFrascoINI = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblFrascoINI = New System.Windows.Forms.Label()
        Me.opFrascos2 = New System.Windows.Forms.RadioButton()
        Me.opFrascos1 = New System.Windows.Forms.RadioButton()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VidroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NMudasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpressoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SelecaoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsFrascos = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFrascos = New SisControl.NET.dsFrascos()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.taFrascos = New SisControl.NET.dsFrascosTableAdapters.aux_frascosTableAdapter()
        Me.epErro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabLotes.SuspendLayout()
        Me.tbLote.SuspendLayout()
        Me.tbFrascos.SuspendLayout()
        Me.grpInclusao.SuspendLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabLotes
        '
        Me.tabLotes.Controls.Add(Me.tbLote)
        Me.tabLotes.Controls.Add(Me.tbFrascos)
        Me.tabLotes.Location = New System.Drawing.Point(6, 4)
        Me.tabLotes.Name = "tabLotes"
        Me.tabLotes.SelectedIndex = 0
        Me.tabLotes.Size = New System.Drawing.Size(522, 517)
        Me.tabLotes.TabIndex = 0
        '
        'tbLote
        '
        Me.tbLote.Controls.Add(Me.lstRepicador)
        Me.tbLote.Controls.Add(Me.Button1)
        Me.tbLote.Controls.Add(Me.btNovo)
        Me.tbLote.Controls.Add(Me.chkAtivo)
        Me.tbLote.Controls.Add(Me.Label20)
        Me.tbLote.Controls.Add(Me.txtAnotacoes)
        Me.tbLote.Controls.Add(Me.txtDias)
        Me.tbLote.Controls.Add(Me.Label19)
        Me.tbLote.Controls.Add(Me.Label18)
        Me.tbLote.Controls.Add(Me.cmbExplante)
        Me.tbLote.Controls.Add(Me.Label17)
        Me.tbLote.Controls.Add(Me.cmbFrasco)
        Me.tbLote.Controls.Add(Me.txtEstFrascos)
        Me.tbLote.Controls.Add(Me.Label14)
        Me.tbLote.Controls.Add(Me.txtEstoque)
        Me.tbLote.Controls.Add(Me.Label15)
        Me.tbLote.Controls.Add(Me.txtEstIni)
        Me.tbLote.Controls.Add(Me.Label16)
        Me.tbLote.Controls.Add(Me.Label13)
        Me.tbLote.Controls.Add(Me.txtData)
        Me.tbLote.Controls.Add(Me.Label12)
        Me.tbLote.Controls.Add(Me.cmbMeio)
        Me.tbLote.Controls.Add(Me.Label11)
        Me.tbLote.Controls.Add(Me.cmbFase)
        Me.tbLote.Controls.Add(Me.Label10)
        Me.tbLote.Controls.Add(Me.txtTempo)
        Me.tbLote.Controls.Add(Me.Label9)
        Me.tbLote.Controls.Add(Me.txtM_F)
        Me.tbLote.Controls.Add(Me.Label8)
        Me.tbLote.Controls.Add(Me.txtNFrascos)
        Me.tbLote.Controls.Add(Me.Label7)
        Me.tbLote.Controls.Add(Me.txtNOrigem)
        Me.tbLote.Controls.Add(Me.Label6)
        Me.tbLote.Controls.Add(Me.Label5)
        Me.tbLote.Controls.Add(Me.cmbOrigem)
        Me.tbLote.Controls.Add(Me.Label4)
        Me.tbLote.Controls.Add(Me.txtClone)
        Me.tbLote.Controls.Add(Me.Label3)
        Me.tbLote.Controls.Add(Me.txtLote)
        Me.tbLote.Controls.Add(Me.cmbMercadoria)
        Me.tbLote.Controls.Add(Me.Label2)
        Me.tbLote.Controls.Add(Me.Label1)
        Me.tbLote.Controls.Add(Me.txtCodigo)
        Me.tbLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLote.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbLote.Location = New System.Drawing.Point(4, 22)
        Me.tbLote.Name = "tbLote"
        Me.tbLote.Padding = New System.Windows.Forms.Padding(3)
        Me.tbLote.Size = New System.Drawing.Size(514, 491)
        Me.tbLote.TabIndex = 0
        Me.tbLote.Text = "Dados do Lote"
        Me.tbLote.UseVisualStyleBackColor = True
        '
        'lstRepicador
        '
        Me.lstRepicador.FormattingEnabled = True
        Me.lstRepicador.Location = New System.Drawing.Point(289, 115)
        Me.lstRepicador.Name = "lstRepicador"
        Me.lstRepicador.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstRepicador.Size = New System.Drawing.Size(219, 95)
        Me.lstRepicador.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(414, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "&Ficha Atual"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(414, 11)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(94, 23)
        Me.btNovo.TabIndex = 21
        Me.btNovo.Text = "&Novo"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.Location = New System.Drawing.Point(16, 468)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 17)
        Me.chkAtivo.TabIndex = 40
        Me.chkAtivo.TabStop = False
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 431)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Anotações:"
        '
        'txtAnotacoes
        '
        Me.txtAnotacoes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnotacoes.Location = New System.Drawing.Point(134, 428)
        Me.txtAnotacoes.Multiline = True
        Me.txtAnotacoes.Name = "txtAnotacoes"
        Me.txtAnotacoes.Size = New System.Drawing.Size(374, 57)
        Me.txtAnotacoes.TabIndex = 19
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(134, 405)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(35, 20)
        Me.txtDias.TabIndex = 18
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(13, 408)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 13)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "Dias para Repicagem:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(13, 384)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Explante:"
        '
        'cmbExplante
        '
        Me.cmbExplante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbExplante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbExplante.FormattingEnabled = True
        Me.cmbExplante.Items.AddRange(New Object() {"Calos", "Embrião", "Folha", "Fragmento Rizoma", "Gema Apical", "Gema Lateral", "Meristema", "Plântula", "Segmento Nodal", "Sementes", "Tufos"})
        Me.cmbExplante.Location = New System.Drawing.Point(134, 381)
        Me.cmbExplante.Name = "cmbExplante"
        Me.cmbExplante.Size = New System.Drawing.Size(119, 21)
        Me.cmbExplante.Sorted = True
        Me.cmbExplante.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(13, 360)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Tipo do Frasco:"
        '
        'cmbFrasco
        '
        Me.cmbFrasco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFrasco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFrasco.FormattingEnabled = True
        Me.cmbFrasco.Items.AddRange(New Object() {"Frasco de Vidro", "Tubo de Ensaio", "Erlenmeyer", "Pote plástico 500g", "Pote plástico 250g", "Biorreator", "Especial"})
        Me.cmbFrasco.Location = New System.Drawing.Point(134, 357)
        Me.cmbFrasco.Name = "cmbFrasco"
        Me.cmbFrasco.Size = New System.Drawing.Size(119, 21)
        Me.cmbFrasco.TabIndex = 16
        '
        'txtEstFrascos
        '
        Me.txtEstFrascos.Location = New System.Drawing.Point(134, 334)
        Me.txtEstFrascos.Name = "txtEstFrascos"
        Me.txtEstFrascos.Size = New System.Drawing.Size(35, 20)
        Me.txtEstFrascos.TabIndex = 15
        Me.txtEstFrascos.Text = "0"
        Me.txtEstFrascos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(13, 337)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Estoque em Frascos:"
        '
        'txtEstoque
        '
        Me.txtEstoque.Location = New System.Drawing.Point(134, 311)
        Me.txtEstoque.Name = "txtEstoque"
        Me.txtEstoque.Size = New System.Drawing.Size(35, 20)
        Me.txtEstoque.TabIndex = 14
        Me.txtEstoque.Text = "0"
        Me.txtEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(13, 314)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Estoque:"
        '
        'txtEstIni
        '
        Me.txtEstIni.Location = New System.Drawing.Point(134, 288)
        Me.txtEstIni.Name = "txtEstIni"
        Me.txtEstIni.Size = New System.Drawing.Size(35, 20)
        Me.txtEstIni.TabIndex = 13
        Me.txtEstIni.Text = "0"
        Me.txtEstIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(13, 291)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Estoque Inicial:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(13, 268)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Data:"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(134, 265)
        Me.txtData.Mask = "00/00/00"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(67, 20)
        Me.txtData.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(13, 244)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Meio:"
        '
        'cmbMeio
        '
        Me.cmbMeio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMeio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMeio.FormattingEnabled = True
        Me.cmbMeio.Location = New System.Drawing.Point(134, 241)
        Me.cmbMeio.Name = "cmbMeio"
        Me.cmbMeio.Size = New System.Drawing.Size(120, 21)
        Me.cmbMeio.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(13, 220)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Fase:"
        '
        'cmbFase
        '
        Me.cmbFase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFase.FormattingEnabled = True
        Me.cmbFase.Location = New System.Drawing.Point(134, 217)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(120, 21)
        Me.cmbFase.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(286, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Repicadores:"
        '
        'txtTempo
        '
        Me.txtTempo.Location = New System.Drawing.Point(134, 194)
        Me.txtTempo.Mask = "00:00"
        Me.txtTempo.Name = "txtTempo"
        Me.txtTempo.Size = New System.Drawing.Size(35, 20)
        Me.txtTempo.TabIndex = 8
        Me.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTempo.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Tempo:"
        '
        'txtM_F
        '
        Me.txtM_F.Location = New System.Drawing.Point(134, 171)
        Me.txtM_F.Name = "txtM_F"
        Me.txtM_F.Size = New System.Drawing.Size(35, 20)
        Me.txtM_F.TabIndex = 7
        Me.txtM_F.Text = "0"
        Me.txtM_F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Mudas/Frasco:"
        '
        'txtNFrascos
        '
        Me.txtNFrascos.Location = New System.Drawing.Point(134, 148)
        Me.txtNFrascos.Name = "txtNFrascos"
        Me.txtNFrascos.Size = New System.Drawing.Size(35, 20)
        Me.txtNFrascos.TabIndex = 6
        Me.txtNFrascos.Text = "0"
        Me.txtNFrascos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Nº de Frascos:"
        '
        'txtNOrigem
        '
        Me.txtNOrigem.Location = New System.Drawing.Point(134, 125)
        Me.txtNOrigem.Name = "txtNOrigem"
        Me.txtNOrigem.Size = New System.Drawing.Size(35, 20)
        Me.txtNOrigem.TabIndex = 5
        Me.txtNOrigem.Text = "0"
        Me.txtNOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Nº Frascos de Orígem:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Lote de Orígem:"
        '
        'cmbOrigem
        '
        Me.cmbOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrigem.DropDownHeight = 100
        Me.cmbOrigem.FormattingEnabled = True
        Me.cmbOrigem.IntegralHeight = False
        Me.cmbOrigem.Location = New System.Drawing.Point(134, 101)
        Me.cmbOrigem.Name = "cmbOrigem"
        Me.cmbOrigem.Size = New System.Drawing.Size(121, 21)
        Me.cmbOrigem.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Clone:"
        '
        'txtClone
        '
        Me.txtClone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClone.Location = New System.Drawing.Point(134, 78)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(59, 20)
        Me.txtClone.TabIndex = 3
        Me.txtClone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Lote:"
        '
        'txtLote
        '
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLote.Location = New System.Drawing.Point(134, 55)
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
        Me.cmbMercadoria.Location = New System.Drawing.Point(134, 30)
        Me.cmbMercadoria.Name = "cmbMercadoria"
        Me.cmbMercadoria.Size = New System.Drawing.Size(213, 21)
        Me.cmbMercadoria.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mercadoria:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código do Lote:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigo.Location = New System.Drawing.Point(134, 6)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(119, 21)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbFrascos
        '
        Me.tbFrascos.AutoScroll = True
        Me.tbFrascos.Controls.Add(Me.lblEtiquetas)
        Me.tbFrascos.Controls.Add(Me.btSalvar)
        Me.tbFrascos.Controls.Add(Me.Button4)
        Me.tbFrascos.Controls.Add(Me.btImpEtiquetas)
        Me.tbFrascos.Controls.Add(Me.Button2)
        Me.tbFrascos.Controls.Add(Me.grpInclusao)
        Me.tbFrascos.Controls.Add(Me.dgFrascos)
        Me.tbFrascos.Controls.Add(Me.Label21)
        Me.tbFrascos.Location = New System.Drawing.Point(4, 22)
        Me.tbFrascos.Name = "tbFrascos"
        Me.tbFrascos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFrascos.Size = New System.Drawing.Size(514, 491)
        Me.tbFrascos.TabIndex = 1
        Me.tbFrascos.Text = "Dados dos Frascos"
        Me.tbFrascos.UseVisualStyleBackColor = True
        '
        'lblEtiquetas
        '
        Me.lblEtiquetas.AutoSize = True
        Me.lblEtiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEtiquetas.Location = New System.Drawing.Point(191, 457)
        Me.lblEtiquetas.Name = "lblEtiquetas"
        Me.lblEtiquetas.Size = New System.Drawing.Size(15, 15)
        Me.lblEtiquetas.TabIndex = 8
        Me.lblEtiquetas.Text = "  "
        '
        'btSalvar
        '
        Me.btSalvar.Enabled = False
        Me.btSalvar.Location = New System.Drawing.Point(188, 121)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(104, 23)
        Me.btSalvar.TabIndex = 7
        Me.btSalvar.Text = "Salvar Lista"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(188, 92)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Alterar Estoque"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btImpEtiquetas
        '
        Me.btImpEtiquetas.Location = New System.Drawing.Point(188, 63)
        Me.btImpEtiquetas.Name = "btImpEtiquetas"
        Me.btImpEtiquetas.Size = New System.Drawing.Size(104, 23)
        Me.btImpEtiquetas.TabIndex = 4
        Me.btImpEtiquetas.Text = "Imprimir Etiquetas"
        Me.btImpEtiquetas.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(188, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Incluir Frascos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'grpInclusao
        '
        Me.grpInclusao.Controls.Add(Me.Button6)
        Me.grpInclusao.Controls.Add(Me.btIncluiFrascos)
        Me.grpInclusao.Controls.Add(Me.txtFrascosQuebra)
        Me.grpInclusao.Controls.Add(Me.txtFrascosM_F)
        Me.grpInclusao.Controls.Add(Me.txtFrascosTOTAL)
        Me.grpInclusao.Controls.Add(Me.txtFrascoINI)
        Me.grpInclusao.Controls.Add(Me.Label25)
        Me.grpInclusao.Controls.Add(Me.Label24)
        Me.grpInclusao.Controls.Add(Me.Label23)
        Me.grpInclusao.Controls.Add(Me.lblFrascoINI)
        Me.grpInclusao.Controls.Add(Me.opFrascos2)
        Me.grpInclusao.Controls.Add(Me.opFrascos1)
        Me.grpInclusao.Location = New System.Drawing.Point(308, 35)
        Me.grpInclusao.Name = "grpInclusao"
        Me.grpInclusao.Size = New System.Drawing.Size(190, 205)
        Me.grpInclusao.TabIndex = 2
        Me.grpInclusao.TabStop = False
        Me.grpInclusao.Text = " Inclusão de Frascos "
        Me.grpInclusao.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(103, 164)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Cancelar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btIncluiFrascos
        '
        Me.btIncluiFrascos.Location = New System.Drawing.Point(15, 164)
        Me.btIncluiFrascos.Name = "btIncluiFrascos"
        Me.btIncluiFrascos.Size = New System.Drawing.Size(75, 23)
        Me.btIncluiFrascos.TabIndex = 10
        Me.btIncluiFrascos.Text = "Incluir"
        Me.btIncluiFrascos.UseVisualStyleBackColor = True
        '
        'txtFrascosQuebra
        '
        Me.txtFrascosQuebra.Location = New System.Drawing.Point(139, 132)
        Me.txtFrascosQuebra.Name = "txtFrascosQuebra"
        Me.txtFrascosQuebra.Size = New System.Drawing.Size(39, 20)
        Me.txtFrascosQuebra.TabIndex = 9
        Me.txtFrascosQuebra.Text = "0"
        Me.txtFrascosQuebra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFrascosM_F
        '
        Me.txtFrascosM_F.Location = New System.Drawing.Point(139, 106)
        Me.txtFrascosM_F.Name = "txtFrascosM_F"
        Me.txtFrascosM_F.Size = New System.Drawing.Size(39, 20)
        Me.txtFrascosM_F.TabIndex = 8
        Me.txtFrascosM_F.Text = "0"
        Me.txtFrascosM_F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFrascosTOTAL
        '
        Me.txtFrascosTOTAL.Location = New System.Drawing.Point(139, 80)
        Me.txtFrascosTOTAL.Name = "txtFrascosTOTAL"
        Me.txtFrascosTOTAL.Size = New System.Drawing.Size(39, 20)
        Me.txtFrascosTOTAL.TabIndex = 7
        Me.txtFrascosTOTAL.Text = "0"
        Me.txtFrascosTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFrascoINI
        '
        Me.txtFrascoINI.Location = New System.Drawing.Point(139, 54)
        Me.txtFrascoINI.Name = "txtFrascoINI"
        Me.txtFrascoINI.Size = New System.Drawing.Size(39, 20)
        Me.txtFrascoINI.TabIndex = 6
        Me.txtFrascoINI.Text = "0"
        Me.txtFrascoINI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(13, 135)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Mudas no frasco Quebra"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(13, 109)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Mudas/Frasco"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(13, 83)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 13)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Nº TOTAL de Frascos"
        '
        'lblFrascoINI
        '
        Me.lblFrascoINI.AutoSize = True
        Me.lblFrascoINI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFrascoINI.Location = New System.Drawing.Point(13, 57)
        Me.lblFrascoINI.Name = "lblFrascoINI"
        Me.lblFrascoINI.Size = New System.Drawing.Size(69, 13)
        Me.lblFrascoINI.TabIndex = 2
        Me.lblFrascoINI.Text = "Frasco Inicial"
        '
        'opFrascos2
        '
        Me.opFrascos2.AutoSize = True
        Me.opFrascos2.Location = New System.Drawing.Point(66, 19)
        Me.opFrascos2.Name = "opFrascos2"
        Me.opFrascos2.Size = New System.Drawing.Size(53, 17)
        Me.opFrascos2.TabIndex = 1
        Me.opFrascos2.Text = "Único"
        Me.opFrascos2.UseVisualStyleBackColor = True
        '
        'opFrascos1
        '
        Me.opFrascos1.AutoSize = True
        Me.opFrascos1.Checked = True
        Me.opFrascos1.Location = New System.Drawing.Point(6, 19)
        Me.opFrascos1.Name = "opFrascos1"
        Me.opFrascos1.Size = New System.Drawing.Size(54, 17)
        Me.opFrascos1.TabIndex = 0
        Me.opFrascos1.TabStop = True
        Me.opFrascos1.Text = "Varios"
        Me.opFrascos1.UseVisualStyleBackColor = True
        '
        'dgFrascos
        '
        Me.dgFrascos.AutoGenerateColumns = False
        Me.dgFrascos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgFrascos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgFrascos.ColumnHeadersHeight = 25
        Me.dgFrascos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.LoteDataGridViewTextBoxColumn, Me.VidroDataGridViewTextBoxColumn, Me.NMudasDataGridViewTextBoxColumn, Me.ImpressoDataGridViewCheckBoxColumn, Me.SelecaoDataGridViewCheckBoxColumn})
        Me.dgFrascos.DataSource = Me.bsFrascos
        Me.dgFrascos.Location = New System.Drawing.Point(17, 36)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.RowHeadersWidth = 21
        Me.dgFrascos.Size = New System.Drawing.Size(165, 437)
        Me.dgFrascos.TabIndex = 6
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        Me.IdDataGridViewTextBoxColumn.Width = 40
        '
        'LoteDataGridViewTextBoxColumn
        '
        Me.LoteDataGridViewTextBoxColumn.DataPropertyName = "Lote"
        Me.LoteDataGridViewTextBoxColumn.HeaderText = "Lote"
        Me.LoteDataGridViewTextBoxColumn.Name = "LoteDataGridViewTextBoxColumn"
        Me.LoteDataGridViewTextBoxColumn.Visible = False
        Me.LoteDataGridViewTextBoxColumn.Width = 53
        '
        'VidroDataGridViewTextBoxColumn
        '
        Me.VidroDataGridViewTextBoxColumn.DataPropertyName = "Vidro"
        Me.VidroDataGridViewTextBoxColumn.FillWeight = 40.0!
        Me.VidroDataGridViewTextBoxColumn.HeaderText = "Vidro"
        Me.VidroDataGridViewTextBoxColumn.Name = "VidroDataGridViewTextBoxColumn"
        Me.VidroDataGridViewTextBoxColumn.Width = 56
        '
        'NMudasDataGridViewTextBoxColumn
        '
        Me.NMudasDataGridViewTextBoxColumn.DataPropertyName = "NMudas"
        Me.NMudasDataGridViewTextBoxColumn.FillWeight = 30.0!
        Me.NMudasDataGridViewTextBoxColumn.HeaderText = "Nº Mudas"
        Me.NMudasDataGridViewTextBoxColumn.Name = "NMudasDataGridViewTextBoxColumn"
        Me.NMudasDataGridViewTextBoxColumn.Width = 79
        '
        'ImpressoDataGridViewCheckBoxColumn
        '
        Me.ImpressoDataGridViewCheckBoxColumn.DataPropertyName = "Impresso"
        Me.ImpressoDataGridViewCheckBoxColumn.FalseValue = "0"
        Me.ImpressoDataGridViewCheckBoxColumn.HeaderText = "Impresso"
        Me.ImpressoDataGridViewCheckBoxColumn.IndeterminateValue = "-1"
        Me.ImpressoDataGridViewCheckBoxColumn.Name = "ImpressoDataGridViewCheckBoxColumn"
        Me.ImpressoDataGridViewCheckBoxColumn.TrueValue = "1"
        Me.ImpressoDataGridViewCheckBoxColumn.Visible = False
        Me.ImpressoDataGridViewCheckBoxColumn.Width = 55
        '
        'SelecaoDataGridViewCheckBoxColumn
        '
        Me.SelecaoDataGridViewCheckBoxColumn.DataPropertyName = "Selecao"
        Me.SelecaoDataGridViewCheckBoxColumn.FalseValue = "0"
        Me.SelecaoDataGridViewCheckBoxColumn.HeaderText = "Selecao"
        Me.SelecaoDataGridViewCheckBoxColumn.IndeterminateValue = "-1"
        Me.SelecaoDataGridViewCheckBoxColumn.Name = "SelecaoDataGridViewCheckBoxColumn"
        Me.SelecaoDataGridViewCheckBoxColumn.TrueValue = "1"
        Me.SelecaoDataGridViewCheckBoxColumn.Visible = False
        Me.SelecaoDataGridViewCheckBoxColumn.Width = 52
        '
        'bsFrascos
        '
        Me.bsFrascos.AllowNew = False
        Me.bsFrascos.DataMember = "aux_frascos"
        Me.bsFrascos.DataSource = Me.DsFrascos
        Me.bsFrascos.Filter = "lote=2422"
        Me.bsFrascos.Sort = "vidro"
        '
        'DsFrascos
        '
        Me.DsFrascos.DataSetName = "Frascos"
        Me.DsFrascos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Frascos do Lote"
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(434, 523)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(94, 23)
        Me.btFechar.TabIndex = 23
        Me.btFechar.Text = "&Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(334, 523)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(94, 23)
        Me.btIncluir.TabIndex = 20
        Me.btIncluir.Text = "&Incluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'taFrascos
        '
        Me.taFrascos.ClearBeforeFill = True
        '
        'epErro
        '
        Me.epErro.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epErro.ContainerControl = Me
        '
        'frmLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 548)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.tabLotes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Lotes"
        Me.tabLotes.ResumeLayout(False)
        Me.tbLote.ResumeLayout(False)
        Me.tbLote.PerformLayout()
        Me.tbFrascos.ResumeLayout(False)
        Me.tbFrascos.PerformLayout()
        Me.grpInclusao.ResumeLayout(False)
        Me.grpInclusao.PerformLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabLotes As System.Windows.Forms.TabControl
    Friend WithEvents tbLote As System.Windows.Forms.TabPage
    Friend WithEvents tbFrascos As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtClone As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents cmbMercadoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTempo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtM_F As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNFrascos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNOrigem As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbMeio As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFase As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEstFrascos As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEstoque As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEstIni As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbFrasco As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbExplante As System.Windows.Forms.ComboBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAnotacoes As System.Windows.Forms.TextBox
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lstRepicador As System.Windows.Forms.ListBox
    Friend WithEvents grpInclusao As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btImpEtiquetas As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents opFrascos2 As System.Windows.Forms.RadioButton
    Friend WithEvents opFrascos1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblFrascoINI As System.Windows.Forms.Label
    Friend WithEvents txtFrascosQuebra As System.Windows.Forms.TextBox
    Friend WithEvents txtFrascosM_F As System.Windows.Forms.TextBox
    Friend WithEvents txtFrascosTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFrascoINI As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btIncluiFrascos As System.Windows.Forms.Button
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents bsFrascos As System.Windows.Forms.BindingSource
    Friend WithEvents DsFrascos As SisControl.NET.dsFrascos
    Friend WithEvents taFrascos As SisControl.NET.dsFrascosTableAdapters.aux_frascosTableAdapter
    Friend WithEvents lblEtiquetas As System.Windows.Forms.Label
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VidroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NMudasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImpressoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SelecaoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents epErro As System.Windows.Forms.ErrorProvider
End Class
