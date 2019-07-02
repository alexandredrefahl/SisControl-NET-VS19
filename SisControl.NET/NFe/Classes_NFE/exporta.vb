''' <summary>
''' TAG do grupo de exportação
'''
''' Informar apenas na exportação
''' </summary>
Public Class exporta
    ''' <summary>
    ''' Sigla da UF onde ocorrerá o Embarque dos produtos
    ''' </summary>
    Private _UFEmbarq As String
    Public Property UFEmbarq() As String
        Get
            Return _UFEmbarq
        End Get
        Set(ByVal value As String)
            _UFEmbarq = value
        End Set
    End Property
    ''' <summary>
    ''' Local onde ocorrerá o Embarque dos produtos
    ''' </summary>
    Private _xLocEmbarq As String
    Public Property xLocEmbarq() As String
        Get
            Return _xLocEmbarq
        End Get
        Set(ByVal value As String)
            _xLocEmbarq = value
        End Set
    End Property
End Class