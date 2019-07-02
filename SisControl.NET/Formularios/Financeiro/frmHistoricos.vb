Public Class frmHistoricos

    'TRUE = CTCred  | FALSE = CTDeb
    Dim Origem As Boolean = True


    Private Sub frmHistoricos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Carrega todos os históricos Cadastrados
        Carrega_Lista(cmbHistorico, "ctbhistorico", "id", "descricao", True)
        btExcluir.Enabled = False
        'dgContas.Enabled = False
        pnlContas.Visible = False
        Carrega_Grid()
    End Sub

    Private Sub Carrega_Grid()
        Dim DT As DataTable
        Dim SQL As String

        SQL = "SELECT id,cdcred,descri FROM planocontas WHERE Tipo='A' ORDER BY descri"
        Try
            DT = SQLQuery(SQL)
            dgContas.DataSource = DT
            dgContas.Enabled = True
            dgContas.Columns(0).Visible = 0
            dgContas.Columns(1).Width = 30
            dgContas.Columns(2).Width = 80

        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar as informações das contas" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub cmbHistorico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbHistorico.SelectedIndexChanged
        'Se algo foi selecionado
        If cmbHistorico.SelectedIndex <> -1 Then
            txtDescricao.Text = cmbHistorico.Text
            txtCTCred.Text = DLookup("CTCre", "ctbhistorico", "id=" & cmbVal(cmbHistorico))
            txtCTDeb.Text = DLookup("CTDeb", "ctbhistorico", "id=" & cmbVal(cmbHistorico))

            'Puxa a descricao do Banco de Dados
            If txtCTCred.Text <> String.Empty Then
                lblCTCred.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTCred.Text))
            End If
            If txtCTDeb.Text <> String.Empty Then
                lblCTDeb.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTDeb.Text))
            End If

            grpHistorico.Enabled = False
            btNovo.Text = "Editar"
            btIncluir.Text = "Novo"
            btExcluir.Enabled = True
        End If
    End Sub

    Private Sub btCancela_Click(sender As System.Object, e As System.EventArgs) Handles btCancela.Click
        Me.Close()
    End Sub

    Private Sub limpar_campos()
        txtDescricao.Text = String.Empty
        txtCTDeb.Text = String.Empty
        txtCTCred.Text = String.Empty
        lblCTCred.Text = "..."
        lblCTDeb.Text = "..."
        cmbHistorico.Text = String.Empty
        cmbHistorico.SelectedIndex = -1
    End Sub

    Private Sub btNovo_Click(sender As System.Object, e As System.EventArgs) Handles btNovo.Click
        Dim SQL As String

        'Se estiver apenas selecionado
        If grpHistorico.Enabled = False And btNovo.Text = "Editar" Then
            grpHistorico.Enabled = True
            txtDescricao.Focus()
            btNovo.Text = "Salvar"
            Exit Sub
        End If

        If grpHistorico.Enabled = True And btNovo.Text = "Salvar" Then
            If Validar_Campos() Then
                'Salva um registro existente
                SQL = "UPDATE ctbhistorico SET Descricao='" & txtDescricao.Text & "',CTCre=" & txtCTCred.Text & ",CTDeb=" & txtCTDeb.Text & " WHERE id=" & cmbVal(cmbHistorico)
                Try
                    ExecutaSQL(SQL)
                    MsgBox("Histórico Contábil alterado com sucesso!")
                    btNovo.Text = "Editar"
                    'Carrega todos os históricos Cadastrados
                    Carrega_Lista(cmbHistorico, "ctbhistorico", "id", "descricao", True)
                    grpHistorico.Enabled = False
                    cmbHistorico.Focus()
                Catch ex As Exception
                    MsgBox("Erro ao tentar alterar o Histórico Contábil!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    Function Validar_Campos() As Boolean
        Dim Retorno As Boolean = True
        Dim Mensagem As String = String.Empty

        'Verifica Descrição
        If txtDescricao.Text = String.Empty Then
            Retorno = False
            Mensagem &= "Descrição não pode ser vazia" & vbCrLf
        End If

        'Verifica Conta para crédito
        If txtCTCred.Text = String.Empty Or txtCTCred.Text = "0" Then
            Retorno = False
            Mensagem &= "Uma conta para crédito válida deve ser informada" & vbCrLf
        End If

        'Verifica conta de débito
        If txtCTDeb.Text = String.Empty Or txtCTDeb.Text = "0" Then
            Retorno = False
            Mensagem &= "Uma conta para débito válida deve ser informada" & vbCrLf
        End If

        'Se houver mensagem
        If Mensagem.Length > 0 Then
            MsgBox("Falha ao validar os dados:" & vbCrLf & Mensagem, MsgBoxStyle.Critical, "Erro")
            Return False
        End If

        'Se tudo está OK
        Return True
    End Function

    Private Sub btIncluir_Click(sender As System.Object, e As System.EventArgs) Handles btIncluir.Click
        Dim SQL As String

        'Se pedir um novo
        If btIncluir.Text = "Novo" Then
            btIncluir.Text = "Incluir"
            limpar_campos()
            grpHistorico.Enabled = True
            btNovo.Enabled = False
            btExcluir.Enabled = False
            Exit Sub
        End If

        'Se quiser incluir
        If btIncluir.Text = "Incluir" Then
            If Validar_Campos() Then
                SQL = "INSERT INTO ctbhistorico (Descricao,CTCre,CTDeb) VALUES (" & Texto_Vazio(txtDescricao.Text) & "," & Texto_Vazio(txtCTCred.Text) & "," & Texto_Vazio(txtCTDeb.Text) & ")"
                Try
                    ExecutaSQL(SQL)
                    MsgBox("Histórico Contábil incluído com sucesso!")
                    limpar_campos()
                    grpHistorico.Enabled = False
                    btNovo.Enabled = True
                    'Carrega todos os históricos Cadastrados
                    Carrega_Lista(cmbHistorico, "ctbhistorico", "id", "descricao", True)
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir o Histórico Contábil!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If

    End Sub

    Private Sub btExcluir_Click(sender As System.Object, e As System.EventArgs) Handles btExcluir.Click
        'Se tiver algo selecionado
        If cmbHistorico.SelectedIndex <> -1 Then
            Dim a As Integer
            a = MsgBox("Tem certeza que deseja excluir o histórico:" & vbCrLf & cmbHistorico.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            'Se o usuário confirmar
            If a = vbYes Then
                Dim SQL As String
                SQL = "DELETE FROM ctbhistorico WHERE id=" & cmbVal(cmbHistorico)
                Try
                    ExecutaSQL(SQL)
                    MsgBox("Histórico contábil excluído com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                    'Carrega todos os históricos Cadastrados
                    Carrega_Lista(cmbHistorico, "ctbhistorico", "id", "descricao", True)
                    cmbHistorico.Text = String.Empty
                Catch ex As Exception
                    MsgBox("Erro ao tentar ecluir o histórico contábil!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    Private Sub txtCTCred_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCTCred.KeyDown
        'Pediu a lista
        If e.KeyCode = Keys.F3 Then
            pnlContas.Visible = True
            dgContas.Focus()
            'Para identificar quem pediu a conta
            Origem = True
        End If
    End Sub

    Private Sub txtCTCred_Leave(sender As Object, e As System.EventArgs) Handles txtCTCred.Leave
        'Quando deixa a caixa de CTCred verifica a conta novamente
        If txtCTCred.Text <> String.Empty Then
            lblCTCred.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTCred.Text))
        End If
    End Sub

    Private Sub txtCTDeb_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCTDeb.KeyDown
        'Pediu a lista
        If e.KeyCode = Keys.F3 Then
            pnlContas.Visible = True
            dgContas.Focus()
            'Para identificar quem pediu a conta
            Origem = False
        End If
    End Sub

    Private Sub txtCTDeb_Leave(sender As Object, e As System.EventArgs) Handles txtCTDeb.Leave
        If txtCTDeb.Text <> String.Empty Then
            lblCTDeb.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTDeb.Text))
        End If
    End Sub

    Private Sub dgContas_AllowUserToResizeRowsChanged(sender As Object, e As System.EventArgs) Handles dgContas.AllowUserToResizeRowsChanged

    End Sub

    Private Sub dgContas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgContas.KeyDown
        'Painel se esconde
        If e.KeyCode = Keys.Enter Then
            pnlContas.Visible = False
            If Origem Then
                txtCTCred.Text = dgContas.SelectedRows(0).Cells("CDCRED").Value
                txtCTCred.Focus()
            Else
                txtCTDeb.Text = dgContas.SelectedRows(0).Cells("CDCRED").Value
                txtCTDeb.Focus()
            End If
        End If
        'Se apertar o ESC
        If e.KeyCode = Keys.Escape Then
            pnlContas.Visible = False
            If Origem Then
                txtCTCred.Focus()
            Else
                txtCTDeb.Focus()
            End If
        End If
    End Sub


    Private Sub dgContas_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContas.CellContentClick

    End Sub
End Class