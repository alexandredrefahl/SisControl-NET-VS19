''' <summary>
''' Informar apenas quando se tratar de medicamentos, permite múltiplas ocorrências (ilimitado)
''' </summary>
Public Class med
    ''' <summary>
    ''' Número do Lote do medicamento
    ''' </summary>
    Private _cProdANVISA As String
    Public Property cProdANVISA() As String
        Get
            Return _cProdANVISA
        End Get
        Set(ByVal value As String)
            _cProdANVISA = value
        End Set
    End Property

    ''' <summary>
    ''' Preço máximo consumidor
    ''' </summary>
    Private _vPMC As Decimal
    Public Property vPMC() As Decimal
        Get
            Return _vPMC
        End Get
        Set(ByVal value As Decimal)
            _vPMC = value
        End Set
    End Property
End Class