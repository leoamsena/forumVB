Imports System.Web.Mvc

Namespace Controllers

    Public Class FuncionarioController
        Private db = New FuncionarioDB()


        Public Function makeLogin(login As String, password As String)
            Return db.makeAuth(login, Database.hash(password))
        End Function

        Public Function registerFunc(nome As String, CPF As String, email As String, password As String) As Boolean
            password = Database.hash(password)
            Dim func As Funcionario = New Funcionario(CPF, nome, email, password)
            Return db.registerFunc(func)
        End Function

    End Class
End Namespace