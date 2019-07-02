Imports MySql.Data.MySqlClient

Public Class frmPlanoContas

    Private Sub frmPlanoContas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Atualiza o plano de contas em forma de TRee View
        Atualiza_Tree()
    End Sub

    Sub Atualiza_Tree()
        Dim myConn As New MySqlConnection(MY_SQL_CONNECTION)
        Dim DA As New MySqlDataAdapter("SELECT * FROM PlanoContas WHERE isnull(CODSUP) ORDER By CDCOMP", myConn)
        Dim DS As New DataSet()
        DA.Fill(DS, "PlanoContas")

        Dim DR As DataRow

        'N� Raiz
        For Each DR In DS.Tables("PlanoContas").Rows
            Dim tnRaiz As TreeNode = tvContas.Nodes.Add(DR("CdComp") & " - " & DR("Descri"))
            'Aqui � chamado um m�todo que � recursivo
            'Passando o parametro dos filhos para achar os subgrupos (Netos)
            Preenche_Sub(tnRaiz, DR("CDCOMP"))
        Next
        'Fecha a conex�o e livra para n�o dar erro de Pool
        myConn.Close()
        myConn.Dispose()
    End Sub

    Sub Preenche_Sub(ByVal Node As TreeNode, ByVal Parente As String)
        Dim DT As DataTable = SQLQuery("SELECT * FROM PlanoContas WHERE CODSUP='" & Parente & "' ORDER BY CDCOMP")

        Dim DR As DataRow

        'Percorrer o TreeView localizando os filhos
        For Each DR In DT.Rows
            Dim tnFilho As TreeNode = Node.Nodes.Add(DR("CDComp") & " - " & DR("Descri"))
            'Chama o mesmo m�doto recursivamente
            Preenche_Sub(tnFilho, DR("CDCOMP"))
        Next
    End Sub
End Class