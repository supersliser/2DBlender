Imports System.IO
Public Class TwoDBlenderFile
    Private FileName As String

    Public Sub New(FileName As String)
        Me.FileName = FileName
    End Sub

    Public Sub CreateFile()
        Dim CurrentFile As FileStream
        If File.Exists(FileName) Then
            If MsgBox("File already exists. Would you like to override it?", vbYesNo, "File Exists") = vbYes Then
                CurrentFile = New FileStream(FileName, FileMode.Create)
                CurrentFile.Close()
            End If
        Else
            CurrentFile = New FileStream(FileName, FileMode.Create)
            CurrentFile.Close()
        End If
    End Sub

    Public Sub Write(data As Graph(), Coordinates As CoordinateSystem, FrameCount As UInteger)
        Dim CurrentFile As New FileStream(FileName, FileMode.Create)
        Dim Writer As New BinaryWriter(CurrentFile)

        Writer.Write(FrameCount)
        Writer.Write(Coordinates.WorldSize.Width)
        Writer.Write(Coordinates.WorldSize.Height)
        Writer.Write(Coordinates.GridSquareSize.Width)
        Writer.Write(Coordinates.GridSquareSize.Height)
        If Not IsNothing(Main.CurrentCamera) Then
            Writer.Write(True)
            Writer.Write(Main.CurrentCamera.Name)
            Writer.Write(Main.CurrentCamera.CurrentValue.GridX)
            Writer.Write(Main.CurrentCamera.CurrentValue.GridY)
            Writer.Write(Main.CurrentCamera.Size.GridWidth)
            Writer.Write(Main.CurrentCamera.Size.GridHeight)
            Writer.Write(Main.CurrentCamera.ColourMode)
            If Not IsNothing(Main.CurrentCamera.KF.GetKeyframes) Then
                Writer.Write(Main.CurrentCamera.KF.GetKeyframes.Count)
                For k = 0 To Main.CurrentCamera.KF.GetKeyframes.Count - 1
                    Writer.Write(Main.CurrentCamera.KF.GetKeyframes(k).Frame)
                    Writer.Write(Main.CurrentCamera.KF.GetKeyframes(k).Data.GridX)
                    Writer.Write(Main.CurrentCamera.KF.GetKeyframes(k).Data.GridY)
                    Writer.Write(Main.CurrentCamera.KF.GetKeyframes(k).InterpolationToNext)
                Next
            Else
                Writer.Write(-1)
            End If
        Else
            Writer.Write(False)
        End If
        Writer.Write(data.Count)
        For i = 0 To data.Count - 1
            Writer.Write(data(i).Name)
            Writer.Write(data(i).Visible)
            Writer.Write(data(i).Vertices.Count)
            For v = 0 To data(i).Vertices.Count - 1
                Writer.Write(data(i).Vertices(v).Name)
                Writer.Write(data(i).Vertices(v).CurrentValue.GridX)
                Writer.Write(data(i).Vertices(v).CurrentValue.GridY)
                If Not IsNothing(data(i).Vertices(v).KF.GetKeyframes) Then
                    Writer.Write(data(i).Vertices(v).KF.GetKeyframes.Count)
                    For k = 0 To data(i).Vertices(v).KF.GetKeyframes.Count - 1
                        Writer.Write(data(i).Vertices(v).KF.GetKeyframes(k).Frame)
                        Writer.Write(data(i).Vertices(v).KF.GetKeyframes(k).Data.GridX)
                        Writer.Write(data(i).Vertices(v).KF.GetKeyframes(k).Data.GridY)
                        Writer.Write(data(i).Vertices(v).KF.GetKeyframes(k).InterpolationToNext)
                    Next
                Else
                    Writer.Write(-1)
                End If
            Next
            Writer.Write(data(i).Edges.Count)
            For a = 0 To data(i).Edges.Count - 1
                Writer.Write(data(i).Edges(a).ParentIndex.Count)
                For v = 0 To data(i).Edges(a).ParentIndex.Count - 1
                    Writer.Write(data(i).Edges(a).ParentIndex(v))
                Next
                Writer.Write(data(i).Edges(a).Name)
                Writer.Write(data(i).Edges(a).CurrentValue.A)
                Writer.Write(data(i).Edges(a).CurrentValue.R)
                Writer.Write(data(i).Edges(a).CurrentValue.G)
                Writer.Write(data(i).Edges(a).CurrentValue.B)
                If Not IsNothing(data(i).Edges(a).KF.GetKeyframes) Then
                    Writer.Write(data(i).Edges(a).KF.GetKeyframes.Count)
                    For k = 0 To data(i).Edges(a).KF.GetKeyframes.Count - 1
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).Frame)
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).Data.A)
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).Data.R)
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).Data.G)
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).Data.B)
                        Writer.Write(data(i).Edges(a).KF.GetKeyframes(k).InterpolationToNext)
                    Next
                Else
                    Writer.Write(-1)
                End If
            Next
            Writer.Write(data(i).Faces.Count)
            For f = 0 To data(i).Faces.Count - 1
                Writer.Write(data(i).Faces(f).ParentIndex.Count)
                For a = 0 To data(i).Faces(f).ParentIndex.Count - 1
                    Writer.Write(data(i).Faces(f).ParentIndex(a))
                Next
                Writer.Write(data(i).Faces(f).Name)
                Writer.Write(data(i).Faces(f).CurrentValue.A)
                Writer.Write(data(i).Faces(f).CurrentValue.R)
                Writer.Write(data(i).Faces(f).CurrentValue.G)
                Writer.Write(data(i).Faces(f).CurrentValue.B)
                If Not IsNothing(data(i).Faces(f).KF.GetKeyframes) Then
                    Writer.Write(data(i).Faces(f).KF.GetKeyframes.Count)
                    For k = 0 To data(i).Faces(f).KF.GetKeyframes.Count - 1
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).Frame)
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).Data.A)
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).Data.R)
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).Data.G)
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).Data.B)
                        Writer.Write(data(i).Faces(f).KF.GetKeyframes(k).InterpolationToNext)
                    Next
                Else
                    Writer.Write(-1)
                End If
            Next
        Next
        CurrentFile.Close()
    End Sub

    Public Sub Read()
        Dim CurrentFile As New FileStream(FileName, FileMode.Open)
        If FileName.EndsWith(".tbl") Then
            On Error GoTo ErrorOccured
            Dim Reader As New BinaryReader(CurrentFile)
            Dim data As New List(Of Graph)
            Dim framecount As UInteger = Reader.ReadUInt32
            Dim canvas As New Size(Reader.ReadInt32, Reader.ReadInt32)
            Dim gridbox As New Size(Reader.ReadInt32, Reader.ReadInt32)

            Main.Coordinates = New CoordinateSystem(canvas, gridbox)

            If Reader.ReadBoolean Then
                Main.CurrentCamera = New Camera(Reader.ReadString, New TPoint(Reader.ReadUInt32, Reader.ReadUInt32), New TSize(Reader.ReadUInt32, Reader.ReadUInt32))
                Main.CurrentCamera.ColourMode = Reader.ReadInt32
                Dim camKFCount As Integer = Reader.ReadInt32
                If Not camKFCount = -1 Then
                    For i = 0 To camKFCount - 1
                        Main.CurrentCamera.KF.Add(Reader.ReadUInt32, New TPoint(Reader.ReadUInt32, Reader.ReadUInt32), Reader.ReadInt32)
                    Next
                End If
            End If

            Dim graphcount As Integer = Reader.ReadInt32
            For i = 0 To graphcount - 1
                data.Add(New Graph(data.Count))
                data(i).Name = Reader.ReadString
                data(i).Visible = Reader.ReadBoolean
                Dim verticescount As Integer = Reader.ReadInt32
                For v = 0 To verticescount - 1
                    data(i).Vertices.AddLast(New Node(Reader.ReadString, New TPoint(Reader.ReadUInt32, Reader.ReadUInt32), data(i).Vertices.Count))
                    Dim verticeskeyframecount As Integer = Reader.ReadInt32
                    If Not verticeskeyframecount = -1 Then
                        For k = 0 To verticeskeyframecount - 1
                            data(i).Vertices(v).KF.Add(Reader.ReadUInt32, New TPoint(Reader.ReadUInt32, Reader.ReadUInt32), Reader.ReadInt32)
                        Next
                    End If
                Next
                Dim arcscount As Integer = Reader.ReadInt32
                For a = 0 To arcscount - 1
                    Dim arcsparentcount As Integer = Reader.ReadInt32
                    Dim parents As New List(Of UInteger)
                    For p = 0 To arcsparentcount - 1
                        parents.Add(Reader.ReadUInt32)
                    Next
                    data(i).Edges.AddLast(New Arc(Reader.ReadString, Color.FromArgb(Reader.ReadByte, Reader.ReadByte, Reader.ReadByte, Reader.ReadByte), data(i).Edges.Count, parents.ToArray))
                    Dim arcskeyframecount As Integer = Reader.ReadInt32
                    If Not arcskeyframecount = -1 Then
                        For k = 0 To arcskeyframecount - 1
                            data(i).Edges(a).KF.Add(Reader.ReadUInt32, Color.FromArgb(Reader.ReadByte, Reader.ReadByte, Reader.ReadByte, Reader.ReadByte), Reader.ReadInt32)
                        Next
                    End If
                Next
                Dim facescount As Integer = Reader.ReadInt32
                For f = 0 To facescount - 1
                    Dim facesparentcount As Integer = Reader.ReadInt32
                    Dim parents As New List(Of UInteger)
                    For p = 0 To facesparentcount - 1
                        parents.Add(Reader.ReadUInt32)
                    Next
                    data(i).Faces.AddLast(New Fill(Reader.ReadString, Color.FromArgb(Reader.ReadByte, Reader.ReadByte, Reader.ReadByte, Reader.ReadByte), data(i).Faces.Count, parents.ToArray))
                    Dim facekeyframecount As Integer = Reader.ReadInt32
                    If Not facekeyframecount = -1 Then
                        For k = 0 To facekeyframecount - 1
                            data(i).Faces(f).KF.Add(Reader.ReadUInt32, Color.FromArgb(Reader.ReadByte, Reader.ReadByte, Reader.ReadByte, Reader.ReadByte), Reader.ReadInt32)
                        Next
                    End If
                Next
            Next
            CurrentFile.Close()
            Main.LoadViewport(framecount, canvas, data.ToArray)
            GoTo EndSub
ErrorOccured:
            MsgBox("File corrupted", vbOKOnly, "Error")
            Reader.Close()
EndSub:
        Else
            MsgBox("File not valid", vbOKOnly, "Error")
        End If
    End Sub
End Class
