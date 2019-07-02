Public Class frmPlantio
    Public varPlantador As String, varID As Double
    'Vari�veis utilizadas na conex�o mysql
    Private MyCON As MySql.Data.MySqlClient.MySqlConnection
    Private MyCMD As MySql.Data.MySqlClient.MySqlCommand
    Private MyADA As MySql.Data.MySqlClient.MySqlDataAdapter

    Dim Ordem_Producao As Integer

    Private Sub frmPlantio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        EnterAsTab(sender, e)
    End Sub

    Private Sub frmPlantio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega lista de funcion�rios
        Carrega_Lista(lstPlantador, "Repicador", "id", "Nome", True, "Ativo=1")
        'Carrega lista de clientes no combo
        Carrega_Lista(cmbCliente, "Clientes", "id", "Nome", True)

        If Not Ordem_Producao = -1 Then
            Carrega_Ordem()
        End If

    End Sub

    Private Sub Carrega_Ordem()
        Dim DR As DataRow

        'Recupera os dados da ordem de produ��o que vai ser preenchida
        Try
            DR = DLookupRow("programacao", "id=" & Ordem_Producao)
            If Not IsDBNull(DR) And Not IsNothing(DR) Then
                'Preenche os dados que vieram da programa��o
                txtMercadoria.Text = DR("Mercadoria")
                txtClone.Text = DR("Clone")
                txtNMudas.Text = DR("Mudas")
                txtSubstrato.Text = "Casca de Pinus"

            End If
        Catch ex As Exception

        End Try

        'Troca a cor dos campos que devem ser preenchidos
        'Muda a cor de fundo dos dados que devem ser preenchidos
        Dim cor As System.Drawing.Color
        cor = Color.Khaki

        txtData.BackColor = cor
        txtNBandejas.BackColor = cor
        lstPlantador.BackColor = cor

    End Sub

    Private Sub txtMercadoria_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMercadoria.Enter
        txtMercadoria.SelectAll()
    End Sub

    Private Sub txtClone_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClone.Enter
        txtClone.SelectAll()
    End Sub

    Private Sub txtSubstrato_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubstrato.Enter
        txtSubstrato.SelectAll()
    End Sub

    Private Sub lstPlantador_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPlantador.Leave
        Dim o As Object, num As Integer
        Dim m As ListBox.SelectedObjectCollection = lstPlantador.SelectedItems

        'Se n�o tiver nada selecionado
        If IsDBNull(m) Then
            'sai da rotina
            Exit Sub
        End If
        'sen�o processa cada item da lista
        varPlantador = String.Empty
        num = m.Count
        'Define um contador
        Dim i As Integer = 1
        For Each o In m
            If i < num Then
                'soma os numeros em varRepicador
                varPlantador = varPlantador & o.valor.ToString & ";"
            Else
                'soma os numeros em varRepicador
                varPlantador = varPlantador & o.valor.ToString
            End If
            i = i + 1
        Next
        'debug
        Console.WriteLine("VarPlantador=" & varPlantador)
    End Sub

    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click

        '*
        '* FAZ ALGUMAS VERIFICA��ES
        '*

        If txtMercadoria.Text = String.Empty Or txtMercadoria.Text = "0" Then
            MsgBox("O c�digo da mercadoria deve ser infomado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        If txtClone.Text = String.Empty Then
            MsgBox("O c�digo do clone deve ser informado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        If txtNBandejas.Text = String.Empty Or txtNBandejas.Text = "0" Then
            MsgBox("O n�mero de bandejas deve ser informado e n�o pode ser Zero", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        If txtNMudas.Text = String.Empty Or txtNMudas.Text = "0" Then
            MsgBox("O n�mero de mudas deve ser informado e n�o pode ser zero", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If

        If lstPlantador.SelectedItems.Count <= 0 Then
            MsgBox("� necess�rio informar a pessoa que plantou o lote.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aviso")
            Exit Sub
        End If



        Dim SQL As String, i As Integer

        SQL = "INSERT INTO plantio (Data,Num_Mudas,Bandeja,Mercadoria,Substrato,Cliente,Plantador,Num_Bandejas,Clone) VALUES "
        SQL = SQL & "('" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "'," & txtNMudas.Text & "," & Retorna_Bandeja() & "," & txtMercadoria.Text
        SQL = SQL & ",'" & txtSubstrato.Text & "'," & cmbVal(cmbCliente) & ",'" & varPlantador & "'," & txtNBandejas.Text & "," & txtClone.Text & ")"

        Try
            'Tenta incluir os dados
            ExecutaSQL(SQL)

            'Se esse lote veio de uma ordem de produ��o ent�o d� baixa da Ordem de Produ��o tamb�m
            If Ordem_Producao <> -1 Then
                SQLQuery("UPDATE Programacao SET DataBaixa='" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "' WHERE id=" & Ordem_Producao)
            End If

            'Se conseguir segue adiante
            varID = DMax("id", "plantio")
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir o plantio" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        'Habilita os dois quadros
        grpPlantio.Enabled = False
        lblPlantio.Visible = True
        lblPlantio.Text = "Plantio: " & StrZero(varID, 4)
        grpBandejas.Enabled = True
        grpOrigem.Enabled = True

        'Inclui as bandejas automaticamente no cadastro de bandejas
        SQL = "INSERT INTO aux_bandejas (Tipo,Mudas,NAtual,Ativo,Mercadoria,Clone,Plantio,Data) VALUES "
        Dim n As Integer = Val(txtNBandejas.Text), nMudas As Integer
        For i = 1 To n
            nMudas = Retorna_Bandeja()
            'se for a �ltima passada
            If i = n Then
                'Quanto seria todas as bandejas completas - o que falta para o informado
                nMudas = Retorna_Bandeja() - ((Val(txtNBandejas.Text) * Retorna_Bandeja()) - Val(txtNMudas.Text))
            End If
            SQL = SQL & "(" & Retorna_Bandeja() & "," & nMudas & "," & nMudas & ",1," & txtMercadoria.Text & "," & txtClone.Text & "," & varID & ",'" & Format(CDate(txtData.Text), "yyyy-MM-dd") & "')"
            'Se n�o for a ultima acrescenta uma v�rgula para montar a SQL
            If i < n Then
                SQL = SQL & ","
            End If
        Next i
        Try
            'Tenta fazer a inclus�o
            ExecutaSQL(SQL)
        Catch ex As Exception
            'Manda mensagem caso de errado
            MsgBox("Erro ao tentar incluir as bandejas no banco de dados" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        'Atualiza o grid de bandejas
        Atualiza_Grid_Bandejas("SELECT id,tipo,mudas FROM aux_bandejas WHERE Plantio=" & varID)
        'Debug
        'Console.WriteLine(SQL)
        txtCodigo.Focus()
        txtCodigo.SelectAll()
    End Sub
    Private Function valida_inclusao() As Boolean
        If txtMercadoria.Text.Length = 0 Or txtMercadoria.Text = "0" Then
            MsgBox("� necess�rio informar o c�digo da mercadoria", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If txtClone.Text.Length = 0 Then
            MsgBox("� necess�rio informar o c�digo do clone", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If txtData.Text = "__/__/__" Then
            MsgBox("� necess�rio informar a data do plantio", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        Try
            Dim tData As Date = CDate(txtData.Text)
        Catch ex As Exception
            MsgBox("A data digitada n�o � uma data v�lida. Verifique a digita��o novamente", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End Try
        If txtNMudas.Text.Length = 0 Or txtNMudas.Text = "0" Then
            MsgBox("� necess�rio que seja digitada a quantidade de mudas", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If txtNBandejas.Text.Length = 0 Or txtNBandejas.Text = "0" Then
            MsgBox("� necess�rio que seja digitada a quantidade de bandejas", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If cmbCliente.Text.Length = 0 Then
            MsgBox("� necess�rio informar o cliente", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If txtSubstrato.Text.Length = 0 Or txtSubstrato.Text = "0" Then
            MsgBox("� necess�rio informar o tipo de substrato utilizado", MsgBoxStyle.Exclamation, "Aviso")
            GoTo falso
        End If
        If rd72.Checked = False And rd128.Checked = False And rd255.Checked = False And rd450.Checked = False Then
            MsgBox("� necess�rio informar qual o tipo de bandeja utilizado no plantio!", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End If

        'Se passou por todas as regras
        GoTo Verdadeiro
Falso:
        valida_inclusao = False
        Exit Function

Verdadeiro:
        valida_inclusao = True
        Exit Function
    End Function
    Private Function Retorna_Bandeja() As String
        'Valor padr�o Vazio
        Retorna_Bandeja = String.Empty
        'Verifica qual Radio est� selecionado e retorna como strign
        If rd70.Checked = True Then
            Retorna_Bandeja = "70"
            GoTo fim
        End If
        If rd72.Checked = True Then
            Retorna_Bandeja = "72"
            GoTo fim
        End If
        If rd128.Checked = True Then
            Retorna_Bandeja = "128"
            GoTo fim
        End If
        If rd255.Checked = True Then
            Retorna_Bandeja = "255"
            GoTo fim
        End If
        If rd450.Checked = True Then
            Retorna_Bandeja = "450"
            GoTo fim
        End If
FIM:
    End Function

    Private Sub txtNMudas_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNMudas.Leave
        'Tenta calcular o tipo da bandeja utilizada
        If (Val(txtNMudas.Text) Mod 70) = 0 Then
            rd70.Checked = True
        End If
        If (Val(txtNMudas.Text) Mod 72) = 0 Then
            rd72.Checked = True
        End If
        If (Val(txtNMudas.Text) Mod 128) = 0 Then
            rd128.Checked = True
        End If
        If (Val(txtNMudas.Text) Mod 255) = 0 Then
            rd255.Checked = True
        End If
        If (Val(txtNMudas.Text) Mod 450) = 0 Then
            rd450.Checked = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        'Se a inclus�o n�o passar nas regras de valida��o
        If Not valida_codigo() Then
            Exit Sub
        End If

        'Verifica se o campo com o c�digo do lote n�o est� vazio
        If txtCodigo.Text <> "___.___.____" Then
            SQL = "INSERT INTO sub_plantio (Lote,Origem,Origem_num) VALUES (" & varID & ",'" & txtCodigo.Text.Replace(",", ".") & "'," & txtMudas.Text & ")"
            Console.WriteLine(SQL)
            Try
                'Tenta fazer a inclus�o
                ExecutaSQL(SQL)
            Catch ex As Exception
                'Se der erro envia a mensagem
                MsgBox("Erro ao tentar incluir lote de origem." & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        Else
            'Se estiver vazio Avisa
            MsgBox("O C�digo do lote tem que ser preenchido!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Atualiza o datagrid
        Atualiza_Grid_Historico("SELECT Origem,Origem_num FROM sub_plantio WHERE lote=" & varID)
        txtCodigo.Text = String.Empty
        txtMudas.Text = 0
        txtCodigo.Focus()
    End Sub

    Private Sub Totaliza_Origem()
        Dim Total As UInteger = 0
        With dgOrigem
            For i As Integer = 0 To .RowCount - 1
                Total += .Rows(i).Cells(1).Value
            Next
        End With
        lblMudasOrigem.Text = Format(Total, "N0")
    End Sub


    Function valida_codigo() As Boolean
        If txtCodigo.Text.Length < 12 Then
            MsgBox("O tamanho do c�digo � imcompat�vel com o sistema adotado!", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End If
        If Val(txtCodigo.Text.Substring(0, 3)) <> Val(txtMercadoria.Text) Then
            MsgBox("H� uma diverg�ncia no c�digo da mercadoria informado!", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End If
        If Val(txtCodigo.Text.Substring(8, 4)) <> Val(txtClone.Text) Then
            MsgBox("H� uma diverg�ncia no clone informado!", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End If
        Dim Codigo(3) As String
        'Divide o c�digo nos 3 pedacos
        'Uso a v�rgula porque o maskeditbox troca sozinho o ponto pela v�rgula
        Codigo = txtCodigo.Text.Split(",")
        'Verifica se localiza (O lote n�o precisa estar ativo)
        'Localizar o lote - Se achar retorno o ID sen�o retorna NULL
        Dim CodLote As Object = DLookup("id", "Lotes", "(Mercadoria=" & Val(Codigo(0)).ToString & ") AND (Lote=" & Val(Codigo(1)).ToString & ") AND (Clone=" & Val(Codigo(2)).ToString & ")")

        'Se for NULL � porque n�o achou
        If CodLote Is Nothing = True Then
            MsgBox("Lote n�o Encontrado, verifique se � um lote existente ou n�o houve erro de digita��o", MsgBoxStyle.Exclamation, "Aviso")
            GoTo Falso
        End If
        'Se passar por todas estas regras � verdadeiro
        GoTo Verdadeiro

Falso:
        valida_codigo = False
        Exit Function
Verdadeiro:
        valida_codigo = True
        Exit Function

    End Function

    Private Sub Atualiza_Grid_Historico(ByVal SQL As String)
        Try
            MyCON = New MySql.Data.MySqlClient.MySqlConnection(MY_SQL_CONNECTION)
            MyADA = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL, MyCON)
            Dim dsDados As New DataSet
            MyADA.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(SQL, MyCON)
            MyADA.Fill(dsDados)
            dgOrigem.DataSource = dsDados.Tables(0)
            dgOrigem.RowHeadersWidth = 25
            dgOrigem.Columns(0).HeaderText = "Lote"
            dgOrigem.Columns(0).Width = 100
            dgOrigem.Columns(1).HeaderText = "Mudas"
            dgOrigem.Columns(1).Width = 45
            MyCON.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Erro inesperado ao abrir a base de dados !" & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro n� " & ex.Number)
            MyCON.Close()
        End Try
        'Totaliza as bandejas de origem
        Totaliza_Origem()
    End Sub

    Private Sub Atualiza_Grid_Bandejas(ByVal SQL As String)
        Try
            MyCON = New MySql.Data.MySqlClient.MySqlConnection(MY_SQL_CONNECTION)
            MyADA = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL, MyCON)
            Dim dsDados As New DataSet
            MyADA.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(SQL, MyCON)
            MyADA.Fill(dsDados)
            dgBandejas.DataSource = dsDados.Tables(0)
            dgBandejas.RowHeadersWidth = 25
            dgBandejas.Columns(0).HeaderText = "Bandeja"
            dgBandejas.Columns(0).Width = 65
            dgBandejas.Columns(1).HeaderText = "C�lulas"
            dgBandejas.Columns(1).Width = 45
            dgBandejas.Columns(2).HeaderText = "Mudas"
            dgBandejas.Columns(2).Width = 45
            MyCON.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Erro inesperado ao abrir a base de dados !" & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro n� " & ex.Number)
            MyCON.Close()
        End Try
    End Sub

    Private Sub dgBandejas_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBandejas.CellValueChanged
        'Habilita o bot�o de salvar
        btSalvar.Enabled = True
    End Sub


    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        Dim num As Integer = dgBandejas.RowCount, i As Integer, SQL As String
        'Pega o grid bandejas
        With dgBandejas
            'Tem que ser -2 porque come�a em 0 e ainda tem a linha do add New
            For i = 0 To num - 2
                'Fixa na linha em quest�o
                With .Rows(i)
                    'Se a primeira c�lula n�o for vazia
                    If .Cells(0).Value.ToString <> String.Empty Then
                        'Monta a SQL
                        SQL = "UPDATE aux_bandejas SET Tipo=" & .Cells(1).Value & ", Mudas=" & .Cells(2).Value & ", NAtual=" & .Cells(2).Value & " WHERE id=" & .Cells(0).Value
                        'Tenta salvar os dados no servidor
                        Try
                            ExecutaSQL(SQL)
                        Catch ex As Exception
                            MsgBox("Erro ao tentar salvar dados nas bandejas!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
                            Exit Sub
                        End Try
                    End If
                End With
            Next i
        End With
    End Sub

    Private Sub txtMudas_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMudas.Enter
        txtMudas.SelectAll()
    End Sub


    Private Sub btNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovo.Click
        'Se n�o passar pela checagem das quantidades n�o vai adiante
        If Not Valida_Campos() Then
            Exit Sub
        End If

        'Limpa os campos da mercadoria
        txtMercadoria.Text = String.Empty
        txtClone.Text = String.Empty
        txtData.Text = String.Empty
        rd72.Checked = True
        txtNMudas.Text = 0
        txtNBandejas.Text = 0
        cmbCliente.Text = String.Empty
        lstPlantador.ClearSelected()
        txtSubstrato.Text = String.Empty
        lblPlantio.Text = "Plantio: 00000"
        'Desabilita os grupos
        grpPlantio.Enabled = True
        grpBandejas.Enabled = False
        grpOrigem.Enabled = False
        'Limpa os grids de bandejas
        Atualiza_Grid_Historico("SELECT Origem,Origem_num FROM sub_plantio WHERE lote=0")
        Atualiza_Grid_Bandejas("SELECT id,tipo,mudas FROM aux_bandejas WHERE Plantio=0")
        'Move o foco para as mercadorias
        txtMercadoria.Focus()
    End Sub

    Function Valida_Campos() As Boolean
        Dim i As Integer, BandejasTotal As Integer, OrigemTotal As Integer
        BandejasTotal = 0
        OrigemTotal = 0
        'Soma as mudas nas bandejas
        With dgBandejas
            For i = 0 To .RowCount - 1
                BandejasTotal += Val(.Rows(i).Cells(2).Value)
            Next
        End With
        'Debug
        Console.WriteLine(Me.Name & ": Mudas em Bandejas:" & BandejasTotal)
        'Soma as mudas na or�gem
        With dgOrigem
            For i = 0 To .RowCount - 1
                OrigemTotal += Val(.Rows(i).Cells(1).Value)
            Next
        End With
        'Debug
        Console.WriteLine(Me.Name & ": Mudas de Or�gem:" & OrigemTotal)

        'Faz a valida��o do n�mero de mudas
        If BandejasTotal <> Val(txtNMudas.Text) Then
            MsgBox("O n�mero de mudas informado e o n�mero de mudas em bandejas divegem!" & vbCrLf & "Mudas totais: " & txtNMudas.Text & vbCrLf & "Mudas em bandejas: " & BandejasTotal.ToString, MsgBoxStyle.Exclamation)
            Valida_Campos = False
            Exit Function
        End If
        'Faz a valida��o do n�mero de mudas de origem
        If OrigemTotal <> Val(txtNMudas.Text) Then
            MsgBox("O n�mero de mudas informado e o n�mero de mudas de or�gem divergem!" & vbCrLf & "Mudas totais: " & txtNMudas.Text & vbCrLf & "Mudas de Or�gem: " & OrigemTotal.ToString, MsgBoxStyle.Exclamation)
            Valida_Campos = False
            Exit Function
        End If
        'Se passou por todos sem sair ent�o � verdadeiro
        Valida_Campos = True
    End Function

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        'Se passar no teste de valida��o deixa fechar
        If Valida_Campos() Then
            Me.Close()
        End If
    End Sub

    Public Sub New(Optional ByVal Ordem As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Ordem_Producao = Ordem


    End Sub

End Class