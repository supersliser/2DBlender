Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Media.Imaging

Public Class RenderViewport
    Private Arcs() As RenderArc
    Private Fills() As RenderFill
    Private OutputCanvas As New List(Of Bitmap)
    Private FrameCount As UInteger
    Private Camera As Camera

    Private Sub RenderWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RenderWorker.DoWork 'actual rendering subroutine
        OutputCanvas.Clear()
        For f = CUInt(0) To FrameCount - 1 'does for each frame
            OutputCanvas.Add(New Bitmap(CInt(Camera.Size.WorldWidth), CInt(Camera.Size.WorldHeight))) 'creates the output canvas based on the size of the camera
            RenderBox.Image = OutputCanvas(f)
            Dim g As Graphics = Graphics.FromImage(OutputCanvas(f))
            RenderWorker.ReportProgress(50, "output canvas initialised successfully")
            Dim p As New Pen(Color.Black)
            Dim b As New SolidBrush(Color.Black)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            RenderWorker.ReportProgress(50, "drawing systems initialised successfully")
            g.Clear(Color.White) 'makes sure each canvas is white by default
            For i = 0 To Fills.Count - 1 'draws each fill first to be underneath arcs
                Select Case Camera.ColourMode
                    Case ColourModes.RGB
                        b.Color = Fills(i).Colour(f)
                    Case ColourModes.BW
                        Dim colourvalues As Integer = Fills(i).Colour(f).R
                        colourvalues += Fills(i).Colour(f).G
                        colourvalues += Fills(i).Colour(f).B
                        Dim bwcolour As Byte = colourvalues \ 3
                        b.Color = Color.FromArgb(bwcolour, bwcolour, bwcolour)
                    Case ColourModes.Inverted
                        b.Color = Color.FromArgb(Not Fills(i).Colour(f).R, Not Fills(i).Colour(f).G, Not Fills(i).Colour(f).B)
                End Select
                g.FillRegion(b, Fills(i).ToRegion(f))
                RenderWorker.ReportProgress(50, "Face (" & i + 1 & "/" & Fills.Count & ") drawn successfully")
            Next
            For i = 0 To Arcs.Count - 1 'draws arcs second to be on top of fills
                Select Case Camera.ColourMode
                    Case ColourModes.RGB
                        b.Color = Arcs(i).Colour(f)
                    Case ColourModes.BW
                        Dim bwcolour As Byte = (Arcs(i).Colour(f).A + Arcs(i).Colour(f).G + Arcs(i).Colour(f).B) / 3
                        b.Color = Color.FromArgb(bwcolour, bwcolour, bwcolour)
                    Case ColourModes.Inverted
                        b.Color = Color.FromArgb(Not Arcs(i).Colour(f).R, Not Arcs(i).Colour(f).G, Not Arcs(i).Colour(f).B)
                End Select
                g.DrawLine(p, New Drawing.Point(Arcs(i).Start(f).X, Arcs(i).Start(f).Y), New Drawing.Point(Arcs(i).Finish(f).X, Arcs(i).Finish(f).Y))
                RenderWorker.ReportProgress(50, "Edge (" & i + 1 & "/" & Arcs.Count & ") drawn successfully")
            Next
        Next

        RenderProgress.Value = 0
    End Sub

    Public Sub SetupStill(Graph As Graph(), Cam As Camera) 'prepares viewport to render still image
        Dim ArcCount As UInteger 'the total amount of arcs in the entire project
        Dim FillCount As UInteger 'the total amount of fills in the entire project
        For i = 0 To Graph.Count - 1
            ArcCount += Graph(i).ArcCount
        Next
        For i = 0 To Graph.Count - 1
            FillCount += Graph(i).FillCount
        Next
        ReDim Arcs(ArcCount) 'arcs and fills are stored in fixed size arrays
        ReDim Fills(FillCount)

        For i = 0 To Graph.Count - 1
            For j = CUInt(0) To Graph(i).ArcCount 'for each arc in each graph
                Arcs(j) = New RenderArc(0)
                Arcs(j).Start(0) = New Drawing.Point(Graph(i).Edges(j).Parent(0).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(0).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                Arcs(j).Finish(0) = New Drawing.Point(Graph(i).Edges(j).Parent(1).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(1).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                Arcs(j).Colour(0) = Graph(i).Edges(j).CurrentValue
                Arcs(j).Z = i
            Next
            For j = CUInt(0) To Graph(i).FillCount 'for each fill in each graph
                Fills(j) = New RenderFill(0, Graph(i).Faces(j).ParentNodes.Count - 1)
                For k = 0 To Graph(i).Faces(j).ParentNodes.Count - 1
                    Fills(j).Vertex(0, k) = New Drawing.Point(Graph(i).Faces(j).ParentNodes(k).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Faces(j).ParentNodes(k).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                Next
                Fills(j).Colour(0) = Graph(i).Faces(j).CurrentValue
                Fills(j).Z = i
            Next
        Next

        Camera = Cam
        RenderProgress.Maximum = Arcs.Count + Fills.Count + 2
        RenderProgress.Value = 0
        FrameCount = 1
    End Sub

    Public Sub SetupAnim(Graph As Graph(), Cam As Camera, Framecount As UInteger) 'prepares viewport to render animation
        Dim ArcCount As UInteger
        Dim FillCount As UInteger
        For i = 0 To Graph.Count - 1
            ArcCount += Graph(i).ArcCount
        Next
        For i = 0 To Graph.Count - 1
            FillCount += Graph(i).FillCount
        Next
        ReDim Arcs(ArcCount)
        ReDim Fills(FillCount)

        For i = 0 To Graph.Count - 1
            For j = CUInt(0) To Graph(i).ArcCount
                Arcs(j) = New RenderArc(Framecount)
                For f = CUInt(0) To Framecount - 1
                    Try 'tries to get keyframe data but if none is available then uses current value instead
                        Arcs(j).Start(f + 1) = New Drawing.Point(Graph(i).Edges(j).Parent(0).KF.GetKeyframe(f).getDataTPoint(f).WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(0).KF.GetKeyframe(f).getDataTPoint(f).WorldY - Cam.CurrentValue.WorldY)
                    Catch ex As NullReferenceException
                        Arcs(j).Start(f + 1) = New Drawing.Point(Graph(i).Edges(j).Parent(0).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(0).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                    End Try
                    Try
                        Arcs(j).Finish(f + 1) = New Drawing.Point(Graph(i).Edges(j).Parent(1).KF.GetKeyframe(f).getDataTPoint(f).WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(1).KF.GetKeyframe(f).getDataTPoint(f).WorldY - Cam.CurrentValue.WorldY)
                    Catch ex As NullReferenceException
                        Arcs(j).Finish(f + 1) = New Drawing.Point(Graph(i).Edges(j).Parent(1).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Edges(j).Parent(1).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                    End Try
                    Try
                        Arcs(j).Colour(f + 1) = Graph(i).Edges(j).KF.GetKeyframe(f).getDataColour(f)
                    Catch ex As NullReferenceException
                        Arcs(j).Colour(f + 1) = Graph(i).Edges(j).CurrentValue
                    End Try
                Next
                Arcs(j).Z = i
            Next
            For j = CUInt(0) To Graph(i).FillCount
                Fills(j) = New RenderFill(Framecount, Graph(i).Faces(j).ParentNodes.Count - 1)
                For f = CUInt(0) To Framecount - 1
                    For k = 0 To Graph(i).Faces(j).ParentNodes.Count - 1
                        Try
                            Fills(j).Vertex(f + 1, k) = New Drawing.Point(Graph(i).Faces(j).ParentNodes(k).KF.GetKeyframe(f).getDataTPoint(f).WorldX - Cam.CurrentValue.WorldX, Graph(i).Faces(j).ParentNodes(k).KF.GetKeyframe(f).getDataTPoint(f).WorldY - Cam.CurrentValue.WorldY)
                        Catch ex As NullReferenceException
                            Fills(j).Vertex(f + 1, k) = New Drawing.Point(Graph(i).Faces(j).ParentNodes(k).CurrentValue.WorldX - Cam.CurrentValue.WorldX, Graph(i).Faces(j).ParentNodes(k).CurrentValue.WorldY - Cam.CurrentValue.WorldY)
                        End Try
                    Next
                    Try
                        Fills(j).Colour(f + 1) = Graph(i).Faces(j).KF.GetKeyframe(f).getDataColour(f)
                    Catch ex As NullReferenceException
                        Fills(j).Colour(f + 1) = Graph(i).Faces(j).CurrentValue
                    End Try
                Next
                Fills(j).Z = i
            Next
        Next

        Camera = Cam

        RenderProgress.Maximum = Framecount * ((Arcs.Count + Fills.Count) + 2)
        RenderProgress.Value = 0
        Me.FrameCount = Framecount
    End Sub

    Private Sub Play_Click(sender As Object, e As EventArgs) Handles Play.Click
        RenderWorker.RunWorkerAsync(Log)
    End Sub

    Private Sub Pause_Click(sender As Object, e As EventArgs) Handles Pause.Click
        RenderWorker.CancelAsync()
    End Sub

    Private Sub BMPFileButton_Click(sender As Object, e As EventArgs) Handles BMPFileButton.Click 'outputs to a bitmap graphics file
        If OutputCanvas.Count = 1 Then

            SaveFileDialog.DefaultExt = "bmp"
            SaveFileDialog.Filter = "Bitmap Graphics Files|*.bmp|All files|*.*"
            SaveFileDialog.ShowDialog()
            Dim FileName As String = SaveFileDialog.FileName

            If Not FileName = Nothing Then
                Dim FileType(1) As Byte
                FileType(0) = Asc("B")
                FileType(1) = Asc("M")
                Dim FileSize As UInt32
                Const Reserved As UInt16 = 0
                Const PixelDataOffset As UInt32 = 54
                Const HeaderSize As UInt32 = 40
                Dim ImageWidth As Int32 = Camera.Size.WorldWidth
                Dim ImageHeight As Int32 = Camera.Size.WorldHeight
                Const Planes As Int16 = 1
                Const BitsPerPixel As Int16 = 24
                Const Zero As Int32 = 0
                Dim buffer As Integer
                FileSize = ((ImageWidth * 3) * ImageHeight) + PixelDataOffset

                Dim data((ImageWidth * 3) - 1, ImageHeight - 1) As Byte
                If Not (ImageWidth * 3) Mod 4 = 0 Then
                    buffer = (4 - ((ImageWidth * 3) Mod 4))
                    ReDim data((ImageWidth * 3) + buffer - 1, ImageHeight - 1)
                    FileSize += buffer * ImageHeight
                End If

                For h = 0 To ImageHeight - 1
                    For w = 0 To ImageWidth - 1 - buffer
                        data(w * 3, h) = OutputCanvas(0).GetPixel(w, ImageHeight - 1 - h).B
                        data((w * 3) + 1, h) = OutputCanvas(0).GetPixel(w, ImageHeight - 1 - h).G
                        data((w * 3) + 2, h) = OutputCanvas(0).GetPixel(w, ImageHeight - 1 - h).R
                    Next
                    If Not buffer = 0 Then
                        For i = 0 To buffer
                            data(ImageWidth - 1 - i, h) = CByte(0)
                        Next
                    End If
                Next

                Dim stream As New FileStream(FileName, FileMode.Create)
                Dim io As New BinaryWriter(stream)
                With io
                    .Write(FileType)
                    .Write(FileSize)
                    .Write(Reserved)
                    .Write(Reserved)
                    .Write(PixelDataOffset)
                    .Write(HeaderSize)
                    .Write(ImageWidth)
                    .Write(ImageHeight)
                    .Write(Planes)
                    .Write(BitsPerPixel)
                    .Write(Zero)
                    .Write(Zero)
                    .Write(Zero)
                    .Write(Zero)
                    .Write(Zero)
                    .Write(Zero)

                    For h = 0 To data.GetLength(1) - 1
                        For w = 0 To data.GetLength(0) - 1
                            .Write(data(w, h))
                        Next
                    Next
                    .Close()
                End With
            End If
        End If
    End Sub

    Private Sub RenderWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles RenderWorker.ProgressChanged 'adds an item to the log along with the time of the message
        Log.Items.Add(TimeOfDay.ToShortTimeString & ":" & TimeOfDay.Second & ":" & TimeOfDay.Millisecond & " : " & vbTab & e.UserState)
        RenderProgress.Value += 1
    End Sub

    Private Sub PNGFileButton_Click(sender As Object, e As EventArgs) Handles PNGFileButton.Click
        If OutputCanvas.Count = 1 Then
            SaveFileDialog.DefaultExt = "png"
            SaveFileDialog.Filter = "Portable Network Graphics File|*.png|All files|*.*"
            SaveFileDialog.ShowDialog()
            Dim FileName As String = SaveFileDialog.FileName

            If Not FileName = Nothing Then
                OutputCanvas(0).Save(SaveFileDialog.FileName, Imaging.ImageFormat.Png)
            End If
        End If
    End Sub

    Private Sub JPEGFileButton_Click(sender As Object, e As EventArgs) Handles JPEGFileButton.Click
        If OutputCanvas.Count = 1 Then
            SaveFileDialog.DefaultExt = "jpeg"
            SaveFileDialog.Filter = "Joint Photographic Experts Group file|*.jpeg|All files|*.*"
            SaveFileDialog.ShowDialog()
            Dim FileName As String = SaveFileDialog.FileName

            If Not FileName = Nothing Then
                OutputCanvas(0).Save(SaveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
            End If
        End If
    End Sub

    Private Sub GIFFileButton_Click(sender As Object, e As EventArgs) Handles GIFFileButton.Click
        If OutputCanvas.Count > 1 Then
            SaveFileDialog.DefaultExt = "gif"
            SaveFileDialog.Filter = "Graphics Interchange file|*.gif|All files|*.*"
            SaveFileDialog.ShowDialog()
            Dim FileName As String = SaveFileDialog.FileName

            If Not FileName = Nothing Then

                Dim encoder As New GifBitmapEncoder

                For f = CUInt(0) To FrameCount - 1
                    Dim mem As New MemoryStream

                    OutputCanvas(f).Save(mem, Imaging.ImageFormat.Bmp)

                    Dim bitmapimagetemp As New BitmapImage
                    With bitmapimagetemp
                        .BeginInit()
                        .StreamSource = mem
                        .CacheOption = BitmapCacheOption.OnLoad
                        .EndInit()
                        .Freeze()
                    End With
                    encoder.Frames.Add(BitmapFrame.Create(bitmapimagetemp))
                Next
                Dim stream As New FileStream(FileName, FileMode.Create)

                encoder.Save(stream)

                stream.Close()
            End If
        End If
    End Sub

    Public Function colour24bitTo8bit(input As Color) As Byte
        Return (((input.R \ 32) << 5) + ((input.G \ 32) << 2) + (input.B \ 64))
    End Function

    Public Sub export32bitToByte(ByRef data As LinkedList(Of Byte), input As Int32)
        Dim item() As Byte = BitConverter.GetBytes(input)
        data.AddLast(item(0))
        data.AddLast(item(1))
        data.AddLast(item(2))
        data.AddLast(item(3))
    End Sub

    Private Structure LocalImageDescriptor
        Public separator As Byte
        Public left As Int32
        Public top As Int32
        Public width As Int32
        Public height As Int32
        Public packed As Byte

        Public Sub New(WorldSize As Size)
            separator = 2
            left = 0
            top = 0
            width = WorldSize.Width
            height = WorldSize.Height
            packed = 0
            packed += 1 << 7
            packed += 1 << 2
            packed += 1 << 1
            packed += 1 << 0
        End Sub
    End Structure
End Class