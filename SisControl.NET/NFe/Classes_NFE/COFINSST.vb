''' <summary>
''' TAG do grupo de COFINS Substituição Tributária
''' </summary>
Public Class COFINSST
    ''' <summary>
    ''' Informar campos para cálculo do COFINS Substituição Tributária em percentual (T02 e T03) ou campos
    ''' para COFINS em valor (T04 e T05).
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
    Private _pCOFINS As Double
    Public Property pCOFINS() As Double
        Get
            Return _pCOFINS
        End Get
        Set(ByVal value As Double)
            _pCOFINS = value
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
    Private _vCOFINS As Double
    Public Property vCOFINS() As Double
        Get
            Return _vCOFINS
        End Get
        Set(ByVal value As Double)
            _vCOFINS = value
        End Set
    End Property
End Class