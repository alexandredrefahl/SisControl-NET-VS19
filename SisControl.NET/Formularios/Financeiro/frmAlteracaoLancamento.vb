Public Class frmAlteracaoLancamento

    Public TipoDoc As Integer = 0, docID As UInteger = 0

    Sub New(Optional ByVal Tipo As UInt16 = 1, Optional ByVal ID As Integer = 0)

        'TIPO   1 = Pagar  |  2 = Receber

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Por padrão Tipo=1 que é Pagar
        TipoDOC = Tipo

        'Se o usuário fornecer um ID então carrega os dados
        If ID <> 0 Then
            docID = ID
        End If
    End Sub

    Private Sub frmAlteracaoLancamento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsPRLancamentos.pr_lancamentos' table. You can move, or remove it, as needed.
        Me.TA_PRlancamentos.Fill(Me.DsPRLancamentos.pr_lancamentos)
        'TODO: This line of code loads data into the 'DsPRLancamentos.pr_lancamentos' table. You can move, or remove it, as needed.
        Me.TA_PRlancamentos.Fill(Me.DsPRLancamentos.pr_lancamentos)

        'Se for conta a Pagar
        If TipoDoc = 1 Then
            'Carrega lista de fornecedores
            Carrega_Lista(txtPessoa, "Fornecedores", "id", "Razao", True)
        ElseIf TipoDoc = 2 Then 'Se for a receber
            'Carrega lista de fornecedores
            Carrega_Lista(txtPessoa, "Clientes", "id", "Nome", True)
        End If

        'Se houver um número fornecido
        If docID <> 0 Then
            Carrega_Documento()
        End If
    End Sub


    Private Sub Carrega_documento()
        Dim SQL As String, DT As DataTable
        SQL = "SELECT * FROM pagarreceber WHERE id=" & docID

        Try
            DT = SQLQuery(SQL)
            'Se achou o registro
            If DT.Rows.Count > 0 Then
                'Preenche os campos
                With DT.Rows(0)
                    txtVencimento.Text = Format(.Item("Vencimento"), "dd/MM/yy")
                    chkContra.Checked = .Item("Apresentacao")
                    txtPessoa.Text = .Item("Pessoa")
                    txtEmissao.Text = Format(.Item("Emissao"), "dd/MM/yy")
                    txtEntSai.Text = Format(.Item("EntSai"), "dd/MM/yy")
                    txtDoc.Text = .Item("Documento")
                    cmbTipoDoc.Text = .Item("TipoDoc")
                    txtValor.Text = Format(CDbl(.Item("Valor")), "N2")
                    txtParcela.Text = .Item("parcela")
                    chkPrevisao.Checked = .Item("Previsao")
                    chkMensal.Checked = .Item("Mensal")
                    chkCompra.Checked = .Item("Compra")

                    'Carrega "filtra" os lancamentos que pertencem a esta conta
                    BSPrlancamentos.Filter = "idDoc=" & docID
                End With
            Else
                'Se não achou
                MsgBox("Lançamento não localizado!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgLancCont_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgLancCont.SelectionChanged
        'Se existir algo selecionado
        If dgLancCont.SelectedRows.Count > 0 Then
            If Not IsDBNull(dgLancCont.SelectedRows(0).Cells("CTCred").Value) And Not IsNothing(dgLancCont.SelectedRows(0).Cells("CTCred").Value) Then
                lbl_Credito.Text = dgLancCont.SelectedRows(0).Cells("CTCred").Value.ToString & " - " & DLookup("Descri", "planocontas", "cdcred=" & dgLancCont.SelectedRows(0).Cells("CTCred").Value)
            Else
                lbl_Credito.Text = "..."
            End If
            If Not IsDBNull(dgLancCont.SelectedRows(0).Cells("CTDeb").Value) And Not IsNothing(dgLancCont.SelectedRows(0).Cells("CTDeb").Value) Then
                lbl_Debito.Text = dgLancCont.SelectedRows(0).Cells("CTDeb").Value & " - " & DLookup("Descri", "planocontas", "cdcred=" & dgLancCont.SelectedRows(0).Cells("CTDeb").Value)
            Else
                lbl_Debito.Text = "..."
            End If
        End If
    End Sub

    Private Sub dgLancCont_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLancCont.CellEndEdit
        'Se mexer no código do histórico tem que recalcular
        If e.ColumnIndex = 1 Then
            'Se for um código de histórico válido
            If Not IsDBNull(dgLancCont.Rows(e.RowIndex).Cells(1).Value) Then

                Dim SQL As String, DT As DataTable
                SQL = "SELECT * FROM ctbHistorico WHERE id=" & dgLancCont.Rows(e.RowIndex).Cells(1).Value
                Console.WriteLine(SQL)
                Try
                    'Tenta localizar o historico no BD
                    DT = SQLQuery(SQL)
                    'Se existir um histórico com esse código

                    If DT.Rows.Count > 0 Then
                        'Transfere Descrição
                        Console.WriteLine(DT.Rows(0).Item("Descricao"))
                        dgLancCont.Rows(e.RowIndex).Cells(2).Value = DT.Rows(0).Item("Descricao")
                        'Tranfere Crédito
                        Console.WriteLine(DT.Rows(0).Item("CTCre"))
                        dgLancCont.Rows(e.RowIndex).Cells(4).Value = DT.Rows(0).Item("CTCre")
                        'Transfere Débito
                        Console.WriteLine(DT.Rows(0).Item("CTDeb"))
                        dgLancCont.Rows(e.RowIndex).Cells(5).Value = DT.Rows(0).Item("CTDeb")
                    Else
                        'Se não existir
                        dgLancCont.Rows(e.RowIndex).Cells(1).Value = ""
                        MsgBox("Não existe um histórico contábil com este código!", MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
            End If
            'dgItens.Rows(e.RowIndex).Cells(8).Value = Val(dgItens.Rows(e.RowIndex).Cells(6).Value) * Converte_Numero(dgItens.Rows(e.RowIndex).Cells(7).Value)
        End If

        'Se mexer no valor formata ele para o modo de milhar
        If e.ColumnIndex = 6 Then
            dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "N2")
        End If

        'Conta de Debito e Credit
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
            If dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                If e.ColumnIndex = 5 Then
                    lbl_Debito.Text = DLookup("DESCRI", "Planocontas", "CDRed=" & dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                End If
                If e.ColumnIndex = 4 Then
                    lbl_Credito.Text = DLookup("DESCRI", "Planocontas", "CDRed=" & dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                End If
            End If
        End If

        If IsDBNull(dgLancCont.Rows(e.RowIndex).Cells(7).Value) Then
            dgLancCont.Rows(e.RowIndex).Cells(7).Value = docID
        End If

        Atualiza_totais()
    End Sub

    Private Sub Atualiza_totais()
        Dim i As Integer = 0, Total As Double
        'Revisa linha por linha somando os lancamentos
        For i = 0 To dgLancCont.Rows.Count - 1
            With dgLancCont.Rows(i).Cells("col_Valor")
                If Not IsDBNull(.Value) Then
                    Total += .Value
                End If
            End With
        Next
        lbl_Total.Text = Format(Total, "N2")
    End Sub

    Private Sub dgLancCont_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgLancCont.KeyDown
        'Se pressionar F3 torna o painel visível
        If e.KeyCode = Keys.F3 Then
            pnlHistorico.Visible = True
            dgHistorico.Focus()
        End If

        'Enter as tab
        If e.KeyCode = Keys.Enter Then
            EnterAsTab(Me, e)
        End If
    End Sub

    Private Sub dgLancCont_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgLancCont.DataError
        MsgBox("Erro na célula: Col:" & e.ColumnIndex & ", Lin:" & e.RowIndex & vbCrLf & e.Exception.Message)
        e.Cancel = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Tenta fazer a atualização
        Try
            salva_registro()
            'Atualiza o table adapter com a contabilização
            TA_PRlancamentos.Update(DsPRLancamentos)
            MsgBox("Lançamento Atualizado com sucesso!", MsgBoxStyle.Information, "Confirmação")
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar os dados da contabilização!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Salva_Registro()
        Dim SQL As String

        'monta a SQL básica
        SQL = "UPDATE pagarreceber SET "
        'Atualiza os dados
        SQL &= "Vencimento = '" & Format(CDate(txtVencimento.Text), "yyyy-MM-dd") & "' ,"
        SQL &= "Apresentacao = " & IIf(chkContra.Checked, "1", "0") & " ,"
        SQL &= "Pessoa = '" & txtPessoa.Text & "' ,"
        SQL &= "Emissao = '" & Format(CDate(txtEmissao.Text), "yyyy-MM-dd") & "' ,"
        SQL &= "EntSai = '" & Format(CDate(txtEntSai.Text), "yyyy-MM-dd") & "' ,"
        SQL &= "Documento = " & Texto_Vazio(txtDoc.Text) & ","
        SQL &= "TipoDoc = '" & cmbTipoDoc.Text & "' ,"
        SQL &= "Valor = " & Transforma_Valor(txtValor.Text) & " ,"
        SQL &= "Previsao = " & IIf(chkPrevisao.Checked, "1", "0") & " ,"
        SQL &= "Mensal = " & IIf(chkMensal.Checked, "1", "0") & " ,"
        SQL &= "Parcela = '" & Texto_Vazio(txtParcela.Text) & "' ,"
        SQL &= "compra = " & IIf(chkCompra.Checked, "1", "0")
        SQL &= " WHERE id = " & docID

        Try
            'Tenta gravar no Banco de Dados
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar salvar os dados do lançamento no banco de dados", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub
End Class
