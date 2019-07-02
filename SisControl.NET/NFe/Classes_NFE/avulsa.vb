''' <summary>
''' Informações do fisco emitente, grupo de uso exclusivo do fisco.
''' </summary>
Public Class avulsa
    Public Sub New()

    End Sub

    ''' <summary>
    ''' CNPJ do órgão emitente
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
    ''' Órgão emitente
    ''' </summary>
    Private _xOrgao As String
    Public Property xOrgao() As String
        Get
            Return _xOrgao
        End Get
        Set(ByVal value As String)
            _xOrgao = value
        End Set
    End Property
    ''' <summary>
    ''' Matrícula do agente
    ''' </summary>
    Private _matr As String
    Public Property matr() As String
        Get
            Return _matr
        End Get
        Set(ByVal value As String)
            _matr = value
        End Set
    End Property
    ''' <summary>
    ''' Nome do agente
    ''' </summary>
    Private _xAgente As String
    Public Property xAgente() As String
        Get
            Return _xAgente
        End Get
        Set(ByVal value As String)
            _xAgente = value
        End Set
    End Property
    ''' <summary>
    ''' Preencher com Código DDD + número do telefone
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
    ''' <summary>
    ''' Número do Documento de Arrecadação de Receita
    ''' </summary>
    Private _nDAR As String
    Public Property nDAR() As String
        Get
            Return _nDAR
        End Get
        Set(ByVal value As String)
            _nDAR = value
        End Set
    End Property
    ''' <summary>
    ''' Data de emissão do Documento de Arrecadação
    ''' </summary>
    Private _dEmi As DateTime
    Public Property dEmi() As DateTime
        Get
            Return _dEmi
        End Get
        Set(ByVal value As DateTime)
            _dEmi = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total constante no Documento de arrecadação de Receita
    ''' </summary>
    Private _vDAR As Double
    Public Property vDAR() As Double
        Get
            Return _vDAR
        End Get
        Set(ByVal value As Double)
            _vDAR = value
        End Set
    End Property
    ''' <summary>
    ''' Repartição Fiscal emitente
    ''' </summary>
    Private _repEmi As String
    Public Property repEmi() As String
        Get
            Return _repEmi
        End Get
        Set(ByVal value As String)
            _repEmi = value
        End Set
    End Property
    ''' <summary>
    ''' Data de pagamento do Documento de Arrecadação
    ''' </summary>
    Private _dPag As DateTime
    Public Property dPag() As DateTime
        Get
            Return _dPag
        End Get
        Set(ByVal value As DateTime)
            _dPag = value
        End Set
    End Property
End Class
