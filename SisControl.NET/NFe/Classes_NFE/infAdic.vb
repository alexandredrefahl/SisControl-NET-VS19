''' <summary>
''' TAG de grupo de Informações Adicionais
''' </summary>
Public Class infAdic
    ''' <summary>
    ''' Informações Adicionais de Interesse do Fisco
    ''' </summary>
    Private _infAdFisco As String
    Public Property infAdFisco() As String
        Get
            Return _infAdFisco
        End Get
        Set(ByVal value As String)
            _infAdFisco = value
        End Set
    End Property
    ''' <summary>
    ''' Informações Complementares de interesse do Contribuinte
    ''' </summary>
    Private _infCpl As String
    Public Property infCpl() As String
        Get
            Return _infCpl
        End Get
        Set(ByVal value As String)
            _infCpl = value
        End Set
    End Property
End Class