Public Class frmRastreamentoLotes

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Primeiro verifica se não está vazio
        If txtCodigo.Text = String.Empty Then
            Exit Sub
        End If
        'Se o código for muito curto
        If txtCodigo.Text.Length < 11 Then
            MsgBox("Código do lote inválido", MsgBoxStyle.Critical, "Erro")
            txtCodigo.Text = String.Empty
            txtCodigo.Focus()
            Exit Sub
        End If

        'Agora tira todos os pontos do código
        Dim Codigo As String
        Codigo = txtCodigo.Text.Replace(".", "")

        'Verifica como é que o usuário digitou, ou se ele scaneou o código
        Select Case Codigo.Length
            Case 14 '00230580000067 (Lido com código de barras)
                'Separa as porções de código
                txtMercadoria.Text = Int(Codigo.Substring(1, 3))
                txtLote.Text = Int(Codigo.Substring(4, 3))
                txtClone.Text = Int(Codigo.Substring(7, 4))
            Case 9  '230580000 (Digitado à mão, mas já sem os pontos)
                'Separa as porções de código
                txtMercadoria.Text = Int(Codigo.Substring(0, 2))
                txtLote.Text = Int(Codigo.Substring(2, 3))
                txtClone.Text = Int(Codigo.Substring(5, 4))
            Case 10  '0230580000 (Digitado à mão, mas já sem os pontos)
                'Separa as porções de código
                txtMercadoria.Text = Int(Codigo.Substring(0, 3))
                txtLote.Text = Int(Codigo.Substring(3, 3))
                txtClone.Text = Int(Codigo.Substring(6, 4))
            Case Else
                MsgBox("O código não pode ser identificado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
                txtCodigo.Text = String.Empty
                txtCodigo.Focus()
                Exit Sub
        End Select

        'Localizar o ID do lote em questão
        Dim DT As DataTable
        DT = SQLQuery("SELECT id,origem,mercadoria,lote,clone,Est_Inicial,Contaminacao, DATA, fase, (SELECT est_inicial-contaminacao AS nmudas FROM lotes AS lotes2 WHERE id=lotes.origem) AS mudas_ori FROM lotes WHERE Mercadoria=" & txtMercadoria.Text & " AND Lote=" & txtLote.Text & " AND Clone=" & txtClone.Text & " AND Ativo=1")
        'Se não foi localizado nenhuma linha
        If DT.Rows.Count <= 0 Then
            MsgBox("Nenhum lote ativo encontrado paara este código!", MsgBoxStyle.Critical, "Erro")
            txtCodigo.Text = String.Empty
            txtCodigo.Focus()
            Exit Sub
        End If
        'Pega a linha que foi localizada
        Dim DR As DataRow = DT.Rows(0)

        Dim varNOrigem As Double = 0

        If Not IsDBNull(DR("mudas_ori")) And Not IsDBNull(DR("est_inicial")) Then
            varNOrigem = DR("est_inicial") / DR("mudas_ori")
        Else
            varNOrigem = 0
        End If

        'Primeira linha
        dsRastreio.Tables(0).Rows.Add(DR("id"), DR("Mercadoria") & "." & DR("Lote") & "." & DR("Clone"), DR("Est_Inicial"), varNOrigem, DR("Contaminacao") / DR("Est_inicial") * 100, DR("Data"), DR("Fase"), DR("Contaminacao"), DR("Est_inicial") - DR("Contaminacao"))

        Dim varOrigem As Integer = DR("Origem")
        'Agora começa a procurar os demais lotes
        While varOrigem > 0
            Dim varEstoque = 0
            Console.WriteLine("Origem=" & varOrigem)
            DT = SQLQuery("SELECT id,origem,mercadoria,lote,clone,Est_Inicial,Contaminacao, DATA, fase, (SELECT est_inicial-contaminacao AS nmudas FROM lotes AS lotes2 WHERE id=lotes.origem) AS mudas_ori FROM lotes WHERE id=" & varOrigem)
            'Se não foi localizado nenhuma linha
            If DT.Rows.Count <= 0 Then
                GoTo fim
            End If
            'Pega a linha que foi localizada
            DR = DT.Rows(0)

            If Not IsDBNull(DR("mudas_ori")) And Not IsDBNull(DR("est_inicial")) Then
                varNOrigem = DR("est_inicial") / DR("mudas_ori")
            Else
                varNOrigem = 0
            End If

            'Mostra o que restou para que desse aqueles valores
            varEstoque = DR("Est_Inicial") - DR("Contaminacao")

            'Linhas sequenciais
            dsRastreio.Tables(0).Rows.Add(DR("id"), DR("Mercadoria") & "." & DR("Lote") & "." & DR("Clone"), DR("est_inicial"), varNOrigem, DR("Contaminacao") / DR("Est_inicial") * 100, DR("Data"), DR("Fase"), DR("Contaminacao"), DR("Est_inicial") - DR("Contaminacao"))
            varOrigem = IIf(IsDBNull(DR("Origem")), -1, DR("Origem"))
        End While
Fim:
        'Fecha as estatisticas para o lote rastreado.
        Estatisticas()
    End Sub

    Private Sub Estatisticas()
        'Se tiver algo na tabela
        If dgRastro.Rows.Count > 0 Then
            'Percorre todos os resultados fazendo as somas
            Dim varMudas As Integer = 0, varMult As Double = 0, varCont As Double = 0, varDias As Integer = 0
            For i As Integer = 0 To dgRastro.Rows.Count - 1
                With dgRastro.Rows(i)
                    varMudas += .Cells(datMudas.Index).Value
                    varMult += .Cells(datTaxa.Index).Value
                    varCont += .Cells(datCont.Index).Value
                    'Conta os dias entre as datas (a partir da segunda linha)
                    If i > 0 Then
                        Dim Data_Atu As Date, Data_Ant As Date, Horas As TimeSpan
                        Data_Atu = .Cells(datData.Index).Value
                        Data_Ant = dgRastro.Rows(i - 1).Cells(datData.Index).Value
                        ' subtrai a data da data atual
                        Horas = Data_Ant.Subtract(Data_Atu)
                        'Calcula o número de dias entre as datas
                        varDias += Horas.Days
                    End If
                End With
            Next
            'Preenche os resultados
            Label10.Text = Format(varMudas, "N0")
            Label11.Text = Format(varCont / dgRastro.Rows.Count, "N1")
            Label12.Text = Format(varMult / dgRastro.Rows.Count, "N2")
            Label13.Text = dgRastro.Rows.Count
            Label15.Text = Int(varDias / dgRastro.Rows.Count)

        End If
    End Sub


    Private Sub txtCodigo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        'Muda para o controle seguinte
        EnterAsTab(sender, e)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Limpa todos os resultados
        txtCodigo.Text = String.Empty
        txtMercadoria.Text = "000"
        txtLote.Text = "000"
        txtClone.Text = "0000"
        Label10.Text = "..."
        Label11.Text = "..."
        Label12.Text = "..."
        Label13.Text = "..."
        Label15.Text = "..."
        txtCodigo.Focus()
        'Apaga todos os registros contidos no DataSet
        dsRastreio.Tables(0).Rows.Clear()
    End Sub

    Private Sub dgRastro_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRastro.CellContentDoubleClick
        Me.Cursor = Cursors.WaitCursor

        Dim ID As Integer = -1
        'Pega o ID do Lote
        ID = dgRastro.SelectedRows(0).Cells(0).Value

        'Monta uma nova instancia da Tela de Lotes
        Dim viewDetalhe As New frmNovoLotes("L", ID)
        'Define o MDI parent
        viewDetalhe.MdiParent = Me.MdiParent
        Me.Cursor = Cursors.Arrow
        'Por fim mostra o lote
        viewDetalhe.Show()
    End Sub
End Class