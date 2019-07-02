<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContasReceber
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtPessoa = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtParcela = New System.Windows.Forms.TextBox
        Me.chkMensal = New System.Windows.Forms.CheckBox
        Me.chkPrevisao = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.grpContabil = New System.Windows.Forms.GroupBox
        Me.lblCTDeb = New System.Windows.Forms.Label
        Me.lblCTCred = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCTDeb = New System.Windows.Forms.TextBox
        Me.txtCTCred = New System.Windows.Forms.TextBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCodHis = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEntSai = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmissao = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkContra = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVencimento = New System.Windows.Forms.MaskedTextBox
        Me.pnlHistorico = New System.Windows.Forms.Panel
        Me.dgHistorico = New System.Windows.Forms.DataGridView
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescricaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTCreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTDebDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CtbhistoricoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSContab = New SisControl.NET.DSContab
        Me.CtbhistoricoTableAdapter = New SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter
        Me.grpContabil.SuspendLayout()
        Me.pnlHistorico.SuspendLayout()
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CtbhistoricoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPessoa
        '
        Me.txtPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtPessoa.FormattingEnabled = True
        Me.txtPessoa.Location = New System.Drawing.Point(100, 42)
        Me.txtPessoa.Name = "txtPessoa"
        Me.txtPessoa.Size = New System.Drawing.Size(403, 21)
        Me.txtPessoa.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(211, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Parcela:"
        '
        'txtParcela
        '
        Me.txtParcela.Location = New System.Drawing.Point(306, 120)
        Me.txtParcela.Name = "txtParcela"
        Me.txtParcela.Size = New System.Drawing.Size(100, 20)
        Me.txtParcela.TabIndex = 27
        Me.txtParcela.Text = "Única"
        '
        'chkMensal
        '
        Me.chkMensal.AutoSize = True
        Me.chkMensal.Location = New System.Drawing.Point(214, 146)
        Me.chkMensal.Name = "chkMensal"
        Me.chkMensal.Size = New System.Drawing.Size(60, 17)
        Me.chkMensal.TabIndex = 31
        Me.chkMensal.Text = "Mensal"
        Me.chkMensal.UseVisualStyleBackColor = True
        '
        'chkPrevisao
        '
        Me.chkPrevisao.AutoSize = True
        Me.chkPrevisao.Location = New System.Drawing.Point(100, 146)
        Me.chkPrevisao.Name = "chkPrevisao"
        Me.chkPrevisao.Size = New System.Drawing.Size(67, 17)
        Me.chkPrevisao.TabIndex = 29
        Me.chkPrevisao.Text = "Previsão"
        Me.chkPrevisao.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 278)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(362, 278)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Incluir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grpContabil
        '
        Me.grpContabil.Controls.Add(Me.lblCTDeb)
        Me.grpContabil.Controls.Add(Me.lblCTCred)
        Me.grpContabil.Controls.Add(Me.Label10)
        Me.grpContabil.Controls.Add(Me.Label9)
        Me.grpContabil.Controls.Add(Me.txtCTDeb)
        Me.grpContabil.Controls.Add(Me.txtCTCred)
        Me.grpContabil.Controls.Add(Me.txtDescricao)
        Me.grpContabil.Controls.Add(Me.Label8)
        Me.grpContabil.Controls.Add(Me.txtCodHis)
        Me.grpContabil.Location = New System.Drawing.Point(10, 172)
        Me.grpContabil.Name = "grpContabil"
        Me.grpContabil.Size = New System.Drawing.Size(508, 100)
        Me.grpContabil.TabIndex = 33
        Me.grpContabil.TabStop = False
        Me.grpContabil.Text = " Contabilização "
        '
        'lblCTDeb
        '
        Me.lblCTDeb.AutoSize = True
        Me.lblCTDeb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTDeb.Location = New System.Drawing.Point(121, 74)
        Me.lblCTDeb.Name = "lblCTDeb"
        Me.lblCTDeb.Size = New System.Drawing.Size(16, 13)
        Me.lblCTDeb.TabIndex = 25
        Me.lblCTDeb.Text = "..."
        '
        'lblCTCred
        '
        Me.lblCTCred.AutoSize = True
        Me.lblCTCred.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTCred.Location = New System.Drawing.Point(121, 48)
        Me.lblCTCred.Name = "lblCTCred"
        Me.lblCTCred.Size = New System.Drawing.Size(16, 13)
        Me.lblCTCred.TabIndex = 24
        Me.lblCTCred.Text = "..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Conta Débito:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Conta Crédito:"
        '
        'txtCTDeb
        '
        Me.txtCTDeb.Location = New System.Drawing.Point(83, 71)
        Me.txtCTDeb.Name = "txtCTDeb"
        Me.txtCTDeb.Size = New System.Drawing.Size(32, 20)
        Me.txtCTDeb.TabIndex = 13
        '
        'txtCTCred
        '
        Me.txtCTCred.Location = New System.Drawing.Point(83, 45)
        Me.txtCTCred.Name = "txtCTCred"
        Me.txtCTCred.Size = New System.Drawing.Size(32, 20)
        Me.txtCTCred.TabIndex = 12
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(124, 19)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(369, 20)
        Me.txtDescricao.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Histórico:"
        '
        'txtCodHis
        '
        Me.txtCodHis.Location = New System.Drawing.Point(83, 19)
        Me.txtCodHis.Name = "txtCodHis"
        Me.txtCodHis.Size = New System.Drawing.Size(32, 20)
        Me.txtCodHis.TabIndex = 10
        Me.txtCodHis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Valor:"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(100, 120)
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
        Me.cmbTipoDoc.Location = New System.Drawing.Point(306, 93)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(197, 21)
        Me.cmbTipoDoc.Sorted = True
        Me.cmbTipoDoc.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Tipo Documento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Nº Documento:"
        '
        'txtDoc
        '
        Me.txtDoc.Location = New System.Drawing.Point(100, 94)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(79, 20)
        Me.txtDoc.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Entrada:"
        '
        'txtEntSai
        '
        Me.txtEntSai.Location = New System.Drawing.Point(264, 68)
        Me.txtEntSai.Mask = "99/99/99"
        Me.txtEntSai.Name = "txtEntSai"
        Me.txtEntSai.Size = New System.Drawing.Size(57, 20)
        Me.txtEntSai.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Emissão:"
        '
        'txtEmissao
        '
        Me.txtEmissao.Location = New System.Drawing.Point(100, 68)
        Me.txtEmissao.Mask = "99/99/99"
        Me.txtEmissao.Name = "txtEmissao"
        Me.txtEmissao.Size = New System.Drawing.Size(57, 20)
        Me.txtEmissao.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Sacado:"
        '
        'chkContra
        '
        Me.chkContra.AutoSize = True
        Me.chkContra.Location = New System.Drawing.Point(163, 18)
        Me.chkContra.Name = "chkContra"
        Me.chkContra.Size = New System.Drawing.Size(126, 17)
        Me.chkContra.TabIndex = 17
        Me.chkContra.Text = "Contra Apresentação"
        Me.chkContra.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Vencimento:"
        '
        'txtVencimento
        '
        Me.txtVencimento.Location = New System.Drawing.Point(100, 16)
        Me.txtVencimento.Mask = "99/99/99"
        Me.txtVencimento.Name = "txtVencimento"
        Me.txtVencimento.Size = New System.Drawing.Size(57, 20)
        Me.txtVencimento.TabIndex = 16
        '
        'pnlHistorico
        '
        Me.pnlHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHistorico.Controls.Add(Me.dgHistorico)
        Me.pnlHistorico.Location = New System.Drawing.Point(134, 6)
        Me.pnlHistorico.Name = "pnlHistorico"
        Me.pnlHistorico.Size = New System.Drawing.Size(390, 205)
        Me.pnlHistorico.TabIndex = 38
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
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Cód"
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
        Me.CTCreDataGridViewTextBoxColumn.HeaderText = "Créd"
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
        'CtbhistoricoTableAdapter
        '
        Me.CtbhistoricoTableAdapter.ClearBeforeFill = True
        '
        'frmContasReceber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 316)
        Me.Controls.Add(Me.pnlHistorico)
        Me.Controls.Add(Me.txtPessoa)
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
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContasReceber"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento de Contas a Receber"
        Me.grpContabil.ResumeLayout(False)
        Me.grpContabil.PerformLayout()
        Me.pnlHistorico.ResumeLayout(False)
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CtbhistoricoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPessoa As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtParcela As System.Windows.Forms.TextBox
    Friend WithEvents chkMensal As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrevisao As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grpContabil As System.Windows.Forms.GroupBox
    Friend WithEvents lblCTDeb As System.Windows.Forms.Label
    Friend WithEvents lblCTCred As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCTDeb As System.Windows.Forms.TextBox
    Friend WithEvents txtCTCred As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCodHis As System.Windows.Forms.TextBox
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
    Friend WithEvents pnlHistorico As System.Windows.Forms.Panel
    Friend WithEvents dgHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents DSContab As SisControl.NET.DSContab
    Friend WithEvents CtbhistoricoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CtbhistoricoTableAdapter As SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTDebDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
