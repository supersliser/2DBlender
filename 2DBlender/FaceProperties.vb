Public Class FaceProperties
    Private Fill As Fill
    Public Setup As Boolean = True

    Public Sub New(NewFill As Fill)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Fill = NewFill
        Colour.BackColor = NewFill.CurrentValue
        NameValue.Text = Fill.Name
    End Sub

    Private Sub ExportChanges(oldfill As Fill)
        Main.CurrentLayer.EditFill(oldfill, Fill)
        Main.RefreshImage()
        Main.KeyframeViewer.RefreshImage()
    End Sub

    Public Sub RefreshFill(Fill As Fill)
        Setup = True
        Me.Fill = Fill
        Colour.BackColor = Fill.CurrentValue
        Setup = False
        NameValue.Text = Fill.Name
    End Sub

    Private Sub Colour_MouseClick(sender As Object, e As MouseEventArgs) Handles Colour.MouseClick
        If Not Setup Then
            Dim oldfill As Fill = Fill
            ColorDialog1.ShowDialog()
            Colour.BackColor = ColorDialog1.Color
            Fill.CurrentValue = Colour.BackColor
            ExportChanges(oldfill)
        End If
    End Sub

    Private Sub Name_TextChanged(sender As Object, e As EventArgs) Handles NameValue.LostFocus
        If Not Setup Then
            Dim oldfill As Fill = Fill
            Fill.Name = NameValue.Text
            ExportChanges(oldfill)
        End If
    End Sub

    Private Sub Keyframe_Click(sender As Object, e As EventArgs) Handles Keyframe.Click
        If Not Setup Then
            Dim oldfill As Fill = Fill
            Fill.AddKeyframe(Main.CurrentFrame)
            ExportChanges(oldfill)
        End If
    End Sub

    Private Sub AddInterpolation_Click(sender As Object, e As EventArgs) Handles AddInterpolation.Click
        If InterpolationType.Text = "Static" Then
            Fill.KF.AddInterpolation(Main.CurrentFrame, Interpolations.StaticMovement)
        ElseIf InterpolationType.Text = "Constant" Then
            Fill.KF.AddInterpolation(Main.CurrentFrame, Interpolations.ConstantMovement)
        End If
    End Sub
End Class
