''' <summary>
''' TAG de grupo do CST 01, 02, 03,04, 51, 52, 53, 54 e 55
''' </summary>
Public Class IPINT
    ''' <summary>
    ''' 01-Entrada tributada com alíquota zero
    ''' 02-Entrada isenta
    ''' 03-Entrada não-tributada
    ''' 04-Entrada imune
    ''' 05-Entrada com suspensão
    ''' 51-Saída tributada com alíquota zero
    ''' 52-Saída isenta
    ''' 53-Saída não-tributada
    ''' 54-Saída imune
    ''' 55-Saída com suspensão
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
End Class