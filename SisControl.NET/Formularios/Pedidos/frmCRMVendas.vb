Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCRMVendas

    Private Sub frmCRMVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgNegocios.RowsDefaultCellStyle.BackColor = Color.White
        dgNegocios.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Atualiza_Grid()
    End Sub

    Private Sub Atualiza_Grid()
        Dim Textos() As String = {"Status", "id", "Titulo", "Cliente", "Empresa", "Fone", "E-mail", "Ult. Atualização"}
        Dim Tamanhos() As Integer = {30, 40, 180, 180, 60, 90, 160, 100}
        Dim visivel() As Integer = {1, 1, 1, 1, 1, 1, 1, 1}
        Dim lin As Integer
        Dim SQL As String = String.Empty
        Dim dt As DataTable

        'Se existe alguma linha selecionada, guarda o número da linha
        'Guarda a posição atual para poder voltar na mesma posição
        If dgNegocios.Rows.Count > 0 Then
            lin = dgNegocios.CurrentRow.Index
        Else
            lin = 0
        End If

        'Define a SQL de seleção
        SQL = "SELECT status,id,titulo,cliente,empresa,fone,email,atualizacao FROM Negocios WHERE Status < 5"
        'Recupera os dados
        dt = SQLQuery(SQL)
        'Atribui a nova tabela de dados ao datagrid
        dgNegocios.DataSource = dt

        'Função genérica para formatar o datagrid nas larguras e cabeçalhos
        Formata_Datagrid(dgNegocios, Textos, Tamanhos, visivel)

        'Define os formatos dos números
        'formatos específicos para cada coluna
        With dgNegocios
            With .Columns("status").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "00000"
                .ForeColor = Color.Gray
            End With
            With .Columns("atualizacao").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
                .Format = "dd/MM/yyyy"
            End With
        End With

        'Retorna à linha que estava antes de atualizar o banco de dados
        dgNegocios.CurrentCell = dgNegocios.Rows(lin).Cells(1)
    End Sub


    Private Sub btImprimir_Click(sender As Object, e As EventArgs)
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "pedNegocios.rpt"

        Me.Cursor = Cursors.WaitCursor

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)

            Dim PrinterName As String
            Dim ePage As Integer
            Dim sPage As Integer
            Dim nCopy As Integer

            'Pede para selecionar a impressora
            PrintDialog1.Document = PrintDocument1
            Dim DR As DialogResult = PrintDialog1.ShowDialog()

            'Se der tudo certo
            If DR = DialogResult.OK Then
                'Quantas Cópias
                nCopy = PrintDialog1.PrinterSettings.Copies
                'Número da Página inicial (0=todas)
                sPage = 0
                'Numero final igual a Zero imprime todas
                ePage = 0
                'Pega o nome da impressora
                PrinterName = PrintDocument1.PrinterSettings.PrinterName
                'Define o nome da impressora
                CR.PrintOptions.PrinterName = PrinterName
                'Manda o relatório para impressoa
                CR.PrintToPrinter(nCopy, False, sPage, ePage)
            Else
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            Me.Cursor = Cursors.Arrow
            MsgBox("Lista de Negócios enviada para impressão.", MsgBoxStyle.Information, "Confirmação")
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar a lista de negócios para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub dgNegocios_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgNegocios.RowPrePaint
        If Not IsDBNull(dgNegocios.Rows(e.RowIndex).Cells("Status").Value) Then
            dgNegocios.Rows(e.RowIndex).Cells("status").Style.BackColor = Cor_Negocio(dgNegocios.Rows(e.RowIndex).Cells("Status").Value)
        End If
    End Sub

    Private Function Cor_Negocio(ByVal Status As String) As System.Drawing.Color
        Select Case Status
            Case "1"
                'Oportunidade (1) - Azul Claro
                Return Color.LightCyan
            Case "2"
                'Contato (2) - Amarelo
                Return Color.Yellow
            Case "3"
                'Proposta (3) - Amarelo Esverdeado
                Return Color.GreenYellow
            Case "4"
                'Negociação (4) - Verde Claro
                Return Color.LightGreen
            Case "5"
                'Ganho (5) - Verde
                Return Color.Green
            Case "6"
                'Perdido (6) - Vermelho
                Return Color.Red
            Case Else
                'Se não for nenhum destes acima
                Return Color.White
        End Select
    End Function

    Private Sub dgNegocios_SelectionChanged(sender As Object, e As EventArgs) Handles dgNegocios.SelectionChanged
        If dgNegocios.SelectedRows.Count >= 1 Then
            Atualiza_Eventos()
        End If
    End Sub

    Private Sub Atualiza_Eventos()
        Dim sql As String = String.Empty
        sql = "SELECT evento,id,data,tipo,observacao FROM negocios_eventos WHERE evento=" & dgNegocios.SelectedRows(0).Cells(1).Value & " ORDER BY data"
        Dim dtEv As DataTable = SQLQuery(sql)
        dgEventos.DataSource = dtEv

        Dim Textos() As String = {"Evento", "id", "Data", "Tipo", "Observação"}
        Dim Tamanhos() As Integer = {0, 40, 80, 100, 600}
        Dim visivel() As Integer = {0, 1, 1, 1, 1}

        Formata_Datagrid(dgEventos, Textos, Tamanhos, visivel)

        'Define os formatos dos números
        'formatos específicos para cada coluna
        With dgEventos
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "00000"
                .ForeColor = Color.Gray
            End With
            With .Columns("data").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
                .Format = "dd/MM/yyyy"
            End With
        End With
    End Sub

    Private Function EnviarEmail(ByVal EmailAddress As String, Optional ByVal Subject As String = "", Optional ByVal Body As String = "") As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams &
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If

        Try
            System.Diagnostics.Process.Start(sParams)
        Catch
            bAns = False
        End Try
        Return bAns
    End Function

    Private Sub EnviarEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarEmailToolStripMenuItem.Click
        EnviarEmail(dgNegocios.SelectedRows(0).Cells("email").Value, "Mudas")
    End Sub

    Private Sub PesquisarEmailsEnviadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesquisarEmailsEnviadosToolStripMenuItem.Click
        'Historico de e-mails no GMail
        Dim Pesquisa As String = "https://mail.google.com/mail/u/0/#search/"

        Process.Start(Pesquisa & dgNegocios.SelectedRows(0).Cells("email").Value)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim Tela As New frmNegocio
        Tela.MdiParent = Me.MdiParent
        Tela.Show()
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Dim Tela As New frmNegocio(dgNegocios.SelectedRows(0).Cells("id").Value)
        Tela.MdiParent = Me.MdiParent
        Tela.Show()
    End Sub

    Private Sub tsBarraFerramentas_Click(sender As Object, e As EventArgs) Handles tsBarraFerramentas.Click
        pnlEvento.Visible = True
        txtData.Value = Now.Date()
        txtTipo.Text = ""
        txtRegistro.Text = ""
    End Sub

    Private Sub btAddEvento_Click(sender As Object, e As EventArgs) Handles btAddEvento.Click
        Dim sql As String = String.Empty

        sql = "INSERT INTO negocios_eventos SET "

        sql &= "Evento=" & dgNegocios.SelectedRows(0).Cells("id").Value & ","
        sql &= "Data='" & Format(txtData.Value, "yyyy-MM-dd") & "',"
        sql &= "tipo='" & txtTipo.Text & "',"
        sql &= "Observacao='" & txtRegistro.Text & "'"

        Try
            ExecutaSQL(sql)
            'Atualiza a data da última interação
            sql = "UPDATE negocios SET Atualizacao=current_timestamp() WHERE id=" & dgNegocios.SelectedRows(0).Cells("id").Value
            ExecutaSQL(sql)
            pnlEvento.Visible = False
            Atualiza_Eventos()
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir o evento" & vbCr & ex.Message, "Erro")
            pnlEvento.Visible = False
            Exit Sub
        End Try
    End Sub

    Private Sub Altera_Status(ByVal newStatus As Short)
        Dim SQL As String = String.Empty
        Dim motivo As String = String.Empty

        Dim a As Integer = MsgBox("Confirma a alteração de status do Negócio " & dgNegocios.SelectedRows(0).Cells("id").Value & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")

        If a = vbYes Then
            'Se registrar a perda de um negócio deve informar o motivo
            If newStatus = 6 Then
                motivo = InputBox("Informe resumidamente o motivo da perda do negócio", "Motivo da Perda")
            End If
            SQL = "UPDATE negocios SET Status=" & newStatus & ", atualizacao=current_timestamp()"
            'Se for uma perda, registra também o motivo da perda
            If newStatus = 6 Then
                SQL &= ",perda_motivo='" & motivo & "'"
            End If
            SQL &= " WHERE id=" & dgNegocios.SelectedRows(0).Cells("id").Value
            'Tenta fazer a inclusão no banco de dados
            Try
                ExecutaSQL(SQL)
                'se deu certo cria também um evento
                SQL = "INSERT INTO negocios_eventos SET Evento=" & dgNegocios.SelectedRows(0).Cells("id").Value & ", data=current_date(),Tipo='Status',Observacao='Status do negócio alterado de " & dgNegocios.SelectedRows(0).Cells("status").Value & " para " & newStatus & "'"
                'Executa esta SQL
                ExecutaSQL(SQL)
                'Refaz o grid com as novas informações
                Atualiza_Grid()
            Catch ex As Exception
                MsgBox("Erro ao atualizar Status do Negócio" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub OportunidadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OportunidadeToolStripMenuItem.Click
        Altera_Status(1)
    End Sub

    Private Sub ContatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContatoToolStripMenuItem.Click
        Altera_Status(2)
    End Sub

    Private Sub PropostaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropostaToolStripMenuItem.Click
        Altera_Status(3)
    End Sub

    Private Sub NegociaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegociaçãoToolStripMenuItem.Click
        Altera_Status(4)
    End Sub

    Private Sub GanhoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GanhoToolStripMenuItem.Click
        Altera_Status(5)
    End Sub

    Private Sub PerdidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerdidoToolStripMenuItem.Click
        Altera_Status(6)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub ToolStripContainer1_LeftToolStripPanel_Click(sender As Object, e As EventArgs) Handles ToolStripContainer1.LeftToolStripPanel.Click
    End Sub
End Class