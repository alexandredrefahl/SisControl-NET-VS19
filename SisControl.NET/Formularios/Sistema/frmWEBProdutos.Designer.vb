<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWEBProdutos
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
        Me.lstProdutos = New System.Windows.Forms.ListBox
        Me.txtCientifico = New System.Windows.Forms.TextBox
        Me.txtPopular = New System.Windows.Forms.TextBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCategoria = New System.Windows.Forms.ComboBox
        Me.txtArquivo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btNovo = New System.Windows.Forms.Button
        Me.btEnviar = New System.Windows.Forms.Button
        Me.btSalvar = New System.Windows.Forms.Button
        Me.statusBAR = New System.Windows.Forms.StatusStrip
        Me.pnlMensagem = New System.Windows.Forms.ToolStripStatusLabel
        Me.dlgArquivo = New System.Windows.Forms.OpenFileDialog
        Me.statusBAR.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstProdutos
        '
        Me.lstProdutos.FormattingEnabled = True
        Me.lstProdutos.Location = New System.Drawing.Point(12, 12)
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.Size = New System.Drawing.Size(270, 95)
        Me.lstProdutos.TabIndex = 0
        '
        'txtCientifico
        '
        Me.txtCientifico.Location = New System.Drawing.Point(98, 144)
        Me.txtCientifico.Name = "txtCientifico"
        Me.txtCientifico.Size = New System.Drawing.Size(280, 20)
        Me.txtCientifico.TabIndex = 1
        '
        'txtPopular
        '
        Me.txtPopular.Location = New System.Drawing.Point(98, 170)
        Me.txtPopular.Name = "txtPopular"
        Me.txtPopular.Size = New System.Drawing.Size(280, 20)
        Me.txtPopular.TabIndex = 2
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(98, 196)
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(280, 81)
        Me.txtDescricao.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nome Científico"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nome Popular"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descrição"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Items.AddRange(New Object() {"Ornamentais", "Frutíferas", "Florestais"})
        Me.cmbCategoria.Location = New System.Drawing.Point(456, 199)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(144, 21)
        Me.cmbCategoria.TabIndex = 7
        '
        'txtArquivo
        '
        Me.txtArquivo.Location = New System.Drawing.Point(456, 144)
        Me.txtArquivo.Name = "txtArquivo"
        Me.txtArquivo.Size = New System.Drawing.Size(144, 20)
        Me.txtArquivo.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Categoria"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(398, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Foto"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(606, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(453, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Imagem JPEG de 114 x 150 px"
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(392, 254)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 23)
        Me.btNovo.TabIndex = 13
        Me.btNovo.Text = "&Novo"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'btEnviar
        '
        Me.btEnviar.Location = New System.Drawing.Point(554, 254)
        Me.btEnviar.Name = "btEnviar"
        Me.btEnviar.Size = New System.Drawing.Size(101, 23)
        Me.btEnviar.TabIndex = 14
        Me.btEnviar.Text = "&Enviar Cadastro"
        Me.btEnviar.UseVisualStyleBackColor = True
        '
        'btSalvar
        '
        Me.btSalvar.Location = New System.Drawing.Point(473, 254)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 15
        Me.btSalvar.Text = "&Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'statusBAR
        '
        Me.statusBAR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pnlMensagem})
        Me.statusBAR.Location = New System.Drawing.Point(0, 289)
        Me.statusBAR.Name = "statusBAR"
        Me.statusBAR.Size = New System.Drawing.Size(666, 22)
        Me.statusBAR.TabIndex = 16
        Me.statusBAR.Text = "StatusStrip1"
        '
        'pnlMensagem
        '
        Me.pnlMensagem.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.pnlMensagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pnlMensagem.Name = "pnlMensagem"
        Me.pnlMensagem.Size = New System.Drawing.Size(651, 17)
        Me.pnlMensagem.Spring = True
        Me.pnlMensagem.Text = "Teste 1 2 3 ..."
        Me.pnlMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgArquivo
        '
        Me.dlgArquivo.DefaultExt = "jpg"
        Me.dlgArquivo.Filter = "Arquivos de Imagem|*.jpg"
        Me.dlgArquivo.InitialDirectory = "c:\"
        Me.dlgArquivo.Title = "Carregar Foto"
        '
        'frmWEBProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 311)
        Me.Controls.Add(Me.statusBAR)
        Me.Controls.Add(Me.btSalvar)
        Me.Controls.Add(Me.btEnviar)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtArquivo)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtPopular)
        Me.Controls.Add(Me.txtCientifico)
        Me.Controls.Add(Me.lstProdutos)
        Me.KeyPreview = True
        Me.Name = "frmWEBProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Produtos - Site"
        Me.statusBAR.ResumeLayout(False)
        Me.statusBAR.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstProdutos As System.Windows.Forms.ListBox
    Friend WithEvents txtCientifico As System.Windows.Forms.TextBox
    Friend WithEvents txtPopular As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtArquivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btEnviar As System.Windows.Forms.Button
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents statusBAR As System.Windows.Forms.StatusStrip
    Friend WithEvents pnlMensagem As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dlgArquivo As System.Windows.Forms.OpenFileDialog
End Class
