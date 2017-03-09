'==============================================================================
'   Project:            Final Project
'   Title:              
'   File Name:          
'   Date Completed:     
'
'   Group Members:      Caitlin McMurchie, Chistopher Hale, Michael Guich
'   Class:              161, 2107, Winter Quarter
'
'   Description:        A top down 2D racing game                       
'                       If you crash 5 times into another car, you loose                  
'                       Use the arrow keys To move up, down, left, And right                     
'                       
'==============================================================================
'   Known Bugs:
'==============================================================================
Option Strict On
Option Explicit On

Imports System.Drawing.Drawing2D
Imports System.Threading
Public Class frmFinal

    Dim cshtFrames As Short = 1

    Dim graBG As Graphics
    Dim graBGBuffer As Graphics
    Dim graSprite As Graphics
    Dim graObstacle As Graphics
    Dim graObstacle2 As Graphics

    Dim bmpBuffer As Bitmap
    Dim bmpSprite As Bitmap = New Bitmap("..\Images\CarSprite2.bmp")
    Dim bmpBG As Bitmap
    Dim bmpObstacle As Bitmap = New Bitmap("..\Images\CarSprite.bmp")

    Dim cshtSpriteX As Short = 50
    Dim cshtSpriteY As Short = 350
    Dim cshtSpriteW As Short = CShort(bmpSprite.Width \ cshtFrames)
    Dim cshtSpriteH As Short = CShort(bmpSprite.Height)
    Dim cshtSpriteSpeed As Short = 10        'controls how meany spaces the car moves when you press an arrow key
    Dim cshtGameSpeed As Short


    'first car
    Dim cshtObstacleX As Short = 700
    Dim cshtObstacleY As Short = 188
    Dim cshtObstacleW As Short = CShort(bmpObstacle.Width)
    Dim cshtObstacleH As Short = CShort(bmpObstacle.Height)

    Dim cshtObstacleXStep As Short = -100
    Dim cshtObstacleYStep As Short = 0

    Dim cshtObstacle2X As Short = 700
    Dim cshtObstacle2Y As Short = 388
    Dim cshtObstacle2W As Short = CShort(bmpObstacle.Width)
    Dim cshtObstacle2H As Short = CShort(bmpObstacle.Height)

    Dim cshtObstacle2XStep As Short = -10
    Dim cshtObstacle2YStep As Short = 0

    Const CSHTXSTEP As Short = -10
    Dim cshtBGXStep As Short = CSHTXSTEP         'controls background speed
    Dim cshtBGYStep As Short = 0

    Dim cshtBGX As Short

    Dim mtxSprite As Matrix
    Dim mtxBG As Matrix

    Dim recCurrentFrame As Rectangle
    Dim cshtFrameX As Short
    Dim cshtFrameY As Short
    Dim cshtAnimatedSpriteLength As Short = CShort(bmpSprite.Width)

    Dim cstrStartup As String = Application.StartupPath

    Private Sub frmFinal_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        '======================================================================
        '   Description:    loads the bmp and graphics maps
        '                   initializes matrixes
        '======================================================================

        Const strPATH As String = "..\Images\"

        prgHealthBar.Value = 100

        'cstrStartup = cstrStartup.Substring(0, cstrStartup.Length - "Sounds".Length)

        wmpIntro.URL = "D:\Final Project\161 Final Project\bin\Sounds\Intro.wav"
        wmpIntro.Ctlcontrols.play()

        bmpBG = New Bitmap(strPATH & "RaceTrack3.bmp")
        graBG = pnlGame.CreateGraphics
        bmpBuffer = New Bitmap(pnlGame.Width, pnlGame.Height, graBG)
        graBGBuffer = Graphics.FromImage(bmpBuffer)
        graSprite = Graphics.FromImage(bmpBuffer)
        bmpSprite.MakeTransparent(Color.FromArgb(255, 0, 255))
        graObstacle = Graphics.FromImage(bmpBuffer)
        bmpObstacle.MakeTransparent(Color.FromArgb(255, 0, 255))

        mtxSprite = New Matrix(1, 0, 0, 1, cshtObstacleXStep, cshtObstacleYStep)
        mtxBG = New Matrix(1, 0, 0, 1, cshtBGXStep, cshtBGYStep)

        MessageBox.Show("DIRECTIONS ON HOW TO PLAY:" & vbCrLf &
                "       Use the Up, Down, Left, and Right keys to move" _
                & vbCrLf &
                "       If you hit another car you will take damage and loose health." _
                & vbCrLf & "       If you are hit five times you loose." _
                & vbCrLf &
                "       Make it to the end and you win" & vbCrLf)

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) _
        Handles btnStart.Click
        '======================================================================
        '   Description:    Starts the game
        '
        '                   detects collision between player car and objects
        '
        '                   keeps track of health
        '
        '                   if you're hit more 5 times a screen is diplayed
        '                       saying that you lost
        '======================================================================
        Dim shtViewWidth As Short = CShort(pnlGame.Width)
        Dim i As Integer
        Dim j As Integer
        Dim blnCrash As Boolean = False
        Dim shtCrashes As Short
        Dim intGameSpeedEffect As Integer

        cshtGameSpeed = 0

        btnStart.Enabled = False
        btnStop.Enabled = False

        Randomize()
        cshtObstacleX = CShort(Rnd() * (bmpBG.Width - shtViewWidth) _
            + shtViewWidth)         'spawn cars
        cshtObstacle2X = CShort(Rnd() * (bmpBG.Width - shtViewWidth) _
            + shtViewWidth)

        Do Until shtCrashes > 4
            intGameSpeedEffect = 0
            'i = 0
            'Do Until i >= CShort((bmpBG.Width - shtViewWidth) / _
            '                               (cshtBGXStep * (-1)))
            For i = 0 To CShort(((bmpBG.Width - shtViewWidth) /
                (cshtBGXStep * (-1))) + intGameSpeedEffect)
                intGameSpeedEffect += cshtGameSpeed

                Do Until cshtBGXStep = CSHTXSTEP + cshtGameSpeed
                    If cshtBGXStep < CSHTXSTEP + cshtGameSpeed Then
                        cshtBGXStep += CShort(1)
                    ElseIf cshtBGXStep > CSHTXSTEP + cshtGameSpeed Then
                        cshtBGXStep -= CShort(1)
                    End If
                    mtxBG = New Matrix(1, 0, 0, 1, cshtBGXStep, cshtBGYStep)
                Loop

                graBGBuffer.DrawImageUnscaled(bmpBG, 0, 0)

                recCurrentFrame = New Rectangle(cshtFrameX, cshtFrameY,
                                                cshtSpriteW, cshtSpriteH)
                graSprite.DrawImage(bmpSprite, cshtSpriteX, cshtSpriteY,
                                    recCurrentFrame, GraphicsUnit.Pixel)


                If cshtFrameX >= cshtAnimatedSpriteLength - cshtSpriteW Then 'animation
                    cshtFrameX = 0
                Else
                    cshtFrameX += cshtSpriteW
                End If


                If cshtObstacleX > -cshtObstacleW Then   'respawn car when off screen 
                    cshtObstacleX += cshtObstacleXStep + cshtGameSpeed
                Else
                    cshtObstacleX = CShort(Rnd() * (bmpBG.Width - shtViewWidth) _
                        + shtViewWidth)
                End If

                If cshtObstacle2X > -cshtObstacle2W Then   'respawn car2 when off screen 
                    cshtObstacle2X += cshtObstacle2XStep + cshtGameSpeed
                Else
                    cshtObstacle2X = CShort(Rnd() * (bmpBG.Width -
                        shtViewWidth) + shtViewWidth)
                End If

                lblInfo.Text = "X is " & cshtSpriteX.ToString & Chr(13) &
                    "Obstacle X is " & cshtObstacle2X.ToString & Chr(13) &
                    " GameSpeed = " & cshtGameSpeed.ToString   '<  dont include in final

                graObstacle.DrawImageUnscaled(bmpObstacle, (cshtObstacleX),
                                              cshtObstacleY)
                graObstacle.DrawImageUnscaled(bmpObstacle, cshtObstacle2X,
                                              cshtObstacle2Y)
                graBG.DrawImageUnscaled(bmpBuffer, 0, 0)
                Thread.Sleep(0)

                'colision detection 
                If fCrash(i, cshtSpriteX, cshtSpriteY, cshtSpriteW, cshtSpriteH,
                          cshtObstacleX, cshtObstacleY, cshtObstacleW,
                          cshtObstacleH) And blnCrash = False Then

                    blnCrash = True

                    shtCrashes += CShort(1)
                    If shtCrashes = 1 Then
                        MsgBox("you've crashed " & shtCrashes.ToString &
                               " time.")
                        prgHealthBar.Value -= 20
                        wmpCrash.URL = "D:\Final Project\161 Final Project\bin\Sounds\Car Crash.wav"
                        wmpCrash.Ctlcontrols.play()
                    Else
                        MsgBox("you've crashed " & shtCrashes.ToString &
                               " times.")
                        prgHealthBar.Value -= 20
                        wmpCrash.Ctlcontrols.play()
                    End If

                    'respawn obstacle car
                    cshtObstacleX = CShort(Rnd() * (bmpBG.Width - shtViewWidth) _
                        + shtViewWidth)

                ElseIf fCrash(i, cshtSpriteX, cshtSpriteY, cshtSpriteW,
                              cshtSpriteH, cshtObstacle2X, cshtObstacle2Y,
                              cshtObstacle2W, cshtObstacle2H) And
                              blnCrash = False Then

                    blnCrash = True

                    shtCrashes += CShort(1)
                    If shtCrashes = 1 Then
                        MsgBox("youve crashed " & shtCrashes.ToString &
                               " time.")
                        prgHealthBar.Value -= 20
                        wmpCrash.Ctlcontrols.play()
                    Else
                        MsgBox("youve crashed " & shtCrashes.ToString &
                               " times.")
                        prgHealthBar.Value -= 20
                        wmpCrash.Ctlcontrols.play()
                    End If

                    'respawn obstacle car
                    cshtObstacle2X = CShort(Rnd() * (bmpBG.Width - shtViewWidth) _
                        + shtViewWidth)

                End If

                graBGBuffer.MultiplyTransform(mtxBG)
                Application.DoEvents()
                cshtBGX = CShort(i)
                blnCrash = False


                If shtCrashes > 4 Then      'check if you've damaged out
                    i = CShort((bmpBG.Width - shtViewWidth) / (cshtBGXStep *
                        (-1)))
                    MessageBox.Show("YOU LOOSE")
                    prgHealthBar.Value = 100
                    wmpLoosing.URL = "D:\Final Project\161 Final Project\bin\Sounds\Music\Outro\Motivator.mp3"
                    wmpLoosing.Ctlcontrols.play()

                End If

                'i += cshtBGXStep
                ' Loop

            Next i
            graBGBuffer.ResetTransform()
            blnCrash = False
        Loop
            btnStart.Enabled = True
        btnStop.Enabled = True

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) _
        Handles btnStop.Click
        '======================================================================
        '   Description:    Stops the game
        '======================================================================

        Me.Close()

    End Sub
    Private Function fCrash(ByVal intX As Integer, ByVal intObj1X As Integer,
                        ByVal intObj1Y As Integer, ByVal intObj1W As Integer,
                        ByVal intObj1H As Integer, ByVal intObj2X As Integer,
                        ByVal intObj2Y As Integer, ByVal intObj2W As Integer,
                        ByVal intObj2H As Integer) As Boolean
        '======================================================================
        '   Description:  collision detection for car and obsticals
        '======================================================================
        Dim blnAnswer As Boolean = False

        If intObj1X + intObj1W >= intObj2X And
                        intObj1Y + intObj1H >= intObj2Y And
                        intObj1Y <= intObj2Y + intObj1H And
                         intObj1X <= intObj2X + intObj2W Then

            blnAnswer = True

        End If
        Return blnAnswer
    End Function

    Private Sub frmFinal_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles Me.KeyDown

        '======================================================================
        '   Description: Controls the speed and direction of the car
        '======================================================================

        Dim shtviewWidth As Short = CShort(pnlGame.Width)

        'If e.KeyCode = Keys.Right And cshtSpriteX < (shtviewWidth - _
        '               cshtSpriteSpeed -bmpSprite.Width) Then
        '    cshtSpriteX += cshtSpriteSpeed
        'ElseIf e.KeyCode = Keys.Left And cshtSpriteX > (cshtSpriteSpeed) Then
        '    cshtSpriteX -= cshtSpriteSpeed
        If e.KeyCode = Keys.Down And cshtSpriteY < (pnlGame.Height -
            cshtSpriteSpeed - bmpSprite.Height) Then
            cshtSpriteY += CShort(cshtSpriteSpeed + 20)
        ElseIf e.KeyCode = Keys.Up Then
            cshtSpriteY -= CShort(cshtSpriteSpeed + 20)
        ElseIf e.KeyCode = Keys.Right And cshtGameSpeed > (-50) Then
            cshtGameSpeed -= CShort(1)
        ElseIf e.KeyCode = Keys.Left And cshtGameSpeed < 9 Then
            cshtGameSpeed += CShort(1)
        End If

    End Sub


End Class
