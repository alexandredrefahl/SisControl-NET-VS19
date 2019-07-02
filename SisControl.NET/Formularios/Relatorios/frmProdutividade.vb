'Para poder usar o excel para gerar os relatorios
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared

Public Class frmProdutividade

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click

        If dgProdutividade.RowCount <= 0 Then
            MsgBox("Não há dados para montar a planilha")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'Define o cursor no modo espera
        Me.Cursor = Cursors.WaitCursor
        msg("Criando planilha Excel...")

        'Inicia o Excel e cria um novo workbook/worksheet
        Dim excelApp As New Excel.Application
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
        Dim Lin As Integer, Col As Integer, i As Integer = 0, Col_Bas As Integer, Lin_Bas As Integer

        'Define o cursor de espera
        Try

            'Torna o Excel invisível ao usuário até que a planilha seja preenchida
            'excelApp.Visible = False
            'Coluna do primeiro repicador
            Col = 2

            With excelWorksheet

                .Range("A4").Value = "Jan"
                .Range("A5").Value = "Fev"
                .Range("A6").Value = "Mar"
                .Range("A7").Value = "Abr"
                .Range("A8").Value = "Mai"
                .Range("A9").Value = "Jun"
                .Range("A10").Value = "Jul"
                .Range("A11").Value = "Ago"
                .Range("A12").Value = "Set"
                .Range("A13").Value = "Out"
                .Range("A14").Value = "Nov"
                .Range("A15").Value = "Dez"

                'Comecar na segunda linha
                Col_Bas = 2 'Começa na "B"
                Lin_Bas = 4 'Começa na "3"

                Lin = 4
                Col = -2

                'Preenche a planilha Excel com os dados do datagrid

                Dim Rep() As Integer = {}, flVisto As Boolean = False, oldRepicador As Integer

                'Ordena a tabela por Ordem Alfabética de nome
                dgProdutividade.Sort(dgProdutividade.Columns(2), System.ComponentModel.ListSortDirection.Ascending)

                'Pega o primeiro repicador para analizar
                oldRepicador = 0

                'Percorre todas as linhas
                For j As Integer = 0 To dgProdutividade.Rows.Count - 1
                    'Se trocou o repicador muda a coluna base
                    If dgProdutividade.Rows(j).Cells(1).Value <> oldRepicador Then
                        'Pula para a coluna do lado
                        Col += 4
                        'Repicador fica sendo o atual
                        oldRepicador = dgProdutividade.Rows(j).Cells(1).Value
                        'Monta o cabecalho da coluna com o nome do repicador
                        .Cells(Lin - 2, Col).Value = dgProdutividade.Rows(j).Cells(2).Value.ToString.Substring(0, dgProdutividade.Rows(j).Cells(2).Value.ToString.IndexOf(" "))
                        'Formata a coluna para o número
                        .Columns(Col).NumberFormat = "#,##0"        'Produção
                        .Columns(Col + 1).NumberFormat = "#,##0"    'Contaminação
                        .Columns(Col + 2).NumberFormat = "0.0%"     'Porcentagem
                        'Monta o cabeçalho das células
                        .Cells(Lin - 1, Col).value = "Prod"
                        .Cells(Lin - 1, Col + 1).value = "Cont."
                        .Cells(Lin - 1, Col + 2).value = "%"
                        .Cells(Lin - 1, Col + 3).value = "Horas"
                    End If
                    'Processa as produções (soma a linha base com o mês para posicionar o valor)
                    .Cells((Lin - 1) + dgProdutividade.Rows(j).Cells(0).Value, Col).value = dgProdutividade.Rows(j).Cells(3).Value      'Produção
                    .Cells((Lin - 1) + dgProdutividade.Rows(j).Cells(0).Value, Col + 1).value = dgProdutividade.Rows(j).Cells(4).Value  'Contaminação
                    .Cells((Lin - 1) + dgProdutividade.Rows(j).Cells(0).Value, Col + 2).FormulaR1C1 = "=IF(RC[-2]>0,RC[-1]/RC[-2],0)"
                    .Cells((Lin - 1) + dgProdutividade.Rows(j).Cells(0).Value, Col + 3).value = dgProdutividade.Rows(j).Cells(6).Value  'Horas
                Next

                'Formata a Planilha
                'Coloca linhas de grade
                .Range(.Cells(2, 2), .Cells(15, Col + 3)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(.Cells(4, 1), .Cells(15, 1)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                'Mescla as células do Cabeçalho do Repicador
                Dim R As Int16 = 30, G As Int16 = 30, B As Int16 = 30
                For k As Int16 = 2 To Col Step 4
                    'Linha 2 junta de 4 em 4 células para mesclar os nomes dos repicadores
                    .Range(.Cells(2, k), .Cells(2, k + 3)).Merge()
                    .Range(.Cells(2, k), .Cells(2, k + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    'Linha dos títulos
                    .Range(.Cells(3, k), .Cells(3, k + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    'Formata borda Grossa por grupo
                    .Range(.Cells(2, k), .Cells(15, k + 3)).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlMedium
                    .Range(.Cells(2, k), .Cells(15, k + 3)).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
                    .Range(.Cells(2, k), .Cells(15, k + 3)).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlMedium
                    .Range(.Cells(2, k), .Cells(15, k + 3)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
                    'Faz a borda depois do título
                    .Range(.Cells(2, k), .Cells(3, k + 3)).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
                    .Range(.Cells(2, k), .Cells(3, k + 3)).Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    .Range(.Cells(2, k), .Cells(3, k + 3)).Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic
                    .Range(.Cells(2, k), .Cells(3, k + 3)).Interior.Color = RGB(0, 128, 255)

                Next
                'Redmensiona as colunas
                .Range(.Cells(2, 2), .Cells(15, Col + 3)).ColumnWidth = 7.3

                'Torna o Excel visível
                excelApp.Visible = True
                Me.Cursor = Cursors.Arrow

            End With
        Catch ex As Exception
            MsgBox("Erro ao tentar preencher os dados no Excel!" & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Dim Cor_Fundo(12) As System.Drawing.Color

    Private Sub msg(ByVal Mensagem As String)
        lblStatus.Text = Mensagem
        lblStatus.Refresh()
    End Sub

    Private Structure Repicador
        Dim Cod As Integer
        Dim Prod As Integer
        Dim Cont As Integer
        Dim Horas As Double
    End Structure

    Private Sub frmProdutividade_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Ano Corrente
        txtAno.Text = Year(Date.Now)
        'Começa em Janeiro
        txtMesINI.Text = 1
        'Termina no mes corrente
        txtMesFIM.Text = Month(Date.Now)
        'Define as cores das linhas por mes (criando um gradiente de cores)
        For i As Integer = 0 To 11
            Cor_Fundo(i) = Color.FromArgb(RGB(90 + (i * 10), 220 + i, 244))
        Next i

        'dsResultado.WriteXmlSchema("C:\produtividade.xml")

    End Sub

    Private Sub btVer_Click(sender As System.Object, e As System.EventArgs) Handles btVer.Click

        Me.Cursor = Cursors.WaitCursor
        msg("Iniciando obtenção de dados...")
        'Limpa os dados anteriores
        dsResultado.Tables(0).Rows.Clear()

        Producao_em_lotes()
Fim:
        'Função que resume o datagrid recalculando as porcentagens e num de mudas por hora
        Resumo_DataGrid()
        btExcel.Enabled = True
        Me.Cursor = Cursors.Arrow
        msg("...")
    End Sub

    Private Sub Producao_em_lotes()
        '*
        '*  PRODUTIVIDADE INDIVIDUAL
        '*

        'Começa varrendo os meses
        Dim m As Integer
        For m = txtMesINI.Text To txtMesFIM.Text
            Dim SQL As String, DT As DataTable
            'Seleção da produtividade individual
            msg("Obtendo dados para o Mês " & m.ToString("00") & "/" & txtAno.Text)
            'Gera SQL de Seleção
            SQL = "SELECT Repicador,(SELECT Nome FROM repicador WHERE id=repicador) AS Nome,SUM(TIME_TO_SEC(tempo))/3600 AS Horas,SUM(Est_Inicial) AS Prod, SUM(Contaminacao) - SUM(oxidacao) AS Cont FROM Lotes WHERE MONTH(DATA)=" & m & " AND YEAR(DATA)=" & txtAno.Text & " AND fase IN(3,4,5,6,9,10) AND NOT INSTR(repicador,';') GROUP BY repicador;"
            'Debug
            Console.WriteLine(SQL)
            Try
                DT = SQLQuery(SQL)
                'Se houve algum resultado
                If DT.Rows.Count > 0 Then
                    'Roda todas as linhas fazendo a inclusão no DATASET
                    For r As Integer = 0 To DT.Rows.Count - 1
                        'Faz a inclusão no DATASET 
                        With DT.Rows(r)
                            Try
                                dsResultado.Tables(0).Rows.Add(m, .Item("Repicador"), .Item("Nome"), .Item("Prod"), .Item("Cont"), (.Item("Cont") / .Item("Prod") * 100), .Item("Horas"), (.Item("Prod") / (.Item("Horas"))))
                            Catch ex As Exception
                                MsgBox("Erro ao tentar incluir os dados do Banco de Dados no DataSet" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                                GoTo Fim
                            End Try
                        End With
                    Next
                Else
                    'Só acontece isso caso não tenham materiais repicados no mês
                    GoTo Volta
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar obter dados dos repicadores" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                GoTo Fim
            End Try


            '*
            '* PRODUTIVIDADE COMBINADA
            '*

            SQL = "SELECT Repicador,(SELECT Nome FROM repicador WHERE id=repicador) AS Nome,SUM(TIME_TO_SEC(tempo))/3600 AS Horas,SUM(Est_Inicial) AS Prod, SUM(Contaminacao) - SUM(oxidacao) AS Cont FROM Lotes WHERE MONTH(DATA)=" & m & " AND YEAR(DATA)=" & txtAno.Text & " AND fase IN(3,4,5,6,9,10) AND INSTR(repicador,';') GROUP BY repicador;"
            Try
                DT = SQLQuery(SQL)
                'Se houve algum resultado
                If DT.Rows.Count > 0 Then
                    'Roda todas as linhas fazendo a inclusão no DATASET
                    For r As Integer = 0 To DT.Rows.Count - 1
                        'Faz a inclusão no DATASET 
                        With DT.Rows(r)
                            Try
                                'Divide os repicadores que participam da produção
                                Dim Reps() As String
                                Reps = Split(.Item("Repicador"), ";")
                                'Processa a informação para cada um dos repicadores
                                For i As Integer = 0 To Reps.Length - 1
                                    Dim Atual As Repicador
                                    'Pega o código do repicador atual
                                    Atual.Cod = Reps(i)
                                    'Função para dividir a produção e pegar o repicador atual
                                    Divide_Producao(Atual, .Item("Repicador"), m, .Item("Prod"), .Item("Cont"), .Item("Horas"))
                                    'Atualiza o DataSET com os dados do repicador Atual
                                    Soma_DataSET(Atual, m)
                                Next

                            Catch ex As Exception
                                MsgBox("Erro ao tentar incluir os dados do Banco de Dados no DataSet" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                                GoTo Fim
                            End Try
                        End With
                    Next
                Else
                    GoTo Volta
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar obter dados dos lotes combinados" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                GoTo Fim
            End Try
Volta:
        Next

fim:

    End Sub


    Private Sub Resumo_DataGrid()
        msg("Resumindo dados para criação das estatísticas")

        'Acumula os valores para fazer as médias
        Dim totProd As Integer = 0, totCont As Integer = 0, totHoras As Double = 0, totPercent As Double = 0
        Dim medProd As Integer = 0, medCont As Integer = 0, medHoras As Double = 0, medPercent As Double = 0
        'Pega o número total de amostras
        Dim num As Integer = dsResultado.Tables(0).Rows.Count

        'Resume tudo recalculando todos os índices de aproveitamento
        For i As Integer = 0 To dsResultado.Tables(0).Rows.Count - 1
            'Calcula para cada linha
            With dsResultado.Tables(0).Rows(i)
                'Refaz os índices de Percentagem e Mudas por hora
                'Tira problema com divisão por zero
                If .Item("Produzido") > 0 Then
                    .Item("Percent") = .Item("Contaminado") / .Item("Produzido")
                Else
                    .Item("Percent") = 0
                End If
                'Exclui problema com divisão por zero
                If .Item("Horas") > 0 Then
                    .Item("Mds_hora") = .Item("Produzido") / .Item("Horas")
                Else
                    .Item("Mds_hora") = 0
                End If
                'Acumula os totais de Produção e Contaminação
                totProd += .Item("Produzido")
                totCont += .Item("Contaminado")
                totHoras += .Item("Horas")
                totPercent += .Item("Percent")
            End With
        Next
        'Porcentage de contaminação
        totPercent = totCont / totProd * 100

        'Faz as médias
        medProd = totProd / num
        medCont = totCont / num
        medHoras = totHoras / num
        medPercent = totCont / totProd * 100

        'Preenche o resumo dos totais
        lblTotProd.Text = totProd.ToString("N0")
        lblTotCont.Text = totCont.ToString("N0")
        lblTotHoras.Text = totHoras.ToString("N1")
        lblTotPercent.Text = totPercent.ToString("N1")

        'Preenche as médias 
        lblMedProd.Text = medProd.ToString("N0")
        lblMedCont.Text = medCont.ToString("N0")
        lblMedHoras.Text = medHoras.ToString("N1")
        lblMedPercent.Text = medPercent.ToString("N1")
    End Sub

    Private Sub Soma_DataSET(ByRef Atual As Repicador, ByVal Mes As Integer)
        'Pesquisa cada linha do DATASET
        For i As Integer = 0 To dsResultado.Tables(0).Rows.Count - 1
            With dsResultado.Tables(0).Rows(i)
                'Se o mes for o mesmo e o repicador for o mesmo então faz a soma dos parametros
                If .Item("Cod") = Atual.Cod And .Item("Mes") = Mes Then
                    .Item("Produzido") += Atual.Prod
                    .Item("Contaminado") += Atual.Cont
                    .Item("Horas") += Atual.Horas
                End If
            End With
        Next
    End Sub

    Private Sub Divide_Producao(ByRef Atual As Repicador, ByVal Envolvidos As String, ByVal Mes As Integer, ByVal Prod As Integer, Cont As Integer, Horas As Integer)
        Dim SQL As String, SQL2 As String, DT_Total As DataTable, DT_Individual As DataTable
        Dim idxProd As Double, idxCont As Double, idxHoras As Double

        'Envolvidos (troca para que possa ser usado na Clausula IN da consulta SQL
        Envolvidos = Envolvidos.Replace(";", ",")
        'Monta a SQL que Irá Procurar os dados
        SQL = "SELECT SUM(TIME_TO_SEC(tempo))/3600 AS horas, SUM(Est_Inicial) AS Prod, SUM(Contaminacao) AS Cont FROM lotes WHERE MONTH(DATA)=" & Mes & " AND YEAR(DATA)=" & txtAno.Text & " AND fase IN(3,4,5,6,9,10) AND NOT INSTR(repicador,';') AND Repicador IN(" & Envolvidos & ")"
        SQL2 = "SELECT repicador as Cod,SUM(TIME_TO_SEC(tempo))/3600 AS horas,SUM(Est_Inicial) AS Prod, SUM(Contaminacao) AS Cont FROM lotes WHERE MONTH(DATA)=" & Mes & " AND YEAR(DATA)=" & txtAno.Text & " AND fase IN(3,4,5,6,9,10) AND NOT INSTR(repicador,';') AND Repicador IN(" & Envolvidos & ") GROUP BY Repicador"
        'Tenta recuperar no banco de dados
        Try
            'Pega o valor combinado no banco de dados
            DT_Total = SQLQuery(SQL)
            DT_Individual = SQLQuery(SQL2)
            'Se deu algum resultado
            If DT_Total.Rows.Count > 0 And DT_Individual.Rows.Count > 0 Then
                'Procura o repicador atual na tabela dos individuais
                For Each DR As DataRow In DT_Individual.Rows
                    'Se localizar o repicador atual na tabela individual
                    If DR.Item("Cod") = Atual.Cod Then
                        'Cria os índices de cada ítem para acrescentar no repicador
                        'Prevê erro de divisão por zero
                        If DT_Total.Rows(0).Item("Prod") > 0 Then
                            idxProd = DR.Item("Prod") / DT_Total.Rows(0).Item("Prod")
                        Else
                            idxProd = 0
                        End If
                        'Elimina erro de divisão por zero
                        If DT_Total.Rows(0).Item("Cont") > 0 Then
                            idxCont = DR.Item("Cont") / DT_Total.Rows(0).Item("Cont")
                        Else
                            idxCont = 0
                        End If
                        'Elimina erro de Divisão por zero
                        If DT_Total.Rows(0).Item("Horas") > 0 Then
                            idxHoras = DR.Item("Horas") / DT_Total.Rows(0).Item("Horas")
                        Else
                            idxHoras = 0
                        End If

                        Console.WriteLine("Mes=" & Mes.ToString("00") & " Cod=" & Atual.Cod & " Prod=" & idxProd.ToString("N4") & " Cont=" & idxCont.ToString("N4") & " Horas=" & idxHoras.ToString("N4"))

                        'Atribui à cada um a sua porção
                        Atual.Prod = Int(Prod * idxProd)
                        Atual.Cont = Int(Cont * idxCont)
                        Atual.Horas = (Horas * idxHoras)

                        'Console.WriteLine("Cod=" & Atual.Cod & " Prod=" & Atual.Prod & " Cont=" & Atual.Cont & " Horas=" & Atual.Horas)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Erro ao pegar a soma combinada dos repicadores" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub btPrint_Click(sender As System.Object, e As System.EventArgs) Handles btPrint.Click
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "crREL_Produtividade.rpt"

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            msg("Preparando Relatório")

            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            CR.SetDataSource(dsResultado)

            msg("Definindo parâmetros")

            'Define o parameter field
            CR.SetParameterValue("txtAno", txtAno.Text)
            CR.SetParameterValue("txtMesINI", txtMesINI.Text)
            CR.SetParameterValue("txtMesFIM", txtMesFIM.Text)

            'Manda o relatório para impressoa
            ' StartPage=0 e EndPage=0 = Imprime todas
            msg("Enviando para impressora")
            CR.PrintToPrinter(1, False, 0, 0)
            MsgBox("Relatório impresso com sucesso", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o relatório para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub
End Class


