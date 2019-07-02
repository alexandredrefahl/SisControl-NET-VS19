Public Class frmTransportadoras

    Private Sub frmTransportadoras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'quando carregar
        Carrega_Lista(cmbTransportadora, "transportadores", "id", "razao")
    End Sub

    Private Sub btAction_Click(sender As System.Object, e As System.EventArgs) Handles btAction.Click
        Dim SQL As String
        'Verifica se é inclusão ou alteração
        If btAction.Text = "Incluir" Then
            SQL = "INSERT INTO transportadores SET "
            SQL &= Monta_SQL()
            Try
                ExecutaSQL(SQL)
                MsgBox("Transportadora incluída com sucesso!", MsgBoxStyle.Information, "Confirmação")
                LimpaCampos()
                btNovo.Enabled = False
                Carrega_Lista(cmbTransportadora, "transportadores", "id", "razao")
                cmbTransportadora.Focus()
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir transportadora" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        ElseIf btAction.Text = "Salvar" Then
            SQL = "UPDATE transportadores SET "
            SQL &= Monta_SQL()
            SQL &= " WHERE id=" & cmbVal(cmbTransportadora)
            Try
                ExecutaSQL(SQL)
                MsgBox("Dados salvos com sucesso!", MsgBoxStyle.Information, "Confirmação")
                btNovo.Enabled = True
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar dados da transportadora" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String = ""

        SQL &= "Razao = " & Texto_Vazio(txtRazao.Text) & " ,"
        SQL &= "Endereco = " & Texto_Vazio(txtEndereco.Text) & " ,"
        SQL &= "Num = " & Texto_Vazio(txtNum.Text) & " ,"
        SQL &= "Bairro = " & Texto_Vazio(txtBairro.Text) & " ,"
        SQL &= "Cidade = " & Texto_Vazio(txtCidade.Text) & " ,"
        SQL &= "Estado = " & Texto_Vazio(txtEstado.Text) & " ,"
        SQL &= "CEP = " & Texto_Vazio(txtCEP.Text) & " ,"
        SQL &= "Fone = " & Texto_Vazio(txtFone.Text) & " ,"
        SQL &= "Fax = " & Texto_Vazio(txtFax.Text) & " ,"
        SQL &= "email = " & Texto_Vazio(txtEmail.Text) & " ,"
        SQL &= "Contato = " & Texto_Vazio(txtContato.Text) & " ,"
        SQL &= "CNPJ_CPF = " & Texto_Vazio(txtCNPJ_CPF.Text) & " ,"
        SQL &= "Inscricao = " & Texto_Vazio(txtInscricao.Text)
        'Retorna a SQL montada
        Return SQL

    End Function

    Private Sub cmbTransportadora_Leave(sender As System.Object, e As System.EventArgs) Handles cmbTransportadora.Leave
        Dim DT As DataTable, SQL As String
        'Se tiver algo selecionado
        If cmbTransportadora.SelectedIndex <> -1 Then
            'começa a carregar os dados
            SQL = "SELECT * FROM Transportadores WHERE id=" & cmbVal(cmbTransportadora)
            'Carreega os dados da transportadora
            DT = SQLQuery(SQL)
            'Se tivefr algum resultado
            If DT.Rows.Count > 0 Then
                'Carrega os dados da transportadora
                With DT.Rows(0)
                    txtRazao.Text = NaoNulo(.Item("Razao"))
                    txtEndereco.Text = NaoNulo(.Item("Endereco"))
                    txtNum.Text = NaoNulo(.Item("Num"))
                    txtBairro.Text = NaoNulo(.Item("Bairro"))
                    txtCidade.Text = NaoNulo(.Item("Cidade"))
                    txtEstado.Text = NaoNulo(.Item("Estado"))
                    txtCEP.Text = NaoNulo(.Item("cep"))
                    txtFone.Text = NaoNulo(.Item("Fone"))
                    txtFax.Text = NaoNulo(.Item("Fax"))
                    txtEmail.Text = NaoNulo(.Item("Email"))
                    txtContato.Text = NaoNulo(.Item("Contato"))
                    txtCNPJ_CPF.Text = NaoNulo(.Item("CNPJ_CPF"))
                    txtInscricao.Text = NaoNulo(.Item("Inscricao"))
                    btNovo.Enabled = True
                End With
                btAction.Text = "Salvar"
            End If
            DT = Nothing
        End If
    End Sub

    Private Sub btFechar_Click(sender As System.Object, e As System.EventArgs) Handles btFechar.Click
        'Fecha o formulário
        Me.Close()
    End Sub

    Private Sub btNovo_Click(sender As System.Object, e As System.EventArgs) Handles btNovo.Click
        LimpaCampos()
        btNovo.Enabled = False
        btAction.Text = "Incluir"
        txtRazao.Focus()
    End Sub

    Private Sub LimpaCampos()
        Limpa_Campos(Me)
        For Each c As Control In grpdados.Controls
            'Se for textbox, combobox, ou maskeditbox então limp
            If c.GetType.ToString = "System.Windows.Forms.MaskedTextBox" Or c.GetType.ToString = "System.Windows.Forms.TextBox" Or c.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                'Limpa o texto
                c.Text = String.Empty
            End If
        Next
        cmbTransportadora.SelectedIndex = -1
    End Sub

End Class