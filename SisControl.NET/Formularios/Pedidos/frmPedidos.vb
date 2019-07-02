Imports System.Globalization

Public Class frmPedidos
    Dim Pedido_ID As Integer
    Dim It_Ct As Int16
    Dim datPedido As New clsPedido
    Protected dsData As New DataSet
    Protected myBind As BindingManagerBase
    Protected myADA As New MySql.Data.MySqlClient.MySqlDataAdapter


    Sub New(Optional ByVal Codigo As Integer = -1)
        ' This call is required by the designer.
        InitializeComponent()
        'Inicializa a variável com -1
        Pedido_ID = -1

        'Se for fornecido algum código
        If Codigo <> -1 Then
            Pedido_ID = Codigo
            Me.Text = "Alteração de Pedido"
            btIncluir.Text = "Salvar Pedido"
        End If
    End Sub

    Private Sub frmPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            tabPedidos.SelectedTab = TabCliente
            cmbCliente.Focus()
        End If
        If e.KeyCode = Keys.F3 Then
            tabPedidos.SelectedTab = tabProduto
            txtCodPro.Focus()
        End If
        If e.KeyCode = Keys.F4 Then
            tabPedidos.SelectedTab = tabStatus
            cmbStatus.Focus()
        End If
        If e.KeyCode = Keys.F5 Then
            tabPedidos.SelectedTab = tabPagamento
            txtDataPedido.Focus()
        End If
    End Sub

    Private Sub frmPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Possibilitar a formatação dos valores do Frete, Seguro e Desconto
        ovFrete = New System.Windows.Forms.Binding("Text", bsPedidos, "ValFrete", True)
        ovSeguro = New System.Windows.Forms.Binding("Text", bsPedidos, "ValSeguro", True)
        ovDesconto = New System.Windows.Forms.Binding("Text", bsPedidos, "ValDesconto", True)
        txtvFrete.DataBindings.Add(ovFrete)
        txtvSeg.DataBindings.Add(ovSeguro)
        txtvDesc.DataBindings.Add(ovDesconto)

        'Carrega os dados do cliente
        Carrega_Lista(cmbCliente, "Clientes", "ID", "Nome", True)
        'Carrega as formas de pagamento
        Carrega_Lista(cmbForma, "Forpag", "id", "Descricao", True)
        'Carrega lista das transportadoras
        Carrega_Lista(cmbFrete, "transportadores", "id", "Razao", True)

        'Desabilita os avisos de Erro por enquanto
        epError.Clear()
        epError.BlinkStyle = ErrorBlinkStyle.NeverBlink
        taPedidos_Itens = Nothing

        'Se pedido ID=-1 então é um novo pedido
        If Pedido_ID = -1 Then
            'Zera o contador de itens
            It_Ct = 0
            'Coloca sempre a data atual na data do pedido
            txtDataPedido.Value = Date.Now
        Else
            'Rotina que carrega os dados do pedido selecionado por Pedido_id
            Carrega_Pedido()
        End If
    End Sub

    Private Sub Carrega_Pedido()

        '*
        '* CARREGA OS DADOS DO PEDIDO
        '*

        Try

            'Recupera os dados do pedido
            TaPedido.Fill(DsPedidos.Tables("Pedidos"), Pedido_ID)

            'Se não encontrar o pedido (o que é bem pouco provável)
            If DsPedidos.Tables("Pedidos").Rows.Count <= 0 Then
                MsgBox("Pedido não encontrado!", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If

            'Recupera os dados dos ítens do pedido
            TaPedidos_Itens1.Fill(DsPedidos.Tables("pedidos_itens"), Pedido_ID)
            'Recupera as duplicatas associadas ao pedido
            TaPedidos_Duplicatas.Fill(DsPedidos.Tables("duplicatas"), Pedido_ID)

            'Carrega dos dados dos ítens e das duplicatas nos datagrids
            dgItens.DataSource = DsPedidos.Tables("pedidos_itens")
            dgDuplicatas.DataSource = DsPedidos.Tables("duplicatas")

            'Faz algumas correçõeszinhas na hora de carregar o pedido
            With DsPedidos.Tables("Pedidos").Rows(0)
                'Arruma a pessoa física ou jurídica
                If Not IsDBNull(.Item("PFPJ")) Then
                    If .Item("PFPJ") = "F" Then
                        rdPF.Checked = True
                    ElseIf .Item("PFPJ") = "J" Then
                        rdPJ.Checked = True
                    End If
                End If
                'Arruma a modalidade de frete
                If Not IsDBNull(.Item("ModFrete")) Then
                    cmbModFrete.SelectedIndex = .Item("ModFrete") - 1
                End If
                'Aruma o status do pedido
                If Not IsDBNull(.Item("Status")) Then
                    cmbStatus.SelectedIndex = .Item("Status")
                End If
                'Formata os valores de Frete, Desconto e seguro
                txtvDescFormat()
                txtvFreteFormat()
                txtvSegFormat()
            End With


            'Carrega as tabelas no DataSet
            'Dim DTpedidos As DataTable = SQLQuery("SELECT * FROM pedidos_itens WHERE Pedido_ID=" & Pedido_ID)
            'Dim DTduplicatas As DataTable = SQLQuery("SELECT * FROM duplicatas WHERE Pedido_id=" & Pedido_ID)
            'DTpedidos.TableName = "pedidos_itens"
            'dsData.Tables.Add(DTpedidos.Copy)
            'Console.WriteLine("DSData Tabelas: " & dsData.Tables.Count)
            'DTduplicatas.TableName = "duplicatas"
            'dsData.Tables.Add(DTduplicatas.Copy)
            'DTduplicatas = Nothing
            'DTpedidos = Nothing
            'Nomeia as tabelas

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Atualiza_Totais()
    End Sub

    Private Sub cmbCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCliente.Leave
        If cmbCliente.SelectedIndex = -1 Then
            Exit Sub
        End If

        'Se for um pedido novo
        If Pedido_ID = -1 Then
            Dim Tabela As DataTable, SQL As String, DR As DataRow
            'Carrega os dados do cliente selecionado
            If cmbCliente.Text <> String.Empty Then
                Try
                    'Busca o cliente selecionado no banco de dados
                    SQL = "SELECT * FROM Clientes WHERE id=" & cmbVal(cmbCliente)
                    Tabela = SQLQuery(SQL)
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
                    txtFax.Text = NaoNulo(DR("Fax"))
                    txtCelular.Text = NaoNulo(DR("Celular"))
                    txtEmail.Text = NaoNulo(DR("Email"))
                    txtContato.Text = NaoNulo(DR("contato"))
                    txtObservacoes.Text = NaoNulo(DR("Observacoes"))
                    'Converte os radio buttons
                    If Not IsDBNull(DR("PFPJ")) Then
                        If DR("PFPJ") = "F" Then
                            rdPF.Checked = True
                            Label9.Text = "CPF:"
                        Else
                            rdPJ.Checked = True
                            Label9.Text = "CNPJ:"
                        End If
                    Else
                        'por padrão habilita a pessoa fisica
                        rdPF.Checked = True
                        Label9.Text = "CPF:"
                    End If
                    'Preenche os campos
                    txtPFPJ.Text = NaoNulo(DR("PFPJ"))
                    txtCPF_CNPJ.Text = NaoNulo(DR("CPF_CNPJ"))
                    txtInscricao.Text = NaoNulo(DR("RG_IE"))
                    txtCodCli.Text = cmbVal(cmbCliente)

                Catch ex As Exception
                    MsgBox("Erro ao tentar localizar os dados do Cliente" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Tabela = Nothing
                    DR = Nothing
                    Exit Sub
                End Try
            End If
        End If
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Tenta incluir uma linha do datagrid
        Try
            'Junta as demais informações
            Dim varICMS As Double, varPIS As Double, varCOFINS As Double, varValICMS As Double, varValPIS As Double, varValCOFINS As Double, varNCM As String, varTotal As Double

            Dim DT As DataTable
            DT = SQLQuery("SELECT icms,pis,cofins,ncm FROM clones WHERE Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            'Se encontrou
            If DT.Rows.Count > 0 Then
                varTotal = String_to_Numero(txtValor.Text) * String_to_Numero(txtQtde.Text)
                With DT.Rows(0)
                    varNCM = NaoNulo(.Item("ncm"))
                    varPIS = .Item("pis")
                    varcofins = .Item("Cofins")
                    varICMS = .Item("icms")
                    varValPIS = varTotal * varPIS
                    varValCOFINS = varTotal * varCOFINS
                    varValICMS = varTotal * varICMS
                End With
                'Fecha o datatable e libera a memoria
                DT.Dispose()
                DT = Nothing
            Else
                MsgBox("Produto não encontrado, verifique o código do Produto e o Clone", MsgBoxStyle.Critical)
                Limpa_Inclusao_Itens()
                Exit Sub
            End If

            Dim Parametros() As Object
            'id,Pedido_id,CodPro,Clone,Descricao,NCM,Unidade,Qtde,Unitario,Total,Atendido,Status,Forma,Tipo,CFOP,ICMS,PIS,Cofins,VICMS,vPIS,vCOFINS
            Parametros = {It_Ct, IIf(Pedido_ID = -1, 0, Pedido_ID), txtCodPro.Text, lblMercadoria.Text & " cv. " & lblClone.Text, varNCM, "md", String_to_Numero(txtQtde.Text), String_to_Numero(txtValor.Text), varTotal, 0, 0, "BD", "RN", txtCFOP.Text, varICMS, varPIS, varCOFINS, varValICMS, varValPIS, varValCOFINS, txtClone.Text}

            DsPedidos.Tables("pedidos_itens").Rows.Add(Parametros)
            'DsPedidos.Refresh()
            Atualiza_Totais()
            'Limpa os campos
            Limpa_Inclusao_Itens()
            'Aumenta o contador de itens
            It_Ct += 1
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir novo item" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub
    Private Sub Limpa_Inclusao_Itens()
        'Limpa somente os campos de inclusão de ítens
        txtCodPro.Text = String.Empty
        txtClone.Text = String.Empty
        lblMercadoria.Text = "..."
        lblClone.Text = "..."
        txtQtde.Text = String.Empty
        lblClone.Text = String.Empty
        lblMercadoria.Text = String.Empty
        cmbTipo.Text = String.Empty
        cmbPadrao.Text = String.Empty
        txtValor.Text = String.Empty
        txtCodPro.Focus()
    End Sub
    Private Sub Atualiza_Totais()
        Dim i As Integer, varTotal As Double = 0, varMudas As Integer = 0, TotalGeral As Double = 0
        'Se tiver mais de uma linha faz os totais
        If dgItens.Rows.Count > 0 Then
            'passa por todas as linhas somando as mudas e o total
            For i = 0 To dgItens.Rows.Count - 1
                '4 e 6
                varTotal = varTotal + String_to_Numero(dgItens.Rows(i).Cells("Valor").Value)
                varMudas = varMudas + String_to_Numero(dgItens.Rows(i).Cells("NMudas").Value)
            Next
            'Preenche o campo com o total do pedido
            txtTotal.Text = Format(varTotal, "N2")

            'Preenche o numero total de mudas
            txtNMudas.Text = Format(varMudas, "N0")

            'Calcula o resumo do pedido
            lblMercadorias.Text = txtTotal.Text
            'Atualiza o valor do frete no resumo
            lblFrete.Text = txtvFrete.Text
            'Atualiza o valor do seguro
            lblDespesas.Text = txtvSeg.Text
            'Atualiza o valor do desconto
            lblDescontos.Text = txtvDesc.Text
            'Mercadorias + frete + despesas
            TotalGeral = varTotal + String_to_Numero(lblFrete.Text) + String_to_Numero(lblDespesas.Text)
            'Impostos
            TotalGeral += String_to_Numero(lblImpostos.Text)
            'Descontos
            TotalGeral -= String_to_Numero(lblDescontos.Text)
            'A rotina converte_numero já retorna o string recebido como double
            lblTotPedido.Text = Format(TotalGeral, "N2")

        End If
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        'Sai sem salvar nada
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Avança uma tab
        tabPedidos.SelectedTab = tabProduto
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Avança uma TAB
        tabPedidos.SelectedTab = tabStatus
    End Sub

    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click

        If btIncluir.Text = "Salvar Pedido" Then
            Atualizar_Pedido()
        Else
            Incluir_Pedido()
        End If

    End Sub

    Private Sub Atualizar_Pedido()

        Try
            bsPedidos.EndEdit()

            '*
            '* DADOS DO PEDIDO
            '*

            ' Primeiro verifica se existem mudanças no dataset
            If Not DsPedidos.HasChanges(DataRowState.Modified) Then
                MsgBox("Não existem alterações para serem salvas", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If

            'Cria um dataset temporário somente com as modificações
            Dim tempDataSet As DataSet = DsPedidos.GetChanges(DataRowState.Modified)

            'Verifica se esse pequenos dataset tem erros
            If tempDataSet.HasErrors Then
                ' Insert code to resolve errors.
            End If

            'Depois de verificados todos os erros e ver se tem alterações então grava
            TaPedido.Update(tempDataSet)

            '*
            '* DADOS DOS ITENS
            '*
            '* Esse é um pouco mais trabalhoso porque tem que ver se adicionou, apagou ou alterou
            '*

            'Faz as Alterações
            TaPedidos_Itens1.Update(DsPedidos)

            '*
            '* DADOS DAS DUPLICATAS
            '*
            '* Estes dados também dão um pouco mais de trabalho pois tem que alterar, e gravar
            '*

            TaPedidos_Duplicatas.Update(DsPedidos)

            tempDataSet = Nothing

            MsgBox("Pedido atualizado com sucesso!", MsgBoxStyle.Information, "Aviso")
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o pedido no banco de dados" & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Incluir_Pedido()
        Dim varID As Integer = -1, i As Integer = 0
        Dim valorItem As Double = 0

        'Verifica se os campos estão atendidos antes de dar sequencia a inclusão
        If Valida_Campos() Then

            'Cria uma nova instancia da classe pedido
            Dim Pedido As New clsPedido

            With Pedido
                '*
                '* DADOS DOS CLIENTES
                '*
                .Cliente = cmbCliente.Text
                .CodCli = cmbVal(cmbCliente)
                .Endereco = txtEndereco.Text
                .Num = txtNumero.Text
                .Bairro = txtBairro.Text
                .Estado = txtEstado.Text
                .Cidade = txtCidade.Text
                .CodCidade = txtCodMun.Text
                .CEP = txtCEP.Text
                .Pais = txtPais.Text
                .codPais = txtCodPais.Text
                .Fone = txtFone.Text
                .Fax = txtFax.Text
                .Celular = txtCelular.Text
                .email = txtEmail.Text
                .PFPJ = IIf(rdPF.Checked, "F", "J")
                .CNPJ_CPF = txtCPF_CNPJ.Text
                .Inscricao = txtInscricao.Text
                .Contato = txtContato.Text
                .Observacao = txtObservacoes.Text
                .Transportadora = cmbFrete.Text

                '*
                '* DADOS DA PARA NFE
                '*

                .CFOP = txtCFOP.Text
                .NaturezaOP = txtNatureza.Text

                '*
                '* PRODUTOS
                '*

                For i = 0 To dgItens.RowCount - 1
                    Dim Item As New Pedidos_Itens
                    With dgItens.Rows(i)
                        Item._CodProduto = .Cells(celCodPro.Index).Value
                        Item._Clone = .Cells(celClone.Index).Value
                        Item._Descricao = .Cells(celDescricao.Index).Value
                        Item._Forma = .Cells(celForma.Index).Value
                        Item._CFOP = txtCFOP.Text
                        Item._NCM = .Cells(celNCM.Index).Value
                        Item._pCofins = .Cells(celCOFINS.Index).Value
                        Item._pICMS = .Cells(celICMS.Index).Value
                        Item._pPIS = .Cells(celPIS.Index).Value
                        Item._QtdeAtendida = 0
                        Item._Quantidade = .Cells(NMudas.Index).Value
                        Item._Unidade = "md"
                        Item._Unitario = .Cells(celUnitario.Index).Value
                        If cmbStatus.SelectedIndex > -1 Then
                            Item._Status_Item = cmbStatus.Text.Substring(0, 1)
                        Else
                            Item._Status_Item = "0"
                        End If
                        Item._Tipo_Muda = .Cells(celTipo.Index).Value
                        Item._Total = Item._Quantidade * Item._Unitario
                    End With
                    'Adiciona um ítem ao pedido
                    .Itens.Add(Item)

                Next i

                'Resumo dos ítens
                .NumItens = .Itens.Count
                .NumMudas = String_to_Numero(txtNMudas.Text)
                .Valor = String_to_Numero(txtTotal.Text)

                '*
                '* DADOS DOS STATUS
                '*
                If cmbStatus.SelectedIndex > -1 Then
                    .Status = cmbStatus.Text.Substring(0, 2)
                Else
                    'Valor padrão
                    .Status = "0"
                End If
                .DataAprovado = dtAutorizado.Value
                .AprovadoPor = txtAutoPor.Text
                .AprovadorRG = txtRGAprovador.Text

                '*
                '* DADOS DO PAGAMENTO E PRAZOS
                '*
                .DataPedido = txtDataPedido.Value
                .DataAprovado = txtDataPedido.Value
                .PrazoEntrega = txtDataEntrega.Value
                .Vendedor = txtVendedor.Text
                If cmbModFrete.SelectedIndex > -1 Then
                    .ModFrete = cmbModFrete.Text.Substring(0, 1)
                Else
                    .ModFrete = 1
                End If
                .ValorFrete = String_to_Numero(txtvFrete.Text)
                .ValorSeguro = String_to_Numero(txtvSeg.Text)
                .ValorDesconto = String_to_Numero(txtvDesc.Text)
                If cmbForma.SelectedIndex > -1 Then
                    .FormaPagamento = cmbVal(cmbForma)
                Else
                    .FormaPagamento = -1
                End If

                '*
                '* DADOS DAS DUPLICATAS
                '*

                For i = 0 To dgDuplicatas.RowCount - 1
                    Dim Dup As New Pedidos_Duplicatas
                    With dgDuplicatas.Rows(i)
                        Dup.Pedido_Id = -1
                        Dup.Vencimento = .Cells(celVencimento.Index).Value
                        Dup.Descricao = .Cells(celDescricao_Dup.Index).Value
                        Dup.Valor = String_to_Numero(.Cells(celValor_Dup.Index).Value)
                        Dup.Lancado = False
                    End With

                    'Adiciona a duplicata ao pedido
                    .Duplicatas.Add(Dup)
                Next

                '*
                '* INCLUSÃO DO PEDIDO, ITENS E DUPLICATAS
                '*

                Pedido.Incluir()

            End With
        End If
    End Sub

    Private Sub Incluir_Antigo()
        Dim SQL As String, varID As Integer = -1, i As Integer = 0, a As Int16 = 0
        Dim varNCM As String, varICMS As Double = 0, varPIS As Double = 0, varCOFINS As Double = 0
        Dim valorItem As Double = 0

        'Pede a confirmação do usuario
        a = MsgBox("Confirma a inclusão do pedido atual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        If a = vbYes Then

            '*
            '* INCLUSÃO DO PEDIDO
            '*

            'Monta a SQL para fazer a inclusão do pedido
            Try
                Sql = "INSERT INTO Pedidos SET "

            Catch ex As Exception
                MsgBox("Erro ao tentar montar a SQL do Pedido" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            'Tenta fazer a inclusão do pedido
            Try
                'Tenta incluir os dados
                Console.WriteLine(Me.Name & " Pedido:" & Sql)
                ExecutaSQL(Sql)
                'Se conseguir segue adiante
                varID = DMax("id", "pedidos")
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir o Pedido" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try

            For i = 0 To DsPedidos.Tables("Pedidos_Itens").Rows.Count - 1
                With DsPedidos.Tables("Pedidos_itens").Rows(i)
                    .Item("Pedido_id") = varID
                End With
            Next

            'taPedidos_Itens.Update(DsPedidos.Tables("Pedidos_Itens"))
            MsgBox("Itens sucesso")

            '*
            '* INCLUSÃO DOS ÍTENS
            '*

            Try

                Sql = "INSERT INTO pedidos_itens (Pedido_id,CodPro,Clone,Descricao,NCM,Unid,Quantidade,Unitario,Total,Atendido,STATUS,Forma,Tipo,CFOP,ICMS,PIS,COFINS,vICMS,vPIS,vCOFINS) VALUES "


                'Procede com a inclusão dos ítens do pedido
                For i = 0 To dgItens.Rows.Count - 1
                    With dgItens.Rows(i)
                        'Quando for mais de uma linha tem que ter virgula entre os dados
                        If i > 0 Then
                            Sql = Sql & ","
                        End If
                        'Preenche as variáveis necessarias
                        varNCM = DLookup("NCM", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                        varICMS = DLookup("ICMS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                        varPIS = DLookup("PIS", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                        varCOFINS = DLookup("Cofins", "Clones", "Mercadoria=" & .Cells(1).Value & " AND clone=" & Val(.Cells(2).Value))
                        ValorItem = String_to_Numero(.Cells(6).Value)

                        'Monta a SQL
                        Sql &= "(" & varID.ToString & ","                     'Pedido_Id
                        Sql &= .Cells(1).Value & ","                          'CodPro
                        Sql &= Val(.Cells(2).Value) & ","                     'Clone
                        Sql &= "'" & .Cells(3).Value & "',"                   'Descricao
                        Sql &= "'" & varNCM & "',"                            'NCM
                        Sql &= "'UN',"                                        'Unidade
                        Sql &= Numero_to_SQL(.Cells(4).Value) & ","           'Quantidade
                        Sql &= Numero_to_SQL(.Cells(5).Value) & ","           'Unitário
                        Sql &= Numero_to_SQL(.Cells(6).Value) & ","           'Total
                        Sql &= "0,"                                           'Atendido
                        Sql &= "1,"                                           'Status - 0-Autorizado 1-Produz 2-Parcial 3-Cancelado 4-Atendido
                        Sql &= "'" & .Cells(7).Value.ToString.ToUpper & "',"  'Forma
                        Sql &= "'" & .Cells(8).Value.ToString.ToUpper & "',"  'Tipo
                        Sql &= "'" & txtCFOP.Text & "',"                      'CFOP
                        Sql &= varICMS & ","                                  'Aliquota ICMS
                        Sql &= varPIS & ","                                   'Aliquota PIS
                        Sql &= varCOFINS & ","                                'Aliquota COFINS
                        Sql &= varICMS * ValorItem & ","                      'Valor ICMS
                        Sql &= varPIS * ValorItem & ","                       'Valor PIS
                        Sql &= varCOFINS * ValorItem & ")"                    'Valor cofins
                    End With
                Next
                'Montada a SQL ela pode ser executada
                Console.WriteLine(Me.Name & " Itens:" & Sql)
                ExecutaSQL(Sql)
                MsgBox("Pedido " & varID.ToString & " e seus ítens incluidos com sucesso", MsgBoxStyle.Information, "Aviso")
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir os ítens do Pedido: " & varID.ToString & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try

            '*
            '* INCLUSÃO DAS DUPLICATAS
            '*

            Try
                Sql = "INSERT INTO duplicatas (Pedido_id,Vencimento,Valor,Descricao) VALUES "
                'Verifica todas as duplicadas
                For i = 0 To dgDuplicatas.RowCount - 1
                    'Se tiver mais de um registro poe virgula
                    If i > 0 Then
                        Sql &= ","
                    End If
                    With dgDuplicatas.Rows(i)
                        Sql &= "(" & varID.ToString & ","                                   'Id do Pedido
                        Sql &= "'" & Format(CDate(.Cells(1).Value), "yyyy-MM-dd") & "',"    'Vencimento
                        Sql &= Numero_to_SQL(.Cells(2).Value) & ","                         'Valor 
                        Sql &= "'" & .Cells(3).Value & "')"                                 'Descricao 
                    End With
                Next

                'Montada a SQL ela pode ser executada
                Console.WriteLine(Me.Name & " Duplicatas:" & Sql)
                ExecutaSQL(Sql)
                MsgBox("Pedido " & varID.ToString & " e suas Duplicatas incluídas com sucesso", MsgBoxStyle.Information, "Aviso")
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir as Duplicatas do Pedido: " & varID.ToString & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If

    End Sub

    Private Function Valida_Campos() As Boolean
        Dim Msg As String = String.Empty, Valida As Boolean = True

        'Verifica o Cliente
        If cmbCliente.Text = String.Empty Then
            epError.SetError(cmbCliente, "Cliente não pode ser vazio")
            'Msg &= "O Cliente é obrigatório" & vbCrLf
            Valida = False
        End If

        'CPF_CNPJ
        If txtCPF_CNPJ.Text.Length < 11 Then
            epError.SetError(txtCPF_CNPJ, "CPF ou CNPJ não podem ser vazios")
            'Msg &= "Verifique o CPF ou CNPJ do cliente" & vbCrLf
            Valida = False
        End If

        'Itens
        If dgItens.Rows.Count <= 0 Then
            epError.SetError(dgItens, "É necessário que o pedido tenha pelo menos um ítem")
            'Msg &= "O Pedido não contém ítens" & vbCrLf
            Valida = False
        End If

        'Forma
        If cmbForma.Text = String.Empty Then
            epError.SetError(cmbForma, "Deve-se informar a condição de pagamento")
            'Msg &= "Informe quais serão as condições de pagamento" & vbCrLf
            Valida = False
        End If

        'Data
        If txtDataPedido.Text = "  /  /" Then
            epError.SetError(txtDataPedido, "Informe a data do pedido")
            'Msg &= "Informe a data do pedido" & vbCrLf
            Valida = False
        End If

        'Verifica se a soma das parcelas fecha com a soma dos produtos
        Dim Valor As Double = 0
        For i As Integer = 0 To dgDuplicatas.RowCount - 1
            Valor += String_to_Numero(dgDuplicatas.Rows(i).Cells(celValor_Dup.Index).Value)
        Next
        If Valor <> String_to_Numero(lblTotPedido.Text) Then
            Msg &= "Total das duplicatas não corresponde ao valor total do pedido" & vbCrLf
            MsgBox("Erro ao tentar incluir o Pedido, observe abaixo:" & vbCrLf & Msg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Valida = False
        End If

        'Se tiver qualquer erro
        'If Not Valida Then
        'MsgBox("Erro ao tentar incluir o Pedido, observe abaixo:" & vbCrLf & Msg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
        'End If
        'Retorna a resposta que foi dada
        Return Valida

    End Function

    Private Sub rdPF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPF.CheckedChanged
        If rdPF.Checked Then
            Label9.Text = "CPF:"
        End If
    End Sub

    Private Sub rdPJ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPJ.CheckedChanged
        If rdPJ.Checked Then
            Label9.Text = "CNPJ:"
        End If
    End Sub

    Private Sub cmbPadrao_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPadrao.Leave
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
        Try
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
        Catch ex As InvalidCastException    'Erro de conversão de NULL para Double
            Preco = 0
        Catch ex As Exception               'Outra excessão não tratada
            MsgBox("Erro ao recuperar informações dos clones" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        
        'Se não retornar um valor nulo
        If Not IsDBNull(Preco) Then
            'Formata o texto como Numerico 2 
            txtValor.Text = Format(Preco, "N2")
        End If
    End Sub


    Private Sub txtvFrete_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvFrete.Leave
        txtvFreteFormat()
    End Sub
    Private Sub txtvFreteFormat()
        'Formata o campo do frete
        txtvFrete.Text = Format(String_to_Numero(txtvFrete.Text), "N2")
        'Atualiza os totais
        Atualiza_Totais()
    End Sub


    Private Sub txtvSeg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvSeg.Leave
        txtvSegFormat()
    End Sub
    Private Sub txtvSegFormat()
        'Formata o campo do seguro
        txtvSeg.Text = Format(String_to_Numero(txtvSeg.Text), "N2")
        'Atualiza os totais
        Atualiza_Totais()
    End Sub

    Private Sub txtvDesc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvDesc.Leave
        txtvDescFormat()
    End Sub
    Private Sub txtvDescFormat()
        'Formata o campo do frete
        txtvDesc.Text = Format(String_to_Numero(txtvDesc.Text), "N2")
        'Atualiza os totais
        Atualiza_Totais()
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

            'Limpa as parcelas primerio
            DsPedidos.Tables("Duplicatas").Clear()

            'Para cada parcela cria uma duplicata
            For i = 0 To vetVenc.Length - 1
                'Tenta incluir as parcelas
                Try
                    'Tenta fazer a inclusão das parcelas
                    DsPedidos.Tables("duplicatas").Rows.Add(i, DBNull.Value, Pedido_ID, Format(txtDataEntrega.Value.AddDays(vetVenc(i)), "dd/MM/yy"), String_to_Numero(lblTotPedido.Text) * Val(vetPorc(i)) / 100, "Parc. " & i + 1 & "/" & vetVenc.Length.ToString, False)
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir as duplicadas de forma automática!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            Next
        End If
    End Sub

    Private Sub txtEstado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstado.LostFocus
        'Preenche o combobox com o nome dos municipios 
        If txtEstado.Text.Length = 2 Then
            Carrega_Lista(txtCidade, "Rais", "Cod", "Municipio", True, "Estado='" & txtEstado.Text & "'")
        End If
    End Sub

    Private Sub txtCidade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCidade.LostFocus
        'Preenche o codigo do municipio
        If txtCidade.SelectedIndex <> -1 Then
            txtCodMun.Text = cmbVal(txtCidade)
        End If
    End Sub

    Private Sub dgItens_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItens.CellEndEdit
        'Se forem alterados alguns valores recalcular
        If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            dgItens.Rows(e.RowIndex).Cells(Valor.Index).Value = Val(dgItens.Rows(e.RowIndex).Cells(NMudas.Index).Value) * Converte_Numero(dgItens.Rows(e.RowIndex).Cells(celUnitario.Index).Value)
        End If
        Atualiza_Totais()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Avança uma tab
        tabPedidos.SelectedTab = tabPagamento
    End Sub

    Private Sub txtCFOP_Leave(sender As System.Object, e As System.EventArgs) Handles txtCFOP.Leave
        'Não esta vazio
        If txtCFOP.Text <> "" Then
            If txtCFOP.Text.IndexOf(".") > 0 Then
                txtCFOP.Text.Replace(".", "")
            End If
            If txtCFOP.Text.Length = 4 Then
                txtNatureza.Text = DLookup("Descricao", "CFOP", "CFOP='" & txtCFOP.Text & "'")
            End If
        End If
    End Sub

    Private Sub oVFrete_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs) Handles ovFrete.Format
        Formata_Num(e)
    End Sub

    Private Sub oVSeguro_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs) Handles ovSeguro.Format
        Formata_Num(e)
    End Sub

    Private Sub oVDesconto_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs) Handles ovDesconto.Format
        Formata_Num(e)
    End Sub

    Private Sub Formata_Num(ByRef par As System.Windows.Forms.ConvertEventArgs)
        par.Value = Format(par.Value, "N2")
    End Sub

    Private Sub dtAutorizado_Leave(sender As Object, e As System.EventArgs) Handles dtAutorizado.Leave
        If dtAutorizado.Text.Length > 0 Then
            txtDataPedido.Value = dtAutorizado.Value
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btWEBCadastro.Click
        Dim auxForm As New frmAux_Clientes_WEB, varID As Integer
        'Abre a janela auxiliar para escolher o cliente Cadastrado na WEB
        auxForm.ShowDialog()
        'Pega o ID do cliente cadastrado
        varID = auxForm.ClienteID
        'Se vier algum registro que não for zero
        If varID <> 0 Then
            Dim Cliente As New Cliente_WEB
            Me.Cursor = Cursors.WaitCursor
            ' Procura o cliente pelo ID recebido
            Cliente.Carrega_Dados_Cliente(varID)
            'Com os dados do cliente, preenche o pedido
            Preenche_Campos_Dados_Cliente(Cliente)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    'Preenche os dados do pedido recuperado da WEB Opencart
    Private Sub Preenche_Campos_Dados_Pedido(ByRef Pedido As clsPedido)
        With Pedido
            cmbCliente.Text = .Cliente
            txtCodCli.Text = .CodCli
            txtEndereco.Text = .Endereco
            txtBairro.Text = .Bairro
            txtCEP.Text = .CEP
            txtEstado.Text = .Estado
            txtCidade.Text = .Cidade
            txtCPF_CNPJ.Text = .CNPJ_CPF
            'Verifica se é pessoa física ou jurídica
            IIf(txtCPF_CNPJ.Text.Length > 9, rdPJ.Checked = True, rdPF.Checked = True)
            txtInscricao.Text = .Inscricao
            txtFone.Text = .Fone
            txtFax.Text = .Fax
            txtEmail.Text = .email
            txtContato.Text = .Cliente
        End With
    End Sub

    'Busca somente o cadastro do cliente na WEB Opencart
    Private Sub Preenche_Campos_Dados_Cliente(ByRef Cli As Cliente_WEB)
        With Cli
            With Cli
                cmbCliente.Text = .Nome & " " & .Sobrenome
                txtEndereco.Text = .Endereco
                txtBairro.Text = .Bairro
                txtCEP.Text = .CEP
                txtEstado.Text = .Estado
                txtCidade.Text = .Cidade
                txtCPF_CNPJ.Text = .CPF_CNPJ
                'Verifica se é pessoa física ou jurídica
                IIf(txtCPF_CNPJ.Text.Length > 9, rdPJ.Checked = True, rdPF.Checked = True)
                txtInscricao.Text = .RG_IE
                txtFone.Text = .Telefone
                txtFax.Text = .Fax
                txtEmail.Text = .Email
                txtContato.Text = .Nome
            End With
        End With
    End Sub


    Private Function recupera_dados_cliente_web(ByVal id) As DataTable
        Dim DT As DataTable, SQL As String
        'Monta a SQL de recuperação
        SQL = "SELECT name,value FROM vtex_facileforms_subrecords WHERE Record=" & id
        'Mostra na tela de Debug
        Console.WriteLine("SQL Cliente WEB: " & SQL)
        'Tenta recuperar a linha na forma de DataTable
        If Conectado Then
            Try
                'Tenta fazer a conexao com o banco de dados remoto
                Me.Cursor = Cursors.WaitCursor
                DT = SQLQuery(SQL, True)
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                MsgBox("Erro ao tentar se comunicar com o banco de dados remoto." & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Me.Cursor = Cursors.Arrow
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
        Return DT
    End Function

    Private Sub Processa_dados_recebidos(ByRef Tabela As DataTable)
        Dim DR As DataRow
        'Para cada linha de dados em Tabela (DT) processar
        DR = Tabela.Rows(0)

        'Pega o nome do campo e verifica onde vai colocar
        Select Case DR.Item("name")
            Case "txtNome"
                'Essa função faz com que a primeira letra de cada palavra seja Maiuscula e o resto minuscula
                cmbCliente.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtEndereco"
                txtEndereco.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtNumero"
                txtNumero.Text = NaoNulo(DR.Item("value"))
            Case "txtBairro"
                txtBairro.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtCEP"
                txtCEP.Text = NaoNulo(DR.Item("value"))
            Case "txtCidade"
                txtCidade.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtEstado"
                txtEstado.Text = NaoNulo(DR.Item("value")).ToUpper
            Case "txtPais"
                txtPais.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtCPFCNPJ"
                txtCPF_CNPJ.Text = NaoNulo(DR.Item("value"))
            Case "txtIE"
                txtInscricao.Text = NaoNulo(DR.Item("value"))
            Case "txtPessoa"
                txtContato.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
            Case "txtFone"
                txtFone.Text = NaoNulo(DR.Item("value"))
            Case "txtFax"
                txtFax.Text = NaoNulo(DR.Item("value"))
            Case "txtCelular"
                txtCelular.Text = NaoNulo(DR.Item("value"))
            Case "txtEmail"
                txtEmail.Text = NaoNulo(DR.Item("value")).ToLower
        End Select
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        Dim auxForm As New frmAux_Pedido_WEB, varID As Integer
        'Abre a janela auxiliar para escolher o Pedido Cadastrado na WEB
        auxForm.ShowDialog()
        'Pega o ID do cliente cadastrado
        varID = auxForm.PedidoID
        'Se vier algum registro que não for zero
        If varID <> 0 Then
            'Cria um pedido em branco
            Dim ped As New clsPedido
            Me.Cursor = Cursors.WaitCursor
            ' Procura o cliente pelo ID recebido
            ped.Carrega_Pedido_WEB(varID)
            'Com os dados do cliente, preenche o pedido
            Exibe_Pedido_Objeto(ped) '_Pedido_Objeto(ped)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Exibe_Pedido_Objeto(ByRef objPedido As clsPedido)
        'Função que coloca nos campos os dados do pedido carregado do sistema ou da WEB
        With objPedido

            '**
            '** DADOS DO CLIENTE E PEDIDO
            '** 

            cmbCliente.Text = .Cliente
            txtCodCli.Text = .CodCli
            txtEndereco.Text = .Endereco
            txtNumero.Text = .Num
            txtBairro.Text = .Bairro
            txtCidade.Text = .Cidade
            txtEstado.Text = .Estado
            txtCEP.Text = .CEP
            txtFone.Text = .Fone
            txtEmail.Text = .email
            If .PFPJ = "F" Then
                rdPF.Checked = True
            Else
                rdPJ.Checked = True
            End If
            txtPFPJ.Text = .PFPJ
            txtCPF_CNPJ.Text = .CNPJ_CPF
            txtInscricao.Text = .Inscricao
            txtCFOP.Text = .CFOP
            cmbStatus.Text = .Status
            dtAutorizado.Value = .DataPedido
            txtDataPedido.Value = .DataPedido
            txtAutoPor.Text = .Cliente
            txtRGAprovador.Text = .Inscricao
            txtVendedor.Text = "Clona-Gen Online"
            cmbModFrete.SelectedIndex = 0       ' 1 - Remetente
            cmbFrete.Text = .Transportadora
            txtvFrete.Text = .ValorFrete
            txtvDesc.Text = .ValorDesconto
            txtObservacoes.Text = .Observacao

        End With

        '**
        '** ITENS DO PEDIDO
        '**

        'Para cada ítem na lista de ítens
        Dim Parametros() As Object
        'Limpa algum ítem eventualmente adicionado
        DsPedidos.Tables("pedidos_itens").Rows.Clear()
        'Percorre a lista de ítens do objeto para ir acrescentando no tela
        For Each Item_Ped As Pedidos_Itens In objPedido.Itens
            With Item_Ped
                Dim DR As DataRow = DLookupRow("clones", "mercadoria=" & ._CodProduto & " AND clone=" & ._Clone)
                'Monta a lista de parâmetros para inclusão no DataSet
                Dim varCodPro As Int16 = ._CodProduto
                Dim varDescricao As String = DLookup("cientifico", "mercadoria", "id=" & ._CodProduto) & " cv. " & DR("Nome")
                Dim varQtde As Integer = ._Quantidade
                Dim varValUnit As Single = ._Unitario
                Dim varCFOP As String = ._CFOP
                Dim varNCM As Single = NaoNulo(DR("NCM"))
                Dim varTotal As Single = varQtde * varValUnit
                Dim varICMS As Double = DR("icms")
                Dim varPIS As Single = DR("pis")
                Dim varCOFINS As Single = DR("Cofins")
                Dim varValICMS As Single = varTotal * varICMS
                Dim varValPIS As Single = varTotal * varPIS
                Dim varValCOFINS As Single = varTotal * varCOFINS

                'id,Pedido_id,CodPro,Clone,Descricao,NCM,Unidade,Qtde,Unitario,Total,Atendido,Status,Forma,Tipo,CFOP,ICMS,PIS,Cofins,VICMS,vPIS,vCOFINS
                Parametros = {It_Ct, 0, varCodPro, varDescricao, varNCM, "md", varQtde, String_to_Numero(varValUnit), varTotal, 0, 0, "BD", "RN", varCFOP, varICMS, varPIS, varCOFINS, varValICMS, varValPIS, varValCOFINS, ._Clone}
                'Faz a inclusão no DataSet
                DsPedidos.Tables("pedidos_itens").Rows.Add(Parametros)
                'Acrescenta outro íten
                It_Ct += 1
            End With
        Next
        '
        dgItens.Columns(0).Visible = False
        'Atualiza os totais
        Atualiza_Totais()
    End Sub
End Class