''' <summary>
''' TAG de grupo de informações específicas para combustíveis líquidos
''' </summary>
Public Class comb
    Private _CIDE As CIDE
    Public Sub New()
        _CIDE = New CIDE()
    End Sub

    Public ReadOnly Property Cide() As CIDE
        Get
            Return _CIDE
        End Get
    End Property

    ''' <summary>
    ''' Informar apenas quando se tratar de produtos regulados pela ANP -Agência Nacional do Petróleo.
    ''' Utilizar a codificação de produtos do Sistema de Informações de Movimentação de produtos - SIMP
    ''' (http://www.anp.gov.br/simp/index.htm)
    ''' </summary>
    Private _cProdANP As String
    Public Property cProdANP() As String
        Get
            Return _cProdANP
        End Get
        Set(ByVal value As String)
            _cProdANP = value
        End Set
    End Property
    ''' <summary>
    ''' Informar apenas quando a UF utilizar o CODIF (Sistema de Controle do Diferimento do Imposto nas Operações com AEAC - Álcool
    ''' Etílico Anidro Combustível).
    ''' </summary>
    Private _CODIF As String
    Public Property CODIF() As String
        Get
            Return _CODIF
        End Get
        Set(ByVal value As String)
            _CODIF = value
        End Set
    End Property
    ''' <summary>
    ''' Informar quando a quantidade faturada informada no campo qCom (I10) tiver sido ajustada para
    ''' uma temperatura diferente da ambiente.
    ''' </summary>
    Private _qTemp As String
    Public Property qTemp() As String
        Get
            Return _qTemp
        End Get
        Set(ByVal value As String)
            _qTemp = value
        End Set
    End Property
End Class
