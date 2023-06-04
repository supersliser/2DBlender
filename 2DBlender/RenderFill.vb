Public Structure RenderFill
    Public Vertex(,) As Point
    Public Colour() As Color
    Public Z As Integer

    Public Sub New(FrameCount As UInteger, VerticesCount As UInteger)
        ReDim Vertex(FrameCount, VerticesCount)
        ReDim Colour(FrameCount)
    End Sub

    Public Function ToPath(Frame As UInteger) As Drawing2D.GraphicsPath
        Dim tempVertices(Vertex.GetLength(1) - 1) As Point
        For i = 0 To Vertex.GetLength(1) - 1
            tempVertices(i) = Vertex(Frame, i)
        Next
        Dim tempTypes(Vertex.GetLength(1) - 1) As Byte
        For i = 1 To Vertex.GetLength(1) - 1
            tempTypes(i) = 1
        Next
        tempTypes(0) = 0
        Return New Drawing2D.GraphicsPath(tempVertices, tempTypes)
    End Function
    Public Function ToRegion(Frame As UInteger) As Region
        Return New Region(ToPath(Frame))
    End Function
End Structure
