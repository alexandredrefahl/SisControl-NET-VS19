''' <summary>
''' Tag de grupo do processo
''' Campo de uso livre do Fisco
''' Informar o nome do campo no atributo xCampo
''' e o conteúdo do campo no xTexto
''' </summary>
Public Class procRef
    ''' <summary>
    ''' Indentificador do processo ou ato concessório
    ''' </summary>
    Private _nProc As String
    Public Property nProc() As String
        Get
            Return _nProc
        End Get
        Set(ByVal value As String)
            _nProc = value
        End Set
    End Property
    ''' <summary>
    ''' Origem do processo, informar com:
    ''' 0 - SEFAZ;
    ''' 1 - Justiça Federal;
    ''' 2 - Justiça Estadual;
    ''' 3 - Secex/RFB;
    ''' 9 - Outros
    ''' </summary>
    Private _indProc As String
    Public Property indProc() As String
        Get
            Return _indProc
        End Get
        Set(ByVal value As String)
            _indProc = value
        End Set
    End Property
End Class