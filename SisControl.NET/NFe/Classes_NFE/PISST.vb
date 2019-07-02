''' <summary>
''' TAG do grupo de PIS Substituição Tributária
''' </summary>
Public Class PISST
    ''' <summary>
    ''' Informar campos para cálculo do PIS em percentual (R02 e R03) ou campos para PIS em valor (R04 e R05).
    ''' </summary>
    Private _vBC As Double
    Public Property vBC() As Double
        Get
            Return _vBC
        End Get
        Set(ByVal value As Double)
            _vBC = value
        End Set
    End Property
    Private _pPIS As Double
    Public Property pPIS() As Double
        Get
            Return _pPIS
        End Get
        Set(ByVal value As Double)
            _pPIS = value
        End Set
    End Property
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
    Private _vPIS As Double
    Public Property vPIS() As Double
        Get
            Return _vPIS
        End Get
        Set(ByVal value As Double)
            _vPIS = value
        End Set
    End Property
End Class
