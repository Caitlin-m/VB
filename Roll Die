'====================================================================
'
'====================================================================
Option Strict On
Option Explicit On
Public Class frmRoll

    Dim graCanvas As Graphics
    Dim bmpDie1 As Bitmap
    Dim bmpDie2 As Bitmap
    Dim cintDie1 As Integer
    Dim cintDie2 As Integer

    Private Sub btnRoll_Click(sender As Object, e As EventArgs) _
        Handles btnRoll.Click
        '====================================================================
        '
        '====================================================================

        cintDie1 = CInt(Int(6 * Rnd()) + 1)
        cintDie2 = CInt(Int(6 * Rnd()) + 1)

        bmpDie1 = New Bitmap("...\Images\die" & cintDie1.ToString & ".png")
        bmpDie2 = New Bitmap("...\Images\die" & cintDie2.ToString & ".png")

        graCanvas.DrawImageUnscaled(bmpDie1, 0, 0)
        graCanvas.DrawImageUnscaled(bmpDie2, bmpDie1.Width + 10, 0)

        lblScore.Text = (cintDie1 + cintDie2).ToString
        lstScores.Items.Add(cintDie2 + cintDie1).ToString()
        lstScores.Sorted = True


    End Sub

    Private Sub frmRol_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        '====================================================================
        '
        '====================================================================

        graCanvas = pnlDice.CreateGraphics

        Randomize()
    End Sub
End Class
