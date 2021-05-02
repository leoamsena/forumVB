Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Not IsNothing(HttpContext.Current.Session("autenticado"))) AndAlso HttpContext.Current.Session("autenticado").ToString() = "OK" Then
            HttpContext.Current.Response.Redirect("Main.aspx")
        Else
            Debug.WriteLine(CStr(IsNothing(HttpContext.Current.Session("autenticado"))) & " - ")
        End If
    End Sub



    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim objFunc As Funcionario = Controllers.FuncionarioController.makeLogin(Login1.UserName, Login1.Password)
        If Not IsNothing(objFunc) Then
            Session("autenticado") = "OK"
            Session("functionario") = objFunc
            Response.Redirect("Main.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim reg As Boolean = Controllers.FuncionarioController.registerFunc(rgNome.Text, rgCPF.Text, rgEmail.Text, rgPass.Text)

            If reg Then
                rgMsg.Text = "Registrado com sucesso! Faça login! "
            Else
                Throw New Exception("Erro desconhecido!")
            End If
        Catch ex As Exception
            rgMsg.Text = "Erro " + ex.Message + " ao registrar!"
        End Try
    End Sub
End Class