Imports MySql.Data.MySqlClient
Imports System.IO.Ports


Public Class frmEtiquetas

    Public Todas As Boolean, LoteID As Integer
    Friend WithEvents COMPort As New SerialPort

    Private Sub frmEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Verifica todas as mercadorias que existem
        Carrega_Lista(lstMercadoria, "Mercadoria_num", "id", "nome", False)
        Atualiza_Grid_Etiquetas()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Fecha o formulario
        Me.Close()
    End Sub

    Private Sub lstMercadoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMercadoria.SelectedIndexChanged
        'Verifica se não tem nada selecionado
        If lstMercadoria.SelectedItem.ToString = "-1" Then
            'Se não tem pega o lote 1 como padrão
            Carrega_Lista(lstLotes, "id_codigo", "id", "Codigo", True, "Mercadoria=01 and Ativo=1")
        Else
            'Senão pega o que está selecionado na lista
            Carrega_Lista(lstLotes, "id_codigo", "id", "Codigo", True, "Mercadoria=" & cmbVal(lstMercadoria) & " AND Ativo=1")
        End If

    End Sub

    'Reotina que atualiza o Datagrid das etiquetas
    Private Sub Atualiza_Grid_Etiquetas()
        Dim myData As New DataTable
        Dim SQL As String

        SQL = "SELECT * FROM etiquetas_prn ORDER BY Codigo"

        Try
            'Abre a conexao e atribui ao datagrid
            myData = SQLQuery(SQL)

            Try

                lblFrascos.Text = myData.Rows.Count.ToString

                With dgFrascos
                    'Atribui a fonte de dados aberta acima
                    .DataSource = myData
                    'Altura do cabecalho
                    .ColumnHeadersHeight = 10
                    'Largura da primeira coluna (travada)
                    .RowHeadersWidth = 20
                    'oculta a coluna do número sequencial
                    .Columns(0).Visible = False
                    'Se ajusta para que o conteudo da célula fique visível
                    .Columns(1).Width = 85
                    .Columns(2).Width = 65
                    .Columns(3).Width = 80
                    .Columns(4).Width = 45
                    .Columns(5).Width = 45
                    'Ajusta o alinhamento
                    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'Cabecalhos
                    .Columns(1).HeaderText = "Descrição"
                    .Columns(2).HeaderText = "Cód Barras"
                    .Columns(3).HeaderText = "Data"
                    .Columns(4).HeaderText = "Nº Mudas"
                    .Columns(5).HeaderText = "Nº Vidro"
                    'Altura da linha de título
                    .ColumnHeadersHeight = 15
                End With

            Catch myerror As MySqlException
                MsgBox("Houve um erro ao tentar obter os dados: " & myerror.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        Catch myerror As MySqlException
            MsgBox("Erro ao conectar o banco de dados: " & myerror.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub lstLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLotes.SelectedIndexChanged
        Dim Lote As Integer
        'Verifica se não tem nada selecionado
        If lstLotes.SelectedItem.ToString <> "-1" Then
            'Pega o lote atual selecionado
            Lote = cmbVal(lstLotes)
            'Somente se houver algo selecionado
            lstFrascos.Items.Clear()
            Carrega_Lista(lstFrascos, "lista_frascos", "vidro", "item", True, "Lote=" & Lote)
            LoteID = Lote
            lblLote.Text = "Lote: " & Procura_Lote(LoteID)
        End If
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
        SQL = "DELETE FROM etiquetas_prn"
        ExecutaSQL(SQL)
        Atualiza_Grid_Etiquetas()
    End Sub

    Private Sub btTransfere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTransfere.Click
        'Verifica se há frascos selecionados
        If lstFrascos.CheckedItems.Count <= 0 Then
            MsgBox("Não há frascos selecionados para transferir!", vbOKOnly + MsgBoxStyle.Information, "Erro")
            Exit Sub
        End If

        'Se houver seleção

        'Faz uma lista de todos os frascos marcados
        Dim Vidros As String = String.Empty, ct As Integer
        'Faz o looping com todos os itens selecionados para pegar os ID's dos Frascos
        ct = 1
        For Each Item As Object In lstFrascos.CheckedItems
            If ct = 1 Then
                Vidros &= Val(Item.ToString)
            Else
                Vidros &= "," & Val(Item.ToString)
            End If
            'Soma 1 no contador
            ct += 1
        Next

        'Pega o ID do Lote
        Dim m As ListBox.SelectedObjectCollection = lstLotes.SelectedItems
        'Pega o ítemData do ítem selecionado e usa como ID do Lote
        LoteID = m(0).valor

        'Libera a váriável
        m = Nothing

        'Dimensiona a variável
        Dim SQL As String = String.Empty, CodLote As String = String.Empty

        'Pega o código do lote completo
        CodLote = lblLote.Text.Substring(6, 12)

        'Transfere o trabalho da inclusão para o Servidor MYSQL
        SQL = "INSERT INTO `etiquetas_prn` (`Desc`,`Codigo`,`Data`,`nMudas`,`vidro`) SELECT '" & CodLote & "',LPAD(`aux_frascos`.`id`,13,0),date_format(`aux_frascos`.`Data`,'%d/%m/%Y'),`aux_frascos`.`NMudas`,`aux_frascos`.`Vidro` FROM `aux_frascos` WHERE (`aux_frascos`.`Lote`=" & LoteID & " AND `aux_frascos`.`Vidro` IN(" & Vidros & "))"


        'Verifica os ítens selecionados
        'ct = 1
        'Faz o looping com todos os itens selecionados
        'For Each Item As Object In lstFrascos.CheckedItems
        'Aqui tem que trocar pelo novo
        'Codigo = CodBase & Format(Val(Item.ToString), "000")
        'Codigo = ZerosEsquerda(DLookup("id", "Lista_Frascos", "Lote=" & LoteID & " AND Vidro=" & Val(Item.ToString)), 13)
        'nMudas = DLookup("nMudas", "Lista_Frascos", "Lote=" & LoteID & " AND Vidro=" & Val(Item.ToString))
        'Esse null teve que ser colocado porque o nome do campo é uma palavra restrita do MySQL
        'Parte = "(null,'" & Descricao & "','" & Codigo & "','" & Data & "','" & nMudas.ToString("000") & "'," & Val(Item.ToString) & ")"
        'If ct = 1 Then
        'Sql = SQL & Parte
        'Else
        'Sql = SQL & "," & Parte
        'End If
        'ct = ct + 1
        'Next Item

        Try
            ExecutaSQL(SQL)
            MsgBox(Format(ct - 1, "000") & " Etiquetas incluídas com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
            'Atualiza a exibição dos dados
            Atualiza_Grid_Etiquetas()
            'Limpa a seleção do listview (Usa a função do botão para isso)
            Button3_Click(sender, e)
        Catch ex As Exception
            MsgBox("Erro ao transferir etiquetas para área de impressão" & vbCrLf & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub msg(ByVal Texto As String)
        lblMsg.Text = Texto
        lblMsg.Refresh()
    End Sub

    Private Sub btImpSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpSel.Click
        Me.Cursor = Cursors.WaitCursor
        'Cria a tabela que conterá os dados das etiquetas
        Dim DT As DataTable
        'Define as variáveis
        Dim SQL As String, Num As Integer, Resto As Integer, NumReal As Integer
        Dim Cod_ESQ As String, Cod_DIR As String, Des_ESQ As String, Des_DIR As String, Dat_ESQ As String, Dat_DIR As String, mds_ESQ As String, mds_DIR As String, fra_ESQ As String, fra_DIR As String

        'SQL montará a seleçao de registros das etiquetas selecionada para impressão
        SQL = "SELECT * FROM etiquetas_prn ORDER BY codigo"

        'Define um DataTable para receber os dados
        DT = SQLQuery(SQL)

        msg("Reunindo etiquetas...")

        Try

            'Conta os registros que irão ser impressos
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
            msg("Abrindo porta Serial...")

            'Envia um comando para volta da etiqueta na porta serial
            'Função para ajustar posição da etiqueta
            'Envia o comando para dar um backfeed
            Volta_Etiqueta_Serial()

            'Define os parametros de comunicação
            Define_Porta_Serial()
            'Abre a porta serial
            Abre_Porta_Serial()

            'Inicializa as configurações de etiqueta
            msg("Enviando etiquetas para impressora...")
            'Faz o looping para imprimir todas as etiquetas selecionadas
            For i As Integer = 0 To Num - 1 Step 2
                'Atualiza barra de progresso
                Progress.Value = i
                'Garante a atualização visual da barra de progresso
                Progress.Refresh()
                With DT
                    'Monta o codigo de barras
                    Cod_ESQ = .Rows(i).Item("Codigo").ToString
                    'Monta a descrição
                    Des_ESQ = .Rows(i).Item("Desc").ToString
                    'Pega a data do lote
                    Dat_ESQ = .Rows(i).Item("Data").ToString
                    'Pega o Número de mudas do frasco
                    mds_ESQ = .Rows(i).Item("nMudas").ToString
                    'Pega o Numero do Frasco
                    fra_ESQ = .Rows(i).Item("vidro").ToString
                    'Se existir um próximo resultado
                    If i + 1 <= NumReal - 1 Then    'Compensar pois o array comeca em 0
                        'Monta o codigo de barras
                        Cod_DIR = .Rows(i + 1).Item("Codigo").ToString
                        'Monta a descrição
                        Des_DIR = .Rows(i + 1).Item("Desc").ToString
                        'Pega a data do lote
                        Dat_DIR = .Rows(i + 1).Item("Data").ToString
                        'Pega o número de mudas
                        mds_DIR = .Rows(i + 1).Item("nMudas").ToString
                        'Pega o número do frasco
                        fra_DIR = .Rows(i + 1).Item("vidro").ToString
                    Else
                        'Se não existir
                        Cod_DIR = "0000000000000"
                        Des_DIR = "000.000.0000"
                        Dat_DIR = "00/00/00"
                        mds_DIR = "000"
                        fra_DIR = "000"
                    End If
                    'Chama a funcao para imprimir a etiqueta
                    Envia_Etiqueta_Serial(Cod_ESQ, Des_ESQ, Dat_ESQ, mds_ESQ, fra_ESQ, Cod_DIR, Des_DIR, Dat_DIR, mds_DIR, fra_DIR)
                End With
            Next i
            'Fecha a porta serial de comunicação
            COMPort.Close()

        Catch ex As Exception
            MsgBox("Erro ao tentar imprimir as etiquetas:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            msg("...")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        'Zera a barra de progresso
        Progress.Value = 0
        'Limpa a selecao de etiquetas
        Limpa_Selecao()
        msg("...")
        Me.Cursor = Cursors.Arrow
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
        'Atualiza o datagrid para ver se nenhum computador agendou alguma etiqueta
        Atualiza_Grid_Etiquetas()
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

    Private Sub Envia_Etiqueta_Serial(ByVal Cod_Esq As String, ByVal Des_Esq As String, ByVal Dat_Esq As String, ByVal Mds_Esq As String, ByVal Fra_Esq As String, ByVal Cod_Dir As String, ByVal Des_Dir As String, ByVal Dat_Dir As String, ByVal Mds_Dir As String, ByVal Fra_Dir As String)

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
            '.WriteLine("PC")                            'Velocidade de Impressão A/B/C/D/E/F
            .WriteLine("D11")                           'Tamanho do Pixel
            .WriteLine("A2")

            'Agora começa a impressão da etiqueta propriamente dita
            'Etiqueta 01 (Esq)
            .WriteLine(String.Format("1e4202800370018C{0}&E{1}", Cod_Esq.Substring(0, 12), Cod_Esq.Substring(12, 1))) '1112223333444
            .WriteLine(String.Format("1911A0600260050{0}", Cod_Esq))
            .WriteLine("1911A0600810010Lote")
            .WriteLine(String.Format("1911A0800690010{0}", Des_Esq))
            .WriteLine("1911A0600100010Data:")
            .WriteLine(String.Format("1911A0800080033{0}", Dat_Esq))
            .WriteLine("1911A0600100097Mudas:")
            .WriteLine(String.Format("1911A0800080133{0}", Mds_Esq))
            .WriteLine("1911A0600830121Frasco")
            '.WriteLine(String.Format("1911A0800690126{0}", Cod_Esq.Substring(10, 3)))
            .WriteLine(String.Format("1911A0800690126{0}", Fra_Esq))

            'Etiqueta 02 (Dir)
            .WriteLine(String.Format("1e4202800370184C{0}&E{1}", Cod_Dir.Substring(0, 12), Cod_Dir.Substring(12, 1))) '1112223333444
            .WriteLine(String.Format("1911A0600260216{0}", Cod_Dir))
            .WriteLine("1911A0600810175Lote")
            .WriteLine(String.Format("1911A0800690175{0}", Des_Dir))
            .WriteLine("1911A0600100175Data:")
            .WriteLine(String.Format("1911A0800080198{0}", Dat_Dir))
            .WriteLine("1911A0600100263Mudas:")
            .WriteLine(String.Format("1911A0800080298{0}", Mds_Dir))
            .WriteLine("1911A0600830286Frasco")
            '.WriteLine(String.Format("1911A0800690292{0}", Cod_Dir.Substring(10, 3)))
            .WriteLine(String.Format("1911A0800690292{0}", Fra_Dir))

            'Finaliza a etiqueta
            .WriteLine("Q0001")
            .WriteLine("E")
        End With
    End Sub
    'Função que trata algo que foi recebido pela porta serial
    Private Sub Serial_data_recived(ByVal Sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles COMPort.DataReceived
        Console.Write(COMPort.ReadExisting.ToString)
    End Sub
End Class