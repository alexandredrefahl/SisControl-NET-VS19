Imports System.ComponentModel

Public Class frmReservas

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmReservas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Atualiza DataGrig
        Atualiza_Datagrid()
        'Carrega o nome das mercadorias
        Carrega_Lista(cmbMercadoria, "mercadoria_num", "id", "Nome", True)
        'Atualiza para data de hoje
        txtData.Value = Today.Date
    End Sub

    Private Sub ReservasDataGridView_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgReservas.SelectionChanged
        Aplica_Filtro()
    End Sub

    Private Sub Atualiza_Datagrid()
        Try
            'Preenche novamente
            taReservas.Fill(DsReserva.reservas)
        Catch ex As Exception
            'MsgBox("Erro" & vbCrLf & ex.Message)
            Console.WriteLine("Erro Popular Reservas" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Aplica_Filtro()
        'Se existir alguma linha selecionada aplica o filtro
        If dgReservas.SelectedRows.Count > 0 Then
            'Filtra os sub ítens das reservas selecionadas
            Dim Criterio As String = String.Empty
            'Pega o ID da linha selecionada
            Criterio = "Doc_ID=" & dgReservas.SelectedRows(0).Cells(0).Value
            'Aplica o filtro no BindingSource dos ítens
            Dim DT As New DataTable
            Try
                DT = SQLQuery("SELECT * FROM reservas_itens WHERE " & Criterio)
                dgItens.DataSource = DT
                DT.Dispose()
                Formata_Grid_Itens()
            Catch ex As Exception
                MsgBox("Erro ao tentar recuperar os ítens da reserva" & vbCrLf & ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Formata_Grid_Itens()

        With dgItens
            With .Columns("id")
                .Visible = False
            End With
            With .Columns("Doc_Id")
                .Visible = False
            End With
            With .Columns("Mercadoria")
                .Width = 65
                .HeaderText = "Mercadoria"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "000"
            End With
            With .Columns("Clone")
                .HeaderText = "Clone"
                .Width = 65
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "0000"
            End With
            With .Columns("Descricao")
                .HeaderText = "Descrição"
                .Width = 200
            End With
            With .Columns("Quantidade")
                .HeaderText = "Quantidade"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N0"
            End With
            With .Columns("Preco")
                .HeaderText = "Valor"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
            End With
            With .Columns("Forma")
                .HeaderText = "Forma"
                .Width = 135
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
        End With
    End Sub

    Private Sub btAtendida_Click(sender As System.Object, e As System.EventArgs) Handles btAtendida.Click
        'Verifica se existe alguma linha selecionada
        If dgReservas.SelectedRows.Count <= 0 Then
            MsgBox("Não existe nenhuma reserva selecionada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        'Se houver alguma linha selecionada continua
        Dim IDReserva As Integer
        'Pega o id da reserva
        IDReserva = dgReservas.SelectedRows(0).Cells(0).Value
        'monta a SQL de atualização
        Dim SQL As String
        SQL = "UPDATE Reservas SET Atendido=1 WHERE id=" & IDReserva

        Try
            'Executa a Atualização
            ExecutaSQL(SQL)
            'Se Deu certo, atualiza o Datagrid
            Atualiza_Datagrid()
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar as informações da Reserva", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub btExcluir_Click(sender As System.Object, e As System.EventArgs) Handles btExcluir.Click
        'Verifica se existe alguma linha selecionada
        If dgReservas.SelectedRows.Count <= 0 Then
            MsgBox("Não existe nenhuma reserva selecionada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If

        Dim resp As Integer = MsgBox("Deseja realmente excluir a Reserva Selecionada e todos os seus ítens?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")

        'Verifica confirmação
        If resp <> vbYes Then
            Exit Sub
        End If

        'Se o usuário confirmar então exclui

        Dim IDReserva As Integer
        'Pega o id da reserva
        IDReserva = dgReservas.SelectedRows(0).Cells(0).Value
        'monta a SQL de atualização
        Dim SQL As String, SQL_Itens
        SQL = "DELETE FROM Reservas WHERE id=" & IDReserva
        SQL_Itens = "DELETE FROM reservas_itens WHERE Doc_Id=" & IDReserva
        'Tenta excluir os ítens da reserva
        Try
            'Exclui o ítens da reserva
            ExecutaSQL(SQL_Itens)
            Atualiza_Datagrid()
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir os Ítens da Reserva Núm: " & IDReserva, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
        'Tenta excluir a reserva em sí
        Try
            'Exclui a reserva em sí
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir a Reserva de Núm: " & IDReserva, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub cboMercadoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMercadoria.SelectedIndexChanged
        'Se não houver produto selecionado
        If cmbMercadoria.SelectedIndex = -1 Then
            Exit Sub
        End If
        'Carrega os clones assim que a caixa de produtos for alterada
        Carrega_Lista(cmbClone, "clones_num", "id", "nome", True, "Mercadoria=" & cmbVal(cmbMercadoria))
    End Sub

    Private Sub txtQuantidade_Leave(sender As System.Object, e As System.EventArgs) Handles txtQuantidade.Leave
        txtQuantidade.Text = Format(String_to_Numero(txtQuantidade.Text), "N0")
    End Sub

    Private Sub TextBox1_Leave(sender As System.Object, e As System.EventArgs) Handles txtValor.Leave
        txtValor.Text = Format(String_to_Numero(txtValor.Text), "N2")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim email As String
        'Pega o e-mail do cliente da linha selecionada
        email = dgReservas.SelectedRows(0).Cells(4).Value
        'Copia para o clipboard
        Clipboard.SetText(email, TextDataFormat.Text)
    End Sub

    Private Sub btIncluir_Click(sender As System.Object, e As System.EventArgs) Handles btIncluir.Click
        Dim SQL As String = String.Empty
        'Monta a SQL de inclusão
        SQL = "INSERT INTO reservas SET "
        SQL &= "Data='" & Format(txtData.Value, "yyyy-MM-dd") & "',"
        SQL &= "Nome='" & txtNome.Text & "',"
        SQL &= "Fone=" & Texto_Vazio(txtFone.Text) & ","
        SQL &= "Email=" & Texto_Vazio(txtEmail.Text) & ","
        SQL &= "Atendido=0"

        If Valida_Campos() Then
            'Tenta fazer a inclusão
            Try
                ExecutaSQL(SQL)
                DataGridRefresh()
                'Posiciona a seleção no último ítem
                dgReservas.Rows(dgReservas.Rows.Count - 1).Selected = True
                Limpa_Campos()
                MsgBox("Reserva incluída com sucesso. Utilize o campo abaixo para incluir os ítens da Reserva", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir Reserva", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        Else
        End If
    End Sub

    Private Function Valida_Campos() As Boolean
        Dim msg As String = String.Empty

        'Verifica o nome que não pode ser  nulo
        If txtNome.Text = String.Empty Then
            msg &= "Nome não pode estar em branco" & vbCrLf
        End If

        'Deu erro em algum campo
        If msg.Length > 0 Then
            MsgBox("O preenchimento dos campos está incorreto, verifique:" & vbCrLf & msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Limpa_Campos()
        txtData.Value = Today
        txtNome.Text = String.Empty
        txtFone.Text = String.Empty
        txtEmail.Text = String.Empty
    End Sub

    Private Sub btAdd_Item_Click(sender As System.Object, e As System.EventArgs) Handles btAdd_Item.Click
        Dim SQL As String = String.Empty
        Dim Descricao As String, Mercadoria As Integer, Clone As Integer

        Mercadoria = cmbVal(cmbMercadoria)
        Clone = Int(cmbClone.Text.Substring(0, 4))
        Descricao = DLookup("Cientifico", "Mercadoria", "id=" & Mercadoria) & " cv. " & DLookup("Nome", "Clones", "Mercadoria=" & Mercadoria & " AND Clone=" & Clone)

        SQL = "INSERT INTO reservas_itens SET "
        SQL &= "Doc_ID=" & dgReservas.SelectedRows(0).Cells(0).Value & ","
        SQL &= "Mercadoria=" & Mercadoria & ","
        SQL &= "Clone=" & Clone & ","
        SQL &= "Descricao='" & Descricao & "',"
        SQL &= "Quantidade=" & Numero_to_SQL(txtQuantidade.Text) & ","
        SQL &= "Forma='Muda Aclimatizada',"
        SQL &= "Preco=" & Numero_to_SQL(txtValor.Text)

        Try
            ExecutaSQL(SQL)
            MsgBox("Item acrescentado com sucesso!")
            Aplica_Filtro()
            cmbMercadoria.Text = ""
            cmbClone.Text = ""
            txtQuantidade.Text = "0"
            txtValor.Text = "0,00"
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir item na reserva" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub btRemove_Item_Click(sender As System.Object, e As System.EventArgs) Handles btRemove_Item.Click
        Dim SQL As String

        'Monta a SQL de exclusão
        SQL = "DELETE FROM reservas_itens WHERE id=" & dgItens.SelectedRows(0).Cells(0).Value

        Try
            ExecutaSQL(SQL)
            MsgBox("Item excluído com sucesso!")
            Aplica_Filtro()
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir item da reserva" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub btEdit_Click(sender As System.Object, e As System.EventArgs) Handles btEdit.Click
        'Prevê as duas situações
        If btEdit.Text = "Alterar" Then
            'Pega as informações no banco de dados e muda o texto do botão para Salvar

            btEdit.Text = "Salvar"
        ElseIf btEdit.Text = "Salvar" Then

        End If
    End Sub

    Private Sub btEmail_Click(sender As Object, e As EventArgs) Handles btEmail.Click
        Dim Aux_Email As New aux_Processa_Email(Me)
        'Define a mesma janela parente
        Aux_Email.MdiParent = Me.MdiParent
        'Mostra como uma caixa de diálogo
        Aux_Email.Show()
    End Sub

    Public Sub DataGridRefresh()
        'Depois de sair do diálogo atualiza o datagrid
        Atualiza_Datagrid()
        'Posiciona a seleção no último ítem
        dgReservas.Rows(dgReservas.Rows.Count - 1).Selected = True
        dgReservas.CurrentCell = dgReservas.Rows(dgReservas.Rows.Count - 1).Cells(0)
    End Sub


End Class