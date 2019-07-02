''' <summary>
''' TAG de grupo do COFINS
''' Informar apenas um dos grupos S02, S03, S04 ou S04 com base valor atribuído ao campo
''' S06 – CST do COFINS
''' </summary>
Public Class COFINS
    Private _CofinsAliq As COFINSAliq
    Public Property CofinsAliq() As COFINSAliq
        Get
            Return _CofinsAliq
        End Get
        Set(ByVal value As COFINSAliq)
            _CofinsAliq = value
        End Set
    End Property
    Private _CofinsQtde As COFINSQtde
    Public Property CofinsQtde() As COFINSQtde
        Get
            Return _CofinsQtde
        End Get
        Set(ByVal value As COFINSQtde)
            _CofinsQtde = value
        End Set
    End Property
    Private _CofinsNT As COFINSNT
    Public Property CofinsNT() As COFINSNT
        Get
            Return _CofinsNT
        End Get
        Set(ByVal value As COFINSNT)
            _CofinsNT = value
        End Set
    End Property
    Private _CofinsOutr As COFINSOutr
    Public Property CofinsOutr() As COFINSOutr
        Get
            Return _CofinsOutr
        End Get
        Set(ByVal value As COFINSOutr)
            _CofinsOutr = value
        End Set
    End Property
End Class