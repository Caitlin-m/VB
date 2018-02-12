
Option Explicit On
Option Strict On

'==============================================================================
'Project:   Pictures
'Tital:     Picutres
'File Name: 
'
'Author:    Caitlin McMurchie
'Class:     CS 161 Winter, 2017
'
'Description:   
'==============================================================================
'Known Bugs:    
'==============================================================================
Public Class frmPictures

    Dim graPicture As Graphics
    Dim bmpSource As Bitmap
    Dim bmpCopy As Bitmap
    Dim CshortW As Short
    Dim CshortH As Short
    Dim cshtOffset As Short = 5



    Private Sub frmPictures_Load(sender As Object,
                                 e As EventArgs) Handles Me.Load
        '-------------------------------------------------------------------------
        'Description:   Give substance to variables and objects.
        '-------------------------------------------------------------------------

        graPicture = pnlPictures.CreateGraphics
        bmpSource = New Bitmap("..\Images\pitbull-puppies10.jpg")
        CshortW = CShort(bmpSource.Width)
        CshortH = CShort(bmpSource.Height)
        bmpCopy = New Bitmap(CshortW, CshortH, graPicture)



    End Sub

    Private Sub btnCopy_Click(sender As Object,
                              e As EventArgs) Handles btnCopy.Click
        '-------------------------------------------------------------------------
        'Description:   This will make a visual copy of the source picture.
        '-------------------------------------------------------------------------
        Dim clrTemp As Color = Color.Black
        Dim i As Integer
        Dim j As Integer

        For i = 0 To CshortW - 1
            For j = 0 To CshortH - 1
                clrTemp = bmpSource.GetPixel(i, j)
                bmpCopy.SetPixel(i, j, clrTemp)

            Next j

        Next i

        Call sUpDateScreen()

    End Sub

    Private Sub pnlPictures_Paint(sender As Object,
                                  e As PaintEventArgs) Handles pnlPictures.Paint
        Call sUpDateScreen()



    End Sub

    Private Sub sUpDateScreen()
        graPicture.DrawImageUnscaled(bmpSource, 0, 0)
        graPicture.DrawImageUnscaled(bmpCopy, CshortW + 5, 0)

    End Sub

    Private Sub btnErase_Click(sender As Object,
                               e As EventArgs) Handles btnErase.Click

        Dim clrTemp As Color = pnlPictures.BackColor
        Dim shtX As Short
        Dim shtY As Short
        Dim I As Integer
        Dim j As Integer

        For I = 0 To 3000

            For j = 2 To 100
                shtX = CShort(Int(Rnd() * CshortW))
                shtY = CShort(Int(Rnd() * CshortH))
                bmpCopy.SetPixel(shtX, shtY, clrTemp)

            Next j
            Call sUpDateScreen()
        Next I

        For I = 0 To CshortW - 1
            For j = 0 To CshortH - 1
                bmpCopy.SetPixel(I, j, clrTemp)

            Next j

        Next I

        Call sUpDateScreen()

    End Sub

    Private Sub btnMirror_Click(sender As Object,
                                e As EventArgs) Handles btnMirror.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------
        Dim clrtemp As Color
        Dim i As Integer
        Dim j As Integer

        For i = 0 To CshortW - 1
            For j = 0 To CshortH - 1
                clrtemp = bmpSource.GetPixel(i, j)
                bmpCopy.SetPixel(CshortW - 1 - i, j, clrtemp)

            Next j

        Next i

        Call sUpDateScreen()

    End Sub

    Private Sub btnRotate_Click(sender As Object,
                                e As EventArgs) Handles btnRotate.Click
        '-------------------------------------------------------------------------
        'Description:
        '-------------------------------------------------------------------------
        Dim clrTemp As Color = Color.Black
        Dim shtX As Short
        Dim shtY As Short
        Dim i As Integer
        Dim j As Integer

        bmpCopy = New Bitmap(CshortH, CshortW, graPicture)

        For i = 0 To CshortW - 1
            For j = 0 To CshortH - 1
                clrTemp = bmpSource.GetPixel(i, j)
                bmpCopy.SetPixel(CshortH - 1 - j, CshortW - 1 - i, clrTemp)

            Next j

        Next i

        cshtOffset = 5

        Call sUpDateScreen()




    End Sub
End Class
