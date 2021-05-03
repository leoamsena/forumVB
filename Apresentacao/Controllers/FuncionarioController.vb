Imports System.Web.Mvc

Namespace Controllers
    Public Class FuncionarioController


        Public Shared Function makeLogin(login As String, password As String)
            Return FuncionarioDB.makeAuth(login, Database.hash(password))
        End Function

        Public Shared Function registerFunc(nome As String, CPF As String, email As String, password As String) As Boolean
            password = Database.hash(password)
            Dim func As Funcionario = New Funcionario(CPF, nome, email, password)
            Return FuncionarioDB.registerFunc(func)
        End Function

    End Class
End Namespace