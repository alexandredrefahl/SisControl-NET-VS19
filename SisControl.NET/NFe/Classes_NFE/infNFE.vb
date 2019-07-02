Public Class InfNFE
    Private _emit As emit
    Public _ide As ide
    Private _dest As dest
    Private _det As List(Of det)

    Public Sub New()
        'Inicializa automaticamente apenas aqueles que são obrigatórios
        _emit = New emit()
        _dest = New dest()
        _ide = New ide()
        '_retirada = new retirada();
        ' _avulsa = new avulsa();

        _det = New List(Of det)()
    End Sub

    ' Por enquanto não vou gerar o ID aqui... para que a Danfe possa ser impressa de imediato,
    ' * o ERP deve gerar este ID
    ' *
    ' * public string gerarChaveNFE()
    ' {
    '
    ' }
    Public ReadOnly Property Ide() As ide
        Get
            Return _ide
        End Get
    End Property

    Public ReadOnly Property Emit() As emit
        Get
            Return _emit
        End Get
    End Property

    Private _Avulsa As avulsa
    Public Property Avulsa() As avulsa
        Get
            Return _Avulsa
        End Get
        Set(ByVal value As avulsa)
            _Avulsa = value
        End Set
    End Property

    Private _Total As total
    Public Property Total() As total
        Get
            Return _Total
        End Get
        Set(ByVal value As total)
            _Total = value
        End Set
    End Property

    Private _Cobr As cobr
    Public Property Cobr() As cobr
        Get
            Return _Cobr
        End Get
        Set(ByVal value As cobr)
            _Cobr = value
        End Set
    End Property

    Private _pag As pag
    Public Property Pag() As pag
        Get
            Return _pag
        End Get
        Set(ByVal value As pag)
            _pag = value
        End Set
    End Property

    Private _InfAdic As infAdic
    Public Property InfAdic() As infAdic
        Get
            Return _InfAdic
        End Get
        Set(ByVal value As infAdic)
            _InfAdic = value
        End Set
    End Property

    Public ReadOnly Property Dest() As dest
        Get
            Return _dest
        End Get
    End Property

    Public ReadOnly Property Det() As List(Of det)
        Get
            Return _det
        End Get
    End Property


    Private _Retirada As retirada
    Public Property Retirada() As retirada
        Get
            Return _Retirada
        End Get
        Set(ByVal value As retirada)
            _Retirada = value
        End Set
    End Property
    Private _Entrega As entrega
    Public Property Entrega() As entrega
        Get
            Return _Entrega
        End Get
        Set(ByVal value As entrega)
            _Entrega = value
        End Set
    End Property

    Private _Transp As transp
    Public Property Transp() As transp
        Get
            Return _Transp
        End Get
        Set(ByVal value As transp)
            _Transp = value
        End Set
    End Property
End Class

