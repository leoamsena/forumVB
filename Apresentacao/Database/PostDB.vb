Public Class PostDB
    Inherits Database



    Public Function SearchPosts() As Post()
        Dim connection = Conn
        Dim cmd As OleDb.OleDbCommand = MountCmd("Select p.*,f.nome FROM posts AS p INNER JOIN funcionarios AS F ON f.id = p.usuario ORDER BY data DESC", connection, Nothing)
        Dim objDict As Queue = SearchRecords(cmd, connection)
        Dim arrPost As Post() = Nothing
        Dim tam As Integer = 0
        For Each row As Dictionary(Of String, String) In objDict
            tam += 1
            ReDim Preserve arrPost(tam - 1)
            arrPost(tam - 1) = New Post(row.Item("titulo"), row.Item("texto"), row.Item("data"), New Funcionario(row.Item("usuario")), row.Item("id"))
        Next
        Return arrPost

    End Function

    Public Function SavePost(post As Post) As Boolean
        Dim connection = Conn
        Dim cmd = MountCmd("INSERT INTO posts(titulo,texto,data,usuario) VALUES (?,?, ?,? )", connection, post.Title, post.Text, post.PostDate, post.User.id)
        Return SaveRecord(cmd, connection)
    End Function

End Class


