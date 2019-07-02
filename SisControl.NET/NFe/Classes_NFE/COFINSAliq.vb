''' <summary>
''' TAG do grupo de COFINS tributado pela alíquota
''' CST = 01 ou 02
''' </summary>
Public Class COFINSAliq
    ''' <summary>
    ''' 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
    ''' 02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada));
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
    ''' Valor da Base de Cálculo da COFINS
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
    ''' Alíquota da COFINS (em percentual)
    ''' </summary>
    Private _pCOFINS As Double
    Public Property pCOFINS() As Double
        Get
            Return _pCOFINS
        End Get
        Set(ByVal value As Double)
            _pCOFINS = value
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