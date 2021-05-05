Public Class _Default
    Inherits Page

    Private funcionarioController As Controllers.FuncionarioController

    Public Sub New()
        funcionarioController = New Controllers.FuncionarioController()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Application("visitas") = Nothing Then
            Application("visitas") = 1
        Else
            Application("visitas") += 1
        End If
        lblVisits.Text = "Visitas a essa página: " & Application("visitas")
        If Not IsPostBack Then
            lblCount.Text = "Tentativas de login: 0"
        End If
        If (Not IsNothing(HttpContext.Current.Session("autenticado"))) AndAlso HttpContext.Current.Session("autenticado").ToString() = "OK" Then
            HttpContext.Current.Response.Redirect("Home.aspx")


        End If
    End Sub



    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim objFunc As Funcionario = funcionarioController.makeLogin(Login1.UserName, Login1.Password)
        If Not IsNothing(objFunc) Then
            Session("autenticado") = "OK"
            Session("funcionario") = objFunc
            Response.Redirect("Home.aspx")
        End If
        If ViewState("counter") = Nothing Then
            ViewState("counter") = 0
        End If
        ViewState("counter") += 1
        lblCount.Text = "Tentativas de login: " & ViewState("counter")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim reg As Boolean = funcionarioController.registerFunc(rgNome.Text, rgCPF.Text, rgEmail.Text, rgPass.Text)

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