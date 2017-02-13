
Option Explicit On
Option Strict On

Public Class frmLine

    Dim graCanvas As Graphics
    Dim bmpCanvas As Bitmap


    Private Sub btnDraw_Click(sender As Object, e As EventArgs) _
        Handles btnDraw.Click
        '----------------------------------------------------------------------
        'Description:   This will draw a line for the user.
        '----------------------------------------------------------------------

        Dim intX1 As Integer
        Dim intx2 As Integer
        Dim intY1 As Integer
        Dim intY2 As Integer
        Dim i As Integer
        Dim dblJ As Double
        Dim dblSlope As Double

        intX1 = Convert.ToInt32(txtX1.Text)
        intY1 = CInt(txtY1.Text)
        intx2 = CInt(txtX2.Text)
        intY2 = CInt(txtY2.Text)

        dblSlope = Math.Abs((intY2 - intY1) / (intx2 - intX1))

        If intY1 = intY2 Then
            dblJ = intY1
            For i = intX1 To intx2
                bmpCanvas.SetPixel(i, intY1, Color.BlueViolet)

            Next i
        ElseIf intX1 = intx2 Then
            i = intX1
            For dblJ = intY1 To intY2
                bmpCanvas.SetPixel(i, CInt(Int(dblJ)), Color.PaleVioletRed)
            Next dblJ
        Else
            dblJ = intY1

            For i = intX1 To intx2
                bmpCanvas.SetPixel(i, CInt(Int(dblJ)), Color.Green)
                dblJ += dblSlope
            Next i

        End If

        graCanvas.DrawImageUnscaled(bmpCanvas, 0, 0)

    End Sub

    Private Sub frmLine_Load(sender As Object, e As EventArgs) _
        Handles Me.Load
        '----------------------------------------------------------------------
        'Description:   Configure graphics and bitmap objects.
        '----------------------------------------------------------------------

        graCanvas = pnlLine.CreateGraphics
        bmpCanvas = New Bitmap(pnlLine.Width, pnlLine.Height)


    End Sub
End Class
