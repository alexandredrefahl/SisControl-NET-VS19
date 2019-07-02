<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlteracaoLancamento
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkCompra = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtParcela = New System.Windows.Forms.TextBox()
        Me.chkMensal = New System.Windows.Forms.CheckBox()
        Me.chkPrevisao = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpContabil = New System.Windows.Forms.GroupBox()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_Debito = New System.Windows.Forms.Label()
        Me.lbl_Credito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgLancCont = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodHist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTCred = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTDeb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_IDDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lancado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BSPrlancamentos = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPRLancamentos = New SisControl.NET.dsPRLancamentos()
        Me.pnlHistorico = New System.Windows.Forms.Panel()
        Me.dgHistorico = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEntSai = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmissao = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkContra = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVencimento = New System.Windows.Forms.MaskedTextBox()
        Me.txtPessoa = New System.Windows.Forms.ComboBox()
        Me.TA_PRlancamentos = New SisControl.NET.dsPRLancamentosTableAdapters.pr_lancamentosTableAdapter()
        Me.grpContabil.SuspendLayout()
        CType(Me.dgLancCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BSPrlancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPRLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHistorico.SuspendLayout()
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkCompra
        '
        Me.chkCompra.AutoSize = True
        Me.chkCompra.Location = New System.Drawing.Point(304, 141)
        Me.chkCompra.Name = "chkCompra"
        Me.chkCompra.Size = New System.Drawing.Size(62, 17)
        Me.chkCompra.TabIndex = 32
        Me.chkCompra.Text = "Compra"
        Me.chkCompra.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(209, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Parcela:"
        '
        'txtParcela
        '
        Me.txtParcela.Location = New System.Drawing.Point(304, 115)
        Me.txtParcela.Name = "txtParcela"
        Me.txtParcela.Size = New System.Drawing.Size(100, 20)
        Me.txtParcela.TabIndex = 28
        Me.txtParcela.Text = "Única"
        '
        'chkMensal
        '
        Me.chkMensal.AutoSize = True
        Me.chkMensal.Location = New System.Drawing.Point(212, 141)
        Me.chkMensal.Name = "chkMensal"
        Me.chkMensal.Size = New System.Drawing.Size(60, 17)
        Me.chkMensal.TabIndex = 31
        Me.chkMensal.Text = "Mensal"
        Me.chkMensal.UseVisualStyleBackColor = True
        '
        'chkPrevisao
        '
        Me.chkPrevisao.AutoSize = True
        Me.chkPrevisao.Location = New System.Drawing.Point(98, 141)
        Me.chkPrevisao.Name = "chkPrevisao"
        Me.chkPrevisao.Size = New System.Drawing.Size(67, 17)
        Me.chkPrevisao.TabIndex = 29
        Me.chkPrevisao.Text = "Previsão"
        Me.chkPrevisao.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(441, 428)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 428)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Salvar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grpContabil
        '
        Me.grpContabil.Controls.Add(Me.lbl_Total)
        Me.grpContabil.Controls.Add(Me.Label10)
        Me.grpContabil.Controls.Add(Me.lbl_Debito)
        Me.grpContabil.Controls.Add(Me.lbl_Credito)
        Me.grpContabil.Controls.Add(Me.Label9)
        Me.grpContabil.Controls.Add(Me.Label8)
        Me.grpContabil.Controls.Add(Me.dgLancCont)
        Me.grpContabil.Location = New System.Drawing.Point(8, 167)
        Me.grpContabil.Name = "grpContabil"
        Me.grpContabil.Size = New System.Drawing.Size(508, 255)
        Me.grpContabil.TabIndex = 34
        Me.grpContabil.TabStop = False
        Me.grpContabil.Text = " Contabilização "
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
        Me.dgLancCont.AutoGenerateColumns = False
        Me.dgLancCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancCont.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.CodHist, Me.Historico, Me.Data, Me.CTCred, Me.CTDeb, Me.col_Valor, Me.col_IDDoc, Me.Lancado})
        Me.dgLancCont.DataSource = Me.BSPrlancamentos
        Me.dgLancCont.Location = New System.Drawing.Point(7, 19)
        Me.dgLancCont.MultiSelect = False
        Me.dgLancCont.Name = "dgLancCont"
        Me.dgLancCont.RowHeadersWidth = 25
        Me.dgLancCont.RowTemplate.ErrorText = "Erro de Linha"
        Me.dgLancCont.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancCont.Size = New System.Drawing.Size(495, 186)
        Me.dgLancCont.TabIndex = 0
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'CodHist
        '
        Me.CodHist.DataPropertyName = "CDHist"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "000"
        DataGridViewCellStyle1.NullValue = "0"
        Me.CodHist.DefaultCellStyle = DataGridViewCellStyle1
        Me.CodHist.HeaderText = "Cód"
        Me.CodHist.MaxInputLength = 3
        Me.CodHist.Name = "CodHist"
        Me.CodHist.Width = 45
        '
        'Historico
        '
        Me.Historico.DataPropertyName = "Historico"
        Me.Historico.HeaderText = "Histórico"
        Me.Historico.MaxInputLength = 60
        Me.Historico.Name = "Historico"
        Me.Historico.Width = 250
        '
        'Data
        '
        Me.Data.DataPropertyName = "Data"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.Visible = False
        '
        'CTCred
        '
        Me.CTCred.DataPropertyName = "CTCred"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "000"
        Me.CTCred.DefaultCellStyle = DataGridViewCellStyle2
        Me.CTCred.HeaderText = "Déb."
        Me.CTCred.Name = "CTCred"
        Me.CTCred.Width = 45
        '
        'CTDeb
        '
        Me.CTDeb.DataPropertyName = "CTDeb"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "000"
        Me.CTDeb.DefaultCellStyle = DataGridViewCellStyle3
        Me.CTDeb.HeaderText = "Créd."
        Me.CTDeb.Name = "CTDeb"
        Me.CTDeb.Width = 45
        '
        'col_Valor
        '
        Me.col_Valor.DataPropertyName = "Valor"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0,00"
        Me.col_Valor.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_Valor.HeaderText = "Valor"
        Me.col_Valor.Name = "col_Valor"
        Me.col_Valor.Width = 57
        '
        'col_IDDoc
        '
        Me.col_IDDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_IDDoc.DataPropertyName = "idDoc"
        Me.col_IDDoc.HeaderText = "idDoc"
        Me.col_IDDoc.MaxInputLength = 7
        Me.col_IDDoc.Name = "col_IDDoc"
        Me.col_IDDoc.Width = 60
        '
        'Lancado
        '
        Me.Lancado.DataPropertyName = "Lancado"
        Me.Lancado.HeaderText = "Lancado"
        Me.Lancado.Name = "Lancado"
        Me.Lancado.Visible = False
        '
        'BSPrlancamentos
        '
        Me.BSPrlancamentos.DataMember = "pr_lancamentos"
        Me.BSPrlancamentos.DataSource = Me.DsPRLancamentos
        '
        'DsPRLancamentos
        '
        Me.DsPRLancamentos.DataSetName = "dsPRLancamentos"
        Me.DsPRLancamentos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnlHistorico
        '
        Me.pnlHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHistorico.Controls.Add(Me.dgHistorico)
        Me.pnlHistorico.Location = New System.Drawing.Point(497, 14)
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
        Me.dgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistorico.Location = New System.Drawing.Point(14, 10)
        Me.dgHistorico.Name = "dgHistorico"
        Me.dgHistorico.ReadOnly = True
        Me.dgHistorico.RowHeadersWidth = 20
        Me.dgHistorico.RowTemplate.Height = 18
        Me.dgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistorico.Size = New System.Drawing.Size(363, 182)
        Me.dgHistorico.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Valor:"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(98, 115)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(79, 20)
        Me.txtValor.TabIndex = 26
        Me.txtValor.Text = "0,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Items.AddRange(New Object() {"Boleto", "Con. Transporte", "DARF - Guia", "Duplicata", "Fatura", "Folha Pagamento", "GPS - Guia", "Guia de Recolhimento", "IPTU - Carnê", "NF", "NFe", "NFs", "Ordem Compra", "Promissória", "Recibo", "Req. Interna"})
        Me.cmbTipoDoc.Location = New System.Drawing.Point(304, 88)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(197, 21)
        Me.cmbTipoDoc.Sorted = True
        Me.cmbTipoDoc.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(209, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Tipo Documento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Nº Documento:"
        '
        'txtDoc
        '
        Me.txtDoc.Location = New System.Drawing.Point(98, 89)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(79, 20)
        Me.txtDoc.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Entrada:"
        '
        'txtEntSai
        '
        Me.txtEntSai.Location = New System.Drawing.Point(262, 63)
        Me.txtEntSai.Mask = "99/99/99"
        Me.txtEntSai.Name = "txtEntSai"
        Me.txtEntSai.Size = New System.Drawing.Size(57, 20)
        Me.txtEntSai.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Emissão:"
        '
        'txtEmissao
        '
        Me.txtEmissao.Location = New System.Drawing.Point(98, 63)
        Me.txtEmissao.Mask = "99/99/99"
        Me.txtEmissao.Name = "txtEmissao"
        Me.txtEmissao.Size = New System.Drawing.Size(57, 20)
        Me.txtEmissao.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Cedente:"
        '
        'chkContra
        '
        Me.chkContra.AutoSize = True
        Me.chkContra.Location = New System.Drawing.Point(161, 13)
        Me.chkContra.Name = "chkContra"
        Me.chkContra.Size = New System.Drawing.Size(126, 17)
        Me.chkContra.TabIndex = 17
        Me.chkContra.Text = "Contra Apresentação"
        Me.chkContra.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Vencimento:"
        '
        'txtVencimento
        '
        Me.txtVencimento.Location = New System.Drawing.Point(98, 11)
        Me.txtVencimento.Mask = "99/99/99"
        Me.txtVencimento.Name = "txtVencimento"
        Me.txtVencimento.Size = New System.Drawing.Size(57, 20)
        Me.txtVencimento.TabIndex = 16
        '
        'txtPessoa
        '
        Me.txtPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtPessoa.FormattingEnabled = True
        Me.txtPessoa.Location = New System.Drawing.Point(98, 37)
        Me.txtPessoa.Name = "txtPessoa"
        Me.txtPessoa.Size = New System.Drawing.Size(403, 21)
        Me.txtPessoa.TabIndex = 19
        '
        'TA_PRlancamentos
        '
        Me.TA_PRlancamentos.ClearBeforeFill = True
        '
        'frmAlteracaoLancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 458)
        Me.Controls.Add(Me.pnlHistorico)
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
        Me.Name = "frmAlteracaoLancamento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alteração de Lançamentos"
        Me.grpContabil.ResumeLayout(False)
        Me.grpContabil.PerformLayout()
        CType(Me.dgLancCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BSPrlancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPRLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHistorico.ResumeLayout(False)
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCompra As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtParcela As System.Windows.Forms.TextBox
    Friend WithEvents chkMensal As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrevisao As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grpContabil As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHistorico As System.Windows.Forms.Panel
    Friend WithEvents dgHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Debito As System.Windows.Forms.Label
    Friend WithEvents lbl_Credito As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgLancCont As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEntSai As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkContra As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVencimento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents DsPRLancamentos As SisControl.NET.dsPRLancamentos
    Friend WithEvents BSPrlancamentos As System.Windows.Forms.BindingSource
    Friend WithEvents TA_PRlancamentos As SisControl.NET.dsPRLancamentosTableAdapters.pr_lancamentosTableAdapter
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodHist As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTDeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_IDDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lancado As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
