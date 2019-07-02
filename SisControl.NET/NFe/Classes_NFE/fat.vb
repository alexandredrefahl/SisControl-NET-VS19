Public Class fat
    ''' <summary>
    ''' Número da Fatura
    ''' </summary>
    Private _nFat As String
    Public Property nFat() As String
        Get
            Return _nFat
        End Get
        Set(ByVal value As String)
            _nFat = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Original da Fatura
    ''' </summary>
    Private _vOrig As String
    Public Property vOrig() As Double
        Get
            Return _vOrig
        End Get
        Set(ByVal value As Double)
            _vOrig = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do desconto
    ''' </summary>
    Private _vDesc As String
    Public Property vDesc() As Double
        Get
            Return _vDesc
        End Get
        Set(ByVal value As Double)
            _vDesc = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Líquido da Fatura
    ''' </summary>
    Private _vLiq As String
    Public Property vLiq() As Double
        Get
            Return _vLiq
        End Get
        Set(ByVal value As Double)
            _vLiq = value
        End Set
    End Property
End Class