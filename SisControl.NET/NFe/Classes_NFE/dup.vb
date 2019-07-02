Public Class dup
    ''' <summary>
    ''' Número da duplicata
    ''' </summary>
    Private _nDup As String
    Public Property nDup() As String
        Get
            Return _nDup
        End Get
        Set(ByVal value As String)
            _nDup = value
        End Set
    End Property
    ''' <summary>
    ''' Data de vencimento
    ''' </summary>
    Private _dVenc As DateTime
    Public Property dVenc() As DateTime
        Get
            Return _dVenc
        End Get
        Set(ByVal value As DateTime)
            _dVenc = value
        End Set
    End Property
    ''' <summary>
    ''' Valor da duplicata
    ''' </summary>
    Private _vDup As Double
    Public Property vDup() As Double
        Get
            Return _vDup
        End Get
        Set(ByVal value As Double)
            _vDup = value
        End Set
    End Property
End Class