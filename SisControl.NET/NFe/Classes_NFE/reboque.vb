''' <summary>
''' TAG de grupo Reboque
''' </summary>
Public Class reboque
    ''' <summary>
    ''' Placa do veiculo
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
    Private _RTNC As String
    Public Property RTNC() As String
        Get
            Return _RTNC
        End Get
        Set(ByVal value As String)
            _RTNC = value
        End Set
    End Property
End Class