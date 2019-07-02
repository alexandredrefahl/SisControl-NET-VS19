<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManutLancam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManutLancam))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataFIM = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataINI = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgLancamentos = New System.Windows.Forms.DataGridView()
        Me.grpAcoes = New System.Windows.Forms.GroupBox()
        Me.btInverte = New System.Windows.Forms.Button()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.btAlterar = New System.Windows.Forms.Button()
        Me.grpAlteracao = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtContraparte = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHistorico = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDeb = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCred = New System.Windows.Forms.TextBox()
        Me.txtCDCOMP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCDRED = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.btUpdade = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAcoes.SuspendLayout()
        Me.grpAlteracao.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDataFIM)
        Me.GroupBox1.Controls.Add(Me.txtDataINI)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(821, 54)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Informações "
        '
        'btFiltrar
        '
        Me.btFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFiltrar.Image = CType(resources.GetObject("btFiltrar.Image"), System.Drawing.Image)
        Me.btFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btFiltrar.Location = New System.Drawing.Point(701, 19)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(114, 25)
        Me.btFiltrar.TabIndex = 2
        Me.btFiltrar.Text = "Filtrar"
        Me.btFiltrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "até:"
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Location = New System.Drawing.Point(141, 20)
        Me.txtDataFIM.Mask = "99/99/9999"
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(68, 20)
        Me.txtDataFIM.TabIndex = 1
        '
        'txtDataINI
        '
        Me.txtDataINI.Location = New System.Drawing.Point(36, 20)
        Me.txtDataINI.Mask = "99/99/9999"
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(68, 20)
        Me.txtDataINI.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "De:"
        '
        'dgLancamentos
        '
        Me.dgLancamentos.AllowUserToAddRows = False
        Me.dgLancamentos.AllowUserToDeleteRows = False
        Me.dgLancamentos.AllowUserToOrderColumns = True
        Me.dgLancamentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancamentos.Location = New System.Drawing.Point(12, 72)
        Me.dgLancamentos.Name = "dgLancamentos"
        Me.dgLancamentos.ReadOnly = True
        Me.dgLancamentos.RowHeadersWidth = 25
        Me.dgLancamentos.RowTemplate.Height = 20
        Me.dgLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancamentos.Size = New System.Drawing.Size(821, 262)
        Me.dgLancamentos.TabIndex = 0
        '
        'grpAcoes
        '
        Me.grpAcoes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAcoes.Controls.Add(Me.btInverte)
        Me.grpAcoes.Controls.Add(Me.btExcluir)
        Me.grpAcoes.Controls.Add(Me.btAlterar)
        Me.grpAcoes.Location = New System.Drawing.Point(12, 340)
        Me.grpAcoes.Name = "grpAcoes"
        Me.grpAcoes.Size = New System.Drawing.Size(821, 50)
        Me.grpAcoes.TabIndex = 3
        Me.grpAcoes.TabStop = False
        Me.grpAcoes.Text = " Ações "
        '
        'btInverte
        '
        Me.btInverte.Enabled = False
        Me.btInverte.Location = New System.Drawing.Point(87, 19)
        Me.btInverte.Name = "btInverte"
        Me.btInverte.Size = New System.Drawing.Size(75, 23)
        Me.btInverte.TabIndex = 1
        Me.btInverte.Text = "Inverte"
        Me.btInverte.UseVisualStyleBackColor = True
        '
        'btExcluir
        '
        Me.btExcluir.Location = New System.Drawing.Point(168, 19)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 2
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'btAlterar
        '
        Me.btAlterar.Location = New System.Drawing.Point(6, 19)
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(75, 23)
        Me.btAlterar.TabIndex = 0
        Me.btAlterar.Text = "Alterar"
        Me.btAlterar.UseVisualStyleBackColor = True
        '
        'grpAlteracao
        '
        Me.grpAlteracao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAlteracao.Controls.Add(Me.lblID)
        Me.grpAlteracao.Controls.Add(Me.txtContraparte)
        Me.grpAlteracao.Controls.Add(Me.Label9)
        Me.grpAlteracao.Controls.Add(Me.txtHistorico)
        Me.grpAlteracao.Controls.Add(Me.Label8)
        Me.grpAlteracao.Controls.Add(Me.txtDeb)
        Me.grpAlteracao.Controls.Add(Me.Label7)
        Me.grpAlteracao.Controls.Add(Me.Label6)
        Me.grpAlteracao.Controls.Add(Me.txtCred)
        Me.grpAlteracao.Controls.Add(Me.txtCDCOMP)
        Me.grpAlteracao.Controls.Add(Me.Label5)
        Me.grpAlteracao.Controls.Add(Me.Label4)
        Me.grpAlteracao.Controls.Add(Me.txtCDRED)
        Me.grpAlteracao.Controls.Add(Me.txtData)
        Me.grpAlteracao.Controls.Add(Me.Label1)
        Me.grpAlteracao.Controls.Add(Me.btCancela)
        Me.grpAlteracao.Controls.Add(Me.btUpdade)
        Me.grpAlteracao.Location = New System.Drawing.Point(14, 402)
        Me.grpAlteracao.Name = "grpAlteracao"
        Me.grpAlteracao.Size = New System.Drawing.Size(818, 108)
        Me.grpAlteracao.TabIndex = 4
        Me.grpAlteracao.TabStop = False
        Me.grpAlteracao.Text = "Alteração de Lançamento"
        '
        'lblID
        '
        Me.lblID.ForeColor = System.Drawing.Color.Gray
        Me.lblID.Location = New System.Drawing.Point(726, 77)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(75, 23)
        Me.lblID.TabIndex = 17
        Me.lblID.Text = "..."
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContraparte
        '
        Me.txtContraparte.AutoSize = True
        Me.txtContraparte.Location = New System.Drawing.Point(162, 82)
        Me.txtContraparte.Name = "txtContraparte"
        Me.txtContraparte.Size = New System.Drawing.Size(16, 13)
        Me.txtContraparte.TabIndex = 16
        Me.txtContraparte.Text = "..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Lançamento de Contrapartida:"
        '
        'txtHistorico
        '
        Me.txtHistorico.Location = New System.Drawing.Point(60, 52)
        Me.txtHistorico.MaxLength = 120
        Me.txtHistorico.Name = "txtHistorico"
        Me.txtHistorico.Size = New System.Drawing.Size(461, 20)
        Me.txtHistorico.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(6, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Histórico"
        '
        'txtDeb
        '
        Me.txtDeb.Location = New System.Drawing.Point(571, 26)
        Me.txtDeb.Name = "txtDeb"
        Me.txtDeb.Size = New System.Drawing.Size(67, 20)
        Me.txtDeb.TabIndex = 4
        Me.txtDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(527, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Débito"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(408, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Crédito"
        '
        'txtCred
        '
        Me.txtCred.Location = New System.Drawing.Point(454, 26)
        Me.txtCred.Name = "txtCred"
        Me.txtCred.Size = New System.Drawing.Size(67, 20)
        Me.txtCred.TabIndex = 3
        Me.txtCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCDCOMP
        '
        Me.txtCDCOMP.Location = New System.Drawing.Point(337, 26)
        Me.txtCDCOMP.Name = "txtCDCOMP"
        Me.txtCDCOMP.Size = New System.Drawing.Size(65, 20)
        Me.txtCDCOMP.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(296, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Conta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(168, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cód Reduzido"
        '
        'txtCDRED
        '
        Me.txtCDRED.Location = New System.Drawing.Point(248, 26)
        Me.txtCDRED.Name = "txtCDRED"
        Me.txtCDRED.Size = New System.Drawing.Size(42, 20)
        Me.txtCDRED.TabIndex = 1
        '
        'txtData
        '
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(60, 26)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(102, 20)
        Me.txtData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Data"
        '
        'btCancela
        '
        Me.btCancela.Location = New System.Drawing.Point(726, 48)
        Me.btCancela.Name = "btCancela"
        Me.btCancela.Size = New System.Drawing.Size(75, 23)
        Me.btCancela.TabIndex = 7
        Me.btCancela.Text = "Cancela"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'btUpdade
        '
        Me.btUpdade.Location = New System.Drawing.Point(726, 19)
        Me.btUpdade.Name = "btUpdade"
        Me.btUpdade.Size = New System.Drawing.Size(75, 23)
        Me.btUpdade.TabIndex = 6
        Me.btUpdade.Text = "Confirma"
        Me.btUpdade.UseVisualStyleBackColor = True
        '
        'frmManutLancam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 522)
        Me.Controls.Add(Me.grpAlteracao)
        Me.Controls.Add(Me.grpAcoes)
        Me.Controls.Add(Me.dgLancamentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManutLancam"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Lançamentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAcoes.ResumeLayout(False)
        Me.grpAlteracao.ResumeLayout(False)
        Me.grpAlteracao.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDataFIM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataINI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgLancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents grpAcoes As System.Windows.Forms.GroupBox
    Friend WithEvents btExcluir As System.Windows.Forms.Button
    Friend WithEvents btAlterar As System.Windows.Forms.Button
    Friend WithEvents grpAlteracao As System.Windows.Forms.GroupBox
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents btUpdade As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCred As System.Windows.Forms.TextBox
    Friend WithEvents txtCDCOMP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCDRED As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDeb As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHistorico As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtContraparte As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btInverte As System.Windows.Forms.Button
End Class
