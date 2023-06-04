Public Class Main
    Public IO As TwoDBlenderFile 'Instanciated only to read and write to storage
    Public ViewportRectangle As Rectangle 'Stores the size and location of the viewport on the canvas
    Public Coordinates As CoordinateSystem 'The global coordinate system for the viewport
    Public Layers As LinkedList(Of Graph) 'Stores all layers of the image
    Private CurrentLayerIndex As UInteger 'Stores the index of the currently active layer, used when placing display objects onto viewport
    Private Setup As Boolean = True 'Stores a 1 while the viewport is still being setup to avoid events being triggered, set to 0 at the end of setup
    Private CurrentTool As Tools 'Stores the currently selected tool
    Private CTRLHeld As Boolean 'Stores a 1 if the Control key is held
    Private Move1 As PointF 'Stores the first value used for comparison to measure movement
    Private ViewportProperties As ViewportProperties 'Stores the varies properties viewports, only instanciated on need
    Public NodeProperties As VertexProperties
    Public ArcProperties As EdgeProperties
    Public FillProperties As FaceProperties
    Public CameraProperties As CameraProperties
    Public KeyframeViewer As KeyframeViewport 'Displays the active keyframe for a selected object
    Public CurrentCamera As Camera 'The current global camera, only 1 exists at any given time and transcends layers
    Public Property CurrentLayer As Graph 'Gets the currently selected layer based on CurrentLayerIndex
        Set(value As Graph)
            CurrentLayerIndex = value.Index
        End Set
        Get
            Return Layers(CurrentLayerIndex)
        End Get
    End Property
    Public Property CurrentFrame As UInteger 'Gets the current value of the KeyframeViewer's trackbar
        Set(value As UInteger)
            KeyframeViewer.TrackBar.Value = value
        End Set
        Get
            Return KeyframeViewer.TrackBar.Value
        End Get
    End Property
    Public Property CurrentZoom As Single 'Gets the current zoom of the viewport rectangle
        Set(value As Single)
            ViewportProperties.Zoom.Value = value * 100
        End Set
        Get
            Return ViewportProperties.Zoom.Value / 100
        End Get
    End Property
    Public ReadOnly Property CanvasSize As Size 'Gets the current size of the canvas from the coordinate system
        Get
            Return Coordinates.WorldSize
        End Get
    End Property

    Private Sub ClearProperties() 'Clears all properties pages other than the viewport properties
        With PropertiesControl.TabPages
            .RemoveByKey("Vertex")
            .RemoveByKey("Edge")
            .RemoveByKey("Face")
            .RemoveByKey("Camera")
        End With
    End Sub
    Private Sub SetupViewportProperties() 'Sets up the properties window specified by the identifer
        ViewportProperties = New ViewportProperties(New Rectangle(0, 0, OutputBox.Width, OutputBox.Height))
        PropertiesControl.TabPages.Add("Viewport", "Viewport Properties")
        PropertiesControl.TabPages.Item("Viewport").Controls.Add(ViewportProperties)
        ViewportProperties.Dock = DockStyle.Fill
        ViewportProperties.setup = False
    End Sub
    Private Sub SetupNodeProperties(SelectedNode As Node)
        ClearProperties()
        NodeProperties = New VertexProperties(SelectedNode, Coordinates.GridSize)
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
    Private Sub SetupCameraProperties(Camera As Camera)
        ClearProperties()
        CameraProperties = New CameraProperties(Camera, Coordinates.GridSize)
        PropertiesControl.TabPages.Add("Camera", Camera.Name & " Properties")
        PropertiesControl.TabPages.Item("Camera").Controls.Add(CameraProperties)
        CameraProperties.Dock = DockStyle.Fill
        CameraProperties.setup = False
    End Sub
    Private Sub SetupKeyframeViewport(FrameCount As UInteger)
        KeyframeViewer = New KeyframeViewport
        KeyframeSplitter.Panel2.Controls.Clear()
        KeyframeSplitter.Panel2.Controls.Add(KeyframeViewer)
        KeyframeViewer.Dock = DockStyle.Fill
        KeyframeViewer.Initialise(FrameCount)
        KeyframeViewer.setup = False
    End Sub
    Private Sub ClearAllProperties()
        Try
            PropertiesControl.TabPages.Clear()
            Layers.Clear()
            Outliner.Nodes.Clear()
        Catch
        End Try
    End Sub
    Public Sub SetupNewViewport(WorldSize As Size, GridBox As Size, FrameCount As UInteger) 'Creates a new project and prepares the viewport for its use
        ClearAllProperties()
        ViewportRectangle = New Rectangle(0, 0, OutputBox.Width, OutputBox.Height)
        Coordinates = New CoordinateSystem(WorldSize, GridBox)
        Layers = New LinkedList(Of Graph)
        Layers.AddLast(New Graph(Layers.Count))
        CurrentLayerIndex = 0
        AddLayer(Layers.Last.Value.Name, 0)
        CurrentTool = Tools.Null
        CTRLHeld = False
        SetupKeyframeViewport(FrameCount)
        SetupViewportProperties()
        Setup = False
        RefreshImage()
    End Sub
    Public Sub LoadViewport(FrameCount As UInteger, WorldSize As Size, Layers As Graph()) 'Loads an old project and the prepares the viewport to function with it
        ClearAllProperties()
        ViewportRectangle = New Rectangle(0, 0, OutputBox.Width, OutputBox.Height)
        Me.Layers = New LinkedList(Of Graph)
        For i = 0 To Layers.Count - 1
            Me.Layers.AddLast(Layers(i))
        Next
        CurrentLayerIndex = 0
        AddLayer(Me.Layers.Last.Value.Name, Me.Layers.Last.Value.Index)
        CurrentTool = Tools.Null
        CTRLHeld = False
        RefreshOutliner()
        SetupKeyframeViewport(FrameCount)
        SetupViewportProperties()
        Setup = False
        RefreshImage()
    End Sub
    Public Sub RefreshImage() 'used when an edit to the image has been made to draw the image onto the viewport
        If Not Setup Then
            Dim canvas As New Bitmap(CanvasSize.Width, CanvasSize.Height) 'A bitmap file that represents the actual canvas
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            Coordinates.DrawGrid(g) 'Draws the grid first so that it appears at the bottom
            Try
                CurrentCamera.Draw(g) 'Draws the camera second so that it appears above the grid but underneath other display objects
            Catch ex As NullReferenceException
            End Try
            For i = 0 To Layers.Count - 1
                If Layers(i).Visible Then
                    Layers(i).Draw(g) 'Draws each layer
                End If
            Next
            Dim output As New Bitmap(OutputBox.Width, OutputBox.Height) 'Creates a second image that is the size of the viewport to stop overflow or mishapen canvases
            Dim g2 As Graphics = Graphics.FromImage(output)
            g2.DrawImage(canvas, New Rectangle(0, 0, OutputBox.Width, OutputBox.Height), ViewportRectangle, GraphicsUnit.Pixel) 'Draws the canvas that fits into the viewport rectangle, stretching it to the size of the output box
            OutputBox.Image = output
            OutputBox.Focus() 'focus is to make sure the viewport can be clicked after being reset
            KeyframeViewer.RefreshImage()
        End If
    End Sub

    Private Sub Main_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged 'Triggered when the size of the viewport changes to make sure that images are not skewed
        If Not Setup Then
            ViewportRectangle.Size = New Size(OutputBox.Width, OutputBox.Height)
            ViewportProperties.ExternalRefresh(ViewportRectangle)
            RefreshImage()
        End If
    End Sub
    Private Sub KeyframeSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles KeyframeSplitter.SplitterMoved
        If Not Setup Then
            ViewportRectangle.Size = New Size(OutputBox.Width, OutputBox.Height)
            ViewportProperties.ExternalRefresh(ViewportRectangle)
            RefreshImage()
        End If
    End Sub
    Private Sub PropertiesSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles PropertiesSplitter.SplitterMoved
        If Not Setup Then
            ViewportRectangle.Size = New Size(OutputBox.Width, OutputBox.Height)
            ViewportProperties.ExternalRefresh(ViewportRectangle)
            RefreshImage()
        End If
    End Sub


    Private Sub CreateVertex_Click(sender As Object, e As EventArgs) Handles CreateVertex.Click
        CurrentTool = Tools.DrawVertex
    End Sub
    Private Sub MoveTool_Click(sender As Object, e As EventArgs) Handles MoveTool.Click
        CurrentTool = Tools.Move
    End Sub
    Private Sub ConnectNodes_Click(sender As Object, e As EventArgs) Handles ConnectNodes.Click
        If Not Setup Then
            CurrentLayer.AddArc(Color.Black)
            RefreshImage()
        End If
    End Sub
    Private Sub ConnectArcs_Click(sender As Object, e As EventArgs) Handles ConnectArcs.Click
        If Not Setup Then
            CurrentLayer.AddFill(Color.White)
            RefreshImage()
        End If
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
        If Not Setup Then
            Dim MouseLocation As TPoint
            MouseLocation = New TPoint(CSng((e.X / CurrentZoom) + ViewportRectangle.X), CSng((e.Y / CurrentZoom) + ViewportRectangle.Y)) 'Calculates the grid point where the mouse clicked
            With CurrentLayer
                Select Case CurrentTool
                    Case Tools.Selection 'runs if the select tool is the currently active tool
                        If Not CTRLHeld Then 'if control is held then keep currently highlighted items as highlighted, otherwise set all objects to unhighlighted
                            .DeselectAll()
                            Try
                                CurrentCamera.Highlighted = False
                            Catch ex As NullReferenceException
                            End Try
                        End If
                        If .SelectItem(MouseLocation) Then 'if an item is selected in the current layer then dont bother looking to see if it selects a camera, if it isnt then that is noted so that it can check the camera
                            ClearProperties()
                            Select Case .SelectedItemType 'if a display object from a graph is selected then the relavent properties panel should be setup
                                Case = DisplayObjects.Node
                                    SetupNodeProperties(.SelectedItem)
                                Case = DisplayObjects.Arc
                                    SetupArcProperties(.SelectedItem)
                                Case = DisplayObjects.Fill
                                    SetupFillProperties(.SelectedItem)
                            End Select
                        Else
                            Try
                                If CurrentCamera.SelectMe(MouseLocation.GridLocation) Then 'attempts to select the current camera, if successful then setup the relevant properties
                                    SetupCameraProperties(CurrentCamera)
                                End If
                            Catch ex As NullReferenceException 'a layer is guarenteed to exist however a camera might not exist
                            End Try
                        End If
                    Case Tools.DrawVertex
                        .DeselectAll()
                        .AddNode(MouseLocation.GridLocation) 'Adds a single vertex to the layer
                    Case Tools.Square
                        .DeselectAll()
                        CurrentLayer.AddRectangle(MouseLocation, New TSize(CUInt(6), CUInt(6))) 'Adds a rectangle to the layer
                    Case Tools.Triangle
                        .DeselectAll()
                        CurrentLayer.AddTriangle(MouseLocation, New TSize(CUInt(6), CUInt(6))) 'Adds a triangle to the layer
                    Case Tools.Camera
                        .DeselectAll()
                        CurrentCamera = New Camera(MouseLocation, New TSize(CSng(CanvasSize.Width / 10), CSng(CanvasSize.Height / 10))) 'Creates a new camera of a size relative to the size of the canvas
                End Select
            End With
            RefreshImage()
        End If
    End Sub
    Public Sub SelectItem(Index As UInteger, Type As DisplayObjects) 'Selects the specified item
        If Not Setup Then
            With CurrentLayer
                If Not CTRLHeld Then 'if control is held then keep currently highlighted items as highlighted, otherwise set all objects to unhighlighted
                    .DeselectAll()
                End If
                .SelectItem(Index, Type)
                ClearProperties()
                Select Case .SelectedItemType 'if a display object from a graph is selected then the relavent properties panel should be setup
                    Case = DisplayObjects.Node
                        SetupNodeProperties(.SelectedItem)
                    Case = DisplayObjects.Arc
                        SetupArcProperties(.SelectedItem)
                    Case = DisplayObjects.Fill
                        SetupFillProperties(.SelectedItem)
                End Select
            End With
        End If
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
    Private Sub OutputBox_MouseDown(sender As Object, e As MouseEventArgs) Handles OutputBox.MouseDown 'When the mouse is first clicked while the move tool is selected, the location of the mouse is saved
        If Not Setup Then
            If CurrentTool = Tools.Move Then
                Move1 = New PointF(e.X, e.Y)
            End If
        End If
    End Sub
    Private Sub OutputBox_MouseUp(sender As Object, e As MouseEventArgs) Handles OutputBox.MouseUp 'When the mouse button is released, the distance the mouse travelled since it was clicked is measured and all selected and highlighted items are moved by the same vector
        If Not Setup Then
            If CurrentTool = Tools.Move Then
                CurrentLayer.MoveNode(New PointF(e.X - Move1.X, e.Y - Move1.Y))
                Try
                    If CurrentCamera.Highlighted Then
                        CurrentCamera.CurrentValue = New TPoint(CurrentCamera.CurrentValue.WorldX + (e.X - Move1.X), CurrentCamera.CurrentValue.WorldY + (e.Y - Move1.Y))
                        CameraProperties.RefreshCam(CurrentCamera)
                    End If
                Catch ex As NullReferenceException
                End Try
                Move1 = Nothing
                RefreshImage()
            End If
        End If
    End Sub


    Private Sub NewProject_Click(sender As Object, e As EventArgs) Handles NewProject.Click 'Opens the new file window
        NewFile.Activate()
        NewFile.Show()
    End Sub
    Private Sub OpenProject_Click(sender As Object, e As EventArgs) Handles OpenProject.Click 'prompts the user with a file dialog and then opens the file they select
        OpenFileDialog.ShowDialog()
        If OpenFileDialog.FileName <> Nothing Then
            IO = New TwoDBlenderFile(OpenFileDialog.FileName)
            IO.Read()
        End If
    End Sub
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click 'saves the file to the previously selected file location
        IO.Write(Layers.ToArray, Coordinates, KeyframeViewer.TrackBar.Maximum)
    End Sub
    Private Sub SaveAs_Click(sender As Object, e As EventArgs) Handles SaveAs.Click 'changes the file location before saving
        SaveFileDialog.ShowDialog()
        IO = New TwoDBlenderFile(SaveFileDialog.FileName)
        IO.CreateFile()
        IO.Write(Layers.ToArray, Coordinates, KeyframeViewer.TrackBar.Maximum)
    End Sub


    Private Sub RenderImage_Click(sender As Object, e As EventArgs) Handles RenderImage.Click 'shows the render viewport and provides it the required data for producing a still image based on the current frame
        If Not Setup Then
            Try
                RenderViewport.Show()
                RenderViewport.SetupStill(Layers.ToArray, CurrentCamera)
            Catch ex As NullReferenceException
                MsgBox("Please add a camera", vbOKOnly, "Error!")
            Catch ex As ArithmeticException
                MsgBox("Data must be present within the layers", vbOKOnly, "Error!")
            End Try
        End If
    End Sub
    Private Sub RenderAnimation_Click(sender As Object, e As EventArgs) Handles RenderAnimation.Click 'shows the render viewport and provides it the required data for producing an animation
        If Not Setup Then
            Try
                KeyframeViewer.TrackBar.Value = KeyframeViewer.TrackBar.Minimum
                KeyframeViewer.TriggerScroll()
                RenderViewport.Show()
                RenderViewport.SetupAnim(Layers.ToArray, CurrentCamera, KeyframeViewer.TrackBar.Maximum)
            Catch ex As NullReferenceException
                MsgBox("Please add a camera", vbOKOnly, "Error!")
            Catch ex As ArithmeticException
                MsgBox("Data must be present within the layers", vbOKOnly, "Error!")
            End Try
        End If
    End Sub


    Private Sub CreateLayer_Click(sender As Object, e As EventArgs) Handles CreateLayer.Click 'Creates a new graph and adds it to the layers linked list
        If Not Setup Then
            Layers.AddLast(New Graph(Layers.Count))
            AddLayer(Layers.Last.Value.Name, Layers.Count - 1)
        End If
    End Sub
    Public Sub AddLayer(Name As String, Index As UInteger) 'Adds the representation of a layer to the outliner
        Outliner.Nodes.Add("Layer " & Index, Name)
    End Sub
    Public Sub AddDisplayObject(Name As String, Index As UInteger, ParentName As String, Type As DisplayObjects) 'Adds the representation of the specified display object to the outliner
        Select Case Type
            Case DisplayObjects.Node
                Outliner.Nodes.Item(ParentName).Nodes.Add("Vertices " & Index, Name)
            Case DisplayObjects.Arc
                Outliner.Nodes.Item(ParentName).Nodes.Add("Edges " & Index, Name)
            Case DisplayObjects.Fill
                Outliner.Nodes.Item(ParentName).Nodes.Add("Faces " & Index, Name)
        End Select
    End Sub
    Private Sub Outliner_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Outliner.AfterLabelEdit 'Edits the name of the outliner and pushes that edit to the graph
        If e.Node.Level = 0 Then 'if the node level is 0, we can assume it is a graph that has had its name changed
            For i = 0 To Layers.Count - 1 'steps through each graph until the index is the same as the one that has been changed
                If i = Mid(e.Node.Name, 6) Then
                    If e.Label = "" Then
                        e.CancelEdit = True
                    Else
                        Layers(i).Name = e.Label 'saves the new name to the data structure
                    End If
                End If
            Next
        Else 'if the node level is greater than 0 then a display object is selected
            If e.Node.Name.Contains("Vertices") Then 'check the name of the node in the outliner for the type of display object
                For i = 0 To Layers.Count - 1
                    If i = Mid(e.Node.Parent.Name, 6) Then
                        For j = 0 To Layers(i).Vertices.Count - 1 'steps through each item of that type in each layer until the index is the same as the one that has been changed
                            If j = Mid(e.Node.Name, 9) Then
                                If e.Label = "" Then
                                    e.CancelEdit = True
                                Else
                                    Layers(i).Vertices(j).Name = e.Label 'saves the name to the data structure
                                    NodeProperties.RefreshNode(Layers(i).Vertices(j)) 'updates the properties viewport of that object
                                End If
                            End If
                        Next
                    End If
                Next
            ElseIf e.Node.Name.Contains("Edges") Then
                For i = 0 To Layers.Count - 1
                    If i = Mid(e.Node.Parent.Name, 6) Then
                        For j = 0 To Layers(i).Edges.Count - 1 'steps through each item of that type in each layer until the index is the same as the one that has been changed
                            If j = Mid(e.Node.Name, 6) Then
                                If e.Label = "" Then
                                    e.CancelEdit = True
                                Else
                                    Layers(i).Edges(j).Name = e.Label
                                    ArcProperties.RefreshArc(Layers(i).Edges(j))
                                End If
                            End If
                        Next
                    End If
                Next
            ElseIf e.Node.Name.Contains("Faces") Then
                For i = 0 To Layers.Count - 1
                    If i = Mid(e.Node.Parent.Name, 6) Then
                        For j = 0 To Layers(i).Faces.Count - 1 'steps through each item of that type in each layer until the index is the same as the one that has been changed
                            If j = Mid(e.Node.Name, 6) Then
                                If e.Label = "" Then
                                    e.CancelEdit = True
                                Else
                                    Layers(i).Faces(j).Name = e.Label
                                    FillProperties.RefreshFill(Layers(i).Faces(j))
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub Outliner_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Outliner.AfterSelect 'selects the item in the viewport based on what is selected in the outliner
        If e.Node.Name.Contains("Vertices") Then 'check the name of the node in the outliner for the type of display object
            For i = 0 To Layers.Count - 1 'steps through the layers until the correct one is selected
                If i = Mid(e.Node.Parent.Name, 6) Then
                    SelectItem(Mid(e.Node.Name, 9), DisplayObjects.Node)
                End If
            Next
        ElseIf e.Node.Name.Contains("Edges") Then
            For i = 0 To Layers.Count - 1
                If i = Mid(e.Node.Parent.Name, 6) Then
                    SelectItem(Mid(e.Node.Name, 6), DisplayObjects.Arc)
                End If
            Next
        ElseIf e.Node.Name.Contains("Faces") Then
            For i = 0 To Layers.Count - 1
                If i = Mid(e.Node.Parent.Name, 6) Then
                    SelectItem(Mid(e.Node.Name, 6), DisplayObjects.Fill)
                End If
            Next
        ElseIf e.Node.Name.Contains("Layer") Then
            CurrentLayerIndex = CUInt(Mid(e.Node.Name, 6))
        End If
        RefreshImage()
    End Sub
    Public Sub RefreshOutliner() 'force refresh of outliner 
        Outliner.Nodes.Clear() 'resets outliner
        For i = 0 To Layers.Count - 1 'creates a new node based on the display objects available
            AddLayer(Layers(i).Name, i)
            For j = 0 To Layers(i).Vertices.Count - 1
                AddDisplayObject(Layers(i).Vertices(j).Name, j, Layers(i).Name, DisplayObjects.Node)
            Next
            For j = 0 To Layers(i).Edges.Count - 1
                AddDisplayObject(Layers(i).Edges(j).Name, j, Layers(i).Name, DisplayObjects.Arc)
            Next
            For j = 0 To Layers(i).Faces.Count - 1
                AddDisplayObject(Layers(i).Faces(j).Name, j, Layers(i).Name, DisplayObjects.Fill)
            Next
        Next
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click 'deletes any selected items
        If Not Setup Then
            Try
                If CurrentCamera.Highlighted Then 'if the camera is selected then delete that camera, otherwise, delete the selected items of the selected layer
                    CurrentCamera = Nothing
                Else
                    CurrentLayer.DeleteSelectedItem()
                End If
            Catch ex As NullReferenceException
                CurrentLayer.DeleteSelectedItem()
            End Try
            ClearProperties() 'refreshes all items
            RefreshImage()
            RefreshOutliner()
        End If
    End Sub

    Private Sub ShowLayer_Click(sender As Object, e As EventArgs) Handles ShowLayer.Click
        If Not Setup Then
            CurrentLayer.Visible = True
            RefreshImage()
            ClearProperties()
        End If
    End Sub
    Private Sub HideLayer_Click(sender As Object, e As EventArgs) Handles HideLayer.Click
        If Not Setup Then
            CurrentLayer.Visible = False
            RefreshImage()
            ClearProperties()
        End If
    End Sub
    Private Sub DeleteLayer_Click(sender As Object, e As EventArgs) Handles DeleteLayer.Click
        If Not Setup Then
            If Not CurrentLayerIndex = 0 Then 'layer 0 cannot be deleted
                Layers.Remove(CurrentLayer)
                CurrentLayerIndex = 0
                CurrentLayerIndex = 0
                RefreshOutliner()
                RefreshImage()
                ClearProperties()
            End If
        End If
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