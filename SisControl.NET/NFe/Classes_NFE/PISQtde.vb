''' <summary>
''' TAG do grupo de PIS tributado por Qtde
''' CST = 03
''' </summary>
Public Class PISQtde
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
    ''' Alíquota do PIS (em reais)
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
    ''' Valor do PIS
    ''' </summary>
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