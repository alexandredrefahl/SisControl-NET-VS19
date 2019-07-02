Imports MySql.Data.MySqlClient



Public Class frmManutLancam

    'Define os dois tamanhos de tela
    Dim TAM_NORMAL As Integer = 440
    Dim TAM_EXTENDIDO As Integer = 560

    Structure Contraparte
        Private id As Integer
        Private Data As String
        Private CDRED As Integer
        Private CDCOMP As Integer
        Private Historico As String
        Private Credito As String
        Private Debito As String
    End Structure


    Private Sub frmManutLancam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Tamanho do formulário com a área de alteração oculta
        Me.Height = tam_normal
        'Já preenche a data final com o dia de hoje
        txtDataFIM.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub Formata_Grid()
        Dim Textos() As String = {"id", "Data", "Cód", "Conta", "Histórico", "Crédito", "Débito"}
        Dim Larguras() As Integer = {50, 75, 45, 75, 350, 80, 80}
        Dim Visiveis() As Integer = {1, 1, 1, 1, 1, 1, 1}
        Dim i As Int16 = 0
        Formata_Datagrid(dgLancamentos, Textos, Larguras, Visiveis)

        'formatos específicos para cada coluna
        With dgLancamentos
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .ForeColor = Color.LightGray
            End With
            With .Columns("Pagamento").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "dd/MM/yyyy"
            End With
            With .Columns("CDCOMP").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("Historico").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("Credito").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            With .Columns("Debito").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
        End With
    End Sub

    Private Sub btFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btFiltrar.Click
        Atualiza_Dados()
    End Sub

    Private Sub Atualiza_Dados()
        Dim DT As DataTable
        Dim SQL As String

        'Usa a função que monta a SQL
        SQL = Monta_SQL()

        Try
            'Tenta obter a tabela e em seguinda atribuir ao dataGrid
            Console.WriteLine(Me.Name & ": " & SQL)
            DT = SQLQuery(SQL)
            dgLancamentos.DataSource = DT
            Formata_Grid()
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar dados dos lançamentos no Servidor." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String, Criterio As String = String.Empty

        SQL = "SELECT * FROM ViewLancContab "

        'DEBUG
        'Console.WriteLine("Data INI: " & txtDataINI.Text & " / Data FIM: " & txtDataFIM.Text)

        'Faz a o teste relativo as datas
        'Se nenhuma data foi informada
        If txtDataINI.Text = "  /  /" And txtDataFIM.Text = "  /  /" Then
            GoTo Ordem
        End If
        'Se a data Inicial foi informada
        If txtDataINI.Text <> "  /  /" Then
            'Se já existir um critério anterior
            If Criterio <> String.Empty Then
                Criterio &= " AND "
            End If
            'Se a data final foi preenchida
            Criterio &= "(Pagamento>='" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "')"
        End If
        'Se a data Final foi informada
        If txtDataFIM.Text <> "  /  /" Then
            'Se já existir um critério anterior
            If Criterio <> String.Empty Then
                Criterio &= " AND "
            End If
            'Se a data final foi preenchida
            Criterio &= "(Pagamento<='" & Format(CDate(txtDataFIM.Text), "yyyy-MM-dd") & "')"
        End If

Ordem:
        'Verifica se ´há criérios
        If Criterio <> String.Empty Then
            SQL &= "WHERE " & Criterio & " "
        End If
        'Adiciona o critério de ordenação
        SQL &= "ORDER By Pagamento,id"

        Return SQL

    End Function

    Private Sub btExcluir_Click(sender As System.Object, e As System.EventArgs) Handles btExcluir.Click
        Dim resp As Integer, LancID As DataRow


        resp = MsgBox("Tem certeza de que deseja excluir o Lançamento Selecionado?", MsgBoxStyle.Critical + vbYesNo, "Alerta")

        If resp = vbYes Then
            Dim varID As Integer, SQL As String = String.Empty
            Dim itm_atual As Integer
            'Pega o lançamento na linha selecionada
            varID = dgLancamentos.SelectedRows(0).Cells(0).Value
            Console.WriteLine("ManutLancam - Id para ser Excluído " & varID)
            'Pega a linha atualmente selecionada
            'itm_atual = Int(dgLancamentos.SelectedRows(0).Index.ToString)
            itm_atual = dgLancamentos.CurrentRow.Index
            'Pula para o imediatamente anterior
            If itm_atual > 0 Then
                itm_atual -= 1
            End If

            'Localiza o lançamento de Contrapartida
            LancID = Localiza_Contrapartida()
            'Confirma para ver se quer excluir os dois ou um só
            resp = MsgBox("Deseja excluir também o lançamento de Contrapartida? Confira abaixo:" & vbCrLf & vbCrLf & "(" & LancID.Item("id") & ") | " & LancID.Item("CDCOMP") & " | " & LancID.Item("Historico"), MsgBoxStyle.Question + vbYesNo, "Confirmação")

            'Verifica se SIM ou se NAO
            If resp = vbNo Then
                'Monta a SQL de exclusão para um único lançamento
                SQL = "DELETE FROM Lancamentos WHERE id=" & varID
            ElseIf resp = vbYes Then
                'Monta a SQL de exclusao para ambos lançamentos
                SQL = "DELETE FROM Lancamentos WHERE id IN(" & varID & ", " & LancID.Item("id") & ")"
            End If
            Try
                ExecutaSQL(SQL)
                MsgBox("Lançamento excluído com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
            Catch ex As Exception
                MsgBox("Erro ao tentar excluir o lançamento" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            Try
                'Remonta o grid com a saída desta linha
                Atualiza_Dados()
                'Volta a selecionar a linha que estava selecionada
                'dgLancamentos.Rows(itm_atual).Selected = True
                dgLancamentos.CurrentCell = dgLancamentos.Rows(itm_atual).Cells(1)
            Catch ex As Exception
                'Se não pode mover para a posição, então move para a última
                dgLancamentos.CurrentCell = dgLancamentos.Rows(dgLancamentos.Rows.Count - 1).Cells(1)
            End Try

        Else
            'Se desistir sai da rotina e não faz nada
            Exit Sub
        End If

    End Sub

    Private Sub btAlterar_Click(sender As System.Object, e As System.EventArgs) Handles btAlterar.Click
        'Aumenta o tamanho do form para que apareça a área de alteração
        Me.Height = TAM_EXTENDIDO
        'Desabilita temporariamente os botoes de alterar e excluir
        grpAcoes.Enabled = False
        'Desabilita o acesso ao datagrid também
        dgLancamentos.Enabled = False
        'Preenche os campos com o lançamento atual
        Preenche_Campos()
        Localiza_Contrapartida()
    End Sub

    Private Sub btCancela_Click(sender As System.Object, e As System.EventArgs) Handles btCancela.Click
        Retorna_ao_DataGrid()
    End Sub

    Private Sub Preenche_Campos()
        Dim lancID As DataRow

        With dgLancamentos.SelectedRows(0)
            txtData.Value = .Cells("Pagamento").Value
            txtCDRED.Text = .Cells("CDRED").Value
            txtCDCOMP.Text = .Cells("CDCOMP").Value
            txtHistorico.Text = .Cells("Historico").Value
            txtCred.Text = FormatNumber(.Cells("Credito").Value, 2)
            txtDeb.Text = FormatNumber(.Cells("Debito").Value, 2)
            lblID.Text = .Cells("id").Value
        End With

        'Pega a linha que contém a contrapartida
        lancID = Localiza_Contrapartida()

        'Identifica a contraparte
        txtContraparte.Text = "(" & lancID.Item("id") & ") | " & lancID.Item("CDCOMP") & " | " & lancID.Item("Historico")
    End Sub

    Private Function Localiza_Contrapartida() As DataRow
        'Define a variável
        Dim varData As String
        Dim varCredito As Double
        Dim varDebito As Double
        Dim varHistorico As String
        Dim Criterio As String
        'Dim lanc As Lancamentos
        Dim lancID As DataRow

        'Pega os dados do lancamento atual
        With dgLancamentos.SelectedRows(0)
            varData = .Cells("Pagamento").Value
            varHistorico = .Cells("Historico").Value
            varCredito = Double.Parse(.Cells("Credito").Value)
            varDebito = Double.Parse(.Cells("Debito").Value)
        End With

        Criterio = "Pagamento='" & Format(CDate(varData), "yyyy-MM-dd") & "' AND Historico='" & varHistorico & "' AND "

        'Verifica se o lançamento é de Crédito e procura no Débito, se é Débito procura no Crédito
        If varDebito = 0 Then
            Criterio &= "Debito=" & Numero_to_SQL(varCredito)
        ElseIf varCredito = 0 Then
            Criterio &= "Credito=" & Numero_to_SQL(varDebito)
        End If
        Console.WriteLine("ManutLancam Critério: " & Criterio)
        'Pega a linha completa do lançamento
        lancID = DLookupRow("ViewLancContab", Criterio)
        Return lancID
    End Function

    Private Sub dgLancamentos_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgLancamentos.SelectionChanged
        'Se estiverem selecionadas 2 linhas, então habilita o Botão, caso contrário não
        If dgLancamentos.SelectedRows.Count = 2 Then
            With dgLancamentos
                If (.SelectedRows(0).Cells("Pagamento").Value = .SelectedRows(1).Cells("Pagamento").Value) And (.SelectedRows(0).Cells("Historico").Value = .SelectedRows(1).Cells("Historico").Value) Then
                    btInverte.Enabled = True
                End If
            End With
        Else
            btInverte.Enabled = False
        End If
    End Sub

    Private Sub btInverte_Click(sender As System.Object, e As System.EventArgs) Handles btInverte.Click
        Dim resp As Integer

        'Pede confirmação antes de executar a inversão
        resp = MsgBox("Deseja inverter os lançamentos de Crédito e Débito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        'Se sim
        If resp = vbYes Then
            'Percorre os 2 lançamentos fazendo a inversão
            For i As Single = 0 To 1
                Dim Linha As DataRow, SQL As String = ""
                Linha = DLookupRow("Lancamentos", "id=" & dgLancamentos.SelectedRows(i).Cells("id").Value)
                'Agora monta a SQL de alteração
                SQL = "UPDATE Lancamentos SET "
                'Verifica se é Crédito ou Débito e inverte
                If Linha.Item("Credito") > 0 Then
                    SQL &= "Debito=" & Numero_to_SQL(Linha.Item("Credito")) & ", Credito=0, Tipo='D'"
                ElseIf Linha.Item("Debito") > 0 Then
                    SQL &= "Credito=" & Numero_to_SQL(Linha.Item("Debito")) & ", Debito=0, Tipo='C'"
                End If
                'Garante que só este lançamento seja invertido
                SQL &= " WHERE id=" & Linha.Item("id")
                Console.WriteLine("Inverter: " & SQL)
                'Efetua a mudança no banco de dados
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao inverter lançamentos! Contate o Administrador.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                    Exit Sub
                End Try
            Next
            MsgBox("Lançamentos Invertidos com Sucesso")
            Dim atual As Integer
            'Grava a posição do lancamento
            atual = dgLancamentos.CurrentRow.Index
            'Renova os dados com o novo filtro
            Atualiza_Dados()
            'Reposiciona a linha na linha que estava
            dgLancamentos.CurrentCell = dgLancamentos.Rows(atual).Cells(0)
        End If
    End Sub

    Private Sub btUpdade_Click(sender As System.Object, e As System.EventArgs) Handles btUpdade.Click
        'Primeiramente temos que saber se a conta foi alterada
        'Se a conta foi alterada, não podemos alterar a contrapartida, somente o lancamento atual
        Dim flagConta As Boolean = False, resp As Integer
        'Verifica se a conta está diferente daquela que está no datagrid
        If txtCDRED.Text <> dgLancamentos.CurrentRow.Cells("CDRED").Value Then
            'Marca dizendo que a conta foi alterada
            flagConta = True
        End If

        'Se a conta foi alterada (Mexe somente no lançamento atual)
        If flagConta Then
            'Pede a primeira confirmação
            resp = MsgBox("Deseja realmente alterar o Lancamento selecionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            'Se sim então altera
            If resp = vbYes Then
                'Função que altera o lançamento único
                Altera_Lancamento_Unico()
            End If
        Else
            'Se a conta não foi alterada, então pode também atualizar o lançamento Pareado
            resp = MsgBox("Deseja alterar o Lancamento selecionado e seu Correspondente?" & vbCrLf & vbCrLf & "SIM = Altera os Dois Lançamentos" & vbCrLf & "NÃO = Altera Somente ESTE Lançamento" & vbCrLf & "CANCELAR = Não altera nenhum Lançamento", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Confirmação")
            'Se sim então altera AMBOS lançamentos
            If resp = vbYes Then
                'Altera os dois lancamentos
                Altera_Lancamento_Duplo()
            ElseIf resp = vbNo Then
                'Altera somente este lancamento
                Altera_Lancamento_Unico()
            ElseIf resp = vbCancel Then
                'Aciona a mesa ação do botão de cancelar
                btCancela_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub Altera_Lancamento_Unico()
        'Verifica se É Crédito ou débito
        Dim varTipo As Char, SQL As String
        If Double.Parse(txtCred.Text) > 0 Then
            varTipo = "C"
        ElseIf Double.Parse(txtDeb.Text) Then
            varTipo = "D"
        End If
        If Valida_Campos() Then
            'Monta a SQL para fazer a alteração
            SQL = "UPDATE Lancamentos SET CDRED='" & txtCDRED.Text & "',CDCOMP='" & txtCDCOMP.Text & "',Historico='" & txtHistorico.Text & "',Pagamento='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',Credito=" & Numero_to_SQL(txtCred.Text) & ",Debito=" & Numero_to_SQL(txtDeb.Text) & ",Tipo='" & varTipo & "' WHERE id=" & lblID.Text
            Console.WriteLine("Alteração de Lançamento: " & Sql)
            ExecutaSQL(SQL)
            Dim Linha As Integer = dgLancamentos.CurrentRow.Index
            Atualiza_Dados()
            dgLancamentos.CurrentCell = dgLancamentos.Rows(Linha).Cells(0)
            Retorna_ao_DataGrid()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Altera_Lancamento_Duplo()
        Dim Lanc1 As Integer, Lanc2 As Integer, Contra As DataRow, SQL1 As String, SQL2 As String
        'Pega o ID do primeiro lançamento
        Lanc1 = lblID.Text
        'Pega o ID do segundo lançamento
        Contra = Localiza_Contrapartida()
        Lanc2 = Contra.Item("id")

        'Verifica se É Crédito ou débito
        Dim varTipo As Char
        If Double.Parse(txtCred.Text) > 0 Then
            varTipo = "C"
        ElseIf Double.Parse(txtDeb.Text) Then
            varTipo = "D"
        End If
        'Verifica se o lançamento pode prosseguir
        If Valida_Campos() Then
            'Monta a SQL para fazer a alteração do Primeiro Lançamento
            SQL1 = "UPDATE Lancamentos SET Historico='" & txtHistorico.Text & "',Pagamento='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',Credito=" & Numero_to_SQL(txtCred.Text) & ",Debito=" & Numero_to_SQL(txtDeb.Text) & ",Tipo='" & varTipo & "' WHERE id=" & Lanc1
            'Inverte o lançamento de Crédito e Débito
            If varTipo = "C" Then
                varTipo = "D"
            Else
                varTipo = "C"
            End If
            SQL2 = "UPDATE Lancamentos SET Historico='" & txtHistorico.Text & "',Pagamento='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',Credito=" & Numero_to_SQL(txtDeb.Text) & ",Debito=" & Numero_to_SQL(txtCred.Text) & ",Tipo='" & varTipo & "' WHERE id=" & Lanc2
            Console.WriteLine("Alteração de Lançamento 1: " & SQL1)
            Console.WriteLine("Alteração de Lançamento 2: " & SQL2)
            ExecutaSQL(SQL1)
            ExecutaSQL(SQL2)
            Dim Linha As Integer = dgLancamentos.CurrentRow.Index
            Atualiza_Dados()
            dgLancamentos.CurrentCell = dgLancamentos.Rows(Linha).Cells(0)
            Retorna_ao_DataGrid()
        Else
            Exit Sub
        End If
    End Sub

    Private Function Valida_Campos() As Boolean
        'À Princípio é Verdadeiro
        Dim Retorno As Boolean = True, msg As String = String.Empty

        'Verifica o código Reduzido
        If txtCDRED.Text = String.Empty Then
            Retorno = False
            msg &= "Código Reduzido não pode estar em branco" & vbCrLf
        End If
        'Verifica o código completo
        If txtCDCOMP.Text = String.Empty Then
            Retorno = False
            msg &= "Código da Conta não pode estar em branco" & vbCrLf
        End If
        'Verifica o Histórico
        If txtHistorico.Text = String.Empty Then
            Retorno = False
            msg &= "Histórico não pode estar em branco" & vbCrLf
        End If
        If Double.Parse(txtCred.Text) > 0 And Double.Parse(txtDeb.Text) > 0 Then
            Retorno = False
            msg &= "Débito e Crédito nunca podem ser preenchidos ao mesmo termpo" & vbCrLf
        End If

        'Se houve algum problema informar
        If Not Retorno Then
            MsgBox("Pendências ao alterar o lançamento, verifique" & vbCrLf & msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Return Retorno
        End If
        'Se estiver tudo OK
        Return Retorno
    End Function

    Private Sub txtCDRED_Leave(sender As System.Object, e As System.EventArgs) Handles txtCDRED.Leave
        'Se houver algo preenchido e for um número
        'Se o campo estiver vazio saí da Sub
        If txtCDRED.Text = String.Empty Then
            Exit Sub
        End If
        'Tenta pegar o código completo à partir do código Reduzido
        Try
            Dim CDCOMP As String
            CDCOMP = DLookup("CDCOMP", "planocontas", "CDCRED=" & txtCDRED.Text)
            'Se localizou algo
            If Not IsDBNull(CDCOMP) Or CDCOMP <> String.Empty Then
                txtCDCOMP.Text = CDCOMP
            Else
                txtCDCOMP.Text = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Erro ao localizar a informação sobre a conta no Banco de dados" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub txtCred_Leave(sender As System.Object, e As System.EventArgs) Handles txtCred.Leave
        If txtCred.Text = String.Empty Then
            txtCred.Text = "0,00"
        End If
        If Double.Parse(txtCred.Text) > 0 Then
            txtDeb.Text = "0,00"
        End If
    End Sub

    Private Sub txtDeb_Leave(sender As System.Object, e As System.EventArgs) Handles txtDeb.Leave
        If txtDeb.Text = String.Empty Then
            txtDeb.Text = "0,00"
        End If
        If Double.Parse(txtDeb.Text) > 0 Then
            txtCred.Text = "0,00"
        End If
    End Sub

    Private Sub Retorna_ao_DataGrid()
        'Habilita os controles de alteração e exclusão
        grpAcoes.Enabled = True
        'Volta ao tamanho normal
        Me.Height = TAM_NORMAL
        'Habilita o acesso ao datagrid
        dgLancamentos.Enabled = True
    End Sub
End Class