<Authorize()> _
Public Class DisabilityController
    Inherits System.Web.Mvc.Controller



    Dim _db As Repository

    Sub New()
        _db = New Repository
    End Sub
    '
    ' GET: /Disability/

    Function Index(ByVal permilink As String) As ActionResult
        Dim x = _db.getDisabilitiesByInfo(permilink)

        Return View(x)
    End Function

    '
    ' GET: /Disability/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Dim x = _db.getDisability(id)
        Return View(x)
    End Function

    '
    ' GET: /Disability/Create

    <Authorize(Roles:="DisabilityCreate")> _
    Function Create(ByVal Permilink As String) As ActionResult
        ViewData("RegistrarNo") = Myapp.GetRegistrarNo(Permilink)
        ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Return View()
    End Function

    '
    ' POST: /Disability/Create
    <Authorize(Roles:="DisabilityCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal Permilink As String, ByVal rs As String, ByVal NewDisability As Model.Disability) As ActionResult
        Try
            ' TODO: Add insert logic here
            NewDisability.RegistrarNo = Myapp.GetRegistrarNo(Permilink)
            NewDisability.InputedBy = Myapp.UserId
            NewDisability.Ed = Date.Now
            NewDisability.Ud = Date.Now
            _db.Add(NewDisability)

            Return Redirect(rs)
        Catch ex As Exception

            Return View(NewDisability)
        End Try
    End Function

    '
    ' GET: /Disability/Edit/5
    <Authorize(Roles:="DisabilityEdit")> _
    Function Edit(ByVal Permilink As String, ByVal id As Integer) As ActionResult
        Dim x = _db.getDisability(id)
        ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Return View(x)
    End Function

    '
    ' POST: /Disability/Edit/5
    <Authorize(Roles:="DisabilityEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal Permilink As String, ByVal id As Integer, ByVal rs As String, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here
            Dim x = _db.getDisability(id)

            UpdateModel(x)

            _db.Save()

            Return Redirect(rs)
        Catch ex As Exception
            Dim x = _db.getDisability(id)

            Return View()
        End Try
    End Function

    '
    ' GET: /Disability/Edit/5
    <Authorize(Roles:="DisabilityDelete")> _
    Function Delete(ByVal Permilink As String, ByVal id As Integer) As ActionResult
        Dim x = _db.getDisability(id)
        ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Return View(x)
    End Function

    '
    ' POST: /Disability/Edit/5
    <Authorize(Roles:="DisabilityDelete")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(ByVal Permilink As String, ByVal id As Integer, ByVal rs As String, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.deleteDisability(id)

        Return Redirect(rs)
    End Function

End Class
