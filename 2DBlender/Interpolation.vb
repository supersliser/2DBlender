Public Class Interpolation(Of T)
    Inherits Keyframe(Of T)
    Public Type As Interpolations

    Public Overrides Sub Draw(g As Graphics)
        Select Case Type
            Case Interpolations.StaticMovement
                g.FillEllipse(New SolidBrush(Color.Red), New Rectangle(New Point(Main.KeyframeViewer.Coordinates.GridSquareSize.Width * (Frame - 1), Main.KeyframeViewer.Coordinates.GridSquareSize.Height) - New Point(4, 4), New Size(8, 8)))
            Case Interpolations.ConstantMovement
                g.FillEllipse(New SolidBrush(Color.Green), New Rectangle(New Point(Main.KeyframeViewer.Coordinates.GridSquareSize.Width * (Frame - 1), Main.KeyframeViewer.Coordinates.GridSquareSize.Height) - New Point(4, 4), New Size(8, 8)))
        End Select
    End Sub

    Public Sub Key(PreviousFrame As UInteger, PreviousData As TPoint)
        Select Case Type
            Case = Interpolations.StaticMovement
                Data = CObj(PreviousData)
            Case = Interpolations.ConstantMovement
                Dim temp2 As Object = NextItem.Data
                Dim temp As TPoint = temp2
                Dim FrameDistance As Integer = NextItem.Frame - PreviousFrame
                Dim xDistance As Integer = temp.WorldX - PreviousData.WorldX
                Dim yDistance As Integer = temp.WorldY - PreviousData.WorldY

                For i = 1 To FrameDistance - 1
                    Data = CObj(New TPoint(CSng(PreviousData.WorldX + (xDistance * (i / FrameDistance))), CSng(PreviousData.WorldY + (yDistance * (i / FrameDistance)))))
                Next
        End Select
    End Sub

    Public Sub Key(PreviousFrame As UInteger, PreviousData As Color)
        Select Case Type
            Case Interpolations.StaticMovement
                Data = CObj(PreviousData)
            Case = Interpolations.ConstantMovement
                Dim temp2 As Object = NextItem.Data
                Dim temp As Color = temp2
                Dim FrameDistance As Integer = NextItem.Frame - PreviousFrame
                Dim aDistance As Integer = temp.A - PreviousData.A
                Dim rDistance As Integer = temp.R - PreviousData.R
                Dim gDistance As Integer = temp.G - PreviousData.G
                Dim bDistance As Integer = temp.B - PreviousData.B

                For i = 1 To FrameDistance - 1
                    Data = CObj(Color.FromArgb(CUInt(PreviousData.A + (aDistance * (i / FrameDistance))), CUInt(PreviousData.R + (rDistance * (i / FrameDistance))), CUInt(PreviousData.G + (gDistance * (i / FrameDistance))), CUInt(PreviousData.B + (bDistance * (i / FrameDistance)))))
                Next
        End Select
    End Sub
End Class
Public Enum Interpolations
    StaticMovement
    ConstantMovement
End Enum
