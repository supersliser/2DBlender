Public Class RenderFill
    Public Vertex(,) As Point
    Public Colour() As Color
    Public Z As Integer

    Public Sub New(Vertices As TPoint(), Colour As Color, Z As Integer)
        For i = 0 To Vertices.Count - 1
            Vertex(0, i) = Vertices(i).GridLocation
        Next
        Me.Colour(0) = Colour
        Me.Z = Z
    End Sub
End Class
