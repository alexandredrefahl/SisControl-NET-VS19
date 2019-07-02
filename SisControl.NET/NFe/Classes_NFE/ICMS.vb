''' <summary>
''' Informar apenas um dos grupos N02, N03, N04, N05, N06, N07, N08, N09 ou N10, com base no
''' conteúdo informado na TAG CST.
''' </summary>
Public Class ICMS
    Public Sub New()

    End Sub

    Private _Icms00 As ICMS00
    Public Property Icms00() As ICMS00
        Get
            Return _Icms00
        End Get
        Set(ByVal value As ICMS00)
            _Icms00 = value
        End Set
    End Property
    Private _Icms10 As ICMS10
    Public Property Icms10() As ICMS10
        Get
            Return _Icms10
        End Get
        Set(ByVal value As ICMS10)
            _Icms10 = value
        End Set
    End Property
    Private _Icms20 As ICMS20
    Public Property Icms20() As ICMS20
        Get
            Return _Icms20
        End Get
        Set(ByVal value As ICMS20)
            _Icms20 = value
        End Set
    End Property
    Private _Icms30 As ICMS30
    Public Property Icms30() As ICMS30
        Get
            Return _Icms30
        End Get
        Set(ByVal value As ICMS30)
            _Icms30 = value
        End Set
    End Property
    Private _Icms40 As ICMS40
    Public Property Icms40() As ICMS40
        Get
            Return _Icms40
        End Get
        Set(ByVal value As ICMS40)
            _Icms40 = value
        End Set
    End Property
    Private _Icms51 As ICMS51
    Public Property Icms51() As ICMS51
        Get
            Return _Icms51
        End Get
        Set(ByVal value As ICMS51)
            _Icms51 = value
        End Set
    End Property
    Private _Icms60 As ICMS60
    Public Property Icms60() As ICMS60
        Get
            Return _Icms60
        End Get
        Set(ByVal value As ICMS60)
            _Icms60 = value
        End Set
    End Property
    Private _Icms70 As ICMS70
    Public Property Icms70() As ICMS70
        Get
            Return _Icms70
        End Get
        Set(ByVal value As ICMS70)
            _Icms70 = value
        End Set
    End Property
    Private _Icms90 As ICMS90
    Public Property Icms90() As ICMS90
        Get
            Return _Icms90
        End Get
        Set(ByVal value As ICMS90)
            _Icms90 = value
        End Set
    End Property

    Private _ICMSSN101 As ICMSSN101
    Public Property ICMSSN101() As ICMSSN101
        Get
            Return _ICMSSN101
        End Get
        Set(ByVal value As ICMSSN101)
            _ICMSSN101 = value
        End Set
    End Property

    Private _ICMSSN102 As ICMSSN102
    Public Property ICMSSN102() As ICMSSN102
        Get
            Return _ICMSSN102
        End Get
        Set(ByVal value As ICMSSN102)
            _ICMSSN102 = value
        End Set
    End Property
End Class