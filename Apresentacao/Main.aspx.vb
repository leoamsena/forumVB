Public Class Main
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(HttpContext.Current.Session("autenticado")) OrElse HttpContext.Current.Session("autenticado").ToString() <> "OK" Then
            HttpContext.Current.Session.Abandon()

            HttpContext.Current.Response.Redirect("Default.aspx")
        Else
            HtmlControls.
        End If
    End Sub

End Class