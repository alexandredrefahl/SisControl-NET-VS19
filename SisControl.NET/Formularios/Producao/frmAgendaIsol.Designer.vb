<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgendaIsol
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
        Me.dgAgenda = New System.Windows.Forms.DataGridView
        Me.chkShow = New System.Windows.Forms.CheckBox
        CType(Me.dgAgenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgAgenda
        '
        Me.dgAgenda.AllowUserToAddRows = False
        Me.dgAgenda.AllowUserToDeleteRows = False
        Me.dgAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAgenda.Location = New System.Drawing.Point(12, 12)
        Me.dgAgenda.Name = "dgAgenda"
        Me.dgAgenda.ReadOnly = True
        Me.dgAgenda.RowHeadersWidth = 20
        Me.dgAgenda.RowTemplate.Height = 20
        Me.dgAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAgenda.Size = New System.Drawing.Size(299, 405)
        Me.dgAgenda.TabIndex = 0
        '
        'chkShow
        '
        Me.chkShow.AutoSize = True
        Me.chkShow.Checked = True
        Me.chkShow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShow.Location = New System.Drawing.Point(12, 423)
        Me.chkShow.Name = "chkShow"
        Me.chkShow.Size = New System.Drawing.Size(197, 17)
        Me.chkShow.TabIndex = 1
        Me.chkShow.Text = "Mostrar esta agenda na próxima vez"
        Me.chkShow.UseVisualStyleBackColor = True
        '
        'frmAgendaIsol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 449)
        Me.Controls.Add(Me.chkShow)
        Me.Controls.Add(Me.dgAgenda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAgendaIsol"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Agenda de Isolamentos"
        CType(Me.dgAgenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgAgenda As System.Windows.Forms.DataGridView
    Friend WithEvents chkShow As System.Windows.Forms.CheckBox
End Class
