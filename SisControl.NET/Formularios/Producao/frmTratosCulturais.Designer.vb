<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTratosCulturais
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgTrato = New System.Windows.Forms.DataGridView()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProduto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConcentracao = New System.Windows.Forms.TextBox()
        Me.rdGL = New System.Windows.Forms.RadioButton()
        Me.rdMGL = New System.Windows.Forms.RadioButton()
        Me.chkEstufa1 = New System.Windows.Forms.CheckBox()
        Me.chkEstufa2 = New System.Windows.Forms.CheckBox()
        Me.grpDetalhes = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservacoes = New System.Windows.Forms.TextBox()
        CType(Me.dgTrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalhes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data:"
        '
        'txtData
        '
        Me.txtData.Enabled = False
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(51, 172)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(344, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Novo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(425, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(506, 423)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 25)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgTrato
        '
        Me.dgTrato.AllowUserToAddRows = False
        Me.dgTrato.AllowUserToDeleteRows = False
        Me.dgTrato.AllowUserToOrderColumns = True
        Me.dgTrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTrato.Location = New System.Drawing.Point(12, 12)
        Me.dgTrato.Name = "dgTrato"
        Me.dgTrato.ReadOnly = True
        Me.dgTrato.RowHeadersWidth = 21
        Me.dgTrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTrato.Size = New System.Drawing.Size(569, 150)
        Me.dgTrato.TabIndex = 0
        '
        'cmbTipo
        '
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Adubação", "Fungicida", "Inseticida", "Fertirrigação"})
        Me.cmbTipo.Location = New System.Drawing.Point(19, 35)
        Me.cmbTipo.MaxLength = 30
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo:"
        '
        'cmbProduto
        '
        Me.cmbProduto.FormattingEnabled = True
        Me.cmbProduto.Location = New System.Drawing.Point(146, 35)
        Me.cmbProduto.MaxLength = 45
        Me.cmbProduto.Name = "cmbProduto"
        Me.cmbProduto.Size = New System.Drawing.Size(121, 21)
        Me.cmbProduto.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(143, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Produto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(270, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Concentração:"
        '
        'txtConcentracao
        '
        Me.txtConcentracao.Location = New System.Drawing.Point(273, 35)
        Me.txtConcentracao.Name = "txtConcentracao"
        Me.txtConcentracao.Size = New System.Drawing.Size(56, 20)
        Me.txtConcentracao.TabIndex = 13
        Me.txtConcentracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdGL
        '
        Me.rdGL.AutoSize = True
        Me.rdGL.Checked = True
        Me.rdGL.Location = New System.Drawing.Point(335, 36)
        Me.rdGL.Name = "rdGL"
        Me.rdGL.Size = New System.Drawing.Size(42, 17)
        Me.rdGL.TabIndex = 14
        Me.rdGL.TabStop = True
        Me.rdGL.Text = "g/L"
        Me.rdGL.UseVisualStyleBackColor = True
        '
        'rdMGL
        '
        Me.rdMGL.AutoSize = True
        Me.rdMGL.Location = New System.Drawing.Point(383, 36)
        Me.rdMGL.Name = "rdMGL"
        Me.rdMGL.Size = New System.Drawing.Size(46, 17)
        Me.rdMGL.TabIndex = 15
        Me.rdMGL.Text = "ml/L"
        Me.rdMGL.UseVisualStyleBackColor = True
        '
        'chkEstufa1
        '
        Me.chkEstufa1.AutoSize = True
        Me.chkEstufa1.Location = New System.Drawing.Point(163, 174)
        Me.chkEstufa1.Name = "chkEstufa1"
        Me.chkEstufa1.Size = New System.Drawing.Size(62, 17)
        Me.chkEstufa1.TabIndex = 16
        Me.chkEstufa1.Text = "Estufa I"
        Me.chkEstufa1.UseVisualStyleBackColor = True
        '
        'chkEstufa2
        '
        Me.chkEstufa2.AutoSize = True
        Me.chkEstufa2.Location = New System.Drawing.Point(231, 174)
        Me.chkEstufa2.Name = "chkEstufa2"
        Me.chkEstufa2.Size = New System.Drawing.Size(65, 17)
        Me.chkEstufa2.TabIndex = 17
        Me.chkEstufa2.Text = "Estufa II"
        Me.chkEstufa2.UseVisualStyleBackColor = True
        '
        'grpDetalhes
        '
        Me.grpDetalhes.Controls.Add(Me.Label2)
        Me.grpDetalhes.Controls.Add(Me.txtObservacoes)
        Me.grpDetalhes.Controls.Add(Me.Label7)
        Me.grpDetalhes.Controls.Add(Me.Label6)
        Me.grpDetalhes.Controls.Add(Me.txtVolume)
        Me.grpDetalhes.Controls.Add(Me.cmbTipo)
        Me.grpDetalhes.Controls.Add(Me.Label3)
        Me.grpDetalhes.Controls.Add(Me.cmbProduto)
        Me.grpDetalhes.Controls.Add(Me.rdMGL)
        Me.grpDetalhes.Controls.Add(Me.Label4)
        Me.grpDetalhes.Controls.Add(Me.rdGL)
        Me.grpDetalhes.Controls.Add(Me.Label5)
        Me.grpDetalhes.Controls.Add(Me.txtConcentracao)
        Me.grpDetalhes.Location = New System.Drawing.Point(15, 198)
        Me.grpDetalhes.Name = "grpDetalhes"
        Me.grpDetalhes.Size = New System.Drawing.Size(566, 219)
        Me.grpDetalhes.TabIndex = 18
        Me.grpDetalhes.TabStop = False
        Me.grpDetalhes.Text = "Detalhes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(436, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Volume:"
        '
        'txtVolume
        '
        Me.txtVolume.Location = New System.Drawing.Point(439, 35)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(38, 20)
        Me.txtVolume.TabIndex = 17
        Me.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(479, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "L"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Observações"
        '
        'txtObservacoes
        '
        Me.txtObservacoes.AcceptsReturn = True
        Me.txtObservacoes.AcceptsTab = True
        Me.txtObservacoes.Enabled = False
        Me.txtObservacoes.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacoes.Location = New System.Drawing.Point(19, 81)
        Me.txtObservacoes.Multiline = True
        Me.txtObservacoes.Name = "txtObservacoes"
        Me.txtObservacoes.Size = New System.Drawing.Size(458, 122)
        Me.txtObservacoes.TabIndex = 21
        '
        'frmTratosCulturais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 458)
        Me.Controls.Add(Me.grpDetalhes)
        Me.Controls.Add(Me.chkEstufa2)
        Me.Controls.Add(Me.chkEstufa1)
        Me.Controls.Add(Me.dgTrato)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTratosCulturais"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tratos Culturais - Estufa"
        CType(Me.dgTrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalhes.ResumeLayout(False)
        Me.grpDetalhes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dgTrato As System.Windows.Forms.DataGridView
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProduto As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtConcentracao As TextBox
    Friend WithEvents rdGL As RadioButton
    Friend WithEvents rdMGL As RadioButton
    Friend WithEvents chkEstufa1 As CheckBox
    Friend WithEvents chkEstufa2 As CheckBox
    Friend WithEvents grpDetalhes As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVolume As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObservacoes As TextBox
End Class
