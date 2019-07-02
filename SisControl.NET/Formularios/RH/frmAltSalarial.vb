Public Class frmAltSalarial

    Private Sub frmAltSalarial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ao carregar, seleciona lista de funcionários
        Carrega_Lista(cmbFuncionario, "Funcionarios", "id", "Nome", True)


    End Sub

    Private Sub cmbFuncionario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFuncionario.SelectedIndexChanged
        'Atualiza o datagrid
        Atualiza_Datagrid(cmbVal(cmbFuncionario))

        'Se houverem atualizações, posso alterar
        If dgSalarios.Rows.Count > 0 Then
            'Habilita os botoes de edicao
            btAlterar.Enabled = True
            btExcluir.Enabled = True
            btAtualizar.Enabled = True
        Else
            'Desabilita os botoes de edicao
            btAlterar.Enabled = False
            btExcluir.Enabled = False
            btAtualizar.Enabled = False
        End If

    End Sub

    Private Sub Atualiza_Datagrid(IDFuncionario as Int16)
        Dim DS As DataTable, SQL As String

        'Ao Alterar o funcionário seleciona os itens
        SQL = "SELECT id,Data,Valor FROM RHAltSalarios WHERE CodFunc=" & IDFuncionario & " ORDER BY Data"
        DS = SQLQuery(SQL)

        'Preenche com os dados recuperados
        dgSalarios.DataSource = DS

        'Formata o DataGrid
        With dgSalarios
            'Oculta a primeira coluna (ID)
            .Columns(0).Visible = False

        End With


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        Dim SQL As String

        'Se o botão estiver alterado pela rotina de alteração
        If btIncluir.Text = "Salvar" Then
            With dgSalarios.SelectedRows(0)
                SQL = "UPDATE RHAltSalarios SET Data='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',Valor=" & txtSalario.Text.Replace(",", ".") & " WHERE id=" & .Cells(0).Value.ToString
                Console.WriteLine(Me.Name.ToString & ":" & SQL)
            End With
            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar o salário do funcionário!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            'Retorna o botão ao normal
            btIncluir.Text = "Adicionar"
            txtData.Text = String.Empty
            txtSalario.Text = String.Empty
            'Atuzaliza o Datagrid
            Atualiza_Datagrid(cmbVal(cmbFuncionario))
            'Sai antes que cause uma nova inclusão
            Exit Sub
        End If

        '                                         ID ,          CodFunc,                  Data,                                              Valor
        SQL = "INSERT INTO RHAltSalarios VALUES (NULL," & cmbVal(cmbFuncionario) & ",'" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "'," & txtSalario.Text.Replace(",", ".") & ")"
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o salário do funcionário!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        txtSalario.Text = String.Empty
        txtData.Text = String.Empty
        Atualiza_Datagrid(cmbVal(cmbFuncionario))

    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        Dim SQL As String, a As Integer
        'Pede confirmação
        a = MsgBox("Tem certeza de que deseja excluir este lançamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        'Se confirmou então vai adiante
        If a = vbYes Then
            'monta a SQL para fazer a exclusão
            SQL = "DELETE FROM RHAltSalarios WHERE id=" & dgSalarios.SelectedRows(0).Cells(0).Value
            'informação para debug
            Console.WriteLine(Me.Name.ToString & ":" & SQL)
            'Tenta executar a exclusão
            Try
                'executa a sql
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar excluir alteração salarial!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAlterar.Click
        Dim a As Int16

        'pede confirmacao
        a = MsgBox("Tem certeza que deseja alterar os dados da alteração salarial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        'Se confirmar
        If a = vbYes Then
            'Com a grade de salarios
            With dgSalarios
                'transfere os valores do grid para as caixas de texto
                txtData.Text = .SelectedRows(0).Cells(1).Value.ToString
                txtSalario.Text = .SelectedRows(0).Cells(2).Value.ToString
                'Muda o texto do botão de Incluir para Salvar
                btIncluir.Text = "Salvar"
            End With
        End If
    End Sub

    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        Dim SQL As String, a As Int16, Sal As Double, n As Int16
        'Pega o ultimo salario e atualiza na ficha do funcionario
        a = MsgBox("Tem certeza que deseja transferir o último salário para a ficha do funcionário?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")

        'Se confirmar procede a troca
        If a = vbYes Then
            'Pega o último salario
            n = dgSalarios.Rows.Count - 1
            'Vai na ultima linha
            Sal = Val(dgSalarios.Rows(n).Cells(2).Value.ToString.Replace(",", "."))
            'Monta a SQL
            SQL = "UPDATE Funcionarios SET Salario=" & Sal & " WHERE id=" & cmbVal(cmbFuncionario)
            'debug
            Console.WriteLine(Me.Name.ToString & ":" & SQL)
            Try
                ExecutaSQL(SQL)
                MsgBox("Ficha do funcionário atualizada com sucesso", MsgBoxStyle.Information, "Sucesso")
                Exit Sub
            Catch ex As Exception
                MsgBox("Erro ao atualizar a ficha do funcionário" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub
End Class