Public Class ide
    Private _NFRef As List(Of NFref)
    Public Sub New()
        'vDesc = null;
        _NFRef = New List(Of NFref)()
    End Sub

    ''' <summary>
    ''' Código da UF do emitente do Documento Fiscal. Utilizar a Tabela do IBGE de código de unidades da
    ''' federação (Anexo IV - Tabela de UF, Município e País)
    ''' </summary>
    Private _cUF As Integer
    Public Property cUF() As Integer
        Get
            Return _cUF
        End Get
        Set(ByVal value As Integer)
            _cUF = value
        End Set
    End Property
    ''' <summary>
    ''' Código numérico que compõe a Chave de Acesso. Número aleatório gerado pelo emitente para
    ''' cada NF-e para evitar acessos indevidos da NF-e.
    ''' </summary>
    Private _cNF As String
    Public Property cNF() As String
        Get
            Return _cNF
        End Get
        Set(ByVal value As String)
            _cNF = value
        End Set
    End Property
    ''' <summary>
    ''' Informar a natureza da operação de que decorrer a saída ou a entrada, tais como: venda, compra,
    ''' transferência, devolução, importação, consignação, remessa (para fins de demonstração, de
    ''' industrialização ou outra), conforme previsto na alínea 'i', inciso I, art. 19
    ''' do CONVÊNIO S/Nº, de 15 de dezembro de 1970
    ''' </summary>
    Private _natOp As String
    Public Property natOp() As String
        Get
            Return _natOp
        End Get
        Set(ByVal value As String)
            _natOp = value
        End Set
    End Property
    ''' <summary>
    ''' 0 – pagamento à vista;
    ''' 1 – pagamento à prazo;
    ''' 2 - outros.
    ''' </summary>
    Private _indPag As String
    Public Property indPag() As String
        Get
            Return _indPag
        End Get
        Set(ByVal value As String)
            _indPag = value
        End Set
    End Property
    ''' <summary>
    ''' Utilizar o código 55 para identificação da NF-e, emitida em substituição ao modelo 1 ou 1A.
    ''' </summary>
    Private _mod As String
    Public Property [mod]() As String
        Get
            Return _mod
        End Get
        Set(ByVal value As String)
            _mod = value
        End Set
    End Property
    ''' <summary>
    ''' Série do Documento Fiscal, informar 0 (zero) para série única.
    ''' </summary>
    Private _serie As String
    Public Property serie() As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    ''' <summary>
    ''' Número do Documento Fiscal.
    ''' </summary>
    Private _nNF As String
    Public Property nNF() As String
        Get
            Return _nNF
        End Get
        Set(ByVal value As String)
            _nNF = value
        End Set
    End Property
    ''' <summary>
    ''' Data de emissão do documento fiscal, Formato “AAAA-MM-DD” (v.2.0)
    ''' </summary>
    Private _dEmi As String
    Public Property dEmi() As String
        Get
            Return _dEmi
        End Get
        Set(ByVal value As String)
            _dEmi = value
        End Set
    End Property
    Public Function ShouldSerializedEmi() As Boolean
        Return Not (dEmi = Nothing Or dEmi = String.Empty)
    End Function

    ''' <summary>
    ''' Data de saída ou da entrada da mercadoria/produto, Formato “AAAA-MM-DD” (v.2.0)
    ''' </summary>
    Private _dSaiEnt As String
    Public Property dSaiEnt() As String
        Get
            Return _dSaiEnt
        End Get
        Set(ByVal value As String)
            _dSaiEnt = value
        End Set
    End Property
    Public Function ShouldSerializedSaiEnt() As Boolean
        Return Not (dSaiEnt = Nothing Or dSaiEnt = String.Empty)
    End Function

    ''' <summary>
    ''' Hora de Saída ou da Entrada da Mercadoria/Produto Formato “HH:MM:SS” (v.2.0)
    ''' </summary>
    ''' 
    Private _hSaiEnt As String
    Public Property hSaiEnt() As String
        Get
            Return _hSaiEnt
        End Get
        Set(ByVal value As String)
            _hSaiEnt = value
        End Set
    End Property
    Public Function ShouldSerializehSaiEnt() As Boolean
        Return Not (hSaiEnt = Nothing Or hSaiEnt = String.Empty)
    End Function

    '''<summary>
    '''Data e hora AAAA-MM-DDThh:mm:ssTZD (v.3.0)
    '''</summary>

    Private _dhEmi As String
    Public Property dhEmi() As String
        Get
            Return _dhEmi
        End Get
        Set(value As String)
            _dhEmi = value
        End Set
    End Property

    Public Function ShouldSerializedhEmi() As Boolean
        Return Not (dhEmi = Nothing Or dhEmi = String.Empty)
    End Function

    '''<summary>
    '''Data e hora AAAA-MM-DDThh:mm:ssTZD (v.3.0)
    '''</summary>
    Private _dhSaiEnt As String
    Public Property dhSaiEnt() As String
        Get
            Return _dhSaiEnt
        End Get
        Set(value As String)
            _dhSaiEnt = value
        End Set
    End Property

    Public Function ShouldSerializedhSaiEnt() As Boolean
        Return Not (dhSaiEnt = Nothing Or dhSaiEnt = String.Empty)
    End Function

    ''' <summary>
    ''' 0-entrada / 1-saída
    ''' </summary>
    Private _tpNF As Integer
    Public Property tpNF() As Integer
        Get
            Return _tpNF
        End Get
        Set(ByVal value As Integer)
            _tpNF = value
        End Set
    End Property

    ''' <summary>
    ''' Versão 3.10
    ''' 1=Operação interna 
    ''' 2=Operação interestadual
    ''' 3=Operação com exterior
    ''' </summary>
    Private _idDest As String
    Public Property idDest() As String
        Get
            Return _idDest
        End Get
        Set(ByVal value As String)
            _idDest = value
        End Set
    End Property

    Public Function ShouldSerializeidDest() As Boolean
        Return Not (idDest = Nothing Or idDest = String.Empty)
    End Function

    ''' <summary>
    ''' Informar o município de ocorrência do fato gerador do ICMS. Utilizar a
    ''' Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
    ''' </summary>
    Private _cMunFG As Integer
    Public Property cMunFG() As Integer
        Get
            Return _cMunFG
        End Get
        Set(ByVal value As Integer)
            _cMunFG = value
        End Set
    End Property


    ''' <summary>
    ''' Grupo com as informações das NF/NF-e referenciadas.
    ''' </summary>

    Private _tpImp As Integer
    Public Property tpImp() As Integer
        Get
            Return _tpImp
        End Get
        Set(ByVal value As Integer)
            _tpImp = value
        End Set
    End Property
    ''' <summary>
    ''' 1 – Normal – emissão normal;
    ''' 2 – Contingência FS – emissão em contingência com impressão do DANFE em Formulário de Segurança;
    ''' 3 – Contingência SCAN – emissão em contingência no Sistema de Contingência do Ambiente Nacional – SCAN;
    ''' 4 – Contingência DPEC - emissão em contingência com envio da Declaração Prévia de Emissão em Contingência – DPEC;
    ''' 5 – Contingência FS-DA - emissão em contingência com impressão do DANFE em Formulário de Segurança para Impressão de
    ''' Documento Auxiliar de Documento Fiscal Eletrônico (FS-DA).
    ''' </summary>
    Private _tpEmis As String
    Public Property tpEmis() As String
        Get
            Return _tpEmis
        End Get
        Set(ByVal value As String)
            _tpEmis = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o DV da Chave de Acesso da NF-e, o DV será calculado com a aplicação do algoritmo módulo 11
    ''' (base 2,9) da Chave de Acesso. (vide item 5 do Manual de Integração)
    ''' </summary>
    Private _cDV As String
    Public Property cDV() As String
        Get
            Return _cDV
        End Get
        Set(ByVal value As String)
            _cDV = value
        End Set
    End Property
    ''' <summary>
    ''' 1-Produção/ 2-Homologação
    ''' </summary>
    Private _tpAmb As Integer
    Public Property tpAmb() As Integer
        Get
            Return _tpAmb
        End Get
        Set(ByVal value As Integer)
            _tpAmb = value
        End Set
    End Property
    ''' <summary>
    ''' 1- NF-e normal/ 2-NF-e complementar / 3 – NF-e de ajuste
    ''' </summary>
    Private _finNFe As String
    Public Property finNFe() As String
        Get
            Return _finNFe
        End Get
        Set(ByVal value As String)
            _finNFe = value
        End Set
    End Property

    ''' <summary>
    ''' Versão 3.10 NFe
    ''' 0=Normal; 
    ''' 1=Consumidor final;
    ''' </summary>
    Private _indFinal As String
    Public Property indFinal() As String
        Get
            Return _indFinal
        End Get
        Set(ByVal value As String)
            _indFinal = value
        End Set
    End Property
    Public Function ShouldSerializeindFinal() As Boolean
        Return Not (indFinal = Nothing Or indFinal = String.Empty)
    End Function
    ''' <summary>
    ''' Versão 3.10 NFe    
    ''' 0=Não se aplica (por exemplo, Nota Fiscal complementar 
    ''' ou de ajuste); 
    ''' 1=Operação presencial; 
    ''' 2=Operação não presencial, pela Internet; 
    ''' 3=Operação não presencial, Teleatendimento; 
    ''' 4=NFC-e em operação com entrega a domicílio; 
    ''' 9=Operação não presencial, outros. 
    ''' </summary>

    Private _indPres As String
    Public Property indPres() As String
        Get
            Return _indPres
        End Get
        Set(ByVal value As String)
            _indPres = value
        End Set
    End Property
    Public Function ShouldSerializeindPres() As Boolean
        Return Not (indPres = Nothing Or indPres = String.Empty)
    End Function

    ''' <summary>
    ''' Identificador do processo de emissão da NF-e: 0 - emissão de NF-e com aplicativo do contribuinte;
    ''' 1 - emissão de NF-e avulsa pelo Fisco;
    ''' 2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
    ''' 3- emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.
    ''' </summary>
    Private _procEmi As String
    Public Property procEmi() As String
        Get
            Return _procEmi
        End Get
        Set(ByVal value As String)
            _procEmi = value
        End Set
    End Property
    ''' <summary>
    ''' Identificador da versão do processo de emissão (informar a versão do aplicativo emissor de NF-e).
    ''' </summary>
    Private _verProc As String
    Public Property verProc() As String
        Get
            Return _verProc
        End Get
        Set(ByVal value As String)
            _verProc = value
        End Set
    End Property
    ''' <summary>
    ''' Notas fiscais referenciadas.
    ''' </summary>
    Public Property NFRef() As List(Of NFref)
        Get
            Return _NFRef
        End Get
        Set(ByVal value As List(Of NFref))
            _NFRef = value
        End Set
    End Property
End Class