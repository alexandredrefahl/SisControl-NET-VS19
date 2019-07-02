Public Class entrega
    Private _CNPJ As String
    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property
    Private _xLgr As String
    Public Property xLgr() As String
        Get
            Return _xLgr
        End Get
        Set(ByVal value As String)
            _xLgr = value
        End Set
    End Property
    Private _nro As String
    Public Property nro() As String
        Get
            Return _nro
        End Get
        Set(ByVal value As String)
            _nro = value
        End Set
    End Property
    Private _xCpl As String
    Public Property xCpl() As String
        Get
            Return _xCpl
        End Get
        Set(ByVal value As String)
            _xCpl = value
        End Set
    End Property
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
    ''' Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País). Informar ‘9999999 ‘para operações
    ''' com o exterior.
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
    Private _xMun As String
    Public Property xMun() As String
        Get
            Return _xMun
        End Get
        Set(ByVal value As String)
            _xMun = value
        End Set
    End Property
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