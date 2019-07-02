Public Class frmAlteracaoLote
    'Variavel global que guarda o n do lote
    Private LoteID As Integer
    Dim varRepicador As String
    'flag de impressão
    Private ImpFLAG As Boolean = False

    Private Sub frmAlteracaoLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Refresh_Listas()
    End Sub
    Private Sub Refresh_Listas()
        'Carrega a lista de mercadorias
        Carrega_Lista(lstMercadoria, "Mercadoria_num", "id", "Nome")
        'Limpa lista de lotes
        lstLotes.Items.Clear()
    End Sub

    Private Sub lstMercadoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMercadoria.SelectedIndexChanged
        'Verifica se há um item selecionado
        If lstMercadoria.SelectedIndex = -1 Then
            'Se nenhum item está selecionado sai da sub
            Exit Sub
        End If
        'Caso contrario
        Carrega_Lista(lstLotes, "id_codigo", "id", "codigo", True, "(Mercadoria=" & cmbVal(lstMercadoria) & ") AND (ativo=1)")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIr.Click
        Dim Codigo(3) As String

        'Se for vazio já sai da rotina
        If txtCodigoLote.Text = String.Empty Then
            Exit Sub
        End If

        Dim Lote_ID As Integer, txt As String

        If rdCodigo.Checked Then
            'Verifica erro no código do lote
            If txtCodigoLote.Text.Length < 9 Or txtCodigoLote.Text.Length > 14 Then
                MsgBox("Erro no Código do Lote. Digite o código no formato 999.999.9999 ou passe o leitor de código de barras no frasco", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
                txtCodigoLote.Text = ""
                txtCodigoLote.Focus()
            End If

            'Verifica pelo tamanho do código do lote para ver cada caso!
            Select Case txtCodigoLote.Text.Length
                Case 9      '000000000      (Formato antigo sem pontuação)
                    Codigo(0) = txtCodigoLote.Text.Substring(0, 2)
                    Codigo(1) = txtCodigoLote.Text.Substring(2, 3)
                    Codigo(2) = txtCodigoLote.Text.Substring(5, 4)
                Case 10     '0000000000     (Formato novo sem pontuação)
                    Codigo(0) = txtCodigoLote.Text.Substring(0, 3)
                    Codigo(1) = txtCodigoLote.Text.Substring(3, 3)
                    Codigo(2) = txtCodigoLote.Text.Substring(6, 4)
                Case 11     '00.000.0000     (Formato antigo com pontuação)
                    Codigo(0) = txtCodigoLote.Text.Substring(0, 2)
                    Codigo(1) = txtCodigoLote.Text.Substring(3, 3)
                    Codigo(2) = txtCodigoLote.Text.Substring(7, 4)
                Case 12     '000.000.0000   (formato novo com pontuação)
                    Codigo(0) = txtCodigoLote.Text.Substring(0, 3)
                    Codigo(1) = txtCodigoLote.Text.Substring(4, 3)
                    Codigo(2) = txtCodigoLote.Text.Substring(8, 4)
                Case 14     '00000000000000 (Formato do código de barras)
                    Codigo(0) = txtCodigoLote.Text.Substring(1, 3)
                    Codigo(1) = txtCodigoLote.Text.Substring(4, 3)
                    Codigo(2) = txtCodigoLote.Text.Substring(7, 4)
                Case Else
                    MsgBox("O sistema não pode indentificar o padrão de digitação do Código do lote:" & vbCrLf & "Tente digitar o Código no formato 999.999.9999 ou passar o leitor de código de barras no frasco", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
                    txtCodigoLote.Text = ""
                    txtCodigoLote.Focus()
            End Select

            'Se já consegui desmontar o código então procura o lote
            txt = DLookup("id", "Lotes", "Mercadoria=" & Int(Codigo(0)) & " AND Lote=" & Int(Codigo(1)) & " AND Clone=" & Int(Codigo(2)) & " AND Ativo=1")
            'Pesquisa o lote (para evitar o erro de conversão de "" em int)
            Lote_ID = IIf(txt <> "", txt, -1)
        ElseIf rdId.Checked Then
            Lote_ID = txtCodigoLote.Text
        End If

        'Se encontorou
        If Lote_ID > -1 Then
            Dim frm As New frmNovoLotes("L", Lote_ID)
            'Define o MDI Form
            frm.MdiParent = Me.MdiParent
            'Determina que a posição será manual
            frm.StartPosition = FormStartPosition.Manual
            'Calcula a posição do novo Formulário baseado no atual
            frm.Location = frm.PointToClient(New Point(Me.Location.X + 250, Me.Location.Y + (Me.Size.Height - Me.ClientSize.Height + 96)))
            frm.Show()
        Else
            Dim a As Integer
            a = MsgBox("O Lote procurado não está entre os lotes Ativos. Deseja procurá-lo entre os lotes Inativos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            'Verifica a resposta do usuário (sim ou não)
            If a = vbNo Then
                txtCodigoLote.Text = ""
                txtCodigoLote.Focus()
            ElseIf a = vbYes Then
                Dim data As String
                data = InputBox("Digite a data do lote no formato DD/MM/AAAA (Ex:" & Format(Date.Now, "dd/mm/yyyy") & ").")
                'Verifica se a data foi digitada corretamente
                If data.Length <> 10 Then
                    MsgBox("A data está em formato incorreto", MsgBoxStyle.Critical, "Erro")
                    txtCodigoLote.Focus()
                End If
                'Procura o lote entre os inativos
                txt = DLookup("id", "Lotes", "Mercadoria=" & Int(Codigo(0)) & " AND Lote=" & Int(Codigo(1)) & " AND Clone=" & Int(Codigo(2)) & " AND data='" & Format(CDate(data), "yyyy-MM-dd") & "'")
                'para evitar o erro de conversão de "" em int
                Lote_ID = IIf(txt <> "", txt, -1)
                If Lote_ID > -1 Then
                    Dim frm As New frmNovoLotes("L", Lote_ID)
                    'Define o MDI Form
                    frm.MdiParent = Me.MdiParent
                    'Determina que a posição será manual
                    frm.StartPosition = FormStartPosition.Manual
                    'Calcula a posição do novo Formulário baseado no atual
                    frm.Location = frm.PointToClient(New Point(Me.Location.X + 250, Me.Location.Y + (Me.Size.Height - Me.ClientSize.Height + 96)))
                    frm.Show()
                    txtCodigoLote.Text = ""
                    txtCodigoLote.Focus()
                Else
                    MsgBox("O Lote procurado não foi encontrado nem entre os lotes Inativos!" & vbCrLf & "Verifique se ele não foi excluído!", MsgBoxStyle.Critical, "Erro")
                    txtCodigoLote.Text = ""
                    txtCodigoLote.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub lstLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotes.SelectedIndexChanged
        'Ao modificar o ítem selecionado
        'Se não tiver nada selecionado sai da sub
        If lstLotes.SelectedIndex = -1 Then
            Exit Sub
        End If
        'se houver algo selecionado
        'Atualiza a variavel global
        LoteID = cmbVal(lstLotes)
        btGo.Enabled = True
    End Sub

    Private Sub txtCodigoLote_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoLote.KeyDown
        EnterAsTab(sender, e)
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Recarrega todas as listas
        Refresh_Listas()
    End Sub

    Private Sub btGo_Click(sender As Object, e As EventArgs) Handles btGo.Click
        Dim frm As New frmNovoLotes("L", LoteID)
        'Define o MDI Form
        frm.MdiParent = Me.MdiParent
        'Determina que a posição será manual
        frm.StartPosition = FormStartPosition.Manual
        'Calcula a posição do novo Formulário baseado no atual
        frm.Location = frm.PointToClient(New Point(Me.Location.X + 250, Me.Location.Y + (Me.Size.Height - Me.ClientSize.Height + 96)))
        frm.Show()
    End Sub
End Class