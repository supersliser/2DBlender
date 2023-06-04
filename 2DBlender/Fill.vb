Public Class Fill
    Inherits Entity(Of Color)
    Public ParentIndex As LinkedList(Of UInteger)
    Public Overrides ReadOnly Property ParentGraph As Graph 'gets the graph that contains this item
        Get
            For i = 0 To Main.Layers.Count - 1
                For j = 0 To Main.Layers(i).Faces.Count - 1
                    If Main.Layers(i).Faces(j).Name = Name Then 'checks based on the name of each fill within each graph
                        Return Main.Layers(i)
                    End If
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public Overrides ReadOnly Property Index As UInteger 'index within graph's linked list
        Get
            For i = 0 To ParentGraph.Faces.Count - 1
                If ParentGraph.Faces(i).Name = Name Then 'checks based on the name of each fill within the parent graph
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property Parent As Arc() 'gets the arc that controls the shape and size of the fills
        Get
            Dim output(ParentIndex.Count - 1) As Arc
            For i = 0 To ParentIndex.Count - 1
                output(i) = ParentGraph.Edges(ParentIndex(i))
            Next
            Return output
        End Get
    End Property
    Public ReadOnly Property ParentNodes As Node() 'gets the nodes that control the location and rotation of this face
        Get

            Dim output As New List(Of Node)

            For i = 0 To ParentIndex.Count - 1
                For j = 0 To 1
                    If Not output.Contains(Parent(i).Parent(j)) Then
                        output.Add(Parent(i).Parent(j))
                    End If
                Next
            Next
            Return output.ToArray
        End Get
    End Property

    Public Sub New(Colour As Color, Index As UInteger, Parents As UInteger())
        MyBase.New(Colour, Index)
        Name = "Face " & Main.CurrentLayer.Faces.Count + 1 'default name is "Face [index + 1]"
        ParentIndex = New LinkedList(Of UInteger)
        For i = 0 To Parents.Count - 1 'adds the parents to the parent linked list
            ParentIndex.AddLast(Parents(i))
        Next
    End Sub
    Public Sub New(Name As String, Colour As Color, Index As UInteger, Parents As UInteger())
        MyBase.New(Colour, Index)
        Me.Name = Name
        ParentIndex = New LinkedList(Of UInteger)
        For i = 0 To Parents.Count - 1
            ParentIndex.AddLast(Parents(i))
        Next
    End Sub

    Public Sub Draw(g As Graphics) 'Draws this fill to the given viewport
        Dim p As Drawing2D.GraphicsPath = ToPath()
        If IsSelectedItem Then
            g.FillPath(New SolidBrush(Color.Green), p)
        ElseIf Highlighted Then
            g.FillPath(New SolidBrush(Color.Orange), p)
        Else
            g.FillPath(New SolidBrush(CurrentValue), p)
        End If
    End Sub

    Public Function ToPath() As Drawing2D.GraphicsPath 'connects all the parent faces into a single path
        Dim temp As New List(Of PointF)
        For i = 0 To ParentIndex.Count - 1
            temp.Add(New PointF(ParentNodes(i).CurrentValue.WorldX, ParentNodes(i).CurrentValue.WorldY))
        Next
        Dim types As New List(Of Byte)
        types.Add(0)
        For i = 1 To ParentIndex.Count - 1
            types.Add(1)
        Next
        Return New Drawing2D.GraphicsPath(temp.ToArray, types.ToArray)
    End Function

    Public Function IsOnPoint(World As PointF) As Boolean 'Checks if a given point is within the hitbox of the fill
        Dim r As New Region(ToPath)
        Return r.IsVisible(World)
    End Function

    Public Sub PushKeyframe(CurrentFrame As UInteger) 'pushes the value from the keyframe and interpolation to the current value
        Try
            CurrentValue = KF.GetKeyframe(CurrentFrame).getDataColour(CurrentFrame)
        Catch ex As Exception
        End Try
    End Sub
End Class
