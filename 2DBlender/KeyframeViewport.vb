Public Class KeyframeViewport
    Public Coordinates As CoordinateSystem
    Public setup As Boolean = True

    Public Sub Initialise(FrameCount)
        TrackBar.Maximum = FrameCount
        Try
            Coordinates = New CoordinateSystem(New Point(OutputBox.Width - OutputBox.Padding.Horizontal, OutputBox.Height - OutputBox.Padding.Vertical), New Size((OutputBox.Width - OutputBox.Padding.Horizontal) / (TrackBar.Maximum - TrackBar.Minimum), (OutputBox.Height - OutputBox.Padding.Vertical) / 2))
        Catch ex As OverflowException
            Coordinates = New CoordinateSystem(New Point(OutputBox.Width - OutputBox.Padding.Horizontal, OutputBox.Height - OutputBox.Padding.Vertical), New Size((OutputBox.Width - OutputBox.Padding.Horizontal), (OutputBox.Height - OutputBox.Padding.Vertical) / 2))
        End Try
    End Sub

    Public Sub RefreshImage()
        If Not setup Then
            Dim OutputImage As New Bitmap(OutputBox.Width - OutputBox.Padding.Horizontal, OutputBox.Height)
            Dim g As Graphics = Graphics.FromImage(OutputImage)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            Coordinates.DrawGrid(g)
            Main.CurrentLayer.DrawKeyframes(g)
            OutputBox.Image = OutputImage
            OutputBox.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub TrackBar_Scroll(sender As Object, e As EventArgs) Handles TrackBar.Scroll
        If Not setup Then
            Main.CurrentLayer.PushKeyframes(TrackBar.Value)
            Select Case Main.CurrentLayer.SelectedItemType
                Case DisplayObjects.Node
                    Main.NodeProperties.RefreshNode(Main.CurrentLayer.SelectedItem)
                Case DisplayObjects.Arc
                    Main.ArcProperties.RefreshArc(Main.CurrentLayer.SelectedItem)
                Case DisplayObjects.Fill
                    Main.FillProperties.RefreshFill(Main.CurrentLayer.SelectedItem)
            End Select
            RefreshImage()
            Main.RefreshImage()
        End If
    End Sub

    Private Sub OutputBox_SizeChanged(sender As Object, e As EventArgs) Handles OutputBox.SizeChanged
        If Not setup Then
            Coordinates = New CoordinateSystem(New Size(OutputBox.Width - OutputBox.Padding.Horizontal, OutputBox.Height), New Size(OutputBox.Width / (TrackBar.Maximum - TrackBar.Minimum) / TrackBar.TickFrequency, OutputBox.Height / 2))
            RefreshImage()
        End If
    End Sub
End Class
