Public Class Round
    Inherits ListViewItem

    Private _index As Integer

    Public ReadOnly Property RoundIndex() As Integer
        Get
            Return _index
        End Get
    End Property

    Sub New(ByVal index As Integer)
        _index = index
        Me.Text = _index
        Me.SubItems.AddRange(New String() {"", "", "", ""})
    End Sub

    Public Sub Play(ByVal coin As Coin, ByVal moves As Integer)
        Dim column As ColumnHeader = Nothing
        For Each col As ColumnHeader In Me.ListView.Columns
            If coin.Type.Equals(col.Tag) Then
                column = col
                Exit For
            End If
        Next
        If Not column Is Nothing Then
            SubItems(column.Index).Text = _
                String.Format("{0} [{1}]", _
                coin.Index, moves)
        End If
    End Sub

End Class
