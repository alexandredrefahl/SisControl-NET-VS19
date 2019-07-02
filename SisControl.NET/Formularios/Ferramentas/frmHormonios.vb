Option Strict Off
Option Explicit On
Friend Class frmHormonios
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
		'This form is an MDI child.
		'This code simulates the VB6 
		' functionality of automatically
		' loading and showing an MDI
		' child's parent.
        'The MDI form in the VB6 project had its
		'AutoShowChildren property set to True
		'To simulate the VB6 behavior, we need to
		'automatically Show the form whenever it
		'is loaded.  If you do not want this behavior
		'then delete the following line of code
		'UPGRADE_NOTE: Remove the next line of code to stop form from automatically showing. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2018"'
		Me.Show
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
    Public WithEvents txtMgL As System.Windows.Forms.TextBox
	Public WithEvents txtMicroMol As System.Windows.Forms.TextBox
	Public WithEvents txtPM As System.Windows.Forms.TextBox
    Public WithEvents optConversao_1 As System.Windows.Forms.RadioButton
    Public WithEvents optConversao_0 As System.Windows.Forms.RadioButton
    Public WithEvents cmdLimpar As System.Windows.Forms.Button
    Public WithEvents cmdCalcular As System.Windows.Forms.Button
    Public WithEvents lstHormonio As System.Windows.Forms.ListBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents optConversao As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtMgL = New System.Windows.Forms.TextBox()
        Me.txtMicroMol = New System.Windows.Forms.TextBox()
        Me.txtPM = New System.Windows.Forms.TextBox()
        Me.optConversao_1 = New System.Windows.Forms.RadioButton()
        Me.optConversao_0 = New System.Windows.Forms.RadioButton()
        Me.cmdLimpar = New System.Windows.Forms.Button()
        Me.cmdCalcular = New System.Windows.Forms.Button()
        Me.lstHormonio = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMgL
        '
        Me.txtMgL.AcceptsReturn = True
        Me.txtMgL.BackColor = System.Drawing.SystemColors.Window
        Me.txtMgL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMgL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMgL.Location = New System.Drawing.Point(320, 136)
        Me.txtMgL.MaxLength = 0
        Me.txtMgL.Name = "txtMgL"
        Me.txtMgL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMgL.Size = New System.Drawing.Size(65, 20)
        Me.txtMgL.TabIndex = 8
        Me.txtMgL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMicroMol
        '
        Me.txtMicroMol.AcceptsReturn = True
        Me.txtMicroMol.BackColor = System.Drawing.SystemColors.Window
        Me.txtMicroMol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMicroMol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMicroMol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMicroMol.Location = New System.Drawing.Point(320, 112)
        Me.txtMicroMol.MaxLength = 0
        Me.txtMicroMol.Name = "txtMicroMol"
        Me.txtMicroMol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMicroMol.Size = New System.Drawing.Size(65, 20)
        Me.txtMicroMol.TabIndex = 7
        Me.txtMicroMol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPM
        '
        Me.txtPM.AcceptsReturn = True
        Me.txtPM.BackColor = System.Drawing.SystemColors.Window
        Me.txtPM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPM.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPM.Location = New System.Drawing.Point(320, 88)
        Me.txtPM.MaxLength = 0
        Me.txtPM.Name = "txtPM"
        Me.txtPM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPM.Size = New System.Drawing.Size(65, 20)
        Me.txtPM.TabIndex = 6
        Me.txtPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'optConversao_1
        '
        Me.optConversao_1.BackColor = System.Drawing.SystemColors.Control
        Me.optConversao_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.optConversao_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optConversao_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optConversao_1.Location = New System.Drawing.Point(224, 48)
        Me.optConversao_1.Name = "optConversao_1"
        Me.optConversao_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optConversao_1.Size = New System.Drawing.Size(130, 21)
        Me.optConversao_1.TabIndex = 5
        Me.optConversao_1.TabStop = True
        Me.optConversao_1.Text = "microM --> mg/L"
        Me.optConversao_1.UseVisualStyleBackColor = False
        '
        'optConversao_0
        '
        Me.optConversao_0.BackColor = System.Drawing.SystemColors.Control
        Me.optConversao_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.optConversao_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optConversao_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optConversao_0.Location = New System.Drawing.Point(224, 24)
        Me.optConversao_0.Name = "optConversao_0"
        Me.optConversao_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optConversao_0.Size = New System.Drawing.Size(130, 18)
        Me.optConversao_0.TabIndex = 4
        Me.optConversao_0.TabStop = True
        Me.optConversao_0.Text = "mg/L --> microM"
        Me.optConversao_0.UseVisualStyleBackColor = False
        '
        'cmdLimpar
        '
        Me.cmdLimpar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLimpar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLimpar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLimpar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLimpar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLimpar.Location = New System.Drawing.Point(288, 168)
        Me.cmdLimpar.Name = "cmdLimpar"
        Me.cmdLimpar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLimpar.Size = New System.Drawing.Size(97, 25)
        Me.cmdLimpar.TabIndex = 3
        Me.cmdLimpar.Text = "Limpar"
        Me.cmdLimpar.UseVisualStyleBackColor = False
        '
        'cmdCalcular
        '
        Me.cmdCalcular.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalcular.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalcular.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCalcular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalcular.Location = New System.Drawing.Point(185, 168)
        Me.cmdCalcular.Name = "cmdCalcular"
        Me.cmdCalcular.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalcular.Size = New System.Drawing.Size(97, 25)
        Me.cmdCalcular.TabIndex = 2
        Me.cmdCalcular.Text = "Calcular"
        Me.cmdCalcular.UseVisualStyleBackColor = False
        '
        'lstHormonio
        '
        Me.lstHormonio.BackColor = System.Drawing.SystemColors.Window
        Me.lstHormonio.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstHormonio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHormonio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstHormonio.Items.AddRange(New Object() {"BAP - Benzilaminopurina", "2,4D - DicloroFenoxyAcético", "KIN - Cinetina", "AIB - Ácido Indol Butírico", "ANA - Ácido Naftaleno Acético", "AIA - Ácido Indol Acético", "ABA - Ácido Abcísico", "TDZ - Tidiazuron", "GA3 - Ácido Giberélico", "2iP - 2, Isopentenil Adenina"})
        Me.lstHormonio.Location = New System.Drawing.Point(8, 24)
        Me.lstHormonio.Name = "lstHormonio"
        Me.lstHormonio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstHormonio.Size = New System.Drawing.Size(201, 134)
        Me.lstHormonio.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(224, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Valor em mg/L"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(224, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Valor em microMol:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(224, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Peso Molecular:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selecione um Hormônio:"
        '
        'frmHormonios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(397, 201)
        Me.Controls.Add(Me.txtMgL)
        Me.Controls.Add(Me.txtMicroMol)
        Me.Controls.Add(Me.txtPM)
        Me.Controls.Add(Me.optConversao_1)
        Me.Controls.Add(Me.optConversao_0)
        Me.Controls.Add(Me.cmdLimpar)
        Me.Controls.Add(Me.cmdCalcular)
        Me.Controls.Add(Me.lstHormonio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(452, 316)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHormonios"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculadora de Hormônios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmHormonios
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmHormonios
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmHormonios()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 



    Dim PM(10) As Double
	
	Private Sub cmdCalcular_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalcular.Click
        If optConversao_0.Checked = True Then 'mg/L para MicroMol
            txtMicroMol.Text = Format((String_to_Numero(txtMgL.Text) / String_to_Numero(txtPM.Text)) * (10 ^ 3), "F4")
        ElseIf optConversao_1.Checked = True Then  'MicroMol para Mg/L
            txtMgL.Text = Format((10 ^ -3) * String_to_Numero(txtMicroMol.Text) * String_to_Numero(txtPM.Text), "F4")
        End If
	End Sub
	
	Private Sub cmdLimpar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLimpar.Click
        txtPM.Text = ""
        txtMicroMol.Text = ""
        txtMgL.Text = ""
        optConversao_0.Checked = True
	End Sub
	
	Private Sub frmHormonios_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Preenche os pesos dos hormonios conforme aparece na lista
        PM(1) = 225.3   'BAP
        PM(2) = 221     '2,4D
        PM(3) = 215.2   'KIN
        PM(4) = 203.2   'AIB
        PM(5) = 186.2   'ANA
        PM(6) = 175.2   'AIA
        PM(7) = 264.3   'ABA
        PM(8) = 220.2   'TDZ
        PM(9) = 346.4   'GA3
        PM(10) = 203.2  '2iP

        optConversao_0.Text = "Mg/L --> " & ChrW(181) & "M"
        optConversao_1.Text = ChrW(181) & "M --> Mg/L"
	End Sub
	
    Private Sub lstHormonio_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstHormonio.SelectedIndexChanged
        txtPM.Text = Format(PM(lstHormonio.SelectedIndex + 1), "F4")
    End Sub
	
    Private Sub txtMgL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMgL.Leave
        txtMgL.Text = Format(String_to_Numero(txtMgL.Text), "F4")
    End Sub
	
	Private Sub txtMicroMol_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMicroMol.Leave
        txtMicroMol.Text = Format(String_to_Numero(txtMicroMol.Text), "F4")
	End Sub

    Private Sub optConversao_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optConversao_0.CheckedChanged
        Trata_Conversao()
    End Sub

    Private Sub optConversao_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optConversao_1.CheckedChanged
        Trata_Conversao()
    End Sub

    Sub Trata_Conversao()
        If optConversao_0.Checked = True Then
            txtMgL.ForeColor = System.Drawing.Color.Blue
            txtMicroMol.ForeColor = System.Drawing.Color.Black
            txtMicroMol.Text = ""
            txtMgL.Focus()
        ElseIf optConversao_1.Checked = True Then
            txtMicroMol.ForeColor = System.Drawing.Color.Blue
            txtMgL.ForeColor = System.Drawing.Color.Black
            txtMgL.Text = ""
            txtMicroMol.Focus()
        End If
    End Sub
End Class