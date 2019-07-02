Public Class frmRecuperacao
    'Flag para determinar o lote ativo
    Dim FLAG As Boolean = False

    Private Sub frmRecuperacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub frmRecuperacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dimensiona os vetores para formatação do datagrid
        Dim heaFrascos() As String = {"Merc", "Lote", "Clone", "Frasco", "Nº Mudas", "Motivo", "ID", "Cód"}
        Dim widFrascos() As Integer = {50, 50, 50, 50, 77, 50, 50, 50}
        Dim visFrascos() As Integer = {1, 1, 1, 1, 1, 1, 1, 1}
        Dim heaRecuperados() As String = {"Nº Frasco", "Nº Mudas"}
        Dim widRecuperados() As Integer = {70, 70}
        Dim visRecuperados() As Integer = {1, 1}

        'Preenche a data no campo data
        txtData.Text = Format(Today(), "dd/MM/yyyy")
        cmbMotivo.Text = "Fungo"
        'Formata o datagrid com os headers e tamahos

        'Define a primeira coluna (morta)
        dgFrascos.RowHeadersWidth = 20
        dgRecuperados.RowHeadersWidth = 20

        'Usa a funcao genérica para formatar o datagrid
        Formata_Datagrid(dgFrascos, heaFrascos, widFrascos, visFrascos)
        Formata_Datagrid(dgRecuperados, heaRecuperados, widRecuperados, visRecuperados)

        'Move o posicionamento para a primeira aba
        TabRecuperacao.SelectedTab = Tab1
        'Move o foco para o código de barras
        txtCodigoBarras.Focus()
    End Sub

    Private Sub btConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirma.Click
        Dim Resp As Boolean
        'Tenta a fazer a exclusão 
        Resp = Baixa_Frascos(dgFrascos, dsFrascos, txtData, 1)
        If Resp Then
            'Atualiza as labels e move a tab para o controle
            lblPasso1.Enabled = False
            lblPasso2.Enabled = True
            lblPasso3.Enabled = False
            TabRecuperacao.SelectedTab = Tab2
            'Move o foco para a caixa de texto nFrascos
            txtNFrascos.Focus()
        Else
            txtCodigoBarras.Text = String.Empty
            txtCodigoBarras.Focus()
        End If

        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgRecuperados.Rows.Count > 0 Then
            Dim SQL As String, SQLLotes As String, NMudas As Integer
            'monta a SQL base
            SQL = "INSERT INTO aux_frascos (Lote,Vidro,NMudas,Impresso,Selecao) VALUES "
            'Com o grid de recuperados
            With dgRecuperados
                'Roda todas as linhas para pegar os valores
                For i As Integer = 0 To dgRecuperados.Rows.Count - 1
                    'Se for a primeira vez que passa aqui não usa virgula
                    If i = 0 Then
                        SQL &= "(" & lblID.Text & "," & .Rows(i).Cells(0).Value & "," & .Rows(i).Cells(1).Value & ",0,0)"
                    Else    'Senão usa
                        SQL &= ",(" & lblID.Text & "," & .Rows(i).Cells(0).Value & "," & .Rows(i).Cells(1).Value & ",0,0)"
                    End If
                    'Vai somando o número total de mudas
                    NMudas += .Rows(i).Cells(1).Value
                Next i
            End With
            'Monta a SQL para atualizar o estoque no cadastro de lotes
            SQLLotes = "UPDATE Lotes SET Estoque=Estoque+" & NMudas.ToString & ",Est_frascos=Est_Frascos+" & dgRecuperados.Rows.Count & " WHERE id=" & lblID.Text

            'Debug
            Console.WriteLine(SQL)
            Console.WriteLine(SQLLotes)
            Try
                'Executa a sql de inserção
                ExecutaSQL(SQL)
                ExecutaSQL(SQLLotes)
            Catch ex As Exception
                MsgBox("Erro ao atualizar o banco de dados." & vbCrLf & ex.Message & vbCrLf & ex.ToString)
                Exit Sub
            End Try

            'Atualiza as labels
            lblPasso1.Enabled = False
            lblPasso2.Enabled = False
            lblPasso3.Enabled = True
            'Altera a TAB ativa
            TabRecuperacao.SelectedTab = Tab3
        Else
            MsgBox("É necessário incluir pelo menos um frasco.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As Integer
        'Pergunta ao usuario se ele quer recuperar mais algum lote
        a = MsgBox("Deseja recuperar algum outro lote?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmação")
        If a = vbYes Then
            'Utiliza a função para finalizar a edição
            Finaliza_Edicao()
            'Move o foco para a caixa do código de barras
            txtCodigoBarras.Focus()
        Else
            'Fecha o formulario
            Me.Close()
        End If
        Finaliza_Edicao()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtNFrascos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNFrascos.Enter
        'Seleciona todo o texto
        txtNFrascos.SelectAll()
    End Sub

    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        Dim i As Integer, Max As Integer

        'Verifica qual o maior numero de frasco desde lote
        Max = DMax("Vidro", "aux_frascos", "Lote=" & lblID.Text)
        'Se o lote não tiver mais frascos
        If IsDBNull(Max) Or IsNothing(Max) Then
            'Então zera o número de frascos
            Max = 0
        End If
        'Se retornou alguma coisa
        'If Max <> Nothing Then
        For i = (Max + 1) To (Max + Int(txtNFrascos.Text))
            'inclui a linha no DATA SET e por conseguencia no datagrid
            dsFrascos.Tables(1).Rows.Add(i, txtM_f.Text)
        Next i
        'End If
        dgRecuperados.Enabled = True
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SQL As String, ct As Integer, Descricao As String, CodBase As String
        Dim Data As String
        'Descrição já está pronta no cabecalho
        Descricao = lblLote.Text
        'Separa o código em pedaços
        CodBase = Descricao
        'usa o artificio para retirar os pontos do código
        CodBase = CodBase.Replace(".", "")

        Data = Format(CDate(lblData.Text), "dd/MM/yy")

        'Monta a SQL padrão
        SQL = "INSERT INTO etiquetas_prn VALUES "
        Try
            'Faz o looping com todos as etiquetas deste lote(datagrid)
            For ct = 0 To dgRecuperados.RowCount - 1
                'Se for a segunda vez que passa aqui poe uma virgula
                If ct > 0 Then
                    SQL = SQL & ","
                End If
                'Vai montando a SQL
                SQL = SQL & "(null,'" & Descricao & "','" & CodBase & Format(CInt(dgRecuperados.Rows(ct).Cells(0).Value), "000") & "','" & Data & "'," & Format(CInt(dgRecuperados.Rows(ct).Cells(1).Value), "000") & ")"
            Next ct
        Catch ex As Exception
            MsgBox("Erro na geração das etiquetas!" & vbCr & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

        'Tenta Executar a SQL montada
        Try
            ExecutaSQL(SQL)
            'Se deu tudo certo vai adiante
            MsgBox(Format(ct, "000") & " Etiquetas enviadas para impressão!", MsgBoxStyle.OkOnly, "Confirmação")
            lblImpressas.Text = "Etiquetas Impressas - OK"
        Catch ex As Exception
            MsgBox("Erro ao enviar as etiquetas para impressão!" & vbCr & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            Exit Sub
        End Try
        'Marca todas as etiquetas desta lote como impressas
        Try
            SQL = "UPDATE aux_frascos SET Impresso=1 WHERE Lote=" & lblID.Text
            'Tenta marcar os frascos
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao marcar as etiquetas como impressas!" & vbCr & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Erro")
            Exit Sub
        End Try
    End Sub

    Sub Finaliza_Edicao()
        'Atualiza os rótulos de dados
        lblLote.Text = "000.000.0000"
        lblID.Text = "0000"
        lblData.Text = "00/00/0000"
        'Muda para aba 1 e atualiza os rótulos de dados
        lblPasso1.Enabled = True
        lblPasso2.Enabled = False
        lblPasso3.Enabled = False
        TabRecuperacao.SelectedTab = Tab1
        'Apaga todas as caixas de texto
        txtData.Text = Format(DateTime.Today, "dd/MM/yyyy")
        txtCodigoBarras.Text = String.Empty
        cmbMotivo.Text = "Fungos"
        txtNFrascos.Text = "0"
        txtM_f.Text = "0"
        'Apaga os dados contidos nas duas tabelas
        dsFrascos.Tables(0).Clear()
        dsFrascos.Tables(1).Clear()
        'Label de etiquestas impressas
        lblImpressas.Text = "  "
        'Dasabilita a edição dos frascos
        dgRecuperados.Enabled = False
        'Define a flag para o novo lote
        FLAG = False
    End Sub

    Private Sub txtNCont_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNCont.LostFocus
        Dim Resposta As Integer = Nothing
        'Coloca o cursor em espera
        Me.Cursor = Cursors.WaitCursor
        'Usa a função compartilhada no Modulo Generico arquivo Biblioteca.vb
        Resposta = Adiciona_Frasco(dgFrascos, dsFrascos, txtCodigoBarras, cmbMotivo, txtTotal)
        'se for a primeira vez que passa aqui
        If (Not FLAG) And (Resposta <> -1) Then
            'Coloca o código do lote na label
            lblID.Text = Format(Resposta, "####")
            'Retorna o código do lote em forma de texto
            lblLote.Text = Procura_Lote(Int(lblID.Text))
            'Já procura a data do lote na primeira passada
            lblData.Text = DLookup("Data", "lotes", "id=" & Resposta)
            'Seta a flag para que ele não tenha que ficar procurando toda vez
            FLAG = True
        End If
        'Corrige os frascos contaminados
        If (Resposta <> -1) Then
            'Vai na última linha e troca o valor do frasco
            dgFrascos.Rows(dgFrascos.Rows.Count - 1).Cells(4).Value = txtNCont.Text
        End If
        'Volta o cursor ao normal
        Me.Cursor = Cursors.Arrow
        'Limpa a caixa de texto 
        txtNCont.Text = String.Empty
    End Sub

End Class