Public Class ICMSSN102

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
    '102 - Tributada pelo Simples Nacional sem permissão de crédito.
    '103 – Isenção do ICMS no Simples Nacional para faixa de receita bruta.
    '300 – Imune.
    '400 – Não tributada pelo Simples Nacional
    Private _CSOSN As String
    Public Property CSOSN() As String
        Get
            Return _CSOSN
        End Get
        Set(ByVal value As String)
            _CSOSN = value
        End Set
    End Property
End Class

