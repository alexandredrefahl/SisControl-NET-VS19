''' <summary>
''' Campo de uso livre do Fisco Informar o nome do campo no atributo xCampo
''' e o conteúdo do campo no xTexto
''' </summary>
Public Class obsFisco
    ''' <summary>
    ''' Identificação do campo
    ''' </summary>
    Private _xCampo As String
    Public Property xCampo() As String
        Get
            Return _xCampo
        End Get
        Set(ByVal value As String)
            _xCampo = value
        End Set
    End Property
    ''' <summary>
    ''' Conteúdo do campo
    ''' </summary>
    Private _xTexto As String
    Public Property xTexto() As String
        Get
            Return _xTexto
        End Get
        Set(ByVal value As String)
            _xTexto = value
        End Set
    End Property
End Class