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

    Public Function RegisterFuncionario(strFuncionarioName As String, strCpf As String, strEmail As String, strPassword As String) As Boolean
        strPassword = Database.GetHash(strPassword)
        Dim objFuncionario As mdlFuncionario = New mdlFuncionario(strCpf, strFuncionarioName, strEmail, strPassword)
        Dim blnSuccess = FFuncionarioDatabase.registerFunc(objFuncionario)
        If (blnSuccess) Then
            onNewUserRegistered()
        End If
        Return blnSuccess
    End Function

End Class
