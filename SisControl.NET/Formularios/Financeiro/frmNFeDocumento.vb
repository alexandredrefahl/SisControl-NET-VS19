'Imports MySql.Data.MySqlClient

Public Class frmNFeDocumento
    Dim DocID As Integer = 0, TipoDOC As UInt16 = 1
    Dim flagItens As Boolean, flag

    Sub New(Optional ByVal Tipo As UInt16 = 1, Optional ByVal Numero As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        'Tipo 1-Saída 0-Entrada 2-Pedido

        If Tipo = 2 Then
            TipoDOC = 1     'NFe de Saida
            If Numero <> 0 Then
                Carrega_Pedido(Numero)
            End If
        Else
            'Por padrão Tipo=1 que é saída
            TipoDOC = Tipo
            If Numero <> 0 Then
                DocID = Numero
            End If
        End If


    End Sub

    Private Sub frmDocSAI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'ENTER
        If e.KeyCode = 13 Then
            EnterAsTab(sender, e)
        End If
    End Sub

    Private Sub frmDocSAI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Numero da nota (alterado para pegar direto do Banco de Dados)
        'txtDocumento.Text = Val(My.Settings.NumNFE).ToString("000000000")
        Dim SQL As String, DT As DataTable
        SQL = "SELECT MAX(documento) AS NFe FROM docs WHERE Serie=" & My.Settings.NFeSerie
        DT = SQLQuery(SQL)
        If DT.Rows.Count > 0 Then
            'Pega o último valor no banco de dados
            txtDocumento.Text = Format(Int(NaoNulo(DT.Rows(0).Item("NFE"))) + 1, "000000000")
            'Libera memória
            DT = Nothing
            SQL = Nothing
        End If
        'Carrega as formas de pagamento
        Carrega_Lista(cmbForma, "Forpag", "id", "Descricao")
        Carrega_Lista(txtCliente, "Clientes", "id", "Nome", True)
        Carrega_Lista(cmbFrete, "transportadores", "id", "Razao", True)
        'Se o tipo for 1-Saída 0-Entrada
        If TipoDOC = 1 Then
            Me.Text = "Documento de Saída"
            btPedido.Enabled = True
        ElseIf TipoDOC = 0 Then
            Me.Text = "Documento de Entrada"
            btPedido.Enabled = False
        End If

        'Se foi fornecido algum número
        If DocID <> 0 Then
            Carrega_Documento()
            btIncluir.Text = "Salvar"
        Else
            'Acerta a Data
            txtData.Value = DateTime.Now.Date
        End If
    End Sub

    Private Sub Incluir_Documento()
        'Cria um objeto-classe documento
        Dim Documento As New dsDoc_Entrada_Saida

        'Preenche com os dados da inclusão Tabela principal
        With Documento.Tables("docs").Rows(0)   'Vai incluir
            .Item("cliente") = txtCliente.Text
            .Item("data") = txtData.Value
            .Item("codcli") = cmbVal(txtCliente)
            .Item("Endereco") = txtEndereco.Text
            .Item("num") = txtNumero.Text
        End With
    End Sub

    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        Dim varID As Integer = 0
        'Passa pela validação
        If ValidarNota() Then
            'Se estiver no modo de EDICAO
            If btIncluir.Text = "Salvar" Then
                'Desvia para rotina de salvar o DOcumento e sai da SUB
                Salva_Documento()
                Exit Sub
            End If

            Dim SQL_Docs As String = String.Empty

            'Monta a SQL aos pedaços
            SQL_Docs = "INSERT INTO Docs SET " & SQL_Campos()

            'Tentar substituir pelo TRANSACIONAL
            'Tenta fazer a inclusão da NF
            'Try
            'Executa a SQL
            'ExecutaSQL(SQL_Docs)
            'Se conseguir segue adiante
            'Catch ex As Exception
            'MsgBox("Erro ao tentar incluir o documento de " & IIf(TipoDOC = 1, "Saída", "Entrada") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            'Exit Sub
            'End Try

            '*
            '* INCLUSÃO DOS ÍTENS
            '*
            Dim varNCM As String, varICMS As Double = 0, varPIS As Double = 0, varCOFINS As Double = 0
            Dim i As Integer, ValorItem As Double = 0
            Dim SQL_Itens
            SQL_Itens = "INSERT INTO Docs_itens (Doc_ID,Item_Nota,CodPro,Clone,Descricao,NCM,Unid,Quantidade,Unitario,Total,CFOP,ICMS,PIS,COFINS,vICMS,vPIS,vCOFINS) VALUES "

            'Procede com a inclusão dos ítens do pedido
            For i = 0 To dgItens.Rows.Count - 1
                With dgItens.Rows(i)
                    'Quando for mais de uma linha tem que ter virgula entre os dados
                    If i > 0 Then
                        SQL_Itens = SQL_Itens & ","
                    End If
                    'Preenche as variáveis necessarias
                    varNCM = DLookup("NCM", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varICMS = DLookup("ICMS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varPIS = DLookup("PIS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varCOFINS = DLookup("Cofins", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    ValorItem = String_to_Numero(.Cells(8).Value)

                    If IsDBNull(varNCM) Then
                        MsgBox("NCM não cadastrado para esta mercadoria. Assumindo valor padrão.", MsgBoxStyle.Critical, "Erro")
                        varNCM = "06029029"
                    End If

                    'Monta a SQL
                    SQL_Itens &= "((SELECT MAX(id) FROM docs),"               'Pedido_Id
                    SQL_Itens &= i + 1 & ","                                  'Item da nota
                    SQL_Itens &= .Cells(1).Value & ","                        'CodPro
                    SQL_Itens &= Val(.Cells(2).Value) & ","                   'Clone
                    SQL_Itens &= "'" & .Cells(3).Value & "',"                 'Descricao
                    SQL_Itens &= "'" & varNCM & "',"                          'NCM
                    SQL_Itens &= "'UN',"                                      'Unidade
                    SQL_Itens &= Numero_to_SQL(.Cells(6).Value) & ","         'Quantidade
                    SQL_Itens &= Numero_to_SQL(.Cells(7).Value) & ","         'Unitário
                    SQL_Itens &= Numero_to_SQL(ValorItem) & ","               'Total
                    'SQL &= "'" & .Cells(7).Value.ToString.ToUpper & "'," 'Forma
                    'SQL &= "'" & .Cells(8).Value.ToString.ToUpper & "'," 'Tipo
                    SQL_Itens &= "'" & txtCFOP.Text & "',"                     'CFOP
                    SQL_Itens &= varICMS & ","                                 'Aliquota ICMS
                    SQL_Itens &= varPIS & ","                                  'Aliquota PIS
                    SQL_Itens &= varCOFINS & ","                               'Aliquota COFINS
                    SQL_Itens &= varICMS * ValorItem & ","                     'Valor ICMS
                    SQL_Itens &= varPIS * ValorItem & ","                      'Valor PIS
                    SQL_Itens &= varCOFINS * ValorItem & ")"                   'Valor cofins
                End With
            Next
            'Montada a SQL ela pode ser executada
            Console.WriteLine(Me.Name & " Itens:" & SQL_Itens)
            'ExecutaSQL(Sql) - SUBSTITUIDO PELO TRANSACIONAL

            '*
            '*  INSERE AS DUPLICATAS
            '*

            Dim SQL_Duplicatas As String = String.Empty

            If dgDuplicatas.Rows.Count > 0 Then
                SQL_Duplicatas = "INSERT INTO Duplicatas (Doc_ID,Vencimento,Valor,Descricao,formaPag) VALUES "
                For i = 0 To dgDuplicatas.Rows.Count - 1
                    With dgDuplicatas.Rows(i)
                        If i > 0 Then
                            'Se for a segunda tem que por a vírgula
                            SQL_Duplicatas &= ","
                        End If
                        SQL_Duplicatas &= "((SELECT MAX(id) FROM docs),"
                        SQL_Duplicatas &= "'" & Format(CDate(.Cells("Data").Value), "yyyy-MM-dd") & "',"
                        SQL_Duplicatas &= Numero_to_SQL(.Cells("Valor").Value) & ","
                        SQL_Duplicatas &= "'" & .Cells("Descricao").Value & "',"
                        SQL_Duplicatas &= "'" & .Cells("Forma").Value & "')"
                    End With
                Next
                'ExecutaSQL(Sql)    - SUBSTITUIDO PELO TRANSACIONAL
            End If
            Console.WriteLine(Me.Name & " Duplicatas:" & SQL_Duplicatas)
            '*
            '* INCLUSÃO DOS VOLUMES
            '*

            Dim SQL_Volumes As String = String.Empty

            If dgVolumes.Rows.Count > 0 Then
                SQL_Volumes = "INSERT INTO docs_volumes (Doc_ID,Volume,Largura,Altura,Profundidade,Peso) VALUES "
                For i = 0 To dgVolumes.Rows.Count - 2
                    With dgVolumes.Rows(i)
                        If i > 0 Then
                            'Se for a segunda tem que por a vírgula
                            SQL_Volumes &= ","
                        End If
                        SQL_Volumes &= "((SELECT MAX(id) FROM docs),"
                        SQL_Volumes &= .Cells(0).Value & ","
                        SQL_Volumes &= Numero_to_SQL(.Cells(1).Value) & ","
                        SQL_Volumes &= Numero_to_SQL(.Cells(2).Value) & ","
                        SQL_Volumes &= Numero_to_SQL(.Cells(3).Value) & ","
                        SQL_Volumes &= Numero_to_SQL(.Cells(4).Value) & ")"
                    End With
                Next
                'ExecutaSQL(Sql)    - SUBSTITUIDO PELO TRANSACIONAL
            End If
            Console.WriteLine(Me.Name & " Volumes:" & SQL_Volumes)


            'ExecutaSQL(Sql) - SUBSTITUIDO PELO TRANSACIONAL

            '****************************************************
            '**
            '** MONTA A INCLUSÃO POR TRANSAÇÃO
            '**
            '****************************************************
            Dim Comandos(3) As String   'Lembrar de Declarar o Array pelo UperBound Não pelo número de elementos!

            'Atribui cada SQL a um elemento do Array
            Comandos(0) = SQL_Docs
            Comandos(1) = SQL_Itens
            Comandos(2) = SQL_Duplicatas
            Comandos(3) = SQL_Volumes

            'Envia o arrai de comandos para a função que fará a transação
            If SQLTransacao(Comandos) Then
                'se retornar TRUE, ou seja deu tudo certo
                varID = DMax("id", "Docs")
                'Se deu certo atualiza os parametros
                Dim SQL_Parametros As String = String.Empty
                'Acrescenta um número à nota fiscal
                SQL_Parametros = "UPDATE Parametros SET Valor=" & CInt(txtDocumento.Text) + 1 & " WHERE Nome='NFeNum'"
                'Atualiza a numeração da NFe.
                ExecutaSQL(SQL_Parametros)
                MsgBox("Documento de Saída: " & txtDocumento.Text & " (" & varID.ToString & ")" & " e seus ítens incluidos com sucesso!" & vbCrLf & "Vá ao menu Financeiro -> NFe -> Emitir NFe, para enviar a nota", MsgBoxStyle.Information, "Aviso")
                'Se tem algum pedido registrado
                If txtNPedido.Text <> String.Empty Then
                    Dim a As Integer = MsgBox("Deseja Liquidar o Pedido Nº: " & txtNPedido.Text & "?", vbQuestion + MsgBoxStyle.YesNo)
                    'Se o usuário responder sim então
                    If a = vbYes Then
                        Liquida_Pedido(txtNPedido.Text)
                    End If
                End If
            Else
                'se retornar FALSE, ou seja, deu algum problema
                MsgBox("Erro na Transação de Inclusão do Documento de " & IIf(TipoDOC = 1, "Saída", "Entrada") & ": " & varID.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Liquida_Pedido(ByVal PedidoID As Integer)
        Dim DataEntrega As String

        'Pega a data da emissão da nota
        DataEntrega = txtData.Value
        'Se não estiver em branco
        If DataEntrega <> "" Then
            Dim SQL_Pedido As String
            'Atualização do pedido
            SQL_Pedido = "UPDATE Pedidos SET Status=4,DataEntregue='" & Format(CDate(DataEntrega), "yyyy-MM-dd") & "' WHERE id=" & PedidoID
            Dim SQL_Pedido_Itens
            'Atualização dos ítens
            SQL_Pedido_Itens = "UPDATE Pedidos_itens SET Atendido=Quantidade,Status=4 WHERE Pedido_id=" & PedidoID
            'Insere no controle de entregas
            Dim varCliente As String, SQL_Controle As String
            varCliente = cmbVal(txtCliente)
            'Define o controle de entregas
            SQL_Controle = "INSERT INTO Pedido_entregas (Cliente,id_Pedido,id_item,DATA,Quantidade) SELECT " & varCliente & " AS cliente, " & PedidoID & " AS id_pedido, id, '" & Format(CDate(DataEntrega), "yyyy-MM-dd") & "' AS DATA,Quantidade FROM Pedidos_itens WHERE Pedido_id=" & PedidoID

            'Monta o Array de Comandos para a transação
            Dim SQLs(2) As String   'Declarando o pedido pelo UpperBound

            SQLs(0) = SQL_Pedido
            SQLs(1) = SQL_Pedido_Itens
            SQLs(2) = SQL_Controle

            'Executa a transação e verifica se deu tudo certo
            If SQLTransacao(SQLs) Then
                MsgBox("Pedido Nº " & Format(PedidoID, "00000") & " liquidado com sucesso!", MsgBoxStyle.Information, "Confirmação")
            Else
                MsgBox("Erro ao liquidar o pedido Nº " & Format(PedidoID, "00000"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            End If
        End If


    End Sub

    Private Sub btPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPedido.Click
        Dim Pedido As String

        'Pede que digite um pedido
        Pedido = InputBox("Entre com o número do pedido", "Copiar Pedido")
        'Se o usuário cancelou e não digigou nada
        If Pedido = "" Then
            Exit Sub
        Else
            'Carrega o pedido selecionado
            Carrega_Pedido(Pedido)
        End If
    End Sub

    Private Sub Carrega_Pedido(ByVal Pedido As String)
        Dim SQL As String, DT As DataTable

        'Se passou adiante deixa o programa procurar o pedido
        SQL = "SELECT * FROM Pedidos WHERE id=" & Val(Pedido).ToString
        Try
            DT = SQLQuery(SQL)
            'Se localizou o pedido
            If DT.Rows.Count > 0 Then
                With DT.Rows(0)
                    'Atualiza os campos de acordo com o valor do pedido
                    txtCFOP.Text = NaoNulo(.Item("CFOP"))
                    txtNatOP.Text = NaoNulo(.Item("NaturezaOP"))
                    txtCliente.Text = NaoNulo(.Item("Cliente"))
                    txtEndereco.Text = NaoNulo(.Item("Endereco"))
                    txtNumero.Text = NaoNulo(.Item("Num"))
                    txtBairro.Text = NaoNulo(.Item("Bairro"))
                    txtCidade.Text = NaoNulo(.Item("Cidade"))
                    txtCodMun.Text = NaoNulo(.Item("CodCidade"))
                    txtEstado.Text = NaoNulo(.Item("Estado"))
                    txtCEP.Text = NaoNulo(.Item("CEP"))
                    txtPais.Text = NaoNulo(.Item("Pais"))
                    txtCodPais.Text = NaoNulo(.Item("codPais"))
                    txtFone.Text = NaoNulo(.Item("Fone"))
                    txtEmail.Text = NaoNulo(.Item("email"))
                    txtCPF_CNPJ.Text = Limpa_Formatacao(.Item("CNPJ_CPF"))
                    If .Item("PFPJ") = "F" Then
                        rdPF.Checked = True
                        rdPJ.Checked = False
                        Label13.Text = "CPF:"
                    Else
                        rdPF.Checked = False
                        rdPJ.Checked = True
                        Label13.Text = "CNPJ:"
                    End If
                    txtInscricao.Text = Limpa_Formatacao(NaoNulo(.Item("Inscricao")))
                    txtContato.Text = NaoNulo(.Item("Contato"))
                    txtVendedor.Text = NaoNulo(.Item("Vendedor"))
                    txtNPedido.Text = Format(Val(.Item("ID")), "0000")
                    cmbModFrete.SelectedIndex = Val(.Item("ModFrete")) - 1
                    txtvFrete.Text = Format(Val(.Item("ValFrete")), "N2")
                    txtvSeg.Text = Format(Val(.Item("valSeguro")), "N2")
                    txtvDesc.Text = Format(Val(.Item("ValDesconto")), "N2")
                    Localiza_Item(cmbForma, .Item("Forpag"))

                    'Localiza os ítens
                    Dim DT1 As DataTable
                    SQL = "SELECT id,CodPro,Clone,Descricao,NCM,Unid,Quantidade,Unitario,Total FROM Pedidos_itens WHERE Pedido_id=" & Val(Pedido) & " ORDER BY id"

                    Try
                        DT1 = SQLQuery(SQL)
                        Dim i As Integer = 0
                        'Se houverem itens cadastrados
                        If DT1.Rows.Count > 0 Then
                            For i = 0 To DT1.Rows.Count - 1
                                With DT1.Rows(i)
                                    Dim varNCM As String
                                    'Se o NCM não tiver no cadastro
                                    If IsDBNull(.Item("NCM")) Then
                                        varNCM = InputBox("Entre com o NCM do ítem: " & .Item("Descricao"), "Código NCM")
                                    Else
                                        varNCM = .Item("NCM")
                                    End If
                                    dgItens.Rows.Add(.Item("id"), .Item("CodPro"), .Item("Clone"), .Item("Descricao"), varNCM, .Item("Unid"), .Item("Quantidade"), .Item("Unitario"), .Item("Total"))
                                End With
                            Next
                        End If
                        'Libera Memoria
                        DT1.Dispose()
                    Catch ex As Exception
                        MsgBox("Erro ao tentar localizar os ítens do pedido nº " & Pedido & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try
                    'Localiza as parcelas
                    Dim DT2 As DataTable
                    SQL = "SELECT id,Vencimento,Valor,Descricao FROM Duplicatas WHERE Pedido_id=" & Val(Pedido)
                    Try
                        DT2 = SQLQuery(SQL)
                        Dim j As Integer
                        'Se houveram parcelas cadastradas no pedido
                        If DT2.Rows.Count > 0 Then
                            For j = 0 To DT2.Rows.Count - 1
                                With DT2.Rows(j)
                                    dgDuplicatas.Rows.Add(Format(CDate(.Item("Vencimento")), "dd/MM/yy"), Val(.Item("Valor")), .Item("Descricao"))
                                End With
                            Next
                        End If
                        DT2.Dispose()
                    Catch ex As Exception
                        MsgBox("Erro ao tentar localizar as duplicatas do pedido nº " & Pedido & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try
                End With
                'Rotina que atualiza os totais da NF
                Atualiza_Totais()
            End If
        Catch ex As Exception
            MsgBox("Erro ao recuperar dados do pedido nº " & Pedido & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub txtCodPro_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodPro.Leave
        Dim Texto As String
        'Se estiver vazio não pesquisa
        If txtCodPro.Text = String.Empty Then
            'sai da sub
            Exit Sub
        End If
        'Tenta localizar
        Try
            Texto = DLookup("Cientifico", "Mercadoria", "ID=" & txtCodPro.Text)
            lblMercadoria.Text = Texto
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar a mercadoria" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub txtClone_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClone.Leave
        Dim Texto As String
        'Se tiver vazio não pesquisa
        If txtClone.Text = String.Empty Then
            'Sai da Sub
            Exit Sub
        End If
        Try
            txtClone.Text = StrZero(txtClone.Text, 4)
            Texto = DLookup("Nome", "Clones", "(Mercadoria=" & txtCodPro.Text & ") AND (Clone=" & txtClone.Text & ")")
            lblClone.Text = Texto
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar a mercadoria" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub cmbPadrao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPadrao.SelectedIndexChanged
        'Se não houver os códigos digitados evita o erro de não localizar a mercadoria
        If txtCodPro.Text = "" Or txtClone.Text = "" Then
            Exit Sub
        End If

        'Se não tiver nada selecionado
        If cmbPadrao.SelectedIndex = -1 Then
            Exit Sub
        End If

        'Verifica qual o tipo da muda e já busca o preço
        Dim Preco As Double = 0
        Select Case cmbPadrao.Text.Substring(0, 2)
            Case "In"   'In Vitro
                Preco = DLookup("Pr_InVitro", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            Case "Pr"   'Pré Aclimatizada
                Preco = DLookup("Pr_PreAclim", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            Case "Ac"   'Aclimatizada
                Preco = DLookup("Pr_Aclimatada", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            Case "Ad"   'Adulta
                Preco = DLookup("Pr_Adulta", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            Case Else
                Preco = 0
        End Select
        'Se não retornar um valor nulo
        If Not IsDBNull(Preco) Then
            'Formata o texto como Numerico 2 
            'txtValor.Text = Format(Preco, "#0.00")
            txtValor.Text = Format(Preco, "N2")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim varID As Integer, varCP As Integer, varCC As Integer, varDesc As String, varNCM As String, varQtde As Integer, varUnit As Double, varTot As Double

        'tem que estar tudo preenchido
        If txtCodPro.Text <> "" And txtClone.Text <> "" And txtQtde.Text <> "" And txtValor.Text <> "" Then
            'monta o Array para inclusão
            varID = 0   'Todos os produtos adicionados depois ganham id=0
            varCP = txtCodPro.Text  'Código do produto
            varCC = txtClone.Text  'Cod Clone
            varDesc = lblMercadoria.Text & " cv " & lblClone.Text
            varNCM = DLookup("NCM", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            varQtde = String_to_Numero(txtQtde.Text)
            varUnit = String_to_Numero(txtValor.Text)
            varTot = varQtde * varUnit
        Else
            MsgBox("Para incluir um ítem ao Documento de Saída complete:" & vbCrLf & "Mercadoria, Clone, Quantidade, Valor Unitário", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
        Try
            'faz a inclusão propriamente dita
            dgItens.Rows.Add(varID, varCP, varCC, varDesc, varNCM, "md", varQtde, varUnit, varTot)
            txtCodPro.Text = String.Empty
            txtClone.Text = String.Empty
            txtQtde.Text = String.Empty
            txtValor.Text = String.Empty
            lblMercadoria.Text = "---"
            lblClone.Text = "---"
            Atualiza_Totais()
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir o ítem no Documento de Saída" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub dgItens_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItens.CellEndEdit
        'Se forem alterados alguns valores recalcular
        If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            dgItens.Rows(e.RowIndex).Cells(8).Value = Val(dgItens.Rows(e.RowIndex).Cells(6).Value) * String_to_Numero(dgItens.Rows(e.RowIndex).Cells(7).Value)
        End If
        Atualiza_Totais()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Tem certeza que deseja Cancelar?", MsgBoxStyle.YesNo, "Confirmação") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub txtvFrete_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvFrete.Leave
        txtvFrete.Text = Format(String_to_Numero(txtvFrete.Text), "N2")
        Atualiza_Totais()
    End Sub

    Private Sub txtvSeg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvSeg.Leave
        txtvSeg.Text = Format(String_to_Numero(txtvSeg.Text), "N2")
        Atualiza_Totais()
    End Sub

    Private Sub txtvDesc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvDesc.Leave
        txtvDesc.Text = Format(String_to_Numero(txtvDesc.Text), "N2")
        Atualiza_Totais()
    End Sub

    Private Sub txtDespesas_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDespesas.Leave
        txtDespesas.Text = Format(String_to_Numero(txtDespesas.Text), "N2")
        Atualiza_Totais()
    End Sub

    Private Sub txtCFOP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCFOP.Leave
        If txtCFOP.Text.IndexOf(".") > 0 Then
            txtCFOP.Text.Replace(".", "")
        End If
        If txtCFOP.Text.Length = 4 Then
            txtNatOP.Text = DLookup("Descricao", "CFOP", "CFOP='" & txtCFOP.Text & "'")
        End If
    End Sub

    Private Sub cmbForma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForma.SelectedIndexChanged
        Dim Vencimentos As String = String.Empty, Porcentagens As String = String.Empty
        Dim vetVenc() As String, vetPorc() As String, i As Integer = 0
        'Se houver algo selecionado
        If cmbForma.SelectedIndex <> -1 Then
            'Pega no banco de dados os vencimentos e porcentagens de cada parcela
            Vencimentos = DLookup("Vencimentos", "Forpag", "id=" & cmbVal(cmbForma))
            Porcentagens = DLookup("Porcentagem", "forpag", "Id=" & cmbVal(cmbForma))
            'Divide em partes
            vetVenc = Split(Vencimentos, ";")
            vetPorc = Split(Porcentagens, ";")
            dgDuplicatas.Rows.Clear()
            'Para cada parcela cria uma duplicata
            For i = 0 To vetVenc.Length - 1
                'Tenta incluir as parcelas
                Try
                    'Tenta fazer a inclusão das parcelas
                    dgDuplicatas.Rows.Add(Format(CDate(txtData.Text).AddDays(vetVenc(i)), "dd/MM/yyyy"), String_to_Numero(lblTotPedido.Text) * Val(vetPorc(i)) / 100, "Parc. " & i + 1 & "/" & vetVenc.Length.ToString, cmbFormaPag.Text.Substring(0, 2))
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir as duplicadas de forma automática!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            Next
            Atualiza_Totais()
        End If
    End Sub

    Private Sub txtCidade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCidade.LostFocus
        'quando muda coloca o codigo do municipi
        If txtCidade.SelectedIndex <> -1 Then
            txtCodMun.Text = cmbVal(txtCidade)
        End If
    End Sub

    Private Sub txtEstado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstado.LostFocus
        'Preenche o combobox com o nome dos municipios 
        If txtEstado.Text.Length = 2 Then
            Carrega_Lista(txtCidade, "Rais", "Cod", "Municipio", True, "Estado='" & txtEstado.Text & "'")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Calcula o peso baseado nos peso dos ítens
        If dgItens.RowCount <= 0 Then
            MsgBox("Não existem itens no documento de saída. Não é possível calcular o peso!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        Dim i As Integer, pesoitem As Double = 0, PesoTotal As Double = 0

        Try
            'Se existirem itens
            For i = 0 To dgItens.RowCount - 1
                With dgItens.Rows(i)
                    'consulta no Banco de Dados o peso individual
                    pesoitem = DLookup("Peso", "Clones", "Mercadoria=" & .Cells(1).Value & " AND Clone=" & .Cells(2).Value)
                    'Multiplica o peso individual por N Mudas
                    PesoTotal += (pesoitem * .Cells(6).Value)
                End With
            Next
        Catch ex As Exception
            MsgBox("Erro ao tentar calcular o peso da mercadoria!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        txtPesoB.Text = Format(PesoTotal, "N3")
        txtPesoL.Text = Format(PesoTotal, "N3")
    End Sub

    '*
    '*
    '* OPERAÇÕES COM O DOCUMENTO
    '*
    '*

    ' *** Função que carrega o documento
    Private Sub Carrega_Documento()
        btIncluir.Text = "Salvar"
        Dim SQL As String, DT As DataTable

        'Se passou adiante deixa o programa procurar o pedido
        SQL = "SELECT * FROM Docs WHERE id=" & DocID
        Try
            DT = SQLQuery(SQL)
            'Se localizou o pedido
            If DT.Rows.Count > 0 Then
                With DT.Rows(0)
                    'Atualiza os campos de acordo com o valor do pedido
                    '*
                    '* DADOS DO CLIENTE
                    '* 
                    txtCFOP.Text = .Item("CFOP")
                    txtNatOP.Text = .Item("NatOP")
                    txtCliente.Text = .Item("Cliente")
                    txtEndereco.Text = .Item("Endereco")
                    txtNumero.Text = .Item("Num")
                    txtBairro.Text = .Item("Bairro")
                    txtCidade.Text = .Item("Cidade")
                    txtCodMun.Text = .Item("CodCidade")
                    txtEstado.Text = .Item("Estado")
                    txtCEP.Text = .Item("CEP")
                    txtPais.Text = .Item("Pais")
                    txtCodPais.Text = .Item("codPais")
                    txtFone.Text = .Item("Fone")
                    txtEmail.Text = .Item("email")
                    txtCPF_CNPJ.Text = Limpa_Formatacao(.Item("CNPJ_CPF"))
                    If .Item("PFPJ") = "F" Then
                        rdPF.Checked = True
                        rdPJ.Checked = False
                        Label13.Text = "CPF:"
                    Else
                        rdPF.Checked = False
                        rdPJ.Checked = True
                        Label13.Text = "CNPJ:"
                    End If
                    txtInscricao.Text = Limpa_Formatacao(.Item("Inscricao"))
                    txtContato.Text = .Item("Contato")
                    txtVendedor.Text = .Item("Vendedor")
                    txtNPedido.Text = Format(Val(.Item("ID")), "0000")
                    'Novos campos da NFe 3.10
                    txtrefNFe.Text = NaoNulo(.Item("refNFE"))
                    txtInfAdFisco.Text = NaoNulo(.Item("infAdFisco"))
                    txtIndPres.Text = .Item("indPres")
                    txtindIEDest.Text = .Item("indIEDest")


                    '*
                    '*  DADOS DO FRETE
                    '*
                    cmbModFrete.SelectedIndex = .Item("ModFr")
                    txtvFrete.Text = Format(Val(.Item("vFrete")), "N2")
                    cmbFrete.Text = NaoNulo(.Item("Transportadora"))
                    txtTraCNPJ.Text = NaoNulo(.Item("traCNPJ"))
                    txtTraIE.Text = NaoNulo(.Item("Traie"))
                    txtTraEndereco.Text = NaoNulo(.Item("traEndereco"))
                    txtTraMun.Text = NaoNulo(.Item("TraMunicipio"))
                    txtTraUF.Text = NaoNulo(.Item("trauf"))
                    txtVeiPlaca.Text = NaoNulo(.Item("veiPlaca"))
                    txtVeiUF.Text = NaoNulo(.Item("veiUF"))
                    txtTraQtde.Text = NaoNulo(.Item("traQtde"))
                    txtTraEspecie.Text = NaoNulo(.Item("traEspecie"))
                    txtTraNum.Text = NaoNulo(.Item("traNumeracao"))
                    '*
                    '* VALORES E PAGAMENTOS
                    '*
                    txtvSeg.Text = Format(Val(.Item("vSeg")), "N2")
                    txtvDesc.Text = Format(Val(.Item("vDesc")), "N2")
                    Localiza_Item(cmbForma, .Item("FormaPgto"))
                    TipoDOC = .Item("TipoDoc")

                    'Localiza os ítens
                    Dim DT1 As DataTable
                    SQL = "SELECT id,CodPro,Clone,Descricao,NCM,Unid,Quantidade,Unitario,Total FROM Docs_itens WHERE Doc_id=" & DocID

                    Try
                        DT1 = SQLQuery(SQL)
                        Dim i As Integer = 0
                        'Se houverem itens cadastrados
                        If DT1.Rows.Count > 0 Then
                            For i = 0 To DT1.Rows.Count - 1
                                With DT1.Rows(i)
                                    dgItens.Rows.Add(.Item("id"), .Item("CodPro"), .Item("Clone"), .Item("Descricao"), .Item("NCM"), .Item("Unid"), .Item("Quantidade"), .Item("Unitario"), .Item("Total"))
                                End With
                            Next
                        End If
                        'Libera Memoria
                        DT1.Dispose()
                    Catch ex As Exception
                        MsgBox("Erro ao tentar localizar os ítens do Documento nº " & DocID & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try
                    'Localiza as parcelas
                    Dim DT2 As DataTable
                    SQL = "SELECT id,Vencimento,Valor,Descricao FROM Duplicatas WHERE Doc_id=" & DocID
                    Try
                        DT2 = SQLQuery(SQL)
                        Dim j As Integer
                        'Se houveram parcelas cadastradas no pedido
                        If DT2.Rows.Count > 0 Then
                            'Limpa o Datagrid antes de chamar
                            dgDuplicatas.Rows.Clear()
                            For j = 0 To DT2.Rows.Count - 1
                                With DT2.Rows(j)
                                    dgDuplicatas.Rows.Add(Format(CDate(.Item("Vencimento")), "dd/MM/yy"), Val(.Item("Valor")), .Item("Descricao"))
                                End With
                            Next
                        End If
                        DT2.Dispose()
                    Catch ex As Exception
                        MsgBox("Erro ao tentar localizar as duplicatas do Documento nº " & DocID & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                        Exit Sub
                    End Try
                End With
                'Rotina que atualiza os totais da NF
                Atualiza_Totais()
            End If
        Catch ex As Exception
            MsgBox("Erro ao recuperar dados do Documento nº " & DocID & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    ' *** Função de salva o documento
    Private Sub Salva_Documento()
        Dim SQL As String = String.Empty

        'Monta a SQL aos pedaços
        SQL = "UPDATE Docs SET " & SQL_Campos() & " WHERE id=" & DocID

        'Tenta fazer a inclusão da NF
        Try
            'Executa a SQL
            ExecutaSQL(SQL)
            'Se conseguir segue adiante
        Catch ex As Exception
            MsgBox("Erro ao tentar Atualizar o Documento de " & IIf(TipoDOC = 1, "Saída", "Entrada") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        '*
        '* ALTERACAO DOS ÍTENS
        '*

        Dim varNCM As String, varICMS As Double = 0, varPIS As Double = 0, varCOFINS As Double = 0
        Dim i As Integer, ValorItem As Double = 0
        Dim SQL_INSERT As String = String.Empty                 'Simples porque só vai ter uma
        Dim CT As Integer = 0

        'Monta as bases das duas SQL
        SQL_INSERT = SQL = "INSERT INTO Docs_itens (Doc_ID,Item_Nota,CodPro,Clone,Descricao,NCM,Unid,Quantidade,Unitario,Total,CFOP,ICMS,PIS,COFINS,vICMS,vPIS,vCOFINS) VALUES "

        Try
            'apaga todos os ítens e recoloca eles novamente
            SQL = "DELETE FROM Docs_itens WHERE doc_id=" & DocID
            ExecutaSQL(SQL)
            'Verifica item a item
            For i = 0 To dgItens.RowCount - 1
                'com os dados dos itens
                With dgItens.Rows(i)
                    'Se for um ítem novo então acrescenta na SQL de inclusão
                    'Quando for mais de uma linha tem que ter virgula entre os dados
                    If i > 0 Then
                        SQL = SQL & ","
                    End If
                    'Preenche as variáveis necessarias
                    varNCM = DLookup("NCM", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varICMS = DLookup("ICMS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varPIS = DLookup("PIS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    varCOFINS = DLookup("Cofins", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                    ValorItem = String_to_Numero(.Cells(8).Value)

                    'Monta a SQL
                    SQL_INSERT &= "(" & DocID.ToString & ","                   'iddoDocumento
                    SQL_INSERT &= i + 1 & ","                                  'Item da nota
                    SQL_INSERT &= .Cells(1).Value & ","                        'CodPro
                    SQL_INSERT &= Val(.Cells(2).Value) & ","                   'Clone
                    SQL_INSERT &= "'" & .Cells(3).Value & "',"                 'Descricao
                    SQL_INSERT &= "'" & varNCM & "',"                          'NCM
                    SQL_INSERT &= "'UN',"                                      'Unidade
                    SQL_INSERT &= Numero_to_SQL(.Cells(6).Value.ToString) & "," 'Quantidade
                    SQL_INSERT &= Numero_to_SQL(.Cells(7).Value.ToString) & "," 'Unitário
                    SQL_INSERT &= Numero_to_SQL(ValorItem) & ","                              'Total
                    SQL_INSERT &= "'" & txtCFOP.Text & "',"                     'CFOP
                    SQL_INSERT &= varICMS & ","                                 'Aliquota ICMS
                    SQL_INSERT &= varPIS & ","                                  'Aliquota PIS
                    SQL_INSERT &= varCOFINS & ","                               'Aliquota COFINS
                    SQL_INSERT &= varICMS * ValorItem & ","                     'Valor ICMS
                    SQL_INSERT &= varPIS * ValorItem & ","                      'Valor PIS
                    SQL_INSERT &= varCOFINS * ValorItem & ")"                   'Valor cofins
                End With
            Next
        Catch ex As Exception
            MsgBox("Erro ao tentar montar a SQL para atualização dos ítens do Documento: " & Format(DocID, "000000") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        'Agora tenta executar estas SQLs
        Try
            'Tenta inclur os itens novos
            Console.WriteLine(Me.Name & " Itens:" & SQL_INSERT)
            ExecutaSQL(SQL_INSERT)
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir/atualizar os ítens do Documento: " & Format(DocID, "000000") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        '*
        '* ATUALIZA AS DUPLICATAS
        '*

        'Remove todas as duplicadas existentes e acrescenta novas
        SQL = "DELETE FROM Duplicatas WHERE Doc_id=" & DocID
        ExecutaSQL(SQL)

        If dgDuplicatas.Rows.Count > 0 Then
            SQL = "INSERT INTO Duplicatas (Doc_ID,Vencimento,Valor,Descricao) VALUES "
            For i = 0 To dgDuplicatas.Rows.Count - 1
                With dgDuplicatas.Rows(i)
                    If i > 0 Then
                        'Se for a segunda tem que por a vírgula
                        SQL &= ","
                    End If
                    SQL &= "(" & DocID.ToString & ","
                    SQL &= "'" & Format(CDate(.Cells("Data").Value), "yyyy-MM-dd") & "',"
                    SQL &= String_to_Numero(.Cells("Valor").Value) & ","
                    SQL &= "'" & .Cells("Descricao").Value & "')"
                End With
            Next
            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar as duplicatas do Documento: " & Format(DocID, "000000") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub '
            End Try

        End If
        MsgBox("Documento de " & IIf(TipoDOC = 1, "Saída", "Entrada") & ": " & txtDocumento.Text & " (" & DocID.ToString & ")" & " e seus ítens alterados com sucesso!", MsgBoxStyle.Information, "Confirmação")
    End Sub

    '*
    '*
    '*  FUNCOES AUXILIARES
    '*
    '*

    'Monta a SQL para inclusão ou alteração dos dados
    Private Function SQL_Campos() As String
        Dim SQL As String = String.Empty

        'Esta SQL serve tanto para INSERT como para UPDATE
        SQL &= "Data='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',"
        SQL &= "Cliente='" & txtCliente.Text & "',"
        SQL &= "CodCli=" & cmbVal(txtCliente) & ","
        SQL &= "Endereco='" & txtEndereco.Text & "',"
        SQL &= "Num='" & txtNumero.Text & "',"
        SQL &= "Bairro='" & txtBairro.Text & "',"
        SQL &= "Cidade='" & txtCidade.Text & "',"
        SQL &= "CodCidade='" & txtCodMun.Text & "',"
        SQL &= "Estado='" & txtEstado.Text & "',"
        SQL &= "Cep='" & txtCEP.Text & "',"
        SQL &= "Pais='" & txtPais.Text & "',"
        SQL &= "CodPais='" & txtCodPais.Text & "',"
        SQL &= "Fone=" & Texto_Vazio(txtFone.Text) & ","
        SQL &= "PFPJ='" & IIf(rdPJ.Checked, "J", "F") & "',"
        SQL &= "CNPJ_CPF='" & txtCPF_CNPJ.Text & "',"
        SQL &= "email=" & Texto_Vazio(txtEmail.Text) & ","
        SQL &= "inscricao='" & txtInscricao.Text & "',"
        SQL &= "Contato=" & Texto_Vazio(txtContato.Text) & ","
        SQL &= "vProd=" & Numero_to_SQL(lblMercadorias.Text) & ","
        SQL &= "vFrete=" & Numero_to_SQL(lblFrete.Text) & ","
        SQL &= "vSeg=" & Numero_to_SQL(txtvSeg.Text) & ","
        SQL &= "vDesc=" & Numero_to_SQL(txtvDesc.Text) & ","
        SQL &= "vDespesas=" & Numero_to_SQL(txtDespesas.Text) & ","
        SQL &= "vTotal=" & Numero_to_SQL(lblTotPedido.Text) & ","
        SQL &= "nMudas=" & String_to_Numero(txtNMudas.Text) & ","
        SQL &= "nItens=" & dgItens.RowCount & ","
        SQL &= "EspItens=" & Texto_Vazio(txtEspecieVol.Text) & ","
        SQL &= "PesoBruto=" & Numero_to_SQL(txtPesoB.Text) & ","
        SQL &= "PesoLiquido=" & Numero_to_SQL(txtPesoL.Text) & ","
        SQL &= "Tipo='" & txtTipo.Text.Substring(0, 1) & "',"
        SQL &= "Serie='" & txtSerie.Text & "',"
        SQL &= "Documento='" & txtDocumento.Text & "',"
        SQL &= "numPedido=" & Texto_Vazio(txtNPedido.Text) & ","
        SQL &= "CFOP='" & txtCFOP.Text & "',"
        SQL &= "NatOP='" & txtNatOP.Text & "',"
        SQL &= "ModFr=" & cmbModFrete.Text.Substring(0, 1) & ","
        SQL &= "FormaPgto=" & cmbVal(cmbForma) & ","
        SQL &= "Vendedor=" & Texto_Vazio(txtVendedor.Text) & ","
        SQL &= "veiUF=" & Texto_Vazio(txtVeiUF.Text) & ","
        SQL &= "veiPlaca=" & IIf(txtVeiPlaca.Text = "   -", "NULL", "'" & txtVeiPlaca.Text & "'") & ","
        SQL &= "Transportadora=" & Texto_Vazio(cmbFrete.Text) & ","
        SQL &= "traCNPJ=" & Texto_Vazio(txtTraCNPJ.Text) & ","
        SQL &= "traEndereco=" & Texto_Vazio(txtTraEndereco.Text) & ","
        SQL &= "traMunicipio=" & Texto_Vazio(txtTraMun.Text) & ","
        SQL &= "traUF=" & Texto_Vazio(txtTraUF.Text) & ","
        SQL &= "traQtde=" & Texto_Vazio(txtTraQtde.Text) & ","
        SQL &= "traEspecie=" & Texto_Vazio(txtTraEspecie.Text) & ","
        SQL &= "traNumeracao=" & Texto_Vazio(txtTraNum.Text) & ","
        SQL &= "Obs=" & Texto_Vazio(txtObs.Text) & ","
        SQL &= "TipoDOC=" & TipoDOC & ","
        SQL &= "infAdFisco=" & Texto_Vazio(txtInfAdFisco.Text) & ","
        SQL &= "refNFE=" & Texto_Vazio(txtrefNFe.Text) & ","
        SQL &= "indPres=" & txtIndPres.Text.Substring(0, 1) & ","
        SQL &= "indIEDest=" & txtindIEDest.Text.Substring(0, 1)
        Return SQL

    End Function

    'Atualiza os totais baseado nas tabelas
    Private Sub Atualiza_Totais()
        Dim i As Integer, varTotal As Double = 0, varMudas As Integer = 0, TotalGeral As Double = 0
        'Se tiver mais de uma linha faz os totais
        If dgItens.Rows.Count > 0 Then
            'passa por todas as linhas somando as mudas e o total
            For i = 0 To dgItens.Rows.Count - 1
                '4 e 6
                varTotal = varTotal + String_to_Numero(dgItens.Rows(i).Cells(8).Value)
                varMudas = varMudas + String_to_Numero(dgItens.Rows(i).Cells(6).Value)
            Next
            'Preenche o campo com o total do pedido
            txtTotal.Text = Format(varTotal, "N2")

            'Preenche o numero total de mudas
            txtNMudas.Text = Format(varMudas, "N0")
        End If

        'Calcula o resumo do pedido
        lblMercadorias.Text = txtTotal.Text
        'Atualiza o valor do frete no resumo
        lblFrete.Text = txtvFrete.Text
        'Atualiza o valor do seguro
        lblDespesas.Text = txtvSeg.Text
        'Atualiza o valor do desconto
        lblDescontos.Text = txtvDesc.Text
        'Atualizar o valor das despesas
        lblDespesas.Text = txtDespesas.Text
        'Seguro
        lblSeguro.Text = txtvSeg.Text

        'Mercadorias + frete + despesas + Seguro
        TotalGeral = varTotal + String_to_Numero(lblFrete.Text) + String_to_Numero(lblDespesas.Text) + String_to_Numero(lblSeguro.Text)
        'Impostos
        TotalGeral += String_to_Numero(lblImpostos.Text)
        'Descontos
        TotalGeral -= String_to_Numero(lblDescontos.Text)
        'A rotina converte_numero já retorna o string recebido como double
        lblTotPedido.Text = Format(TotalGeral, "N2")

        If dgDuplicatas.Rows.Count > 0 Then
            Dim valDup As Double = 0
            'Verifica as duplicatas
            For i = 0 To dgDuplicatas.Rows.Count - 1
                valDup += String_to_Numero(dgDuplicatas.Rows(i).Cells("Valor").Value)
            Next
            txtValDup.Text = Format(valDup, "N2")
        End If
    End Sub

    'Valida os campos da NF
    Private Function ValidarNota() As Boolean
        'Faz a validação dos campos
        Dim Msg As String = String.Empty

        If Double.Parse(txtPesoB.Text) <= 0 Or Double.Parse(txtPesoL.Text) <= 0 Then
            Msg &= "Peso não foi calculado" & vbCrLf
        End If

        If txtSerie.Text = "" Then
            Msg &= "Nº da Série em Branco" & vbCrLf
        End If

        If txtDocumento.Text = "" Then
            Msg &= "Nº do Documento em Branco" & vbCrLf
        End If

        'Se for consumidor final e a Nota for do tipo 1-Normal
        If txtindIEDest.Text.Substring(0, 1) = 9 And txtTipo.Text.Substring(0, 1) = 1 Then
            If txtCFOP.Text <> "5101" And txtCFOP.Text <> "6107" Then
                'Se for consumidor final e o CFOP estiver errado alerta
                Msg &= "CFOP não condiz com consumidor final." & vbCrLf
            End If
            If txtInscricao.Text.Length > 0 Then
                'Se digitou inscição estadual
                Msg &= "Não digitar Incrição Estadual para consumidor Final" & vbCrLf
            End If
        End If

        'Outras validações de CFOP
        If txtCFOP.Text = "" Then
            Msg &= "CFOP em Branco" & vbCrLf
        ElseIf txtEstado.Text <> "SC" And txtCFOP.Text.Substring(0, 1) = 5 Then
            Msg &= "CFOP incompatível com venda fora do estado" & vbCrLf
        ElseIf txtCFOP.Text.IndexOf(".") > 0 Then
            Msg &= "Digite o CFOP sem a pontuação" & vbCrLf
        ElseIf txtCFOP.Text.Length() > 4 Then
            Msg &= "CFOP com muitos caracteres, use o padrão de 4 dígitos" & vbCrLf
        End If

        'Validação para CFOP do Estado
        If txtEstado.Text = "SC" Then
            '1 - Saída
            If TipoDOC = 1 And (txtCFOP.Text.Substring(0, 1) <> 5) Then
                Msg &= "CFOP incompatível com Operação dentro do Estado (5XXX)" & vbCrLf
            End If
            '0 - Entrada
            If TipoDOC = 0 And (txtCFOP.Text.Substring(0, 1) <> 1) Then
                Msg &= "CFOP incompatível com Operação dentro do Estado (2XXX)" & vbCrLf
            End If
        End If
        If txtEstado.Text <> "SC" Then
            '1 - Saída
            If TipoDOC = 1 And (txtCFOP.Text.Substring(0, 1) <> 6) Then
                Msg &= "CFOP incompatível com Operação fora do Estado (6XXX)" & vbCrLf
            End If
            '0 - Entrada
            If TipoDOC = 0 And (txtCFOP.Text.Substring(0, 1) <> 2) Then
                Msg &= "CFOP incompatível com Operação fora do Estado (2XXX)" & vbCrLf
            End If
        End If
        'Se a operação é estadual e for informado consumidor final
        If txtEstado.Text = "SC" And txtindIEDest.Text.Substring(0, 1) = 9 Then
            Msg &= "Operação dentro do Estado deve ser informado 2-Isento caso Seja Consumidor Final" & vbCrLf
        End If

        If txtNatOP.Text = "" Then
            Msg &= "Natureza da Operação em Branco" & vbCrLf
        End If

        If cmbModFrete.Text = "" Then
            Msg &= "Modalidade de frete não informada" & vbCrLf
        End If

        If txtTraQtde.Text = "" Then
            Msg &= "Quantidade de volumes não informada" & vbCrLf
        End If

        If txtTraEspecie.Text = "" Then
            Msg &= "Espécie dos volumes não informada" & vbCrLf
        End If

        If txtTraQtde.Text = "" Then
            Msg &= "Quantidade de volumes não informada" & vbCrLf
        End If

        If txtTraNum.Text = "" Then
            Msg &= "Numeração dos volumes de volumes não informada" & vbCrLf
        End If

        If txtCliente.Text = "" Then
            Msg &= "Cliente não informado" & vbCrLf
        End If

        If txtEndereco.Text = "" Then
            Msg &= "Endereço não informado" & vbCrLf
        End If

        If txtNumero.Text = "" Then
            Msg &= "Número não informado. Se não houver número informar S/N" & vbCrLf
        End If

        If txtBairro.Text = "" Then
            Msg &= "Bairro não informado" & vbCrLf
        End If

        If txtCidade.Text = "" Then
            Msg &= "Cidade não informada" & vbCrLf
        End If

        If txtCodMun.Text.Length < 7 Then
            Msg &= "Código do municícpio inválido" & vbCrLf
        End If

        If txtEstado.Text = "" Then
            Msg &= "Estado não informado" & vbCrLf
        End If

        If txtCEP.Text.Length() < 8 Then
            Msg &= "CEP não informado ou inválido" & vbCrLf
        End If

        If txtPais.Text = "" Then
            Msg &= "País não informado" & vbCrLf
        ElseIf txtPais.Text = "Brasil" And txtCodPais.Text <> "1058" Then
            Msg &= "Código do país não confere" & vbCrLf
        End If

        If rdPF.Checked = False And rdPJ.Checked = False Then
            Msg &= "Não está informado se o cliente é PF ou PJ" & vbCrLf
        End If

        If dgItens.Rows.Count = 0 Then
            Msg &= "Não existem ítens de Mercadoria no Documento de Saída" & vbCrLf
        End If

        If txtCPF_CNPJ.Text.Length < 11 Then
            Msg &= "CNPJ/CPF inválido"
        ElseIf txtCPF_CNPJ.Text.IndexOf(".") > 0 Then
            Msg &= "Digite o CNPJ/CPF sem formatação (.,-)" & vbCrLf
        ElseIf txtCPF_CNPJ.Text.IndexOf("-") > 0 Then
            Msg &= "Digite o CNPJ/CPF sem formatação (.,-)" & vbCrLf
        ElseIf txtCPF_CNPJ.Text.IndexOf(",") > 0 Then
            Msg &= "Digite o CNPJ/CPF sem formatação (.,-)" & vbCrLf
        End If

        'Se está marcado o CPF
        'If rdPF.Checked Then
        'If Not ValidaCPF(txtCPF_CNPJ.Text) Then
        'Msg &= "CPF não é válido" & vbCrLf
        'End If
        'ElseIf rdPJ.Checked Then
        'If Not ValidaCNPJ(txtCPF_CNPJ.Text) Then
        'Msg &= "CNPJ não é válido" & vbCrLf
        'End If
        'End If

        'Se o frete for preenchido
        If cmbFrete.Text.Length > 2 Then
            If txtTraCNPJ.Text = "" Then
                Msg &= "Quando há transporatadora o CNPJ deve ser informado" & vbCrLf
            End If
            If txtTraIE.Text = "" Then
                Msg &= "Quando há transporatadora a Inscrição deve ser informada" & vbCrLf
            End If
            If txtTraMun.Text = "" Then
                Msg &= "Quando há transporatadora o Município deve ser informado" & vbCrLf
            End If
            If txtTraUF.Text = "" Then
                Msg &= "Quando há transporatadora a UF deve ser informada" & vbCrLf
            End If
        End If

        'Valida O tipo da inscrição estadual
        If txtindIEDest.Text = String.Empty Then
            Msg &= "Informar o tipo de contribuição (Contribuinte/Isento/Não Contribuinte)" & vbCrLf
        End If
        'Valida o tipo de presença
        If txtIndPres.Text = String.Empty Then
            Msg &= "Informar o Tipo de Presença" & vbCrLf
        End If

        'Se for uma operação de Devolução tem que referenciar a NFe e ela tem que ter 42 dígitos
        If txtTipo.Text.Substring(0, 1) = 4 And txtrefNFe.Text.Length < 42 Then
            Msg &= "É necessário referenciar a NFe de orígem informando a chave de 42 dígitos"
        End If

        'Se não tiver nenhum erro
        If Msg = String.Empty Then
            Return True
        Else
            MsgBox(Msg, MsgBoxStyle.Critical, "Erro")
            Return False
        End If
    End Function


    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        Dim Tabela As DataTable, SQL As String, DR As DataRow
        'Carrega os dados do cliente selecionado
        If txtCliente.Text <> String.Empty Then
            Try
                'Busca o cliente selecionado no banco de dados
                SQL = "SELECT * FROM Clientes WHERE id=" & cmbVal(txtCliente)
                Tabela = SQLQuery(SQL)

                'Se não encontrar por não ser um cliente cadastrado
                If Tabela.Rows.Count <= 0 Then
                    Exit Sub
                End If

                'Preenche os campos com os dados do BD
                DR = Tabela.Rows(0)
                txtEndereco.Text = NaoNulo(DR("Endereco"))
                txtNumero.Text = NaoNulo(DR("Num"))
                txtCidade.Text = NaoNulo(DR("Cidade"))
                txtCodMun.Text = NaoNulo(DR("CodMun"))
                txtPais.Text = NaoNulo(DR("Pais"))
                txtCodPais.Text = NaoNulo(DR("CodPais"))
                txtBairro.Text = NaoNulo(DR("Bairro"))
                txtEstado.Text = NaoNulo(DR("Estado"))
                txtCEP.Text = NaoNulo(DR("CEP"))
                txtFone.Text = NaoNulo(DR("Fone"))
                txtEmail.Text = NaoNulo(DR("Email"))
                txtContato.Text = NaoNulo(DR("contato"))
                'Converte os radio buttons
                If Not IsDBNull(DR("PFPJ")) Then
                    If DR("PFPJ") = "F" Then
                        rdPF.Checked = True
                        Label13.Text = "CPF:"
                    Else
                        rdPJ.Checked = True
                        Label13.Text = "CNPJ:"
                    End If
                Else
                    'por padrão habilita a pessoa fisica
                    rdPF.Checked = True
                    Label13.Text = "CPF:"
                End If
                'Preenche os campos
                txtCPF_CNPJ.Text = Limpa_Formatacao(NaoNulo(DR("CPF_CNPJ")))
                txtInscricao.Text = Limpa_Formatacao(NaoNulo(DR("RG_IE")))

            Catch ex As Exception
                MsgBox("Erro ao tentar localizar os dados do Cliente" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Tabela = Nothing
                DR = Nothing
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub cmbFrete_Leave(sender As System.Object, e As System.EventArgs) Handles cmbFrete.Leave
        'Se for preenchida uma transportadora
        If cmbFrete.Text <> "" Then
            Label30.ForeColor = Color.Blue  'CNPJ
            Label46.ForeColor = Color.Blue  'Inscricao
            Label48.ForeColor = Color.Blue  'Municipio
            Label49.ForeColor = Color.Blue  'UF
            Carrega_Transportadora()
        Else
            Label30.ForeColor = Color.Black  'CNPJ
            Label46.ForeColor = Color.Black  'Inscricao
            Label48.ForeColor = Color.Black  'Municipio
            Label49.ForeColor = Color.Black  'UF
        End If

    End Sub

    Private Sub Carrega_Transportadora()
        'Se tiver transportadora selecionada
        If cmbFrete.SelectedIndex <> -1 Then
            Dim DT As DataTable, SQL As String
            SQL = "SELECT * FROM transportadores WHERE id=" & cmbVal(cmbFrete)
            DT = SQLQuery(SQL)
            'Se achou algum registro
            If DT.Rows.Count > 0 Then
                'Com a primeira e única linha
                With DT.Rows(0)
                    txtTraCNPJ.Text = NaoNulo(.Item("CNPJ_CPF"))
                    txtTraIE.Text = NaoNulo(.Item("Inscricao"))
                    txtTraEndereco.Text = NaoNulo(.Item("Endereco")) & ", " & NaoNulo(.Item("Num"))
                    txtTraMun.Text = NaoNulo(.Item("Cidade"))
                    txtTraUF.Text = NaoNulo(.Item("Estado"))
                End With
            End If
        End If
    End Sub

    Private Sub bt_CEP_Click(sender As System.Object, e As System.EventArgs) Handles bt_CEP.Click
        'Muda o cursor
        Me.Cursor = Cursors.WaitCursor
        'Define a estrutura de retorno do endereço
        Dim Address As New EnderecoWEB
        'Busca o endereço pelo CEP
        Busca_Endereco(txtCEP.Text, Address)
        'Preenche os campos com o retorno da função
        txtEndereco.Text = Address.Tipo_Logradouro & " " & Address.Logradouro
        txtBairro.Text = Address.Bairro
        txtCidade.Text = Address.Cidade
        txtEstado.Text = Address.Uf
        'Retorna o cursos para o modo tradicional
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rdPF_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdPF.CheckedChanged
        Label13.Text = "CPF:"
    End Sub

    Private Sub rdPJ_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdPJ.CheckedChanged
        Label13.Text = "CNPJ:"
    End Sub



    Private Sub txtTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtTipo.SelectedIndexChanged
        Select Case txtTipo.Text
            Case "1-Normal"                 ' Notas fiscais normais não precisam destas informaçãoes
                Label56.Visible = False
                txtrefNFe.Visible = False
                txtInfAdFisco.Visible = False
                Label57.Visible = False
            Case Else           ' Se for nota Complementar, Ajuste ou Devolução precisa informar
                Label56.Visible = True
                txtrefNFe.Visible = True
                txtInfAdFisco.Visible = True
                Label57.Visible = True
        End Select
    End Sub

    Private Sub dgVolumes_Leave(sender As Object, e As EventArgs) Handles dgVolumes.Leave
        soma_volumes()
    End Sub

    Private Sub dgVolumes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgVolumes.CellValueChanged
        soma_volumes()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Incluir_Documento()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dim novo As New frmDoc_Entrada_Saida(1) 'Tipo 1 de Saida
        novo.MdiParent = Me.MdiParent
        novo.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim novo As New frmDoc_Entrada_Saida(1, 481) 'Carrega nota 481
        novo.MdiParent = Me.MdiParent
        novo.Show()
    End Sub

    Private Sub Soma_Volumes()
        'Já conta quantos volumes foram adicionados
        txtTraQtde.Text = Format(dgVolumes.Rows.Count - 1, "N0")

        Dim Peso_Total As Double = 0

        'Se houver volumes, soma o peso
        If dgVolumes.Rows.Count > 1 Then
            'Para cada linha do datagrid
            For i As Integer = 0 To dgVolumes.Rows.Count - 2
                Peso_Total += dgVolumes.Rows(i).Cells(4).Value
            Next
            'Totaliza o peso dos volumes
            lblPeso.Text = Format(Peso_Total, "N3")
            'Monta a string do número dos volumes
            txtTraNum.Text = dgVolumes.Rows(0).Cells(0).Value & "-" & dgVolumes.Rows(dgVolumes.Rows.Count - 2).Cells(0).Value
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtPesoL.Text = lblPeso.Text
        txtPesoB.Text = lblPeso.Text
        MsgBox("Peso tranferido para o Campo Peso Líquido e Peso Bruto!", MsgBoxStyle.OkOnly, "Aviso")
    End Sub
End Class