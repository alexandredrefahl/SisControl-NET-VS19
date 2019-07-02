''' <summary>
''' TAG do grupo de COFINS não tributado
''' CST = 04, 06, 07, 08, 09
''' </summary>
Public Class COFINSNT
    ''' <summary>
    ''' 04 - Operação Tributável (tributação monofásica (alíquota zero));
    ''' 06 - Operação Tributável (alíquota zero);
    ''' 07 - Operação Isenta da Contribuição;
    ''' 08 - Operação Sem Incidência da Contribuição;
    ''' 09 - Operação com Suspensão da Contribuição;
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