''' <summary>
''' TAG de grupo de Cobrança
''' </summary>
Public Class cobr
    ''' <summary>
    ''' TAG de grupo da Fatura
    ''' </summary>
    '''
    Public Sub New()
        _Dup = New List(Of dup)
        _fat = New List(Of fat)
    End Sub
    Private _Fat As List(Of fat)
    Public Property Fat() As List(Of fat)
        Get
            Return _Fat
        End Get
        Set(ByVal value As List(Of fat))
            _Fat = value
        End Set
    End Property

    Private _Dup As List(Of dup)
    Public Property Dup() As List(Of dup)
        Get
            Return _Dup
        End Get
        Set(ByVal value As List(Of dup))
            _Dup = value
        End Set
    End Property


End Class