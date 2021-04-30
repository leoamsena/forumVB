Public Class Funcionario
    Inherits Pessoa
    Private FEmail As String
    Private FPassword As String

    Public Sub New(CPF As String, Nome As String, Email As String, Password As String)
        MyBase.New(CPF, Nome)
        FEmail = Email
        FPassword = Password
    End Sub

End Class
