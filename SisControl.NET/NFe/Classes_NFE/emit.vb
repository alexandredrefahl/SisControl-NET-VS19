''' <summary>
''' Grupo com as informações do emitente da NF-e
''' </summary>
Public Class emit
    Public Sub New()
        _enderEmit = New enderEmit()
    End Sub

    Private _enderEmit As enderEmit

    ''' <summary>
    ''' Informar o CNPJ do emitente. Em se tratando de emissão de NF-e avulsa pelo Fisco, as informações
    ''' do remente serão informadas neste grupo. O CNPJ ou CPF deverão ser informados com os zeros não
    ''' significativos.
    ''' </summary>
    Private _CNPJ As String
    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o CNPJ do emitente. Em se tratando de emissão de NF-e avulsa pelo Fisco, as informações
    ''' do remente serão informadas neste grupo. O CNPJ ou CPF deverão ser informados com os zeros não
    ''' significativos.
    ''' </summary>
    Private _CPF As String
    Public Property CPF() As String
        Get
            Return _CPF
        End Get
        Set(ByVal value As String)
            _CPF = value
        End Set
    End Property
    ''' <summary>
    ''' Razão social ou nome do emitente
    ''' </summary>
    Private _xNome As String
    Public Property xNome() As String
        Get
            Return _xNome
        End Get
        Set(ByVal value As String)
            _xNome = value
        End Set
    End Property
    ''' <summary>
    ''' Nome fantasia
    ''' </summary>
    Private _xFant As String
    Public Property xFant() As String
        Get
            Return _xFant
        End Get
        Set(ByVal value As String)
            _xFant = value
        End Set
    End Property
    ''' <summary>
    ''' TAG de grupo do Endereço do emitente
    ''' </summary>
    Public ReadOnly Property EnderEmit() As enderEmit
        Get
            Return _enderEmit
        End Get
    End Property

    ''' <summary>
    ''' Campo de informação obrigatória nos casos de emissão própria (procEmi = 0, 2 ou 3).
    ''' A IE deve ser informada apenas com algarismos para destinatários contribuintes do ICMS, sem
    ''' caracteres de formatação (ponto,barra, hífen, etc.);
    ''' O literal “ISENTO” deve ser informado apenas para contribuintes do ICMS que são isentos de inscrição no cadastro de
    ''' contribuintes do ICMS e estejam emitindo NF-e avulsa;
    ''' </summary>
    Private _IE As String
    '<Obrigatorio()> _
    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property
    ''' <summary>
    ''' Informar a IE do ST da UF de destino da mercadoria, quando houver a retenção do ICMS ST para a UF de destino.
    ''' </summary>
    Private _IEST As String
    Public Property IEST() As String
        Get
            Return _IEST
        End Get
        Set(ByVal value As String)
            _IEST = value
        End Set
    End Property
    ''' <summary>
    ''' Este campo deve ser informado, quando ocorrer a emissão de NF-e conjugada, com prestação de
    ''' serviços sujeitos ao ISSQN e fornecimento de peças sujeitos ao ICMS.
    ''' </summary>
    Private _IM As String
    Public Property IM() As String
        Get
            Return _IM
        End Get
        Set(ByVal value As String)
            _IM = value
        End Set
    End Property
    ''' <summary>
    ''' Este campo deve ser informado quando o campo IM (C19) for informado.
    ''' </summary>
    Private _CNAE As String
    Public Property CNAE() As String
        Get
            Return _CNAE
        End Get
        Set(ByVal value As String)
            _CNAE = value
        End Set
    End Property
    ''' <summary>
    '''Este campo será obrigatoriamente preenchidocom:
    '''1 – Simples Nacional;
    '''2 – Simples Nacional – excesso
    '''de sublimite de receita bruta;
    '''3 – Regime Normal. (v2.0).
    ''' </summary>

    Private _CRT As String
    Public Property CRT() As String
        Get
            Return _CRT
        End Get
        Set(ByVal value As String)
            _CRT = value
        End Set
    End Property
End Class