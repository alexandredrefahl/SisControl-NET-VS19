Public Class detPag
    ''' <summary>
    ''' Indicador de forma de pagamento
    ''' </summary>
    Private _tPag As String
    'Private _tPag As Double
    '    Public Property tPag() As Int32
    '        Get
    '   Return _tPag
    '    End Get
    '    Set(ByVal value As Int32)
    '            _tPag = value
    '    End Set
    '    End Property

    Public Property tPag() As String
        Get
            Return _tPag
        End Get
        Set(ByVal value As String)
            _tPag = value
        End Set
    End Property

    ''' <summary>
    ''' valor pagamento
    ''' </summary>
    Private _vPag As Double
    Public Property vPag() As Double
        Get
            Return _vPag
        End Get
        Set(ByVal value As Double)
            _vPag = value
        End Set
    End Property
End Class
