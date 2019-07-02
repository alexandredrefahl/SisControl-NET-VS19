Imports MailKit.Net.Pop3
Imports MimeKit
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.ComponentModel


Public Class aux_Processa_Email

    Public frmPai As frmReservas

    Dim varLogin As String = "comercial@clona-gen.com.br"
    Dim varPass As String = "clona@2018"

    Private Structure InfoEmail
        Dim Nome As String
        Dim Fone As String
        Dim Email As String
        Dim Data As String
        Dim Variedades As List(Of String)
        'Cria uma estrutura já com o nome
        Public Sub New(ByVal vNome As String)
            Nome = vNome
            Variedades = New List(Of String)
        End Sub
        Public Sub Clear()
            Nome = String.Empty
            Fone = String.Empty
            Email = String.Empty
            Data = String.Empty
            Variedades.Clear()
        End Sub
    End Structure

    Dim Altura_Cond As Integer = 262
    Dim Altura_Expa As Integer = 455

    Dim Atual As New InfoEmail(".")

    Public Sub New(ByRef Pai As frmReservas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPai = Pai

    End Sub

    Private Sub msg(ByVal texto As String)
        tsMsg.Text = texto
        ssStatus.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As New Pop3Client()
        Try
            Me.Cursor = Cursors.WaitCursor
            msg("Conectando ao servidor...")
            client.Connect("uscentral30.myserverhosts.com", 995, True)
            'Note: since we don't have an OAuth2 token, disable the XOAUTH2 authentication mechanism.
            'client.AuthenticationMechanisms.Remove("XOAUTH2")
            msg("Autenticando...")
            client.Authenticate(varLogin, varPass)
            msg("Conectado ao servidor de e-mail")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao conectar com servidor de e-mail" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        msg("Verificando mensagens...")
        msg("O servidor possui: " & client.Count & " mensagens")

        If client.Count = 0 Then
            MsgBox("Não há e-mail a serem recuperados.", MsgBoxStyle.OkOnly, "Aviso")
            client.Disconnect(True)
            Exit Sub
        End If

        msg("Processando mensagens...")
        tsProgress.Minimum = 0
        tsProgress.Maximum = client.Count - 1

        For i As Integer = 0 To client.Count - 1
            'Atualiza a barra de progresso
            tsProgress.Value = i
            ssStatus.Refresh()
            Dim Mensagem As MimeMessage = client.GetMessage(i)
            lstEmails.Items.Add(Mensagem.Subject)
            msg("Processando mensagem " & i + 1 & " de " & client.Count - 1)
        Next
        tsProgress.Value = 0
        msg("Desconectando...")
        client.Disconnect(True)
        msg("...")

    End Sub
    Private Sub Processa_Anexo(ByVal mensagem As MimeMessage, ByRef inf As InfoEmail)
        For Each anexo As MimePart In mensagem.Attachments
            anexo.WriteTo("d:\" & anexo.FileName)
        Next
    End Sub


    Private Sub Processa_Email(ByVal Mensagem As MimeMessage, ByRef Info As InfoEmail)
        Dim varNome As String = ""
        Dim varEmail As String = ""
        Dim varFone As String = ""
        Dim varVariedades As String = ""
        Dim varData As String = Mensagem.Date.ToString("yyyy-MM-dd")
        Dim varFrom As String = Mensagem.From.ToString()
        Dim varMensagem As String = Mensagem.HtmlBody

        '## Define a Data da Reserva
        txtData.Text = varData

        '## Extração do Nome/Telefone
        Dim padraoRegex As String = "(?:Nome:<\/b>)(.*?)(?:<br>)"
        Dim rgNome As New Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim Matches As MatchCollection = rgNome.Matches(varMensagem)
        'Se encontrou pelo menos um
        If Matches.Count > 0 Then
            '## Extração do Nome
            'Dentro do Match o Grupo 1 (do meio) dos caracteres separados
            varNome = Matches.Item(0).Groups(1).Value
            'Remove o espaço em branco do primeiro caractere
            varNome = varNome.Remove(0, 1)
            txtNome.Text = varNome
            Info.Nome = varNome
        End If

        '## Extração do Telefone
        padraoRegex = "(?:Telefone:<\/b>)(.*?)(?:<\/p>)"
        Dim rgFone As New Regex(padraoRegex)
        Matches = rgFone.Matches(varMensagem)
        'Se encontrou pelo menos um
        If Matches.Count > 0 Then
            'Dentro do Match o Grupo 1 (do meio) dos caracteres separados
            varFone = Matches.Item(0).Groups(1).Value
            varFone = varFone.Remove(0, 1)
            txtFone.Text = varFone
            Info.Fone = varFone
        End If

        '## Extração E-Mail
        padraoRegex = "[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})"
        Dim rgEmail As New Regex(padraoRegex)
        Matches = rgEmail.Matches(varMensagem)
        'Se encontrou pelo menos um
        If Matches.Count > 0 Then
            varEmail = Matches.Item(0).Value
            txtEmail.Text = varEmail
            Info.Email = varEmail
        End If

        '## Extração das variedades
        padraoRegex = "(mandioca-brs-)(\d\d\d)"
        Dim rgVariedades As New Regex(padraoRegex)
        Matches = rgVariedades.Matches(varMensagem)
        'Se encontrou pelo menos um
        If Matches.Count > 0 Then
            For Each varBRS As Match In Matches
                lblVariedades.Text &= (varBRS.Groups(2).Value & ";")
                Info.Variedades.Add(New String(varBRS.Groups(2).Value.ToString))
            Next
        End If

    End Sub

    Private Sub btAdicionar_Click(sender As Object, e As EventArgs) Handles btAdicionar.Click
        'Pega o íten selecionado
        Dim n As Integer = lstEmails.SelectedIndex

        'Dimensiona a conexão pop3
        Dim client As New Pop3Client()
        Try
            Me.Cursor = Cursors.WaitCursor
            msg("Conectando ao servidor...")
            client.Connect("uscentral30.myserverhosts.com", 995, True)
            msg("Autenticando...")
            client.Authenticate(varLogin, varPass)
            msg("Conectado ao servidor de e-mail")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao conectar com servidor de e-mail" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        'Depois de ter conseguido conectar pega a mensagem específica
        Dim Mensagem As MimeMessage = client.GetMessage(n)

        lblVariedades.Text = ""
        'Envia a mensagem inteira como referência e recebe de volta por valor o atual preenchido
        'Processa_Email(Mensagem, Atual)
        Processa_Anexo(Mensagem, Atual)
        'aumenta o form

        Me.Size = New System.Drawing.Size(390, Altura_Expa)
        'Desconecta do provedor
        client.Disconnect(True)

    End Sub

    Private Sub aux_Processa_Email_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(390, Altura_Cond)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SQL_Reserva As String, SQL_Itens As String, id As Integer = -1

        'Pega o próximo ID do Auto_Increment da tabela
        id = DNextID("reservas")

        'Com as informações no objeto e-mail é possível criar as duas SQL
        'Monta a SQL de inclusão da Reserva
        SQL_Reserva = "INSERT INTO reservas SET "
        SQL_Reserva &= "id=" & id & ","
        SQL_Reserva &= "Data='" & txtData.Text & "',"
        SQL_Reserva &= "Nome='" & txtNome.Text & "',"
        SQL_Reserva &= "Fone=" & Texto_Vazio(txtFone.Text) & ","
        SQL_Reserva &= "Email=" & Texto_Vazio(txtEmail.Text) & ","
        SQL_Reserva &= "Atendido=0"

        Dim Mercadoria As Integer, Clone As Integer, Descricao As String

        'Define a mercadoria = Mandioca
        Mercadoria = 45

        SQL_Itens = "INSERT INTO reservas_itens (Doc_Id,Mercadoria,Clone,Descricao,Quantidade,Forma,Preco) VALUES "
        For i As Integer = 0 To Atual.Variedades.Count - 1
            'Se for a segunda vez que passa aqui cria a lista.
            If i > 0 Then
                SQL_Itens &= ","
            End If
            'Preenche as variáveis auxiliares
            Clone = Atual.Variedades(i)
            Descricao = DLookup("Cientifico", "Mercadoria", "id=" & Mercadoria) & " cv. " & DLookup("Nome", "Clones", "Mercadoria=" & Mercadoria & " AND Clone=" & Clone)
            'Monta a SQL de inclusão
            SQL_Itens &= "(" & id & ","
            SQL_Itens &= Mercadoria & ","
            SQL_Itens &= Clone & ","
            SQL_Itens &= "'" & Descricao & "',"
            SQL_Itens &= txtQtdePadrao.Text & ","
            SQL_Itens &= "'Muda Aclimatizada',"
            SQL_Itens &= Numero_to_SQL(txtValor.Text) & ")"
        Next

        Console.WriteLine(SQL_Reserva)
        Console.WriteLine(SQL_Itens)

        'Monta um Array de SQLs para fazer o lote em transação (ou tudo ou nada
        Dim SQL_Transacao(1) As String
        'Atribui as duas SQLs na transação
        SQL_Transacao(0) = SQL_Reserva
        SQL_Transacao(1) = SQL_Itens
        'Tenta executar a transação
        Try
            Me.Cursor = Cursors.WaitCursor
            'tenta executar a transação SQL
            If SQLTransacao(SQL_Transacao) Then
                MsgBox("A reserva e seus ítens foram incluídos com sucesso!", MsgBoxStyle.OkOnly, "Confirmação")
                msg("Enviando e-mail para o cliente...")
                If chkEmail.Checked Then
                    Envia_Email()
                End If
                Me.Cursor = Cursors.Arrow
                Me.Size = New System.Drawing.Size(390, Altura_Cond)
                Atual.Clear()
                msg("...")
            Else
                MsgBox("Erro desconhecido ao incluir a reserva ou seus ítens", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Erro ao incluir a reserva ou seus ítens" & vbCrLf & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub limpa_campos()
        txtNome.Text = String.Empty
        txtData.Text = String.Empty
        txtEmail.Text = String.Empty
        txtFone.Text = String.Empty
        txtNome.Text = String.Empty
        txtQtdePadrao.Text = "20"
        txtValor.Text = "2,00"
    End Sub

    Private Sub Envia_Email()
        Dim eml As New Email

        If txtEmail.Text = String.Empty Then
            MsgBox("Não é possível enviar e-mail pois o campo não foi preenchido", MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        'Dimensiona variáveis usadas no cabeçalho do e-mail
        Dim mlBody As String = String.Empty

        mlBody = Gera_Body()

        'Preenche os dados de envio
        Email.enviaMensagemEmail(E_MailFrom, txtEmail.Text, "", "alexandre@clona-gen.com.br", "[Clona-Gen] Interessado em mudas de Mandioca", mlBody, E_MailServer)
    End Sub

    Private Function Gera_Body() As String
        Dim Body As String = String.Empty
        Dim strModeloPath As String = My.Application.Info.DirectoryPath & "\modelos\confirmacao_reserva.html"

        Dim varPrimeiroNome = txtNome.Text.Substring(0, txtNome.Text.IndexOf(" "))
        Dim varSaudacao = IIf(Now.TimeOfDay.Hours > 12, "Boa tarde", "Bom dia")
        Dim varVariedades = String.Empty

        For i As Integer = 0 To Atual.Variedades.Count - 1
            If i > 0 Then
                'Se for o último boa "E"
                If i = Atual.Variedades.Count - 1 Then
                    varVariedades &= " e "
                Else
                    varVariedades &= ", "
                End If
            End If
            varVariedades &= "BRS-" & Atual.Variedades(i)
        Next

        'Carrega arquivo de modelo de e-mail
        'Lê o arquivo de modelo
        Body = File.ReadAllText(strModeloPath)
        'Define os campos que serão substituidos no modelo
        Dim Campos() As String = {"[Primeiro_Nome]", "[Saudacao]", "[variedades]"}
        'Cria um array com todas as informações coletadas
        Dim Valores() As String = {varPrimeiroNome, varSaudacao, varVariedades}

        'Substitui os campos do HTML gerando o corpo do e-mail
        For i As Integer = 0 To Campos.Length - 1
            Body = Body.Replace(Campos(i), Valores(i))
        Next
        'Retorna 
        Return Body
    End Function

    Private Sub aux_Processa_Email_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmPai.DataGridRefresh()
    End Sub
End Class