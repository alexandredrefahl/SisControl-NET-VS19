Public Class ICMSInter
    Private _vBCICMSSTDest As Double
    Public Property vBCICMSSTDest() As Double
        Get
            Return _vBCICMSSTDest
        End Get
        Set(ByVal value As Double)
            _vBCICMSSTDest = value
        End Set
    End Property
    Private _vICMSSTDest As Double
    Public Property vICMSSTDest() As Double
        Get
            Return _vICMSSTDest
        End Get
        Set(ByVal value As Double)
            _vICMSSTDest = value
        End Set
    End Property
End Class