Public Class PostDB
    Inherits Database



    Public Function SearchPosts() As Post()
        Dim objConnection = Conn
        Dim objCommand As OleDb.OleDbCommand = MountCmd("Select p.*,f.nome FROM posts AS p INNER JOIN funcionarios AS F ON f.id = p.usuario ORDER BY data DESC", objConnection, Nothing)
        Dim objDict As Queue = SearchRecords(objCommand, objConnection)
        Dim arrPost As Post() = Nothing
        Dim numLength As Integer = 0
        For Each row As Dictionary(Of String, String) In objDict
            numLength += 1
            ReDim Preserve arrPost(numLength - 1)
            arrPost(numLength - 1) = New Post(row.Item("titulo"), row.Item("texto"), row.Item("data"), New Funcionario(row.Item("usuario")), row.Item("id"))
        Next
        Return arrPost

    End Function

    Public Function SavePost(post As Post) As Boolean
        Dim objConnection = Conn
        Dim objCommand = MountCmd("INSERT INTO posts(titulo,texto,data,usuario) VALUES (?,?, ?,? )", objConnection, post.Title, post.Text, post.PostDate, post.User.id)
        Return SaveRecord(objCommand, objConnection)
    End Function

End Class


