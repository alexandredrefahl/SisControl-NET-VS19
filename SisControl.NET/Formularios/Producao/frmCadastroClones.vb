Public Class frmCadastroClones
    Public Status As String

    Private Sub frmCadastroClones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista de mercadorias
        Carrega_Lista(cmbMercadoria, "Mercadoria_num", "id", "Nome")

    End Sub

    Private Sub cmbMercadoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMercadoria.SelectedIndexChanged
        'Quando mudar a seleção aqui disponibiliza os clones para serem editados
        Carrega_Lista(lstClone, "Clones_num", "id", "nome", True, "Mercadoria=" & cmbVal(cmbMercadoria))
    End Sub

    Private Sub lstClone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClone.SelectedIndexChanged
        Dim DT As DataTable, SQL As String
        'Monta a Sql
        SQL = "SELECT * FROM Clones WHERE id=" & cmbVal(lstClone)
        'Pega o resultado no formato de tabela
        DT = SQLQuery(SQL)
        'Se houver resultado
        If DT.Rows.Count > 0 Then
            With DT.Rows(0)
                txtClone.Text = .Item("clone")
                txtNome.Text = .Item("Nome")
                'Para evitar a excessão do null
                txtDescricao.Text = IIf(IsDBNull(.Item("descricao")), "", .Item("Descricao"))
                'Habilita a edição
                btEditar.Enabled = True
            End With
        End If
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        'Edição
        Status = "Edi"
        'Habilita o grupo de edição
        grpClone.Enabled = True
        'Desabilita a lista para que a pessoa não possa trocar o clone
        lstClone.Enabled = False
        'Desabilita o botão de novo
        btNovo.Enabled = False
        'Move o foco para o clone
        txtClone.Focus()
    End Sub

    Private Sub txtClone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClone.TextChanged
        btSalvar.Enabled = True
    End Sub

    Private Sub txtNome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNome.TextChanged
        btSalvar.Enabled = True
    End Sub

    Private Sub txtDescricao_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescricao.TextChanged
        btSalvar.Enabled = True
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        Dim SQL As String = String.Empty
        'Se estiver no modo edição
        If Status = "Edi" Then
            SQL = "UPDATE Clones SET "
            SQL &= "Clone='" & txtClone.Text & "',"
            SQL &= "Nome='" & txtNome.Text & "',"
            SQL &= "Descricao='" & txtDescricao.Text & "'"
            SQL &= " WHERE id=" & cmbVal(lstClone)
        ElseIf Status = "Nov" Then
            'Esse primeiro null é por causa do ID
            SQL = "INSERT INTO Clones (id,Mercadoria,Clone,Nome,Descricao) VALUES (NULL,"
            SQL &= cmbVal(cmbMercadoria) & ","
            'Inserir aqui uma verificação se este clone já existe
            SQL &= txtClone.Text & ","
            SQL &= "'" & txtNome.Text & "',"
            SQL &= IIf(txtDescricao.Text = String.Empty, "NULL", "'" & txtDescricao.Text & "'")
            SQL &= ")"
        End If
        Try
            'Tenta executar a SQL
            ExecutaSQL(SQL)
            If Status = "Edi" Then
                MsgBox("Registro do clone salvo com sucesso!", MsgBoxStyle.Information, "Confirmação")
            ElseIf Status = "Nov" Then
                MsgBox("Registro do clone incluído com sucesso!", MsgBoxStyle.Information, "Confirmação")
            End If
            'Limpa os campos
            Limpa()
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o banco de dados!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub
    Private Sub Limpa()
        'Habilita e desabilita os controles
        grpClone.Enabled = False
        btSalvar.Enabled = False
        btEditar.Enabled = True
        btNovo.Enabled = True
        'Se incluiu um clone novo então acrescenta ele à lista
        If Status = "Nov" Then
            Carrega_Lista(lstClone, "Clones_num", "id", "nome", True, "Mercadoria=" & cmbVal(cmbMercadoria))
        End If
    End Sub

    Private Sub btNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovo.Click
        'Novo
        Status = "Nov"
        'Habilita certos controles
        btEditar.Enabled = False
        btSalvar.Enabled = True
        grpClone.Enabled = True
        txtClone.Text = String.Empty
        txtNome.Text = String.Empty
        txtDescricao.Text = String.Empty
        'move o foco para txtclone
        txtClone.Focus()
    End Sub
End Class