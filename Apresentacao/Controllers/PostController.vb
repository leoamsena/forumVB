Public Class PostController
    Private db As PostDB
    Friend WithEvents MySender As FuncionarioController


    Public Sub New()
        db = New PostDB()
    End Sub

    Public Sub onNewUserRegistered(Source As Object, args As EventArgs) Handles MySender.newUserRegistered
        Debug.WriteLine("novo")
        Dim test As Integer = Nothing
        db.insertPost(New Post("Novo usuário!", "Agora temos um novo usuário para contribuir conosco!", Date.Now(), New Funcionario(test)))
    End Sub
    Public Function allPosts() As Post()
        Return db.searchPost()
    End Function
    Public Function insertPost(titulo As String, texto As String, funcionario As Integer)
        Return db.insertPost(New Post(titulo, texto, Date.Now(), New Funcionario(funcionario)))
    End Function

End Class
