Public Class frmContasReceber

    Private Sub txtPessoa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPessoa.SelectedIndexChanged
        'Carrega lista de fornecedores
        Carrega_Lista(txtPessoa, "Clientes", "id", "Nome", True)
    End Sub

    Private Sub txtCodHis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodHis.KeyDown
        'Se pressionar F3 torna o painel visível
        If e.KeyCode = Keys.F3 Then
            pnlHistorico.Visible = True
            'move o foco para o painel
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

    Private Sub txtCTCred_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTCred.Leave
        'Quando deixa a caixa de CTCred verifica a conta novamente
        If txtCTCred.Text <> String.Empty Then
            lblCTCred.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTCred.Text))
        End If
    End Sub

    Private Sub txtCTDeb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTDeb.Leave
        If txtCTDeb.Text <> String.Empty Then
            lblCTDeb.Text = DLookup("Descri", "PlanoContas", "CDCRed=" & Val(txtCTDeb.Text))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String, varData As String, varEntSai As String, varEmissao As String, varContra As Int16
        If Valida_Campos() Then
            'Preparação das variáveis
            varData = IIf(chkContra.Checked, "NULL", "'" & Format(CDate(txtVencimento.Text), "yyyy-MM-dd") & "'")
            varContra = IIf(chkContra.Checked, 1, 0)
            varEmissao = IIf((txtEmissao.Text = "__/__/"), "NULL", "'" & Format(CDate(txtEmissao.Text), "yyyy-MM-dd") & "'")
            varEntSai = IIf((txtEntSai.Text = "__/__/"), "NULL", "'" & Format(CDate(txtEntSai.Text), "yyyy-MM-dd") & "'")

            'Montagem da SQL
            SQL = "INSERT INTO PagarReceber "
            SQL &= "(id,Vencimento,Apresentacao,Pessoa,Emissao,EntSai,Documento,TipoDoc,Valor,Previsao,Mensal,CodHist,Descricao,CTCred,CTDeb,Parcela,TipoPR)"
            SQL &= " VALUES ("
            SQL &= "NULL,"                                  'ID 
            SQL &= varData & ","                            'Vencimento 
            SQL &= varContra & ","                          'Contra
            SQL &= "'" & txtPessoa.Text & "',"              'Pessoa
            SQL &= varEmissao & ","                         'Emissao 
            SQL &= varEntSai & ","                          'EntSai
            SQL &= "'" & txtDoc.Text & "',"                 'Documento
            SQL &= "'" & cmbTipoDoc.Text & "',"             'TipoDoc
            SQL &= txtValor.Text.Replace(",", ".") & ","    'Valor
            SQL &= IIf(chkPrevisao.Checked, 1, 0) & ","     'Previsao 
            SQL &= IIf(chkMensal.Checked, 1, 0) & ","       'Mensal
            SQL &= IIf(String.IsNullOrEmpty(txtCodHis.Text), "NULL", txtCodHis.Text) & ","          'CodHist 
            SQL &= IIf(String.IsNullOrEmpty(txtDescricao.Text), "NULL", "'" & txtDescricao.Text & "'") & ","    'descricao 
            SQL &= IIf(String.IsNullOrEmpty(txtCTCred.Text), "NULL", txtCTCred.Text) & ","          'CTCred
            SQL &= IIf(String.IsNullOrEmpty(txtCTDeb.Text), "NULL", txtCTDeb.Text) & ","            'CTDEB
            SQL &= "'" & txtParcela.Text & "',"             'Parcela
            SQL &= "'R')"                                   'TipoPR - Pagar ou Receber

            'Tenta fazer a inclusão do Documento
            Try
                Console.WriteLine(Me.Name & ": " & SQL)
                ExecutaSQL(SQL)
                'Informa ao usuario que deu certo
                MsgBox("Lançamento incluído com sucesso no Contas a Receber", MsgBoxStyle.OkOnly, "Confirmação")
                Limpa()
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir lançamentos em Contas a Receber" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub
    Private Function Valida_Campos() As Boolean
        Return True
    End Function

    Private Sub Limpa()
        'Limpa os campos
        Limpa_Campos(Me)
        'Zera o valor
        txtValor.Text = "0,00"
        chkPrevisao.Checked = False
        chkMensal.Checked = False
        txtCodHis.Text = String.Empty
        txtDescricao.Text = String.Empty
        txtCTDeb.Text = String.Empty
        txtCTCred.Text = String.Empty
        lblCTDeb.Text = "..."
        lblCTDeb.Text = "..."
        'Move o foco
        txtVencimento.Focus()
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

    Private Sub txtCodHis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodHis.TextChanged

    End Sub

    Private Sub frmContasReceber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DSContab.ctbhistorico' table. You can move, or remove it, as needed.
        Me.CtbhistoricoTableAdapter.Fill(Me.DSContab.ctbhistorico)

    End Sub

    Private Sub dgHistorico_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHistorico.CellContentClick

    End Sub
End Class