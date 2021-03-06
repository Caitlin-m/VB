'=====================================================================
'=====================================================================

Option Explicit On
Option Strict On

Imports System.Drawing.Drawing2D
Imports System.Threading

Public Class frmAnimation

    Dim graBG As Graphics
    Dim graBGBuffer As Graphics
    Dim graSprite As Graphics
    Dim bmpBuffer As Bitmap
    Dim bmpSprite As Bitmap
    Dim bmpBG As Bitmap

    Dim cshtSpriteX As Short = 10
    Dim cshtSpriteY As Short = 150

    Dim cshtBGX As Short

    Dim cshtSpriteXStep As Short = 0
    Dim cshtSpriteYStep As Short = 0

    Dim cshtBGXStep As Short = -1
    Dim cshtBGYStep As Short = 0

    Dim mtxBG As Matrix
    Dim mtxSprite As Matrix


    Private Sub btnPlay_Click(ByVal sender As Object, _
                       ByVal e As System.EventArgs) Handles btnPlay.Click

        Dim shtViewWidth As Short = CShort(pnlGame.Width)
        Dim i As Integer
        Dim j As Integer

        btnPlay.Enabled = False
        For j = 0 To 2
            For i = 0 To bmpBG.Width - shtViewWidth
                graBGBuffer.DrawImageUnscaled(bmpBG, 0, 0)
                lblInfo.Text = "X is " & cshtSpriteX.ToString
                graSprite.DrawImageUnscaled(bmpSprite, cshtSpriteX, cshtSpriteY)
                graBG.DrawImageUnscaled(bmpBuffer, 0, 0)
                Thread.Sleep(10)
                graBGBuffer.MultiplyTransform(mtxBG)
                Application.DoEvents()
                cshtBGX = CShort(i)
            Next i
            graBGBuffer.ResetTransform()
        Next j

        btnPlay.Enabled = True
    End Sub



    Private Sub frmAnimation_Load(sender As Object, e As EventArgs) _
        Handles Me.Load
        Const strPATH As String = "..\Images\"

        bmpSprite = New Bitmap(strPATH & "car.bmp")
        bmpBG = New Bitmap(strPATH & "background.bmp")
        graBG = pnlGame.CreateGraphics
        bmpBuffer = New Bitmap(pnlGame.Width, pnlGame.Height)
        graBGBuffer = Graphics.FromImage(bmpBuffer)
        graSprite = Graphics.FromImage(bmpBuffer)
        bmpSprite.MakeTransparent(Color.FromArgb(255, 0, 255))
        mtxBG = New Matrix(1, 0, 0, 1, cshtBGXStep, cshtBGYStep)
        mtxSprite = New Matrix(1, 0, 0, 1, cshtSpriteXStep, cshtSpriteYStep)

    End Sub

    Private Sub frmAnimation_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown

        Dim shtViewWidth As Short = CShort(pnlGame.Width)

        If e.KeyCode = Keys.Right And cshtSpriteX < (shtViewWidth - 3 - bmpSprite.Width) Then
            cshtSpriteX += CShort(3)
        ElseIf e.KeyCode = Keys.Left Then
            cshtSpriteX -= CShort(3)
        ElseIf e.KeyCode = Keys.Down Then
            cshtSpriteY += CShort(3)
        ElseIf e.KeyCode = Keys.Up Then
            cshtSpriteY -= CShort(3)
        End If

    End Sub
End Class
