Public Class frmOLEFichas
    Dim stdDocName As String
    Dim corSelect As System.Drawing.Color
    Dim corNormal As System.Drawing.Color

    Private Sub frmOLEFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Define as cores
        corNormal = System.Drawing.SystemColors.Control
        corSelect = System.Drawing.SystemColors.MenuHighlight

    End Sub
    Private Sub frame1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame1.Click
        stdDocName = "FCtrProd.doc"
        Frame1.BackColor = corSelect    'Selecionado
        frame2.BackColor = corNormal   'Normal
        Frame3.BackColor = corNormal   'Normal
        Frame4.BackColor = corNormal   'Normal
        Frame5.BackColor = corNormal   'Normal
    End Sub

    Private Sub frame2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frame2.Click
        stdDocName = "FCtrEuca.doc"
        Frame1.BackColor = corNormal    'Normal
        frame2.BackColor = corSelect    'Selecionado
        Frame3.BackColor = corNormal    'Normal
        Frame4.BackColor = corNormal    'Normal
        Frame5.BackColor = corNormal    'Normal
    End Sub

    Private Sub Frame3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame3.Click

        stdDocName = "FPlantio.doc"
        Frame1.BackColor = corNormal    'Normal
        frame2.BackColor = corNormal    'Normal
        Frame3.BackColor = corSelect    'Selecionado
        Frame4.BackColor = corNormal    'Normal
        Frame5.BackColor = corNormal    'Normal

    End Sub
    Private Sub Frame4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame4.Click
        stdDocName = "FOrq.doc"
        Frame1.BackColor = corNormal    'Normal
        frame2.BackColor = corNormal    'Normal
        Frame3.BackColor = corNormal    'Normal
        Frame4.BackColor = corSelect    'Selecionado
        Frame5.BackColor = corNormal    'Normal
    End Sub
    Private Sub Frame5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame5.Click
        stdDocName = "FMeio.doc"
        Frame1.BackColor = corNormal    'Normal
        frame2.BackColor = corNormal    'Normal
        Frame3.BackColor = corNormal    'Normal
        Frame4.BackColor = corNormal    'Normal
        Frame5.BackColor = corSelect    'Selecionado
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Call frame1_Click(sender, e)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Call frame2_Click(sender, e)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Call Frame3_Click(sender, e)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Call frame1_Click(sender, e)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Call frame2_Click(sender, e)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Call Frame3_Click(sender, e)
    End Sub

    Private Sub brPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brPrint.Click
        Dim oWordObj As Object
        oWordObj = CreateObject("Word.Application")
        oWordObj.Documents.Open(My.Application.Info.DirectoryPath & "\Fichas\" & stdDocName)
        oWordObj.ActiveDocument.PrintOut(Copies:=nCopias.Value.ToString)
        oWordObj.Quit()
    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click
        Frame4_Click(sender, e)
    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click
        Frame4_Click(sender, e)
    End Sub


    Private Sub pb5_Click(sender As System.Object, e As System.EventArgs) Handles pb5.Click
        Frame5_Click(sender, e)
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click
        Frame5_Click(sender, e)
    End Sub

    Private Sub Frame1_Enter(sender As System.Object, e As System.EventArgs) Handles Frame1.Enter

    End Sub
End Class