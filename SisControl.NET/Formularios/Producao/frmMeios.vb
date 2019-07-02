
Public Class frmMeios

    
    Private Sub frmMeios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista de meio de cultura
        Carrega_Lista(cmbMeio, "meio", "id", "meio", True)
        Carrega_Lista(cmbBase, "meiosbase", "id", "Nome")
    End Sub

    Private Sub btCor1_Click(sender As System.Object, e As System.EventArgs) Handles btCor1.Click
        Dim Cor As Color
        cdCores.ShowDialog()
        Cor = cdCores.Color
        lblCor1.BackColor = Cor
        txtCor1.Text = Cor.R.ToString("000") & ";" & Cor.G.ToString("000") & ";" & Cor.B.ToString("000")
    End Sub

    Private Sub btCor2_Click(sender As System.Object, e As System.EventArgs) Handles btCor2.Click
        Dim Cor As Color
        cdCores.ShowDialog()
        Cor = cdCores.Color
        lblCor2.BackColor = Cor
        txtCor2.Text = Cor.R.ToString("000") & ";" & Cor.G.ToString("000") & ";" & Cor.B.ToString("000")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Limpa_Campos()
    End Sub

    Private Sub Limpa_Campos()
        txtDescricao.Text = ""
        txtConstituicao.Text = ""
        cmbBase.SelectedIndex = -1
        cmbBase.Text = ""
        txtPH.Text = ""
        txt24D.Text = ""
        txt2IP.Text = ""
        txtABA.Text = ""
        txtAIA.Text = ""
        txtAIB.Text = ""
        txtANA.Text = ""
        txtBAP.Text = ""
        txtCor1.Text = ""
        txtCor2.Text = ""
        txtOutros.Text = ""
        lblCor1.BackColor = Color.White
        lblCor2.BackColor = Color.White
        TabControl1.TabIndex = 0
        txtDescricao.Focus()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        'Se for um meio novo Que ainda não tem código
        If cmbMeio.SelectedIndex = -1 Then
            SQL = Monta_SQL("INSERT")
        Else
            'Se for um meio que já existe e só é preciso alterar
            SQL = Monta_SQL("UPDATE")
        End If

        Try
            ExecutaSQL(SQL)
            If cmbMeio.SelectedIndex = -1 Then
                MsgBox("Meio de cultura incluído com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação")
            Else
                MsgBox("Meio de cultura salvo com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar salvar o meio de cultura atual." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Private Function Monta_SQL(Tipo As String) As String
        Dim SQL As String = String.Empty
        If Not Tipo = String.Empty Then
            'Verifica qual o tipo de SQL que se precisa
            If Tipo = "INSERT" Then
                SQL = "INSERT INTO Meio SET "
            ElseIf Tipo = "UPDATE" Then
                SQL = "UPDATE Meio SET "
            End If
            'Monta a parte comum às duas operações
            SQL &= "Meio='" & txtDescricao.Text & "', "
            SQL &= "Constituicao='" & txtConstituicao.Text & "', "
            SQL &= "ph=" & Numero_to_SQL(txtPH.Text) & ", "
            SQL &= "MeioBase=" & cmbVal(cmbBase) & ", "
            SQL &= "ANA=" & Numero_to_SQL(txtANA.Text) & ", "
            SQL &= "BAP=" & Numero_to_SQL(txtBAP.Text) & ", "
            SQL &= "24D=" & Numero_to_SQL(txt24D.Text) & ", "
            SQL &= "KIN=" & Numero_to_SQL(txtKIN.Text) & ", "
            SQL &= "2iP=" & Numero_to_SQL(txt2IP.Text) & ", "
            SQL &= "ABA=" & Numero_to_SQL(txtABA.Text) & ", "
            SQL &= "TDZ=" & Numero_to_SQL(txtTDZ.Text) & ", "
            SQL &= "AIB=" & Numero_to_SQL(txtAIB.Text) & ", "
            SQL &= "AIA=" & Numero_to_SQL(txtAIA.Text) & ", "
            SQL &= "GA3=" & Numero_to_SQL(txtGA3.Text) & ", "
            SQL &= "Outros=" & Texto_Vazio(txtOutros.Text) & ","
            SQL &= "Cor1=" & Texto_Vazio(txtCor1.Text) & ","
            SQL &= "Cor2=" & Texto_Vazio(txtCor2.Text)
            'Se for do tipo UPDATE tem que definir o ID para alteração
            If Tipo = "UPDATE" Then
                SQL &= " WHERE id=" & cmbVal(cmbMeio)
            End If
        End If
        Return SQL
    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbMeio_Leave(sender As System.Object, e As System.EventArgs) Handles cmbMeio.Leave
        'Se tiver algo selecionado....
        If cmbMeio.SelectedIndex > -1 Then
            Dim Lin As DataRow
            'Pega a linha de dados correspondente ao registro localizado
            Lin = DLookupRow("meio", "id=" & cmbVal(cmbMeio))
            'Começa a preencher os campos
            txtDescricao.Text = Lin.Item("Meio")
            txtConstituicao.Text = NaoNulo(Lin.Item("Constituicao"))
            Localiza_Item(cmbBase, Lin.Item("MeioBase"))
            txtPH.Text = Format(Lin.Item("ph"), "N2")
            txt24D.Text = NaoNulo(Lin.Item("24D"))
            txt2IP.Text = NaoNulo(Lin.Item("2IP"))
            txtABA.Text = NaoNulo(Lin.Item("ABA"))
            txtAIA.Text = NaoNulo(Lin.Item("AIA"))
            txtAIB.Text = NaoNulo(Lin.Item("AIB"))
            txtANA.Text = NaoNulo(Lin.Item("ANA"))
            txtBAP.Text = NaoNulo(Lin.Item("BAP"))
            txtGA3.Text = NaoNulo(Lin.Item("GA3"))
            txtTDZ.Text = NaoNulo(Lin.Item("TDZ"))
            txtKIN.Text = NaoNulo(Lin.Item("KIN"))
            txtCor1.Text = NaoNulo(Lin.Item("Cor1"))
            txtCor2.Text = NaoNulo(Lin.Item("Cor2"))
            txtOutros.Text = NaoNulo(Lin.Item("Outros"))
            'Verifica se o meio tem alguma cor cadastrada
            Dim divideCOR1() As String
            If Not IsDBNull(Lin.Item("Cor1")) And Not Lin.Item("Cor1").ToString = String.Empty Then
                divideCOR1 = Lin.Item("Cor1").ToString.Split(";")
                lblCor1.BackColor = Color.FromArgb(divideCOR1(0), divideCOR1(1), divideCOR1(2))
            End If
            Dim divideCOR2() As String
            If Not IsDBNull(Lin.Item("Cor2")) And Not Lin.Item("Cor2").ToString = String.Empty Then
                divideCOR2 = Lin.Item("Cor2").ToString.Split(";")
                lblCor2.BackColor = Color.FromArgb(divideCOR2(0), divideCOR2(1), divideCOR2(2))
            End If
            TabControl1.TabIndex = 0
            txtDescricao.Focus()

        End If
    End Sub

    Private Sub cmbBase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbBase.SelectedIndexChanged

    End Sub
End Class