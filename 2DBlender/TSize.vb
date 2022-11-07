Public Structure TSize
    Private WidthW As Single 'world width
    Private HeightW As Single 'world height
    Private WidthG As UInteger 'grid width
    Private HeightG As UInteger 'grid height


    Public Sub New(WorldSize As SizeF, GridSize As Size) 'constructors based on various data
        Me.WorldSize = WorldSize
        Me.GridSize = GridSize
    End Sub
    Public Sub New(WorldWidth As UInteger, WorldHeight As UInteger, GridWidth As UInteger, GridHeight As UInteger)
        WidthW = WorldWidth
        HeightW = WorldHeight
        WidthG = GridWidth
        HeightG = GridHeight
    End Sub
    Public Sub New(GridWidth As UInteger, GridHeight As UInteger)
        WidthG = GridWidth
        HeightG = GridHeight
        WidthW = Main.Coordinates.ToWorld(New Point(GridWidth, GridHeight)).X
        HeightW = Main.Coordinates.ToWorld(New Point(GridWidth, GridHeight)).Y
    End Sub
    Public Sub New(GridSize As Size)
        WidthG = GridSize.Width
        HeightG = GridSize.Height
        WidthW = Main.Coordinates.ToWorld(GridSize).X
        HeightW = Main.Coordinates.ToWorld(GridSize).Y
    End Sub
    Public Sub New(WorldX As Single, WorldY As Single)
        WidthW = WorldX
        HeightW = WorldY
        WidthG = Main.Coordinates.ToGrid(New Point(WorldX, WorldY)).X
        HeightG = Main.Coordinates.ToGrid(New Point(WorldX, WorldY)).Y
    End Sub
    Public Sub New(WorldSize As SizeF)
        WidthW = WorldSize.Width
        HeightW = WorldSize.Height
        WidthG = Main.Coordinates.ToGrid(WorldSize).X
        HeightG = Main.Coordinates.ToGrid(WorldSize).Y
    End Sub

    'accesses the world version of the size
    Public Property WorldSize As SizeF
        Set(value As SizeF)
            WidthW = value.Width
            HeightW = value.Height
            WidthG = Main.Coordinates.ToGrid(WorldSize).X
            HeightG = Main.Coordinates.ToGrid(WorldSize).Y
        End Set
        Get
            Return New SizeF(WidthW, HeightW)
        End Get
    End Property
    Public Property WorldWidth As Single
        Set(value As Single)
            WidthW = value
            WidthG = Main.Coordinates.ToGrid(WorldSize).X
        End Set
        Get
            Return WidthW
        End Get
    End Property
    Public Property WorldHeight As Single
        Set(value As Single)
            HeightW = value
            HeightG = Main.Coordinates.ToGrid(WorldSize).Y
        End Set
        Get
            Return HeightW
        End Get
    End Property

    'accesses the grid version of the size
    Public Property GridSize As Size
        Set(value As Size)
            WidthG = value.Width
            HeightG = value.Height
            WidthW = Main.Coordinates.ToWorld(GridSize).X
            HeightW = Main.Coordinates.ToWorld(GridSize).Y
        End Set
        Get
            Return New Size(WidthG, HeightG)
        End Get
    End Property
    Public Property GridWidth As UInteger
        Set(value As UInteger)
            WidthG = value
            WidthW = Main.Coordinates.ToWorld(GridSize).X
        End Set
        Get
            Return WidthG
        End Get
    End Property
    Public Property GridHeight As UInteger
        Set(value As UInteger)
            HeightG = value
            HeightW = Main.Coordinates.ToWorld(GridSize).Y
        End Set
        Get
            Return HeightG
        End Get
    End Property


    Public Shared Operator +(A As TSize, B As TSize) As TSize 'controls interactions with different built in operators
        Return New TSize(A.WidthW + B.WidthW, A.HeightW + B.HeightW, A.WidthG + B.WidthG, A.HeightG + B.HeightG)
    End Operator
    Public Shared Operator +(A As TSize, Grid As Point) As TSize
        Return New TSize(CUInt(A.WidthG + Grid.X), CUInt(A.HeightG + Grid.Y))
    End Operator
    Public Shared Operator +(A As TSize, World As PointF) As TSize
        Return New TSize(A.WidthG + World.X, A.HeightG + World.Y)
    End Operator
    Public Shared Operator +(A As TSize, Grid As Size) As TSize
        Return New TSize(CUInt(A.WidthG + Grid.Width), CUInt(A.HeightG + Grid.Height))
    End Operator
    Public Shared Operator +(A As TSize, World As SizeF) As TSize
        Return New TSize(A.WidthG + World.Width, A.HeightG + World.Height)
    End Operator
    Public Shared Operator +(A As TSize, B As TPoint) As TSize
        Return New TSize(A.WorldWidth + B.WorldX, A.WorldHeight + B.WorldY, A.GridWidth + B.GridX, A.GridHeight + B.GridY)
    End Operator
    Public Shared Operator *(A As TSize, B As TSize) As TSize
        Return New TSize(A.WidthW * B.WidthW, A.HeightW * B.HeightW, A.WidthG * B.WidthG, A.HeightG * B.HeightG)
    End Operator
    Public Shared Operator *(A As TSize, Grid As Point) As TSize
        Return New TSize(CUInt(A.WidthG * Grid.X), CUInt(A.HeightG * Grid.Y))
    End Operator
    Public Shared Operator *(A As TSize, World As PointF) As TSize
        Return New TSize(A.WidthG * World.X, A.HeightG * World.Y)
    End Operator
    Public Shared Operator *(A As TSize, Grid As Size) As TSize
        Return New TSize(CUInt(A.WidthG * Grid.Width), CUInt(A.HeightG * Grid.Height))
    End Operator
    Public Shared Operator *(A As TSize, World As SizeF) As TSize
        Return New TSize(A.WidthG * World.Width, A.HeightG * World.Height)
    End Operator
    Public Shared Operator *(A As TSize, B As TPoint) As TSize
        Return New TSize(A.WorldWidth * B.WorldX, A.WorldHeight * B.WorldY, A.GridWidth * B.GridX, A.GridHeight * B.GridY)
    End Operator
    Public Shared Operator -(A As TSize, B As TSize) As TSize
        Return New TSize(A.WidthW - B.WidthW, A.HeightW - B.HeightW, A.WidthG - B.WidthG, A.HeightG - B.HeightG)
    End Operator
    Public Shared Operator -(A As TSize, Grid As Point) As TSize
        Return New TSize(CUInt(A.WidthG - Grid.X), CUInt(A.HeightG - Grid.Y))
    End Operator
    Public Shared Operator -(A As TSize, World As PointF) As TSize
        Return New TSize(A.WidthG - World.X, A.HeightG - World.Y)
    End Operator
    Public Shared Operator -(A As TSize, Grid As Size) As TSize
        Return New TSize(CUInt(A.WidthG - Grid.Width), CUInt(A.HeightG - Grid.Height))
    End Operator
    Public Shared Operator -(A As TSize, World As SizeF) As TSize
        Return New TSize(A.WidthG - World.Width, A.HeightG - World.Height)
    End Operator
    Public Shared Operator -(A As TSize, B As TPoint) As TSize
        Return New TSize(A.WorldWidth - B.WorldX, A.WorldHeight - B.WorldY, A.GridWidth - B.GridX, A.GridHeight - B.GridY)
    End Operator
    Public Shared Operator /(A As TSize, B As TSize) As TSize
        Return New TSize(A.WidthW / B.WidthW, A.HeightW / B.HeightW, A.WidthG / B.WidthG, A.HeightG / B.HeightG)
    End Operator
    Public Shared Operator /(A As TSize, Grid As Point) As TSize
        Return New TSize(CUInt(A.WidthG / Grid.X), CUInt(A.HeightG / Grid.Y))
    End Operator
    Public Shared Operator /(A As TSize, World As PointF) As TSize
        Return New TSize(A.WidthG / World.X, A.HeightG / World.Y)
    End Operator
    Public Shared Operator /(A As TSize, Grid As Size) As TSize
        Return New TSize(CUInt(A.WidthG / Grid.Width), CUInt(A.HeightG / Grid.Height))
    End Operator
    Public Shared Operator /(A As TSize, World As SizeF) As TSize
        Return New TSize(A.WidthG / World.Width, A.HeightG / World.Height)
    End Operator
    Public Shared Operator /(A As TSize, B As TPoint) As TSize
        Return New TSize(A.WorldWidth / B.WorldX, A.WorldHeight / B.WorldY, A.GridWidth / B.GridX, A.GridHeight / B.GridY)
    End Operator

    Public Shared Operator =(A As TSize, B As TSize) As Boolean
        If A.WidthW = B.WidthW And A.HeightW = B.HeightW Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator <>(A As TSize, B As TSize) As Boolean
        If A.WidthW = B.WidthW And A.HeightW = B.HeightW Then
            Return False
        Else
            Return True
        End If
    End Operator
    Public Shared Operator <(A As TSize, B As TSize) As Boolean
        If A.WidthW < B.WidthW And A.HeightW < B.HeightW Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator >(A As TSize, B As TSize) As Boolean
        If A.WidthW > B.WidthW And A.HeightW > B.HeightW Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator <=(A As TSize, B As TSize) As Boolean
        If A.WidthW <= B.WidthW And A.HeightW <= B.HeightW Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator >=(A As TSize, B As TSize) As Boolean
        If A.WidthW >= B.WidthW And A.HeightW >= B.HeightW Then
            Return True
        Else
            Return False
        End If
    End Operator
End Structure
