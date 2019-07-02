Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class auxPedidos
    Dim Cliente_ID As Integer

    Sub New(Optional ByVal ID_Cliente As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Cliente_ID = ID_Cliente
    End Sub
    Private Sub auxPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega o data grid (com os dados do cliente atual
        atualiza_datagrid(Cliente_ID)
    End Sub

    Private Sub atualiza_datagrid(ByVal ClienteID As String)
        Dim SQL As String, DT As DataTable
        Dim Cabecalhos() As String = {"Pedido", "Data", "Itens", "Mudas", "Valor", "Cliente", "Status"}
        Dim Larguras() As Integer = {50, 80, 50, 50, 80, 50, 30}
        Dim Visiveis() As Integer = {1, 1, 1, 1, 1, 0, 1}

        'Monta a SQL
        SQL = "SELECT * FROM lista_pedidos WHERE Cliente=" & ClienteID & " ORDER BY Data,Status"
        'Tenta recuperar os pedidos
        Try
            'Executa a sql no banco de dados
            DT = SQLQuery(SQL)
            'Atribui o resultado � datagrid
            dgpedidos.DataSource = DT
        Catch ex As Exception
            MsgBox("Erro ao tentar recuperar os pedidos do banco de dados" & vbCrLf & ex.Message & vbCrLf & ex.ToString & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
        'Fun��o generalizada para formatar Datagrids
        Formata_Datagrid(dgpedidos, Cabecalhos, Larguras, Visiveis)
        Formata_Colunas()
    End Sub

    Private Sub Formata_Colunas()
        Try
            'formatos espec�ficos para cada coluna
            With dgpedidos
                With .Columns("Pedido").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Format = "0000"
                End With
                With .Columns("data").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Format = "dd/MM/yyyy"
                End With
                With .Columns("itens").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("mudas").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Valor").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleRight
                    .Format = "N2"
                End With
                With .Columns("status").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Format = "0"
                End With
            End With
        Catch ex As Exception
            MsgBox("Erro ao tentar formatar os dado no Grid." & vbCrLf & ex.Message & vbCrLf & ex.ToString & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try
    End Sub

    Private Sub dgpedidos_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgpedidos.RowPrePaint
        'Pinta cada c�lula de acordo com o status do pedido
        dgpedidos.Rows(e.RowIndex).Cells("Status").Style.BackColor = Cor_Pedido(dgpedidos.Rows(e.RowIndex).Cells("Status").Value)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Cria o caminho base para os arquivos de relat�rio
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & "crPedido.rpt"

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Relat�rio n�o localizado :" & vbCrLf & strReportPath, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            'instancia o relatorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            'Define o parameter field
            CR.SetParameterValue("Id_Pedido", dgpedidos.SelectedRows(0).Cells("Pedido").Value)

            'Manda o relat�rio para impressoa
            CR.PrintToPrinter(1, False, 1, 1)
            Me.Cursor = Cursors.Arrow
            MsgBox("Pedido enviado para impress�o com sucesso.", MsgBoxStyle.Information, "Confirma��o")
        Catch ex As Exception
            MsgBox("Erro ao tentar enviar o pedido para impress�o!" & vbCrLf & ex.Message & vbCrLf & ex.ToString & vbCrLf & ex.ToString, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try
    End Sub
End Class