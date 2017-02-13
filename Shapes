'=========================================================================
'
'=========================================================================

Option Explicit On
Option Strict On

'Imports System.Drawing.Drawing2D
Public Class frmShapes

    Dim graShapes As Graphics
    Dim bmpShapes As Bitmap
    Dim cshtX As Short
    Dim cshtY As Short
    Dim cbytCount As Byte

    Private Sub frmShapes_Load(sender As Object,
                               e As EventArgs) Handles Me.Load
        '---------------------------------------------------------------------
        'Description:
        '---------------------------------------------------------------------

        graShapes = pnlShapes.CreateGraphics
        bmpShapes = New Bitmap(pnlShapes.Width, pnlShapes.Height, graShapes)

    End Sub
    Private Sub sUpDateScreen()
        '---------------------------------------------------------------------
        'Description:
        '---------------------------------------------------------------------

        graShapes.DrawImageUnscaled(bmpShapes, 0, 0)


    End Sub



    Private Sub btnDraw_Click(sender As Object,
                              e As EventArgs) Handles btnDraw.Click
        '---------------------------------------------------------------------
        'Description:
        '---------------------------------------------------------------------

        Dim pntList(2) As Point
        Dim clrTemp(2) As Color
        Dim bytColor(2) As Byte
        Dim penTemp As Pen = Pens.Pink
        Dim bshTemp As SolidBrush = New SolidBrush(Color.Azure)

        Dim i As Integer
        Dim j As Integer

        pntList(0).X = 255
        pntList(0).Y = 5
        pntList(1).X = 503
        pntList(1).Y = 50
        pntList(2).X = 115
        pntList(2).Y = 150

        clrTemp(0) = Color.Honeydew
        clrTemp(1) = Color.Firebrick
        clrTemp(2) = Color.Green

        cshtX = CShort(Int(pnlShapes.Width / 2.5))
        cshtY = CShort(Int(pnlShapes.Height / 1.8))

        For i = 0 To 2
            For j = 0 To 2
                bytColor(j) = CByte(Rnd() * 255)
            Next j
            clrTemp(i) = Color.FromArgb(bytColor(0), bytColor(1), bytColor(2))
        Next i

        penTemp = New Pen(clrTemp(0))
        bshTemp.Color = clrTemp(1)

        Select Case cbytCount
            Case 0
                graShapes.FillRectangle(bshTemp, cshtX, cshtY, 160, 60)
                graShapes.DrawRectangle(penTemp, cshtX, cshtY, 160, 60)

                cbytCount += CByte(1)
            Case 1
                graShapes.FillPolygon(bshTemp, pntList)
                graShapes.DrawPolygon(penTemp, pntList)

                cbytCount += CByte(1)
            Case 2
                graShapes.FillEllipse(bshTemp, 450, 100, 75, 75)
                graShapes.DrawEllipse(penTemp, 450, 100, 75, 75)

                cbytCount = CByte(0)
        End Select

    End Sub

End Class
