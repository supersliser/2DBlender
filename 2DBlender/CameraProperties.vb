Public Class CameraProperties
    Private Cam As Camera 'Stores the camera that these properties currently represent
    Public setup As Boolean = True 'Stops events being triggerred during instanciation

    Public Sub New(SelectedCam As Camera, GridSize As Size) 'sets up the properties for this camera and makes them appear in the viewport

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        setup = True
        Cam = SelectedCam
        X.Value = SelectedCam.CurrentValue.GridX
        X.Maximum = GridSize.Width - 1
        Y.Value = SelectedCam.CurrentValue.GridY
        Y.Maximum = GridSize.Height - 1
        NameValue.Text = SelectedCam.Name
        WidthValue.Value = SelectedCam.Size.GridWidth
        HeightValue.Value = SelectedCam.Size.GridHeight
        Select Case SelectedCam.ColourMode
            Case = ColourModes.RGB
                ColourMode.SelectedIndex = 0
            Case = ColourModes.BW
                ColourMode.SelectedIndex = 1
            Case = ColourModes.Inverted
                ColourMode.SelectedIndex = 2
        End Select
        setup = False
    End Sub

    Private Sub ExportChanges() 'applies any changes made in the properties viewport to the base object
        Main.CurrentCamera = Cam
        Main.RefreshImage()
        Main.KeyframeViewer.RefreshImage()
    End Sub

    Private Sub X_ValueChanged(sender As Object, e As EventArgs) Handles X.ValueChanged 'Event handlers for when a value of the base object is changed
        If Not setup Then
            setup = True
            Cam.CurrentValue.GridX = X.Value
            If X.Value + WidthValue.Value > X.Maximum + 1 Then
                WidthValue.Value = (X.Maximum + 1) - X.Value
            End If
            Cam.Size.GridWidth = WidthValue.Value
            ExportChanges()
            setup = False
        End If
    End Sub

    Private Sub Y_ValueChanged(sender As Object, e As EventArgs) Handles Y.ValueChanged
        If Not setup Then
            setup = True
            Cam.CurrentValue.GridY = Y.Value
            If Y.Value + Cam.Size.GridHeight > Y.Maximum + 1 Then
                HeightValue.Value = (Y.Maximum + 1) - Y.Value
            End If
            Cam.Size.GridHeight = HeightValue.Value
            ExportChanges()
            setup = False
        End If
    End Sub

    Private Sub Keyframe_Click(sender As Object, e As EventArgs) Handles Keyframe.Click
        If Not setup Then
            Cam.AddKeyframe(Main.CurrentFrame)
            ExportChanges()
        End If
    End Sub

    Public Sub RefreshCam(SelectedCam As Camera) 'refreshes the stored camera if changed by some external facet
        setup = True
        Cam = SelectedCam
        X.Value = SelectedCam.CurrentValue.GridX
        Y.Value = SelectedCam.CurrentValue.GridY
        NameValue.Text = SelectedCam.Name
        WidthValue.Value = SelectedCam.Size.GridWidth
        HeightValue.Value = SelectedCam.Size.GridHeight
        Select Case SelectedCam.ColourMode
            Case = ColourModes.RGB
                ColourMode.SelectedIndex = 0
            Case = ColourModes.BW
                ColourMode.SelectedIndex = 1
            Case = ColourModes.Inverted
                ColourMode.SelectedIndex = 2
        End Select
        setup = False
    End Sub

    Private Sub NameValue_TextChanged(sender As Object, e As EventArgs) Handles NameValue.LostFocus
        If Not setup Then
            If NameValue.Text = "" Then
                NameValue.Text = Cam.Name
            Else
                Cam.Name = NameValue.Text
                ExportChanges()
            End If
        End If
    End Sub

    Private Sub AddInterpolation_Click(sender As Object, e As EventArgs) Handles AddInterpolation.Click
        If InterpolationType.Text = "Static" Then
            Cam.KF.AddInterpolation(Main.CurrentFrame, Interpolations.StaticMovement)
        ElseIf InterpolationType.Text = "Constant" Then
            Cam.KF.AddInterpolation(Main.CurrentFrame, Interpolations.ConstantMovement)
        End If
    End Sub

    Private Sub Width_ValueChanged(sender As Object, e As EventArgs) Handles WidthValue.ValueChanged
        If Not setup Then
            setup = True
            Cam.Size.GridWidth = WidthValue.Value
            If X.Value + WidthValue.Value > X.Maximum Then
                WidthValue.Value = X.Maximum - X.Value
            End If
            ExportChanges()
            setup = False
        End If
    End Sub

    Private Sub Height_ValueChanged(sender As Object, e As EventArgs) Handles HeightValue.ValueChanged
        If Not setup Then
            setup = True
            Cam.Size.GridHeight = HeightValue.Value
            If Y.Value + HeightValue.Value > Y.Maximum Then
                HeightValue.Value = Y.Maximum - Y.Value
            End If
            ExportChanges()
            setup = False
        End If
    End Sub

    Private Sub ColourMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColourMode.SelectedIndexChanged
        Select Case ColourMode.SelectedIndex
            Case 0
                Cam.ColourMode = ColourModes.RGB
            Case = 1
                Cam.ColourMode = ColourModes.BW
            Case = 2
                Cam.ColourMode = ColourModes.Inverted
        End Select
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If Not setup Then
            Cam.KF.DeleteKeyframe(Main.CurrentFrame)
            ExportChanges()
        End If
    End Sub
End Class
