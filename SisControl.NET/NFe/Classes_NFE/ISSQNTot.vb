''' <summary>
''' TAG de grupo de Valores Totais referentes ao ISSQN
''' </summary>
Public Class ISSQNtot
    ''' <summary>
    ''' Valor Total dos Serviços sob não incidência ou não tributados pelo ICMS
    ''' </summary>
    Private _vServ As Double
    Public Property vServ() As Double
        Get
            Return _vServ
        End Get
        Set(ByVal value As Double)
            _vServ = value
        End Set
    End Property
    ''' <summary>
    ''' Base de Cálculo do ISS
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
    ''' Valor Total do ISS
    ''' </summary>
    Private _vISS As Double
    Public Property vISS() As Double
        Get
            Return _vISS
        End Get
        Set(ByVal value As Double)
            _vISS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do PIS sobre serviços
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
    ''' <summary>
    ''' Valor do COFINS sobre serviços
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