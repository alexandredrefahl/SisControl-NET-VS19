Option Strict Off
Option Explicit On

Friend Class frmAplicaClientes
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
    Public WithEvents cmdVoltar As System.Windows.Forms.Button
	Public WithEvents cmdLimpa As System.Windows.Forms.Button
	Public WithEvents cmdAtribuir As System.Windows.Forms.Button
	Public WithEvents cmd As System.Windows.Forms.Button
	Public WithEvents lstSel As System.Windows.Forms.ListBox
	Public WithEvents lstLotes As System.Windows.Forms.ListBox
	Public WithEvents lstClientes As System.Windows.Forms.ListBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblID As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAplicaClientes))
        Me.cmdVoltar = New System.Windows.Forms.Button
        Me.cmdLimpa = New System.Windows.Forms.Button
        Me.cmdAtribuir = New System.Windows.Forms.Button
        Me.cmd = New System.Windows.Forms.Button
        Me.lstSel = New System.Windows.Forms.ListBox
        Me.lstLotes = New System.Windows.Forms.ListBox
        Me.lstClientes = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdVoltar
        '
        Me.cmdVoltar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVoltar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVoltar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoltar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVoltar.Image = CType(resources.GetObject("cmdVoltar.Image"), System.Drawing.Image)
        Me.cmdVoltar.Location = New System.Drawing.Point(168, 224)
        Me.cmdVoltar.Name = "cmdVoltar"
        Me.cmdVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoltar.Size = New System.Drawing.Size(81, 25)
        Me.cmdVoltar.TabIndex = 9
        Me.cmdVoltar.Text = "<<"
        Me.cmdVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdVoltar.UseVisualStyleBackColor = False
        '
        'cmdLimpa
        '
        Me.cmdLimpa.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLimpa.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLimpa.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLimpa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLimpa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLimpa.Location = New System.Drawing.Point(168, 304)
        Me.cmdLimpa.Name = "cmdLimpa"
        Me.cmdLimpa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLimpa.Size = New System.Drawing.Size(81, 25)
        Me.cmdLimpa.TabIndex = 8
        Me.cmdLimpa.Text = "Limpa Seleção"
        Me.cmdLimpa.UseVisualStyleBackColor = False
        '
        'cmdAtribuir
        '
        Me.cmdAtribuir.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAtribuir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAtribuir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAtribuir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAtribuir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAtribuir.Location = New System.Drawing.Point(264, 384)
        Me.cmdAtribuir.Name = "cmdAtribuir"
        Me.cmdAtribuir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAtribuir.Size = New System.Drawing.Size(137, 25)
        Me.cmdAtribuir.TabIndex = 5
        Me.cmdAtribuir.Text = "Atribuir Selecionados"
        Me.cmdAtribuir.UseVisualStyleBackColor = False
        '
        'cmd
        '
        Me.cmd.BackColor = System.Drawing.SystemColors.Control
        Me.cmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd.Image = CType(resources.GetObject("cmd.Image"), System.Drawing.Image)
        Me.cmd.Location = New System.Drawing.Point(168, 264)
        Me.cmd.Name = "cmd"
        Me.cmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd.Size = New System.Drawing.Size(81, 25)
        Me.cmd.TabIndex = 4
        Me.cmd.Text = ">>"
        Me.cmd.UseVisualStyleBackColor = False
        '
        'lstSel
        '
        Me.lstSel.BackColor = System.Drawing.SystemColors.Window
        Me.lstSel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSel.Location = New System.Drawing.Point(264, 176)
        Me.lstSel.Name = "lstSel"
        Me.lstSel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSel.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSel.Size = New System.Drawing.Size(137, 199)
        Me.lstSel.Sorted = True
        Me.lstSel.TabIndex = 3
        '
        'lstLotes
        '
        Me.lstLotes.BackColor = System.Drawing.SystemColors.Window
        Me.lstLotes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLotes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLotes.Location = New System.Drawing.Point(16, 176)
        Me.lstLotes.Name = "lstLotes"
        Me.lstLotes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLotes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstLotes.Size = New System.Drawing.Size(137, 199)
        Me.lstLotes.Sorted = True
        Me.lstLotes.TabIndex = 2
        '
        'lstClientes
        '
        Me.lstClientes.BackColor = System.Drawing.SystemColors.Window
        Me.lstClientes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstClientes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstClientes.Location = New System.Drawing.Point(16, 8)
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstClientes.Size = New System.Drawing.Size(385, 108)
        Me.lstClientes.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(264, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lotes Selecionados"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Lotes Disponíveis"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.SystemColors.Control
        Me.lblID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Blue
        Me.lblID.Location = New System.Drawing.Point(16, 128)
        Me.lblID.Name = "lblID"
        Me.lblID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblID.Size = New System.Drawing.Size(18, 19)
        Me.lblID.TabIndex = 1
        Me.lblID.Text = "0"
        '
        'frmAplicaClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(418, 416)
        Me.Controls.Add(Me.cmdVoltar)
        Me.Controls.Add(Me.cmdLimpa)
        Me.Controls.Add(Me.cmdAtribuir)
        Me.Controls.Add(Me.cmd)
        Me.Controls.Add(Me.lstSel)
        Me.Controls.Add(Me.lstLotes)
        Me.Controls.Add(Me.lstClientes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblID)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(8, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAplicaClientes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atribuição de Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As frmAplicaClientes
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAplicaClientes
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAplicaClientes()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As frmAplicaClientes)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Dim ClienteID As Integer

    Private Sub cmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmd.Click

        Dim itensSel As ListBox.SelectedObjectCollection = lstLotes.SelectedItems


        For Each obj As Object In itensSel
            lstSel.Items.Add(obj)
        Next

        Dim itensIDX As ListBox.ObjectCollection = lstSel.Items
        'Remove os itens que estão selecionados da caixa "Lotes"
        For Each obj As Object In itensIDX
            lstLotes.Items.Remove(obj)
        Next

    End Sub

    Private Sub cmdAtribuir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAtribuir.Click
        Dim i As Integer, n As Integer, id As Object
        Dim SQL As String

        On Error GoTo Erro
        'Se não houver nenhum cliente selecionado
        If lblID.Text = "0" Then
            MsgBox("Nenhum cliente selecionado!", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        'Conta quantos itens tem na lista
        n = lstSel.Items.Count

        'Não existem lotes selecionados
        If n = 0 Then
            MsgBox("Não existem itens na lista de seleção!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        'Monta a SQL geral
        SQL = "UPDATE Lotes SET Cliente=" & ClienteID & " WHERE "

        'Cria uma array dos items da listbox
        Dim Items As ListBox.ObjectCollection = lstSel.Items
        'Percorre todos eles
        For Each obj As Object In Items
            id = CType(obj, MeuItemData).ToInteger
            'Se for a primeira vez que passa
            If i = 0 Then
                SQL &= "(id IN(" & id
                i += 1
            Else ' Se já é a segunda vez em diante
                SQL &= "," & id
            End If
        Next
        SQL &= "))"
        Console.WriteLine(SQL)

        'Executa a SQL para alteração
        ExecutaSQL(SQL)

        'Envia mensagem de que deu certo
        MsgBox(n & " Lotes Atribuídos com Sucesso!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
        'Limpa a selecao
        lstSel.Items.Clear()

fim:
        Exit Sub

Erro:
        MsgBox("Erro na função de Atribuição" & vbCrLf & Err.Number & " - " & Err.Description)
        Resume fim
    End Sub

    Private Sub cmdLimpa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLimpa.Click
        Dim SQLLista As Object
        'Limpa lista de seleção
        lstSel.Items.Clear()
        'Preeche lotes diponíveis novamente
        'Preeche lotes diponíveis
        SQLLista = "SELECT id,concat_ws('.',cast(mercadoria as char),cast(lote as char),cast(clone as char)) as Codigo From Lotes Where Cliente=0 and Ativo=1 ORDER By Mercadoria,Clone,Lote"
        Carrega_Lista(lstLotes, "Lotes", "id", "concat_ws('.',cast(mercadoria as char),cast(lote as char),cast(clone as char)) as Codigo")

    End Sub
    'Inverso da outra função
    Private Sub cmdVoltar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVoltar.Click
        Dim itensSel As ListBox.SelectedObjectCollection = lstSel.SelectedItems


        For Each obj As Object In itensSel
            lstLotes.Items.Add(obj)
        Next

        Dim itensIDX As ListBox.ObjectCollection = lstLotes.Items
        'Remove os itens que estão selecionados da caixa "Lotes"
        For Each obj As Object In itensIDX
            lstSel.Items.Remove(obj)
        Next

        lstLotes.Sorted = True
    End Sub

    Private Sub frmAplicaClientes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Preeche lotes diponíveis
        Carrega_Lista(lstLotes, "Lotes", "id", "concat_ws('.',cast(mercadoria as char),cast(lote as char),cast(clone as char)) as Codigo", False, "Cliente=0 and Ativo=1")
        'Preenche Clientes
        Carrega_Lista(lstClientes, "Clientes", "id", "Nome", True)
        'limpa a selecao
        lstSel.Items.Clear()
    End Sub

    Private Sub lstClientes_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstClientes.SelectedIndexChanged
        Dim it As Object
        it = lstClientes.SelectedIndex
        ClienteID = cmbVal(lstClientes)
        lblID.Text = StrZero(ClienteID, 3) & " - " & lstClientes.Items(it).ToString
    End Sub
End Class