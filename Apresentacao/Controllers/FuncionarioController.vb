Imports System.Web.Mvc

<System.ComponentModel.DefaultEvent("newUserRegistered")>
Public Class FuncionarioController
    Private FFuncionarioDatabase = New FuncionarioDB()
    Private FPostController = New PostController()
    Public Delegate Sub newUserEventHandler(source As Object, args As EventArgs)
    Public Event newUserRegistered As newUserEventHandler

    Public Sub New()
        AddHandler Me.newUserRegistered, AddressOf FPostController.onNewUserRegistered
    End Sub

    Protected Overridable Sub onNewUserRegistered()

        RaiseEvent newUserRegistered(Me, EventArgs.Empty)
    End Sub
    Public Function MakeLogin(login As String, password As String)
        Return FFuncionarioDatabase.makeAuth(login, Database.GetHash(password))
    End Function

    Public Function RegisterFuncionario(nome As String, CPF As String, email As String, password As String) As Boolean
        password = Database.GetHash(password)
        Dim func As Funcionario = New Funcionario(CPF, nome, email, password)
        Dim success = FFuncionarioDatabase.registerFunc(func)
        If (success) Then
            onNewUserRegistered()
        End If
        Return success
    End Function

End Class
