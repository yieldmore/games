Public Class Coin

    Public ReadOnly Property Color() As Drawing.Color
        Get
            Select Case _type
                Case ludo.BlockType.Blue
                    Return Drawing.Color.LightBlue
                Case ludo.BlockType.Green
                    Return Drawing.Color.LightGreen
                Case ludo.BlockType.Red
                    Return Drawing.Color.Magenta
                Case ludo.BlockType.Yellow
                    Return Drawing.Color.LightGoldenrodYellow
            End Select
        End Get
    End Property

    Public Sub New(ByVal type As BlockType)
        _type = type
    End Sub

    Public Index As Integer
    Public Block As Block

    Private _type As BlockType
    Public ReadOnly Property Type() As BlockType
        Get
            Return _type
        End Get
    End Property

End Class
