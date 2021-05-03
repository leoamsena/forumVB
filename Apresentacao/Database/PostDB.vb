Public Class PostDB
    Public Shared Function searchPosts() As Post()
        Dim conn As OleDb.OleDbConnection = Database.getConn
        Dim strSQL As String = "Select p.*,f.nome FROM posts AS p INNER JOIN funcionarios AS F ON f.id = p.usuario ORDER BY data "
        Dim cmd As New OleDb.OleDbCommand(strSQL, conn)

        conn.Open()
        Dim sqlReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim exists As Boolean = sqlReader.HasRows

        Dim arrPost As Post() = Nothing

        If exists Then
            ReDim arrPost(0)
        End If

        While sqlReader.Read()
            ReDim arrPost(arrPost.Length + 1)

            Dim values(5) As Object
            sqlReader.GetValues(values)
            arrPost(arrPost.Length - 1) = New Post(values(1).ToString, values(2).ToString, values(3).ToString, New Funcionario(values(5).ToString))
        End While
        conn.Close()
        Return arrPost
    End Function
End Class
