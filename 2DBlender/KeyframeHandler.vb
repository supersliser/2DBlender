Public Class KeyframeHandler(Of T)
    Private Base As Keyframe(Of T) 'the first keyframe element in the list
    Public ReadOnly Property Tail As Keyframe(Of T) 'works out where the tail of the list is
        Get
            Dim i As Keyframe(Of T) = Base
            Do
                If i.IsTail Then
                    Return i
                Else
                    i = i.NextItem
                End If
            Loop
        End Get
    End Property
    Public ReadOnly Property Count As UInteger 'gets the number of elements in the list
        Get
            Try
                If Not Base.IsTail Then
                    Dim i As Keyframe(Of T) = Base
                    Dim c As UInteger = 1
                    Dim finish As Boolean = False
                    Do 'steps through and counts each one
                        If i.IsTail Then
                            finish = True
                        Else
                            i = i.NextItem
                        End If
                        c += 1
                    Loop Until finish
                    Return c
                Else
                    Return 1
                End If
            Catch ex As NullReferenceException
                Return Nothing
            End Try
        End Get
    End Property

    Public Sub Add(ByVal CurrentFrame As UInteger, ByVal InputData As T) 'adds keyframes
        If IsNothing(Base) Then
            Base = New Keyframe(Of T)
            Base.Data = InputData
            Base.Frame = CurrentFrame
        Else
            AddR(CurrentFrame, InputData, Base)
        End If
    End Sub
    Private Sub AddR(CurrentFrame As UInteger, InputData As T, i As Keyframe(Of T))
        If i.IsTail Then 'if it reaches the tail value, create a new keyframe on the end and add the data there
            i.NextItem = New Keyframe(Of T)
            i = i.NextItem
            i.Data = InputData
            i.Frame = CurrentFrame
            i.InterpolationToNext = Interpolations.keyframe
        ElseIf i.Frame = CurrentFrame Then 'if it finds the frame is already present, replaces the associated data with the new keyframe data
            i.Data = InputData
            i.InterpolationToNext = Interpolations.keyframe
        ElseIf i.Frame < CurrentFrame And CurrentFrame < i.NextItem.Frame Then 'if there is a space where the frame fits then it goes in there
            Dim temp As Keyframe(Of T) = i.NextItem
            i.NextItem = New Keyframe(Of T)
            i.NextItem.Data = InputData
            i.NextItem.Frame = CurrentFrame
            i.NextItem.NextItem = temp
            i.NextItem.InterpolationToNext = Interpolations.keyframe
        Else
            AddR(CurrentFrame, InputData, i.NextItem)
        End If
    End Sub
    Public Sub Add(ByVal CurrentFrame As UInteger, ByVal InputData As T, Type As Interpolations) 'adds keyframes
        If IsNothing(Base) Then
            Base = New Keyframe(Of T)
            Base.Data = InputData
            Base.Frame = CurrentFrame
        Else
            AddR(CurrentFrame, InputData, Base, Type)
        End If
    End Sub
    Private Sub AddR(CurrentFrame As UInteger, InputData As T, i As Keyframe(Of T), Type As Interpolations)
        If i.IsTail Then 'if it reaches the tail value, create a new keyframe on the end and add the data there
            i.NextItem = New Keyframe(Of T)
            i = i.NextItem
            i.Data = InputData
            i.Frame = CurrentFrame
            i.InterpolationToNext = Type
        ElseIf i.Frame = CurrentFrame Then 'if it finds the frame is already present, replaces the associated data with the new keyframe data
            i.Data = InputData
            i.InterpolationToNext = Type
        ElseIf i.Frame < CurrentFrame And CurrentFrame < i.NextItem.Frame Then 'if there is a space where the frame fits then it goes in there
            Dim temp As Keyframe(Of T) = i.NextItem
            i.NextItem = New Keyframe(Of T)
            i.NextItem.Data = InputData
            i.NextItem.Frame = CurrentFrame
            i.NextItem.NextItem = temp
            i.NextItem.InterpolationToNext = Type
        Else
            AddR(CurrentFrame, InputData, i.NextItem)
        End If
    End Sub

    Public Function GetKeyframe(Frame As UInteger) As Keyframe(Of T) 'gets the keyframe for the specified frame
        If Not IsNothing(Base) Then 'looks for if there is a keyframe for the specified frame
            If Base.Frame = Frame Then
                Return Base
            ElseIf Not Base.IsTail Then
                Return GetKeyframeR(Frame, Base)
            End If
        End If
        Return Nothing
    End Function
    Private Function GetKeyframeR(Frame As UInteger, i As Keyframe(Of T)) As Keyframe(Of T)
        'if there wasnt a keyframe for the specified frame, go through and find the space where it should have been and get the frame before it
        Dim temp As Keyframe(Of T)
        Try
            If i.Frame < Frame > i.NextItem.Frame Then
                temp = i
            End If
        Catch ex As Exception
        End Try
        If i.Frame < Frame And i.IsTail Then
            temp = i
        End If
        If IsNothing(temp) And Not i.IsTail Then
            temp = GetKeyframeR(Frame, i.NextItem)
        End If
        If IsNothing(temp) Then
            If i.Frame < Frame Then
                temp = i
            End If
        End If
        Return temp
    End Function
    Public Function GetKeyframes() As Keyframe(Of T)()
        Dim i As Keyframe(Of T) = Base
        Dim output As New List(Of Keyframe(Of T))
        If IsNothing(i) Then
            Return Nothing
        End If
        If Base.IsTail Then
            output.Add(Base)
            Return output.ToArray
        Else
            output.Add(Base)
            GetKeyframesR(Base.NextItem, output)
            Return output.ToArray
        End If

    End Function
    Public Function GetKeyframesR(ByRef i As Keyframe(Of T), ByVal output As List(Of Keyframe(Of T))) As List(Of Keyframe(Of T))
        If i.IsTail Then
            output.Add(i)
            Return output
        Else
            output.Add(i)
            Return GetKeyframesR(i.NextItem, output)
        End If
    End Function

    Public Sub DeleteKeyframe(Frame As UInteger) 'deletes the specified keyframe and shifts the list 
        Try
            If Base.Frame = Frame Then
                If Base.IsTail Then
                    Base = Nothing
                Else
                    Dim temp As Keyframe(Of T) = Base.NextItem
                    Base = temp
                End If
            Else
                DeleteKeyframeR(Frame, Base.NextItem)
            End If
        Catch ex As NullReferenceException
            MsgBox("Cannot delete keyframe, none exist", vbOKOnly, "Error!")
        End Try
    End Sub
    Private Sub DeleteKeyframeR(Frame As UInteger, ByRef i As Keyframe(Of T))
        If i.Frame = Frame Then
            If i.IsTail Then
                i = Nothing
            Else
                Dim temp As Keyframe(Of T) = i.NextItem
                i = temp
            End If
        Else
            DeleteKeyframeR(Frame, i.NextItem)
        End If
    End Sub

    Public Sub Draw(g As Graphics) 'draws the keyframes to the specifed graphics system
        If Not IsNothing(Base) Then
            Base.Draw(g)
            If Not Base.IsTail Then
                DrawR(g, Base.NextItem)
            End If
        End If
    End Sub
    Private Sub DrawR(g As Graphics, i As Keyframe(Of T))
        i.Draw(g)
        If Not i.IsTail Then
            DrawR(g, i.NextItem)
        End If
    End Sub


    Public Sub AddInterpolation(Frame As UInteger, Type As Interpolations)
        If Not Count < 2 Then
            AddInterpolationR(Frame, Type, Base)
        End If
    End Sub
    Private Sub AddInterpolationR(Frame As UInteger, Type As Interpolations, i As Keyframe(Of T))
        Try
            If i.Frame < Frame And Frame < i.NextItem.Frame Then
                i.InterpolationToNext = Type
            Else
                AddInterpolationR(Frame, Type, i.NextItem)
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub
End Class
