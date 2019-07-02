''' <summary>
''' CST – 30 - Isenta ou não tributada e com cobrança do ICMS por
''' substituição tributária
''' </summary>
Public Class ICMS30
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
    ''' Valor da base de calculo do imposto
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
    ''' Aliquota do imposto
    ''' </summary>
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
