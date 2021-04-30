Public Class Funcionarios
    Public Shared Function makeLogin(login As String, password As String) As Boolean
        Dim conn As OleDb.OleDbConnection = Database.getConn
        Dim strSQL As String = "Select * FROM Funcionarios WHERE email = ? AND password = ? "
        Dim cmd As New OleDb.OleDbCommand(strSQL, conn)
        cmd.Parameters.Add("@email", OleDb.OleDbType.VarChar).Value = "leo@leo.com"
        cmd.Parameters.Add("@pass", OleDb.OleDbType.VarChar).Value = "pass"
        conn.Open()
        Dim sqlReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim exists As Boolean = sqlReader.HasRows
        conn.Close()
        Return exists
    End Function
End Class
