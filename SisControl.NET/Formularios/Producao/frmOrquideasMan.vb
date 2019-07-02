Public Class frmOrquideasMan

    Private Sub frmOrquideasMan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub frmOrquideasMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista com os lotes de orquide que estao ativos
        Carrega_Lista(cmbLotes, "Germinacao", "id", "cod", True, "ativo=1")
        'Atualiza a data para o dia atual
        txtData.Value = Now.Date
        'Carrega o nome dos repicadores
        Carrega_Lista(lstRepicador, "Repicador", "id", "Nome", True, "Ativo=1")
        'grupo inativado
        grpProducao.Enabled = False
    End Sub

    Private Sub cmbLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLotes.SelectedIndexChanged
        'Atualiza os dados do lote
        Atualiza_dados()
    End Sub

    Private Sub Atualiza_Dados()
        Dim SQL As String, DT As DataTable, DR As DataRow
        'Monta a SQL para os lotes
        SQL = "SELECT * FROM Germinacao WHERE id=" & cmbVal(cmbLotes)
        Try
            'Executa a SQL
            DT = SQLQuery(SQL)
            'Pega a linha selecionada (unica)
            DR = DT.Rows(0)
            lblID.Text = DR("id")
            lblEspecie.Text = NaoNulo(DR("Especie"))
            lblDescricao.Text = NaoNulo(DR("Descricao"))
            lblSem.Text = NaoNulo(DR("NSementes"))
            lblMds.Text = NaoNulo(DR("Nmudas"))
            lblPlt.Text = NaoNulo(DR("NPLantadas"))
            'Se a data da semeadura estiver em branco
            If Not IsDBNull(DR("semeadura")) Then
                'Senão publica
                lblSemeadura.Text = Format(CDate(DR("semeadura")), "dd/MM/yyyy")
            Else
                'Coloca como não informado
                lblSemeadura.Text = "N/I"
            End If
            'Grupo de produção habilitado
            grpProducao.Enabled = True
        Catch ex As Exception
            MsgBox("Problema ao localizar as informações do lote" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            lblID.Text = "..."
            lblEspecie.Text = "---"
            lblDescricao.Text = "---"
            lblSem.Text = "---"
            lblMds.Text = "---"
            lblPlt.Text = "---"
            lblSemeadura.Text = "---"
            Exit Sub
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Int16  ', DGVR As New DataGridViewRow
        'Se não  estiverem zerados os campos
        If (txtNFrascos.Text = String.Empty) Or (txtNFrascos.Text = "0") Then
            txtNFrascos.Focus()
            Exit Sub
        End If
        'Se o número de mudas etiver zerado
        If (txtNMudas.Text = String.Empty) Or (txtNMudas.Text = "0") Then
            txtNMudas.Focus()
            Exit Sub
        End If
        'Preenche os campos
        For i = 1 To txtNFrascos.Text
            dgFrascos.Rows.Add(txtNMudas.Text)
        Next i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '*
        '* FAZ ALGUMAS VERIFICAÇÕES
        '*

        'Verifica se o número de frascos foi digitado
        If (txtSementes.Text = String.Empty Or txtSementes.Text = "0") And (dgFrascos.Rows.Count <= 0) Then
            MsgBox("É necessário incluir os frascos antes de prosseguir", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        'Verifica se algum repicador foi selecionado
        If lstRepicador.SelectedItems.Count <= 0 Then
            MsgBox("É necessário selecionar ao menos um repicador", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If


        Dim num As Int16, Vidro As Integer, SQL As String, Soma As Integer = 0, i As Integer

        '*
        '* ATUALIZAÇÃO DO ESTOQUE DO LOTE
        '*

        'SQL Base
        SQL = "UPDATE germinacao SET "
        If txtSementes.Text <> String.Empty Or txtSementes.Text <> "0" Then
            SQL &= "nsementes=nsementes+" & IIf(txtSementes.Text = "", 0, txtSementes.Text) & " "
        End If
        'Número de frascos a serem adicionados
        num = dgFrascos.Rows.Count - 1
        'se Existirem frascos de mudas a serem incluidos
        If num > 0 Then
            'Vai somando as mudas
            For i = 0 To num - 1
                Soma += dgFrascos.Rows(i).Cells(0).Value
            Next
            'Se já tiver algum complemento
            If SQL.Length > 23 Then
                'Bota uma vírgula
                SQL &= ","
            End If
            'Atualiza o número de mudas
            SQL &= "Nmudas=Nmudas+" & Soma & ",Frascos=Frascos+" & num
        End If
        'Individualiza o lote
        SQL &= " WHERE id=" & lblID.Text
        'Tenta fazer a atualização do estoque de frascos primeiro
        Try
            Console.WriteLine(Me.Name & ": " & SQL)
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o estoque do lote " & cmbLotes.Text & " (" & lblID.Text & ")" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try

        '*
        '* INCLUSÃO DOS FRASCOS INDIVIDUAIS
        '*

        'Monta a SQL para os frascos e faz a inclusão
        'Número de frasco inicial para inclusão
        Vidro = DMax("Vidro", "aux_germinacao", "lote=" & lblID.Text)
        SQL = "INSERT INTO aux_germinacao (Lote,Tipo,NMudas,Vidro,Repicagem,Repicador) VALUES "
        Dim tam_old As Integer = SQL.Length
        'Primeiro os de semente
        Vidro += 1

        'Define o repicador
        Dim varRepicador As String = String.Empty
        If lstRepicador.SelectedItems.Count > 0 Then
            varRepicador = "'" & valRepicador(lstRepicador) & "'"
        Else
            varRepicador = "NULL"
        End If

        'Se existirem frascos de semente
        If txtSementes.Text <> String.Empty And txtSementes.Text <> "0" Then
            'inclui os frascos com sementes primeiro
            For i = 1 To txtSementes.Text
                If SQL.Length > tam_old Then
                    'Se o tamanho da string aumentou então quer dizer que é o próximo
                    SQL &= ","
                End If

                SQL &= "(" & lblID.Text & ",'S',0," & Vidro & ",'" & Format(txtData.Value, "yyyy-MM-dd") & "'," & varRepicador & ")"
                Vidro += 1
            Next
        End If

        'Se existirem frascos de mudas
        If dgFrascos.Rows.Count - 1 > 0 Then
            'Se o comprimento da SQL já for maior (já tiver os frascos)
            'Poe uma virgula (70 é o tamanho da SQL base
            If SQL.Length > tam_old Then
                SQL &= ","
            End If
            'Começa a correr o grid para fazer a inclusão
            For i = 0 To num - 1
                If i > 0 Then
                    'Se for a segunda vez que passa por virgula
                    SQL &= ","
                End If
                SQL &= "(" & lblID.Text & ",'M'," & dgFrascos.Rows(i).Cells(0).Value & "," & Vidro & ",'" & Format(txtData.Value, "yyyy-MM-dd") & "'," & varRepicador & ")"
                Vidro += 1
            Next
        End If
        'Com a SQL pronta pode-se tentar fazer a inclusão
        Try
            Console.WriteLine(Me.Name & ": " & SQL)
            ExecutaSQL(SQL)
            'Se deu tudo certo informa ao usuário
            MsgBox("Estoque atualizado com sucesso!" & vbCrLf & "Frascos incluídos com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
            Dim a As Integer
            a = MsgBox("Enviar etiquetas para a fila de impressão?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            If a = vbYes Then
                Impressao_Etiquetas()
            End If
            limpa()
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir os frascos individuais do lote " & cmbLotes.Text & " (" & lblID.Text & ")" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Impressao_Etiquetas()

        'Se não puder identificar o ID do lote processado
        If lblID.Text = String.Empty Then
            Exit Sub
        End If

        Dim SQL As String
        'Monta a SQL de inclusão
        SQL = "SELECT * FROM aux_germinacao WHERE Lote=" & lblID.Text & " AND Impresso=0"

        Try
            Dim DT As DataTable
            DT = SQLQuery(SQL)
            'se existirem resultados
            If DT.Rows.Count > 0 Then
                Dim i As Integer = 0

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

                'Verifica os dados comuns a todos os frascos
                varLote = cmbLotes.Text
                varEspecie = lblEspecie.Text
                varDescri = lblDescricao.Text

                'Verifica se a data da polinizaçao é nula
                varDataP = Texto_Vazio(DLookup("Polinizacao", "germinacao", "id=" & lblID.Text))
                varDataC = Texto_Vazio(DLookup("Colheita", "germinacao", "id=" & lblID.Text))
                varDataS = Texto_Vazio(lblSemeadura.Text)

                'Monta a SQL padrão
                SQL = "INSERT INTO etiquetasorq_prn VALUES "
                Dim Parte As String

                'Procura todos os frascos para enviar para impressão
                For i = 0 To DT.Rows.Count - 1
                    'Monta as informações específicas do frasco
                    With DT.Rows(i)
                        varCodBar = .Item("id")
                        varFrasco = Format(.Item("vidro"), "000")
                        varTemp = Format(CDate(txtData.Text), "yyyy-MM-dd")
                        varNMudas = DLookup("Nmudas", "aux_germinacao", "id=" & varCodBar)
                    End With
                    'Verifica se a data da repicagem não é nula
                    If IsDBNull(varTemp) Then
                        varDataR = "Null"
                    Else
                        varDataR = "'" & varTemp & "'"
                    End If

                    'Ese null teve que ser colocado porqe o nome do campo é uma palavra restrita do MySQL
                    Parte = "(null,'" & Format(Val(varCodBar), "0000000") & "'," & varDataC & ",'" & varLote & "','" & varEspecie & "'," & varDataP & "," & varDataS & ",'" & varDescri & "'," & varDataR & "," & varFrasco & ",'" & varNMudas & "')"

                    'Se for a primeira vez que passa aqui vai direto
                    If i = 0 Then
                        SQL = SQL & Parte
                    Else    'Se já for mais vezes poe a virgula para montar a SQL
                        SQL = SQL & "," & Parte
                    End If
                Next

                If ExecutaSQL(SQL) Then
                    MsgBox(Format(DT.Rows.Count, "000") & " Etiquetas incluídas com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                    'Define todas as etiquetas como impressas
                    ExecutaSQL("UPDATE aux_germinacao SET Impresso=1 WHERE Lote=" & lblID.Text & " AND Impresso=0")
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir as etiquetas deste lote." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub limpa()
        cmbLotes.Text = String.Empty
        cmbLotes.SelectedIndex = -1
        lblEspecie.Text = "..."
        lblDescricao.Text = "..."
        lblSemeadura.Text = "..."
        lblSem.Text = "..."
        lblMds.Text = "..."
        lblPlt.Text = "..."
        lblID.Text = "..."
        txtSementes.Text = String.Empty
        txtNFrascos.Text = String.Empty
        txtNMudas.Text = String.Empty
        lstRepicador.ClearSelected()
        dgFrascos.Rows.Clear()
        grpProducao.Enabled = False
        cmbLotes.Focus()
    End Sub
End Class