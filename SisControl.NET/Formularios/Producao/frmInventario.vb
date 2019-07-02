Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmInventario
    'Usa as variáveis globais para fazer o inventário (Acessível a todas as funções)

    Dim xl As New Application
    Dim xlw As Workbook
    Dim sheet As Worksheet
    Dim r As Range

    Dim oEscrever As System.IO.StreamWriter

    Private Structure Lote
        Dim Mercadoria As Integer
        Dim Lote As Integer
        Dim Clone As Integer
        Dim Codigo As String
        Dim id As Integer
        Dim Frasco As Integer
        Dim nMudas As Int16
        Dim frID As Integer
    End Structure

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Mostra a caixa de diálogo
        fileExcel.ShowDialog()
        txtArquivo.Text = fileExcel.FileName
    End Sub

    Private Sub Abre_Planilha()


        Me.Cursor = Cursors.WaitCursor

        msg("Abrindo arquivo do Excel...")
        Try
            Dim lins As Integer = 0
            'Abrir o arquivo do Excel 
            xlw = xl.Workbooks.Open(txtArquivo.Text)

            msg("Selecionando planilha com dados...")
            'Seleciona a primeira planilha 1
            xlw.Sheets(1).select()

            ' Pega a planilha 1
            sheet = xlw.Sheets(1)

            ' Verifica a faixa de células que está sendo usada
            r = sheet.UsedRange
            lins = r.Rows.Count

            'Define os valores da barra de progresso
            pbProgresso.Minimum = 0
            pbProgresso.Maximum = lins

            Console.WriteLine("Número de Linhas: {0}", lins)
            msg("Ordenando dados...")

            'Limpa as classificações anteriores
            sheet.Sort.SortFields.Clear()
            'Cria o novo modelo de classificação
            sheet.Sort.SortFields.Add(Key:=sheet.Range("A:A"), SortOn:=XlSortOn.xlSortOnValues, Order:=XlSortOrder.xlAscending, DataOption:=XlSortDataOption.xlSortTextAsNumbers)

            'Com a planilha ativa faz a classificação
            With sheet.Sort
                .SetRange(sheet.Range("A1:A" & lins))
                .Header = XlYesNoGuess.xlNo
                .MatchCase = False
                .Orientation = XlSortOrientation.xlSortColumns
                .SortMethod = XlSortMethod.xlPinYin
                .Apply()
            End With
        Catch ex As Exception
            MsgBox("Erro ao manipular o arquivo Excel" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub msg(ByVal texto As String)
        lblMsg.Text = texto
        lblMsg.Refresh()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Se o arquivo ainda não foi informado
        If txtArquivo.Text = String.Empty Then
            Exit Sub
        End If

        'Desabilita o botão durante o processamento.
        Button2.Enabled = False
        'Abre a planilha e verifica as abas
        oEscrever = File.CreateText("c:\Registro_erros_Inventario.txt")
        Abre_Planilha()
        Processa_Dados()
        msg("Montando resumo")
        Monta_Resumo()
        'Fecha o arquivo de Log de Erros
        oEscrever.Close()
        msg("Concluído!")

        'Fecha o arquivo salvando o conteúdo ordenado
        xlw.Close(True)
        ' Liberamos a memória
        xlw = Nothing
        xl = Nothing
        'reabilita o botão
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Dim i As Integer

    Private Sub Processa_Dados()
        
        'Limpa a tabela resumo
        DsInventario.Tables(0).Rows.Clear()
        'Limpa a tabela auxiliar de inventário
        Dim a As Integer
        a = MsgBox("Deseja limpar qualquer dado de um inventário anterior?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")
        If a = vbYes Then
            ExecutaSQL("DELETE FROM aux_inventario_lotes")
        End If

        'Define o cursor para espera
        Me.Cursor = Cursors.WaitCursor

        'Percorre todas as linhas da planilha ativa
        Dim invOld As String = ""
        Dim Codigo As New Lote, ct As Integer = 0, CodigoOld As New Lote, idLOTE As Integer
        For i = 1 To r.Rows.Count
            With r

                msg("Processando linha " & i & " de " & r.Rows.Count)

                'Processar os dados referentes ao Frasco em questão
                'Separa o código e pega o ID no Banco de dados
                Dim Celula As String = sheet.Range("A" & i).Value
                If Celula = String.Empty Then
                    oEscrever.WriteLine(i.ToString("000000") & " - Linha em branco")
                    GoTo Proximo
                End If
                Separa_Codigo(Celula, Codigo)
                'Se for a primeira vez que passa aqui
                If i = 1 Then
                    'Passou pela primeira vez tem que pegar o id do lote
                    Procura_id_Lote(Codigo)
                    idLOTE = Codigo.id
                    'Automáticamente o código atual e o antigo são os mesmos
                    CodigoOld = Codigo
                End If
                'Processa cada linha verificando se mudou de lote
                If Codigo.Codigo <> CodigoOld.Codigo Then
                    'Acrescenta uma linha ao Dataset que representa o lote
                    With CodigoOld
                        Dim mds_fr As Int16 = 0
                        'se o código tem um id Válido busca as informações do lote
                        If CodigoOld.id <> -1 Then
                            mds_fr = DLookup("Mudas_frasco", "Lotes", "id=" & CodigoOld.id)
                        End If
                        DsInventario.Tables(0).Rows.Add({.id, .Codigo, mds_fr, 3, .Mercadoria, .Lote, .Clone, ct})
                    End With
                    'Se mudou de lote pega o código como referencia e zera o contador de frascos
                    'Também é necessário pegar o id do novo lote
                    Procura_id_Lote(Codigo)
                    idLOTE = Codigo.id
                    CodigoOld = Codigo
                    ct = 1
                Else
                    'Conta um frasco a mais para esse lote
                    ct += 1
                End If
                'Como não procuramos o id a cada frasco para diminuir o processamento
                'Então adotei a estratégia de usar o ID que está em uso
                Codigo.id = idLOTE
                'Procura o Frasco que está sendo processado
                Procura_Frasco(Codigo)
                'Coloca o frasco na tabela auxiliar de inventário
                ExecutaSQL("INSERT INTO aux_inventario_lotes SET Lote=" & idLOTE & ", Vidro=" & Codigo.Frasco & ", nMudas=" & Codigo.nMudas)
                pbProgresso.Value = i
                pbProgresso.Refresh()
            End With
Proximo:
        Next
        'insere o último registro 
        With Codigo
            Dim mds_fr As Int16 = 0
            'se o código tem um id Válido busca as informações do lote
            If Codigo.id <> -1 Then
                mds_fr = DLookup("Mudas_frasco", "Lotes", "id=" & Codigo.id)
            End If
            DsInventario.Tables(0).Rows.Add({.id, .Codigo, mds_fr, Codigo.nMudas, .Mercadoria, .Lote, .Clone, ct})
        End With
        'Volta o cursor ao normal.
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Monta_Resumo()
        'Conta as linhas da planilha para saber quantos frascos foram computados
        lblFrascosProcessados.Text = r.Rows.Count.ToString("N0")
        'conta quantas linhas foram geradas (Lotes)
        lblLotesProcessados.Text = DsInventario.Tables(0).Rows.Count.ToString("N0")
        Dim Estoque As Integer = 0, Frascos As Integer = 0
        'Percorre todo o dataset somando o estoque

        For i As Integer = 0 To DsInventario.Tables(0).Rows.Count - 1
            With DsInventario.Tables(0).Rows(i)
                .Item("colEstoque") = .Item("colFrascos") * .Item("colMds_Frasco")
                Estoque += .Item("colEstoque")
                Frascos += .Item("colFrascos")
            End With
        Next
        lblEstoqueTotal.Text = Estoque.ToString("N0")

    End Sub

    Private Sub Separa_Codigo(ByVal Codigo As Double, ByRef Lote_Processado As Lote)
        'Pega o valor do código e separa nas variáveis
        '0150150005017 (Exemplo de código para tirar as posições)
        '0001112222333
        Dim txtCod As String
        '                        000 111 2222 333
        'txtCod = Format(Codigo, "0000000000000")

        txtCod = Codigo.ToString.PadLeft(13, "0")

        'Separa as posições
        With Lote_Processado
            .Mercadoria = txtCod.Substring(0, 3)
            .Lote = txtCod.Substring(3, 3)
            .Clone = txtCod.Substring(6, 4)
            .Frasco = txtCod.Substring(10, 3)
            .Codigo = .Mercadoria.ToString("000") & "." & .Lote.ToString("000") & "." & .Clone.ToString("0000")
            .id = -1
        End With
    End Sub
    'Sub que retorna o ID do lote consultado
    Private Sub Procura_id_Lote(ByRef Codigo As Lote)
        'Tenta localizar o ID do lote processado
        Dim idLote As Object
        With Codigo
            Try
                'Tenta localizar o lote.
                idLote = DLookup("id", "Lotes", "Mercadoria=" & .Mercadoria & " AND Lote=" & .Lote & " AND Clone=" & .Clone & " AND Ativo=1")
                If IsDBNull(idLote) Or IsNothing(idLote) Or idLote = "" Then
                    Dim dataLote As String = String.Empty
                    dataLote = InputBox("O lote " & .Codigo & " Não foi encontrado." & vbCrLf & "Insira a DATA do lote:", "Data do Lote")
                    Log_Erro(Codigo, "Lote não encontrado, Data Solicitada")
                    If dataLote <> String.Empty Then
                        Dim SQL As String = String.Empty
                        idLote = DLookup("id", "Lotes", "Mercadoria=" & .Mercadoria & " AND Lote=" & .Lote & " AND Clone=" & .Clone & " AND data='" & Format(CDate(dataLote), "yyyy-MM-dd") & "'")
                        .id = idLote
                    Else
                        MsgBox("Lote não processado!", vbOKOnly, "Erro")
                        Exit Sub
                    End If
                Else
                    Console.WriteLine("Id do Lote processado:" & idLote.ToString)
                    .id = idLote
                End If
            Catch ex As Exception
                MsgBox("Lote " & .Codigo & " Não encontrado" & vbCr & ex.Message, vbOKOnly + MsgBoxStyle.Critical, "Lote não Encontrado")
                Log_Erro(Codigo, "Lote não encontrado mesmo com data")
            End Try
        End With
    End Sub

    Private Sub Log_Erro(ByRef Codigo As Lote, msg As String)
        'Registra o erro no arquivo
        If chkErro.Checked Then
            oEscrever.WriteLine(i.ToString("000000") & " - " & Codigo.Codigo & " - " & msg)
        End If

    End Sub


    Private Sub Procura_Frasco(ByRef Codigo As Lote)
        Dim SQL As String = String.Empty
        'Tenta procurar o frasco específicamente para pegar seus dados
        Try
            Dim nMudas As Object
            'Procura este frasco específicamente
            nMudas = DLookup("nMudas", "aux_frascos", "Vidro=" & Codigo.Frasco & " AND Lote=" & Codigo.id)
            'Se o frasco FOI encontrado
            If Not IsDBNull(nMudas) And Not IsNothing(nMudas) And nMudas <> "" Then
                Codigo.nMudas = nMudas
            Else
                'Se não encontrou o frasco específico procura no num de Mds/frasco do lote.
                nMudas = DLookup("Mudas_frasco", "Lotes", "id=" & Codigo.id)
                Codigo.nMudas = nMudas
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar o frasco " & Codigo.Frasco.ToString("000") & " do Lote: " & Codigo.Codigo & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Log_Erro(Codigo, "Frasco não localizado")
            Exit Sub
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim a As Int16, SQL As String
        'Atualiza a progress bar
        pbProgresso.Maximum = 100
        pbProgresso.Value = 0
        a = MsgBox("Esse inventário é um INVENTÁRIO COMPLETO ou PARCIAL?" & vbCrLf & "SIM = INVENTÁRIO COMPLETO" & vbCrLf & "NÃO = INVENTÁRIO PARCIAL" & vbCrLf & "CANCELAR = Não processa os dados", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Confirmação")
        'Se o usuário cancelar a ação então sai da rotina e não executa nada.
        If a = vbCancel Then
            Exit Sub
        End If
        'Se for um inventario TOTAL, então desativa TODOS os lotes e Reativa somente os Selecionados
        If a = vbYes Then
            Dim b As Int16
            b = MsgBox("Confirma a sobreposição de TODOS os dados de Estoque?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")
            'Se o usuário não confirmar sai da rotina
            If b = vbNo Then
                Exit Sub
            Else
                Me.Cursor = Cursors.WaitCursor
                msg("Inativando todos os lotes...")
                pbProgresso.Value = 20
                pbProgresso.Refresh()
                'Se confirmar o inventário completo, então aqui desabilita TODOS os lotes e exclui TODOS os frascos
                SQL = "UPDATE Lotes SET ativo=0"
                Try
                    ExecutaSQL(SQL)
                    'Elimina todos os frascos
                    msg("Excluindo dados anteriores dos frascos...")
                    SQL = "DELETE FROM aux_frascos"
                    ExecutaSQL(SQL)
                    pbProgresso.Value = 40
                    pbProgresso.Refresh()
                    'Atualiza o estoque
                    Atualiza_Estoque()
                Catch ex As Exception
                    MsgBox("Erro ao tentar desabilitar os lotes" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End Try
            End If
        ElseIf a = vbNo Then    'Se o usuário clicar em Não, ou seja, INVENTARIO PARCIAL
            'Se o usuário clicar direto em Não vem para cá 
            'Se for um inventário parcial então Reativa somente os lotes que estão selecionados
            'Tem que apagar os frascos somente dos lotes selecionados pois senão haverá sobreposição
            SQL = "DELETE FROM aux_frascos WHERE lote IN(SELECT DISTINCT lote FROM aux_inventario_lotes)"
            Try
                msg("Eliminando frascos dos lotes inventariados...")
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao eliminar os frascos dos lotes selecionados" & vbCrLf & ex.Message, MsgBoxStyle.Critical + vbOKOnly, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try
            Atualiza_Estoque()
        End If
        msg("Inventário de Estoque Concluído com Sucesso...")
        MsgBox("Inventário de Estoque Concluído com Sucesso!!!", MsgBoxStyle.Exclamation + vbOKOnly, "Aviso")
        pbProgresso.Value = 100
        Me.Cursor = Cursors.Arrow
    End Sub

    'Essa rotina atualiza os estoques com base na quantidade de mudas nos frascos
    Private Sub Atualiza_Estoque()
        Dim SQL As String, a As Int16
        'Primeira coisa antes de atualizar o estoque é copiar os frascos do inventário para a tabela principal
        Copia_Frascos()
        'Habilita os Lotes correspondentes ao frascos que estão no inventário.
        'Segunda parte, Faz no servidor o recálculo dos frascos
        SQL = "UPDATE lotes SET Ativo=1,Estoque=(SELECT SUM(nMudas) FROM aux_frascos WHERE lote=lotes.id),Est_frascos=(SELECT COUNT(id) FROM aux_frascos WHERE lote=lotes.id) WHERE id IN (SELECT DISTINCT lote FROM aux_inventario_lotes)"
        a = MsgBox("Tem certeza de que quer recalcular o estoque dos lotes baseando-se" & vbCrLf & "em seus frascos em estoque?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        If a = vbYes Then
            'Tenta executar a sql padrão
            Try
                msg("Recalculando estoque...")
                pbProgresso.Value = 80
                pbProgresso.Refresh()
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar recalcular o estoque dos frascos. Verifique o banco de dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    'Essa rotina transfere os frascos da tabela temporária de AUX_INVENTARIO_LOTES para a tabela oficial AUX_FRASCOS
    Private Sub Copia_Frascos()
        Dim SQL As String
        'Cria a SQL que faz a Cópia direta dos frascos de uma tabela para outra.
        SQL = "INSERT INTO aux_frascos (Lote,Vidro,NMudas,Impresso,Selecao) SELECT Lote,Vidro,nMudas,1,0 FROM aux_inventario_lotes"
        Try
            msg("Copiando frascos inventariados...")
            pbProgresso.Value = 60
            pbProgresso.Refresh()
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao copiar frascos da Tabela Inventário." & vbCrLf & ex.Message, MsgBoxStyle.Critical + vbOKOnly, "Erro")
            Exit Sub
        End Try
    End Sub
End Class