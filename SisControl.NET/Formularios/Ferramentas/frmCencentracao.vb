Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmConcentracoes
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'For the start-up form, the first instance created is the default instance.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
        Me.Show()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtHistorico As System.Windows.Forms.TextBox
	Public WithEvents lstHormonio As System.Windows.Forms.ListBox
	Public WithEvents txtMgL As System.Windows.Forms.TextBox
	Public WithEvents txtLitros As System.Windows.Forms.TextBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button()
        Me.txtHistorico = New System.Windows.Forms.TextBox()
        Me.lstHormonio = New System.Windows.Forms.ListBox()
        Me.txtMgL = New System.Windows.Forms.TextBox()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.CancelButton_Renamed = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(312, 240)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(81, 25)
        Me.Command1.TabIndex = 6
        Me.Command1.Text = "Limpar"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'txtHistorico
        '
        Me.txtHistorico.AcceptsReturn = True
        Me.txtHistorico.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistorico.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistorico.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistorico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistorico.Location = New System.Drawing.Point(16, 208)
        Me.txtHistorico.MaxLength = 0
        Me.txtHistorico.Multiline = True
        Me.txtHistorico.Name = "txtHistorico"
        Me.txtHistorico.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHistorico.Size = New System.Drawing.Size(225, 153)
        Me.txtHistorico.TabIndex = 5
        '
        'lstHormonio
        '
        Me.lstHormonio.BackColor = System.Drawing.SystemColors.Window
        Me.lstHormonio.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstHormonio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHormonio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstHormonio.Items.AddRange(New Object() {"BAP - Benzilaminopurina", "2,4D - DicloroFenoxyAcético", "KIN - Cinetina", "AIB - Ácido Indol Butírico", "ANA - Ácido Naftaleno Acético", "AIA - Ácido Indol Acético", "ABA - Ácido Abcísico", "TDZ - Tidiazuron", "GA3 - Ácido Giberélico", "2iP - 2, Isopentenil Adenina"})
        Me.lstHormonio.Location = New System.Drawing.Point(16, 80)
        Me.lstHormonio.Name = "lstHormonio"
        Me.lstHormonio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstHormonio.Size = New System.Drawing.Size(225, 82)
        Me.lstHormonio.TabIndex = 2
        '
        'txtMgL
        '
        Me.txtMgL.AcceptsReturn = True
        Me.txtMgL.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgL.Location = New System.Drawing.Point(160, 40)
        Me.txtMgL.MaxLength = 0
        Me.txtMgL.Name = "txtMgL"
        Me.txtMgL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgL.Size = New System.Drawing.Size(49, 20)
        Me.txtMgL.TabIndex = 1
        Me.txtMgL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLitros
        '
        Me.txtLitros.AcceptsReturn = True
        Me.txtLitros.BackColor = System.Drawing.SystemColors.Window
        Me.txtLitros.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLitros.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitros.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLitros.Location = New System.Drawing.Point(160, 16)
        Me.txtLitros.MaxLength = 0
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLitros.Size = New System.Drawing.Size(49, 20)
        Me.txtLitros.TabIndex = 0
        Me.txtLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CancelButton_Renamed
        '
        Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelButton_Renamed.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelButton_Renamed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelButton_Renamed.Location = New System.Drawing.Point(312, 16)
        Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
        Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelButton_Renamed.Size = New System.Drawing.Size(81, 25)
        Me.CancelButton_Renamed.TabIndex = 4
        Me.CancelButton_Renamed.Text = "Limpar"
        Me.CancelButton_Renamed.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OKButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(312, 208)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(81, 25)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "Calcular"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cálculos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Hormônio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(216, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Mg/L"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(140, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Concentração do Hormônio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(216, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Litros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Quantidade de Meio:"
        '
        'frmConcentracoes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(408, 400)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtHistorico)
        Me.Controls.Add(Me.lstHormonio)
        Me.Controls.Add(Me.txtMgL)
        Me.Controls.Add(Me.txtLitros)
        Me.Controls.Add(Me.CancelButton_Renamed)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConcentracoes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculadora de Concentrações"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmConcentracoes
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmConcentracoes
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmConcentracoes()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
    Dim CONC(10) As Double
    Dim Nome(10) As String
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
        txtLitros.Text = ""
        txtMgL.Text = ""
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        txtHistorico.Text = ""
    End Sub

    Private Sub frmConcentracoes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(sender, e)
    End Sub
	
	
    Private Sub frmConcentracoes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Preenche as concentrações dos hormonios conforme aparece na lista (em mg/L)
        CONC(1) = MGL_BAP
        CONC(2) = MGL_24D
        CONC(3) = MGL_KIN
        CONC(4) = MGL_AIB
        CONC(5) = MGL_ANA
        CONC(6) = MGL_AIA
        CONC(7) = MGL_ABA
        CONC(8) = MGL_TDZ
        CONC(9) = MGL_GA3
        CONC(10) = MGL_2IP

        'Nomes
        Nome(1) = "BAP"
        Nome(2) = "2,4D"
        Nome(3) = "KIN"
        Nome(4) = "AIB"
        Nome(5) = "ANA"
        Nome(6) = "AIA"
        Nome(7) = "ABA"
        Nome(8) = "TDZ"
        Nome(9) = "GA3"
        Nome(10) = "2iP"

    End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Dim Indice As Short
		Dim Resultado As Double
        'Verifica qual hormonio foi selecionado
        Indice = lstHormonio.SelectedIndex + 1
        'Faz o cálculo efetivamente
        Resultado = (String_to_Numero(txtLitros.Text) * String_to_Numero(txtMgL.Text) / CONC(Indice) * 1000)
        'Apresenta o resultado formatado para 3 casas
        txtHistorico.Text = txtHistorico.Text & Nome(Indice) & " " & VB.Right("..........", 8 - Len(Nome(Indice))) & " " & Format(Resultado, "F0") & Chr(181) & "L" & vbCrLf
    End Sub

    Private Sub txtLitros_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLitros.Leave
        txtLitros.Text = Format(String_to_Numero(txtLitros.Text), "F3")
    End Sub

    Private Sub txtMgL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMgL.Leave
        txtMgL.Text = Format(String_to_Numero(txtMgL.Text), "F3")
    End Sub
End Class