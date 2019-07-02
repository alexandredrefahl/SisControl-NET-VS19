Public Class imposto
    Public Sub New()
        'Só instância aqueles que são obritórios e utilizados sempre...
    End Sub

    Private _Icms As ICMS
    Public Property Icms() As ICMS
        Get
            Return _Icms
        End Get
        Set(ByVal value As ICMS)
            _Icms = value
        End Set
    End Property

    Private _Ipi As IPI
    Public Property Ipi() As IPI
        Get
            Return _Ipi
        End Get
        Set(ByVal value As IPI)
            _Ipi = value
        End Set
    End Property

    Private _Ii As II
    Public Property Ii() As II
        Get
            Return _Ii
        End Get
        Set(ByVal value As II)
            _Ii = value
        End Set
    End Property

    Private _Pis As PIS
    Public Property Pis() As PIS
        Get
            Return _Pis
        End Get
        Set(ByVal value As PIS)
            _Pis = value
        End Set
    End Property
    Private _PisST As PISST
    Public Property PisST() As PISST
        Get
            Return _PisST
        End Get
        Set(ByVal value As PISST)
            _PisST = value
        End Set
    End Property

    Private _Cofins As COFINS
    Public Property Cofins() As COFINS
        Get
            Return _Cofins
        End Get
        Set(ByVal value As COFINS)
            _Cofins = value
        End Set
    End Property
    Private _CofinsST As COFINSST
    Public Property CofinsST() As COFINSST
        Get
            Return _CofinsST
        End Get
        Set(ByVal value As COFINSST)
            _CofinsST = value
        End Set
    End Property

    Private _ICMSUFDest As ICMSUFDest
    Public Property ICMSUFDest() As ICMSUFDest
        Get
            Return _ICMSUFDest
        End Get
        Set(ByVal value As ICMSUFDest)
            _ICMSUFDest = value
        End Set
    End Property

    Private _Issqn As ISSQN
    Public Property Issqn() As ISSQN
        Get
            Return _Issqn
        End Get
        Set(ByVal value As ISSQN)
            _Issqn = value
        End Set
    End Property

End Class