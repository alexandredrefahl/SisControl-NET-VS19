Imports FinancerData.ImportOfx
Imports System.Xml.Linq
Imports System.Reflection
Imports System.Xml

Public Class frmImportOFXData

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ofArquivo.ShowDialog()
        txtArquivo.Text = ofArquivo.FileName
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim doc As XElement = toXElement(txtArquivo.Text)
        'txtResultado.Text &= doc.Descendants("STMTTRN").Elements("TRNTYPE").Value
        'doc.Save("C:\texte.xml")
        Dim DT As DataTable

        'Pega o cadastro de lancamentos de banco para comparar e sugerir o plano de contas
        DT = SQLQuery("SELECT * FROM ctblancbanco")

        'Limpa o DataGrid primeiro
        dgLancamentos.Rows.Clear()

        'Percorre o arquivo do Banco procurando os ítens
        For Each c As XElement In doc.Descendants("STMTTRN")
            Dim varData As Date, varDescri As String, varCred As Double, varDeb As Double, varCTCred As Double, varCTDeb As Double
            Dim varAuxData As String, varHistorico As String = ""
            With dgLancamentos

                '*
                '* Pega os lançamentos no arquivo OFX
                '*

                'Data da Postagem no elemento DTPOSTED
                varAuxData = c.Elements("DTPOSTED").Value
                varAuxData = varAuxData.Substring(6, 2) & "/" & varAuxData.Substring(4, 2) & "/" & varAuxData.Substring(0, 4)
                varData = CDate(varAuxData)
                varDescri = c.Elements("MEMO").Value
                'Ajeitando os dados para que possam ser usados
                If c.Elements("TRNTYPE").Value.Substring(0, 1) = "D" Then
                    varCred = 0
                    'Deixar o valor positivo mas na coluna do débito poi no arquivo aparece "-19,00"
                    varDeb = String_to_Numero(c.Elements("TRNAMT").Value) * -1
                ElseIf c.Elements("TRNTYPE").Value.Substring(0, 1) = "C" Then
                    varCred = String_to_Numero(c.Elements("TRNAMT").Value)
                    varDeb = 0
                End If

                '*
                '* Verifica as contas para lancamento
                '*

                'Varre todos os tipos de lancamentos para sugerir a conta de cred e deb
                For i As Integer = 0 To DT.Rows.Count - 1

                    'Começa com Zero
                    varCTCred = 0
                    varCTDeb = 0
                    'Se encontrar o conteúdo dentro da string
                    If c.Elements("MEMO").Value.IndexOf(DT.Rows(i).Item("Conteudo")) > -1 Then
                        'Atribui os elementos à variável auxiliar que vai sugerir
                        varCTCred = DT.Rows(i).Item("CTCred")
                        varCTDeb = DT.Rows(i).Item("CTDeb")
                        If Not IsDBNull(DT.Rows(i).Item("codHistorico")) Then
                            varHistorico = DLookup("descricao", "ctbhistorico", "id=" & DT.Rows(i).Item("CodHistorico"))
                        End If
                        'Sai porque senão zera (também economiza tempo)
                        Exit For
                    End If
                Next

                'Inclui uma linha no datagrid
                .Rows.Add(varData, varDescri, varHistorico, varCred, varDeb, varCTCred, varCTDeb)
                'Ativa o controle para que se possa mexer
                .Enabled = True
            End With
            btConfirma.Enabled = True
        Next
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btConfirma_Click(sender As System.Object, e As System.EventArgs) Handles btConfirma.Click
        Dim a As Integer

        'Se não passar na validação
        If Not Valida_Campos() Then
            Exit Sub
        End If

        'Pede confirmação para os lancamentos
        a = MsgBox("ATENÇÃO, o sistema não verifica lançamentos duplicados para o mesmo mês." & vbCrLf & "então verifique se você já lançou estes ítens anteriormente" & vbCrLf & vbCrLf & "Deseja Prosseguir?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso")

        'Se o usuário confirmou então prossegue
        If a = vbYes Then


            'Torna a barra de progresso visivel e define valores
            pbProgresso.Visible = True
            pbProgresso.Minimum = 0
            pbProgresso.Maximum = dgLancamentos.RowCount - 1
            'Cursor de espera
            Me.Cursor = Cursors.WaitCursor

            'para cada lancamento faz um lancamento contábil
            For i As Integer = 0 To dgLancamentos.RowCount() - 1
                'Atualiza a barra de progresso
                pbProgresso.Value = i
                pbProgresso.Refresh()

                With dgLancamentos.Rows(i)
                    Dim LancCred As New Lancamentos
                    '*
                    '* LANCAMENTO DE CREDITO
                    '*
                    LancCred.cod_Reduzido = .Cells("colCTDeb").Value
                    LancCred.Pagamento = .Cells("colData").Value
                    LancCred.PreencheCodCompleto()
                    LancCred.Historico = .Cells("colHistorico").Value
                    LancCred.valCred = .Cells("colCred").Value
                    LancCred.valDeb = .Cells("colDeb").Value
                    LancCred.Tipo = "D"
                    'Faz a inclusão
                    LancCred.Incluir()
                    '*
                    '* LANCAMENTO DE DÉBITO
                    '*
                    Dim LancDeb As New Lancamentos
                    'Monta o lancamento
                    LancDeb.cod_Reduzido = .Cells("colCTCred").Value
                    LancDeb.Pagamento = .Cells("colData").Value
                    LancDeb.PreencheCodCompleto()
                    LancDeb.Historico = .Cells("colHistorico").Value
                    LancDeb.valCred = .Cells("colDeb").Value
                    LancDeb.valDeb = .Cells("colCred").Value
                    LancDeb.Tipo = "D"
                    'Faz a inclusão
                    LancDeb.Incluir()

                    'Libera Memoria
                    LancCred = Nothing
                    LancDeb = Nothing
                End With
            Next i
            'Torna o progresso invisivel
            pbProgresso.Visible = False
            'Retorna o cursor
            Me.Cursor = Cursors.Arrow
            MsgBox("Lançamentos contábeis realizados com sucesso!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Confirmação")
        End If

    End Sub


    Private Function Valida_Campos() As Boolean
        Dim msg As String = "", Ret As Boolean = True
        'Faz a varredura das linhas procurando algo fora do comum
        For i As Integer = 0 To dgLancamentos.RowCount - 1
            With dgLancamentos.Rows(i)
                'Se não preencheu o histórico
                If .Cells("colHistorico").Value.ToString.Length < 1 Then
                    msg &= "Coluna do Histórico não preenchida na linha " & i + 1 & vbCrLf
                    Ret = False
                End If
                'Se crédito e débito forem iguais a zero
                If .Cells("colCred").Value = 0 And .Cells("colDeb").Value = 0 Then
                    msg &= "Coluna de Crédito E Débito são zero na linha " & i + 1 & vbCrLf
                    Ret = False
                End If
                'Se coluna das contas for zeero
                If .Cells("colCTCred").Value = 0 Or .Cells("colCTDeb").Value = 0 Then
                    msg &= "Um dos códigos é Zero na linha " & i + 1 & vbCrLf
                End If

                
            End With
        Next

        'Se existir alguma consideração
        If msg.Length > 0 Then
            MsgBox("Existem algumas inconsistências nas linhas a serem inseridas, veja abaixo:" & vbCrLf & vbCrLf & msg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Erro")
            Return Ret
        Else
            Return True
        End If

    End Function
End Class