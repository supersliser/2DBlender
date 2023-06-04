Public Class Camera
    Inherits Entity(Of TPoint)
    Public Size As TSize 'Stores the size of the camera
    Public ColourMode As ColourModes 'Stores the colour mode of the camera

    Public Sub New(Location As TPoint, Size As TSize)
        MyBase.New(Location, 0)
        Me.Size = Size
        Me.Name = "Camera" 'Default name for camera is just camera
        ColourMode = ColourModes.RGB 'Default colour mode is RGB
    End Sub
    Public Sub New(Name As String, Location As TPoint, Size As TSize)
        MyBase.New(Location, 0)
        Me.Size = Size
        Me.Name = Name
        ColourMode = ColourModes.RGB
    End Sub

    Public Sub Draw(g As Graphics) 'Draws the camera to the given graphics system
        If Highlighted Then
            g.DrawRectangle(New Pen(Color.Green), ToRect) 'Camera turns green if highlighted
        Else
            g.DrawRectangle(New Pen(Color.BlueViolet), ToRect) 'Camera is violet by default
        End If
    End Sub

    Public Function ToRect() As Rectangle 'Converts the camera to a rectangle
        Return New Rectangle(New Point(CurrentValue.WorldX, CurrentValue.WorldY), New Size(Size.WorldWidth, Size.WorldHeight))
    End Function

    Public Function SelectMe(Grid As Point) As Boolean 'steps through each grid coordinate and checks if that was where was clicked, if so then highlights the camera
        For i = CurrentValue.GridX - 1 To CurrentValue.GridX + Size.GridWidth + 1
            For j = CurrentValue.GridY - 1 To CurrentValue.GridY + Size.GridHeight + 1
                If New Point(i, j) = Grid Then
                    Highlighted = True
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Public Sub PushKeyframe(CurrentFrame As UInteger)
        Try
            CurrentValue = KF.GetKeyframe(CurrentFrame).getDataTPoint(CurrentFrame)
        Catch ex As Exception
        End Try
    End Sub
End Class
Public Enum ColourModes
    RGB
    BW
    Inverted
End Enum
