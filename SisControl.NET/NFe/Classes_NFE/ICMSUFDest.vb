Public Class ICMSUFDest
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _vBCUFDest As Double
    Public Property vBCUFDest() As Double
        Get
            Return _vBCUFDest
        End Get
        Set(ByVal value As Double)
            _vBCUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _pFCPUFDest As Double
    Public Property pFCPUFDest() As Double
        Get
            Return _pFCPUFDest
        End Get
        Set(ByVal value As Double)
            _pFCPUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _pICMSUFDest As Double
    Public Property pICMSUFDest() As Double
        Get
            Return _pICMSUFDest
        End Get
        Set(ByVal value As Double)
            _pICMSUFDest = value
        End Set
    End Property

    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _pICMSInter As Double
    Public Property pICMSInter() As Double
        Get
            Return _pICMSInter
        End Get
        Set(ByVal value As Double)
            _pICMSInter = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _pICMSInterPart As Double
    Public Property pICMSInterPart() As Double
        Get
            Return _pICMSInterPart
        End Get
        Set(ByVal value As Double)
            _pICMSInterPart = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _vFCPUFDest As Double
    Public Property vFCPUFDest() As Double
        Get
            Return _vFCPUFDest
        End Get
        Set(ByVal value As Double)
            _vFCPUFDest = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _vICMSUFDest As Double
    Public Property vICMSUFDest() As Double
        Get
            Return _vICMSUFDest
        End Get
        Set(ByVal value As Double)
            _vICMSUFDest = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do COFINS
    ''' </summary>
    Private _vICMSUFRemet As Double
    Public Property vICMSUFRemet() As Double
        Get
            Return _vICMSUFRemet
        End Get
        Set(ByVal value As Double)
            _vICMSUFRemet = value
        End Set
    End Property

    Public Sub Calcula_Partilha()
        ' Passo 1 – calcular a base de cálculo do ICMS
        ' Base do ICMS = Valor do produto + Frete + Outras Despesas Acessórias – Descontos + IPI
        ' ** Esse valor já vem calculado no _vBCUFDest

        ' Passo 2 – calcular o Fundo de Combate à Pobreza
        ' FCP = Base do ICMS * (%FCP / 100)
        _vFCPUFDest = _vBCUFDest * (_pFCPUFDest / 100)

        ' Passo 3 – calcular o DIFAL (Valor da diferença do imposto)
        ' DIFAL = Base Do ICMS * ((%Alíquota Do ICMS Intra – %Alíquota Do ICMS Inter) / 100)
        Dim Difal As Double = 0
        Difal = _vBCUFDest * ((_pICMSUFDest - _pICMSInter) / 100)

        ' Passo 4 – efetuar a partilha do DIFAL
        ' Parte que compete a SP – estado de destino:
        ' Parte UF Destino = Valor do DIFAL * (%Destino / 100)
        _vICMSUFDest = Difal * (_pICMSInterPart / 100)

        ' Parte que compete a SC – estado de origem:
        ' Parte UF Origem = Valor do DIFAL * (100 - %Destino / 100)
        _vICMSUFRemet = Difal - _vICMSUFDest
    End Sub

End Class
