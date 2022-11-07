Public Class RenderViewport
    Private Arcs() As RenderArc
    Private Fills() As RenderFill
    Private OutputCanvas As Bitmap
    Private FrameCount As UInteger
    Private GridBox As Size

    Private Sub RenderWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RenderWorker.DoWork
        RenderBox.Image = OutputCanvas
        Dim g As Graphics = Graphics.FromImage(OutputCanvas)
        g.Clear(Color.White)
        UpdateLog("output canvas initialised successfully")
        Dim p As New Pen(Color.Black)
        Dim b As New SolidBrush(Color.Black)
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        UpdateLog("drawing systems initialised successfully")

        For f = CUInt(1) To FrameCount
            For i = 0 To Fills.Count
                b.Color = Fills(i).Colour(f)
                Dim temp As New List(Of PointF)
                For j = 0 To Fills(i).Vertex.GetLength(1)
                    temp.Add(New Point(Fills(i).Vertex(f, j).X * GridBox.Width, Fills(i).Vertex(f, j).Y * GridBox.Height))
                Next
                Dim types As New List(Of Byte)
                For j = 0 To Fills(i).Vertex.GetLength(1)
                    types.Add(1)
                Next
                Dim path As New Drawing2D.GraphicsPath(temp.ToArray, types.ToArray)
                g.FillPath(b, path)
                UpdateLog("Face (" & i & "/" & Fills.Count & ") drawn successfully")
            Next
            For i = 0 To Arcs.Count
                p.Color = Arcs(i).Colour(f)
                g.DrawLine(p, New Point(Arcs(i).Start(f).X * GridBox.Width, Arcs(i).Start(f).Y * GridBox.Height), New Point(Arcs(i).Finish(f).X * GridBox.Width, Arcs(i).Finish(f).Y * GridBox.Height))
                UpdateLog("Edge (" & i & "/" & Arcs.Count & ") drawn successfully")
            Next
        Next
    End Sub

    Public Sub SetupStill(Graph As Graph(), Canvas As Rectangle)
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

        Dim LastArcAccessed As UInteger = 0
        Dim LastFillAccessed As UInteger = 0

        For i = 0 To Graph.Count - 1
            For j = CUInt(0) To Graph(i).ArcCount
                Arcs(LastArcAccessed) = New RenderArc(Graph(i).GetArc(j).Parent(0).CurrentValue, Graph(i).GetArc(j).Parent(1).CurrentValue, Graph(i).GetArc(j).CurrentValue, i * 2)
                LastFillAccessed += 1
            Next
            For j = CUInt(0) To Graph(i).FillCount
                Dim nodes As New List(Of TPoint)
                For k = 0 To Graph(i).GetFill(j).ParentNodes.Count
                    nodes.Add(Graph(i).GetFill(j).ParentNodes(k).CurrentValue)
                Next
                Fills(LastFillAccessed) = New RenderFill(nodes.ToArray, Graph(i).GetFill(j).CurrentValue, (i * 2) - 1)
                LastFillAccessed += 1
            Next
        Next

        OutputCanvas = New Bitmap(Canvas.Width, Canvas.Height)
        RenderProgress.Maximum = Arcs.Count + Fills.Count + 2
        FrameCount = 1
    End Sub

    Public Sub SetupAnim(Graph As Graph(), Canvas As Rectangle, Framecount As UInteger)
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

        Dim LastArcAccessed As UInteger = 0
        Dim LastFillAccessed As UInteger = 0

        For i = 0 To Graph.Count - 1
            For j = CUInt(0) To Graph(i).ArcCount
                Arcs(LastArcAccessed) = New RenderArc(Graph(i).GetArc(j).Parent(0).GetKeyframe(1), Graph(i).GetArc(j).Parent(1).GetKeyframe(1), Graph(i).GetArc(j).GetKeyframe(1), i * 2)
                For k = CUInt(2) To Framecount
                    'Arcs(LastArcAccessed).Start(k) = Graph(i).GetArc(j).Parent(0).KF.get
                Next
                LastFillAccessed += 1
            Next
            For j = CUInt(0) To Graph(i).FillCount
                Dim nodes As New List(Of TPoint)
                For k = 0 To Graph(i).GetFill(j).ParentNodes.Count
                    nodes.Add(Graph(i).GetFill(j).ParentNodes(k).CurrentValue)
                Next
                Fills(LastFillAccessed) = New RenderFill(nodes.ToArray, Graph(i).GetFill(j).CurrentValue, (i * 2) - 1)
                LastFillAccessed += 1
            Next
        Next

        OutputCanvas = New Bitmap(Canvas.Width, Canvas.Height)
        RenderProgress.Maximum = Arcs.Count + Fills.Count + 2
        Me.FrameCount = Framecount
    End Sub

    Private Sub UpdateLog(Item As String)
        Log.Items.Add(TimeOfDay.ToShortTimeString & " : " & vbTab & Item)
        RenderProgress.Value += 1
    End Sub

    Private Sub Play_Click(sender As Object, e As EventArgs) Handles Play.Click
        RenderWorker.RunWorkerAsync()
    End Sub

    Private Sub Pause_Click(sender As Object, e As EventArgs) Handles Pause.Click
        RenderWorker.CancelAsync()
    End Sub
End Class