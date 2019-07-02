<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroClones
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
        Me.cmbMercadoria = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btNovo = New System.Windows.Forms.Button
        Me.btSalvar = New System.Windows.Forms.Button
        Me.lstClone = New System.Windows.Forms.ListBox
        Me.grpClone = New System.Windows.Forms.GroupBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtClone = New System.Windows.Forms.TextBox
        Me.btEditar = New System.Windows.Forms.Button
        Me.grpClone.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMercadoria
        '
        Me.cmbMercadoria.DropDownHeight = 50
        Me.cmbMercadoria.FormattingEnabled = True
        Me.cmbMercadoria.IntegralHeight = False
        Me.cmbMercadoria.Location = New System.Drawing.Point(75, 12)
        Me.cmbMercadoria.Name = "cmbMercadoria"
        Me.cmbMercadoria.Size = New System.Drawing.Size(252, 21)
        Me.cmbMercadoria.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mercadoria:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Clone:"
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(344, 12)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 25)
        Me.btNovo.TabIndex = 4
        Me.btNovo.Text = "&Novo"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'btSalvar
        '
        Me.btSalvar.Enabled = False
        Me.btSalvar.Location = New System.Drawing.Point(344, 72)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 9
        Me.btSalvar.Text = "&Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'lstClone
        '
        Me.lstClone.FormattingEnabled = True
        Me.lstClone.Location = New System.Drawing.Point(75, 42)
        Me.lstClone.Name = "lstClone"
        Me.lstClone.Size = New System.Drawing.Size(252, 82)
        Me.lstClone.TabIndex = 10
        '
        'grpClone
        '
        Me.grpClone.Controls.Add(Me.txtDescricao)
        Me.grpClone.Controls.Add(Me.Label5)
        Me.grpClone.Controls.Add(Me.txtNome)
        Me.grpClone.Controls.Add(Me.Label4)
        Me.grpClone.Controls.Add(Me.Label3)
        Me.grpClone.Controls.Add(Me.txtClone)
        Me.grpClone.Enabled = False
        Me.grpClone.Location = New System.Drawing.Point(12, 130)
        Me.grpClone.Name = "grpClone"
        Me.grpClone.Size = New System.Drawing.Size(407, 145)
        Me.grpClone.TabIndex = 11
        Me.grpClone.TabStop = False
        Me.grpClone.Text = " Dados do Clone "
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(75, 82)
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(318, 49)
        Me.txtDescricao.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Descrição:"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(75, 56)
        Me.txtNome.MaxLength = 15
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(318, 20)
        Me.txtNome.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Nome:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Clone:"
        '
        'txtClone
        '
        Me.txtClone.Location = New System.Drawing.Point(75, 30)
        Me.txtClone.MaxLength = 4
        Me.txtClone.Name = "txtClone"
        Me.txtClone.Size = New System.Drawing.Size(35, 20)
        Me.txtClone.TabIndex = 9
        Me.txtClone.Text = "0000"
        '
        'btEditar
        '
        Me.btEditar.Enabled = False
        Me.btEditar.Location = New System.Drawing.Point(344, 43)
        Me.btEditar.Name = "btEditar"
        Me.btEditar.Size = New System.Drawing.Size(75, 23)
        Me.btEditar.TabIndex = 12
        Me.btEditar.Text = "&Editar"
        Me.btEditar.UseVisualStyleBackColor = True
        '
        'frmCadastroClones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 288)
        Me.Controls.Add(Me.btEditar)
        Me.Controls.Add(Me.grpClone)
        Me.Controls.Add(Me.lstClone)
        Me.Controls.Add(Me.btSalvar)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMercadoria)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCadastroClones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Clones"
        Me.grpClone.ResumeLayout(False)
        Me.grpClone.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMercadoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents lstClone As System.Windows.Forms.ListBox
    Friend WithEvents grpClone As System.Windows.Forms.GroupBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtClone As System.Windows.Forms.TextBox
    Friend WithEvents btEditar As System.Windows.Forms.Button
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
