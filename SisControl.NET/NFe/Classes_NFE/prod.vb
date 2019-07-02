''' <summary>
''' TAG de grupo do detalhamento de Produtos e Serviços da NF-e
''' </summary>
''' 

Public Class prod
    Private _med As List(Of med)
    Private _rastro As List(Of rastro)
    Public Sub New()
        'vDesc = null;
        _med = New List(Of med)()
        _rastro = New List(Of rastro)()
    End Sub
    ''' <summary>
    ''' Código de produto ou serviço
    ''' Preencher com CFOP, caso se trate de itens não relacionados com mercadorias/produto e que o
    ''' contribuinte não possua codificação própria.
    ''' Formato ”CFOP9999”
    ''' </summary>
    Private _cProd As String
    Public Property cProd() As String
        Get
            Return _cProd
        End Get
        Set(ByVal value As String)
            _cProd = value
        End Set
    End Property
    ''' <summary>
    ''' GTIN (Global Trade Item Number) do produto, antigo código EAN ou código de barras
    '''
    ''' Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14
    ''' (antigos códigos EAN, UPC e DUN-14), não informar o conteúdo da TAG em caso de o produto não
    ''' possuir este código.
    ''' </summary>

    Private _cEAN As String
    <Obrigatorio()> _
    Public Property cEAN() As String
        Get
            Return _cEAN
        End Get
        Set(ByVal value As String)
            _cEAN = value
        End Set
    End Property
    ''' <summary>
    ''' Descrição do produto ou serviço
    ''' </summary>
    Private _xProd As String
    Public Property xProd() As String
        Get
            Return _xProd
        End Get
        Set(ByVal value As String)
            _xProd = value
        End Set
    End Property
    ''' <summary>
    ''' Preencher de acordo com a Tabela de Capítulos da NCM. Em caso deserviço, não incluir a TAG.
    ''' </summary>
    Private _NCM As String
    Public Property NCM() As String
        Get
            Return _NCM
        End Get
        Set(ByVal value As String)
            _NCM = value
        End Set
    End Property
    ''' <summary>
    ''' Preencher de acordo com o código EX da TIPI. Em caso de serviço,não incluir a TAG
    ''' </summary>
    Private _EXTIPI As String
    Public Property EXTIPI() As String
        Get
            Return _EXTIPI
        End Get
        Set(ByVal value As String)
            _EXTIPI = value
        End Set
    End Property
    ''' <summary>
    ''' Gênero do produto ou serviço. Preencher de acordo com a Tabela de Capítulos da NCM. Em caso de serviço, não incluir a TAG.
    ''' </summary>
    Private _genero As String
    Public Property genero() As String
        Get
            Return _genero
        End Get
        Set(ByVal value As String)
            _genero = value
        End Set
    End Property
    ''' <summary>
    ''' Utilizar Tabela de CFOP.
    ''' </summary>
    Private _CFOP As String
    Public Property CFOP() As String
        Get
            Return _CFOP
        End Get
        Set(ByVal value As String)
            _CFOP = value
        End Set
    End Property
    ''' <summary>
    ''' Informar a unidade de comercialização do produto.
    ''' </summary>
    Private _uCom As String
    Public Property uCom() As String
        Get
            Return _uCom
        End Get
        Set(ByVal value As String)
            _uCom = value
        End Set
    End Property
    ''' <summary>
    ''' Informar a quantidade de comercialização do produto
    ''' </summary>
    '[Formato("N4", "pt-BR")]
    Private _qCom As Decimal
    <Formato("#####0.0000", "en-US")> _
    Public Property qCom() As Decimal
        Get
            Return _qCom
        End Get
        Set(ByVal value As Decimal)
            _qCom = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o valor unitário de comercialização do produto
    ''' </summary>
    '[Formato("N4", "pt-BR")]
    Private _vUnCom As Double
    <Formato("#####0.0000", "en-US")> _
    Public Property vUnCom() As Double
        Get
            Return _vUnCom
        End Get
        Set(ByVal value As Double)
            _vUnCom = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Total Bruto dos Produtos ou Serviços
    ''' </summary>
    Private _vProd As Double
    Public Property vProd() As Double
        Get
            Return _vProd
        End Get
        Set(ByVal value As Double)
            _vProd = value
        End Set
    End Property
    ''' <summary>
    ''' GTIN (Global Trade Item Number) da unidade tributável,antigo código EAN ou código de barras
    '''
    ''' Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 (antigos códigos EAN, UPC e DUN-14) da unidade tributável do
    ''' produto, não informar o conteúdo da TAG em caso de o produto não possuir este código.
    ''' </summary>
    Private _cEANTrib As String
    <Obrigatorio()> _
    Public Property cEANTrib() As String
        Get
            Return _cEANTrib
        End Get
        Set(ByVal value As String)
            _cEANTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Unidade Tributável
    ''' </summary>
    Private _uTrib As String
    Public Property uTrib() As String
        Get
            Return _uTrib
        End Get
        Set(ByVal value As String)
            _uTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Quantidade Tributável
    ''' </summary>
    Private _qTrib As System.Nullable(Of Decimal)
    <Formato("#####0.0000", "en-US")> _
    Public Property qTrib() As System.Nullable(Of Decimal)
        Get
            Return _qTrib
        End Get
        Set(ByVal value As System.Nullable(Of Decimal))
            _qTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Unitário de tributação
    '''
    ''' Informar o valor unitário de tributação do produto
    ''' </summary>
    Private _vUnTrib As System.Nullable(Of Double)
    <Formato("#####0.0000", "en-US")> _
    Public Property vUnTrib() As System.Nullable(Of Double)
        Get
            Return _vUnTrib
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _vUnTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do frete
    ''' </summary>
    Private _vFrete As System.Nullable(Of Double)
    Public Property vFrete() As System.Nullable(Of Double)
        Get
            Return _vFrete
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _vFrete = value
        End Set
    End Property
    ''' <summary>
    ''' Valor total do seguro
    ''' </summary>
    Private _vSeg As System.Nullable(Of Double)
    Public Property vSeg() As System.Nullable(Of Double)
        Get
            Return _vSeg
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _vSeg = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do desconto
    ''' </summary>
    Private _vDesc As System.Nullable(Of Double)
    Public Property vDesc() As System.Nullable(Of Double)
        Get
            Return _vDesc
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _vDesc = value
        End Set
    End Property

    ''' <summary>
    ''' Valor outros V2.0
    ''' </summary>

    Private _vOutro As System.Nullable(Of Double)
    <Formato("#####0.0000", "en-US")> _
    Public Property vOutro() As System.Nullable(Of Double)
        Get
            Return _vOutro
        End Get
        Set(ByVal value As System.Nullable(Of Double))
            _vOutro = value
        End Set
    End Property

    ''' <summary>
    ''' Este campo deverá ser preenchido com:
    '''0 – o valor do item (vProd) não compõe o valor total da NF-e (vProd)
    '''1 – o valor do item (vProd) compõe o valor total da NF-e (vProd) (v2.0)
    ''' </summary>
    Private _indTot As Integer
    Public Property indTot() As Integer
        Get
            Return _indTot
        End Get
        Set(ByVal value As Integer)
            _indTot = value
        End Set
    End Property

    Private _Di As DI
    Public Property Di() As DI
        Get
            Return _Di
        End Get
        Set(ByVal value As DI)
            _Di = value
        End Set
    End Property
    Private _VeicProd As veicProd
    Public Property VeicProd() As veicProd
        Get
            Return _VeicProd
        End Get
        Set(ByVal value As veicProd)
            _VeicProd = value
        End Set
    End Property
    'CAMPO RASTRO NFE 4.00
    Public Property Rastro() As List(Of rastro)
        Get
            Return _rastro
        End Get
        Set(ByVal value As List(Of rastro))
            _rastro = value
        End Set
    End Property
    Public Property Med() As List(Of med)
        Get
            Return _med
        End Get
        Set(ByVal value As List(Of med))
            _med = value
        End Set
    End Property
    Private _Arma As arma
    Public Property Arma() As arma
        Get
            Return _Arma
        End Get
        Set(ByVal value As arma)
            _Arma = value
        End Set
    End Property
    Private _Comb As comb
    Public Property Comb() As comb
        Get
            Return _Comb
        End Get
        Set(ByVal value As comb)
            _Comb = value
        End Set
    End Property

End Class