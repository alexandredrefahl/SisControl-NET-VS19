<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltSalarial
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
        Me.cmbFuncionario = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSalario = New System.Windows.Forms.TextBox
        Me.txtData = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgSalarios = New System.Windows.Forms.DataGridView
        Me.btIncluir = New System.Windows.Forms.Button
        Me.btAtualizar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.btAlterar = New System.Windows.Forms.Button
        Me.btExcluir = New System.Windows.Forms.Button
        CType(Me.dgSalarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbFuncionario
        '
        Me.cmbFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFuncionario.FormattingEnabled = True
        Me.cmbFuncionario.Location = New System.Drawing.Point(83, 6)
        Me.cmbFuncionario.Name = "cmbFuncionario"
        Me.cmbFuncionario.Size = New System.Drawing.Size(334, 21)
        Me.cmbFuncionario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Funcionário:"
        '
        'txtSalario
        '
        Me.txtSalario.Location = New System.Drawing.Point(225, 33)
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(68, 20)
        Me.txtSalario.TabIndex = 2
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(83, 33)
        Me.txtData.Mask = "99/99/9999"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(68, 20)
        Me.txtData.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Salário:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Data:"
        '
        'dgSalarios
        '
        Me.dgSalarios.AllowUserToAddRows = False
        Me.dgSalarios.AllowUserToDeleteRows = False
        Me.dgSalarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalarios.Location = New System.Drawing.Point(15, 85)
        Me.dgSalarios.Name = "dgSalarios"
        Me.dgSalarios.ReadOnly = True
        Me.dgSalarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSalarios.Size = New System.Drawing.Size(278, 167)
        Me.dgSalarios.TabIndex = 3
        '
        'btIncluir
        '
        Me.btIncluir.Location = New System.Drawing.Point(318, 31)
        Me.btIncluir.Name = "btIncluir"
        Me.btIncluir.Size = New System.Drawing.Size(99, 23)
        Me.btIncluir.TabIndex = 8
        Me.btIncluir.Text = "Adicionar"
        Me.btIncluir.UseVisualStyleBackColor = True
        '
        'btAtualizar
        '
        Me.btAtualizar.Enabled = False
        Me.btAtualizar.Location = New System.Drawing.Point(318, 143)
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(99, 23)
        Me.btAtualizar.TabIndex = 9
        Me.btAtualizar.Text = "Atualizar Ficha"
        Me.btAtualizar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Alterações Salariais"
        '
        'btAlterar
        '
        Me.btAlterar.Enabled = False
        Me.btAlterar.Location = New System.Drawing.Point(318, 85)
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(99, 23)
        Me.btAlterar.TabIndex = 12
        Me.btAlterar.Text = "Alterar"
        Me.btAlterar.UseVisualStyleBackColor = True
        '
        'btExcluir
        '
        Me.btExcluir.Enabled = False
        Me.btExcluir.Location = New System.Drawing.Point(318, 114)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(99, 23)
        Me.btExcluir.TabIndex = 13
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'frmAltSalarial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 272)
        Me.Controls.Add(Me.btExcluir)
        Me.Controls.Add(Me.btAlterar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btAtualizar)
        Me.Controls.Add(Me.btIncluir)
        Me.Controls.Add(Me.dgSalarios)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.txtSalario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbFuncionario)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAltSalarial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alteração Salarial"
        CType(Me.dgSalarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSalario As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgSalarios As System.Windows.Forms.DataGridView
    Friend WithEvents btIncluir As System.Windows.Forms.Button
    Friend WithEvents btAtualizar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btAlterar As System.Windows.Forms.Button
    Friend WithEvents btExcluir As System.Windows.Forms.Button
End Class
