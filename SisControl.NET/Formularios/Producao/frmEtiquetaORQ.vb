Imports MySql.Data.MySqlClient
Imports System.IO.Ports

Public Class frmEtiquetaORQ
    'Define a variável que será usada para a porta serial
    Friend WithEvents COMPort As New SerialPort

    Private Sub frmEtiquetaORQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista dos lotes
        Carrega_Lista(lstLotes, "Germinacao", "id", "cod", True, "Ativo=1")
        'Atualiza o Datagrid
        Atualiza_datagrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Fechar
        Me.Close()
    End Sub

    Private Sub lstLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotes.SelectedIndexChanged
        'Carrega na lista de frascos todos os frascos diponiveis no lote
        Carrega_Lista(lstFrascos, "lista_germinacao", "id", "item", True, "Lote=" & cmbVal(lstLotes))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer

        For i = 0 To lstFrascos.Items.Count - 1
            lstFrascos.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To lstFrascos.Items.Count - 1
            lstFrascos.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim a As Integer
        'Pede confirmação
        a = MsgBox("Confirma exclusão de todas as etiquetas selecionadas?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")
        'Se aceitar limpa senão sai
        If a = vbYes Then
            Limpa_Selecao()
        End If
    End Sub

    'Sub auxiliar para limpar a selecao
    Private Sub Limpa_Selecao()
        Dim SQL As String
        SQL = "DELETE FROM etiquetasorq_prn"
        ExecutaSQL(SQL)
        Atualiza_datagrid()
    End Sub

    Private Sub Atualiza_datagrid()
        Dim SQL As String
        SQL = "SELECT * FROM etiquetasORQ_prn ORDER BY CodBar"

        Try
            Dim DT As DataTable = SQLQuery(SQL)
            lblFrascos.Text = DT.Rows.Count.ToString("000")

            With dgFrascos
                'Atribui a fonte de dados aberta acima
                .DataSource = DT
                'Largura da primeira coluna (travada)
                .RowHeadersWidth = 20
                'oculta a coluna do número sequencial
                .Columns(0).Visible = False
                'Se ajusta para que o conteudo da célula fique visível
                '.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                'Cabecalhos
                .Columns(1).HeaderText = "Código"
                .Columns(2).HeaderText = "Colheita"
                .Columns(3).HeaderText = "Lote"
                .Columns(4).HeaderText = "Espécie"
                .Columns(5).HeaderText = "Cruza"
                .Columns(6).HeaderText = "Semeadura"
                .Columns(7).HeaderText = "Descrição"
                .Columns(8).HeaderText = "Repicagem"
                .Columns(9).HeaderText = "Frasco"
                .Columns(10).HeaderText = "Nº Mudas"

                'Larguras
                .Columns(1).Width = 50
                .Columns(2).Width = 70
                .Columns(3).Width = 35
                .Columns(4).Width = 70
                .Columns(5).Width = 70
                .Columns(6).Width = 70
                .Columns(7).Width = 80
                .Columns(8).Width = 70
                .Columns(9).Width = 40
                .Columns(10).Width = 40
                'Altura da linha de título
                .ColumnHeadersHeight = 15
            End With

        Catch myerror As MySqlException
            MsgBox("Houve um erro ao tentar obter os dados: " & myerror.Message)
        End Try
        
    End Sub

    Private Sub btTransfere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTransfere.Click
        'Dimensiona as variáveis
        Dim SQL As String, Parte As String
        Dim ct As Integer, varID As Integer, DT As DataTable, DR As DataRow
        'Variáveis especificas (mais organizado)
        Dim varLote As String
        Dim varEspecie As String
        Dim varDescri As String
        Dim varDataP As String
        Dim varDataC As String
        Dim varDataS As String
        Dim varDataR As String
        Dim varCodBar As Integer
        Dim varFrasco As String
        Dim varTemp As String
        Dim varNMudas As String

        'Obtem as informacoes no banco de dados
        varID = cmbVal(lstLotes)
        'Monta a SQL
        SQL = "SELECT Cod,Especie,Descricao,Polinizacao,Colheita,Semeadura FROM Germinacao WHERE id=" & varID
        'Debug
        Console.WriteLine(Me.Name & ": " & SQL)
        Try
            'Obtem no banco de dados os dados referentes ao lote
            DT = SQLQuery(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar obter informações sobre o lote" & vbCrLf & ex.Message & vbCrLf & ex.ToString)
            Exit Sub
        End Try

        'Fetch na linha
        DR = DT.Rows(0)

        'Verifica os dados comuns a todos os frascos
        'Dados em comum para todos os lotes
        varLote = DR("Cod")
        varEspecie = NaoNulo(DR("Especie"))
        varDescri = NaoNulo(DR("Descricao"))

        'Verifica se a data da polinizaçao é nula
        If IsDBNull(DR("Polinizacao")) = True Then
            varDataP = "Null"
        Else
            varDataP = "'" & Format(CDate(DR("Polinizacao")), "yyyy-MM-dd") & "'"
        End If
        'Verifica a data da Colheita
        If IsDBNull(DR("Colheita")) = True Then
            varDataC = "Null"
        Else
            varDataC = "'" & Format(CDate(DR("Colheita")), "yyyy-MM-dd") & "'"
        End If
        If IsDBNull(DR("Semeadura")) = True Then
            varDataS = "Null"
        Else
            varDataS = "'" & Format(CDate(DR("Semeadura")), "yyyy-MM-dd") & "'"
        End If

        'Monta a SQL padrão
        SQL = "INSERT INTO etiquetasorq_prn VALUES "

        'Verifica os ítens selecionados
        ct = 1
        'Faz o looping com todos os itens selecionados
        For Each Item As Object In lstFrascos.CheckedItems
            'Informações especificas de cada frasco
            varCodBar = Item.Valor()
            varFrasco = Format(Val(Item.ToString), "000")
            varTemp = DLookup("Repicagem", "aux_germinacao", "id=" & varCodBar)
            varNMudas = DLookup("Nmudas", "aux_germinacao", "id=" & varCodBar)
            If IsDBNull(varTemp) Then
                varDataR = "Null"
            Else
                varDataR = "'" & Format(CDate(varTemp), "yyyy-MM-dd") & "'"
            End If

            'Ese null teve que ser colocado porqe o nome do campo é uma palavra restrita do MySQL
            Parte = "(null,'" & Format(Val(varCodBar), "0000000") & "'," & varDataC & ",'" & varLote & "','" & varEspecie & "'," & varDataP & "," & varDataS & ",'" & varDescri & "'," & varDataR & ",'" & varFrasco & "','" & varNMudas & "')"
            If ct = 1 Then
                SQL = SQL & Parte
            Else
                SQL = SQL & "," & Parte
            End If
            ct = ct + 1
        Next Item

        'Executa a SQL montada
        If ExecutaSQL(SQL) Then
            MsgBox(Format(ct - 1, "000") & " Etiquetas incluídas com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
            'Atualiza a exibição dos dados
            Atualiza_datagrid()
        End If

    End Sub

    Private Sub btImpSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpSel.Click
        'Dimensiona as variaveis da conexao sql
        'Dim conn As New MySqlConnection
        'Dim Command As New MySqlCommand
        'Dim Adapter As New MySqlDataAdapter
        Dim DT As DataTable
        'Dim DR As MySqlDataReader
        'Dim DS As New DataSet
        Dim SQL As String, Num As Integer, Resto As Integer, NumReal As Integer

        'Junta os frascos para poder setar como impressos
        Dim ListaFrascos As String = String.Empty

        'Variaveis especificas para etiquetas
        Dim E_varCodBar As String
        Dim E_varDataH As String
        Dim E_varDataLote As String
        Dim E_varEspecie As String
        Dim E_varDataC As String
        Dim E_varDataS As String
        Dim E_varDesc As String
        Dim E_varDataR As String
        Dim E_varFrasco As String
        Dim E_varNMudas As String
        Dim D_varCodBar As String
        Dim D_varDataH As String
        Dim D_varDataLote As String
        Dim D_varEspecie As String
        Dim D_varDataC As String
        Dim D_varDataS As String
        Dim D_varDesc As String
        Dim D_varDataR As String
        Dim D_varFrasco As String
        Dim D_varNMudas As String

        'SQL montará a seleçao de registros das etiquetas selecionada para impressão
        SQL = "SELECT * FROM etiquetasorq_prn ORDER BY CodBar"

        DT = SQLQuery(SQL)

        Try
            'Coleta o número de registros
            Num = DT.Rows.Count
            NumReal = Num

            'Atualiza a barra de progresso (max min e atual)
            Progress.Minimum = 0
            Progress.Maximum = Num
            Progress.Value = 0
            'Verifica se é par ou impar o número de dados
            Resto = Num Mod 2
            'Se for impar soma 1 para ficar par
            If Resto = 1 Then
                Num = Num + 1
            End If
            'Função para ajustar posição da etiqueta
            Volta_Etiqueta_Serial()

            'Função que faz as definições da porta serial
            Define_Porta_Serial()
            'Abre a porta para comunicação
            Abre_Porta_Serial()

            For i As Integer = 0 To Num - 1 Step 2
                'Atualiza barra de progresso
                Progress.Value = i
                'Garante que será mostrado à medida que acontece
                Progress.Refresh()
                With DT.Rows(i)

                    'Armazena os frascos que estão sendo impressos
                    If ListaFrascos.Length > 0 Then
                        ListaFrascos &= "," & .Item("Codbar")
                    Else
                        ListaFrascos &= .Item("Codbar")
                    End If

                    'Monta a Etiqueta da Esquerda
                    E_varCodBar = Format(Val(.Item("Codbar")), "0000000")
                    'Retirar o Efeito de nulo
                    If IsDBNull(.Item("DataH")) Then
                        E_varDataH = ""
                    Else
                        E_varDataH = Format(CDate(.Item("DataH").ToString), "dd/MM/yy")
                    End If
                    'E_varDataLote = Format(Val(.Item("Lote")), "0000")
                    E_varDataLote = .Item("Lote")
                    E_varEspecie = .Item("Especie").ToString
                    'Retirar o Efeito de nulo
                    If IsDBNull(.Item("DataC")) Then
                        E_varDataC = ""
                    Else
                        E_varDataC = Format(CDate(.Item("DataC").ToString), "dd/MM/yy")
                    End If
                    'Retirar o Efeito de nulo
                    If IsDBNull(.Item("DataS")) Then
                        E_varDataS = ""
                    Else
                        E_varDataS = Format(CDate(.Item("DataS").ToString), "dd/MM/yy")
                    End If
                    'Para não passar por cima das datas na etiqueta
                    If .Item("Descricao").ToString.Length > 17 Then
                        E_varDesc = .Item("Descricao").ToString.Substring(0, 17)
                    Else
                        E_varDesc = .Item("Descricao").ToString
                    End If
                    'Retirar o Efeito de nulo
                    If IsDBNull(.Item("DataR")) Then
                        E_varDataR = ""
                    Else
                        E_varDataR = Format(CDate(.Item("DataR").ToString), "dd/MM/yy")
                    End If
                    E_varFrasco = Format(Val(.Item("Frasco").ToString), "000")
                    'Se for Zero, imprime que é frasco de semente
                    If Val(.Item("NMudas").ToString) = 0 Then
                        E_varNMudas = "SEM"
                    Else
                        E_varNMudas = Format(Val(.Item("NMudas").ToString), "000")
                    End If

                End With
                'Se existir um próximo resultado
                If i + 1 <= NumReal - 1 Then    'Compensar pois o array comeca em 0
                    'Le o proximo resultado
                    With DT.Rows(i + 1)

                        'Armazena os frascos que estão sendo impressos
                        If ListaFrascos.Length > 0 Then
                            ListaFrascos &= "," & .Item("Codbar")
                        Else
                            ListaFrascos &= .Item("Codbar")
                        End If

                        'Monta a Etiqueta da Direita
                        D_varCodBar = Format(Val(.Item("Codbar").ToString), "0000000")
                        'Retirar o Efeito de nulo
                        If IsDBNull(.Item("DataH")) Then
                            D_varDataH = ""
                        Else
                            D_varDataH = Format(CDate(.Item("DataH").ToString), "dd/MM/yy")
                        End If
                        'D_varDataLote = Format(Val(.Item("Lote")), "0000")
                        D_varDataLote = .Item("Lote")
                        D_varEspecie = .Item("Especie").ToString
                        'Retirar o Efeito de nulo
                        If IsDBNull(.Item("DataC")) Then
                            D_varDataC = ""
                        Else
                            D_varDataC = Format(CDate(.Item("DataC").ToString), "dd/MM/yy")
                        End If
                        'Retirar o Efeito de nulo
                        If IsDBNull(.Item("DataS")) Then
                            D_varDataS = ""
                        Else
                            D_varDataS = Format(CDate(.Item("DataS").ToString), "dd/MM/yy")
                        End If
                        'Para não passar por cima das datas na etiqueta
                        If .Item("Descricao").ToString.Length > 17 Then
                            D_varDesc = .Item("Descricao").ToString.Substring(0, 17)
                        Else
                            D_varDesc = .Item("Descricao").ToString
                        End If
                        'Retirar o Efeito de nulo
                        If IsDBNull(.Item("DataR")) Then
                            D_varDataR = ""
                        Else
                            D_varDataR = Format(CDate(.Item("DataR").ToString), "dd/MM/yy")
                        End If
                        D_varFrasco = Format(Val(.Item("Frasco").ToString), "000")
                        'Se for Zero, imprime que é frasco de semente
                        If Val(.Item("NMudas").ToString) = 0 Then
                            D_varNMudas = "SEM"
                        Else
                            D_varNMudas = Format(Val(.Item("NMudas").ToString), "000")
                        End If
                    End With
                Else
                    'Se não existir
                    D_varCodBar = "0000000"
                    D_varDataH = "00/00/00"
                    D_varDataLote = "------"
                    D_varEspecie = "----------"
                    D_varDataC = "00/00/00"
                    D_varDataS = "00/00/00"
                    D_varDesc = "----------"
                    D_varDataR = "00/00/00"
                    D_varFrasco = "000"
                    D_varNMudas = "000"
                End If
                'Chama a funcao para imprimir a etiqueta
                Envia_Etiqueta_Serial(E_varCodBar, E_varDataH, E_varDataLote, E_varEspecie, E_varDataC, E_varDataS, E_varDesc, E_varDataR, E_varFrasco, E_varNMudas, D_varCodBar, D_varDataH, D_varDataLote, D_varEspecie, D_varDataC, D_varDataS, D_varDesc, D_varDataR, D_varFrasco, D_varNMudas)
            Next i
        Catch ex As Exception
            MsgBox("Erro ao tentar imprimir as etiquetas:" & Chr(13) & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            Exit Sub
        End Try

        'Atualiza os frascos como impressos ou não
        SQL = "UPDATE aux_germinacao SET Impresso=1 WHERE id in(" & ListaFrascos & ")"
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar marcar os frascos como impressos!" & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        'Zera a barra de progresso
        Progress.Value = 0
        'Limpa a selecao de etiquetas
        Limpa_Selecao()
        'Fecha a porta serial
        Fecha_Porta_Serial()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim i As Integer
        'Verifica cada item para ver se contem a string de que não foi impresso
        For i = 0 To lstFrascos.Items.Count - 1
            If lstFrascos.Items(i).ToString.Contains("Não") Then
                lstFrascos.SetItemChecked(i, True)
            End If
        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Atualiza_datagrid()
    End Sub

    Private Sub Define_Porta_Serial()
        'Faz o SetUp de comunicação
        With COMPort
            .PortName = My.Settings.MyPrintPort
            .BaudRate = Int(My.Settings.MyBaud)
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
        End With
    End Sub

    Private Sub Abre_Porta_Serial()
        'Abre a porta
        COMPort.Close()
        COMPort.Open()
    End Sub

    Private Sub Fecha_Porta_Serial()
        'Se a porta serial estiver Aberta então fecha
        If COMPort.IsOpen Then
            COMPort.Close()
        End If
    End Sub

    Private Sub Volta_Etiqueta_Serial()
        Define_Porta_Serial()
        Abre_Porta_Serial()
        COMPort.WriteLine(Chr(2) & "f320")
        Fecha_Porta_Serial()
    End Sub

    Private Sub Envia_Etiqueta_Serial(ByVal E_varCodBar As String, ByVal E_varDataH As String, ByVal E_varDataLote As String, ByVal E_varEspecie As String, ByVal E_varDataC As String, ByVal E_varDataS As String, ByVal E_varDesc As String, ByVal E_varDataR As String, ByVal E_varFrasco As String, ByVal E_varNMudas As String, ByVal D_varCodBar As String, ByVal D_varDataH As String, ByVal D_varDataLote As String, ByVal D_varEspecie As String, ByVal D_varDataC As String, ByVal D_varDataS As String, ByVal D_varDesc As String, ByVal D_varDataR As String, ByVal D_varFrasco As String, ByVal D_varNmudas As String)
        'Usando o objeto Público que maneja a serial
        With COMPort
            'Comandos de inicialização da Impressão
            .WriteLine(Chr(2) & "n")                    'Unidade de medida em polegadas
            .WriteLine(Chr(2) & "M0500")                'Comprimento máximo 6 polegadas
            '.WriteLine(Chr(2) & "KI503")                'Intervalo de etiqueta de 03 mm
            .WriteLine(Chr(2) & "O0220")                'Posição inicial da impressora
            .WriteLine(Chr(2) & "V0")
            .WriteLine(Chr(2) & "f320")                 'BackFeed antes de começar
            .WriteLine(Chr(2) & "e")                    'Ativa o sensor de GAP de etiquetas
            .WriteLine(Chr(2) & "j")                    'Elimina a paisa entre etiquetas
            .WriteLine(Chr(2) & "L")                    'Manda padrão da etiqueta (Formato)
            .WriteLine("H" & Trim(My.Settings.MyTemp))  'Define a temperatura de impressão
            .WriteLine("D11")                           'Tamanho do Pixel
            .WriteLine("A2")

            'Etiqueta 01 (Equerda)
            .WriteLine(String.Format("1e4201900480009C{0}&E{1}", E_varCodBar.Substring(0, 6), E_varCodBar.Substring(6, 1)))
            .WriteLine(String.Format("1911A0600370039{0}", E_varCodBar))
            .WriteLine("1911A0600850010Lote")
            .WriteLine(String.Format("1911A0800700010{0}", E_varDataLote))
            .WriteLine(String.Format("1911A0600230006{0}", E_varEspecie))
            .WriteLine("1911A0600850067Mudas")
            .WriteLine("1911A0600850123Frasco")
            .WriteLine(String.Format("1911A0800700128{0}", E_varFrasco))
            .WriteLine(String.Format("1911A0800700070{0}", E_varNMudas))
            .WriteLine(String.Format("1911A0600130006{0}", E_varDesc))
            .WriteLine("101100000350125Repicagem")
            .WriteLine(String.Format("1911A0600230120{0}", E_varDataR))
            .WriteLine("101100000190085Colheita")
            .WriteLine(String.Format("1911A0600090083{0}", E_varDataH))
            .WriteLine("101100000190125Semeadura")
            .WriteLine(String.Format("1911A0600240083{0}", E_varDataC))
            .WriteLine("101100000350082Polinizacao")
            .WriteLine(String.Format("1911A0600090120{0}", E_varDataS))

            'Etiqueta 02 (Equerda)
            .WriteLine(String.Format("1e4201900480175C{0}&E{1}", D_varCodBar.Substring(0, 6), D_varCodBar.Substring(6, 1)))
            .WriteLine(String.Format("1911A0600370204{0}", D_varCodBar))
            .WriteLine("1911A0600850175Lote")
            .WriteLine(String.Format("1911A0800700175{0}", D_varDataLote))
            .WriteLine(String.Format("1911A0600230171{0}", D_varEspecie))
            .WriteLine("1911A0600850233Mudas")
            .WriteLine("1911A0600850288Frasco")
            .WriteLine(String.Format("1911A0800700294{0}", D_varFrasco))
            .WriteLine(String.Format("1911A0800700236{0}", D_varNmudas))
            .WriteLine(String.Format("1911A0600130171{0}", D_varDesc))
            .WriteLine("101100000350290Repicagem")
            .WriteLine(String.Format("1911A0600230285{0}", D_varDataR))
            .WriteLine("101100000190250Colheita")
            .WriteLine(String.Format("1911A0600090248{0}", D_varDataH))
            .WriteLine("101100000190290Semeadura")
            .WriteLine(String.Format("1911A0600240248{0}", D_varDataC))
            .WriteLine("101100000350247Polinizacao")
            .WriteLine(String.Format("1911A0600090285{0}", D_varDataS))

            'Finaliza a etiqueta
            .WriteLine("Q0001")
            .WriteLine("E")
        End With
    End Sub
End Class
