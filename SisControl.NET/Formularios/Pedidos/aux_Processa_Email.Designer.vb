<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aux_Processa_Email
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
        Me.lstEmails = New System.Windows.Forms.ListBox()
        Me.btAdicionar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tsProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblVariedades = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtQtdePadrao = New System.Windows.Forms.TextBox()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstEmails
        '
        Me.lstEmails.FormattingEnabled = True
        Me.lstEmails.Location = New System.Drawing.Point(12, 12)
        Me.lstEmails.Name = "lstEmails"
        Me.lstEmails.Size = New System.Drawing.Size(350, 160)
        Me.lstEmails.TabIndex = 0
        '
        'btAdicionar
        '
        Me.btAdicionar.Location = New System.Drawing.Point(125, 178)
        Me.btAdicionar.Name = "btAdicionar"
        Me.btAdicionar.Size = New System.Drawing.Size(89, 23)
        Me.btAdicionar.TabIndex = 2
        Me.btAdicionar.Text = "Adicionar"
        Me.btAdicionar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Verificar E-mail"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Location = New System.Drawing.Point(145, 368)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(136, 17)
        Me.chkEmail.TabIndex = 9
        Me.chkEmail.Text = "Enviar E-mail p/ Cliente"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsProgress, Me.tsMsg})
        Me.ssStatus.Location = New System.Drawing.Point(0, 209)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(374, 22)
        Me.ssStatus.TabIndex = 6
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tsProgress
        '
        Me.tsProgress.Margin = New System.Windows.Forms.Padding(5, 3, 1, 3)
        Me.tsProgress.Name = "tsProgress"
        Me.tsProgress.Size = New System.Drawing.Size(100, 16)
        Me.tsProgress.Step = 1
        Me.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tsMsg
        '
        Me.tsMsg.Margin = New System.Windows.Forms.Padding(15, 3, 0, 2)
        Me.tsMsg.Name = "tsMsg"
        Me.tsMsg.Size = New System.Drawing.Size(16, 17)
        Me.tsMsg.Text = "..."
        Me.tsMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(61, 234)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(301, 20)
        Me.txtNome.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 237)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nome:"
        '
        'txtFone
        '
        Me.txtFone.Location = New System.Drawing.Point(61, 260)
        Me.txtFone.Name = "txtFone"
        Me.txtFone.Size = New System.Drawing.Size(158, 20)
        Me.txtFone.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Fone:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(61, 286)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(224, 20)
        Me.txtEmail.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "E-Mail:"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(61, 312)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(69, 20)
        Me.txtData.TabIndex = 6
        Me.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Data:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(287, 365)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Confirmar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblVariedades
        '
        Me.lblVariedades.AutoSize = True
        Me.lblVariedades.Location = New System.Drawing.Point(12, 368)
        Me.lblVariedades.Name = "lblVariedades"
        Me.lblVariedades.Size = New System.Drawing.Size(16, 13)
        Me.lblVariedades.TabIndex = 16
        Me.lblVariedades.Text = "..."
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(89, 338)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(41, 20)
        Me.txtValor.TabIndex = 7
        Me.txtValor.Text = "2,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Valor Padrão:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Quantidade Padrão:"
        '
        'txtQtdePadrao
        '
        Me.txtQtdePadrao.Location = New System.Drawing.Point(244, 338)
        Me.txtQtdePadrao.Name = "txtQtdePadrao"
        Me.txtQtdePadrao.Size = New System.Drawing.Size(41, 20)
        Me.txtQtdePadrao.TabIndex = 8
        Me.txtQtdePadrao.Text = "20"
        Me.txtQtdePadrao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'aux_Processa_Email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 231)
        Me.Controls.Add(Me.txtQtdePadrao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.lblVariedades)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFone)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.chkEmail)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btAdicionar)
        Me.Controls.Add(Me.lstEmails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "aux_Processa_Email"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Processar E-mails"
        Me.TopMost = True
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstEmails As ListBox
    Friend WithEvents btAdicionar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents chkEmail As CheckBox
    Friend WithEvents ssStatus As StatusStrip
    Friend WithEvents tsProgress As ToolStripProgressBar
    Friend WithEvents tsMsg As ToolStripStatusLabel
    Friend WithEvents txtNome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFone As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtData As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents lblVariedades As Label
    Friend WithEvents txtValor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtQtdePadrao As TextBox
End Class
