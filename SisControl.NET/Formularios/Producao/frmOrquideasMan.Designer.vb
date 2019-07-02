<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrquideasMan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbLotes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSemeadura = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPlt = New System.Windows.Forms.Label()
        Me.lblMds = New System.Windows.Forms.Label()
        Me.lblSem = New System.Windows.Forms.Label()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.lblEspecie = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpProducao = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNMudas = New System.Windows.Forms.TextBox()
        Me.txtNFrascos = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lstRepicador = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgFrascos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSementes = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.grpProducao.SuspendLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbLotes
        '
        Me.cmbLotes.FormattingEnabled = True
        Me.cmbLotes.Location = New System.Drawing.Point(113, 20)
        Me.cmbLotes.Name = "cmbLotes"
        Me.cmbLotes.Size = New System.Drawing.Size(157, 21)
        Me.cmbLotes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Lotes Disponíveis:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSemeadura)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblPlt)
        Me.GroupBox1.Controls.Add(Me.lblMds)
        Me.GroupBox1.Controls.Add(Me.lblSem)
        Me.GroupBox1.Controls.Add(Me.lblDescricao)
        Me.GroupBox1.Controls.Add(Me.lblEspecie)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 85)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Informações do Lote "
        '
        'lblSemeadura
        '
        Me.lblSemeadura.AutoSize = True
        Me.lblSemeadura.Location = New System.Drawing.Point(70, 58)
        Me.lblSemeadura.Name = "lblSemeadura"
        Me.lblSemeadura.Size = New System.Drawing.Size(16, 13)
        Me.lblSemeadura.TabIndex = 12
        Me.lblSemeadura.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Semeadura:"
        '
        'lblPlt
        '
        Me.lblPlt.AutoSize = True
        Me.lblPlt.Location = New System.Drawing.Point(315, 58)
        Me.lblPlt.Name = "lblPlt"
        Me.lblPlt.Size = New System.Drawing.Size(16, 13)
        Me.lblPlt.TabIndex = 10
        Me.lblPlt.Text = "..."
        '
        'lblMds
        '
        Me.lblMds.AutoSize = True
        Me.lblMds.Location = New System.Drawing.Point(315, 39)
        Me.lblMds.Name = "lblMds"
        Me.lblMds.Size = New System.Drawing.Size(16, 13)
        Me.lblMds.TabIndex = 9
        Me.lblMds.Text = "..."
        '
        'lblSem
        '
        Me.lblSem.AutoSize = True
        Me.lblSem.Location = New System.Drawing.Point(315, 21)
        Me.lblSem.Name = "lblSem"
        Me.lblSem.Size = New System.Drawing.Size(16, 13)
        Me.lblSem.TabIndex = 8
        Me.lblSem.Text = "..."
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(70, 39)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(16, 13)
        Me.lblDescricao.TabIndex = 7
        Me.lblDescricao.Text = "..."
        '
        'lblEspecie
        '
        Me.lblEspecie.AutoSize = True
        Me.lblEspecie.Location = New System.Drawing.Point(70, 21)
        Me.lblEspecie.Name = "lblEspecie"
        Me.lblEspecie.Size = New System.Drawing.Size(16, 13)
        Me.lblEspecie.TabIndex = 6
        Me.lblEspecie.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Estoque Plantadas:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(213, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Estoque Mudas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Estoque Sementes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Descrição:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Espécie:"
        '
        'grpProducao
        '
        Me.grpProducao.Controls.Add(Me.Label14)
        Me.grpProducao.Controls.Add(Me.Label13)
        Me.grpProducao.Controls.Add(Me.txtNMudas)
        Me.grpProducao.Controls.Add(Me.txtNFrascos)
        Me.grpProducao.Controls.Add(Me.Button3)
        Me.grpProducao.Controls.Add(Me.Label12)
        Me.grpProducao.Controls.Add(Me.Label10)
        Me.grpProducao.Controls.Add(Me.lstRepicador)
        Me.grpProducao.Controls.Add(Me.Label9)
        Me.grpProducao.Controls.Add(Me.txtData)
        Me.grpProducao.Controls.Add(Me.Label8)
        Me.grpProducao.Controls.Add(Me.dgFrascos)
        Me.grpProducao.Controls.Add(Me.txtSementes)
        Me.grpProducao.Controls.Add(Me.Label4)
        Me.grpProducao.Location = New System.Drawing.Point(15, 156)
        Me.grpProducao.Name = "grpProducao"
        Me.grpProducao.Size = New System.Drawing.Size(426, 292)
        Me.grpProducao.TabIndex = 3
        Me.grpProducao.TabStop = False
        Me.grpProducao.Text = " Informações de Produção "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(270, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 12)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Nº Mudas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(213, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Nº Vidros"
        '
        'txtNMudas
        '
        Me.txtNMudas.Location = New System.Drawing.Point(269, 93)
        Me.txtNMudas.Name = "txtNMudas"
        Me.txtNMudas.Size = New System.Drawing.Size(43, 20)
        Me.txtNMudas.TabIndex = 5
        Me.txtNMudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNFrascos
        '
        Me.txtNFrascos.Location = New System.Drawing.Point(212, 93)
        Me.txtNFrascos.Name = "txtNFrascos"
        Me.txtNFrascos.Size = New System.Drawing.Size(43, 20)
        Me.txtNFrascos.TabIndex = 4
        Me.txtNFrascos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(323, 93)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(38, 20)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "OK"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(213, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Inclusão Massal:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Repicador:"
        '
        'lstRepicador
        '
        Me.lstRepicador.FormattingEnabled = True
        Me.lstRepicador.Location = New System.Drawing.Point(215, 143)
        Me.lstRepicador.Name = "lstRepicador"
        Me.lstRepicador.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstRepicador.Size = New System.Drawing.Size(199, 134)
        Me.lstRepicador.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(212, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Data da repicagem:"
        '
        'txtData
        '
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(318, 24)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 3
        Me.txtData.Value = New Date(2010, 7, 12, 11, 16, 30, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Frascos de Mudas:"
        '
        'dgFrascos
        '
        Me.dgFrascos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFrascos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgFrascos.Location = New System.Drawing.Point(9, 73)
        Me.dgFrascos.Name = "dgFrascos"
        Me.dgFrascos.Size = New System.Drawing.Size(166, 207)
        Me.dgFrascos.TabIndex = 2
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Nº Mudas"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'txtSementes
        '
        Me.txtSementes.Location = New System.Drawing.Point(144, 27)
        Me.txtSementes.Name = "txtSementes"
        Me.txtSementes.Size = New System.Drawing.Size(31, 20)
        Me.txtSementes.TabIndex = 1
        Me.txtSementes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Frascos de Sementes:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 454)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Confirmar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(366, 454)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblID.Location = New System.Drawing.Point(422, 23)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(19, 15)
        Me.lblID.TabIndex = 13
        Me.lblID.Text = "..."
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmOrquideasMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 483)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpProducao)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLotes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrquideasMan"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Orquídeas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpProducao.ResumeLayout(False)
        Me.grpProducao.PerformLayout()
        CType(Me.dgFrascos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbLotes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlt As System.Windows.Forms.Label
    Friend WithEvents lblMds As System.Windows.Forms.Label
    Friend WithEvents lblSem As System.Windows.Forms.Label
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents lblEspecie As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpProducao As System.Windows.Forms.GroupBox
    Friend WithEvents dgFrascos As System.Windows.Forms.DataGridView
    Friend WithEvents txtSementes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lstRepicador As System.Windows.Forms.ListBox
    Friend WithEvents lblSemeadura As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNMudas As System.Windows.Forms.TextBox
    Friend WithEvents txtNFrascos As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
End Class
