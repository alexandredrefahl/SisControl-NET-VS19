
Public Class frmBaixaLancamentos

    Public Flag As Boolean = False
    'Flag � para destacar quando � Baixa (False) ou Quando � Altera��o (True)

    Private Sub frmBaixaLancamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            EnterAsTab(sender, e)
        End If
    End Sub

    Private Sub frmBaixaLancamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgLancamentos.RowsDefaultCellStyle.BackColor = Color.White
        dgLancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Atualiza_Datagrid()

        'Carrega os comboBox
        'Clientes/fornecedores
        Carrega_Lista(cmbPessoa, "Fornecedores", "id", "Razao", True)
    End Sub

    Private Sub dgLancamentos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgLancamentos.DataError
        e.Cancel = True
    End Sub

    Function Total_Lancamentos() As Double
        Dim i As Integer, N As Integer, Total As Double
        'conta o numero de lancamentos
        N = dgLancamentos.RowCount
        'percorre todos somando
        For i = 0 To N - 1
            Total += Val(dgLancamentos.Rows(i).Cells("Valor").Value)
        Next
        'Atualiza os labels dos totais
        lblNLancamentos.Text = N
        lblTotal.Text = Format(Total, "N2")
        'Retorna com a soma
        Return Total
    End Function

    Private Sub btBaixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBaixa.Click

        'Habilta o grupo
        Dim ID As Integer
        grpLancamento.Enabled = True

        'Habilita os campos
        altPagamento.Enabled = True
        altValor.Enabled = True
        altForma.Enabled = True

        ID = dgLancamentos.SelectedRows(0).Cells("id").Value
        txtNInterno.Text = Format(ID, "00000")
        'Sugere o pagamento como o vencimento
        altPagamento.Text = dgLancamentos.SelectedRows(0).Cells("Vencimento").Value
        'Sugere a data do pagamento como Hoje
        'altPagamento.Text = Format(Date.Today, "dd/MM/yyyy")
        'Preenche o valor
        altValor.Text = Format(dgLancamentos.SelectedRows(0).Cells("Valor").Value, "N2")
        'Move o Foco para a combo de Forma de Pagamento
        altForma.Focus()
    End Sub

    Private Sub btConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirma.Click
        'Dimensiona as vari�veis
        Dim SQL As String = Nothing
        Dim LancamID As Integer = Nothing
        Dim varPagamento As String

        'Lancamento ID
        LancamID = txtNInterno.Text

        'Verifica a data de pagamento
        If altPagamento.Text = "  /  /" Then
            varPagamento = "null"
        Else
            varPagamento = "'" & Format(CDate(altPagamento.Text), "yyyy-MM-dd") & "'"
        End If
        'Monta a SQL de Altera��o
        SQL = "UPDATE PagarReceber SET Pagamento=" & varPagamento & ",Valor=" & Numero_to_SQL(altValor.Text) & ", FP=" & altForma.Text.Substring(0, 1) & " WHERE Id=" & LancamID

        'Tenta fazer a altera��o
        Try
            Dim A As Integer
            'Pede confirma��o antes de enviar a informa��o para o BD
            A = MsgBox("Confirma a " & IIf(Flag, "Atualiza��o", "Baixa") & " do lan�amento?", MsgBoxStyle.YesNo, "Confirma��o")
            If A = vbYes Then
                Console.WriteLine(Me.Name & ": " & SQL)
                'Executa a sql montada(anteriormente)
                ExecutaSQL(SQL)
                'Retorna para o usu�rio dizendo que deu certo
                MsgBox("Lan�amento baixado com sucesso!", MsgBoxStyle.OkOnly, "Confirma��o")
                'Atualiza o datagrid
                Atualiza_Datagrid()
                'Se for uma baixa de titulo
                If Not Flag Then
                    A = MsgBox("Deseja lan�ar esta baixa na Contabilidade?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
                    'Se sim j� procede com os lancamentos
                    If A = vbYes Then

                        'Seleciona os lan�amentos associados
                        Dim DT As DataTable, Lancamentos As String = String.Empty

                        DT = SQLQuery("SELECT * FROM pr_lancamentos WHERE idDoc=" & LancamID)
                        'Se existirem lan�amentos
                        If DT.Rows.Count > 0 Then
                            Dim i As Integer
                            'Percorre todos os lan�amentos montando uma SQL para cada um
                            For i = 0 To DT.Rows.Count - 1
                                'prepara os dados para lan�ar
                                With DT.Rows(i)
                                    'Fazer dois lan�amentos, um de conta Cr�dito e Um de Conta D�bito
                                    Dim varCDCOMP As String = ""
                                    Dim varPessoa As String = dgLancamentos.SelectedRows(0).Cells("Pessoa").Value
                                    Dim varDocumento As String = dgLancamentos.SelectedRows(0).Cells("Documento").Value
                                    Dim ctCODConta As String = ""

                                    'Usa a Classe Lancamentos
                                    Dim LancCred As New Lancamentos
                                    Dim lancDeb As New Lancamentos

                                    '*
                                    '*CREDITO
                                    '*

                                    'Pega o c�digo da conta do lancamento padr�o
                                    'Inverte Cr�dito e Debito por conta dos lancamentos
                                    ctCODConta = .Item("CTDeb")
                                    varCDCOMP = DLookup("CDComp", "PlanoContas", "CDCRed=" & ctCODConta)
                                    'Cria um novo lancamento
                                    LancCred.cod_Reduzido = ctCODConta
                                    LancCred.PreencheCodCompleto()
                                    LancCred.Pessoa = varPessoa
                                    LancCred.Documento = varDocumento
                                    LancCred.Historico = .Item("Historico")
                                    LancCred.Pagamento = CDate(altPagamento.Text)
                                    LancCred.valCred = .Item("Valor")
                                    LancCred.valDeb = "0"
                                    LancCred.Prev = False
                                    LancCred.Mensal = False
                                    LancCred.Tipo = "C"
                                    LancCred.Lanc_ID = dgLancamentos.SelectedRows(0).Cells("id").Value

                                    '*
                                    '*DEBITO
                                    '*

                                    'Inverte Cr�dito e Debito por conta dos lancamentos
                                    'Pega o c�digo da conta do lancamento padr�o
                                    ctCODConta = .Item("CTCred")
                                    varCDCOMP = DLookup("CDComp", "PlanoContas", "CDCRed=" & ctCODConta)
                                    's� troca o que vai mudar no Debito
                                    lancDeb.cod_Reduzido = ctCODConta
                                    lancDeb.PreencheCodCompleto()
                                    lancDeb.Pessoa = varPessoa
                                    lancDeb.Documento = varDocumento
                                    lancDeb.Historico = .Item("Historico")
                                    lancDeb.Pagamento = CDate(altPagamento.Text)
                                    lancDeb.valCred = "0"
                                    lancDeb.valDeb = .Item("Valor")
                                    lancDeb.Prev = False
                                    lancDeb.Mensal = False
                                    lancDeb.Tipo = "D"
                                    LancCred.Lanc_ID = dgLancamentos.SelectedRows(0).Cells("id").Value

                                    'ETAPA DE CORRE��O DAS CONTAS, CASO TENHA LAN�AMENTOS PAGOS DE OUTRA FORMA

                                    'Se for uma CONTA A PAGAR
                                    If rdPagar.Checked And cmbForma.SelectedIndex = 4 Then
                                        LancCred.cod_Reduzido = "42"         ' Pago via "42 - Pagamentos Eletronicos"
                                        'A conta de cr�dito fica aquela que foi agendada conforme o que estiver pagando
                                    End If

                                    'Se for uma CONTA A RECEBER para via BANCO
                                    If rdReceber.Checked And cmbForma.SelectedIndex = 5 Then
                                        LancCred.cod_Reduzido = CTB_APRAZO_BANCO_C ' "33"
                                        lancDeb.cod_Reduzido = CTB_APRAZO_BANCO_D  ' "311"
                                    End If

                                    'Se for uma CONTA a RECEBER paga em Carteira
                                    If rdReceber.Checked And cmbForma.SelectedIndex = 1 Then
                                        'Se for A VISTA
                                        LancCred.cod_Reduzido = CTB_AVISTA_CAIXA_C
                                        lancDeb.cod_Reduzido = CTB_AVISTA_CAIXA_D
                                        'Se for A PRAZO
                                        'Se possui um documento vinculado
                                        If Not IsDBNull(.Item("idDoc")) Then
                                            'Se tem um lancamento ID
                                            Dim DataNFe As Date, dataDup As Date
                                            'Pega a data da nota correspondente (volta duas tabelas al�m)
                                            DataNFe = CDate(DLookup("Data", "docs", "id=" & Int(DLookup("Documento", "pagarreceber", "id=" & .Item("idDoc")))))
                                            dataDup = CDate(.Item("Data"))
                                            'Se for a prazo
                                            If (DataNFe.Month <> dataDup.Month And DataNFe.Year = dataDup.Year) Or (DataNFe.Month = dataDup.Month And DataNFe.Year <> dataDup.Year) Then
                                                'Se for A PRAZO
                                                LancCred.cod_Reduzido = CTB_APRAZO_CAIXA_C
                                                lancDeb.cod_Reduzido = CTB_APRAZO_CAIXA_D
                                            End If
                                        End If
                                    End If

                                    'Atualiza os c�digos completos
                                    LancCred.PreencheCodCompleto()
                                    lancDeb.PreencheCodCompleto()

                                    'Inclui lancamento
                                    LancCred.Incluir()
                                    'Inclui o lancamento com a fun��o
                                    lancDeb.Incluir()

                                    'Reune a lista de lan�amentos
                                    Lancamentos &= .Item("id")
                                End With

                            Next

                            'Tenta incluir o lancamento no banco de dados
                            Try
                                Console.WriteLine(Me.Name & ": " & SQL)
                                ExecutaSQL(SQL)
                                MsgBox("Lan�amentos cont�beis inclu�dos com sucesso!", MsgBoxStyle.Information, "Confirma��o")
                                'Atualiza os lan�amentos sinalizando como lan�ados
                                SQL = "UPDATE pr_lancamentos SET Lancado=1 WHERE id IN(" & Lancamentos & ")"
                                Console.WriteLine(Me.Name & ": " & SQL)
                                ExecutaSQL(SQL)
                                Limpar_Campos()
                                Total_Lancamentos()
                            Catch ex As Exception
                                MsgBox("Erro ao atualizar o lan�amento no banco de dados" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                                Exit Sub
                            End Try
                        Else
                            'Sen�o houver lancamentos associados sai da aplcia��o
                            MsgBox("N�o existem lan�amentos cont�beis associados a este documento", MsgBoxStyle.Critical, "Erro")
                            Exit Sub
                        End If
                    End If
                End If
                'Limpar Campos
                Limpar_Campos()
                'Atualiza totais
                Total_Lancamentos()
                'Desabilita o grid de lan�amento
                grpLancamento.Enabled = False
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o lan�amento:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            'Limpar Campos
            Limpar_Campos()
            'Atualiza Totais
            Total_Lancamentos()
            'Desabilita o grid de lan�amento
            grpLancamento.Enabled = False
            Exit Sub
        End Try
    End Sub

    Private Sub Limpar_Campos()
        'Limpa os campos
        txtNInterno.Text = "00000"
        altForma.Text = String.Empty
        altPagamento.Text = String.Empty
        altValor.Text = String.Empty
    End Sub

    Private Sub altValor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles altValor.Leave
        'formata o valor do campo
        altValor.Text = Format(CDbl(altValor.Text), "N2")
    End Sub

    Sub Monta_Filtro()
        Dim Clausula As String = String.Empty
        'Define o filtro b�sico
        'SQL_GRID = "SELECT 	Vencimento,	Apresentacao,Pessoa,Emissao,EntSai,Documento,TipoDoc,Valor,Previsao,Mensal,TipoPR,Pagamento,FP,Parcela FROM PagarReceber "

        'Veridfica se � conta a pagar ou receber
        If rdPagar.Checked = True Then
            Clausula = "(TipoPR='P')"
        ElseIf rdReceber.Checked = True Then
            Clausula = "(TipoPR='R')"
        End If

        'Verifica o vencimento inicial
        If txtVencINI.Text <> "  /  /" Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Vencimento>='" & Format(CDate(txtVencINI.Text), "yyyy-MM-dd") & "')"
        End If

        'Vencimento final
        If txtVencFIM.Text <> "  /  /" Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Vencimento<='" & Format(CDate(txtVencFIM.Text), "yyyy-MM-dd") & "')"
        End If

        'Verifica o Pagamento inicial
        If txtPagINI.Text <> "  /  /" Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Pagamento>='" & Format(CDate(txtPagINI.Text), "yyyy-MM-dd") & "')"
        End If

        'Pagamento final
        If txtPagFIM.Text <> "  /  /" Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Pagamento<='" & Format(CDate(txtPagFIM.Text), "yyyy-MM-dd") & "')"
        End If

        'Verifica Cliente/Fornecedor

        'Verifica Categoria Financeira

        'Verifica Forma de Pagamento
        If cmbForma.Text <> String.Empty Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(FP=" & cmbForma.Text.Substring(0, 1) & ")"
        End If

        'Verifica Documento
        If txtDoc.Text <> String.Empty Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Documento LIKE '%" & txtDoc.Text & "%'" & ")"
        End If

        'Verifica Pagos
        If rdPago.Checked = True Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(NOT Pagamento Is Null)"
        End If

        'Verifica Aberto
        If rdAberto.Checked = True Then
            'J� foi preenchida
            If Clausula.Length > 1 Then
                Clausula &= "AND "
            End If
            Clausula &= "(Pagamento is Null)"
        End If

        'TODOS n�o precisa verificar porque n�o tem filtro, simplesmente deixa como est�!

        If Clausula <> String.Empty Then
            Try
                'Escreve a clausula no console
                Console.WriteLine(Me.Name & ": " & Clausula)
                'Aplica o filtro no Binding Source
                BSPagarreceber.Filter = Clausula
                'Soma os lancamentos
                lblTotal.Text = Format(Total_Lancamentos(), "N2")
                lblNLancamentos.Text = dgLancamentos.Rows.Count
            Catch ex As Exception
                MsgBox("Falha ao aplicar filtro de sele��o!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltro.Click
        'Monta o filtro e prenche o grid
        Monta_Filtro()
    End Sub

    Private Sub rdReceber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdReceber.CheckedChanged
        'Troca as labels e atualiza os Combos
        Label3.Text = "Cliente:"
        Carrega_Lista(cmbPessoa, "Clientes", "id", "Nome", True)

        'Atualiza o combo de categorias (Entradas/Saidas)
        'Verificar isso primeiro

        'Monta o filtro e prenche o grid
        Monta_Filtro()
    End Sub

    Private Sub rdPagar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPagar.CheckedChanged
        'Troca as labels e atualiza os Combos
        Label3.Text = "Fornecedor:"
        Carrega_Lista(cmbPessoa, "Fornecedores", "id", "Razao", True)
        'Atualiza o combo de categorias (Entradas/Saidas)
        'Verificar isso primeiro
        'Monta o filtro e prenche o grid
        Monta_Filtro()
    End Sub

    Private Sub btCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancela.Click

        grpLancamento.Enabled = False

        'Retira os textos dos campos especificados
        altPagamento.Text = String.Empty
        altValor.Text = String.Empty
        altForma.Text = String.Empty
        'desabilita os campos especificados
        altPagamento.Enabled = False
        altForma.Enabled = False
        altValor.Enabled = False
        'Move o foco para o grid
        dgLancamentos.Focus()
    End Sub

    Private Sub Atualiza_Datagrid()
        'Atualiza o datagrid por carregar os dados novamente
        Me.Cursor = Cursors.WaitCursor
        Me.TAPagarreceber.Fill(Me.DSContab.pagarreceber)
        'Atualiza os totais
        Total_Lancamentos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btExcluir.Click
        'Se existe algo selecionado
        If dgLancamentos.SelectedRows.Count > 0 Then
            'Captura o ID da linha selecionada
            Dim idx As Integer = dgLancamentos.SelectedRows(0).Cells("id").Value

            'Verifica se o lan�amento n�o foi pago ainda. Se j� foi pago n�o pode ser excluido
            'Se j� est� pago
            If Not IsDBNull(dgLancamentos.SelectedRows(0).Cells("Pagamento").Value) Then
                MsgBox("Os lan�amentos que j� foram pagos n�o podem ser exclu�dos!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If

            'Pede confirma��o se o usu�rio quer deletar
            Dim a As Integer = vbNo
            a = MsgBox("Confirmar a exclus�o do lan�amento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")

            'Se o usu�rio confirmou
            If a = vbYes Then
                Dim SQL As String = String.Empty

                SQL = "DELETE FROM pagarreceber WHERE id=" & idx
                'tenta fazer a exclus�o
                Try
                    ExecutaSQL(SQL)
                    'Exclui tamb�m os lancamentos cont�beis pr� agendados
                    SQL = "DELETE FROM pr_lancamentos WHERE idDoc=" & idx
                    ExecutaSQL(SQL)
                    'Se deu tudo certo
                    MsgBox("Lan�amento exclu�do com sucesso!", MsgBoxStyle.Information, "Confirma��o")
                    Atualiza_Datagrid()
                Catch ex As Exception
                    MsgBox("Erro ao excluir o Lan�amento e sua contabiliza��o" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    Private Sub dgLancamentos_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgLancamentos.SelectionChanged
        'Se houver algo selecionado
        If dgLancamentos.SelectedRows.Count > 0 Then
            'Verifica se o t�tulo n�o � pago
            If IsDBNull(dgLancamentos.SelectedRows(0).Cells("Pagamento").Value) Then
                'Habilita o bot�o de exclus�o/Altera��o
                btExcluir.Enabled = True
                btAlterar.Enabled = True
            Else
                'Sen�o habilita
                btExcluir.Enabled = False
                btAlterar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btAlterar_Click(sender As System.Object, e As System.EventArgs) Handles btAlterar.Click
        If dgLancamentos.SelectedRows.Count > 0 Then
            Dim formulario As New frmAlteracaoLancamento(1, dgLancamentos.SelectedRows(0).Cells("id").Value)
            'Define que � MDI child
            formulario.MdiParent = frmMenu
            formulario.Show()
        End If
    End Sub

End Class

