Public Class FuncionarioDB
    Inherits Database

    Public Function MakeAuthentication(login As String, password As String) As Funcionario
        Dim objConnection As OleDb.OleDbConnection = Conn
        Dim objCommand = MountCmd("Select TOP 1 * FROM TB_FUNCIONARIO WHERE Email = ? AND Password = ? ", objConnection, login, password)
        Dim queue = SearchRecords(objCommand, objConnection)
        Dim objFunc As Funcionario = Nothing
        If queue IsNot Nothing Then
            Dim result As Dictionary(Of String, String) = queue.Dequeue()
            objFunc = New Funcionario(result.Item("CPF"), result.Item("Name"), result.Item("Email"), result.Item("Password"), result.Item("Id"))
        End If
        objConnection.Close()
        Return objFunc
    End Function


    Public Function RegisterFuncionario(func As Funcionario) As Boolean
        Dim objConnection = Conn
        Dim objCommand = MountCmd("INSERT INTO TB_FUNCIONARIO(Name,Cpf,Email,Password) VALUES (?,?, ?,? )", objConnection, func.Name, func.Cpf, func.Email, func.Password)
        Return SaveRecord(objCommand, objConnection)
    End Function
End Class


