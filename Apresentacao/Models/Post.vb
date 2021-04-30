Public MustInherit Class Post
    Private FPostDate As DateTime
    Private FTitle As String
    Private FText As String

    Public Sub New(Title As String, Text As String, PDate As DateTime)
        FPostDate = PDate
        FTitle = Title
        FText = Text
    End Sub
End Class
