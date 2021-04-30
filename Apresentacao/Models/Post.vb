Public MustInherit Class Post
    Private FPostDate As DateTime
    Private FTitle As String
    Private FText As String
    Private FUsuario As Funcionario

    Public Sub New(Title As String, Text As String, PDate As DateTime, Funcionario As Funcionario)
        FPostDate = PDate
        FTitle = Title
        FText = Text
        FUsuario = Funcionario
    End Sub
End Class
