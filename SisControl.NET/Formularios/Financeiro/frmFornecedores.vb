Public Class frmFornecedores
    Private Sub frmFornecedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista de fornecedores no combobox
        Carrega_Lista(cmbFornecedor, "Fornecedores", "id", "Razao", True)
        Button2.Enabled = False
        '*
        '* No Campo TAG escreve-se o nome do campo correspondente no banco de dados
        '* para facilitar as rotinas de inclusão e alteração
        '*

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Function Valida_Campos() As Boolean
        Dim retorno As Boolean = True
        Dim Mensagem As String = String.Empty

        Mensagem = "O fornecedor não pode ser incluído porque:"

        'Verifica o fornecedor
        If txtRazao.Text = String.Empty Then
            Mensagem &= vbCrLf & "  - O nome do fornecedor não pode ser nulo"
            retorno = False
        End If

        'Verifica o telefone
        If txtFone.Text = String.Empty Then
            Mensagem &= vbCrLf & "  - O telefone não pode ser nulo"
            retorno = False
        End If

        'Se o fone não tem ( ) ou - 
        If txtFone.Text.IndexOf("(") < 0 Or txtFone.Text.IndexOf(")") < 0 Or txtFone.Text.IndexOf("-") < 0 Then
            Mensagem &= vbCrLf & "  - O fone deve ser digitado no formato (99) 9999-9999"
            retorno = False
        End If

        If Not retorno Then
            MsgBox(Mensagem, MsgBoxStyle.Critical, "Erro")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        If Not Valida_Campos() Then
            Exit Sub
        End If
        If Button1.Text = "Novo" Then
            'Limpa os campos e prepara a inclusão
            Limpa_Campos(Me)
            Button1.Text = "Incluir"
        ElseIf Button1.Text = "Incluir" Then
            'quando passa por aqui já dentro da rotina de inclusão
            SQL = Gera_SQL_Local("INSERT")
            Console.WriteLine(SQL)
            'Tenta fazer a inclusão
            Try
                ExecutaSQL(SQL)
                MsgBox("Dados do fornecedor incluidos com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                'Limpa os campos do formulário
                Limpa_Campos(Me)
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir os dados do Fornecedor" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            'Carrega a lista de fornecedores no combobox
            Carrega_Lista(cmbFornecedor, "Fornecedores", "id", "Razao", True)
            Button1.Text = "Incluir"
        End If
    End Sub

    Private Function Gera_SQL_Local(ByVal Tipo As String)
        Dim SQL As String = ""
        'Inclusão
        If Tipo = "INSERT" Or Tipo = "UPDATE" Then
            If Tipo = "INSERT" Then
                SQL = "INSERT INTO Fornecedores SET "
            ElseIf Tipo = "UPDATE" Then
                SQL = "UPDATE Fornecedores SET "
            End If
            SQL &= "Razao='" & txtRazao.Text & "',"
            SQL &= "Contato=" & Texto_Vazio(txtContato.Text) & ","
            SQL &= "Endereco=" & Texto_Vazio(txtEndereco.Text) & ","
            SQL &= "Cidade=" & Texto_Vazio(txtCidade.Text) & ","
            SQL &= "Estado=" & Texto_Vazio(txtEstado.Text) & ","
            SQL &= "CEP=" & Texto_Vazio(txtCEP.Text) & ","
            SQL &= "Telefone='" & txtFone.Text & "',"
            SQL &= "Fax=" & Texto_Vazio(txtFax.Text) & ","
            SQL &= "CNPJ_CPF=" & Texto_Vazio(txtCNPJ_CPF.Text) & ","
            SQL &= "Inscricao_RG=" & Texto_Vazio(txtInscricao.Text) & ","
            SQL &= "email=" & Texto_Vazio(txtEmail.Text) & ","
            SQL &= "site=" & Texto_Vazio(txtSite.Text) & ","
            SQL &= "Banco=" & Texto_Vazio(txtBanco.Text) & ","
            SQL &= "Agencia=" & Texto_Vazio(txtAgencia.Text) & ","
            SQL &= "Conta=" & Texto_Vazio(txtConta.Text) & ","
            SQL &= "Produtos=" & Texto_Vazio(txtProdutos.Text)
            'Devolve a SQL montada
            Return SQL
        End If
        'se não for nada
        Return String.Empty
    End Function

    Private Sub EstadoTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstado.LostFocus
        'Preenche o combobox com o nome dos municipios 
        If txtEstado.Text.Length = 2 Then
            Carrega_Lista(txtCidade, "Rais", "Cod", "Municipio", True, "Estado='" & txtEstado.Text & "'")
        End If
    End Sub

    Private Sub txtCidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCidade.SelectedIndexChanged
        txtCodCidade.Text = cmbVal(txtCidade)
    End Sub

    Private Sub cmbFornecedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFornecedor.LostFocus
        'Se existir algo selecionado
        If cmbFornecedor.SelectedIndex <> -1 Then
            Dim DT As DataTable
            'Carrega os dados do fornecedor
            DT = SQLQuery("SELECT * FROM Fornecedores WHERE id=" & cmbVal(cmbFornecedor))
            Try
                'Com os dados preenche os campos
                With DT.Rows(0)
                    txtID.Text = NaoNulo(.Item("id"))
                    txtRazao.Text = NaoNulo(.Item("Razao"))
                    txtContato.Text = NaoNulo(.Item("Contato"))
                    txtEndereco.Text = NaoNulo(.Item("Endereco"))
                    txtCidade.Text = NaoNulo(.Item("Cidade"))
                    txtEstado.Text = NaoNulo(.Item("Estado"))
                    txtCEP.Text = NaoNulo(.Item("CEP"))
                    txtFone.Text = NaoNulo(.Item("Telefone"))
                    txtFax.Text = NaoNulo(.Item("Fax"))
                    txtCNPJ_CPF.Text = NaoNulo(.Item("CNPJ_CPF"))
                    txtInscricao.Text = NaoNulo(.Item("Inscricao_RG"))
                    txtEmail.Text = NaoNulo(.Item("email"))
                    txtSite.Text = NaoNulo(.Item("Site"))
                    txtBanco.Text = NaoNulo(.Item("Banco"))
                    txtAgencia.Text = NaoNulo(.Item("Agencia"))
                    txtConta.Text = NaoNulo(.Item("Conta"))
                    txtProdutos.Text = NaoNulo(.Item("Produtos"))
                End With
                Button1.Text = "Novo"
                Button2.Enabled = True
                Button2.Text = "Salvar"
            Catch ex As Exception
                MsgBox("Erro ao recuperar os dados do fornecedor!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            DT = Nothing
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Se o botão estiver habilitado como salvar
        Dim SQL As String
        If Button2.Text = "Salvar" Then
            SQL = Gera_SQL_Local("UPDATE")
            SQL &= " WHERE id=" & txtID.Text
            Try
                ExecutaSQL(SQL)
                MsgBox("Dados atualizados com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                Limpa_Campos(Me)
                Button2.Text = "Editar"
                Button2.Enabled = False
                Button1.Text = "Incluir"
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar os dados do fornecedor!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub
End Class