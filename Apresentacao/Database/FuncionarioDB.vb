Public Class FuncionarioDB
    Inherits Database

    Public Shared Function makeAuth(login As String, password As String) As Funcionario
        Dim connection As OleDb.OleDbConnection = conn
        Dim strSQL As String = "Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ? "
        Dim cmd As New OleDb.OleDbCommand(strSQL, connection)
        cmd.Parameters.Add("@email", OleDb.OleDbType.VarChar).Value = login
        cmd.Parameters.Add("@pass", OleDb.OleDbType.VarChar).Value = password
        connection.Open()
        Dim sqlReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim exists As Boolean = sqlReader.HasRows
        Dim objFunc As Funcionario = Nothing
        If exists Then
            sqlReader.Read()
            Dim values(5) As Object
            sqlReader.GetValues(values)
            Debug.WriteLine(values(0) & " " & values(4).ToString)
            objFunc = New Funcionario(values(1).ToString, values(0).ToString, values(2).ToString, password, Val(values(4).ToString))
        End If
        connection.Close()
        Return objFunc
    End Function


    Public Shared Function registerFunc(func As Funcionario) As Boolean
        Dim connection As OleDb.OleDbConnection = conn
        Dim strSQL As String = "INSERT INTO Funcionarios(nome,cpf,email,password) VALUES (?,?, ?,? )"
        Dim cmd As New OleDb.OleDbCommand(strSQL, connection)

        cmd.Parameters.Add("@nome", OleDb.OleDbType.VarChar).Value = func.getNome
        cmd.Parameters.Add("@cpf", OleDb.OleDbType.VarChar).Value = func.getCPF
        cmd.Parameters.Add("@email", OleDb.OleDbType.VarChar).Value = func.email
        cmd.Parameters.Add("@password", OleDb.OleDbType.VarChar).Value = func.password

        connection.Open()
        Dim icount As Integer
        icount = cmd.ExecuteNonQuery()
        connection.Close()
        Return icount >= 1
    End Function
End Class


