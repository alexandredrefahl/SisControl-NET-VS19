''' <summary>
''' TAG de valores totais
''' </summary>
Public Class total
    Private _IcmsTot As ICMSTot
    Public Property IcmsTot() As ICMSTot
        Get
            Return _IcmsTot
        End Get
        Set(ByVal value As ICMSTot)
            _IcmsTot = value
        End Set
    End Property
    Private _ISSQNTot As ISSQNtot
    Public Property ISSQNTot() As ISSQNtot
        Get
            Return _ISSQNTot
        End Get
        Set(ByVal value As ISSQNtot)
            _ISSQNTot = value
        End Set
    End Property
    Private _RetTrib As retTrib
    Public Property RetTrib() As retTrib
        Get
            Return _RetTrib
        End Get
        Set(ByVal value As retTrib)
            _RetTrib = value
        End Set
    End Property
End Class