

Public Class frmWEBProdutos

    Private Sub frmWEBProdutos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Troca o cursor para modo de espera
        Me.Cursor = Cursors.WaitCursor
        'Avisa o usuario
        pnlMensagem.Text = "Conectando ao servidor para obter produtos cadastrados..."
        'Carrega a lista de produtos (o True do final é para indicar que vai ser na internet)
        Carrega_Lista(lstProdutos, "produtos", "id", "cientifico", True, , True)
        pnlMensagem.Text = " "
        'Troca o cursor para modo de espera
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnviar.Click
        Dim ftpCompleto As String, Arquivo As String, pos As Integer

        'Se não esta vazio ou tem um nome de arquivo válido
        If Len(txtArquivo.Text) > 1 Then
            'Troca o cursor para modo de espera
            Me.Cursor = Cursors.WaitCursor
            pnlMensagem.Text = "Enviando arquivo via FTP para o site..."
            pos = txtArquivo.Text.LastIndexOf("\")

            'Separa somente o nome do arquivo
            Arquivo = txtArquivo.Text.Substring(pos + 1, Len(txtArquivo.Text) - pos - 1)
            ftpCompleto = "ftp://ftp.clona-gen.com.br/www/imagens/produtos/" & Arquivo

            Try
                UpLoadArquivo("ftp://ftp.clona-gen.com.br/www/imagens/produtos/" & Arquivo, txtArquivo.Text, "clonagen", "16240423")
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & ex.ToString)
                GoTo fim
            End Try
        End If

Fim:
        statusBAR.Items(0).Text = ""
        'Troca o cursor para modo de espera
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Mostra a caixa de abertura de arquivo
        dlgArquivo.ShowDialog()
        txtArquivo.Text = dlgArquivo.FileName
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub lstProdutos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProdutos.SelectedIndexChanged
        Dim ID As Integer, SQL As String
        Dim Tabela As DataTable, oldCursor As Cursor

        'Se tem algo selecionado
        If lstProdutos.SelectedIndex >= 0 Then
            'Pega o id da mercadoria
            ID = cmbVal(lstProdutos)
        End If
        'Mensagem na barra de status
        pnlMensagem.Text = "Conectando ao servidor para obter dados..."
        oldCursor = Me.Cursor
        'Cursor de espera
        Me.Cursor = Cursors.WaitCursor

        'Define a SQL
        SQL = "SELECT * FROM produtos WHERE id=" & ID
        'Tenta obter os dados no servidor
        Try
            'False = Local e True=Remoto
            Tabela = SQLQuery(SQL, True)
        Catch ex As Exception
            MsgBox("Erro ao obter os dados no servidor:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro!")
            GoTo fim
        End Try
        'Se retorna algum registro
        If Tabela.Rows.Count > 0 Then
            'Pega a primeira (e única) linha
            With Tabela.Rows(0)
                txtCientifico.Text = .Item("Cientifico")
                txtPopular.Text = .Item("Popular")
                txtDescricao.Text = .Item("Descricao")
                txtArquivo.Text = .Item("Foto")
                'Função que ativa o ítem correspondente em uma lista
                cmbCategoria.SelectedIndex = Val(.Item("Categoria")) - 1
                '1-Ornamental / 2-Frutifera / 3-Florestal
            End With
        End If
        'Desativa o botão enviar cadastro
        btEnviar.Enabled = False
fim:
        pnlMensagem.Text = " "
        'Restaura o cursor antigo
        Me.Cursor = oldCursor
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        Dim a As Integer, SQL As String, oldCursor As Cursor
        'salva o cursor
        oldCursor = Me.Cursor
        'Pede confirmação
        a = MsgBox("Deseja salvar os dados atuais no banco de dados na Internet?", MsgBoxStyle.YesNo, "Confirmação")
        'Se sim
        If a = vbYes Then
            'salva o cursor
            oldCursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            pnlMensagem.Text = "Atualizando informações no banco de dados remoto..."

            SQL = "UPDATE produtos SET cientifico='" & txtCientifico.Text & "',popular='" & txtPopular.Text & _
                "',descricao='" & txtDescricao.Text & "',categoria=" & (cmbCategoria.SelectedIndex + 1) & _
                ",foto='" & txtArquivo.Text & "' WHERE id=" & cmbVal(lstProdutos)
            'Tenta executar
            Try
                'True é para servidor remoto, false é local
                ExecutaSQL(SQL, True)
            Catch ex As Exception
                MsgBox("Erro ao atualizar o banco de dados remoto:" & vbCrLf & ex.Message & vbCrLf & ex.ToString)
                GoTo FIM
            End Try
            MsgBox("Dados atualizados com sucesso!", MsgBoxStyle.OkOnly, "Sucesso")
        End If
FIM:
        'Limpa mensagem
        pnlMensagem.Text = " "
        'Retorna cursor
        Me.Cursor = oldCursor
    End Sub
End Class