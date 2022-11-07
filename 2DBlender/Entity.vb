Public MustInherit Class Entity(Of T) 'Base Class for all visible entitys
    Public Name As String 'Stores the visible name for the entity
    Public Highlighted As Boolean 'stores whether the entity is highlighed for selection
    Public KF As KeyframeHandler(Of T) 'stores all keyframes in a custom linkedlist
    Public CurrentValue As T 'stores the current value stored (either TPoint or color)
    Public Overridable ReadOnly Property Index As UInteger
    Public Overridable ReadOnly Property IsSelectedItem As Boolean
        Get
            Return ParentGraph.SelectedItem Is Me
        End Get
    End Property
    Public Overridable ReadOnly Property ParentGraph As Graph
        Get
            Return Main.CurrentLayer
        End Get
    End Property

    Public Sub New(Input As T, Index As UInteger) 'basic initialiser for all entities
        Name = "Entity" & Index
        Highlighted = False
        KF = New KeyframeHandler(Of T)
        CurrentValue = Input
    End Sub

    Public Overridable Sub AddKeyframe(Frame As UInteger) 'manages keyframe control
        KF.Add(Frame, CurrentValue)
    End Sub
    Public Overridable Sub EditKeyframe(Frame As UInteger, Input As T)
        KF.Add(Frame, Input)
    End Sub
    Public Overridable Function GetKeyframe(Frame As UInteger) As T
        Return KF.GetKeyframe(Frame).Data
    End Function
    Public Overridable Sub PushKeyframe(Frame As UInteger)
        Try
            Dim thing As Keyframe(Of T) = KF.GetKeyframe(Frame)
            CurrentValue = thing.Data
        Catch
        End Try
    End Sub
    Public Overridable Sub DrawKeyframe(g As Graphics)
        KF.Draw(g)
    End Sub
End Class
