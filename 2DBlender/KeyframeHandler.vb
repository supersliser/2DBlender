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
        ElseIf i.Frame = CurrentFrame Then 'if it finds the frame is already present, replaces the associated data with the new keyframe data
            i.Data = InputData
        ElseIf i.Frame < CurrentFrame And CurrentFrame < i.NextItem.Frame Then 'if there is a space where the frame fits then it goes in there
            Dim temp As Keyframe(Of T) = i.NextItem
            i.NextItem = New Keyframe(Of T)
            i.NextItem.Data = InputData
            i.NextItem.Frame = CurrentFrame
            i.NextItem.NextItem = temp
        Else
            AddR(CurrentFrame, InputData, i.NextItem)
        End If
    End Sub

    Public Function GetKeyframe(Frame As UInteger) As Keyframe(Of T) 'gets the keyframe for the specified frame
        If Not IsNothing(Base) Then
            Dim finish As Boolean
            Dim i As Keyframe(Of T) = Base
            Do 'looks for if there is a keyframe for the specified frame
                If i.Frame = Frame Then
                    Return i
                ElseIf i.IsTail Then
                    finish = True
                Else
                    i = i.NextItem
                End If
            Loop Until finish
            Return GetKeyframeR(Frame, Base)
        End If
        Return Nothing
    End Function
    Private Function GetKeyframeR(Frame As UInteger, i As Keyframe(Of T)) As Keyframe(Of T)
        'if there wasnt a keyframe for the specified frame, go through and find the space where it should have been and get the frame before it
        Dim temp As Keyframe(Of T)
        If Not i.IsTail Then
            temp = GetKeyframeR(Frame, i.NextItem)
        End If
        If i.Frame < Frame Then
            If IsNothing(temp) Then
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
        Do
            output.Add(i)
            i = i.NextItem
        Loop Until i.IsTail
        Return output.ToArray
    End Function

    Public Function GetIndex(Frame As UInteger) As UInteger 'gets the index of the element of the specified frame
        Dim finish As Boolean
        Dim i As Keyframe(Of T) = Base
        Dim c As UInteger
        Do
            If i.Frame = Frame Then
                Return c
            ElseIf i.IsTail Then
                finish = True
            Else
                c += 1
                i = i.NextItem
            End If
        Loop Until finish
        Return Nothing
    End Function

    Public Sub DeleteKeyframe(Frame As UInteger) 'deletes the specified keyframe and shifts the list 
        Dim finish As Boolean
        Dim i As Keyframe(Of T) = Base
        Do
            If i.Frame = Frame Then
                i = i.NextItem
            ElseIf i.IsTail Then
                finish = True
            Else
                i = i.NextItem
            End If
        Loop Until finish
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
        If i.Frame < Frame And Frame < i.NextItem.Frame Then
            Dim temp As Keyframe(Of T) = i.NextItem
            Dim input As New Interpolation(Of T)
            input.Type = Type
            input.Frame = Frame
            i.NextItem = input
            i.NextItem.NextItem = temp
            'Try
            input.Key(i.Frame, New TPoint(CObj(i.Data)))
            'Catch ex As Exception
            '    input.Key(i.Frame, CObj(i.Data))
            'End Try
        Else
            AddInterpolationR(Frame, Type, i.NextItem)
        End If
    End Sub
End Class
