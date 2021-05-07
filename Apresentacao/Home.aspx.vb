Public Class Home
    Inherits System.Web.UI.Page


    Private postController As PostController

    Public Sub New()
        postController = New PostController()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("autenticado")) OrElse Session("autenticado").ToString() <> "OK" Then
            Session.Abandon()
            Response.Redirect("Default.aspx")
        Else
            Posts.DataSource = postController.allPosts()
            Posts.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim ok As Boolean = postController.insertPost(titulo.Text, texto.Text, TryCast(Session("funcionario"), Funcionario).id)
        If ok Then
            msgPost.Text = "Sucesso!"
            Response.Redirect(Request.RawUrl)
        Else
            msgPost.Text = "Erro!"
        End If


    End Sub
End Class

