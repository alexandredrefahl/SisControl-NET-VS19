''' <summary>
''' CST – 60 - ICMS cobrado anteriormente por substituição tributária
''' </summary>
Public Class ICMS60
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
    ''' Valor da base de calculo
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
    ''' Valor do ICMS ST cobrado anteriormente por ST
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