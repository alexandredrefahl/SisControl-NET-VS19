<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNFeFatura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgNFs = New System.Windows.Forms.DataGridView()
        Me.menuFuncoes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAlterar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGerarXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuValidar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransmitir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDanfe = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTermo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintTermo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRegFrete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEnviarReg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRastrear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btTransmitir = New System.Windows.Forms.Button()
        Me.btGerarXML = New System.Windows.Forms.Button()
        Me.btDanfe = New System.Windows.Forms.Button()
        Me.grpAcompanhamento = New System.Windows.Forms.GroupBox()
        Me.txtMensagem = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tmrAguarda = New System.Windows.Forms.Timer(Me.components)
        Me.btValidar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btCancelamento = New System.Windows.Forms.Button()
        Me.bt_Inutilizacao = New System.Windows.Forms.Button()
        Me.btAlterar = New System.Windows.Forms.Button()
        Me.pnlInutilizacao = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtJust = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNFeFIM = New System.Windows.Forms.TextBox()
        Me.txtNFeINI = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblCORGerada = New System.Windows.Forms.Label()
        Me.lblCORDigitada = New System.Windows.Forms.Label()
        Me.lblCORTransmitida = New System.Windows.Forms.Label()
        Me.lblCORImpressa = New System.Windows.Forms.Label()
        Me.lblCORCancelada = New System.Windows.Forms.Label()
        Me.btLancar = New System.Windows.Forms.Button()
        Me.ttInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.btExportar = New System.Windows.Forms.Button()
        Me.btEmail = New System.Windows.Forms.Button()
        Me.btPrintTermo = New System.Windows.Forms.Button()
        Me.btCorrecao = New System.Windows.Forms.Button()
        Me.fbPasta = New System.Windows.Forms.FolderBrowserDialog()
        Me.btTermo = New System.Windows.Forms.Button()
        Me.pdImpressora = New System.Windows.Forms.PrintDialog()
        Me.lblCORInutilizada = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlFrete = New System.Windows.Forms.Panel()
        Me.txtTransporte = New System.Windows.Forms.ComboBox()
        Me.btCancela_Frete = New System.Windows.Forms.Button()
        Me.btOKFrete = New System.Windows.Forms.Button()
        Me.txtDataFrete = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVFrete = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRastreador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.webRastreador = New System.Windows.Forms.WebBrowser()
        Me.pnlCorreio = New System.Windows.Forms.Panel()
        Me.bt_Fecha_Browser = New System.Windows.Forms.Button()
        Me.cmbAno = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.dgNFs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuFuncoes.SuspendLayout()
        Me.grpAcompanhamento.SuspendLayout()
        Me.pnlInutilizacao.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlFrete.SuspendLayout()
        Me.pnlCorreio.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgNFs
        '
        Me.dgNFs.AllowUserToAddRows = False
        Me.dgNFs.AllowUserToDeleteRows = False
        Me.dgNFs.AllowUserToOrderColumns = True
        Me.dgNFs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgNFs.ContextMenuStrip = Me.menuFuncoes
        Me.dgNFs.Location = New System.Drawing.Point(15, 34)
        Me.dgNFs.MultiSelect = False
        Me.dgNFs.Name = "dgNFs"
        Me.dgNFs.ReadOnly = True
        Me.dgNFs.RowHeadersWidth = 25
        Me.dgNFs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgNFs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgNFs.Size = New System.Drawing.Size(672, 286)
        Me.dgNFs.TabIndex = 0
        '
        'menuFuncoes
        '
        Me.menuFuncoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAlterar, Me.mnuGerarXML, Me.mnuValidar, Me.mnuTransmitir, Me.mnuDanfe, Me.mnuCancelar, Me.mnuExportar, Me.mnuTermo, Me.mnuPrintTermo, Me.mnuRegFrete, Me.mnuEnviarReg, Me.mnuRastrear})
        Me.menuFuncoes.Name = "menuFuncoes"
        Me.menuFuncoes.Size = New System.Drawing.Size(175, 268)
        '
        'mnuAlterar
        '
        Me.mnuAlterar.Image = Global.SisControl.NET.My.Resources.Resources.document_rename__2_
        Me.mnuAlterar.Name = "mnuAlterar"
        Me.mnuAlterar.Size = New System.Drawing.Size(174, 22)
        Me.mnuAlterar.Text = "&Alterar"
        Me.mnuAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuGerarXML
        '
        Me.mnuGerarXML.Image = Global.SisControl.NET.My.Resources.Resources.document__plus
        Me.mnuGerarXML.Name = "mnuGerarXML"
        Me.mnuGerarXML.Size = New System.Drawing.Size(174, 22)
        Me.mnuGerarXML.Text = "&Gerar Arquivo XML"
        '
        'mnuValidar
        '
        Me.mnuValidar.Image = Global.SisControl.NET.My.Resources.Resources.document_task__2_
        Me.mnuValidar.Name = "mnuValidar"
        Me.mnuValidar.Size = New System.Drawing.Size(174, 22)
        Me.mnuValidar.Text = "&Validar"
        '
        'mnuTransmitir
        '
        Me.mnuTransmitir.Image = Global.SisControl.NET.My.Resources.Resources.document__arrow__2_
        Me.mnuTransmitir.Name = "mnuTransmitir"
        Me.mnuTransmitir.Size = New System.Drawing.Size(174, 22)
        Me.mnuTransmitir.Text = "&Transmitir"
        Me.mnuTransmitir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuDanfe
        '
        Me.mnuDanfe.Image = Global.SisControl.NET.My.Resources.Resources.printer_color__2_
        Me.mnuDanfe.Name = "mnuDanfe"
        Me.mnuDanfe.Size = New System.Drawing.Size(174, 22)
        Me.mnuDanfe.Text = "&Imprimir DANFE"
        '
        'mnuCancelar
        '
        Me.mnuCancelar.Image = Global.SisControl.NET.My.Resources.Resources.document_attribute_x__2_
        Me.mnuCancelar.Name = "mnuCancelar"
        Me.mnuCancelar.Size = New System.Drawing.Size(174, 22)
        Me.mnuCancelar.Text = "&Cancelar"
        '
        'mnuExportar
        '
        Me.mnuExportar.Image = Global.SisControl.NET.My.Resources.Resources.document_xaml__2_
        Me.mnuExportar.Name = "mnuExportar"
        Me.mnuExportar.Size = New System.Drawing.Size(174, 22)
        Me.mnuExportar.Text = "&Exportar XML"
        '
        'mnuTermo
        '
        Me.mnuTermo.Image = Global.SisControl.NET.My.Resources.Resources.report_add
        Me.mnuTermo.Name = "mnuTermo"
        Me.mnuTermo.Size = New System.Drawing.Size(174, 22)
        Me.mnuTermo.Text = "Emitir Termo"
        '
        'mnuPrintTermo
        '
        Me.mnuPrintTermo.Image = Global.SisControl.NET.My.Resources.Resources.printer__5_
        Me.mnuPrintTermo.Name = "mnuPrintTermo"
        Me.mnuPrintTermo.Size = New System.Drawing.Size(174, 22)
        Me.mnuPrintTermo.Text = "Imprimir Termo"
        '
        'mnuRegFrete
        '
        Me.mnuRegFrete.Image = Global.SisControl.NET.My.Resources.Resources.package_add
        Me.mnuRegFrete.Name = "mnuRegFrete"
        Me.mnuRegFrete.Size = New System.Drawing.Size(174, 22)
        Me.mnuRegFrete.Text = "Registrar Frete"
        '
        'mnuEnviarReg
        '
        Me.mnuEnviarReg.Image = Global.SisControl.NET.My.Resources.Resources.email
        Me.mnuEnviarReg.Name = "mnuEnviarReg"
        Me.mnuEnviarReg.Size = New System.Drawing.Size(174, 22)
        Me.mnuEnviarReg.Text = "Enviar Rastreador"
        '
        'mnuRastrear
        '
        Me.mnuRastrear.Image = Global.SisControl.NET.My.Resources.Resources.correio
        Me.mnuRastrear.Name = "mnuRastrear"
        Me.mnuRastrear.Size = New System.Drawing.Size(174, 22)
        Me.mnuRastrear.Text = "Rastrear Objeto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selecione o documento de Saída:"
        '
        'btTransmitir
        '
        Me.btTransmitir.Location = New System.Drawing.Point(304, 326)
        Me.btTransmitir.Name = "btTransmitir"
        Me.btTransmitir.Size = New System.Drawing.Size(87, 23)
        Me.btTransmitir.TabIndex = 2
        Me.btTransmitir.Text = "Transmitir NFe"
        Me.ttInfo.SetToolTip(Me.btTransmitir, "Faz a transmissão do arquivo para Receita Federal")
        Me.btTransmitir.UseVisualStyleBackColor = True
        '
        'btGerarXML
        '
        Me.btGerarXML.Location = New System.Drawing.Point(111, 326)
        Me.btGerarXML.Name = "btGerarXML"
        Me.btGerarXML.Size = New System.Drawing.Size(91, 23)
        Me.btGerarXML.TabIndex = 3
        Me.btGerarXML.Text = "Gerar Arquivo"
        Me.ttInfo.SetToolTip(Me.btGerarXML, "Gera o arquivo XML para transmissão.")
        Me.btGerarXML.UseVisualStyleBackColor = True
        '
        'btDanfe
        '
        Me.btDanfe.Enabled = False
        Me.btDanfe.Location = New System.Drawing.Point(397, 326)
        Me.btDanfe.Name = "btDanfe"
        Me.btDanfe.Size = New System.Drawing.Size(98, 23)
        Me.btDanfe.TabIndex = 4
        Me.btDanfe.Text = "Visualizar DANFE"
        Me.ttInfo.SetToolTip(Me.btDanfe, "Imprime a DANFe")
        Me.btDanfe.UseVisualStyleBackColor = True
        '
        'grpAcompanhamento
        '
        Me.grpAcompanhamento.Controls.Add(Me.txtMensagem)
        Me.grpAcompanhamento.Location = New System.Drawing.Point(15, 383)
        Me.grpAcompanhamento.Name = "grpAcompanhamento"
        Me.grpAcompanhamento.Size = New System.Drawing.Size(672, 128)
        Me.grpAcompanhamento.TabIndex = 5
        Me.grpAcompanhamento.TabStop = False
        Me.grpAcompanhamento.Text = " Acompanhamento "
        '
        'txtMensagem
        '
        Me.txtMensagem.BackColor = System.Drawing.SystemColors.Control
        Me.txtMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMensagem.Location = New System.Drawing.Point(7, 19)
        Me.txtMensagem.Multiline = True
        Me.txtMensagem.Name = "txtMensagem"
        Me.txtMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensagem.Size = New System.Drawing.Size(652, 100)
        Me.txtMensagem.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(607, 530)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tmrAguarda
        '
        Me.tmrAguarda.Interval = 1000
        '
        'btValidar
        '
        Me.btValidar.Location = New System.Drawing.Point(208, 326)
        Me.btValidar.Name = "btValidar"
        Me.btValidar.Size = New System.Drawing.Size(90, 23)
        Me.btValidar.TabIndex = 7
        Me.btValidar.Text = "Validar Arquivo"
        Me.ttInfo.SetToolTip(Me.btValidar, "Valida os dados conforme a Receita Federal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "e assina o arquivo digitalmente.")
        Me.btValidar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 535)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Digitada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(101, 535)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Arquivo Gerado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 535)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Transmitida"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(290, 535)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "DANFE Impressa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(402, 535)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Cancelada"
        '
        'btCancelamento
        '
        Me.btCancelamento.Location = New System.Drawing.Point(501, 326)
        Me.btCancelamento.Name = "btCancelamento"
        Me.btCancelamento.Size = New System.Drawing.Size(90, 23)
        Me.btCancelamento.TabIndex = 14
        Me.btCancelamento.Text = "Cancelamento"
        Me.ttInfo.SetToolTip(Me.btCancelamento, "Gerar e transmitir o XML de Cancelamento da NFe")
        Me.btCancelamento.UseVisualStyleBackColor = True
        '
        'bt_Inutilizacao
        '
        Me.bt_Inutilizacao.Location = New System.Drawing.Point(597, 326)
        Me.bt_Inutilizacao.Name = "bt_Inutilizacao"
        Me.bt_Inutilizacao.Size = New System.Drawing.Size(90, 23)
        Me.bt_Inutilizacao.TabIndex = 15
        Me.bt_Inutilizacao.Text = "Inutilização"
        Me.ttInfo.SetToolTip(Me.bt_Inutilizacao, "Transmitir a inutilização de uma faixa de númeração")
        Me.bt_Inutilizacao.UseVisualStyleBackColor = True
        '
        'btAlterar
        '
        Me.btAlterar.Location = New System.Drawing.Point(15, 326)
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(90, 23)
        Me.btAlterar.TabIndex = 16
        Me.btAlterar.Text = "Alterar"
        Me.ttInfo.SetToolTip(Me.btAlterar, "Alterar a NFe Desde que ela não tenha sido transmitida")
        Me.btAlterar.UseVisualStyleBackColor = True
        '
        'pnlInutilizacao
        '
        Me.pnlInutilizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInutilizacao.Controls.Add(Me.Label11)
        Me.pnlInutilizacao.Controls.Add(Me.txtSerie)
        Me.pnlInutilizacao.Controls.Add(Me.txtJust)
        Me.pnlInutilizacao.Controls.Add(Me.Label8)
        Me.pnlInutilizacao.Controls.Add(Me.Label9)
        Me.pnlInutilizacao.Controls.Add(Me.Label10)
        Me.pnlInutilizacao.Controls.Add(Me.txtNFeFIM)
        Me.pnlInutilizacao.Controls.Add(Me.txtNFeINI)
        Me.pnlInutilizacao.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlInutilizacao.Location = New System.Drawing.Point(242, 159)
        Me.pnlInutilizacao.Name = "pnlInutilizacao"
        Me.pnlInutilizacao.Size = New System.Drawing.Size(418, 143)
        Me.pnlInutilizacao.TabIndex = 17
        Me.pnlInutilizacao.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(265, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Série:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(316, 14)
        Me.txtSerie.MaxLength = 3
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(31, 20)
        Me.txtSerie.TabIndex = 10
        Me.txtSerie.Text = "001"
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtJust
        '
        Me.txtJust.Location = New System.Drawing.Point(113, 84)
        Me.txtJust.Name = "txtJust"
        Me.txtJust.Size = New System.Drawing.Size(295, 20)
        Me.txtJust.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Justificativa:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Numeração Final:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Numeração Inicial:"
        '
        'txtNFeFIM
        '
        Me.txtNFeFIM.Location = New System.Drawing.Point(113, 49)
        Me.txtNFeFIM.Name = "txtNFeFIM"
        Me.txtNFeFIM.Size = New System.Drawing.Size(72, 20)
        Me.txtNFeFIM.TabIndex = 9
        '
        'txtNFeINI
        '
        Me.txtNFeINI.Location = New System.Drawing.Point(113, 14)
        Me.txtNFeINI.Name = "txtNFeINI"
        Me.txtNFeINI.Size = New System.Drawing.Size(72, 20)
        Me.txtNFeINI.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(282, 106)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(126, 29)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(57, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(66, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(57, 23)
        Me.Cancel_Button.TabIndex = 0
        Me.Cancel_Button.Text = "Cancelar"
        '
        'lblCORGerada
        '
        Me.lblCORGerada.BackColor = System.Drawing.Color.Yellow
        Me.lblCORGerada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORGerada.Location = New System.Drawing.Point(88, 536)
        Me.lblCORGerada.Name = "lblCORGerada"
        Me.lblCORGerada.Size = New System.Drawing.Size(10, 10)
        Me.lblCORGerada.TabIndex = 18
        Me.lblCORGerada.Text = " "
        '
        'lblCORDigitada
        '
        Me.lblCORDigitada.BackColor = System.Drawing.Color.White
        Me.lblCORDigitada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORDigitada.Location = New System.Drawing.Point(18, 536)
        Me.lblCORDigitada.Name = "lblCORDigitada"
        Me.lblCORDigitada.Size = New System.Drawing.Size(10, 10)
        Me.lblCORDigitada.TabIndex = 19
        Me.lblCORDigitada.Text = " "
        '
        'lblCORTransmitida
        '
        Me.lblCORTransmitida.BackColor = System.Drawing.Color.LimeGreen
        Me.lblCORTransmitida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORTransmitida.Location = New System.Drawing.Point(194, 536)
        Me.lblCORTransmitida.Name = "lblCORTransmitida"
        Me.lblCORTransmitida.Size = New System.Drawing.Size(10, 10)
        Me.lblCORTransmitida.TabIndex = 20
        Me.lblCORTransmitida.Text = " "
        '
        'lblCORImpressa
        '
        Me.lblCORImpressa.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblCORImpressa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORImpressa.Location = New System.Drawing.Point(277, 536)
        Me.lblCORImpressa.Name = "lblCORImpressa"
        Me.lblCORImpressa.Size = New System.Drawing.Size(10, 10)
        Me.lblCORImpressa.TabIndex = 21
        Me.lblCORImpressa.Text = " "
        '
        'lblCORCancelada
        '
        Me.lblCORCancelada.BackColor = System.Drawing.Color.Crimson
        Me.lblCORCancelada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORCancelada.Location = New System.Drawing.Point(389, 536)
        Me.lblCORCancelada.Name = "lblCORCancelada"
        Me.lblCORCancelada.Size = New System.Drawing.Size(10, 10)
        Me.lblCORCancelada.TabIndex = 22
        Me.lblCORCancelada.Text = " "
        '
        'btLancar
        '
        Me.btLancar.Location = New System.Drawing.Point(501, 355)
        Me.btLancar.Name = "btLancar"
        Me.btLancar.Size = New System.Drawing.Size(90, 23)
        Me.btLancar.TabIndex = 7
        Me.btLancar.Text = "Lançamento"
        Me.ttInfo.SetToolTip(Me.btLancar, "Lançar a NFe em Contas à Receber")
        Me.btLancar.UseVisualStyleBackColor = True
        '
        'btExportar
        '
        Me.btExportar.Location = New System.Drawing.Point(15, 355)
        Me.btExportar.Name = "btExportar"
        Me.btExportar.Size = New System.Drawing.Size(90, 23)
        Me.btExportar.TabIndex = 23
        Me.btExportar.Text = "Exportar XML"
        Me.ttInfo.SetToolTip(Me.btExportar, "Exporta o XML apenas desta NFe para poder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ser enviado por e-mail etc...")
        Me.btExportar.UseVisualStyleBackColor = True
        '
        'btEmail
        '
        Me.btEmail.Location = New System.Drawing.Point(111, 355)
        Me.btEmail.Name = "btEmail"
        Me.btEmail.Size = New System.Drawing.Size(91, 23)
        Me.btEmail.TabIndex = 24
        Me.btEmail.Text = "XML E-mail"
        Me.ttInfo.SetToolTip(Me.btEmail, "Envia o XML desta NFe para o e-mail do cliente " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ou outro qualquer.")
        Me.btEmail.UseVisualStyleBackColor = True
        '
        'btPrintTermo
        '
        Me.btPrintTermo.Location = New System.Drawing.Point(397, 355)
        Me.btPrintTermo.Name = "btPrintTermo"
        Me.btPrintTermo.Size = New System.Drawing.Size(98, 23)
        Me.btPrintTermo.TabIndex = 26
        Me.btPrintTermo.Text = "Imprimir Termo"
        Me.ttInfo.SetToolTip(Me.btPrintTermo, "Imprime a DANFe")
        Me.btPrintTermo.UseVisualStyleBackColor = True
        '
        'btCorrecao
        '
        Me.btCorrecao.Location = New System.Drawing.Point(209, 354)
        Me.btCorrecao.Name = "btCorrecao"
        Me.btCorrecao.Size = New System.Drawing.Size(89, 23)
        Me.btCorrecao.TabIndex = 33
        Me.btCorrecao.Text = "C. Correção"
        Me.ttInfo.SetToolTip(Me.btCorrecao, "Imprime a DANFe")
        Me.btCorrecao.UseVisualStyleBackColor = True
        '
        'fbPasta
        '
        Me.fbPasta.Description = "Selecione a Pasta para Salvar o XML"
        '
        'btTermo
        '
        Me.btTermo.Location = New System.Drawing.Point(304, 355)
        Me.btTermo.Name = "btTermo"
        Me.btTermo.Size = New System.Drawing.Size(87, 23)
        Me.btTermo.TabIndex = 25
        Me.btTermo.Text = "Emitir Termo"
        Me.btTermo.UseVisualStyleBackColor = True
        '
        'pdImpressora
        '
        Me.pdImpressora.UseEXDialog = True
        '
        'lblCORInutilizada
        '
        Me.lblCORInutilizada.BackColor = System.Drawing.Color.DarkKhaki
        Me.lblCORInutilizada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCORInutilizada.Location = New System.Drawing.Point(477, 536)
        Me.lblCORInutilizada.Name = "lblCORInutilizada"
        Me.lblCORInutilizada.Size = New System.Drawing.Size(10, 10)
        Me.lblCORInutilizada.TabIndex = 28
        Me.lblCORInutilizada.Text = " "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(490, 535)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Inutilizada"
        '
        'pnlFrete
        '
        Me.pnlFrete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFrete.Controls.Add(Me.txtTransporte)
        Me.pnlFrete.Controls.Add(Me.btCancela_Frete)
        Me.pnlFrete.Controls.Add(Me.btOKFrete)
        Me.pnlFrete.Controls.Add(Me.txtDataFrete)
        Me.pnlFrete.Controls.Add(Me.Label13)
        Me.pnlFrete.Controls.Add(Me.txtVFrete)
        Me.pnlFrete.Controls.Add(Me.Label12)
        Me.pnlFrete.Controls.Add(Me.txtRastreador)
        Me.pnlFrete.Controls.Add(Me.Label7)
        Me.pnlFrete.Location = New System.Drawing.Point(450, 120)
        Me.pnlFrete.Name = "pnlFrete"
        Me.pnlFrete.Size = New System.Drawing.Size(208, 183)
        Me.pnlFrete.TabIndex = 0
        Me.pnlFrete.Visible = False
        '
        'txtTransporte
        '
        Me.txtTransporte.FormattingEnabled = True
        Me.txtTransporte.Items.AddRange(New Object() {"Correios", "JadLog", "Reunidas"})
        Me.txtTransporte.Location = New System.Drawing.Point(18, 54)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(180, 21)
        Me.txtTransporte.TabIndex = 1
        '
        'btCancela_Frete
        '
        Me.btCancela_Frete.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btCancela_Frete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancela_Frete.Location = New System.Drawing.Point(142, 149)
        Me.btCancela_Frete.Name = "btCancela_Frete"
        Me.btCancela_Frete.Size = New System.Drawing.Size(57, 23)
        Me.btCancela_Frete.TabIndex = 3
        Me.btCancela_Frete.Text = "Cancelar"
        '
        'btOKFrete
        '
        Me.btOKFrete.Location = New System.Drawing.Point(84, 149)
        Me.btOKFrete.Name = "btOKFrete"
        Me.btOKFrete.Size = New System.Drawing.Size(53, 23)
        Me.btOKFrete.TabIndex = 4
        Me.btOKFrete.Text = "OK"
        Me.btOKFrete.UseVisualStyleBackColor = True
        '
        'txtDataFrete
        '
        Me.txtDataFrete.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDataFrete.Location = New System.Drawing.Point(102, 109)
        Me.txtDataFrete.Name = "txtDataFrete"
        Me.txtDataFrete.Size = New System.Drawing.Size(95, 20)
        Me.txtDataFrete.TabIndex = 3
        Me.txtDataFrete.Value = New Date(2015, 6, 9, 14, 37, 5, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Data do Envio:"
        '
        'txtVFrete
        '
        Me.txtVFrete.Location = New System.Drawing.Point(102, 83)
        Me.txtVFrete.Name = "txtVFrete"
        Me.txtVFrete.Size = New System.Drawing.Size(64, 20)
        Me.txtVFrete.TabIndex = 2
        Me.txtVFrete.Text = "0,00"
        Me.txtVFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Valor:"
        '
        'txtRastreador
        '
        Me.txtRastreador.Location = New System.Drawing.Point(18, 28)
        Me.txtRastreador.Name = "txtRastreador"
        Me.txtRastreador.Size = New System.Drawing.Size(179, 20)
        Me.txtRastreador.TabIndex = 0
        Me.txtRastreador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Código do Rastreador/DACTE"
        '
        'webRastreador
        '
        Me.webRastreador.Location = New System.Drawing.Point(15, 10)
        Me.webRastreador.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webRastreador.Name = "webRastreador"
        Me.webRastreador.Size = New System.Drawing.Size(614, 274)
        Me.webRastreador.TabIndex = 30
        '
        'pnlCorreio
        '
        Me.pnlCorreio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCorreio.Controls.Add(Me.pnlInutilizacao)
        Me.pnlCorreio.Controls.Add(Me.bt_Fecha_Browser)
        Me.pnlCorreio.Controls.Add(Me.pnlFrete)
        Me.pnlCorreio.Controls.Add(Me.webRastreador)
        Me.pnlCorreio.Location = New System.Drawing.Point(26, 18)
        Me.pnlCorreio.Name = "pnlCorreio"
        Me.pnlCorreio.Size = New System.Drawing.Size(648, 322)
        Me.pnlCorreio.TabIndex = 30
        Me.pnlCorreio.Visible = False
        '
        'bt_Fecha_Browser
        '
        Me.bt_Fecha_Browser.Location = New System.Drawing.Point(576, 290)
        Me.bt_Fecha_Browser.Name = "bt_Fecha_Browser"
        Me.bt_Fecha_Browser.Size = New System.Drawing.Size(53, 23)
        Me.bt_Fecha_Browser.TabIndex = 31
        Me.bt_Fecha_Browser.Text = "Fechar"
        Me.bt_Fecha_Browser.UseVisualStyleBackColor = True
        '
        'cmbAno
        '
        Me.cmbAno.FormattingEnabled = True
        Me.cmbAno.Items.AddRange(New Object() {"2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016"})
        Me.cmbAno.Location = New System.Drawing.Point(611, 6)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(76, 21)
        Me.cmbAno.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(520, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Selecione o Ano"
        '
        'frmNFeFatura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 558)
        Me.Controls.Add(Me.btCorrecao)
        Me.Controls.Add(Me.pnlCorreio)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbAno)
        Me.Controls.Add(Me.lblCORInutilizada)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btPrintTermo)
        Me.Controls.Add(Me.btTermo)
        Me.Controls.Add(Me.btEmail)
        Me.Controls.Add(Me.btExportar)
        Me.Controls.Add(Me.btLancar)
        Me.Controls.Add(Me.lblCORCancelada)
        Me.Controls.Add(Me.lblCORImpressa)
        Me.Controls.Add(Me.lblCORTransmitida)
        Me.Controls.Add(Me.lblCORDigitada)
        Me.Controls.Add(Me.lblCORGerada)
        Me.Controls.Add(Me.btAlterar)
        Me.Controls.Add(Me.bt_Inutilizacao)
        Me.Controls.Add(Me.btCancelamento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btValidar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpAcompanhamento)
        Me.Controls.Add(Me.btDanfe)
        Me.Controls.Add(Me.btGerarXML)
        Me.Controls.Add(Me.btTransmitir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgNFs)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNFeFatura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Faturamento de NFe"
        CType(Me.dgNFs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuFuncoes.ResumeLayout(False)
        Me.grpAcompanhamento.ResumeLayout(False)
        Me.grpAcompanhamento.PerformLayout()
        Me.pnlInutilizacao.ResumeLayout(False)
        Me.pnlInutilizacao.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlFrete.ResumeLayout(False)
        Me.pnlFrete.PerformLayout()
        Me.pnlCorreio.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgNFs As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btTransmitir As System.Windows.Forms.Button
    Friend WithEvents btGerarXML As System.Windows.Forms.Button
    Friend WithEvents btDanfe As System.Windows.Forms.Button
    Friend WithEvents grpAcompanhamento As System.Windows.Forms.GroupBox
    Friend WithEvents txtMensagem As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tmrAguarda As System.Windows.Forms.Timer
    Friend WithEvents btValidar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btCancelamento As System.Windows.Forms.Button
    Friend WithEvents bt_Inutilizacao As System.Windows.Forms.Button
    Friend WithEvents btAlterar As System.Windows.Forms.Button
    Friend WithEvents pnlInutilizacao As System.Windows.Forms.Panel
    Friend WithEvents txtJust As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNFeFIM As System.Windows.Forms.TextBox
    Friend WithEvents txtNFeINI As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents btLancar As System.Windows.Forms.Button
    Friend WithEvents lblCORGerada As System.Windows.Forms.Label
    Friend WithEvents lblCORDigitada As System.Windows.Forms.Label
    Friend WithEvents lblCORTransmitida As System.Windows.Forms.Label
    Friend WithEvents lblCORImpressa As System.Windows.Forms.Label
    Friend WithEvents lblCORCancelada As System.Windows.Forms.Label
    Friend WithEvents ttInfo As System.Windows.Forms.ToolTip
    Friend WithEvents btExportar As System.Windows.Forms.Button
    Friend WithEvents btEmail As System.Windows.Forms.Button
    Friend WithEvents fbPasta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btTermo As System.Windows.Forms.Button
    Friend WithEvents pdImpressora As System.Windows.Forms.PrintDialog
    Friend WithEvents btPrintTermo As System.Windows.Forms.Button
    Friend WithEvents lblCORInutilizada As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents menuFuncoes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAlterar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuValidar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransmitir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDanfe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCancelar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTermo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintTermo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRegFrete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGerarXML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlFrete As System.Windows.Forms.Panel
    Friend WithEvents btCancela_Frete As System.Windows.Forms.Button
    Friend WithEvents btOKFrete As System.Windows.Forms.Button
    Friend WithEvents txtDataFrete As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVFrete As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRastreador As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mnuRastrear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents webRastreador As System.Windows.Forms.WebBrowser
    Friend WithEvents pnlCorreio As System.Windows.Forms.Panel
    Friend WithEvents bt_Fecha_Browser As System.Windows.Forms.Button
    Friend WithEvents mnuEnviarReg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAno As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btCorrecao As Button
End Class
