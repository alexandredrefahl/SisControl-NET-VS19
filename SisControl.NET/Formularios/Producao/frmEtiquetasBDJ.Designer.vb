<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtiquetasBDJ
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
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lblFrascos = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btImpSel = New System.Windows.Forms.Button()
        Me.btTransfere = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Progress = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstFrascos = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstLotes = New System.Windows.Forms.ListBox()
        Me.lstMercadoria = New System.Windows.Forms.ListBox()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(162, 223)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(97, 23)
        Me.Button7.TabIndex = 38
        Me.Button7.Text = "Não Impressos"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'lblFrascos
        '
        Me.lblFrascos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrascos.Location = New System.Drawing.Point(533, 141)
        Me.lblFrascos.Name = "lblFrascos"
        Me.lblFrascos.Size = New System.Drawing.Size(31, 13)
        Me.lblFrascos.TabIndex = 37
        Me.lblFrascos.Text = "0"
        Me.lblFrascos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(409, 141)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 13)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "Etiquetas Selecionadas:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgFrascos
        '
        Me.dgFrascos.AllowUserToAddRows = False
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Location = New System.Drawing.Point(265, 164)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.Size = New System.Drawing.Size(299, 150)
        Me.dgFrascos.TabIndex = 35
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(162, 309)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 23)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "Limpa Seleção"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btImpSel
        '
        Me.btImpSel.Location = New System.Drawing.Point(162, 280)
        Me.btImpSel.Name = "btImpSel"
        Me.btImpSel.Size = New System.Drawing.Size(97, 23)
        Me.btImpSel.TabIndex = 33
        Me.btImpSel.Text = "Imprime Seleção"
        Me.btImpSel.UseVisualStyleBackColor = True
        '
        'btTransfere
        '
        Me.btTransfere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTransfere.Location = New System.Drawing.Point(162, 252)
        Me.btTransfere.Name = "btTransfere"
        Me.btTransfere.Size = New System.Drawing.Size(97, 23)
        Me.btTransfere.TabIndex = 32
        Me.btTransfere.Text = ">>"
        Me.btTransfere.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(162, 194)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 23)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Desmarca todos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(162, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Marca todos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Progress
        '
        Me.Progress.Location = New System.Drawing.Point(265, 320)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(299, 14)
        Me.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Progress.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Bandejas Selecionadas"
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.ForeColor = System.Drawing.Color.Blue
        Me.lblLote.Location = New System.Drawing.Point(433, 12)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(129, 24)
        Me.lblLote.TabIndex = 27
        Me.lblLote.Text = "Plantio: 0000"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(487, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Bandejas Disponíveis no Plantio"
        '
        'lstFrascos
        '
        Me.lstFrascos.FormattingEnabled = True
        Me.lstFrascos.Location = New System.Drawing.Point(14, 165)
        Me.lstFrascos.Name = "lstFrascos"
        Me.lstFrascos.Size = New System.Drawing.Size(142, 169)
        Me.lstFrascos.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Selecione o Plantio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Selecione a Mercadoria"
        '
        'lstLotes
        '
        Me.lstLotes.FormattingEnabled = True
        Me.lstLotes.Location = New System.Drawing.Point(222, 29)
        Me.lstLotes.Name = "lstLotes"
        Me.lstLotes.Size = New System.Drawing.Size(140, 95)
        Me.lstLotes.TabIndex = 21
        '
        'lstMercadoria
        '
        Me.lstMercadoria.FormattingEnabled = True
        Me.lstMercadoria.Location = New System.Drawing.Point(14, 29)
        Me.lstMercadoria.Name = "lstMercadoria"
        Me.lstMercadoria.Size = New System.Drawing.Size(194, 95)
        Me.lstMercadoria.TabIndex = 20
        '
        'frmEtiquetasBDJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 347)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.lblFrascos)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dgFrascos)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btImpSel)
        Me.Controls.Add(Me.btTransfere)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Progress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLote)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstFrascos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstLotes)
        Me.Controls.Add(Me.lstMercadoria)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEtiquetasBDJ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão Etiquetas para Bandejas"
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lblFrascos As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btImpSel As System.Windows.Forms.Button
    Friend WithEvents btTransfere As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Progress As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstFrascos As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstLotes As System.Windows.Forms.ListBox
    Friend WithEvents lstMercadoria As System.Windows.Forms.ListBox
End Class
