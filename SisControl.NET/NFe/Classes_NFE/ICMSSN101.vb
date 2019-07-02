Public Class ICMSSN101
    ' Origem da mercadoria:
    ' 0 – Nacional;
    ' 1 – Estrangeira – Importação direta;
    ' 2 – Estrangeira – Adquirida no mercado interno.
    Private _orig As String
    Public Property orig() As String
        Get
            Return _orig
        End Get
        Set(ByVal value As String)
            _orig = value
        End Set
    End Property

    'CSOSN
    '101- Tributada pelo Simples Nacional sem permissão de crédito.
    Private _CSOSN As String
    Public Property CSOSN() As String
        Get
            Return _CSOSN
        End Get
        Set(ByVal value As String)
            _CSOSN = value
        End Set
    End Property

    'pCredSN
    'Alíquota aplicável de cálculo do crédito (Simples Nacional)
    Private _pCredSN As String
    Public Property pCredSN() As String
        Get
            Return _pCredSN
        End Get
        Set(ByVal value As String)
            _pCredSN = value
        End Set
    End Property

    'vCredICMSSN
    'Valor crédito do ICMS que pode ser aproveitado nos termos do art. 23 da LC 123 (Simples Nacional)
    Private _vCredICMSSN As String
    Public Property vCredICMSSN() As String
        Get
            Return _vCredICMSSN
        End Get
        Set(ByVal value As String)
            _vCredICMSSN = value
        End Set
    End Property
End Class
