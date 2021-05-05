Public Class FuncionarioDB
    Inherits Database

    Public Function makeAuth(login As String, password As String) As Funcionario
        Dim connection As OleDb.OleDbConnection = conn
        Dim cmd = mountCmd("Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ? ", connection, login, password)
        Dim queue = readData(cmd, connection)
        Dim objFunc As Funcionario = Nothing
        If queue IsNot Nothing Then
            Dim result As Dictionary(Of String, String) = queue.Dequeue()
            objFunc = New Funcionario(result.Item("CPF"), result.Item("nome"), result.Item("email"), result.Item("password"), result.Item("id"))
        End If
        connection.Close()
        Return objFunc
    End Function


    Public Function registerFunc(func As Funcionario) As Boolean
        Dim connection = conn
        Dim cmd = mountCmd("INSERT INTO Funcionarios(nome,cpf,email,password) VALUES (?,?, ?,? )", connection, func.nome, func.CPF, func.email, func.password)
        Return insertData(cmd, connection)
    End Function
End Class


