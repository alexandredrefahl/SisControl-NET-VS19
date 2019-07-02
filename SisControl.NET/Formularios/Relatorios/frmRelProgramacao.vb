Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRelProgramacao

    Protected Structure Linha
        Public Quantidade As Double
        Public Cor1 As String
        Public Cor2 As String
        Public Meio As String
        Public Macro As Double
        Public Micro As Double
        Public Vitamina As Double
        Public Sacarose As Double
        Public Inositol As Double
        Public Agar As Double
        Public Outros As String
        Public BAP As Double
        Public D24 As Double
        Public KIN As Double
        Public AIB As Double
        Public ANA As Double
        Public AIA As Double
        Public GA3 As Double
        Public DIP As Double
        Public Ph As Double
    End Structure

    Private Sub frmRelProgramacao_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDataINI.Text = "01/" & Month(Date.Now).ToString("00") & "/" & Year(Date.Now).ToString("0000")
        txtDataFIM.Text = Date.Now
    End Sub

    Private Sub Msg(ByVal Texto As String)
        lblMsg.Text = Texto
        lblMsg.Refresh()
    End Sub

    Private Sub btProg_Click(sender As System.Object, e As System.EventArgs) Handles btProg.Click
        'Se passou pelo teste da data
        'If Not Verifica_Data() Then
        ' Exit Sub
        'End If

        'Cursor de espera
        Me.Cursor = Cursors.WaitCursor

        Msg("Iniciando montagem do relatório")

        'Se passou então segue com a montagem do relatório
        Dim NomeRel As String = "crPRO_Ordem_de_Producao.rpt"
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & NomeRel

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Arquivo do Relatório não localizado", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Msg("...")
            Exit Sub
        End If

        Msg("Recuperando dados da programação")

        Dim CR As New ReportDocument

        Try
            'instancia o relatorio e carrega

            CR.Load(strReportPath)

            'Informa os parametros de data
            CR.SetParameterValue("DataINI", txtDataINI.Value)
            CR.SetParameterValue("DataFIM", txtDataFIM.Value)
        Catch ex As Exception
            MsgBox("Erro ao carregar arquivo do relatório e definição de parâmetros" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Try
            Msg("Formatando relatório para apresentação")
            ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
            crViewer.ReportSource = CR
            '.Zoom(1);  // Page Width
            '.Zoom(2);  // Whole Page
            crViewer.Zoom(1)
            'Atualiza o relatório
            crViewer.Refresh()
        Catch ex As Exception
            MsgBox("Erro ao formatar relatório para exibição" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        Msg("...")
        'Cursor de Seta
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Function Verifica_Data() As Boolean
        'Verifica se as datas não são iguais

        If txtDataINI.Text = txtDataFIM.Text Then
            MsgBox("As datas informadas são iguais. Selecione datas diferentes", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If
        'Verifica se Inicio menor do que Fim
        If txtDataINI.Text > txtDataFIM.Text Then
            MsgBox("A data Inicial é posterior à data Final.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Return False
        End If
        'Se passou por todas as verificações
        Return True
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'If Not Verifica_Data() Then
        'Exit Sub
        'End If

        Me.Cursor = Cursors.WaitCursor
        Msg("Montando resumo dos meio de cultura")
        'Recupera os dados da programação e preenche o dataset
        Recupera_Dados()

        'Cursor de espera
        Me.Cursor = Cursors.WaitCursor

        Msg("Iniciando montagem do relatório")

        'Se passou então segue com a montagem do relatório
        Dim NomeRel As String = "crPROPlanilha_Meios.rpt"
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\" & NomeRel

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            MsgBox("Arquivo do Relatório não localizado", MsgBoxStyle.Critical, "Erro")
            Me.Cursor = Cursors.Arrow
            Msg("...")
            Exit Sub
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument

        'Carrega o lay-out a partir do arquivo
        CR.Load(strReportPath)

        'Define a fonte de dados como sendo a planilha montada pelo progama
        CR.SetDataSource(dsPlanilha.Tables(0))

        'Informa os parametros de data
        CR.SetParameterValue("txtDataINI", txtDataINI.Value)
        CR.SetParameterValue("txtDataFIM", txtDataFIM.Value)
        CR.SetParameterValue("txtObservacoes", txtObservacoes.Text)

        Msg("Formatando relatório para apresentação")

        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        crViewer.ReportSource = CR

        '.Zoom(1);  // Page Width
        '.Zoom(2);  // Whole Page
        crViewer.Zoom(1)
        'Atualiza o relatório
        crViewer.Refresh()

        Msg("...")
        'Cursor de Seta
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub Recupera_Dados()
        '*
        '* Recupera os dados da programação e preenche o dataset
        '*

        Dim SQL As String
        Dim DT As DataTable

        'Seleciona somente as repicagens do período
        'SQL = "SELECT * FROM Programacao WHERE (Data BETWEEN '" & txtDataINI.Value.ToString("yyyy-MM-dd") & "' AND '" & txtDataFIM.Value.ToString("yyyy-MM-dd") & "') AND Tipo='R' GROUP BY Meio_desc,Meio_S_L"
        SQL = "SELECT meio,Meio_desc,Meio,Meio_s_l,SUM(Meio_Qtde) AS Quantidade FROM Programacao WHERE (DATA BETWEEN '" & txtDataINI.Value.ToString("yyyy-MM-dd") & "' AND '" & txtDataFIM.Value.ToString("yyyy-MM-dd") & "') AND Tipo='R' GROUP BY Meio_desc,Meio_S_L"
        'Console.WriteLine(SQL)

        'Tenta pegar os dados no banco de dados
        Try
            DT = SQLQuery(SQL)
        Catch ex As Exception
            MsgBox("Erro ao recuperar os dados da programação", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Exit Sub
        End Try
        'Se não localizou nada
        If DT.Rows.Count <= 0 Then
            MsgBox("Não foi localizado nenhum dado referente à este período", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If

        'Se achou
        Dim DR As DataRow
        'Limpa o DataTable antigo para não duplicar os meios de cultura
        dsPlanilha.Tables(0).Clear()
        'Para cara linha encontrada processa o meio de cultura
        For Each DR In DT.Rows
            Msg("Calculando Meio de cultura: " & DR.Item("Meio_Desc"))
            'Se o código do meio não está zerado então
            If Not IsDBNull(DR.Item("Meio")) Then
                Dim DRMeio As DataRow
                'Localizar o meio de cultura
                DRMeio = DLookupRow("meios_meiosbase", "id=" & DR.Item("meio"))

                If IsNothing(DRMeio) Then
                    MsgBox("Meio de cultura não cadastrado ou não encontrado", MsgBoxStyle.Critical, "Erro")
                    Exit Sub
                End If

                'Começa a calcular os parametros individuais para fazer a inclusão
                Dim m As New Linha
                m.Outros = String.Empty
                Dim varQ As Double = DR.Item("Quantidade")
                '*
                '* Preenche todos os parametros para inclusão
                '*
                '* COMEÇA COM OS ÍTENS DE QUANTIDADE PADRONIZADA
                '*
                m.Quantidade = varQ
                m.Cor1 = DRMeio.Item("Cor1")
                m.Cor2 = DRMeio.Item("Cor2")
                m.Meio = "(" & DR.Item("Meio") & ")" & DR.Item("Meio_Desc")
                m.Macro = varQ * DRMeio.Item("Macro")
                m.Micro = varQ * DRMeio.Item("Micro")
                m.Vitamina = varQ * DRMeio.Item("Vitamina")
                m.Sacarose = varQ * DRMeio.Item("Sacarose")
                m.Inositol = varQ * DRMeio.Item("Inositol")
                m.Ph = DRMeio.Item("ph")

                'Verifica se é sólido ou líquido para incluir ou não o agar
                If DR.Item("Meio_s_l") = "L" Then
                    'Se for meio Líquido
                    m.Agar = 0
                Else
                    m.Agar = varQ * DRMeio.Item("Agar")
                End If

                'Verifica as observações
                If Not IsDBNull(DRMeio.Item("bsOutros")) Or Not IsDBNull(DRMeio.Item("mcOutros")) Then
                    'Se a observação do meio base não for nula
                    If Not IsDBNull(DRMeio.Item("bsOutros")) Then
                        m.Outros &= DRMeio.Item("bsOutros")
                    End If
                    'Se a observação do meio específico não for nula
                    If Not IsDBNull(DRMeio.Item("mcOutros")) Then
                        'Se já tiver a observação anterior pula uma linha
                        If m.Outros.Length > 0 Then
                            m.Outros &= vbCrLf
                        End If
                        m.Outros &= DRMeio.Item("mcOutros")
                    End If
                End If

                '*
                '* HORMONIOS - CÁLCULO FEITO PARA ML
                '*

                m.BAP = (varQ * IIf(IsDBNull(DRMeio.Item("BAP")), 0, DRMeio.Item("BAP"))) / MGL_BAP
                m.D24 = (varQ * IIf(IsDBNull(DRMeio.Item("24D")), 0, DRMeio.Item("24D"))) / MGL_24D
                m.KIN = (varQ * IIf(IsDBNull(DRMeio.Item("KIN")), 0, DRMeio.Item("KIN"))) / MGL_KIN
                m.AIB = (varQ * IIf(IsDBNull(DRMeio.Item("AIB")), 0, DRMeio.Item("AIB"))) / MGL_AIB
                m.ANA = (varQ * IIf(IsDBNull(DRMeio.Item("ANA")), 0, DRMeio.Item("ANA"))) / MGL_ANA
                m.AIA = (varQ * IIf(IsDBNull(DRMeio.Item("AIA")), 0, DRMeio.Item("AIA"))) / MGL_AIA
                m.GA3 = (varQ * IIf(IsDBNull(DRMeio.Item("GA3")), 0, DRMeio.Item("GA3"))) / MGL_GA3
                m.DIP = (varQ * IIf(IsDBNull(DRMeio.Item("2IP")), 0, DRMeio.Item("2IP"))) / MGL_2IP

                Try
                    'Fazer a inclusão no dataSet
                    dsPlanilha.Tables(0).Rows.Add(m.Quantidade, m.Cor1, m.Cor2, m.Meio, m.Macro, m.Micro, m.Vitamina, m.Sacarose, m.Inositol, m.Agar, m.Outros, m.BAP, m.D24, m.KIN, m.AIB, m.ANA, m.AIA, m.GA3, m.DIP, m.Ph)
                Catch ex As Exception
                    MsgBox("Erro ao tentar incluir um dos meios de cultura na planilha" & vbCrLf & m.Meio, MsgBoxStyle.Critical)
                    Exit Sub
                End Try
            End If
        Next
    End Sub

    Private Sub crViewer_Load(sender As System.Object, e As System.EventArgs) Handles crViewer.Load

    End Sub
End Class