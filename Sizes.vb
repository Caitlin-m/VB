Option Explicit On
Option Strict On

Public Class frmSizes

    Dim graCanvas As Graphics
    Dim bmpSource As Bitmap
    Dim bmpDes As Bitmap
    Dim clrTemp As Color

    Dim cshtW As Short
    Dim cshtH As Short



    Private Sub frmSizes_Load(sender As Object,
                              e As EventArgs) Handles Me.Load
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------

        graCanvas = pnlSizes.CreateGraphics
        bmpSource = New Bitmap("..\Images\red-and-blue-nose-pitbull-puppies.jpg")
        bmpDes = New Bitmap(bmpSource.Width, bmpSource.Height)
        cshtW = CShort(bmpSource.Width - 1)
        cshtH = CShort(bmpSource.Height - 1)

        pnlSizes.BackColor = Me.BackColor



    End Sub

    Private Sub btnCopy_Click(sender As Object,
                              e As EventArgs) Handles btnCopy.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------
        Dim shtX As Short
        Dim shtY As Short

        For shtY = 0 To cshtH
            For shtX = 0 To cshtW
                clrTemp = bmpSource.GetPixel(shtX, shtY)
                bmpDes.SetPixel(shtX, shtY, clrTemp)
            Next shtX
        Next shtY

        Call sUpDate()

    End Sub

    Private Sub sUpDate()
        '-------------------------------------------------------------------------
        'Description:   
        '-------------------------------------------------------------------------

        graCanvas.DrawImage(bmpSource, 0, 0)
        graCanvas.DrawImageUnscaled(bmpDes, cshtW + 5, 0)

    End Sub

    Private Sub pnlSizes_Paint(sender As Object,
                               e As PaintEventArgs) Handles pnlSizes.Paint
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------

        Call sUpDate()

    End Sub

    Private Sub btnClear_Click(sender As Object,
                               e As EventArgs) Handles btnClear.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------

        graCanvas.Clear(pnlSizes.BackColor)
        bmpDes.Dispose()
        bmpDes = New Bitmap(cshtW + 1, cshtH + 1)
        Call sUpDate()


    End Sub

    Private Sub btnStretch_Click(sender As Object,
                                 e As EventArgs) Handles btnStretch.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------

        Dim shtX As Short
        Dim shtY As Short

        bmpDes = New Bitmap(((cshtW + 1) * 2), (cshtH + 1) * 2)

        For shtY = 0 To cshtH
            For shtX = 0 To cshtW
                clrTemp = bmpSource.GetPixel(shtX, shtY)
                bmpDes.SetPixel(shtX * 2, shtY * 2, clrTemp)
                bmpDes.SetPixel(shtX * 2, shtY * 2 + 1, clrTemp)
                bmpDes.SetPixel(shtX * 2 + 1, shtY * 2, clrTemp)
                bmpDes.SetPixel(shtX * 2 + 1, shtY * 2 + 1, clrTemp)
            Next shtX
        Next shtY

        Call sUpDate()

    End Sub

    Private Sub btnShrink_Click(sender As Object,
                                e As EventArgs) Handles btnShrink.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------
        Dim shtX As Short
        Dim shtY As Short
        Dim shtSize As Short = CShort(InputBox("Give me a shrink factor",
                                               "only numbers please", "2"))

        For shtY = 0 To cshtH
            For shtX = 0 To cshtW
                clrTemp = bmpSource.GetPixel(shtX, shtY)
                bmpDes.SetPixel(CShort(shtX / shtSize),
                                CShort(shtY / shtSize), clrTemp)
            Next shtX
        Next shtY

        Call sUpDate()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) _
        Handles btnExit.Click
        Me.Close()
    End Sub
End Class
