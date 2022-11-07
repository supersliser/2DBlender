Public Structure TPoint
    Private WX As Single 'world X coordinate
    Private WY As Single 'world Y coordinate
    Private GX As UInteger 'grid X coordinate
    Private GY As UInteger 'grid Y coorindate


    Public Sub New(WorldLocation As PointF, GridLocation As Point) 'constructors based on various data
        Me.WorldLocation = WorldLocation
        Me.GridLocation = GridLocation
    End Sub
    Public Sub New(WorldX As UInteger, WorldY As UInteger, GridX As UInteger, GridY As UInteger)
        WX = WorldX
        WY = WorldY
        GX = GridX
        GY = GridY
    End Sub
    Public Sub New(GridX As UInteger, GridY As UInteger)
        GX = GridX
        GY = GridY
        WX = Main.Coordinates.ToWorld(New Point(GridX, GridY)).X
        WY = Main.Coordinates.ToWorld(New Point(GridX, GridY)).Y
    End Sub
    Public Sub New(GridLocation As Point)
        Try
            GX = GridLocation.X
        Catch ex As OverflowException
            GX = 0
        End Try
        Try
            GY = GridLocation.Y
        Catch ex As OverflowException
            GY = 0
        End Try
        WX = Main.Coordinates.ToWorld(GridLocation).X
        WY = Main.Coordinates.ToWorld(GridLocation).Y
    End Sub
    Public Sub New(WorldX As Single, WorldY As Single)
        WX = WorldX
        WY = WorldY
        GX = Main.Coordinates.ToGrid(New Point(WorldX, WorldY)).X
        GY = Main.Coordinates.ToGrid(New Point(WorldX, WorldY)).Y
    End Sub
    Public Sub New(WorldLocation As PointF)
        WX = WorldLocation.X
        WY = WorldLocation.Y
        GX = Main.Coordinates.ToGrid(WorldLocation).X
        GY = Main.Coordinates.ToGrid(WorldLocation).Y
    End Sub
    Public Sub New(Input As Object)
        WX = Input.WorldX
        WY = Input.WorldY
        GX = Input.GridX
        GY = Input.GridY
    End Sub

    'accesses the world coordinate of the point
    Public Property WorldLocation As PointF
        Set(value As PointF)
            WX = value.X
            WY = value.Y
            GX = Main.Coordinates.ToGrid(WorldLocation).X
            GY = Main.Coordinates.ToGrid(WorldLocation).Y
        End Set
        Get
            Return New Point(WX, WY)
        End Get
    End Property
    Public Property WorldX As Single
        Set(value As Single)
            WX = value
            GX = Main.Coordinates.ToGrid(WorldLocation).X
        End Set
        Get
            Return WX
        End Get
    End Property
    Public Property WorldY As Single
        Set(value As Single)
            WY = value
            GY = Main.Coordinates.ToGrid(WorldLocation).Y
        End Set
        Get
            Return WY
        End Get
    End Property

    'accesses the grid coordinate of the point
    Public Property GridLocation As Point
        Set(value As Point)
            GX = value.X
            GY = value.Y
            WX = Main.Coordinates.ToWorld(GridLocation).X
            WY = Main.Coordinates.ToWorld(GridLocation).Y
        End Set
        Get
            Return New Point(GX, GY)
        End Get
    End Property
    Public Property GridX As UInteger
        Set(value As UInteger)
            GX = value
            WX = Main.Coordinates.ToWorld(GridLocation).X
        End Set
        Get
            Return GX
        End Get
    End Property
    Public Property GridY As UInteger
        Set(value As UInteger)
            GY = value
            WY = Main.Coordinates.ToWorld(GridLocation).Y
        End Set
        Get
            Return GY
        End Get
    End Property


    Public Shared Operator +(A As TPoint, B As TPoint) As TPoint 'controls interactions with different built in operators
        Return New TPoint(A.WX + B.WX, A.WY + B.WY, A.GX + B.GX, A.GY + B.GY)
    End Operator
    Public Shared Operator +(A As TPoint, Grid As Point) As TPoint
        Return New TPoint(CUInt(A.GX + Grid.X), CUInt(A.GY + Grid.Y))
    End Operator
    Public Shared Operator +(A As TPoint, World As PointF) As TPoint
        Return New TPoint(A.GX + World.X, A.GY + World.Y)
    End Operator
    Public Shared Operator +(A As TPoint, Grid As Size) As TPoint
        Return New TPoint(CUInt(A.GX + Grid.Width), CUInt(A.GY + Grid.Height))
    End Operator
    Public Shared Operator +(A As TPoint, World As SizeF) As TPoint
        Return New TPoint(A.GX + World.Width, A.GY + World.Height)
    End Operator
    Public Shared Operator +(A As TPoint, B As TSize) As TPoint
        Return New TPoint(A.WX + B.WorldWidth, A.WY + B.WorldHeight, A.GX + B.GridWidth, A.GY + B.GridHeight)
    End Operator
    Public Shared Operator *(A As TPoint, B As TPoint) As TPoint
        Return New TPoint(A.WX * B.WX, A.WY * B.WY, A.GX * B.GX, A.GY * B.GY)
    End Operator
    Public Shared Operator *(A As TPoint, Grid As Point) As TPoint
        Return New TPoint(CUInt(A.GX * Grid.X), CUInt(A.GY * Grid.Y))
    End Operator
    Public Shared Operator *(A As TPoint, World As PointF) As TPoint
        Return New TPoint(A.GX * World.X, A.GY * World.Y)
    End Operator
    Public Shared Operator *(A As TPoint, Grid As Size) As TPoint
        Return New TPoint(CUInt(A.GX * Grid.Width), CUInt(A.GY * Grid.Height))
    End Operator
    Public Shared Operator *(A As TPoint, World As SizeF) As TPoint
        Return New TPoint(A.GX * World.Width, A.GY * World.Height)
    End Operator
    Public Shared Operator *(A As TPoint, B As TSize) As TPoint
        Return New TPoint(A.WX * B.WorldWidth, A.WY * B.WorldHeight, A.GX * B.GridWidth, A.GY * B.GridHeight)
    End Operator
    Public Shared Operator -(A As TPoint, B As TPoint) As TPoint
        Return New TPoint(A.WX - B.WX, A.WY - B.WY, A.GX - B.GX, A.GY - B.GY)
    End Operator
    Public Shared Operator -(A As TPoint, Grid As Point) As TPoint
        Return New TPoint(CUInt(A.GX - Grid.X), CUInt(A.GY - Grid.Y))
    End Operator
    Public Shared Operator -(A As TPoint, World As PointF) As TPoint
        Return New TPoint(A.GX - World.X, A.GY - World.Y)
    End Operator
    Public Shared Operator -(A As TPoint, Grid As Size) As TPoint
        Return New TPoint(CUInt(A.GX - Grid.Width), CUInt(A.GY - Grid.Height))
    End Operator
    Public Shared Operator -(A As TPoint, World As SizeF) As TPoint
        Return New TPoint(A.GX - World.Width, A.GY - World.Height)
    End Operator
    Public Shared Operator -(A As TPoint, B As TSize) As TPoint
        Return New TPoint(A.WX - B.WorldWidth, A.WY - B.WorldHeight, A.GX - B.GridWidth, A.GY - B.GridHeight)
    End Operator
    Public Shared Operator /(A As TPoint, B As TPoint) As TPoint
        Return New TPoint(A.WX / B.WX, A.WY / B.WY, A.GX / B.GX, A.GY / B.GY)
    End Operator
    Public Shared Operator /(A As TPoint, Grid As Point) As TPoint
        Return New TPoint(CUInt(A.GX / Grid.X), CUInt(A.GY / Grid.Y))
    End Operator
    Public Shared Operator /(A As TPoint, World As PointF) As TPoint
        Return New TPoint(A.GX / World.X, A.GY / World.Y)
    End Operator
    Public Shared Operator /(A As TPoint, Grid As Size) As TPoint
        Return New TPoint(CUInt(A.GX / Grid.Width), CUInt(A.GY / Grid.Height))
    End Operator
    Public Shared Operator /(A As TPoint, World As SizeF) As TPoint
        Return New TPoint(A.GX / World.Width, A.GY / World.Height)
    End Operator
    Public Shared Operator /(A As TPoint, B As TSize) As TPoint
        Return New TPoint(A.WX / B.WorldWidth, A.WY / B.WorldHeight, A.GX / B.GridWidth, A.GY / B.GridHeight)
    End Operator

    Public Shared Operator =(A As TPoint, B As TPoint) As Boolean
        If A.WX = B.WX And A.WY = B.WY Then
            Return True
        Else
            Return False
        End If
    End Operator
    Public Shared Operator <>(A As TPoint, B As TPoint) As Boolean
        If A.WX = B.WX And A.WY = B.WY Then
            Return False
        Else
            Return True
        End If
    End Operator
End Structure
