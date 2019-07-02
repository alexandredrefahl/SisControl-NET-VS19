Imports BoletoNet   'Geração dos boletos bancários
Imports System.Text
Imports System.IO
Imports System.Net.Mail
Imports SisControl.NET.BoletoNET.Arquivo

Public Class frmEmissaoBoletos

    Dim _arquivo As String = String.Empty


    Private Function Gerar_Imagem() As String

        Dim Address As String = wbBoleto.Url.ToString()
        Dim width As Integer = 670
        Dim height As Integer = 805
        Dim webBrowserWidth As Integer = 670
        Dim webBrowserHeight As Integer = 805
        Dim BMP As Bitmap = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(Address, webBrowserWidth, webBrowserHeight, width, height)
        Dim file As String = Path.Combine(Environment.CurrentDirectory, "boleto.bmp")
        BMP.Save(file)
        Return file
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Se estiver na aba das duplicatas
        If tabOpcoes.SelectedIndex = 0 Then
            If cmbParcelas.Text = "" Then
                MsgBox("Selecione pelo menos uma das parcelas para que seja possível a emissão do boleto.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                'Gera boleto pela nota
                GeraBoletoBradesco()
                wbBoleto.Navigate(_arquivo)
            End If
        End If
        'Se estiver na aba do Avulso
        If tabOpcoes.SelectedIndex = 1 Then
            If txtNome.Text = "" Then
                MsgBox("Os dados não estão preenchidos corretamente, não é possível emitir o boleto", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                'Gera boleto avulso
                GeraAvulso()
                wbBoleto.Navigate(_arquivo)
            End If
        End If
    End Sub

    Private Sub GeraBoletoBradesco()

        'cursor em modo de espera
        Cursor = Cursors.WaitCursor

        Dim DT As DataTable, SQL As String
        'Pega o ID do documento a ser processado
        Dim DocID As Integer = dgNFs.SelectedRows(0).Cells(0).Value

        '* 
        '*  DEFINIÇOES GERAIS
        '*

        Dim Carteira As String = "09"

        'Cria o boleto, e passa os parâmetros usuais
        Dim bb As BoletoBancario

        bb = New BoletoBancario
        bb.CodigoBanco = 237    'codigoBanco

        '*
        '*  DADOS DA EMPRESA (CEDENTE)
        '*

        'Dim vencimento As String = New DateTime(2007, 9, 10)            'Data base para cálculos do banco
        Dim varCedCPF_CNPJ As String = "07.727.715/0001-90"
        Dim varCedNome As String = "Clona-Gen Comércio de Mudas de Plantas Ltda."
        Dim varCedAg As String = "3028"
        Dim varCedDVAg As String = "7"
        Dim varCedCC As String = "080399"
        Dim varCedDVcc As String = "5"
        Dim varCedOpCC As String = "7"
        Dim varCedCod As Integer = 13000

        'Dim c As Cedente = New Cedente(varCedCPF_CNPJ, varCedNome, varCedAg, varCedDVAg, varCedCC, varCedDVcc, varCedOpCC)
        Dim c As Cedente = New Cedente(varCedCPF_CNPJ, varCedNome, varCedAg, varCedCC, varCedDVcc)

        c.Codigo = varCedCod     'Código do Cedente (Número fornecido pelo banco)

        '*
        '*  DADOS DO CLIENTE/FATURAMENTO
        '*

        SQL = "SELECT * FROM docs WHERE id=" & DocID

        Try
            'Pesquisa no banco de dados
            DT = SQLQuery(SQL)
            'Se não encontrou o documento
            If DT.Rows.Count <= 0 Then
                MsgBox("Não há dados para este faturamento!", MsgBoxStyle.Critical, "Erro")
                Cursor = Cursors.Arrow
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar os dados do documento!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Dim ender As Endereco = New Endereco()
        Dim varNome As String
        'Dim varID As Integer
        Dim varCPF_CNPJ As String
        Dim varNFe As String
        Dim varValor As Double
        Dim varVencimento As Date
        Dim varDataDoc As Date
        Dim varDataProc As Date

        'Reune os dados para o faturamento
        With DT.Rows(0)
            varNome = .Item("Cliente")
            varCPF_CNPJ = .Item("cnpj_cpf")
            varNFe = .Item("Documento")
            varValor = CDbl(DLookup("valor", "Duplicatas", "id=" & cmbVal(cmbParcelas)))
            varVencimento = CDate(DLookup("vencimento", "Duplicatas", "id=" & cmbVal(cmbParcelas)))
            varDataDoc = CDate(.Item("Data"))
            varDataProc = Date.Now.Date

            ender.Bairro = .Item("Bairro")
            ender.CEP = .Item("CEP")
            ender.Cidade = .Item("Cidade") & " - " & .Item("Estado")
            ender.Complemento = ""
            ender.End = .Item("Endereco")
            ender.Numero = .Item("Num")
            'ender.EndComNumero = .Item("Endereco") & ", " & 
            ender.UF = .Item("Estado")

        End With

        Dim varNosso_Num As String
        'Gera o "Nosso Numero - 11 posições"
        varNosso_Num = String.Format("{0:00000}", RandomNumber(99999, 0)) & String.Format("{0:000000}", CInt(varNFe))

        Dim b As Boleto = New Boleto(varVencimento, varValor, Carteira, varNosso_Num, c)
        b.NumeroDocumento = varNFe
        'CPF, Nome, Endereço (structure)
        b.Sacado = New Sacado(varCPF_CNPJ, varNome, ender)

        Dim Item As Instrucao_Bradesco = New Instrucao_Bradesco(EnumInstrucoes_Bradesco.NaoReceberAposNDias, 10)             'Código da Instrução e número de dias
        Dim Item1 As Instrucao_Bradesco = New Instrucao_Bradesco(EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos, 90)     'Protestar após 90 dias corridos
        Dim Item2 As Instrucao_Bradesco = New Instrucao_Bradesco            'Instrução personalizada

        Dim valMulta As Double = 0
        valMulta = (0.05 * varValor) / 30   'Calcula o valor da multa por dia

        'Instrução personalizada
        Item2.Descricao = "Cobrar juros de 5% ao mês após o vencimento (R$ " & valMulta.ToString("N2") & " ao dia)"

        b.Instrucoes.Add(Item)              'Não Receber após o vencimento
        b.Instrucoes.Add(Item2)             'Cobrar juros de mora ao dia
        b.Instrucoes.Add(Item1)             'Protestar após 90 dias corridos

        Dim esp As New EspecieDocumento_Bradesco
        esp.Especie = "Duplicata Mercantil"
        esp.Sigla = "DM"

        b.Aceite = "Sem"
        b.Especie = "R$"
        b.ValorBoleto = varValor
        b.DataVencimento = varVencimento
        b.DataDocumento = varDataDoc
        b.DataProcessamento = varDataProc
        b.Carteira = Carteira
        b.EspecieDocumento = esp
        b.NossoNumero = varNosso_Num

        bb.Boleto = b
        bb.Boleto.Valida()

        'Gera o lay out efetivamente
        GeraLayout(bb)
        Cursor = Cursors.Arrow

    End Sub

    Private Sub GeraAvulso()
        'cursor em modo de espera
        Cursor = Cursors.WaitCursor

        '* 
        '*  DEFINIÇOES GERAIS
        '*

        Dim Carteira As String = "09"

        'Cria o boleto, e passa os parâmetros usuais
        Dim bb As BoletoBancario

        bb = New BoletoBancario
        bb.CodigoBanco = 237    'codigoBanco

        '*
        '*  DADOS DA EMPRESA (CEDENTE)
        '*

        'Dim vencimento As String = New DateTime(2007, 9, 10)            'Data base para cálculos do banco
        Dim varCedCPF_CNPJ As String = "07.727.715/0001-90"
        Dim varCedNome As String = "Clona-Gen Comércio de Mudas de Plantas Ltda."
        Dim varCedAg As String = "3028"
        Dim varCedDVAg As String = "7"
        Dim varCedCC As String = "080399"
        Dim varCedDVcc As String = "5"
        Dim varCedOpCC As String = "7"
        Dim varCedCod As Integer = 13000

        'Dim c As Cedente = New Cedente(varCedCPF_CNPJ, varCedNome, varCedAg, varCedDVAg, varCedCC, varCedDVcc, varCedOpCC)
        Dim c As Cedente = New Cedente(varCedCPF_CNPJ, varCedNome, varCedAg, varCedCC, varCedDVcc, varCedDVcc)

        c.Codigo = varCedCod     'Código do Cedente (Número fornecido pelo banco)

        '*
        '*  DADOS DO CLIENTE/FATURAMENTO
        '*

        Dim ender As Endereco = New Endereco()
        Dim varNome As String
        'Dim varID As Integer
        Dim varCPF_CNPJ As String
        Dim varNFe As String
        Dim varValor As Double
        Dim varVencimento As Date
        Dim varDataDoc As Date
        Dim varDataProc As Date

        'Reune os dados para o faturamento
        varNome = txtNome.Text
        varCPF_CNPJ = txtCPFCNPJ.Text
        varNFe = txtNDoc.Text
        varValor = String_to_Numero(txtValor.Text)
        varVencimento = CDate(txtVencimento.Text)
        varDataDoc = CDate(txtDataDoc.Text)
        varDataProc = Date.Now.Date

        'Endereço do Cliente
        ender.Bairro = txtBairro.Text
        ender.CEP = txtCEP.Text
        ender.Cidade = txtCidade.Text & " - " & txtEstado.Text
        ender.Complemento = ""
        ender.End = txtRua.Text
        'ender.Logradouro = txtRua.Text
        ender.Numero = txtNum.Text
        ender.UF = txtEstado.Text



        Dim varNosso_Num As String
        'Gera o "Nosso Numero - 11 posições"
        varNosso_Num = String.Format("{0:00000}", RandomNumber(99999, 0)) & String.Format("{0:000000}", CInt(varNFe))

        Dim b As Boleto = New Boleto(varVencimento, varValor, Carteira, varNosso_Num, c)
        b.NumeroDocumento = varNFe

        'CPF, Nome, Endereço (structure)
        b.Sacado = New Sacado(varCPF_CNPJ, varNome, ender)

        Dim Item As Instrucao_Bradesco = New Instrucao_Bradesco(EnumInstrucoes_Bradesco.NaoReceberAposNDias, 10)             'Código da Instrução e número de dias
        Dim Item1 As Instrucao_Bradesco = New Instrucao_Bradesco(EnumInstrucoes_Bradesco.ProtestarAposNDiasCorridos, 90)     'Protestar após 90 dias corridos
        Dim Item2 As Instrucao_Bradesco = New Instrucao_Bradesco            'Instrução personalizada

        Dim valMulta As Double = 0
        valMulta = (0.05 * varValor) / 30   'Calcula o valor da multa por dia

        'Instrução personalizada
        Item2.Descricao = "Cobrar juros de 5% ao mês após o vencimento (R$ " & valMulta.ToString("N2") & " ao dia)"

        b.Instrucoes.Add(Item)              'Não Receber após o vencimento
        b.Instrucoes.Add(Item2)             'Cobrar juros de mora ao dia
        b.Instrucoes.Add(Item1)             'Protestar após 90 dias corridos

        Dim esp As New EspecieDocumento_Bradesco
        esp.Especie = "Duplicata Mercantil"
        esp.Sigla = "DM"

        b.Aceite = "Sem"
        b.Especie = "R$"
        b.ValorBoleto = varValor
        b.DataVencimento = varVencimento
        b.DataDocumento = varDataDoc
        b.DataProcessamento = varDataProc
        b.Carteira = Carteira
        b.EspecieDocumento = esp
        b.NossoNumero = varNosso_Num

        bb.Boleto = b
        bb.Boleto.Valida()

        'Gera o lay out efetivamente
        GeraLayout(bb)
        Cursor = Cursors.Arrow
    End Sub

    Private Sub GeraLayout(Boleto As BoletoBancario)

        Dim html As StringBuilder = New StringBuilder()

        'Usa o método para montar o HTML 
        Boleto.MostrarComprovanteEntrega = True
        Boleto.OcultarReciboSacado = False

        html.Append(Boleto.MontaHtml())
        html.Append("</br></br>")

        _arquivo = System.IO.Path.GetTempFileName()

        Dim f As FileStream = New FileStream(_arquivo, FileMode.Create)
        Dim w As StreamWriter = New StreamWriter(f, System.Text.Encoding.Default)
        w.Write(html.ToString())
        w.Close()
        f.Close()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'wbBoleto.Print()
        wbBoleto.ShowPrintDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Fechar a aplicação
        Me.Close()
    End Sub

    Private Sub frmEmissaoBoletos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Formata_Grid()
    End Sub

    Private Sub Formata_Grid()
        Dim DT As DataTable = Nothing, SQL As String = String.Empty
        Dim Cabecalhos() As String, Larguras() As Integer, Visiveis() As Integer

        SQL = "SELECT id,Data,Serie,Documento,Cliente,CNPJ_CPF,vTotal,Status FROM Docs ORDER BY Documento"
        Try
            'Coloca os dados da tabela no grid
            DT = SQLQuery(SQL)
            dgNFs.DataSource = DT
        Catch ex As Exception
            MsgBox("Erro ao recuperar as informações das Notas Fiscais!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try


        Cabecalhos = {"ID", "Data", "S", "Nº Doc", "Cliente", "CNPJ/CPF", "Total", "Sit"}
        Larguras = {0, 80, 30, 90, 180, 100, 80, 30}
        Visiveis = {0, 1, 1, 1, 1, 1, 1, 1}
        Formata_Datagrid(dgNFs, Cabecalhos, Larguras, Visiveis)

        'formatos específicos para cada coluna
        With dgNFs
            With .Columns("id").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0000"
            End With
            With .Columns("Data").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "dd/MM/yyyy"
            End With
            With .Columns("Serie").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Documento").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With .Columns("Cliente").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("CNPJ_CPF").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With .Columns("vTotal").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            With .Columns("status").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Format = "0"
            End With
        End With
    End Sub

    Private Sub dgNFs_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgNFs.RowPrePaint
        Dim i As Int16 = 0
        i = e.RowIndex
        Select Case dgNFs.Rows(i).Cells("status").Value.ToString
            Case "0"    'DIGITADA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Digitada
            Case "1"    'GERADO XML
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Gerada
            Case "2"    'TRANSMITIDA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Transmitida
            Case "3"    'DANFE Impressa
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Danfe
            Case "4"    'CANCELADA
                dgNFs.Rows(i).Cells("status").Style.BackColor = Cor_Cancelada
        End Select

    End Sub


    Private Sub dgNFs_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgNFs.SelectionChanged
        'Quando alterar a seleção
        'Se tiver algo selecionado
        If dgNFs.SelectedRows.Count > 0 Then
            Dim DocID As Integer
            DocID = dgNFs.SelectedRows(0).Cells(0).Value   'ID da NF
            'Carrega o combo com as parcelas
            cmbParcelas.Text = String.Empty
            Carrega_Lista(cmbParcelas, "lista_duplicatas", "id", "descricao", False, "Doc_ID=" & DocID)
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim mail As MailMessage = New MailMessage
        Dim NNFe As Int16 = dgNFs.SelectedRows(0).Cells(3).Value    'Pega no número da NFe
        Dim Anexo As String = "Boleto - NFe " & NNFE.ToString("000000") & ".bmp"
        Dim Cliente As String = dgNFs.SelectedRows(0).Cells(4).Value   'Pega o Nome do Cliente
        Dim CNPJ_CPF As String = dgNFs.SelectedRows(0).Cells(5).Value   'Pega o CNPJ do Cliente

        'Formata o CPF e o CNPJ de acordo com o tamanho
        CNPJ_CPF = FormataCpfCnpj(CNPJ_CPF)

        'Cria o anexo
        Anexo = WebsiteThumbnailImageGenerator.GerarImagem(wbBoleto, Anexo)

        mail.From = New MailAddress(E_MailFrom)
        'Manda para o destinatário
        mail.To.Add(New MailAddress(InputBox("Entre com o e-mail do destinatário.")))
        'Com cópia para o e-mail do comercial
        mail.CC.Add(New MailAddress("comercial@clona-gen.com.br"))
        mail.Subject = "Clona-Gen - Fatura ref. NFe " & NNFe
        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        mail.Body = "<html><head><title>Fatura On-Line</title></head><body>"
        mail.Body &= "<p>Sr. Cliente</p>"
        mail.Body &= "<p>Este e-mail foi gerado autom&aacute;ticamente pelo sistema da <strong>CLONA-GEN Com&eacute;rcio de Mudas de Plantas</strong> e cont&eacute;m um boleto emitido em nome de:</p>"
        mail.Body &= "<p><strong>" & Cliente.ToUpper & "<br />"
        mail.Body &= "CNPJ/CPF:</strong>&nbsp;" & CNPJ_CPF & "</p>"
        mail.Body &= "<p>N&atilde;o responda este e-mail. Em caso de d&uacute;vida consulte nossa equipe pelo e-mail <a href=mailto:comercial@clona-gen.com.br>comercial@clona-gen.com.br</a></p>"
        mail.Body &= "<p>Obrigado</p>"
        mail.Body &= "<p>&nbsp; &nbsp; &nbsp;Clona-Gen Com. de Mudas de Plantas Ltda.</p>"
        mail.Body &= "</body></html>"
        mail.Attachments.Add(New Attachment(Anexo))
        'Função que manda o e-mail via imagem
        MandaEmail(mail)
    End Sub

    Private Sub MandaEmail(mail As MailMessage)
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim objSMTPClient As SmtpClient = New SmtpClient
            objSMTPClient.Host = E_MailServer
            objSMTPClient.Port = E_MailPort
            objSMTPClient.EnableSsl = False
            objSMTPClient.Credentials = New System.Net.NetworkCredential(E_MailUser, E_MailPass)
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network
            objSMTPClient.Timeout = 10000
            objSMTPClient.Send(mail)
            MessageBox.Show("Boleto enviado Com sucesso!")
        Catch ex As Exception
            MsgBox("Erro ao enviar boleto por e-mail." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub


End Class