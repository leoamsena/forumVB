Public Class PostDB
    Public Shared Function searchPosts() As Post()
        Dim conn As OleDb.OleDbConnection = Database.getConn
        Dim strSQL As String = "Select p.*,f.nome FROM posts AS p INNER JOIN funcionarios AS F ON f.id = p.usuario ORDER BY data "
        Dim cmd As New OleDb.OleDbCommand(strSQL, conn)

        conn.Open()
        Dim sqlReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim exists As Boolean = sqlReader.HasRows

        Dim arrPost As Post() = Nothing
        Dim tam As Integer = 0


        While sqlReader.Read()
            tam += 1
            ReDim Preserve arrPost(tam - 1)

            Dim values(6) As Object
            sqlReader.GetValues(values)
            arrPost(tam - 1) = New Post(values(1).ToString, values(2).ToString, values(3).ToString, New Funcionario(values(5).ToString), values(0).ToString)

        End While
        conn.Close()
        Return arrPost
    End Function
    Public Shared Function insertPost(post As Post) As Boolean
        Dim conn As OleDb.OleDbConnection = Database.getConn
        Dim strSQL As String = "INSERT INTO posts(titulo,texto,data,usuario) VALUES (?,?, ?,? )"
        Dim cmd As New OleDb.OleDbCommand(strSQL, conn)

        Debug.WriteLine(post.usuario.getId)

        cmd.Parameters.Add("@titulo", OleDb.OleDbType.VarChar).Value = post.title
        cmd.Parameters.Add("@text", OleDb.OleDbType.VarChar).Value = post.text
        cmd.Parameters.Add("@data", OleDb.OleDbType.VarChar).Value = post.postDate
        cmd.Parameters.Add("@usuario", OleDb.OleDbType.VarChar).Value = post.usuario.getId

        conn.Open()
        Dim icount As Integer
        icount = cmd.ExecuteNonQuery()
        conn.Close()
        Return icount >= 1
    End Function
End Class


