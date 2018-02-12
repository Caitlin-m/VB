Option Explicit On
Option Strict On

Public Class frmColors

    Dim clr1 As Color
    Dim clr2 As Color
    Dim clrAvg As Color
    Dim cbytRed As Byte
    Dim cbytGrn As Byte
    Dim cbytBlu As Byte


    Private Sub btnColor1_Click(sender As Object,
                                e As EventArgs) Handles btnColor1.Click
        '----------------------------------------------------------------------
        'Description: When the user clicks on this button they can choose
        '             a color from the color dialog box.
        '----------------------------------------------------------------------

        dlgColor.FullOpen = True
        dlgColor.ShowDialog()
        clr1 = dlgColor.Color

        btnColor1.BackColor = clr1

    End Sub

    Private Sub btnColor2_Click(sender As Object,
                                e As EventArgs) Handles btnColor2.Click
        '----------------------------------------------------------------------
        'Description: When the user clicks on this button they can choose
        '             a color from the color dialog box.
        '----------------------------------------------------------------------

        dlgColor.FullOpen = True
        dlgColor.ShowDialog()
        clr2 = dlgColor.Color

        btnColor2.BackColor = clr2

    End Sub

    Private Sub btnAverage_Click(sender As Object,
                                 e As EventArgs) Handles btnAverage.Click
        '----------------------------------------------------------------------
        'Description:   This will show the average color to the user based on
        '               the selections they have made.
        '----------------------------------------------------------------------

        cbytRed = CByte((clr1.R / 2) + (clr2.R / 2))
        cbytGrn = CByte((clr1.G / 2) + (clr2.G / 2))
        cbytBlu = CByte((clr1.B / 2) + (clr2.B / 2))

        btnAverage.BackColor = Color.FromArgb(cbytBlu, cbytGrn, cbytRed)

    End Sub

    Private Sub frmColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
