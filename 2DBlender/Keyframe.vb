Public Class Keyframe(Of T) 'Stores data relative to a particular frame
    Public Frame As UInteger
    Public Data As T
    Public NextItem As Keyframe(Of T)
    Public ReadOnly Property IsTail As Boolean
        Get
            Try
                Dim temp As UInteger = NextItem.Frame
            Catch ex As NullReferenceException
                Return True
            End Try
            Return False
        End Get
    End Property
    Public Overridable Sub Draw(g As Graphics)
        g.FillEllipse(New SolidBrush(Color.Black), New Rectangle(New Point(Main.KeyframeViewer.Coordinates.GridSquareSize.Width * (Frame - 1), Main.KeyframeViewer.Coordinates.GridSquareSize.Height) - New Point(4, 4), New Size(8, 8)))
    End Sub
End Class
