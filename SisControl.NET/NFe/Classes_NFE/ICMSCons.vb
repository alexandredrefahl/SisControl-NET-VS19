Public Class ICMSCons
    Private _vBCICMSSTCons As Double
    Public Property vBCICMSSTCons() As Double
        Get
            Return _vBCICMSSTCons
        End Get
        Set(ByVal value As Double)
            _vBCICMSSTCons = value
        End Set
    End Property
    Private _vICMSSTCons As Double
    Public Property vICMSSTCons() As Double
        Get
            Return _vICMSSTCons
        End Get
        Set(ByVal value As Double)
            _vICMSSTCons = value
        End Set
    End Property
    Private _UFcons As String
    Public Property UFcons() As String
        Get
            Return _UFcons
        End Get
        Set(ByVal value As String)
            _UFcons = value
        End Set
    End Property
End Class