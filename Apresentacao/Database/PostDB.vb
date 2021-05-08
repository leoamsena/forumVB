Public Class PostDB
    Inherits Database



    Public Function searchPost() As Post()
        Dim connection = conn
        Dim cmd As OleDb.OleDbCommand = mountCmd("Select p.*,f.nome FROM posts AS p INNER JOIN funcionarios AS F ON f.id = p.usuario ORDER BY data DESC", connection, Nothing)
        Dim objDict As Queue = readData(cmd, connection)
        Dim arrPost As Post() = Nothing
        Dim tam As Integer = 0
        For Each row As Dictionary(Of String, String) In objDict
            tam += 1
            ReDim Preserve arrPost(tam - 1)
            arrPost(tam - 1) = New Post(row.Item("titulo"), row.Item("texto"), row.Item("data"), New Funcionario(row.Item("usuario")), row.Item("id"))
        Next
        Return arrPost

    End Function

    Public Function insertPost(post As Post) As Boolean
        Dim connection = conn
        Dim cmd = mountCmd("INSERT INTO posts(titulo,texto,data,usuario) VALUES (?,?, ?,? )", connection, post.title, post.text, post.postDate, post.usuario.id)
        Return insertData(cmd, connection)
    End Function

End Class


