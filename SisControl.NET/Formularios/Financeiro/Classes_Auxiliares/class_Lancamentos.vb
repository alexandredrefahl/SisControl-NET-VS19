
Public Class Lancamentos
    Friend cod_Reduzido As Integer
    Friend cod_Completo As String
    Friend Pessoa As String = ""
    Friend Documento As String = ""
    Friend Historico As String = ""
    Friend Pagamento As Date
    Friend valCred As Double = 0
    Friend valDeb As Double = 0
    Friend Tipo As Char
    Friend Prev As Boolean = False
    Friend Mensal As Boolean = False
    Friend Lanc_ID As Integer = 0


    Friend Function Incluir() As Boolean
        Dim SQL As String

        'SQL Base
        SQL = "INSERT INTO lancamentos SET "
        'SQL dos campos
        SQL &= Gerar_SQL()

        Try
            ExecutaSQL(SQL)
            Return True
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir o lançamento!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Return False
        End Try
    End Function

    Friend Function Alterar() As Boolean
        Dim SQL As String

        'SQL Base
        SQL = "UPDATE lancamentos SET "
        'SQL dos campos
        SQL &= Gerar_SQL()

        Try
            ExecutaSQL(SQL)
            Return True
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar o lançamento!", MsgBoxStyle.Critical, "Erro")
            Return False
        End Try
    End Function

    Friend Sub PreencheCodCompleto()
        If (cod_Reduzido <> 0) And (Not IsNothing(cod_Reduzido)) Then
            cod_Completo = DLookup("CDComp", "PlanoContas", "CDCRed=" & cod_Reduzido)
        End If
    End Sub

    Friend Function Gerar_SQL() As String
        Dim SQL As String = ""
        Dim varPessoa As String = ""
        Dim varDocumento As String = ""
        Dim varHistorico As String = ""
        Dim varLancID As String = ""

        'Corrige alguns parametros se o usuário esqueceu de colocar
        'PESSOA
        If Pessoa = "Null" Or Pessoa = "" Then
            varPessoa = "NULL"
        Else
            varPessoa = "'" & Pessoa & "'"
        End If
        'DOCUMENTO
        If Documento = "Null" Or Documento = "" Then
            varDocumento = "NULL"
        Else
            varDocumento = "'" & Documento & "'"
        End If
        'HISTORICO
        If Historico = "Null" Or Historico = "" Then
            varHistorico = "NULL"
        Else
            varHistorico = "'" & Historico & "'"
        End If
        'LANCAMENTO ID
        If Lanc_ID = 0 Then
            varLancID = "NULL"
        Else
            varLancID = Lanc_ID
        End If

        'MONTA A SQL PROPRIAMENTE DITA
        SQL &= "CDRED=" & cod_Reduzido & ","                                'CDRED
        SQL &= "CDCOMP='" & cod_Completo & "',"                             'CDCOMP
        SQL &= "Pessoa=" & varPessoa & ","                                  'Pessoa
        SQL &= "Documento=" & varDocumento & ","                            'Documento
        SQL &= "Historico=" & varHistorico & ","                            'Historico
        SQL &= "Pagamento='" & Format(Pagamento, "yyyy-MM-dd") & "',"       'Pagamento
        SQL &= "Credito=" & Numero_to_SQL(valCred) & ","                    'Credito
        SQL &= "Debito=" & Numero_to_SQL(valDeb) & ","                      'Debito
        SQL &= "Previsao=" & IIf(Prev, 1, 0) & ","                          'Previsao
        SQL &= "Mensal=" & IIf(Mensal, 1, 0) & ","                          'Mensal
        SQL &= "Tipo='" & Tipo & "',"                                       'Tipo
        SQL &= "LancamentoID=" & varLancID                                  'Lancamento_ID
        Return SQL
    End Function

End Class
