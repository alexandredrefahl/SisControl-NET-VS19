Public Class frmContatos

    Private Sub frmContatos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Pega os dados no Bando de Dados
        Atualiza_DataGrid()
        'desabilita a edição de registros
        tbDados.TabPages(0).Enabled = False
        tbDados.TabPages(1).Enabled = False
        'Seleciona a página de informações
        tbDados.SelectedTab = tabDados
    End Sub

    Private Sub Atualiza_DataGrid()
        'Carrega os contatos já existentes
        Dim DT As DataTable, SQL As String

        dgContatos.Enabled = True

        'Monta a SQL
        SQL = "SELECT id,Data,Nome,Assunto,Fone FROM Contatos"
        'procura a SQL
        DT = SQLQuery(SQL)
        'Se encontrou alguma coisa
        If DT.Rows.Count > 0 Then
            'Carrega os contatos
            dgContatos.DataSource = DT
            'Formata o datagrid
            Dim Cabecalhos() As String = {"ID", "Data", "Nome", "Assunto", "Fone"}
            Dim Visiveis() As Integer = {0, 1, 1, 1, 1}
            Dim Tamanhos() As Integer = {0, 80, 180, 215, 80}
            Formata_Datagrid(dgContatos, Cabecalhos, Tamanhos, Visiveis)
        Else
            MsgBox("Não há contatos registrados")
            Exit Sub
        End If
    End Sub

    Private Sub dgContatos_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgContatos.SelectionChanged
        Carrega_Contato()
    End Sub

    Private Sub Carrega_Contato()
        Dim SQL As String, DT1 As DataTable, ID As Integer

        'Se não houver linha selecionada sai da SUB
        If dgContatos.SelectedRows.Count <= 0 Then
            Exit Sub
        End If

        'Caso contrário continua
        'Verificando qual a linha selecionada para que possa recuperar os dados
        ID = dgContatos.SelectedRows(0).Cells("id").Value

        SQL = "SELECT * FROM Contatos WHERE id=" & ID
        DT1 = SQLQuery(SQL)
        'Preenche os campos
        If DT1.Rows.Count > 0 Then
            With DT1.Rows(0)
                txtAssunto.Text = .Item("Assunto")
                txtData.Text = .Item("Data")
                txtEmail.Text = NaoNulo(.Item("email"))
                txtEntidade.Text = NaoNulo(.Item("entidade"))
                txtFax.Text = NaoNulo(.Item("Fax"))
                txtFone.Text = NaoNulo(.Item("Fone"))
                txtNome.Text = NaoNulo(.Item("Nome"))
                txtSite.Text = NaoNulo(.Item("Site"))
                txtOBS.Text = NaoNulo(.Item("Observacoes"))
                txtProdutos.Text = NaoNulo(.Item("Produtos"))
            End With
        End If
        'Esvazia memória
        DT1 = Nothing
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'Verifica se está no modo de inclusão ou edição
        If Button1.Text = "Incluir" Or Button2.Text = "Salvar" Then
            Button1.Text = "Novo"
            Button1.Enabled = True
            Button2.Text = "Editar"
            Button2.Enabled = True
            'Seleciona a primeira TAB
            tbDados.SelectedTab = tabDados
            tbDados.TabPages(0).Enabled = False
            tbDados.TabPages(1).Enabled = False
            Atualiza_DataGrid()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Novo_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If Button1.Text = "Novo" Then
            'Ativa a tabela de dados
            tbDados.TabPages(0).Enabled = True
            tbDados.TabPages(1).Enabled = True
            dgContatos.Enabled = False

            'limpa todos os campos
            Limpa_Campos(Me)
            Button2.Enabled = False
            Button1.Text = "Incluir"
            txtAssunto.Focus()
            Exit Sub
        End If

        If Button1.Text = "Incluir" Then
            Dim SQL As String = String.Empty

            SQL = "INSERT INTO Contatos SET "
            SQL &= Monta_SQL()

            'Depois de tudo pronto tenta salvar no banco de dados
            Try
                ExecutaSQL(SQL)
                MsgBox("Registro de contato incluído com sucesso!", MsgBoxStyle.Information, "Confirmação")
                tbDados.TabPages(0).Enabled = False
                tbDados.TabPages(1).Enabled = False
                Button2.Enabled = True
                Button1.Text = "Novo"
                'Renova as informações no DataGrid
                Atualiza_DataGrid()
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir o registro" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                tbDados.SelectedTab = tabDados
                tbDados.TabPages(0).Enabled = False
                tbDados.TabPages(1).Enabled = False
                dgContatos.Enabled = True
                Button2.Enabled = True
                Button1.Text = "Novo"
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Editar_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        'Se existir algo selecionado então e o botão estiver no modo de edição
        If dgContatos.SelectedRows.Count > 0 And Button2.Text = "Editar" Then
            'Habilita os campos, desabilita o botão de NOVO e Troca o texto para SALVAR
            dgContatos.Enabled = False
            tbDados.TabPages(0).Enabled = True
            tbDados.TabPages(1).Enabled = True
            Button1.Enabled = False
            Button2.Text = "Salvar"
            Exit Sub
        End If

        'Se o botão estiver no modo de Edição
        If Button2.Text = "Salvar" Then
            Dim SQL As String = String.Empty, varID As Integer

            'Pega o ID na primeira coluna da linha selecionada
            varID = dgContatos.SelectedRows(0).Cells(0).Value

            'Monta a SQL de Atualização
            SQL = "UPDATE Contatos SET "
            SQL &= Monta_SQL()
            SQL &= " WHERE id=" & varID

            'Depois de tudo pronto tenta salvar no banco de dados
            Try
                ExecutaSQL(SQL)
                MsgBox("Registro de contato salvo com sucesso!", MsgBoxStyle.Information, "Confirmação")
                tbDados.TabPages(0).Enabled = False
                tbDados.TabPages(1).Enabled = False
                Button1.Enabled = True
                Button2.Text = "Editar"
                'Renova as informações no DataGrid
                Atualiza_DataGrid()

            Catch ex As Exception
                MsgBox("Erro ao tentar salvar o registro" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                tbDados.TabPages(0).Enabled = False
                tbDados.TabPages(1).Enabled = False
                Button1.Enabled = True
                Button2.Text = "Editar"
                dgContatos.Enabled = True
                Exit Sub
            End Try
            Exit Sub
        End If

    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String = String.Empty

        'Monta a SQL conforme os campos
        SQL &= "Nome = " & Texto_Vazio(txtNome.Text) & " , "
        SQL &= "Entidade = " & Texto_Vazio(txtEntidade.Text) & " , "
        SQL &= "Fone = " & Texto_Vazio(txtFone.Text) & " , "
        SQL &= "Fax = " & Texto_Vazio(txtFax.Text) & " , "
        SQL &= "Celular = " & Texto_Vazio(txtCelular.Text) & " , "
        SQL &= "email = " & Texto_Vazio(txtEmail.Text) & " , "
        SQL &= "site = " & Texto_Vazio(txtSite.Text) & " , "
        SQL &= "Observacoes = " & Texto_Vazio(txtOBS.Text) & " , "
        SQL &= "Produtos = " & Texto_Vazio(txtProdutos.Text) & " , "
        SQL &= "Assunto = " & Texto_Vazio(txtAssunto.Text) & " , "
        SQL &= "DATA = '" & txtData.Value.ToString("yyyy-MM-dd") & "'"

        'Retorna a SQL montada
        Return SQL
    End Function
End Class