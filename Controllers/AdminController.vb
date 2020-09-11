Public Class AdminController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Admin/
    <Authorize(Roles:="admin")> _
    Function Index() As ActionResult
        Return View()
    End Function

End Class
