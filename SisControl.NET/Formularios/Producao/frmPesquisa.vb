Imports System.Data
Imports MySql.Data.MySqlClient

Public Class frmPesquisa
    'Define as variaveis para conexao
    Private MyCON As MySql.Data.MySqlClient.MySqlConnection
    Private MyCMD As New MySql.Data.MySqlClient.MySqlCommand
    Private myTABLE As System.Data.DataTable
    Private MyADA As MySql.Data.MySqlClient.MySqlDataAdapter
    Private SQL As String

    Private Sub frmPesquisa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'preenche os combobox
        Carrega_Lista(cmbFase, "Fases", "id", "Fase")
        Carrega_Lista(cmbCliente, "Clientes", "id", "Nome")
        Carrega_Lista(cmbRepicador, "Repicador", "Numero", "Nome", True, "ativo=1")

        'atualiza o datagrid com a SQL inicial - todos os lotes
        Atualiza_Pesquisa("SELECT * FROM Lotes_Completa ORDER BY Mercadoria,Lote,Clone")
        'Restringe o botão de inativação só para administradores
        If User.Permissao = 1 Then
            btInativar.Visible = True
        End If
    End Sub

    Private Sub Atualiza_Pesquisa(ByVal SQL As String)
        'Define a largura das colunas
        Dim Tamanhos() As Integer = {49, 35, 35, 40, 160, 55, 37, 50, 60, 37, 76, 83, 57, 53, 53, 53, 34, 41, 46}
        Dim Textos() As String = {"ID", "Mer", "Lot", "Clon", "Mercadoria", "Frascos", "M/F", "Tipo", "Tempo", "Rep", "Fase", "Meio", "Data", "Estoque", "E.Fr", "E.I.", "Cont", "Ativo", "Cliente"}

        'Define a conexao e tenta abrir
        MyCON = New MySql.Data.MySqlClient.MySqlConnection(MY_SQL_CONNECTION)
        MyADA = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL, MyCON)
        'Define o comando a ser usado
        MyCMD.Connection = MyCON
        MyCMD.CommandText = SQL
        MyADA.SelectCommand = MyCMD

        'define e preenche um DataTable com os dados
        myTABLE = New DataTable()
        'Adaptador preenche a tabela
        MyADA.Fill(myTABLE)

        'Vincula a tabela ao datagrid
        dgLotes.DataSource = myTABLE
        Dim Estoque As Integer = 0
        'Soma o número de mudas
        For i As Integer = 0 To dgLotes.RowCount - 1
            Estoque = Estoque + Val(dgLotes.Rows(i).Cells(13).Value)
        Next
        'Formata datagrid (18 Colunas)
        For i As Integer = 0 To 17
            'usa o vetor de tamanhos e textos
            With dgLotes.Columns(i)
                .Width = Tamanhos(i)
                .HeaderText = Textos(i)
            End With
        Next
        With dgLotes
            'ID
            .Columns(0).DefaultCellStyle.Format = "000000"
            'Mercadoria
            .Columns(1).DefaultCellStyle.Format = "000"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Lote
            .Columns(2).DefaultCellStyle.Format = "000"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Clone
            .Columns(3).DefaultCellStyle.Format = "0000"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Frascos
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Mudas por frasco
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Repicador
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Data
            .Columns(12).DefaultCellStyle.Format = "dd/MM/yy"
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Estoque
            .Columns(13).DefaultCellStyle.Format = "N0"
            .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Estoque Frascos
            .Columns(14).DefaultCellStyle.Format = "N0"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Estoque Inicial
            .Columns(15).DefaultCellStyle.Format = "N0"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Contaminado
            .Columns(16).DefaultCellStyle.Format = "N0"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Cliente
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        txtTotal.Text = Format(Estoque, "N0")
        txtTotLotes.Text = dgLotes.RowCount
    End Sub


    Private Sub dgLotes_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgLotes.ColumnWidthChanged, dgLotes.ColumnWidthChanged
        'MsgBox("Largura (" & e.Column.Index.ToString & "): " & dgLotes.Columns(e.Column.Index).Width.ToString)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'atualiza o datagrid com a SQL inicial - todos os lotes
        Atualiza_Pesquisa("SELECT * FROM Lotes_Completa ORDER BY Mercadoria,Lote,Clone")
        'Rotina que varre o formulario limpando os campos
        Limpa_Campos(Me)
        chkEstoque.Checked = False
        chkFrascos.Checked = False
        chkBiorreator.Checked = False
        txtDataINI.Text = String.Empty
        txtDataFIM.Text = String.Empty
        cmbRepicador.Text = String.Empty
    End Sub

    Private Sub btFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltrar.Click
        Dim SQL As String, Primeira As Boolean, Criterio As String
        'Inicializa as variaveis
        SQL = "SELECT * FROM Lotes_Completa"
        Primeira = True
        Criterio = ""

        'Filtra a mercadoria
        If Len(txtMercadoria.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Mercadoria=" & txtMercadoria.Text & ")"
        End If
        'Filtra o Lote
        If Len(txtLote.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Lote=" & txtLote.Text & ")"
        End If
        'Filtra o Clone
        If Len(txtClone.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Clone=" & txtClone.Text & ")"
        End If
        'Filtra a data inicial
        If Not txtDataINI.Text = "  /  /" Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Data>='" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "')"
        End If
        'Filtra a data final
        If Not txtDataFIM.Text = "  /  /" Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Data<='" & Format(CDate(txtDataFIM.Text), "yyyy-MM-dd") & "')"
        End If
        'Filtra a Fase
        If Len(cmbFase.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Fase='" & cmbFase.Text & "')"
        End If
        'Filtra o Repicador
        If Len(cmbRepicador.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Repicador like '%" & cmbVal(cmbRepicador) & "%')"
        End If
        'Filtra a Cliente
        If Len(cmbCliente.Text) > 0 Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Cliente=" & cmbVal(cmbCliente) & ")"
        End If
        'Filtra Estoque zerado
        If chkEstoque.Checked Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Estoque <= 0)"
        End If
        'Filtra Frascos Zerados
        If chkFrascos.Checked Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Est_Frascos <= 0)"
        End If
        'Filtra Biorreator
        If chkBiorreator.Checked Then
            If Primeira Then
                Criterio = Criterio & " WHERE "
                Primeira = False
            Else
                Criterio = Criterio & " AND "
            End If
            Criterio = Criterio & "(Tipo_Frasco='Biorreator')"
        End If
        'Tirar a expressão critério sem o WHERE
        If Len(Criterio) > 0 Then
            SQL = SQL & Criterio
        End If

        'Só para Debug
        Console.WriteLine("SQL Filtro: " & SQL)

        'Depois da SQL montada, Atualiza o datagrid
        Try 'Tenta atualizar pesquia
            Atualiza_Pesquisa(SQL)
        Catch ex As Exception
            'Se ocorrer qualquer erro
            MsgBox("Ocorreu um erro ao tentar filtrar os dados:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub


    Private Sub dgLotes_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLotes.CellContentDoubleClick
        Dim ID As Integer = -1

        'Cursor de espera
        Me.Cursor = Cursors.WaitCursor
        'Pega o id da linha selecionada
        ID = dgLotes.SelectedRows(0).Cells(0).Value

        'Cria uma instancia da visualização dos lotes
        Dim editaLote As New frmNovoLotes("L", ID)
        'Define a Janela MDI
        editaLote.MdiParent = Me.MdiParent
        'Seta o cursor corretamente
        Me.Cursor = Cursors.Arrow
        'finalmente mostra a janela
        editaLote.Show()

        'Cria uma instancia da visualização dos lotes
        'Dim viewDetalhes As New frmAlteracaoLote
        'Carrega os dados do lote
        'viewDetalhes.Atualiza_Dados(ID)
        'Define como janela MDI
        'viewDetalhes.MdiParent = Me.MdiParent
        'Muda o mouse
        'Me.Cursor = Cursors.Arrow
        'Finalmente mostra
        'viewDetalhes.Show()
    End Sub

    Private Sub btInativar_Click(sender As Object, e As EventArgs) Handles btInativar.Click
        'Se houver uma ou mais linhas selecionadas.
        If dgLotes.SelectedRows.Count > 0 Then
            Dim a As Integer = 0
            a = MsgBox("Deseja realmente inativar os " & dgLotes.SelectedRows.Count & " selecionados?" & vbCrLf & "Isso irá excluir todos os frascos correspondentes além de zerar os estoques.", vbQuestion + vbYesNo, "Confirmação")
            'Verifica a opção do usuário
            If a = vbYes Then
                Dim txtIDs As String = ""

                Dim txtOperador As String = InputBox("Digite o Código do Operador da Baixa", "Código do Operador")

                If txtOperador = String.Empty Then
                    MsgBox("Baixa não realizada pois operador não foi informado", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                Else
                    'verifica se o operador é válido
                    If IsNumeric(txtOperador) Then
                        'Verifica se o operador existe realmente
                        Dim DR As DataRow = DLookupRow("repicador", "Numero=" & txtOperador)
                        'Se retornou algum resultado
                        If Not DR.IsNull(0) Then
                            Dim b As Int16 = MsgBox("Confirme o Nome do Operador:" & vbCrLf & DR("Nome"), MsgBoxStyle.YesNo, "Confirmação")
                            If b = vbNo Then
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("É necessário informar o código do operador (apenas números)", MsgBoxStyle.OkOnly, "Aviso")
                        Exit Sub
                    End If
                End If

                'Pega o ID de todos os lotes selecionados.
                For i As Integer = 0 To dgLotes.SelectedRows.Count - 1
                    'Acrescenta todos os ID's
                    txtIDs &= dgLotes.SelectedRows(i).Cells(0).Value
                    If i < dgLotes.SelectedRows.Count - 1 Then
                        txtIDs &= ","
                    End If
                Next

                Dim SQL As String = ""
                'Monta a SQL de inativação
                SQL = "UPDATE Lotes SET ativo=0, estoque=0, est_frascos=0, inativado=CURRENT_TIMESTAMP WHERE id IN("
                SQL &= txtIDs & ")"
                'Para fins de debug
                Console.WriteLine("SQL de Inativação Multipla: " & SQL)

                'Monta a SQL de Inativação dos frascos correspondentes
                Dim SQL_Frascos As String = ""
                'Monta a SQL dos frascos

                SQL_Frascos = "UPDATE aux_frascos SET bxExclusao=CURRENT_TIMESTAMP,bxMotivo='R',bxOperador='" & txtOperador & "' WHERE lote IN(" & txtIDs & ")"
                'SQL_Frascos = "DELETE FROM aux_frascos WHERE lote IN(" & txtIDs & ")"
                'Para fins de debug
                Console.WriteLine("SQL de IDs dos frascos: " & SQL_Frascos)

                'Usa a técnica de transação, ou TUDO dá certo ou não exclui, para que os registros não fiquem "órfãos"
                Dim myConnection As New MySqlConnection
                'Define a Connection String
                myConnection.ConnectionString = MY_SQL_CONNECTION
                'Abre a conexão
                myConnection.Open()
                'Cria um novo comando
                Dim myCommand As New MySqlCommand()
                myCommand.Connection = myConnection
                'Cria uma nova transação
                Dim myTrans As MySqlTransaction
                ' Inicia a transação localmente
                myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted)
                ' Adiciona o objeto transação como pendente
                myCommand.Transaction = myTrans

                Try
                    'Executa a primeira tarefa da transação
                    myCommand.CommandText = SQL
                    myCommand.ExecuteNonQuery()
                    'Segunda tarefa da transação
                    myCommand.CommandText = SQL_Frascos
                    myCommand.ExecuteNonQuery()
                    'Tenta verificar se deu certo (ou seja as duas foram executadas sem nenhum erro)
                    myTrans.Commit()
                    MsgBox("Os lotes foram inativados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                    'Atualiza pesquisa
                    btFiltrar_Click(sender, e)
                Catch ex As Exception
                    myTrans.Rollback()
                    MsgBox("Houve um erro ao tentar inativar os lotes." & vbCrLf & "Nenhum Lote foi inativado e nenhum frasco excluído" & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Finally
                    myConnection.Close()
                End Try
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgLotes_SelectionChanged(sender As Object, e As EventArgs) Handles dgLotes.SelectionChanged
        If dgLotes.SelectedRows.Count = 0 Then
            Label10.Visible = False
            txtSelecionados.Visible = False
        Else
            Label10.Visible = True
            txtSelecionados.Visible = True
            txtSelecionados.Text = Format(dgLotes.SelectedRows.Count, "N0")
        End If
    End Sub

    Private Sub btCopiar_Click(sender As Object, e As EventArgs) Handles btCopiar.Click
        'Habilita cópia do gridview para o clipboard
        dgLotes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Copia as células para o clipboard
        Clipboard.SetDataObject(dgLotes.GetClipboardContent())
    End Sub
End Class