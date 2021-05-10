Public Class Home
    Inherits System.Web.UI.Page


    Private FPostController As PostController

    Public Sub New()
        FPostController = New PostController()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strMetodo As String = HttpContext.Current.Request.HttpMethod
        Dim strItem As String = HttpContext.Current.Request.Item("itemenviado")
        Dim isHttps As Boolean = HttpContext.Current.Request.IsSecureConnection


        If IsNothing(Session("autenticado")) OrElse Session("autenticado").ToString() <> "OK" Then
            Session.Abandon()
            Response.Redirect("Default.aspx")
        Else
            Posts.DataSource = FPostController.GetAllPosts()
            Posts.DataBind()
        End If

        'Dim STR As String = Request.ServerVariables("HTTP_REFERER")
        'Request.ServerVariables("REMOTE_ADDR")
        'Request.ServerVariables("SERVERNAME")
        'Request.ServerVariables("HTTP_USER_AGENT")


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim ok As Boolean = FPostController.SavePost(txtTitle.Text, txtText.Text, TryCast(Session("funcionario"), Funcionario).Id)
        If ok Then
            msgPost.Text = "Sucesso!"
            Response.Redirect(Request.RawUrl)
        Else
            msgPost.Text = "Erro!"
        End If


    End Sub
End Class

