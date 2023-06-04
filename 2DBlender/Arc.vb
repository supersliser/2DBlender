Public Class Arc
    Inherits Entity(Of Color)
    Public ParentIndex As LinkedList(Of UInteger)
    Public Overrides ReadOnly Property ParentGraph As Graph 'gets the graph that contains this item
        Get
            For i = 0 To Main.Layers.Count - 1
                For j = 0 To Main.Layers(i).Edges.Count - 1
                    If Main.Layers(i).Edges(j).Name = Name Then 'checks based on the name of each arc within each graph
                        Return Main.Layers(i)
                    End If
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public Overrides ReadOnly Property Index As UInteger 'index within graph's linked list
        Get
            For i = 0 To ParentGraph.Edges.Count - 1
                If ParentGraph.Edges(i).Name = Name Then 'checks based on the name of each arc within the parent graph
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property Parent As Node() 'gets the nodes that control the location and rotation of this arc
        Get
            Dim output(1) As Node
            output(0) = ParentGraph.Vertices(ParentIndex(0))
            output(1) = ParentGraph.Vertices(ParentIndex(1))
            Return output
        End Get
    End Property

    Public Sub New(Colour As Color, Index As UInteger, Parents As UInteger())
        MyBase.New(Colour, Index)
        Name = "Edge " & Main.CurrentLayer.Edges.Count + 1 'default name is "edge [index + 1]"
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


    Public Sub Draw(g As Graphics) 'Draws this arc to the given viewport
        If IsSelectedItem Then
            g.DrawLine(New Pen(Color.Green, 2), Parent(0).CurrentValue.WorldLocation, Parent(1).CurrentValue.WorldLocation)
        ElseIf Highlighted Then
            g.DrawLine(New Pen(Color.Orange, 2), Parent(0).CurrentValue.WorldLocation, Parent(1).CurrentValue.WorldLocation)
        Else
            g.DrawLine(New Pen(CurrentValue, 1), Parent(0).CurrentValue.WorldLocation, Parent(1).CurrentValue.WorldLocation)
        End If
    End Sub


    Public Function IsOnPoint(World As PointF) As Boolean 'Checks if a given point is within the hitbox of the arc
        Dim Points(3) As PointF
        Points(0) = New PointF(Parent(0).CurrentValue.WorldX - Main.Coordinates.GridSquareSize.Width, Parent(0).CurrentValue.WorldY - Main.Coordinates.GridSquareSize.Height)
        Points(1) = New PointF(Parent(0).CurrentValue.WorldX + Main.Coordinates.GridSquareSize.Width, Parent(0).CurrentValue.WorldY - Main.Coordinates.GridSquareSize.Height)
        Points(2) = New PointF(Parent(1).CurrentValue.WorldX + Main.Coordinates.GridSquareSize.Width, Parent(1).CurrentValue.WorldY + Main.Coordinates.GridSquareSize.Height)
        Points(3) = New PointF(Parent(1).CurrentValue.WorldX - Main.Coordinates.GridSquareSize.Width, Parent(1).CurrentValue.WorldY + Main.Coordinates.GridSquareSize.Height)

        Dim temp(3) As Byte
        temp(0) = 0
        temp(1) = 1
        temp(2) = 1
        temp(3) = 1

        Dim r As New Region(New Drawing2D.GraphicsPath(Points, temp))
        Dim output As Boolean = r.IsVisible(World)
        Return output
    End Function

    Public Sub PushKeyframe(CurrentFrame As UInteger) 'pushes the value from the keyframe and interpolation to the current value
        Try
            CurrentValue = KF.GetKeyframe(CurrentFrame).getDataColour(CurrentFrame)
        Catch ex As Exception
        End Try
    End Sub
End Class
