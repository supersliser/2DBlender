Public Class EdgeProperties
    Private Arc As Arc 'Stores the currently selected arc
    Public Setup As Boolean = True

    Public Sub New(NewArc As Arc) 'sets up the properties viewport with the current values of the arcs

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Arc = NewArc
        Colour.BackColor = NewArc.CurrentValue
        NameValue.Text = NewArc.Name
    End Sub

    Private Sub ExportChanges(oldarc As Arc) 'applies the stored arc to the display arc in the main viewport
        Main.CurrentLayer.EditArc(Arc, oldarc)
        Main.RefreshImage()
        Main.KeyframeViewer.RefreshImage()
    End Sub

    Public Sub RefreshArc(Arc As Arc) 'edits the local arc based on the passed value and resets the viewport to display that data
        Setup = True
        Me.Arc = Arc
        Colour.BackColor = Arc.CurrentValue
        Setup = False
        NameValue.Text = Arc.Name
    End Sub

    Private Sub Colour_MouseClick(sender As Object, e As MouseEventArgs) Handles Colour.MouseClick 'edits the local arc based on the event then exports that to the global arc
        If Not Setup Then
            Dim oldarc As Arc = Arc
            ColorDialog1.ShowDialog()
            Colour.BackColor = ColorDialog1.Color
            Arc.CurrentValue = Colour.BackColor
            ExportChanges(oldarc)
        End If
    End Sub

    Private Sub Name_TextChanged(sender As Object, e As EventArgs) Handles NameValue.LostFocus
        If Not Setup Then
            If NameValue.Text = "" Then
                NameValue.Text = Arc.Name
            Else
                Dim oldarc As Arc = Arc
                Arc.Name = NameValue.Text
                ExportChanges(oldarc)
                Main.RefreshOutliner()
            End If
        End If
    End Sub

    Private Sub Keyframe_Click(sender As Object, e As EventArgs) Handles Keyframe.Click
        If Not Setup Then
            Dim oldarc As Arc = Arc
            Arc.AddKeyframe(Main.CurrentFrame)
            ExportChanges(oldarc)
        End If
    End Sub

    Private Sub AddInterpolation_Click(sender As Object, e As EventArgs) Handles AddInterpolation.Click
        If InterpolationType.Text = "Static" Then
            Arc.KF.AddInterpolation(Main.CurrentFrame, Interpolations.StaticMovement)
        ElseIf InterpolationType.Text = "Constant" Then
            Arc.KF.AddInterpolation(Main.CurrentFrame, Interpolations.ConstantMovement)
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If Not Setup Then
            Dim oldarc As Arc = Arc
            Arc.KF.DeleteKeyframe(Main.CurrentFrame)
            ExportChanges(oldarc)
        End If
    End Sub
End Class
