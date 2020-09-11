<Authorize()> _
Public Class AddressController
    Inherits System.Web.Mvc.Controller
    Private _db As iAddressRepository

    Sub New()
        _db = New AddressRepository

    End Sub
    '
    ' GET: /Address/

    Function Index(ByVal permilink As String) As ActionResult
        Dim x = _db.GetAddressesByInfo(Myapp.GetRegistrarNo(permilink))
        If x.Count = 1 Then
            Return RedirectToAction("Details", New With {.permilink = permilink, .id = x.First.AddressID})
        ElseIf x.Count = 0 Then
            Return RedirectToAction("Create", New With {.permilink = permilink})
        Else
            Return View(x)
        End If
        'Return View()
    End Function

    '
    ' GET: /Address/Details/5

    Function Details(ByVal id As Integer) As ActionResult

        Return View(_db.GetAddress(id))
    End Function

    '
    ' GET: /Address/Create
    <Authorize(Roles:="AddressCreate")> _
    Function Create(ByVal Permilink As String) As ActionResult
        ViewData("rs") = Request.UrlReferrer.AbsolutePath

        Return View()
    End Function

    '
    ' POST: /Address/Create
    <Authorize(Roles:="AddressCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal Permilink As String, ByVal rs As String, ByVal newAddress As Model.Address) As ActionResult
        Try

            newAddress.InputedBy = Myapp.UserId

            newAddress.RegistrarNo = Myapp.GetRegistrarNo(Permilink:=Permilink)
            newAddress.ed = Date.Now
            newAddress.ud = Date.Now

            _db.Add(newAddress)
            ' TODO: Add insert logic here
            Return Redirect(rs) 'RedirectToAction("Index")
        Catch
            Return View(newAddress)
        End Try
    End Function

    '
    ' GET: /Address/Edit/5
    <Authorize(Roles:="AddressEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Return View(_db.GetAddress(id))
    End Function

    '
    ' POST: /Address/Edit/5
    <Authorize(Roles:="AddressEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Dim x = _db.GetAddress(id)

            x.ud = Date.Now

            UpdateModel(_db.GetAddress(id))

            _db.save()


            'x.Info.Permilink
            Return RedirectToAction("Details", New With {.controller = "info", .permilink = x.Info.Permilink})
        Catch
            Return View()
        End Try
    End Function
End Class
