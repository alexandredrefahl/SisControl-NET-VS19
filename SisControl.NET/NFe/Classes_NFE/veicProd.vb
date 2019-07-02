''' <summary>
''' TAG de grupo do detalhamento de Veículos novos
'''
''' Informar apenas quando se tratar de veículos novos
''' </summary>
Public Class veicProd
    ''' <summary>
    ''' 1 – Venda concessionária,
    ''' 2 – Faturamento direto
    ''' 3 – Venda direta
    ''' 0 – Outros
    ''' </summary>
    Private _tpOp As Integer
    Public Property tpOp() As Integer
        Get
            Return _tpOp
        End Get
        Set(ByVal value As Integer)
            _tpOp = value
        End Set
    End Property
    ''' <summary>
    ''' Chassi do veículo
    ''' </summary>
    Private _chassi As String
    Public Property chassi() As String
        Get
            Return _chassi
        End Get
        Set(ByVal value As String)
            _chassi = value
        End Set
    End Property
    ''' <summary>
    ''' Código de cada montadora
    ''' </summary>
    Private _cCor As String
    Public Property cCor() As String
        Get
            Return _cCor
        End Get
        Set(ByVal value As String)
            _cCor = value
        End Set
    End Property
    ''' <summary>
    ''' Descrição da Cor
    ''' </summary>
    Private _xCor As String
    Public Property xCor() As String
        Get
            Return _xCor
        End Get
        Set(ByVal value As String)
            _xCor = value
        End Set
    End Property
    ''' <summary>
    ''' Potência Motor
    ''' </summary>
    Private _pot As String
    Public Property pot() As String
        Get
            Return _pot
        End Get
        Set(ByVal value As String)
            _pot = value
        End Set
    End Property
    ''' <summary>
    ''' CM3 (Potência)
    ''' </summary>
    Private _CM3 As String
    Public Property CM3() As String
        Get
            Return _CM3
        End Get
        Set(ByVal value As String)
            _CM3 = value
        End Set
    End Property
    ''' <summary>
    ''' Peso Líquido
    ''' </summary>
    Private _pesoL As Double
    Public Property pesoL() As Double
        Get
            Return _pesoL
        End Get
        Set(ByVal value As Double)
            _pesoL = value
        End Set
    End Property
    ''' <summary>
    ''' Peso bruto
    ''' </summary>
    Private _pesoB As Double
    Public Property pesoB() As Double
        Get
            Return _pesoB
        End Get
        Set(ByVal value As Double)
            _pesoB = value
        End Set
    End Property
    ''' <summary>
    ''' Serial (série)
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
    ''' Tipo de combustível
    ''' </summary>
    Private _tpComb As String
    Public Property tpComb() As String
        Get
            Return _tpComb
        End Get
        Set(ByVal value As String)
            _tpComb = value
        End Set
    End Property
    ''' <summary>
    ''' Numero do motor
    ''' </summary>
    Private _nMotor As String
    Public Property nMotor() As String
        Get
            Return _nMotor
        End Get
        Set(ByVal value As String)
            _nMotor = value
        End Set
    End Property
    Private _CMKG As String
    Public Property CMKG() As String
        Get
            Return _CMKG
        End Get
        Set(ByVal value As String)
            _CMKG = value
        End Set
    End Property
    ''' <summary>
    ''' Distância entre eixos
    ''' </summary>
    Private _dist As String
    Public Property dist() As String
        Get
            Return _dist
        End Get
        Set(ByVal value As String)
            _dist = value
        End Set
    End Property
    ''' <summary>
    ''' RENAVAM
    ''' </summary>
    Private _RENAVAM As String
    Public Property RENAVAM() As String
        Get
            Return _RENAVAM
        End Get
        Set(ByVal value As String)
            _RENAVAM = value
        End Set
    End Property
    ''' <summary>
    ''' Ano Modelo de Fabricação
    ''' </summary>
    Private _anoMod As String
    Public Property anoMod() As String
        Get
            Return _anoMod
        End Get
        Set(ByVal value As String)
            _anoMod = value
        End Set
    End Property
    ''' <summary>
    ''' Ano de fabricação
    ''' </summary>
    Private _anoFab As String
    Public Property anoFab() As String
        Get
            Return _anoFab
        End Get
        Set(ByVal value As String)
            _anoFab = value
        End Set
    End Property
    ''' <summary>
    ''' Tipo de pintura
    ''' </summary>
    Private _tpPint As String
    Public Property tpPint() As String
        Get
            Return _tpPint
        End Get
        Set(ByVal value As String)
            _tpPint = value
        End Set
    End Property
    ''' <summary>
    ''' Tipo de veiculo
    ''' </summary>
    Private _tpVeic As String
    Public Property tpVeic() As String
        Get
            Return _tpVeic
        End Get
        Set(ByVal value As String)
            _tpVeic = value
        End Set
    End Property
    ''' <summary>
    ''' Espécie do veiculo
    ''' </summary>
    Private _espVeic As String
    Public Property espVeic() As String
        Get
            Return _espVeic
        End Get
        Set(ByVal value As String)
            _espVeic = value
        End Set
    End Property
    ''' <summary>
    ''' Condição do VIN
    ''' </summary>
    Private _VIN As String
    Public Property VIN() As String
        Get
            Return _VIN
        End Get
        Set(ByVal value As String)
            _VIN = value
        End Set
    End Property
    ''' <summary>
    ''' Condição do veiculo
    ''' </summary>
    Private _condVeic As String
    Public Property condVeic() As String
        Get
            Return _condVeic
        End Get
        Set(ByVal value As String)
            _condVeic = value
        End Set
    End Property
    ''' <summary>
    ''' Código Marca Modelo
    ''' </summary>
    Private _cMod As String
    Public Property cMod() As String
        Get
            Return _cMod
        End Get
        Set(ByVal value As String)
            _cMod = value
        End Set
    End Property
End Class
