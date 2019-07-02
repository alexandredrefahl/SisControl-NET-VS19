<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrquideas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrquideas))
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtEspecie = New System.Windows.Forms.TextBox()
        Me.txtPolinizacao = New System.Windows.Forms.MaskedTextBox()
        Me.txtColheita = New System.Windows.Forms.MaskedTextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.cmbSituacao = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.cmbMeio = New System.Windows.Forms.ComboBox()
        Me.txtLote = New System.Windows.Forms.MaskedTextBox()
        Me.txtSemeadura = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNFrascos = New System.Windows.Forms.TextBox()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstRepicador = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEsperado = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        resources.ApplyResources(Me.txtCodigo, "txtCodigo")
        Me.txtCodigo.Name = "txtCodigo"
        '
        'txtEspecie
        '
        resources.ApplyResources(Me.txtEspecie, "txtEspecie")
        Me.txtEspecie.Name = "txtEspecie"
        '
        'txtPolinizacao
        '
        resources.ApplyResources(Me.txtPolinizacao, "txtPolinizacao")
        Me.txtPolinizacao.Name = "txtPolinizacao"
        Me.txtPolinizacao.ValidatingType = GetType(Date)
        '
        'txtColheita
        '
        resources.ApplyResources(Me.txtColheita, "txtColheita")
        Me.txtColheita.Name = "txtColheita"
        Me.txtColheita.ValidatingType = GetType(Date)
        '
        'txtDescricao
        '
        resources.ApplyResources(Me.txtDescricao, "txtDescricao")
        Me.txtDescricao.Name = "txtDescricao"
        '
        'cmbSituacao
        '
        Me.cmbSituacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSituacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSituacao.FormattingEnabled = True
        Me.cmbSituacao.Items.AddRange(New Object() {resources.GetString("cmbSituacao.Items"), resources.GetString("cmbSituacao.Items1")})
        resources.ApplyResources(Me.cmbSituacao, "cmbSituacao")
        Me.cmbSituacao.Name = "cmbSituacao"
        '
        'cmbEstado
        '
        Me.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {resources.GetString("cmbEstado.Items"), resources.GetString("cmbEstado.Items1"), resources.GetString("cmbEstado.Items2"), resources.GetString("cmbEstado.Items3"), resources.GetString("cmbEstado.Items4"), resources.GetString("cmbEstado.Items5"), resources.GetString("cmbEstado.Items6")})
        resources.ApplyResources(Me.cmbEstado, "cmbEstado")
        Me.cmbEstado.Name = "cmbEstado"
        '
        'cmbMeio
        '
        Me.cmbMeio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMeio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMeio.FormattingEnabled = True
        resources.ApplyResources(Me.cmbMeio, "cmbMeio")
        Me.cmbMeio.Name = "cmbMeio"
        '
        'txtLote
        '
        resources.ApplyResources(Me.txtLote, "txtLote")
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ValidatingType = GetType(Date)
        '
        'txtSemeadura
        '
        resources.ApplyResources(Me.txtSemeadura, "txtSemeadura")
        Me.txtSemeadura.Name = "txtSemeadura"
        Me.txtSemeadura.ValidatingType = GetType(Date)
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Name = "Label10"
        '
        'btIncluir
        '
        resources.ApplyResources(Me.btIncluir, "btIncluir")
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'btCancela
        '
        resources.ApplyResources(Me.btCancela, "btCancela")
        Me.btCancela.Name = "btCancela"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Name = "Label11"
        '
        'txtNFrascos
        '
        resources.ApplyResources(Me.txtNFrascos, "txtNFrascos")
        Me.txtNFrascos.Name = "txtNFrascos"
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.FormattingEnabled = True
        resources.ApplyResources(Me.cmbClientes, "cmbClientes")
        Me.cmbClientes.Name = "cmbClientes"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Name = "Label12"
        '
        'lstRepicador
        '
        Me.lstRepicador.FormattingEnabled = True
        resources.ApplyResources(Me.lstRepicador, "lstRepicador")
        Me.lstRepicador.Name = "lstRepicador"
        Me.lstRepicador.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'txtEsperado
        '
        resources.ApplyResources(Me.txtEsperado, "txtEsperado")
        Me.txtEsperado.Name = "txtEsperado"
        '
        'frmOrquideas
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtEsperado)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lstRepicador)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbClientes)
        Me.Controls.Add(Me.txtNFrascos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btCancela)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSemeadura)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.cmbMeio)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbSituacao)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtColheita)
        Me.Controls.Add(Me.txtPolinizacao)
        Me.Controls.Add(Me.txtEspecie)
        Me.Controls.Add(Me.txtCodigo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrquideas"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtEspecie As System.Windows.Forms.TextBox
    Friend WithEvents txtPolinizacao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtColheita As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents cmbSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMeio As System.Windows.Forms.ComboBox
    Friend WithEvents txtLote As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSemeadura As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNFrascos As System.Windows.Forms.TextBox
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstRepicador As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEsperado As System.Windows.Forms.TextBox
End Class
