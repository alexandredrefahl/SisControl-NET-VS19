<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoricos
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
        Me.cmbHistorico = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpHistorico = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCTDeb = New System.Windows.Forms.Label()
        Me.lblCTCred = New System.Windows.Forms.Label()
        Me.txtCTDeb = New System.Windows.Forms.TextBox()
        Me.txtCTCred = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btNovo = New System.Windows.Forms.Button()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.btIncluir = New System.Windows.Forms.Button()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.pnlContas = New System.Windows.Forms.Panel()
        Me.dgContas = New System.Windows.Forms.DataGridView()
        Me.lblContas = New System.Windows.Forms.Label()
        Me.grpHistorico.SuspendLayout()
        Me.pnlContas.SuspendLayout()
        CType(Me.dgContas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbHistorico
        '
        Me.cmbHistorico.DropDownHeight = 85
        Me.cmbHistorico.FormattingEnabled = True
        Me.cmbHistorico.IntegralHeight = False
        Me.cmbHistorico.Location = New System.Drawing.Point(128, 12)
        Me.cmbHistorico.Name = "cmbHistorico"
        Me.cmbHistorico.Size = New System.Drawing.Size(359, 21)
        Me.cmbHistorico.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selecione o Histórico:"
        '
        'grpHistorico
        '
        Me.grpHistorico.Controls.Add(Me.Label6)
        Me.grpHistorico.Controls.Add(Me.Label5)
        Me.grpHistorico.Controls.Add(Me.lblCTDeb)
        Me.grpHistorico.Controls.Add(Me.lblCTCred)
        Me.grpHistorico.Controls.Add(Me.txtCTDeb)
        Me.grpHistorico.Controls.Add(Me.txtCTCred)
        Me.grpHistorico.Controls.Add(Me.txtDescricao)
        Me.grpHistorico.Controls.Add(Me.Label2)
        Me.grpHistorico.Location = New System.Drawing.Point(12, 39)
        Me.grpHistorico.Name = "grpHistorico"
        Me.grpHistorico.Size = New System.Drawing.Size(475, 127)
        Me.grpHistorico.TabIndex = 2
        Me.grpHistorico.TabStop = False
        Me.grpHistorico.Text = " Dados do Histórico "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Conta de Débito:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Conta de Crédito:"
        '
        'lblCTDeb
        '
        Me.lblCTDeb.AutoSize = True
        Me.lblCTDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTDeb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTDeb.Location = New System.Drawing.Point(166, 86)
        Me.lblCTDeb.Name = "lblCTDeb"
        Me.lblCTDeb.Size = New System.Drawing.Size(19, 13)
        Me.lblCTDeb.TabIndex = 5
        Me.lblCTDeb.Text = "..."
        '
        'lblCTCred
        '
        Me.lblCTCred.AutoSize = True
        Me.lblCTCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTCred.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCTCred.Location = New System.Drawing.Point(166, 60)
        Me.lblCTCred.Name = "lblCTCred"
        Me.lblCTCred.Size = New System.Drawing.Size(19, 13)
        Me.lblCTCred.TabIndex = 4
        Me.lblCTCred.Text = "..."
        '
        'txtCTDeb
        '
        Me.txtCTDeb.Location = New System.Drawing.Point(112, 83)
        Me.txtCTDeb.Name = "txtCTDeb"
        Me.txtCTDeb.Size = New System.Drawing.Size(48, 20)
        Me.txtCTDeb.TabIndex = 3
        Me.txtCTDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCTCred
        '
        Me.txtCTCred.Location = New System.Drawing.Point(112, 57)
        Me.txtCTCred.Name = "txtCTCred"
        Me.txtCTCred.Size = New System.Drawing.Size(48, 20)
        Me.txtCTCred.TabIndex = 2
        Me.txtCTCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(112, 31)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(344, 20)
        Me.txtDescricao.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrição:"
        '
        'btNovo
        '
        Me.btNovo.Location = New System.Drawing.Point(250, 172)
        Me.btNovo.Name = "btNovo"
        Me.btNovo.Size = New System.Drawing.Size(75, 23)
        Me.btNovo.TabIndex = 3
        Me.btNovo.Text = "Editar"
        Me.btNovo.UseVisualStyleBackColor = True
        '
        'btCancela
        '
        Me.btCancela.Location = New System.Drawing.Point(412, 172)
        Me.btCancela.Name = "btCancela"
        Me.btCancela.Size = New System.Drawing.Size(75, 23)
        Me.btCancela.TabIndex = 4
        Me.btCancela.Text = "Sair"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(169, 172)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btIncluir.TabIndex = 5
        Me.btIncluir.Text = "Incluir"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'btExcluir
        '
        Me.btExcluir.Location = New System.Drawing.Point(331, 172)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 6
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'pnlContas
        '
        Me.pnlContas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContas.Controls.Add(Me.dgContas)
        Me.pnlContas.Controls.Add(Me.lblContas)
        Me.pnlContas.Location = New System.Drawing.Point(181, 12)
        Me.pnlContas.Name = "pnlContas"
        Me.pnlContas.Size = New System.Drawing.Size(306, 182)
        Me.pnlContas.TabIndex = 7
        '
        'dgContas
        '
        Me.dgContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContas.Location = New System.Drawing.Point(11, 27)
        Me.dgContas.MultiSelect = False
        Me.dgContas.Name = "dgContas"
        Me.dgContas.RowHeadersWidth = 20
        Me.dgContas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgContas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgContas.Size = New System.Drawing.Size(286, 144)
        Me.dgContas.TabIndex = 1
        '
        'lblContas
        '
        Me.lblContas.AutoSize = True
        Me.lblContas.Location = New System.Drawing.Point(9, 8)
        Me.lblContas.Name = "lblContas"
        Me.lblContas.Size = New System.Drawing.Size(40, 13)
        Me.lblContas.TabIndex = 0
        Me.lblContas.Text = "Contas"
        '
        'frmHistoricos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 206)
        Me.Controls.Add(Me.pnlContas)
        Me.Controls.Add(Me.btExcluir)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.btCancela)
        Me.Controls.Add(Me.btNovo)
        Me.Controls.Add(Me.grpHistorico)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbHistorico)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistoricos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Históricos Contábeis"
        Me.grpHistorico.ResumeLayout(False)
        Me.grpHistorico.PerformLayout()
        Me.pnlContas.ResumeLayout(False)
        Me.pnlContas.PerformLayout()
        CType(Me.dgContas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbHistorico As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpHistorico As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCTDeb As System.Windows.Forms.Label
    Friend WithEvents lblCTCred As System.Windows.Forms.Label
    Friend WithEvents txtCTDeb As System.Windows.Forms.TextBox
    Friend WithEvents txtCTCred As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btNovo As System.Windows.Forms.Button
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents btExcluir As System.Windows.Forms.Button
    Friend WithEvents pnlContas As System.Windows.Forms.Panel
    Friend WithEvents dgContas As System.Windows.Forms.DataGridView
    Friend WithEvents lblContas As System.Windows.Forms.Label
End Class
