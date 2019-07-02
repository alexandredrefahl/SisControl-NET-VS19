<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizaLancamentos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisualizaLancamentos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSub = New System.Windows.Forms.CheckBox()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.txtConta = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgLancamentos = New System.Windows.Forms.DataGridView()
        Me.grpResumo = New System.Windows.Forms.GroupBox()
        Me.txtSaldoATU = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSaldoANT = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDebitos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCreditos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.btPrint = New System.Windows.Forms.Button()
        Me.txtDataINI = New System.Windows.Forms.DateTimePicker()
        Me.txtDataFIM = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResumo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataFIM)
        Me.GroupBox1.Controls.Add(Me.txtDataINI)
        Me.GroupBox1.Controls.Add(Me.chkSub)
        Me.GroupBox1.Controls.Add(Me.btFiltrar)
        Me.GroupBox1.Controls.Add(Me.txtConta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 54)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Informações "
        '
        'chkSub
        '
        Me.chkSub.AutoSize = True
        Me.chkSub.Checked = True
        Me.chkSub.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSub.Location = New System.Drawing.Point(120, 21)
        Me.chkSub.Name = "chkSub"
        Me.chkSub.Size = New System.Drawing.Size(112, 17)
        Me.chkSub.TabIndex = 1
        Me.chkSub.Text = "Incluir Sub Contas"
        Me.chkSub.UseVisualStyleBackColor = True
        '
        'btFiltrar
        '
        Me.btFiltrar.Image = CType(resources.GetObject("btFiltrar.Image"), System.Drawing.Image)
        Me.btFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btFiltrar.Location = New System.Drawing.Point(557, 18)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(89, 23)
        Me.btFiltrar.TabIndex = 4
        Me.btFiltrar.Text = "Filtrar"
        Me.btFiltrar.UseVisualStyleBackColor = True
        '
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(58, 19)
        Me.txtConta.Mask = "9.99.999"
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(56, 20)
        Me.txtConta.TabIndex = 0
        Me.txtConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTips.SetToolTip(Me.txtConta, "Deixe em branco para exibir todas as contas")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(379, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "até:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "De:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Conta:"
        '
        'dgLancamentos
        '
        Me.dgLancamentos.AllowUserToAddRows = False
        Me.dgLancamentos.AllowUserToDeleteRows = False
        Me.dgLancamentos.AllowUserToOrderColumns = True
        Me.dgLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancamentos.Location = New System.Drawing.Point(12, 72)
        Me.dgLancamentos.Name = "dgLancamentos"
        Me.dgLancamentos.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLancamentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLancamentos.RowHeadersWidth = 25
        Me.dgLancamentos.RowTemplate.Height = 20
        Me.dgLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancamentos.Size = New System.Drawing.Size(710, 262)
        Me.dgLancamentos.TabIndex = 1
        '
        'grpResumo
        '
        Me.grpResumo.Controls.Add(Me.txtSaldoATU)
        Me.grpResumo.Controls.Add(Me.Label7)
        Me.grpResumo.Controls.Add(Me.txtSaldoANT)
        Me.grpResumo.Controls.Add(Me.Label6)
        Me.grpResumo.Controls.Add(Me.lblDebitos)
        Me.grpResumo.Controls.Add(Me.Label5)
        Me.grpResumo.Controls.Add(Me.lblCreditos)
        Me.grpResumo.Controls.Add(Me.Label4)
        Me.grpResumo.Location = New System.Drawing.Point(12, 340)
        Me.grpResumo.Name = "grpResumo"
        Me.grpResumo.Size = New System.Drawing.Size(710, 56)
        Me.grpResumo.TabIndex = 2
        Me.grpResumo.TabStop = False
        Me.grpResumo.Text = " Informações da Conta "
        '
        'txtSaldoATU
        '
        Me.txtSaldoATU.AutoSize = True
        Me.txtSaldoATU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoATU.Location = New System.Drawing.Point(611, 28)
        Me.txtSaldoATU.Name = "txtSaldoATU"
        Me.txtSaldoATU.Size = New System.Drawing.Size(32, 13)
        Me.txtSaldoATU.TabIndex = 7
        Me.txtSaldoATU.Text = "0,00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(529, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Saldo Atual:"
        '
        'txtSaldoANT
        '
        Me.txtSaldoANT.AutoSize = True
        Me.txtSaldoANT.Location = New System.Drawing.Point(96, 28)
        Me.txtSaldoANT.Name = "txtSaldoANT"
        Me.txtSaldoANT.Size = New System.Drawing.Size(28, 13)
        Me.txtSaldoANT.TabIndex = 5
        Me.txtSaldoANT.Text = "0,00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Saldo Anterior:"
        '
        'lblDebitos
        '
        Me.lblDebitos.AutoSize = True
        Me.lblDebitos.Location = New System.Drawing.Point(444, 28)
        Me.lblDebitos.Name = "lblDebitos"
        Me.lblDebitos.Size = New System.Drawing.Size(28, 13)
        Me.lblDebitos.TabIndex = 3
        Me.lblDebitos.Text = "0,00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Total de Débitos:"
        '
        'lblCreditos
        '
        Me.lblCreditos.AutoSize = True
        Me.lblCreditos.Location = New System.Drawing.Point(269, 28)
        Me.lblCreditos.Name = "lblCreditos"
        Me.lblCreditos.Size = New System.Drawing.Size(28, 13)
        Me.lblCreditos.TabIndex = 1
        Me.lblCreditos.Text = "0,00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total de Créditos:"
        '
        'btPrint
        '
        Me.btPrint.Image = CType(resources.GetObject("btPrint.Image"), System.Drawing.Image)
        Me.btPrint.Location = New System.Drawing.Point(675, 18)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(47, 47)
        Me.btPrint.TabIndex = 1
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'txtDataINI
        '
        Me.txtDataINI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataINI.Location = New System.Drawing.Point(278, 19)
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(95, 20)
        Me.txtDataINI.TabIndex = 2
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataFIM.Location = New System.Drawing.Point(410, 19)
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(95, 20)
        Me.txtDataFIM.TabIndex = 3
        '
        'frmVisualizaLancamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 408)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.grpResumo)
        Me.Controls.Add(Me.dgLancamentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVisualizaLancamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualiza Lancamentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResumo.ResumeLayout(False)
        Me.grpResumo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgLancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents grpResumo As System.Windows.Forms.GroupBox
    Friend WithEvents txtConta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents chkSub As System.Windows.Forms.CheckBox
    Friend WithEvents lblDebitos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCreditos As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoATU As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoANT As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents txtDataFIM As DateTimePicker
    Friend WithEvents txtDataINI As DateTimePicker
End Class
