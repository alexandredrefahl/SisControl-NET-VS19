<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFluxo_Caixa
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.grpResumo = New System.Windows.Forms.GroupBox()
        Me.txtSaldoATU = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSaldoANT = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDebitos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCreditos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgLancamentos = New System.Windows.Forms.DataGridView()
        Me.clPagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clConta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clHistorico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clDebito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataFIM = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataINI = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.chFluxo = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dsGrafico = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpResumo.SuspendLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chFluxo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btFiltrar
        '
        Me.btFiltrar.Location = New System.Drawing.Point(486, 13)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btFiltrar.TabIndex = 3
        Me.btFiltrar.Text = "Simular"
        Me.btFiltrar.UseVisualStyleBackColor = True
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
        Me.grpResumo.Location = New System.Drawing.Point(13, 395)
        Me.grpResumo.Name = "grpResumo"
        Me.grpResumo.Size = New System.Drawing.Size(710, 56)
        Me.grpResumo.TabIndex = 12
        Me.grpResumo.TabStop = False
        Me.grpResumo.Text = " Informações da Conta "
        '
        'txtSaldoATU
        '
        Me.txtSaldoATU.AutoSize = True
        Me.txtSaldoATU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoATU.Location = New System.Drawing.Point(627, 28)
        Me.txtSaldoATU.Name = "txtSaldoATU"
        Me.txtSaldoATU.Size = New System.Drawing.Size(32, 13)
        Me.txtSaldoATU.TabIndex = 7
        Me.txtSaldoATU.Text = "0,00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(526, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Saldo Projetado:"
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
        'dgLancamentos
        '
        Me.dgLancamentos.AllowUserToAddRows = False
        Me.dgLancamentos.AllowUserToDeleteRows = False
        Me.dgLancamentos.AllowUserToOrderColumns = True
        Me.dgLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLancamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clPagamento, Me.clConta, Me.clHistorico, Me.clCredito, Me.clDebito, Me.clSaldo})
        Me.dgLancamentos.Location = New System.Drawing.Point(13, 47)
        Me.dgLancamentos.Name = "dgLancamentos"
        Me.dgLancamentos.ReadOnly = True
        Me.dgLancamentos.RowHeadersWidth = 23
        Me.dgLancamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLancamentos.Size = New System.Drawing.Size(710, 331)
        Me.dgLancamentos.TabIndex = 11
        '
        'clPagamento
        '
        Me.clPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.clPagamento.DefaultCellStyle = DataGridViewCellStyle1
        Me.clPagamento.HeaderText = "Pagamento"
        Me.clPagamento.MaxInputLength = 10
        Me.clPagamento.Name = "clPagamento"
        Me.clPagamento.ReadOnly = True
        Me.clPagamento.Width = 75
        '
        'clConta
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.clConta.DefaultCellStyle = DataGridViewCellStyle2
        Me.clConta.HeaderText = "Conta"
        Me.clConta.Name = "clConta"
        Me.clConta.ReadOnly = True
        Me.clConta.Width = 75
        '
        'clHistorico
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clHistorico.DefaultCellStyle = DataGridViewCellStyle3
        Me.clHistorico.HeaderText = "Histórico"
        Me.clHistorico.Name = "clHistorico"
        Me.clHistorico.ReadOnly = True
        Me.clHistorico.Width = 300
        '
        'clCredito
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0,00"
        Me.clCredito.DefaultCellStyle = DataGridViewCellStyle4
        Me.clCredito.HeaderText = "Crédito"
        Me.clCredito.Name = "clCredito"
        Me.clCredito.ReadOnly = True
        Me.clCredito.Width = 70
        '
        'clDebito
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0,00"
        Me.clDebito.DefaultCellStyle = DataGridViewCellStyle5
        Me.clDebito.HeaderText = "Débito"
        Me.clDebito.Name = "clDebito"
        Me.clDebito.ReadOnly = True
        Me.clDebito.Width = 70
        '
        'clSaldo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0,00"
        Me.clSaldo.DefaultCellStyle = DataGridViewCellStyle6
        Me.clSaldo.HeaderText = "Saldo"
        Me.clSaldo.Name = "clSaldo"
        Me.clSaldo.ReadOnly = True
        Me.clSaldo.Width = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "até:"
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Enabled = False
        Me.txtDataFIM.Location = New System.Drawing.Point(207, 15)
        Me.txtDataFIM.Mask = "99/99/99"
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(59, 20)
        Me.txtDataFIM.TabIndex = 1
        '
        'txtDataINI
        '
        Me.txtDataINI.Location = New System.Drawing.Point(111, 15)
        Me.txtDataINI.Mask = "99/99/99"
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(59, 20)
        Me.txtDataINI.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Caixa do Período:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Previsão de até:"
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(390, 15)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(35, 20)
        Me.txtDias.TabIndex = 2
        Me.txtDias.Text = "45"
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(426, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "dias"
        '
        'btImprimir
        '
        Me.btImprimir.Location = New System.Drawing.Point(567, 13)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btImprimir.TabIndex = 4
        Me.btImprimir.Text = "Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = True
        '
        'chFluxo
        '
        Me.chFluxo.BorderSkin.BackColor = System.Drawing.Color.Transparent
        Me.chFluxo.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.AxisX.MajorGrid.Interval = 0.0R
        ChartArea1.AxisX.MajorGrid.IntervalOffset = 0.0R
        ChartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorTickMark.Interval = 0.0R
        ChartArea1.AxisX.MajorTickMark.IntervalOffset = 0.0R
        ChartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisY.MajorGrid.Interval = 0.0R
        ChartArea1.AxisY.MajorGrid.IntervalOffset = 0.0R
        ChartArea1.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.Name = "ChartArea1"
        Me.chFluxo.ChartAreas.Add(ChartArea1)
        Me.chFluxo.DataSource = Me.dsGrafico
        Me.chFluxo.Location = New System.Drawing.Point(16, 47)
        Me.chFluxo.Name = "chFluxo"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.LabelAngle = 90
        Series1.Name = "Series1"
        Series1.XValueMember = "clData"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series1.YValueMembers = "clSaldo"
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.chFluxo.Series.Add(Series1)
        Me.chFluxo.Size = New System.Drawing.Size(710, 331)
        Me.chFluxo.TabIndex = 18
        Me.chFluxo.Text = "Chart1"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.Navy
        Title1.Name = "Title1"
        Title1.ShadowOffset = 1
        Title1.Text = "Fluxo de Caixa"
        Title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.chFluxo.Titles.Add(Title1)
        Me.chFluxo.Visible = False
        '
        'dsGrafico
        '
        Me.dsGrafico.DataSetName = "Grafico"
        Me.dsGrafico.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
        Me.DataTable1.TableName = "tblLancamentos"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "Data"
        Me.DataColumn1.ColumnName = "clData"
        Me.DataColumn1.DataType = GetType(Date)
        Me.DataColumn1.DateTimeMode = System.Data.DataSetDateTime.Local
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Saldo"
        Me.DataColumn2.ColumnName = "clSaldo"
        Me.DataColumn2.DataType = GetType(Double)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(648, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Gráfico"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmFluxo_Caixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 464)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chFluxo)
        Me.Controls.Add(Me.btImprimir)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btFiltrar)
        Me.Controls.Add(Me.grpResumo)
        Me.Controls.Add(Me.dgLancamentos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDataFIM)
        Me.Controls.Add(Me.txtDataINI)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFluxo_Caixa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fluxo de Caixa"
        Me.grpResumo.ResumeLayout(False)
        Me.grpResumo.PerformLayout()
        CType(Me.dgLancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chFluxo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents grpResumo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSaldoATU As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoANT As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDebitos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCreditos As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgLancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataFIM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataINI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clPagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clConta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clHistorico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCredito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDebito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btImprimir As System.Windows.Forms.Button
    Friend WithEvents chFluxo As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dsGrafico As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
