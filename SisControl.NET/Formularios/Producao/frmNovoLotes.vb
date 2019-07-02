Imports QRCoder
Imports MySql.Data.MySqlClient

Public Class frmNovoLotes
    'Define os tipos aceitos pela função
    Enum Tipo_SQL
        Insert
        Update
        Delete
    End Enum

    'Variável que recebe a ordem de Produção caso seja informada
    Dim Ordem_Producao As Integer = -1
    Dim LoteID As Integer = -1

    Public Sub New(Optional ByVal Tipo As Char = "N", Optional ByVal Numero As Integer = -1)
        'Esse foi o jeito para ter 2 opções para NEW
        ' L -> Carrega Lote e Número fica sendo ID do Lote
        ' O -> Carrega Ordem de Produção e o Número fica sendo o número da Ordem

        ' This call is required by the designer.
        InitializeComponent()

        Select Case Tipo
            Case "L"
                'Se recebeu alguma ordem de produção como parâmetro então atribui
                If Numero > -1 Then
                    'Em caso de alteração carrega a informação do Lote
                    LoteID = Numero
                End If
            Case "O"
                If Numero > -1 Then
                    Ordem_Producao = Numero
                End If
        End Select
        'Se recebeu alguma ordem de produção como parâmetro então atribui

    End Sub

    Private Sub frmNovoLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Mercadorias
        Carrega_Lista(cmbMercadoria, "Mercadoria_num", "id", "Nome", True)
        'Repicadores
        Carrega_Lista(cmbRepicador, "Repicador", "id", "Nome", True, "Ativo=1")
        'Fases de Reprodução
        Carrega_Lista(cmbFase, "Fases", "id", "Fase")
        'Meios de Cultura
        Carrega_Lista(cmbMeio, "Meio", "id", "meio", True)
        'Tipos de Frascos
        Carrega_Lista(cmbFrasco, "Tipo_Frasco", "tipo_frasco", "tipo_frasco", True)
        'Tipos de Explante
        Carrega_Lista(cmbExplante, "Tipo_Explante", "tipo_explante", "tipo_explante", True)
        'Acerta a data do Date picker
        txtData.Value = Today()
        'Preenche os combos do grid
        Create_DataSet()
        'Verifica se é um carregamento de lote
        If LoteID > -1 Then
            Carrega_Info_Lote(LoteID)
        End If
        'Verifica se recebeu como parâmetro alguma ordem de produção então já inicia o Preenchimento
        If Ordem_Producao > -1 Then
            Carrega_Info_Ordem()
        End If
    End Sub

    Private Sub Create_DataSet()
        'Cria o DataTable REPICADOR
        Dim DTRepicador As DataTable = SQLQuery("SELECT id,Nome FROM repicador WHERE Ativo=1")
        'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        Me.colRepicador.DataSource = DTRepicador
        Me.colRepicador.ValueMember = "id"
        Me.colRepicador.DisplayMember = "Nome"

        'Cria o DataTable MEIO
        Dim DTMeio As DataTable = SQLQuery("SELECT * FROM meio")
        'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        Me.colMeio.ValueMember = "id"
        Me.colMeio.DisplayMember = "Meio"
        Me.colMeio.DataSource = DTMeio

        'Cria o DataTable TIPO FRASCO
        Dim DTTipoFrasco As DataTable = SQLQuery("SELECT Tipo_Frasco FROM Tipo_Frasco")
        'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        Me.colTipo.ValueMember = "Tipo_Frasco"
        Me.colTipo.DisplayMember = "Tipo_Frasco"
        Me.colTipo.DataSource = DTTipoFrasco

        'Cria o DataTable TIPO EXPLANTE
        Dim DTTipoExplante As DataTable = SQLQuery("SELECT Tipo_Explante FROM Tipo_Explante")
        'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
        Me.colExplante.ValueMember = "Tipo_Explante"
        Me.colExplante.DisplayMember = "Tipo_Explante"
        Me.colExplante.DataSource = DTTipoExplante
    End Sub

    Private Sub QRCode_CSharp(varID As Integer)
        'Criar o QR Code usando a biblioteca em C# Baixada do GitHub
        Dim Level As String
        'Define o Nível do QR Code (L H Q M)
        Level = "L"
        ' "Traduz" o Level para número
        Dim ECCLevel As QRCodeGenerator.ECCLevel = 1
        'Cria o objeto QRCode Generator
        Dim GeradorQR As New QRCodeGenerator
        'Define o URL Base
        Dim urlBase As String = "http://10.1.1.254/index3.php?id="
        'Cria o binário do QR Code
        Dim qrCodeData As QRCodeData = GeradorQR.CreateQrCode(urlBase & varID, ECCLevel)
        Dim qrCode As New QRCode(qrCodeData)
        'Usa o criador para colocar isso na imagem.
        pbQrCode.Image = qrCode.GetGraphic(3, Color.Black, Color.White, False)
    End Sub

    Private Sub Atualiza_Totais()
        Dim soma As Integer = 0
        For i As Integer = 0 To dgFrascos.RowCount - 1
            soma += dgFrascos.Rows(i).Cells(2).Value
        Next
        txtEstIni.Text = Format(soma, "n0")
        txtEstFrascos.Text = Format(dgFrascos.RowCount, "n0")
    End Sub

    Private Sub dgFrascos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgFrascos.RowsAdded
        Atualiza_Totais()
    End Sub

    Private Sub dgFrascos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgFrascos.RowsRemoved
        Atualiza_Totais()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        'troca ponto por virgula
        If e.KeyChar = "," Then
            e.Handled = True
            ' envia a nova tecla
            SendKeys.Send(".")
        End If
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
            txtLote.Text = ZerosEsquerda(Partes(1), 3)
            'Parte2=Clone
            txtClone.Text = ZerosEsquerda(Partes(2), 4)
            'Procura se já existe o lote
            Cod = DLookup("id", "lotes", "mercadoria=" & Partes(0) & " and lote=" & Partes(1) & " and clone=" & Partes(2) & " and ativo=1")
            If Cod <> "" Then
                nLote = DMax("lote", "Lotes", "mercadoria=" & Partes(0) & " AND Clone=" & Partes(2) & " AND ativo=1")
                If Aviso Then
                    MsgBox("Já existe um lote ativo com este código!" & vbCrLf & "Lote: " & Cod & vbCrLf & "Próximo lote: " & nLote + 1, MsgBoxStyle.Exclamation, "Aviso")
                End If
                txtCodigo.Text = Partes(0) & "." & nLote + 1 & "." & Partes(2)
                txtLote.Text = Format(nLote + 1, "000")
                txtNOrigem.Focus()
                'Exit Sub
            End If

            '*** Depois de Tudo verificado coleta os parâmetros ***

            'Verifica qual o próximo ID de Inserção
            Dim SQL As String = "SELECT Auto_increment as nextID FROM information_schema.tables WHERE table_name='lotes'"
            Try
                Dim dtResult As DataTable
                dtResult = SQLQuery(SQL)
                'Verifica se retornou resultado
                If dtResult.Rows.Count > 0 Then
                    txtID.Text = dtResult.Rows(0).Item("nextID")
                    dtResult = Nothing
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar localizar o ID de Inserção" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            'Povoar o combo origem com os lotes disponíveis
            Carrega_Lista(cmbOrigem, "id_codigo", "id", "Codigo", True, "Mercadoria=" & Partes(0) & " AND Clone=" & Partes(2) & " AND Ativo=1")

            'Preenche o Combo de Origem do DataGridView Também para não dar Erro

            'Cria o DataTable ORIGEM
            Dim DTOrigem As DataTable = SQLQuery("SELECT id,Codigo FROM id_codigo WHERE Mercadoria=" & Partes(0) & " AND Clone=" & Partes(2) & " AND Ativo=1")
            'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
            Me.colOrigem.ValueMember = "id"
            Me.colOrigem.DisplayMember = "codigo"
            Me.colOrigem.DataSource = DTOrigem

            'Gera o QR Code do Lote
            If IsNumeric(txtID.Text) Then
                QRCode_CSharp(txtID.Text)
            End If

            'Move o foco para o combo origem
            txtNOrigem.Focus()
        End If
    End Sub

    Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
        'Se é alteração não passa por essa rotina
        If btIncluir.Text = "Incluir" Then
            Verifica_Num_Lote(True)
        End If
    End Sub

    Private Sub btFrascos_Click(sender As Object, e As EventArgs) Handles btFrascos.Click
        'Faz a verificação e validação dos campos
        If Not valida_campos() Then
            Exit Sub
        End If

        'Verifica se já existem frascos cadastrados
        Dim varVidro As Integer
        If dgFrascos.RowCount <= 0 Then
            varVidro = 1
        Else
            'Organiza os frascos em ordem
            'dgFrascos.Sort(colVidro, System.ComponentModel.ListSortDirection.Ascending)
            'Pega o número do último frasco
            varVidro = dgFrascos.Rows(dgFrascos.Rows.Count - 1).Cells(1).Value + 1
        End If

        'Faz a inserção dos frascos no grid
        For i As Integer = varVidro To varVidro + Int(txtNFrascos.Text) - 1
            With DsFrascosAux.Tables("aux_frascos")
                Dim Row As DataRow = .NewRow
                Row("Lote") = txtID.Text
                Row("vidro") = i
                Row("nMudas") = txtM_F.Text
                Row("impresso") = 0
                Row("selecao") = 0
                Row("Variedade") = cmbVal(cmbMercadoria)
                Row("Clone") = txtClone.Text
                Row("Origem") = cmbVal(cmbOrigem)
                Row("Repicador") = cmbVal(cmbRepicador)
                Row("Meio") = cmbVal(cmbMeio)
                Row("Data") = txtData.Value
                Row("frTipo") = cmbFrasco.Text
                Row("Explante") = cmbExplante.Text
                Row("Dias") = txtDias.Text
                Row("criacao") = Now()
                'Adiciona a linha no DataRow
                Try
                    .Rows.Add(Row)
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir frasco no DataGrid" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End With
        Next
    End Sub

    Private Function valida_campos() As Boolean
        Dim ret As Boolean = True

        'Verifica o código
        If txtCodigo.Text.Length <= 0 Then
            epErro.SetError(txtCodigo, "Digite o código Do lote")
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
            epErro.SetError(cmbMercadoria, "Selecione o código da variedade na lista")
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

        If cmbFase.SelectedIndex = -1 Or cmbFase.Text.Length <= 0 Then
            epErro.SetError(cmbFase, "Selecione a fase da cultura")
            ret = False
        End If
        'Verifica o prazo de repicagem
        If txtDias.Text.Length <= 0 Then
            epErro.SetError(txtDias, "Defina o prazo de repicagem Do material")
            ret = False
        End If
        'Verifica o número de frascos
        If txtNFrascos.Text.Length <= 0 Or txtNFrascos.Text = "0" Then
            epErro.SetError(txtNFrascos, "Digite a quantidade de frascos a acrescentar")
            ret = False
        End If
        'Verifica o número de mudas
        If txtM_F.Text.Length <= 0 Or txtM_F.Text = "0" Then
            epErro.SetError(txtM_F, "Defina o número de mudas por frasco")
            ret = False
        End If
        'Verifica o Repicador
        If cmbRepicador.SelectedIndex = -1 Or cmbRepicador.Text.Length <= 0 Then
            epErro.SetError(cmbRepicador, "Selecione um repicador")
            ret = False
        End If
        'Verifica o Meio de Cultura
        If cmbMeio.SelectedIndex = -1 Or cmbMeio.Text.Length <= 0 Then
            epErro.SetError(cmbMeio, "Selecione o meio de Cultura")
            ret = False
        End If
        'Verifica o Tipo do Frasco
        If cmbFrasco.SelectedIndex = -1 Or cmbFrasco.Text.Length <= 0 Then
            epErro.SetError(cmbFrasco, "Selecione o tipo Do frasco")
            ret = False
        End If
        'Verifica o Tipo do Explante
        If cmbExplante.SelectedIndex = -1 Or cmbExplante.Text.Length <= 0 Then
            epErro.SetError(cmbMercadoria, "Selecione o tipo Do explante")
            ret = False
        End If
        Return ret
    End Function

    Private Sub btIncluir_Click(sender As Object, e As EventArgs) Handles btIncluir.Click
        'Dependendo do comportamento, faz de um ou de outro jeito
        If btIncluir.Text = "Incluir" Then
            Salva_Info_Lote(Tipo_SQL.Insert)
        ElseIf btIncluir.Text = "Salvar" Then
            Salva_Info_Lote(Tipo_SQL.Update)
        End If
    End Sub

    Private Sub Salva_Info_Lote(ByVal Tipo As Tipo_SQL)
        Dim conn As New MySqlConnection(MY_SQL_CONNECTION)

        'Cria o comando MySQL
        Dim SQL As New MySqlCommand()
        SQL.Connection = conn

        'Monta a SQL Base dependendo do tipo de operação
        Select Case Tipo
            Case Tipo_SQL.Insert
                SQL.CommandText = "INSERT INTO lotes Set id=@id, Mercadoria =@merc, Lote =@lote, Clone =@clone, Origem =@origem, Numero_Origem =@norigem, Frascos =@nfrascos, Mudas_frasco =@M_F, Tempo =@tempo, Repicador =@repicador, Fase =@fase, Meio =@meio, Data =@data, Est_Inicial =@estIni, Estoque =@estoque, Est_Frascos =@estfrascos, Anotacoes =@anotacoes, Ativo =@ativo, Frasco =@frasco, Explante =@explante, dias =@dias, Mark =@mark, Local = 1, Ordem_Producao =@op, criacao = CURRENT_TIMESTAMP, QRCode =@qrcode"
            Case Tipo_SQL.Update
                SQL.CommandText = "UPDATE lotes SET Mercadoria=@merc, Lote =@lote, Clone =@clone, Origem =@origem, Numero_Origem =@norigem, Frascos =@nfrascos, Mudas_frasco =@M_F, Tempo =@tempo, Repicador =@repicador, Fase =@fase, Meio =@meio, Data =@data, Est_Inicial =@estIni, Estoque =@estoque, Est_Frascos =@estfrascos, Anotacoes =@anotacoes, Ativo =@ativo, Frasco =@frasco, Explante =@explante, dias =@dias, Mark =@mark, Ordem_Producao =@op WHERE id=@id"
        End Select

        'Preenche os parametros (teve que ser feito dessa forma por conta do QRCode que não dá para incluir direto
        With SQL.Parameters
            .AddWithValue("@id", txtID.Text)
            .AddWithValue("@merc", cmbVal(cmbMercadoria))
            .AddWithValue("@lote", txtLote.Text)
            .AddWithValue("@clone", txtClone.Text)
            .AddWithValue("@origem", cmbVal(cmbOrigem))
            .AddWithValue("@norigem", txtNOrigem.Text)
            .AddWithValue("@nfrascos", txtEstFrascos.Text)
            .AddWithValue("@M_F", txtM_F.Text)
            .AddWithValue("@tempo", txtTempo.Text.ToString)
            .AddWithValue("@repicador", cmbVal(cmbRepicador))
            .AddWithValue("@fase", cmbVal(cmbFase))
            .AddWithValue("@meio", cmbVal(cmbMeio))
            .AddWithValue("@data", CDate(txtData.Text))
            .AddWithValue("@estini", Integer.Parse(txtEstIni.Text, Globalization.NumberStyles.Any))
            .AddWithValue("@estoque", Integer.Parse(txtEstIni.Text, Globalization.NumberStyles.Any))
            .AddWithValue("@estfrascos", Integer.Parse(txtEstFrascos.Text, Globalization.NumberStyles.Any))
            .AddWithValue("@anotacoes", txtAnotacoes.Text)
            .AddWithValue("@ativo", chkAtivo.Checked)
            .AddWithValue("@frasco", cmbFrasco.Text)
            .AddWithValue("@explante", cmbExplante.Text)
            .AddWithValue("@dias", txtDias.Text)
            .AddWithValue("@mark", 0)
            .AddWithValue("@local", 1)
            If txtNumOP.Text = String.Empty Then
                .AddWithValue("@op", -1)
            Else
                .AddWithValue("@op", txtNumOP.Text)
            End If
            If Tipo = Tipo_SQL.Insert Then
                'Prepara imagem para inclusão
                Dim picture As Image = pbQrCode.Image
                'Cria uma stream em memória
                Dim stream As New IO.MemoryStream
                'Preenche a stream com a imagem do picturebox
                picture.Save(stream, Imaging.ImageFormat.Jpeg)
                'Cria o parametro para inclusão do QRCode
                .Add("@QRCode", MySqlDbType.VarBinary).Value = stream.GetBuffer()
            End If
        End With
        Try
            'abre a conexão
            conn.Open()
            'Executa o comando de inserção
            SQL.ExecuteNonQuery()
            'Fecha a conexão
            conn.Close()
            'Uma vez incluido o lote, é a vez de incluir os frascos
            taAux_frascos.Update(DsFrascosAux.aux_frascos)
            'Se não houve nenhum erro
            Dim msg As String = String.Empty
            'Verifica qual a mensagem com base no tipo de operação
            If Tipo = Tipo_SQL.Insert Then
                msg = " incluído com sucesso!"
            ElseIf Tipo = Tipo_SQL.Update Then
                msg = " atualizado com sucesso!"
            ElseIf Tipo = Tipo_SQL.Delete Then
                msg = " eliminado com sucesso!"
            End If

            'Emite a mensagem para o usuário
            MsgBox("Lote " & txtID.Text & msg, MsgBoxStyle.OkOnly, "Aviso")

            'Verifica diretamente no banco de dados se tem algum frasco nessa situação.
            If DCount("id", "aux_frascos", "(lote=" & txtID.Text & ") And (impresso= 0)") > 0 Then
                'Em caso de alteração nos frascos perguntar se envia os frascos para impressão
                Dim resp As Integer = MsgBox("Enviar As etiquetas não impressas para lista de impressão?", vbQuestion + vbYesNo, "Confirmação")
                If resp = vbYes Then
                    Envia_Etiquetas_Impressao()
                End If
            End If

            If Tipo = Tipo_SQL.Insert Then
                'Habilita os campos que podem ter ficado "presos"
                btIncluir.Text = "Incluir"
                txtCodigo.Enabled = True
                cmbMercadoria.Enabled = True
                txtLote.Enabled = True
                txtClone.Enabled = True
                'Limpa os campos e prepara para nova inclusão
                Limpa_Campos()
            ElseIf Tipo = Tipo_SQL.Update Then
                'Fecha o formulário para não hever risco de acrescentar informação novamente
                Me.Close()
            End If

        Catch ex As MySqlException
            'Valor duplicado para chave primária (Erro 1062)
            If ex.Number = MySqlErrorCode.DuplicateKeyEntry Then
                MsgBox("O lote já foi incluído ou já existe um lote com o ID " & txtID.Text & vbCr & "Tente Gerar um outro ID", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End If
            'Algum outro tipo de erro não classificado
            MessageBox.Show("Erro ao tentar incluir o Lote " & vbCr & ex.Number & " ocorreu: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Erro ao tentar incluir o Lote " & vbCr & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Envia_Etiquetas_Impressao()
        Dim SQL As String = String.Empty
        'Monta o código do lote que será impresso
        Dim varCodigo As String = Format(cmbVal(cmbMercadoria), "000") & "." & txtLote.Text & "." & txtClone.Text
        'Monta a SQL de transferencia de etiquetas
        SQL = "INSERT INTO etiquetas_prn (`Desc`,`Codigo`,`Data`,`nMudas`,`vidro`) (SELECT '" & varCodigo & "',lpad(id,13,'0') as Cod,date_format(`data`, '%d/%m/%y') as dataf,nmudas,vidro FROM aux_frascos WHERE (lote=" & txtID.Text & ") AND (impresso=0))"
        Console.WriteLine(SQL)
        Try
            ExecutaSQL(SQL)
            MsgBox("Frascos enviados para lista de impressão com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
        Catch ex As MySqlException
            MsgBox("Erro ao enviar frascos para impressão" & vbCr & ex.Message & "(" & ex.Number & ")", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        Catch ex As Exception
            MsgBox("Erro ao enviar frascos para impressão" & vbCr & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try

        ' ****** Marcar Frascos como Impresso *******
        Try
            'Tem que marcar os frascos como impresso
            SQL = "UPDATE aux_frascos SET impresso=1 WHERE lote=" & txtID.Text
            ExecutaSQL(SQL)
        Catch ex As MySqlException
            MsgBox("Erro ao marcar frascos como Impressos" & vbCr & ex.Message & "(" & ex.Number & ")", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        Catch ex As Exception
            MsgBox("Erro ao marcar frascos como Impressos" & vbCr & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub dgFrascos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgFrascos.DataError
        'Para prevenir o erro de quando o combobox não está preenchido.
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    Private Sub Limpa_Campos()
        'Limpa os campos
        txtCodigo.Text = String.Empty
        cmbMercadoria.Text = String.Empty
        txtLote.Text = String.Empty
        txtClone.Text = String.Empty
        cmbOrigem.Items.Clear()
        cmbOrigem.Text = String.Empty
        txtNOrigem.Text = "0"
        txtNFrascos.Text = "0"
        txtM_F.Text = "0"
        txtTempo.Text = String.Empty
        cmbFase.Text = String.Empty
        cmbMeio.Text = String.Empty
        txtData.Text = String.Empty
        txtEstIni.Text = "0"
        txtEstFrascos.Text = "0"
        cmbFrasco.SelectedIndex = -1
        cmbExplante.SelectedIndex = -1
        txtDias.Text = "0"
        txtAnotacoes.Text = String.Empty
        pbQrCode.Image = Nothing
        cmbRepicador.Text = String.Empty
        txtID.Text = "..."
        'Limpa o DataSet Associado ao DatagridView
        DsFrascosAux.aux_frascos.Clear()
        btIncluir.Text = "Incluir"
        'Move o foco para o campo código
        txtCodigo.Focus()
    End Sub

    Public Sub Carrega_Info_Lote(ByVal LoteID As Integer)
        Atualiza_Dados(LoteID)
        Me.Text = "Alteração de Lotes"
        btIncluir.Text = "Salvar"
    End Sub

    'Sub que faz a procura do LOTE e preenche os dados nos campos
    Public Sub Atualiza_Dados(ByVal id As Integer)
        Dim SQL As String, Tabela As DataTable, DR As DataRow
        'Monta a SQL para localizar o lote
        SQL = "SELECT * FROM Lotes WHERE Id=" & id
        'Tenta preencher a tabela com os dados do lote
        Try
            'Preenche a tabela com o lote que foi pedido
            Tabela = SQLQuery(SQL)
            'Verifica se o lote foi encontrado e se a Query não voltou vazia
            If Tabela.Rows.Count = 0 Then
                'Não há linhas nessa tabela
                MsgBox("Lote não encontrado!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If
            'mostra o id do lote
            txtID.Text = id
            'Extrai a linha (a unica linha)
            DR = Tabela.Rows(0)
            'Se tudo estiver certo, agora preenche os campos
            'Função para localizar no combo onde está a mercadoria
            Localiza_Item(cmbMercadoria, DR("Mercadoria"))
            txtLote.Text = Format(DR("Lote"), "000")
            txtClone.Text = Format(DR("Clone"), "0000")
            'Se a origem é nula
            If IsDBNull(DR("origem")) Then
                'Limpa a lista
                cmbOrigem.Items.Clear()
                'Carrega lista com os lotes inativos
                Carrega_Lista(cmbOrigem, "id_codigo", "id", "Codigo", True, "((Mercadoria=" & DR("Mercadoria") & ") and (Ativo=0) and (Clone=" & DR("Clone") & "))")
                'Limpa o combo
                cmbOrigem.Text = String.Empty
            Else
                'Carrega a lista com os lotes de origem
                Carrega_Lista(cmbOrigem, "id_codigo", "id", "Codigo", True, "((Mercadoria=" & DR("Mercadoria") & ") and (Ativo=1) and (Clone=" & DR("Clone") & ")) OR (Id=" & DR("Origem") & ") ")
                'Depois de carregado localiza o item
                Localiza_Item(cmbOrigem, DR("origem"))
            End If

            ' Atualiza também o DataSet de Origem do Datagrid

            'Cria o DataTable ORIGEM
            Dim DTOrigem As DataTable = SQLQuery("SELECT id,Codigo FROM id_codigo WHERE Mercadoria=" & DR("Mercadoria") & " AND Clone=" & DR("Clone") & " AND Ativo=1")
            'Atribui ele à coluna indicando qual o campo a gravar e qual a mostrar.
            Me.colOrigem.ValueMember = "id"
            Me.colOrigem.DisplayMember = "codigo"
            Me.colOrigem.DataSource = DTOrigem

            txtCodigo.Text = Format(DR("Mercadoria"), "000") & "." & Format(DR("Lote"), "000") & "." & Format(DR("clone"), "0000")
            'Por conta dos lotes antigos que tem os dois repicadores (se existe o ";")
            If DR("Repicador").ToString.IndexOf(";") > 0 Then
                'Pega somente o primeiro repicador
                Localiza_Item(cmbRepicador, DR("Repicador").ToString.Substring(0, DR("Repicador").ToString.IndexOf(";") - 1))
            Else
                'Pega o único repicador
                Localiza_Item(cmbRepicador, DR("Repicador"))
            End If
            txtNOrigem.Text = DR("numero_origem")
            'txtNFrascos.Text = DR("Frascos")
            txtTempo.Text = DR("Tempo").ToString
            Localiza_Item(cmbFase, DR("Fase"))
            Localiza_Item(cmbMeio, DR("Meio"))
            txtM_F.Text = DR("Mudas_frasco")
            txtData.Value = DR("data")
            txtEstIni.Text = DR("Est_inicial")
            'txtEstoque.Text = DR("Estoque")
            txtEstFrascos.Text = DR("Est_Frascos")
            cmbFrasco.Text = DR("Frasco")
            cmbExplante.Text = DR("Explante")
            txtDias.Text = DR("dias")
            txtAnotacoes.Text = DR("anotacoes")
            txtNumOP.Text = IIf(DR("ordem_producao") = -1, String.Empty, DR("ordem_producao"))
            chkAtivo.Checked = DR("ativo")
            'Recupera o QR Code Também
            Try
                Dim Codigo2D() As Byte = DLookupBLOB("Qrcode", "lotes", "id=" & id)
                Dim lstr As New System.IO.MemoryStream(Codigo2D)
                pbQrCode.Image = Image.FromStream(lstr)
                pbQrCode.SizeMode = PictureBoxSizeMode.StretchImage
                lstr.Close()
            Catch ex As Exception

            End Try

            'Pega os dados dos frasocs
            taAux_frascos.Fill(DsFrascosAux.aux_frascos, id)

            'imobiliza alguns campos para não mexer pois não podem ser alterados
            txtCodigo.Enabled = False
            cmbMercadoria.Enabled = False
            txtLote.Enabled = False
            txtClone.Enabled = False

        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar os dados do lote:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Carrega_Info_Ordem()
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
        'txtEstIni.BackColor = cor
        cmbExplante.BackColor = cor
        txtDias.BackColor = cor
        cmbRepicador.BackColor = cor

        cmbFrasco.Text = "Frasco de Vidro"
        '*** Preenche o formulário com os dados pré cadastrados da Ordem de Produção
        txtCodigo.Text = DR("Codigo")
        Verifica_Num_Lote(False)  'Não avisa, simplesmente corrige o número do lote
        Localiza_Item(cmbFase, DR("Fase"))
        Localiza_Item(cmbMeio, DR("Meio"))
        txtM_F.Text = DR("Mds_frasco")
        cmbExplante.Text = "Plântula"
        txtDias.Text = "30"
        txtNumOP.Text = DR("id")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbMercadoria_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMercadoria.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLote.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtClone_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClone.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtNOrigem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNOrigem.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtTempo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTempo.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbFase_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFase.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtDias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDias.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtNFrascos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNFrascos.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtM_F_KeyDown(sender As Object, e As KeyEventArgs) Handles txtM_F.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbOrigem_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbOrigem.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbRepicador_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRepicador.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbMeio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMeio.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbFrasco_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFrasco.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub cmbExplante_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbExplante.KeyDown
        EnterAsTab(sender, e)
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

    Private Sub txtDias_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDias.Enter
        txtDias.SelectAll()
    End Sub

    Private Sub txtLote_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLote.Enter
        txtLote.SelectAll()
    End Sub

    Private Sub dgFrascos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgFrascos.CellEndEdit
        'Se o número de mudas mudar, recalcula os totais para não dar furo no estoque.
        If e.ColumnIndex = 2 Then
            Atualiza_Totais()
        End If
    End Sub

    Private Sub dgFrascos_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgFrascos.RowPrePaint
        If IsDBNull(dgFrascos.Rows(e.RowIndex).Cells("bxExclusao").Value) Then
            dgFrascos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        Else
            dgFrascos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.IndianRed
        End If
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        pnlInfo.Visible = False
    End Sub

    Private Sub dgFrascos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgFrascos.KeyDown
        If e.KeyCode = Keys.F3 Then
            pnlInfo.Visible = True
            Dim FrascoID As Integer = dgFrascos.Rows(dgFrascos.SelectedRows(0).Index).Cells("colId").Value
            lblFrascoID.Text = FrascoID

            Dim DR As DataRow = DLookupRow("aux_frascos", "id=" & FrascoID)

            'Se o frasco tiver sido excluido mostra as informações da exclusão
            If Not IsDBNull(DR("bxExclusao")) Then  'Ou seja CONSTA a data da exclusão
                lblStatus.Text = "[ INATIVO ]"
                lblStatus.BackColor = Color.IndianRed
                lblCriado.Text = Format(DR("criacao"), "dd/MM/yyyy")
                lblDataBaixa.Text = Format(DR("bxExclusao"), "dd/MM/yyyy")
                lblBaixadoPor.Text = DLookup("Nome", "Repicador", "numero=" & DR("bxOperador"))
                Select Case DR("bxMotivo")
                    Case "O"
                        lblMotivoBaixa.Text = "Oxidação"
                    Case "F"
                        lblMotivoBaixa.Text = "Fungo"
                    Case "B"
                        lblMotivoBaixa.Text = "Bactéria"
                    Case "P"
                        lblMotivoBaixa.Text = "Plantio"
                    Case "R"
                        lblMotivoBaixa.Text = "Repicagem"
                    Case Else
                        lblMotivoBaixa.Text = "Não Registrado ou Desconhecido"
                End Select
            Else
                lblStatus.Text = "[ ATIVO ]"
                lblStatus.BackColor = Color.LightGreen
                lblCriado.Text = Format(DR("criacao"), "dd/MM/yyyy")
                lblDataBaixa.Text = "..."
                lblBaixadoPor.Text = "..."
                lblMotivoBaixa.Text = "..."
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            pnlInfo.Visible = False
        End If
    End Sub


End Class