<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlteracaoLote
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
        Me.lstMercadoria = New System.Windows.Forms.ListBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lstLotes = New System.Windows.Forms.ListBox()
        Me.btIr = New System.Windows.Forms.Button()
        Me.txtCodigoLote = New System.Windows.Forms.TextBox()
        Me.rdCodigo = New System.Windows.Forms.RadioButton()
        Me.rdId = New System.Windows.Forms.RadioButton()
        Me.btGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstMercadoria
        '
        Me.lstMercadoria.FormattingEnabled = True
        Me.lstMercadoria.Location = New System.Drawing.Point(12, 130)
        Me.lstMercadoria.Name = "lstMercadoria"
        Me.lstMercadoria.Size = New System.Drawing.Size(196, 121)
        Me.lstMercadoria.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 109)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(119, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Selecione a Mercadoria"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(118, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Digite o Código do Lote"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 85)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(25, 13)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "OU"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(9, 259)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(87, 13)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "Selecione o Lote"
        '
        'lstLotes
        '
        Me.lstLotes.FormattingEnabled = True
        Me.lstLotes.Location = New System.Drawing.Point(12, 280)
        Me.lstLotes.Name = "lstLotes"
        Me.lstLotes.Size = New System.Drawing.Size(196, 121)
        Me.lstLotes.TabIndex = 5
        '
        'btIr
        '
        Me.btIr.Location = New System.Drawing.Point(174, 31)
        Me.btIr.Name = "btIr"
        Me.btIr.Size = New System.Drawing.Size(34, 26)
        Me.btIr.TabIndex = 1
        Me.btIr.Text = "Ir"
        Me.btIr.UseVisualStyleBackColor = True
        '
        'txtCodigoLote
        '
        Me.txtCodigoLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoLote.Location = New System.Drawing.Point(15, 30)
        Me.txtCodigoLote.MaxLength = 14
        Me.txtCodigoLote.Name = "txtCodigoLote"
        Me.txtCodigoLote.Size = New System.Drawing.Size(153, 26)
        Me.txtCodigoLote.TabIndex = 0
        Me.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdCodigo
        '
        Me.rdCodigo.AutoSize = True
        Me.rdCodigo.Checked = True
        Me.rdCodigo.Location = New System.Drawing.Point(15, 62)
        Me.rdCodigo.Name = "rdCodigo"
        Me.rdCodigo.Size = New System.Drawing.Size(58, 17)
        Me.rdCodigo.TabIndex = 2
        Me.rdCodigo.TabStop = True
        Me.rdCodigo.Text = "Código"
        Me.rdCodigo.UseVisualStyleBackColor = True
        '
        'rdId
        '
        Me.rdId.AutoSize = True
        Me.rdId.Location = New System.Drawing.Point(78, 62)
        Me.rdId.Name = "rdId"
        Me.rdId.Size = New System.Drawing.Size(36, 17)
        Me.rdId.TabIndex = 3
        Me.rdId.Text = "ID"
        Me.rdId.UseVisualStyleBackColor = True
        '
        'btGo
        '
        Me.btGo.Location = New System.Drawing.Point(133, 407)
        Me.btGo.Name = "btGo"
        Me.btGo.Size = New System.Drawing.Size(75, 23)
        Me.btGo.TabIndex = 9
        Me.btGo.Text = ">>"
        Me.btGo.UseVisualStyleBackColor = True
        '
        'frmAlteracaoLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 506)
        Me.Controls.Add(Me.btGo)
        Me.Controls.Add(Me.rdId)
        Me.Controls.Add(Me.rdCodigo)
        Me.Controls.Add(Me.txtCodigoLote)
        Me.Controls.Add(Me.btIr)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.lstLotes)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lstMercadoria)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlteracaoLote"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Alteração de Lotes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstMercadoria As System.Windows.Forms.ListBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lstLotes As System.Windows.Forms.ListBox
    Friend WithEvents btIr As System.Windows.Forms.Button
    Friend WithEvents txtCodigoLote As System.Windows.Forms.TextBox
    Friend WithEvents rdCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdId As System.Windows.Forms.RadioButton
    Friend WithEvents btGo As Button
End Class
