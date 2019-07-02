Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRecibo

    Private Sub btEmitir_Click(sender As System.Object, e As System.EventArgs) Handles btEmitir.Click

        'Cursor de Espera
        Me.Cursor = Cursors.WaitCursor
        msg("Localizando modelo do recibo")
        'Cria o caminho base para os arquivos de relatório
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "finRecibo.rpt"

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relatório não localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
        msg("Montando Recibo com as Informações")
        Try
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            'Define o parameter field
            CR.SetParameterValue("txtData", txtData.Text)
            CR.SetParameterValue("txtValor", txtValor.Text)
            CR.SetParameterValue("txtDe", txtNome.Text)
            CR.SetParameterValue("txtEndereco", txtEndereco.Text)
            CR.SetParameterValue("txtCPF_CNPJ", txtCPF_CNPJ.Text)
            CR.SetParameterValue("txtReferente", txtReferente.Text)
            CR.SetParameterValue("txtExtenso", NumeroToExtenso(txtValor.Text))
            msg("Selecionando Impressora")
            'Pede para selecionar a impressora
            PrintDialog1.Document = PrintDocument1
            Dim DR As DialogResult = PrintDialog1.ShowDialog()
            msg("Enviando Recibo para Impressão")
            'Define as variáveis usadas para impressão
            Dim nCopy As UInt16, sPage As UInt16, ePage As UInt16, PrinterName As String
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
            msg("...")
            MsgBox("Recibo Impresso com Sucesso.", MsgBoxStyle.Information, "Confirmação")
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o recibo para impressão!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub

    Private Sub msg(ByVal Msg As String)
        lblMsg.Text = Msg
        lblMsg.Refresh()
    End Sub
End Class