Public Class LudoScreen

    Dim board As New Board, coins As List(Of Coin)
    Dim currentPlayer As Integer
    Dim currentRound As Round

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Reset_Click(Nothing, EventArgs.Empty)

        Dim items As New List(Of Object)
        For Each o As Object In [Enum].GetValues(BlockType.Blue.GetType())
            items.Add(o)
        Next
        items.RemoveAt(items.Count - 1)
        Path.Items.AddRange(items.ToArray())

        items.RemoveAt(0)
        For Each b As BlockType In items
            Dim col As New ColumnHeader
            col.Text = b.ToString().Substring(0, 1)
            col.Tag = b
            col.Width = 46
            Rounds.Columns.Add(col)
        Next
        Rounds.Columns.Insert(0, "Rd.", 40, HorizontalAlignment.Left)

        Path.SelectedIndex = 1
    End Sub

    Private Sub LudoScreen_Paint(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.Clear(System.Drawing.SystemColors.Control)


        Dim size As Integer = Math.Min(ClientSize.Height, ClientSize.Width) / 25

        For Each el As Block In board.Blocks
            Dim b As New SolidBrush(el.Color)
            e.Graphics.FillRectangle(b, el.X * size, el.Y * size, size - 3, size - 3)
        Next

        For Each c As Coin In coins
            Dim b As New SolidBrush(c.Color)
            e.Graphics.FillRectangle(b _
                , c.Block.X * size + 3, c.Block.Y * size + 3 _
                , size - 9, size - 9)
        Next

        Dim t As BlockType = Path.SelectedItem
        If (t <> BlockType.Default) Then
            Dim c As New Coin(t)
            'board.AdvanceCoin(c, 2)
            Dim b As New SolidBrush(Color.Black)
            For i As Integer = 1 To board.HomeIndex - 1
                board.AdvanceCoin(c, 1)
                e.Graphics.DrawString(i, Me.Font, Brushes.Black, _
                    c.Block.X * size, c.Block.Y * size + 2)
            Next
        End If


    End Sub

    Private Sub LudoScreen_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Refresh()
    End Sub

    Private Sub Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Play.Click
pass_play:
        If currentPlayer = 4 Then
            currentPlayer = 1
            currentRound = New Round(currentRound.RoundIndex + 1)
            Rounds.Items.Add(currentRound)
            currentRound.EnsureVisible()
        Else
            currentPlayer += 1
        End If

        Dim c As Coin = coins(currentPlayer - 1)
        Dim die1Value As Integer = New Random(DateTime.Now.Millisecond).Next(1, 6)
        Dim die2Value As Integer = New Random(die1Value).Next(1, 6)

        If (c.Index > 90) Then
            Die2.Visible = False
            die2Value = 0
        Else
            Die2.Visible = True
        End If

        Dim dieTotal = die1Value + die2Value

        If Path.SelectedIndex <> 0 Then
            Path.SelectedItem = c.Type
        End If

        Dim playerName As String = [Enum].GetName(c.Type.GetType(), c.Type)
        If board.HomeIndex.Equals(c.Index + 1) Then
            GoTo pass_play
        Else
            Die1.BackgroundImage = Dice.Images(die1Value - 1)
            If Die2.Visible Then
                Die2.BackgroundImage = Dice.Images(die2Value - 1)
            End If

            If board.AdvanceCoin(c, dieTotal) = False Then
                MessageBox.Show(String.Format("Unable to move {0} forward {1} places", playerName, dieTotal))
            Else
                currentRound.Play(c, dieTotal)
                Me.Refresh()
            End If
            'Info.Text = String.Format("Ply: {1}{0}Die: {2}{0}Pos: {3}", vbCrLf, playerName, die, c.Index)
            End If

            If coins(0).Index.Equals(coins(1).Index) _
                And coins(2).Index.Equals(coins(3).Index) _
                And coins(1).Index.Equals(coins(2).Index) _
                And coins(0).Index.Equals(board.HomeIndex - 1) Then
                Play.Enabled = False
            End If
    End Sub

    Private Sub Path_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Path.SelectedIndexChanged
        Me.Invalidate()
    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click
        Die1.Image = Nothing

        currentPlayer = 0
        coins = New List(Of Coin)
        coins.Add(board.InsertCoin(BlockType.Red))
        coins.Add(board.InsertCoin(BlockType.Blue))
        coins.Add(board.InsertCoin(BlockType.Green))
        coins.Add(board.InsertCoin(BlockType.Yellow))

        Rounds.Items.Clear()
        currentRound = New Round(1)
        Rounds.Items.Add(currentRound)

        Play.Enabled = True

        Me.Invalidate()
    End Sub

End Class
