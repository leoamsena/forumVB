Public Class PostController
    Private db As PostDB

    Public Sub New()
        db = New PostDB()
    End Sub

    Public Function allPosts() As Post()
        Return db.searchPost()
    End Function
    Public Function insertPost(titulo As String, texto As String, funcionario As Integer)
        Return db.insertPost(New Post(titulo, texto, Date.Now(), New Funcionario(funcionario)))
    End Function

End Class
