Option Strict On
Option Explicit On
Public Class frmPoint

    Dim graCanvas As Graphics
    Dim bmpCanvas As Bitmap

    Private Sub btnStart_Click(sender As Object, e As EventArgs) _
        Handles btnStart.Click
        '--------------------------------------------------------------------
        ' Description:  Draw a dot in the middle of pnlPoint
        '--------------------------------------------------------------------

        Dim i As Integer
        Dim j As Integer
        Dim intW As Integer = pnlPoint.Width - 1
        Dim intH As Integer = pnlPoint.Height - 1
        Dim intX As Integer
        Dim intY As Integer

        graCanvas = pnlPoint.CreateGraphics
        bmpCanvas = New Bitmap(intW + 1, intH + 1, graCanvas)

        'intX = CInt(intW / 2)
        'intY = CInt(intH / 2)
        For j = 0 To 1000
            For i = 0 To 6000

                intX = CInt(intW * Rnd())
                intY = CInt(intH * Rnd())
                bmpCanvas.SetPixel(intX, intY, Color.Aqua)

                intX = CInt(intW * Rnd())
                intY = CInt(intH * Rnd())
                bmpCanvas.SetPixel(intX, intY, Color.LightPink)

                intX = CInt(intW * Rnd())
                intY = CInt(intH * Rnd())
                bmpCanvas.SetPixel(intX, intY, Color.Orchid)

                intX = CInt(intW * Rnd())
                intY = CInt(intH * Rnd())
                bmpCanvas.SetPixel(intX, intY, Color.Lavender)

            Next i
            graCanvas.DrawImageUnscaled(bmpCanvas, 0, 0)
        Next j

    End Sub

End Class
