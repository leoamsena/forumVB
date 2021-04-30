Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim logado As Boolean = Funcionarios.makeLogin("", "")
        System.Diagnostics.Debug.WriteLine("logado?" & CStr(logado))

    End Sub
End Class