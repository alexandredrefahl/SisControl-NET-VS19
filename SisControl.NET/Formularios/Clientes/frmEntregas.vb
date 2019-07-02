Public Class frmEntregas

    Private Sub frmEntregas2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Preenche o combo dos clientes
        Carrega_Lista(cmbClientes, "Clientes", "id", "Nome", True)
    End Sub

    Private Sub btPesquisaPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPesquisaPedidos.Click
        Atualiza_Pedidos()
        'Se pressionou F3 quando o código estava vazio então...
        pnPedidos.Visible = True
    End Sub

    Private Sub txtPedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPedido.KeyDown
        If e.KeyCode = Keys.F3 Then
            Atualiza_Pedidos()
            'Se pressionou F3 quando o código estava vazio então...
            pnPedidos.Visible = True
        End If
    End Sub

    Private Sub btPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPedido.Click
        'Quando confirma pega o id do pedido
        If dgPedidos.SelectedRows.Count > 0 Then
            txtPedido.Text = Val(dgPedidos.SelectedRows(0).Cells(0).Value.ToString)
            'Esconde a telinha
            pnPedidos.Visible = False
            'move o foco para os pedidos
            txtPedido.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Simplesmente esconde a tela de pedidos
        pnPedidos.Visible = False
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub txtPedido_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedido.Leave
        'Atualiza os itens do pedido selecionado
        Atualiza_Datagrid()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Define as variaveis
        Dim SQL As String
        Dim QT, AT, a As Integer

        'SQL de inclusão no ítem do pedido
        SQL = "UPDATE pedidos_itens SET Atendido=Atendido+" & txtEntregue.Text & " WHERE id=" & txtID.Text
        Try
            ExecutaSQL(SQL)
            Console.WriteLine(Me.Name & ": " & SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar a quantidade no registro do pedido" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        'SQL de inclusão no registro de entregas
        SQL = "INSERT INTO pedido_entregas (id_pedido,cliente,id_item,data,quantidade) VALUES (" & txtPedido.Text & "," & cmbVal(cmbClientes) & "," & txtID.Text & ",'" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "'," & txtEntregue.Text & ")"
        Try
            ExecutaSQL(SQL)
            Console.WriteLine(Me.Name & ": " & SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar a quantidade no registro de entregas" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        'Verifica se o pedido foi atendido por completo
        AT = DLookup("Atendido", "Pedidos_itens", "id=" & txtID.Text)
        QT = DLookup("Quantidade", "Pedidos_itens", "id=" & txtID.Text)

        'Se o atendido for maior ou igual ao pedido
        If AT >= QT Then
            a = MsgBox("A quantidade atendida é maior ou igual à quantidade Pedida!" & vbCrLf & "Pedido: " & QT & vbCrLf & "Atendido: " & AT & vbCrLf & "Deseja mudar o status do ítem para Atendido (4)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
            If a = vbYes Then
                SQL = "UPDATE Pedidos_Itens SET Status=4 WHERE id=" & txtID.Text
                Try
                    'Executa a SQL de atualização
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar atualizar o status do ítem " & txtID.Text & " do pedido nº " & txtPedido.Text & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If
        End If
        'Limpa os campos de inclusão
        txtID.Text = String.Empty
        txtCodPro.Text = String.Empty
        txtClone.Text = String.Empty
        txtDescricao.Text = String.Empty
        txtEntregue.Text = String.Empty
        'Atualiza o datagrid
        Atualiza_Datagrid()
    End Sub

    Private Sub Atualiza_Pedidos()
        'Quando mudar o cliente (se tiver alguem selecionado)
        Dim DT As DataTable, SQL As String
        'formata o datagrid
        Dim Texto() As String = {"Nº", "Data", "Nº Itens", "Nº Mudas", "Valor"}
        Dim Tamanhos() As Integer = {60, 75, 55, 55, 65}
        Dim visiveis() As Integer = {1, 1, 1, 1, 1}

        If cmbClientes.SelectedIndex <> -1 Then
            SQL = "SELECT id, Data, Nitens, Nmudas, valor FROM Pedidos WHERE CodCli=" & cmbVal(cmbClientes)
            Try
                'Localiza os pedidos do cliente
                DT = SQLQuery(SQL)
                'Preenche a tabela de pedidos
                dgPedidos.DataSource = DT
                'Usa a funcao genérica para formatar o datagrid
                Formata_Datagrid(dgPedidos, Texto, Tamanhos, visiveis)
            Catch ex As Exception
                MsgBox("Erro ao tentar localizar os pedidos do cliente" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Atualiza_Datagrid()
        Dim DT As DataTable, SQL As String, i As Int16
        'formata o datagrid
        Dim Texto() As String = {"Id", "Cód.", "Clone", "Descrição", "Un.", "Qtde", "Atendido", "Status"}
        Dim Tamanhos() As Integer = {50, 50, 50, 160, 35, 70, 70, 40}
        Dim visiveis() As Integer = {0, 1, 1, 1, 1, 1, 1, 1}

        'se tiver algono campo de pedidos
        If txtPedido.Text.Length > 0 Then
            SQL = "SELECT id,codpro,clone,descricao,unid,quantidade,atendido,status FROM Pedidos_itens WHERE pedido_id=" & txtPedido.Text
            'Verifica os pedidos no banco de dados
            DT = SQLQuery(SQL)
            'Atribui ao datagrid
            dgItens.DataSource = DT
            'Usa a funcao genérica para formatar o datagrid
            Formata_Datagrid(dgItens, Texto, Tamanhos, visiveis)
            'formata as cores de fundo do datagrid
            For i = 0 To dgItens.Rows.Count - 1
                dgItens.Rows(i).Cells(7).Style.BackColor = Cor_Pedido(dgItens.Rows(i).Cells(7).Value)
            Next
        End If
    End Sub

    Private Sub dgItens_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItens.SelectionChanged
        preenche_linha()
    End Sub

    Private Sub Preenche_Linha()
        'Se tem itens selecionados
        If dgItens.SelectedRows.Count > 0 Then
            With dgItens.SelectedRows(0)
                txtID.Text = .Cells(0).Value.ToString
                txtCodPro.Text = .Cells(1).Value.ToString
                txtClone.Text = .Cells(2).Value.ToString
                txtDescricao.Text = .Cells(3).Value.ToString
            End With
        End If
    End Sub

    Private Sub dgPedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPedidos.CellContentClick

    End Sub
End Class