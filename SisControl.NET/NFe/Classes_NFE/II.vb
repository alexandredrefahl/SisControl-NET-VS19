''' <summary>
''' TAG de grupo do Imposto de Importação
''' Informar apenas quando o item for sujeito ao II
''' </summary>
Public Class II
    ''' <summary>
    ''' Valor da BC do Imposto de Importação
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
    ''' <summary>
    ''' Valor das despesas aduaneiras
    ''' </summary>
    Private _vDespAdu As Double
    Public Property vDespAdu() As Double
        Get
            Return _vDespAdu
        End Get
        Set(ByVal value As Double)
            _vDespAdu = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do Imposto de Importação
    ''' </summary>
    Private _vII As Double
    Public Property vII() As Double
        Get
            Return _vII
        End Get
        Set(ByVal value As Double)
            _vII = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do Imposto sobre Operações Financeiras
    ''' </summary>
    Private _vIOF As Double
    Public Property vIOF() As Double
        Get
            Return _vIOF
        End Get
        Set(ByVal value As Double)
            _vIOF = value
        End Set
    End Property
End Class