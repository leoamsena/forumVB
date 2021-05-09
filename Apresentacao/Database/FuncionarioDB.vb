Public Class FuncionarioDB
    Inherits Database

    Public Function MakeAuthentication(login As String, password As String) As Funcionario
        Dim connection As OleDb.OleDbConnection = Conn
        Dim cmd = MountCmd("Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ? ", connection, login, password)
        Dim queue = SearchRecords(cmd, connection)
        Dim objFunc As Funcionario = Nothing
        If queue IsNot Nothing Then
            Dim result As Dictionary(Of String, String) = queue.Dequeue()
            objFunc = New Funcionario(result.Item("CPF"), result.Item("nome"), result.Item("email"), result.Item("password"), result.Item("id"))
        End If
        connection.Close()
        Return objFunc
    End Function


    Public Function RegisterFuncionario(func As Funcionario) As Boolean
        Dim connection = Conn
        Dim cmd = MountCmd("INSERT INTO Funcionarios(nome,cpf,email,password) VALUES (?,?, ?,? )", connection, func.Name, func.Cpf, func.Email, func.Password)
        Return SaveRecord(cmd, connection)
    End Function
End Class


