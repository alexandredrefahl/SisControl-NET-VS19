Public Class frmMercadoria

    Dim DS As DataSet

    Private Sub frmMercadoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsClones.clones' table. You can move, or remove it, as needed.


        'Preenche o combo mercadoria
        Carrega_Lista(cmbMercadoria, "Mercadoria_num", "id", "Nome", True)

        'Carrega os comboboxes dos meio de cultura
        Carrega_Lista(cmbISO, "Meio", "id", "meio", True)
        Carrega_Lista(cmbMUL, "Meio", "id", "meio", True)
        Carrega_Lista(cmbMAN, "Meio", "id", "meio", True)
        Carrega_Lista(cmbALO, "Meio", "id", "meio", True)
        Carrega_Lista(cmbENR, "Meio", "id", "meio", True)
        Carrega_Lista(cmbGER, "Meio", "id", "meio", True)

        'Desabilita a edi��o de tudo
        Habilita_Controles(False)

        'Preenche o DataSet com as informa��es do clone da mercadoria especifica
        taClones.Fill(Me.DsClones.clones, cmbVal(cmbMercadoria))

    End Sub

    Private Sub Carrega_Mercadoria()
        Dim varID As Integer = -1

        'Se existir algo selecionado
        If cmbMercadoria.SelectedIndex > -1 Then
            Dim DR As DataRow
            'Pega o ID selecionado
            varID = cmbVal(cmbMercadoria)
            DR = DLookupRow("Mercadoria", "id=" & varID)
            'Se n�o encontrou nada ent�o
            If IsNothing(DR) Then
                MsgBox("Mercadoria n�o encontrada", MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End If
            'Se sim passa adiante
            txtCientifico.Text = NaoNulo(DR.Item("Cientifico"))
            txtPopular.Text = NaoNulo(DR.Item("Popular"))
            'Agora carrega os meios de cultura
            If Not IsDBNull(DR.Item("meioISO")) Then
                Localiza_Item(cmbISO, DR.Item("MeioISO"))
            Else
                cmbISO.SelectedIndex = -1
                cmbISO.Text = ""
            End If
            If Not IsDBNull(DR.Item("meioMUL")) Then
                Localiza_Item(cmbMUL, DR.Item("MeioMUL"))
            Else
                cmbMUL.SelectedIndex = -1
                cmbMUL.Text = ""
            End If
            If Not IsDBNull(DR.Item("meioMAN")) Then
                Localiza_Item(cmbMAN, DR.Item("MeioMAN"))
            Else
                cmbMAN.SelectedIndex = -1
                cmbMAN.Text = ""
            End If
            If Not IsDBNull(DR.Item("meioALO")) Then
                Localiza_Item(cmbALO, DR.Item("MeioALO"))
            Else
                cmbALO.SelectedIndex = -1
                cmbALO.Text = ""
            End If
            If Not IsDBNull(DR.Item("meioENR")) Then
                Localiza_Item(cmbENR, DR.Item("MeioENR"))
            Else
                cmbENR.SelectedIndex = -1
                cmbENR.Text = ""
            End If
            If Not IsDBNull(DR.Item("meioGER")) Then
                Localiza_Item(cmbGER, DR.Item("MeioGER"))
            Else
                cmbGER.SelectedIndex = -1
                cmbGER.Text = ""
            End If
            'Agora carrega os clones associados a esta mercadoria

            Dim MercID As Integer
            MercID = cmbVal(cmbMercadoria)
            'Preenche o DataSet com as informa��es do clone da mercadoria especifica
            taClones.Fill(Me.DsClones.clones, MercID)

        End If
    End Sub

    Private Sub cmbMercadoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMercadoria.SelectedIndexChanged
        Carrega_Mercadoria()
    End Sub

    Private Sub btEditar_Click(sender As System.Object, e As System.EventArgs) Handles btEditar.Click
        'Verifica se j� est� no modo de edi��o ou n�o
        If btEditar.Text = "Editar" Then
            btEditar.Text = "Salvar"
            btNovo.Enabled = False
            'Habilita os campos para edi��o
            Habilita_Controles(True)
            Exit Sub
        End If

        'Caso esteja no modo de edi��o ent�o precisa salvar
        If btEditar.Text = "Salvar" Then
            Dim SQL As String = String.Empty

            'Monta a SQL baseado nos campos ativos
            SQL = "UPDATE Mercadoria SET "
            SQL &= Monta_SQL()
            SQL &= " WHERE id=" & cmbVal(cmbMercadoria)
            'Tenta fazer a atualiza��o
            Try
                'Salva as informa��es do Produto principal
                ExecutaSQL(SQL)
                'Salva as informa��es do clone

                '*
                '* DADOS DOS CLONES
                '*
                '*
                Dim MercID As Integer = cmbVal(cmbMercadoria)
                'S� precisa de uma corre��ozinha para incluir o n�mero da mercadoria na coluna oculta
                For i As Integer = 0 To DsClones.Tables(0).Rows.Count - 1
                    'Para cada linha inclui o n�mero da mercadoria
                    With DsClones.Tables(0).Rows(i)
                        .Item(1) = MercID
                    End With
                Next
                'Finaliza a edi��o de registros
                bsClones.EndEdit()
                'Faz as Altera��es
                taClones.Update(DsClones)

                'Depois que deu tudo certo
                MsgBox("Mercadoria e seus Clones atualizados com sucesso", MsgBoxStyle.Information, "Confirma��o")
                Habilita_Controles(False)
                cmbMercadoria.Focus()
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar o cadastro de mercadorias" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try




        End If
    End Sub

    Private Sub Habilita_Controles(ByVal Hab As Boolean)
        tpClones.Enabled = Hab
        tpDados.Enabled = Hab
        tpMeios.Enabled = Hab
        'Se for falso (ou seja desabilita tudo)
        If Not Hab Then         'False
            btEditar.Text = "Editar"
            btNovo.Text = "Novo"
            dgClones.AllowUserToAddRows = False
            'Habilita a sele��o de novas mercadorias
            cmbMercadoria.Enabled = True
            'Habilita os bot�es de a��o novamente
            btEditar.Enabled = True
            btNovo.Enabled = True
        Else                    'True
            'Permite o usu�rio acrescentar linhas
            dgClones.AllowUserToAddRows = True
            'N�o pode mais trocar
            cmbMercadoria.Enabled = False
        End If

    End Sub

    Private Function Monta_SQL() As String
        Dim SQL As String = String.Empty

        'Verifica os campos e monta a SQL
        SQL = "Cientifico = " & Texto_Vazio(txtCientifico.Text) & " , "
        SQL &= "Popular = " & Texto_Vazio(txtPopular.Text) & " , "
        SQL &= "MeioISO = " & cmbVal(cmbISO) & " , "
        SQL &= "MeioMUL = " & cmbVal(cmbMUL) & " , "
        SQL &= "MeioALO = " & cmbVal(cmbALO) & " , "
        SQL &= "MeioENR = " & cmbVal(cmbENR) & " , "
        SQL &= "MeioMAN = " & cmbVal(cmbMAN) & " , "
        SQL &= "MeioGER = " & cmbVal(cmbGER)

        'Retorna o texto da SQL
        Return SQL
    End Function

    Private Sub btCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btCancelar.Click
        'Se estiver no modo de edi��o, s� cancela a edi��o, caso contrario fecha o formul�rio
        If Not tpDados.Enabled Then
            Me.Close()
        Else
            Habilita_Controles(False)
            cmbMercadoria.Focus()
        End If
    End Sub

    Private Sub btNovo_Click(sender As System.Object, e As System.EventArgs) Handles btNovo.Click
        'Verifica o modo de edi��o
        If btNovo.Text = "Novo" Then
            btNovo.Text = "Incluir"
            btEditar.Enabled = False
            'Faz uma sele��o Nula para limpar o DataSet
            taClones.Fill(Me.DsClones.clones, -1)
            'Habilita edi��o de controles
            Habilita_Controles(True)
            tpClones.Enabled = False            'Para fazer a inclus�o do clone s� depois da mercadoria
            'Limpa todos os campos
            Limpa_Campos(Me)
            'Seleciona o tab de Dados
            tcInformacoes.SelectedTab = tpDados
            txtCientifico.Focus()
            Exit Sub
        End If

        'Se estiver no modo de inclus�o ent�o
        If btNovo.Text = "Incluir" Then
            Dim SQL As String
            'Monta a SQL da inclus�o da mercadoria
            SQL = "INSERT INTO mercadoria SET "
            SQL &= Monta_SQL()

            Try
                ExecutaSQL(SQL)
                'Preenche o combo mercadoria
                Carrega_Lista(cmbMercadoria, "Mercadoria_num", "id", "Nome", True)
                Limpa_Campos(Me)
                Habilita_Controles(False)
                cmbMercadoria.Focus()
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir nova mercadoria" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub
End Class