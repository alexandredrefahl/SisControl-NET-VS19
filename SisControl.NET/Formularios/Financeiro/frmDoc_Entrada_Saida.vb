Public Class frmDoc_Entrada_Saida
    Dim DocID As Integer = 0, TipoDOC As UInt16 = 1
    Dim flagItens As Boolean, flag


    ' Dependendo do número e tipo de parâmetros a NFe Carrega de um jeito
    Public Sub New(ByVal Tipo As UShort, Optional ByVal Numero As Integer = -1)

        'Tipo 2-Pedido 1-Saída 0-Entrada

        ' Inicializa os componentes do FORM
        InitializeComponent()

        'NOTA FISCAL NOVA de Entrada ou Saída
        If Numero = -1 And (Tipo = 0 Or Tipo = 1) Then
            'Abre um novo registro em todos os DataSET
            BS_Docs.AddNew()


            txtSerie.Text = My.Settings.NFeSerie
            txtSerie.Refresh()
            'Por padrão Tipo=1 que é saída
            TipoDOC = Tipo
            'Define o tipo da NFe
            TipoTextBox.Text = Tipo
            TipoTextBox.Refresh()
            'Seleciona no primeiro combo o Tipo
            cmbTipo.SelectedIndex = Tipo - 1
            'Busca no BD o Número da Próxima NFe
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
            'Formata o cabeçalho do Form
            If Tipo = 1 Then
                Me.Text = "Documento de Saída"
                btPedido.Enabled = True
            ElseIf Tipo = 0 Then
                Me.Text = "Documento de Entrada"
                btPedido.Enabled = False
            End If
        End If

        'CARREGA PEDIDO (Fornecer Tipo=2 e o Número do Pedido)
        If Numero <> -1 And Tipo = 2 Then
            TipoDOC = 1     'NFe de Saida
            'Define o tipo da NFe
            TipoTextBox.Text = 1
            'Seleciona no primeiro combo o Tipo
            cmbTipo.SelectedIndex = 0
            'Carrega o PEDIDO número XXX
            Carrega_Pedido(Numero)
        End If

        'CARREGA NFe PRONTA (Fornecer o tipo e o número da Nota)
        If Numero <> -1 And (Tipo = 0 Or Tipo = 1) Then
            'Carrega uma nota fiscal em específico (EDITAR)
            DocID = Numero
            'Carrega os dados da NFe
            TA_Docs.Fill(DsDoc_Entrada_Saida.docs, DocID)
            'Carrega os ítens da NFe
            TA_Docs_Itens.Fill(DsDoc_Entrada_Saida.docs_itens)
            btIncluir.Text = "Salvar"
            If Tipo = 1 Then
                Me.Text = "Documento de Saída"
                btPedido.Enabled = False
            ElseIf Tipo = 0 Then
                Me.Text = "Documento de Entrada"
                btPedido.Enabled = False
            End If
        End If
    End Sub

    Private Sub DocsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles DocsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.BS_Docs.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DsDoc_Entrada_Saida)
    End Sub

    Private Sub frmDoc_Entrada_Saida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carrega as formas de pagamento
        Carrega_Lista(cmbForma, "Forpag", "id", "Descricao")
        Carrega_Lista(txtCliente, "Clientes", "id", "Nome", True)
        Carrega_Lista(cmbFrete, "transportadores", "id", "Razao", True)

        txtSerie.Text = "1"
        txtCFOP.Text = "5101"

    End Sub

    Private Sub txtTipo_Leave(sender As Object, e As EventArgs) Handles txtTipo.Leave
        'Preenche a caixa de Texto Padrão.
        TipoTextBox.Text = txtTipo.Text.Substring(0, 1)
    End Sub

    Private Sub txtEstado_Leave(sender As Object, e As EventArgs) Handles txtEstado.Leave
        'Foi digitado um estado de 2 letras
        If txtEstado.Text.Length = 2 Then
            Carrega_Lista(txtCidade, "Rais", "Cod", "Municipio", True, "Estado='" & txtEstado.Text & "'")
        End If
    End Sub

    Private Sub txtCidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCidade.SelectedIndexChanged
        'Se tiver algo selecionado na cidade pega o código do município
        If txtCidade.SelectedIndex <> -1 Then
            txtCodMun.Text = cmbVal(txtCidade)
        End If
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

    Private Sub txtCFOP_Leave(sender As Object, e As EventArgs) Handles txtCFOP.Leave
        If txtCFOP.Text.IndexOf(".") > 0 Then
            txtCFOP.Text.Replace(".", "")
        End If
        If txtCFOP.Text.Length = 4 Then
            txtNatOP.Text = DLookup("Descricao", "CFOP", "CFOP='" & txtCFOP.Text & "'")
        End If
    End Sub

    Private Sub bt_CEP_Click(sender As Object, e As EventArgs) Handles bt_CEP.Click
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

    Private Sub PFPJTextBox_TextChanged(sender As Object, e As EventArgs) Handles PFPJTextBox.TextChanged
        If PFPJTextBox.Text = "F" Then
            rdPF.Checked = True
        ElseIf PFPJTextBox.Text = "J" Then
            rdPJ.Checked = True
        End If
    End Sub

    Private Sub rdPF_CheckedChanged(sender As Object, e As EventArgs) Handles rdPF.CheckedChanged
        If rdPF.Checked Then
            PFPJTextBox.Text = "F"
            Label13.Text = "CPF:"
            txtCPF_CNPJ.MaxLength = 14
        ElseIf rdPJ.Checked Then
            PFPJTextBox.Text = "J"
            Label13.Text = "CNPJ:"
            txtCPF_CNPJ.MaxLength = 18
        End If
    End Sub

    Private Sub txtCPF_CNPJ_Leave(sender As Object, e As EventArgs) Handles txtCPF_CNPJ.Leave
        'Tira todos os caracteres especiais deixando somente números
        txtCPF_CNPJ.Text = Limpa_Formatacao(txtCPF_CNPJ.Text)

        Dim CPF_CNPJ_ERRADO_BACK As Color = Color.LightCoral
        Dim CPF_CNPJ_ERRADO_FORE As Color = Color.Red
        Dim CPF_CNPJ_CERTO_BACK As Color = SystemColors.Window
        Dim CPF_CNPJ_CERTO_FORE As Color = SystemColors.ControlText

        'Valida o CPF ou CNPJ
        If PFPJTextBox.Text = "F" Then
            'Se for pessoa física valida o CPF
            If Not ValidaCPF(txtCPF_CNPJ.Text) Then
                txtCPF_CNPJ.BackColor = CPF_CNPJ_ERRADO_BACK
                txtCPF_CNPJ.ForeColor = CPF_CNPJ_ERRADO_FORE
            Else
                'Caso contrário volta à cor normal.
                txtCPF_CNPJ.BackColor = CPF_CNPJ_CERTO_BACK
                txtCPF_CNPJ.ForeColor = CPF_CNPJ_CERTO_FORE
            End If
        ElseIf PFPJTextBox.Text = "J" Then
            'Se for pessoa jurídica valida o CNPJ
            If Not ValidaCNPJ(txtCPF_CNPJ.Text) Then
                txtCPF_CNPJ.BackColor = CPF_CNPJ_ERRADO_BACK
                txtCPF_CNPJ.ForeColor = CPF_CNPJ_ERRADO_FORE
            Else
                'Caso contrário volta à cor normal.
                txtCPF_CNPJ.BackColor = CPF_CNPJ_CERTO_BACK
                txtCPF_CNPJ.ForeColor = CPF_CNPJ_CERTO_FORE
            End If
        Else
            'Caso contrário volta à cor normal.
            txtCPF_CNPJ.BackColor = CPF_CNPJ_CERTO_BACK
            txtCPF_CNPJ.ForeColor = CPF_CNPJ_CERTO_FORE
        End If

    End Sub

    Private Sub txtindIEDest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtindIEDest.SelectedIndexChanged
        Dim item As Int16
        'Verifica a seleção do usuário para ver se preenche ou não a I.E.
        item = txtindIEDest.Text.Substring(0, 1)
        'Verifica a opção e ativa a caixa de seleção
        Select Case item
            Case 1  'Contribuinte
                txtInscricao.Enabled = True
            Case 2  'Isento
                txtInscricao.Enabled = False
            Case 9  'Não contribuinte
                txtInscricao.Enabled = False
                'Já faz verificação do CFOP em caso de consumidor final
                If txtEstado.Text = "SC" Then
                    txtCFOP.Text = "5101"
                Else
                    txtCFOP.Text = "6107"
                End If
                txtCFOP_Leave(Me, e)
        End Select
        'Atualiza o campo do banco de dados
        IndIEDestTextBox.Text = item
    End Sub

    Private Sub txtIndPres_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtIndPres.SelectedIndexChanged
        'Atualiza a caixa do banco de dados com o número equivalenta à opção selecionada
        IndPresTextBox.Text = txtIndPres.Text.Substring(0, 1)
    End Sub

    Private Sub txtCodPro_Leave(sender As Object, e As EventArgs) Handles txtCodPro.Leave
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

    Private Sub txtClone_Leave(sender As Object, e As EventArgs) Handles txtClone.Leave
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


    '************************************
    '***
    '*** FUNÇÕES AUXILIÁRES
    '***
    '************************************

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim varID As Integer, varCP As Integer, varCC As Integer, varDesc As String, varNCM As String, varQtde As Integer, varUnit As Double, varTot As Double
        Dim varTipo As String, varForma As String

        'tem que estar tudo preenchido
        If txtCodPro.Text <> "" And txtClone.Text <> "" And txtQtde.Text <> "" And txtValor.Text <> "" Then
            'monta o Array para inclusão
            varID = txtDocumento.Text   'Todos os produtos adicionados depois ganham id=0
            varCP = txtCodPro.Text      'Código do produto
            varCC = txtClone.Text       'Cod Clone
            varDesc = lblMercadoria.Text & " cv " & lblClone.Text
            varNCM = DLookup("NCM", "Clones", "Mercadoria=" & txtCodPro.Text & " AND Clone=" & txtClone.Text)
            varQtde = String_to_Numero(txtQtde.Text)
            varUnit = String_to_Numero(txtValor.Text)
            varTot = varQtde * varUnit
            varForma = IIf(cmbPadrao.SelectedIndex <> -1, cmbPadrao.Text.Substring(1, 2), String.Empty)
            varTipo = IIf(cmbTipo.SelectedIndex <> -1, cmbTipo.Text.Substring(1, 2), String.Empty)
        Else
            MsgBox("Para incluir um ítem ao Documento de Saída complete:" & vbCrLf & "Mercadoria, Clone, Quantidade, Valor Unitário", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
        Try
            'faz a inclusão propriamente dita
            'dgItens.Rows.Add(varID, varCP, varCC, varDesc, varNCM, "md", varQtde, varUnit, varTot)
            TA_Docs_Itens.Inserir(1, varID, varCP, varCC, varDesc, varNCM, "md", varQtde, varUnit, varTot, varForma, varTipo, txtCFOP.Text, 0, 0, 0, 0, 0, 0)
            'Recarrega os ítens para mostrar no datagrid
            TA_Docs_Itens.Fill(DsDoc_Entrada_Saida.docs_itens)

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

    Private Sub cmbPadrao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPadrao.SelectedIndexChanged
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

    'Atualiza o combobox em função do que está no BD
    Private Sub IndIEDestTextBox_TextChanged(sender As Object, e As EventArgs) Handles IndIEDestTextBox.TextChanged
        Select Case IndIEDestTextBox.Text
            Case 1
                txtindIEDest.SelectedIndex = 0
            Case 2
                txtindIEDest.SelectedIndex = 1
            Case 9
                txtindIEDest.SelectedIndex = 2
        End Select
    End Sub

    Private Sub IndPresTextBox_TextChanged(sender As Object, e As EventArgs) Handles IndPresTextBox.TextChanged
        Select Case IndPresTextBox.Text
            Case 0 '0 - Não se Aplica
                txtIndPres.SelectedIndex = 0
            Case 1 '1 - Operação Presencial
                txtIndPres.SelectedIndex = 1
            Case 2 '2 - Não Presencial, Internet
                txtIndPres.SelectedIndex = 2
            Case 3 '3 - Não Presencial, Teleatendimento
                txtIndPres.SelectedIndex = 3
            Case 9 '9 - Não Presencia, Outros
                txtIndPres.SelectedIndex = 4
        End Select
    End Sub

    Private Sub btIncluir_Click(sender As Object, e As EventArgs) Handles btIncluir.Click
        If btIncluir.Text = "Incluir" Then
            txtID.Text = txtDocumento.Text
            BS_Docs.EndEdit()
            TableAdapterManager.UpdateAll(DsDoc_Entrada_Saida)
        End If
    End Sub

    Private Sub txtCliente_Leave(sender As Object, e As EventArgs) Handles txtCliente.Leave
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

    '******************************
    '***
    '***  OPERAÇÕES COM OS DOCUMENTOS.
    '***
    '******************************
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
                    txtFone.Text = NaoNulo(.Item("Fone"))
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
End Class