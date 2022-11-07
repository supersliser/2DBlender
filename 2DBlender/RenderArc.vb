Public Class RenderArc
    Public Start() As Point
    Public Finish() As Point
    Public Colour() As Color
    Public Z As Integer

    Public Sub New(Start As TPoint, Finish As TPoint, Colour As Color, Z As Integer)
        Me.Start(0) = Start.GridLocation
        Me.Finish(0) = Finish.GridLocation
        Me.Colour(0) = Colour
        Me.Z = Z
    End Sub
End Class
