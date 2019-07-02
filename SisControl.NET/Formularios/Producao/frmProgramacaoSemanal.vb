Imports MySql.Data.MySqlClient

Public Class frmProgramacaoSemanal

    Dim ProgID As Integer

    Private Sub frmProgramacaoSemanal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub cmbProduto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProduto.SelectedIndexChanged
        'Se não houver produto selecionado
        If cmbProduto.SelectedIndex = -1 Then
            Exit Sub
        End If
        'Carrega os clones assim que a caixa de produtos for alterada
        Carrega_Lista(cmbClone, "clones_num", "id", "nome", True, "Mercadoria=" & cmbVal(cmbProduto))
        cmbClone.Items.Add(New MeuItemData("9999", "XXXX - Todos"))
    End Sub

    Private Sub cmbClone_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClone.SelectedIndexChanged
        'Se houver algum clone selecionado
        If cmbClone.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cmbVal(cmbClone) = "9999" Then
            Exit Sub
        End If

        'não precisa procurar os lotes de origem se não for repicagem
        If rdPlantio.Checked Or rdGeral.Checked Then
            Exit Sub
        End If

        'Cria uma conexao temporaria para criar um TableAdapter
        Dim myConn As New MySqlConnection, SQL As String
        myConn.ConnectionString = MY_SQL_CONNECTION
        'Cria um Table Adapter
        SQL = "SELECT Codigo as colCodigo,Fase as colFase,Est_Frascos as colEstoque,Repicagem as colDataRep,Data as colData,Vencido as colVencido FROM lotes_vencidos WHERE Mercadoria=" & cmbVal(cmbProduto) & " AND Clone=" & cmbClone.Text.Substring(0, 4) & " ORDER BY Vencido DESC ,Codigo"
        Console.WriteLine("SQL: " & SQL)
        Dim myTa As New MySqlDataAdapter(SQL, myConn)
        'Se o table adapter tiver funcional
        If Not IsNothing(myTa) Then
            'Limpa o DataSet Primeiro
            dsLotesVencidos.Tables.Clear()
            ' Preenche o DataSet com os novos valores
            myTa.Fill(dsLotesVencidos)
            'Nomeia a tabela
            dsLotesVencidos.Tables(0).TableName = "LotesV"
            'Atribui ao datagrig
            'dgProducao.DataSource = dsLotesVencidos.Tables(0)
        End If
    End Sub

    Private Sub Recalcula()

        'Se a opção TODOS estiver selecionada
        If cmbVal(cmbClone) = "9999" And txtQtdeMudas.Text > 0 And txtQtdeMudas.Text <> "" And txtM_F.Text > 0 And txtM_F.Text <> "" Then
            txtQtdeMeio.Text = txtQtdeMudas.Text / txtM_F.Text / 50
            Exit Sub
        End If

        'Se estiver tudo selecionado
        If txtQtdeMudas.Text > 0 And txtQtdeMudas.Text <> "" And txtM_F.Text > 0 And txtM_F.Text <> "" And cmbProduto.SelectedIndex > -1 And cmbClone.SelectedIndex > -1 And cmbFase.SelectedIndex > -1 Then
            'Quantidade de mudas / Num de mudas por frasco / 50 frascos em 1 litro
            txtQtdeMeio.Text = txtQtdeMudas.Text / txtM_F.Text / 50
            'Busca o meio de cultura
            Dim meio As Integer = -1
            Select Case cmbFase.Text
                Case "Isolamento"

                    meio = DLookup("MeioISO", "Mercadoria", "id=" & cmbVal(cmbProduto))
                Case "Multiplicação"
                    meio = DLookup("MeioMUL", "Mercadoria", "id=" & cmbVal(cmbProduto))
                Case "Alongamento"
                    meio = DLookup("MeioALO", "Mercadoria", "id=" & cmbVal(cmbProduto))
                Case "Enraizamento"
                    meio = DLookup("MeioENR", "Mercadoria", "id=" & cmbVal(cmbProduto))
                Case "Manutenção"
                    meio = DLookup("MeioMAN", "Mercadoria", "id=" & cmbVal(cmbProduto))
            End Select
            'Se localizou alguma coisa
            If meio <> -1 Then
                'Localiza o ítem cujo id é o que foi localizado
                Localiza_Item(cmbMeios, meio)
            End If
            'Calcula o próximo lote
            Dim MaxLote As Integer = -1
            MaxLote = DMax("lote", "Lotes", "Mercadoria=" & cmbVal(cmbProduto) & " AND Clone=" & cmbClone.Text.Substring(0, 4))
            'Se retornou algo
            If MaxLote > -1 And Not IsDBNull(MaxLote) Then
                'Calcula o próximo lote da sequencia
                txtProximoLote.Text = Format(cmbVal(cmbProduto), "000") & "." & Format(MaxLote + 1, "000") & "." & cmbClone.Text.Substring(0, 4)
            End If
        End If
    End Sub

    Private Sub txtQtdeMudas_Leave(sender As System.Object, e As System.EventArgs) Handles txtQtdeMudas.Leave
        Recalcula()
    End Sub

    Private Sub cmbFase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFase.SelectedIndexChanged
        Recalcula()
    End Sub

    Private Sub txtM_F_Leave(sender As System.Object, e As System.EventArgs) Handles txtM_F.Leave
        Recalcula()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'Monta a SQL da Inclusão ou de Alteração
        Dim SQL As String = "", varOrigem As String = String.Empty

        If Button1.Text = "Incluir" Then
            'SQL geral
            SQL = "INSERT INTO programacao SET "
        ElseIf Button1.Text = "Salvar" Then
            'SQL geral
            SQL = "UPDATE programacao SET "
        End If
        

        'Muda para cada tipo

        'Repicagem
        If rdRepicagem.Checked Then
            varOrigem = lista_lotes()
            SQL &= "Tipo='R',"
            SQL &= "Data='" & Format(txtData.Value, "yyyy-MM-dd") & "',"
            SQL &= "Mercadoria=" & cmbVal(cmbProduto) & ","
            SQL &= "Clone='" & cmbClone.Text.Substring(0, 4) & "',"
            SQL &= "Mudas=" & txtQtdeMudas.Text & ","
            SQL &= "Fase=" & cmbVal(cmbFase) & ","
            SQL &= "Mds_Frasco=" & txtM_F.Text & ","
            SQL &= "Meio=" & cmbVal(cmbMeios) & ","
            SQL &= "Meio_Desc='" & cmbMeios.Text & "',"
            SQL &= "Meio_Qtde=" & Numero_to_SQL(txtQtdeMeio.Text) & ","
            SQL &= "Meio_S_L='" & IIf(rdLiquido.Checked, "L", "S") & "'" & ","
            SQL &= "Observacao='" & txtObs.Text & "',"
            SQL &= "Codigo='" & txtProximoLote.Text & "',"
            SQL &= "Origem='" & varOrigem & "',"
            SQL &= "Frasco='" & cmbFrasco.Text & "'"
        End If
        'Plantio
        If rdPlantio.Checked Then
            SQL &= "Tipo='P',"
            SQL &= "Data='" & Format(txtData.Value, "yyyy-MM-dd") & "',"
            SQL &= "Mercadoria=" & cmbVal(cmbProduto) & ","
            SQL &= "Clone='" & cmbClone.Text.Substring(0, 4) & "',"
            SQL &= "Mudas=" & txtQtdeMudas.Text & ","
            SQL &= "Fase=" & cmbVal(cmbFase) & ","
            SQL &= "Observacao='" & txtObs.Text & "'"
        End If
        'Geral
        If rdGeral.Checked Then
            SQL &= "Tipo='G',"
            SQL &= "Data='" & Format(txtData.Value, "yyyy-MM-dd") & "',"
            SQL &= "Observacao='" & txtObs.Text & "'"
        End If

        Dim Mensagem As String = String.Empty
        'Acrescenta o identificador par que não altere todos os registros.
        If Button1.Text = "Salvar" Then
            SQL &= " WHERE id=" & Int(lblID.Text)
            Mensagem = "Alteração da Ordem de Produção nº: " & lblID.Text & " realizada com sucesso"
        ElseIf Button1.Text = "Incluir" Then
            Mensagem = "Inclusão da Ordem de Produção no dia " & txtData.Value.Date & " realizada com sucesso"
        End If

        Try
            Console.WriteLine("Progamação: " & SQL)
            'Tenta executar a inclusão
            ExecutaSQL(SQL)
            'Se der certo envia a mensagem conforme o tipo de operação (definidas acima)
            MsgBox(Mensagem, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")
            'Limpa para próxima inclusão
            Limpa_Campos(Me)
            dsLotesVencidos.Clear()
            txtProximoLote.Text = "000.000.0000"
            rdSolido.Checked = True
            rdRepicagem.Checked = True
            cmbFrasco.Text = "Frasco de Vidro"
            Button1.Text = "Incluir"
            lblID.Text = ""
            lblID.Visible = False
            txtData.Focus()
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir programação" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdGeral.CheckedChanged
        Muda_Tipo()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdPlantio.CheckedChanged
        Muda_Tipo()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdRepicagem.CheckedChanged
        Muda_Tipo()
    End Sub

    Private Sub Muda_Tipo()
        Dim Nomes() As String
        'Se for uma ordem de repicagem
        If rdRepicagem.Checked Then
            Nomes = {"Nulo"}
            Desabilita_Campos(Me, Nomes)
        End If
        'Se for uma ordem de plantio
        If rdPlantio.Checked Then
            Nomes = {"txtM_F", "grpLotesOrigem", "txtQtdeMeio", "cmbMeios", "rdSolido", "rdLiquido", "txtProximoLote", "dgProducao"}
            Desabilita_Campos(Me, Nomes)
        End If
        'Se for uma ordem Geral (limpeza, arrumação etc...)
        If rdGeral.Checked Then
            Nomes = {"cmbProduto", "cmbClone", "txtQtdeMudas", "cmbFase", "txtM_F", "grpLotesOrigem", "txtQtdeMeio", "cmbMeios", "rdSolido", "rdLiquido", "txtProximoLote", "dgProducao"}
            Desabilita_Campos(Me, Nomes)
        End If
    End Sub

    Private Function lista_lotes() As String
        Dim ret As String = String.Empty
        If dgProducao.SelectedRows.Count > 0 Then
            'Percorre todas as linhas selecionadas
            For i As Integer = 0 To dgProducao.SelectedRows.Count - 1
                If i > 0 Then
                    ret &= "/"
                End If
                ret &= dgProducao.SelectedRows(i).Cells(0).Value
            Next
        End If
        'Se não tiver nada selecionado volta uma string vazia
        Return ret
    End Function

    Public Sub New(Optional ByVal ID As Integer = -1)

        ' This call is required by the designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()

        'Atualiza a Data
        txtData.Value = Date.Now
        'Carrega os combos
        Carrega_Lista(cmbProduto, "mercadoria_num", "id", "Nome", True)
        'Carrega a lista dos meios
        Carrega_Lista(cmbMeios, "Meio", "id", "meio", True)
        'Carrega lista das fases
        Carrega_Lista(cmbFase, "Fases", "id", "Fase", True)

        'Se foi passado algum parametro então carrega os dados
        If ID <> -1 Then
            ProgID = ID
            Carrega_Programacao()
        End If
    End Sub

    Private Sub Carrega_Programacao()
        Dim DR As DataRow

        lblID.Visible = True
        lblID.Text = ProgID.ToString("0000000")
        Button1.Text = "Salvar"

        Try
            DR = DLookupRow("Programacao", "id=" & ProgID)
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar a Ordem de Produção núm " & ProgID & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        'Não é possível carregar a programação ou ela não existe mais
        If IsNothing(DR) Or IsDBNull(DR) Then
            Exit Sub
        End If

        With DR
            'Primeiro carrega os check box baseado no DR
            Select Case .Item("Tipo")
                Case "R"
                    rdRepicagem.Checked = True
                    'Carrega a programação completa

                Case "P"
                    'Plantio carrega somente alguns ítens
                    rdPlantio.Checked = True
                Case "G"
                    'Geral carrega somente observações
                    rdGeral.Checked = True
            End Select
            '*
            '* 1ª ETAPA - Verifica as informações que são comuns aos três tipos
            '*
            '* Data; Observações
            '*

            'Observações
            txtObs.Text = .Item("Observacao")
            'Data
            txtData.Text = .Item("Data")

            'Se for uma ordem Geral, já sai aqui
            If rdGeral.Checked = True Then
                Exit Sub
            End If

            '*
            '* 2ª ETAPA - Verifica o que é tem também no plantio
            '*
            '* Mercadoria; Clone; Quantidade; Fase;
            '*

            'Define o produto a ser Trabalhado
            Localiza_Item(cmbProduto, .Item("Mercadoria"))
            cmbProduto.Refresh()
            'Localiza e define o clone
            Localiza_Item(cmbClone, .Item("Clone"))
            cmbClone.Text = .Item("Clone")
            cmbClone.Refresh()
            'Quantidade
            txtQtdeMudas.Text = .Item("Mudas")
            'Fase
            Localiza_Item(cmbFase, .Item("Fase"))

            'Se for uma ordem de plantio já sai aqui e não termina de carregar o resto
            If rdPlantio.Checked Then
                Exit Sub
            End If

            '*
            '* 3ª ETAPA - Se é uma ordem de Repicagem termina de carregar todo o resto
            '*
            '* Mds/Frasco; Codigo; Quantidade; Tipo meio;
            '*

            'Mudas por frasco
            txtM_F.Text = .Item("Mds_frasco")
            'Codigo do novo lote
            txtProximoLote.Text = .Item("Codigo")
            'Quantidade de Meio
            txtQtdeMeio.Text = .Item("Meio_Qtde")
            'Tipo de meio
            Localiza_Item(cmbMeios, .Item("Meio"))
            cmbMeios.Refresh()
            'Sólido ou líquido
            If .Item("Meio_S_L") = "S" Then
                rdSolido.Checked = True
            Else
                rdLiquido.Checked = True
            End If
            cmbFrasco.Text = .Item("Frasco") 
        End With

    End Sub

End Class