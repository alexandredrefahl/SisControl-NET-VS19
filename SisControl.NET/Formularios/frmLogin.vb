
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.Win32


Public Class frmLogin

    Dim nTentativas As Integer = 0

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        'Verifica se foi digitado uma senha e um usuario
        If txtLogin.Text = "" Or txtSenha.Text = "" Then
            MsgBox("Preencha o nome de usuário e senha para continuar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'User é uma variável Global que contém os dados do usuário
        nTentativas += 1
        'Verifica o número de tentativas
        If nTentativas > 3 Then
            'sai do aplicativo
            Application.Exit()
        End If
        'Pega o usuario e senha
        User.Usuario = txtLogin.Text
        User.Senha = txtSenha.Text
        'Autenticar
        User.Autenticar()
        'Se estiver autenticado
        If nTentativas < 3 And User.Auth Then
            Me.Close()
        ElseIf nTentativas < 3 And Not User.Auth Then
            txtLogin.Text = ""
            txtSenha.Text = ""
            txtLogin.Focus()
            Exit Sub
        ElseIf nTentativas >= 3 And User.Auth = False Then
            MsgBox("Número de tentativas excedida", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            'Fecha o aplicativo se a senha estiver errada por 3 vezes
            Application.Exit()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'Sai do programa
        Application.Exit()
    End Sub

    Private Sub txtLogin_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSenha.Focus()
        End If
    End Sub

    Private Sub txtSenha_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown
        If e.KeyCode = Keys.Enter Then
            OK.Focus()
        End If
    End Sub

    Private Sub frmLogin_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Se o usuário está tentando sair
        If e.KeyCode = Keys.Escape Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Autenticação SisControl"
        'Acesso local por padrão
        cmbLocal.SelectedIndex = 0
    End Sub

    Private Sub cmbLocal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbLocal.SelectedIndexChanged
        If cmbLocal.Text = "Local" Then
            myIP = IP_SQL_CONNECTION
        ElseIf cmbLocal.Text = "Remoto" Then
            myIP = IP_SQL_CONNECTION_WEB
        Else
            myIP = cmbLocal.Text
        End If
        'Monta Conection string

        My.Settings.MyUsername = "alexandre"
        My.Settings.MyPassword = "@drf1624"

        MY_SQL_CONNECTION = "server=" & myIP & ";" & _
            "user id=" & My.Settings.MyUsername & ";" & _
            "password=" & My.Settings.MyPassword & ";" & _
            "database=" & My.Settings.MyDB

        'Define todas as variáveis e os tipos
        'Todas estas informações estão numa XML que é a configuração do projeto
        'As configurações My estão todas nesse XML
        Dim tcpClient As New TcpClient
        Dim IP As String = myIP
        Dim Port As Int32 = My.Settings.MyPort
        Dim Endereco As IPAddress
        'Converte o endereço em ip válido
        Endereco = IPAddress.Parse(IP)
        'Tenta conectar
        Try
            tcpClient.ReceiveTimeout = 300
            tcpClient.Connect(IP, Port)
            frmMenu.sbpStatus.ForeColor = Color.DarkGreen
            frmMenu.sbpStatus.Text = "Status: Conectado"
            Conectado = True
        Catch err As Exception
            frmMenu.sbpStatus.ForeColor = Color.DarkRed
            frmMenu.sbpStatus.Text = "Status: Desconectado"
            Conectado = False
        End Try

        Try
            'Atualiza a conexão com o IP Selecionado no banco de dados ODBC
            Dim regKey As RegistryKey
            regKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\ODBC\ODBC.INI\Controle", True)
            If cmbLocal.Text = "Local" Then
                regKey.SetValue("SERVER", IP_SQL_CONNECTION)
            ElseIf cmbLocal.Text = "Remoto" Then
                regKey.SetValue("SERVER", IP_SQL_CONNECTION_WEB)
            Else
                myIP = cmbLocal.Text
            End If
            regKey.Close()
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar a conexão ODBC" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro ODBC")
            Exit Sub
        End Try
    End Sub
End Class
