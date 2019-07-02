''' <summary>
''' CST – 20 - Com redução de base de cálculo
''' </summary>
Public Class ICMS20
    ''' <summary>
    ''' Origem da mercadoria:
    ''' 0 – Nacional;
    ''' 1 – Estrangeira – Importação direta;
    ''' 2 – Estrangeira – Adquirida no mercado interno.
    ''' </summary>
    Private _orig As String
    Public Property orig() As String
        Get
            Return _orig
        End Get
        Set(ByVal value As String)
            _orig = value
        End Set
    End Property
    ''' <summary>
    ''' Tributação do ICMS: 00 – Tributada integralmente
    ''' </summary>
    Private _CST As String
    Public Property CST() As String
        Get
            Return _CST
        End Get
        Set(ByVal value As String)
            _CST = value
        End Set
    End Property
    ''' <summary>
    ''' 0 - Margem Valor Agregado (%);
    ''' 1 - Pauta (Valor);
    ''' 2 - Preço Tabelado Máx. (valor);
    ''' 3 - valor da operação.
    ''' </summary>
    Private _modBC As String
    Public Property modBC() As String
        Get
            Return _modBC
        End Get
        Set(ByVal value As String)
            _modBC = value
        End Set
    End Property

    ''' <summary>
    ''' Percentual da Redução de BC do ICMS
    ''' </summary>
    Private _pRedBC As Double
    Public Property pRedBC() As Double
        Get
            Return _pRedBC
        End Get
        Set(ByVal value As Double)
            _pRedBC = value
        End Set
    End Property

    ''' <summary>
    ''' Valor da base de calculo do imposto
    ''' </summary>
    Private _vBC As Double
    Public Property vBC() As Double
        Get
            Return _vBC
        End Get
        Set(ByVal value As Double)
            _vBC = value
        End Set
    End Property

    ''' <summary>
    ''' Aliquota do imposto
    ''' </summary>
    Private _pICMS As Double
    Public Property pICMS() As Double
        Get
            Return _pICMS
        End Get
        Set(ByVal value As Double)
            _pICMS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS
    ''' </summary>
    Private _vICMS As Double
    Public Property vICMS() As Double
        Get
            Return _vICMS
        End Get
        Set(ByVal value As Double)
            _vICMS = value
        End Set
    End Property
End Class
