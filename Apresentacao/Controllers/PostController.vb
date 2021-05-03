Public Class PostController


    Public Shared Function allPosts() As Post()
        Return PostDB.searchPosts()
    End Function

End Class
