Public Class VertexProperties
    Private node As Node
    Public setup As Boolean = True

    Public Sub New(SelectedNode As Node, GridSize As Size)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        node = SelectedNode
        X.Value = SelectedNode.CurrentValue.GridX
        X.Maximum = GridSize.Width
        Y.Value = SelectedNode.CurrentValue.GridY
        Y.Maximum = GridSize.Height
        NameValue.Text = SelectedNode.Name
    End Sub

    Private Sub ExportChanges(OldNode As Node)
        Main.CurrentLayer.EditNode(OldNode, node)
        Main.RefreshImage()
        Main.KeyframeViewer.RefreshImage()
    End Sub

    Private Sub X_ValueChanged(sender As Object, e As EventArgs) Handles X.ValueChanged
        If Not setup Then
            Dim oldnode As Node = node
            node.CurrentValue.GridX = X.Value
            ExportChanges(oldnode)
        End If
    End Sub

    Private Sub Y_ValueChanged(sender As Object, e As EventArgs) Handles Y.ValueChanged
        If Not setup Then
            Dim oldnode As Node = node
            node.CurrentValue.GridY = Y.Value
            ExportChanges(oldnode)
        End If
    End Sub

    Private Sub Keyframe_Click(sender As Object, e As EventArgs) Handles Keyframe.Click
        If Not setup Then
            Dim oldnode As Node = node
            node.AddKeyframe(Main.CurrentFrame)
            ExportChanges(oldnode)
        End If
    End Sub

    Public Sub RefreshNode(Node As Node)
        setup = True
        Me.node = Node
        X.Value = Node.CurrentValue.GridX
        Y.Value = Node.CurrentValue.GridY
        NameValue.Text = Node.Name
        setup = False
    End Sub

    Private Sub NameValue_TextChanged(sender As Object, e As EventArgs) Handles NameValue.LostFocus
        If Not setup Then
            If NameValue.Text = "" Then
                NameValue.Text = node.Name
            Else
                Dim oldnode As Node = node
                node.Name = NameValue.Text
                ExportChanges(oldnode)
                Main.RefreshOutliner()
            End If
        End If
    End Sub

    Private Sub AddInterpolation_Click(sender As Object, e As EventArgs) Handles AddInterpolation.Click
        If InterpolationType.Text = "Static" Then
            node.KF.AddInterpolation(Main.CurrentFrame, Interpolations.StaticMovement)
        ElseIf InterpolationType.Text = "Constant" Then
            node.KF.AddInterpolation(Main.CurrentFrame, Interpolations.ConstantMovement)
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If Not setup Then
            Dim oldnode As Node = node
            node.KF.DeleteKeyframe(Main.CurrentFrame)
            ExportChanges(oldnode)
        End If
    End Sub
End Class