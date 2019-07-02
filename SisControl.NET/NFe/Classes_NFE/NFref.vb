''' <summary>
''' Grupo com as informações das NF/NF-e referenciadas
''' </summary>
Public Class NFref
    Private _nfRef As NFref
    Private _RefNF As refNF
    ''' <summary>
    ''' Utilizar esta TAG para referenciar uma Nota Fiscal Eletrônica emitida
    ''' anteriormente, vinculada a NF-e atual.
    ''' Esta informação será utilizada nas hipóteses previstas na legislação.
    ''' (Ex.: Devolução de Mercadorias, Substituição de NF cancelada, Complementação de NF, etc.).
    ''' </summary>

    Public Sub New()
        _RefNF = New refNF()
        '_nfRef = New NFref()
    End Sub

    Private _refNFE As String
    Public Property refNFe() As String
        Get
            Return _refNFE
        End Get
        Set(ByVal value As String)
            _refNFE = value
        End Set
    End Property

    Public ReadOnly Property nfRef() As NFref
        Get
            Return _nfRef
        End Get
    End Property

    Public ReadOnly Property RefNF() As refNF
        Get
            Return _RefNF
        End Get
    End Property
End Class
