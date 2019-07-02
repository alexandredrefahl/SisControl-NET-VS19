Public Class frmAux_Pedido_WEB

    Private _PedidoID As String
    Public Property PedidoID As String
        Get
            Return _PedidoID
        End Get
        Set(value As String)
            _PedidoID = value
        End Set
    End Property


    Private Sub frmAux_Pedido_WEB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dimensiona a strin SQL
        Dim sql As String = "SELECT id,DATA,CONCAT_WS(' ',nome,sobrenome) as Nome FROM clonagen_ocar931.oc6p_View_Pedido ORDER BY id"
        'Dim sql As String = "SELECT record,VALUE FROM vtex_facileforms_subrecords WHERE NAME='txtNome' AND record IN(SELECT id FROM vtex_facileforms_records WHERE NAME='Cadastro_de_Clientes')"

        'Dimensiona o DataTable
        Dim DT As DataTable
        Me.Cursor = Cursors.WaitCursor
        Try
            DT = SQLQuery(sql, True)
            'Atribui o datatable ao datagrid
            dgPedidoWEB.DataSource = DT
            formata_datagrid()
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Falha ao acessar o banco de dados remoto para obter dados dos clientes" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub formata_datagrid()
        With dgPedidoWEB
            With .Columns(0)    'Coluna ID
                .Width = 60
                .HeaderText = "ID"
            End With
            With .Columns(1)    'Coluna Data
                .Width = 85
                .HeaderText = "Data"
            End With
            With .Columns(2)    'Coluna Nome
                .Width = 282
                .HeaderText = "Nome/Razão Social"
            End With
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Se existe algo selecionado
        If dgPedidoWEB.SelectedRows.Count > 0 Then
            'Atribui à classe ao botão selecionado
            _PedidoID = dgPedidoWEB.Rows(dgPedidoWEB.SelectedCells(0).RowIndex).Cells(0).Value
        End If
        Me.Close()
    End Sub

End Class