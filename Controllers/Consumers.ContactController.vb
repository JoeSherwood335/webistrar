<Authorize()> _
Public Class ContactController
    Inherits System.Web.Mvc.Controller
    Private _db As iContactRepository

    Sub New()
        _db = New ContactRepository

    End Sub

    Sub New(ByVal repository As ContactRepository)
        _db = repository
    End Sub
    '
    ' GET: /Contact/

    Function Index(ByVal permilink As String) As ActionResult

        Dim x = _db.GetContactsByInfo(permilink)

        Return View(x)
    End Function

    '
    ' GET: /Contact/Details/5

    Function Details(ByVal id As Integer) As ActionResult

        Return View(_db.GetContact(id))
    End Function

    '
    ' GET: /Contact/Create
    <Authorize(Roles:="ContactCreate")> _
    Function Create() As ActionResult


        ViewData("rs") = Request.UrlReferrer.AbsolutePath

        Return View()
    End Function

    '
    ' POST: /Contact/Create

    <Authorize(Roles:="ContactCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal permilink As String, ByVal rs As String, ByVal contact As Model.Contact) As ActionResult
        Try
            contact.RegistrarNo = _db.GetRegistrarNofromPermilink(permilink)
            contact.InputedBy = Myapp.UserId
            contact.ED = Date.Now
            contact.UD = Date.Now
            If String.IsNullOrEmpty(contact.Other.Trim) Then
                contact.Other = "(self)"
            End If
            _db.Add(contact)

            ' TODO: Add insert logic here

            If String.IsNullOrEmpty(rs) Then
                Return RedirectToAction("index", New With {.controller = "Contact", .permilink = permilink})
            Else
                Return Redirect(rs)
            End If

            ' Return RedirectToAction("Details", New With {.id = contact.ContactID})
        Catch

            Return View()
        End Try
    End Function

    '
    ' GET: /Contact/Edit/5
    <Authorize(Roles:="ContactEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim x = _db.GetContact(id)

        ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Return View(x)
    End Function

    '
    ' POST: /Contact/Edit/5
    <Authorize(Roles:="ContactEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal rs As String, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here
            Dim x = _db.GetContact(id)
            x.UD = Date.Now

            UpdateModel(x)

            _db.Save()

            If String.IsNullOrEmpty(rs) Then
                Return RedirectToAction("index", New With {.controller = "Contact", .permilink = x.Info.Permilink})
            Else
                Return Redirect(rs)
            End If
        Catch
            Return View()
        End Try
    End Function
End Class
