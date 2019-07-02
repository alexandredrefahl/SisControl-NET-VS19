<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLancamentoContab
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodHis = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtCTDeb = New System.Windows.Forms.TextBox()
        Me.txtCTCred = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btConfirma = New System.Windows.Forms.Button()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.lblCTDeb = New System.Windows.Forms.Label()
        Me.lblCTCred = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.pnlHistorico = New System.Windows.Forms.Panel()
        Me.dgHistorico = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTCreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTDebDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BSHistorico = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSContab = New SisControl.NET.DSContab()
        Me.TAHistorico = New SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter()
        Me.pnlHistorico.SuspendLayout()
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BSHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(144, 26)
        Me.txtData.Mask = "99/99/9999"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(68, 20)
        Me.txtData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(33, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código do Histórico:"
        '
        'txtCodHis
        '
        Me.txtCodHis.Location = New System.Drawing.Point(144, 52)
        Me.txtCodHis.Name = "txtCodHis"
        Me.txtCodHis.Size = New System.Drawing.Size(40, 20)
        Me.txtCodHis.TabIndex = 1
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(144, 78)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(325, 20)
        Me.txtDescricao.TabIndex = 2
        '
        'txtCTDeb
        '
        Me.txtCTDeb.Location = New System.Drawing.Point(144, 104)
        Me.txtCTDeb.Name = "txtCTDeb"
        Me.txtCTDeb.Size = New System.Drawing.Size(40, 20)
        Me.txtCTDeb.TabIndex = 3
        '
        'txtCTCred
        '
        Me.txtCTCred.Location = New System.Drawing.Point(144, 130)
        Me.txtCTCred.Name = "txtCTCred"
        Me.txtCTCred.Size = New System.Drawing.Size(40, 20)
        Me.txtCTCred.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(33, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Descrição:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(33, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Conta para Débito:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(33, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Conta para Crédito:"
        '
        'btConfirma
        '
        Me.btConfirma.Location = New System.Drawing.Point(329, 191)
        Me.btConfirma.Name = "btConfirma"
        Me.btConfirma.Size = New System.Drawing.Size(75, 23)
        Me.btConfirma.TabIndex = 5
        Me.btConfirma.Text = "Confirma"
        Me.btConfirma.UseVisualStyleBackColor = True
        '
        'btCancela
        '
        Me.btCancela.Location = New System.Drawing.Point(410, 191)
        Me.btCancela.Name = "btCancela"
        Me.btCancela.Size = New System.Drawing.Size(75, 23)
        Me.btCancela.TabIndex = 6
        Me.btCancela.Text = "Sair"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'lblCTDeb
        '
        Me.lblCTDeb.AutoSize = True
        Me.lblCTDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTDeb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTDeb.Location = New System.Drawing.Point(190, 107)
        Me.lblCTDeb.Name = "lblCTDeb"
        Me.lblCTDeb.Size = New System.Drawing.Size(19, 13)
        Me.lblCTDeb.TabIndex = 12
        Me.lblCTDeb.Text = "..."
        '
        'lblCTCred
        '
        Me.lblCTCred.AutoSize = True
        Me.lblCTCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTCred.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTCred.Location = New System.Drawing.Point(190, 133)
        Me.lblCTCred.Name = "lblCTCred"
        Me.lblCTCred.Size = New System.Drawing.Size(19, 13)
        Me.lblCTCred.TabIndex = 13
        Me.lblCTCred.Text = "..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(33, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Valor:"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(144, 156)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(68, 20)
        Me.txtValor.TabIndex = 4
        Me.txtValor.Text = "0,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlHistorico
        '
        Me.pnlHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHistorico.Controls.Add(Me.dgHistorico)
        Me.pnlHistorico.Location = New System.Drawing.Point(72, 12)
        Me.pnlHistorico.Name = "pnlHistorico"
        Me.pnlHistorico.Size = New System.Drawing.Size(390, 205)
        Me.pnlHistorico.TabIndex = 17
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
        Me.dgHistorico.DataSource = Me.BSHistorico
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "000"
        Me.IdDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
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
        'BSHistorico
        '
        Me.BSHistorico.DataMember = "ctbhistorico"
        Me.BSHistorico.DataSource = Me.DSContab
        '
        'DSContab
        '
        Me.DSContab.DataSetName = "DSContab"
        Me.DSContab.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TAHistorico
        '
        Me.TAHistorico.ClearBeforeFill = True
        '
        'frmLancamentoContab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 226)
        Me.Controls.Add(Me.txtCTCred)
        Me.Controls.Add(Me.lblCTCred)
        Me.Controls.Add(Me.lblCTDeb)
        Me.Controls.Add(Me.txtCTDeb)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btCancela)
        Me.Controls.Add(Me.btConfirma)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCodHis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.pnlHistorico)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLancamentoContab"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamentos Contábeis"
        Me.pnlHistorico.ResumeLayout(False)
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BSHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSContab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodHis As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents txtCTDeb As System.Windows.Forms.TextBox
    Friend WithEvents txtCTCred As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btConfirma As System.Windows.Forms.Button
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents lblCTDeb As System.Windows.Forms.Label
    Friend WithEvents lblCTCred As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents DSContab As SisControl.NET.DSContab
    Friend WithEvents pnlHistorico As System.Windows.Forms.Panel
    Friend WithEvents dgHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents TAHistorico As SisControl.NET.DSContabTableAdapters.ctbhistoricoTableAdapter
    Friend WithEvents BSHistorico As System.Windows.Forms.BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTDebDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
