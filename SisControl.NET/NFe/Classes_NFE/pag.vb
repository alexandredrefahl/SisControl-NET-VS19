Public Class pag
    ''' <summary>
    ''' TAG de grupo de Cobrança
    ''' </summary>
    '''
    Public Sub New()
        _detPag = New List(Of detPag)
    End Sub

    Private _detPag As List(Of detPag)
    Public Property detPag() As List(Of detPag)
        Get
            Return _detPag
        End Get
        Set(ByVal value As List(Of detPag))
            _detPag = value
        End Set
    End Property
End Class
