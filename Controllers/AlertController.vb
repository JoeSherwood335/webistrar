Public Class AlertController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Alert/

    Function Index(ByVal returnpath As String) As ActionResult

        Dim _db As New Repository

        ViewData("returnpath") = returnpath

        Return View(_db.GetMyAlerts)
    End Function

    Function Details(ByVal id As String, ByVal returnpath As String) As ActionResult

        Dim _db As New Repository
        Dim x = From a In _db.GetMyAlerts _
                Where a.Subject = id

        Dim url As String = x.First.Link

        For Each a In x
            _db.Reset(a.AlertId)
        Next

        Return Redirect(url)
    End Function
    Function Reset(ByVal id As String, ByVal returnpath As String) As ActionResult

        Dim _db As New Repository
        Dim x = From a In _db.GetMyAlerts _
                Where a.Subject = id

        Dim url As String = x.First.Link

        For Each a In x
            _db.Reset(a.AlertId)
        Next

        Return Redirect(returnpath)
    End Function
    Function ResetAll(ByVal returnpath As String) As ActionResult

        Dim _db As New Repository
        _db.ResetAllAlert(Myapp.UserId)
        ' Dim serverpath As String = Myapp.GetServerPath
        Return Redirect(returnpath)
    End Function

End Class
