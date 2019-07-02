''' <summary>
''' TAG de grupo de retenções de tributos
'''
''' Exemplos de atos normativos que definem obrigatoriedade da retenção de contribuições:
''' a) IRPJ/CSLL/PIS/COFINS - Fonte - Recebimentos de Órgãos Públicos Federais
''' Lei nº 9.430, de 27 de dezembro de 1996, art. 64 Lei nº 10.833/2003, art. 34
''' como normas infra-legais, temos como exemplo:
''' Instrução Normativa SRF nº 480/2004 e Instrução Normativa nº 539, de 25/04/2005.
''' b) Retenção do Imposto de Renda pelas Fontes Pagadoras REMUNERAÇÃO DE SERVIÇOS
''' PROFISSIONAIS PRESTADOS POR PESSOA JURÍDICA LEI Nº 7.450/85, ART. 52
''' c) IRPJ, CSLL, COFINS e PIS - Serviços Prestados por Pessoas Jurídicas - Retenção na Fonte
''' Lei nº 10.833 de 29.12.2003, arts. 30, 31, 32, 35 e 36
''' </summary>
Public Class retTrib
    ''' <summary>
    ''' Valor Retido de PIS
    ''' </summary>
    Private _vRetPIS As Double
    Public Property vRetPIS() As Double
        Get
            Return _vRetPIS
        End Get
        Set(ByVal value As Double)
            _vRetPIS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Retido de COFINS
    ''' </summary>
    Private _vRetCOFINS As Double
    Public Property vRetCOFINS() As Double
        Get
            Return _vRetCOFINS
        End Get
        Set(ByVal value As Double)
            _vRetCOFINS = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Retido de CSLL
    ''' </summary>
    Private _vRetCSSL As Double
    Public Property vRetCSSL() As Double
        Get
            Return _vRetCSSL
        End Get
        Set(ByVal value As Double)
            _vRetCSSL = value
        End Set
    End Property
    ''' <summary>
    ''' Base de Cálculo do IRRF
    ''' </summary>
    Private _vBCIRRF As Double
    Public Property vBCIRRF() As Double
        Get
            Return _vBCIRRF
        End Get
        Set(ByVal value As Double)
            _vBCIRRF = value
        End Set
    End Property
    ''' <summary>
    ''' Valor Retido do IRRF
    ''' </summary>
    Private _vIRRF As Double
    Public Property vIRRF() As Double
        Get
            Return _vIRRF
        End Get
        Set(ByVal value As Double)
            _vIRRF = value
        End Set
    End Property
    ''' <summary>
    ''' Base de Cálculo da Retenção da Previdência Social
    ''' </summary>
    Private _vBCRetPrev As Double
    Public Property vBCRetPrev() As Double
        Get
            Return _vBCRetPrev
        End Get
        Set(ByVal value As Double)
            _vBCRetPrev = value
        End Set
    End Property
    ''' <summary>
    ''' Valor da Retenção da Previdência Social
    ''' </summary>
    Private _vRetPrev As Double
    Public Property vRetPrev() As Double
        Get
            Return _vRetPrev
        End Get
        Set(ByVal value As Double)
            _vRetPrev = value
        End Set
    End Property
End Class