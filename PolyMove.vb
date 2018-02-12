
Option Explicit On
Option Strict On

Imports System.Drawing.Drawing2D

Public Class frmPolyMove

    Dim graPolyMove As Graphics
    Dim mtxMoveX As Matrix
    Dim mtx2 As Matrix
    Dim mtx3 As Matrix
    Dim pntList() As Point = {New Point(10, 10), New Point(150, 70),
        New Point(80, 110)}

    Private Sub frmPolyMove_Load(ByVal sender As Object, _
                        ByVal e As System.EventArgs) Handles Me.Load
        '----------------------------------------------------------------------
        'Description:   
        '----------------------------------------------------------------------
        graPolyMove = pnlPolyMove.CreateGraphics
        mtxMoveX = New Matrix(1, 0, 0, 1, 10, 0)
        mtx2 = New Matrix(1.2, 0, 0, 1.2, 0, 0)
        mtx3 = New Matrix(1, 0, 0, 1, 0, 0)

    End Sub

    Private Sub btnDraw_Click(ByVal sender As Object, _
                      ByVal e As System.EventArgs) Handles btnDraw.Click
        '----------------------------------------------------------------------
        'Description:   
        '----------------------------------------------------------------------

        graPolyMove.DrawPolygon(Pens.HotPink, pntList)
        graPolyMove.FillPolygon(Brushes.Plum, pntList)
        graPolyMove.MultiplyTransform(mtxMoveX)

        graPolyMove.DrawPolygon(Pens.Aqua, pntList)
        graPolyMove.MultiplyTransform(mtx2)

        graPolyMove.DrawPolygon(Pens.SpringGreen, pntList)
        graPolyMove.MultiplyTransform(mtx3)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) _
        Handles btnClear.Click

        graPolyMove.Clear(pnlPolyMove.BackColor)

    End Sub
End Class
