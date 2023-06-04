Public Class ViewportProperties
    Private OutputViewportRectangle As Rectangle
    Private DefaultCanvasSize As Size
    Public setup As Boolean = True
    Public Sub New(ViewportRectangle As Rectangle)
        InitializeComponent()
        DefaultCanvasSize = ViewportRectangle.Size
        OutputViewportRectangle = ViewportRectangle
        X.Maximum = Main.Coordinates.GridSize.Width - 1
        Y.Maximum = Main.Coordinates.GridSize.Height - 1
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

    Public Sub ExternalRefresh(ViewportRectangle As Rectangle)
        OutputViewportRectangle = ViewportRectangle
        DefaultCanvasSize = ViewportRectangle.Size
    End Sub
    Public Sub ExternalRefresh(ViewportRectangle As Rectangle, Zoom As UInteger)
        OutputViewportRectangle = ViewportRectangle
        DefaultCanvasSize = ViewportRectangle.Size
        Me.Zoom.Value = Zoom
    End Sub
End Class
