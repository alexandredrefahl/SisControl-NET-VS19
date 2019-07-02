<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabPedidos = New System.Windows.Forms.TabControl()
        Me.TabCliente = New System.Windows.Forms.TabPage()
        Me.TabNota = New System.Windows.Forms.TabControl()
        Me.TabDadosCliente = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btWEBCadastro = New System.Windows.Forms.Button()
        Me.bt_CEP = New System.Windows.Forms.Button()
        Me.txtPFPJ = New System.Windows.Forms.TextBox()
        Me.txtCodCli = New System.Windows.Forms.TextBox()
        Me.bsPedidos = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPedidos = New SisControl.NET.dsPedidos()
        Me.txtCidade = New System.Windows.Forms.ComboBox()
        Me.txtCodPais = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.txtCodMun = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContato = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCEP = New System.Windows.Forms.TextBox()
        Me.txtCPF_CNPJ = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdPJ = New System.Windows.Forms.RadioButton()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.rdPF = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtInscricao = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabDadosNota = New System.Windows.Forms.TabPage()
        Me.txtNatureza = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCFOP = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tabProduto = New System.Windows.Forms.TabPage()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmbPadrao = New System.Windows.Forms.ComboBox()
        Me.txtNMudas = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgItens = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PedidoidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celCodPro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celClone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celNCM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NMudas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celAtendido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celCFOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celICMS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celPIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celCOFINS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celVICMS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celVPIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celVCOFINS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPedidos_Itens = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblClone = New System.Windows.Forms.Label()
        Me.lblMercadoria = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtQtde = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtClone = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCodPro = New System.Windows.Forms.TextBox()
        Me.tabStatus = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObservacoes = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtRGAprovador = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtAutorizado = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAutoPor = New System.Windows.Forms.TextBox()
        Me.tabPagamento = New System.Windows.Forms.TabPage()
        Me.cmbFrete = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.dgDuplicatas = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celPedido_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celDescricao_Dup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celValor_Dup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LancadoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsPedidos_Duplicatas = New System.Windows.Forms.BindingSource(Me.components)
        Me.grpResPed = New System.Windows.Forms.GroupBox()
        Me.lblTotPedido = New System.Windows.Forms.Label()
        Me.lblDespesas = New System.Windows.Forms.Label()
        Me.lblImpostos = New System.Windows.Forms.Label()
        Me.lblDescontos = New System.Windows.Forms.Label()
        Me.lblFrete = New System.Windows.Forms.Label()
        Me.lblMercadorias = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbModFrete = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtvDesc = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtvSeg = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtvFrete = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDataEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtDataPedido = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbForma = New System.Windows.Forms.ComboBox()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.epError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TaPedidos_Duplicatas = New SisControl.NET.dsPedidosTableAdapters.taPedidos_Duplicatas()
        Me.TaPedido = New SisControl.NET.dsPedidosTableAdapters.taPedido()
        Me.TaPedidos_Itens1 = New SisControl.NET.dsPedidosTableAdapters.taPedidos_Itens()
        Me.tabPedidos.SuspendLayout()
        Me.TabCliente.SuspendLayout()
        Me.TabNota.SuspendLayout()
        Me.TabDadosCliente.SuspendLayout()
        CType(Me.bsPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDadosNota.SuspendLayout()
        Me.tabProduto.SuspendLayout()
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPedidos_Itens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabStatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabPagamento.SuspendLayout()
        CType(Me.dgDuplicatas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPedidos_Duplicatas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResPed.SuspendLayout()
        CType(Me.epError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabPedidos
        '
        Me.tabPedidos.Controls.Add(Me.TabCliente)
        Me.tabPedidos.Controls.Add(Me.tabProduto)
        Me.tabPedidos.Controls.Add(Me.tabStatus)
        Me.tabPedidos.Controls.Add(Me.tabPagamento)
        Me.tabPedidos.Location = New System.Drawing.Point(12, 12)
        Me.tabPedidos.Multiline = True
        Me.tabPedidos.Name = "tabPedidos"
        Me.tabPedidos.SelectedIndex = 0
        Me.tabPedidos.Size = New System.Drawing.Size(705, 513)
        Me.tabPedidos.TabIndex = 0
        '
        'TabCliente
        '
        Me.TabCliente.Controls.Add(Me.TabNota)
        Me.TabCliente.Controls.Add(Me.Button2)
        Me.TabCliente.Location = New System.Drawing.Point(4, 22)
        Me.TabCliente.Name = "TabCliente"
        Me.TabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCliente.Size = New System.Drawing.Size(697, 487)
        Me.TabCliente.TabIndex = 0
        Me.TabCliente.Text = "Cliente [F2]"
        Me.TabCliente.UseVisualStyleBackColor = True
        '
        'TabNota
        '
        Me.TabNota.Controls.Add(Me.TabDadosCliente)
        Me.TabNota.Controls.Add(Me.TabDadosNota)
        Me.TabNota.Location = New System.Drawing.Point(6, 6)
        Me.TabNota.Name = "TabNota"
        Me.TabNota.SelectedIndex = 0
        Me.TabNota.Size = New System.Drawing.Size(685, 446)
        Me.TabNota.TabIndex = 20
        '
        'TabDadosCliente
        '
        Me.TabDadosCliente.Controls.Add(Me.Button5)
        Me.TabDadosCliente.Controls.Add(Me.btWEBCadastro)
        Me.TabDadosCliente.Controls.Add(Me.bt_CEP)
        Me.TabDadosCliente.Controls.Add(Me.txtPFPJ)
        Me.TabDadosCliente.Controls.Add(Me.txtCodCli)
        Me.TabDadosCliente.Controls.Add(Me.txtCidade)
        Me.TabDadosCliente.Controls.Add(Me.txtCodPais)
        Me.TabDadosCliente.Controls.Add(Me.Label26)
        Me.TabDadosCliente.Controls.Add(Me.txtPais)
        Me.TabDadosCliente.Controls.Add(Me.txtCodMun)
        Me.TabDadosCliente.Controls.Add(Me.Label1)
        Me.TabDadosCliente.Controls.Add(Me.cmbCliente)
        Me.TabDadosCliente.Controls.Add(Me.txtEndereco)
        Me.TabDadosCliente.Controls.Add(Me.Label23)
        Me.TabDadosCliente.Controls.Add(Me.txtNumero)
        Me.TabDadosCliente.Controls.Add(Me.txtBairro)
        Me.TabDadosCliente.Controls.Add(Me.txtEstado)
        Me.TabDadosCliente.Controls.Add(Me.Label2)
        Me.TabDadosCliente.Controls.Add(Me.Label21)
        Me.TabDadosCliente.Controls.Add(Me.Label3)
        Me.TabDadosCliente.Controls.Add(Me.txtContato)
        Me.TabDadosCliente.Controls.Add(Me.Label4)
        Me.TabDadosCliente.Controls.Add(Me.txtCEP)
        Me.TabDadosCliente.Controls.Add(Me.txtCPF_CNPJ)
        Me.TabDadosCliente.Controls.Add(Me.Label5)
        Me.TabDadosCliente.Controls.Add(Me.rdPJ)
        Me.TabDadosCliente.Controls.Add(Me.txtFone)
        Me.TabDadosCliente.Controls.Add(Me.rdPF)
        Me.TabDadosCliente.Controls.Add(Me.Label6)
        Me.TabDadosCliente.Controls.Add(Me.txtFax)
        Me.TabDadosCliente.Controls.Add(Me.Label7)
        Me.TabDadosCliente.Controls.Add(Me.Label10)
        Me.TabDadosCliente.Controls.Add(Me.txtCelular)
        Me.TabDadosCliente.Controls.Add(Me.txtInscricao)
        Me.TabDadosCliente.Controls.Add(Me.Label8)
        Me.TabDadosCliente.Controls.Add(Me.Label9)
        Me.TabDadosCliente.Controls.Add(Me.txtEmail)
        Me.TabDadosCliente.Controls.Add(Me.Label11)
        Me.TabDadosCliente.Location = New System.Drawing.Point(4, 22)
        Me.TabDadosCliente.Name = "TabDadosCliente"
        Me.TabDadosCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDadosCliente.Size = New System.Drawing.Size(677, 420)
        Me.TabDadosCliente.TabIndex = 1
        Me.TabDadosCliente.Text = "Dados Cliente"
        Me.TabDadosCliente.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = Global.SisControl.NET.My.Resources.Resources.opencart_logo
        Me.Button5.Location = New System.Drawing.Point(565, 63)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 40)
        Me.Button5.TabIndex = 58
        Me.Button5.Text = "Pedidos"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btWEBCadastro
        '
        Me.btWEBCadastro.Image = Global.SisControl.NET.My.Resources.Resources.opencart_logo
        Me.btWEBCadastro.Location = New System.Drawing.Point(565, 11)
        Me.btWEBCadastro.Name = "btWEBCadastro"
        Me.btWEBCadastro.Size = New System.Drawing.Size(99, 40)
        Me.btWEBCadastro.TabIndex = 57
        Me.btWEBCadastro.Text = "Clientes"
        Me.btWEBCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btWEBCadastro.UseVisualStyleBackColor = True
        '
        'bt_CEP
        '
        Me.bt_CEP.Image = Global.SisControl.NET.My.Resources.Resources.zoom
        Me.bt_CEP.Location = New System.Drawing.Point(188, 87)
        Me.bt_CEP.Name = "bt_CEP"
        Me.bt_CEP.Size = New System.Drawing.Size(24, 24)
        Me.bt_CEP.TabIndex = 42
        Me.bt_CEP.Text = "..."
        Me.bt_CEP.UseVisualStyleBackColor = True
        '
        'txtPFPJ
        '
        Me.txtPFPJ.Location = New System.Drawing.Point(239, 210)
        Me.txtPFPJ.Name = "txtPFPJ"
        Me.txtPFPJ.Size = New System.Drawing.Size(49, 20)
        Me.txtPFPJ.TabIndex = 41
        Me.txtPFPJ.Visible = False
        '
        'txtCodCli
        '
        Me.txtCodCli.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CodCli", True))
        Me.txtCodCli.Enabled = False
        Me.txtCodCli.Location = New System.Drawing.Point(511, 11)
        Me.txtCodCli.Name = "txtCodCli"
        Me.txtCodCli.Size = New System.Drawing.Size(48, 20)
        Me.txtCodCli.TabIndex = 40
        '
        'bsPedidos
        '
        Me.bsPedidos.DataMember = "pedidos"
        Me.bsPedidos.DataSource = Me.DsPedidos
        '
        'DsPedidos
        '
        Me.DsPedidos.DataSetName = "dsPedidos"
        Me.DsPedidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCidade
        '
        Me.txtCidade.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Cidade", True))
        Me.txtCidade.DropDownHeight = 150
        Me.txtCidade.DropDownWidth = 180
        Me.txtCidade.FormattingEnabled = True
        Me.txtCidade.IntegralHeight = False
        Me.txtCidade.Location = New System.Drawing.Point(361, 63)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(92, 21)
        Me.txtCidade.TabIndex = 5
        '
        'txtCodPais
        '
        Me.txtCodPais.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CodPais", True))
        Me.txtCodPais.Location = New System.Drawing.Point(353, 90)
        Me.txtCodPais.MaxLength = 4
        Me.txtCodPais.Name = "txtCodPais"
        Me.txtCodPais.Size = New System.Drawing.Size(62, 20)
        Me.txtCodPais.TabIndex = 9
        Me.txtCodPais.Text = "1058"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(217, 93)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(32, 13)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "País:"
        '
        'txtPais
        '
        Me.txtPais.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Pais", True))
        Me.txtPais.Location = New System.Drawing.Point(255, 90)
        Me.txtPais.MaxLength = 15
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(94, 20)
        Me.txtPais.TabIndex = 8
        Me.txtPais.Text = "Brasil"
        '
        'txtCodMun
        '
        Me.txtCodMun.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CodCidade", True))
        Me.epError.SetError(Me.txtCodMun, "Código do municipio não pode estar em branco")
        Me.txtCodMun.Location = New System.Drawing.Point(459, 64)
        Me.txtCodMun.MaxLength = 7
        Me.txtCodMun.Name = "txtCodMun"
        Me.txtCodMun.Size = New System.Drawing.Size(62, 20)
        Me.txtCodMun.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente:"
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Cliente", True))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(81, 11)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(424, 21)
        Me.cmbCliente.TabIndex = 0
        '
        'txtEndereco
        '
        Me.txtEndereco.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Endereco", True))
        Me.epError.SetError(Me.txtEndereco, "Endereço não pode estar em branco")
        Me.txtEndereco.Location = New System.Drawing.Point(81, 38)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(366, 20)
        Me.txtEndereco.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(13, 67)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 13)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Bairro:"
        '
        'txtNumero
        '
        Me.txtNumero.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Num", True))
        Me.txtNumero.Location = New System.Drawing.Point(481, 38)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(40, 20)
        Me.txtNumero.TabIndex = 2
        '
        'txtBairro
        '
        Me.txtBairro.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Bairro", True))
        Me.epError.SetError(Me.txtBairro, "Bairro não pode estar em branco")
        Me.txtBairro.Location = New System.Drawing.Point(81, 64)
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(119, 20)
        Me.txtBairro.TabIndex = 3
        '
        'txtEstado
        '
        Me.txtEstado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Estado", True))
        Me.epError.SetError(Me.txtEstado, "UF não pode estar em branco")
        Me.txtEstado.Location = New System.Drawing.Point(255, 64)
        Me.txtEstado.MaxLength = 2
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(33, 20)
        Me.txtEstado.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Endereço:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 275)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 30
        Me.Label21.Text = "Contato:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(312, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cidade:"
        '
        'txtContato
        '
        Me.txtContato.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Contato", True))
        Me.txtContato.Location = New System.Drawing.Point(81, 272)
        Me.txtContato.Name = "txtContato"
        Me.txtContato.Size = New System.Drawing.Size(145, 20)
        Me.txtContato.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(225, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "UF:"
        '
        'txtCEP
        '
        Me.txtCEP.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CEP", True))
        Me.epError.SetError(Me.txtCEP, "CEP não pode estar em branco")
        Me.txtCEP.Location = New System.Drawing.Point(81, 90)
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(89, 20)
        Me.txtCEP.TabIndex = 7
        '
        'txtCPF_CNPJ
        '
        Me.txtCPF_CNPJ.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CNPJ_CPF", True))
        Me.epError.SetError(Me.txtCPF_CNPJ, "CNPJ ou CPF devem ser preenchidos sem a pontuação")
        Me.txtCPF_CNPJ.Location = New System.Drawing.Point(81, 246)
        Me.txtCPF_CNPJ.MaxLength = 18
        Me.txtCPF_CNPJ.Name = "txtCPF_CNPJ"
        Me.txtCPF_CNPJ.Size = New System.Drawing.Size(119, 20)
        Me.txtCPF_CNPJ.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "CEP:"
        '
        'rdPJ
        '
        Me.rdPJ.AutoSize = True
        Me.rdPJ.Checked = True
        Me.rdPJ.Location = New System.Drawing.Point(124, 210)
        Me.rdPJ.Name = "rdPJ"
        Me.rdPJ.Size = New System.Drawing.Size(101, 17)
        Me.rdPJ.TabIndex = 15
        Me.rdPJ.TabStop = True
        Me.rdPJ.Text = "Pessoa Jurídica"
        Me.rdPJ.UseVisualStyleBackColor = True
        '
        'txtFone
        '
        Me.txtFone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Fone", True))
        Me.epError.SetError(Me.txtFone, "Fone não pode estar em branco")
        Me.txtFone.Location = New System.Drawing.Point(81, 134)
        Me.txtFone.Name = "txtFone"
        Me.txtFone.Size = New System.Drawing.Size(89, 20)
        Me.txtFone.TabIndex = 10
        '
        'rdPF
        '
        Me.rdPF.AutoSize = True
        Me.rdPF.Location = New System.Drawing.Point(16, 210)
        Me.rdPF.Name = "rdPF"
        Me.rdPF.Size = New System.Drawing.Size(92, 17)
        Me.rdPF.TabIndex = 14
        Me.rdPF.Text = "Pessoa Física"
        Me.rdPF.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(13, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fone:"
        '
        'txtFax
        '
        Me.txtFax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Fax", True))
        Me.txtFax.Location = New System.Drawing.Point(255, 134)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(89, 20)
        Me.txtFax.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(222, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Fax:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(288, 249)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Insc. Estadual:"
        '
        'txtCelular
        '
        Me.txtCelular.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Celular", True))
        Me.txtCelular.Location = New System.Drawing.Point(429, 134)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(76, 20)
        Me.txtCelular.TabIndex = 12
        '
        'txtInscricao
        '
        Me.txtInscricao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Inscricao", True))
        Me.txtInscricao.Location = New System.Drawing.Point(371, 246)
        Me.txtInscricao.Name = "txtInscricao"
        Me.txtInscricao.Size = New System.Drawing.Size(134, 20)
        Me.txtInscricao.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(373, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Celular:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 249)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "CNPJ:"
        '
        'txtEmail
        '
        Me.txtEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "email", True))
        Me.txtEmail.Location = New System.Drawing.Point(81, 160)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(268, 20)
        Me.txtEmail.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "e-mail:"
        '
        'TabDadosNota
        '
        Me.TabDadosNota.Controls.Add(Me.txtNatureza)
        Me.TabDadosNota.Controls.Add(Me.Label29)
        Me.TabDadosNota.Controls.Add(Me.txtCFOP)
        Me.TabDadosNota.Controls.Add(Me.Label28)
        Me.TabDadosNota.Location = New System.Drawing.Point(4, 22)
        Me.TabDadosNota.Name = "TabDadosNota"
        Me.TabDadosNota.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDadosNota.Size = New System.Drawing.Size(677, 420)
        Me.TabDadosNota.TabIndex = 2
        Me.TabDadosNota.Text = "Dados NF"
        Me.TabDadosNota.UseVisualStyleBackColor = True
        '
        'txtNatureza
        '
        Me.txtNatureza.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "NaturezaOP", True))
        Me.txtNatureza.Location = New System.Drawing.Point(90, 33)
        Me.txtNatureza.MaxLength = 50
        Me.txtNatureza.Name = "txtNatureza"
        Me.txtNatureza.Size = New System.Drawing.Size(417, 20)
        Me.txtNatureza.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 36)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "Natureza:"
        '
        'txtCFOP
        '
        Me.txtCFOP.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "CFOP", True))
        Me.txtCFOP.Location = New System.Drawing.Point(90, 7)
        Me.txtCFOP.MaxLength = 4
        Me.txtCFOP.Name = "txtCFOP"
        Me.txtCFOP.Size = New System.Drawing.Size(50, 20)
        Me.txtCFOP.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(6, 10)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(38, 13)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "CFOP:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(616, 458)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Avançar >>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tabProduto
        '
        Me.tabProduto.Controls.Add(Me.Label42)
        Me.tabProduto.Controls.Add(Me.cmbPadrao)
        Me.tabProduto.Controls.Add(Me.txtNMudas)
        Me.tabProduto.Controls.Add(Me.txtTotal)
        Me.tabProduto.Controls.Add(Me.Button3)
        Me.tabProduto.Controls.Add(Me.dgItens)
        Me.tabProduto.Controls.Add(Me.lblClone)
        Me.tabProduto.Controls.Add(Me.lblMercadoria)
        Me.tabProduto.Controls.Add(Me.Button1)
        Me.tabProduto.Controls.Add(Me.Label18)
        Me.tabProduto.Controls.Add(Me.cmbTipo)
        Me.tabProduto.Controls.Add(Me.txtValor)
        Me.tabProduto.Controls.Add(Me.Label17)
        Me.tabProduto.Controls.Add(Me.txtQtde)
        Me.tabProduto.Controls.Add(Me.Label16)
        Me.tabProduto.Controls.Add(Me.Label15)
        Me.tabProduto.Controls.Add(Me.txtClone)
        Me.tabProduto.Controls.Add(Me.Label14)
        Me.tabProduto.Controls.Add(Me.txtCodPro)
        Me.tabProduto.Location = New System.Drawing.Point(4, 22)
        Me.tabProduto.Name = "tabProduto"
        Me.tabProduto.Size = New System.Drawing.Size(697, 487)
        Me.tabProduto.TabIndex = 2
        Me.tabProduto.Text = "Produtos [F3]"
        Me.tabProduto.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(307, 90)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(31, 13)
        Me.Label42.TabIndex = 21
        Me.Label42.Text = "Tipo:"
        '
        'cmbPadrao
        '
        Me.cmbPadrao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPadrao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPadrao.FormattingEnabled = True
        Me.cmbPadrao.Items.AddRange(New Object() {"In Vitro", "Pré Aclimatizada", "Aclimatizada", "Adulta"})
        Me.cmbPadrao.Location = New System.Drawing.Point(350, 85)
        Me.cmbPadrao.Name = "cmbPadrao"
        Me.cmbPadrao.Size = New System.Drawing.Size(90, 21)
        Me.cmbPadrao.TabIndex = 4
        Me.cmbPadrao.Text = "Aclimatizada"
        '
        'txtNMudas
        '
        Me.txtNMudas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNMudas.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "NMudas", True))
        Me.txtNMudas.Location = New System.Drawing.Point(424, 437)
        Me.txtNMudas.Name = "txtNMudas"
        Me.txtNMudas.Size = New System.Drawing.Size(67, 23)
        Me.txtNMudas.TabIndex = 19
        Me.txtNMudas.Text = "0"
        Me.txtNMudas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Valor", True))
        Me.txtTotal.Location = New System.Drawing.Point(539, 438)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(67, 22)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.Text = "0,00"
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(616, 458)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Avançar >>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgItens
        '
        Me.dgItens.AllowUserToAddRows = False
        Me.dgItens.AllowUserToOrderColumns = True
        Me.dgItens.AutoGenerateColumns = False
        Me.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.PedidoidDataGridViewTextBoxColumn, Me.celCodPro, Me.celClone, Me.celDescricao, Me.celNCM, Me.UnidDataGridViewTextBoxColumn, Me.NMudas, Me.celUnitario, Me.Valor, Me.celAtendido, Me.celStatus, Me.celForma, Me.celTipo, Me.celCFOP, Me.celICMS, Me.celPIS, Me.celCOFINS, Me.celVICMS, Me.celVPIS, Me.celVCOFINS})
        Me.dgItens.DataSource = Me.bsPedidos_Itens
        Me.epError.SetIconAlignment(Me.dgItens, System.Windows.Forms.ErrorIconAlignment.TopRight)
        Me.dgItens.Location = New System.Drawing.Point(29, 129)
        Me.dgItens.MultiSelect = False
        Me.dgItens.Name = "dgItens"
        Me.dgItens.RowHeadersWidth = 20
        Me.dgItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItens.Size = New System.Drawing.Size(611, 309)
        Me.dgItens.TabIndex = 7
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'PedidoidDataGridViewTextBoxColumn
        '
        Me.PedidoidDataGridViewTextBoxColumn.DataPropertyName = "Pedido_id"
        Me.PedidoidDataGridViewTextBoxColumn.HeaderText = "Pedido_id"
        Me.PedidoidDataGridViewTextBoxColumn.Name = "PedidoidDataGridViewTextBoxColumn"
        Me.PedidoidDataGridViewTextBoxColumn.Visible = False
        '
        'celCodPro
        '
        Me.celCodPro.DataPropertyName = "CodPro"
        Me.celCodPro.HeaderText = "Cód"
        Me.celCodPro.MaxInputLength = 3
        Me.celCodPro.Name = "celCodPro"
        Me.celCodPro.Width = 45
        '
        'celClone
        '
        Me.celClone.DataPropertyName = "clone"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "0000"
        DataGridViewCellStyle1.NullValue = "0"
        Me.celClone.DefaultCellStyle = DataGridViewCellStyle1
        Me.celClone.HeaderText = "Clone"
        Me.celClone.MaxInputLength = 4
        Me.celClone.Name = "celClone"
        Me.celClone.Width = 45
        '
        'celDescricao
        '
        Me.celDescricao.DataPropertyName = "Descricao"
        Me.celDescricao.HeaderText = "Descrição"
        Me.celDescricao.Name = "celDescricao"
        Me.celDescricao.Width = 250
        '
        'celNCM
        '
        Me.celNCM.DataPropertyName = "NCM"
        Me.celNCM.HeaderText = "NCM"
        Me.celNCM.Name = "celNCM"
        Me.celNCM.Visible = False
        '
        'UnidDataGridViewTextBoxColumn
        '
        Me.UnidDataGridViewTextBoxColumn.DataPropertyName = "Unid"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0,00"
        Me.UnidDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnidDataGridViewTextBoxColumn.HeaderText = "Unid."
        Me.UnidDataGridViewTextBoxColumn.MaxInputLength = 4
        Me.UnidDataGridViewTextBoxColumn.Name = "UnidDataGridViewTextBoxColumn"
        Me.UnidDataGridViewTextBoxColumn.Width = 35
        '
        'NMudas
        '
        Me.NMudas.DataPropertyName = "Quantidade"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.NMudas.DefaultCellStyle = DataGridViewCellStyle3
        Me.NMudas.HeaderText = "Qtde"
        Me.NMudas.Name = "NMudas"
        Me.NMudas.Width = 65
        '
        'celUnitario
        '
        Me.celUnitario.DataPropertyName = "Unitario"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0,00"
        Me.celUnitario.DefaultCellStyle = DataGridViewCellStyle4
        Me.celUnitario.HeaderText = "Unit"
        Me.celUnitario.Name = "celUnitario"
        Me.celUnitario.Width = 50
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Total"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0,00"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle5
        Me.Valor.HeaderText = "Total"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 65
        '
        'celAtendido
        '
        Me.celAtendido.DataPropertyName = "Atendido"
        Me.celAtendido.HeaderText = "Atendido"
        Me.celAtendido.Name = "celAtendido"
        Me.celAtendido.Visible = False
        '
        'celStatus
        '
        Me.celStatus.DataPropertyName = "Status"
        Me.celStatus.HeaderText = "Status"
        Me.celStatus.Name = "celStatus"
        Me.celStatus.Visible = False
        '
        'celForma
        '
        Me.celForma.DataPropertyName = "Forma"
        Me.celForma.HeaderText = "Forma"
        Me.celForma.Name = "celForma"
        Me.celForma.Visible = False
        '
        'celTipo
        '
        Me.celTipo.DataPropertyName = "Tipo"
        Me.celTipo.HeaderText = "Tipo"
        Me.celTipo.Name = "celTipo"
        Me.celTipo.Visible = False
        '
        'celCFOP
        '
        Me.celCFOP.DataPropertyName = "CFOP"
        Me.celCFOP.HeaderText = "CFOP"
        Me.celCFOP.Name = "celCFOP"
        Me.celCFOP.Visible = False
        '
        'celICMS
        '
        Me.celICMS.DataPropertyName = "ICMS"
        Me.celICMS.HeaderText = "ICMS"
        Me.celICMS.Name = "celICMS"
        Me.celICMS.Visible = False
        '
        'celPIS
        '
        Me.celPIS.DataPropertyName = "PIS"
        Me.celPIS.HeaderText = "PIS"
        Me.celPIS.Name = "celPIS"
        Me.celPIS.Visible = False
        '
        'celCOFINS
        '
        Me.celCOFINS.DataPropertyName = "COFINS"
        Me.celCOFINS.HeaderText = "COFINS"
        Me.celCOFINS.Name = "celCOFINS"
        Me.celCOFINS.Visible = False
        '
        'celVICMS
        '
        Me.celVICMS.DataPropertyName = "vICMS"
        Me.celVICMS.HeaderText = "vICMS"
        Me.celVICMS.Name = "celVICMS"
        Me.celVICMS.Visible = False
        '
        'celVPIS
        '
        Me.celVPIS.DataPropertyName = "vPIS"
        Me.celVPIS.HeaderText = "vPIS"
        Me.celVPIS.Name = "celVPIS"
        Me.celVPIS.Visible = False
        '
        'celVCOFINS
        '
        Me.celVCOFINS.DataPropertyName = "vCOFINS"
        Me.celVCOFINS.HeaderText = "vCOFINS"
        Me.celVCOFINS.Name = "celVCOFINS"
        Me.celVCOFINS.Visible = False
        '
        'bsPedidos_Itens
        '
        Me.bsPedidos_Itens.DataMember = "pedidos_itens"
        Me.bsPedidos_Itens.DataSource = Me.DsPedidos
        '
        'lblClone
        '
        Me.lblClone.AutoSize = True
        Me.lblClone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClone.ForeColor = System.Drawing.Color.Blue
        Me.lblClone.Location = New System.Drawing.Point(169, 58)
        Me.lblClone.Name = "lblClone"
        Me.lblClone.Size = New System.Drawing.Size(19, 15)
        Me.lblClone.TabIndex = 13
        Me.lblClone.Text = "..."
        '
        'lblMercadoria
        '
        Me.lblMercadoria.AutoSize = True
        Me.lblMercadoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercadoria.ForeColor = System.Drawing.Color.Blue
        Me.lblMercadoria.Location = New System.Drawing.Point(169, 33)
        Me.lblMercadoria.Name = "lblMercadoria"
        Me.lblMercadoria.Size = New System.Drawing.Size(19, 15)
        Me.lblMercadoria.TabIndex = 12
        Me.lblMercadoria.Text = "..."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(557, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Adicionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(170, 90)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Forma:"
        '
        'cmbTipo
        '
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"BD - Bandeja", "RN - Raiz Nua", "VT - In Vitro"})
        Me.cmbTipo.Location = New System.Drawing.Point(215, 87)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(86, 21)
        Me.cmbTipo.TabIndex = 3
        Me.cmbTipo.Text = "RN - Raiz Nua"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(488, 87)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(38, 20)
        Me.txtValor.TabIndex = 5
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(448, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Valor:"
        '
        'txtQtde
        '
        Me.txtQtde.Location = New System.Drawing.Point(114, 87)
        Me.txtQtde.Name = "txtQtde"
        Me.txtQtde.Size = New System.Drawing.Size(38, 20)
        Me.txtQtde.TabIndex = 2
        Me.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(23, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Quantidade:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(23, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Clone:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClone
        '
        Me.txtClone.Location = New System.Drawing.Point(114, 58)
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(38, 20)
        Me.txtClone.TabIndex = 1
        Me.txtClone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(23, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Cód. Mercadoria:"
        '
        'txtCodPro
        '
        Me.txtCodPro.Location = New System.Drawing.Point(114, 31)
        Me.txtCodPro.Name = "txtCodPro"
        Me.txtCodPro.Size = New System.Drawing.Size(38, 20)
        Me.txtCodPro.TabIndex = 0
        Me.txtCodPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabStatus
        '
        Me.tabStatus.Controls.Add(Me.GroupBox1)
        Me.tabStatus.Controls.Add(Me.Button4)
        Me.tabStatus.Controls.Add(Me.Label30)
        Me.tabStatus.Controls.Add(Me.cmbStatus)
        Me.tabStatus.Controls.Add(Me.Label25)
        Me.tabStatus.Controls.Add(Me.txtRGAprovador)
        Me.tabStatus.Controls.Add(Me.Label22)
        Me.tabStatus.Controls.Add(Me.dtAutorizado)
        Me.tabStatus.Controls.Add(Me.Label12)
        Me.tabStatus.Controls.Add(Me.txtAutoPor)
        Me.tabStatus.Location = New System.Drawing.Point(4, 22)
        Me.tabStatus.Name = "tabStatus"
        Me.tabStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStatus.Size = New System.Drawing.Size(697, 487)
        Me.tabStatus.TabIndex = 3
        Me.tabStatus.Text = "Status [F4]"
        Me.tabStatus.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObservacoes)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 146)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(655, 157)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Observações "
        '
        'txtObservacoes
        '
        Me.txtObservacoes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Observacoes", True))
        Me.txtObservacoes.Location = New System.Drawing.Point(12, 19)
        Me.txtObservacoes.Multiline = True
        Me.txtObservacoes.Name = "txtObservacoes"
        Me.txtObservacoes.Size = New System.Drawing.Size(631, 125)
        Me.txtObservacoes.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(616, 458)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Avançar >>"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(17, 33)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 13)
        Me.Label30.TabIndex = 50
        Me.Label30.Text = "Status do Pedido:"
        '
        'cmbStatus
        '
        Me.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"01 - Aguardando Pagamento", "02 - Processando", "03 - Despachado (4)", "07 - Cancelado (3)", "11 - Reembolsado", "14 - Expirado", "15 - Processado", "17 - Aguardando Estoque", "18 - Aguardando Definição"})
        Me.cmbStatus.Location = New System.Drawing.Point(135, 30)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(191, 21)
        Me.cmbStatus.Sorted = True
        Me.cmbStatus.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 112)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 48
        Me.Label25.Text = "Doc. Aprovador:"
        '
        'txtRGAprovador
        '
        Me.txtRGAprovador.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "RGAprovado", True))
        Me.txtRGAprovador.Location = New System.Drawing.Point(135, 109)
        Me.txtRGAprovador.Name = "txtRGAprovador"
        Me.txtRGAprovador.Size = New System.Drawing.Size(108, 20)
        Me.txtRGAprovador.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 47
        Me.Label22.Text = "Autorizado em:"
        '
        'dtAutorizado
        '
        Me.dtAutorizado.CustomFormat = "dd/MM/yyyy"
        Me.dtAutorizado.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsPedidos, "Aprovado", True))
        Me.dtAutorizado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAutorizado.Location = New System.Drawing.Point(135, 57)
        Me.dtAutorizado.Name = "dtAutorizado"
        Me.dtAutorizado.Size = New System.Drawing.Size(108, 20)
        Me.dtAutorizado.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Autorizado por:"
        '
        'txtAutoPor
        '
        Me.txtAutoPor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "AprovadoPor", True))
        Me.txtAutoPor.Location = New System.Drawing.Point(135, 83)
        Me.txtAutoPor.Name = "txtAutoPor"
        Me.txtAutoPor.Size = New System.Drawing.Size(191, 20)
        Me.txtAutoPor.TabIndex = 2
        '
        'tabPagamento
        '
        Me.tabPagamento.Controls.Add(Me.cmbFrete)
        Me.tabPagamento.Controls.Add(Me.Label27)
        Me.tabPagamento.Controls.Add(Me.Label41)
        Me.tabPagamento.Controls.Add(Me.dgDuplicatas)
        Me.tabPagamento.Controls.Add(Me.grpResPed)
        Me.tabPagamento.Controls.Add(Me.cmbModFrete)
        Me.tabPagamento.Controls.Add(Me.Label34)
        Me.tabPagamento.Controls.Add(Me.Label33)
        Me.tabPagamento.Controls.Add(Me.txtvDesc)
        Me.tabPagamento.Controls.Add(Me.Label32)
        Me.tabPagamento.Controls.Add(Me.txtvSeg)
        Me.tabPagamento.Controls.Add(Me.Label31)
        Me.tabPagamento.Controls.Add(Me.txtvFrete)
        Me.tabPagamento.Controls.Add(Me.txtVendedor)
        Me.tabPagamento.Controls.Add(Me.Label24)
        Me.tabPagamento.Controls.Add(Me.Label20)
        Me.tabPagamento.Controls.Add(Me.Label19)
        Me.tabPagamento.Controls.Add(Me.txtDataEntrega)
        Me.tabPagamento.Controls.Add(Me.txtDataPedido)
        Me.tabPagamento.Controls.Add(Me.Label13)
        Me.tabPagamento.Controls.Add(Me.cmbForma)
        Me.tabPagamento.Controls.Add(Me.btIncluir)
        Me.tabPagamento.Controls.Add(Me.btCancelar)
        Me.tabPagamento.Location = New System.Drawing.Point(4, 22)
        Me.tabPagamento.Name = "tabPagamento"
        Me.tabPagamento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagamento.Size = New System.Drawing.Size(697, 487)
        Me.tabPagamento.TabIndex = 1
        Me.tabPagamento.Text = "Pagamento [F5]"
        Me.tabPagamento.UseVisualStyleBackColor = True
        '
        'cmbFrete
        '
        Me.cmbFrete.FormattingEnabled = True
        Me.cmbFrete.Location = New System.Drawing.Point(431, 70)
        Me.cmbFrete.Name = "cmbFrete"
        Me.cmbFrete.Size = New System.Drawing.Size(230, 21)
        Me.cmbFrete.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(339, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(82, 13)
        Me.Label27.TabIndex = 66
        Me.Label27.Text = "Transportadora:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(19, 334)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(60, 13)
        Me.Label41.TabIndex = 61
        Me.Label41.Text = "Duplicatas:"
        '
        'dgDuplicatas
        '
        Me.dgDuplicatas.AllowUserToAddRows = False
        Me.dgDuplicatas.AllowUserToOrderColumns = True
        Me.dgDuplicatas.AutoGenerateColumns = False
        Me.dgDuplicatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDuplicatas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn1, Me.DocIDDataGridViewTextBoxColumn, Me.celPedido_ID, Me.celVencimento, Me.celDescricao_Dup, Me.celValor_Dup, Me.LancadoDataGridViewCheckBoxColumn})
        Me.dgDuplicatas.DataSource = Me.bsPedidos_Duplicatas
        Me.dgDuplicatas.Location = New System.Drawing.Point(22, 354)
        Me.dgDuplicatas.Name = "dgDuplicatas"
        Me.dgDuplicatas.RowHeadersWidth = 21
        Me.dgDuplicatas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDuplicatas.Size = New System.Drawing.Size(326, 112)
        Me.dgDuplicatas.TabIndex = 10
        '
        'IdDataGridViewTextBoxColumn1
        '
        Me.IdDataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn1.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn1.Name = "IdDataGridViewTextBoxColumn1"
        Me.IdDataGridViewTextBoxColumn1.Visible = False
        '
        'DocIDDataGridViewTextBoxColumn
        '
        Me.DocIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID"
        Me.DocIDDataGridViewTextBoxColumn.HeaderText = "Doc_ID"
        Me.DocIDDataGridViewTextBoxColumn.Name = "DocIDDataGridViewTextBoxColumn"
        Me.DocIDDataGridViewTextBoxColumn.Visible = False
        '
        'celPedido_ID
        '
        Me.celPedido_ID.DataPropertyName = "Pedido_id"
        Me.celPedido_ID.HeaderText = "Pedido_id"
        Me.celPedido_ID.Name = "celPedido_ID"
        Me.celPedido_ID.Visible = False
        '
        'celVencimento
        '
        Me.celVencimento.DataPropertyName = "Vencimento"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "d"
        Me.celVencimento.DefaultCellStyle = DataGridViewCellStyle6
        Me.celVencimento.HeaderText = "Vencimento"
        Me.celVencimento.Name = "celVencimento"
        Me.celVencimento.Width = 85
        '
        'celDescricao_Dup
        '
        Me.celDescricao_Dup.DataPropertyName = "Descricao"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Format = "@!"
        Me.celDescricao_Dup.DefaultCellStyle = DataGridViewCellStyle7
        Me.celDescricao_Dup.HeaderText = "Descrição"
        Me.celDescricao_Dup.Name = "celDescricao_Dup"
        Me.celDescricao_Dup.Width = 130
        '
        'celValor_Dup
        '
        Me.celValor_Dup.DataPropertyName = "Valor"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0,00"
        Me.celValor_Dup.DefaultCellStyle = DataGridViewCellStyle8
        Me.celValor_Dup.HeaderText = "Valor"
        Me.celValor_Dup.Name = "celValor_Dup"
        Me.celValor_Dup.Width = 60
        '
        'LancadoDataGridViewCheckBoxColumn
        '
        Me.LancadoDataGridViewCheckBoxColumn.DataPropertyName = "Lancado"
        Me.LancadoDataGridViewCheckBoxColumn.FalseValue = "0"
        Me.LancadoDataGridViewCheckBoxColumn.HeaderText = "Lancado"
        Me.LancadoDataGridViewCheckBoxColumn.Name = "LancadoDataGridViewCheckBoxColumn"
        Me.LancadoDataGridViewCheckBoxColumn.TrueValue = "1"
        Me.LancadoDataGridViewCheckBoxColumn.Visible = False
        '
        'bsPedidos_Duplicatas
        '
        Me.bsPedidos_Duplicatas.DataMember = "duplicatas"
        Me.bsPedidos_Duplicatas.DataSource = Me.DsPedidos
        '
        'grpResPed
        '
        Me.grpResPed.Controls.Add(Me.lblTotPedido)
        Me.grpResPed.Controls.Add(Me.lblDespesas)
        Me.grpResPed.Controls.Add(Me.lblImpostos)
        Me.grpResPed.Controls.Add(Me.lblDescontos)
        Me.grpResPed.Controls.Add(Me.lblFrete)
        Me.grpResPed.Controls.Add(Me.lblMercadorias)
        Me.grpResPed.Controls.Add(Me.Label40)
        Me.grpResPed.Controls.Add(Me.Label39)
        Me.grpResPed.Controls.Add(Me.Label38)
        Me.grpResPed.Controls.Add(Me.Label37)
        Me.grpResPed.Controls.Add(Me.Label36)
        Me.grpResPed.Controls.Add(Me.Label35)
        Me.grpResPed.Location = New System.Drawing.Point(26, 155)
        Me.grpResPed.Name = "grpResPed"
        Me.grpResPed.Size = New System.Drawing.Size(627, 132)
        Me.grpResPed.TabIndex = 8
        Me.grpResPed.TabStop = False
        Me.grpResPed.Text = " Resumo do Pedido "
        '
        'lblTotPedido
        '
        Me.lblTotPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotPedido.Location = New System.Drawing.Point(361, 104)
        Me.lblTotPedido.Name = "lblTotPedido"
        Me.lblTotPedido.Size = New System.Drawing.Size(83, 13)
        Me.lblTotPedido.TabIndex = 11
        Me.lblTotPedido.Text = "0,00"
        Me.lblTotPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDespesas
        '
        Me.lblDespesas.Location = New System.Drawing.Point(365, 79)
        Me.lblDespesas.Name = "lblDespesas"
        Me.lblDespesas.Size = New System.Drawing.Size(79, 13)
        Me.lblDespesas.TabIndex = 10
        Me.lblDespesas.Text = "0,00"
        Me.lblDespesas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpostos
        '
        Me.lblImpostos.Location = New System.Drawing.Point(365, 54)
        Me.lblImpostos.Name = "lblImpostos"
        Me.lblImpostos.Size = New System.Drawing.Size(79, 13)
        Me.lblImpostos.TabIndex = 9
        Me.lblImpostos.Text = "0,00"
        Me.lblImpostos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescontos
        '
        Me.lblDescontos.Location = New System.Drawing.Point(365, 29)
        Me.lblDescontos.Name = "lblDescontos"
        Me.lblDescontos.Size = New System.Drawing.Size(79, 13)
        Me.lblDescontos.TabIndex = 8
        Me.lblDescontos.Text = "0,00"
        Me.lblDescontos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFrete
        '
        Me.lblFrete.Location = New System.Drawing.Point(94, 54)
        Me.lblFrete.Name = "lblFrete"
        Me.lblFrete.Size = New System.Drawing.Size(79, 13)
        Me.lblFrete.TabIndex = 7
        Me.lblFrete.Text = "0,00"
        Me.lblFrete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMercadorias
        '
        Me.lblMercadorias.Location = New System.Drawing.Point(94, 29)
        Me.lblMercadorias.Name = "lblMercadorias"
        Me.lblMercadorias.Size = New System.Drawing.Size(79, 13)
        Me.lblMercadorias.TabIndex = 6
        Me.lblMercadorias.Text = "0,00"
        Me.lblMercadorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(253, 104)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 13)
        Me.Label40.TabIndex = 5
        Me.Label40.Text = "Total do Pedido"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(253, 79)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 13)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "Despesas (+)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(253, 54)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 13)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "Impostos (+)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(253, 29)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 13)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "Descontos (-)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(15, 54)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(46, 13)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "Frete (+)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(15, 29)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(65, 13)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "Mercadorias"
        '
        'cmbModFrete
        '
        Me.cmbModFrete.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsPedidos, "ModFrete", True))
        Me.cmbModFrete.FormattingEnabled = True
        Me.cmbModFrete.Items.AddRange(New Object() {"1 - Remetente", "2 - Destinatário"})
        Me.cmbModFrete.Location = New System.Drawing.Point(121, 112)
        Me.cmbModFrete.Name = "cmbModFrete"
        Me.cmbModFrete.Size = New System.Drawing.Size(84, 21)
        Me.cmbModFrete.TabIndex = 4
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(23, 115)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(92, 13)
        Me.Label34.TabIndex = 57
        Me.Label34.Text = "Modalidade Frete:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(505, 115)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(83, 13)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "Valor Desconto:"
        '
        'txtvDesc
        '
        Me.txtvDesc.Location = New System.Drawing.Point(594, 112)
        Me.txtvDesc.Name = "txtvDesc"
        Me.txtvDesc.Size = New System.Drawing.Size(51, 20)
        Me.txtvDesc.TabIndex = 7
        Me.txtvDesc.Text = "0,00"
        Me.txtvDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(354, 115)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(71, 13)
        Me.Label32.TabIndex = 54
        Me.Label32.Text = "Valor Seguro:"
        '
        'txtvSeg
        '
        Me.txtvSeg.Location = New System.Drawing.Point(431, 112)
        Me.txtvSeg.Name = "txtvSeg"
        Me.txtvSeg.Size = New System.Drawing.Size(51, 20)
        Me.txtvSeg.TabIndex = 6
        Me.txtvSeg.Text = "0,00"
        Me.txtvSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(211, 115)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 13)
        Me.Label31.TabIndex = 52
        Me.Label31.Text = "Valor Frete:"
        '
        'txtvFrete
        '
        Me.txtvFrete.Location = New System.Drawing.Point(282, 112)
        Me.txtvFrete.Name = "txtvFrete"
        Me.txtvFrete.Size = New System.Drawing.Size(51, 20)
        Me.txtvFrete.TabIndex = 5
        Me.txtvFrete.Text = "0,00"
        Me.txtvFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendedor
        '
        Me.txtVendedor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsPedidos, "Vendedor", True))
        Me.txtVendedor.Location = New System.Drawing.Point(121, 70)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(212, 20)
        Me.txtVendedor.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(23, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 50
        Me.Label24.Text = "Vendedor:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(23, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 13)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Previsão de Entrega:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(23, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Data do Pedido:"
        '
        'txtDataEntrega
        '
        Me.txtDataEntrega.CustomFormat = "dd/MM/yyyy"
        Me.txtDataEntrega.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsPedidos, "Prazo", True))
        Me.txtDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDataEntrega.Location = New System.Drawing.Point(140, 36)
        Me.txtDataEntrega.Name = "txtDataEntrega"
        Me.txtDataEntrega.Size = New System.Drawing.Size(108, 20)
        Me.txtDataEntrega.TabIndex = 1
        '
        'txtDataPedido
        '
        Me.txtDataPedido.CustomFormat = "dd/MM/yyyy"
        Me.txtDataPedido.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsPedidos, "Data", True))
        Me.txtDataPedido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDataPedido.Location = New System.Drawing.Point(140, 10)
        Me.txtDataPedido.Name = "txtDataPedido"
        Me.txtDataPedido.Size = New System.Drawing.Size(108, 20)
        Me.txtDataPedido.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(18, 308)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Forma de Pagamento:"
        '
        'cmbForma
        '
        Me.cmbForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbForma.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsPedidos, "ForPag", True))
        Me.cmbForma.FormattingEnabled = True
        Me.cmbForma.Location = New System.Drawing.Point(135, 305)
        Me.cmbForma.Name = "cmbForma"
        Me.cmbForma.Size = New System.Drawing.Size(290, 21)
        Me.cmbForma.TabIndex = 9
        '
        'btIncluir
        '
        Me.btIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIncluir.Location = New System.Drawing.Point(489, 458)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(121, 23)
        Me.btIncluir.TabIndex = 11
        Me.btIncluir.Text = "&Finalizar Pedido"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.Location = New System.Drawing.Point(616, 458)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btCancelar.TabIndex = 12
        Me.btCancelar.Text = "&Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'epError
        '
        Me.epError.ContainerControl = Me
        '
        'TaPedidos_Duplicatas
        '
        Me.TaPedidos_Duplicatas.ClearBeforeFill = True
        '
        'TaPedido
        '
        Me.TaPedido.ClearBeforeFill = True
        '
        'TaPedidos_Itens1
        '
        Me.TaPedidos_Itens1.ClearBeforeFill = True
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 537)
        Me.Controls.Add(Me.tabPedidos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digitação de Pedidos"
        Me.tabPedidos.ResumeLayout(False)
        Me.TabCliente.ResumeLayout(False)
        Me.TabNota.ResumeLayout(False)
        Me.TabDadosCliente.ResumeLayout(False)
        Me.TabDadosCliente.PerformLayout()
        CType(Me.bsPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDadosNota.ResumeLayout(False)
        Me.TabDadosNota.PerformLayout()
        Me.tabProduto.ResumeLayout(False)
        Me.tabProduto.PerformLayout()
        CType(Me.dgItens, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPedidos_Itens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabStatus.ResumeLayout(False)
        Me.tabStatus.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabPagamento.ResumeLayout(False)
        Me.tabPagamento.PerformLayout()
        CType(Me.dgDuplicatas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPedidos_Duplicatas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResPed.ResumeLayout(False)
        Me.grpResPed.PerformLayout()
        CType(Me.epError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabPedidos As System.Windows.Forms.TabControl
    Friend WithEvents TabCliente As System.Windows.Forms.TabPage
    Friend WithEvents tabPagamento As System.Windows.Forms.TabPage
    Friend WithEvents tabProduto As System.Windows.Forms.TabPage
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtEndereco As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCEP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFone As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtInscricao As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdPJ As System.Windows.Forms.RadioButton
    Friend WithEvents rdPF As System.Windows.Forms.RadioButton
    Friend WithEvents txtCPF_CNPJ As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtClone As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCodPro As System.Windows.Forms.TextBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtQtde As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblMercadoria As System.Windows.Forms.Label
    Friend WithEvents lblClone As System.Windows.Forms.Label
    Friend WithEvents dgItens As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtContato As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtBairro As System.Windows.Forms.TextBox
    Friend WithEvents TabNota As System.Windows.Forms.TabControl
    Friend WithEvents TabDadosCliente As System.Windows.Forms.TabPage
    Friend WithEvents TabDadosNota As System.Windows.Forms.TabPage
    Friend WithEvents txtNMudas As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents txtCodMun As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPais As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDataEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDataPedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbForma As System.Windows.Forms.ComboBox
    Friend WithEvents tabStatus As System.Windows.Forms.TabPage
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtRGAprovador As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtAutorizado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAutoPor As System.Windows.Forms.TextBox
    Friend WithEvents txtNatureza As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCFOP As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbModFrete As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtvDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtvSeg As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtvFrete As System.Windows.Forms.TextBox
    Friend WithEvents grpResPed As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotPedido As System.Windows.Forms.Label
    Friend WithEvents lblDespesas As System.Windows.Forms.Label
    Friend WithEvents lblImpostos As System.Windows.Forms.Label
    Friend WithEvents lblDescontos As System.Windows.Forms.Label
    Friend WithEvents lblFrete As System.Windows.Forms.Label
    Friend WithEvents lblMercadorias As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents dgDuplicatas As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cmbPadrao As System.Windows.Forms.ComboBox
    Friend WithEvents txtCidade As System.Windows.Forms.ComboBox
    Friend WithEvents taPedidos_Itens As SisControl.NET.dsPedidosTableAdapters.taPedidos_Itens
    Friend WithEvents taDuplicatas As SisControl.NET.dsPedidosTableAdapters.taPedidos_Duplicatas
    Friend WithEvents txtCodCli As System.Windows.Forms.TextBox
    Friend WithEvents txtPFPJ As System.Windows.Forms.TextBox
    Friend WithEvents DsPedidos As SisControl.NET.dsPedidos
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacoes As System.Windows.Forms.TextBox
    Friend WithEvents IdDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celPedido_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celVencimento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celDescricao_Dup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celValor_Dup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LancadoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TaPedidos_Duplicatas As SisControl.NET.dsPedidosTableAdapters.taPedidos_Duplicatas
    Friend WithEvents bsPedidos_Duplicatas As System.Windows.Forms.BindingSource
    Friend WithEvents bsPedidos_Itens As System.Windows.Forms.BindingSource
    Friend WithEvents epError As System.Windows.Forms.ErrorProvider
    Friend WithEvents bsPedidos As System.Windows.Forms.BindingSource
    Friend WithEvents TaPedido As SisControl.NET.dsPedidosTableAdapters.taPedido
    Friend WithEvents TaPedidos_Itens1 As SisControl.NET.dsPedidosTableAdapters.taPedidos_Itens
    '* PARA POSSIBILITAR A FORMATAÇÃO DO VALOR DO FRETE
    Friend WithEvents ovFrete As Binding
    Friend WithEvents ovSeguro As Binding
    Friend WithEvents ovDesconto As Binding
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PedidoidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celCodPro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celClone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celNCM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NMudas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celAtendido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celForma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celCFOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celICMS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celPIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celCOFINS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celVICMS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celVPIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents celVCOFINS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_CEP As System.Windows.Forms.Button
    Friend WithEvents btWEBCadastro As Button
    Friend WithEvents cmbFrete As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Button5 As Button
End Class
