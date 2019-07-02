Partial Class dsMapa_Com
    Partial Class dtComercializacaoDataTable

        Private Sub dtComercializacaoDataTable_dtComercializacaoRowChanging(sender As Object, e As dtComercializacaoRowChangeEvent) Handles Me.dtComercializacaoRowChanging

        End Sub

        Private Sub dtComercializacaoDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ComForaResumoColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
