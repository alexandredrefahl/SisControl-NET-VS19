Public Class frmAltSalarial

    Private Sub frmAltSalarial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ao carregar, seleciona lista de funcion�rios
        Carrega_Lista(cmbFuncionario, "Funcionarios", "id", "Nome", True)


    End Sub

    Private Sub cmbFuncionario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFuncionario.SelectedIndexChanged
        'Atualiza o datagrid
        Atualiza_Datagrid(cmbVal(cmbFuncionario))

        'Se houverem atualiza��es, posso alterar
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

        'Ao Alterar o funcion�rio seleciona os itens
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

        'Se o bot�o estiver alterado pela rotina de altera��o
        If btIncluir.Text = "Salvar" Then
            With dgSalarios.SelectedRows(0)
                SQL = "UPDATE RHAltSalarios SET Data='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "',Valor=" & txtSalario.Text.Replace(",", ".") & " WHERE id=" & .Cells(0).Value.ToString
                Console.WriteLine(Me.Name.ToString & ":" & SQL)
            End With
            Try
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar o sal�rio do funcion�rio!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
            'Retorna o bot�o ao normal
            btIncluir.Text = "Adicionar"
            txtData.Text = String.Empty
            txtSalario.Text = String.Empty
            'Atuzaliza o Datagrid
            Atualiza_Datagrid(cmbVal(cmbFuncionario))
            'Sai antes que cause uma nova inclus�o
            Exit Sub
        End If

        '                                         ID ,          CodFunc,                  Data,                                              Valor
        SQL = "INSERT INTO RHAltSalarios VALUES (NULL," & cmbVal(cmbFuncionario) & ",'" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "'," & txtSalario.Text.Replace(",", ".") & ")"
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o sal�rio do funcion�rio!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        txtSalario.Text = String.Empty
        txtData.Text = String.Empty
        Atualiza_Datagrid(cmbVal(cmbFuncionario))

    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        Dim SQL As String, a As Integer
        'Pede confirma��o
        a = MsgBox("Tem certeza de que deseja excluir este lan�amento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
        'Se confirmou ent�o vai adiante
        If a = vbYes Then
            'monta a SQL para fazer a exclus�o
            SQL = "DELETE FROM RHAltSalarios WHERE id=" & dgSalarios.SelectedRows(0).Cells(0).Value
            'informa��o para debug
            Console.WriteLine(Me.Name.ToString & ":" & SQL)
            'Tenta executar a exclus�o
            Try
                'executa a sql
                ExecutaSQL(SQL)
            Catch ex As Exception
                MsgBox("Erro ao tentar excluir altera��o salarial!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAlterar.Click
        Dim a As Int16

        'pede confirmacao
        a = MsgBox("Tem certeza que deseja alterar os dados da altera��o salarial?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
        'Se confirmar
        If a = vbYes Then
            'Com a grade de salarios
            With dgSalarios
                'transfere os valores do grid para as caixas de texto
                txtData.Text = .SelectedRows(0).Cells(1).Value.ToString
                txtSalario.Text = .SelectedRows(0).Cells(2).Value.ToString
                'Muda o texto do bot�o de Incluir para Salvar
                btIncluir.Text = "Salvar"
            End With
        End If
    End Sub

    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        Dim SQL As String, a As Int16, Sal As Double, n As Int16
        'Pega o ultimo salario e atualiza na ficha do funcionario
        a = MsgBox("Tem certeza que deseja transferir o �ltimo sal�rio para a ficha do funcion�rio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")

        'Se confirmar procede a troca
        If a = vbYes Then
            'Pega o �ltimo salario
            n = dgSalarios.Rows.Count - 1
            'Vai na ultima linha
            Sal = Val(dgSalarios.Rows(n).Cells(2).Value.ToString.Replace(",", "."))
            'Monta a SQL
            SQL = "UPDATE Funcionarios SET Salario=" & Sal & " WHERE id=" & cmbVal(cmbFuncionario)
            'debug
            Console.WriteLine(Me.Name.ToString & ":" & SQL)
            Try
                ExecutaSQL(SQL)
                MsgBox("Ficha do funcion�rio atualizada com sucesso", MsgBoxStyle.Information, "Sucesso")
                Exit Sub
            Catch ex As Exception
                MsgBox("Erro ao atualizar a ficha do funcion�rio" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub
End Class