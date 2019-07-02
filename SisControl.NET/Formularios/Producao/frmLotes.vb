Imports MySql.Data.MySqlClient


Public Class frmLotes

    Dim Old_Color As New System.Drawing.Color, varRepicador As String
    Private MyCON As New MySql.Data.MySqlClient.MySqlConnection(MY_SQL_CONNECTION)
    Private MyADA As MySql.Data.MySqlClient.MySqlDataAdapter
    Private dsDados As New DataSet
    Private dtDados As New DataTable

    'Define os comandos
    Friend WithEvents cmdUpdate As New MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents cmdDelete As New MySql.Data.MySqlClient.MySqlCommand

    'Variavel global que guarda o n do lote
    Private LoteID As Integer
    'flag de impressão
    Private ImpFLAG As Boolean = False
    'Variável que recebe a ordem de Produção caso seja informada
    Dim Ordem_Producao As Integer = -1

    Public Sub New(Optional ByVal Ordem As Integer = -1)

        ' Essa Chamada é necessária pelo sistema.
        InitializeComponent()

        'Se recebeu alguma ordem de produção como parâmetro então atribui
        If Ordem > -1 Then
            Ordem_Producao = Ordem
        End If
    End Sub

    Private Sub Atualiza_Grid_Frascos(ByVal ID As String)
        Try
            'Renova o DataSet
            taFrascos.Fill(DsFrascos.aux_frascos)
            'Limpa o filtro
            bsFrascos.RemoveFilter()
            'aplica o novo filtro
            bsFrascos.Filter = "lote=" & ID
            'atualiza o grid dos frascos
            dgFrascos.Refresh()
            'Formata o grid com as colunas
            dgFrascos.RowHeadersWidth = 15
            'Id (0) e Lote (1) são escondidos, e não aparecem no grid
            dgFrascos.Columns(0).Visible = False
            dgFrascos.Columns(1).Visible = False
            dgFrascos.Columns(2).HeaderText = "Vidro"
            dgFrascos.Columns(2).Width = 40
            dgFrascos.Columns(3).HeaderText = "Nº Mudas"
            dgFrascos.Columns(3).Width = 30
            dgFrascos.Columns(4).Visible = False
            dgFrascos.Columns(5).Visible = False
            'MyCON.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Erro inesperado ao abrir a base de dados !" & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro nº " & ex.Number)
            'MyCON.Close()
        End Try
    End Sub

    Private Sub frmLotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub frmLotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Mercadorias
        Carrega_Lista(cmbMercadoria, "Mercadoria_num", "id", "Nome", True)
        'Repicadores
        Carrega_Lista(lstRepicador, "Repicador", "id", "Nome", True, "Ativo=1")
        'Fases de Reprodução
        Carrega_Lista(cmbFase, "Fases", "id", "Fase")
        'Meios de Cultura
        Carrega_Lista(cmbMeio, "Meio", "id", "meio", True)
        'dgFrascos.DataSource = bsFrascos
        Atualiza_Grid_Frascos("0")
        tbFrascos.Enabled = False

        'Verifica se recebeu como parâmetro alguma ordem de produção então já inicia o Preenchimento
        If Ordem_Producao > -1 Then
            Carrega_Ordem()
        End If

        'move o foco para o codigo
        txtCodigo.Focus()
    End Sub

    Public Sub Carrega_Info_Lote(ByVal LoteID As Integer)

    End Sub

    Private Sub Carrega_Ordem()
        Me.Cursor = Cursors.WaitCursor
        Dim DR As DataRow
        'Pega os dados da Ordem de Produção e Preenche na ficha
        DR = DLookupRow("programacao", "id=" & Ordem_Producao)

        'Se não achou nada e DR está vazio sai da rotina
        If IsDBNull(DR) Or IsNothing(DR) Then
            MsgBox("Não foi possível localizar a Ordem de Produção Nº: " & Ordem_Producao, MsgBoxStyle.Critical + vbOKOnly, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'Muda a cor de fundo dos dados que devem ser preenchidos
        Dim cor As System.Drawing.Color
        cor = Color.Khaki

        cmbOrigem.BackColor = cor
        txtNOrigem.BackColor = cor
        txtNFrascos.BackColor = cor
        txtTempo.BackColor = cor
        txtData.BackColor = cor
        txtEstIni.BackColor = cor
        cmbExplante.BackColor = cor
        txtDias.BackColor = cor
        lstRepicador.BackColor = cor

        cmbFrasco.Text = "Frasco de Vidro"
        '*** Preenche o formulário com os dados pré cadastrados da Ordem de Produção
        txtCodigo.Text = DR("Codigo")
        Verifica_Num_Lote(False)  'Não avisa, simplesmente corrige o número do lote
        Localiza_Item(cmbFase, DR("Fase"))
        Localiza_Item(cmbMeio, DR("Meio"))
        txtM_F.Text = DR("Mds_frasco")
        cmbExplante.Text = "Plântula"
        txtDias.Text = "45"
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.LostFocus
        Verifica_Num_Lote(True)
    End Sub

    Private Sub Verifica_Num_Lote(ByVal Aviso As Boolean)
        Dim Cod As String, nLote As Integer
        'Se houver algo digitado
        If Len(txtCodigo.Text) Then

            'Verifica se tem duas posições com ponto
            If (txtCodigo.Text.Length < 5) Or (txtCodigo.Text.IndexOf(".") = -1) Or (txtCodigo.Text.LastIndexOf(".") = -1) Or (txtCodigo.Text.LastIndexOf(".") = txtCodigo.Text.Length) Then
                MsgBox("Formato do código digitado de forma incorreta. Usar o formato 99.999.9999", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If

            'Declara as variaveis
            Dim Partes() As String
            'Divide a string em partes no "."
            Partes = txtCodigo.Text.Split(".")
            'Parte0=Mercadoria
            'Localiza o item na combo box
            Localiza_Item(cmbMercadoria, Partes(0))
            'Parte1=Codlote
            txtLote.Text = Partes(1)
            'Parte2=Clone
            txtClone.Text = Partes(2)
            'Procura se já existe o lote
            Cod = DLookup("id", "lotes", "mercadoria=" & Partes(0) & " and lote=" & Partes(1) & " and clone=" & Partes(2) & " and ativo=1")
            If Cod <> "" Then
                nLote = DMax("lote", "Lotes", "mercadoria=" & Partes(0) & " AND Clone=" & Partes(2) & " AND ativo=1")
                If Aviso Then
                    MsgBox("Já existe um lote ativo com este código!" & vbCrLf & "Lote: " & Cod & vbCrLf & "Próximo lote: " & nLote + 1, MsgBoxStyle.Exclamation, "Aviso")
                End If
                txtCodigo.Text = Partes(0) & "." & nLote + 1 & "." & Partes(2)
                txtLote.Text = nLote + 1
                txtCodigo.Focus()
                Exit Sub
            End If
            'Povoar o combo origem com os lotes disponíveis
            Carrega_Lista(cmbOrigem, "id_codigo", "id", "Codigo", True, "Mercadoria=" & Partes(0) & " AND Clone=" & Partes(2) & " AND Ativo=1")
            'Move o foco para o combo origem
            cmbOrigem.Focus()
        End If
    End Sub

    Private Sub txtM_F_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_F.Enter
        txtM_F.SelectAll()
    End Sub


    Private Sub txtM_F_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_F.LostFocus
        'Se o número de frascos foi preenchido
        If Len(txtNFrascos.Text) And Val(txtNFrascos.Text) > 0 Then
            If Len(txtM_F.Text) And Val(txtM_F.Text) > 0 Then
                'Calcula o número estimado de mudas
                txtEstIni.Text = (Val(txtNFrascos.Text) * Val(txtM_F.Text)).ToString
                'O Estoque inicial vai ser esse mesmo numero
                txtEstoque.Text = txtEstIni.Text
                'O estoque em frascos é o mesmo número de frascos
                txtEstFrascos.Text = txtNFrascos.Text
            End If
        End If
    End Sub

    Private Sub txtEstIni_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstIni.Enter
        txtEstIni.SelectAll()
    End Sub

    Private Sub txtEstoque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstIni.GotFocus
        'Salva a cor anterior
        Old_Color = txtEstIni.BackColor
        'Faz o fundo ficar vermelho para conferir o valor
        txtEstIni.BackColor = Color.DarkSalmon

    End Sub

    Private Sub txtEstoque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstIni.LostFocus
        'restaura a cor anterior
        txtEstIni.BackColor = Old_Color
        'Se foi alterado já arruma no estoque inicial também
        txtEstoque.Text = txtEstIni.Text
    End Sub

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Dim a As Integer
        'Se já existir um lote digitado
        If Len(txtCodigo.Text) > 0 Then
            'Que não teve as etiquetas impressas
            If ImpFLAG = False Then
                a = MsgBox("As etiquetas deste lote ainda não foram impressas." & Chr(13) & "Imprimir agora?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmação")
                If a = vbYes Then
                    'Manda executar a rotina de incluir as etiquetas, o Sender e o "e" são os mesmos!
                    btImpEtiquetas_Click(sender, e)
                End If
            End If
        End If
        'Fecha o formulário
        Me.Close()
    End Sub


    Private Sub lstRepicador_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRepicador.LostFocus
        varRepicador = valRepicador(lstRepicador)
    End Sub


    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        Dim SQL As String, Resp As Integer

        If Not Validacao() Then
            MsgBox("Verifique os erros no preenchimento do formulário.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        'Se ele tiver como botão "Novo"
        If btIncluir.Text = "Novo" Then
            'Verifica se os dados ficam ou não
            Resp = MsgBox("Deseja manter os dados do lote atual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            'Se desejar limpar tudo
            If Resp = vbNo Then
                'Aciona o click no botão novo
                btNovo_Click(sender, e)
                'Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0
                'Move o foco para o campo do código
                txtCodigo.Focus()
                GoTo finaliza
            Else    'Se os dados ficam
                'Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0
                txtCodigo.Text = String.Empty
                cmbOrigem.Items.Clear()
                cmbMercadoria.Text = String.Empty
                txtClone.Text = String.Empty
                txtLote.Text = String.Empty
                txtNOrigem.Text = "0"
                txtNFrascos.Text = "0"
                txtTempo.Text = String.Empty
                'Move o foco para a primeira aba
                tabLotes.SelectedIndex = 0
                'Move o foco para o campo do código
                txtCodigo.Focus()
                GoTo finaliza
            End If
Finaliza:
            'Volta o label do botão para incluir
            btIncluir.Text = "Incluir"
            'Apaga a mensagem de etiquetas impressas
            lblEtiquetas.Text = String.Empty
            'Sai da sub e não realiza a inclusão
            Exit Sub
        End If

        SQL = "INSERT INTO Lotes (id,Mercadoria,Lote,Clone,Origem,Numero_Origem,Frascos,Mudas_frasco,Tempo,Repicador,Fase,Meio,Data,Est_Inicial,Estoque,Est_Frascos,Anotacoes,Ativo,Frasco,Explante,dias,Mark,Local,criacao) VALUES (" & _
        "NULL," & cmbVal(cmbMercadoria) & "," & txtLote.Text & "," & txtClone.Text & "," & cmbVal(cmbOrigem) & _
        "," & txtNOrigem.Text & "," & txtNFrascos.Text & "," & txtM_F.Text & ",'" & txtTempo.Text.ToString & "'," & Texto_Vazio(varRepicador) & "," & cmbVal(cmbFase) & "," & cmbVal(cmbMeio) & ",'" & Format(CDate(txtData.Text), "yyyy-MM-dd") & _
        "'," & txtEstIni.Text & "," & txtEstoque.Text & "," & txtEstFrascos.Text & ",'" & txtAnotacoes.Text & "'," & chkAtivo.Checked & ",'" & cmbFrasco.Text & "','" & cmbExplante.Text & "'," & txtDias.Text & ",0,1,CURRENT_TIMESTAMP)"

        Try
            'Tenta executar a consulta sql
            Resp = ExecutaSQL(SQL)
            If Resp Then
                'Pega o ID do ultimo lote
                LoteID = DMax("id", "Lotes")
                MsgBox("Dados gravados com sucesso!" & vbCrLf & "ID do novo Lote: " & LoteID, vbOKCancel + vbInformation, "Aviso")

                'Se esse lote veio de uma ordem de produção então dá baixa da Ordem de Produção também
                If Ordem_Producao <> -1 Then
                    ExecutaSQL("UPDATE Programacao SET DataBaixa='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "' WHERE id=" & Ordem_Producao)
                End If

                'Habilita segunda aba
                'move para segunda Aba (index baseado em 0) 
                tbFrascos.Enabled = True
                tabLotes.SelectedIndex = 1
                'Desabilita o botão de incluir para não fazer a inclusão 2 vezes
                btIncluir.Enabled = False
                'Limpa o Grid de Frascos
                Atualiza_Grid_Frascos(LoteID.ToString)
                'Foco no botão 2 - Incluir etiquetas
                Button2.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        grpInclusao.Visible = True
        If txtNFrascos.Text = 1 Then     'Muda para o modo de adicao unica
            'muda para o modo de adição unico
            opFrascos2.Checked = True
            opFrascos_Click(1)
            txtFrascoINI.Text = 0
            txtFrascosQuebra.Text = txtEstoque.Text
        Else
            'muda para o modo de adição multiplo
            opFrascos1.Checked = True
            opFrascos_Click(1)
            'Iguala os campos chave que serão utilizados
            txtFrascoINI.Text = 0
            txtFrascosTOTAL.Text = txtNFrascos.Text
            txtFrascosM_F.Text = txtM_F.Text
            'Calcula o numero de mudas no frasco de quebra
            txtFrascosQuebra.Text = Val(txtM_F.Text) - ((Val(txtM_F.Text) * Val(txtNFrascos.Text)) - Val(txtEstIni.Text))
        End If
        btIncluiFrascos.Focus()
    End Sub


    Private Sub opFrascos_Click(ByVal Index As Integer)
        'Opção de vário
        If opFrascos1.Checked = True Then
            txtFrascosTOTAL.Enabled = True
            txtFrascoINI.Enabled = True
            txtFrascosM_F.Enabled = True
            txtFrascosQuebra.Enabled = True
            lblFrascoINI.Text = "Frasco Inicial:"
            grpInclusao.Text = "Nº Mudas no Frasco Quebra:"
            Label24.Enabled = True
            Label25.Enabled = True
            'Opcao de único
        ElseIf opFrascos2.Checked = True Then
            txtFrascosTOTAL.Enabled = False
            txtFrascoINI.Enabled = True
            lblFrascoINI.Text = "Nº do Frasco:"
            txtFrascosM_F.Enabled = False
            txtFrascosQuebra.Enabled = True
            grpInclusao.Text = "Nº de Mudas no Frasco:"
            Label24.Enabled = False
            Label25.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        grpInclusao.Visible = False
    End Sub

    Private Sub btIncluiFrascos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluiFrascos.Click
        'Dimensiona as variáveis
        Dim a As Object, SQL As String, i As Single, n As Integer
        'Pede confirmação
        a = MsgBox("Os dados estão conferidos?" + Chr(13) + "Deseja continuar?", vbYesNo + vbQuestion, "Confirmação")

        'Se a resposta for SIM
        If a = vbYes Then

            'Monta a SQL base para inclusão
            SQL = "INSERT INTO aux_frascos (id,Lote,Vidro,NMudas,Impresso,Selecao) VALUES "

            'se a opção vários está selecionada
            If opFrascos1.Checked = True Then
                'tem que descontar o frasco de quebra também
                n = Val((txtFrascosTOTAL.Text)) - 2
                'Faz o looping para inclusão
                For i = 0 To n
                    'quando for a segunda vez que passa aqui, coloca a virgula
                    If i > 0 Then
                        SQL = SQL & ","
                    End If
                    'Substitui pelo SQL
                    SQL = SQL & "(null," & LoteID & "," & Val(txtFrascoINI.Text) + i & "," & txtFrascosM_F.Text & ",0,0)"
                Next i

                'insere um vidro avulso que é o da quebra
                SQL = SQL & ",(null," & LoteID & "," & Val(txtFrascoINI.Text) + i & "," & txtFrascosQuebra.Text & ",0,0)"
                'Executa a SQL de inclusão
                ExecutaSQL(SQL)

                'Se a opcao unico esta selecionada
            ElseIf opFrascos2.Checked = True Then
                'Faz a inclusão unica
                SQL = SQL & "(null," & LoteID & "," & Val(txtFrascoINI.Text) & "," & txtFrascosQuebra.Text & ",0,0)"
                'Executa a SQL de inclusão
                ExecutaSQL(SQL)
            End If
            'atualiza o recordset
            Atualiza_Grid_Frascos(LoteID.ToString)
            'Desliga a exibição da inclusão
            grpInclusao.Visible = False
            'Habilita o botão de inclusão e troca o label dele
            btIncluir.Enabled = True
            btIncluir.Text = "Novo"
            'Move o foco para o botaõ de impressão de etiquetas
            btImpEtiquetas.Focus()
        End If

    End Sub

    Private Sub btImpEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpEtiquetas.Click
        'Dimensiona as variáveis
        Dim Data As String, Descricao As String, SQL As String, CodBase As String, Mercadoria As String
        Dim ct As Integer

        'Veriica se existem etiquetas para imprimir
        If dgFrascos.RowCount <= 0 Then
            MsgBox("Não existem frascos cadastrados ainda!" & vbCrLf & "Favor Cadastrar depois solicitar a impressão!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            'move o foco para o botão 2
            Button2.Focus()
            Exit Sub
        End If

        'Obtem as informacoes no formulário de inclusão
        Data = Format(CDate(txtData.Text), "dd/MM/yy")
        Mercadoria = Format(CInt(cmbVal(cmbMercadoria)), "000")
        'mota a descrição baseado nos campos do formulário
        Descricao = Mercadoria & "." & Format(CInt(txtLote.Text), "000") & "." & Format(CInt(txtClone.Text), "0000")
        'Monta o codigo base desmontando o código do lote
        CodBase = Mercadoria & Format(CInt(txtLote.Text), "000") & Format(CInt(txtClone.Text), "0000")

        'Monta a SQL padrão
        SQL = "INSERT INTO etiquetas_prn VALUES "
        Try
            'Faz o looping com todos as etiquetas deste lote(datagrid)
            For ct = 0 To dgFrascos.RowCount - 1
                'Se for a segunda vez que passa aqui poe uma virgula
                If ct > 0 Then
                    SQL = SQL & ","
                End If
                'Vai montando a SQL
                SQL = SQL & "(null,'" & Descricao & "','" & CodBase & Format(CInt(dgFrascos.Rows(ct).Cells(2).Value), "000") & "','" & Data & "','" & Format(CInt(dgFrascos.Rows(ct).Cells(3).Value), "000") & "')"
            Next ct
        Catch ex As Exception
            MsgBox("Erro na geração das etiquetas!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        'Tenta Executar a SQL montada
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao enviar as etiquetas para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            Exit Sub
        End Try
        'Se deu tudo certo vai adiante
        MsgBox(Format(ct, "000") & " Etiquetas enviadas para impressão!", MsgBoxStyle.OkOnly, "Confirmação")
        'Marca todas as etiquetas desta lote como impressas
        lblEtiquetas.Text = "Etiquetas impressas"

        Try
            SQL = "UPDATE aux_frascos SET Impresso=1 WHERE Lote=" & LoteID
            'Tenta marcar os frascos
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao marcar as etiquetas como impressas!" & Chr(13) & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            Exit Sub
        End Try
        'Só para DEBUG
        Console.WriteLine(Me.Name & ": " & SQL)
        'Informa que as etiquetas foram impressas com sucesso
        ImpFLAG = True
        'Habilita o botão de incluir novo registro
        btIncluir.Text = "Novo"
        btIncluir.Enabled = True
    End Sub

    Private Sub btNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovo.Click
        Dim a As Integer
        'Se já existir um lote digitado
        'Que não teve as etiquetas impressas
        If ImpFLAG = False Then
            a = MsgBox("As etiquetas deste lote ainda não foram impressas." & Chr(13) & "Imprimir agora?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmação")
            If a = vbYes Then
                'Manda executar a rotina de incluir as etiquetas, o Sender e o "e" são os mesmos!
                btImpEtiquetas_Click(sender, e)
                GoTo Novo
            End If
            'Se os lotes já tiverem sido impressos
            GoTo Novo
        End If

Novo:
        'Limpa os campos
        txtCodigo.Text = String.Empty
        cmbMercadoria.Text = String.Empty
        txtLote.Text = String.Empty
        txtClone.Text = String.Empty
        cmbOrigem.Items.Clear()
        txtNOrigem.Text = "0"
        txtNFrascos.Text = "0"
        txtM_F.Text = "0"
        txtTempo.Text = String.Empty
        cmbFase.Text = String.Empty
        cmbMeio.Text = String.Empty
        txtData.Text = String.Empty
        txtEstIni.Text = "0"
        txtEstoque.Text = "0"
        txtEstFrascos.Text = "0"
        cmbFrasco.SelectedIndex = -1
        cmbExplante.SelectedIndex = -1
        txtDias.Text = "0"
        txtAnotacoes.Text = String.Empty

        'Limpa a seleção dos repicadores
        lstRepicador.ClearSelected()
        'Limpa o grid frascos
        Atualiza_Grid_Frascos("0")
        'Habilita o botão de incluir
        btIncluir.Enabled = True
        btIncluir.Text = "Incluir"
        tabLotes.SelectedIndex = 0
        'Move o foco para o campo código
        txtCodigo.Focus()
    End Sub

    Private Sub txtAnotacoes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAnotacoes.LostFocus
        'Move o foco para o botão incluir
        btIncluir.Focus()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Apaga somenteo o mínio para continuar incluindo com a ficha atual
        txtCodigo.Text = String.Empty
        txtNOrigem.Text = 0
        txtNFrascos.Text = 0
        txtTempo.Text = String.Empty
        cmbOrigem.Text = String.Empty
        'Move o foco
        txtCodigo.Focus()
    End Sub

    Private Sub txtNOrigem_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNOrigem.Enter
        txtNOrigem.SelectAll()
    End Sub

    Private Sub txtNFrascos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNFrascos.Enter
        txtNFrascos.SelectAll()
    End Sub

    Private Sub txtTempo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTempo.Enter
        txtTempo.SelectAll()
    End Sub

    Private Sub txtData_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtData.Enter
        txtData.SelectAll()
    End Sub

    Private Sub txtDias_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDias.Enter
        txtDias.SelectAll()
    End Sub

    Private Sub txtEstFrascos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstFrascos.Enter
        txtEstFrascos.SelectAll()
    End Sub

    Private Sub txtEstoque_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstoque.Enter
        txtEstoque.SelectAll()
    End Sub

    Private Sub txtLote_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLote.Enter
        txtLote.SelectAll()
    End Sub

    Private Sub dgFrascos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFrascos.CellEndEdit
        'Célula começou a ser modificada, habilita o botão de salvar
        btSalvar.Enabled = True
    End Sub

    Private Sub DefineComandos()
        Dim myCMB As New MySql.Data.MySqlClient.MySqlCommandBuilder(MyADA)
        MyADA.UpdateCommand = myCMB.GetUpdateCommand()
        'Console.WriteLine(myCMB.GetUpdateCommand.CommandText)
        'MsgBox(MyADA.UpdateCommand.Parameters.Count.ToString)
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        'Executa o método update definido na Sub DefineComandos()
        Try
            bsFrascos.EndEdit()
            taFrascos.Update(DsFrascos.aux_frascos)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar a tabela de Frascos!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try

    End Sub

    Private Sub cmbOrigem_Leave(sender As System.Object, e As System.EventArgs) Handles cmbOrigem.Leave
        'Faz a verificação se o lote de orígem está preenchido  

        'Se estiver prreenchido é obrigado a ter escolhido um lote de orígem
        If cmbOrigem.Text.Length > 0 Then
            'Verifica se foi escolhido
            If cmbOrigem.SelectedIndex = -1 Then
                MsgBox("Verifique o lote de orígem! Ele não foi preenchido adequadamente." & vbCrLf & "Opte por escolher uma opção da lista.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End If
        End If
    End Sub

    Private Function Validacao() As Boolean
        Dim ret As Boolean = True

        'Verifica o código
        If txtCodigo.Text.Length <= 0 Then
            epErro.SetError(txtCodigo, "Digite o código do lote")
            ret = False
        End If

        'Verifica o lote de origem
        If cmbOrigem.Text.Length > 0 Then
            'Verifica se foi escolhido
            If cmbOrigem.SelectedIndex = -1 Then
                epErro.SetError(cmbOrigem, "Verifique o lote de orígem!")
                ret = False
            End If
        End If
        'Verifica a mercadoria
        If cmbMercadoria.SelectedIndex = -1 Or cmbMercadoria.Text.Length <= 0 Then
            epErro.SetError(cmbMercadoria, "Selecione o código da mercadoria na lista")
            ret = False
        End If
        'Verifia o clone
        If txtClone.Text.Length <= 0 Then
            epErro.SetError(txtClone, "Clone está em branco")
            ret = False
        End If
        'Verifica o lote
        If txtLote.Text.Length <= 0 Then
            epErro.SetError(txtLote, "O Lote está em branco")
            ret = False
        End If


        Return ret
    End Function


    Private Sub txtCodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        'troca ponto por virgula
        If e.KeyChar = "," Then
            e.Handled = True
            ' envia a nova tecla
            SendKeys.Send(".")
        End If
    End Sub


End Class