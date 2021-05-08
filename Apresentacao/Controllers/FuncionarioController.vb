Imports System.Web.Mvc

<System.ComponentModel.DefaultEvent("newUserRegistered")>
Public Class FuncionarioController
    Private db = New FuncionarioDB()
    Private post = New PostController()
    Public Delegate Sub newUserEventHandler(source As Object, args As EventArgs)
    Public Event newUserRegistered As newUserEventHandler

    Public Sub New()
        AddHandler Me.newUserRegistered, AddressOf post.onNewUserRegistered
    End Sub

    Protected Overridable Sub onNewUserRegistered()

        RaiseEvent newUserRegistered(Me, EventArgs.Empty)
    End Sub
    Public Function makeLogin(login As String, password As String)
        Return db.makeAuth(login, Database.hash(password))
    End Function

    Public Function registerFunc(nome As String, CPF As String, email As String, password As String) As Boolean
        password = Database.hash(password)
        Dim func As Funcionario = New Funcionario(CPF, nome, email, password)
        Dim success = db.registerFunc(func)
        If (success) Then
            onNewUserRegistered()
        End If
        Return success
    End Function

End Class
