Public Class CoordinateSystem 'used to store locational data and to convert between windows points and custom grid points
    Public GridSquareSize As Size 'stores the size of an individual square within a grid
    Private GridPoint(,) As Point 'stores the individual grid coordinates and their relative world coordinates
    Public WorldSize As Size 'stores the size of the canvas
    Public ReadOnly Property GridSize As Size 'accesses the size of the canvas in grid coordinates
        Get
            Return New Size(WorldSize.Width / GridSquareSize.Width, WorldSize.Height / GridSquareSize.Height)
        End Get
    End Property


    Public Function ToGrid(World As PointF) As Point 'converts a world coordinate to a grid coordinate
        Dim loopbreak As UInteger
        Do
            For x = 0 To GridSize.Width 'steps through each grid coordinate
                For y = 0 To GridSize.Height
                    If World.X >= GridPoint(x, y).X - (GridSquareSize.Width / 2) Then 'checks that the specified world coordinate is within the hitbox of the grid coordinate
                        If World.Y >= GridPoint(x, y).Y - (GridSquareSize.Height / 2) Then
                            If World.X < GridPoint(x, y).X + (GridSquareSize.Width / 2) Then
                                If World.Y < GridPoint(x, y).Y + (GridSquareSize.Height / 2) Then
                                    Return New Point(x, y)
                                End If
                            End If
                        End If
                    End If
                Next
            Next
            If World.X > WorldSize.Width Then
                World.X = WorldSize.Width
            End If
            If World.Y > WorldSize.Height Then
                World.Y = WorldSize.Height
            End If
            loopbreak += 1
        Loop Until loopbreak = 2
    End Function


    Public Function ToWorld(Grid As Point) As PointF 'converts a grid coordinate to a world coordinate
        Try
            Return GridPoint(Grid.X, Grid.Y)
        Catch ex As IndexOutOfRangeException
            If Grid.X < 0 Then
                Grid.X = 0
            End If
            If Grid.Y < 0 Then
                Grid.Y = 0
            End If
            If Grid.X > GridSize.Width Then
                Grid.X = GridSize.Width
            End If
            If Grid.Y > GridSize.Height Then
                Grid.Y = GridSize.Height
            End If
            Return GridPoint(Grid.X, Grid.Y)
        End Try
    End Function


    Public Sub New(WorldSize As Size, GridSquareSize As Size) 'constructs the object
        Me.WorldSize = WorldSize
        Me.GridSquareSize = GridSquareSize
        ReDim GridPoint(GridSize.Width, GridSize.Height)
        For x = 0 To GridSize.Width 'steps through each grid coordinate and records its relevant world coordinate
            For y = 0 To GridSize.Height
                GridPoint(x, y) = New Point(x * GridSquareSize.Width, y * GridSquareSize.Height)
            Next
        Next
    End Sub

    Public Sub New(WorldSize As Size, GridBoxX As UInteger, GridBoxY As UInteger)
        Me.WorldSize = WorldSize
        ReDim GridPoint(GridBoxX, GridBoxY)
        For x = CUInt(0) To GridBoxX
            For y = CUInt(0) To GridBoxY
                GridPoint(x, y) = New Point(x * (WorldSize.Width / GridBoxX), y * (WorldSize.Height / GridBoxY))
            Next
        Next
        GridSquareSize = New Size(WorldSize.Width / GridBoxX, WorldSize.Height / GridBoxY)
    End Sub

    Public Sub DrawGrid(g As Graphics) 'draws the grid to the provided graphics system
        For x = 0 To GridPoint.GetLength(0) - 1
            For y = 0 To GridPoint.GetLength(1) - 1
                g.DrawRectangle(New Pen(Color.FromArgb(10, Color.Black)), New Rectangle(GridPoint(x, y), GridSquareSize))
            Next
        Next

    End Sub
End Class