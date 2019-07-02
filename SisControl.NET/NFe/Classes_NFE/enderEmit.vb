Public Class enderEmit
    ''' <summary>
    ''' Logradouro
    ''' </summary>
    Private _xLgr As String
    Public Property xLgr() As String
        Get
            Return _xLgr
        End Get
        Set(ByVal value As String)
            _xLgr = value
        End Set
    End Property
    ''' <summary>
    ''' Número
    ''' </summary>
    Private _nro As String
    Public Property nro() As String
        Get
            Return _nro
        End Get
        Set(ByVal value As String)
            _nro = value
        End Set
    End Property
    ''' <summary>
    ''' Complemento
    ''' </summary>
    Private _xCpl As String
    Public Property xCpl() As String
        Get
            Return _xCpl
        End Get
        Set(ByVal value As String)
            _xCpl = value
        End Set
    End Property
    ''' <summary>
    ''' Bairro
    ''' </summary>
    Private _xBairro As String
    Public Property xBairro() As String
        Get
            Return _xBairro
        End Get
        Set(ByVal value As String)
            _xBairro = value
        End Set
    End Property
    ''' <summary>
    ''' Código do municipio, Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
    ''' Informar ‘9999999 ‘para operações com o exterior.
    ''' </summary>
    Private _cMun As Integer
    Public Property cMun() As Integer
        Get
            Return _cMun
        End Get
        Set(ByVal value As Integer)
            _cMun = value
        End Set
    End Property
    ''' <summary>
    ''' Informar ‘EXTERIOR ‘para operações com o exterior.
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
    ''' Informar ‘EX ‘para operações com o exterior.
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
    ''' <summary>
    ''' Informar os zeros não significativos.
    ''' </summary>
    Private _CEP As String
    Public Property CEP() As String
        Get
            Return _CEP
        End Get
        Set(ByVal value As String)
            _CEP = value
        End Set
    End Property
    ''' <summary>
    ''' 1058 - Brasil
    ''' </summary>
    Private _cPais As Integer
    Public Property cPais() As Integer
        Get
            Return _cPais
        End Get
        Set(ByVal value As Integer)
            _cPais = value
        End Set
    End Property
    ''' <summary>
    ''' Brasil ou BRASIL
    ''' </summary>
    Private _xPais As String
    Public Property xPais() As String
        Get
            Return _xPais
        End Get
        Set(ByVal value As String)
            _xPais = value
        End Set
    End Property
    ''' <summary>
    ''' Preencher com Código DDD + número do telefone.
    ''' </summary>
    Private _fone As String
    Public Property fone() As String
        Get
            Return _fone
        End Get
        Set(ByVal value As String)
            _fone = value
        End Set
    End Property
End Class