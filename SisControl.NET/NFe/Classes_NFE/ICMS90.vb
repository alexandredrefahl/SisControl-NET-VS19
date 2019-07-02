Public Class ICMS90
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
    ''' Percentual da Redução de BC
    ''' </summary>
    Private _pRedBC As System.Nullable(Of Double)
    Public Property pRedBC() As System.Nullable(Of Double)
        Get
            Return _pRedBC
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _pRedBC = value
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
    ''' <summary>
    ''' Modalidade de determinação da BC do ICMS ST
    ''' 0 – Preço tabelado ou máximo sugerido;
    ''' 1 - Lista Negativa (valor);
    ''' 2 - Lista Positiva (valor);
    ''' 3 - Lista Neutra (valor);
    ''' 4 - Margem Valor Agregado (%);
    ''' 5 - Pauta (valor);
    ''' </summary>
    Private _modBCST As String
    Public Property modBCST() As String
        Get
            Return _modBCST
        End Get
        Set(ByVal value As String)
            _modBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Percentual da margem de valor Adicionado do ICMS ST
    ''' </summary>
    Private _pMVAST As System.Nullable(Of Double)
    Public Property pMVAST() As System.Nullable(Of Double)
        Get
            Return _pMVAST
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _pMVAST = value
        End Set
    End Property
    ''' <summary>
    ''' Percentual da Redução de BC do ICMS ST
    ''' </summary>
    Private _pRedBCST As System.Nullable(Of Double)
    Public Property pRedBCST() As System.Nullable(Of Double)
        Get
            Return _pRedBCST
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _pRedBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS ST
    ''' </summary>
    Private _vBCST As Double
    Public Property vBCST() As Double
        Get
            Return _vBCST
        End Get
        Set(ByVal value As Double)
            _vBCST = value
        End Set
    End Property
    ''' <summary>
    ''' Alíquota do imposto do ICMS ST
    ''' </summary>
    Private _pICMSST As Double
    Public Property pICMSST() As Double
        Get
            Return _pICMSST
        End Get
        Set(ByVal value As Double)
            _pICMSST = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS ST retido
    ''' </summary>
    Private _vICMSST As Double
    Public Property vICMSST() As Double
        Get
            Return _vICMSST
        End Get
        Set(ByVal value As Double)
            _vICMSST = value
        End Set
    End Property
End Class