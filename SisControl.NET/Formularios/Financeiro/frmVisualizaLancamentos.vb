Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Public Class frmVisualizaLancamentos

    Dim Conta As String = String.Empty

    Private Sub btFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFiltrar.Click
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
            Monta_Resumo(Conta)
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar dados dos lançamentos no Servidor." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub frmVisualizaLancamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDataFIM.Value = Now
        txtDataINI.Value = Now
    End Sub

    Private Sub Formata_Grid()
        Dim Textos() As String = {"id", "Pagamento", "Red", "Conta", "Histórico", "Crédito", "Débito"}
        Dim Larguras() As Integer = {55, 77, 40, 60, 280, 75, 75}
        Dim Visiveis() As Integer = {1, 1, 1, 1, 1, 1, 1}
        Dim i As Int16 = 0
        Formata_Datagrid(dgLancamentos, Textos, Larguras, Visiveis)

        'formatos específicos para cada coluna
        With dgLancamentos
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

    Private Sub Monta_Resumo(ByVal Conta As String)
        Dim i As Integer, Credito As Double = 0, Debito As Double = 0
        Dim SaldoFinal As Double
        Dim Saldo As Double

        'Revisa linha por linha somando os lancamentos
        For i = 0 To dgLancamentos.Rows.Count - 1
            With dgLancamentos.Rows(i).Cells("Debito")
                Debito += .Value
            End With
            With dgLancamentos.Rows(i).Cells("Credito")
                Credito += .Value
            End With
        Next
        lblCreditos.Text = Format(Credito, "N2")
        lblDebitos.Text = Format(Debito, "N2")

        'Calcula o saldo Anterior
        Saldo = Saldo_Anterior()

        txtSaldoANT.Text = Format(Saldo, "N2")
        SaldoFinal = Saldo + Credito - Debito
        'Calcula o saldo atual subtraindo o inicial + credito - Debitos
        txtSaldoATU.Text = Format(SaldoFinal, "N2")
    End Sub

    Private Function Monta_SQL() As String
        Dim Partes() As String, SQL As String, Criterio As String = String.Empty

        Partes = txtConta.Text.Split(",")

        SQL = "SELECT * FROM ViewLancContab "

        'Se o usuário não informou nada no critério contas
        If txtConta.Text = " ,  ," Then
            Conta = String.Empty
            GoTo Datas
        End If

Conta:
        'Se o usuario naõ informou a ultima parte da conta
        If Partes(2) = "" Then
            'Se ele não informou a segunda parte da conta
            If Partes(1) = "  " Then
                'Pega só o primeiro númedo da conta
                Conta = txtConta.Text.Substring(0, 1)
            Else
                'Se ele informou a segunda parte (troca virgula por ponto)
                Conta = txtConta.Text.Substring(0, 4).Replace(",", ".")
            End If
        Else
            'Se ele informou a conta completa
            'Tem que trocar virgula por ponto pra não dar erro
            Conta = txtConta.Text.Replace(",", ".")
        End If
        'Se pedir para incluir as subcontas
        If chkSub.Checked Then
            Criterio = "(CDCOMP like '" & Conta & "%')"
        Else
            Criterio = "(CDCOMP = '" & Conta & "')"
        End If

Datas:

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
        SQL &= "ORDER By Pagamento"

        Return SQL

    End Function

    Private Function Saldo_Anterior() As Double
        Dim SQL As String = String.Empty
        Dim DT As DataTable = Nothing, DR As DataRow, Saldo As Double

        If Conta = String.Empty Then
            Saldo = 0
        Else
            'Se a conta não for vazia
            If txtDataINI.Text <> "  /  /" Then
                'Descobre o saldo antes de emitir o relatório
                SQL = "SELECT SUM(credito)-SUM(debito) AS saldo FROM viewlanccontab WHERE pagamento < '" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "' AND cdcomp LIKE '" & Conta
            Else
                SQL = "SELECT SUM(credito)-SUM(debito) AS saldo FROM viewlanccontab WHERE cdcomp LIKE '" & Conta
            End If
            'Se incluir as subcontas coloca a mascara no like senão naõ
            If chkSub.Checked Then
                SQL &= "%'"
            Else
                SQL &= "'"
            End If
        End If

        'Com a SQL pronta tenta fazer o calculo
        Try
            Console.WriteLine(Me.Name & ": Saldo : " & SQL)
            DT = SQLQuery(SQL)
            'Se retornou algum resultado
            If Not IsNothing(DT) And DT.Rows.Count <> 0 Then
                DR = DT.Rows(0)
                'converte o valor em double (se for nulo em Zero)
                If Not IsDBNull(DR("saldo")) Then
                    Saldo = NaoNulo(Convert.ToDouble(DR("Saldo")))
                Else
                    Saldo = 0
                End If
            Else
                MsgBox("Não foi possível recuperar a tabela no banco de dados para cálculo do Saldo Inicial", MsgBoxStyle.Critical, "Erro")
                Exit Function
            End If
            'Retorna o saldo
            Return Saldo
        Catch ex As Exception
            MsgBox("Erro ao tentar calcular o saldo inicial" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Function
        End Try

    End Function

    Private Sub btPrint_Click(sender As System.Object, e As System.EventArgs) Handles btPrint.Click

        Dim conn As MySqlConnection
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim nomeRel As String = "crFIN_Movimento_Contas.rpt"
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & nomeRel

        'Cursor em modo de espera
        Me.Cursor = Cursors.WaitCursor

        Try
            conn = New MySqlConnection()
            conn.ConnectionString = MY_SQL_CONNECTION
            cmd.Connection = conn

            'Tenta abrir a conexao
            Try
                conn.Open()
            Catch myerror As MySqlException
                MsgBox("Erro ao connectar: " & vbCrLf & myerror.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try

            'Se conseguiu conectar então segue adiante
            cmd.CommandText = Monta_SQL()
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            'Cria uma tabela Lancamentos no DataSet Virtual
            ds.Tables.Add("lancamentos")
            da.Fill(ds, "lancamentos")

            'verifica se o arquivo existe
            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Relatório não localizado :" & vbCrLf & strReportPath))
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)

            'Seta o novo dataSET do programa
            CR.SetDataSource(ds)

            'Passa o valor dos parametros
            CR.SetParameterValue("txtDataINI", txtDataINI.Text)
            CR.SetParameterValue("txtDataFIM", txtDataFIM.Text)
            CR.SetParameterValue("saldoINI", txtSaldoANT.Text)
            CR.SetParameterValue("txtConta", Conta)

            'Manda o relatório para impressoa
            CR.PrintToPrinter(1, False, 0, 0)

            'Volta o cursor ao normal
            Me.Cursor = Cursors.Arrow
            'Avisa o usuário que deu certo
            MsgBox("Relatório enviado para a impressora!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")
            

            'Libera todos os recursos usados pelo sistema.
            ds.Dispose()
            da.Dispose()
            cmd.Dispose()
            conn.Dispose()
            CR.Dispose()

            ds = Nothing
            da = Nothing
            cmd = Nothing
            conn = Nothing
            CR = Nothing

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MsgBox(ex.Message)
        End Try


    End Sub
End Class