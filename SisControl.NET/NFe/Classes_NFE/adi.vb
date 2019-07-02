Public Class adi
    ''' <summary>
    ''' Numero da adição
    ''' </summary>
    Private _nAdicao As String
    Public Property nAdicao() As String
        Get
            Return _nAdicao
        End Get
        Set(ByVal value As String)
            _nAdicao = value
        End Set
    End Property
    ''' <summary>
    ''' Numero seqüencial do item dentro da adição
    ''' </summary>
    Private _nSeqAdic As String
    Public Property nSeqAdic() As String
        Get
            Return _nSeqAdic
        End Get
        Set(ByVal value As String)
            _nSeqAdic = value
        End Set
    End Property
    ''' <summary>
    ''' Código do fabricante estrangeiro, usado nos sistemas internos de
    ''' informação do emitente da NF-e
    ''' </summary>
    Private _cFabricante As String
    Public Property cFabricante() As String
        Get
            Return _cFabricante
        End Get
        Set(ByVal value As String)
            _cFabricante = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do desconto do item da DI – adição
    ''' </summary>
    Private _vDescDI As Double
    Public Property vDescDI() As Double
        Get
            Return _vDescDI
        End Get
        Set(ByVal value As Double)
            _vDescDI = value
        End Set
    End Property
End Class