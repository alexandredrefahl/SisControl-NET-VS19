''' <summary>
''' Tag da Declaração de Importação
''' </summary>
Public Class DI
    Private _adi As List(Of adi)
    Public Sub New()
        _adi = New List(Of adi)()
    End Sub

    ''' <summary>
    ''' Número do Documento de Importação DI/DSI/DA (DI/DSI/DA)
    ''' </summary>
    Private _nDI As String
    Public Property nDI() As String
        Get
            Return _nDI
        End Get
        Set(ByVal value As String)
            _nDI = value
        End Set
    End Property
    ''' <summary>
    ''' Data de Registro da DI/DSI/DA
    ''' Formato “AAAA-MM-DD”
    ''' </summary>
    Private _dDI As DateTime
    Public Property dDI() As DateTime
        Get
            Return _dDI
        End Get
        Set(ByVal value As DateTime)
            _dDI = value
        End Set
    End Property
    ''' <summary>
    ''' Local de desembaraço
    ''' </summary>
    Private _xLocDesemb As String
    Public Property xLocDesemb() As String
        Get
            Return _xLocDesemb
        End Get
        Set(ByVal value As String)
            _xLocDesemb = value
        End Set
    End Property
    ''' <summary>
    ''' Sigla da UF onde ocorreu o Desembaraço Aduaneiro
    ''' </summary>
    Private _UFDesemb As String
    Public Property UFDesemb() As String
        Get
            Return _UFDesemb
        End Get
        Set(ByVal value As String)
            _UFDesemb = value
        End Set
    End Property
    ''' <summary>
    ''' Data do Desembaraço Aduaneiro
    ''' </summary>
    Private _dDesemb As DateTime
    Public Property dDesemb() As DateTime
        Get
            Return _dDesemb
        End Get
        Set(ByVal value As DateTime)
            _dDesemb = value
        End Set
    End Property
    ''' <summary>
    ''' Código do exportador, usado nos sistemas internos de informação do emitente da NF-e
    ''' </summary>
    Private _cExportador As String
    Public Property cExportador() As String
        Get
            Return _cExportador
        End Get
        Set(ByVal value As String)
            _cExportador = value
        End Set
    End Property

    ''' <summary>
    ''' Adições
    ''' </summary>
    Public ReadOnly Property Adi() As List(Of adi)
        Get
            Return _adi
        End Get
    End Property
End Class