Public Class Camera
    Inherits Entity(Of TPoint)
    Public Size As TSize

    Public Sub New(Location As TPoint, Size As TSize)
        MyBase.New(Location, 0)
        Me.Size = Size
    End Sub

    Public Sub Draw(g As Graphics)
        g.DrawRectangle(New Pen(Color.BlueViolet), New Rectangle(New Point(CurrentValue.WorldX, CurrentValue.WorldY), New Size(Size.WorldWidth, Size.WorldHeight)))
    End Sub
End Class
