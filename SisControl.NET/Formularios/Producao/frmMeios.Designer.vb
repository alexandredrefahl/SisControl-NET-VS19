<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeios
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbMeio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDescricao = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConstituicao = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.tpHormonios = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPH = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbBase = New System.Windows.Forms.ComboBox()
        Me.txtKIN = New System.Windows.Forms.TextBox()
        Me.txtTDZ = New System.Windows.Forms.TextBox()
        Me.txtGA3 = New System.Windows.Forms.TextBox()
        Me.txt2IP = New System.Windows.Forms.TextBox()
        Me.txt24D = New System.Windows.Forms.TextBox()
        Me.txtBAP = New System.Windows.Forms.TextBox()
        Me.txtANA = New System.Windows.Forms.TextBox()
        Me.txtAIB = New System.Windows.Forms.TextBox()
        Me.txtAIA = New System.Windows.Forms.TextBox()
        Me.txtABA = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tpCores = New System.Windows.Forms.TabPage()
        Me.txtCor2 = New System.Windows.Forms.TextBox()
        Me.txtCor1 = New System.Windows.Forms.TextBox()
        Me.btCor2 = New System.Windows.Forms.Button()
        Me.lblCor2 = New System.Windows.Forms.Label()
        Me.btCor1 = New System.Windows.Forms.Button()
        Me.lblCor1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cdCores = New System.Windows.Forms.ColorDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.tpOutros = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtOutros = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.tpDescricao.SuspendLayout()
        Me.tpHormonios.SuspendLayout()
        Me.tpCores.SuspendLayout()
        Me.tpOutros.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMeio
        '
        Me.cmbMeio.FormattingEnabled = True
        Me.cmbMeio.Location = New System.Drawing.Point(95, 12)
        Me.cmbMeio.Name = "cmbMeio"
        Me.cmbMeio.Size = New System.Drawing.Size(306, 21)
        Me.cmbMeio.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Localize o Meio:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpDescricao)
        Me.TabControl1.Controls.Add(Me.tpHormonios)
        Me.TabControl1.Controls.Add(Me.tpOutros)
        Me.TabControl1.Controls.Add(Me.tpCores)
        Me.TabControl1.Location = New System.Drawing.Point(8, 43)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(397, 226)
        Me.TabControl1.TabIndex = 11
        '
        'tpDescricao
        '
        Me.tpDescricao.Controls.Add(Me.Label3)
        Me.tpDescricao.Controls.Add(Me.Label2)
        Me.tpDescricao.Controls.Add(Me.txtConstituicao)
        Me.tpDescricao.Controls.Add(Me.txtDescricao)
        Me.tpDescricao.Location = New System.Drawing.Point(4, 22)
        Me.tpDescricao.Name = "tpDescricao"
        Me.tpDescricao.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDescricao.Size = New System.Drawing.Size(389, 200)
        Me.tpDescricao.TabIndex = 0
        Me.tpDescricao.Text = "Descrição"
        Me.tpDescricao.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Composição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Descrição"
        '
        'txtConstituicao
        '
        Me.txtConstituicao.AcceptsReturn = True
        Me.txtConstituicao.AcceptsTab = True
        Me.txtConstituicao.AllowDrop = True
        Me.txtConstituicao.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConstituicao.Location = New System.Drawing.Point(79, 39)
        Me.txtConstituicao.Multiline = True
        Me.txtConstituicao.Name = "txtConstituicao"
        Me.txtConstituicao.Size = New System.Drawing.Size(288, 143)
        Me.txtConstituicao.TabIndex = 10
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(79, 13)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(288, 20)
        Me.txtDescricao.TabIndex = 9
        '
        'tpHormonios
        '
        Me.tpHormonios.Controls.Add(Me.Label4)
        Me.tpHormonios.Controls.Add(Me.txtPH)
        Me.tpHormonios.Controls.Add(Me.Label16)
        Me.tpHormonios.Controls.Add(Me.cmbBase)
        Me.tpHormonios.Controls.Add(Me.txtKIN)
        Me.tpHormonios.Controls.Add(Me.txtTDZ)
        Me.tpHormonios.Controls.Add(Me.txtGA3)
        Me.tpHormonios.Controls.Add(Me.txt2IP)
        Me.tpHormonios.Controls.Add(Me.txt24D)
        Me.tpHormonios.Controls.Add(Me.txtBAP)
        Me.tpHormonios.Controls.Add(Me.txtANA)
        Me.tpHormonios.Controls.Add(Me.txtAIB)
        Me.tpHormonios.Controls.Add(Me.txtAIA)
        Me.tpHormonios.Controls.Add(Me.txtABA)
        Me.tpHormonios.Controls.Add(Me.Label15)
        Me.tpHormonios.Controls.Add(Me.Label14)
        Me.tpHormonios.Controls.Add(Me.Label13)
        Me.tpHormonios.Controls.Add(Me.Label12)
        Me.tpHormonios.Controls.Add(Me.Label11)
        Me.tpHormonios.Controls.Add(Me.Label10)
        Me.tpHormonios.Controls.Add(Me.Label9)
        Me.tpHormonios.Controls.Add(Me.Label8)
        Me.tpHormonios.Controls.Add(Me.Label7)
        Me.tpHormonios.Controls.Add(Me.Label6)
        Me.tpHormonios.Location = New System.Drawing.Point(4, 22)
        Me.tpHormonios.Name = "tpHormonios"
        Me.tpHormonios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHormonios.Size = New System.Drawing.Size(389, 200)
        Me.tpHormonios.TabIndex = 1
        Me.tpHormonios.Text = "Hormônios"
        Me.tpHormonios.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(307, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "pH"
        '
        'txtPH
        '
        Me.txtPH.Location = New System.Drawing.Point(334, 16)
        Me.txtPH.Name = "txtPH"
        Me.txtPH.Size = New System.Drawing.Size(42, 20)
        Me.txtPH.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(8, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Meio Base:"
        '
        'cmbBase
        '
        Me.cmbBase.FormattingEnabled = True
        Me.cmbBase.Location = New System.Drawing.Point(74, 15)
        Me.cmbBase.Name = "cmbBase"
        Me.cmbBase.Size = New System.Drawing.Size(210, 21)
        Me.cmbBase.TabIndex = 20
        '
        'txtKIN
        '
        Me.txtKIN.Location = New System.Drawing.Point(224, 162)
        Me.txtKIN.Name = "txtKIN"
        Me.txtKIN.Size = New System.Drawing.Size(60, 20)
        Me.txtKIN.TabIndex = 19
        Me.txtKIN.Text = "0,00"
        Me.txtKIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTDZ
        '
        Me.txtTDZ.Location = New System.Drawing.Point(224, 136)
        Me.txtTDZ.Name = "txtTDZ"
        Me.txtTDZ.Size = New System.Drawing.Size(60, 20)
        Me.txtTDZ.TabIndex = 18
        Me.txtTDZ.Text = "0,00"
        Me.txtTDZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGA3
        '
        Me.txtGA3.Location = New System.Drawing.Point(224, 110)
        Me.txtGA3.Name = "txtGA3"
        Me.txtGA3.Size = New System.Drawing.Size(60, 20)
        Me.txtGA3.TabIndex = 17
        Me.txtGA3.Text = "0,00"
        Me.txtGA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt2IP
        '
        Me.txt2IP.Location = New System.Drawing.Point(224, 84)
        Me.txt2IP.Name = "txt2IP"
        Me.txt2IP.Size = New System.Drawing.Size(60, 20)
        Me.txt2IP.TabIndex = 16
        Me.txt2IP.Text = "0,00"
        Me.txt2IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt24D
        '
        Me.txt24D.Location = New System.Drawing.Point(224, 58)
        Me.txt24D.Name = "txt24D"
        Me.txt24D.Size = New System.Drawing.Size(60, 20)
        Me.txt24D.TabIndex = 15
        Me.txt24D.Text = "0,00"
        Me.txt24D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBAP
        '
        Me.txtBAP.Location = New System.Drawing.Point(45, 162)
        Me.txtBAP.Name = "txtBAP"
        Me.txtBAP.Size = New System.Drawing.Size(60, 20)
        Me.txtBAP.TabIndex = 14
        Me.txtBAP.Text = "0,00"
        Me.txtBAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtANA
        '
        Me.txtANA.Location = New System.Drawing.Point(45, 136)
        Me.txtANA.Name = "txtANA"
        Me.txtANA.Size = New System.Drawing.Size(60, 20)
        Me.txtANA.TabIndex = 13
        Me.txtANA.Text = "0,00"
        Me.txtANA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAIB
        '
        Me.txtAIB.Location = New System.Drawing.Point(45, 110)
        Me.txtAIB.Name = "txtAIB"
        Me.txtAIB.Size = New System.Drawing.Size(60, 20)
        Me.txtAIB.TabIndex = 12
        Me.txtAIB.Text = "0,00"
        Me.txtAIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAIA
        '
        Me.txtAIA.Location = New System.Drawing.Point(45, 84)
        Me.txtAIA.Name = "txtAIA"
        Me.txtAIA.Size = New System.Drawing.Size(60, 20)
        Me.txtAIA.TabIndex = 11
        Me.txtAIA.Text = "0,00"
        Me.txtAIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtABA
        '
        Me.txtABA.Location = New System.Drawing.Point(45, 58)
        Me.txtABA.Name = "txtABA"
        Me.txtABA.Size = New System.Drawing.Size(60, 20)
        Me.txtABA.TabIndex = 10
        Me.txtABA.Text = "0,00"
        Me.txtABA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(187, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "TDZ:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(187, 165)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "KIN:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(188, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "GA3:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(188, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "2iP:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(187, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "2,4D:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "ABA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "BAP:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "ANA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "AIB:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "AIA:"
        '
        'tpCores
        '
        Me.tpCores.Controls.Add(Me.txtCor2)
        Me.tpCores.Controls.Add(Me.txtCor1)
        Me.tpCores.Controls.Add(Me.btCor2)
        Me.tpCores.Controls.Add(Me.lblCor2)
        Me.tpCores.Controls.Add(Me.btCor1)
        Me.tpCores.Controls.Add(Me.lblCor1)
        Me.tpCores.Controls.Add(Me.Label1)
        Me.tpCores.Location = New System.Drawing.Point(4, 22)
        Me.tpCores.Name = "tpCores"
        Me.tpCores.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCores.Size = New System.Drawing.Size(389, 200)
        Me.tpCores.TabIndex = 2
        Me.tpCores.Text = "Cores"
        Me.tpCores.UseVisualStyleBackColor = True
        '
        'txtCor2
        '
        Me.txtCor2.Location = New System.Drawing.Point(83, 47)
        Me.txtCor2.Name = "txtCor2"
        Me.txtCor2.Size = New System.Drawing.Size(100, 20)
        Me.txtCor2.TabIndex = 6
        '
        'txtCor1
        '
        Me.txtCor1.Location = New System.Drawing.Point(83, 13)
        Me.txtCor1.Name = "txtCor1"
        Me.txtCor1.Size = New System.Drawing.Size(100, 20)
        Me.txtCor1.TabIndex = 5
        '
        'btCor2
        '
        Me.btCor2.Location = New System.Drawing.Point(189, 44)
        Me.btCor2.Name = "btCor2"
        Me.btCor2.Size = New System.Drawing.Size(24, 24)
        Me.btCor2.TabIndex = 4
        Me.btCor2.Text = "..."
        Me.btCor2.UseVisualStyleBackColor = True
        '
        'lblCor2
        '
        Me.lblCor2.BackColor = System.Drawing.Color.Cornsilk
        Me.lblCor2.Location = New System.Drawing.Point(50, 44)
        Me.lblCor2.Name = "lblCor2"
        Me.lblCor2.Size = New System.Drawing.Size(24, 24)
        Me.lblCor2.TabIndex = 3
        '
        'btCor1
        '
        Me.btCor1.Location = New System.Drawing.Point(189, 11)
        Me.btCor1.Name = "btCor1"
        Me.btCor1.Size = New System.Drawing.Size(24, 24)
        Me.btCor1.TabIndex = 2
        Me.btCor1.Text = "..."
        Me.btCor1.UseVisualStyleBackColor = True
        '
        'lblCor1
        '
        Me.lblCor1.BackColor = System.Drawing.Color.Cornsilk
        Me.lblCor1.ForeColor = System.Drawing.Color.White
        Me.lblCor1.Location = New System.Drawing.Point(50, 11)
        Me.lblCor1.Name = "lblCor1"
        Me.lblCor1.Size = New System.Drawing.Size(24, 24)
        Me.lblCor1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cores"
        '
        'cdCores
        '
        Me.cdCores.AnyColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(245, 275)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Salvar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(326, 275)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(164, 275)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Novo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'tpOutros
        '
        Me.tpOutros.Controls.Add(Me.txtOutros)
        Me.tpOutros.Controls.Add(Me.Label17)
        Me.tpOutros.Location = New System.Drawing.Point(4, 22)
        Me.tpOutros.Name = "tpOutros"
        Me.tpOutros.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOutros.Size = New System.Drawing.Size(389, 200)
        Me.tpOutros.TabIndex = 3
        Me.tpOutros.Text = "Outros"
        Me.tpOutros.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Outros"
        '
        'txtOutros
        '
        Me.txtOutros.Location = New System.Drawing.Point(77, 15)
        Me.txtOutros.Multiline = True
        Me.txtOutros.Name = "txtOutros"
        Me.txtOutros.Size = New System.Drawing.Size(298, 110)
        Me.txtOutros.TabIndex = 1
        '
        'frmMeios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 305)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbMeio)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMeios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Meios de Cultura"
        Me.TabControl1.ResumeLayout(False)
        Me.tpDescricao.ResumeLayout(False)
        Me.tpDescricao.PerformLayout()
        Me.tpHormonios.ResumeLayout(False)
        Me.tpHormonios.PerformLayout()
        Me.tpCores.ResumeLayout(False)
        Me.tpCores.PerformLayout()
        Me.tpOutros.ResumeLayout(False)
        Me.tpOutros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMeio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDescricao As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConstituicao As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents tpHormonios As System.Windows.Forms.TabPage
    Friend WithEvents txtKIN As System.Windows.Forms.TextBox
    Friend WithEvents txtTDZ As System.Windows.Forms.TextBox
    Friend WithEvents txtGA3 As System.Windows.Forms.TextBox
    Friend WithEvents txt2IP As System.Windows.Forms.TextBox
    Friend WithEvents txt24D As System.Windows.Forms.TextBox
    Friend WithEvents txtBAP As System.Windows.Forms.TextBox
    Friend WithEvents txtANA As System.Windows.Forms.TextBox
    Friend WithEvents txtAIB As System.Windows.Forms.TextBox
    Friend WithEvents txtAIA As System.Windows.Forms.TextBox
    Friend WithEvents txtABA As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbBase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPH As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tpCores As System.Windows.Forms.TabPage
    Friend WithEvents btCor2 As System.Windows.Forms.Button
    Friend WithEvents lblCor2 As System.Windows.Forms.Label
    Friend WithEvents btCor1 As System.Windows.Forms.Button
    Friend WithEvents lblCor1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCor1 As System.Windows.Forms.TextBox
    Friend WithEvents cdCores As System.Windows.Forms.ColorDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents tpOutros As System.Windows.Forms.TabPage
    Friend WithEvents txtOutros As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
