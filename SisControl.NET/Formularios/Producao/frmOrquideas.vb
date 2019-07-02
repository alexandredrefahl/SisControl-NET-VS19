Public Class frmOrquideas

    Private Sub btCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancela.Click
        Me.Close()
    End Sub

    Private Function Validar() As Boolean
        'Primeiramente verifica se o código solicitado já existe.
        Dim resp As String = String.Empty
        resp = DLookup("Especie", "Germinacao", "Cod='" & txtCodigo.Text & "'")

        'Se achou alguma coisa.
        If resp <> String.Empty Then
            MsgBox("O código informado já existe: " & resp, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If

        'Verifica o código do cliente
        If cmbClientes.SelectedIndex = -1 Or cmbClientes.Text = "" Then
            MsgBox("Cliente precisa ser informado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If

        'Verifica a Descrição
        If txtDescricao.Text = String.Empty Then
            MsgBox("É nescessário informar uma descrição.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If

        'Vefica a data do Lote
        If txtLote.Text = "  /  /" Then
            MsgBox("É nescessário informar a data da chegada do lote", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If

        'Verifica a data da semeadura
        'Vefica a data do Lote
        If txtSemeadura.Text = "  /  /" Then
            MsgBox("É nescessário informar a data da semeadura", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If

        'Se passou por tudo 
        Return True
    End Function


    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        'Dimensiona a variavel pra receber o item selecionado
        Dim Meio As Integer, Cliente As Integer, SQL As String, datCruza As String, datColheita As String
        Dim i As Integer, LoteID As Integer, a As Integer

        'Verifica se a validação está feita
        If Not Validar() Then
            Exit Sub
        End If

        'Como esse combo depende de um index então tem que usar esse recurso
        Meio = cmbVal(cmbMeio)
        Cliente = cmbVal(cmbClientes)
        'Equaliza a questão da data para evitar erro de conversão de tipo
        If txtPolinizacao.Text <> "  /  /" Then
            datCruza = "'" & Format(CDate(txtPolinizacao.Text), "yyyy-MM-dd") & "'"
        Else
            datCruza = "NULL"
        End If
        'Faz o mesmo para colheita
        If txtColheita.Text <> "  /  /" Then
            datColheita = "'" & Format(CDate(txtColheita.Text), "yyyy-MM-dd") & "'"
        Else
            datColheita = "NULL"
        End If
        'Lote e semeadura não precisam pois já são verificaso em Valida_Campos

        'Faz a verificação dos campos a serem preenchidos
        If Valida_Campos() Then
            'Se tiver algum repicador selecionado
            Dim varRepicador As String = String.Empty
            'Se tiver um repicador selecionado retorna
            If lstRepicador.SelectedItems.Count > 0 Then
                varRepicador = Texto_Vazio(valRepicador(lstRepicador))
            Else
                'Retorno null
                varRepicador = "NULL"
            End If

            'Monta a SQL
            SQL = "INSERT INTO germinacao SET "
            SQL &= "Cod='" & txtCodigo.Text & "',"
            SQL &= "Especie='" & txtEspecie.Text & "',"
            SQL &= "Polinizacao=" & datCruza & ","
            SQL &= "Colheita=" & datColheita & ","
            SQL &= "Descricao= '" & txtDescricao.Text & "',"
            SQL &= "Situacao='" & cmbSituacao.Text & "',"
            SQL &= "Estado='" & cmbEstado.Text & "',"
            SQL &= "Semeadura='" & Format(CDate(txtSemeadura.Text), "yyyy-MM-dd") & "',"
            SQL &= "Meio='" & cmbMeio.Text & "',"
            SQL &= "Cod_Meio=" & Meio & ","
            SQL &= "STATUS='Semeada',"
            SQL &= "lote='" & Format(CDate(txtLote.Text), "yyyy-MM-dd") & "',"
            SQL &= "NMudas=0,"
            SQL &= "NSementes=" & txtNFrascos.Text & ","
            SQL &= "NPlantadas=0,"
            SQL &= "Ativo=1,"
            SQL &= "frascos=" & txtNFrascos.Text & ","
            SQL &= "Cliente=" & Cliente & ","
            SQL &= "Repicador=" & varRepicador & ","
            SQL &= "MdsEsperado=" & txtEsperado.Text

            'Tenta executar a SQL
            Try
                'Debug
                Console.WriteLine(Me.Name & ": " & SQL)
                'Executa a SQL
                ExecutaSQL(SQL)
                MsgBox("Lote: " & txtCodigo.Text & " Incluído com sucesso", MsgBoxStyle.Information, "Confirmação")
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir o lote de germinação de orquídeas." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try

            'Pega o último id incluido
            LoteID = DMax("id", "germinacao")
            SQL = "INSERT INTO aux_germinacao (Lote,Tipo,NMudas,Vidro,Repicagem,Repicador) VALUES "
            For i = 1 To Val(txtNFrascos.Text)
                'se for a segunda passada já inclui uma virgula
                If i > 1 Then
                    SQL &= ","
                End If
                'Monta a SQL para inclusão de uma linha (Frasco)
                SQL &= "(" & LoteID & ",'S',0," & i & ",'" & Format(CDate(txtSemeadura.Text), "yy-MM-dd") & "'," & varRepicador & ")"
            Next

            'Tenta incluir os frascos de semeadura
            Try
                ExecutaSQL(SQL)
                'Debug
                Console.WriteLine(Me.Name & ": " & SQL)
                a = MsgBox("Deseja enviar as etiquetas deste lote para impressão?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
                If a = vbYes Then
                    'Impressão de etiquetas
                    Imprime_etiquetas(LoteID)
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir os frascos do lote: " & txtLote.Text & " (" & LoteID & ")" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try

            a = MsgBox("Deseja manter os dados do cliente?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")
            If a = vbNo Then
                'Executa a funçao que limpa todos os campos de um form
                Limpa_Campos(Me)
                'Move o foco para o código
                cmbClientes.Focus()
            Else
                'Limpa somente os campos comuns
                txtCodigo.Text = ""
                txtEspecie.Text = ""
                txtPolinizacao.Text = ""
                txtColheita.Text = ""
                txtDescricao.Text = ""
                txtNFrascos.Text = ""
                txtEsperado.Text = "0"
                'Move o foco para o código
                txtCodigo.Focus()
            End If

            
        End If
    End Sub

    Private Sub frmOrquideas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Faz o tratamento de teclas do VB e troca o Enter pelo Tab
        EnterAsTab(sender, e)
    End Sub

    Private Sub frmOrquideas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Usa a sub para preencher o combo com os dados da tabela
        Carrega_Lista(cmbMeio, "Meio", "id", "Meio")
        'Preenche a lista de Clientes
        Carrega_Lista(cmbClientes, "Clientes", "id", "Nome", True)
        'Preenche a lista de repicadores
        Carrega_Lista(lstRepicador, "Repicador", "id", "Nome", True, "ativo=1")
    End Sub

    Private Function Valida_Campos() As Boolean
        Dim Mensagem As String = String.Empty
        'Se não houver cliente selecionado
        If cmbClientes.Text = String.Empty Or cmbClientes.SelectedIndex = -1 Then
            Mensagem = Mensagem & "Cliente não informado" & vbCrLf
        End If
        'Codigo
        If txtCodigo.Text = String.Empty Then
            Mensagem = Mensagem & "Código da Cápsula não informado" & vbCrLf
        End If
        If txtLote.Text = "  /  /" Then
            Mensagem = Mensagem & "A data que identifica o Lote precisa ser informada" & vbCrLf
        End If
        If txtSemeadura.Text = "  /  /" Then
            Mensagem = Mensagem & "A data de semeadura precisa ser informada" & vbCrLf
        End If

        'Ao final verifica se existiram mensagens de erro
        If mensagem <> String.Empty Then
            MsgBox("Os seguintes erros foram detectados durante a tentativa de inclusão:" & vbCrLf & vbCrLf & Mensagem, MsgBoxStyle.Exclamation, "Aviso")
            Valida_Campos = False
        Else
            Valida_Campos = True
        End If

    End Function
    Private Sub Imprime_etiquetas(ByVal varID As Integer)
        'Variáveis especificas (mais organizado)
        Dim SQL As String, Parte As String = String.Empty, i As Integer, DT As DataTable
        Dim varCodBar As String = String.Empty
        Dim varLote As String = String.Empty
        Dim varEspecie As String = String.Empty
        Dim varDescri As String = String.Empty
        Dim varDataP As String = String.Empty
        Dim varDataC As String = String.Empty
        Dim varDataS As String = String.Empty
        Dim varDataR As String = String.Empty
        Dim varDataH As String = String.Empty
        Dim varFrasco As Integer = 0
        Dim varTemp As String = String.Empty
        Dim varNMudas As String = String.Empty

        'Verifica os dados comuns a todos os frascos
        'Dados em comum para todos os lotes
        varLote = txtCodigo.Text
        varEspecie = txtEspecie.Text
        varDescri = txtDescricao.Text

        'Verifica se a data da polinizaçao é nula
        If txtPolinizacao.Text = "  /  /" Then
            varDataP = "Null"
        Else
            varDataP = "'" & Format(CDate(txtPolinizacao.Text), "yyyy-MM-dd") & "'"
        End If

        'Verifica a data da Colheita
        If txtColheita.Text = "  /  /" Then
            varDataC = "Null"
        Else
            varDataC = "'" & Format(CDate(txtColheita.Text), "yyyy-MM-dd") & "'"
        End If

        'Verifica a data da semeadura
        If txtSemeadura.Text = "  /  /" Then
            varDataS = "Null"
        Else
            varDataS = "'" & Format(CDate(txtSemeadura.Text), "yyyy-MM-dd") & "'"

        End If

        SQL = "SELECT * FROM aux_germinacao WHERE Lote=" & varID & " ORDER BY vidro"

        'Recupera os frascos do BD
        DT = SQLQuery(SQL)

        'Monta a SQL padrão
        SQL = "INSERT INTO etiquetasorq_prn (codbar,dataH,lote,especie,dataC,dataS,descricao,dataR,Frasco,NMudas) VALUES "

        'Percorre todas as etiquetas incluindo no sistema
        For i = 0 To DT.Rows.Count - 1
            If i > 0 Then
                Parte &= ","
            End If
            With DT.Rows(i)
                'Pega o Código de Barras
                varCodBar = Format(.Item("id"), "00000")
                'Descricao do lote
                varLote = DLookup("Cod", "Germinacao", "id=" & .Item("Lote"))
                If IsNothing(varLote) Then
                    varLote = "Sem ID"
                End If
                'Numero de mudas
                varNMudas = .Item("Nmudas")
                'Numero do frasco
                varFrasco = .Item("Vidro")
                'Data da Repicagem
                varDataR = .Item("Repicagem")
            End With
            Parte &= "(" & varCodBar & "," & varDataC & ",'" & varLote & "','" & varEspecie & "'," & varDataP & "," & varDataS & ",'" & varDescri & "','" & varDataR & "'," & varFrasco & "," & varNMudas & ")"
        Next

        'Coloca os valores
        SQL &= Parte

        Try
            'Executa a SQL montada
            Console.WriteLine(Me.Name & ": " & SQL)
            ExecutaSQL(SQL)
            MsgBox(Format(i, "000") & " Etiquetas incluídas com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
        Catch ex As Exception
            MsgBox("Falha ao enviar as etiquetas para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub
End Class