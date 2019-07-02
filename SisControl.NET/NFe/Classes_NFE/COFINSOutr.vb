''' <summary>
''' TAG do grupo de COFINS outras operações
''' CST = 99
''' </summary>
Public Class COFINSOutr
    ''' <summary>
    ''' 99 - Outras Operações;
    ''' </summary>
    Private _CST As String
    Public Property CST() As String
        Get
            Return _CST
        End Get
        Set(ByVal value As String)
            _CST = value
        End Set
    End Property
    ''' <summary>
    ''' Informar campos para cálculo do COFINS em percentual (S07 e S08) ou campos para COFINS em valor (S09 e S10).
    ''' </summary>
    ''Private _vBC As Double
    ''Public Property vBC() As Double
    ''   Get
    ''       Return _vBC
    ''   End Get
    ''   Set(ByVal value As Double)
    ''       _vBC = value
    ''    End Set
    ''End Property
    ''Private _pCOFINS As Double
    ''Public Property pCOFINS() As Double
    ''   Get
    ''       Return _pCOFINS
    ''   End Get
    ''   Set(ByVal value As Double)
    ''       _pCOFINS = value
    ''   End Set
    ''End Property
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