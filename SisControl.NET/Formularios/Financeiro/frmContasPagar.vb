Public Class frmContasPagar

    Private Sub cmbDocTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(Me, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Fecha o programa
        Me.Close()
    End Sub

    Private Sub txtValor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValor.Leave
        'Formata o valor na caixa de texto
        txtValor.Text = Format(CDbl(txtValor.Text), "N2")
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String, varData As String, varEntSai As String, varEmissao As String, varContra As Int16, varCompra As Int16
        If Valida_Campos() Then
            'Prepara��o das vari�veis
            varData = IIf(chkContra.Checked, "NULL", "'" & Format(CDate(txtVencimento.Text), "yyyy-MM-dd") & "'")
            varCompra = IIf(chkCompra.Checked, "1", "0")
            varContra = IIf(chkContra.Checked, 1, 0)
            varEmissao = IIf((txtEmissao.Text = "__/__/"), "NULL", "'" & Format(CDate(txtEmissao.Text), "yyyy-MM-dd") & "'")
            varEntSai = IIf((txtEntSai.Text = "__/__/"), "NULL", "'" & Format(CDate(txtEntSai.Text), "yyyy-MM-dd") & "'")

            'Montagem da SQL
            SQL = "INSERT INTO PagarReceber SET "
            SQL &= "Vencimento=" & varData & ","                        'Vencimento 
            SQL &= "Apresentacao=" & varContra & ","                    'Contra
            SQL &= "Pessoa='" & txtPessoa.Text & "',"                   'Pessoa
            SQL &= "Emissao=" & varEmissao & ","                        'Emissao 
            SQL &= "EntSai=" & varEntSai & ","                          'EntSai
            SQL &= "Documento='" & txtDoc.Text & "',"                   'Documento
            SQL &= "Descricao='" & txtDescricao.Text & "',"             'Descricao
            SQL &= "TipoDoc='" & cmbTipoDoc.Text & "',"                 'TipoDoc
            SQL &= "Valor=" & Transforma_Valor(txtValor.Text) & ","     'Valor
            SQL &= "Previsao=" & IIf(chkPrevisao.Checked, 1, 0) & ","   'Previsao 
            SQL &= "Mensal=" & IIf(chkMensal.Checked, 1, 0) & ","       'Mensal
            SQL &= "Parcela='" & txtParcela.Text & "',"                 'Parcela
            SQL &= "TipoPR='P',"                                        'TipoPR - Pagar ou Receber
            SQL &= "Compra=" & varCompra                                'Compra

            'Tenta fazer a inclus�o do Documento
            Try
                Console.WriteLine(Me.Name & ": " & SQL)
                ExecutaSQL(SQL)
                'Informa ao usuario que deu certo
                MsgBox("Lan�amento inclu�do com sucesso no Contas a Pagar", MsgBoxStyle.OkOnly, "Confirma��o")
                'pega o n�mero do lancamento recem incluido
                Dim IDLancamento As Integer = DMax("id", "pagarreceber")
                Dim i As Integer = 0
                'Incluir cada um dos lancamentos
                For i = 0 To dgLancCont.Rows.Count - 2          '-2 pois tem que contar a linha adicional
                    SQL = "INSERT INTO pr_lancamentos SET "
                    With dgLancCont.Rows(i)
                        SQL &= "CDHist=" & IIf(.Cells(0).Value <> "", .Cells(0).Value, "NULL") & ","
                        SQL &= "Historico='" & .Cells(1).Value & "',"
                        SQL &= "Data='" & Format(CDate(txtVencimento.Text), "yyyy-MM-dd") & "',"
                        SQL &= "Valor=" & Numero_to_SQL(.Cells(4).Value) & ","
                        SQL &= "CTCred=" & .Cells(2).Value & ","
                        SQL &= "CTDeb=" & .Cells(3).Value & ","
                        SQL &= "idDoc=" & IDLancamento
                    End With
                    'Faz a inclus�o no banco de dados.
                    ExecutaSQL(SQL)
                Next
                MsgBox("Lan�amentos cont�beis agendados com sucesso!", MsgBoxStyle.Information, "Confirma��o")
                Limpa()
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir lan�amentos em Contas a Pagar" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Function Valida_Campos() As Boolean
        Dim Retorno As Boolean = True, Mensagem As String = ""

        'Mensagem padr�o
        Mensagem = "O Documento a pagar n�o pode ser incluido:" & vbCrLf

        'Verifica se os totais batem
        If lbl_Total.Text <> txtValor.Text Then
            Mensagem = "O valor do documento n�o coincide com o total do valor da contabiliza��o" & vbCrLf
            Retorno = False
        End If

        'Manda a mensagem para o usu�rio
        If Not Retorno Then
            MsgBox(Mensagem, MsgBoxStyle.Critical, "Erro")
            Return Retorno
        End If

        Retorno = True

        'Se passou por tudo retorna verdadeiro
        Return Retorno
    End Function
    Private Sub Limpa()
        'Limpa os campos
        Limpa_Campos(Me)
        'Zera o valor
        txtValor.Text = "0,00"
        chkPrevisao.Checked = False
        chkMensal.Checked = False
        dgLancCont.Rows.Clear()
        lbl_Credito.Text = "..."
        lbl_Debito.Text = "..."
        lbl_Total.Text = "0,00"
        txtParcela.Text = "�nica"
        'Move o foco
        txtVencimento.Focus()
    End Sub
    Private Sub frmContasPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DSContab.ctbhistorico' table. You can move, or remove it, as needed.
        Me.CtbhistoricoTableAdapter.Fill(Me.DSContab.ctbhistorico)
        'Carrega lista de fornecedores
        Carrega_Lista(txtPessoa, "Fornecedores", "id", "Razao", True)
    End Sub

    Private Sub dgHistorico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgHistorico.KeyDown
        'Se pressionar enter prrenche o historico e retorna
        If e.KeyCode = Keys.Enter Then
            'Se houver alguma linha selecionada
            If dgHistorico.SelectedRows.Count > 0 Then
                'Transfere o conteudo para o c�digo do hist�rico
                dgLancCont.SelectedRows(0).Cells(0).Value = dgHistorico.SelectedRows(0).Cells(0).Value
                'Tranfere o Hist�rico
                dgLancCont.SelectedRows(0).Cells(1).Value = dgHistorico.SelectedRows(0).Cells(1).Value
                'Transfere a Conta Cr�dito
                dgLancCont.SelectedRows(0).Cells(2).Value = dgHistorico.SelectedRows(0).Cells(2).Value
                'Transfere a Conta D�bito
                dgLancCont.SelectedRows(0).Cells(3).Value = dgHistorico.SelectedRows(0).Cells(3).Value
                'Apaga o painel
                pnlHistorico.Visible = False
            Else
                pnlHistorico.Visible = False
            End If
        End If
        'Se pressionar esc
        If e.KeyCode = Keys.Escape Then
            pnlHistorico.Visible = False
            dgLancCont.Focus()
        End If
    End Sub
    Private Sub dgLancCont_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLancCont.CellEndEdit

        'Se mexer no c�digo do hist�rico tem que recalcular
        If e.ColumnIndex = 0 Then
            'Se for um c�digo de hist�rico v�lido
            If dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty Then
                Exit Sub
            Else
                Dim SQL As String, DT As DataTable
                SQL = "SELECT * FROM ctbHistorico WHERE id=" & dgLancCont.Rows(e.RowIndex).Cells(0).Value
                Console.WriteLine(SQL)
                Try
                    'Tenta localizar o historico no BD
                    DT = SQLQuery(SQL)
                    'Se existir um hist�rico com esse c�digo

                    If DT.Rows.Count > 0 Then
                        'Transfere Descri��o
                        Console.WriteLine(DT.Rows(0).Item("Descricao"))
                        dgLancCont.Rows(e.RowIndex).Cells(1).Value = DT.Rows(0).Item("Descricao")
                        'Tranfere Cr�dito
                        Console.WriteLine(DT.Rows(0).Item("CTCre"))
                        dgLancCont.Rows(e.RowIndex).Cells(2).Value = DT.Rows(0).Item("CTCre")
                        'Transfere D�bito
                        Console.WriteLine(DT.Rows(0).Item("CTDeb"))
                        dgLancCont.Rows(e.RowIndex).Cells(3).Value = DT.Rows(0).Item("CTDeb")
                    Else
                        'Se n�o existir
                        dgLancCont.Rows(e.RowIndex).Cells(0).Value = ""
                        MsgBox("N�o existe um hist�rico cont�bil com este c�digo!", MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Erro ao localizar no banco de dados." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
            'dgItens.Rows(e.RowIndex).Cells(8).Value = Val(dgItens.Rows(e.RowIndex).Cells(6).Value) * Converte_Numero(dgItens.Rows(e.RowIndex).Cells(7).Value)
        End If

        'Se mexer no valor formata ele para o modo de milhar
        If e.ColumnIndex = 4 Then
            'dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "N2")
        End If

        'Conta de Debito
        If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            If dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                If e.ColumnIndex = 3 Then
                    lbl_Debito.Text = DLookup("DESCRI", "Planocontas", "CDCRed=" & dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                End If
                If e.ColumnIndex = 2 Then
                    lbl_Credito.Text = DLookup("DESCRI", "Planocontas", "CDCRed=" & dgLancCont.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                End If
            End If
        End If

        Atualiza_totais()
    End Sub


    Private Sub dgLancCont_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgLancCont.KeyDown
        'Se pressionar F3 torna o painel vis�vel
        If e.KeyCode = Keys.F3 Then
            pnlHistorico.Visible = True
            dgHistorico.Focus()
        End If
    End Sub

    Private Sub Atualiza_totais()
        Dim i As Integer = 0, Total As Double
        'Revisa linha por linha somando os lancamentos
        For i = 0 To dgLancCont.Rows.Count - 1
            With dgLancCont.Rows(i).Cells("col_Valor")
                Total += .Value
            End With
        Next
        lbl_Total.Text = Format(Total, "N2")
    End Sub

    Private Sub dgLancCont_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgLancCont.SelectionChanged
        'Se existir algo selecionado
        If dgLancCont.SelectedRows.Count > 0 Then
            If dgLancCont.SelectedRows(0).Cells(2).Value Then
                lbl_Credito.Text = dgLancCont.SelectedRows(0).Cells(2).Value.ToString & " - " & DLookup("Descri", "planocontas", "cdcred=" & dgLancCont.SelectedRows(0).Cells(2).Value)
            Else
                lbl_Credito.Text = "..."
            End If
            If dgLancCont.SelectedRows(0).Cells(3).Value Then
                lbl_Debito.Text = dgLancCont.SelectedRows(0).Cells(3).Value & " - " & DLookup("Descri", "planocontas", "cdcred=" & dgLancCont.SelectedRows(0).Cells(3).Value)
            Else
                lbl_Debito.Text = "..."
            End If
        End If
    End Sub


End Class