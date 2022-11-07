Public Class NewFile
    Private Sub SelectFileLocation_Click(sender As Object, e As EventArgs) Handles SelectFileLocation.Click
        FileLocationDialog.ShowDialog()
    End Sub

    Private Sub FileLocationDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileLocationDialog.FileOk
        FileLocation.Text = FileLocationDialog.FileName
    End Sub

    Private Sub CanvasLock_CheckedChanged(sender As Object, e As EventArgs) Handles CanvasLock.CheckedChanged
        If CanvasLock.Checked Then
            CanvasHeight.ReadOnly = True
            CanvasHeight.Value = CanvasWidth.Value
        Else
            CanvasHeight.ReadOnly = False
        End If
    End Sub

    Private Sub CanvasWidth_ValueChanged(sender As Object, e As EventArgs) Handles CanvasWidth.ValueChanged
        If CanvasLock.Checked Then
            CanvasHeight.Value = CanvasWidth.Value
        End If
    End Sub

    Private Sub GridBoxLock_CheckedChanged(sender As Object, e As EventArgs) Handles GridBoxLock.CheckedChanged
        If GridBoxLock.Checked Then
            GridBoxHeight.ReadOnly = True
            GridBoxHeight.Value = GridBoxHeight.Value
        Else
            GridBoxHeight.ReadOnly = False
        End If
    End Sub

    Private Sub GridBoxWidth_ValueChanged(sender As Object, e As EventArgs) Handles GridBoxWidth.ValueChanged
        If GridBoxLock.Checked Then
            GridBoxHeight.Value = GridBoxWidth.Value
        End If
    End Sub

    Private Sub Create_Enter(sender As Object, e As EventArgs) Handles Create.Enter
        If FileLocation.Text = Nothing Then
            MsgBox("Please select file location", vbOKOnly, "Error!")
        Else
            Main.IO = New TwoDBlenderFile(FileLocation.Text)
            Main.IO.CreateFile()
            Main.SetupViewport(New Size(CanvasWidth.Value, CanvasHeight.Value), New Size(GridBoxWidth.Value, GridBoxHeight.Value), FrameCount.Value)
            OnDeactivate(e)
            Hide()
        End If
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Hide()
        OnDeactivate(e)
    End Sub
End Class