<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContatos
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
        Me.dgContatos = New System.Windows.Forms.DataGridView()
        Me.tbDados = New System.Windows.Forms.TabControl()
        Me.tabDados = New System.Windows.Forms.TabPage()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAssunto = New System.Windows.Forms.TextBox()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.txtEntidade = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.tabObs = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProdutos = New System.Windows.Forms.TextBox()
        Me.txtOBS = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.dgContatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDados.SuspendLayout()
        Me.tabDados.SuspendLayout()
        Me.tabObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgContatos
        '
        Me.dgContatos.AllowUserToAddRows = False
        Me.dgContatos.AllowUserToDeleteRows = False
        Me.dgContatos.AllowUserToOrderColumns = True
        Me.dgContatos.AllowUserToResizeRows = False
        Me.dgContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContatos.Location = New System.Drawing.Point(12, 12)
        Me.dgContatos.MultiSelect = False
        Me.dgContatos.Name = "dgContatos"
        Me.dgContatos.ReadOnly = True
        Me.dgContatos.RowHeadersWidth = 20
        Me.dgContatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgContatos.Size = New System.Drawing.Size(598, 169)
        Me.dgContatos.TabIndex = 0
        '
        'tbDados
        '
        Me.tbDados.Controls.Add(Me.tabDados)
        Me.tbDados.Controls.Add(Me.tabObs)
        Me.tbDados.Location = New System.Drawing.Point(12, 187)
        Me.tbDados.Name = "tbDados"
        Me.tbDados.SelectedIndex = 0
        Me.tbDados.Size = New System.Drawing.Size(598, 222)
        Me.tbDados.TabIndex = 1
        '
        'tabDados
        '
        Me.tabDados.Controls.Add(Me.txtData)
        Me.tabDados.Controls.Add(Me.Label8)
        Me.tabDados.Controls.Add(Me.txtAssunto)
        Me.tabDados.Controls.Add(Me.txtSite)
        Me.tabDados.Controls.Add(Me.Label7)
        Me.tabDados.Controls.Add(Me.Label6)
        Me.tabDados.Controls.Add(Me.txtEmail)
        Me.tabDados.Controls.Add(Me.txtFax)
        Me.tabDados.Controls.Add(Me.Label5)
        Me.tabDados.Controls.Add(Me.txtCelular)
        Me.tabDados.Controls.Add(Me.Label4)
        Me.tabDados.Controls.Add(Me.Label3)
        Me.tabDados.Controls.Add(Me.Label2)
        Me.tabDados.Controls.Add(Me.Label1)
        Me.tabDados.Controls.Add(Me.txtFone)
        Me.tabDados.Controls.Add(Me.txtEntidade)
        Me.tabDados.Controls.Add(Me.txtNome)
        Me.tabDados.Location = New System.Drawing.Point(4, 22)
        Me.tabDados.Name = "tabDados"
        Me.tabDados.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDados.Size = New System.Drawing.Size(590, 196)
        Me.tabDados.TabIndex = 0
        Me.tabDados.Text = "Dados"
        Me.tabDados.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.CustomFormat = "dd/MM/yyyy"
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(466, 6)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(6, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Assunto:"
        '
        'txtAssunto
        '
        Me.txtAssunto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAssunto.Location = New System.Drawing.Point(110, 6)
        Me.txtAssunto.MaxLength = 80
        Me.txtAssunto.Name = "txtAssunto"
        Me.txtAssunto.Size = New System.Drawing.Size(337, 20)
        Me.txtAssunto.TabIndex = 0
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(110, 142)
        Me.txtSite.MaxLength = 50
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(181, 20)
        Me.txtSite.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Site:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "E-Mail:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(110, 113)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(181, 20)
        Me.txtEmail.TabIndex = 6
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(347, 113)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(100, 20)
        Me.txtFax.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(299, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fax:"
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(347, 84)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(100, 20)
        Me.txtCelular.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Celular:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fone:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Empresa/Entidade:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nome:"
        '
        'txtFone
        '
        Me.txtFone.Location = New System.Drawing.Point(110, 84)
        Me.txtFone.MaxLength = 30
        Me.txtFone.Name = "txtFone"
        Me.txtFone.Size = New System.Drawing.Size(100, 20)
        Me.txtFone.TabIndex = 4
        '
        'txtEntidade
        '
        Me.txtEntidade.Location = New System.Drawing.Point(110, 58)
        Me.txtEntidade.MaxLength = 80
        Me.txtEntidade.Name = "txtEntidade"
        Me.txtEntidade.Size = New System.Drawing.Size(337, 20)
        Me.txtEntidade.TabIndex = 3
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(110, 32)
        Me.txtNome.MaxLength = 60
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(337, 20)
        Me.txtNome.TabIndex = 2
        '
        'tabObs
        '
        Me.tabObs.Controls.Add(Me.Label9)
        Me.tabObs.Controls.Add(Me.txtProdutos)
        Me.tabObs.Controls.Add(Me.txtOBS)
        Me.tabObs.Location = New System.Drawing.Point(4, 22)
        Me.tabObs.Name = "tabObs"
        Me.tabObs.Padding = New System.Windows.Forms.Padding(3)
        Me.tabObs.Size = New System.Drawing.Size(590, 196)
        Me.tabObs.TabIndex = 1
        Me.tabObs.Text = "Observações"
        Me.tabObs.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Produtos de Interesse:"
        '
        'txtProdutos
        '
        Me.txtProdutos.Location = New System.Drawing.Point(125, 170)
        Me.txtProdutos.MaxLength = 80
        Me.txtProdutos.Name = "txtProdutos"
        Me.txtProdutos.Size = New System.Drawing.Size(459, 20)
        Me.txtProdutos.TabIndex = 1
        '
        'txtOBS
        '
        Me.txtOBS.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOBS.Location = New System.Drawing.Point(6, 16)
        Me.txtOBS.Multiline = True
        Me.txtOBS.Name = "txtOBS"
        Me.txtOBS.Size = New System.Drawing.Size(578, 148)
        Me.txtOBS.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(373, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Novo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(454, 415)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(535, 415)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmContatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 447)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbDados)
        Me.Controls.Add(Me.dgContatos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContatos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contatos com Clientes"
        CType(Me.dgContatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDados.ResumeLayout(False)
        Me.tabDados.ResumeLayout(False)
        Me.tabDados.PerformLayout()
        Me.tabObs.ResumeLayout(False)
        Me.tabObs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgContatos As System.Windows.Forms.DataGridView
    Friend WithEvents tbDados As System.Windows.Forms.TabControl
    Friend WithEvents tabDados As System.Windows.Forms.TabPage
    Friend WithEvents tabObs As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFone As System.Windows.Forms.TextBox
    Friend WithEvents txtEntidade As System.Windows.Forms.TextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAssunto As System.Windows.Forms.TextBox
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOBS As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProdutos As System.Windows.Forms.TextBox
End Class
