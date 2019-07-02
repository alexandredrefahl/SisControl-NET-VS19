''' <summary>
''' TAG de grupo de Retenção do ICMS do transporte
'''
''' Informar o valor do ICMS do serviço de transporte retido.
''' </summary>
Public Class retTransp
    ''' <summary>
    ''' Valor do Serviço
    ''' </summary>
    Private _vServ As Double
    Public Property vServ() As Double
        Get
            Return _vServ
        End Get
        Set(ByVal value As Double)
            _vServ = value
        End Set
    End Property
    ''' <summary>
    ''' BC da Retenção do ICMS
    ''' </summary>
    Private _vBCRet As Double
    Public Property vBCRet() As Double
        Get
            Return _vBCRet
        End Get
        Set(ByVal value As Double)
            _vBCRet = value
        End Set
    End Property
    ''' <summary>
    ''' Alíquota da Retenção
    ''' </summary>
    Private _pICMSRet As Double
    Public Property pICMSRet() As Double
        Get
            Return _pICMSRet
        End Get
        Set(ByVal value As Double)
            _pICMSRet = value
        End Set
    End Property
    ''' <summary>
    ''' Valor do ICMS Retido
    ''' </summary>
    Private _vICMSRet As Double
    Public Property vICMSRet() As Double
        Get
            Return _vICMSRet
        End Get
        Set(ByVal value As Double)
            _vICMSRet = value
        End Set
    End Property
    ''' <summary>
    ''' CFOP
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
    ''' Código do município de ocorrência do fato gerador do ICMS do transporte
    '''
    ''' Informar o município de ocorrência do fato gerador do ICMS do transporte.
    ''' Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
    ''' </summary>
    Private _cMunFG As String
    Public Property cMunFG() As String
        Get
            Return _cMunFG
        End Get
        Set(ByVal value As String)
            _cMunFG = value
        End Set
    End Property
End Class