''' <summary>
''' Grupo com as informações do destinatário da NF-e.
''' </summary>
Public Class dest
    Private _enderDest As enderDest
    Public Sub New()
        _enderDest = New enderDest()
    End Sub
    ''' <summary>
    ''' Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos.
    ''' Não informar o conteúdo da TAG se a operação for realizada com o exterior.
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
    ''' Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos.
    ''' Não informar o conteúdo da TAG se a operação for realizada com o exterior.
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
    ''' Razão Social ou nome do destinatário
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
    ''' Obrigatório, nas operações que se beneficiam de incentivos fiscais existentes nas áreas sob controle
    ''' da SUFRAMA. A omissão da Inscrição SUFRAMA impede o processamento da operação pelo Sistema de
    ''' Mercadoria Nacional da SUFRAMA e a liberação da Declaração de Ingresso, prejudicando a
    ''' comprovação do ingresso/internamento da mercadoria nas áreas sob controle da SUFRAMA.
    ''' </summary>
    Private _ISUF As String
    Public Property ISUF() As String
        Get
            Return _ISUF
        End Get
        Set(ByVal value As String)
            _ISUF = value
        End Set
    End Property
    Public ReadOnly Property EnderDest() As enderDest
        Get
            Return _enderDest
        End Get
    End Property

    '''<summary>
    ''' Versão NFe 3.10  
    ''' 1=Contribuinte ICMS (informar a IE do destinatário); 
    ''' 2=Contribuinte isento de Inscrição no cadastro de Contribuintes do ICMS; 
    ''' 9=Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS. 
    ''' Nota 1: No caso de NFC-e informar indIEDest=9 e não informar a tag IE do destinatário; 
    ''' Nota 2: No caso de operação com o Exterior informar 
    ''' indIEDest=9 e não informar a tag IE do destinatário; 
    ''' Nota 3: No caso de Contribuinte Isento de Inscrição 
    ''' (indIEDest=2), não informar a tag IE do destinatário. 
    '''</summary>
    ''' 
    Private _indIEDest As String
    Public Property indIEDest() As String
        Get
            Return _indIEDest
        End Get
        Set(ByVal value As String)
            _indIEDest = value
        End Set
    End Property

    '''<summary>
    ''' 
    ''' Informar a IE quando o destinatário for contribuinto do ICMS. Informar ISENTO quando o
    ''' destinatário for contribuinto do ICMS, mas não estiver obrigado à inscrição no cadastro de
    ''' contribuintes do ICMS. Não informar o conteúdo da TAG se o destinatário não for contribuinte do ICMS.
    ''' Esta tag aceita apenas: . ausência de conteúdo (<IE></IE> ou <IE/>) para destinatários não
    ''' contribuintes do ICMS; . algarismos para destinatários contribuintes do ICMS, sem caracteres de formatação (ponto,
    ''' barra, hífen, etc.); . literal “ISENTO” para destinatários contribuintes do ICMS que são isentos de inscrição no cadastro de
    ''' contribuintes do ICMS;
    ''' 
    '''</summary>
    Private _IE As String
    <Obrigatorio()> _
    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property
    ''' <summary>
    ''' Preencher com Email do Destinatário.
    ''' </summary>
    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
End Class