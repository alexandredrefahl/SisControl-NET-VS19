'Importa os NameSpaces do Crystal Reports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmFluxo_Caixa

    Private Linhas_Novas As Integer

    Private Sub btFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btFiltrar.Click

        'Limpa o grid primeiro
        dgLancamentos.Rows.Clear()

        'Carrega os saldos
        Carrega_Saldo_Inicial()

        'Lançamentos existentes
        Carrega_Contas_Existentes()
        'Pega o número da linha
        Linhas_Novas = dgLancamentos.Rows.Count

        'Carrega os lançamentos futuros
        Carrega_Contas_Futuras()

    End Sub


    Private Sub Carrega_Contas_Existentes()
        Dim DT As DataTable, SQL As String, Criterio As String

        SQL = "SELECT * FROM ViewLancContab "
        'Seleciona a conta CAIXA 1.___.__
        Criterio = "(CDCOMP like '1.%')"

Datas:

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
        'Verifica se há criérios
        If Criterio <> String.Empty Then
            SQL &= "WHERE " & Criterio & " "
        End If
        'Adiciona o critério de ordenação
        SQL &= "ORDER By Pagamento,Debito,Credito"
        Try
            'Tenta obter a tabela e em seguinda atribuir ao dataGrid
            DT = SQLQuery(SQL)
            'Se retornou algum resultado
            If DT.Rows.Count > 0 Then
                Dim DR As DataRow, Saldo_Atual As Double, Sum_Credito As Double, Sum_Debito As Double
                Sum_Credito = 0
                Sum_Debito = 0
                'Converter string em valor
                Saldo_Atual = Double.Parse(txtSaldoANT.Text, System.Globalization.NumberStyles.AllowThousands + System.Globalization.NumberStyles.AllowDecimalPoint)
                'Saldo_Atual = Convert.ToDouble(txtSaldoANT.Text)
                'Para cada linha do resultado
                For Each DR In DT.Rows
                    Saldo_Atual = Saldo_Atual + DR("Credito") - DR("Debito")
                    Sum_Credito += DR("Credito")
                    Sum_Debito += DR("Debito")
                    'Monta um array com as informações
                    Try
                        'Tenta fazer a inclusão da linha
                        dgLancamentos.Rows.Add({DR("Pagamento"), DR("CDCOMP"), DR("Historico"), DR("Credito"), DR("Debito"), Saldo_Atual})
                    Catch ex As Exception
                        MsgBox("Erro ao tentar incluir lançamento no fluxo de caixa!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try
                Next
                'Atualiza o resumo
                txtSaldoATU.Text = Format(Saldo_Atual, "N2")
                lblCreditos.Text = Format(Sum_Credito, "N2")
                lblDebitos.Text = Format(Sum_Debito, "N2")
                'Libera memória
                DR = Nothing
                DT = Nothing
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar dados dos lançamentos no Servidor." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Carrega_Saldo_Inicial()
        Dim SQL As String, Conta As String, DT As DataTable, DR As DataRow, Saldo As Double

        'Conta Caixa
        Conta = "1."

        'se houver uma data inicial
        If txtDataINI.Text <> "  /  /" Then
            'Descobre o saldo antes de emitir o relatório
            SQL = "SELECT SUM(credito)-SUM(debito) AS saldo FROM viewlanccontab WHERE pagamento < '" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "' AND cdcomp LIKE '" & Conta
        Else
            SQL = "SELECT SUM(credito)-SUM(debito) AS saldo FROM viewlanccontab WHERE cdcomp LIKE '" & Conta
        End If

        'Seleciona a conta CAIXA
        SQL &= "%'"

        'Com a SQL pronta tenta fazer o calculo
        Try
            Console.WriteLine(Me.Name & ": Saldo : " & SQL)
            DT = SQLQuery(SQL)
            'Se retornou algum resultado
            If DT.Rows.Count <> 0 Then
                DR = DT.Rows(0)
                'converte o valor em double (se for nulo em Zero)
                If Not IsDBNull(DR("saldo")) Then
                    Saldo = NaoNulo(Convert.ToDouble(DR("Saldo")))
                Else
                    Saldo = 0
                End If
            End If
            'Libera memória
            DT = Nothing
            DR = Nothing
            'Criar uma linha no DataGrid com o Saldo
            dgLancamentos.Rows.Add({Format(CDate(txtDataINI.Text).AddDays(-1), "dd/MM/yyyy"), "", "Saldo Inicial do Período", 0, 0, Saldo})
            'coloca a informação do saldo inicial no resumo
            txtSaldoANT.Text = Format(Saldo, "N2")
        Catch ex As Exception
            MsgBox("Erro ao tentar calcular o saldo inicial" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Carrega_Contas_Futuras()
        Dim SQL As String, Dias As Int16
        Dim DT As DataTable, DR As DataRow
        Dim Debito As Double, Credito As Double, Saldo_Atual As Double

        'Faz a validação das datas
        If txtDias.Text <> String.Empty Then
            If Integer.Parse(txtDias.Text) > 0 Then
                Dias = Integer.Parse(txtDias.Text)
            End If
        Else
            txtDias.Text = 45
        End If

        'monta a SQL para procurar os lançamentos futuros
        SQL = "SELECT pagarreceber.Vencimento AS DATA"
        SQL &= ", Space(1) AS Conta"
        SQL &= ", pagarreceber.Descricao AS Historico"
        SQL &= ", pagarreceber.TipoPR AS Tipo"
        SQL &= ", pagarreceber.Valor "
        SQL &= "FROM Controle.pagarreceber "
        SQL &= "WHERE (ISNULL(pagarreceber.Pagamento)) AND pagarreceber.Vencimento<= '" & Format(CDate(txtDataFIM.Text).AddDays(Dias), "yyyy-MM-dd") & "' ORDER BY pagarreceber.Vencimento,pagarreceber.TipoPR"

        'Debug
        Console.WriteLine(Me.Name & ": SQL : " & SQL)

        Try
            DT = SQLQuery(SQL)
            'Se retornou algum resultado
            If DT.Rows.Count > 0 Then                       'Permite Negativos                             Permite ponto de milhar                            Permite Ponto decimal
                'Saldo_Atual = Double.Parse(txtSaldoATU.Text, Globalization.NumberStyles.AllowLeadingSign + System.Globalization.NumberStyles.AllowThousands + System.Globalization.NumberStyles.AllowDecimalPoint)
                Saldo_Atual = CDbl(txtSaldoATU.Text)
                'Para Cada linha
                For Each DR In DT.Rows
                    'Verifica o tipo de lancamento
                    If DR("Tipo") = "P" Then
                        Debito = DR("Valor")
                        Credito = 0
                    ElseIf DR("Tipo") = "R" Then
                        Debito = 0
                        Credito = DR("Valor")
                    End If
                    Saldo_Atual = Saldo_Atual + Credito - Debito
                    dgLancamentos.Rows.Add({DR("Data"), DR("Conta"), DR("Historico"), Credito, Debito, Saldo_Atual})
                Next
                'Saldo atual Projetado
                txtSaldoATU.Text = Format(Saldo_Atual, "N2")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir os lançamentos futuros" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub Monta_Resumo(ByVal Conta As String)
        Dim i As Integer, Credito As Double = 0, Debito As Double = 0
        Dim SaldoFinal As Double
        Dim Saldo As Double, DT As DataTable = Nothing
        'Revisa linha por linha somando os lancamentos
        For i = 0 To dgLancamentos.Rows.Count - 1
            With dgLancamentos.Rows(i).Cells("clDebito")
                Debito += .Value
            End With
            With dgLancamentos.Rows(i).Cells("clCredito")
                Credito += .Value
            End With
        Next
        lblCreditos.Text = Format(Credito, "N2")
        lblDebitos.Text = Format(Debito, "N2")
        'Para calculo do saldo anterior

        SaldoFinal = Saldo + Credito - Debito
        'Calcula o saldo atual subtraindo o inicial + credito - Debitos
        txtSaldoATU.Text = Format(SaldoFinal, "N2")
    End Sub

    Private Sub dgLancamentos_RowPrePaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgLancamentos.RowPrePaint
        'Se for a primeira linha do Saldo inicial
        If e.RowIndex = 0 Then
            dgLancamentos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Beige
        End If
        'Se for negativo pinta as células de vermelho
        If dgLancamentos.Rows(e.RowIndex).Cells("clSaldo").Value <= 0 Then
            If e.RowIndex > Linhas_Novas - 1 Then
                dgLancamentos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Salmon
            Else
                dgLancamentos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSalmon
            End If

        Else
            If e.RowIndex > Linhas_Novas - 1 Then
                'Se forem os lançamentos novos
                dgLancamentos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    Private Sub frmFluxo_Caixa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Data atual
        txtDataFIM.Text = Format(Today.Date, "dd/MM/yy")
        'Data Inicial
        txtDataINI.Text = Format(CDate("01/01/" & Today.Date.Year), "dd/MM/yy")

    End Sub

    Private Sub txtSaldoATU_Click(sender As System.Object, e As System.EventArgs) Handles txtSaldoATU.Click

    End Sub

    Private Sub txtSaldoATU_TextChanged(sender As Object, e As System.EventArgs) Handles txtSaldoATU.TextChanged
        'Verifica se o saldo é positivo ou negativo
        If txtSaldoATU.Text <= 0 Then
            txtSaldoATU.ForeColor = Color.Red
        Else
            txtSaldoATU.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btImprimir.Click
        'Define o relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\rptFIN_Fluxo_Caixa.rpt"

        Me.Cursor = Cursors.WaitCursor

        'Primeiro Verifica se há simulação feitas
        If dgLancamentos.Rows.Count <= 0 Then
            MsgBox("É necessário fazer uma simulação antes de imprimir!", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório naõ localizado" & vbCrLf & strReportPath)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        'Define os parametros
        CR.SetParameterValue("txtDataINI", txtDataINI.Text)
        CR.SetParameterValue("txtDataFIM", txtDataFIM.Text)
        CR.SetParameterValue("SaldoINI", dgLancamentos.Rows(0).Cells("clSaldo").Value)
        CR.SetParameterValue("txtDias", txtDias.Text)
        Try
            'Manda o relatório para impressoa
            CR.PrintToPrinter(1, False, 1, 1)
            MsgBox("Relatório enviado para impressão com sucesso!", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao tentar imprimir o relatório!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub Chart1_Click(sender As System.Object, e As System.EventArgs) Handles chFluxo.Click
        chFluxo.Visible = False
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        If dgLancamentos.Rows.Count > 0 Then
            'Esvazia o Dataset
            dsGrafico.Tables(0).Rows.Clear()
            For i = 1 To dgLancamentos.Rows.Count - 1
                With dgLancamentos.Rows(i)
                    If i <= dgLancamentos.Rows.Count - 2 Then
                        If .Cells(0).Value <> dgLancamentos.Rows(i + 1).Cells(0).Value Then
                            dsGrafico.Tables(0).Rows.Add({.Cells(0).Value, Double.Parse(.Cells(5).Value, System.Globalization.NumberStyles.AllowThousands + System.Globalization.NumberStyles.AllowDecimalPoint + System.Globalization.NumberStyles.AllowLeadingSign)})
                            'Debug
                            Console.WriteLine("Par:" & .Cells(0).Value & "," & Double.Parse(.Cells(5).Value, System.Globalization.NumberStyles.AllowThousands + System.Globalization.NumberStyles.AllowDecimalPoint + System.Globalization.NumberStyles.AllowLeadingSign))
                        End If
                    ElseIf i = dgLancamentos.Rows.Count - 1 Then
                        dsGrafico.Tables(0).Rows.Add({.Cells(0).Value, Double.Parse(.Cells(5).Value, System.Globalization.NumberStyles.AllowThousands + System.Globalization.NumberStyles.AllowDecimalPoint + System.Globalization.NumberStyles.AllowLeadingSign)})
                    End If
                End With
            Next
            chFluxo.Visible = True
        End If
    End Sub
End Class