<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtiquetas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEtiquetas))
        Me.lstMercadoria = New System.Windows.Forms.ListBox()
        Me.lstLotes = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstFrascos = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Progress = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btTransfere = New System.Windows.Forms.Button()
        Me.btImpSel = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.MySqlConnectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblFrascos = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.grpFrascos = New System.Windows.Forms.GroupBox()
        CType(Me.MySqlConnectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFrascos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstMercadoria
        '
        Me.lstMercadoria.FormattingEnabled = True
        Me.lstMercadoria.Location = New System.Drawing.Point(12, 26)
        Me.lstMercadoria.Name = "lstMercadoria"
        Me.lstMercadoria.Size = New System.Drawing.Size(194, 95)
        Me.lstMercadoria.TabIndex = 0
        '
        'lstLotes
        '
        Me.lstLotes.FormattingEnabled = True
        Me.lstLotes.Location = New System.Drawing.Point(220, 26)
        Me.lstLotes.Name = "lstLotes"
        Me.lstLotes.Size = New System.Drawing.Size(140, 95)
        Me.lstLotes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selecione a Mercadoria"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Selecione o Lote"
        '
        'lstFrascos
        '
        Me.lstFrascos.FormattingEnabled = True
        Me.lstFrascos.Location = New System.Drawing.Point(12, 44)
        Me.lstFrascos.Name = "lstFrascos"
        Me.lstFrascos.Size = New System.Drawing.Size(142, 169)
        Me.lstFrascos.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Frascos Disponíveis no Lote"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(577, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.ForeColor = System.Drawing.Color.Blue
        Me.lblLote.Location = New System.Drawing.Point(468, 9)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(184, 24)
        Me.lblLote.TabIndex = 7
        Me.lblLote.Text = "Lote: 000.000.0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Frascos Selecionados"
        '
        'Progress
        '
        Me.Progress.Location = New System.Drawing.Point(263, 199)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(364, 14)
        Me.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Progress.TabIndex = 10
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Marca todos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(160, 73)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Desmarca todos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btTransfere
        '
        Me.btTransfere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTransfere.Location = New System.Drawing.Point(160, 131)
        Me.btTransfere.Name = "btTransfere"
        Me.btTransfere.Size = New System.Drawing.Size(97, 23)
        Me.btTransfere.TabIndex = 13
        Me.btTransfere.Text = ">>"
        Me.btTransfere.UseVisualStyleBackColor = True
        '
        'btImpSel
        '
        Me.btImpSel.Location = New System.Drawing.Point(160, 159)
        Me.btImpSel.Name = "btImpSel"
        Me.btImpSel.Size = New System.Drawing.Size(97, 23)
        Me.btImpSel.TabIndex = 14
        Me.btImpSel.Text = "Imprime Seleção"
        Me.btImpSel.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(160, 188)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 23)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "Limpa Seleção"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'MySqlConnectionBindingSource
        '
        Me.MySqlConnectionBindingSource.DataSource = GetType(MySql.Data.MySqlClient.MySqlConnection)
        '
        'dgFrascos
        '
        Me.dgFrascos.AllowUserToAddRows = False
        Me.dgFrascos.AllowUserToDeleteRows = False
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Location = New System.Drawing.Point(263, 43)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.ReadOnly = True
        Me.dgFrascos.Size = New System.Drawing.Size(364, 150)
        Me.dgFrascos.TabIndex = 16
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(469, 20)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 13)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Etiquetas Selecionadas:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFrascos
        '
        Me.lblFrascos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrascos.Location = New System.Drawing.Point(596, 20)
        Me.lblFrascos.Name = "lblFrascos"
        Me.lblFrascos.Size = New System.Drawing.Size(31, 13)
        Me.lblFrascos.TabIndex = 18
        Me.lblFrascos.Text = "0"
        Me.lblFrascos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(160, 102)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(97, 23)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "Não Impressos"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(552, 218)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 25)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Atualiza"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.Location = New System.Drawing.Point(12, 381)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(534, 18)
        Me.lblMsg.TabIndex = 21
        Me.lblMsg.Text = "..."
        '
        'grpFrascos
        '
        Me.grpFrascos.Controls.Add(Me.Label3)
        Me.grpFrascos.Controls.Add(Me.lstFrascos)
        Me.grpFrascos.Controls.Add(Me.Button4)
        Me.grpFrascos.Controls.Add(Me.Label5)
        Me.grpFrascos.Controls.Add(Me.Button7)
        Me.grpFrascos.Controls.Add(Me.Progress)
        Me.grpFrascos.Controls.Add(Me.lblFrascos)
        Me.grpFrascos.Controls.Add(Me.Button2)
        Me.grpFrascos.Controls.Add(Me.Label25)
        Me.grpFrascos.Controls.Add(Me.Button3)
        Me.grpFrascos.Controls.Add(Me.dgFrascos)
        Me.grpFrascos.Controls.Add(Me.btTransfere)
        Me.grpFrascos.Controls.Add(Me.Button6)
        Me.grpFrascos.Controls.Add(Me.btImpSel)
        Me.grpFrascos.Location = New System.Drawing.Point(12, 127)
        Me.grpFrascos.Name = "grpFrascos"
        Me.grpFrascos.Size = New System.Drawing.Size(640, 251)
        Me.grpFrascos.TabIndex = 22
        Me.grpFrascos.TabStop = False
        Me.grpFrascos.Text = " Dados dos Frascos "
        '
        'frmEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 405)
        Me.Controls.Add(Me.grpFrascos)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblLote)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstLotes)
        Me.Controls.Add(Me.lstMercadoria)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEtiquetas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ipressão de Etiquetas"
        CType(Me.MySqlConnectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFrascos.ResumeLayout(False)
        Me.grpFrascos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstMercadoria As System.Windows.Forms.ListBox
    Friend WithEvents lstLotes As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstFrascos As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Progress As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btTransfere As System.Windows.Forms.Button
    Friend WithEvents btImpSel As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents MySqlConnectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblFrascos As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents grpFrascos As GroupBox
End Class
