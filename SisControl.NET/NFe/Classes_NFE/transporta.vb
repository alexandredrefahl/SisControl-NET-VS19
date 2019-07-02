''' <summary>
''' TAG de grupo transportador
''' </summary>
Public Class transporta
    ''' <summary>
    ''' CNPJ
    ''' Informar o CNPJ do Transportador, preenchendo os zeros não significativos.
    ''' </summary>
    Private _CNPJ As String
    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property
    ''' <summary>
    ''' CNPJ
    ''' Informar o CPF do Transportador, preenchendo os zeros não significativos.
    ''' </summary>
    Private _CPF As String
    Public Property CPF() As String
        Get
            Return _CPF
        End Get
        Set(ByVal value As String)
            _CPF = value
        End Set
    End Property
    ''' <summary>
    ''' Razão social ou nome
    ''' </summary>
    Private _xNome As String
    Public Property xNome() As String
        Get
            Return _xNome
        End Get
        Set(ByVal value As String)
            _xNome = value
        End Set
    End Property
    ''' <summary>
    ''' Inscrição estadual
    ''' </summary>
    Private _IE As String
    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property
    ''' <summary>
    ''' Endereço completo
    ''' </summary>
    Private _xEnder As String
    Public Property xEnder() As String
        Get
            Return _xEnder
        End Get
        Set(ByVal value As String)
            _xEnder = value
        End Set
    End Property
    ''' <summary>
    ''' Nome do municipio
    ''' </summary>
    Private _xMun As String
    Public Property xMun() As String
        Get
            Return _xMun
        End Get
        Set(ByVal value As String)
            _xMun = value
        End Set
    End Property
    ''' <summary>
    ''' Sigla da UF
    ''' </summary>
    Private _UF As String
    Public Property UF() As String
        Get
            Return _UF
        End Get
        Set(ByVal value As String)
            _UF = value
        End Set
    End Property
End Class
