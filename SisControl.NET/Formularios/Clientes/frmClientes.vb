Imports System.Globalization

Public Class frmClientes
    Dim IDCliente As Integer = 0, IDModo As Integer = 0
    Private SQL As String

    Sub New(Optional ByVal ClienteID As Integer = 0, Optional ByVal Modo As Integer = 0)
        'Modo=0 -> Editar, Modo=1 -> Visualizar

        ' This call is required by the designer.
        InitializeComponent()

        'Se for informado carrega a ficha do cliente
        If ClienteID <> 0 Then
            IDCliente = ClienteID
            If Modo <> 0 Then
                IDModo = 1
            Else
                IDModo = 0
            End If
        End If
    End Sub

    Private Sub frmClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            EnterAsTab(sender, e)
        End If
    End Sub

    Private Sub frmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Preenche o Combo com o nome dos clientes
        Carrega_Lista(cmbCliente, "Clientes", "id", "Nome", True)
        'Se foi informado um cliente
        If IDCliente <> 0 Then
            Carrega_Cliente()
        End If
    End Sub

    Private Sub Carrega_Cliente()
        Dim SQL As String = String.Empty
        'Clientes
        SQL = "SELECT * FROM Clientes WHERE id=" & IDCliente

        Try
            Dim DT As DataTable
            DT = SQLQuery(SQL)
            'Se encontrou um resultado
            If DT.Rows.Count > 0 Then
                With DT.Rows(0)
                    txtCodigo.Text = .Item("id")
                    txtNome.Text = NaoNulo(.Item("Nome"))
                    txtEndereco.Text = NaoNulo(.Item("Endereco"))
                    txtNum.Text = NaoNulo(.Item("Num"))
                    txtBairro.Text = NaoNulo(.Item("Bairro"))
                    txtCEP.Text = NaoNulo(.Item("CEP"))
                    txtCidade.Text = NaoNulo(.Item("Cidade"))
                    txtCodMun.Text = NaoNulo(.Item("CodMun"))
                    txtEstado.Text = NaoNulo(.Item("Estado"))
                    txtPais.Text = NaoNulo(.Item("Pais"))
                    txtCodPais.Text = NaoNulo(.Item("codPais"))
                    If Not IsDBNull(.Item("PFPJ")) Then
                        IIf(.Item("PFPJ") = "F", rdPF.Checked = True, rdPJ.Checked = True)
                        IIf(.Item("PFPJ") = "F", Label9.Text = "CPF", "CNPJ")
                    End If
                    txtCNPJ.Text = NaoNulo(.Item("cpf_cnpj"))
                    txtIE.Text = NaoNulo(.Item("RG_IE"))
                    txtFone.Text = NaoNulo(.Item("Fone"))
                    txtFax.Text = NaoNulo(.Item("Fax"))
                    txtCelular.Text = NaoNulo(.Item("Celular"))
                    txtEmail.Text = NaoNulo(.Item("email"))
                    txtSite.Text = NaoNulo(.Item("site"))
                    txtOBS.Text = NaoNulo(.Item("Observacoes"))
                    txtContrato.Text = NaoNulo(.Item("Contrato"))
                    txtProdutos.Text = NaoNulo(.Item("Produtos"))
                    txtContato.Text = NaoNulo(.Item("Contato"))
                End With
                Button4.Text = "Salvar"
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar dados do cliente." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If txtCodigo.Text <> "" Then
            Dim Form As New auxPedidos(txtCodigo.Text)
            'Define que é mdichild
            Form.MdiParent = frmMenu
            'Mostra formulário
            Form.Show()
        End If
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        'Atualiza clientes
        IDCliente = cmbVal(cmbCliente)
        Carrega_Cliente()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Incluir" Then
            Inclui_Cliente()
        ElseIf Button4.Text = "Salvar" Then
            Salva_Cliente()
        End If
    End Sub

    Private Sub Inclui_Cliente()
        Dim SQL As String

        SQL = "INSERT INTO Clientes SET "

        'Rotina que monta a SQL dos campos
        SQL &= Monta_SQL()

        Try
            ExecutaSQL(SQL)
            MsgBox("Inclusão do cliente realizada com sucesso!", MsgBoxStyle.Information, "Confirmação")
            Limpa_Campos(Me)
            txtNome.Focus()
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir a ficha do cliente." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Salva_Cliente()
        Dim SQL As String

        SQL = "UPDATE Clientes SET "

        'Rotina que monta a SQL dos campos
        SQL &= Monta_SQL()

        SQL &= " WHERE id=" & txtCodigo.Text

        Try
            ExecutaSQL(SQL)
            MsgBox("Alteração do cliente realizada com sucesso!", MsgBoxStyle.Information, "Confirmação")
        Catch ex As Exception
            MsgBox("Erro ao tentar salvar a ficha do cliente." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Function Monta_SQL()
        Dim SQL As String

        'Monta a SQL com os nomes dos campos (usado na rotina de INCLUSÃO/ALTERAÇÃO)
        SQL = "Nome='" & txtNome.Text & "',"
        SQL &= "Endereco=" & Texto_Vazio(txtEndereco.Text) & ","
        SQL &= "Num=" & Texto_Vazio(txtNum.Text) & ","
        SQL &= "Bairro=" & Texto_Vazio(txtBairro.Text) & ","
        SQL &= "Cidade=" & Texto_Vazio(txtCidade.Text) & ","
        SQL &= "CodMun=" & Texto_Vazio(txtCodMun.Text) & ","
        SQL &= "Estado=" & Texto_Vazio(txtEstado.Text) & ","
        SQL &= "Pais=" & Texto_Vazio(txtPais.Text) & ","
        SQL &= "CodPais=" & Texto_Vazio(txtCodPais.Text) & ","
        SQL &= "CEP=" & Texto_Vazio(txtCEP.Text) & ","
        SQL &= "PFPJ='" & IIf(rdPF.Checked, "F", "J") & "',"
        SQL &= "CPF_CNPJ=" & Texto_Vazio(txtCNPJ.Text) & ","
        SQL &= "RG_IE=" & Texto_Vazio(txtIE.Text) & ","
        SQL &= "Fone=" & Texto_Vazio(txtFone.Text) & ","
        SQL &= "Fax=" & Texto_Vazio(txtFax.Text) & ","
        SQL &= "Celular=" & Texto_Vazio(txtCelular.Text) & ","
        SQL &= "email=" & Texto_Vazio(txtEmail.Text) & ","
        SQL &= "Site=" & Texto_Vazio(txtSite.Text) & ","
        SQL &= "Observacoes=" & Texto_Vazio(txtOBS.Text) & ","
        SQL &= "Contrato=" & Texto_Vazio(txtContrato.Text) & ","
        SQL &= "Produtos=" & Texto_Vazio(txtProdutos.Text) & ","
        SQL &= "Contato=" & Texto_Vazio(txtContato.Text)

        Return SQL
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Limpa_Campos(Me)
        txtPais.Text = "Brasil"
        txtCodPais.Text = "1058"
        txtNome.Focus()
        Button4.Text = "Incluir"
    End Sub

    Private Sub rdPF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPF.CheckedChanged
        If rdPF.Checked Then
            Label9.Text = "CPF:"
        Else
            Label9.Text = "CNPJ:"
        End If
    End Sub

    Private Sub txtEstado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEstado.LostFocus
        'Preenche o combobox com o nome dos municipios 
        If txtEstado.Text.Length = 2 Then
            Carrega_Lista(txtCidade, "Rais", "Cod", "Municipio", True, "Estado='" & txtEstado.Text & "'")
        End If
    End Sub

    Private Sub txtCidade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCidade.LostFocus
        'Preenche o codigo do municipio
        If txtCidade.SelectedIndex <> -1 Then
            txtCodMun.Text = cmbVal(txtCidade)
        End If
    End Sub

    Private Sub btBuscaCEP_Click(sender As System.Object, e As System.EventArgs) Handles btBuscaCEP.Click
        'Muda o cursor
        Me.Cursor = Cursors.WaitCursor
        'Define a estrutura de retorno do endereço
        Dim Address As New EnderecoWEB
        'Busca o endereço pelo CEP
        Busca_Endereco(txtCEP.Text, Address)
        'Preenche os campos com o retorno da função
        txtEndereco.Text = Address.Tipo_Logradouro & " " & Address.Logradouro
        txtBairro.Text = Address.Bairro
        txtCidade.Text = Address.Cidade
        txtEstado.Text = Address.Uf
        'Retorna o cursos para o modo tradicional
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim auxForm As New frmAux_Clientes_WEB, varID As Integer
        'Abre a janela auxiliar para escolher o cliente Cadastrado na WEB
        auxForm.ShowDialog()
        'Pega o ID do cliente cadastrado
        varID = auxForm.ClienteID
        'Se vier algum registro que não for zero
        If varID <> 0 Then
            Dim Cliente As New Cliente_WEB
            Me.Cursor = Cursors.WaitCursor
            ' Procura o cliente pelo ID recebido
            Cliente.Carrega_Dados_Cliente(varID)

            'Procura os dados no banco de dados remoto
            'DT = recupera_dados_cliente_web(varID)
            'se não achou, ou não concluiu a operação
            'If IsNothing(DT) Then
            'Exit Sub
            'End If
            'Caso tenha dado certo, processa o retorno para pegar os dados do cliente
            'Processa_dados_recebidos(DT)
            Preenche_Campos_Dados_Cliente(Cliente)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Preenche_Campos_Dados_Cliente(ByRef Cli As Cliente_WEB)
        With Cli
            txtNome.Text = .Nome & " " & .Sobrenome
            txtEndereco.Text = .Endereco
            txtBairro.Text = .Bairro
            txtCEP.Text = .CEP
            txtEstado.Text = .Estado
            txtCidade.Text = .Cidade
            txtCNPJ.Text = .CPF_CNPJ
            'Verifica se é pessoa física ou jurídica
            IIf(txtCNPJ.Text.Length > 9, rdPJ.Checked = True, rdPF.Checked = True)
            txtIE.Text = .RG_IE
            txtFone.Text = .Telefone
            txtFax.Text = .Fax
            txtEmail.Text = .Email
            txtContato.Text = .Nome
        End With
    End Sub

    Private Function recupera_dados_cliente_web(ByVal id) As DataTable
        Dim DT As DataTable, SQL As String
        'Monta a SQL de recuperação
        SQL = "SELECT name,value FROM vtex_facileforms_subrecords WHERE Record=" & id
        'Mostra na tela de Debug
        Console.WriteLine("SQL Cliente WEB: " & SQL)
        'Tenta recuperar a linha na forma de DataTable
        If Conectado Then
            Try
                'Tenta fazer a conexao com o banco de dados remoto
                Me.Cursor = Cursors.WaitCursor
                DT = SQLQuery(SQL, True)
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                MsgBox("Erro ao tentar se comunicar com o banco de dados remoto." & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Me.Cursor = Cursors.Arrow
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
        Return DT
    End Function

    Private Sub Processa_dados_recebidos(ByRef Tabela As DataTable)
        Dim DR As DataRow
        'Para cada linha de dados em Tabela (DT) processar
        For Each DR In Tabela.Rows
            'Pega o nome do campo e verifica onde vai colocar
            Select Case DR.Item("name")
                Case "txtNome"
                    'Essa função faz com que a primeira letra de cada palavra seja Maiuscula e o resto minuscula
                    txtNome.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtEndereco"
                    txtEndereco.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtNumero"
                    txtNum.Text = NaoNulo(DR.Item("value"))
                Case "txtBairro"
                    txtBairro.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtCEP"
                    txtCEP.Text = NaoNulo(DR.Item("value"))
                Case "txtCidade"
                    txtCidade.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtEstado"
                    txtEstado.Text = NaoNulo(DR.Item("value")).ToUpper
                Case "txtPais"
                    txtPais.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtCPFCNPJ"
                    txtCNPJ.Text = NaoNulo(DR.Item("value"))
                Case "txtIE"
                    txtIE.Text = NaoNulo(DR.Item("value"))
                Case "txtPessoa"
                    txtContato.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NaoNulo(DR.Item("value")))
                Case "txtFone"
                    txtFone.Text = NaoNulo(DR.Item("value"))
                Case "txtFax"
                    txtFax.Text = NaoNulo(DR.Item("value"))
                Case "txtCelular"
                    txtCelular.Text = NaoNulo(DR.Item("value"))
                Case "txtEmail"
                    txtEmail.Text = NaoNulo(DR.Item("value")).ToLower
            End Select
        Next
    End Sub

End Class