Imports System.IO
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmManutPedidos

    'Defini��o de vari�veis globais
    Dim Lin As Integer

    Private Sub frmManutPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega lista dos clientes
        Carrega_Lista(cmbCliente, "Clientes", "id", "Nome", True)
        btSalvar.Enabled = False
        dgPedidos.RowsDefaultCellStyle.BackColor = Color.White
        dgPedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'Coloca o ano corrente
        txtAno.Value = Year(Today)
        Atualiza_grid()
    End Sub

    Private Sub Atualiza_grid()
        'Se existe alguma linha selecionada, guarda o n�mero da linha
        'Guarda a posi��o atual para poder voltar na mesma posi��o
        If dgPedidos.Rows.Count > 0 Then
            Lin = dgPedidos.CurrentRow.Index
        Else
            Lin = 0
        End If

        Dim SQL As String, DT As DataTable, Condicao As String = ""
        'Monta a SQL Base
        SQL = "SELECT * FROM pedidos_completo"
        'Verifica nos filtros o que est� selecionado
        If cmbStatus.Text.Length > 0 Then
            If cmbStatus.Text.Substring(0, 1) <> "T" Then
                Condicao &= "Status=" & cmbStatus.Text.Substring(0, 1)
            End If
        End If
        'Verifica se a data Est� selecionada
        If chkData.Checked Then
            If Condicao.Length > 0 Then
                Condicao &= " AND "
            End If
            Condicao &= "(Data BETWEEN '" & Format(CDate(txtDataINI.Text), "yyyy-MM-dd") & "' AND '" & Format(CDate(txtDataFIM.Text), "yyyy-MM-dd") & "')"
        Else    'Se n�o selecionou a data ent�o usa o ano do pedido
            If Condicao.Length > 0 Then
                Condicao &= " AND "
            End If
            Condicao &= "(YEAR(Data)=" & txtAno.Value & ")"
        End If
        'Se o Cliente est� selecionado
        If cmbCliente.Text.Length > 0 Then
            If Condicao.Length > 0 Then
                Condicao &= " AND "
            End If
            Condicao &= "(CodCli=" & cmbVal(cmbCliente) & ")"
        End If
        'Se alguma das condi��es foi preenchida
        If Condicao.Length > 0 Then
            SQL &= " WHERE " & Condicao
        End If
        'Preenche a lista dos pedidos
        SQL &= " ORDER BY id"
        'Busca no banco de dados.
        Try
            DT = SQLQuery(SQL)
            'Confere se retornou algum resultado Sen�o j� sai da sub
            If DT.Rows.Count <= 0 Then
                'Se n�o retornou nada sai da sub.
                Exit Sub
            End If
            dgPedidos.DataSource = DT
            Formata_Grid()
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar dados dos pedidos!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub Formata_Grid()
        Dim Textos() As String = {"N�", "Data", "Cod", "Cliente", "CNPJ/CPF", "N� Itens", "N� Mudas", "Valor", "FP", "ST"}
        Dim Larguras() As Integer = {40, 72, 30, 140, 110, 45, 45, 60, 30, 30}
        Dim Visiveis() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        Dim i As Int16 = 0
        Formata_Datagrid(dgPedidos, Textos, Larguras, Visiveis)

        'Define os formatos dos n�meros
        'formatos espec�ficos para cada coluna
        With dgPedidos
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "00000"
            End With
            With .Columns("Data").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "dd/MM/yyyy"
            End With
            With .Columns("nMudas").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N0"
            End With
            With .Columns("Valor").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            With .Columns("forpag").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0"
            End With
            With .Columns("status").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0"
            End With
        End With

        'Retorna � linha que estava antes de atualizar o banco de dados
        dgPedidos.CurrentCell = dgPedidos.Rows(Lin).Cells(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub dgPedidos_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgPedidos.RowPrePaint
        If Not IsDBNull(dgPedidos.Rows(e.RowIndex).Cells("Status").Value) Then
            dgPedidos.Rows(e.RowIndex).Cells("status").Style.BackColor = Cor_Pedido(dgPedidos.Rows(e.RowIndex).Cells("Status").Value)
        End If
    End Sub

    Private Sub btEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEmail.Click

        Dim PedidoID As Integer
        PedidoID = dgPedidos.SelectedRows(0).Cells("id").Value

        Dim email = DLookup("email", "Pedidos", "id=" & PedidoID)
        If email = String.Empty Then
            MsgBox("Este pedido n�o tem nenhum e-mail cadastrado junto a ele. N�o ser� poss�vel fazer a transmiss�o!", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        'Dimensiona vari�veis usadas no cabe�alho do e-mail
        Dim mlFrom As String
        Dim mlTO As String
        Dim mlCC As String
        Dim mlSubject As String
        Dim mlBody As String = String.Empty
        Dim mlSMTP As String

        'Preenche os dados de envio
        mlFrom = E_MailFrom
        mlTO = email
        mlCC = "alexandre@clona-gen.com.br"
        mlSubject = "Confirma��o do Pedido #" & Format(PedidoID, "00000") & " � Clona-Gen Biotecnologia Vegetal"
        mlSMTP = E_MailServer

        Dim i As Integer = 0

        'valida��o dos dados
        If mlSMTP = "" Then
            MsgBox("Informe o nome do servidor SMTP", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
            Me.Cursor = Cursors.Arrow
        End If
        If mlFrom = "" Then
            MsgBox("Informe o endere�o de Origem", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
            Me.Cursor = Cursors.Arrow
        End If
        If mlTO = "" Then
            MsgBox("Informe o endere�o de destino", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
            Me.Cursor = Cursors.Arrow
        End If
        If mlSubject = "" Then
            MsgBox("Informe o assunto do email", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
            Me.Cursor = Cursors.Arrow
        End If

        Dim Mailmsg As New System.Net.Mail.MailMessage()

        'endereca o recipiente
        Mailmsg.To.Add(New MailAddress(mlTO))
        Mailmsg.CC.Add(New MailAddress(mlCC))
        Mailmsg.From = New MailAddress(mlFrom)
        Mailmsg.ReplyToList.Add(New MailAddress(mlFrom))

        Dim mSmtpCliente As New SmtpClient(mlSMTP)
        'Especifica o formato 
        Mailmsg.IsBodyHtml = True
        'define o assunto
        Mailmsg.Subject = mlSubject

        'ANEXA UMA C�PIA DO PDF DO PEDIDO AO E-MAIL

        'Cria o caminho base para os arquivos de relat�rio
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "crPedido.rpt"
        Dim ArquivoPDF As String
        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relat�rio n�o localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        Try
            'instancia o relatorio e carrega
            Dim CR As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            'Carrega o relatorio
            CR.Load(strReportPath)
            'Define o parameter field
            CR.SetParameterValue("Id_Pedido", PedidoID)
            'Define os parametros de exporta��o
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            ArquivoPDF = System.Environment.GetEnvironmentVariable("Temp").ToString & "\" & "Clona-Gen_Pedido_" & Format(PedidoID, "0000") & ".pdf"
            'ArquivoPDF = "C:" & "\" & "Clona-Gen_Pedido_" & Format(PedidoID, "0000") & ".pdf"
            CrDiskFileDestinationOptions.DiskFileName = ArquivoPDF
            CrExportOptions = CR.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            'Exporta o r�lat�rio em PDF
            CR.Export()
        Catch ex As Exception
            MsgBox("Erro ao tentar gerar o PDF do Pedido para Anexar ao E-mail." & vbCrLf & ex.Message, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        'Anexa o PDF ao e-mail
        Mailmsg.Attachments.Add(New Attachment(ArquivoPDF))

        'Corpo do EMail
        Mailmsg.Body = Gera_Body()

        'ENvia o email
        mSmtpCliente.Timeout = 40000
        Dim credential As New System.Net.NetworkCredential(E_MailUser, E_MailPass)
        mSmtpCliente.Credentials = credential
        Try
            mSmtpCliente.Send(Mailmsg)
            MsgBox("Pedido N� " & Format(PedidoID, "0000") & " Enviado por E-mail com sucesso", MsgBoxStyle.Information, "Confirma��o")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o pedido por e-mail" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Function Gera_Body() As String
        Dim Body As String = String.Empty
        Dim SQL As String = String.Empty
        Dim pedidoID As Integer, DR As DataRow, DTItens As DataTable

        'Verifica se o arquivo de modelo est� dispon�vel na pasta
        Dim strModeloPath As String = My.Application.Info.DirectoryPath & "\modelos\envio_pedido.html"
        Dim strModeloLinha As String = My.Application.Info.DirectoryPath & "\modelos\linha_produtos.html"

        'Verifica a exist�ncia do arquivo de modelo
        If Not IO.File.Exists(strModeloPath) Then
            MsgBox("Arquivo de modelo de e-mail n�o encontrado :" & vbCrLf & strModeloPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Return String.Empty
        End If

        'Pega o ID do pedido
        pedidoID = dgPedidos.SelectedRows(0).Cells(0).Value
        'Pega a linha de dados do pedido
        DR = DLookupRow("pedidos", "id=" & pedidoID)

        '**
        '*  DADOS DO PEDIDO
        '**
        If Not IsDBNull(DR) Then

            'Dimensiona as vari�veis que v�o pegar as informa��es
            Dim varPedido As String = Format(pedidoID, "00000")
            Dim varCodigo As String = Format(DR.Item("CodCli"), "0000")
            Dim varEndereco As String = DR.Item("Endereco")
            Dim varContato As String = NaoNulo(DR.Item("Contato"))
            Dim varCliente As String = DR.Item("Cliente")
            Dim varCidade As String = NaoNulo(DR.Item("Cidade"))
            Dim varEmail As String = DR.Item("Email")
            Dim varCPF_CNPJ As String = DR.Item("CNPJ_CPF")
            Dim varEstado As String = DR.Item("Estado")
            Dim varFone As String = NaoNulo(DR.Item("Fone"))
            Dim varData As String = Format(DR.Item("data"), "dd/MM/yyyy")
            Dim varNumMudas As String = Format(DR.Item("NMudas"), "N0")
            Dim totalMerc As String = Format(DR.Item("valor"), "N2")
            Dim varDesconto As String = Format(DR.Item("valDesconto"), "N2")
            Dim varFrete As String = Format(DR.Item("valFrete"), "N2")
            Dim varTotalPed As String = Format(DR.Item("valor") + DR.Item("valFrete") + DR.Item("valSeguro") - DR.Item("valDesconto"), "N2")
            Dim varProdutos As String = String.Empty
            Dim varTotalMerc As Integer = 0

            '**
            '*  DADOS DOS PRODUTOS
            '**
            SQL = "SELECT id,codpro,clone,descricao,ncm,quantidade,unitario,total FROM pedidos_itens WHERE pedido_id=" & pedidoID
            DTItens = SQLQuery(SQL)

            If DTItens.Rows.Count > 0 Then
                Dim i As Integer = 0

                '* ITENS DO PEDIDO
                For i = 0 To DTItens.Rows.Count - 1
                    With DTItens.Rows(i)
                        Dim Linha_Produto As String = File.ReadAllText(strModeloLinha)
                        'Substitui as informa��es
                        Linha_Produto = Linha_Produto.Replace("[codPro]", Format(.Item("CodPro"), "000") & "." & Format(.Item("Clone"), "0000"))
                        Linha_Produto = Linha_Produto.Replace("[produto]", .Item("Descricao"))
                        Linha_Produto = Linha_Produto.Replace("[ncm]", .Item("NCM"))
                        Linha_Produto = Linha_Produto.Replace("[qtde]", Format(.Item("Quantidade"), "N0"))
                        Linha_Produto = Linha_Produto.Replace("[preco]", Format(.Item("Unitario"), "N2"))
                        Linha_Produto = Linha_Produto.Replace("[total]", Format(.Item("Total"), "N2"))
                        'Soma o total dos produtos
                        varTotalMerc += .Item("Total")
                        'Vai montando a string que vai compor o HTML do pedido
                        varProdutos &= Linha_Produto
                    End With
                Next i

                'Carrega arquivo de modelo de e-mail
                'L� o arquivo de modelo
                Body = File.ReadAllText(strModeloPath)
                'Define os campos que ser�o substituidos no modelo
                Dim Campos() As String = {"[numPedido]", "[codigo]", "[endereco]", "[contato]", "[cliente]", "[cidade]", "[email]", "[cpf_cnpj]", "[estado]", _
                                          "[fone]", "[data]", "[numMudas]", "[totalMerc]", "[desconto]", "[frete]", "[totalPed]", "[linha_produtos]"}
                'Cria um array com todas as informa��es coletadas
                Dim Valores() As String = {varPedido, varCodigo, varEndereco, varContato, varCliente, varCidade, varEmail, varCPF_CNPJ, varEstado, varFone, varData, varNumMudas, varTotalMerc, varDesconto, varFrete, varTotalPed, varProdutos}

                'Substitui os campos do HTML gerando o corpo do e-mail
                For i = 0 To Campos.Length - 1
                    Body = Body.Replace(Campos(i), Valores(i))
                Next
                'Libera memoria
                DTItens = Nothing
                'Retorna 
                Return Body
            End If

        End If

        Return String.Empty
    End Function

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        'Cria o caminho base para os arquivos de relat�rio
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "crPedido.rpt"

        Me.Cursor = Cursors.WaitCursor

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relat�rio n�o localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            'Define o parameter field
            CR.SetParameterValue("Id_Pedido", dgPedidos.SelectedRows(0).Cells("id").Value)

            Dim PrinterName As String
            Dim ePage As Integer
            Dim sPage As Integer
            Dim nCopy As Integer

            'Pede para selecionar a impressora
            PrintDialog1.Document = PrintDocument1
            Dim DR As DialogResult = PrintDialog1.ShowDialog()

            'Se der tudo certo
            If DR = DialogResult.OK Then
                'Quantas C�pias
                nCopy = PrintDialog1.PrinterSettings.Copies
                'N�mero da P�gina inicial (0=todas)
                sPage = 0
                'Numero final igual a Zero imprime todas
                ePage = 0
                'Pega o nome da impressora
                PrinterName = PrintDocument1.PrinterSettings.PrinterName
                'Define o nome da impressora
                CR.PrintOptions.PrinterName = PrinterName
                'Manda o relat�rio para impressoa
                CR.PrintToPrinter(nCopy, False, sPage, ePage)
            Else
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            'Se deu tudo certo volta o cursor e informa
            Me.Cursor = Cursors.Arrow

            MsgBox("Pedido enviado para impress�o com sucesso.", MsgBoxStyle.Information, "Confirma��o")
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o pedido para impress�o!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        Dim a As Integer

        'Pede confirma��o do usuario
        a = MsgBox("Tem certeza que deseja excluir o pedido " & " e todos os seus �tens?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Confirma��o")

        'Se SIM
        If a = vbYes Then
            Dim PedidoID As Integer = dgPedidos.SelectedRows(0).Cells("id").Value
            Dim SQL As String, Mensagem As String

            SQL = "DELETE FROM Pedidos WHERE id=" & PedidoID
            Mensagem = " Pedido N� " & PedidoID
            Try
                ExecutaSQL(SQL)
                'Parte para exclis�o dos itens
                Mensagem = " Itens do pedido N� " & PedidoID
                SQL = "DELETE FROM Pedidos_itens WHERE Pedido_id=" & PedidoID
                ExecutaSQL(SQL)
                'Parte para exclus�o das duplicatas
                Mensagem = " Duplicatas do pedido N� " & PedidoID
                SQL = "DELETE FROM Duplicatas WHERE Pedido_id=" & PedidoID
                ExecutaSQL(SQL)
                MsgBox("Pedido N� " & Format(PedidoID, "00000") & ", seus �tens e suas duplicatas foram exclu�dos com sucesso!", MsgBoxStyle.Information, "Confirma��o")
                Atualiza_grid()
            Catch ex As Exception
                MsgBox("Erro ao excluir " & Mensagem & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLiquidar.Click
        Dim DataEntrega As String, a As Integer, PedidoID As Integer
        Dim SQL As String

        PedidoID = dgPedidos.SelectedRows(0).Cells("id").Value

        a = MsgBox("Deseja realmente liquidar o pedido N� " & Format(PedidoID, "00000"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
        'Se o user na� confirmar
        If a = vbNo Then
            Exit Sub
        ElseIf a = vbYes Then
            'Se sim vai adiante
            DataEntrega = InputBox("Qual a data da liquida��o do pedido?", System.DateTime.Today.Date)
            If DataEntrega <> "" Then
                'Atualiza��o do pedido
                SQL = "UPDATE Pedidos SET Status=4,DataEntregue='" & Format(CDate(DataEntrega), "yyyy-MM-dd") & "' WHERE id=" & PedidoID
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar atualizar o status do pedido N� " & Format(PedidoID, "00000") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
                'Atualiza��o dos �tens
                SQL = "UPDATE Pedidos_itens SET Atendido=Quantidade,Status=4 WHERE Pedido_id=" & PedidoID
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar atualizar o status dos �tens do pedido N� " & Format(PedidoID, "00000") & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
                'Insere no controle de entregas
                Dim varCliente As String = dgPedidos.SelectedRows(0).Cells("CodCli").Value
                SQL = "INSERT INTO Pedido_entregas (Cliente,id_Pedido,id_item,DATA,Quantidade) SELECT " & varCliente & " AS cliente, " & PedidoID & " AS id_pedido, id, '" & Format(CDate(DataEntrega), "yyyy-MM-dd") & "' AS DATA,Quantidade FROM Pedidos_itens WHERE Pedido_id=" & PedidoID
                Try
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar atualizar o registro de entregas!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
                MsgBox("Pedido N� " & Format(PedidoID, "00000") & " liquidado com sucesso!", MsgBoxStyle.Information, "Confirma��o")
                Atualiza_grid()
            End If
        End If
    End Sub

    Private Sub dgPedidos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPedidos.SelectionChanged
        Dim Status As Integer
        If dgPedidos.SelectedRows.Count > 0 Then
            Status = dgPedidos.SelectedRows(0).Cells("Status").Value

            Select Case Status
                Case 0  ' 00 - Faz o Mesmo que autorizado
                    btAlterar.Enabled = True
                    btExcluir.Enabled = True
                    btLiquidar.Enabled = True
                    btImprimir.Enabled = True
                    btEmail.Enabled = True
                    btStatus.Enabled = True
                    btCancela.Enabled = True
                    btFaturar.Enabled = True
                Case 1  ' 01 - AUTORIZADO
                    btAlterar.Enabled = True
                    btExcluir.Enabled = True
                    btLiquidar.Enabled = True
                    btImprimir.Enabled = True
                    btEmail.Enabled = True
                    btStatus.Enabled = True
                    btCancela.Enabled = True
                    btFaturar.Enabled = True
                Case 2  ' 02 - EM PRODUCAO
                    btAlterar.Enabled = True
                    btExcluir.Enabled = True
                    btLiquidar.Enabled = True
                    btImprimir.Enabled = True
                    btEmail.Enabled = True
                    btStatus.Enabled = True
                    btCancela.Enabled = True
                    btFaturar.Enabled = True
                Case 3  '03 - CANCELADO
                    btAlterar.Enabled = False
                    btExcluir.Enabled = True
                    btLiquidar.Enabled = False
                    btImprimir.Enabled = True
                    btEmail.Enabled = False
                    btStatus.Enabled = True
                    btCancela.Enabled = False
                    btFaturar.Enabled = False
                Case 4  '04 - ATENDIDO
                    btAlterar.Enabled = False
                    btExcluir.Enabled = False
                    btLiquidar.Enabled = False
                    btImprimir.Enabled = True
                    btEmail.Enabled = True
                    btStatus.Enabled = False
                    btCancela.Enabled = False
                    btFaturar.Enabled = False
            End Select
        End If
    End Sub

    Private Sub btAlterar_Click(sender As System.Object, e As System.EventArgs) Handles btAlterar.Click

        'Se houver algo selecionado
        If dgPedidos.SelectedRows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim PedidoID As Integer = -1
            'Pega o ID do pedido atual
            PedidoID = dgPedidos.SelectedRows(0).Cells("id").Value
            'Cria um form de altera��o de pedido e manda o ID atual junto
            Dim Form2 As New frmPedidos(PedidoID)
            Form2.MdiParent = frmMenu
            'Mostra o formul�rio
            Form2.Show()
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub btCancela_Click(sender As System.Object, e As System.EventArgs) Handles btCancela.Click
        Dim a As Integer
        Dim PedidoID As Integer = -1

        'Se tiver algum pedido selecionado
        If dgPedidos.SelectedRows.Count > 0 Then
            'Pega o Id do pedido selecionado
            PedidoID = dgPedidos.SelectedRows(0).Cells("id").Value
            'Confirma com o usuario se quer realmente cancelar o pedido
            a = MsgBox("Deseja realmente cancelar o Pedido n� ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirma��o")
            'Se confirmou
            If a = vbYes Then
                Dim SQL As String
                'Monta a SQL para a acao
                SQL = "UPDATE Pedidos SET Status=3 WHERE id=" & PedidoID
                Try
                    'Executa a SQL
                    ExecutaSQL(SQL)
                    'Cancelar os �tens tamb�m
                    SQL = "UPDATE pedidos_itens SET Status=3 WHERE Pedido_id=" & PedidoID
                    ExecutaSQL(SQL)
                    'confirma que foi realizado
                    MsgBox("Pedido cancelado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirma��o")
                    'Atualiza o grid
                    Atualiza_grid()
                Catch ex As Exception
                    MsgBox("Erro ao tentar cancelar o Pedido n� " & PedidoID & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End Try
            End If
        End If

    End Sub

    Private Sub btStatus_Click(sender As System.Object, e As System.EventArgs) Handles btStatus.Click
        'Torna o painel vis�vel
        pnlStatus.Visible = True
    End Sub

    Private Sub BtSTCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtSTCancelar.Click
        'torna o painel invis�vel novamente
        pnlStatus.Visible = False

    End Sub

    Private Sub btSTOK_Click(sender As System.Object, e As System.EventArgs) Handles btSTOK.Click
        'Se existir algo selecionado
        If cmbAltStatus.SelectedIndex > -1 Then
            Dim PedidoID As Integer = -1, SQL As String, NovoStatus As String = ""
            'Pega o Id do pedido selecionado
            PedidoID = dgPedidos.SelectedRows(0).Cells("id").Value
            NovoStatus = cmbAltStatus.Text.Substring(0, 1)
            'Monta a SQL
            SQL = "UPDATE Pedidos SET Status=" & NovoStatus & " WHERE id=" & PedidoID
            'Tenta executar a SQL
            Try
                'Executa a SQL
                ExecutaSQL(SQL)

                'Verifica o status dos �tens
                Select Case NovoStatus
                    Case "0"    'N�o Aprovado
                        SQL = "UPDATE pedidos_itens SET Status=" & NovoStatus & " WHERE pedido_id=" & PedidoID & " AND Atendido<Quantidade"
                    Case "1"    'Aprovado
                        SQL = "UPDATE pedidos_itens SET Status=" & NovoStatus & " WHERE pedido_id=" & PedidoID & " AND Atendido<Quantidade"
                    Case "2"    'Em Produ��o
                        SQL = "UPDATE pedidos_itens SET Status=" & NovoStatus & " WHERE pedido_id=" & PedidoID & " AND Atendido<Quantidade"
                    Case "3"    'Cancelado
                        SQL = "UPDATE pedidos_itens SET Status=" & NovoStatus & " WHERE pedido_id=" & PedidoID
                    Case "4"    'Atendido
                        SQL = "UPDATE pedidos_itens SET Status=" & NovoStatus & " WHERE pedido_id=" & PedidoID
                End Select
                'Executa a segunda atualiza��o
                ExecutaSQL(SQL)
                'confirma que foi realizado
                MsgBox("Status do Pedido n� " & PedidoID & " alterado para: " & cmbAltStatus.Text, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirma��o")
                'Limpa caixa de pedidos
                cmbAltStatus.Text = ""
                pnlStatus.Visible = False
                'Atualiza o grid
                Atualiza_grid()
            Catch ex As Exception
                MsgBox("Erro ao tentar alterar o Status do Pedido n�" & PedidoID & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
                pnlStatus.Visible = False
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Limpa todos os filtros
        cmbStatus.Text = String.Empty
        cmbCliente.Text = String.Empty
        chkData.Checked = False
        txtDataFIM.Text = Date.Today
        txtDataINI.Text = Date.Today
        'manda atualizar o grid
        Atualiza_grid()
    End Sub

    Private Sub btFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btFiltrar.Click
        'Manda atualizar o grid pois o filtro � aplicado dentro da rotina
        Atualiza_grid()
    End Sub

    Private Sub btFaturar_Click(sender As System.Object, e As System.EventArgs) Handles btFaturar.Click
        'Pega o ID do pedido selecionado
        Dim Num As Integer = dgPedidos.SelectedRows(0).Cells("id").Value
        'Cria um novo objeto 
        Dim wnd As New frmNFeDocumento(2, Num)
        'Define quem � o Pai MDI
        wnd.MdiParent = Me.MdiParent
        'Mostra
        wnd.Show()
    End Sub

    Private Sub txtAno_ValueChanged(sender As Object, e As EventArgs) Handles txtAno.ValueChanged
        'Atualiza_grid()
    End Sub
End Class