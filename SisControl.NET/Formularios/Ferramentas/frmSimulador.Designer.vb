<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimulador
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
        Me.grpModo = New System.Windows.Forms.GroupBox()
        Me.rbTaxa = New System.Windows.Forms.RadioButton()
        Me.rbInicial = New System.Windows.Forms.RadioButton()
        Me.rbQtde = New System.Windows.Forms.RadioButton()
        Me.rbTempo = New System.Windows.Forms.RadioButton()
        Me.txtTempo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtQtde = New System.Windows.Forms.TextBox()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.txtMult = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grpModo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpModo
        '
        Me.grpModo.Controls.Add(Me.rbTaxa)
        Me.grpModo.Controls.Add(Me.rbInicial)
        Me.grpModo.Controls.Add(Me.rbQtde)
        Me.grpModo.Controls.Add(Me.rbTempo)
        Me.grpModo.Location = New System.Drawing.Point(12, 12)
        Me.grpModo.Name = "grpModo"
        Me.grpModo.Size = New System.Drawing.Size(358, 72)
        Me.grpModo.TabIndex = 0
        Me.grpModo.TabStop = False
        Me.grpModo.Text = " Selecione a Opção Desejada "
        '
        'rbTaxa
        '
        Me.rbTaxa.AutoSize = True
        Me.rbTaxa.Location = New System.Drawing.Point(180, 20)
        Me.rbTaxa.Name = "rbTaxa"
        Me.rbTaxa.Size = New System.Drawing.Size(161, 17)
        Me.rbTaxa.TabIndex = 3
        Me.rbTaxa.Text = "Simular taxa de multiplicação"
        Me.rbTaxa.UseVisualStyleBackColor = True
        '
        'rbInicial
        '
        Me.rbInicial.AutoSize = True
        Me.rbInicial.Location = New System.Drawing.Point(180, 43)
        Me.rbInicial.Name = "rbInicial"
        Me.rbInicial.Size = New System.Drawing.Size(144, 17)
        Me.rbInicial.TabIndex = 2
        Me.rbInicial.Text = "Simular quantidade inicial"
        Me.rbInicial.UseVisualStyleBackColor = True
        '
        'rbQtde
        '
        Me.rbQtde.AutoSize = True
        Me.rbQtde.Location = New System.Drawing.Point(17, 43)
        Me.rbQtde.Name = "rbQtde"
        Me.rbQtde.Size = New System.Drawing.Size(137, 17)
        Me.rbQtde.TabIndex = 1
        Me.rbQtde.Text = "Simular quantidade final"
        Me.rbQtde.UseVisualStyleBackColor = True
        '
        'rbTempo
        '
        Me.rbTempo.AutoSize = True
        Me.rbTempo.Checked = True
        Me.rbTempo.Location = New System.Drawing.Point(17, 19)
        Me.rbTempo.Name = "rbTempo"
        Me.rbTempo.Size = New System.Drawing.Size(95, 17)
        Me.rbTempo.TabIndex = 0
        Me.rbTempo.TabStop = True
        Me.rbTempo.Text = "Simular Tempo"
        Me.rbTempo.UseVisualStyleBackColor = True
        '
        'txtTempo
        '
        Me.txtTempo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtTempo.Location = New System.Drawing.Point(132, 96)
        Me.txtTempo.Name = "txtTempo"
        Me.txtTempo.Size = New System.Drawing.Size(67, 20)
        Me.txtTempo.TabIndex = 1
        Me.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tempo (Meses)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Quantidade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Inicial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Taxa Multiplicação"
        '
        'txtQtde
        '
        Me.txtQtde.Location = New System.Drawing.Point(132, 122)
        Me.txtQtde.Name = "txtQtde"
        Me.txtQtde.Size = New System.Drawing.Size(67, 20)
        Me.txtQtde.TabIndex = 7
        Me.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInicial
        '
        Me.txtInicial.Location = New System.Drawing.Point(132, 148)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(67, 20)
        Me.txtInicial.TabIndex = 8
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMult
        '
        Me.txtMult.Location = New System.Drawing.Point(132, 174)
        Me.txtMult.Name = "txtMult"
        Me.txtMult.Size = New System.Drawing.Size(67, 20)
        Me.txtMult.TabIndex = 10
        Me.txtMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(295, 143)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Limpar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(295, 174)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Calcular"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmSimulador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 212)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtMult)
        Me.Controls.Add(Me.txtInicial)
        Me.Controls.Add(Me.txtQtde)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTempo)
        Me.Controls.Add(Me.grpModo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSimulador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simulador de Cálculo"
        Me.grpModo.ResumeLayout(False)
        Me.grpModo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpModo As System.Windows.Forms.GroupBox
    Friend WithEvents rbTaxa As System.Windows.Forms.RadioButton
    Friend WithEvents rbInicial As System.Windows.Forms.RadioButton
    Friend WithEvents rbQtde As System.Windows.Forms.RadioButton
    Friend WithEvents rbTempo As System.Windows.Forms.RadioButton
    Friend WithEvents txtTempo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQtde As System.Windows.Forms.TextBox
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtMult As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
