Public Class Graph
    Public Name As String
    Public Visible As Boolean
    Public SelectedItemIndex As Integer
    Public SelectedItemType As DisplayObjects
    Public Vertices As LinkedList(Of Node)
    Public Edges As LinkedList(Of Arc)
    Public Faces As LinkedList(Of Fill)
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
    Public ReadOnly Property Index As UInteger
        Get
            For i = 0 To Main.Layers.Count
                If Main.Layers.ElementAt(i).Equals(Me) Then
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public Property SelectedItem As Object
        Set(value As Object)
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
            Select Case SelectedItemType
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


    Public Sub New()
        Try
            Name = "Layer " & Index
        Catch
            Name = "Layer 0"
        End Try
        Visible = False
        SelectedItemIndex = -1
        SelectedItemType = DisplayObjects.Null
        Vertices = New LinkedList(Of Node)
        Edges = New LinkedList(Of Arc)
        Faces = New LinkedList(Of Fill)
    End Sub

    Public Sub Draw(g As Graphics)
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

    Public Sub AddTriangle(Location As TPoint, Size As TSize)
        AddNode(Location.GridLocation) '3
        AddNode(New Point(Location.GridX + (Size.GridWidth / 2), Location.GridY + Size.GridHeight)) '2
        AddNode(New Point(Location.GridX - (Size.GridWidth / 2), Location.GridY + Size.GridHeight)) '1

        DeselectAll()
        Vertices(Vertices.Count - 3).Highlighted = True
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
        Edges(Edges.Count - 3).Highlighted = True
        Edges(Edges.Count - 2).Highlighted = True
        SelectedItem = Edges(Edges.Count - 1)
        AddFill(Color.White)
    End Sub
    Public Sub AddRectangle(Location As TPoint, Size As TSize)
        AddNode(Location.GridLocation) '4
        AddNode(New Point(Location.GridX + Size.GridWidth, Location.GridY)) '3
        AddNode(New Point(Location.GridX, Location.GridY + Size.GridHeight)) '2
        AddNode(Location.GridLocation + Size.GridSize) '1

        DeselectAll()
        Vertices(Vertices.Count - 4).Highlighted = True
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
        Edges(Edges.Count - 4).Highlighted = True
        Edges(Edges.Count - 3).Highlighted = True
        Edges(Edges.Count - 2).Highlighted = True
        SelectedItem = Edges(Edges.Count - 1)
        AddFill(Color.White)
    End Sub

    Public Sub AddNode(GridPoint As Point)
        Dim failed As Boolean
        For i = 0 To Vertices.Count - 1
            If Vertices(i).CurrentValue.GridLocation = GridPoint Then
                MsgBox("Cannot have 2 Nodes in the same location on the same layer, please use different layers or place the node somewhere else", vbOKOnly, "Warning!")
                failed = True
            End If
        Next
        If Not failed Then
            Vertices.AddLast(New Node(GridPoint, Vertices.Count))
        End If
    End Sub
    Public Sub AddNode(Node As Node)
        Dim failed As Boolean
        For i = 0 To Vertices.Count - 1
            If Vertices(i).CurrentValue.GridLocation = Node.CurrentValue.GridLocation Then
                MsgBox("Cannot have 2 Nodes in the same location on the same layer, please use different layers or place the node somewhere else", vbOKOnly, "Warning!")
                failed = True
            End If
        Next
        If Not failed Then
            Vertices.AddLast(Node)
        End If
    End Sub
    Public Sub EditNode(OldNode As Node, NewNode As Node)
        Vertices.ToArray(OldNode.Index) = NewNode
    End Sub
    Public Sub MoveNode(MoveAmount As TPoint)
        For i = 0 To Vertices.Count - 1
            If Vertices(i).Highlighted Then
                Vertices(i).CurrentValue += MoveAmount
            End If
        Next
    End Sub
    Public Sub DeleteNode(Index As UInteger)
        Vertices.Remove(Vertices(Index))
    End Sub

    Public Sub AddArc(Colour As Color)
        Dim added As Boolean
        For i = 0 To Vertices.Count - 1
            If Vertices(i).Highlighted Then
                If i <> SelectedItemIndex Then
                    If SelectedItemIndex <> -1 Then
                        If Not added Then
                            Dim output(1) As UInteger
                            output(0) = i
                            output(1) = SelectedItemIndex
                            Edges.AddLast(New Arc(Colour, Edges.Count, output))
                            added = True
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub AddArc(Arc As Arc)
        Edges.AddLast(Arc)
    End Sub
    Public Sub EditArc(Newarc As Arc, Oldarc As Arc)
        Edges.ToArray(Oldarc.Index) = Newarc
    End Sub
    Public Sub DeleteArc(Arc As Arc)
        Edges.Remove(Arc)
    End Sub
    Public Function GetArc(Index As UInteger) As Arc
        Return Edges(Index)
    End Function

    Public Sub AddFill(Colour As Color)
        Dim arcs As New List(Of UInteger)
        For i = 0 To Edges.Count - 1
            If Edges(i).Highlighted Then
                If i <> SelectedItemIndex Then
                    If SelectedItemIndex <> -1 Then
                        arcs.Add(Edges(i).Index)
                    End If
                End If
            End If
        Next
        arcs.Add(SelectedItem.index)
        Faces.AddLast(New Fill(Colour, Faces.Count, arcs.ToArray))
    End Sub
    Public Sub AddFill(Fill As Fill)
        Faces.AddLast(Fill)
    End Sub
    Public Sub EditFill(OldFill As Fill, NewFill As Fill)
        Faces.ToArray(OldFill.Index) = NewFill
    End Sub
    Public Sub DeleteFill(Fill As Fill)
        Faces.Remove(Fill)
    End Sub
    Public Function GetFill(Index As UInteger) As Fill
        Return Faces(Index)
    End Function

    Public Sub DeselectAll()
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
    Public Sub SelectItem(Location As TPoint)
        Dim success As Boolean
        If SelectedItemIndex <> -1 Then
            SelectedItem.Highlighted = True
        End If
        For i = 0 To Vertices.Count - 1
            If Vertices(i).CurrentValue.GridLocation = Location.GridLocation Then
                Vertices(i).Highlighted = True
                SelectedItemType = DisplayObjects.Node
                SelectedItemIndex = i
                success = True
            End If
        Next
        If Not success Then
            For i = 0 To Edges.Count - 1
                If Edges(i).IsOnPoint(Location.WorldLocation) Then
                    success = True
                    Edges(i).Highlighted = True
                    SelectedItemType = DisplayObjects.Arc
                    SelectedItemIndex = i
                End If
            Next
        End If
        If Not success Then
            For i = 0 To Faces.Count - 1
                If Faces(i).IsOnPoint(Location.WorldLocation) Then
                    success = True
                    Faces(i).Highlighted = True
                    SelectedItemType = DisplayObjects.Fill
                    SelectedItemIndex = i
                End If
            Next
        End If
        If Not success Then
            SelectedItemIndex = -1
            SelectedItemType = DisplayObjects.Null
        End If
    End Sub

    Public Sub AddKeyframe(Input As Object)
        If SelectedItemIndex <> -1 Then
            SelectedItem.AddKeyframe(Input)
        End If
    End Sub
    Public Function GetKeyframe(Frame As UInteger) As Object
        Return SelectedItem.GetKeyframe(Frame)
    End Function
    Public Function GetVertexKeyframes(Frame As UInteger) As TPoint()
        Dim output As New List(Of TPoint)
        For i = 0 To Vertices.Count - 1
            output.Add(Vertices(i).GetKeyframe(Frame))
        Next
        Return output.ToArray
    End Function
    Public Function GetArcKeyframes(Frame As UInteger) As Color()
        Dim output As New List(Of Color)
        For i = 0 To Edges.Count - 1
            output.Add(Edges(i).GetKeyframe(Frame))
        Next
        Return output.ToArray
    End Function
    Public Function GetFillKeyframes(Frame As UInteger) As Color()
        Dim output As New List(Of Color)
        For i = 0 To Faces.Count - 1
            output.Add(Faces(i).GetKeyframe(Frame))
        Next
        Return output.ToArray
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
End Enum