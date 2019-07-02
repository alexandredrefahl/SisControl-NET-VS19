''' <summary>
''' Informar apenas quando se tratar de armamento, permite múltiplas
''' ocorrências (ilimitado)
''' </summary>
Public Class arma
    ''' <summary>
    ''' Indicador do tipo de arma de fogo
    '''
    ''' 0 - Uso permitido;
    ''' 1 - Uso restrito;
    ''' </summary>
    Private _tpArma As String
    Public Property tpArma() As String
        Get
            Return _tpArma
        End Get
        Set(ByVal value As String)
            _tpArma = value
        End Set
    End Property
    ''' <summary>
    ''' Número de série da arma
    ''' </summary>
    Private _nSerie As String
    Public Property nSerie() As String
        Get
            Return _nSerie
        End Get
        Set(ByVal value As String)
            _nSerie = value
        End Set
    End Property
    ''' <summary>
    ''' Número de série do cano
    ''' </summary>
    Private _nCano As String
    Public Property nCano() As String
        Get
            Return _nCano
        End Get
        Set(ByVal value As String)
            _nCano = value
        End Set
    End Property
    ''' <summary>
    ''' Descrição completa da arma, compreendendo: calibre, marca, capacidade, tipo de
    ''' funcionamento, comprimento e demais elementos que permitam a sua perfeita identificação.
    ''' </summary>
    Private _descr As String
    Public Property descr() As String
        Get
            Return _descr
        End Get
        Set(ByVal value As String)
            _descr = value
        End Set
    End Property
End Class