Public Class frmMapa_Comercializacao

    Private Sub frmMapa_Comercializacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAno.Text = Now.Year
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Selecionar Todos os clones que serão resumidos no mapa
        Dim SQL As String = String.Empty

        'SQL de seleção dos clones que serão resumidos
        SQL = "SELECT `clones`.`RNC`,`clones`.`Mercadoria`,`clones`.`Clone`,`mercadoria`.`Cientifico`,`clones`.`Nome` FROM `Controle`.`clones` INNER JOIN `Controle`.`mercadoria` ON (`clones`.`Mercadoria` = `mercadoria`.`ID`) WHERE (`clones`.`Mapa_Com` =1)"

        'Limpa a tabela para começar a inclusão
        DsMapa_Com.dtComercializacao.Rows.Clear()
        'Cria uma tabela temporária
        Dim dtClones As DataTable
        'Tenta pegar os dados dos clones
        Try
            dtClones = SQLQuery(SQL)
        Catch ex As Exception
            MsgBox("Erro ao recuperar dados dos clones", MsgBoxStyle.Critical, vbOKOnly)
            Exit Sub
        End Try

        'Se deu certo vai povoar a tabela com os dados
        'Para cada linha vai fazer o resumo de todos os dados.
        For Each Linha As DataRow In dtClones.Rows
            With Linha
                'Try
                'Prepara as Variáveis
                Dim varRNC As String = NotNull(.Item("RNC"), "")
                Dim varCientifico As String = .Item("Cientifico")
                Dim varCultivar As String = .Item("Nome")
                Dim varPrevista As Integer = 0
                Dim varAprovada As Integer = 0
                Dim varComUF As Integer = 0
                Dim varComFora As Integer = 0
                Dim varComExpo As Integer = 0
                Dim varUso As Integer = 0
                Dim varDescarte As Integer = 0
                Dim varTerceiros As Integer = 0
                Dim varSaldo As Integer = 0

                'Calcula a VENDA FORA DO ESTADO
                Dim SQL_ComFora As String = String.Empty
                Dim varComForaResumo As String = String.Empty
                'Prepara a SQL que procura por cada estado
                SQL_ComFora = "SELECT `docs_itens`.`CodPro` AS mercadoria, `docs_itens`.`Clone` , SUM(`docs_itens`.`Quantidade`) AS Mudas, `docs`.`Estado` AS UF FROM `Controle`.`docs` INNER JOIN `Controle`.`docs_itens` ON (`docs`.`id` = `docs_itens`.`Doc_ID`) WHERE (YEAR(DATA) =" & txtAno.Text & ") AND `docs_itens`.`CodPro`=" & .Item("Mercadoria") & " AND `docs_itens`.`Clone`=" & .Item("Clone") & " AND `docs`.`Estado`<>'SC' GROUP BY `docs_itens`.`CodPro`, `docs_itens`.`Clone`, `docs`.`Estado`"
                Dim dtComFora As DataTable, numComFora As Integer = 0
                dtComFora = SQLQuery(SQL_ComFora)
                'Se encontrou alguma venda
                If dtComFora.Rows.Count > 0 Then
                    For Each lin As DataRow In dtComFora.Rows
                        varComForaResumo &= lin.Item("Mudas") & " (" & lin.Item("UF") & ")" & vbCr
                        numComFora += lin.Item("Mudas")
                    Next
                    varComFora = numComFora
                    dtComFora = Nothing
                End If

                'Calcula a VENDA DENTRO DO ESTADO
                Dim SQL_ComUF As String = String.Empty
                'Prepara a SQL que procura dentro do Estado
                SQL_ComUF = "SELECT `docs_itens`.`CodPro` AS mercadoria, `docs_itens`.`Clone` , SUM(`docs_itens`.`Quantidade`) AS Mudas, `docs`.`Estado` AS UF FROM `Controle`.`docs` INNER JOIN `Controle`.`docs_itens` ON (`docs`.`id` = `docs_itens`.`Doc_ID`) WHERE (YEAR(DATA) =" & txtAno.Text & ") AND `docs_itens`.`CodPro`=" & .Item("Mercadoria") & " AND `docs_itens`.`Clone`=" & .Item("Clone") & " AND `docs`.`Estado`='SC' GROUP BY `docs_itens`.`CodPro`, `docs_itens`.`Clone`, `docs`.`Estado`"
                Dim dtComUF As DataTable
                dtComUF = SQLQuery(SQL_ComUF)
                'Se encontrou alguma venda
                If dtComUF.Rows.Count > 0 Then
                    varComUF = dtComUF.Rows(0).Item("Mudas")
                    dtComUF = Nothing
                End If

                'Calcula as AUTORIZADAS e DESCARTE
                Dim SQL_Totais As String = String.Empty
                SQL_Totais = "SELECT SUM(contaminacao) AS Descarte, SUM(est_inicial) AS Aprovadas FROM lotes WHERE mercadoria=" & .Item("Mercadoria") & " AND clone=" & .Item("clone") & " AND YEAR(DATA)=" & txtAno.Text
                Dim dtTotais As DataTable
                dtTotais = SQLQuery(SQL_Totais)
                'Se encontrou algum registro
                If dtTotais.Rows.Count > 0 Then
                    If Not IsDBNull(dtTotais.Rows(0).Item("Aprovadas")) Then
                        varAprovada = dtTotais.Rows(0).Item("Aprovadas")
                    Else
                        varAprovada = 0
                    End If
                    If Not IsDBNull(dtTotais.Rows(0).Item("Descarte")) Then
                        varDescarte = dtTotais.Rows(0).Item("Descarte")
                    Else
                        varDescarte = 0
                    End If
                End If
                dtTotais = Nothing

                'Saldo é a Quantidade Produzida (APROVADA) menos o que foi Vendido, Consumido, ou Descartado
                varSaldo = varAprovada - varDescarte - varUso - varComUF - varComFora - varComExpo

                'Final, adiciona a linha no dataset
                'Campos do DataSet (RNC,Especie,Cultivar,Tipo,Classe,Prevista,Aprovada,ComUF,ComFora,ComExpo,Uso,Descarte,Terceiros,Saldo,ComForaResumo)
                DsMapa_Com.dtComercializacao.Rows.Add({varRNC, varCientifico, varCultivar, "Muda Aclimatizada", "1", varPrevista, varAprovada, varComUF, varComFora, varComExpo, varUso, varDescarte, varTerceiros, varSaldo, varComForaResumo})

                'Catch ex As Exception
                'MsgBox("Ocorreu um erro ao tentar recuperar os dados de produção" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                'Exit Sub
                'End Try

            End With
        Next

    End Sub

    Private Sub btExcel_Click(sender As Object, e As EventArgs) Handles btExcel.Click
        'Habilita cópia do gridview para o clipboard
        dgMapa.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Copia as células para o clipboard
        Clipboard.SetDataObject(dgMapa.GetClipboardContent())
    End Sub

    Private Sub dgMapa_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgMapa.ColumnWidthChanged
        'MsgBox(e.Column.Width)
    End Sub
End Class