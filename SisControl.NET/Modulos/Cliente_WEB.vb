Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class Cliente_WEB
    Private _idWEB As Integer
    Private _Nome As String
    Private _Num As String
    Private _Sobrenome As String
    Private _Email As String
    Private _Telefone As String
    Private _Fax As String
    Private _Celular As String
    Private _Neewsletter As Boolean
    Private _addID As Integer
    Private _Endereco As String
    Private _Bairro As String
    Private _Cidade As String
    Private _Estado As String
    Private _CEP As String
    Private _CPF_CNPJ As String
    Private _RG_IE As String
    Private _Pais As String
    Private _DataCadastro As String
    Private _PFPJ As Char

    'Dados de acesso ao OpenCart On Line
    Private Const OC_CONNECTION_STRING As String = "server=clona-gen.com.br;user id=clonagen_remoto;password=16240423;database=clonagen_ocar931"
    Private Const Tabela_Cliente As String = "oc6p_customer"
    Private Const Tabela_Endereco As String = "oc6p_address"
    Private Const Tabela_Zonas As String = "oc6p_zone"
    Private Const Tabela_Pais As String = "oc6p_geo_zone"

    ''' <summary>
    ''' id do cliente no OpenCart
    ''' </summary>
    Public Property idWEB As Integer
        Get
            Return _idWEB
        End Get
        Set(value As Integer)
            _idWEB = value
        End Set
    End Property

    ''' <summary>
    ''' Nome
    ''' </summary>
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property

    ''' <summary>
    ''' Sobrenome
    ''' </summary>
    Public Property Sobrenome As String
        Get
            Return _Sobrenome
        End Get
        Set(value As String)
            _Sobrenome = value
        End Set
    End Property

    ''' <summary>
    ''' E-mail
    ''' </summary>
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property

    ''' <summary>
    ''' Telefone do cliente
    ''' </summary>
    Public Property Telefone As String
        Get
            Return _Telefone
        End Get
        Set(value As String)
            _Telefone = value
        End Set
    End Property

    ''' <summary>
    ''' Fax
    ''' </summary>
    Public Property Fax As String
        Get
            Return _Fax
        End Get
        Set(value As String)
            _Fax = value
        End Set
    End Property

    ''' <summary>
    ''' Se deseja ou não receber as novidades
    ''' </summary>
    Public Property Newsletter As Boolean
        Get
            Return _Neewsletter
        End Get
        Set(value As Boolean)
            _Neewsletter = value
        End Set
    End Property

    ''' <summary>
    ''' ID da tabela endereço
    ''' </summary>
    Public Property addID As String
        Get
            Return _addID
        End Get
        Set(value As String)
            _addID = value
        End Set
    End Property

    ''' <summary>
    ''' Endereço
    ''' </summary>
    Public Property Endereco As String
        Get
            Return _Endereco
        End Get
        Set(value As String)
            _Endereco = value
        End Set
    End Property

    ''' <summary>
    ''' Bairro
    ''' </summary>
    Public Property Bairro As String
        Get
            Return _Bairro
        End Get
        Set(value As String)
            _Bairro = value
        End Set
    End Property

    ''' <summary>
    ''' Cidade
    ''' </summary>
    Public Property Cidade As String
        Get
            Return _Cidade
        End Get
        Set(value As String)
            _Cidade = value
        End Set
    End Property

    ''' <summary>
    ''' Estado
    ''' </summary>
    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    ''' <summary>
    ''' CEP
    ''' </summary>
    Public Property CEP As String
        Get
            Return _CEP
        End Get
        Set(value As String)
            _CEP = value
        End Set
    End Property

    ''' <summary>
    ''' CPF ou CNPJ conforme o caso
    ''' </summary>
    Public Property CPF_CNPJ As String
        Get
            Return _CPF_CNPJ
        End Get
        Set(value As String)
            _CPF_CNPJ = value
        End Set
    End Property

    ''' <summary>
    ''' RG ou Inscrição Estadual conforme o caso
    ''' </summary>
    Public Property RG_IE As String
        Get
            Return _RG_IE
        End Get
        Set(value As String)
            _RG_IE = value
        End Set
    End Property

    ''' <summary>
    ''' País
    ''' </summary>
    Public Property Pais As Integer
        Get
            Return _Pais
        End Get
        Set(value As Integer)
            _Pais = value
        End Set
    End Property

    ''' <summary>
    ''' Data do Cadastro
    ''' </summary>
    Public Property DataCadastro As String
        Get
            Return _DataCadastro
        End Get
        Set(value As String)
            _DataCadastro = value
        End Set
    End Property


    ''' <summary>
    ''' Pega os dados do cliente OpenCart e preenche o objeto
    ''' </summary>
    Public Sub Carrega_Dados_Cliente(ClienteID As Integer)
        Dim SQL As String = ""
        Dim DR As DataRow

        'Se não estiver conectado pelo IP já 
        If Not Conectado Then
            Exit Sub
        End If

        'Define as variaveis da biblioteca MySQL
        Dim myConn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myRead As MySqlDataReader
        Dim myData As New DataTable
        Dim myAddress As New DataTable

        Console.WriteLine(SQL)
        'Atribui o comando SQL
        myConn.ConnectionString = OC_CONNECTION_STRING

        'Tenta abrir a conexao
        Try
            myConn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & vbCrLf & myerror.Message)
            myConn.Close()
            myConn.Dispose()
            Exit Sub
        End Try

        'Se conseguiu abrir a conexao então executa o resto
        Try
            'Monta a SQL com estratégias para ler os campos mistos
            'SQL = "SELECT *,REPLACE(custom_field,'" & Chr(22) & "','|') as campo_misto FROM " & Tabela_Cliente & " WHERE customer_id=" & ClienteID '

            SQL = "SELECT * FROM oc6p_View_Cadastro_Cliente WHERE customer_id=" & ClienteID

            'Define o tipo de comando - TEXT = SQL
            myCommand.Connection = myConn
            'Define o tipo do comando
            myCommand.CommandType = CommandType.Text
            myCommand.CommandTimeout = MY_TIMEOUT
            'Define a SQL em si
            myCommand.CommandText = SQL
            'Executa o DataReader
            myRead = myCommand.ExecuteReader(CommandBehavior.SingleResult)
            'Carrega a(s) linha(s) no DataTable
            myData.Load(myRead)
            DR = myData.Rows(0)    'Seleciona uma View Criada com todos os dados Relacionados

            'Libera a Memoria
            myCommand.Dispose()
            myConn.Close()
            myConn.Dispose()
        Catch ex As Exception
            MsgBox("Erro ao abrir a conexão: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            'Libera a memoria
            myCommand.Dispose()
            myConn.Close()
            myConn.Dispose()
            Exit Sub
        End Try

        'Povoa os campos da classe com os dados
        With DR
            _Nome = .Item("firstname")
            _Sobrenome = .Item("lastname")
            _Email = .Item("email")
            _Telefone = .Item("telephone")
            _Fax = .Item("fax")
            _CPF_CNPJ = .Item("campo_misto")
            'Usando Expressões regulares para retirar a expresão
            '{"3":"1","4":"3790686","2":"00385491905"} String Padrão
            Dim varCPF_CNPJ As String = _CPF_CNPJ.Replace(".", "")
            varCPF_CNPJ = varCPF_CNPJ.Replace("-", "")
            'Esse Regex quer dizer Uma expressão entre aspas com 11 a 14 posições aceitando dígitos de 0 a 9 incluindo - e .
            Dim rgxCPF_CNPJ As New Regex("[0-9-.]{11,14}")
            'Verifica o retorno (1 padrão de 11 dígitos)
            Dim Matches As MatchCollection = rgxCPF_CNPJ.Matches(varCPF_CNPJ)
            'Se encontrou pelo menos um
            If Matches.Count > 0 Then
                _CPF_CNPJ = Matches.Item(0).Value
            End If
            'Esse Regex quer dizer Uma expressão entre aspas com 7 a 9 posições aceitando dígitos de 0 a 9 incluindo - e .
            Dim rgxRGIE As New Regex("[0-9-.]{7,9}")
            Matches = rgxRGIE.Matches(varCPF_CNPJ)
            'Se encontrou pelo menos um
            If Matches.Count > 0 Then
                _RG_IE = Matches.Item(0).Value
            End If
            _Endereco = .Item("address_1")
            _Bairro = .Item("address_2")
            _Cidade = .Item("city")
            _CEP = .Item("postcode")
            _Estado = .Item("code")
            _Pais = .Item("Name")
        End With
    End Sub

    ''' <summary>
    ''' Insere os dados do Objeto no Banco de dados Local
    ''' </summary>
    Public Sub Insere_Cliente_Local()
        Dim conn As New MySqlConnection(MY_SQL_CONNECTION)

        'Cria o comando MySQL
        Dim SQL As New MySqlCommand()
        SQL.Connection = conn

        'Monta a SQL Base para a operação
        SQL.CommandText = "INSERT INTO clientes SET `Nome` = @nome, `Endereco`= @Endereco, `Num` = @Num, `Bairro` = @Bairro, `Cidade` = @Cidade, `Estado` = @Estado, `CEP` = @CEP, `PFPJ` = @PFPJ, `CPF_CNPJ` = @CPF_CNPJ, `RG_IE` = @RG_IE, `Fone` = @Fone, `Fax` = @Fax, `Celular` = @Celular, `email` = @email, `Contato` = @Contato, `SiteCod` = @SiteCod, `mark` = 0"

        'Preenche os parametros (teve que ser feito dessa forma por conta do QRCode que não dá para incluir direto
        With SQL.Parameters
            .AddWithValue("@nome", _Nome & " " & _Sobrenome)
            .AddWithValue("@Endereco", _Endereco)
            .AddWithValue("@Num", _Num)
            .AddWithValue("@Bairro", _Bairro)
            .AddWithValue("@Cidade", _Cidade)
            .AddWithValue("@Estado", _Estado)
            .AddWithValue("@CEP", _CEP)
            .AddWithValue("@PFPJ", _PFPJ)
            .AddWithValue("@CPF_CNPJ", _CPF_CNPJ)
            .AddWithValue("@RG_IE", _RG_IE)
            .AddWithValue("@Fone", _Telefone)
            .AddWithValue("@Fax", _Fax)
            .AddWithValue("@Celular", _Celular)
            .AddWithValue("@email", _Email)
            .AddWithValue("@Contato", _Nome)
            .AddWithValue("@SiteCod", _idWEB)
        End With

        Try
            'abre a conexão
            conn.Open()
            'Executa o comando de inserção
            SQL.ExecuteNonQuery()
            'Fecha a conexão
            conn.Close()
        Catch ex As Exception
            MsgBox("Erro ao introduzir cliente no Banco de Dados" & vbCr & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub
End Class
