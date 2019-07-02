Public Class frmLancamentoContab

    Private Sub txtCodHis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodHis.KeyDown
        If e.KeyCode = Keys.F3 Then
            pnlHistorico.Visible = True
            dgHistorico.Focus()
        End If
    End Sub

    Private Sub txtCodHis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodHis.Leave
        'Se não estiver vazio
        If txtCodHis.Text.Length > 0 Then
            'Procura no banco de dados para localizar o historico
            txtDescricao.Text = DLookup("Descricao", "CTBHistorico", "id=" & Val(txtCodHis.Text))
            txtCTDeb.Text = DLookup("CTCre", "CTBHistorico", "id=" & Val(txtCodHis.Text))
            txtCTCred.Text = DLookup("CTDeb", "CTBHistorico", "id=" & Val(txtCodHis.Text))

            'Depois localiza a descrição das contas de crédito e débito
            lblCTDeb.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTDeb.Text))
            lblCTCred.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTCred.Text))
        End If
    End Sub

    Private Sub btCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancela.Click
        'Fecha e sai
        Me.Close()
    End Sub

    Private Sub btConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirma.Click
        Dim a As Integer, DeuCerto As Boolean

        'Testa a validade dos campos para verificar inconsistencias
        If Not Valida_Campos() Then
            Exit Sub
        End If

        'Confirma se quer fazer o lancamento
        a = MsgBox("Confirma a inclusão do lançamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")

        'Se o usuario confirmar
        If a = vbYes Then
            Dim Lanc As New Lancamentos
           
            'Faz dois lancamentos, um numa conta para débito e noutra para credito
            If txtCTCred.Text > 0 Then
                'CREDITO
                'Monta um lançamento de CRÉDITO
                Lanc.cod_Reduzido = txtCTCred.Text
                Lanc.cod_Completo = DLookup("CDComp", "PlanoContas", "CDCRed=" & Lanc.cod_Reduzido)
                Lanc.Historico = txtDescricao.Text
                Lanc.Documento = "Null"
                Lanc.Pessoa = "Null"
                Lanc.Pagamento = CDate(txtData.Text)
                Lanc.valCred = String_to_Numero(txtValor.Text)
                Lanc.valDeb = 0
                Lanc.Tipo = "C"

                'Inclui o lançamento no banco de dados
                DeuCerto = Lanc.Incluir()

            End If
            'Faz o segundo lancamento
            If txtCTDeb.Text > 0 Then
                'DEBITO
                'Muda somente o que vai ser alterado com o DEBITO 
                Lanc.cod_Reduzido = txtCTDeb.Text
                Lanc.cod_Completo = DLookup("CDComp", "PlanoContas", "CDCRed=" & Lanc.cod_Reduzido)
                Lanc.valCred = 0
                Lanc.valDeb = String_to_Numero(txtValor.Text)
                Lanc.Tipo = "D"

                'Inclui o lancamento no banco de dados
                DeuCerto = Lanc.Incluir()
            End If

            If DeuCerto Then
                'Se conseguiu fazer os lancamentos
                Limpa_Campos(Me)
                lblCTCred.Text = "..."
                lblCTDeb.Text = "..."
                txtValor.Text = "0,00"
                txtData.Focus()
            End If
        End If
    End Sub

    Private Function Valida_Campos() As Boolean
        Dim Mensagem As String = String.Empty, Validade As Boolean = True

        'Valida a Data
        If txtData.Text = "__/__/" Then
            Mensagem &= "Campo data é obrigatório" & vbCrLf
            Validade = False
        End If

        'Valida a descricao
        If txtDescricao.Text.Length < 1 Then
            Mensagem &= "A descrição do lançamento é obrigatória" & vbCrLf
            Validade = False
        End If

        'Valida Conta debito
        If txtCTDeb.Text.Length < 1 Then
            Mensagem &= "A conta para débito deve ser informada" & vbCrLf
            Validade = False
        End If

        'Valida Conta credito
        If txtCTDeb.Text.Length < 1 Then
            Mensagem &= "A conta para crédito deve ser informada" & vbCrLf
            Validade = False
        End If

        'Valida Conta debito
        If txtValor.Text = "0,00" Then
            Mensagem &= "O campo valor é obrigatório" & vbCrLf
            Validade = False
        End If

        'Verifica se alguma mensagem foi gerada
        If Not Validade Then
            MsgBox(Mensagem, MsgBoxStyle.Critical, "Erro")
            Return False
            Exit Function
        Else
            Return True
            Exit Function
        End If

    End Function

    Private Sub txtValor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor.Leave
        txtValor.Text = Format(Val(txtValor.Text.Replace(",", ".")), "#0.00")
    End Sub

    Private Sub frmLancamentoContab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Troca o enter pelo TAB
        EnterAsTab(sender, e)
    End Sub

    Private Sub dgHistorico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgHistorico.KeyDown
        'Se pressionar enter prrenche o historico e retorna
        If e.KeyCode = Keys.Enter Then
            'Se houver alguma linha selecionada
            If dgHistorico.SelectedRows.Count > 0 Then
                'Transfere o conteudo para o código do histórico
                txtCodHis.Text = dgHistorico.SelectedRows(0).Cells(0).Value
                'Apaga o painel
                pnlHistorico.Visible = False
                txtCodHis.Focus()
            Else
                pnlHistorico.Visible = False
                txtCodHis.Focus()
            End If
        End If
        'Se pressionar esc
        If e.KeyCode = Keys.Escape Then
            pnlHistorico.Visible = False
            txtCodHis.Focus()
        End If
    End Sub

    Private Sub txtCTDeb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTDeb.Leave
        If txtCTDeb.Text <> String.Empty Then
            lblCTDeb.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTDeb.Text))
        End If
    End Sub

    Private Sub txtCTCred_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTCred.Leave
        'Quando deixa a caixa de CTCred verifica a conta novamente
        If txtCTCred.Text <> String.Empty Then
            lblCTCred.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTCred.Text))
        End If
    End Sub

    Private Sub frmLancamentoContab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DSContab.ctbhistorico' table. You can move, or remove it, as needed.
        Me.TAHistorico.Fill(Me.DSContab.ctbhistorico)
    End Sub

    Private Sub dgHistorico_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHistorico.CellContentClick

    End Sub

    Private Sub txtCTDeb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTDeb.TextChanged

    End Sub
End Class