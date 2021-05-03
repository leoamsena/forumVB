Public Class PostController


    Public Shared Function allPosts() As Post()
        Return PostDB.searchPosts()
    End Function
    Public Shared Function insertPost(titulo As String, texto As String, funcionario As Integer)
        Debug.WriteLine(funcionario)
        Return PostDB.insertPost(New Post(titulo, texto, Date.Now(), New Funcionario(funcionario)))
    End Function

End Class
