Public Class CIDE
    Private _qBCProd As Decimal
    Public Property qBCProd() As Decimal
        Get
            Return _qBCProd
        End Get
        Set(ByVal value As Decimal)
            _qBCProd = value
        End Set
    End Property
    Private _vAliqProd As Double
    Public Property vAliqProd() As Double
        Get
            Return _vAliqProd
        End Get
        Set(ByVal value As Double)
            _vAliqProd = value
        End Set
    End Property
    Private _vCIDE As Double
    Public Property vCIDE() As Double
        Get
            Return _vCIDE
        End Get
        Set(ByVal value As Double)
            _vCIDE = value
        End Set
    End Property
End Class