Public Class Formato
    Inherits Attribute
    Public formato As String
    Public cultura As String

    Public Sub New(ByVal formatoInf As String, ByVal culturaInf As String)
        Me.formato = formatoInf
        Me.cultura = culturaInf
    End Sub
End Class
