Public Class Board

    Private _blocks, reds, greens, blues, yellows As List(Of Block)

    Private _homeIndex As Integer

    Public ReadOnly Property HomeIndex() As Integer
        Get
            Return _homeIndex
        End Get
    End Property


    Public ReadOnly Property Blocks() As List(Of Block)
        Get
            Return _blocks
        End Get
    End Property

    Public Function InsertCoin(ByVal type As BlockType) As Coin
        Dim c As New Coin(type)
        c.Index = -1
        AdvanceCoin(c, 1)
        Return c
    End Function

    Public Function AdvanceCoin(ByVal coin As Coin, ByVal paces As Integer) As Boolean
        If coin.Index + paces >= HomeIndex Then
            Return False
        Else
            coin.Index += paces
            Dim l As List(Of Block)
            Select Case coin.Type
                Case BlockType.Blue
                    l = blues
                Case BlockType.Green
                    l = greens
                Case BlockType.Red
                    l = reds
                Case Else
                    l = yellows
            End Select
            coin.Block = l.ToArray()(coin.Index)
            Return True
        End If
    End Function

    Public Sub New()
        _blocks = New List(Of Block)
        _blocks.Clear()


        Dim b As New BlockBuilder(13, 1)

        _blocks.AddRange(b.GetBlocks(BlockType.Default, -1, 0, 2))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, 1, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, -1, 0, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, 1, 2))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 1, 0, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, 1, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 1, 0, 2))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, -1, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 1, 0, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, -1, 2))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, -1, 0, 10))
        _blocks.AddRange(b.GetBlocks(BlockType.Default, 0, -1, 10))

        Dim red As Block() = New BlockBuilder(12, 1).GetBlocks(BlockType.Red, 0, 1, 10)
        Dim yellow As Block() = New BlockBuilder(1, 12).GetBlocks(BlockType.Yellow, 1, 0, 10)
        Dim green As Block() = New BlockBuilder(12, 23).GetBlocks(BlockType.Green, 0, -1, 10)
        Dim blue As Block() = New BlockBuilder(23, 12).GetBlocks(BlockType.Blue, -1, 0, 10)
        Dim home As Block() = New BlockBuilder(12, 12).GetBlocks(BlockType.Home, 0, 0, 1)

        Dim start As Block

        reds = _blocks.GetRange(0, 88)
        reds.AddRange(reds.GetRange(0, 1).ToArray())
        reds.AddRange(red)
        reds.AddRange(home)
        reds.InsertRange(0, _blocks.GetRange(87, 1).ToArray())

        yellows = _blocks.GetRange(22, 66)
        yellows.AddRange(_blocks.GetRange(0, 22).ToArray())
        yellows.AddRange(yellows.GetRange(0, 1).ToArray())
        yellows.AddRange(yellow)
        yellows.AddRange(home)
        yellows.InsertRange(0, _blocks.GetRange(21, 1).ToArray())

        greens = _blocks.GetRange(44, 44)
        greens.AddRange(_blocks.GetRange(0, 44).ToArray())
        greens.AddRange(greens.GetRange(0, 1).ToArray())
        greens.AddRange(green)
        greens.AddRange(home)
        greens.InsertRange(0, _blocks.GetRange(43, 1).ToArray())

        blues = _blocks.GetRange(66, 22)
        blues.AddRange(_blocks.GetRange(0, 66).ToArray())
        blues.AddRange(blues.GetRange(0, 1).ToArray())
        blues.AddRange(blue)
        blues.AddRange(home)
        blues.InsertRange(0, _blocks.GetRange(65, 1).ToArray())

        start = New Block : start.X = 14 : start.Y = 1 : start.Type = BlockType.Red
        reds.Insert(0, start) : _blocks.Add(start)

        start = New Block : start.X = 10 : start.Y = 23 : start.Type = BlockType.Green
        greens.Insert(0, start) : _blocks.Add(start)

        start = New Block : start.X = 1 : start.Y = 10 : start.Type = BlockType.Yellow
        yellows.Insert(0, start) : _blocks.Add(start)

        start = New Block : start.X = 23 : start.Y = 14 : start.Type = BlockType.Blue
        blues.Insert(0, start) : _blocks.Add(start)

        _homeIndex = reds.Count

        _blocks.AddRange(red)
        _blocks.AddRange(yellow)
        _blocks.AddRange(green)
        _blocks.AddRange(blue)
        _blocks.AddRange(home)



    End Sub

    Private Class BlockBuilder
        Private _x, _y As Integer

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            _x = x : _y = y
        End Sub

        Public Function GetBlocks(ByVal type As BlockType, ByVal dX As Integer, ByVal dY As Integer, ByVal count As Integer) As Block()
            Dim list As New List(Of Block)
            While count > 0
                _x += dX : _y += dY
                Dim b As New Block
                b.Type = type
                b.X = _x : b.Y = _y
                list.Add(b)
                count += -1
            End While
            Return list.ToArray()
        End Function

    End Class

End Class
