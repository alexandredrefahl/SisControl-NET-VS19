''' <summary>
''' TAG de grupo Veículo
''' </summary>
Public Class veicTransp
    ''' <summary>
    ''' Placa do Veículo
    ''' </summary>
    Private _placa As String
    Public Property placa() As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property
    ''' <summary>
    ''' Sigla da UF
    ''' </summary>
    Private _UF As String
    Public Property UF() As String
        Get
            Return _UF
        End Get
        Set(ByVal value As String)
            _UF = value
        End Set
    End Property
    ''' <summary>
    ''' Registro Nacional de Transportador de Carga (ANTT)
    ''' </summary>
    Private _RNTC As String
    Public Property RNTC() As String
        Get
            Return _RNTC
        End Get
        Set(ByVal value As String)
            _RNTC = value
        End Set
    End Property
End Class