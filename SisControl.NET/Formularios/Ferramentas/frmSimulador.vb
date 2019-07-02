Imports System.Math

Public Class frmSimulador

    Private Sub rbTempo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbTempo.CheckedChanged
        'Tem que isolar algumas caixas de texto
        txtTempo.BackColor = Color.LemonChiffon
    End Sub

    Private Sub limpa_campos()
        txtInicial.Text = ""
        txtMult.Text = ""
        txtQtde.Text = ""
        txtTempo.Text = ""
        Todos_Brancos()
        'Atualiza a cor de fundo do que irá ser simulado
        If rbInicial.Checked Then
            txtInicial.BackColor = Color.LemonChiffon
        ElseIf rbQtde.Checked Then
            txtQtde.BackColor = Color.LemonChiffon
        ElseIf rbTaxa.Checked Then
            txtMult.BackColor = Color.LemonChiffon
        ElseIf rbTempo.Checked Then
            txtTempo.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub Todos_Brancos()
        txtInicial.BackColor = Color.White
        txtMult.BackColor = Color.White
        txtQtde.BackColor = Color.White
        txtTempo.BackColor = Color.White
    End Sub

    Private Sub rbQtde_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbQtde.CheckedChanged
        Todos_Brancos()
        txtQtde.BackColor = Color.LemonChiffon
    End Sub

    Private Sub rbTaxa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbTaxa.CheckedChanged
        Todos_Brancos()
        txtMult.BackColor = Color.LemonChiffon
    End Sub

    Private Sub rbInicial_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInicial.CheckedChanged
        Todos_Brancos()
        txtInicial.BackColor = Color.LemonChiffon
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        limpa_campos()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Verifica qual formula será utilizada
        Dim varInicial As Double = 0
        Dim varQtde As Double = 0
        Dim varTempo As Double = 0
        Dim varTaxa As Double = 0

        'Isolando o Número Iniciais
        If rbInicial.Checked Then
            varQtde = String_to_Numero(txtQtde.Text)
            varTaxa = String_to_Numero(txtMult.Text)
            varTempo = String_to_Numero(txtTempo.Text)
            'Calculado o número inicial isolado
            varInicial = varQtde / (varTaxa ^ varTempo)
            txtInicial.Text = varInicial.ToString("N0")
        End If

        'Isolando a Quantidade Final
        If rbQtde.Checked Then
            varTaxa = String_to_Numero(txtMult.Text)
            varTempo = String_to_Numero(txtTempo.Text)
            varInicial = String_to_Numero(txtInicial.Text)
            'Calculando com a Quantidade isolada
            varQtde = varInicial * (varTaxa ^ varTempo)
            txtQtde.Text = varQtde.ToString("N0")
        End If

        'Isolando a Taxa de Multiplicação
        If rbTaxa.Checked Then
            varQtde = String_to_Numero(txtQtde.Text)
            varTempo = String_to_Numero(txtTempo.Text)
            varInicial = String_to_Numero(txtInicial.Text)
            'Calculando com a Taxa isolada
            varTaxa = (varQtde / varInicial) ^ (1 / varTempo)
            txtMult.Text = varTaxa.ToString("N2")
        End If

        'Isolando o Tempo
        If rbTempo.Checked Then
            varQtde = String_to_Numero(txtQtde.Text)
            varInicial = String_to_Numero(txtInicial.Text)
            varTaxa = String_to_Numero(txtMult.Text)
            'Calculando com o Tempo isolado
            varTempo = (Log10(varQtde / varInicial) / Log10(varTaxa))
            txtTempo.Text = varTempo.ToString("N1")
        End If
    End Sub
End Class