<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportOFXData
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtArquivo = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ofArquivo = New System.Windows.Forms.OpenFileDialog()
        Me.dgLancamentos = New System.Windows.Forms.DataGridView()
        Me.btConfirma = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pbProgresso = New System.Windows.Forms.ProgressBar()
        Me.colData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistorico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCred = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCTCred = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCTDeb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtArquivo
        '
        Me.txtArquivo.Location = New System.Drawing.Point(64, 22)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(549, 20)
        Me.txtArquivo.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(654, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Importar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Arquivo:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(619, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = " ... "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ofArquivo
        '
        Me.ofArquivo.Filter = "Oficial Financial Exchange (OFX)|*.ofx"
        Me.ofArquivo.Title = "Selecione o Arquivo"
        '
        'dgLancamentos
        '
        Me.dgLancamentos.AllowUserToAddRows = False
        Me.dgLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colData, Me.colDescricao, Me.colHistorico, Me.colCred, Me.colDeb, Me.colCTCred, Me.colCTDeb})
        Me.dgLancamentos.Enabled = False
        Me.dgLancamentos.Location = New System.Drawing.Point(15, 49)
        Me.dgLancamentos.MultiSelect = False
        Me.dgLancamentos.Name = "dgLancamentos"
        Me.dgLancamentos.RowHeadersWidth = 21
        Me.dgLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancamentos.Size = New System.Drawing.Size(714, 274)
        Me.dgLancamentos.TabIndex = 4
        '
        'btConfirma
        '
        Me.btConfirma.Enabled = False
        Me.btConfirma.Location = New System.Drawing.Point(573, 329)
        Me.btConfirma.Name = "btConfirma"
        Me.btConfirma.Size = New System.Drawing.Size(75, 23)
        Me.btConfirma.TabIndex = 5
        Me.btConfirma.Text = "Confirma"
        Me.btConfirma.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(654, 329)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Cancela"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pbProgresso
        '
        Me.pbProgresso.Location = New System.Drawing.Point(15, 329)
        Me.pbProgresso.Name = "pbProgresso"
        Me.pbProgresso.Size = New System.Drawing.Size(305, 23)
        Me.pbProgresso.TabIndex = 7
        Me.pbProgresso.Visible = False
        '
        'colData
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Format = "d"
        Me.colData.DefaultCellStyle = DataGridViewCellStyle1
        Me.colData.HeaderText = "Data"
        Me.colData.Name = "colData"
        Me.colData.Width = 70
        '
        'colDescricao
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Format = "@!"
        DataGridViewCellStyle2.NullValue = " "
        Me.colDescricao.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDescricao.HeaderText = "Descrição"
        Me.colDescricao.MaxInputLength = 120
        Me.colDescricao.Name = "colDescricao"
        Me.colDescricao.Width = 180
        '
        'colHistorico
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colHistorico.DefaultCellStyle = DataGridViewCellStyle3
        Me.colHistorico.HeaderText = "Histórico"
        Me.colHistorico.MaxInputLength = 120
        Me.colHistorico.Name = "colHistorico"
        Me.colHistorico.Width = 175
        '
        'colCred
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0,00"
        Me.colCred.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCred.HeaderText = "Crédito"
        Me.colCred.Name = "colCred"
        Me.colCred.Width = 65
        '
        'colDeb
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0,00"
        Me.colDeb.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDeb.HeaderText = "Débito"
        Me.colDeb.Name = "colDeb"
        Me.colDeb.Width = 65
        '
        'colCTCred
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colCTCred.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCTCred.HeaderText = "CT Créd"
        Me.colCTCred.Name = "colCTCred"
        Me.colCTCred.Width = 55
        '
        'colCTDeb
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colCTDeb.DefaultCellStyle = DataGridViewCellStyle7
        Me.colCTDeb.HeaderText = "CT Déb"
        Me.colCTDeb.Name = "colCTDeb"
        Me.colCTDeb.Width = 55
        '
        'frmImportOFXData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 359)
        Me.Controls.Add(Me.pbProgresso)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btConfirma)
        Me.Controls.Add(Me.dgLancamentos)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtArquivo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportOFXData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Arquivo Bancário"
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtArquivo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ofArquivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgLancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents btConfirma As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pbProgresso As System.Windows.Forms.ProgressBar
    Friend WithEvents colData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistorico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCTCred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCTDeb As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
