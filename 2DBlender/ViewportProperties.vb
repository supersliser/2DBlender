Public Class ViewportProperties
    Private OutputViewportRectangle As Rectangle
    Private DefaultCanvasSize As Size
    Public setup As Boolean = True
    Public Sub New(ViewportRectangle As Rectangle)
        InitializeComponent()
        DefaultCanvasSize = ViewportRectangle.Size
        OutputViewportRectangle = ViewportRectangle
        Zoom.Value = 100
    End Sub

    Private Sub ExportChanges()
        Main.ViewportRectangle = OutputViewportRectangle
        Main.RefreshImage()
    End Sub

    Private Sub Zoom_ValueChanged(sender As Object, e As EventArgs) Handles Zoom.ValueChanged
        If setup = False Then
            OutputViewportRectangle.Width = DefaultCanvasSize.Width / (Zoom.Value / 100)
            OutputViewportRectangle.Height = DefaultCanvasSize.Height / (Zoom.Value / 100)
            ExportChanges()
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles X.ValueChanged
        If setup = False Then
            OutputViewportRectangle.X = New TPoint(New Point(X.Value, Y.Value)).WorldX
            ExportChanges()
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles Y.ValueChanged
        If setup = False Then
            OutputViewportRectangle.Y = New TPoint(New Point(X.Value, Y.Value)).WorldY
            ExportChanges()
        End If
    End Sub
End Class
