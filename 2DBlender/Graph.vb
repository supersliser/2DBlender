Public Class Graph
    Public Name As String
    Public Visible As Boolean
    Public SelectedItemIndex As Integer 'The index of the currently selected item
    Public SelectedItemType As DisplayObjects 'The type of object the currently selected item is
    Public Vertices As LinkedList(Of Node) 'A list of all active vertices
    Public Edges As LinkedList(Of Arc) 'A list of all active edges
    Public Faces As LinkedList(Of Fill) 'A list of all active faces
    Public ReadOnly Property NodeCount As UInteger
        Get
            Return Vertices.Count - 1
        End Get
    End Property
    Public ReadOnly Property ArcCount As UInteger
        Get
            Return Edges.Count - 1
        End Get
    End Property
    Public ReadOnly Property FillCount As UInteger
        Get
            Return Faces.Count - 1
        End Get
    End Property
    Public ReadOnly Property HighlightedNodeCount As UInteger
        Get
            Dim output As UInteger
            For i = 0 To Vertices.Count - 1
                If Vertices(i).Highlighted Then
                    output += 1
                End If
            Next
            Return output
        End Get
    End Property
    Public ReadOnly Property HighlightedArcCount As UInteger
        Get
            Dim output As UInteger
            For i = 0 To Edges.Count - 1
                If Edges(i).Highlighted Then
                    output += 1
                End If
            Next
            Return output
        End Get
    End Property
    Public ReadOnly Property HighlightedFillCount As UInteger
        Get
            Dim output As UInteger
            For i = 0 To Faces.Count - 1
                If Faces(i).Highlighted Then
                    output += 1
                End If
            Next
            Return output
        End Get
    End Property
    Public ReadOnly Property HighlightedCount As UInteger
        Get
            Return HighlightedNodeCount + HighlightedArcCount + HighlightedFillCount
        End Get
    End Property
    Public ReadOnly Property Index As UInteger
        Get
            For i = 0 To Main.Layers.Count
                If Main.Layers.ElementAt(i).Equals(Me) Then 'steps through each layer and checks whether they are the same as this one, if true then the number of steps is the index
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public Property SelectedItem As Object
        Set(value As Object) 'checks the type of the selected item and sets the value of selected item index to that
            If value.GetType Is GetType(Node) Then
                SelectedItemType = DisplayObjects.Node
                SelectedItemIndex = value.Index
                Vertices.ElementAt(SelectedItemIndex).Highlighted = True
            ElseIf value.GetType Is GetType(Arc) Then
                SelectedItemType = DisplayObjects.Arc
                SelectedItemIndex = value.Index
                Edges.ElementAt(SelectedItemIndex).Highlighted = True
            ElseIf value.GetType Is GetType(Fill) Then
                SelectedItemType = DisplayObjects.Fill
                SelectedItemIndex = value.Index
                Faces.ElementAt(SelectedItemIndex).Highlighted = True
            End If
        End Set
        Get
            Select Case SelectedItemType 'gets the item from the correct list based on the type
                Case = DisplayObjects.Node
                    Return Vertices(SelectedItemIndex)
                Case = DisplayObjects.Arc
                    Return Edges(SelectedItemIndex)
                Case = DisplayObjects.Fill
                    Return Faces(SelectedItemIndex)
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property OutlinerName As String
        Get
            Return "Layer " & Index
        End Get
    End Property


    Public Sub New(Index As UInteger)
        Name = "Layer " & Index 'default name is "Layer [index + 1]
        Visible = True
        SelectedItemIndex = -1
        SelectedItemType = DisplayObjects.Null
        Vertices = New LinkedList(Of Node)
        Edges = New LinkedList(Of Arc)
        Faces = New LinkedList(Of Fill)
    End Sub

    Public Sub Draw(g As Graphics) 'Draws all display objects
        For i = 0 To Faces.Count - 1
            Faces(i).Draw(g)
        Next
        For i = 0 To Edges.Count - 1
            Edges(i).Draw(g)
        Next
        For i = 0 To Vertices.Count - 1
            Vertices(i).Draw(g)
        Next
    End Sub

    Public Sub AddTriangle(Location As TPoint, Size As TSize) 'places the required nodes, arcs and fills to make a triangle shape
        AddNode(Location.GridLocation) '3 'places nodes first
        AddNode(New Point(Location.GridX + (Size.GridWidth / 2), Location.GridY + Size.GridHeight)) '2
        AddNode(New Point(Location.GridX - (Size.GridWidth / 2), Location.GridY + Size.GridHeight)) '1

        DeselectAll()
        Vertices(Vertices.Count - 3).Highlighted = True 'connects nodes with arcs
        SelectedItem = Vertices(Vertices.Count - 2)
        AddArc(Color.Black)

        DeselectAll()
        Vertices(Vertices.Count - 2).Highlighted = True
        SelectedItem = Vertices(Vertices.Count - 1)
        AddArc(Color.Black)

        DeselectAll()
        Vertices(Vertices.Count - 1).Highlighted = True
        SelectedItem = Vertices(Vertices.Count - 3)
        AddArc(Color.Black)

        DeselectAll()
        Edges(Edges.Count - 3).Highlighted = True 'connects arcs with fill
        Edges(Edges.Count - 2).Highlighted = True
        SelectedItem = Edges(Edges.Count - 1)
        AddFill(Color.White)
        DeselectAll()
    End Sub
    Public Sub AddRectangle(Location As TPoint, Size As TSize) 'places the required nodes, arcs and fills to make a rectangle shape
        'places nodes first
        If Location.WorldX >= Main.CanvasSize.Width Then '4
            If Location.WorldY >= Main.CanvasSize.Height Then
                AddNode(New Point(Location.GridX - 1, Location.GridY - 1)) 'if node 4 is clicked on the bottom right hand corner of the canvas
            Else
                AddNode(New Point(Location.GridX - 1, Location.GridY)) 'if node 4 is clicked on the bottom of the canvas
            End If
        Else
            If Location.WorldY >= Main.CanvasSize.Height Then
                AddNode(New Point(Location.GridX, Location.GridY - 1)) 'if node 4 is clicked on the right of the canvas
            Else
                AddNode(Location.GridLocation) 'if node 4 is placed on a valid place on the canvas
            End If
        End If
        If Location.WorldY >= Main.CanvasSize.Height Then '3
            AddNode(New Point(Location.GridX + Size.GridWidth, Location.GridY - 1)) 'if node 3 is placed on the bottom of the canvas
        Else
            AddNode(New Point(Location.GridX + Size.GridWidth, Location.GridY)) 'if node 3 is placed on a valid place on the canvas
        End If
        If Location.WorldX >= Main.CanvasSize.Width Then '2
            AddNode(New Point(Location.GridX - 1, Location.GridY + Size.GridHeight)) 'if node 2 is clicked on the right of the canvas
        Else
            AddNode(New Point(Location.GridX, Location.GridY + Size.GridHeight)) 'if node 2 is placed on a valid place on the canvas
        End If
        AddNode(Location.GridLocation + Size.GridSize) '1

        DeselectAll()
        Vertices(Vertices.Count - 4).Highlighted = True 'connect nodes with arcs
        SelectedItem = Vertices(Vertices.Count - 3)
        AddArc(Color.Black)

        DeselectAll()
        Vertices(Vertices.Count - 3).Highlighted = True
        SelectedItem = Vertices(Vertices.Count - 1)
        AddArc(Color.Black)

        DeselectAll()
        Vertices(Vertices.Count - 1).Highlighted = True
        SelectedItem = Vertices(Vertices.Count - 2)
        AddArc(Color.Black)

        DeselectAll()
        Vertices(Vertices.Count - 2).Highlighted = True
        SelectedItem = Vertices(Vertices.Count - 4)
        AddArc(Color.Black)

        DeselectAll()
        Edges(Edges.Count - 4).Highlighted = True 'connect arcs with fill
        Edges(Edges.Count - 3).Highlighted = True
        Edges(Edges.Count - 2).Highlighted = True
        SelectedItem = Edges(Edges.Count - 1)
        AddFill(Color.White)
        DeselectAll()
    End Sub

    Public Sub AddNode(GridPoint As Point) 'adds a default node at the specified location to the list
        Dim failed As Boolean
        For i = 0 To Vertices.Count - 1
            If Vertices(i).CurrentValue.GridLocation = GridPoint Then 'checks to see if another node is already on this point, if it is then the node is not successfully drawn
                MsgBox("Cannot have 2 Nodes in the same location on the same layer, please use different layers or place the node somewhere else", vbOKOnly, "Warning!")
                failed = True
            End If
        Next
        If Not failed Then
            Vertices.AddLast(New Node(GridPoint, Vertices.Count))
            Main.AddDisplayObject(Vertices.Last.Value.Name, Vertices.Last.Value.Index, OutlinerName, DisplayObjects.Node)
        End If
    End Sub
    Public Sub AddNode(Node As Node) 'adds a node to the list
        Dim failed As Boolean
        For i = 0 To Vertices.Count - 1
            If Vertices(i).CurrentValue.GridLocation = Node.CurrentValue.GridLocation Then
                MsgBox("Cannot have 2 Nodes in the same location on the same layer, please use different layers or place the node somewhere else", vbOKOnly, "Warning!")
                failed = True
            End If
        Next
        If Not failed Then
            Vertices.AddLast(Node)
            Main.AddDisplayObject(Vertices.Last.Value.Name, Vertices.Last.Value.Index, Name, DisplayObjects.Node)
        End If
    End Sub
    Public Sub EditNode(OldNode As Node, NewNode As Node)
        Vertices.ToArray(OldNode.Index) = NewNode 'replaces an old node with a new node, index is dynamic so only way to achieve this
    End Sub
    Public Sub MoveNode(WorldMoveAmount As PointF) 'increases the location of all highlighted nodes by a given amount
        For i = 0 To Vertices.Count - 1
            If Vertices(i).Highlighted Then
                Vertices(i).CurrentValue = New TPoint(Vertices(i).CurrentValue.WorldX + WorldMoveAmount.X, Vertices(i).CurrentValue.WorldY + WorldMoveAmount.Y)
                Main.NodeProperties.RefreshNode(Vertices(i))
            End If
        Next
    End Sub
    Public Sub DeleteNode(Index As UInteger) 'deletes the node and any children arcs
        For i = 0 To Edges.Count - 1
            If Index < Edges(i).ParentIndex(0) Then
                Dim temp As UInteger = Edges(i).ParentIndex(0)
                Edges(i).ParentIndex.RemoveFirst()
                Edges(i).ParentIndex.AddFirst(temp - 1)
            End If
            If Index < Edges(i).ParentIndex(1) Then
                Dim temp As UInteger = Edges(i).ParentIndex(1)
                Edges(i).ParentIndex.RemoveLast()
                Edges(i).ParentIndex.AddLast(temp - 1)
            End If
        Next
        Vertices.Remove(Vertices(Index))
    End Sub

    Public Sub AddArc(Colour As Color) 'adds a default arc between the selected node and another highlighted node
        Dim added As Boolean
        If HighlightedNodeCount = 2 Then
            For i = 0 To Vertices.Count - 1 'steps though each node
                If Vertices(i).Highlighted Then 'checks if the node is highlighted
                    If i <> SelectedItemIndex Then 'checks it isnt also the selected node
                        If SelectedItemIndex <> -1 Then 'checks a node is selected
                            If Not added Then
                                Dim output(1) As UInteger
                                output(0) = i
                                output(1) = SelectedItemIndex
                                Edges.AddLast(New Arc(Colour, Edges.Count, output))
                                Main.AddDisplayObject(Edges.Last.Value.Name, Edges.Last.Value.Index, OutlinerName, DisplayObjects.Arc)
                                added = True
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub AddArc(Arc As Arc) 'adds a predefined arc to the graph
        Edges.AddLast(Arc)
        Main.AddDisplayObject(Edges.Last.Value.Name, Edges.Last.Value.Index, Name, DisplayObjects.Arc)
    End Sub
    Public Sub EditArc(Newarc As Arc, Oldarc As Arc) 'replaces an old arc with a new arc
        Edges.ToArray(Oldarc.Index) = Newarc
    End Sub
    Public Sub DeleteArc(Index As UInteger) 'deletes an arc and any associated faces
        For i = 0 To Faces.Count - 1
            Dim temp() As UInteger = Faces(i).ParentIndex.ToArray
            For j = 0 To temp.Count - 1
                If temp(j) > Index Then
                    temp(j) -= 1
                End If
            Next
            Faces(i).ParentIndex.Clear()
            For j = 0 To temp.Count - 1
                Faces(i).ParentIndex.AddLast(temp(j))
            Next
        Next
        Edges.Remove(Edges(Index))
    End Sub

    Public Sub AddFill(Colour As Color) 'adds a default face beteen multiple edges
        Dim arcs As New List(Of UInteger)
        If HighlightedArcCount > 2 Then
            If Not SelectedItemIndex = -1 Then
                For i = 0 To Edges.Count - 1 'steps through each edge
                    If Edges(i).Highlighted Then 'checks if it is highlighted
                        If i <> SelectedItemIndex Then 'checks it is not the selected item
                            arcs.Add(i) 'adds the given index to the list of parent arcs
                        End If
                    End If
                Next
                arcs.Add(SelectedItem.index) 'adds the selected item to the list of parent arcs
                Faces.AddLast(New Fill(Colour, Faces.Count, arcs.ToArray))
                Main.AddDisplayObject(Faces.Last.Value.Name, Faces.Last.Value.Index, OutlinerName, DisplayObjects.Fill)
            End If
        End If
    End Sub
    Public Sub AddFill(Fill As Fill) 'adds a predefined fill to the graph
        Faces.AddLast(Fill)
        Main.AddDisplayObject(Faces.Last.Value.Name, Faces.Last.Value.Index, Name, DisplayObjects.Fill)
    End Sub
    Public Sub EditFill(OldFill As Fill, NewFill As Fill) 'replaces an old fill with a new fill
        Faces.ToArray(OldFill.Index) = NewFill
    End Sub
    Public Sub DeleteFill(Index As UInteger)
        Faces.Remove(Faces(Index))
    End Sub

    Public Sub DeselectAll() 'sets all highlighted values to false and clears selected item
        For i = 0 To Vertices.Count - 1
            Vertices(i).Highlighted = False
        Next
        For i = 0 To Edges.Count - 1
            Edges(i).Highlighted = False
        Next
        For i = 0 To Faces.Count - 1
            Faces(i).Highlighted = False
        Next
        SelectedItemIndex = -1
        SelectedItemType = DisplayObjects.Null
    End Sub
    Public Function SelectItem(Location As TPoint) 'checks items to be selected
        Dim success As Boolean
        If SelectedItemIndex <> -1 Then
            SelectedItem.Highlighted = True
        End If
        For i = 0 To Vertices.Count - 1 'first checks nodes
            If Vertices(i).CurrentValue.GridLocation = Location.GridLocation Then
                Vertices(i).Highlighted = True
                SelectedItemType = DisplayObjects.Node
                SelectedItemIndex = i
                success = True
            End If
        Next
        If Not success Then
            For i = 0 To Edges.Count - 1 'then checks edges
                If Edges(i).IsOnPoint(Location.WorldLocation) Then
                    success = True
                    Edges(i).Highlighted = True
                    SelectedItemType = DisplayObjects.Arc
                    SelectedItemIndex = i
                End If
            Next
        End If
        If Not success Then
            For i = 0 To Faces.Count - 1 'then checks faces
                If Faces(i).IsOnPoint(Location.WorldLocation) Then
                    success = True
                    Faces(i).Highlighted = True
                    SelectedItemType = DisplayObjects.Fill
                    SelectedItemIndex = i
                End If
            Next
        End If
        If Not success Then 'if nothing has been selected then nothing is selected
            SelectedItemIndex = -1
            SelectedItemType = DisplayObjects.Null
        End If
        Return success
    End Function
    Public Sub SelectItem(Index As UInteger, Type As DisplayObjects) 'Selects and highlights given item
        Select Case Type
            Case DisplayObjects.Node
                Vertices(Index).Highlighted = True
                SelectedItemType = DisplayObjects.Node
                SelectedItemIndex = Index
            Case DisplayObjects.Arc
                Edges(Index).Highlighted = True
                SelectedItemType = DisplayObjects.Arc
                SelectedItemIndex = Index
            Case DisplayObjects.Fill
                Faces(Index).Highlighted = True
                SelectedItemType = DisplayObjects.Fill
                SelectedItemIndex = Index
        End Select
    End Sub
    Public Sub DeleteSelectedItem() 'deletes the selected item and any assoicated items
        Select Case SelectedItemType
            Case DisplayObjects.Node
                Dim deletedarcs As New List(Of UInteger)
                Dim deletedfills As New List(Of UInteger)
                For i = 0 To Edges.Count - 1
                    If Edges(i).ParentIndex.Contains(SelectedItemIndex) Then
                        deletedarcs.Add(i)
                        For j = 0 To Faces.Count - 1
                            If Faces(j).ParentIndex.Contains(i) Then
                                If Faces(j).ParentIndex.Count <= 3 Then
                                    If Not deletedfills.Contains(j) Then
                                        deletedfills.Add(j)
                                    End If
                                Else
                                    Faces(j).ParentIndex.Remove(i)
                                End If
                            End If
                        Next
                    End If
                Next
                For i = 0 To deletedarcs.Count - 1
                    DeleteArc(deletedarcs(i))
                Next
                For i = 0 To deletedfills.Count - 1
                    DeleteFill(deletedfills(i))
                Next
                DeleteNode(SelectedItemIndex)
            Case DisplayObjects.Arc
                Dim deletedfills As New List(Of UInteger)
                For i = 0 To Faces.Count - 1
                    If Faces(i).ParentIndex.Contains(SelectedItemIndex) Then
                        If Faces(i).ParentIndex.Count <= 3 Then
                            deletedfills.Add(i)
                        Else
                            Faces(i).ParentIndex.Remove(SelectedItemIndex)
                        End If
                    End If
                Next
                For i = 0 To deletedfills.Count - 1
                    DeleteFill(deletedfills(i))
                Next
                DeleteArc(SelectedItemIndex)
            Case DisplayObjects.Fill
                DeleteFill(SelectedItemIndex)
        End Select
        SelectedItemIndex = -1
        SelectedItemType = DisplayObjects.Null
    End Sub

    Public Sub AddKeyframe(Input As Object) 'interacts with the selected item
        If SelectedItemIndex <> -1 Then
            SelectedItem.AddKeyframe(Input)
        End If
    End Sub
    Public Function GetKeyframe(Frame As UInteger) As Object
        Return SelectedItem.GetKeyframe(Frame)
    End Function
    Public Sub DrawKeyframes(g As Graphics)
        If SelectedItemIndex <> -1 Then
            SelectedItem.DrawKeyframe(g)
        End If
    End Sub
    Public Sub PushKeyframes(Frame As UInteger)
        For i = 0 To Vertices.Count - 1
            Vertices(i).PushKeyframe(Frame)
        Next
        For i = 0 To Edges.Count - 1
            Edges(i).PushKeyframe(Frame)
        Next
        For i = 0 To Faces.Count - 1
            Faces(i).PushKeyframe(Frame)
        Next
    End Sub
End Class

Public Enum DisplayObjects
    Null
    Node
    Arc
    Fill
    Camera
End Enum