''' <summary>
''' TAG de grupo Volumes
''' </summary>
Public Class vol
    ''' <summary>
    ''' Quantidade de volumes transportados
    ''' </summary>
    Private _qVol As String
    Public Property qVol() As String
        Get
            Return _qVol
        End Get
        Set(ByVal value As String)
            _qVol = value
        End Set
    End Property
    ''' <summary>
    ''' Espécie dos volumes transportados
    ''' </summary>
    Private _esp As String
    Public Property esp() As String
        Get
            Return _esp
        End Get
        Set(ByVal value As String)
            _esp = value
        End Set
    End Property
    ''' <summary>
    ''' Marca dos volumes transportados
    ''' </summary>
    Private _marca As String
    Public Property marca() As String
        Get
            Return _marca
        End Get
        Set(ByVal value As String)
            _marca = value
        End Set
    End Property
    ''' <summary>
    ''' Numeração dos volumes transportados
    ''' </summary>
    Private _nVol As String
    Public Property nVol() As String
        Get
            Return _nVol
        End Get
        Set(ByVal value As String)
            _nVol = value
        End Set
    End Property
    ''' <summary>
    ''' Peso Líquido (em kg)
    ''' </summary>
    Private _pesoL As Decimal
    <Formato("####0.000", "en-US")> _
    Public Property pesoL() As Decimal
        Get
            Return _pesoL
        End Get
        Set(ByVal value As Decimal)
            _pesoL = value
        End Set
    End Property
    ''' <summary>
    ''' Peso Bruto (em kg)
    ''' </summary>
    Private _pesoB As Decimal
    <Formato("####0.000", "en-US")> _
    Public Property pesoB() As Decimal
        Get
            Return _pesoB
        End Get
        Set(ByVal value As Decimal)
            _pesoB = value
        End Set
    End Property
End Class