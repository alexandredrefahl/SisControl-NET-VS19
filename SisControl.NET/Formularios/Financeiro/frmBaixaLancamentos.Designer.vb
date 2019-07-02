<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaixaLancamentos
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
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.grpPago = New System.Windows.Forms.GroupBox()
        Me.rdTodos = New System.Windows.Forms.RadioButton()
        Me.rdAberto = New System.Windows.Forms.RadioButton()
        Me.rdPago = New System.Windows.Forms.RadioButton()
        Me.btLimpar = New System.Windows.Forms.Button()
        Me.btFiltro = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPagFIM = New System.Windows.Forms.MaskedTextBox()
        Me.txtPagINI = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbForma = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPessoa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVencFIM = New System.Windows.Forms.MaskedTextBox()
        Me.txtVencINI = New System.Windows.Forms.MaskedTextBox()
        Me.rdPagar = New System.Windows.Forms.RadioButton()
        Me.rdReceber = New System.Windows.Forms.RadioButton()
        Me.grpLancamentos = New System.Windows.Forms.GroupBox()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.btAlterar = New System.Windows.Forms.Button()
        Me.btBaixa = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblNLancamentos = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgLancamentos = New System.Windows.Forms.DataGridView()
        Me.BSPagarreceber = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSContab = New SisControl.NET.DSContab()
        Me.grpLancamento = New System.Windows.Forms.GroupBox()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.btConfirma = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.altValor = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.altPagamento = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.altForma = New System.Windows.Forms.ComboBox()
        Me.txtNInterno = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TAPagarreceber = New SisControl.NET.DSContabTableAdapters.pagarreceberTableAdapter()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApresentacaoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Pessoa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NossoNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDocDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParcelaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrevisaoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MensalDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoPRDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpParametros.SuspendLayout()
        Me.grpPago.SuspendLayout()
        Me.grpLancamentos.SuspendLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BSPagarreceber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLancamento.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.grpPago)
        Me.grpParametros.Controls.Add(Me.btLimpar)
        Me.grpParametros.Controls.Add(Me.btFiltro)
        Me.grpParametros.Controls.Add(Me.Label9)
        Me.grpParametros.Controls.Add(Me.txtDoc)
        Me.grpParametros.Controls.Add(Me.Label5)
        Me.grpParametros.Controls.Add(Me.Label6)
        Me.grpParametros.Controls.Add(Me.txtPagFIM)
        Me.grpParametros.Controls.Add(Me.txtPagINI)
        Me.grpParametros.Controls.Add(Me.Label4)
        Me.grpParametros.Controls.Add(Me.cmbForma)
        Me.grpParametros.Controls.Add(Me.Label3)
        Me.grpParametros.Controls.Add(Me.cmbPessoa)
        Me.grpParametros.Controls.Add(Me.Label2)
        Me.grpParametros.Controls.Add(Me.Label1)
        Me.grpParametros.Controls.Add(Me.txtVencFIM)
        Me.grpParametros.Controls.Add(Me.txtVencINI)
        Me.grpParametros.Controls.Add(Me.rdPagar)
        Me.grpParametros.Controls.Add(Me.rdReceber)
        Me.grpParametros.Location = New System.Drawing.Point(14, 10)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(915, 106)
        Me.grpParametros.TabIndex = 0
        Me.grpParametros.TabStop = False
        Me.grpParametros.Text = " Parâmetros "
        '
        'grpPago
        '
        Me.grpPago.Controls.Add(Me.rdTodos)
        Me.grpPago.Controls.Add(Me.rdAberto)
        Me.grpPago.Controls.Add(Me.rdPago)
        Me.grpPago.Location = New System.Drawing.Point(706, 68)
        Me.grpPago.Name = "grpPago"
        Me.grpPago.Size = New System.Drawing.Size(203, 31)
        Me.grpPago.TabIndex = 28
        Me.grpPago.TabStop = False
        '
        'rdTodos
        '
        Me.rdTodos.AutoSize = True
        Me.rdTodos.Location = New System.Drawing.Point(144, 10)
        Me.rdTodos.Name = "rdTodos"
        Me.rdTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdTodos.TabIndex = 2
        Me.rdTodos.Text = "Todos"
        Me.rdTodos.UseVisualStyleBackColor = True
        '
        'rdAberto
        '
        Me.rdAberto.AutoSize = True
        Me.rdAberto.Checked = True
        Me.rdAberto.Location = New System.Drawing.Point(64, 10)
        Me.rdAberto.Name = "rdAberto"
        Me.rdAberto.Size = New System.Drawing.Size(74, 17)
        Me.rdAberto.TabIndex = 1
        Me.rdAberto.TabStop = True
        Me.rdAberto.Text = "Em Aberto"
        Me.rdAberto.UseVisualStyleBackColor = True
        '
        'rdPago
        '
        Me.rdPago.AutoSize = True
        Me.rdPago.Location = New System.Drawing.Point(3, 10)
        Me.rdPago.Name = "rdPago"
        Me.rdPago.Size = New System.Drawing.Size(55, 17)
        Me.rdPago.TabIndex = 0
        Me.rdPago.Text = "Pagos"
        Me.rdPago.UseVisualStyleBackColor = True
        '
        'btLimpar
        '
        Me.btLimpar.Location = New System.Drawing.Point(834, 46)
        Me.btLimpar.Name = "btLimpar"
        Me.btLimpar.Size = New System.Drawing.Size(75, 23)
        Me.btLimpar.TabIndex = 10
        Me.btLimpar.Text = "Limpar"
        Me.btLimpar.UseVisualStyleBackColor = True
        '
        'btFiltro
        '
        Me.btFiltro.Location = New System.Drawing.Point(834, 16)
        Me.btFiltro.Name = "btFiltro"
        Me.btFiltro.Size = New System.Drawing.Size(75, 23)
        Me.btFiltro.TabIndex = 9
        Me.btFiltro.Text = "Filtrar"
        Me.btFiltro.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(563, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Documento:"
        '
        'txtDoc
        '
        Me.txtDoc.Location = New System.Drawing.Point(634, 18)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(100, 20)
        Me.txtDoc.TabIndex = 3
        Me.txtDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(365, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "até"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(232, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Pagamento:"
        '
        'txtPagFIM
        '
        Me.txtPagFIM.Location = New System.Drawing.Point(393, 79)
        Me.txtPagFIM.Mask = "99/99/99"
        Me.txtPagFIM.Name = "txtPagFIM"
        Me.txtPagFIM.Size = New System.Drawing.Size(58, 20)
        Me.txtPagFIM.TabIndex = 8
        Me.txtPagFIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPagINI
        '
        Me.txtPagINI.Location = New System.Drawing.Point(302, 79)
        Me.txtPagINI.Mask = "99/99/99"
        Me.txtPagINI.Name = "txtPagINI"
        Me.txtPagINI.Size = New System.Drawing.Size(57, 20)
        Me.txtPagINI.TabIndex = 7
        Me.txtPagINI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(517, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Forma de Pagamento:"
        '
        'cmbForma
        '
        Me.cmbForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbForma.FormattingEnabled = True
        Me.cmbForma.Items.AddRange(New Object() {"1 - Banco", "2 - Carteira", "3 - Depósito", "4 - Lotérica"})
        Me.cmbForma.Location = New System.Drawing.Point(634, 47)
        Me.cmbForma.Name = "cmbForma"
        Me.cmbForma.Size = New System.Drawing.Size(100, 21)
        Me.cmbForma.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(123, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fornecedor:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPessoa
        '
        Me.cmbPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPessoa.FormattingEnabled = True
        Me.cmbPessoa.Location = New System.Drawing.Point(196, 18)
        Me.cmbPessoa.Name = "cmbPessoa"
        Me.cmbPessoa.Size = New System.Drawing.Size(352, 21)
        Me.cmbPessoa.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "até"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Vencimento:"
        '
        'txtVencFIM
        '
        Me.txtVencFIM.Location = New System.Drawing.Point(169, 79)
        Me.txtVencFIM.Mask = "99/99/99"
        Me.txtVencFIM.Name = "txtVencFIM"
        Me.txtVencFIM.Size = New System.Drawing.Size(58, 20)
        Me.txtVencFIM.TabIndex = 6
        Me.txtVencFIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVencINI
        '
        Me.txtVencINI.Location = New System.Drawing.Point(78, 79)
        Me.txtVencINI.Mask = "99/99/99"
        Me.txtVencINI.Name = "txtVencINI"
        Me.txtVencINI.Size = New System.Drawing.Size(57, 20)
        Me.txtVencINI.TabIndex = 5
        Me.txtVencINI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdPagar
        '
        Me.rdPagar.AutoSize = True
        Me.rdPagar.Checked = True
        Me.rdPagar.Location = New System.Drawing.Point(6, 46)
        Me.rdPagar.Name = "rdPagar"
        Me.rdPagar.Size = New System.Drawing.Size(98, 17)
        Me.rdPagar.TabIndex = 1
        Me.rdPagar.TabStop = True
        Me.rdPagar.Text = "Contas a Pagar"
        Me.rdPagar.UseVisualStyleBackColor = True
        '
        'rdReceber
        '
        Me.rdReceber.AutoSize = True
        Me.rdReceber.Location = New System.Drawing.Point(6, 19)
        Me.rdReceber.Name = "rdReceber"
        Me.rdReceber.Size = New System.Drawing.Size(111, 17)
        Me.rdReceber.TabIndex = 0
        Me.rdReceber.Text = "Contas a Receber"
        Me.rdReceber.UseVisualStyleBackColor = True
        '
        'grpLancamentos
        '
        Me.grpLancamentos.Controls.Add(Me.btExcluir)
        Me.grpLancamentos.Controls.Add(Me.btAlterar)
        Me.grpLancamentos.Controls.Add(Me.btBaixa)
        Me.grpLancamentos.Controls.Add(Me.Label10)
        Me.grpLancamentos.Controls.Add(Me.Label11)
        Me.grpLancamentos.Controls.Add(Me.lblNLancamentos)
        Me.grpLancamentos.Controls.Add(Me.lblTotal)
        Me.grpLancamentos.Controls.Add(Me.dgLancamentos)
        Me.grpLancamentos.Location = New System.Drawing.Point(14, 123)
        Me.grpLancamentos.Name = "grpLancamentos"
        Me.grpLancamentos.Size = New System.Drawing.Size(915, 277)
        Me.grpLancamentos.TabIndex = 1
        Me.grpLancamentos.TabStop = False
        Me.grpLancamentos.Text = " Lançamentos "
        '
        'btExcluir
        '
        Me.btExcluir.Enabled = False
        Me.btExcluir.Location = New System.Drawing.Point(171, 250)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 20)
        Me.btExcluir.TabIndex = 3
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'btAlterar
        '
        Me.btAlterar.Enabled = False
        Me.btAlterar.Location = New System.Drawing.Point(90, 250)
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(75, 20)
        Me.btAlterar.TabIndex = 2
        Me.btAlterar.Text = "Alterar"
        Me.btAlterar.UseVisualStyleBackColor = True
        '
        'btBaixa
        '
        Me.btBaixa.Location = New System.Drawing.Point(9, 250)
        Me.btBaixa.Name = "btBaixa"
        Me.btBaixa.Size = New System.Drawing.Size(75, 20)
        Me.btBaixa.TabIndex = 1
        Me.btBaixa.Text = "Baixar"
        Me.btBaixa.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(712, 254)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Total dos Lançamentos:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(565, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Nº de Lançamentos:"
        '
        'lblNLancamentos
        '
        Me.lblNLancamentos.AutoSize = True
        Me.lblNLancamentos.Location = New System.Drawing.Point(675, 254)
        Me.lblNLancamentos.Name = "lblNLancamentos"
        Me.lblNLancamentos.Size = New System.Drawing.Size(13, 13)
        Me.lblNLancamentos.TabIndex = 2
        Me.lblNLancamentos.Text = "0"
        Me.lblNLancamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(839, 250)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(68, 20)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgLancamentos
        '
        Me.dgLancamentos.AllowUserToAddRows = False
        Me.dgLancamentos.AllowUserToDeleteRows = False
        Me.dgLancamentos.AllowUserToOrderColumns = True
        Me.dgLancamentos.AutoGenerateColumns = False
        Me.dgLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Vencimento, Me.ApresentacaoDataGridViewCheckBoxColumn, Me.Pessoa, Me.Documento, Me.NossoNumDataGridViewTextBoxColumn, Me.TipoDocDataGridViewTextBoxColumn, Me.Pagamento, Me.FPDataGridViewTextBoxColumn, Me.ParcelaDataGridViewTextBoxColumn, Me.PrevisaoDataGridViewCheckBoxColumn, Me.MensalDataGridViewCheckBoxColumn, Me.Valor, Me.TipoPRDataGridViewTextBoxColumn})
        Me.dgLancamentos.DataSource = Me.BSPagarreceber
        Me.dgLancamentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLancamentos.Location = New System.Drawing.Point(9, 17)
        Me.dgLancamentos.MultiSelect = False
        Me.dgLancamentos.Name = "dgLancamentos"
        Me.dgLancamentos.ReadOnly = True
        Me.dgLancamentos.RowHeadersWidth = 23
        Me.dgLancamentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancamentos.Size = New System.Drawing.Size(900, 227)
        Me.dgLancamentos.TabIndex = 0
        '
        'BSPagarreceber
        '
        Me.BSPagarreceber.AllowNew = False
        Me.BSPagarreceber.DataMember = "pagarreceber"
        Me.BSPagarreceber.DataSource = Me.DSContab
        '
        'DSContab
        '
        Me.DSContab.DataSetName = "DSContab"
        Me.DSContab.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'grpLancamento
        '
        Me.grpLancamento.Controls.Add(Me.btCancela)
        Me.grpLancamento.Controls.Add(Me.btConfirma)
        Me.grpLancamento.Controls.Add(Me.Label22)
        Me.grpLancamento.Controls.Add(Me.altValor)
        Me.grpLancamento.Controls.Add(Me.Label21)
        Me.grpLancamento.Controls.Add(Me.altPagamento)
        Me.grpLancamento.Controls.Add(Me.Label15)
        Me.grpLancamento.Controls.Add(Me.altForma)
        Me.grpLancamento.Controls.Add(Me.txtNInterno)
        Me.grpLancamento.Controls.Add(Me.Label13)
        Me.grpLancamento.Enabled = False
        Me.grpLancamento.Location = New System.Drawing.Point(15, 408)
        Me.grpLancamento.Name = "grpLancamento"
        Me.grpLancamento.Size = New System.Drawing.Size(914, 57)
        Me.grpLancamento.TabIndex = 2
        Me.grpLancamento.TabStop = False
        Me.grpLancamento.Text = "Dados do Lançamento "
        '
        'btCancela
        '
        Me.btCancela.Location = New System.Drawing.Point(831, 18)
        Me.btCancela.Name = "btCancela"
        Me.btCancela.Size = New System.Drawing.Size(74, 24)
        Me.btCancela.TabIndex = 4
        Me.btCancela.Text = "Cancelar"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'btConfirma
        '
        Me.btConfirma.Location = New System.Drawing.Point(751, 18)
        Me.btConfirma.Name = "btConfirma"
        Me.btConfirma.Size = New System.Drawing.Size(74, 24)
        Me.btConfirma.TabIndex = 3
        Me.btConfirma.Text = "Confirmar"
        Me.btConfirma.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(499, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Valor:"
        '
        'altValor
        '
        Me.altValor.Location = New System.Drawing.Point(539, 21)
        Me.altValor.Name = "altValor"
        Me.altValor.Size = New System.Drawing.Size(66, 20)
        Me.altValor.TabIndex = 2
        Me.altValor.Text = "0,00"
        Me.altValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(322, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "Pagamento:"
        '
        'altPagamento
        '
        Me.altPagamento.Location = New System.Drawing.Point(392, 21)
        Me.altPagamento.Mask = "99/99/9999"
        Me.altPagamento.Name = "altPagamento"
        Me.altPagamento.Size = New System.Drawing.Size(66, 20)
        Me.altPagamento.TabIndex = 1
        Me.altPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(135, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Forma:"
        '
        'altForma
        '
        Me.altForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.altForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.altForma.DropDownWidth = 113
        Me.altForma.FormattingEnabled = True
        Me.altForma.Items.AddRange(New Object() {"1 - Banco", "2 - Carteira", "3 - Depósito", "4 - Lotérica", "5 - Déb. Eletrônico", "6 - Créd. NFe"})
        Me.altForma.Location = New System.Drawing.Point(182, 21)
        Me.altForma.Name = "altForma"
        Me.altForma.Size = New System.Drawing.Size(113, 21)
        Me.altForma.TabIndex = 0
        '
        'txtNInterno
        '
        Me.txtNInterno.AutoSize = True
        Me.txtNInterno.Location = New System.Drawing.Point(86, 24)
        Me.txtNInterno.Name = "txtNInterno"
        Me.txtNInterno.Size = New System.Drawing.Size(37, 13)
        Me.txtNInterno.TabIndex = 21
        Me.txtNInterno.Text = "00000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Nº Interno"
        '
        'TAPagarreceber
        '
        Me.TAPagarreceber.ClearBeforeFill = True
        '
        'Id
        '
        Me.Id.DataPropertyName = "id"
        Me.Id.HeaderText = "id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Vencimento
        '
        Me.Vencimento.DataPropertyName = "Vencimento"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Vencimento.DefaultCellStyle = DataGridViewCellStyle1
        Me.Vencimento.HeaderText = "Vencimento"
        Me.Vencimento.Name = "Vencimento"
        Me.Vencimento.ReadOnly = True
        Me.Vencimento.Width = 70
        '
        'ApresentacaoDataGridViewCheckBoxColumn
        '
        Me.ApresentacaoDataGridViewCheckBoxColumn.DataPropertyName = "Apresentacao"
        Me.ApresentacaoDataGridViewCheckBoxColumn.FalseValue = "0"
        Me.ApresentacaoDataGridViewCheckBoxColumn.HeaderText = "Ap"
        Me.ApresentacaoDataGridViewCheckBoxColumn.IndeterminateValue = "-1"
        Me.ApresentacaoDataGridViewCheckBoxColumn.Name = "ApresentacaoDataGridViewCheckBoxColumn"
        Me.ApresentacaoDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ApresentacaoDataGridViewCheckBoxColumn.TrueValue = "1"
        Me.ApresentacaoDataGridViewCheckBoxColumn.Width = 30
        '
        'Pessoa
        '
        Me.Pessoa.DataPropertyName = "Pessoa"
        Me.Pessoa.HeaderText = "Fornecedor/Cliente"
        Me.Pessoa.Name = "Pessoa"
        Me.Pessoa.ReadOnly = True
        Me.Pessoa.Width = 180
        '
        'Documento
        '
        Me.Documento.DataPropertyName = "Documento"
        Me.Documento.HeaderText = "Nº Doc"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 80
        '
        'NossoNumDataGridViewTextBoxColumn
        '
        Me.NossoNumDataGridViewTextBoxColumn.DataPropertyName = "NossoNum"
        Me.NossoNumDataGridViewTextBoxColumn.HeaderText = "Núm"
        Me.NossoNumDataGridViewTextBoxColumn.Name = "NossoNumDataGridViewTextBoxColumn"
        Me.NossoNumDataGridViewTextBoxColumn.ReadOnly = True
        Me.NossoNumDataGridViewTextBoxColumn.ToolTipText = "Número do Boleto"
        Me.NossoNumDataGridViewTextBoxColumn.Width = 80
        '
        'TipoDocDataGridViewTextBoxColumn
        '
        Me.TipoDocDataGridViewTextBoxColumn.DataPropertyName = "TipoDoc"
        Me.TipoDocDataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.TipoDocDataGridViewTextBoxColumn.Name = "TipoDocDataGridViewTextBoxColumn"
        Me.TipoDocDataGridViewTextBoxColumn.ReadOnly = True
        Me.TipoDocDataGridViewTextBoxColumn.Width = 55
        '
        'Pagamento
        '
        Me.Pagamento.DataPropertyName = "Pagamento"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "d"
        Me.Pagamento.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pagamento.HeaderText = "Pagamento"
        Me.Pagamento.MaxInputLength = 11
        Me.Pagamento.Name = "Pagamento"
        Me.Pagamento.ReadOnly = True
        Me.Pagamento.Width = 80
        '
        'FPDataGridViewTextBoxColumn
        '
        Me.FPDataGridViewTextBoxColumn.DataPropertyName = "FP"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FPDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FPDataGridViewTextBoxColumn.HeaderText = "FP"
        Me.FPDataGridViewTextBoxColumn.Name = "FPDataGridViewTextBoxColumn"
        Me.FPDataGridViewTextBoxColumn.ReadOnly = True
        Me.FPDataGridViewTextBoxColumn.ToolTipText = "Forma de Pagamento"
        Me.FPDataGridViewTextBoxColumn.Width = 30
        '
        'ParcelaDataGridViewTextBoxColumn
        '
        Me.ParcelaDataGridViewTextBoxColumn.DataPropertyName = "Parcela"
        Me.ParcelaDataGridViewTextBoxColumn.HeaderText = "Parcela"
        Me.ParcelaDataGridViewTextBoxColumn.Name = "ParcelaDataGridViewTextBoxColumn"
        Me.ParcelaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ParcelaDataGridViewTextBoxColumn.Width = 50
        '
        'PrevisaoDataGridViewCheckBoxColumn
        '
        Me.PrevisaoDataGridViewCheckBoxColumn.DataPropertyName = "Previsao"
        Me.PrevisaoDataGridViewCheckBoxColumn.HeaderText = "Pre"
        Me.PrevisaoDataGridViewCheckBoxColumn.Name = "PrevisaoDataGridViewCheckBoxColumn"
        Me.PrevisaoDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PrevisaoDataGridViewCheckBoxColumn.ToolTipText = "Previsão"
        Me.PrevisaoDataGridViewCheckBoxColumn.Width = 40
        '
        'MensalDataGridViewCheckBoxColumn
        '
        Me.MensalDataGridViewCheckBoxColumn.DataPropertyName = "Mensal"
        Me.MensalDataGridViewCheckBoxColumn.HeaderText = "Men"
        Me.MensalDataGridViewCheckBoxColumn.Name = "MensalDataGridViewCheckBoxColumn"
        Me.MensalDataGridViewCheckBoxColumn.ReadOnly = True
        Me.MensalDataGridViewCheckBoxColumn.ToolTipText = "Mensal"
        Me.MensalDataGridViewCheckBoxColumn.Width = 40
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Valor"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle4
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.Width = 80
        '
        'TipoPRDataGridViewTextBoxColumn
        '
        Me.TipoPRDataGridViewTextBoxColumn.DataPropertyName = "TipoPR"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TipoPRDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TipoPRDataGridViewTextBoxColumn.HeaderText = "TipoPR"
        Me.TipoPRDataGridViewTextBoxColumn.Name = "TipoPRDataGridViewTextBoxColumn"
        Me.TipoPRDataGridViewTextBoxColumn.ReadOnly = True
        Me.TipoPRDataGridViewTextBoxColumn.Width = 30
        '
        'frmBaixaLancamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 475)
        Me.Controls.Add(Me.grpLancamentos)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.grpLancamento)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBaixaLancamentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Baixa de Lançamentos"
        Me.grpParametros.ResumeLayout(False)
        Me.grpParametros.PerformLayout()
        Me.grpPago.ResumeLayout(False)
        Me.grpPago.PerformLayout()
        Me.grpLancamentos.ResumeLayout(False)
        Me.grpLancamentos.PerformLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BSPagarreceber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLancamento.ResumeLayout(False)
        Me.grpLancamento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents grpLancamentos As System.Windows.Forms.GroupBox
    Friend WithEvents grpLancamento As System.Windows.Forms.GroupBox
    Friend WithEvents rdPagar As System.Windows.Forms.RadioButton
    Friend WithEvents rdReceber As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVencFIM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtVencINI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbForma As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPagFIM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPagINI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents dgLancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents btLimpar As System.Windows.Forms.Button
    Friend WithEvents btFiltro As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblNLancamentos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btBaixa As System.Windows.Forms.Button
    Friend WithEvents btAlterar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents altForma As System.Windows.Forms.ComboBox
    Friend WithEvents txtNInterno As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents altValor As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents altPagamento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents btConfirma As System.Windows.Forms.Button
    Friend WithEvents grpPago As System.Windows.Forms.GroupBox
    Friend WithEvents rdTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdAberto As System.Windows.Forms.RadioButton
    Friend WithEvents rdPago As System.Windows.Forms.RadioButton
    Friend WithEvents DSContab As SisControl.NET.DSContab
    Friend WithEvents BSPagarreceber As System.Windows.Forms.BindingSource
    Friend WithEvents TAPagarreceber As SisControl.NET.DSContabTableAdapters.pagarreceberTableAdapter
    Friend WithEvents btExcluir As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApresentacaoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Pessoa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NossoNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDocDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParcelaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrevisaoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MensalDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoPRDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
