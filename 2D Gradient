Option Explicit On
Option Strict On

Public Class frmGradient2d

    Dim graCanvas As Graphics
    Dim bmpCanvas As Bitmap

    Private Sub btnRun_Click(sender As Object, e As EventArgs) _
        Handles btnRun.Click
        '----------------------------------------------------------------------
        'Description:   This will draw a 2d gradient from black to red. Then 
        '               draw another from green to black at 90 degrees.
        '----------------------------------------------------------------------

        Dim i As Integer
        Dim intW As Integer = pnlGradient.Width
        Dim intH As Integer = pnlGradient.Height
        Dim intX As Integer
        Dim intY As Integer
        Dim bytR As Byte
        Dim bytG As Byte
        Dim bytB As Byte
        Dim clrPoint As Color

        graCanvas = pnlGradient.CreateGraphics
        bmpCanvas = New Bitmap(intW, intH, graCanvas)

        intY = intH \ 2
        For intX = 0 To intW - 1
            bytR = CByte(intX / (intW - 1) * 255)
            clrPoint = Color.FromArgb(bytR, 0, 0)
            For i = -10 To 10
                bmpCanvas.SetPixel(intX, intY + i, clrPoint)
            Next i
            graCanvas.DrawImageUnscaled(bmpCanvas, 0, 0)
        Next intX

        intX = intW \ 2
        For intY = 0 To intH - 1
            bytG = CByte(intY / (intH - 1) * 255)
            clrPoint = Color.FromArgb(0, bytG, 0)
            For i = -10 To 9
                bmpCanvas.SetPixel(intX + i, intY, clrPoint)
            Next i
            graCanvas.DrawImageUnscaled(bmpCanvas, 0, 0)
        Next intY
    End Sub

    Private Sub frmGradient2d_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

    End Sub
End Class
