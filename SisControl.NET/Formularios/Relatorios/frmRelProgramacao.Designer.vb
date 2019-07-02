<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelProgramacao
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataINI = New System.Windows.Forms.DateTimePicker()
        Me.txtDataFIM = New System.Windows.Forms.DateTimePicker()
        Me.btProg = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dsPlanilha = New System.Data.DataSet()
        Me.DTMeios = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn14 = New System.Data.DataColumn()
        Me.DataColumn15 = New System.Data.DataColumn()
        Me.DataColumn16 = New System.Data.DataColumn()
        Me.DataColumn17 = New System.Data.DataColumn()
        Me.DataColumn18 = New System.Data.DataColumn()
        Me.DataColumn19 = New System.Data.DataColumn()
        Me.DataColumn20 = New System.Data.DataColumn()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.txtObservacoes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dsPlanilha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTMeios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data:"
        '
        'txtDataINI
        '
        Me.txtDataINI.CustomFormat = "dd/MM/yyyy"
        Me.txtDataINI.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDataINI.Location = New System.Drawing.Point(50, 6)
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(95, 20)
        Me.txtDataINI.TabIndex = 1
        '
        'txtDataFIM
        '
        Me.txtDataFIM.CustomFormat = "dd/MM/yyyy"
        Me.txtDataFIM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDataFIM.Location = New System.Drawing.Point(160, 6)
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(95, 20)
        Me.txtDataFIM.TabIndex = 2
        '
        'btProg
        '
        Me.btProg.Location = New System.Drawing.Point(261, 4)
        Me.btProg.Name = "btProg"
        Me.btProg.Size = New System.Drawing.Size(151, 23)
        Me.btProg.TabIndex = 3
        Me.btProg.Text = "Ordens de Produção"
        Me.btProg.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(418, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Visualiza Planilha"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dsPlanilha
        '
        Me.dsPlanilha.DataSetName = "NewDataSet"
        Me.dsPlanilha.Tables.AddRange(New System.Data.DataTable() {Me.DTMeios})
        '
        'DTMeios
        '
        Me.DTMeios.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn15, Me.DataColumn16, Me.DataColumn17, Me.DataColumn18, Me.DataColumn19, Me.DataColumn20})
        Me.DTMeios.TableName = "Meios"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Qtde"
        Me.DataColumn1.DataType = GetType(Double)
        Me.DataColumn1.DefaultValue = 0R
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Cor1"
        Me.DataColumn2.DefaultValue = "0"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Cor2"
        Me.DataColumn3.DefaultValue = "0"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Meio"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Macro"
        Me.DataColumn5.DataType = GetType(Double)
        Me.DataColumn5.DefaultValue = 0R
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "Micro"
        Me.DataColumn6.DataType = GetType(Double)
        Me.DataColumn6.DefaultValue = 0R
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Vitamina"
        Me.DataColumn7.DataType = GetType(Double)
        Me.DataColumn7.DefaultValue = 0R
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "Sacarose"
        Me.DataColumn8.DataType = GetType(Double)
        Me.DataColumn8.DefaultValue = 0R
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "Inositol"
        Me.DataColumn9.DataType = GetType(Double)
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Agar"
        Me.DataColumn10.DataType = GetType(Double)
        Me.DataColumn10.DefaultValue = 0R
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "Outros"
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "BAP"
        Me.DataColumn12.DataType = GetType(Double)
        Me.DataColumn12.DefaultValue = 0R
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "24D"
        Me.DataColumn13.DataType = GetType(Double)
        Me.DataColumn13.DefaultValue = 0R
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "KIN"
        Me.DataColumn14.DataType = GetType(Double)
        Me.DataColumn14.DefaultValue = 0R
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "AIB"
        Me.DataColumn15.DataType = GetType(Double)
        Me.DataColumn15.DefaultValue = 0R
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "ANA"
        Me.DataColumn16.DataType = GetType(Double)
        Me.DataColumn16.DefaultValue = 0R
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "AIA"
        Me.DataColumn17.DataType = GetType(Double)
        Me.DataColumn17.DefaultValue = 0R
        '
        'DataColumn18
        '
        Me.DataColumn18.ColumnName = "GA3"
        Me.DataColumn18.DataType = GetType(Double)
        Me.DataColumn18.DefaultValue = 0R
        '
        'DataColumn19
        '
        Me.DataColumn19.ColumnName = "2iP"
        Me.DataColumn19.DataType = GetType(Double)
        Me.DataColumn19.DefaultValue = 0R
        '
        'DataColumn20
        '
        Me.DataColumn20.ColumnName = "Ph"
        Me.DataColumn20.DataType = GetType(Double)
        Me.DataColumn20.DefaultValue = 0R
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(12, 517)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(16, 13)
        Me.lblMsg.TabIndex = 6
        Me.lblMsg.Text = "..."
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crViewer.Location = New System.Drawing.Point(12, 33)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.ShowCloseButton = False
        Me.crViewer.ShowGroupTreeButton = False
        Me.crViewer.ShowParameterPanelButton = False
        Me.crViewer.Size = New System.Drawing.Size(561, 371)
        Me.crViewer.TabIndex = 7
        Me.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'txtObservacoes
        '
        Me.txtObservacoes.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacoes.Location = New System.Drawing.Point(12, 423)
        Me.txtObservacoes.Multiline = True
        Me.txtObservacoes.Name = "txtObservacoes"
        Me.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacoes.Size = New System.Drawing.Size(561, 93)
        Me.txtObservacoes.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Observações Planilha de Meios:"
        '
        'frmRelProgramacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 541)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObservacoes)
        Me.Controls.Add(Me.crViewer)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btProg)
        Me.Controls.Add(Me.txtDataFIM)
        Me.Controls.Add(Me.txtDataINI)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelProgramacao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programação da Produção"
        CType(Me.dsPlanilha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTMeios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataINI As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDataFIM As System.Windows.Forms.DateTimePicker
    Friend WithEvents btProg As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dsPlanilha As System.Data.DataSet
    Friend WithEvents DTMeios As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents DataColumn18 As System.Data.DataColumn
    Friend WithEvents DataColumn19 As System.Data.DataColumn
    Friend WithEvents DataColumn20 As System.Data.DataColumn
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtObservacoes As TextBox
    Friend WithEvents Label2 As Label
End Class
