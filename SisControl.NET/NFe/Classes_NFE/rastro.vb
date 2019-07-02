
Public Class rastro
    ''' <summary>
    ''' Informar apenas quando se tratar de medicamentos, permite múltiplas ocorrências (ilimitado)
    ''' Número do Lote do medicamento
    ''' </summary>
    Private _nLote As String
    Public Property nLote() As String
        Get
            Return _nLote
        End Get
        Set(ByVal value As String)
            _nLote = value
        End Set
    End Property
    ''' <summary>
    ''' Quantidade de produto no Lote do medicamento
    ''' </summary>
    Private _qLote As Decimal
    <Formato("N0", "pt-BR")>
    Public Property qLote() As Decimal
        Get
            Return _qLote
        End Get
        Set(ByVal value As Decimal)
            _qLote = value
        End Set
    End Property
    ''' <summary>
    ''' Data de fabricação
    ''' </summary>
    Private _dFab As DateTime
    Public Property dFab() As DateTime
        Get
            Return _dFab
        End Get
        Set(ByVal value As DateTime)
            _dFab = value
        End Set
    End Property
    ''' <summary>
    ''' Data de validade
    ''' </summary>
    Private _dVal As DateTime
    Public Property dVal() As DateTime
        Get
            Return _dVal
        End Get
        Set(ByVal value As DateTime)
            _dVal = value
        End Set
    End Property
    ''' <summary>
    ''' Codigo de agregação
    ''' </summary>
    Private _cAgreg As String
    Public Property cAgreg() As String
        Get
            Return _cAgreg
        End Get
        Set(ByVal value As String)
            _cAgreg = value
        End Set
    End Property
End Class
