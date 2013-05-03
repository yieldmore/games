Public Structure Block

    Public Overrides Function ToString() As String
        Return String.Format("", X, Y)
    End Function

    Private _x As Integer

    Property X() As Integer
        Get
            Return _x
        End Get
        Set(ByVal value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer

    Property Y() As Integer
        Get
            Return _y
        End Get
        Set(ByVal value As Integer)
            _y = value
        End Set
    End Property

    Private _blockType As BlockType

    Property Type() As BlockType
        Get
            Return _blockType
        End Get
        Set(ByVal value As BlockType)
            _blockType = value
        End Set
    End Property

    Public ReadOnly Property Color() As Drawing.Color
        Get
            Select Case _blockType
                Case ludo.BlockType.Blue
                    Return Drawing.Color.Blue
                Case ludo.BlockType.Default
                    Return SystemColors.ControlDark
                Case ludo.BlockType.Green
                    Return Drawing.Color.Green
                Case ludo.BlockType.Red
                    Return Drawing.Color.Red
                Case ludo.BlockType.Yellow
                    Return Drawing.Color.Yellow
                Case ludo.BlockType.Home
                    Return Drawing.Color.White
            End Select
        End Get
    End Property

End Structure
