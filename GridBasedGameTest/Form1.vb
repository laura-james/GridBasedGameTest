Imports System.Drawing
'https://www.youtube.com/watch?v=XV2HFzbKOJI&t=43s
Public Class Form1
    'View PORT
    Dim ResWidth As Integer = 750
    Dim Resheight As Integer = 550
    Dim TileSize As Integer = 32
    'Graphics Variables
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim bmpTile As Bitmap
    Dim sRect As Rectangle
    Dim dRect As Rectangle


    'FPS Counter
    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim MaxTicks As Integer = 0

    ' Map Variables
    Dim map(100, 100, 100) As Integer 'x y and z - z is is block passable
    Dim Mapx As Integer = 20
    Dim MapY As Integer = 20
    'GAME RUNNING?
    Dim IsRunning As Boolean = True

    'Mouse Locations
    Dim mouseX As Integer
    Dim mouseY As Integer
    Dim mMapX As Integer
    Dim mMapY As Integer
    'Paint Brush
    Dim PaintBrush As Integer = 0




    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim myGraphics As Graphics
        myGraphics = Me.CreateGraphics
        Dim myPen As Pen
        myPen = New Pen(Brushes.DarkMagenta, 2)
        myGraphics.DrawLine(myPen, 60, 180, 220, 50)
        myGraphics.DrawRectangle(myPen, 100, 100, 200, 50)
        myPen.DashStyle = Drawing2D.DashStyle.Dot
        myGraphics.DrawRectangle(myPen, 200, 200, 250, 150)
        Dim myBrush As Brush
        myBrush = New SolidBrush(Color.Red)
        myGraphics.FillEllipse(myBrush, 250, 250, 60, 40)
        redbox()
    End Sub
    Public Sub redbox()
        Dim g As Graphics
        g = Me.CreateGraphics
        Dim bRed As Brush
        bRed = New SolidBrush(Color.Red)
        Dim bwhite As Brush
        bwhite = New SolidBrush(Color.White)
        Dim x1 As Integer = 100
        Do While x1 < 800
            x1 = x1 + 1
            g.FillRectangle(bRed, x1, 100, 50, 50)
            Threading.Thread.Sleep(10)
            g.FillRectangle(bwhite, x1, 100, 50, 50)
        Loop
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus() ' primary window at time of load
        'INITILAISE Graphics OBJECTS
        G = Me.CreateGraphics
        ' BB = New Bitmap(Me.Width, Me.Height)
        BB = New Bitmap(ResWidth, Resheight)
        bmpTile = New Bitmap(GFX.pbGFX.Image)

        'set up map
        map(21, 21, 0) = 1
        map(22, 21, 0) = 1
        StartGameLoop()

    End Sub
    Private Sub StartGameLoop()
        Do While IsRunning = True
            'Keep App responsive
            Application.DoEvents()

            '1.) Check user input
            '2.) Check AI
            '3.) Update Object Data (positions, status etc)
            '4.) Check triggers and Conditions
            '5.) Draw Graphics
            DrawGraphics()
            '6.) Playing sounds

            'UPDATE TICK COUNTER to know how loops are performing
            TickCounter()

        Loop
    End Sub

    Private Sub DrawGraphics()
        ' FILL THE BACKKBUFFER
        ' DRAW TILES
        For X = 0 To 19 ' 20 tiles across
            For Y = 0 To 14 '15 down (32 px each)
                'new sub to go here
                getsourcerect(Mapx + X, MapY + Y, TileSize, TileSize)
                dRect = New Rectangle(X * TileSize, Y * TileSize, TileSize, TileSize)
                G.DrawImage(bmpTile, dRect, sRect, GraphicsUnit.Pixel)
            Next
        Next

        'DRAW FINAL LAYERS
        'guys, menus,
        G.FillRectangle(Brushes.Red, 21 * TileSize, 4 * TileSize, TileSize, TileSize)
        G.FillRectangle(Brushes.Blue, 21 * TileSize, 6 * TileSize, TileSize, TileSize)
        G.DrawRectangle(Pens.Red, mouseX * TileSize, mouseY * TileSize, TileSize, TileSize)
        G.DrawString("ticks: " & tTicks & vbCrLf &
                     "TPS:" & MaxTicks & vbCrLf &
                     "MouseX:" & mouseX & vbCrLf &
                     "MouseY:" & mouseY & vbCrLf &
                     "MMapX:" & mMapX & vbCrLf &
                     "MMapY:" & mMapY & vbCrLf &
                     "", Me.Font, Brushes.Black, 650, 0)

        'COPY BACKBUFFER TO GRAPHICS OBJECTS
        G = Graphics.FromImage(BB)
        ' DRAW BACKBUFFER TO SCREEN
        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 0, ResWidth, Resheight)

        'FIX OVERDRAW
        G.Clear(Color.Chartreuse)
    End Sub

    Private Sub TickCounter()
        If tSec = TimeOfDay.Second And IsRunning = True Then
            tTicks = tTicks + 1
        Else
            MaxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        mouseX = Math.Floor(e.X / TileSize)
        mouseY = Math.Floor(e.Y / TileSize)

        mMapX = Mapx + mouseX
        mMapY = MapY + mouseY

    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'MsgBox("you clicked " & mMapX & " " & mMapY)
        If mouseX = 21 And mouseY = 4 Then
            PaintBrush = 1
        ElseIf mouseX = 21 And mouseY = 6 Then
            PaintBrush = 2
        End If
        Select Case PaintBrush
            Case 0
            Case 1 ' red
                map(mMapX, mMapY, 0) = 1

            Case 2 ' blue
                map(mMapX, mMapY, 0) = 2


        End Select
    End Sub
    Private Sub getsourcerect(ByVal x As Integer, ByVal y As Integer, byvalw As Integer, ByVal h As Integer)
        Select Case map(x, y, 0)
            Case 0 'grass
                sRect = New Rectangle(0, 0, TileSize, TileSize)
            Case 1 'tree
                sRect = New Rectangle(32, 32, TileSize, TileSize)
            Case 2 'mountain
                sRect = New Rectangle(64, 32, TileSize, TileSize)
        End Select
    End Sub
End Class
