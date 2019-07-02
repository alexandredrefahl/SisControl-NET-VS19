<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWEB_Trello
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWEB_Trello))
        Me.wbBrowser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbBrowser
        '
        Me.wbBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbBrowser.Location = New System.Drawing.Point(0, 0)
        Me.wbBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbBrowser.Name = "wbBrowser"
        Me.wbBrowser.Size = New System.Drawing.Size(765, 467)
        Me.wbBrowser.TabIndex = 0
        '
        'frmWEB_Trello
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 467)
        Me.Controls.Add(Me.wbBrowser)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWEB_Trello"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CRM - Trello"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wbBrowser As WebBrowser
End Class
