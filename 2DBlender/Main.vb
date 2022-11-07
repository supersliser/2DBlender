Public Class Main
    Public IO As TwoDBlenderFile
    Public ViewportRectangle As Rectangle
    Public Coordinates As CoordinateSystem
    Public CanvasSize As Size
    Public Layers As LinkedList(Of Graph)
    Private CurrentLayerIndex As UInteger
    Private Setup As Boolean = True
    Private CurrentTool As Tools
    Private CTRLHeld As Boolean
    Private Move1 As TPoint
    Private ViewportProperties As ViewportProperties
    Public NodeProperties As VertexProperties
    Public ArcProperties As EdgeProperties
    Public FillProperties As FaceProperties
    Public KeyframeViewer As KeyframeViewport
    Public CurrentCamera As Camera
    Public Property CurrentLayer As Graph
        Set(value As Graph)
            CurrentLayerIndex = value.Index
        End Set
        Get
            Return Layers(CurrentLayerIndex)
        End Get
    End Property
    Public Property CurrentFrame As UInteger
        Set(value As UInteger)
            KeyframeViewer.TrackBar.Value = value
        End Set
        Get
            Return KeyframeViewer.TrackBar.Value
        End Get
    End Property
    Public Property CurrentZoom As Single
        Set(value As Single)
            ViewportProperties.Zoom.Value = value * 100
        End Set
        Get
            Return ViewportProperties.Zoom.Value / 100
        End Get
    End Property

    Private Sub ClearProperties()
        With PropertiesControl.TabPages
            .RemoveByKey("Vertex")
            .RemoveByKey("Edge")
            .RemoveByKey("Face")
        End With
    End Sub
    Private Sub SetupViewportProperties()
        ViewportProperties = New ViewportProperties(New Rectangle(0, 0, OutputBox.Width, OutputBox.Height))
        PropertiesControl.TabPages.Add("Viewport", "Viewport Properties")
        PropertiesControl.TabPages.Item("Viewport").Controls.Add(ViewportProperties)
        ViewportProperties.Dock = DockStyle.Fill
        ViewportProperties.setup = False
    End Sub
    Private Sub SetupNodeProperties(SelectedNode As Node)
        ClearProperties()
        NodeProperties = New VertexProperties(SelectedNode)
        PropertiesControl.TabPages.Add("Vertex", SelectedNode.Name & " Properties")
        PropertiesControl.TabPages.Item("Vertex").Controls.Add(NodeProperties)
        NodeProperties.Dock = DockStyle.Fill
        NodeProperties.setup = False
    End Sub
    Private Sub SetupArcProperties(SelectedArc As Arc)
        ClearProperties()
        ArcProperties = New EdgeProperties(SelectedArc)
        PropertiesControl.TabPages.Add("Edge", SelectedArc.Name & " Properties")
        PropertiesControl.TabPages.Item("Edge").Controls.Add(ArcProperties)
        ArcProperties.Dock = DockStyle.Fill
        ArcProperties.Setup = False
    End Sub
    Private Sub SetupFillProperties(SelectedFill As Fill)
        ClearProperties()
        FillProperties = New FaceProperties(SelectedFill)
        PropertiesControl.TabPages.Add("Face", SelectedFill.Name & " Properties")
        PropertiesControl.TabPages.Item("Face").Controls.Add(FillProperties)
        FillProperties.Dock = DockStyle.Fill
        FillProperties.Setup = False
    End Sub
    Private Sub SetupKeyframeViewport(FrameCount As UInteger)
        KeyframeViewer = New KeyframeViewport
        KeyframeSplitter.Panel2.Controls.Add(KeyframeViewer)
        KeyframeViewer.Dock = DockStyle.Fill
        KeyframeViewer.Initialise(FrameCount)
        KeyframeViewer.setup = False
    End Sub
    Public Sub SetupViewport(WorldSize As Size, GridBox As Size, FrameCount As UInteger)
        ViewportRectangle = New Rectangle(0, 0, OutputBox.Width, OutputBox.Height)
        Coordinates = New CoordinateSystem(WorldSize, GridBox)
        CanvasSize = WorldSize
        Layers = New LinkedList(Of Graph)
        Layers.AddLast(New Graph)
        CurrentLayerIndex = 0
        CurrentTool = Tools.Null
        CTRLHeld = False
        CurrentLayerIndex = 0
        SetupKeyframeViewport(FrameCount)
        SetupViewportProperties()
        Setup = False
        RefreshImage()
        KeyframeViewer.RefreshImage()
    End Sub
    Public Sub RefreshImage()
        If Not Setup Then
            Dim canvas As New Bitmap(CanvasSize.Width, CanvasSize.Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            Coordinates.DrawGrid(g)
            Try
                CurrentCamera.Draw(g)
            Catch ex As NullReferenceException
            End Try
            For i = 0 To Layers.Count - 1
                Layers(i).Draw(g)
            Next
            Dim output As New Bitmap(OutputBox.Width, OutputBox.Height)
            Dim g2 As Graphics = Graphics.FromImage(output)
            g2.DrawImage(canvas, New Rectangle(0, 0, OutputBox.Width, OutputBox.Height), ViewportRectangle, GraphicsUnit.Pixel)
            OutputBox.Image = output
            OutputBox.Focus()
            KeyframeViewer.RefreshImage()
        End If
    End Sub

    Private Sub CreateVertex_Click(sender As Object, e As EventArgs) Handles CreateVertex.Click
        CurrentTool = Tools.DrawVertex
    End Sub
    Private Sub ConnectNodes_Click(sender As Object, e As EventArgs) Handles ConnectNodes.Click
        CurrentLayer.AddArc(Color.Black)
        RefreshImage()
    End Sub
    Private Sub ConnectArcs_Click(sender As Object, e As EventArgs) Handles ConnectArcs.Click
        CurrentLayer.AddFill(Color.White)
        RefreshImage()
    End Sub
    Private Sub CreateCamera_Click(sender As Object, e As EventArgs) Handles CreateCamera.Click
        CurrentTool = Tools.Camera
    End Sub
    Private Sub SelectTool_Click(sender As Object, e As EventArgs) Handles SelectTool.Click
        CurrentTool = Tools.Selection
    End Sub
    Private Sub CreatePrimitveTriangle_Click(sender As Object, e As EventArgs) Handles CreatePrimitveTriangle.Click
        CurrentTool = Tools.Triangle
    End Sub
    Private Sub CreatePrimitiveSquare_Click(sender As Object, e As EventArgs) Handles CreatePrimitiveSquare.Click
        CurrentTool = Tools.Square
    End Sub
    Private Sub OutputBox_MouseClick(sender As Object, e As MouseEventArgs) Handles OutputBox.MouseClick
        Dim MouseLocation As PointF
        MouseLocation.X = (e.X / CurrentZoom) + ViewportRectangle.X
        MouseLocation.Y = (e.Y / CurrentZoom) + ViewportRectangle.Y
        With CurrentLayer
            Select Case CurrentTool
                Case Tools.Selection
                    If Not CTRLHeld Then
                        .DeselectAll()
                    End If
                    .SelectItem(New TPoint(MouseLocation))
                    ClearProperties()
                    Select Case .SelectedItemType
                        Case = DisplayObjects.Node
                            SetupNodeProperties(.SelectedItem)
                        Case = DisplayObjects.Arc
                            SetupArcProperties(.SelectedItem)
                        Case = DisplayObjects.Fill
                            SetupFillProperties(.SelectedItem)
                    End Select
                Case Tools.DrawVertex
                    .DeselectAll()
                    .AddNode(New TPoint(MouseLocation).GridLocation)
                Case Tools.Square
                    .DeselectAll()
                    CurrentLayer.AddRectangle(New TPoint(MouseLocation), New TSize(CUInt(6), CUInt(6)))
                Case Tools.Triangle
                    .DeselectAll()
                    CurrentLayer.AddTriangle(New TPoint(MouseLocation), New TSize(CUInt(6), CUInt(6)))
                Case Tools.Camera
                    .DeselectAll()
                    CurrentCamera = New Camera(New TPoint(MouseLocation), New TSize(CSng(CanvasSize.Width / 10), CSng(CanvasSize.Height / 10)))
            End Select
        End With
        RefreshImage()
    End Sub
    Private Sub OutputBox_KeyDown(sender As Object, e As KeyEventArgs) Handles OutputBox.KeyDown
        Select Case e.KeyCode
            Case Keys.ControlKey
                CTRLHeld = True
        End Select
    End Sub
    Private Sub OutputBox_KeyUp(sender As Object, e As KeyEventArgs) Handles OutputBox.KeyUp
        Select Case e.KeyCode
            Case Keys.ControlKey
                CTRLHeld = False
        End Select
    End Sub
    Private Sub OutputBox_MouseDown(sender As Object, e As MouseEventArgs) Handles OutputBox.MouseDown
        If CurrentTool = Tools.Move Then
            Move1 = New TPoint(New PointF(e.X, e.Y))
        End If
    End Sub
    Private Sub OutputBox_MouseUp(sender As Object, e As MouseEventArgs) Handles OutputBox.MouseUp
        If CurrentTool = Tools.Move Then
            Dim Move2 As New TPoint(New PointF(e.X - Move1.WorldX, e.Y - Move1.WorldY))
            Move1 = Nothing
            CurrentLayer.MoveNode(Move2)
        End If
    End Sub


    Private Sub NewProject_Click(sender As Object, e As EventArgs) Handles NewProject.Click
        NewFile.Activate()
        NewFile.Show()
    End Sub
    Private Sub OpenProject_Click(sender As Object, e As EventArgs) Handles OpenProject.Click
        OpenFileDialog.ShowDialog()
        If OpenFileDialog.FileName <> Nothing Then
            IO = New TwoDBlenderFile(OpenFileDialog.FileName)
            IO.Read(Layers.ToArray, Coordinates)
        End If
    End Sub
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        IO.Write(Layers.ToArray, Coordinates)
    End Sub
    Private Sub SaveAs_Click(sender As Object, e As EventArgs) Handles SaveAs.Click
        SaveFileDialog.ShowDialog()
        IO = New TwoDBlenderFile(SaveFileDialog.FileName)
        IO.CreateFile()
        IO.Write(Layers.ToArray, Coordinates)
    End Sub


    Private Sub RenderImage_Click(sender As Object, e As EventArgs) Handles RenderImage.Click
        RenderViewport.Show()
    End Sub
End Class
Public Enum Tools
    Null
    Selection
    DrawVertex
    Move
    Square
    Triangle
    Camera
End Enum
