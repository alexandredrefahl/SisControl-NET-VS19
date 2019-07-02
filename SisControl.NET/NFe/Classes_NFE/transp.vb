''' <summary>
''' Tag de grupo de informações do transporte da NFE
''' </summary>
Public Class transp
    ''' <summary>
    ''' Modalidade do frete
    ''' </summary>
    Private _modFrete As String
    Public Property modFrete() As String
        Get
            Return _modFrete
        End Get
        Set(ByVal value As String)
            _modFrete = value
        End Set
    End Property

    Private _Transporta As transporta
    Public Property Transporta() As transporta
        Get
            Return _Transporta
        End Get
        Set(ByVal value As transporta)
            _Transporta = value
        End Set
    End Property
    Private _RetTransp As retTransp
    Public Property RetTransp() As retTransp
        Get
            Return _RetTransp
        End Get
        Set(ByVal value As retTransp)
            _RetTransp = value
        End Set
    End Property
    Private _VeicTransp As veicTransp
    Public Property VeicTransp() As veicTransp
        Get
            Return _VeicTransp
        End Get
        Set(ByVal value As veicTransp)
            _VeicTransp = value
        End Set
    End Property
    Private _Reboque As reboque
    Public Property Reboque() As reboque
        Get
            Return _Reboque
        End Get
        Set(ByVal value As reboque)
            _Reboque = value
        End Set
    End Property
    Private _Vol As vol
    Public Property Vol() As vol
        Get
            Return _Vol
        End Get
        Set(ByVal value As vol)
            _Vol = value
        End Set
    End Property

End Class