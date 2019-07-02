Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.ComponentModel


Module Constantes
    'Definição ds constantes do programa

    Public Cor_Digitada As System.Drawing.Color = Color.White
    Public Cor_Gerada As System.Drawing.Color = Color.Yellow
    Public Cor_Transmitida As System.Drawing.Color = Color.LimeGreen
    Public Cor_Danfe As System.Drawing.Color = Color.DodgerBlue
    Public Cor_Cancelada As System.Drawing.Color = Color.Crimson
    Public Cor_Inutilizada As System.Drawing.Color = Color.DarkKhaki

    Public Conectado As Boolean = True      'False = Desconectado   True = Conectado

    'Códigos dos lancamentos contábeis
    Public Const CTB_AVISTA_CAIXA_D As Integer = 259
    Public Const CTB_AVISTA_CAIXA_C As Integer = 602

    Public Const CTB_AVISTA_BANCO_D As Integer = 259
    Public Const CTB_AVISTA_BANCO_C As Integer = 33

    Public Const CTB_APRAZO_CAIXA_D As Integer = 311
    Public Const CTB_APRAZO_CAIXA_C As Integer = 602

    Public Const CTB_APRAZO_BANCO_D As Integer = 311
    Public Const CTB_APRAZO_BANCO_C As Integer = 33

    Public Const CTB_APRAZO_MES_D As Integer = 260
    Public Const CTB_APRAZO_MES_C As Integer = 311

    Public Const E_CNPJ As String = "07727715000190"
    Public Const E_RAZAO As String = "CLONA-GEN Comercio de Mudas de Plantas Ltda."
    Public Const E_IE As String = "255097050"
    Public Const E_ENDERECO As String = "Rua Ottokar Doerffel"
    Public Const E_NUM As String = "534"
    Public Const E_BAIRRO As String = "Atiradores"
    Public Const E_CIDADE As String = "Joinville"
    Public Const E_UF As String = "SC"
    Public Const E_CEP As String = "89203001"
    Public Const E_FONE As String = "04734396607"

    Public Const E_MailServer As String = "mail.clona-gen.com.br"
    Public Const E_MailUser As String = "comercial@clona-gen.com.br"
    Public Const E_MailPass As String = "16240423"
    Public Const E_MailFrom As String = "CLONA-GEN Comercial<comercial@clona-gen.com.br>"
    Public Const E_MailPort As Integer = 25
    Public Const E_EnableSsl As Boolean = False

    Public User As New Usuario

    Public MY_TIMEOUT As Integer = 20

    Public myIP As String = "10.1.1.254"

    '*
    '* CONCENTRAÇÕES PADRONIZADAS DOS HORMONIOS (mg/ml)
    '*

    Public MGL_BAP As Decimal = 1   'BAP
    Public MGL_24D As Decimal = 0.5 '2,4D
    Public MGL_KIN As Decimal = 1   'KIN
    Public MGL_AIB As Decimal = 1   'AIB
    Public MGL_ANA As Decimal = 1   'ANA
    Public MGL_AIA As Decimal = 1   'AIA
    Public MGL_ABA As Decimal = 0.5 'ABA
    Public MGL_TDZ As Decimal = 0.5 'TDZ
    Public MGL_GA3 As Decimal = 0.5 'GA3
    Public MGL_2IP As Decimal = 0.5 '2iP

End Module

Module Generico

    '**********************************************************************************
    '*  Modulo genérico que é utilizado tanto pelo ervido de de código de barras      *
    '*  quanto pela recuperação de frascos                                            *
    '**********************************************************************************

    '** São várias funções para isso e por isso estão em módulo

    Function Adiciona_Frasco(ByRef dgFrascos As DataGridView, ByRef dsFrascos As DataSet, ByRef txtCodigoBarras As TextBox, ByRef cmbMotivo As ComboBox, ByRef txtTotal As Label) As Integer
        Dim CodVidro As Object, CodLote As Object = Nothing
        Dim codMER, codLOT, codCLON, codFRA, Mudas As Integer
        Dim flagPresente As Boolean = False

        'Se não houver codigo de barras então sair
        If Len(txtCodigoBarras.Text) < 1 Then
            Exit Function
        End If

        'Resolver o problema dos números irem parar no combo de motivo
        'Se for detectados números nas primeiras posções do combo
        If Char.IsDigit(Mid(cmbMotivo.Text, 1, 3)) Then
            MsgBox("Erro de código de barras ou motivo" & vbCrLf & "Passe o último frasco novamente", MsgBoxStyle.Critical, "Erro")
            'Zera as opções novamente
            txtCodigoBarras.Text = String.Empty
            cmbMotivo.Text = "Fungo"
            txtCodigoBarras.Focus()
            'Sai da funcao sem fazer nada
            Exit Function
        End If

        'Se o tamanho do código não bater sai para não dar erro
        If Len(txtCodigoBarras.Text) < 12 Then  'Pelo menos até que as etiquetas tenham 13 digitos
            MsgBox("Código de barras incorreto!" & vbCrLf & " Verificar!", vbOKOnly + vbExclamation, "AVISO")
            GoTo Fim
            Exit Function
        End If

        'Ajusta para ler os dois padrões de código de barras
        If txtCodigoBarras.Text.Length = 14 Then '(Gambiarra)
            'Separa o lote em partes
            '0001112222333
            codMER = Val(txtCodigoBarras.Text.Substring(1, 3)).ToString
            codLOT = Val(txtCodigoBarras.Text.Substring(4, 3)).ToString
            codCLON = Val(txtCodigoBarras.Text.Substring(7, 4)).ToString
            codFRA = Val(txtCodigoBarras.Text.Substring(11, 3)).ToString
        ElseIf txtCodigoBarras.Text.Length = 13 Then '(Código Atual Mercadoria com 000)
            'Separa o lote em partes
            '0001112222333
            codMER = Val(txtCodigoBarras.Text.Substring(0, 3)).ToString
            codLOT = Val(txtCodigoBarras.Text.Substring(3, 3)).ToString
            codCLON = Val(txtCodigoBarras.Text.Substring(6, 4)).ToString
            codFRA = Val(txtCodigoBarras.Text.Substring(10, 3)).ToString
        ElseIf txtCodigoBarras.Text.Length = 12 Then '(Codigo Antigo Mercadoria com 00)
            'Separa o lote em partes
            '001112222333
            codMER = Val(txtCodigoBarras.Text.Substring(0, 2)).ToString
            codLOT = Val(txtCodigoBarras.Text.Substring(2, 3)).ToString
            codCLON = Val(txtCodigoBarras.Text.Substring(5, 4)).ToString
            codFRA = Val(txtCodigoBarras.Text.Substring(9, 3)).ToString
        End If

        'Debug
        'MsgBox("Comp" & txtCodigoBarras.Text.Length & vbCrLf & codMER & " " & codLOT & " " & codCLON & " " & codFRA)

        'Zera o código do lote 
        CodLote = Nothing

        'Localizar o lote - Se achar retorno o ID senão retorna NULL
        CodLote = DLookup("id", "Lotes", "(Mercadoria=" & codMER & ") AND (Lote=" & codLOT & ") AND (Clone=" & codCLON & ") AND (ativo=1)")

        'Se for NULL é porque não achou
        If IsNothing(CodLote) Or CodLote = String.Empty Or IsDBNull(CodLote) Then
            MsgBox("Lote não encontrado!", vbExclamation, "AVISO")
            CodLote = -1
            GoTo Fim
        End If

        'Se encontrou o lote agora procura o frasco
        'Pegar os identificadores do vidro
        'Se achar retorno o ID senão retorna NULL
        CodVidro = DLookup("id", "Aux_Frascos", "(Lote=" & CodLote & ") AND (Vidro=" & codFRA & ") AND (ISNULL(bxExclusao))")
        'Se for NULL é porque não achou
        If IsNothing(CodVidro) Or CodVidro = String.Empty Or IsDBNull(CodVidro) Then
            MsgBox("Frasco não encontrado!", vbExclamation, "AVISO")
            CodLote = -1
            GoTo Fim
        End If
        'Com o parametro especificado
        With dgFrascos
            'Procura pelo frasco existente
            For i As Integer = 0 To .RowCount - 1
                'se achar o id coincidente
                If .Rows(i).Cells(6).Value = CodVidro Then
                    MsgBox("Este frasco já está na lista!", vbExclamation, "AVISO")
                    GoTo Fim
                End If
            Next
        End With

        'Se achou o vidro agora pega o número de mudas
        Mudas = DLookup("NMudas", "Aux_Frascos", "ID=" & CodVidro)

        'Verifica se o frasco que está vindo faz parte desse lote
        'If dgFrascos.RowCount > 0 Then
        '   'Pode pegar o que está na primeira linha mesmo (Todo tem que ser iguais)
        '   If CodLote <> dgFrascos.Rows(0).Cells(7).Value Then
        '       MsgBox("O frasco que você está tentando adicionar não faz parte deste lote" & Chr(13) & Chr(13) & "Passe todos os frascos do mesmo lote" & Chr(13) & Chr(13) & "Quando terminar clique em CONFIRMAR para então passar outro lote", vbInformation, "AVISO")
        '       GoTo Fim
        '   End If
        ' End If

        'inclui a linha no DATA SET e por consequencia no datagrid
        dsFrascos.Tables(0).Rows.Add(codMER, codLOT, codCLON, codFRA, Mudas, cmbMotivo.Text.Substring(0, 1), CodVidro, CodLote)
        'Conta o número de frascos
        txtTotal.Text = dsFrascos.Tables(0).Rows.Count
Fim:
        txtCodigoBarras.Text = Nothing
        txtCodigoBarras.Focus()
        'Se não localizar ou não achar retorna Nothing
        Return CodLote

    End Function

    Function Baixa_Frascos(ByRef dgFrascos As DataGridView, ByRef dsFrascos As DataSet, ByRef txtData As MaskedTextBox, ByVal Operador As Integer) As Boolean

        'Dim SQL As String, Tabela As Variant, CodLote As Single, CodVidro As Single, Mudas As Single
        Dim Plantio As Single, Repicagem As Single, Fungo As Single, Bacteria As Single, Oxidacao As Single, Mudas As Single, Contaminacao As Single
        Dim QtF As Single, QtB As Single, QtO As Single, QtP As Single, QtR As Single
        Dim Num As Single, SQL As String, lote_atual As String = ""
        Dim Motivo As String, LoteOLD As Integer = 0
        Dim Frascos As Integer, SQLExclusao As String

        'Conta quantas entradas tem
        Num = dgFrascos.RowCount

        If Num <= 0 Then
            MsgBox("Não há elementos na lista para serem processados", vbOKCancel + vbCritical, "Erro")
            Return False
            Exit Function
        End If

        'monta o resumo
        Fungo = 0
        Bacteria = 0
        Oxidacao = 0
        Plantio = 0
        Repicagem = 0
        Contaminacao = 0
        Frascos = 0
        Mudas = 0

        LoteOLD = 0
        SQLExclusao = String.Empty

        'Organiza as entradas por código do lote
        dgFrascos.Sort(dgFrascos.Columns(7), System.ComponentModel.ListSortDirection.Ascending)

        For i As Integer = 0 To Num - 1
            'Lote anterior no primeiro caso é o primeiro lote
            If i = 0 Then
                LoteOLD = dgFrascos.Rows(i).Cells(7).Value
            End If
            With dgFrascos.Rows(i)
                'se Vai trocar o lote, antes tem que processar o lote anterior
                If .Cells(7).Value = LoteOLD Then
                    'Usa a funcao desenvolvida para fazer o resumo
                    Motivo = .Cells(5).Value.ToString
                    Soma_lotes(dgFrascos, i, Motivo, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, Contaminacao, Mudas, Frascos, QtF, QtB, QtO, QtP, QtR)
                    'Acrescenta na lista de ID a serem excluidos
                    If SQLExclusao = String.Empty Then
                        'Se for a primeira vez que passa aqui
                        SQLExclusao = dgFrascos.Rows(i).Cells(6).Value.ToString
                    Else
                        'Se for segunda já coloca a virgula
                        SQLExclusao &= "," & dgFrascos.Rows(i).Cells(6).Value.ToString
                    End If
                Else
                    'Se o lote atual for diferente do anterior
                    'Processa os frascos do lote
                    If Not Aux_Processa_Frasco(dgFrascos, LoteOLD, Contaminacao, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, Frascos, Mudas, QtP, QtR, txtData.Text) Then
                        Exit Function
                    End If
                    'Reinicia as variáveis
                    Fungo = 0
                    Bacteria = 0
                    Oxidacao = 0
                    Plantio = 0
                    Repicagem = 0
                    Contaminacao = 0
                    Frascos = 0
                    Mudas = 0
                    QtF = 0
                    QtB = 0
                    QtO = 0
                    QtP = 0
                    QtR = 0
                    'Zera a SQL de exclusão e começa com o valor da linha atual
                    SQLExclusao = dgFrascos.Rows(i).Cells(6).Value.ToString
                    'Soma o lote atual
                    Motivo = .Cells(5).Value.ToString
                    Soma_lotes(dgFrascos, i, Motivo, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, Contaminacao, Mudas, Frascos, QtF, QtB, QtO, QtP, QtR)
                    'Lote atual fica sendo o loteOLD
                    LoteOLD = .Cells(7).Value
                End If
                If i = Num - 1 Then
                    'Processa os frascos do lote
                    If Not Aux_Processa_Frasco(dgFrascos, LoteOLD, Contaminacao, Fungo, Bacteria, Oxidacao, Plantio, Repicagem, Frascos, Mudas, QtP, QtR, txtData.Text) Then
                        Exit Function
                    End If
                End If
            End With
        Next i

        'Agora por ultimo tem que apagar os frascos
        'Todo servico esta acabado

        'SQL = "DELETE FROM Aux_Frascos WHERE id IN("
        SQL = "UPDATE aux_frascos SET bxExclusao=CURRENT_TIMESTAMP, bxOperador=" & Operador & " WHERE id IN("
        For i As Integer = 0 To Num - 1
            With dgFrascos.Rows(i)
                'Se for o primeiro valor
                If i = 0 Then
                    'Monta a SQL
                    SQL = SQL & .Cells(6).Value.ToString
                Else    'Se for mais de um tem que ter a virgula
                    SQL = SQL & "," & .Cells(6).Value.ToString
                End If
            End With
        Next i
        'Finaliza a SQL
        SQL = SQL & ")"
        'Tenta excluir
        Try
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir os frascos !" & vbCrLf & ex.Message & vbCrLf & ex.ToString, vbCritical)
            Return False
            Exit Function
        End Try
        'Tudo acabado pode-se limpar o listview para a proxima etapa
        dsFrascos.Tables(0).Clear()
Fim:
        Return True
    End Function

    Private Sub Soma_lotes(ByRef dgFrascos As Object, ByVal Linha As Integer, ByVal Motivo As String, ByRef Fungo As Integer, ByRef Bacteria As Integer, ByRef Oxidacao As Integer, ByRef Plantio As Integer, ByRef Repicagem As Integer, ByRef Contaminacao As Integer, ByRef Mudas As Integer, ByRef Frascos As Integer, ByRef QtF As Integer, ByRef QtB As Integer, ByRef QtO As Integer, ByRef QtP As Integer, ByRef QtR As Integer)
        Select Case Motivo     'Motivo
            Case "F"
                Fungo = Fungo + dgFrascos.Rows(Linha).Cells(4).Value
                QtF = QtF + 1 'Vai contando quantos frascos em cada motivo
            Case "B"
                Bacteria = Bacteria + dgFrascos.Rows(Linha).Cells(4).Value
                QtB = QtB + 1
            Case "O"
                Oxidacao = Oxidacao + dgFrascos.Rows(Linha).Cells(4).Value
                QtO = QtO + 1
            Case "P"
                Plantio = Plantio + dgFrascos.Rows(Linha).Cells(4).Value
                QtP = QtP + 1
            Case "R" : Repicagem = Repicagem + dgFrascos.Rows(Linha).Cells(4).Value
                QtR = QtR + 1
        End Select
        Contaminacao = Fungo + Bacteria + Oxidacao
        Mudas = Mudas + dgFrascos.Rows(Linha).Cells(4).Value
        Frascos += 1
    End Sub

    Function Aux_Processa_Frasco(ByRef dgfrascos As Object, ByVal Lote_ID As Integer, ByRef Contaminacao As Integer, ByRef Fungo As Integer, ByRef Bacteria As Integer, ByRef Oxidacao As Integer, ByRef Plantio As Integer, ByRef Repicagem As Integer, ByRef Frascos As Integer, ByRef Mudas As Integer, ByRef QtP As Integer, ByRef QtR As Integer, ByVal Data As String) As Boolean
        Dim SQL As String, Lote_atual As String
        'Atualiza o estoque da tabela dos lotes
        'Monta a SQL
        SQL = "UPDATE Lotes SET Contaminacao=Contaminacao+" & Contaminacao & ", Fungo=Fungo+" & Fungo & ",Bacteria=Bacteria+" & Bacteria & ",Oxidacao=Oxidacao+" & Oxidacao & ",Est_Frascos=Est_Frascos-" & Frascos & ", Estoque=Estoque-" & Mudas & " WHERE Id=" & Lote_ID
        'Executa a SQL
        Try
            'Tenta executar a operação
            ExecutaSQL(SQL)
        Catch ex As Exception
            MsgBox("Erro ao atualizar o Estoque/Contaminação no banco de dados!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
            Return False
        End Try

        'Pega o código textual do lote selecionado em cmbLote
        Lote_atual = Procura_Lote(Lote_ID)

        'Registra o plantio e a repicagem no histórico
        SQL = "INSERT INTO Historico (lote,data,Descricao,retirada,frascos) VALUES "
        SQL &= "(" & Lote_ID & ","
        SQL &= "'" & Format(CDate(Data), "yyyy-MM-dd") & "',"
        'Faz uma SQL por motivo
        If Plantio > 0 Then
            Dim SQLpl As String
            SQLpl = SQL & "'Plantio do lote " & Lote_atual & "',"
            SQLpl &= Plantio & ","
            SQLpl &= QtP & ")"
            Try
                ExecutaSQL(SQLpl)
            Catch ex As Exception
                MsgBox("Erro na inclusão dos dados de plantio no histórico" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
                Return False
            End Try
        End If
        If Repicagem > 0 Then
            Dim SQLre As String
            SQLre = SQL & "'Repicagem do lote " & Lote_atual & "',"
            SQLre &= Repicagem & ","
            SQLre &= QtR & ")"
            Try
                ExecutaSQL(SQLre)
            Catch ex As Exception
                MsgBox("Erro na inclusão dos dados de repicagem no histórico" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical)
                Return False
            End Try
        End If

        'Pega o estoque atual e ve se é zero
        Dim tmpEstoque As Integer = 0

        tmpEstoque = DLookup("Estoque", "Lotes", "id=" & Lote_ID)
        'Verifica se o estoque atual é zero ou negativo
        If tmpEstoque <= 0 Then
            'Verifica se o usuário deseja que o lote seja inativado em função disso
            Dim a As Integer
            a = MsgBox("Lote atual com estoque menor ou igual a ZERO (" & tmpEstoque.ToString & ")" & Chr(13) & "Deseja desativar o lote " & Lote_atual & "?", vbYesNo + vbQuestion, "Aviso")
            'Em caso positivo cria a rotina para desativar o lote
            If a = vbYes Then
                'Monta a SQL para desativar
                SQL = "UPDATE Lotes SET Ativo=0, estoque=0 ,est_frascos=0,inativado=CURRENT_TIMESTAMP WHERE Id=" & Lote_ID
                'Executa a ação
                Try
                    ExecutaSQL(SQL)
                    'Para garantir se o lote for desativado então apagar todos os frascos daquele lote
                    'So pode aqui em baixo porque vai precisar dos frascos antes para fazer os relatorios
                    'Monta a SQL para excluir todos os frascos
                    SQL = "UPDATE Aux_Frascos SET bxExclusao=CURRENT_TIMESTAMP WHERE Lote=" & Lote_ID
                    'Executa a SQL
                    ExecutaSQL(SQL)
                Catch ex As Exception
                    MsgBox("Erro ao tentar inativar o lote ou apagar seus frascos: " & Lote_atual & vbCrLf & ex.Message & vbCrLf & ex.ToString, vbCritical)
                    Return False
                End Try
            End If
        End If
        'Zera as variáveis novamente
        Fungo = 0
        Bacteria = 0
        Oxidacao = 0
        Plantio = 0
        Repicagem = 0
        Contaminacao = 0
        Frascos = 0
        Mudas = 0
        Return True
    End Function

End Module

Module Biblioteca
    'Declara a variavel global de conexao com MySQL
    Friend IP_SQL_CONNECTION As String = "10.1.1.254"
    Friend IP_SQL_CONNECTION_WEB As String = "187.59.80.163"
    Friend MY_SQL_CONNECTION As String = Nothing
    Friend MY_SQL_CONNECTION_WEB As String = Nothing
    Friend DS_MYSQL_CONNECTION As String = Nothing

    'Declara variável Global
    Friend GENERALID As String
    'Variáveis utilizadas na impressão
    Public PTR1 As IntPtr = Nothing
    Public wFILE As System.IO.FileStream = Nothing
    Public Porta As String = "LPT1"

    'Declara as constantes que serão usadas na Função Createfile
    Const GENERIC_READ = &H80000000
    Const GENERIC_WRITE = &H40000000
    Const OPEN_EXISTING = 3
    Const FILE_SHARE_READ = &H1
    Const FILE_SHARE_WRITE = &H2
    Const FILE_ATTRIBUTE_NORMAL = &H80
    Const FILE_FLAG_NO_BUFFERING = &H20000000

    'Declara uma função da própria API do Windows para poder acessar a lpt1
    Declare Auto Function CreateFile Lib "kernel32.dll" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As IntPtr) As IntPtr

    'Troca o enter pelo tab em controles do tipo textbox
    Sub MoverFoco(ByVal formulario As Form, ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' Verifica a tecla pressionada e obtem o proximo controle ou o anterior, dependendo da tecla pressionada
        If e.KeyCode = Keys.Enter Then
            If Not formulario.GetNextControl(sender, True) Is Nothing Then formulario.GetNextControl(sender, True).Focus()
        End If
    End Sub

    Public Function NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function

    'Preenche um listbox ou um combobox com valores
    Sub Carrega_Lista(ByRef Lista As Object, ByVal Tabela As String, ByVal Dados As String, ByVal Items As String, Optional ByVal Indexado As Boolean = False, Optional ByVal Criterio As String = "", Optional ByVal WEB As Boolean = False)

        'Se não estiver conectado já sai
        If Not Conectado Then
            Exit Sub
        End If

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String
        'Define a conexao
        conn = New MySqlConnection()
        'Se não for passado ou se for false (usa Conexão local)
        If (WEB = Nothing) Or (WEB = False) Then
            'Usa a string de conexao atribuida na primeira janela
            conn.ConnectionString = MY_SQL_CONNECTION
        Else    'Senão usa conexão no servidor WEB
            conn.ConnectionString = MY_SQL_CONNECTION_WEB
        End If
        'Monta a SQL com os parametros
        SQL = "SELECT " & Dados & "," & Items & " FROM " & Tabela
        'Se houver critério informado então usa
        If Len(Criterio) Then
            SQL = SQL & " WHERE " & Criterio
        End If
        If Indexado Then
            'Organiza os dados
            SQL = SQL & " ORDER BY " & Items
        End If

        Console.WriteLine("Carrega_Lista: " & SQL)

        'Tenta conectar e ver se dá erro
        Try
            conn.Open()
            'Se abriu, Executa os comandos
            'Define quem é a conexao ativa
            myCommand.Connection = conn
            'Qual a SQL a ser usada
            myCommand.CommandText = SQL
            'Monta o data reader
            Dim dr As MySqlDataReader = myCommand.ExecuteReader
            'Define que a string vai ser o resultado
            Dim str As String = dr.ToString
            'Limpa a lista primeiro
            Lista.items.clear()
            Lista.beginupdate()
            While (dr.Read())
                'Classe criada pelo Marcorati para substituir o Item Data antigo
                'Outra coisa. é usado o número dos campos para não dar problema com o nome
                'Em caso de usar "Campo as Alexandre"
                Lista.Items.Add(New MeuItemData(dr(0), dr(1)))
            End While
            Lista.endupdate()

        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            GoTo Fim
        End Try
        'Fecha conexao
        conn.Close()

Fim:
        conn.Dispose()

    End Sub

    'Clone da função enter as tab
    Sub EnterAsTab(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
            e.Handled = True
        End If
    End Sub

    'Função que executa instruções SQL de Inclusão, Exclusão e Update (sem retorno)
    Function ExecutaSQL(ByVal SQL As String, Optional ByVal Onde As Boolean = False) As Integer

        'Se não estiver conectado já sai
        If Not Conectado Then
            Return -1
        End If

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim varRetorno As Integer

        'Valor padrão
        varRetorno = 0

        'Define a conexao
        conn = New MySqlConnection()
        'False = Local / True = Remoto
        If Onde = False Then
            'Usa a string de conexao atribuida na primeira janela
            conn.ConnectionString = MY_SQL_CONNECTION
        Else
            'Usa string de conexao remota
            conn.ConnectionString = MY_SQL_CONNECTION_WEB
        End If

        'Tenta abrir a conexao
        Try
            conn.Open()
        Catch myerror As MySqlException
            MsgBox("Erro ao connectar: " & vbCrLf & myerror.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            GoTo FIM
        End Try
        'Se conseguiu abrir a conexao então executa o resto

        'Define quem é a conexao ativa
        myCommand.Connection = conn
        'Qual a SQL a ser usada
        myCommand.CommandText = SQL
        'Para desenvolvimento
        Console.WriteLine("ExecutaSQL: " & SQL)
        Try
            'Retorna o valor que deu ao executar a query
            varRetorno = myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao executar o comando SQL" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            varRetorno = -1
        End Try

FIM:
        'Libera a variável e o servidor
        conn.Close()
        conn.Dispose()
        conn = Nothing
        'Retorna o valor da função 
        Return varRetorno

    End Function

    'Limpa todos os campos de um formulário
    Public Sub Limpa_Campos(ByRef formulario As Form)
        Dim c As Control
        'Varre todos os controles do formulario
        For Each c In formulario.Controls
            'Se for textbox, combobox, ou maskeditbox então limpa o texto
            If TypeOf c Is MaskedTextBox Or TypeOf c Is TextBox Or TypeOf c Is ComboBox Then
                'Limpa o texto
                c.Text = String.Empty
            End If
            'Se for um groupBox limpa tudo o que tiver dentro
            If TypeOf c Is GroupBox Then
                For i As Integer = 0 To c.Controls.Count - 1
                    If TypeOf c Is MaskedTextBox Or TypeOf c Is TextBox Or TypeOf c Is ComboBox Then
                        c.Text = String.Empty
                    End If
                Next
            End If
            If TypeOf c Is TabControl Then
                'para cada tabpage neste tabControl
                'Dim col As TabControl = c
                'Para cada tabpage no tabcontrol
                For Each t As TabPage In c.Controls
                    'Para cada controle nessa tabpage
                    For Each ct As Control In t.Controls
                        'Verifica se é um destes tipos e apaga
                        If TypeOf ct Is MaskedTextBox Or TypeOf ct Is TextBox Or TypeOf ct Is ComboBox Then
                            ct.Text = String.Empty
                        End If
                    Next
                Next
            End If
        Next
    End Sub

    'Autocompletar para comboboxes
    Public Sub AutoCompleteCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Allow select keys without Autocompleting
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        'Get the Typed Text and Find it in the list
        sTypedText = cbo.Text
        iFoundIndex = cbo.FindString(sTypedText)

        'If we found the Typed Text in the list then Autocomplete
        If iFoundIndex >= 0 Then

            'Get the Item from the list (Return Type depends if Datasource was bound 
            ' or List Created)
            oFoundItem = cbo.Items(iFoundIndex)

            'Use the ListControl.GetItemText to resolve the Name in case the Combo 
            ' was Data bound
            sFoundText = cbo.GetItemText(oFoundItem)

            'Append then found text to the typed text to preserve case
            sAppendText = sFoundText.Substring(sTypedText.Length)
            cbo.Text = sTypedText & sAppendText

            'Select the Appended Text
            cbo.SelectionStart = sTypedText.Length
            cbo.SelectionLength = sAppendText.Length

        End If

    End Sub

    Public Sub AutoCompleteCombo_Leave(ByVal cbo As ComboBox)
        Dim iFoundIndex As Integer
        iFoundIndex = cbo.FindStringExact(cbo.Text)
        cbo.SelectedIndex = iFoundIndex
    End Sub

    Public Function DLookupBLOB(ByVal FieldName As String, ByVal RecSource As String, ByVal Criteria As String) As Object
        'Se não estiver conectado pelo IP já 
        If Not Conectado Then
            Return String.Empty
        End If

        'Define a variavel que contera a sql
        Dim SQL As String, varRetorno As Object

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand

        'Monta a SQL baseado nos dados passados
        SQL = "SELECT " & FieldName & " FROM " & RecSource & " WHERE " & Criteria

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return Nothing
            Exit Function
        End Try
        'Se conseguiu abrir a conexao então executa o resto

        'Define quem é a conexao ativa
        myCommand.Connection = conn
        'Qual a SQL a ser usada
        myCommand.CommandText = SQL
        myCommand.CommandTimeout = MY_TIMEOUT

        Console.WriteLine("DLookup: " & SQL)
        'Armazena a variável antes de fechar a conexão
        varRetorno = myCommand.ExecuteScalar

        'Fecha e libera
        'Libera a variável e o servidor
        conn.Close()
        conn.Dispose()
        conn = Nothing

        'Retorna o valor que deu ao executar a query
        If IsDBNull(varRetorno) Or IsNothing(varRetorno) Then
            varRetorno = Nothing
        End If
        Return varRetorno

    End Function

    Public Function DLookup(ByVal FieldName As String, ByVal RecSource As String, ByVal Criteria As String) As String

        'Se não estiver conectado pelo IP já 
        If Not Conectado Then
            Return String.Empty
        End If

        'Define a variavel que contera a sql
        Dim SQL As String, varRetorno As Object

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        'Dim myAdapter As New MySqlDataAdapter
        'Dim myData As New DataTable

        'Monta a SQL baseado nos dados passados
        SQL = "SELECT " & FieldName & " FROM " & RecSource & " WHERE " & Criteria

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return String.Empty
            Exit Function
        End Try
        'Se conseguiu abrir a conexao então executa o resto

        'Define quem é a conexao ativa
        myCommand.Connection = conn
        'Qual a SQL a ser usada
        myCommand.CommandText = SQL
        myCommand.CommandTimeout = MY_TIMEOUT

        Console.WriteLine("DLookup: " & SQL)
        'Armazena a variável antes de fechar a conexão
        varRetorno = myCommand.ExecuteScalar

        'Fecha e libera
        'Libera a variável e o servidor
        conn.Close()
        conn.Dispose()
        conn = Nothing

        'Retorna o valor que deu ao executar a query
        If IsDBNull(varRetorno) Or IsNothing(varRetorno) Then
            varRetorno = String.Empty
        End If
        Return varRetorno
    End Function

    Public Function DLookupRow(ByVal Tabela As String, ByVal Criterio As String, Optional ByVal Remoto As Boolean = False) As DataRow
        Dim DR As DataRow

        'Se não estiver conectado pelo IP já 
        If Not Conectado Then
            Return Nothing
        End If

        'Define a variavel que contera a sql
        Dim SQL As String

        'Define as variaveis da biblioteca MySQL
        Dim myConn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myRead As MySqlDataReader
        Dim myData As New DataTable

        'Monta a SQL baseado nos dados passados
        SQL = "SELECT * FROM " & Tabela & " WHERE " & Criterio
        Console.WriteLine(SQL)

        'Usa a string de conexao atribuida na primeira janela
        'Se for para acesso remoto usa a string WEB se for para acesso local usa a Local
        If Remoto Then
            myConn.ConnectionString = MY_SQL_CONNECTION_WEB
        Else
            myConn.ConnectionString = MY_SQL_CONNECTION
        End If

        'Tenta abrir a conexao
        Try
            myConn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & vbCrLf & myerror.Message)
            myConn.Close()
            myConn.Dispose()
            Return Nothing
            Exit Function
        End Try
        'Se conseguiu abrir a conexao então executa o resto

        Try
            'Define o tipo de comando - TEXT = SQL
            myCommand.Connection = myConn
            'Define o tipo do comando
            myCommand.CommandType = CommandType.Text
            myCommand.CommandTimeout = MY_TIMEOUT
            'Define a SQL em si
            myCommand.CommandText = SQL
            'Executa o DataReader
            myRead = myCommand.ExecuteReader()
            'Carrega a(s) linha(s) no DataTable

            If Not myRead.HasRows Then
                MsgBox("Não foram encontradas linhas que satisfaçam a condição.")
            End If

            myData.Load(myRead)

            'Libera a Memoria
            myCommand.Dispose()
            myConn.Close()
            myConn.Dispose()

            'Retorna a linha desejada
            DR = myData.Rows(0)
            'Se não for em branco
            If Not IsNothing(DR) Then
                Return DR
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Erro ao abrir a conexão: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            'Libera a memoria
            myCommand.Dispose()
            myConn.Close()
            myConn.Dispose()
            Return Nothing
        End Try
    End Function

    Function Last_ID() As Integer

        If Not Conectado Then
            Return -1
        End If

        'Sintaxe var=Last_ID()
        'Define a variavel que contera a sql
        Dim SQL As String

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable, Retorno As Integer

        SQL = "SELECT LAST_INSERT_ID() AS Ultimo"

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
            'Se conseguiu abrir a conexao então executa o resto
            'Define quem é a conexao ativa
            myCommand.Connection = conn
            'Qual a SQL a ser usada
            myCommand.CommandText = SQL
            'Retorna o valor que deu ao executar a query
            'Libera a variável e o servidor
            Retorno = myCommand.ExecuteScalar

        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return -1
            Exit Function
        End Try

        'Fecha e libera
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return Retorno
    End Function

    Function DCount(ByVal Campo As String, ByVal Tabela As String, Optional ByVal Criterio As String = "") As Integer
        'Se não estiver conectado
        If Not Conectado Then
            Return 0
        End If

        'Sintaxe DMax("Vidro", "Aux_frascos", "Lote=" & LoteID)
        'Define a variavel que contera a sql
        Dim SQL As String, Resposta As Object

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable, Retorno As Integer = -1

        'Monta a SQL baseado nos dados passados
        If Not Criterio = "" Then
            'Com critério
            SQL = "SELECT COUNT(" & Campo & ") as Conta FROM " & Tabela & " WHERE " & Criterio
        Else
            'Sem critério definido
            SQL = "SELECT COUNT(" & Campo & ") as Conta FROM " & Tabela
        End If

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
            'Se conseguiu abrir a conexao então executa o resto
            'Define quem é a conexao ativa
            myCommand.Connection = conn
            'Qual a SQL a ser usada
            myCommand.CommandText = SQL
            'Retorna o valor que deu ao executar a query
            'Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar
            If Not IsDBNull(Resposta) Then
                Return Val(Resposta)
            Else
                Return 0
            End If
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return -1
            Exit Function
        End Try

        'Fecha e libera
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return Retorno
    End Function

    Public Function DNextID(ByVal Tabela As String) As Integer
        'Se não estiver conectado
        If Not Conectado Then
            Return 0
        End If

        'Define a variavel que conterá a sql
        Dim SQL As String, Resposta As Object

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable, Retorno As Integer = -1

        'Monta a SQL que pega o próximo ID da tabela informada
        SQL = "SELECT `AUTO_INCREMENT` FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'controle' AND TABLE_NAME = '" & Tabela & "'"

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
            'Se conseguiu abrir a conexao então executa o resto
            'Define quem é a conexao ativa
            myCommand.Connection = conn
            'Qual a SQL a ser usada
            myCommand.CommandText = SQL
            'Retorna o valor que deu ao executar a query
            'Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar
            If Not IsDBNull(Resposta) Then
                Return Val(Resposta)
            Else
                Return -1
            End If
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return -1
            Exit Function
        End Try

        'Fecha e libera
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return Retorno
    End Function


    Public Function DMax(ByVal Campo As String, ByVal Tabela As String, Optional ByVal Criterio As String = "") As Integer
        'Se não estiver conectado
        If Not Conectado Then
            Return 0
        End If

        'Sintaxe DMax("Vidro", "Aux_frascos", "Lote=" & LoteID)
        'Define a variavel que contera a sql
        Dim SQL As String, Resposta As Object

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable, Retorno As Integer = -1

        'Monta a SQL baseado nos dados passados
        If Not Criterio = "" Then
            'Com critério
            SQL = "SELECT MAX(" & Campo & ") as Maximo FROM " & Tabela & " WHERE " & Criterio
        Else
            'Sem critério definido
            SQL = "SELECT MAX(" & Campo & ") as Maximo FROM " & Tabela
        End If

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
            'Se conseguiu abrir a conexao então executa o resto
            'Define quem é a conexao ativa
            myCommand.Connection = conn
            'Qual a SQL a ser usada
            myCommand.CommandText = SQL
            'Retorna o valor que deu ao executar a query
            'Libera a variável e o servidor
            Resposta = myCommand.ExecuteScalar
            If Not IsDBNull(Resposta) Then
                Return Int(Resposta)
            Else
                Return 0
            End If
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            Return -1
            Exit Function
        End Try

        'Fecha e libera
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return Retorno
    End Function
    Public Sub Localiza_Item(ByRef Lista As Object, ByVal Valor As String)
        '*
        '* Localiza e seleciona um item em um ComboBox ou ListBox baseado em um Index
        '*

        Dim aIndex As Integer
        'Usando o objeto lista
        With Lista
            'Para cada item da lista
            For aIndex = 0 To .Items.Count - 1
                'Verifica se a propriedade de valor é igual ao Valor fornecido
                Try
                    If CType(.items(aIndex), MeuItemData).Valor = Valor Then
                        'Se for seleciona o item
                        .SelectedIndex = aIndex
                        .Text = .SelectedItem.ToString
                        Exit For
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Next
            'Se não encontrar nenhum então não seleciona nada
            If aIndex >= .Items.Count Then .SelectedIndex = -1
        End With
    End Sub

    'retorna o Value Item de uma lista qualquer
    Function cmbVal(ByRef Lista As Object) As Object
        Dim num As Integer, Ret As Object
        With Lista
            num = .SelectedIndex
            If num = -1 Then
                Return -1
                Exit Function
            End If
            Try
                Ret = CType(.Items(.SelectedIndex), MeuItemData).Valor
                Return Ret
            Catch ex As InvalidCastException
                MsgBox("Não há valor numérico associado à caixa de combinação!" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Return -1
            End Try
        End With
    End Function
    'Preenche uma sequencia com determinado número de zeros
    Function StrZero(ByVal nNumero As Object, ByVal nCasas As Integer) As String
        Dim Retorno As String
        Retorno = Right("000000000000" + LTrim(nNumero), nCasas)
        Return Retorno
    End Function

    'Retorna o código de um lote baseado em seu código
    Function Procura_Lote(ByVal IdLote As Integer) As String
        Dim Retorno As String
        'Define a variavel que contera a sql
        Dim SQL As String

        'Define as variaveis da biblioteca MySQL
        Dim conn As New MySqlConnection
        Dim myCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim myData As New DataTable
        Dim dr As MySqlDataReader

        'Monta a SQL baseado nos dados passados
        SQL = "SELECT id,Mercadoria,Lote,Clone FROM Lotes WHERE id=" & IdLote.ToString

        'Define a conexao
        conn = New MySqlConnection()
        'Usa a string de conexao atribuida na primeira janela
        conn.ConnectionString = MY_SQL_CONNECTION

        'Tenta abrir a conexao
        Try
            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Erro ao connectar: " & myerror.Message)
            conn.Close()
            conn.Dispose()
            conn = Nothing
            Return ""
            Exit Function
        End Try
        'Se conseguiu abrir a conexao então executa o resto

        'Define quem é a conexao ativa
        myCommand.Connection = conn
        'Qual a SQL a ser usada
        myCommand.CommandText = SQL
        'Retorna o valor que deu ao executar a query
        dr = myCommand.ExecuteReader()
        Retorno = ""
        If dr.Read() Then
            Retorno = Format(dr.GetInt16("Mercadoria"), "000") & "." & Format(dr.GetInt16("Lote"), "000") & "." & Format(dr.GetInt16("Clone"), "0000")
        Else
            Retorno = String.Empty
        End If
        conn.Close()
        'Libera a variável e o servidor
        conn.Dispose()
        conn = Nothing
        Return Retorno
    End Function

    Public Sub UpLoadArquivo(ByVal FTP As String, ByVal Arquivo As String, ByVal ftpUser As String, ByVal ftpPass As String)

        'FTP = "ftp://ftp.provedor.com/pasta/arquivo.gif"
        'Arquivo = "d:\Meus documentos\arquivo.gif"
        'ftpUser = "Usuário do FTP"
        'ftpPass = "Senha do FTP"

        'Dimensiona as variáveis
        Dim target As Uri = New Uri(FTP)
        Dim fileName As String = Arquivo

        Dim request As FtpWebRequest = CType(FtpWebRequest.Create(target), FtpWebRequest)
        'Faz o acesso ao ftp
        request.Method = WebRequestMethods.Ftp.UploadFile
        'Modo binario
        request.UseBinary = True
        'Dimensiona as variáveis de acesso ao arquivo local
        Dim FS As New FileStream(Arquivo, FileMode.Open)
        Dim br As BinaryReader = New BinaryReader(FS)
        Dim buffer() As Byte = br.ReadBytes(CInt(FS.Length))
        br.Close()
        FS.Close()
        request.ContentLength = buffer.Length
        request.Credentials = New NetworkCredential(ftpUser, ftpPass)

        Dim requestStream As Stream = request.GetRequestStream
        requestStream.Write(buffer, 0, buffer.Length)
        requestStream.Close()

        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        If response.ToString = "System.Net.FtpWebResponse" Then
            'Se a sresposta do servidor foi OK então!
            MsgBox("Arquivo enviado com sucesso!", vbOKOnly, "Sucesso")
        Else
            MsgBox("Erro ao enviar o arquivo! Tente novamente!", vbOKOnly, "Erro")
        End If
        response.Close()

    End Sub
    Public Function SQLTransacao(ByVal SQLs() As String, Optional ByVal Local As Boolean = False) As Boolean

        'Usa a técnica de transação, ou TUDO dá certo ou não inclui nada para que não haja erro
        Dim myConnection As New MySqlConnection
        'Define a Connection String
        If Local = False Then
            'FALSE = Conexão Local
            myConnection.ConnectionString = MY_SQL_CONNECTION
        Else
            'TRUE = Conexão Remota com o Site
            myConnection.ConnectionString = MY_SQL_CONNECTION_WEB
        End If

        'Abre a conexão
        myConnection.Open()

        'Cria uma nova transação
        Dim myTrans As MySqlTransaction
        ' Inicia a transação localmente
        myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted)

        'Cria um novo comando
        Dim myCommand As New MySqlCommand()
        myCommand.Connection = myConnection
        ' Adiciona o objeto transação como pendente
        myCommand.Transaction = myTrans

        Try
            'Para cada SQL do conjunto monta a transação
            For i As Integer = 0 To SQLs.GetUpperBound(0)   'Upper Bound da dimensão 0
                'Executa cada tarefa da transação
                'Auxiliar para Debug
                Console.WriteLine("Array SQL Transação (" & i & "): " & SQLs(i))
                myCommand.CommandText = SQLs(i)
                myCommand.ExecuteNonQuery()
            Next
            'Tenta verificar se deu certo (ou seja se todas foram executadas sem nenhum erro)
            myTrans.Commit()
            'Finaliza a conexão e fecha a transação.
            myConnection.Close()
            'Se deu tudo certo
            Return True
        Catch ex As Exception
            'Desfaz a transação inteira e nada acontece.
            myTrans.Rollback()
            MsgBox("Erro na transação SQL:" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            'Finaliza a conexão e fecha a transação.
            myConnection.Close()
            Return False
        End Try
    End Function


    Public Function SQLQuery(ByVal SQL As String, Optional ByVal Local As Boolean = False) As DataTable

        'Verifica se está conectado ao BD
        If Not Conectado Then
            Return Nothing
        End If
        'Verifica se o parametro passado é válido
        If SQL = String.Empty Or IsDBNull(SQL) Then
            Return Nothing
        End If

        Dim myComm As New MySqlCommand
        Dim myConn As New MySqlConnection
        Dim myAda As New MySqlDataAdapter
        Dim myDS As New DataSet
        Dim myTab As New DataTable

        'Verifica se é qualquer otra query que não seja selecao
        If SQL.Substring(0, 6) <> "SELECT" Then
            MsgBox("Esta função executa apenas SQL's que retornem dados", vbCritical, "Erro")
            myConn.Close()
            myConn.Dispose()
            Return Nothing
            Exit Function
        End If

        'Verifica se a base de dados é local ou remota
        If Local = False Then 'Usar banco de dados local
            myConn.ConnectionString = MY_SQL_CONNECTION
        Else    'Usar banco de dados remoto
            myConn.ConnectionString = MY_SQL_CONNECTION_WEB
        End If
        'tenta abrir a conexao
        Try
            myConn.Open()
            'Define o tipo de comando - TEXT = SQL
            myComm.Connection = myConn
            'Define o tipo do comando
            myComm.CommandType = CommandType.Text
            'Define a SQL em si
            myComm.CommandText = SQL
            'define o adaptador
            myAda.SelectCommand = myComm
            'Preenche o dataset
            myAda.Fill(myTab)
            'Retorna a tabela desejada
            myComm.Dispose()
            myConn.Close()
            myConn.Dispose()
        Catch ex As Exception
            MsgBox("Erro ao abrir a conexão: " & ex.Message, MsgBoxStyle.Critical, "Erro")
            myComm.Dispose()
            myConn.Close()
            myConn.Dispose()
        End Try
        Return myTab
    End Function

    'Public Sub Imprime_Etiqueta(ByVal Cod_Esq As String, ByVal Des_Esq As String, ByVal Dat_Esq As String, ByVal Cod_Dir As String, ByVal Des_Dir As String, ByVal Dat_Dir As String)
    'A variável Porta é Global e é usada para a definição da porta de Impressão
    'Cria um arquivo virtual usando a API do windows
    'Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    'Dim handle As SafeFileHandle
    'Dim S1 As String
    'Tenta imprimir as etiquetas
    '    Try
    'tenta criar o arquivos
    'Dim wFile As System.IO.FileStream
    'Dim byteData() As Byte, impTemp As Integer = 10
    '
    'Abre o arquivo LPT1
    '        wFile = New FileStream(ptr, FileAccess.Write)

    'Prepara a etiqueta
    '        S1 = Chr(2) & "c0000" & Chr(13)        ' Midia não continua
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "O0220" & Chr(13)        ' Posicao inicial da impressora
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "KW0335" & Chr(13)       '
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "KI7" & Chr(1) & Chr(13) '1 - Termal Transfer 0- Direct Transfer
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "V0" & Chr(13)           '
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "L" & Chr(13)            'Manda padrão da etiqueta
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '       wFile.Write(byteData, 0, byteData.Length)
    '       S1 = "H" & Trim(impTemp) & Chr(13)      'Temperatura de 10 a 20
    '       byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "PC" & Chr(13)                    'Velocidade de Impressão A/B/C/D/E
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '       S1 = "A2" & Chr(13)                     '
    '       byteData = Encoding.ASCII.GetBytes(S1)
    '       wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "D11" & Chr(13)                    ' Tamanho do pixel
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '
    'Etiqueta 01
    '            S1 = "191100200260018" & "Lote:" & Chr(13)       'Label do lote
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '         S1 = "1D3101500520017" & Cod_Esq & Chr(13)       'Codigo de Barras do Lote
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '       wFile.Write(byteData, 0, byteData.Length)
    '      S1 = "191100200030017" & "Data:" & Chr(13)       'Label Data
    '     byteData = Encoding.ASCII.GetBytes(S1)
    '    wFile.Write(byteData, 0, byteData.Length)
    '   S1 = "191100300260049" & Des_Esq & Chr(13)       'Descricao do lote
    '  byteData = Encoding.ASCII.GetBytes(S1)
    ' wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "191100200030048" & Dat_Esq & Chr(13)       'Data em si
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '
    'Etiqueta 02
    '           S1 = "191100200260181" & "Lote:" & Chr(13)       'Label do lote
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '           wFile.Write(byteData, 0, byteData.Length)
    '           S1 = "1D3101500520180" & Cod_Dir & Chr(13)       'Codigo de Barras do Lote
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '           wFile.Write(byteData, 0, byteData.Length)
    '           S1 = "191100200030180" & "Data:" & Chr(13)       'Label Data
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '          S1 = "191100300260212" & Des_Dir & Chr(13)       'Descricao do lote
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '          S1 = "191100200030211" & Dat_Dir & Chr(13)       'Data em si
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '
    '   'Comandos de finalização
    ''           S1 = "^02" & Chr(13)
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '           wFile.Write(byteData, 0, byteData.Length)
    '           S1 = "Q0001" & Chr(13)                           ' Contador de cópia
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '          S1 = "E" & Chr(13)                               ' Fim do servico
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '         wFile.Write(byteData, 0, byteData.Length)
    '    'Fecha o arquivo
    '            wFile.Close()
    '
    '        Catch ex As IOException
    '   'se houver uma excessão mosta a mensagem
    '           MsgBox(ex.Message & vbCrLf & ex.ToString)
    '       End Try
    '   End Sub
    '
    'Public Sub Volta_Etiqueta_Serial(ByRef Porta As SerialPort)
    'Envia o comando para dar um backfeed
    '       Porta.WriteLine(Chr(2) & "f320")
    '  End Sub

    '    Public Sub Volta_Etiqueta()
    'Le as definicoes do arquivo INI
    'A variável Porta é Global e é usada para a definição da porta de Impressão
    'Cria um arquivo virtual usando a API do windows
    'Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    'Dim S1 As String
    'Tenta imprimir as etiquetas
    '    Try
    'tenta criar o arquivos
    'Dim wFile As System.IO.FileStream
    'Dim byteData() As Byte, impTemp As Integer = 10

    'Abre o arquivo LPT1
    '        wFile = New FileStream(ptr, FileAccess.Write)

    'Prepara a etiqueta
    '            S1 = Chr(2) & "f320" & Chr(13)          ' Back Feed de 1 polegada antes da impressão
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '           wFile.Write(byteData, 0, byteData.Length)
    'Fecha o arquivos
    '           wFile.Close()
    '       Catch ex As Exception
    'Mostra a mensagem
    '           MsgBox(ex.Message & vbCrLf & ex.ToString)
    '       End Try
    '   End Sub

    'Sub Imprime_Etiqueta_Orquidea(ByVal E_varCodBar As String, ByVal E_varDataH As String, ByVal E_varDataLote As String, ByVal E_varEspecie As String, ByVal E_varDataC As String, ByVal E_varDataS As String, ByVal E_varDesc As String, ByVal E_varDataR As String, ByVal E_varFrasco As String, ByVal E_varNMudas As String, ByVal D_varCodBar As String, ByVal D_varDataH As String, ByVal D_varDataLote As String, ByVal D_varEspecie As String, ByVal D_varDataC As String, ByVal D_varDataS As String, ByVal D_varDesc As String, ByVal D_varDataR As String, ByVal D_varFrasco As String, ByVal D_varNmudas As String)
    ' 'Cria um arquivo virtual usando a API do windows
    ' 'A variável Porta é Global e é usada para a definição da porta de Impressão
    ' Dim ptr As IntPtr = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    ' 'Dim handle As SafeFileHandle
    ' Dim S1 As String
    ' 'Tenta imprimir as etiquetas
    '     Try
    ' 'tenta criar o arquivos
    ' Dim wFile As System.IO.FileStream
    '  'Dim byteData() As Byte, impTemp As Integer = 10
    '
    '    'Abre o arquivo LPT1
    '            wFile = New FileStream(ptr, FileAccess.Write)
    '
    'Prepara a etiqueta
    '        S1 = Chr(2) & "c0000" & Chr(13)        ' Midia não continua
    '       byteData = Encoding.ASCII.GetBytes(S1)
    ''       wFile.Write(byteData, 0, byteData.Length)
    '       S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    '      byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "O0220" & Chr(13)        ' Posicao inicial da impressora
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '         S1 = Chr(2) & "KW0335" & Chr(13)       '
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "KI7" & Chr(1) & Chr(13) '1 - Termal Transfer 0- Direct Transfer
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "V0" & Chr(13)           '
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = Chr(2) & "L" & Chr(13)            'Manda padrão da etiqueta
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "H" & Trim(impTemp) & Chr(13)      'Temperatura de 10 a 20
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "PC" & Chr(13)                    'Velocidade de Impressão A/B/C/D/E
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '       S1 = "A2" & Chr(13)                     '
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '       wFile.Write(byteData, 0, byteData.Length)
    '       S1 = "D11" & Chr(13)                    ' Tamanho do pixel
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '
    '    '*
    '    '* ETIQUETA 01 (DIREITA)
    '    '*
    '
    'Cabecalho do lote
    '           S1 = "191100200730016Lote:" & Chr(13)
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    'Codigo de barras ou ID da semeadura
    '           S1 = "1D3101500590112" & E_varCodBar & Chr(13)
    '           byteData = Encoding.ASCII.GetBytes(S1)
    '           wFile.Write(byteData, 0, byteData.Length)
    '   'Cabecalho Colheita (Harvest)
    '          S1 = "191100100160017C:" & Chr(13)
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '  'Data da Colheita
    '          S1 = "191100100160027" & E_varDataH & Chr(13)
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '  'Data que indica o lote
    '          S1 = "191100200730043" & E_varDataLote & Chr(13)
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '          wFile.Write(byteData, 0, byteData.Length)
    '  'Nome da Especie
    '          S1 = "191100100380016" & E_varEspecie & Chr(13)
    '          byteData = Encoding.ASCII.GetBytes(S1)
    '         wFile.Write(byteData, 0, byteData.Length)
    ' 'Data do cruzamento
    '         S1 = "191100100160087" & E_varDataC & Chr(13)
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '         wFile.Write(byteData, 0, byteData.Length)
    ' 'Cabecalho cruzamento
    '         S1 = "191100100160077P:" & Chr(13)
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '         wFile.Write(byteData, 0, byteData.Length)
    'Data da semeadura
    '         S1 = "191100100040027" & E_varDataS & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'cabecalho da Semeadura
    '        S1 = "191100100040017S:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    ''        wFile.Write(byteData, 0, byteData.Length)
    'Descricao
    '        S1 = "191100100270016" & E_varDesc & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Cabecalho repicagem
    '        S1 = "191100100040077R:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    ''Data da Repicagem
    '        S1 = "191100100040087" & E_varDataR & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    ''Cabecalho Frasco
    '        S1 = "191100200580016Frasco:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    ''Número do frasco
    '        S1 = "191100200580056" & E_varFrasco & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Verifica se tem mudas
    '        If E_varNMudas <> "000" Then
    'Número de mudas
    '            S1 = "191100200370113" & E_varNMudas & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    'Número de mudas
    '            S1 = "191100200370133Mds" & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    '        Else
    'Frasco de semente
    '            S1 = "191100200370113" & "Sem" & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    '        End If
    '
    '*
    '* ETIQUETA 02 (DIREITA)
    '*
    '
    'Cabecalho do lote
    '        S1 = "191100200730179Lote:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Codigo de barras ou ID da semeadura
    '        S1 = "1D3101500590282" & D_varCodBar & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Cabecalho Colheita (Harvest)
    '        S1 = "191100100160180C:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Data da Colheita
    '        S1 = "191100100160190" & D_varDataH & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Data que indica o lote
    '        S1 = "191100200730206" & D_varDataLote & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Nome da Especie
    '        S1 = "191100100380179" & D_varEspecie & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Data do cruzamento
    '        S1 = "191100100160250" & D_varDataC & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Cabecalho cruzamento
    '        S1 = "191100100160240P:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Data da semeadura
    '        S1 = "191100100040190" & D_varDataS & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'cabecalho da Semeadura
    '        S1 = "191100100040180S:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Descricao
    '        S1 = "191100100270179" & D_varDesc & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Cabecalho repicagem
    '        S1 = "191100100040240R:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Data da Repicagem
    '        S1 = "191100100040250" & D_varDataR & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Cabecalho Frasco
    '        S1 = "191100200580179Frasco:" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Número do frasco
    '        S1 = "191100200580219" & D_varFrasco & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Se for frasco com sementes não poe o numero de mudas
    '        If D_varNmudas <> "000" Then
    'Número de mudas
    '            S1 = "191100200370276" & D_varNmudas & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    'Número de mudas
    '            S1 = "191100200370296Mds" & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    '        Else
    'Número de mudas
    '            S1 = "191100200370276" & "Sem" & Chr(13)
    '            byteData = Encoding.ASCII.GetBytes(S1)
    '            wFile.Write(byteData, 0, byteData.Length)
    '        End If

    'Comandos de finalização das Etiquetas
    '        S1 = "^02" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "Q0001" & Chr(13)                           ' Contador de cópia
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    '        S1 = "E" & Chr(13)                               ' Fim do servico
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFile.Write(byteData, 0, byteData.Length)
    'Fecha o arquivo
    '       wFile.Close()
    '   Catch ex As Exception
    '       MsgBox("Erro na impressão de etiquetas de Orquídeas" & vbCrLf & ex.Message & vbCrLf & ex.ToString)
    '        Exit Sub
    '    End Try
    '
    '   End Sub

    'Public Sub Abre_Impressora()

    'Cria um arquivo virtual usando a API do windows

    '     PTR1 = CreateFile(Porta, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)
    ' Dim S1 As String, byteData() As Byte
    '     Try
    'Abre o arquivo LPT1
    '         wFILE = New FileStream(PTR1, FileAccess.Write)

    'Comandos de ROM
    'Ficam gravados mesmo depois que se desliga a impressora

    '        S1 = Chr(2) & "KI7" & Chr(1) & Chr(13)  '0- Transferencia Direta
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFILE.Write(byteData, 0, byteData.Length)

    '         S1 = Chr(2) & "KW0335" & Chr(13)       '
    '         byteData = Encoding.ASCII.GetBytes(S1)
    '         wFILE.Write(byteData, 0, byteData.Length)

    '        S1 = Chr(2) & "V0" & Chr(13)           '
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFILE.Write(byteData, 0, byteData.Length)

    '        Catch ex As IOException
    '            MsgBox("Erro ao tentar criar abertura na LPT1!" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
    '           Exit Sub
    '      End Try

    'End Sub

    'Public Sub Fecha_Impressora()
    ' 'Fecha o arquivo
    '     wFILE.Close()
    ' 'Elimina da memória os registrdores
    '     PTR1 = Nothing
    '     wFILE = Nothing
    ' End Sub

    'Public Sub Cabecalho_Etiqueta()
    'Define as variáveis
    Dim byteData() As Byte, impTemp As Integer = 10
    Dim S1 As String

    'Prepara a etiqueta com comandos Temporários

    '    S1 = Chr(2) & "c0000" & Chr(13)        ' Midia Contínua (bobina em Rolo)
    '    byteData = Encoding.ASCII.GetBytes(S1)
    '    wFILE.Write(byteData, 0, byteData.Length)
    '    S1 = Chr(2) & "f320" & Chr(13)         ' Back Feed de 1 polegada antes da impressão
    '    byteData = Encoding.ASCII.GetBytes(S1)
    '    wFILE.Write(byteData, 0, byteData.Length)
    '    S1 = Chr(2) & "KI503" & Chr(13)        ' Intervalo de etiqueta de 03 mm
    '    byteData = Encoding.ASCII.GetBytes(S1)
    '    wFILE.Write(byteData, 0, byteData.Length)
    '    S1 = Chr(2) & "O0220" & Chr(13)        ' Ajusta a posição do início (O220 - Sem margem)
    '    byteData = Encoding.ASCII.GetBytes(S1)
    '    wFILE.Write(byteData, 0, byteData.Length)
    'End Sub

    'Public Sub Finaliza_Etiqueta()
    ' 'Define as variáveis
    ' Dim byteData() As Byte, impTemp As Integer = 10
    ' Dim S1 As String
    '
    '    'Comandos de finalização
    '        S1 = "^02" & Chr(13)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFILE.Write(byteData, 0, byteData.Length)
    '        S1 = "Q0001" & Chr(13)                           ' Contador de cópia (01 cópia de cada)
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFILE.Write(byteData, 0, byteData.Length)
    '        S1 = "E" & Chr(13)                               ' Fim da formatação e Imprime
    '        byteData = Encoding.ASCII.GetBytes(S1)
    '        wFILE.Write(byteData, 0, byteData.Length)
    '   End Sub

    Public Sub Imprime_Etiqueta_Bandeja(ByVal E_CodBar As String, ByVal E_Mercad As String, ByVal E_Data As String, ByVal E_Tipo As String, ByVal D_CodBar As String, ByVal D_Mercad As String, ByVal D_Data As String, ByVal D_Tipo As String)
        'Define as variáveis 
        Dim byteData() As Byte, impTemp As Integer = 10
        Dim S1 As String
        'Tenta imprimir as etiquetas
        Try

            '*
            '* Começa o envio das configurações da etiqueta
            '* 
            S1 = Chr(2) & "L" & Chr(13)            'Manda padrão da etiqueta
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "H" & Trim(impTemp) & Chr(13)      'Temperatura de 10 a 20
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "PD" & Chr(13)                    'Velocidade de Impressão A/B/C/D (D=76,2 mm/s)
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "A2" & Chr(13)                     '
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "D11" & Chr(13)                    ' Tamanho do pixel (1x1 -> D11)
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)

            '*
            '* Etiqueta 01
            '*

            S1 = "1D4201300150018" & E_CodBar & Chr(13)             'Código Barras
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100400160085" & E_Mercad & Chr(13)             'Mercadoria
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100100030109" & E_Data & Chr(13)               'Data
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100000030021" & "Tipo:" & E_Tipo & Chr(13)      'Tipo
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)

            '*
            '* Etiqueta 02
            '*

            S1 = "1D4201300150168" & D_CodBar & Chr(13)             'Código de Barras
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100400160235" & D_Mercad & Chr(13)             'Mercadoria
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100100030259" & D_Data & Chr(13)               'Data
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)
            S1 = "191100000030171" & "Tipo:" & D_Tipo & Chr(13)      'Tipo
            byteData = Encoding.ASCII.GetBytes(S1)
            wFILE.Write(byteData, 0, byteData.Length)

        Catch ex As IOException
            'se houver uma excessão mosta a mensagem
            MsgBox(ex.Message & vbCrLf & ex.ToString)
        End Try
    End Sub


    Sub IP_Barra_Status()
        'Define todas as variáveis e os tipos
        'Todoas estas informações estão numa XML que é a configuração do projeto
        'As configurações My estão todas nesse XML
        Dim tcpClient As New TcpClient
        Dim IP As String = My.Settings.MyServer
        Dim Port As Int32 = My.Settings.MyPort
        Dim Endereco As IPAddress
        'Converte o endereço em ip válido
        Endereco = IPAddress.Parse(IP)

        'Tenta conectar
        Try
            tcpClient.Connect(IP, Port)
            frmMenu.sbpStatus.ForeColor = Color.DarkGreen
            frmMenu.sbpStatus.Text = "Status: Conectado"
            frmMenu.sbpIP.Text = "IP Servidor: " & IP
            Conectado = True
        Catch err As Exception
            frmMenu.sbpStatus.ForeColor = Color.DarkRed
            frmMenu.sbpStatus.Text = "Status: Desconectado"
            frmMenu.sbpIP.Text = "IP Servidor: " & IP
            Conectado = False
        End Try
    End Sub

    Function Troca_Ponto(ByVal num As Double) As String
        Dim Resposta As String
        'Recebe um número com vírgula e transforma ele em ponto
        Resposta = num.ToString
        'Efetua a troca com a função
        Resposta = Resposta.Replace(",", ".")
        'Retorna uma string
        Return Resposta
    End Function

    Sub Formata_Datagrid(ByRef dataGrid As Object, ByVal Cabecalhos() As String, ByVal Larguras() As Integer, Optional ByVal Visiveis() As Integer = Nothing)
        Dim Num As Integer
        'Conta o número de colunas baseado no tamanho do array
        Num = Cabecalhos.Length
        If Num <> dataGrid.columns.count Then
            Console.WriteLine("Número de parametros passados:" & Num & " | Núm Colunas no Datagrid:" & dataGrid.columns.count)
            MsgBox("Erro ao formatar o datagrid:" & vbCrLf & "O número de colunas não coincide com o informado.", MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End If
        'Formata datagrid (Num Colunas)
        For i As Integer = 0 To Num - 1
            'usa o vetor de tamanhos e textos
            With dataGrid.Columns(i)
                .Width = Larguras(i)
                .HeaderText = Cabecalhos(i)
                'se foi definido pelo usuário
                If Visiveis.Length > 0 Then
                    'Faz a conversao de tipos
                    If Visiveis(i) = 1 Then
                        .Visible = True
                    ElseIf Visiveis(i) = 0 Then
                        .Visible = False
                    End If
                End If
            End With
        Next
    End Sub
    'função para eliminar o erro de dbnull em pesquisas a banco de dados
    Function NaoNulo(ByVal Campo) As String
        If IsDBNull(Campo) Then
            Return String.Empty
        Else
            Return Campo
        End If
    End Function

    'Função que transforma o valor para poder ser gravado no banco de dados
    Function Transforma_Valor(ByVal Valor As String)

        Dim STR As String, i As Long
        STR = CStr(Valor)
        'Tira as os pontos de milhar
        STR = STR.Replace(".", "")
        'Procura a vírgula
        i = InStr(1, STR, ",")
        If i = 0 Then
            Transforma_Valor = STR
            Exit Function
        Else
            Transforma_Valor = STR.Replace(",", ".")
            Exit Function
        End If

    End Function

    Function Cor_Pedido(ByVal Status As String) As System.Drawing.Color
        Select Case Status
            Case "1"
                'Autorizado (1) - Branco
                Return Color.LightGray
            Case "2"
                'Produzindo (2) - Amarelo
                Return Color.Yellow
            Case "3"
                'Cancelado (3) - Vermelho
                Return Color.Red
            Case "4"
                'Atendido (4) - Verde
                Return Color.GreenYellow
            Case Else
                'Se não for nenhum destes acima
                Return Color.White
        End Select
    End Function

    Function BuscaCep(ByVal cep As String) As Hashtable
        Dim ds As DataSet
        Dim _resultado As String
        Dim ht As System.Collections.Hashtable = Nothing
        Try
            ds = New DataSet()
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml")
            If Not IsNothing(ds) Then
                If (ds.Tables(0).Rows.Count > 0) Then
                    _resultado = ds.Tables(0).Rows(0).Item("resultado").ToString()
                    ht = New Hashtable
                    Select Case _resultado
                        Case "1"
                            ht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            ht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            ht.Add("bairro", ds.Tables(0).Rows(0).Item("bairro").ToString().Trim())
                            ht.Add("tipologradouro", ds.Tables(0).Rows(0).Item("tipo_logradouro").ToString().Trim())
                            ht.Add("logradouro", ds.Tables(0).Rows(0).Item("logradouro").ToString().Trim())
                            ht.Add("tipo", 1)

                        Case "2"
                            ht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            ht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            ht.Add("tipo", 2)
                        Case Else
                            ht.Add("tipo", 0)
                    End Select
                End If
            End If
            Return ht
        Catch ex As Exception
            Throw New Exception("Falha ao Buscar o Cep" & vbCrLf & ex.ToString)
            Return Nothing
        End Try
    End Function

    Function Converte_Numero(ByVal Numero As String) As Double
        'Se não for informado, ou for vazio
        If Numero = String.Empty Or Numero = "" Or Numero = vbNull Then
            'Retorna zero
            Return 0
        End If
        Try
            Dim Val As Double
            Val = String_to_Numero(Numero)
            Return Val
        Catch ex As Exception
            MsgBox("Erro ao converter número na rotina Converte_Numero" & vbCrLf & ex.Message & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
            Return 0
        End Try
    End Function

    Function Texto_Vazio(ByVal Texto As String) As String
        If Texto = "" Or Texto = String.Empty Then
            Return "NULL"
        Else
            Return "'" & Texto & "'"
        End If
    End Function

    '* 
    '* Função que Gera o Codigo SQL Baseado nos campos
    '*
    Function Gera_SQL(ByVal frm As Form, ByVal Tabela As String, ByVal Tipo As String, Optional ByVal Especial As String = "", Optional ByVal id As Integer = -1) As String
        '*
        '* Especial = string contendo algum campo especial que precise de processamento foras
        '*            do convencional que não possa ser tratado pelo looping
        '*
        '* ID       = No caso de um update, o ID serve para selecionar o registro a ser alterado
        '*
        '* TAG      = O campo tag do formulário deve ser preenchido com o o tipo de dados underline
        '*            em seguida o nome do campo no bando de dados. Ex: T_NomeCli
        '*            Se o campo não precisar ser registrado, então preenche-se com 0_
        '*          

        Dim Retorno As String = String.Empty, SQL As String = String.Empty
        Dim Ctrl As Control, ct As Integer = 0

        'Monta a SQL Base
        If Tipo = "INSERT" Then
            SQL = "INSERT INTO " & Tabela & " SET "
        ElseIf Tipo = "UPDATE" Then
            SQL = "UPDATE " & Tabela & " SET "
        End If

        'Percorre todos os controles procurando a as TAGS
        For Each Ctrl In frm.Controls
            If Ctrl.GetType.ToString = "System.Windows.Forms.MaskedTextBox" Or Ctrl.GetType.ToString = "System.Windows.Forms.TextBox" Or Ctrl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                'Se o campo TAG estiver preenchido se não for computado preencher com 0_
                If Ctrl.Tag.ToString.Length > 2 Then
                    'Se a lista for maior que 1 então
                    If ct > 0 Then
                        SQL &= ","
                    End If
                    'Começa com o nome do campo (Tirando os 2 char do tipo)
                    SQL &= Ctrl.Tag.ToString.Remove(0, 2) & "="
                    'Se for do tipo texto 
                    Select Case Ctrl.Tag.ToString.Substring(0, 2)
                        Case "T_"   'Texto
                            SQL &= Texto_Vazio(Ctrl.Text)
                        Case "I_"   'Numero Inteiro
                            SQL &= Ctrl.Text
                        Case "F_"   'Numero flutuante
                            SQL &= Troca_Ponto(Converte_Numero(Ctrl.Text))
                        Case "D_"   'Data
                            SQL &= "'" & Format(CDate(Ctrl.Text), "yyyy-MM-dd")
                    End Select
                End If
                ct += 1
            End If
        Next
        'Se foi fornecido algum campo especial
        If Especial <> "" And ct > 0 Then
            SQL &= "," & Especial
        ElseIf Especial <> "" Then
            SQL &= Especial
        End If
        'Se for fornecido algum ID
        If Tipo = "UPDATE" And id <> -1 Then
            SQL &= " WHERE id=" & id
        End If
        'Maior que 8 porque é o comprimento dos comandos básicos
        If SQL.Length > 8 Then
            Return SQL
        End If
        'Se não aconteceu nada retorna string.empty
        Return String.Empty
    End Function

    Function valRepicador(ByRef Lista As Object) As String
        Dim o As Object, varRepicador As String
        Dim m As ListBox.SelectedObjectCollection = Lista.SelectedItems

        'Se não tiver nada selecionado
        If m.Count <= 0 Then
            'sai da rotina
            Return String.Empty
        End If
        'Senão processa cada item da lista
        varRepicador = ""
        For Each o In m
            'soma os numeros em varRepicador
            If varRepicador.Length > 0 Then
                varRepicador &= ";" & o.valor
            Else
                varRepicador = o.valor
            End If
        Next
        'debug
        Console.WriteLine(vbCrLf & "VarRepicador=" & varRepicador.ToString)
        'Verifica qual o retorno se deve dar
        If varRepicador.Length > 0 Then
            Return varRepicador
        Else
            Return String.Empty
        End If

    End Function

    Function String_to_Numero(Numero As String) As Double
        Dim Ret As Double
        'Converte Numero em uma string
        If String.IsNullOrEmpty(Numero) Then Return 0

        ' Converter string em número
        Try
            Ret = Double.Parse(Numero, Globalization.NumberStyles.Any)
        Catch ex As FormatException
            MsgBox("O Número não está em um formato válido!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Function
        Catch ex As Exception
            MsgBox("Não foi possível converter uma string em Número com vírgula" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Function
        End Try

        Return Ret
    End Function

    Function Numero_to_String(Numero As Double) As String
        Dim Ret As String
        Ret = Format(Numero, "N2")
        Return Ret
    End Function

    Function Numero_to_SQL(ByVal Numero As String) As String
        Dim Ret As String
        If Numero = "" Or Numero = "0,00" Or IsDBNull(Numero) Then
            Return "0"
        End If
        Ret = Numero.Replace(".", "")
        Ret = Ret.Replace(",", ".")
        Return Ret
    End Function

    Function Limpa_Formatacao(ByVal Texto As String) As String
        Dim Remover As String, i As Integer
        'Caracteres que devem ser removidos
        Remover = "()*/-+_.,\"
        For i = 1 To Len(Remover)
            Texto = Texto.Replace(Mid(Remover, i, 1), "")
        Next
        Return Texto
    End Function

    Function ValidaCPF(ByVal CPF As String) As Boolean
        Dim i, x, n1, n2 As Integer
        Dim dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                              "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
        CPF = CPF.Trim
        For i = 0 To dadosArray.Length - 1
            If CPF.Length < 11 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next

        'Verifica se tem formatação
        If CPF.IndexOf(".") > 0 Or CPF.IndexOf("-") > 0 Then
            CPF = removeFormatacao(CPF)
        End If

        'Calcula o DV Módulo 10
        For x = 0 To 1
            n1 = 0
            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0
            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next
        'Se validou retorna verdadeiro
        Return True
    End Function

    Public Function ValidaCNPJ(ByVal CNPJ As String) As Boolean

        Dim valida As Boolean
        CNPJ = CNPJ.Trim

        'Limpa a formatação
        CNPJ = Limpa_Formatacao(CNPJ)

        valida = efetivaValidacao(CNPJ)

        If valida Then
            ValidaCNPJ = True
        Else
            ValidaCNPJ = False
        End If

    End Function

    Private Function efetivaValidacao(ByVal cnpj As String) As Boolean
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim resultado1 As Integer
        Dim resultado2 As Integer
        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next
        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 +
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 +
                       Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Function FormataCpfCnpj(ByVal strCpfCnpj As String) As String

        If (strCpfCnpj.Length <= 11) Then
            Dim mtpCpf As MaskedTextProvider = New MaskedTextProvider("000\.000\.000-00")
            mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11))
            Return mtpCpf.ToString()
        Else
            Dim mtpCnpj As MaskedTextProvider = New MaskedTextProvider("00\.000\.000/0000-00")
            mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11))
            Return mtpCnpj.ToString()
        End If

    End Function

    Function ZerosEsquerda(ByVal strString As String, ByVal intTamanho As UInt16) As String
        Dim strResult As String = ""
        For intCont As UInt16 = 1 To (intTamanho - strString.Length)
            strResult += "0"
        Next
        Return strResult + strString
    End Function

    Function DiasUteis(ByVal dataINI As Date, ByVal dataFIM As Date) As Integer

        Dim dtInicio As Date
        Dim dtFinal As Date

        If dataINI > dataFIM Then
            dtInicio = dataINI
            dtFinal = dataFIM
        End If

        If Not IsDate(dtInicio) Or Not IsDate(dtFinal) Then
            Return 0
        End If

        Dim diff As Integer, i As Integer
        Dim intFimDias As Integer

        diff = DateDiff(DateInterval.Day, dtFinal, dtInicio)
        intFimDias = 0

        For i = 0 To diff Step 1
            If (Weekday(DateAdd(DateInterval.Day, i, dtInicio)) = vbSaturday) Or (Weekday(DateAdd(DateInterval.Day, i, dtInicio)) <> vbSunday) Then
                intFimDias += 1
            End If
        Next i
        Return intFimDias
    End Function

    Function Truncar(ByVal Texto, ByVal Tamanho)
        'Se for vazio ou nulo
        If Texto = String.Empty Then
            Return String.Empty
        ElseIf IsDBNull(Texto) Then
            Return String.Empty
        End If

        'Limita um texto à uma determinada quantidade de caracteres
        If (Texto.Length <= Tamanho) Then
            Return Texto
        Else
            Return String.Format("{0}...", Texto.Substring(0, Tamanho))
        End If

    End Function
    Function Nome_Repicadores(ByVal Lista As String, Optional ByVal Completo As Boolean = False) As String
        'Se for vazio
        If Lista.Length <= 0 Or IsDBNull(Lista) Then
            Return String.Empty
        End If

        Dim Retorno As String = String.Empty

        'Separa os nomes por vírgula
        Dim Rep() As String
        Rep = Lista.Split(";")

        Dim i As Integer = 1, Nam As String = String.Empty

        'Para cada Nome
        For Each Nome As String In Rep
            If Completo Then
                If i > 1 Then
                    Retorno &= "/"
                End If
                Retorno &= DLookup("Nome", "Repicador", "id=" & Nome)
            Else
                If i > 1 Then
                    Retorno &= "/"
                End If
                Nam = DLookup("Nome", "Repicador", "id=" & Nome)
                Retorno &= IIf((Nam = "") Or (IsNothing(Nam)), "", Mid(Nam, 1, InStr(Nam, " ") - 1))
            End If
            i += 1
        Next

        Return Retorno
    End Function

    Function E_Vazio_Nulo(ByVal Variavel As Object) As String

        'Verifica se é nulo
        If IsDBNull(Variavel) Then
            Return String.Empty
        ElseIf IsNothing(Variavel) Then
            Return String.Empty
        Else
            Return Variavel.ToString        'Se não cair em nenhum dos casos, retorna o proprio valor convertido em string
        End If
    End Function

    Public Sub Desabilita_Campos(ByRef Formulario As Form, ByVal Nomes() As String)
        'Primeiro varre o formulário habilitando todos
        Dim C As Control
        'Varre todos os controles do formulario
        For Each C In Formulario.Controls
            C.Enabled = True
            'Se for um GroupBox faz a recursividade
            If TypeOf C Is GroupBox Then
                For i As Integer = 0 To C.Controls.Count - 1
                    C.Controls(i).Enabled = True
                Next
            End If
        Next

        'Agora varre novamente desabilitando o que não precisa ficar aceso
        'Varre todos os controles do formulario
        For Each C In Formulario.Controls
            If Procura_Array(C.Name, Nomes) Then
                C.Enabled = False
            End If
            'Se for um GroupBox faz a recursividade
            If TypeOf C Is GroupBox Then
                For i As Integer = 0 To C.Controls.Count - 1
                    If Procura_Array(C.Controls(i).Name, Nomes) Then
                        C.Controls(i).Enabled = False
                    End If
                Next
            End If
        Next
    End Sub

    Private Function Procura_Array(ByVal Nome As String, ByRef Nomes() As String) As Boolean
        For i As Integer = 0 To Nomes.Length - 1
            If Nome = Nomes(i) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub Busca_Endereco(ByVal CEP As String, ByRef Address As EnderecoWEB)
        Try
            'Dimensiona um novo DataSet
            Dim ds As New DataSet()
            'Define o string do endereço de busca do CEP
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP)
            ds.ReadXml(xml)
            Address.Tipo_Logradouro = ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
            Address.Logradouro = ds.Tables(0).Rows(0)("logradouro").ToString()
            Address.Bairro = ds.Tables(0).Rows(0)("bairro").ToString()
            Address.Cidade = ds.Tables(0).Rows(0)("cidade").ToString()
            Address.Uf = ds.Tables(0).Rows(0)("uf").ToString()
        Catch ex As Exception
            MsgBox("Erro ao tentar localizar CEP" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
        End Try
    End Sub

    ''' <summary>
    ''' Função principal que recolhe o valor e chama as duas funções
    ''' auxiliares para a parte inteira e para a parte decimal
    ''' </summary>
    ''' <param name="number">Número a converter para extenso (Reais)</param>
    ''' 
    Public Function NumeroToExtenso(ByVal number As Decimal) As String
        Dim cent As Integer
        Try
            ' se for =0 retorna 0 reais
            If number = 0 Then
                Return "Zero Reais"
            End If
            ' Verifica a parte decimal, ou seja, os centavos
            cent = Decimal.Round((number - Int(number)) * 100, MidpointRounding.ToEven)
            ' Verifica apenas a parte inteira
            number = Int(number)
            ' Caso existam centavos
            If cent > 0 Then
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real e " + getDecimal(cent) + "centavos"
                    ' Caso o valor seja inferior a 1 Real
                ElseIf number = 0 Then
                    Return getDecimal(cent) + "centavos"
                Else
                    Return getInteger(number) + "Reais e " + getDecimal(cent) + "centavos"
                End If
            Else
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real"
                Else
                    Return getInteger(number) + "Reais"
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Função auxiliar - Parte decimal a converter
    ''' </summary>
    ''' <param name="number">Parte decimal a converter</param>
    Public Function getDecimal(ByVal number As Byte) As String
        Try
            Select Case number
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String = _
                       {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", _
                        "Sete", "Oito", "Nove", "Dez", "Onze", _
                        "Doze", "Treze", "Quatorze", "Quinze", _
                        "Dezesseis", "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String = _
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta", _
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2) + " "
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getDecimal(number Mod 10) + " "
                    End If
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Função auxiliar - Parte inteira a converter
    ''' </summary>
    ''' <param name="number">Parte inteira a converter</param>
    Public Function getInteger(ByVal number As Decimal) As String
        Try
            number = Int(number)
            Select Case number
                Case Is < 0
                    Return "-" & getInteger(-number)
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String = _
                        {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", _
                        "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", _
                        "Treze", "Quatorze", "Quinze", "Dezesseis", _
                        "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String = _
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta", _
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2)
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getInteger(number Mod 10)
                    End If
                Case 100
                    Return "Cem"
                Case 101 To 999
                    Dim strArray() As String = _
                           {"Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", _
                           "Seiscentos", "Setecentos", "Oitocentos", "Novecentos"}
                    If (number Mod 100) = 0 Then
                        Return strArray(number \ 100 - 1) + " "
                    Else
                        Return strArray(number \ 100 - 1) + " e " + getInteger(number Mod 100)
                    End If
                Case 1000 To 1999
                    Select Case (number Mod 1000)
                        Case 0
                            Return "Mil"
                        Case Is <= 100
                            Return "Mil e " + getInteger(number Mod 1000)
                        Case Else
                            Return "Mil, " + getInteger(number Mod 1000)
                    End Select
                Case 2000 To 999999
                    Select Case (number Mod 1000)
                        Case 0
                            Return getInteger(number \ 1000) & "Mil"
                        Case Is <= 100
                            Return getInteger(number \ 1000) & "Mil e " & getInteger(number Mod 1000)
                        Case Else
                            Return getInteger(number \ 1000) & "Mil, " & getInteger(number Mod 1000)
                    End Select
                Case 1000000 To 1999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return "Um Milhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhão e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhão, " & getInteger(number Mod 1000000)
                    End Select
                Case 2000000 To 999999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return getInteger(number \ 1000000) + " Milhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhões e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhões, " & getInteger(number Mod 1000000)
                    End Select
                Case 1000000000 To 1999999999
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return "Um Bilhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhão e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhão, " + getInteger(number Mod 1000000000)
                    End Select
                Case Else
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return getInteger(number \ 1000000000) + " Bilhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhões e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhões, " + getInteger(number Mod 1000000000)
                    End Select
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function HoraFormatoUTC(DataHora As DateTime) As String
        Dim UTC As String = String.Empty
        Dim fusoHorario As String = String.Empty
        'informar a data de emissão do Documento Fiscal no padrão UTC - Universal Coordinated Time
        'onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00(Manaus)
        'no horário de verão serão - 01:00, -02:00 e -03:00
        'Ex.: 2010-08-19T13:00:15-03:00.

        If DLookup("valor", "parametros", "Nome='NFeHoraVerao'") = 1 Then 'Se estiver no horário de verão
            fusoHorario = "-02:00"
        Else
            fusoHorario = "-03:00"
        End If
        'Monta a string no formato correto
        UTC = Format(DataHora, "yyy-MM-dd") & "T" & Format(DataHora, "HH:mm:ss") & fusoHorario
        'retorna
        'Debug
        Console.WriteLine("UTC: " & UTC)
        Return UTC
    End Function

    'Função que pega a stream de uma imagem e salva no Banco de dados para ser usado
    Function GetImage(ByVal URL As String) As System.Drawing.Image
        'Um objeto para mandar a requisição para o servidor
        Dim Request As System.Net.HttpWebRequest
        'Um objeto para pegar o retorno
        Dim Response As System.Net.HttpWebResponse
        Dim Retorno As System.Drawing.Image

        'Contactar o servidor para tentar pegar a imagem que precisamos
        Try
            'Criar o objeto Request com a url recebida como parâmetro
            Request = System.Net.WebRequest.Create(URL)
            'Pega o retorno do servidor e faz um cast para transformar no formato do objeto que precisamos
            Response = CType(Request.GetResponse, System.Net.WebResponse)

            If Request.HaveResponse Then 'A resposta realmente veio do servidor?
                If Response.StatusCode = System.Net.HttpStatusCode.OK Then 'Retornou código 200?
                    'Se a resposta estiver OK (código 200) então podemos carregar a imagem
                    'A Função FROMSTREAM cria uma imagem a partir da stream recebida
                    Retorno = System.Drawing.Image.FromStream(Response.GetResponseStream)
                    Return Retorno
                End If
            End If
        Catch e As System.Net.WebException
            MsgBox("Ocorreu um erro ao pegar o endereço [" & URL & "]." & vbCrLf & " O sistema retornou: " & e.Message, MsgBoxStyle.Exclamation, "Erro!")
            Exit Try
        Catch e As System.Net.ProtocolViolationException
            MsgBox("Uma violação de protocolo ocorreu [" & URL & "]." & vbCrLf & "  O sistema retornou: " & e.Message, MsgBoxStyle.Exclamation, "Erro!")
            Exit Try
        Catch e As System.Net.Sockets.SocketException
            MsgBox("Erro de soquete [" & URL & "]." & vbCrLf & "  O sistema retornou: " & e.Message, MsgBoxStyle.Exclamation, "Erro!")
            Exit Try
        Catch e As System.IO.EndOfStreamException
            MsgBox("Ocorreu um erro de IO. O sistema retornou: " & e.Message, MsgBoxStyle.Exclamation, "Erro!")
            Exit Try
        Finally
        End Try
        Return Nothing
    End Function

End Module


