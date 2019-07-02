Public Class frmAux_Clientes_WEB

    Private _clienteID As String
    Public Property ClienteID As String
        Get
            Return _clienteID
        End Get
        Set(value As String)
            _clienteID = value
        End Set
    End Property

    Private _clienteNOME As String
    Public Property ClientNOME As String
        Get
            Return _clienteNOME
        End Get
        Set(value As String)
            _clienteNOME = value
        End Set
    End Property

    Private Sub frmAux_Clientes_WEB_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dimensiona a strin SQL
        Dim sql As String = "SELECT customer_id, concat_ws(' ',firstname,lastname) as nome FROM clonagen_ocar931.oc6p_customer"

        'Dimensiona o DataTable
        Dim DT As DataTable
        Me.Cursor = Cursors.WaitCursor
        Try
            DT = SQLQuery(sql, True)
            'Atribui o datatable ao datagrid
            dgClientesWEB.DataSource = DT
            formata_datagrid()
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Falha ao acessar o banco de dados remoto para obter dados dos clientes" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Fecha o formulário
        Me.Close()
    End Sub

    Private Sub formata_datagrid()
        With dgClientesWEB
            With .Columns(0)    'Coluna ID
                .Width = 60
                .HeaderText = "ID"
            End With
            With .Columns(1)    'Coluna Nome
                .Width = 282
                .HeaderText = "Nome/Razão Social"
            End With
        End With
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Se existe algo selecionado
        If dgClientesWEB.SelectedRows.Count > 0 Then
            'Atribui à classe ao botão selecionado
            _clienteID = dgClientesWEB.Rows(dgClientesWEB.SelectedCells(0).RowIndex).Cells(0).Value
        End If
        Me.Close()
    End Sub
End Class