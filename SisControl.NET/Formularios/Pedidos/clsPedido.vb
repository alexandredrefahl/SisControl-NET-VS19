
'*
'* CLASSE DO CORPO DO PEDIDO
'*

Imports System.Text.RegularExpressions

Public Class clsPedido

    'Inicializa o ítem com lista
    Private _Itens As List(Of Pedidos_Itens)
    Private _Duplicatas As List(Of Pedidos_Duplicatas)

    Public Sub New()
        'Inicializa somente os ítens que são obrigatórios
        _Itens = New List(Of Pedidos_Itens)()
        _Duplicatas = New List(Of Pedidos_Duplicatas)
    End Sub


    '* Inicia a lista das propriedades
    '*
    '* Uma variável local privada para economizar memória
    '* E métodos para pegar e setar as variáveis para fazer isso localmente
    '*

    Private _id As Integer
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Data As Date
    Public Property DataPedido() As Date
        Get
            Return _Data
        End Get
        Set(ByVal value As Date)
            _Data = value
        End Set
    End Property
    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property
    Private _CodCli As Integer
    Public Property CodCli() As Integer
        Get
            Return _CodCli
        End Get
        Set(ByVal value As Integer)
            _CodCli = value
        End Set
    End Property
    Private _Endereco As String
    Public Property Endereco() As String
        Get
            Return _Endereco
        End Get
        Set(ByVal value As String)
            _Endereco = value
        End Set
    End Property
    Private _Num As String
    Public Property Num() As String
        Get
            Return _Num
        End Get
        Set(ByVal value As String)
            _Num = value
        End Set
    End Property
    Private _Bairro As String
    Public Property Bairro() As String
        Get
            Return _Bairro
        End Get
        Set(ByVal value As String)
            _Bairro = value
        End Set
    End Property
    Private _Cidade As String
    Public Property Cidade() As String
        Get
            Return _Cidade
        End Get
        Set(ByVal value As String)
            _Cidade = value
        End Set
    End Property
    Private _CodCidade As String
    Public Property CodCidade() As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property
    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property
    Private _CEP As String
    Public Property CEP() As String
        Get
            Return _CEP
        End Get
        Set(ByVal value As String)
            _CEP = value
        End Set
    End Property
    Private _Pais As String
    Public Property Pais() As String
        Get
            Return _Pais
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property
    Private _codPais As String
    Public Property codPais() As String
        Get
            Return _codPais
        End Get
        Set(ByVal value As String)
            _codPais = value
        End Set
    End Property
    Private _Fone As String
    Public Property Fone() As String
        Get
            Return _Fone
        End Get
        Set(ByVal value As String)
            _Fone = value
        End Set
    End Property
    Private _Celular As String
    Public Property Celular() As String
        Get
            Return _Celular
        End Get
        Set(ByVal value As String)
            _Celular = value
        End Set
    End Property
    Private _Fax As String
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property
    Private _PFPJ As String
    Public Property PFPJ() As String
        Get
            Return _PFPJ
        End Get
        Set(ByVal value As String)
            _PFPJ = value
        End Set
    End Property
    Private _CNPJ_CPF As String
    Public Property CNPJ_CPF() As String
        Get
            Return _CNPJ_CPF
        End Get
        Set(ByVal value As String)
            _CNPJ_CPF = value
        End Set
    End Property
    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Private _Inscricao As String
    Public Property Inscricao() As String
        Get
            Return _Inscricao
        End Get
        Set(ByVal value As String)
            _Inscricao = value
        End Set
    End Property
    Private _Contato As String
    Public Property Contato() As String
        Get
            Return _Contato
        End Get
        Set(ByVal value As String)
            _Contato = value
        End Set
    End Property
    Private _Vendedor As String
    Public Property Vendedor() As String
        Get
            Return _Vendedor
        End Get
        Set(ByVal value As String)
            _Vendedor = value
        End Set
    End Property
    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Private _DataAprovado As Date
    Public Property DataAprovado() As Nullable(Of Date)
        Get
            Return _DataAprovado
        End Get
        Set(ByVal value As Nullable(Of Date))
            _DataAprovado = value
        End Set
    End Property
    Private _AprovadoPor As String
    Public Property AprovadoPor() As String
        Get
            Return _AprovadoPor
        End Get
        Set(ByVal value As String)
            _AprovadoPor = value
        End Set
    End Property
    Private _AprovadorRG As String
    Public Property AprovadorRG() As String
        Get
            Return _AprovadorRG
        End Get
        Set(ByVal value As String)
            _AprovadorRG = value
        End Set
    End Property
    Private _Valor As Double
    Public Property Valor() As Double
        Get
            Return _Valor
        End Get
        Set(ByVal value As Double)
            _Valor = value
        End Set
    End Property
    Private _NumMudas As Integer
    Public Property NumMudas() As Integer
        Get
            Return _NumMudas
        End Get
        Set(ByVal value As Integer)
            _NumMudas = value
        End Set
    End Property
    Private _NumItens As Integer
    Public Property NumItens() As Integer
        Get
            Return _NumItens
        End Get
        Set(ByVal value As Integer)
            _NumItens = value
        End Set
    End Property
    Private _PrazoEntrega As Date
    Public Property PrazoEntrega() As Date
        Get
            Return _PrazoEntrega
        End Get
        Set(ByVal value As Date)
            _PrazoEntrega = value
        End Set
    End Property
    Private _FormaPagamento As Integer
    Public Property FormaPagamento() As Integer
        Get
            Return _FormaPagamento
        End Get
        Set(ByVal value As Integer)
            _FormaPagamento = value
        End Set
    End Property
    Private _CFOP As String
    Public Property CFOP() As String
        Get
            Return _CFOP
        End Get
        Set(ByVal value As String)
            _CFOP = value
        End Set
    End Property
    Private _NatOP As String
    Public Property NaturezaOP() As String
        Get
            Return _NatOP
        End Get
        Set(ByVal value As String)
            _NatOP = value
        End Set
    End Property
    Private _ModFrete As Integer = 1
    Public Property ModFrete() As Integer
        Get
            Return _ModFrete
        End Get
        Set(ByVal value As Integer)
            _ModFrete = value
        End Set
    End Property
    Private _valFrete As Double
    Public Property ValorFrete() As Double
        Get
            Return _valFrete
        End Get
        Set(ByVal value As Double)
            _valFrete = value
        End Set
    End Property
    Private _valSeguro As Double
    Public Property ValorSeguro() As Double
        Get
            Return _valSeguro
        End Get
        Set(ByVal value As Double)
            _valSeguro = value
        End Set
    End Property
    Private _valDesconto As Double
    Public Property ValorDesconto() As Double
        Get
            Return _valDesconto
        End Get
        Set(ByVal value As Double)
            _valDesconto = value
        End Set
    End Property
    Private _Obs As String
    Public Property Observacao() As String
        Get
            Return _Obs
        End Get
        Set(ByVal value As String)
            _Obs = value
        End Set
    End Property
    Private _Tra As String
    Public Property Transportadora() As String
        Get
            Return _Tra
        End Get
        Set(ByVal value As String)
            _Tra = value
        End Set
    End Property

    '* As duas propriedades que são compostas por listas

    Public ReadOnly Property Itens() As List(Of Pedidos_Itens)
        Get
            Return _Itens
        End Get
    End Property

    Public ReadOnly Property Duplicatas() As List(Of Pedidos_Duplicatas)
        Get
            Return _Duplicatas
        End Get
    End Property

    Public Sub Incluir(Optional ByVal AutoCalc As Boolean = False)
        Dim SQL As String

        'Opcção de fazer o resumo dos campos Valor, NMudas e NItens Automaticamente
        If AutoCalc Then
            Calcula_Totais()
        End If

        'Cria a base da SQL
        SQL = "INSERT INTO Pedidos SET "
        SQL &= Monta_SQL()

        'Executa propriamente dita
        Try
            ExecutaSQL(SQL)
            'Pega o id do pedido
            _id = DMax("id", "Pedidos")

            'Inclui os ítens do pedido
            Incluir_Itens()

            'Inclui as duplicatas do pedido
            Incluir_Duplicatas()

            MsgBox("Pedido, ítens e duplicatas incluídos com sucesso!" & vbCrLf & "Pedido: " & _id, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir o pedido atual" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub Incluir_Itens()
        'Passa por todos os ítens
        For i As Integer = 0 To _Itens.Count - 1
            'Pega o id da inclusão
            _Itens(i)._Pedido_id = _id
            'Inclui cada um dos itens
            _Itens(i).Incluir()
        Next
    End Sub

    Private Sub Incluir_Duplicatas()
        'Passa por todos os ítens
        For i As Integer = 0 To _Duplicatas.Count - 1
            'Pega o ID da inclusão
            _Duplicatas(i).Pedido_Id = _id
            'Incluir cada um dos ítens
            _Duplicatas(i).Incluir()
        Next
    End Sub

    Public Sub Alterar()
        Dim SQL As String

        SQL = "UPDATE Pedidos SET "
        SQL &= Monta_SQL()
        SQL &= " WHERE id=" & _id

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar os dados do pedido atual" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Public Sub Carrega_Pedido_WEB(ByVal Pedido_ID As Integer)
        Dim SQL As String, DT As DataTable
        'Selecionar pedido
        'SQL = "SELECT order_id, customer_id, firstname,lastname, email, telephone,fax,custom_field,payment_address_1,payment_address_2,payment_city,payment_postcode,payment_country,payment_zone,shipping_method,shipping_code,date_added,comment FROM clonagen_ocar931.oc6p_order WHERE order_id=" & Pedido_ID

        'Essa QUERY não é padrão do OpenCart, ela foi montada para facilitar a integração do sistema
        SQL = "SELECT * FROM clonagen_ocar931.oc6p_View_Pedido WHERE id=" & Pedido_ID

        'Carrega os dados do pedido selecionado (True para Carregar Pedidos WEB)
        DT = SQLQuery(SQL, True)
        'Se localizou algum registro
        If DT.Rows.Count > 0 Then
            '*
            '* CARREGA OS DADOS DO PEDIDO
            '*
            With DT.Rows(0)
                _id = .Item("id")
                _Data = .Item("data")
                _Cliente = NaoNulo(.Item("Nome") & " " & .Item("Sobrenome"))
                _CodCli = NaoNulo(.Item("CodCli"))
                _CFOP = "6108"
                _Endereco = NaoNulo(.Item("endereco"))
                _Num = 0
                _Bairro = NaoNulo(.Item("bairro"))
                _Cidade = NaoNulo(.Item("cidade"))
                _CodCidade = 0
                _Estado = NaoNulo(.Item("SiglaEstado"))
                _CEP = NaoNulo(.Item("cep"))
                _Pais = NaoNulo(.Item("pais"))
                _codPais = 0
                _Fone = ""
                _Celular = NaoNulo(.Item("Telefone"))
                _Fax = NaoNulo(.Item("Fax"))
                _CNPJ_CPF = NaoNulo(.Item("CPF_CNPJ"))
                'Usando Expressões regulares para retirar a expresão
                '{"3":"1","4":"3790686","2":"00385491905"} String Padrão
                Dim varCPF_CNPJ As String = _CNPJ_CPF.Replace(".", "")
                varCPF_CNPJ = varCPF_CNPJ.Replace("-", "")
                'Esse Regex quer dizer Uma expressão entre aspas com 11 a 14 posições aceitando dígitos de 0 a 9 incluindo - e .
                Dim rgxCPF_CNPJ As New Regex("[0-9-.]{11,14}")
                'Verifica o retorno (1 padrão de 11 dígitos)
                Dim Matches As MatchCollection = rgxCPF_CNPJ.Matches(varCPF_CNPJ)
                'Se encontrou pelo menos um
                If Matches.Count > 0 Then
                    _CNPJ_CPF = Matches.Item(0).Value
                End If
                'Esse Regex quer dizer Uma expressão entre aspas com 7 a 9 posições aceitando dígitos de 0 a 9 incluindo - e .
                Dim rgxRGIE As New Regex("[0-9-.]{7,9}")
                Matches = rgxRGIE.Matches(varCPF_CNPJ)
                'Se encontrou pelo menos um
                If Matches.Count > 0 Then
                    _Inscricao = Matches.Item(0).Value
                End If
                _PFPJ = IIf(_CNPJ_CPF.Length > 11, "J", "F")
                _email = NaoNulo(.Item("email"))
                _Contato = NaoNulo(.Item("Nome"))
                _Vendedor = "Loja Online"
                _Status = 1
                _AprovadoPor = NaoNulo(.Item("Nome"))
                _AprovadorRG = _CNPJ_CPF

                '* Faz uma verificação para achar o CFOP Adequado
                'Estes valores são colocados manualmente pois o OpenCart não usa assim
                If _Estado = "SC" Then
                    'Venda de mercadoria dentro do estado
                    _CFOP = "5102"
                Else
                    'Venda para consumidor final fora do estado
                    _CFOP = "6108"
                End If
                'Já procura a Descrição do CFOP cadastrada no Banco de Dados
                _NatOP = DLookup("Descricao", "CFOP", "CFOP=" & _CFOP)
                '_PrazoEntrega = .Item("Prazo")
                _FormaPagamento = 1 'A vista
                _ModFrete = 1
                _Tra = NaoNulo(.Item("FreteTipo"))
                '_Tra = Right(.Item("CodPostagem"), 5)
                _valFrete = Format(.Item("valfrete"), "N2")
                _valSeguro = 0
                _valDesconto = 0
                _Obs = NaoNulo(.Item("observacao"))

            End With
            'libera memória
            DT = Nothing

            '*
            '* CARREGA OS ÍTENS DO PEDIDO
            '*

            Dim DT_ITENS As DataTable, DR As DataRow
            SQL = "SELECT * FROM clonagen_ocar931.oc6p_order_product WHERE Order_id=" & _id
            'Recupera os ítens
            DT_ITENS = SQLQuery(SQL, True)

            'Verifica se tem ítens cadastrados
            If DT_ITENS.Rows.Count > 0 Then
                For Each DR In DT_ITENS.Rows
                    Dim Item As New Pedidos_Itens
                    Item._CodProduto = DR("model").ToString.Substring(0, 2)
                    Item._Clone = DR("model").ToString.Substring(3, 4)
                    Item._Descricao = DR("Name")
                    Item._Forma = "Raiz Nua"
                    Item._CFOP = _CFOP
                    'Tem que pesquisar no Banco de Dados
                    Item._NCM = ""
                    Item._pCofins = 0
                    Item._pICMS = 0
                    Item._pPIS = 0
                    Item._QtdeAtendida = 0
                    Item._Quantidade = DR("quantity")
                    Item._Unidade = "md"
                    Item._Unitario = DR("price")
                    Item._Status_Item = "0"
                    Item._Tipo_Muda = "Aclimatizada"
                    Item._Total = Item._Quantidade * Item._Unitario
                    'Adiciona um ítem ao pedido
                    _Itens.Add(Item)
                Next
            End If
        End If
    End Sub

    Public Sub Carrega(ByVal Pedido_ID As Integer)
        Dim SQL As String, DT As DataTable

        'Selecionar pedido
        SQL = "SELECT * FROM Pedidos WHERE id=" & Pedido_ID
        'Carrega os dados do pedido selecionado
        DT = SQLQuery(SQL)
        'Se localizou algum registro
        If DT.Rows.Count > 0 Then
            '*
            '* CARREGA OS DADOS DO PEDIDO
            '*
            With DT.Rows(0)
                _id = .Item("id")
                _Data = .Item("data")
                _Cliente = NaoNulo(.Item("Cliente"))
                _CodCli = NaoNulo(.Item("CodCli"))
                _Endereco = NaoNulo(.Item("endereco"))
                _Num = NaoNulo(.Item("Num"))
                _Bairro = NaoNulo(.Item("Bairro"))
                _Cidade = NaoNulo(.Item("Cidade"))
                _CodCidade = NaoNulo(.Item("CodCidade"))
                _Estado = NaoNulo(.Item("Estado"))
                _CEP = NaoNulo(.Item("cep"))
                _Pais = NaoNulo(.Item("Pais"))
                _codPais = NaoNulo(.Item("CodPais"))
                _Fone = NaoNulo(.Item("Fone"))
                _Celular = NaoNulo(.Item("Celular"))
                _Fax = NaoNulo(.Item("Fax"))
                _PFPJ = NaoNulo(.Item("PFPJ"))
                _CNPJ_CPF = NaoNulo(.Item("CNPJ_CPF"))
                _email = NaoNulo(.Item("email"))
                _Inscricao = NaoNulo(.Item("Inscricao"))
                _Contato = NaoNulo(.Item("Contato"))
                _Vendedor = NaoNulo(.Item("vendedor"))
                _Status = NaoNulo(.Item("Status"))
                _AprovadoPor = NaoNulo(.Item("AprovadoPor"))
                _AprovadorRG = NaoNulo(.Item("RGAprovado"))
                _Valor = .Item("Valor")
                _NumMudas = .Item("Nmudas")
                _NumItens = .Item("NItens")
                _PrazoEntrega = .Item("Prazo")
                _FormaPagamento = .Item("Forpag")
                _CFOP = NaoNulo(.Item("cfop"))
                _NatOP = NaoNulo(.Item("NaturezaOP"))
                _ModFrete = NaoNulo(.Item("ModFrete"))
                _valFrete = NaoNulo(.Item("ValFrete"))
                _valSeguro = NaoNulo(.Item("valSeguro"))
                _valDesconto = NaoNulo(.Item("valDesconto"))
                _Obs = NaoNulo(.Item("Observacoes"))
            End With

            '*
            '* CARREGA OS ITENS DO PEDIDO
            '*



            '*
            '* CARREGA AS DUPLICATAS DO PEDIDO
            '*
            DT = Nothing
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Calcula_Totais()
        Dim i As Integer = 0
        _Valor = 0
        _NumItens = 0
        _NumMudas = 0

        'Verifica quanto ítens
        _NumItens = _Itens.Count

        'Soma o total de mudas e o total de valor
        For i = 0 To _Itens.Count - 1
            _Valor += _Itens(i)._Total
            _NumMudas += _Itens(i)._Quantidade
        Next

    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String = ""

        SQL &= "Data = '" & Format(_Data, "yyyy-MM-dd") & "' , "
        SQL &= "Cliente = '" & _Cliente & "' , "
        SQL &= "CodCli = " & _CodCli & " , "
        SQL &= "Endereco = " & Texto_Vazio(_Endereco) & " , "
        SQL &= "Num = " & Texto_Vazio(_Num) & " , "
        SQL &= "Bairro = " & Texto_Vazio(_Bairro) & " , "
        SQL &= "Cidade = " & Texto_Vazio(_Cidade) & " , "
        SQL &= "CodCidade = " & Texto_Vazio(_CodCidade) & " , "
        SQL &= "Estado = " & Texto_Vazio(_Estado) & " , "
        SQL &= "CEP = " & Texto_Vazio(_CEP) & " , "
        SQL &= "Pais = " & Texto_Vazio(_Pais) & " , "
        SQL &= "CodPais = " & Texto_Vazio(_codPais) & " , "
        SQL &= "Fone = " & Texto_Vazio(_Fone) & " , "
        SQL &= "Celular = " & Texto_Vazio(_Celular) & " , "
        SQL &= "Fax = " & Texto_Vazio(_Fax) & " , "
        SQL &= "PFPJ = '" & _PFPJ & "' , "
        SQL &= "CNPJ_CPF = " & Texto_Vazio(_CNPJ_CPF) & ", "
        SQL &= "email = " & Texto_Vazio(_email) & " , "
        SQL &= "Inscricao = " & Texto_Vazio(_Inscricao) & " , "
        SQL &= "Contato = " & Texto_Vazio(_Contato) & " , "
        SQL &= "Vendedor = " & Texto_Vazio(_Vendedor) & " , "
        SQL &= "Status = " & Texto_Vazio(_Status) & " , "
        SQL &= "Aprovado = " & IIf(IsDBNull(_DataAprovado), "NULL", "'" & Format(_DataAprovado, "yyyy-MM-dd") & "'") & " ,"
        SQL &= "AprovadoPor = " & Texto_Vazio(_AprovadoPor) & " , "
        SQL &= "RGAprovado = " & Texto_Vazio(_AprovadorRG) & " , "
        SQL &= "Valor = " & Numero_to_SQL(_Valor) & " , "
        SQL &= "NMudas = " & _NumMudas & " , "
        SQL &= "NItens = " & _NumItens & " , "
        SQL &= "Prazo = " & IIf(IsDBNull(_PrazoEntrega), "NULL", "'" & Format(_PrazoEntrega, "yyyy-MM-dd") & "'") & " ,"
        SQL &= "ForPag = " & _FormaPagamento & " , "
        SQL &= "CFOP = " & Texto_Vazio(_CFOP) & " , "
        SQL &= "NaturezaOP = " & Texto_Vazio(_NatOP) & " , "
        SQL &= "ModFrete = " & Texto_Vazio(_ModFrete) & " , "
        SQL &= "ValFrete = " & Numero_to_SQL(_valFrete) & " , "
        SQL &= "ValSeguro = " & Numero_to_SQL(_valSeguro) & " , "
        SQL &= "ValDesconto = " & Numero_to_SQL(_valDesconto) & ", "
        SQL &= "Observacoes = " & Texto_Vazio(_Obs) & ", "
        SQL &= "Transportadora = " & Texto_Vazio(_Tra)
        Return SQL

    End Function


End Class


'*
'* CLASSE PARA OS ÍTENS DO PEDIDO
'*


Public Class Pedidos_Itens

    Public _id As Integer = -1
    Public _Pedido_id As Integer = -1
    Public _CodProduto As String
    Public _Clone As String
    Public _Descricao As String
    Public _NCM As String
    Public _Unidade As String = "md"
    Public _Quantidade As Integer = 0
    Public _Unitario As Double = 0
    Public _Total As Double = 0
    Public _QtdeAtendida As Double = 0
    Public _Status_Item As String = 0
    Public _Forma As String
    Public _Tipo_Muda As String
    Public _CFOP As String
    Public _pICMS As Double = 0
    Public _pPIS As Double = 0
    Public _pCofins As Double = 0
    Private _vICMS As Double = 0
    Private _vPIS As Double = 0
    Private _vCOFINS As Double = 0

    Public Sub Atualizar()
        Dim SQL As String
        SQL = "UPDATE pedidos_itens SET "
        SQL &= Monta_SQL()
        SQL &= " WHERE id=" & _id

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao salvar o ítem " & _id & " do Pedido " & _Pedido_id, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Public Sub Incluir()
        Dim SQL As String
        SQL = "INSERT INTO pedidos_itens SET "
        SQL &= Monta_SQL()

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao incluir o ítem do Pedido " & _Pedido_id, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Calcula_totais()
        _Total = _Quantidade * _Unitario
        _vPIS = _Total * _pPIS
        _vCOFINS = _Total * _pCofins
        _vICMS = _Total * _pICMS
    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String = ""

        Calcula_totais()

        SQL &= "Pedido_id =" & IIf(_Pedido_id = -1, "NULL", _Pedido_id) & ","
        SQL &= "CodPro = " & _CodProduto & ","
        SQL &= "Clone = " & _Clone & ","
        SQL &= "Descricao = " & Texto_Vazio(_Descricao) & " , "
        SQL &= "NCM = " & Texto_Vazio(_NCM) & ","
        SQL &= "Unid = " & Texto_Vazio(_Unidade) & " , "
        SQL &= "Quantidade = " & _Quantidade & ", "
        SQL &= "Unitario = " & Numero_to_SQL(_Unitario) & " , "
        SQL &= "Total = " & Numero_to_SQL(_Total) & " , "
        SQL &= "Atendido = " & _QtdeAtendida & " , "
        SQL &= "Status = " & Texto_Vazio(_Status_Item) & " , "
        SQL &= "Forma = " & Texto_Vazio(_Forma) & " , "
        SQL &= "Tipo = " & Texto_Vazio(_Tipo_Muda) & " , "
        SQL &= "CFOP = " & Texto_Vazio(_CFOP) & " , "
        SQL &= "ICMS = " & Numero_to_SQL(_pICMS) & " , "
        SQL &= "PIS = " & Numero_to_SQL(_vPIS) & " , "
        SQL &= "COFINS = " & Numero_to_SQL(_pCofins) & " , "
        SQL &= "vICMS = " & Numero_to_SQL(_vICMS) & " , "
        SQL &= "vPIS = " & Numero_to_SQL(_vPIS) & " , "
        SQL &= "vCOFINS = " & Numero_to_SQL(_vCOFINS)
        Return SQL
    End Function

End Class

'*
'* CLASSE PARA AS DUPLICATAS DO PEDIDO
'*

Public Class Pedidos_Duplicatas

    '*
    '* Propriedades
    '* 
    Private _id As Integer
    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _Pedido_ID As Integer
    Public Property Pedido_Id As Integer
        Get
            Return _Pedido_ID
        End Get
        Set(ByVal value As Integer)
            _Pedido_ID = value
        End Set
    End Property

    Private _Vencimento As Date
    Public Property Vencimento As Date
        Get
            Return _Vencimento
        End Get
        Set(ByVal value As Date)
            _Vencimento = value
        End Set
    End Property
    Private _Valor As Double
    Public Property Valor As Double
        Get
            Return _Valor
        End Get
        Set(ByVal value As Double)
            _Valor = value
        End Set
    End Property
    Private _Descricao As String
    Public Property Descricao As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property
    Private _Lancado As Nullable(Of Boolean)
    Public Property Lancado As Nullable(Of Boolean)
        Get
            Return _Lancado
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            _Lancado = value
        End Set
    End Property

    Private Function Monta_SQL() As String
        Dim SQL As String = ""

        SQL &= "Doc_ID = NULL , "           'Doc_ID sempre vai ser Null no pedido
        SQL &= "Pedido_id = " & _Pedido_ID & " , "
        SQL &= "Vencimento = '" & Format(_Vencimento, "yyyy-MM-dd") & "' , "
        SQL &= "Valor = " & Numero_to_SQL(_Valor) & " , "
        SQL &= "Descricao = " & Texto_Vazio(_Descricao) & " , "
        SQL &= "Lancado = " & IIf(IsDBNull(_Lancado), "0", IIf(_Lancado, "1", "0"))

        Return SQL
    End Function

    Public Sub Incluir()
        Dim SQL As String

        'Monta a SQL base
        SQL = "INSERT INTO duplicatas SET "
        SQL &= Monta_SQL()
        Console.WriteLine("Classe Pedidos: " & SQL)

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Não foi possível incluir uma duplicata do Pedido " & _Pedido_ID & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Public Sub Atualiza()
        Dim SQL As String

        If IsDBNull(_id) Then
            MsgBox("Não é possível atualizar esta suplicata pois ela não tem um ID válido")
            Exit Sub
        End If

        'Monta a SQL base
        SQL = "UPDATE duplicatas SET "
        SQL &= Monta_SQL()
        SQL &= " WHERE id=" & _id

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Não foi possível atualizar a duplicata " & _id & " do pedido " & _Pedido_ID & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

End Class
