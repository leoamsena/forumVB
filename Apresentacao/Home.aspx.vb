Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(HttpContext.Current.Session("autenticado")) OrElse HttpContext.Current.Session("autenticado").ToString() <> "OK" Then
            HttpContext.Current.Session.Abandon()

            HttpContext.Current.Response.Redirect("Default.aspx")
        Else
            Posts.DataSource = PostController.allPosts()
            Posts.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.WriteLine(TryCast(Session("funcionario"), Funcionario).getNome)
        Debug.WriteLine(TryCast(Session("funcionario"), Funcionario).id)
        Dim ok As Boolean = PostController.insertPost(titulo.Text, texto.Text, TryCast(Session("funcionario"), Funcionario).id)
        If ok Then
            msgPost.Text = "Sucesso!"
        Else
            msgPost.Text = "Erro!"
        End If

    End Sub
End Class