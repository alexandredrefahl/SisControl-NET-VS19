Public Class frmNegocio

    Dim IDNeg As Integer = -1

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub


    Public Sub New(Optional ByVal IDNegocio = -1)

        ' Essa chamada é requerida pelo tempo de construção
        InitializeComponent()

        ' Adicionar qualquer função extra ao inicializador

        'Se o id for nulo então já descarta
        If IDNegocio = -1 Then
            btSalvar.Text = "Incluir"
            Exit Sub
        Else        'Caso contrário, carrega o negócio em questão
            IDNeg = IDNegocio
            Carrega_Negocio(IDNegocio)
        End If
    End Sub

    Private Sub Carrega_Negocio(ByVal IDNegocio As Integer)
        'Dimensiona a linha que vai receber
        Dim DR As DataRow
        'Recupera dados do banco de dados.
        DR = DLookupRow("Negocios", "id=" & IDNegocio)
        'Coloca o conteúdo nos texbox
        With DR
            txtTitulo.Text = NaoNulo(.Item("Titulo"))
            txtCliente.Text = NaoNulo(.Item("Cliente"))
            txtEmpresa.Text = NaoNulo(.Item("Empresa"))
            txtEmail.Text = NaoNulo(.Item("email"))
            txtFone.Text = NaoNulo(.Item("Fone"))
            txtValor.Text = Format(.Item("valor"), "N2")
            txtObservacoes.Text = NaoNulo(.Item("Observacoes"))
            cmbStatus.Text = NaoNulo(.Item("Status"))
        End With

    End Sub

    Private Sub Salva_Negocio(ByVal Tipo As String)
        Dim SQL As String = ""

        If Tipo = "N" Then      'Novo
            'Monta a SQL de Salvamento
            SQL = "INSERT INTO Negocios SET "
        ElseIf Tipo = "U" Then  'Update
            SQL = "UPDATE Negocios SET "
        End If

        'Monta o corpo do SQL
        SQL &= "Titulo=" & Texto_Vazio(txtTitulo.Text) & ","
        SQL &= "Cliente=" & Texto_Vazio(txtCliente.Text) & ","
        SQL &= "Empresa=" & Texto_Vazio(txtEmpresa.Text) & ","
        SQL &= "Fone=" & Texto_Vazio(txtFone.Text) & ","
        SQL &= "email=" & Texto_Vazio(txtEmail.Text) & ","
        SQL &= "valor=" & Numero_to_SQL(txtValor.Text) & ","
        SQL &= "Observacoes=" & Texto_Vazio(txtObservacoes.Text) & ","
        SQL &= "Status=" & cmbStatus.Text.Substring(0, 1) & ","
        'Verifica se o tipo é inclusão ou alteração para complementar a SQL
        If Tipo = "N" Then
            SQL &= "Criacao=CURRENT_TIMESTAMP()"
        ElseIf Tipo = "U" Then
            SQL &= "Atualizacao=CURRENT_TIMESTAMP()"
        End If

        'Se for de atualização complementa com o ID de referencia
        If Tipo = "U" Then
            SQL &= " WHERE id=" & IDNeg
        End If

        'Então executa a SQL
        Try
            Dim ret As Integer
            ret = ExecutaSQL(SQL)
            If ret = -1 Then
                MsgBox("Erro ao tentar incluir/salvar o negócio editado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir/salvar o negócio editado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
        'Se passou pelo processo de inclusão/salvamento
        If Tipo = "N" Then
            MsgBox("Negócio incluído com sucesso", MsgBoxStyle.OkOnly, "Confirmação")
        ElseIf Tipo = "U" Then
            MsgBox("Negócio alterado com sucesso", MsgBoxStyle.OkCancel, "Confirmação")
        End If

        Me.Close()
        'Função que limpa todos os campos do formulário
        'Limpa_Campos(Me)
        'txtValor.Text = "0,00"
        'txtTitulo.Focus()
        'Importante para o salvamento
        'IDNeg = -1
    End Sub


    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        'Se tem um ID registrado
        If IDNeg <> -1 Then
            'Se já tem um registro aberto, só faz o update
            Salva_Negocio("U")
        Else
            'Se for um registro novo então cria uma cópia.
            Salva_Negocio("N")
        End If
    End Sub

    Private Sub btWin_Click(sender As Object, e As EventArgs)
        Dim resp As Integer
        If IDNeg <> -1 Then
            Console.WriteLine("ID do Negócio:" & IDNeg)
            'Confirmação
            resp = MsgBox("Deseja registrar o Ganho do Negócio?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Confirmação")
            'Se for confirmado
            If resp = vbYes Then
                Dim SQL As String = ""
                SQL = "UPDATE Negocios SET Status=5 AND ganho_data=CURRENT_TIMESTAMP() WHERE id=" & IDNeg
                ExecutaSQL(SQL)
                MsgBox("Negócio Registrado com Sucesso", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação")
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Não há nenhum negócio carregado. Não é possível fazer o registro.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If
    End Sub

    Private Sub btLoose_Click(sender As Object, e As EventArgs)
        Dim resp As Integer
        If IDNeg <> -1 Then
            'Confirmação
            resp = MsgBox("Deseja registrar a Baixa do Negócio?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Confirmação")
            'Se for confirmado
            If resp = vbYes Then
                'Pergunta ao usuário o motivo da perda
                Dim SQL As String = "", perda_motivo As String
                perda_motivo = InputBox("Qual o motivo da perda do Negócio?", "Motivo da Perda")
                SQL = "UPDATE Negocios SET Status=6, perda_motivo='" & perda_motivo & "', perda_data=CURRENT_TIMESTAMP() WHERE id=" & IDNeg
                ExecutaSQL(SQL)
                MsgBox("Negócio baixado com sucesso", MsgBoxStyle.OkOnly, "Confirmação")
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Não há nenhum negócio carregado. Não é possível fazer o registro.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End If
    End Sub

    Private Sub btEmail_Click(sender As Object, e As EventArgs) Handles btEmail.Click
        'Função snipet para abrir o programa de e-mail registrado pelo sistema
        EnviarEmail(txtEmail.Text, txtTitulo.Text)
    End Sub

    Private Function EnviarEmail(ByVal EmailAddress As String, Optional ByVal Subject As String = "", Optional ByVal Body As String = "") As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If

        Try
            Process.Start(sParams)
        Catch
            bAns = False
        End Try
        Return bAns
    End Function



    Private Sub btHistorico_Click(sender As Object, e As EventArgs) Handles btHistorico.Click
        'Historico de e-mails no GMail
        Dim Pesquisa As String = "https://mail.google.com/mail/u/0/#search/"

        Process.Start(Pesquisa & txtEmail.Text)

    End Sub

    Private Sub frmNegocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class