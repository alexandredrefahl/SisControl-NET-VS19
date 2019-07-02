Imports System.IO.Ports

Public Class frmEtiquetasBDJ

    Friend WithEvents COMPort As New SerialPort

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmEtiquetasBDJ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Verifica todas as mercadorias que existem
        Carrega_Lista(lstMercadoria, "Mercadoria_num", "id", "nome", False)

        'Carrega as etiquetas
        Atualiza_Grid()
    End Sub

    Private Sub lstMercadoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMercadoria.SelectedIndexChanged
        'Carrega lista com os lotes de plantio que estão disponíveis para aquela mercadoria
        'Ainda tem que criar uma mandeira de selecionar o clone
        Carrega_Lista(lstLotes, "Plantio_Data", "id", "Descricao", True, "Mercadoria=" & cmbVal(lstMercadoria) & " AND Ativo=1")
    End Sub

    Private Sub lstLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotes.SelectedIndexChanged
        'Informa qual é o plantio selecionado
        lblLote.Text = "Plantio: " & StrZero(cmbVal(lstLotes), 4)

        'Carrega a lista de bandejas pertencentes à este lote
        Carrega_Lista(lstFrascos, "lista_Bandejas", "id", "Descricao", True, "plantio=" & cmbVal(lstLotes))
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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim i As Integer
        For i = 0 To lstFrascos.Items.Count - 1
            If lstFrascos.Items(i).ToString.Contains("Não") Then
                lstFrascos.SetItemChecked(i, True)
            End If
        Next
    End Sub

    Private Sub btTransfere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTransfere.Click
        'Corre a lista e preenche as bandejas selecionadas
        'Dimensiona as variáveis
        Dim Lista As String = String.Empty, SQL_Base As String
        Dim ct As Integer = 0, varTipo As String, varID As Integer, varMerc As String, varData As String, varCodigo As String

        Dim Item As Object

        If lstFrascos.CheckedItems.Count <= 0 Then
            MsgBox("Não há bandejas selecionadas para transferência!", MsgBoxStyle.Exclamation, "Verificação")
            Exit Sub
        End If

        SQL_Base = "INSERT Bandejas_prn (id_bandeja,Tipo,Mercadoria,Data) VALUES "

        'Cria um DataRow para pesquisar todas as bandejas 
        Dim DR As DataRow

        'Pega a lista de todos os selecionados
        For Each Item In lstFrascos.CheckedItems
            varID = CType(Item, MeuItemData).Valor
            'Código
            varCodigo = Int16.Parse(varID).ToString("000000")
            'Pesquisa a linha
            DR = DLookupRow("aux_bandejas", "id=" & varCodigo)
            'Mercadoria
            varMerc = Int16.Parse(DR("Mercadoria")).ToString("000")
            varMerc &= "." & Int16.Parse(DR("clone")).ToString("0000")
            'Tipo
            varTipo = DR("Tipo")
            varData = Format(CDate(DR("Data")), "dd/MM/yy")
            'Se for a segunda vez que passa aqui já poe virgula na SQL
            If ct > 0 Then
                SQL_Base &= ","
                Lista &= ","
            End If
            'Monta a lista dos IDs para tornar impresso
            Lista &= varID
            'Vai montando a SQL
            SQL_Base &= "(" & varCodigo & "," & varTipo & ",'" & varMerc & "','" & varData & "')"
            'Conta quandos itens já dforam adicionados
            ct += 1
        Next

        'Tenta fazer a inclusão
        Try
            'Executa a SQL montada
            If ExecutaSQL(SQL_Base) Then
                MsgBox(Format(ct, "000") & " Etiquetas incluídas com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                'Atualiza a exibição dos dados
                Atualiza_Grid()
                'Atualiza a informação de impressos nas bandejas
                SQL_Base = "UPDATE aux_bandejas SET Impresso=1 WHERE id IN (" & Lista & ")"
                ExecutaSQL(SQL_Base)
                'Recarrega a lista de bandejas pertencentes à este lote
                Carrega_Lista(lstFrascos, "lista_Bandejas", "id", "Descricao", True, "plantio=" & cmbVal(lstLotes))
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir as etiquetas das bandejas!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub Atualiza_Grid()
        'Faz a atualização do grid com os dados das banejas selecionadas
        Dim DT As DataTable = Nothing, SQL As String = String.Empty

        'SQL = "SELECT id,LPAD(id_bandeja, 6, '0') as id_bandeja,Mercadoria,Tipo,Data FROM Bandejas_PRN ORDER BY Mercadoria"
        SQL = "SELECT id,CAST(LPAD(id_bandeja, 6, '0') AS CHAR) AS id_bandeja,Mercadoria,Tipo,DATA FROM Bandejas_PRN ORDER BY Mercadoria"

        Try
            'Tenta carregar os dados da SQL
            DT = SQLQuery(SQL)
            'Atribui a SQL à datagrid
            dgFrascos.DataSource = DT

            'Formata o datagrid para ficar visível
            lblFrascos.Text = dgFrascos.Rows.Count

            With dgFrascos
                'Atribui a fonte de dados aberta acima
                .DataSource = DT
                'Altura do cabecalho
                .ColumnHeadersHeight = 15
                'Largura da primeira coluna (travada)
                .RowHeadersWidth = 20
                'oculta a coluna do número sequencial
                .Columns(0).Visible = False
                'Se ajusta para que o conteudo da célula fique visível
                .Columns(1).Width = 68
                .Columns(2).Width = 65
                .Columns(3).Width = 50
                .Columns(4).Width = 75
                'Cabecalhos
                .Columns(1).HeaderText = "Cód Bar"
                .Columns(2).HeaderText = "Mercadoria"
                .Columns(3).HeaderText = "Tipo"
                .Columns(4).HeaderText = "Data"
                'Formatos 
            End With
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar a tabela com as informações das bandejas" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
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
        SQL = "DELETE FROM Bandejas_prn"
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir etiquetas selecionadas", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        Atualiza_Grid()
    End Sub

    Private Sub btImpSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpSel.Click

        '*
        '* NESTA FUNCAO DIFERENTE DAS DEMAIS OPTEI POR IMPRIMIR DIRETO DO DATAGRID
        '* SEM FICAR FAZENDO ACESSOS AO BANCO DE DADOS
        '*
        Dim num As Integer, Resto As Int16, NumReal As Integer
        Dim E_Cod As String, E_Mer As String, E_Tip As String, E_Dat As String, D_Cod As String, D_Mer As String, D_Tip As String, D_Dat As String
        'conta quantas etiquetas serão impressas
        num = dgFrascos.RowCount
        NumReal = num

        Me.Cursor = Cursors.WaitCursor

        'Atualiza a barra de progresso (max min e atual)
        Progress.Minimum = 0
        Progress.Maximum = num
        Progress.Value = 0

        'Verifica se é par ou impar o número de dados
        Resto = num Mod 2
        'Se for impar soma 1 para ficar par
        If Resto = 1 Then
            num = num + 1
        End If

        Define_Porta_Serial()

        Abre_Porta_Serial()

        'Começa impressão
        For i As Integer = 0 To num - 1 Step 2
            'Atualiza barra de progresso
            Progress.Value = i
            'Atualiza a barra de progresso
            Progress.Refresh()

            '*** Monta a etiqueta da esquerda

            With dgFrascos.Rows(i)
                'Monta o codigo de barras
                E_Cod = StrZero(.Cells(1).Value, 5)
                'Mercadoria
                E_Mer = .Cells(2).Value
                'Tipo
                E_Tip = .Cells(3).Value
                'Data
                E_Dat = .Cells(4).Value
            End With
            'Se existir um próximo resultado
            If i + 1 <= NumReal - 1 Then    'Compensar pois o array comeca em 0
                'Le o proximo resultado
                'Monta o codigo de barras
                With dgFrascos.Rows(i + 1)
                    D_Cod = StrZero(.Cells(1).Value, 5)
                    'Mercadoria
                    D_Mer = .Cells(2).Value
                    'Tipo
                    D_Tip = .Cells(3).Value
                    'Data
                    D_Dat = .Cells(4).Value
                End With
            Else
                'Se não existir
                D_Cod = "00000"
                D_Mer = "000.0000"
                D_Tip = "000"
                D_Dat = "00/00/00"
            End If

            'Chama a funcao para imprimir a etiqueta
            Envia_Etiqueta_Serial(E_Cod, E_Mer, E_Dat, E_Tip, D_Cod, D_Mer, D_Dat, D_Tip)
        Next
        'Fecha o arquivo da impressora
        Fecha_Porta_Serial()
        'Elimina todas as etiquetas da fila de impressão
        Limpa_Selecao()
        'Limpa a barra de progresso
        Progress.Value = 0
        Progress.Refresh()
        'Retorna o cursor
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgFrascos_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgFrascos.DataError
        Console.WriteLine(e.ColumnIndex & "," & e.RowIndex & " - " & e.Exception.Message)
        Console.WriteLine(e.Exception.ToString)
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
        COMPort.WriteLine(Chr(2) & "f320")
    End Sub

    Public Sub Envia_Etiqueta_Serial(ByVal E_CodBar As String, ByVal E_Mercad As String, ByVal E_Data As String, ByVal E_Tipo As String, ByVal D_CodBar As String, ByVal D_Mercad As String, ByVal D_Data As String, ByVal D_Tipo As String)
        With COMPort

            .WriteLine(Chr(2) & "c0000")
            .WriteLine(Chr(2) & "KI502")
            .WriteLine(Chr(2) & "O0220")
            .WriteLine(Chr(2) & "f220")
            .WriteLine(Chr(2) & "KW0307")
            .WriteLine(Chr(2) & "KI7")
            .WriteLine(Chr(2) & "V0")
            .WriteLine(Chr(2) & "L")
            .WriteLine("H11")
            .WriteLine("PE")
            .WriteLine("A2")
            .WriteLine("D11")

            '** Esquerda

            .WriteLine("1D4201300150018" & E_CodBar)
            .WriteLine("191100400160085" & E_Mercad)
            .WriteLine("191100100030109" & E_Data)
            .WriteLine("191100000030021Tipo: " & E_Tipo)

            '** Direita

            .WriteLine("1D4201300150168" & D_CodBar)
            .WriteLine("191100400160235" & D_Mercad)
            .WriteLine("191100100030259" & D_Data)
            .WriteLine("191100000030171Tipo: " & D_Tipo)

            'Finaliza as etiquetas

            .WriteLine("^02")
            .WriteLine("Q0001")
            .WriteLine("E")

        End With
    End Sub
End Class