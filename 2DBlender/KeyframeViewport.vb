Public Class KeyframeViewport
    Public Coordinates As CoordinateSystem
    Public setup As Boolean = True

    Public Sub Initialise(FrameCount)
        TrackBar.Maximum = FrameCount
        Coordinates = New CoordinateSystem(New Size(OutputBox.Width - 26, OutputBox.Height), FrameCount - 1, 2)
        setup = False
    End Sub

    Public Sub RefreshImage()
        If Not setup Then
            Dim OutputImage As New Bitmap((OutputBox.Width - OutputBox.Padding.Horizontal), OutputBox.Height)
            Dim g As Graphics = Graphics.FromImage(OutputImage)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            Coordinates.DrawGrid(g)
            Try
                If Main.CurrentCamera.Highlighted Then
                    Main.CurrentCamera.DrawKeyframe(g)
                Else
                    Main.CurrentLayer.DrawKeyframes(g)
                End If
            Catch ex As NullReferenceException
                Main.CurrentLayer.DrawKeyframes(g)
            End Try
            OutputBox.Image = OutputImage
            OutputBox.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub TrackBar_Scroll(sender As Object, e As EventArgs) Handles TrackBar.Scroll
        If Not setup Then
            TriggerScroll()
        End If
    End Sub

    Public Sub TriggerScroll()
        Main.CurrentLayer.PushKeyframes(TrackBar.Value)
        Try
            Main.CurrentCamera.PushKeyframe(TrackBar.Value)
        Catch ex As NullReferenceException
        End Try
        Select Case Main.CurrentLayer.SelectedItemType
            Case DisplayObjects.Node
                Main.NodeProperties.RefreshNode(Main.CurrentLayer.SelectedItem)
            Case DisplayObjects.Arc
                Main.ArcProperties.RefreshArc(Main.CurrentLayer.SelectedItem)
            Case DisplayObjects.Fill
                Main.FillProperties.RefreshFill(Main.CurrentLayer.SelectedItem)
            Case DisplayObjects.Camera
                Main.CameraProperties.RefreshCam(Main.CurrentCamera)
        End Select
        Main.RefreshImage()
    End Sub

    Private Sub OutputBox_SizeChanged(sender As Object, e As EventArgs) Handles OutputBox.SizeChanged
        If Not setup Then
            Coordinates = New CoordinateSystem(New Size(OutputBox.Width - 26, OutputBox.Height), TrackBar.Maximum - 1, 2)
            RefreshImage()
        End If
    End Sub
End Class
