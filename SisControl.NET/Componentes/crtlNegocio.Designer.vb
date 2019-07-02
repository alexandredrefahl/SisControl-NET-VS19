<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtlNegocio
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblCor = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(18, 7)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(188, 20)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "..."
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblValor.Location = New System.Drawing.Point(18, 34)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(52, 13)
        Me.lblValor.TabIndex = 1
        Me.lblValor.Text = "R$ 0,00"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCor
        '
        Me.lblCor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblCor.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCor.Location = New System.Drawing.Point(212, 0)
        Me.lblCor.Name = "lblCor"
        Me.lblCor.Size = New System.Drawing.Size(8, 60)
        Me.lblCor.TabIndex = 2
        '
        'lblData
        '
        Me.lblData.BackColor = System.Drawing.Color.Transparent
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblData.Location = New System.Drawing.Point(140, 35)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(67, 13)
        Me.lblData.TabIndex = 3
        Me.lblData.Text = "99/99/9999"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'crtlNegocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.lblCor)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblCliente)
        Me.Name = "crtlNegocio"
        Me.Size = New System.Drawing.Size(220, 60)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblCor As System.Windows.Forms.Label
    Friend WithEvents lblData As System.Windows.Forms.Label

End Class
