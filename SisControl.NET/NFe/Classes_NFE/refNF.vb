''' <summary>
''' Grupo com as informações das NF referenciadas Idem a informação da TAG anterior, referenciando
''' uma Nota Fiscal modelo 1/1A normal (a NF referenciada não é uma NF-e).
''' </summary>
Public Class refNF
    ''' <summary>
    ''' Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
    ''' </summary>
    Private _cUF As Integer
    Public Property cUF() As Integer
        Get
            Return _cUF
        End Get
        Set(ByVal value As Integer)
            _cUF = value
        End Set
    End Property
    ''' <summary>
    ''' AAMM da emissão da NF
    ''' </summary>
    Private _AAMM As String
    Public Property AAMM() As String
        Get
            Return _AAMM
        End Get
        Set(ByVal value As String)
            _AAMM = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o CNPJ do emitente da NF
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
    ''' Informar o código do modelo do Documento fiscal: 01 – modelo 01
    ''' </summary>
    Private _mod As String
    Public Property [mod]() As String
        Get
            Return _mod
        End Get
        Set(ByVal value As String)
            _mod = value
        End Set
    End Property
    ''' <summary>
    ''' Informar a série do documento fiscal (informar zero se inexistente).
    ''' </summary>
    Private _serie As String
    Public Property serie() As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    ''' <summary>
    ''' 1 – 999999999
    ''' </summary>
    Private _nNF As String
    Public Property nNF() As String
        Get
            Return _nNF
        End Get
        Set(ByVal value As String)
            _nNF = value
        End Set
    End Property

End Class
