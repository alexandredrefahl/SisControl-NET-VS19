Public Class ICMSComb
    Private _vBCICMS As Double
    Public Property vBCICMS() As Double
        Get
            Return _vBCICMS
        End Get
        Set(ByVal value As Double)
            _vBCICMS = value
        End Set
    End Property
    Private _vICMS As Double
    Public Property vICMS() As Double
        Get
            Return _vICMS
        End Get
        Set(ByVal value As Double)
            _vICMS = value
        End Set
    End Property
    Private _vBCICMSST As Double
    Public Property vBCICMSST() As Double
        Get
            Return _vBCICMSST
        End Get
        Set(ByVal value As Double)
            _vBCICMSST = value
        End Set
    End Property
    Private _vICMSST As Double
    Public Property vICMSST() As Double
        Get
            Return _vICMSST
        End Get
        Set(ByVal value As Double)
            _vICMSST = value
        End Set
    End Property
End Class