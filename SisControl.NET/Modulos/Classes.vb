Public Class MeuItemData
    Public Valor As Object
    Public Descricao As String

    Public Sub New(ByVal NovoValor As Object, ByVal NovaDescricao As String)
        Valor = NovoValor
        Descricao = NovaDescricao
    End Sub


    Public Overrides Function ToString() As String
        Return Descricao
    End Function

    Public Function ToInteger() As Integer
        Return Int(Valor)
    End Function

End Class


'*
'*  CLASSE DE CONTROLE DE USUARIO
'*

Public Class Usuario

    Private _Usuario As String = ""
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property
    Private _id As Integer = -1
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Senha As String = ""
    Public Property Senha As String
        Get
            Return _Senha
        End Get
        Set(ByVal value As String)
            _Senha = value
        End Set
    End Property
    Private _Nome As String = ""
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property
    Private _Permissao As Integer
    Public Property Permissao As Integer
        Get
            Return _Permissao
        End Get
        Set(ByVal value As Integer)
            _Permissao = value
        End Set
    End Property

    Private _Auth As Boolean = False
    Public Property Auth As Boolean
        Get
            Return _Auth
        End Get
        Set(ByVal value As Boolean)
            _Auth = value
        End Set
    End Property

    Private _Bloqueado As Boolean = False
    Public Property Bloqueado As Boolean
        Get
            Return _Bloqueado
        End Get
        Set(ByVal value As Boolean)
            _Bloqueado = value
        End Set
    End Property

    Public Sub Autenticar()
        Dim DR As DataRow   ', SQL As String

        'Se não tiver conectado pode entrar com a senha master para usar as funções básicas
        If _Usuario = "Admin" And _Senha = "11111" Then
            _Nome = "Administrador Geral"
            _Bloqueado = False
            _Auth = True
            _id = -1
            Exit Sub
        End If

        'SQL = "SELECT * FROM acesso WHERE login='" & _Usuario & "' and senha='" & _Senha & "'"
        'Procura o usuário
        DR = DLookupRow("acesso", "login='" & _Usuario & "' and senha='" & _Senha & "'")
        'Se encontrou algum

        If Not DR.IsNull(0) Then
            _Nome = DR("Nome")
            _Permissao = DR("permissao")
            _Bloqueado = DR("bloqueado")
            _id = DR("id")
            'Autenticado
            _Auth = True
        Else
            MsgBox("Usuário inválido ou senha não confere", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro de Login")
            _Auth = False
            Exit Sub
        End If
        'Libera memória
        DR = Nothing
    End Sub
End Class

Public Class EnderecoWEB
    Private _Tipo_Logradouro As String = ""
    Public Property Tipo_Logradouro As String
        Get
            Return _Tipo_Logradouro
        End Get
        Set(ByVal value As String)
            _Tipo_Logradouro = value
        End Set
    End Property
    Private _Logradouro As String = ""
    Public Property Logradouro As String
        Get
            Return _Logradouro
        End Get
        Set(ByVal value As String)
            _Logradouro = value
        End Set
    End Property
    Private _Bairro As String = ""
    Public Property Bairro As String
        Get
            Return _Bairro
        End Get
        Set(ByVal value As String)
            _Bairro = value
        End Set
    End Property
    Private _Cidade As String = ""
    Public Property Cidade As String
        Get
            Return _Cidade
        End Get
        Set(ByVal value As String)
            _Cidade = value
        End Set
    End Property
    Private _Uf As String = ""
    Public Property Uf As String
        Get
            Return _Uf
        End Get
        Set(ByVal value As String)
            _Uf = value
        End Set
    End Property
End Class