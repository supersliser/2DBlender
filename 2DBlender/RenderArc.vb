Public Structure RenderArc
    Public Start() As Point
    Public Finish() As Point
    Public Colour() As Color
    Public Z As Integer

    Public Sub New(FrameCount As UInteger)
        ReDim Start(FrameCount)
        ReDim Finish(FrameCount)
        ReDim Colour(FrameCount)
    End Sub

End Structure
