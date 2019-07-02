Imports System.Windows.Forms.Calendar

Public Class frmPlanejamentoProducao

    Dim NovaData As Date

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub atualiza_datagrid()
        Dim DataINI As Date, DataFIM As Date
        DataINI = CDate(Mes.SelectionStart)
        DataFIM = CDate(Mes.SelectionEnd)

        If (chkAberto.Checked Or chkTodas.Checked) And (DataINI = DataFIM) Then
            Exit Sub
        End If

        Dim SQL As String
        'SQL = "SELECT id,Data,Tipo,Mercadoria,Clone,mudas,databaixa FROM Programacao WHERE data BETWEEN '" & Format(DataINI, "yyyy-MM-dd") & "' AND '" & Format(DataFIM, "yyyy-MM-dd") & "'"
        SQL = "SELECT `programacao`.`id`, `programacao`.`Data`, `programacao`.`Tipo`, `programacao`.`Mercadoria`, `programacao`.`Clone`, `mercadoria`.`Cientifico`, `fases`.`Fase`,`programacao`.`Mudas`, `programacao`.`DataBaixa` FROM mercadoria INNER JOIN programacao ON (`mercadoria`.`ID` = `programacao`.`Mercadoria`) INNER JOIN `Controle`.`fases` ON (`fases`.`ID` = `programacao`.`Fase`) WHERE `programacao`.`data` BETWEEN '" & Format(DataINI, "yyyy-MM-dd") & "' AND '" & Format(DataFIM, "yyyy-MM-dd") & "'"

        'Verifica no check box se são todas ou só as em aberto
        If chkAberto.Checked Then
            SQL &= " AND ISNULL(`programacao`.`Databaixa`)"
        End If

        'Cria ordenação por data
        SQL &= " ORDER BY `programacao`.`data`"

        'Troca a SQL para esta especícifica que lista todas em aberto
        If chkTodasAberto.Checked Then
            SQL = "SELECT `programacao`.`id`, `programacao`.`Data`, `programacao`.`Tipo`, `programacao`.`Mercadoria`, `programacao`.`Clone`, `mercadoria`.`Cientifico`, `fases`.`Fase`,`programacao`.`Mudas`, `programacao`.`DataBaixa` FROM mercadoria INNER JOIN programacao ON (`mercadoria`.`ID` = `programacao`.`Mercadoria`) INNER JOIN `Controle`.`fases` ON (`fases`.`ID` = `programacao`.`Fase`) WHERE ISNULL(`programacao`.`Databaixa`) ORDER BY `programacao`.`data`"
        End If
        'Se existe algum código digitado
        If txtIdOP.Text.Length > 3 Then
            SQL = "SELECT `programacao`.`id`, `programacao`.`Data`, `programacao`.`Tipo`, `programacao`.`Mercadoria`, `programacao`.`Clone`, `mercadoria`.`Cientifico`, `fases`.`Fase`,`programacao`.`Mudas`, `programacao`.`DataBaixa` FROM mercadoria INNER JOIN programacao ON (`mercadoria`.`ID` = `programacao`.`Mercadoria`) INNER JOIN `Controle`.`fases` ON (`fases`.`ID` = `programacao`.`Fase`) WHERE `programacao`.`id`=" & txtIdOP.Text
        End If

        Console.WriteLine("PlanejamentoProducao: " & SQL)

        Dim DT As DataTable
        DT = SQLQuery(SQL)
        dgOrdens.DataSource = DT
        Dim Nomes() As String = {"Cód.", "Data", "Tipo", "Prod", "Clone", "Nome", "Fase", "Mudas", "Baixa"}
        Dim Tamanho() As Integer = {60, 80, 40, 40, 50, 125, 80, 50, 80}
        Dim visivel() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1}
        Formata_Datagrid(dgOrdens, Nomes, Tamanho, visivel)

        With dgOrdens

            'formatos específicos para cada coluna
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "00000"
            End With
            With .Columns("data").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "dd/MM/yyyy"
            End With
            With .Columns("Tipo").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Mercadoria").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "000"
            End With
            With .Columns("Clone").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "0000"
            End With
            With .Columns("Mudas").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N0"
            End With
            With .Columns("databaixa").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "dd/MM/yyyy"
            End With
        End With
    End Sub

    Private Sub Mes_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles Mes.SelectionChanged
        atualiza_datagrid()
    End Sub

    Private Sub dgOrdens_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgOrdens.SelectionChanged
        If dgOrdens.SelectedRows.Count > 0 Then
            Atualiza_OP(dgOrdens.SelectedRows(0).Cells(0).Value)
        End If
    End Sub

    Private Sub Atualiza_OP(ByVal Id As Integer)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim SQL As String = String.Empty
        Dim resp As Integer = -1

        'confirma com o usuário se realmente quer excluir essa ordem de produção
        resp = MsgBox("Deseja realmente excluir esta Ordem de Produção", vbQuestion + vbYesNo, "Confirmação")
        'Se a Resposta for Sim então
        If resp = vbYes Then
            'Monta a SQL de exclusão
            SQL = "DELETE FROM Programacao WHERE id=" & dgOrdens.SelectedRows(0).Cells(0).Value
            Try
                ExecutaSQL(SQL)
                atualiza_datagrid()
            Catch ex As Exception
                MsgBox("Erro ao tentar excluir a Ordem de Produção" & vbCr & ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub chkTodas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTodas.CheckedChanged
        atualiza_datagrid()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim SQL As String = String.Empty
        Dim id As Integer = -1, resp As Integer = -1

        'Pegao número da ordem a ser baixada
        id = dgOrdens.SelectedRows(0).Cells(0).Value

        'Pede confirmação de baixa
        resp = MsgBox("Deseja realmente dar baixa na orde de produção Núm: " & id.ToString("0000000"), vbQuestion + vbYesNo, "Confirmação")

        'Se confimou então vai em frete
        If resp = vbYes Then
            Dim Baixa As String = InputBox("Digite a data da Baixa no formato 99/99/9999")
            'Se o usuário não cancelou
            If Baixa <> String.Empty Then
                SQL = "UPDATE Programacao SET databaixa='" & Format(CDate(Baixa), "yyyy-MM-dd") & "' WHERE id=" & id
                Try
                    ExecutaSQL(SQL)
                    atualiza_datagrid()
                Catch ex As Exception
                    MsgBox("Erro ao tentar Baixar a Ordem de Produção núm: " & id, vbCritical)
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Ativa o calendário
        calCalendario.Visible = True
    End Sub

    Private Sub calCalendario_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles calCalendario.DateChanged
        'Pega a data que foi clicada
        NovaData = calCalendario.SelectionStart
        'Esconde o calendário
        calCalendario.Visible = False
        'Pega a linha selecionada
        Dim id As Integer = dgOrdens.SelectedRows(0).Cells(0).Value, resp As Integer, SQL As String
        'Confirma com o usuario se quer reagendar
        resp = MsgBox("Confirma o Reagendamento da Ordem de Produção núm " & id & " para o dia " & NovaData, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
        'Verifica se quer reagendar
        If resp = vbYes Then
            SQL = "UPDATE Programacao SET Data='" & Format(NovaData, "yyyy-MM-dd") & "' WHERE id=" & id
            Try
                ExecutaSQL(SQL)
                atualiza_datagrid()
            Catch ex As Exception
                MsgBox("Erro ao tentar Reagendar a Ordem de Produção núm " & id, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim DR As DataRow, OP As Integer = -1
        Dim idOrdem As Integer = dgOrdens.SelectedRows(0).Cells(0).Value

        'Se houver algo válido digitado
        If Not IsDBNull(idOrdem) Then
            OP = idOrdem
            'Coloca o cursor em posição de espera
            Me.Cursor = Cursors.WaitCursor
            Try
                'Pega os dados da Ordem de Produção e Preenche na ficha
                DR = DLookupRow("programacao", "id=" & Int(OP))
                'Se não achou nada e DR está vazio sai da rotina
                If IsDBNull(DR) Or IsNothing(DR) Then
                    MsgBox("Não foi possível localizar a Ordem de Produção Nº: " & OP, MsgBoxStyle.Critical + vbOKOnly, "Erro")
                    Me.Cursor = Cursors.Arrow
                End If
            Catch ex As Exception
                MsgBox("Erro ao tentar localizar a ordem de produção" & vbCrLf & ex.Message, MsgBoxStyle.Critical + vbOKOnly, "Erro")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try

            If DR("Tipo") = "R" Then            'Se for uma ordem de Produção (R)epicagem
                Dim child As New frmLotes(OP)
                child.MdiParent = Me
                'Mostra o formulário
                child.Show()
                Me.Cursor = Cursors.Arrow
            ElseIf DR("Tipo") = "P" Then        'Se por uma ordem de (P)lantio
                Dim child As New frmPlantio(OP)
                child.MdiParent = Me
                'Mostra o formulário
                child.Show()
            ElseIf DR("Tipo") = "G" Then        'Se for uma ordem (G)eral
                Dim a As String
                a = InputBox("Esta é uma ordem de Serviços Direta." & vbCrLf & "Digite a data da Baixa no campo abaixo para concluir esta Ordem de Serviço", "Data da Baixa")
                'Se o usuário colocou alguma informação
                If a <> String.Empty Then
                    ExecutaSQL("UPDATE Programacao SET DataBaixa='" & Format(CDate(a), "yyyy-MM-dd") & "' WHERE id=" & OP)
                    MsgBox("Ordem de produção concluída com sucesso!")
                    Me.Cursor = Cursors.Arrow
                End If
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim win As New frmProgramacaoSemanal
        win.MdiParent = Me.MdiParent
        win.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim Id As Integer = dgOrdens.SelectedRows(0).Cells(0).Value
        Dim win As New frmProgramacaoSemanal(Id)
        win.MdiParent = Me.MdiParent
        win.Show()
    End Sub


    Private Sub rdTodasAberto_Click(sender As Object, e As EventArgs) Handles chkTodasAberto.Click
        atualiza_datagrid()
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btProcura.Click
        atualiza_datagrid()
    End Sub
End Class