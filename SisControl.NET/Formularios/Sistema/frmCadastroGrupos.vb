Public Class frmCadastroGrupos

    Protected Friend DT As DataTable
    Protected Friend P As New perm
    Protected Friend vet(10) As String

    Structure perm
        Friend Arquivo As String
        Friend Producao As String
        Friend Clientes As String
        Friend Pedidos As String
        Friend RH As String
        Friend Financeiro As String
        Friend Ferramentas As String
        Friend Relatorios As String
        Friend Sistema As String
        Friend WEB As String
        Friend Principal As String
        Friend Perfil As String
    End Structure

    Private Sub frmCadastroGrupos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Carrega_Lista(cmbPerfil, "permissoes", "id", "Perfil")
    End Sub

    Private Sub cmbPerfil_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPerfil.SelectedIndexChanged
        'Se foi selecionado algo válido
        If cmbPerfil.SelectedIndex <> -1 Then
            'Carrega a lista de permissoes
            Me.DT = SQLQuery("SELECT * FROM permissoes WHERE id=" & cmbVal(cmbPerfil))
            If Me.DT.Rows.Count > 0 Then
                With Me.DT.Rows(0)
                    P.Arquivo = .Item("Arquivo")
                    P.Producao = .Item("Producao")
                    P.Clientes = .Item("Clientes")
                    P.Pedidos = .Item("Pedidos")
                    P.RH = .Item("RH")
                    P.Financeiro = .Item("Financeiro")
                    P.Ferramentas = .Item("Ferramentas")
                    P.Relatorios = .Item("Relatorios")
                    P.Sistema = .Item("Sistema")
                    P.WEB = .Item("web")
                    P.Principal = .Item("Principal")
                    P.Perfil = .Item("Perfil")
                End With
                atualiza_Principal()
            End If
        End If
    End Sub

    Private Sub atualiza_Principal()
        'Se tiver o mesmo número de ítens, então carrega
        If P.Principal.Length = lstPrincipal.Items.Count Then
            'Para cada ítem
            For i As Integer = 0 To lstPrincipal.Items.Count - 1
                lstPrincipal.SetItemChecked(i, IIf(P.Principal.Substring(i, 1) = 1, True, False))
            Next
        End If
    End Sub

    Private Sub atualiza_Sub_menu()
        Dim Selecionado As Integer = lstPrincipal.SelectedIndex
        Dim Obj As ToolStripMenuItem
        'Apaga a lista de ítens
        lstMenu.Items.Clear()
        'Para cada menu tem um associado
        Select Case lstPrincipal.SelectedIndex
            Case 0
                Obj = frmMenu.mnpArquivo
                vet(0) = P.Arquivo
            Case 1
                Obj = frmMenu.mnpProducao
                vet(1) = P.Producao
            Case 2
                Obj = frmMenu.mnpClientes
                vet(2) = P.Clientes
            Case 3
                Obj = frmMenu.mnpPedidos
                vet(3) = P.Pedidos
            Case 4
                Obj = frmMenu.mnpRH
                vet(4) = P.RH
            Case 5
                Obj = frmMenu.mnpFinanceiro
                vet(5) = P.Financeiro
            Case 6
                Obj = frmMenu.mnpFerramentas
                vet(6) = P.Ferramentas
            Case 7
                Obj = frmMenu.mnpRelatorios
                vet(7) = P.Relatorios
            Case 8
                Obj = frmMenu.mnpSistema
                vet(8) = P.Sistema
            Case 9
                Obj = frmMenu.mnpWEB
                vet(9) = P.WEB
            Case Else
                Obj = Nothing
        End Select

        If IsNothing(Obj) Then
            Exit Sub
        End If

        'Pega os ítens
        For i As Integer = 0 To Obj.DropDownItems.Count - 1
            lstMenu.Items.Add(Obj.DropDownItems(i).Text.Replace("&", ""))
        Next

        'Se tiver algum perfil selecinado então verifica o que está ativo o que não está
        If cmbPerfil.SelectedIndex > -1 Then
            If vet(Selecionado).Length = lstMenu.Items.Count Then
                For i As Integer = 0 To vet(Selecionado).Length - 1
                    lstMenu.SetItemChecked(i, IIf(vet(Selecionado).Substring(i, 1) = 1, True, False))
                Next
            End If
        End If
    End Sub

    Private Sub lstPrincipal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstPrincipal.SelectedIndexChanged
        'Quando mudar aqui tem que atualizar o submenu
        If lstPrincipal.SelectedIndex > -1 Then
            'Atualiza os ítens do sub menu
            atualiza_Sub_menu()
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Limpa os argumentos e esvazia o perfil
        cmbPerfil.Text = ""
        cmbPerfil.SelectedIndex = -1
        P.Arquivo = ""
        P.Producao = ""
        P.Clientes = ""
        P.Pedidos = ""
        P.RH = ""
        P.Financeiro = ""
        P.Ferramentas = ""
        P.Relatorios = ""
        P.Sistema = ""
        P.WEB = ""
        P.Principal = ""
        P.Perfil = ""
        cmbPerfil.Focus()
    End Sub

    Private Sub lstMenu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstMenu.SelectedIndexChanged
        
    End Sub

    Private Function Monta_String() As String
        Dim Retorno As String = ""
        If lstMenu.Items.Count > 0 Then
            For i As Integer = 0 To lstMenu.Items.Count - 1
                Retorno &= IIf(lstMenu.GetItemChecked(i), "1", "0")
            Next
        Else
            Retorno = ""
        End If
        Return Retorno
    End Function

    Private Sub lstMenu_Leave(sender As System.Object, e As System.EventArgs) Handles lstMenu.Leave
        'Para cada menu tem um associado
        Select Case lstPrincipal.SelectedIndex
            Case 0
                P.Arquivo = Monta_String()
                vet(0) = P.Arquivo
            Case 1
                P.Producao = Monta_String()
                vet(1) = P.Producao
            Case 2
                P.Clientes = Monta_String()
                vet(2) = P.Clientes
            Case 3
                P.Pedidos = Monta_String()
                vet(3) = P.Pedidos
            Case 4
                P.RH = Monta_String()
                vet(4) = P.RH
            Case 5
                P.Financeiro = Monta_String()
                vet(5) = P.Financeiro
            Case 6
                P.Ferramentas = Monta_String()
                vet(6) = P.Ferramentas
            Case 7
                P.Relatorios = Monta_String()
                vet(7) = P.Relatorios
            Case 8
                P.Sistema = Monta_String()
                vet(8) = P.Sistema
            Case 9
                P.WEB = Monta_String()
                vet(9) = P.WEB
        End Select
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If cmbPerfil.SelectedIndex > -1 Then
            'Existente
            Dim SQL As String
            SQL = "UPDATE permissoes SET "
            SQL &= "Arquivo='" & P.Arquivo & "',"
            SQL &= "Producao='" & P.Producao & "',"
            SQL &= "Clientes='" & P.Clientes & "',"
            SQL &= "Pedidos='" & P.Pedidos & "',"
            SQL &= "RH='" & P.RH & "',"
            SQL &= "Financeiro='" & P.Financeiro & "',"
            SQL &= "Ferramentas='" & P.Ferramentas & "',"
            SQL &= "Relatorios='" & P.Relatorios & "',"
            SQL &= "Sistema='" & P.Sistema & "''"
            SQL &= "Web='" & P.WEB & "',"
            SQL &= "Principal='" & P.Principal & "'"
            SQL &= " WHERE id = " & cmbVal(cmbPerfil)

            'Falta atualizar as alteraçloes do princial

            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar salvar permissão do perfil." & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        Else
            'Novo
        End If
    End Sub
End Class


