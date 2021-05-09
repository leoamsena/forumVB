Public Class PostController
    Private FPostDatabase As PostDB
    Friend WithEvents FMySender As FuncionarioController


    Public Sub New()
        FPostDatabase = New PostDB()
    End Sub

    Public Sub onNewUserRegistered(Source As Object, args As EventArgs) Handles FMySender.newUserRegistered
        Debug.WriteLine("novo")
        'Dim test As Integer = Nothing
        'FPostDatabase.SavePost(New Post("Novo usuário!", "Agora temos um novo usuário para contribuir conosco!", Date.Now(), New Funcionario(test)))
    End Sub
    Public Function GetAllPosts() As mdlPost()
        Return FPostDatabase.SearchPosts()
    End Function
    Public Function SavePost(titulo As String, texto As String, funcionario As Integer)
        Return FPostDatabase.SavePost(New mdlPost(titulo, texto, Date.Now(), New mdlFuncionario(funcionario)))
    End Function

End Class
