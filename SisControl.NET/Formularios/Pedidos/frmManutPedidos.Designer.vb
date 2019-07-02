<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManutPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManutPedidos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAno = New System.Windows.Forms.NumericUpDown()
        Me.chkData = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataFIM = New System.Windows.Forms.DateTimePicker()
        Me.txtDataINI = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.dgPedidos = New System.Windows.Forms.DataGridView()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btExcluir = New System.Windows.Forms.Button()
        Me.btAlterar = New System.Windows.Forms.Button()
        Me.btImprimir = New System.Windows.Forms.Button()
        Me.btEmail = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btFaturar = New System.Windows.Forms.Button()
        Me.btCancela = New System.Windows.Forms.Button()
        Me.btStatus = New System.Windows.Forms.Button()
        Me.btLiquidar = New System.Windows.Forms.Button()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.BtSTCancelar = New System.Windows.Forms.Button()
        Me.btSTOK = New System.Windows.Forms.Button()
        Me.cmbAltStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Controls.Add(Me.chkData)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btFiltrar)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDataFIM)
        Me.GroupBox1.Controls.Add(Me.txtDataINI)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Seleção de Pedidos "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(376, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Ano:"
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(407, 49)
        Me.txtAno.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.txtAno.Minimum = New Decimal(New Integer() {2006, 0, 0, 0})
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(96, 20)
        Me.txtAno.TabIndex = 12
        Me.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAno.Value = New Decimal(New Integer() {2006, 0, 0, 0})
        '
        'chkData
        '
        Me.chkData.AutoSize = True
        Me.chkData.Location = New System.Drawing.Point(232, 22)
        Me.chkData.Name = "chkData"
        Me.chkData.Size = New System.Drawing.Size(43, 17)
        Me.chkData.TabIndex = 11
        Me.chkData.Text = "De:"
        Me.chkData.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(549, 49)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Limpar Filtro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btFiltrar
        '
        Me.btFiltrar.Image = CType(resources.GetObject("btFiltrar.Image"), System.Drawing.Image)
        Me.btFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btFiltrar.Location = New System.Drawing.Point(549, 20)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(89, 23)
        Me.btFiltrar.TabIndex = 9
        Me.btFiltrar.Text = "Filtrar"
        Me.btFiltrar.UseVisualStyleBackColor = True
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(59, 49)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(311, 21)
        Me.cmbCliente.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(376, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "até:"
        '
        'txtDataFIM
        '
        Me.txtDataFIM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataFIM.Location = New System.Drawing.Point(407, 20)
        Me.txtDataFIM.Name = "txtDataFIM"
        Me.txtDataFIM.Size = New System.Drawing.Size(96, 20)
        Me.txtDataFIM.TabIndex = 3
        '
        'txtDataINI
        '
        Me.txtDataINI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataINI.Location = New System.Drawing.Point(275, 20)
        Me.txtDataINI.Name = "txtDataINI"
        Me.txtDataINI.Size = New System.Drawing.Size(95, 20)
        Me.txtDataINI.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status:"
        '
        'cmbStatus
        '
        Me.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"1- Autorizados", "2 - Em Produção", "3 - Cancelados", "4 - Atendidos", "Todos"})
        Me.cmbStatus.Location = New System.Drawing.Point(59, 20)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(160, 21)
        Me.cmbStatus.TabIndex = 0
        '
        'dgPedidos
        '
        Me.dgPedidos.AllowUserToAddRows = False
        Me.dgPedidos.AllowUserToDeleteRows = False
        Me.dgPedidos.AllowUserToOrderColumns = True
        Me.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPedidos.Location = New System.Drawing.Point(12, 98)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.ReadOnly = True
        Me.dgPedidos.RowHeadersWidth = 20
        Me.dgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPedidos.Size = New System.Drawing.Size(644, 324)
        Me.dgPedidos.TabIndex = 1
        '
        'btSalvar
        '
        Me.btSalvar.Location = New System.Drawing.Point(474, 22)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 3
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'btFechar
        '
        Me.btFechar.Location = New System.Drawing.Point(555, 22)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 4
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'btExcluir
        '
        Me.btExcluir.Location = New System.Drawing.Point(95, 22)
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 6
        Me.btExcluir.Text = "Excluir"
        Me.btExcluir.UseVisualStyleBackColor = True
        '
        'btAlterar
        '
        Me.btAlterar.Location = New System.Drawing.Point(14, 22)
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(75, 23)
        Me.btAlterar.TabIndex = 7
        Me.btAlterar.Text = "Alterar"
        Me.btAlterar.UseVisualStyleBackColor = True
        '
        'btImprimir
        '
        Me.btImprimir.Location = New System.Drawing.Point(257, 22)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btImprimir.TabIndex = 8
        Me.btImprimir.Text = "Imprimir"
        Me.btImprimir.UseVisualStyleBackColor = True
        '
        'btEmail
        '
        Me.btEmail.Location = New System.Drawing.Point(338, 22)
        Me.btEmail.Name = "btEmail"
        Me.btEmail.Size = New System.Drawing.Size(81, 23)
        Me.btEmail.TabIndex = 9
        Me.btEmail.Text = "E-Mail"
        Me.btEmail.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btFaturar)
        Me.GroupBox2.Controls.Add(Me.btCancela)
        Me.GroupBox2.Controls.Add(Me.btStatus)
        Me.GroupBox2.Controls.Add(Me.btLiquidar)
        Me.GroupBox2.Controls.Add(Me.btEmail)
        Me.GroupBox2.Controls.Add(Me.btSalvar)
        Me.GroupBox2.Controls.Add(Me.btImprimir)
        Me.GroupBox2.Controls.Add(Me.btFechar)
        Me.GroupBox2.Controls.Add(Me.btAlterar)
        Me.GroupBox2.Controls.Add(Me.btExcluir)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 428)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(641, 82)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Ações "
        '
        'btFaturar
        '
        Me.btFaturar.Location = New System.Drawing.Point(176, 51)
        Me.btFaturar.Name = "btFaturar"
        Me.btFaturar.Size = New System.Drawing.Size(75, 23)
        Me.btFaturar.TabIndex = 13
        Me.btFaturar.Text = "Faturar"
        Me.btFaturar.UseVisualStyleBackColor = True
        '
        'btCancela
        '
        Me.btCancela.Location = New System.Drawing.Point(95, 51)
        Me.btCancela.Name = "btCancela"
        Me.btCancela.Size = New System.Drawing.Size(75, 23)
        Me.btCancela.TabIndex = 12
        Me.btCancela.Text = "Cancelar"
        Me.btCancela.UseVisualStyleBackColor = True
        '
        'btStatus
        '
        Me.btStatus.Location = New System.Drawing.Point(14, 51)
        Me.btStatus.Name = "btStatus"
        Me.btStatus.Size = New System.Drawing.Size(75, 23)
        Me.btStatus.TabIndex = 11
        Me.btStatus.Text = "Altera Status"
        Me.btStatus.UseVisualStyleBackColor = True
        '
        'btLiquidar
        '
        Me.btLiquidar.Location = New System.Drawing.Point(176, 22)
        Me.btLiquidar.Name = "btLiquidar"
        Me.btLiquidar.Size = New System.Drawing.Size(75, 23)
        Me.btLiquidar.TabIndex = 10
        Me.btLiquidar.Text = "Liquidar"
        Me.btLiquidar.UseVisualStyleBackColor = True
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(15, 514)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(10, 10)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape5, Me.RectangleShape4, Me.RectangleShape3, Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(668, 534)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape5
        '
        Me.RectangleShape5.BackColor = System.Drawing.Color.White
        Me.RectangleShape5.FillColor = System.Drawing.Color.GreenYellow
        Me.RectangleShape5.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape5.Location = New System.Drawing.Point(415, 514)
        Me.RectangleShape5.Name = "RectangleShape5"
        Me.RectangleShape5.Size = New System.Drawing.Size(10, 10)
        '
        'RectangleShape4
        '
        Me.RectangleShape4.BackColor = System.Drawing.Color.White
        Me.RectangleShape4.FillColor = System.Drawing.Color.Red
        Me.RectangleShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape4.Location = New System.Drawing.Point(315, 514)
        Me.RectangleShape4.Name = "RectangleShape4"
        Me.RectangleShape4.Size = New System.Drawing.Size(10, 10)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BackColor = System.Drawing.Color.White
        Me.RectangleShape3.FillColor = System.Drawing.Color.Yellow
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(215, 514)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(10, 10)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.LightGray
        Me.RectangleShape2.FillColor = System.Drawing.Color.LightGray
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(115, 514)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(10, 10)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 514)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Não Autorizado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(128, 514)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Autorizado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(228, 514)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Produzindo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(328, 514)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Cancelado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(428, 514)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Atendido"
        '
        'pnlStatus
        '
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.BtSTCancelar)
        Me.pnlStatus.Controls.Add(Me.btSTOK)
        Me.pnlStatus.Controls.Add(Me.cmbAltStatus)
        Me.pnlStatus.Controls.Add(Me.Label10)
        Me.pnlStatus.Location = New System.Drawing.Point(169, 224)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(319, 70)
        Me.pnlStatus.TabIndex = 17
        Me.pnlStatus.Visible = False
        '
        'BtSTCancelar
        '
        Me.BtSTCancelar.Location = New System.Drawing.Point(249, 37)
        Me.BtSTCancelar.Name = "BtSTCancelar"
        Me.BtSTCancelar.Size = New System.Drawing.Size(57, 23)
        Me.BtSTCancelar.TabIndex = 3
        Me.BtSTCancelar.Text = "Cancelar"
        Me.BtSTCancelar.UseVisualStyleBackColor = True
        '
        'btSTOK
        '
        Me.btSTOK.Location = New System.Drawing.Point(200, 37)
        Me.btSTOK.Name = "btSTOK"
        Me.btSTOK.Size = New System.Drawing.Size(43, 23)
        Me.btSTOK.TabIndex = 2
        Me.btSTOK.Text = "OK"
        Me.btSTOK.UseVisualStyleBackColor = True
        '
        'cmbAltStatus
        '
        Me.cmbAltStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAltStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAltStatus.FormattingEnabled = True
        Me.cmbAltStatus.Items.AddRange(New Object() {"01 - Aguardando Pagamento", "02 - Processando", "03 - Despachado", "05 - Completo (4)", "07 - Cancelado (3)", "08 - Negado", "09 - Cancelamento Revertido", "10 - Não aprovado", "11 - Devolvido", "13 - Cancelado pela operadora", "14 - Expirado", "15 - Processado"})
        Me.cmbAltStatus.Location = New System.Drawing.Point(134, 10)
        Me.cmbAltStatus.Name = "cmbAltStatus"
        Me.cmbAltStatus.Size = New System.Drawing.Size(173, 21)
        Me.cmbAltStatus.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Novo Status do Pedido"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmManutPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 534)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgPedidos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManutPedidos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Pedidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dgPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDataFIM As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDataINI As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents btSalvar As System.Windows.Forms.Button
    Friend WithEvents btFechar As System.Windows.Forms.Button
    Friend WithEvents btExcluir As System.Windows.Forms.Button
    Friend WithEvents btAlterar As System.Windows.Forms.Button
    Friend WithEvents btImprimir As System.Windows.Forms.Button
    Friend WithEvents btEmail As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btLiquidar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btCancela As System.Windows.Forms.Button
    Friend WithEvents btStatus As System.Windows.Forms.Button
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents BtSTCancelar As System.Windows.Forms.Button
    Friend WithEvents btSTOK As System.Windows.Forms.Button
    Friend WithEvents cmbAltStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btFaturar As System.Windows.Forms.Button
    Friend WithEvents chkData As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Private WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Private WithEvents RectangleShape5 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents RectangleShape4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAno As NumericUpDown
End Class
