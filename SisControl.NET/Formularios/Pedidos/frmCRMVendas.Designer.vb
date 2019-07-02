<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRMVendas
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.tsbtEvento = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.tsBarraFerramentas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.OportunidadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropostaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NegociaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GanhoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerdidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.scDivisoria = New System.Windows.Forms.SplitContainer()
        Me.dgNegocios = New System.Windows.Forms.DataGridView()
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PesquisarEmailsEnviadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlEvento = New System.Windows.Forms.Panel()
        Me.btAddEvento = New System.Windows.Forms.Button()
        Me.txtRegistro = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.ComboBox()
        Me.txtData = New System.Windows.Forms.DateTimePicker()
        Me.dgEventos = New System.Windows.Forms.DataGridView()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.tsbtEvento.SuspendLayout()
        CType(Me.scDivisoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scDivisoria.Panel1.SuspendLayout()
        Me.scDivisoria.Panel2.SuspendLayout()
        Me.scDivisoria.SuspendLayout()
        CType(Me.dgNegocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmMenu.SuspendLayout()
        Me.pnlEvento.SuspendLayout()
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.tsbtEvento)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.scDivisoria)
        Me.ToolStripContainer1.ContentPanel.Padding = New System.Windows.Forms.Padding(15, 0, 15, 10)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(935, 415)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'ToolStripContainer1.LeftToolStripPanel
        '
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(935, 415)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'tsbtEvento
        '
        Me.tsbtEvento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.tsBarraFerramentas, Me.ToolStripSplitButton1})
        Me.tsbtEvento.Location = New System.Drawing.Point(15, 0)
        Me.tsbtEvento.Name = "tsbtEvento"
        Me.tsbtEvento.Size = New System.Drawing.Size(905, 25)
        Me.tsbtEvento.TabIndex = 0
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.SisControl.NET.My.Resources.Resources.document__plus
        Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripButton2.Text = "Novo Negócio"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.SisControl.NET.My.Resources.Resources.DeleteHS
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripButton3.Text = "Excluir Negócio"
        '
        'tsBarraFerramentas
        '
        Me.tsBarraFerramentas.Image = Global.SisControl.NET.My.Resources.Resources.plus
        Me.tsBarraFerramentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsBarraFerramentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBarraFerramentas.Name = "tsBarraFerramentas"
        Me.tsBarraFerramentas.Size = New System.Drawing.Size(95, 22)
        Me.tsBarraFerramentas.Text = "Novo Evento"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OportunidadeToolStripMenuItem, Me.ContatoToolStripMenuItem, Me.PropostaToolStripMenuItem, Me.NegociaçãoToolStripMenuItem, Me.GanhoToolStripMenuItem, Me.PerdidoToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.SisControl.NET.My.Resources.Resources.document_rename__2_
        Me.ToolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripSplitButton1.Text = "Status"
        '
        'OportunidadeToolStripMenuItem
        '
        Me.OportunidadeToolStripMenuItem.Name = "OportunidadeToolStripMenuItem"
        Me.OportunidadeToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.OportunidadeToolStripMenuItem.Text = "1 - Oportunidade"
        '
        'ContatoToolStripMenuItem
        '
        Me.ContatoToolStripMenuItem.Name = "ContatoToolStripMenuItem"
        Me.ContatoToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ContatoToolStripMenuItem.Text = "2 - Contato"
        '
        'PropostaToolStripMenuItem
        '
        Me.PropostaToolStripMenuItem.Name = "PropostaToolStripMenuItem"
        Me.PropostaToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.PropostaToolStripMenuItem.Text = "3 - Proposta"
        '
        'NegociaçãoToolStripMenuItem
        '
        Me.NegociaçãoToolStripMenuItem.Name = "NegociaçãoToolStripMenuItem"
        Me.NegociaçãoToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NegociaçãoToolStripMenuItem.Text = "4 - Negociação"
        '
        'GanhoToolStripMenuItem
        '
        Me.GanhoToolStripMenuItem.Name = "GanhoToolStripMenuItem"
        Me.GanhoToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.GanhoToolStripMenuItem.Text = "5 - Ganho"
        '
        'PerdidoToolStripMenuItem
        '
        Me.PerdidoToolStripMenuItem.Name = "PerdidoToolStripMenuItem"
        Me.PerdidoToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.PerdidoToolStripMenuItem.Text = "6 - Perdido"
        '
        'scDivisoria
        '
        Me.scDivisoria.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.scDivisoria.Location = New System.Drawing.Point(15, 45)
        Me.scDivisoria.Name = "scDivisoria"
        Me.scDivisoria.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scDivisoria.Panel1
        '
        Me.scDivisoria.Panel1.Controls.Add(Me.dgNegocios)
        '
        'scDivisoria.Panel2
        '
        Me.scDivisoria.Panel2.Controls.Add(Me.pnlEvento)
        Me.scDivisoria.Panel2.Controls.Add(Me.dgEventos)
        Me.scDivisoria.Size = New System.Drawing.Size(905, 360)
        Me.scDivisoria.SplitterDistance = 181
        Me.scDivisoria.TabIndex = 0
        '
        'dgNegocios
        '
        Me.dgNegocios.AllowUserToAddRows = False
        Me.dgNegocios.AllowUserToDeleteRows = False
        Me.dgNegocios.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgNegocios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgNegocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgNegocios.ContextMenuStrip = Me.cmMenu
        Me.dgNegocios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgNegocios.Location = New System.Drawing.Point(0, 0)
        Me.dgNegocios.Name = "dgNegocios"
        Me.dgNegocios.ReadOnly = True
        Me.dgNegocios.RowHeadersWidth = 25
        Me.dgNegocios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgNegocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgNegocios.Size = New System.Drawing.Size(905, 181)
        Me.dgNegocios.TabIndex = 0
        '
        'cmMenu
        '
        Me.cmMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarEmailToolStripMenuItem, Me.PesquisarEmailsEnviadosToolStripMenuItem, Me.EditarToolStripMenuItem})
        Me.cmMenu.Name = "cmMenu"
        Me.cmMenu.Size = New System.Drawing.Size(217, 70)
        '
        'EnviarEmailToolStripMenuItem
        '
        Me.EnviarEmailToolStripMenuItem.Name = "EnviarEmailToolStripMenuItem"
        Me.EnviarEmailToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.EnviarEmailToolStripMenuItem.Text = "Enviar E-mail"
        '
        'PesquisarEmailsEnviadosToolStripMenuItem
        '
        Me.PesquisarEmailsEnviadosToolStripMenuItem.Name = "PesquisarEmailsEnviadosToolStripMenuItem"
        Me.PesquisarEmailsEnviadosToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.PesquisarEmailsEnviadosToolStripMenuItem.Text = "Pesquisar E-mails Enviados"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'pnlEvento
        '
        Me.pnlEvento.Controls.Add(Me.btAddEvento)
        Me.pnlEvento.Controls.Add(Me.txtRegistro)
        Me.pnlEvento.Controls.Add(Me.txtTipo)
        Me.pnlEvento.Controls.Add(Me.txtData)
        Me.pnlEvento.Location = New System.Drawing.Point(16, 28)
        Me.pnlEvento.Name = "pnlEvento"
        Me.pnlEvento.Size = New System.Drawing.Size(742, 67)
        Me.pnlEvento.TabIndex = 1
        Me.pnlEvento.Visible = False
        '
        'btAddEvento
        '
        Me.btAddEvento.Location = New System.Drawing.Point(658, 9)
        Me.btAddEvento.Name = "btAddEvento"
        Me.btAddEvento.Size = New System.Drawing.Size(75, 23)
        Me.btAddEvento.TabIndex = 3
        Me.btAddEvento.Text = "Adicionar"
        Me.btAddEvento.UseVisualStyleBackColor = True
        '
        'txtRegistro
        '
        Me.txtRegistro.Location = New System.Drawing.Point(213, 8)
        Me.txtRegistro.Multiline = True
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(439, 51)
        Me.txtRegistro.TabIndex = 2
        '
        'txtTipo
        '
        Me.txtTipo.FormattingEnabled = True
        Me.txtTipo.Items.AddRange(New Object() {"E-mail", "Ligação"})
        Me.txtTipo.Location = New System.Drawing.Point(111, 7)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(96, 21)
        Me.txtTipo.TabIndex = 1
        '
        'txtData
        '
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtData.Location = New System.Drawing.Point(9, 8)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(96, 20)
        Me.txtData.TabIndex = 0
        '
        'dgEventos
        '
        Me.dgEventos.AllowUserToAddRows = False
        Me.dgEventos.AllowUserToDeleteRows = False
        Me.dgEventos.AllowUserToOrderColumns = True
        Me.dgEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEventos.Location = New System.Drawing.Point(0, 0)
        Me.dgEventos.Name = "dgEventos"
        Me.dgEventos.ReadOnly = True
        Me.dgEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEventos.Size = New System.Drawing.Size(905, 175)
        Me.dgEventos.TabIndex = 0
        '
        'frmCRMVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 415)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmCRMVendas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relacionamento com Cliente"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.tsbtEvento.ResumeLayout(False)
        Me.tsbtEvento.PerformLayout()
        Me.scDivisoria.Panel1.ResumeLayout(False)
        Me.scDivisoria.Panel2.ResumeLayout(False)
        CType(Me.scDivisoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scDivisoria.ResumeLayout(False)
        CType(Me.dgNegocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmMenu.ResumeLayout(False)
        Me.pnlEvento.ResumeLayout(False)
        Me.pnlEvento.PerformLayout()
        CType(Me.dgEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrtlNegocio1 As SisControl.NET.crtlNegocio
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolStripContainer1 As ToolStripContainer
    Friend WithEvents scDivisoria As SplitContainer
    Friend WithEvents dgNegocios As DataGridView
    Friend WithEvents dgEventos As DataGridView
    Friend WithEvents tsbtEvento As ToolStrip
    Friend WithEvents tsBarraFerramentas As ToolStripButton
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents OportunidadeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContatoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropostaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NegociaçãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GanhoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerdidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents cmMenu As ContextMenuStrip
    Friend WithEvents EnviarEmailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PesquisarEmailsEnviadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlEvento As Panel
    Friend WithEvents txtTipo As ComboBox
    Friend WithEvents txtData As DateTimePicker
    Friend WithEvents btAddEvento As Button
    Friend WithEvents txtRegistro As TextBox
End Class
