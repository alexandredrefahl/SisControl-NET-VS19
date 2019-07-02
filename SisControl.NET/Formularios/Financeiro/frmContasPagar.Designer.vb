<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContasPagar
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
        Me.txtVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkContra = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmissao = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEntSai = New System.Windows.Forms.MaskedTextBox()
        Me.txtDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.grpContabil = New System.Windows.Forms.GroupBox()
        Me.pnlHistorico = New System.Windows.Forms.Panel()
        Me.dgHistorico = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTCreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTDebDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtbhistoricoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSContab = New SisControl.NET.DSContab()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_Debito = New System.Windows.Forms.Label()
        Me.lbl_Credito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgLancCont = New System.Windows.Forms.DataGridView()
        Me.col_CodHist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Cred = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chkPrevisao = New System.Windows.Forms.CheckBox()
        Me.chkMensal = New System.Windows.Forms.CheckBox()
        Me.txtParcela = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPessoa = New System.Windows.Forms.ComboBox()
        Me.CtbhistoricoTableAdapter = New SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter()
        Me.chkCompra = New System.Windows.Forms.CheckBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grpContabil.SuspendLayout()
        Me.pnlHistorico.SuspendLayout()
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CtbhistoricoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLancCont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtVencimento
        '
        Me.txtVencimento.Location = New System.Drawing.Point(98, 22)
        Me.txtVencimento.Mask = "99/99/99"
        Me.txtVencimento.Name = "txtVencimento"
        Me.txtVencimento.Size = New System.Drawing.Size(57, 20)
        Me.txtVencimento.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vencimento:"
        '
        'chkContra
        '
        Me.chkContra.AutoSize = True
        Me.chkContra.Location = New System.Drawing.Point(161, 24)
        Me.chkContra.Name = "chkContra"
        Me.chkContra.Size = New System.Drawing.Size(126, 17)
        Me.chkContra.TabIndex = 1
        Me.chkContra.Text = "Contra Apresentação"
        Me.chkContra.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cedente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Emissão:"
        '
        'txtEmissao
        '
        Me.txtEmissao.Location = New System.Drawing.Point(98, 101)
        Me.txtEmissao.Mask = "99/99/99"
        Me.txtEmissao.Name = "txtEmissao"
        Me.txtEmissao.Size = New System.Drawing.Size(57, 20)
        Me.txtEmissao.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Entrada:"
        '
        'txtEntSai
        '
        Me.txtEntSai.Location = New System.Drawing.Point(262, 101)
        Me.txtEntSai.Mask = "99/99/99"
        Me.txtEntSai.Name = "txtEntSai"
        Me.txtEntSai.Size = New System.Drawing.Size(57, 20)
        Me.txtEntSai.TabIndex = 4
        '
        'txtDoc
        '
        Me.txtDoc.Location = New System.Drawing.Point(98, 127)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(79, 20)
        Me.txtDoc.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Nº Documento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(209, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tipo Documento:"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Items.AddRange(New Object() {"Boleto", "Con. Transporte", "DARF - Guia", "Duplicata", "Fatura", "Folha Pagamento", "GPS - Guia", "Guia de Recolhimento", "IPTU - Carnê", "NF", "NFe", "NFs", "Ordem Compra", "Promissória", "Recibo", "Req. Interna"})
        Me.cmbTipoDoc.Location = New System.Drawing.Point(304, 126)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(197, 21)
        Me.cmbTipoDoc.Sorted = True
        Me.cmbTipoDoc.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Valor:"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(98, 153)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(79, 20)
        Me.txtValor.TabIndex = 7
        Me.txtValor.Text = "0,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpContabil
        '
        Me.grpContabil.Controls.Add(Me.pnlHistorico)
        Me.grpContabil.Controls.Add(Me.lbl_Total)
        Me.grpContabil.Controls.Add(Me.Label10)
        Me.grpContabil.Controls.Add(Me.lbl_Debito)
        Me.grpContabil.Controls.Add(Me.lbl_Credito)
        Me.grpContabil.Controls.Add(Me.Label9)
        Me.grpContabil.Controls.Add(Me.Label8)
        Me.grpContabil.Controls.Add(Me.dgLancCont)
        Me.grpContabil.Location = New System.Drawing.Point(8, 202)
        Me.grpContabil.Name = "grpContabil"
        Me.grpContabil.Size = New System.Drawing.Size(508, 255)
        Me.grpContabil.TabIndex = 12
        Me.grpContabil.TabStop = False
        Me.grpContabil.Text = " Contabilização "
        '
        'pnlHistorico
        '
        Me.pnlHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHistorico.Controls.Add(Me.dgHistorico)
        Me.pnlHistorico.Location = New System.Drawing.Point(73, 41)
        Me.pnlHistorico.Name = "pnlHistorico"
        Me.pnlHistorico.Size = New System.Drawing.Size(390, 205)
        Me.pnlHistorico.TabIndex = 16
        Me.pnlHistorico.Visible = False
        '
        'dgHistorico
        '
        Me.dgHistorico.AllowUserToAddRows = False
        Me.dgHistorico.AllowUserToDeleteRows = False
        Me.dgHistorico.AllowUserToOrderColumns = True
        Me.dgHistorico.AutoGenerateColumns = False
        Me.dgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistorico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.DescricaoDataGridViewTextBoxColumn, Me.CTCreDataGridViewTextBoxColumn, Me.CTDebDataGridViewTextBoxColumn})
        Me.dgHistorico.DataSource = Me.CtbhistoricoBindingSource
        Me.dgHistorico.Location = New System.Drawing.Point(14, 10)
        Me.dgHistorico.Name = "dgHistorico"
        Me.dgHistorico.ReadOnly = True
        Me.dgHistorico.RowHeadersWidth = 20
        Me.dgHistorico.RowTemplate.Height = 18
        Me.dgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistorico.Size = New System.Drawing.Size(363, 182)
        Me.dgHistorico.TabIndex = 0
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "000"
        Me.IdDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Cód."
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Width = 40
        '
        'DescricaoDataGridViewTextBoxColumn
        '
        Me.DescricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao"
        Me.DescricaoDataGridViewTextBoxColumn.HeaderText = "Histórico"
        Me.DescricaoDataGridViewTextBoxColumn.Name = "DescricaoDataGridViewTextBoxColumn"
        Me.DescricaoDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescricaoDataGridViewTextBoxColumn.Width = 200
        '
        'CTCreDataGridViewTextBoxColumn
        '
        Me.CTCreDataGridViewTextBoxColumn.DataPropertyName = "CTCre"
        Me.CTCreDataGridViewTextBoxColumn.HeaderText = "Créd."
        Me.CTCreDataGridViewTextBoxColumn.Name = "CTCreDataGridViewTextBoxColumn"
        Me.CTCreDataGridViewTextBoxColumn.ReadOnly = True
        Me.CTCreDataGridViewTextBoxColumn.Width = 40
        '
        'CTDebDataGridViewTextBoxColumn
        '
        Me.CTDebDataGridViewTextBoxColumn.DataPropertyName = "CTDeb"
        Me.CTDebDataGridViewTextBoxColumn.HeaderText = "Déb"
        Me.CTDebDataGridViewTextBoxColumn.Name = "CTDebDataGridViewTextBoxColumn"
        Me.CTDebDataGridViewTextBoxColumn.ReadOnly = True
        Me.CTDebDataGridViewTextBoxColumn.Width = 40
        '
        'CtbhistoricoBindingSource
        '
        Me.CtbhistoricoBindingSource.DataMember = "ctbhistorico"
        Me.CtbhistoricoBindingSource.DataSource = Me.DSContab
        '
        'DSContab
        '
        Me.DSContab.DataSetName = "DSContab"
        Me.DSContab.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbl_Total
        '
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(402, 209)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(73, 23)
        Me.lbl_Total.TabIndex = 20
        Me.lbl_Total.Text = "0,00"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(356, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Total:"
        '
        'lbl_Debito
        '
        Me.lbl_Debito.AutoSize = True
        Me.lbl_Debito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Debito.Location = New System.Drawing.Point(86, 233)
        Me.lbl_Debito.Name = "lbl_Debito"
        Me.lbl_Debito.Size = New System.Drawing.Size(16, 13)
        Me.lbl_Debito.TabIndex = 18
        Me.lbl_Debito.Text = "..."
        '
        'lbl_Credito
        '
        Me.lbl_Credito.AutoSize = True
        Me.lbl_Credito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Credito.Location = New System.Drawing.Point(86, 214)
        Me.lbl_Credito.Name = "lbl_Credito"
        Me.lbl_Credito.Size = New System.Drawing.Size(16, 13)
        Me.lbl_Credito.TabIndex = 17
        Me.lbl_Credito.Text = "..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Conta Débito:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Conta Crédito:"
        '
        'dgLancCont
        '
        Me.dgLancCont.AllowUserToOrderColumns = True
        Me.dgLancCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancCont.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_CodHist, Me.col_Historico, Me.col_Cred, Me.col_Debito, Me.col_Valor})
        Me.dgLancCont.Location = New System.Drawing.Point(7, 19)
        Me.dgLancCont.MultiSelect = False
        Me.dgLancCont.Name = "dgLancCont"
        Me.dgLancCont.RowHeadersWidth = 25
        Me.dgLancCont.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgLancCont.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancCont.Size = New System.Drawing.Size(495, 186)
        Me.dgLancCont.TabIndex = 0
        '
        'col_CodHist
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "000"
        Me.col_CodHist.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_CodHist.HeaderText = "Cód"
        Me.col_CodHist.MaxInputLength = 3
        Me.col_CodHist.Name = "col_CodHist"
        Me.col_CodHist.Width = 45
        '
        'col_Historico
        '
        Me.col_Historico.HeaderText = "Histórico"
        Me.col_Historico.MaxInputLength = 60
        Me.col_Historico.Name = "col_Historico"
        Me.col_Historico.Width = 250
        '
        'col_Cred
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "000"
        Me.col_Cred.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_Cred.HeaderText = "Créd."
        Me.col_Cred.Name = "col_Cred"
        Me.col_Cred.Width = 45
        '
        'col_Debito
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "000"
        Me.col_Debito.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_Debito.HeaderText = "Déb."
        Me.col_Debito.MaxInputLength = 3
        Me.col_Debito.Name = "col_Debito"
        Me.col_Debito.Width = 45
        '
        'col_Valor
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0,00"
        Me.col_Valor.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_Valor.HeaderText = "Valor"
        Me.col_Valor.Name = "col_Valor"
        Me.col_Valor.Width = 57
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 463)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Incluir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(441, 463)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkPrevisao
        '
        Me.chkPrevisao.AutoSize = True
        Me.chkPrevisao.Location = New System.Drawing.Point(98, 179)
        Me.chkPrevisao.Name = "chkPrevisao"
        Me.chkPrevisao.Size = New System.Drawing.Size(67, 17)
        Me.chkPrevisao.TabIndex = 9
        Me.chkPrevisao.Text = "Previsão"
        Me.chkPrevisao.UseVisualStyleBackColor = True
        '
        'chkMensal
        '
        Me.chkMensal.AutoSize = True
        Me.chkMensal.Location = New System.Drawing.Point(212, 179)
        Me.chkMensal.Name = "chkMensal"
        Me.chkMensal.Size = New System.Drawing.Size(60, 17)
        Me.chkMensal.TabIndex = 10
        Me.chkMensal.Text = "Mensal"
        Me.chkMensal.UseVisualStyleBackColor = True
        '
        'txtParcela
        '
        Me.txtParcela.Location = New System.Drawing.Point(304, 153)
        Me.txtParcela.Name = "txtParcela"
        Me.txtParcela.Size = New System.Drawing.Size(100, 20)
        Me.txtParcela.TabIndex = 8
        Me.txtParcela.Text = "Única"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(209, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Parcela:"
        '
        'txtPessoa
        '
        Me.txtPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtPessoa.FormattingEnabled = True
        Me.txtPessoa.Location = New System.Drawing.Point(98, 48)
        Me.txtPessoa.Name = "txtPessoa"
        Me.txtPessoa.Size = New System.Drawing.Size(403, 21)
        Me.txtPessoa.TabIndex = 1
        '
        'CtbhistoricoTableAdapter
        '
        Me.CtbhistoricoTableAdapter.ClearBeforeFill = True
        '
        'chkCompra
        '
        Me.chkCompra.AutoSize = True
        Me.chkCompra.Location = New System.Drawing.Point(304, 179)
        Me.chkCompra.Name = "chkCompra"
        Me.chkCompra.Size = New System.Drawing.Size(62, 17)
        Me.chkCompra.TabIndex = 11
        Me.chkCompra.Text = "Compra"
        Me.chkCompra.UseVisualStyleBackColor = True
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(98, 75)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(403, 20)
        Me.txtDescricao.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(12, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Descrição"
        '
        'frmContasPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 493)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.chkCompra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtParcela)
        Me.Controls.Add(Me.chkMensal)
        Me.Controls.Add(Me.chkPrevisao)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpContabil)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.cmbTipoDoc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEntSai)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmissao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkContra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVencimento)
        Me.Controls.Add(Me.txtPessoa)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContasPagar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento de Contas a Pagar"
        Me.grpContabil.ResumeLayout(False)
        Me.grpContabil.PerformLayout()
        Me.pnlHistorico.ResumeLayout(False)
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CtbhistoricoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLancCont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVencimento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkContra As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEntSai As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents grpContabil As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkPrevisao As System.Windows.Forms.CheckBox
    Friend WithEvents chkMensal As System.Windows.Forms.CheckBox
    Friend WithEvents txtParcela As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents pnlHistorico As System.Windows.Forms.Panel
    Friend WithEvents dgHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents DSContab As SisControl.NET.DSContab
    Friend WithEvents CtbhistoricoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CtbhistoricoTableAdapter As SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTDebDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgLancCont As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Debito As System.Windows.Forms.Label
    Friend WithEvents lbl_Credito As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkCompra As System.Windows.Forms.CheckBox
    Friend WithEvents col_CodHist As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Cred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
