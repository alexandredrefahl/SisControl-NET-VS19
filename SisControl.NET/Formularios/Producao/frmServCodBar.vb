Public Class frmServCodBar

    Private Sub cmbMotivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivo.GotFocus
        'Se o automático estiver pressionado não há necessidade de ativar o enter
        If chkAuto.Checked Then
            'Procura o próximo controle
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbMotivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMotivo.KeyDown
        MoverFoco(Me, sender, e)
    End Sub

    Private Sub cmbMotivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivo.LostFocus
        If txtCodigoBarras.Text = String.Empty Then
            Exit Sub
        End If

        If cmbOperador.SelectedIndex = -1 Then
            MsgBox("Selecione um operador para a baixa.", MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        'Gambiarra para poder migrar de sistema pois todas as novas etiquetas não começam com o número do lote
        If (Len(txtCodigoBarras.Text) = 13) And (txtCodigoBarras.Text.Substring(0, 4) = "0000") Then
            Nova_Baixa()
            Exit Sub
        End If
        'Usa a função compartilhada no Modulo Generico arquivo Biblioteca.vb
        Adiciona_Frasco(dgFrascos, dsFrascos, txtCodigoBarras, cmbMotivo, txtTotal)
    End Sub

    Private Sub Nova_Baixa()
        Dim codMer As Integer, codLOT As Integer, codCLON As Integer, codFRA As Integer, Mudas As Integer, codVidro As Integer, codLote As Integer
        Dim DR As DataRow
        'Localiza o frasco scaneado
        DR = DLookupRow("aux_frascos", "(ISNULL(bxExclusao)) AND (id=" & txtCodigoBarras.Text & ")")

        'Verifica se veio a linha
        If IsNothing(DR) Then
            'Pesquisa o ID
            DR = DLookupRow("aux_frascos", "(id=" & txtCodigoBarras.Text & ")")
            'Se não achou nem o ID então avisa que o frasco naõ existe mais
            If IsNothing(DR) Then
                MsgBox("Frasco não encontrado ou não cadastrado!")
                GoTo Fim
            Else
                MsgBox("Este frasco já foi baixado em: " & DR("bxExclusao") & vbCrLf & "Operador: " & DLookup("Nome", "repicador", "id=" & DR("bxoperador")) & vbCrLf & "Motivo:   " & DR("bxmotivo"))
                GoTo Fim
            End If
        End If

        '## Acrescentar verificação se o frasco já consta.
        '##
        '** Tem que fazer manualmente mesmo para não alterar a ordem

        Dim frascoID As String = DR("id")
        'Pega o ID e verifica em todas as linhas
        For i As Integer = 0 To dgFrascos.RowCount - 1
            'Se encontrar então avisa a mensagem
            If dgFrascos.Rows(i).Cells("CoID").Value = frascoID Then
                MsgBox("Este frasco já está na lista!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Aviso")
                GoTo Fim
            End If
        Next

        'Tendo os dados em mãos, é só pegar na linha e ver o que precisa
        codLOT = DLookup("lote", "lotes", "id=" & DR("Lote"))
        If IsDBNull(DR("Variedade")) Or IsDBNull(DR("clone")) Then
            Dim DRL As DataRow
            DRL = DLookupRow("lotes", "id=" & DR("Lote"))
            codMer = DRL("Mercadoria")
            codCLON = DRL("Clone")
            DRL = Nothing
        Else
            codMer = DR("Variedade")
            codCLON = DR("Clone")
        End If

        codFRA = DR("Vidro")
        Mudas = DR("NMudas")
        codVidro = DR("id")
        codLote = DR("Lote")
        dsFrascos.Tables(0).Rows.Add(codMer, codLOT, codCLON, codFRA, Mudas, cmbMotivo.Text.Substring(0, 1), codVidro, codLote)
        'Conta o número de frascos
        txtTotal.Text = dsFrascos.Tables(0).Rows.Count

Fim:
        'Limpa o campo
        txtCodigoBarras.Text = String.Empty
        'Devolve o foco para ó código de barras 
        txtCodigoBarras.Focus()
    End Sub


    Private Sub frmServCodBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dimensiona os vetores para formatação do datagrid
        Dim Textos() As String = {"Merc", "Lote", "Clone", "Frasco", "Nº Mudas", "Motivo", "ID", "Cód"}
        Dim Tamanhos() As Integer = {50, 50, 50, 50, 77, 50, 50, 50}
        Dim visiveis() As Integer = {1, 1, 1, 1, 1, 1, 1, 1}

        'Formata o grid das orquideas
        Dim TextosO() As String = {"Id", "Lote", "Tipo", "Nº Mudas", "Vidro", "Motivo"}
        Dim TamanhosO() As Integer = {70, 70, 70, 77, 70, 70}
        Dim VisiveisO() As Integer = {1, 1, 1, 1, 1, 1}

        'Preenche a data no campo data
        txtData.Text = Format(Today(), "dd/MM/yyyy")
        txtDataO.Text = txtData.Text

        cmbMotivo.Text = "Fungo"
        cmbMotivoO.Text = "Fungo"

        'Formata o datagrid com os headers e tamahos
        'Define a primeira coluna (morta)
        dgFrascos.RowHeadersWidth = 20
        'Define a primeira coluna (morta)
        dgFrascosO.RowHeadersWidth = 20

        'Usa a funcao genérica para formatar o datagrid
        Formata_Datagrid(dgFrascos, Textos, Tamanhos, visiveis)
        Formata_Datagrid(dgFrascosO, TextosO, TamanhosO, VisiveisO)

        'Carrega a lista de quem está dando baixa
        Carrega_Lista(cmbOperador, "repicador", "id", "Nome", True, "Ativo=1")

        'Move o foco para o código de barras
        txtCodigoBarras.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtCodigoBarras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoBarras.KeyDown
        If e.KeyCode = Keys.F12 Then
            'Se pressionou F12 quando o código estava vazio então...
            If Len(txtCodigoBarras.Text) <= 0 Then
                'Chama o procedimento de encerrar
                Call btConfirma_Click(sender, e)
                GoTo fim
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            'se recebeu um enter então move o foco para o combo
            cmbMotivo.Focus()
        End If
Fim:
    End Sub

    Private Sub txtData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtData.KeyDown
        MoverFoco(Me, sender, e)
    End Sub

    Private Sub btConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirma.Click
        'Dimensiona a variavel resposta
        Dim Resp As Boolean
        'Utiliza as funções compartilhadas no arquivo Biblioteca.vb módulo Genérico
        'Estas funções são compartilhadas pela baixa de Frascos e pela recuperação de Frascos
        'Resp = Baixa_Frascos(dgFrascos, dsFrascos, txtData, cmbVal(cmbOperador))
        Baixa_Frascos_Novo()
        If Resp Then
            'Atualiza a contagem de frascos que vai ser Zero
            txtTotal.Text = dgFrascos.RowCount
            'Esvazia a caixa do código de barras
            txtCodigoBarras.Text = String.Empty
            'Move o foco para ela
            txtCodigoBarras.Focus()
        Else
            'Esvazia a caixa do código de barras
            txtCodigoBarras.Text = String.Empty
            'Move o foco para ela
            txtCodigoBarras.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Baixa_Frascos_Novo()
        'Conta quantas entradas tem
        Dim Num As Integer = dgFrascos.RowCount

        If Num <= 0 Then
            MsgBox("Não há elementos na lista para serem processados", vbOKCancel + vbCritical, "Erro")
            Exit Sub
        End If
        'processa todos os frascos

        'String que irá guardar a lista de todos os lotes processados
        Dim Lista_Lotes As String = String.Empty

        For i As Integer = 0 To Num - 1
            'Lote anterior no primeiro caso é o primeiro lote
            Dim frascoID As Integer = dgFrascos.Rows(i).Cells("coID").Value
            'Atualiza a baixa do frasco com o motivo e a contaminação
            Dim SQL As String = "UPDATE aux_frascos SET bxExclusao=CURRENT_TIMESTAMP, bxMotivo='" & dgFrascos.Rows(i).Cells("colMotivo").Value & "', bxOperador=" & cmbVal(cmbOperador) & " WHERE id=" & frascoID
            'Console.WriteLine(SQL)
            'Consolida no Banco de Dados
            ExecutaSQL(SQL)
            'Atualiza o estoque do lote reduzindo o número de frascos e atualizando o estoque.
            SQL = "UPDATE lotes SET Est_frascos=est_frascos-1, Estoque=Estoque-" & dgFrascos.Rows(i).Cells("colMUD").Value
            'Inclui a contaminação específica (Motivo)
            Select Case dgFrascos.Rows(i).Cells("colMotivo").Value
                Case "F"
                    SQL &= ", fungo=fungo+" & dgFrascos.Rows(i).Cells("colMUD").Value
                    SQL &= ", Contaminacao=Contaminacao+" & dgFrascos.Rows(i).Cells("colMUD").Value
                Case "B"
                    SQL &= ", bacteria=bacteria+" & dgFrascos.Rows(i).Cells("colMUD").Value
                    SQL &= ", Contaminacao=Contaminacao+" & dgFrascos.Rows(i).Cells("colMUD").Value
                Case "O"
                    SQL &= ", oxidacao=oxidacao+" & dgFrascos.Rows(i).Cells("colMUD").Value
                    SQL &= ", Contaminacao=Contaminacao+" & dgFrascos.Rows(i).Cells("colMUD").Value
            End Select
            'Acrescenta a clausula condicinal
            SQL &= " WHERE id=" & dgFrascos.Rows(i).Cells("coCOD").Value
            'Efetiva no Banco de dados
            ExecutaSQL(SQL)

            'Reune a lista de todos os lotes processados.
            'Procura o lote atual dentro da string, se não houver, acrescenta
            If Lista_Lotes.IndexOf(dgFrascos.Rows(i).Cells("coCOD").Value) < 0 Then
                'Se não for a primeira vez que passa aqui
                If Lista_Lotes.Length > 0 Then
                    'Se não for a primeira então vai colocando a virgula.
                    Lista_Lotes &= "," & dgFrascos.Rows(i).Cells("coCOD").Value
                Else
                    'Se for a primeira vez
                    Lista_Lotes = dgFrascos.Rows(i).Cells("coCOD").Value
                End If

            End If
        Next i


        dsFrascos.Tables(0).Clear()
        txtTotal.Text = 0
        txtCodigoBarras.Text = String.Empty
        txtCodigoBarras.Focus()
    End Sub


    Private Sub cmbMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivo.SelectedIndexChanged
        Dim a As Integer
        'Se quando for selecionado Plantio ou Repicagem perguntar se quer
        'Ativar o modo automático
        If (Mid(cmbMotivo.Text, 1, 1) = "P") Or (Mid(cmbMotivo.Text, 1, 1) = "P") Then
            a = MsgBox("Verificação de modo Plantio ou Repicagem" & vbCrLf & "Deseja ativar o modo automático?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Sugestão")
            'Se sim então
            If a = vbYes Then
                'Ativo o checkbox
                chkAuto.Checked = True
                'Move o foco para o campo de código de barras
                txtCodigoBarras.Focus()
            Else
                'Move o foco para o campo de código de barras
                txtCodigoBarras.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btFechaO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechaO.Click
        Me.Close()

    End Sub

    Private Sub cmbMotivoO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivoO.GotFocus
        'Se o automático estiver pressionado não há necessidade de ativar o enter
        If chkAutoO.Checked Then
            'Procura o próximo controle
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbMotivoO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMotivoO.KeyDown
        If e.KeyCode = Keys.Enter Then
            EnterAsTab(sender, e)
        End If
    End Sub

    Private Sub cmbMotivoO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivoO.LostFocus
        Dim DT As DataTable, DR As DataRow
        'Agora quando perde o foco é que preenche o datagrid
        'se houver código de barras
        If Not txtCodBarO.Text = String.Empty Then
            'verifica se ó código é válido
            If txtCodBarO.Text.Length > 7 Or txtCodBarO.Text.Length < 5 Then
                MsgBox("Código de barras incorreto, favor verificar", MsgBoxStyle.Critical, "Erro")
                GoTo fim
                Exit Sub
            End If
            'Pega os dados da linha selecionada
            DT = SQLQuery("SELECT * FROM aux_germinacao WHERE Id=" & Val(txtCodBarO.Text))
            'Tenta pegar a linha selecionada
            Try
                'Pega a linha
                DR = DT.Rows(0)
            Catch ex As Exception
                MsgBox("Frasco não encontrado!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Erro")
                GoTo fim
                Exit Sub
            End Try
            'Faz a verificação para atestar se o frasco já está na lista

            'Com o parametro especificado
            With dgFrascosO
                'Procura pelo frasco existente
                For i As Integer = 0 To .RowCount - 1
                    'se achar o id coincidente
                    If .Rows(i).Cells(0).Value = Val(txtCodBarO.Text) Then
                        MsgBox("Este frasco já está na lista!", vbExclamation, "AVISO")
                        GoTo fim
                    End If
                Next
            End With

            'Preenche uma nova linha no datagrid
            'inclui a linha no DATA SET e por conseguencia no datagrid
            dsFrascos.Tables(1).Rows.Add(DR("id"), DR("Lote"), DR("Tipo"), DR("nMudas"), DR("Vidro"), cmbMotivoO.Text.Substring(0, 1))
            DR = Nothing
            DT = Nothing
            'Conta o número de frascos
            txtTotalO.Text = dsFrascos.Tables(1).Rows.Count
        End If
fim:
        'Limpa o código de barras
        txtCodBarO.Text = String.Empty
        'move o foco para lá
        txtCodBarO.Focus()
    End Sub

    Private Sub cmbMotivoO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivoO.SelectedIndexChanged
        Dim a As Integer
        'Verifica se é repicagem e pergunta Se deve ser ativado o automático
        If chkAutoO.Checked = False Then
            'Se o motivo for Repicagem ou plantio
            If cmbMotivoO.Text.StartsWith("R") Or cmbMotivoO.Text.StartsWith("P") Then
                a = MsgBox("Verificação de modo Plantio ou Repicagem" & vbCrLf & "Deseja ativar o modo automático?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
                'Se sim então
                If a = vbYes Then
                    'Ativo o checkbox
                    chkAutoO.Checked = True
                    'Move o foco para o campo de código de barras
                    txtCodBarO.Focus()
                Else
                    'Move o foco para o campo de código de barras
                    txtCodBarO.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub txtCodBarO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodBarO.KeyDown
        If e.KeyCode = Keys.F12 Then
            'Se pressionou F12 quando o código estava vazio então...
            If txtCodigoBarras.Text.Length <= 0 Then
                'Chama o procedimento de encerrar
                Call btConfirmaO_Click(sender, e)
                GoTo fim
            End If
        End If
        MoverFoco(Me, sender, e)
Fim:
    End Sub


    Private Sub btConfirmaO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfirmaO.Click
        Dim Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, NS As Integer
        Dim SF, SB, SO, SR As Integer, SQL_Exclusao As String
        Dim i As Int16, LoteOLD As String, a As Boolean

        'Inicializa as variáveis
        Fungo = 0
        Bacteria = 0
        Oxidacao = 0
        Plantio = 0
        Repicagem = 0
        SF = 0
        SB = 0
        SO = 0
        SR = 0
        NF = 0
        NS = 0
        LoteOLD = String.Empty
        SQL_Exclusao = String.Empty

        'Primeiro ordenar por lote (para fazer os descontos e acrescimos por lote
        dgFrascosO.Sort(dgFrascosO.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

        pgProcesso.Minimum = 0
        pgProcesso.Maximum = dgFrascosO.RowCount - 1
        pgProcesso.Value = 0

        'Passa por todos os registros
        For i = 0 To dgFrascosO.RowCount - 1
            With dgFrascosO.Rows(i)
                If i = 0 Then
                    LoteOLD = .Cells(1).Value.ToString
                End If
                'Se estamos trabalhando no lote atural
                If .Cells(1).Value.ToString = LoteOLD Then
                    'Usa a funcao de soma desenvolvida para fazer o resumo
                    Soma(Fungo, Bacteria, Oxidacao, Plantio, Repicagem, SF, SB, SO, SR, NF, NS, i)
                    'Acrescenta na lista de ID que serão excluidos
                    If SQL_Exclusao = String.Empty Then
                        'Se for a primeira vez deixa assim
                        SQL_Exclusao &= .Cells(0).Value.ToString
                    Else
                        'Se já for mais vezes tem que por a virgula antes
                        SQL_Exclusao &= "," & .Cells(0).Value.ToString
                    End If
                Else
                    'Se o lote atual for diferente do anterior
                    'Processa o lote faz as inclusoes necessárias e reinicializa as variáveis
                    a = Processa_Frascos(LoteOLD, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, SF, SB, SO, SR, NS, SQL_Exclusao)
                    'Reinicializa as variáveis
                    Fungo = 0
                    Bacteria = 0
                    Oxidacao = 0
                    Plantio = 0
                    Repicagem = 0
                    SF = 0
                    SB = 0
                    SO = 0
                    SR = 0
                    NF = 0
                    NS = 0
                    'Zera a sql de exclusao e comeca com o valor do lote atual
                    SQL_Exclusao = .Cells(0).Value.ToString
                    'Soma o do lote atual
                    Soma(Fungo, Bacteria, Oxidacao, Plantio, Repicagem, SF, SB, SO, SR, NF, NS, i)
                    'Loteold fica sendo o lote atual
                    LoteOLD = .Cells(1).Value.ToString
                End If
                If i = dgFrascosO.RowCount - 1 Then
                    a = Processa_Frascos(LoteOLD, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, NF, SF, SB, SO, SR, NS, SQL_Exclusao)
                End If
                'Verifica se o lote é o mesmo do anterior
                'Atualiza a barra de progresso
                pgProcesso.Value = i
                'Garante a atualização da barra de progresso na hora
                pgProcesso.Refresh()
            End With
        Next
        'Limpa o datagrid
        'Tudo acabado pode-se limpar o datagrid para a proxima etapa
        dsFrascos.Tables(1).Clear()
        txtTotalO.Text = 0
        pgProcesso.Value = 0
    End Sub
    'Esta sub faz a soma das variáveis que é utilizada várias vezes
    Private Sub Soma(ByRef fungo, ByRef bacteria, ByRef oxidacao, ByRef plantio, ByRef repicagem, ByRef SF, ByRef SB, ByRef SO, ByRef SR, ByRef Nf, ByRef Ns, ByVal i)

        With dgFrascosO.Rows(i)
            'Se for um frasco com mudas então ve que tipo de contaminacao e desconta as mudas
            If .Cells(2).Value.ToString = "M" Then
                Select Case .Cells(5).Value.ToString
                    Case "F"
                        fungo += Val(.Cells(3).Value.ToString)
                    Case "B"
                        bacteria += Val(.Cells(3).Value.ToString)
                    Case "O"
                        oxidacao += Val(.Cells(3).Value.ToString)
                    Case "P"
                        plantio += Val(.Cells(3).Value.ToString)
                    Case "R"
                        repicagem += Val(.Cells(3).Value.ToString)
                End Select
                'Um frasco a mais processado
                Nf += 1
            ElseIf .Cells(2).Value.ToString = "S" Then
                Select Case .Cells(5).Value.ToString
                    Case "F"
                        SF += 1
                    Case "B"
                        SB += 1
                    Case "O"
                        SO += 1
                    Case "R"
                        SR += 1
                End Select
                'Um frasco de semente processado
                Ns += 1
            End If
        End With
    End Sub

    Private Function Processa_Frascos(ByVal Lote As String, ByVal Fungo As Integer, ByVal Bacteria As Integer, ByVal Oxidacao As Integer, ByVal Plantio As Integer, ByVal Repicagem As Integer, ByVal NF As Integer, ByVal SF As Integer, ByVal SB As Integer, ByVal SO As Integer, ByRef SR As Integer, ByVal NS As Integer, ByVal SQL_Exclusao As String) As Boolean
        'Primeiramente monta a SQL para atualizar o estoque do lote de germinação
        Dim SQL As String, TotalMudas As Integer, a As Integer
        Dim Est_F, Est_S, Est_P As Int16, Cod As String

        Cod = String.Empty

        SQL = "UPDATE Germinacao SET "
        TotalMudas = Fungo + Bacteria + Oxidacao + Plantio + Repicagem
        SQL &= "NMudas=Nmudas-" & TotalMudas & ","
        SQL &= "NSementes=NSementes-" & NS & ","
        SQL &= "Frascos=Frascos-" & NF & ","
        SQL &= "F=F+" & Fungo & ","
        SQL &= "B=B+" & Bacteria & ","
        SQL &= "O=O+" & Oxidacao & ","
        SQL &= "P=P+" & Plantio & ","
        SQL &= "R=R+" & Repicagem & ","
        SQL &= "SF=SF+" & SF & ","
        SQL &= "SB=SB+" & SB & ","
        SQL &= "SO=SO+" & SO & ","
        SQL &= "SR=SR+" & SR & ""
        SQL &= " WHERE(Id=" & Lote & ");"
        SQL_Exclusao = "DELETE FROM aux_germinacao WHERE id IN(" & SQL_Exclusao & ");"
        'Debug
        Console.WriteLine(Me.Name & ": " & SQL)
        Console.WriteLine(Me.Name & ": " & SQL_Exclusao)
        'Executa a SQL de processamento dos frascos
        Try
            ExecutaSQL(SQL)
            ExecutaSQL(SQL_Exclusao)
            'Consulta o lote para ver como estão os estoques
            'Se tiver algum estoque zerado tem de inativar o lote.
            Est_S = DLookup("NSementes", "germinacao", "id=" & Lote)
            Est_F = DLookup("Frascos", "germinacao", "id=" & Lote)
            Est_P = DLookup("NPlantadas", "germinacao", "id=" & Lote)
            Cod = DLookup("Cod", "germinacao", "id=" & Lote)
            'Se todos os estoques estiverem zerados então anula o lote
            If Est_S <= 0 And Est_F <= 0 And Est_P <= 0 Then
                a = MsgBox("O estoque do lote " & Cod & " (" & Lote & ") é menor ou igua a ZERO" & vbCrLf & "Sementes: " & Est_S & vbCrLf & "Mudas: " & Est_F & vbCrLf & "Plantadas: " & Est_P & vbCrLf & "Deseja desativar o lote?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação")
                'Se for confirmado
                If a = vbYes Then
                    SQL = "UPDATE Germinacao SET Ativo=0,Inativado=NOW() WHERE id=" & Lote
                    Try
                        'Tenta executar a SQL
                        ExecutaSQL(SQL)
                    Catch ex As Exception
                        MsgBox("Erro ao tentar inativar o lote " & Cod & " (" & Lote & ")" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                        Return False
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o estoque de frascos de orquídeas no lote " & Cod & " (" & Lote & ")" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            'se deu erro já retorna por aqui como falso
            Return False
        End Try
        'Se deu tudo certo retorna verdadeiro
        Return True
    End Function

    Private Sub TabLotes_Click(sender As Object, e As EventArgs) Handles TabLotes.Click

    End Sub
End Class