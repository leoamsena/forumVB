Public Class FuncionarioDB
    Inherits Database

    Public Function MakeAuthentication(login As String, password As String) As Funcionario
        Dim objConnection As OleDb.OleDbConnection = Conn
        Dim objCommand = MountCmd("Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ? ", objConnection, login, password)
        Dim queue = SearchRecords(objCommand, objConnection)
        Dim objFunc As Funcionario = Nothing
        If queue IsNot Nothing Then
            Dim result As Dictionary(Of String, String) = queue.Dequeue()
            objFunc = New Funcionario(result.Item("CPF"), result.Item("nome"), result.Item("email"), result.Item("password"), result.Item("id"))
        End If
        objConnection.Close()
        Return objFunc
    End Function


    Public Function RegisterFuncionario(func As Funcionario) As Boolean
        Dim objConnection = Conn
        Dim objCommand = MountCmd("INSERT INTO Funcionarios(nome,cpf,email,password) VALUES (?,?, ?,? )", objConnection, func.Name, func.Cpf, func.Email, func.Password)
        Return SaveRecord(objCommand, objConnection)
    End Function
End Class


