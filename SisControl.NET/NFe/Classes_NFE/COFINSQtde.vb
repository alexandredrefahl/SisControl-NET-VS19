''' <summary>
''' CST = 03
''' </summary>
Public Class COFINSQtde
    ''' <summary>
    ''' 03 - Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto);
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
    ''' Quantidade Vendida
    ''' </summary>
    Private _qBCProd As Decimal
    Public Property qBCProd() As Decimal
        Get
            Return _qBCProd
        End Get
        Set(ByVal value As Decimal)
            _qBCProd = value
        End Set
    End Property
    ''' <summary>
    ''' Aliquota do COFINS (em Reais)
    ''' </summary>
    Private _vAliqProd As Double
    Public Property vAliqProd() As Double
        Get
            Return _vAliqProd
        End Get
        Set(ByVal value As Double)
            _vAliqProd = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do COFINS
    ''' </summary>
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