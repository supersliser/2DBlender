Public Class Fill
    Inherits Entity(Of Color)
    Public ParentIndex As LinkedList(Of UInteger)
    Public Overrides ReadOnly Property Index As UInteger 'index within graph's linked list
        Get
            For i = 0 To ParentGraph.Faces.Count - 1
                If ParentGraph.Faces(i).Name = Name Then
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property Parent As Arc()
        Get
            Dim output(ParentIndex.Count - 1) As Arc
            For i = 0 To ParentIndex.Count - 1
                output(i) = ParentGraph.Edges(ParentIndex(i))
            Next
            Return output
        End Get
    End Property
    Public ReadOnly Property ParentNodes As Node()
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
        Name = "Face " & Main.CurrentLayer.Faces.Count - 1
        ParentIndex = New LinkedList(Of UInteger)
        For i = 0 To Parents.Count - 1
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

    Public Sub Draw(g As Graphics)
        Dim p As Drawing2D.GraphicsPath = ToPath()
        If IsSelectedItem Then
            g.FillPath(New SolidBrush(Color.Green), p)
        ElseIf Highlighted Then
            g.FillPath(New SolidBrush(Color.Orange), p)
        Else
            g.FillPath(New SolidBrush(CurrentValue), p)
        End If
    End Sub

    Public Function ToPath() As Drawing2D.GraphicsPath
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

    Public Function IsOnPoint(World As PointF) As Boolean
        Dim r As New Region(ToPath)
        Return r.IsVisible(World)
    End Function
End Class
