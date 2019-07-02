''' <summary>
''' Informar apenas um dos grupos Q02, Q03, Q04 ou Q05 com base valor atribuído ao campo Q06 –CST do PIS
''' </summary>
Public Class PIS
    Private _PisAliq As PISAliq
    Public Property PisAliq() As PISAliq
        Get
            Return _PisAliq
        End Get
        Set(ByVal value As PISAliq)
            _PisAliq = value
        End Set
    End Property
    Private _PisQtd As PISQtde
    Public Property PisQtd() As PISQtde
        Get
            Return _PisQtd
        End Get
        Set(ByVal value As PISQtde)
            _PisQtd = value
        End Set
    End Property
    Private _PisNT As PISNT
    Public Property PisNT() As PISNT
        Get
            Return _PisNT
        End Get
        Set(ByVal value As PISNT)
            _PisNT = value
        End Set
    End Property
    Private _PisOutr As PISOutr
    Public Property PisOutr() As PISOutr
        Get
            Return _PisOutr
        End Get
        Set(ByVal value As PISOutr)
            _PisOutr = value
        End Set
    End Property
End Class