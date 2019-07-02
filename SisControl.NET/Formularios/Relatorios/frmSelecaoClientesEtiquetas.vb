Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSelecaoClientesEtiquetas

    Private Sub frmSelecaoClientesEtiquetas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Carrega a lista de clientes que podem ser escolhidos
        Carrega_Lista(lstClientes, "Clientes", "id", "Nome", True)
        Carrega_Lista(lstNFe, "idNFe", "id", "Item")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'cursor de espera
        Me.Cursor = Cursors.WaitCursor
        lblInfo.Text = "Atualizando Banco de Dados..."
        lblInfo.Refresh()
        'primeiro atualiza o banco de dados
        atualiza_banco_dados()
        'Depois tenta imprimir o relatório

        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "rptEtiquetas_Clientes.rpt"

        lblInfo.Text = "Localizando relatório..."
        lblInfo.Refresh()
        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            lblInfo.Text = ""
            lblInfo.Refresh()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument

            lblInfo.Text = "Montando etiquetas..."
            lblInfo.Refresh()

            CR.Load(strReportPath)
            Dim PrinterName As String
            Dim ePage As Integer
            Dim sPage As Integer
            Dim nCopy As Integer


            lblInfo.Text = "Selecionando impressora..."
            lblInfo.Refresh()
            'Pede para selecionar a impressora
            PrintDialog1.Document = PrintDocument1
            Dim DR As DialogResult = PrintDialog1.ShowDialog()
            'Se der tudo certo
            If DR = DialogResult.OK Then
                'Quantas Cópias
                nCopy = 1
                'Número da Página inicial (0=todas)
                sPage = 0
                'Numero final igual a Zero imprime todas
                ePage = 0
                'Pega o nome da impressora
                PrinterName = PrintDocument1.PrinterSettings.PrinterName
                'Define o nome da impressora
                CR.PrintOptions.PrinterName = PrinterName
                'Manda o relatório para impressoa
                lblInfo.Text = "Enviando para impressora..."
                lblInfo.Refresh()
                CR.PrintToPrinter(nCopy, False, sPage, ePage)
            Else
                lblInfo.Text = ""
                Me.Cursor = Cursors.Arrow
            End If
            'confirma que deu tudo certo
            lblInfo.Text = ""
            MsgBox("Etiquetas impressas com sucesso", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o pedido para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            lblInfo.Text = ""
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub atualiza_banco_dados()
        Dim SQL As String, IDs As String = ""

        'Limpa todas as selecoes antigas
        SQL = "UPDATE Clientes SET mark=0"
        ExecutaSQL(SQL)

        'Pega todos os ítens marcados
        For i As Integer = 0 To lstClientes.Items.Count - 1
            'Se o ítem estiver marcado
            If lstClientes.GetItemChecked(i) Then
                'Se já for o segundo ítem
                If IDs.Length > 0 Then
                    'Acrescenta uma vírgula
                    IDs &= ","
                End If
                'Pega o ID para fazer a lista
                IDs &= CType(lstClientes.Items(i), MeuItemData).Valor.ToString
            End If
        Next

        'Se não foi selecionado nenhum cliente então não gera a SQL
        If IDs = String.Empty Then
            Exit Sub
        End If

        Try
            'Depois marca no banco de dados os selecionados
            SQL = "UPDATE Clientes SET mark=1 WHERE id IN(" & IDs & ")"
            Console.WriteLine("Sel Clientes: " & SQL)
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar selecionar os clientes no banco de dados" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub msg(ByVal Texto As String)
        lblInfo.Text = Texto
        lblInfo.Refresh()
    End Sub

    Private Sub remove_etiquetas_antigas()
        Dim SQL As String
        'Apaga todas as etiquetas geradas anteriormente
        SQL = "DELETE FROM encomendas_prn"

        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar limpar a tabela de Etiquetas..." & vbCr & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub btEncomendas_Click(sender As System.Object, e As System.EventArgs) Handles btEncomendas.Click
        'cursor de espera
        Me.Cursor = Cursors.WaitCursor
        
        msg("Apagando Registros Anteriores...")
        remove_etiquetas_antigas()

        'primeiro atualiza o banco de dados
        msg("Atualizando Banco de Dados de Clientes...")
        atualiza_banco_dados()  'Clientes selecionados

        'Monta as etiquetas
        Monta_Etiquetas_Clientes()
        Monta_Etiquetas_NFe()

        'Depois tenta imprimir o relatório
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "rptEtiquetas_Encomenda.rpt"

        msg("Localizando arquivo de Relatório...")

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            msg("")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument

            msg("Montando etiquetas...")

            CR.Load(strReportPath)
            Dim PrinterName As String
            Dim ePage As Integer
            Dim sPage As Integer
            Dim nCopy As Integer

            msg("Selecionando impressora...")

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
                msg("Enviando para impressora " & nCopy & " cópia(s)...")

                CR.PrintToPrinter(nCopy, False, sPage, ePage)
            Else
                lblInfo.Text = ""
                Me.Cursor = Cursors.Arrow
            End If

            'confirma que deu tudo certo
            lblInfo.Text = ""
            lblInfo.Refresh()
            MsgBox("Etiquetas impressas com sucesso", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o pedido para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            msg("")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Monta_Etiquetas_Clientes()
        'Monta as etiquetas com base nos clientes selecionados e nas NFEs Selecionadas
        Dim SQL As String, DT As DataTable, DR As DataRow, SQL_Inc As String = ""
        'Primeiro para os clientes selecionados
        msg("Reunindo Etiquetas de Clientes Selecionados...")
        SQL = "SELECT * FROM clientes WHERE Mark=1"
        Try
            DT = SQLQuery(SQL)
            'Se retornou alguma linha
            If DT.Rows.Count > 0 Then
                'Define a SQL Base
                SQL_Inc = "INSERT INTO encomendas_prn (Nome,Endereco,Cidade,Estado,CEP,Pais,Peso,num_volume,Volumes,Documento) VALUES "
                'Para cada linha de dados na tabela de clientes
                Dim ct As Boolean = False
                For Each DR In DT.Rows
                    With DR
                        'Acrescenta uma vírgula após a primeira inclusão
                        If ct Then
                            SQL_Inc &= ","
                        End If
                        'Monta a SQL de inclusão
                        SQL_Inc &= "('" & .Item("Nome") & "', '" & .Item("Endereco") & ", " & .Item("Num") & "', '" & .Item("Cidade") & "', '" & .Item("Estado") & "','" & .Item("CEP") & "', '" & .Item("Pais") & "',0.000,01,01,'---')"
                        'Define que tem mais de um ítem
                        ct = True
                    End With
                Next
                'Terminado de montar a SQL de inclusão, tenta atualizar o banco de dados
                msg("Incluindo Etiquetas de Clientes Selecionados...")
                Console.WriteLine("Etiquetas Clientes Selecionados: " & SQL_Inc)
                ExecutaSQL(SQL_Inc)
            End If
        Catch ex As Exception
            MsgBox("Erro ao recuperar clientes marcados" & vbCr & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub Monta_Etiquetas_NFe()
        'Percorre o checklist pegando o ID das notas que foram selecionadas
        Dim SQL As String, IDs As String = "", DT As DataTable, DR As DataRow, SQL_Inc As String = ""

        'Pega todos os ítens marcados
        For i As Integer = 0 To lstNFe.Items.Count - 1
            'Se o ítem estiver marcado
            If lstNFe.GetItemChecked(i) Then
                'Se já for o segundo ítem
                If IDs.Length > 0 Then
                    'Acrescenta uma vírgula
                    IDs &= ","
                End If
                'Pega o ID para fazer a lista
                IDs &= CType(lstNFe.Items(i), MeuItemData).Valor.ToString
            End If
        Next

        'Se não foi selecionado nenhum cliente então não gera a SQL
        If IDs = String.Empty Then
            Exit Sub
        End If

        'Se foi selecionado algo então processa a lista
        SQL = "SELECT * FROM docs_volumes WHERE Doc_Id IN(" & IDs & ")"
        Try
            'Procura no banco de dados se retornou algo
            DT = SQLQuery(SQL)
            'Se retornou algo do Banco de Dados
            If DT.Rows.Count > 0 Then
                'Define a SQL Base
                SQL_Inc = "INSERT INTO encomendas_prn (Nome,Endereco,Cidade,Estado,CEP,Pais,Peso,num_volume,Volumes,Documento,L,A,P) VALUES "
                'Para cada linha de dados na tabela de volumes
                Dim ct As Boolean = False
                For Each DR In DT.Rows
                    'Pega as informações do cliente para esse volume
                    Dim InfoCli As DataRow = DLookupRow("docs", "id=" & DR.Item("Doc_Id"))
                    With DR
                        'Acrescenta uma vírgula após a primeira inclusão
                        If ct Then
                                SQL_Inc &= ","
                            End If
                        'Monta a SQL de inclusão
                        SQL_Inc &= "('" & InfoCli.Item("Cliente") & "', '" & InfoCli.Item("Endereco") & ", " & InfoCli.Item("Num") & "', '" & InfoCli.Item("Cidade") & "', '" & InfoCli.Item("Estado") & "','" & InfoCli.Item("CEP") & "', '" & InfoCli.Item("Pais") & "'," & Numero_to_SQL(.Item("Peso")) & "," & .Item("Volume") & ", " & InfoCli.Item("traQtde") & ",'" & Format(.Item("Doc_Id"), "000000") & "'," & Numero_to_SQL(.Item("Largura")) & "," & Numero_to_SQL(.Item("Altura")) & "," & Numero_to_SQL(.Item("Profundidade")) & ")"
                        'Define que tem mais de um ítem
                        ct = True
                    End With
                Next
                'Terminado de montar a SQL de inclusão, tenta atualizar o banco de dados
                msg("Incluindo Etiquetas de Clientes Selecionados...")
                Console.WriteLine("Etiquetas Clientes Selecionados: " & SQL_Inc)
                ExecutaSQL(SQL_Inc)
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar os dados das NFes Selecionadas" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            msg("")
            Exit Sub
        End Try

    End Sub
End Class