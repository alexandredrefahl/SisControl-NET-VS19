''' <summary>
''' TAG de grupo de Lacres
''' </summary>
Public Class lacres
    ''' <summary>
    ''' Número dos lacres
    ''' </summary>
    Private _nLacre As String
    Public Property nLacre() As String
        Get
            Return _nLacre
        End Get
        Set(ByVal value As String)
            _nLacre = value
        End Set
    End Property
End Class