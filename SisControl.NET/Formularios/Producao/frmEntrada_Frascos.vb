Public Class frmEntrada_Frascos


    Private Sub txtCodigo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub txtCodigo_Leave(sender As System.Object, e As System.EventArgs) Handles txtCodigo.Leave
        Dim Lote As Integer = -1, Mercadoria As Integer = -1, Clone As Integer = -1, Frasco As Integer = -1, LoteID As Integer = -1
        'Verifica se o campo não é vazio
        If txtCodigo.Text = String.Empty Then
            Exit Sub
        End If

        If txtCodigo.Text.Length < 13 Then
            MsgBox("Erro no código de barras", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
            txtCodigo.Text = ""
            txtCodigo.Focus()
            Exit Sub
        End If

        'Se não é vazio vai adiante e se o código tem 13 posicoes 000 000 0000 000
        'Medida para compensar um zero a mais que a etiquetadora poe no código de barras
        Try
            If txtCodigo.Text.Length = 14 Then
                'Tenta separar as partes do código
                Mercadoria = txtCodigo.Text.Substring(1, 3)
                Lote = txtCodigo.Text.Substring(4, 3)
                Clone = txtCodigo.Text.Substring(7, 4)
                Frasco = txtCodigo.Text.Substring(11, 3)
            ElseIf txtCodigo.Text.Length = 13 Then
                Mercadoria = txtCodigo.Text.Substring(0, 3)
                Lote = txtCodigo.Text.Substring(3, 3)
                Clone = txtCodigo.Text.Substring(6, 4)
                Frasco = txtCodigo.Text.Substring(10, 3)
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar processar o código de barras. Formato incorreto" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            limpa_formulario()
            Exit Sub
        End Try

        If Mercadoria > -1 And Lote > -1 And Clone > -1 Then
            Try
                'Tenta localizar se existe algum lote ativo com essa referencia
                Dim txt As String
                txt = DLookup("id", "Lotes", "Mercadoria=" & Mercadoria & " AND Lote=" & Lote & " AND Clone=" & Clone & " AND Ativo=1")
                LoteID = IIf(txt <> "", Integer.Parse(txt), -1)
                'Elimina a variável
                txt = Nothing
            Catch ex As Exception
                MsgBox("Erro ao tentar localizar as informações do lote" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try

            'Verifica se achou algo
            If Not LoteID = -1 Then
                'Habilita a informação do lote
                lblLote.Enabled = True
                lblID.Enabled = True

                'Monta a string do lote
                lblLote.Text = Format(Mercadoria, "000") & "." & Format(Lote, "000") & "." & Format(Clone, "0000")
                lblID.Text = LoteID
                lblFrasco.Text = Format(Frasco, "000")
                txtNumMudas.Text = DLookup("Mudas_frasco", "Lotes", "id=" & LoteID)
            Else
                'Se não encontrou nenhum lote ativo que atenda as especificações
                'Verifica a possibilidade de existirem lotes com essa especificação que estejam inativos
                Carrega_Lista(lstLotes, "Lotes", "id", "lote_id", True, "Mercadoria=" & Mercadoria & " AND Lote=" & Lote & " AND Clone=" & Clone)
                If lstLotes.Items.Count <= 0 Then
                    MsgBox("Não foram encontrados lotes ativos/inativos que atendam a estas especificações", MsgBoxStyle.Critical, "Erro")
                    'Pega o número do frasco
                    lblFrasco.Text = Frasco
                    'Limpa formulário e pede que tente novamente
                    limpa_formulario()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub limpa_formulario()
        txtCodigo.Text = String.Empty
        lblLote.Text = "..."
        lblLote.Enabled = False
        lblID.Text = "..."
        lblID.Enabled = False
        lblFrasco.Text = "..."
        lblFrasco.Enabled = False
        lstLotes.Items.Clear()
        lstLotes.Enabled = False
        txtNumMudas.Text = 0
        txtCodigo.Focus()
    End Sub

    Private Sub lstLotes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstLotes.SelectedIndexChanged
        'Se existir algum ítem escolhido então:
        If lstLotes.SelectedIndex > -1 Then
            Dim loteID As Integer
            'Localiza o ID do lote que está sendo procurado
            loteID = cmbVal(lstLotes)
            'Identifica o ID do Lote
            lblID.Text = loteID
            'Pega o lote nos ítens do listbox "000.000.0000"
            lblLote.Text = lstLotes.SelectedItems.Item(0).ToString.Substring(1, 12)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Fecha o formulário atual
        Me.Close()
    End Sub

    Private Sub btConfirma_Click(sender As System.Object, e As System.EventArgs) Handles btConfirma.Click

        'Primeiro verifica se algum lote 
        If lblID.Text <> "..." Then
            Dim LoteID As Integer = Integer.Parse(lblID.Text)
            'Se encontrou um lote então...
            'Procura se este frasco já existe
            Dim FrascoID As String
            FrascoID = DLookup("id", "Aux_Frascos", "Lote=" & Integer.Parse(lblID.Text) & " AND Vidro=" & Integer.Parse(lblFrasco.Text))
            'Se não achou Segue a diante pois o frasco não existe.
            If IsNothing(FrascoID) Or FrascoID = "" Then
                Dim SQL As String
                'Tenta incluir o frasco no lote
                Try
                    'Cria a SQL que fará a inclusão
                    SQL = "INSERT INTO aux_frascos SET "
                    SQL &= "Lote=" & LoteID & ","
                    SQL &= "Vidro= " & lblFrasco.Text & ","
                    SQL &= "NMudas=" & IIf(txtNumMudas.Text <> String.Empty, txtNumMudas.Text, 0) & ","
                    SQL &= "Impresso=1,"
                    SQL &= "Selecao=0"

                    'Executa esta SQL
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar inserir o frasco no Banco de dados" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                    Exit Sub
                End Try
                'Tenta atualiar o estoque do lote
                Try
                    'Cria a SQL que vai atualizar o Estoque no Banco de Dados
                    SQL = "UPDATE Lotes SET Estoque=Estoque + " & IIf(txtNumMudas.Text <> String.Empty, txtNumMudas.Text, 0) & ", Est_Frascos=Est_Frascos + 1 WHERE id=" & Integer.Parse(lblID.Text)

                    'Executa essa SQL
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar atualizar o estoque do lote " & lblLote.Text & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                    Exit Sub
                End Try

                'Avisa o Usuário que deu tudo certo
                MsgBox("O Frasco foi incluído com sucesso e o estoque do lote " & lblLote.Text & " está atualizado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Aviso")
                limpa_formulario()
                Exit Sub
            Else
                'Se foi encontrado então avisa o usuário
                MsgBox("Este frasco já possui um equivalente no banco de dados e não é possível reintegra-lo por este método" & vbCrLf & "Tente dar entrada manualmente pela rotina de alteração de lotes", MsgBoxStyle.Critical, "Erro")
                limpa_formulario()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtNumMudas_Enter(sender As System.Object, e As System.EventArgs) Handles txtNumMudas.Enter
        txtNumMudas.SelectAll()
    End Sub

    Private Sub txtCodigo_Enter(sender As System.Object, e As System.EventArgs) Handles txtCodigo.Enter
        txtCodigo.SelectAll()
    End Sub


    Private Sub txtNumMudas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumMudas.KeyDown
        EnterAsTab(sender, e)
    End Sub
End Class