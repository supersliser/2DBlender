Public Class Keyframe(Of T) 'Stores data relative to a particular frame
    Public Frame As UInteger 'The time the data is for
    Public Data As T 'The data at the particular time
    Public NextItem As Keyframe(Of T) 'The next item in the linked list
    Public InterpolationToNext As Interpolations 'How the keyframe should move between this keyframe and the next keyframe
    Public ReadOnly Property IsTail As Boolean 'Whether the Keyframe is the last keyframe in the list
        Get
            Try
                Dim temp As UInteger = NextItem.Frame
            Catch ex As NullReferenceException
                Return True
            End Try
            Return False
        End Get
    End Property
    Public Overridable Sub Draw(g As Graphics) 'Draws the keyframes to the given keyframe viewport graphics system
        g.FillEllipse(New SolidBrush(Color.Black), New Rectangle(New Point(Main.KeyframeViewer.Coordinates.GridSquareSize.Width * (Frame - 1), Main.KeyframeViewer.Coordinates.GridSquareSize.Height) - New Point(4, 4), New Size(8, 8)))
    End Sub

    Public Function getDataTPoint(CurrentFrame As UInteger) As TPoint 'gets the data of a node keyframe based on the frame, data of previous keyframe and interpolation mode
        Select Case InterpolationToNext
            Case Interpolations.keyframe
                Return CObj(Data)
            Case Interpolations.StaticMovement
                Return CObj(Data)
            Case Interpolations.ConstantMovement
                Dim temp As Object = Data
                Dim start As TPoint = temp 'data's type is undefined so to avoid error, data is stored in temporary undefined object that can then be cast to tpoint
                temp = NextItem.Data
                Dim finish As TPoint = temp

                CurrentFrame = CurrentFrame - Frame 'works out the frame without relevance to starting position

                Dim frameDistance As UInteger = NextItem.Frame - Frame
                Dim xDistance As Single = (finish.WorldX - start.WorldX) / frameDistance 'distance point moves on X axis
                Dim yDistance As Single = (finish.WorldY - start.WorldY) / frameDistance 'distance point moves on Y axis

                Return New TPoint(CSng(start.WorldX + (CurrentFrame * xDistance)), CSng(start.WorldY + (CurrentFrame * yDistance)))
        End Select
    End Function

    Public Function getDataColour(CurrentFrame As UInteger) As Color 'gets the data of an arc or fill keyframe based on the frame, data of previous keyframe and interpolation mode
        Select Case InterpolationToNext
            Case Interpolations.keyframe
                Return CObj(Data)
            Case Interpolations.StaticMovement
                Return CObj(Data)
            Case Interpolations.ConstantMovement
                Dim temp As Object = Data
                Dim start As Color = temp
                temp = NextItem.Data
                Dim finish As Color = temp

                CurrentFrame = CurrentFrame - Frame

                Dim frameDistance As UInteger = NextItem.Frame - Frame
                Dim aDistance As Single = (finish.A - start.A) / frameDistance 'Change in alpha
                Dim rDistance As Single = (finish.R - start.R) / frameDistance 'Change in red
                Dim gDistance As Single = (finish.G - start.G) / frameDistance 'Change in green
                Dim bDistance As Single = (finish.B - start.B) / frameDistance 'Change in blue

                Return Color.FromArgb(CByte(start.A + (CurrentFrame * aDistance)), CByte(start.R + (CurrentFrame * rDistance)), CByte(start.G + (CurrentFrame * gDistance)), CByte(start.B + (CurrentFrame * bDistance)))
        End Select
    End Function

End Class
Public Enum Interpolations
    keyframe = 0 'no interpolation
    StaticMovement = 1 'data only changes on new keyframe
    ConstantMovement = 2 'data changes at constant rate between keyframes
End Enum