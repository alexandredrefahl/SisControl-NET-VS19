<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanejamentoProducao
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
        Dim CalendarHighlightRange6 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange7 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange8 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange9 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange10 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Me.Cal = New System.Windows.Forms.Calendar.Calendar()
        Me.Mes = New System.Windows.Forms.Calendar.MonthView()
        Me.dgOrdens = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.chkAberto = New System.Windows.Forms.RadioButton()
        Me.chkTodas = New System.Windows.Forms.RadioButton()
        Me.calCalendario = New System.Windows.Forms.MonthCalendar()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.chkTodasAberto = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdOP = New System.Windows.Forms.TextBox()
        Me.btProcura = New System.Windows.Forms.Button()
        CType(Me.dgOrdens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cal
        '
        Me.Cal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        CalendarHighlightRange6.DayOfWeek = System.DayOfWeek.Monday
        CalendarHighlightRange6.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange6.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange7.DayOfWeek = System.DayOfWeek.Tuesday
        CalendarHighlightRange7.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange7.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange8.DayOfWeek = System.DayOfWeek.Wednesday
        CalendarHighlightRange8.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange8.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange9.DayOfWeek = System.DayOfWeek.Thursday
        CalendarHighlightRange9.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange9.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange10.DayOfWeek = System.DayOfWeek.Friday
        CalendarHighlightRange10.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange10.StartTime = System.TimeSpan.Parse("08:00:00")
        Me.Cal.HighlightRanges = New System.Windows.Forms.Calendar.CalendarHighlightRange() {CalendarHighlightRange6, CalendarHighlightRange7, CalendarHighlightRange8, CalendarHighlightRange9, CalendarHighlightRange10}
        Me.Cal.Location = New System.Drawing.Point(0, 0)
        Me.Cal.Name = "Cal"
        Me.Cal.Size = New System.Drawing.Size(0, 0)
        Me.Cal.TabIndex = 0
        '
        'Mes
        '
        Me.Mes.ArrowsColor = System.Drawing.SystemColors.Window
        Me.Mes.ArrowsSelectedColor = System.Drawing.Color.Gold
        Me.Mes.DayBackgroundColor = System.Drawing.Color.Empty
        Me.Mes.DayGrayedText = System.Drawing.SystemColors.GrayText
        Me.Mes.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight
        Me.Mes.DaySelectedColor = System.Drawing.SystemColors.WindowText
        Me.Mes.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText
        Me.Mes.ItemPadding = New System.Windows.Forms.Padding(2)
        Me.Mes.Location = New System.Drawing.Point(12, 12)
        Me.Mes.MonthTitleColor = System.Drawing.Color.Gray
        Me.Mes.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption
        Me.Mes.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Mes.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText
        Me.Mes.Name = "Mes"
        Me.Mes.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.WorkWeek
        Me.Mes.Size = New System.Drawing.Size(192, 158)
        Me.Mes.TabIndex = 1
        Me.Mes.Text = "MonthView1"
        Me.Mes.TodayBorderColor = System.Drawing.Color.Maroon
        '
        'dgOrdens
        '
        Me.dgOrdens.AllowUserToAddRows = False
        Me.dgOrdens.AllowUserToDeleteRows = False
        Me.dgOrdens.AllowUserToResizeRows = False
        Me.dgOrdens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrdens.Location = New System.Drawing.Point(214, 28)
        Me.dgOrdens.Name = "dgOrdens"
        Me.dgOrdens.ReadOnly = True
        Me.dgOrdens.RowHeadersWidth = 20
        Me.dgOrdens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrdens.Size = New System.Drawing.Size(647, 263)
        Me.dgOrdens.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ordens de Produção"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(376, 297)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Baixa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(295, 297)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Reagendar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(457, 297)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Excluir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(538, 297)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Alterar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(214, 297)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Executar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'chkAberto
        '
        Me.chkAberto.AutoSize = True
        Me.chkAberto.Location = New System.Drawing.Point(12, 199)
        Me.chkAberto.Name = "chkAberto"
        Me.chkAberto.Size = New System.Drawing.Size(122, 17)
        Me.chkAberto.TabIndex = 10
        Me.chkAberto.Text = "Em Aberto (Semana)"
        Me.chkAberto.UseVisualStyleBackColor = True
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Checked = True
        Me.chkTodas.Location = New System.Drawing.Point(12, 176)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(103, 17)
        Me.chkTodas.TabIndex = 11
        Me.chkTodas.TabStop = True
        Me.chkTodas.Text = "Todas (Semana)"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'calCalendario
        '
        Me.calCalendario.Location = New System.Drawing.Point(295, 129)
        Me.calCalendario.Name = "calCalendario"
        Me.calCalendario.TabIndex = 9
        Me.calCalendario.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(619, 297)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Nova"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'chkTodasAberto
        '
        Me.chkTodasAberto.AutoSize = True
        Me.chkTodasAberto.Location = New System.Drawing.Point(12, 222)
        Me.chkTodasAberto.Name = "chkTodasAberto"
        Me.chkTodasAberto.Size = New System.Drawing.Size(106, 17)
        Me.chkTodasAberto.TabIndex = 13
        Me.chkTodasAberto.TabStop = True
        Me.chkTodasAberto.Text = "Todas em Aberto"
        Me.chkTodasAberto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 281)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Procurar pelo Código:"
        '
        'txtIdOP
        '
        Me.txtIdOP.Location = New System.Drawing.Point(12, 297)
        Me.txtIdOP.Name = "txtIdOP"
        Me.txtIdOP.Size = New System.Drawing.Size(106, 20)
        Me.txtIdOP.TabIndex = 15
        Me.txtIdOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btProcura
        '
        Me.btProcura.Location = New System.Drawing.Point(124, 297)
        Me.btProcura.Name = "btProcura"
        Me.btProcura.Size = New System.Drawing.Size(24, 20)
        Me.btProcura.TabIndex = 16
        Me.btProcura.Text = "..."
        Me.btProcura.UseVisualStyleBackColor = True
        '
        'frmPlanejamentoProducao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 329)
        Me.Controls.Add(Me.btProcura)
        Me.Controls.Add(Me.txtIdOP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTodasAberto)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.calCalendario)
        Me.Controls.Add(Me.chkTodas)
        Me.Controls.Add(Me.chkAberto)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgOrdens)
        Me.Controls.Add(Me.Mes)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanejamentoProducao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planejamento da Produção"
        CType(Me.dgOrdens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cal As System.Windows.Forms.Calendar.Calendar
    Friend WithEvents Mes As System.Windows.Forms.Calendar.MonthView
    Friend WithEvents dgOrdens As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents chkAberto As System.Windows.Forms.RadioButton
    Friend WithEvents chkTodas As System.Windows.Forms.RadioButton
    Friend WithEvents calCalendario As System.Windows.Forms.MonthCalendar
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents chkTodasAberto As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdOP As System.Windows.Forms.TextBox
    Friend WithEvents btProcura As System.Windows.Forms.Button
End Class
