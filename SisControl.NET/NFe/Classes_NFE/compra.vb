''' <summary>
''' TAG do Grupo de Compra
''' Informar adicionais de compra
''' </summary>
Public Class compra
    ''' <summary>
    ''' Informar a identificação da Nota de Empenho, quando se tratar de compras públicas
    ''' </summary>
    Private _xNEmp As String
    Public Property xNEmp() As String
        Get
            Return _xNEmp
        End Get
        Set(ByVal value As String)
            _xNEmp = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o pedido.
    ''' </summary>
    Private _xPed As String
    Public Property xPed() As String
        Get
            Return _xPed
        End Get
        Set(ByVal value As String)
            _xPed = value
        End Set
    End Property
    ''' <summary>
    ''' Informar o contrato de compra
    ''' </summary>
    Private _xCont As String
    Public Property xCont() As String
        Get
            Return _xCont
        End Get
        Set(ByVal value As String)
            _xCont = value
        End Set
    End Property
End Class