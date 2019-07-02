Imports Microsoft.Office.Interop

Module ExportExcel
    'Constantes utilizadas na formatação do Excel
    Const xlGeneral = 1
    Const xlCenter = -4108
    Const xlContent = -5002
    Const xlSolid = 1
    Const xlAutomatic = -4105
    Const xlThemeColorDark1 = 1
    Const xlThemeColorAccent3 = 7
    Const xlNone = -4142
    Const xlDiagonalDown = 5
    Const xlDiagonalUp = 6
    Const xlEdgeLeft = 7
    Const xlEdgeTop = 8
    Const xlEdgeBottom = 9
    Const xlEdgeRight = 10
    Const xlInsideVertical = 11
    Const xlInsideHorizontal = 12
    Const xlContinuous = 1
    Const xlThin = 2

    Sub Resumo_Pedidos()
        'Inicia o Excel e cria um novo workbook/worksheet
        Dim excelApp As New Excel.Application
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
        Dim myDT As DataTable, DR As DataRow, i As Integer, SQL As String, Faixa As String

        'Torna o Excel invisível ao usuário até que a planilha seja preenchida
        excelApp.Visible = False
        Dim Hoje As String = Format(Date.Now, "dd/MM/yyyy")

        With excelWorksheet
            'Título
            .Range("A1").Value = "Planilha Resumo de Pedidos - " & Hoje
            'Rótulos
            .Range("A3").Value = "Cód"
            .Range("B3").Value = "Clone"
            .Range("C3").Value = "Cliente"
            .Range("D3").Value = "Pedido"
            .Range("E3").Value = "Data"
            .Range("F3").Value = "Quantidade"
            .Range("G3").Value = "Atendido"
            .Range("H3").Value = "Aberto"
            .Range("I3").Value = "Crescendo"
            .Range("J3").Value = "Liberado"
            .Range("K3").Value = "Finalização"
            .Range("L3").Value = "Multiplicando"
            .Range("M3").Value = "Produzir"
            .Range("N3").Value = "Enraizar"
            .Range("O3").Value = "Plantar"
            .Range("P3").Value = "Faturar"
            'Tem que formatar aqui por causa do texto logn que vem depois
            .Columns("A:A").EntireColumn.AutoFit()
            'Define as celulas a serem trabalhadas
            Faixa = "A3:P3"
            .Range(Faixa).Font.Bold = True
            .Range(Faixa).HorizontalAlignment = xlCenter
            .Range(Faixa).VerticalAlignment = xlCenter
            .Range(Faixa).Interior.Pattern = xlSolid
            .Range(Faixa).Interior.Color = RGB(200, 200, 200)

            With .Range(Faixa).Interior
                .TintAndShade = -0.0499893185216834
                .PatternTintAndShade = 0
            End With

            'Define as celulas a serem trabalhadas
            Faixa = "A1:P1"
            With .Range(Faixa)
                .HorizontalAlignment = xlCenter
                .VerticalAlignment = xlCenter
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .IndentLevel = 0
                .ShrinkToFit = False
                .MergeCells = False
            End With
            .Range(Faixa).Merge()
            .Range(Faixa).Font.Bold = True
            With .Range(Faixa).Font
                .Name = "Arial"
                .Size = 16
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
                .TintAndShade = 0
            End With

            'Realiza a pesquisa primária no banco de dados
            SQL = "SELECT pedidos_itens.CodPro,pedidos_itens.Clone,pedidos_itens.Pedido_id,pedidos.Data,pedidos.Cliente,pedidos_itens.Descricao,pedidos_itens.Quantidade,pedidos_itens.Atendido FROM pedidos_itens INNER JOIN pedidos ON (pedidos_itens.Pedido_id = pedidos.id) WHERE pedidos_itens.Atendido<pedidos_itens.Quantidade AND pedidos_itens.Status IN (0,1,2) ORDER BY pedidos_itens.CodPro,pedidos_itens.Clone,pedidos.data"
            myDT = SQLQuery(SQL)
            'Primeira linha disponível para dados na planilha
            i = 4
            Dim CR As Integer, MOLD As Integer, CLOLD As Integer, Pesquisa As DataTable, DR1 As DataRow
            Dim Multiplicacao As Integer, Final As Integer, Crescendo As Integer, Liberado As Integer
            MOLD = Nothing
            CLOLD = Nothing
            CR = 0
            'CR = Contador de Repeticao
            'MOLD = Mercadoria anterior

            'Aqui começa a colocar os dados no relatorio
            For Each DR In myDT.Rows
                'Se for a primeira vez tem que pesquisar
                If i > 4 Then
                    'Se for diferente Recalcula
                    If (MOLD <> DR("CodPro")) Or (CLOLD <> DR("Clone")) Then
                        Multiplicacao = 0
                        Final = 0
                        Crescendo = 0
                        Liberado = 0

                        'SQL para saber quantos existem multiplicando em laboratorio
                        SQL = "SELECT SUM(estoque) AS estoque FROM lotes WHERE ativo=1 AND fase IN(1,2,3,9) AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                        'Para retornar o valor
                        Pesquisa = SQLQuery(SQL)
                        DR1 = Pesquisa.Rows(0)
                        If IsDBNull(DR1("Estoque")) Then
                            Multiplicacao = 0
                        Else
                            Multiplicacao = DR1("Estoque")
                        End If

                        'SQL para saber quantos existem Enraizando em laboratorio
                        SQL = "SELECT SUM(estoque) AS estoque FROM lotes WHERE ativo=1 AND fase IN(4,5,6) AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                        'Para retornar o valor
                        Pesquisa = SQLQuery(SQL)
                        DR1 = Pesquisa.Rows(0)
                        If IsDBNull(DR1("Estoque")) Then
                            Final = 0
                        Else
                            Final = DR1("Estoque")
                        End If

                        'SQL para saber quantas mudas existem liberadas na Estufa
                        SQL = "SELECT SUM(natual) AS Estoque FROM aux_bandejas WHERE liberada=1 AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                        'Para retornar o valor
                        Pesquisa = SQLQuery(SQL)
                        DR1 = Pesquisa.Rows(0)
                        If IsDBNull(DR1("Estoque")) Then
                            Liberado = 0
                        Else
                            Liberado = DR1("Estoque")
                        End If

                        'SQL para saber quantas mudas existem liberadas na Estufa
                        SQL = "SELECT SUM(natual) AS Estoque FROM aux_bandejas WHERE liberada=0 AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                        'Para retornar o valor
                        Pesquisa = SQLQuery(SQL)
                        DR1 = Pesquisa.Rows(0)
                        If IsDBNull(DR1("Estoque")) Then
                            Crescendo = 0
                        Else
                            Crescendo = DR1("Estoque")
                        End If

                        DR1 = Nothing
                        Pesquisa = Nothing
                        'Torna a linha unica
                        .Range("A" & i & ":P" & i).Merge()
                        .Range("A" & i & ":P" & i).Interior.Pattern = xlSolid
                        .Range("A" & i & ":P" & i).Interior.Color = RGB(230, 230, 230)
                        'Pula uma linha antes também
                        i += 1
                        'Esses valores aqui vem da pesquisa individual
                        .Range("A" & i & ":H" & i).Merge()
                        .Range("A" & i).Value = "Estoque para Mercadoria " & DR("CodPro") & "." & DR("clone")
                        .Range("A" & i & ":L" & i).Font.Bold = True
                        .Range("I" & i).Value = Crescendo
                        .Range("J" & i).Value = Liberado
                        .Range("K" & i).Value = Final
                        .Range("L" & i).Value = Multiplicacao
                        'pula uma linha
                        i += 1
                    Else    'Se for igual não precisa
                        'Acrescenta 1 ao contador de repetição
                        CR += 1
                    End If

                ElseIf i = 4 Then
                    'Na primeira linha tem que recalcular direto
                    Multiplicacao = 0
                    Final = 0
                    Crescendo = 0
                    Liberado = 0

                    'SQL para saber quantos existem multiplicando em laboratorio
                    SQL = "SELECT SUM(estoque) AS estoque FROM lotes WHERE ativo=1 AND fase IN(1,2,3,9) AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                    'Para retornar o valor
                    Pesquisa = SQLQuery(SQL)
                    DR1 = Pesquisa.Rows(0)
                    'Capturar o Erro de DBNULL
                    If IsDBNull(DR1("Estoque")) Then
                        Multiplicacao = 0
                    Else
                        Multiplicacao = DR1("Estoque")
                    End If

                    'SQL para saber quantos existem Enraizando em laboratorio
                    SQL = "SELECT SUM(estoque) AS estoque FROM lotes WHERE ativo=1 AND fase IN(4,5,6) AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                    'Para retornar o valor
                    Pesquisa = SQLQuery(SQL)
                    DR1 = Pesquisa.Rows(0)
                    If IsDBNull(DR1("Estoque")) Then
                        Final = 0
                    Else
                        Final = DR1("Estoque")
                    End If

                    'SQL para saber quantas mudas existem liberadas na Estufa
                    SQL = "SELECT SUM(natual) AS Estoque FROM aux_bandejas WHERE liberada=1 AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                    'Para retornar o valor
                    Pesquisa = SQLQuery(SQL)
                    DR1 = Pesquisa.Rows(0)
                    If IsDBNull(DR1("Estoque")) Then
                        Liberado = 0
                    Else
                        Liberado = DR1("Estoque")
                    End If

                    'SQL para saber quantas mudas existem liberadas na Estufa
                    SQL = "SELECT SUM(natual) AS Estoque FROM aux_bandejas WHERE liberada=0 AND mercadoria=" & DR("CodPro") & " AND clone=" & DR("Clone")
                    'Para retornar o valor
                    Pesquisa = SQLQuery(SQL)
                    DR1 = Pesquisa.Rows(0)
                    If IsDBNull(DR1("Estoque")) Then
                        Crescendo = 0
                    Else
                        Crescendo = DR1("Estoque")
                    End If

                    DR1 = Nothing
                    Pesquisa = Nothing
                    'Esses valores aqui vem da pesquisa individual
                    .Range("A" & i & ":H" & i).Merge()
                    .Range("A" & i & ":L" & i).Font.Bold = True
                    .Range("A" & i).Value = "Estoque para Mercadoria " & DR("CodPro") & "." & DR("clone")
                    .Range("I" & i).Value = Crescendo
                    .Range("J" & i).Value = Liberado
                    .Range("K" & i).Value = Final
                    .Range("L" & i).Value = Multiplicacao
                    'pula uma linha
                    i += 1
                End If

                .Range("A" & i).Value = DR("CodPro")
                MOLD = DR("CodPro")
                CLOLD = DR("clone")
                .Range("B" & i).Value = DR("Clone")
                .Range("C" & i).Value = DR("Cliente")
                .Range("D" & i).Value = DR("Pedido_ID")
                .Range("E" & i).Value = DR("Data")
                .Range("F" & i).Value = DR("Quantidade")
                .Range("G" & i).Value = DR("Atendido")
                'Esse sai por formula de calculo
                .Range("H" & i).Formula = "=F" & i & "-G" & i
                i += 1
            Next
            'Formatação extra
            .Columns("B:B").EntireColumn.AutoFit()
            .Columns("C:C").EntireColumn.AutoFit()
            .Columns("D:D").ColumnWidth = 6.71
            .Columns("E:E").EntireColumn.AutoFit()
            .Columns("A:A").ColumnWidth = 9
            .Columns("G:L").ColumnWidth = 9
            .Range("F4:P" & i - 1).NumberFormat = "#.##0"

            'Coloca as bordas em tudo
            'Faixa de células que vai ser trabalhada
            Faixa = "A3:P" & i - 1
            .Range(Faixa).Borders(xlDiagonalDown).LineStyle = xlNone
            .Range(Faixa).Borders(xlDiagonalUp).LineStyle = xlNone
            With .Range(Faixa).Borders(xlEdgeLeft)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeTop)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeBottom)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeRight)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlInsideVertical)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlInsideHorizontal)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
        End With

        'Torna o Excel visível ao usuário para que a planilha possa ser consultada
        excelApp.Visible = True

    End Sub

    'Exporta os ítens dos pedidos juntamente com o estoque para ver quando precisaria produzir.
    Sub Resumo_Producao()
        'Inicia o Excel e cria um novo workbook/worksheet
        Dim excelApp As New Excel.Application
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
        Dim myDT As DataTable, DR As DataRow, i As Integer, SQL As String, Faixa As String
        Dim Valor As Integer

        'Torna o Excel invisível ao usuário até que a planilha seja preenchida
        excelApp.Visible = False
        Dim Hoje As String = Format(Date.Now, "dd/MM/yyyy")

        'Formata a planilha para receber os dados
        With excelWorksheet
            .Range("A3").Value = "Mercadoria"
            .Range("B3").Value = "Clone"
            .Range("C3").Value = "Quantidade"
            .Range("D3").Value = "Atendido"
            .Range("E3").Value = "Saldo"
            .Range("F3").Value = "Estoque Iniciação"
            .Range("G3").Value = "Estoque Multiplicação"
            .Range("H3").Value = "Estoque Enraizamento"
            .Range("I3").Value = "Estufa não liberado"
            .Range("J3").Value = "Estufa Liberado"
            .Range("K3").Value = "A Produzir"
            .Range("3:3").RowHeight = 30

            With .Range("A3:K3")
                .HorizontalAlignment = xlCenter
                .VerticalAlignment = xlCenter
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .IndentLevel = 0
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With .Range("A3:K3").Font
                .Name = "Calibri"
                .FontStyle = "Negrito"
                .Size = 9
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
                .TintAndShade = 0
            End With
            .Columns("A:J").EntireColumn.AutoFit()
        End With

        'Monta a SQL principal por onde vai correr os pedidos
        SQL = "SELECT * FROM resumo_pedidos ORDER BY CodPro,Clone"
        'Busca a tabela no banco de dados
        myDT = SQLQuery(SQL)

        'Define o "i" como a linha da planilha
        'Na linha 4 começam os dados
        i = 4

        'Percorre cada linha para montar a tabela no Excel
        For Each DR In myDT.Rows
            'Pega o Excel novamente
            With excelWorksheet
                'começa a preencher a Planilha
                .Range("A" & i).Value = DR("CodPro")
                .Range("B" & i).Value = DR("Clone")
                .Range("C" & i).Value = DR("SQuantidade")
                .Range("D" & i).Value = DR("SAtendido")
                'Diminui o Pedido do Atendido
                .Range("E" & i).Formula = "=C" & i & "-" & "D" & i

                'Estoque do LABORATORIO
                '
                'Estoque de iniciação
                Dim Result = DLookup("Estoque", "estoque_lab_fase", "Fase=1 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor = Ret_Resultado(Result)
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=2 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor += Ret_Resultado(Result)
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=10 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor += Ret_Resultado(Result)
                .Range("F" & i).Value = Valor

                'Estoque na Multiplicação
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=3 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor = Ret_Resultado(Result)
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=9 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor += Ret_Resultado(Result)
                .Range("G" & i).Value = Valor
                'Estoque no Enraizamento
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=4 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor = Ret_Resultado(Result)
                Result = DLookup("Estoque", "estoque_lab_fase", "Fase=5 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                Valor += Ret_Resultado(Result)
                .Range("H" & i).Value = Valor

                'Estoque da ESTUFA
                '
                'Estoque recém plantado
                Result = DLookup("Estoque", "estoque_est_fase", "Liberada=0 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                .Range("I" & i).Value = Ret_Resultado(Result)
                'Estoque pronto para venda
                Result = DLookup("Estoque", "estoque_est_fase", "Liberada=1 AND Mercadoria=" & DR("CodPro") & " AND Clone=" & DR("Clone"))
                .Range("J" & i).Value = Ret_Resultado(Result)

                'Calcula o saldo menos tudo o que já tem produzido
                .Range("K" & i).Formula = "=E" & i & "-SOMA(F" & i & ":J" & i & ")"
            End With
            'Próxima linha
            i += 1
        Next
        'Formata a planilha pronta
        Faixa = "C4:K" & i - 1
        With excelWorksheet
            .Columns("E:E").EntireColumn.AutoFit()
            .Range(Faixa).Borders(xlDiagonalDown).LineStyle = xlNone
            .Range(Faixa).Borders(xlDiagonalUp).LineStyle = xlNone
            With .Range(Faixa).Borders(xlEdgeLeft)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeTop)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeBottom)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlEdgeRight)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlInsideVertical)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            With .Range(Faixa).Borders(xlInsideHorizontal)
                .LineStyle = xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = xlThin
            End With
            .Range(Faixa).NumberFormat = "#.##0"
            Faixa = "A3:K3"
            With .Range(Faixa).Interior
                .Pattern = xlSolid
                .PatternColorIndex = xlAutomatic
                .ThemeColor = xlThemeColorAccent3
                .TintAndShade = 0.599993896298105
                .PatternTintAndShade = 0
            End With
            Faixa = "A4:B" & i - 1
            With .Range(Faixa).Interior
                .Pattern = xlSolid
                .PatternColorIndex = xlAutomatic
                .ThemeColor = xlThemeColorAccent3
                .TintAndShade = 0.799981688894314
                .PatternTintAndShade = 0
            End With
            Faixa = "K4:K" & i - 1
            With .Range(Faixa).Interior
                .Pattern = xlSolid
                .PatternColorIndex = xlAutomatic
                .ThemeColor = xlThemeColorAccent3
                .TintAndShade = 0.799981688894314
                .PatternTintAndShade = 0
            End With

            'Formata o Cabecalho
            '

            .Range("A1").Value = "Mapa de Produção"
            Faixa = "A1:I1"
            With .Range(Faixa)
                .HorizontalAlignment = xlCenter
                .VerticalAlignment = xlCenter
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .IndentLevel = 0
                .ShrinkToFit = False
                .MergeCells = True
            End With
            'Arruma a fonte
            With .Range(Faixa).Font
                .Name = "Calibri"
                .Size = 14
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
            End With
            .Range(Faixa).Font.Bold = True
            Faixa = "J1:K1"
            With .Range(Faixa)
                .HorizontalAlignment = xlCenter
                .VerticalAlignment = xlCenter
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .IndentLevel = 0
                .ShrinkToFit = False
                .MergeCells = True
            End With
            .Range(Faixa).Value = Date.Today
            .Range(Faixa).NumberFormat = "dd/mm/aaaa"
        End With
        'torna o Excel Visível
        excelApp.Visible = True
    End Sub

    Private Function Ret_Resultado(ByVal Result)
        If IsDBNull(Result) Or Result = "" Then
            Return 0
        Else
            Return Result
        End If
    End Function
End Module
