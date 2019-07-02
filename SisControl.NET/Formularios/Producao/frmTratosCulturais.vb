Public Class frmTratosCulturais

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub frmTratosCulturais_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtData.Text = System.DateTime.Today.Date
        Atualiza_Datagrid()

    End Sub

    Private Sub dgTrato_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTrato.SelectionChanged
        If dgTrato.SelectedRows.Count > 0 Then
            With dgTrato.SelectedRows(0)
                txtData.Value = NaoNulo(.Cells("Data").Value)
                chkEstufa1.Checked = .Cells("Estufa1").Value
                chkEstufa2.Checked = .Cells("Estufa2").Value
                cmbTipo.Text = NaoNulo(.Cells("Tipo").Value)
                cmbProduto.Text = NaoNulo(.Cells("Produto").Value)
                txtConcentracao.Text = NaoNulo(.Cells("Concentracao").Value)
                txtVolume.Text = NaoNulo(.Cells("Volume").Value)
                If NaoNulo(.Cells("Unidade").Value) = "mg/L" Then
                    rdMGL.Checked = True
                Else
                    rdGL.Checked = True
                End If
                txtObservacoes.Text = NaoNulo(.Cells("Observacoes").Value)
            End With
        End If
    End Sub

    Private Sub Atualiza_Datagrid()
        Dim SQL As String = String.Empty, DT As DataTable
        SQL = "SELECT * FROM TratoEstufa ORDER BY Data"
        Try
            DT = SQLQuery(SQL)
            dgTrato.DataSource = DT

            Dim Cabecalhos() As String = {"ID", "Data", "E I", "E II", "Tipo", "Produto", "Conc.", "Un.", "Vol.", "Obs"}
            Dim Visiveis() As Integer = {0, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            Dim Tamanhos() As Integer = {0, 80, 30, 30, 90, 90, 40, 30, 40, 95}
            Formata_Datagrid(dgTrato, Cabecalhos, Tamanhos, Visiveis)

        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar dados de Tratos Culturais no Banco de Dados" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Limpa_Campos()
        txtData.Value = Date.Today.Date
        chkEstufa1.Checked = False
        chkEstufa2.Checked = False
        cmbTipo.Text = String.Empty
        cmbProduto.Text = String.Empty
        txtConcentracao.Text = String.Empty
        rdGL.Checked = True
        txtVolume.Text = String.Empty
        txtObservacoes.Text = String.Empty
    End Sub

    Private Sub Habilita_Campos(ByVal TF As Boolean)
        txtData.Enabled = TF
        chkEstufa1.Enabled = TF
        chkEstufa2.Enabled = TF
        cmbTipo.Enabled = TF
        cmbProduto.Enabled = TF
        txtConcentracao.Enabled = TF
        txtVolume.Enabled = TF
        txtObservacoes.Enabled = TF
        rdGL.Enabled = TF
        rdMGL.Enabled = TF
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Se for acrescentar um registro
        If Button1.Text = "Novo" Then
            'Limpa_Campos(Me)
            'Limpa os campos de dados
            Limpa_Campos()
            'Habilita os campos necessários
            Habilita_Campos(True)
            txtData.Focus()
            Button1.Text = "Incluir"
            Button2.Enabled = False
            GoTo fim
        End If
        'Executa a inclusão
        If Button1.Text = "Incluir" Then
            Dim SQL As String = String.Empty
            SQL = "INSERT INTO TratoEstufa SET "
            'Monta a aSQL de inclusão
            SQL &= "Data='" & txtData.Value.ToString("yyyy-MM-dd") & "',"
            SQL &= "Estufa1=" & IIf(chkEstufa1.Checked, 1, 0) & ","
            SQL &= "Estufa2=" & IIf(chkEstufa2.Checked, 1, 0) & ","
            SQL &= "Tipo=" & Texto_Vazio(cmbTipo.Text) & ","
            SQL &= "Produto=" & Texto_Vazio(cmbProduto.Text) & ","
            SQL &= "Concentracao=" & Numero_to_SQL(txtConcentracao.Text) & ","
            SQL &= "Unidade='" & IIf(rdGL.Checked, "g/L", "ml/L") & "',"
            SQL &= "Volume=" & Numero_to_SQL(txtVolume.Text) & ","
            SQL &= "Observacoes=" & Texto_Vazio(txtObservacoes.Text)

            'Tenta fazer a inclusão
            Try
                ExecutaSQL(SQL)
                MsgBox("Serviço incluído com sucesso!", MsgBoxStyle.Information, "Confirmação")
                Button1.Text = "Novo"
                Button2.Enabled = True
                Habilita_Campos(False)
                'Atualiza o datagrid
                Atualiza_Datagrid()
                'Seleciona automaticamente a ultima linha
                dgTrato.Rows(dgTrato.RowCount - 1).Selected = True
                GoTo fim
            Catch ex As Exception
                MsgBox("Erro ao tentar incluir o serviço!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
fim:

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "Editar" Then
            Habilita_Campos(True)
            txtData.Focus()
            Button2.Text = "Salvar"
            Button1.Enabled = False
            GoTo Fim
        End If

        If Button2.Text = "Salvar" Then
            Dim SQL As String = String.Empty
            SQL = "UPDATE TratoEstufa SET "
            'Monta a aSQL de inclusão
            SQL &= "Data='" & txtData.Value.ToString("yyyy-MM-dd") & "',"
            SQL &= "Estufa1=" & IIf(chkEstufa1.Checked, 1, 0) & ","
            SQL &= "Estufa2=" & IIf(chkEstufa2.Checked, 1, 0) & ","
            SQL &= "Tipo=" & Texto_Vazio(cmbTipo.Text) & ","
            SQL &= "Produto=" & Texto_Vazio(cmbProduto.Text) & ","
            SQL &= "Concentracao=" & Numero_to_SQL(txtConcentracao.Text) & ","
            SQL &= "Unidade='" & IIf(rdGL.Checked, "g/L", "ml/L") & "',"
            SQL &= "Volume=" & Numero_to_SQL(txtVolume.Text) & ","
            SQL &= "Observacoes=" & Texto_Vazio(txtObservacoes.Text)
            SQL &= " WHERE id=" & dgTrato.SelectedRows(0).Cells(0).Value
            'Tenta fazer a inclusão
            Try
                ExecutaSQL(SQL)
                MsgBox("Serviço Atualizado com sucesso!", MsgBoxStyle.Information, "Confirmação")
                Button2.Text = "Editar"
                Habilita_Campos(False)
                Atualiza_Datagrid()
                'Seleciona automaticamente a ultima linha
                dgTrato.Rows(dgTrato.RowCount - 1).Selected = True
                GoTo Fim
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar o serviço!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
Fim:

    End Sub

End Class