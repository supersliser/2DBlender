Public Class Node 'Base vertex class
    Inherits Entity(Of TPoint)
    Public Overrides ReadOnly Property ParentGraph As Graph
        Get
            For i = 0 To Main.Layers.Count - 1
                For j = 0 To Main.Layers(i).Vertices.Count - 1
                    If Main.Layers(i).Vertices(j).Name = Name Then
                        Return Main.Layers(i)
                    End If
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public Overrides ReadOnly Property Index As UInteger 'index within graph's linked list
        Get
            For i = 0 To ParentGraph.Vertices.Count
                If ParentGraph.Vertices(i).Name = Name Then
                    Return i
                End If
            Next
            Return Nothing
        End Get
    End Property


    Public Sub New(GridPoint As Point, Index As UInteger) 'constructor for vertices
        MyBase.New(New TPoint(GridPoint), Index)
        Name = "Vertex " & Main.CurrentLayer.Vertices.Count + 1
    End Sub
    Public Sub New(Name As String, Point As TPoint, Index As UInteger)
        MyBase.New(Point, Index)
        Me.Name = Name
    End Sub

    Public Sub Draw(g As Graphics) 'draws in different colours based on whether selected or not
        If IsSelectedItem Then
            g.FillEllipse(New SolidBrush(Color.Green), New RectangleF(CurrentValue.WorldLocation + New Size(-4, -4), New SizeF(8, 8)))
        ElseIf Highlighted Then
            g.FillEllipse(New SolidBrush(Color.Orange), New RectangleF(CurrentValue.WorldLocation + New Size(-4, -4), New SizeF(8, 8)))
        Else
            g.FillEllipse(New SolidBrush(Color.Black), New RectangleF(CurrentValue.WorldLocation + New Size(-4, -4), New SizeF(8, 8)))
        End If
    End Sub

    Public Sub PushKeyframe(CurrentFrame As UInteger)
        Try
            CurrentValue = KF.GetKeyframe(CurrentFrame).getDataTPoint(CurrentFrame)
        Catch ex As Exception
        End Try
    End Sub
End Class
