Imports MvcPaging
<Authorize()> _
<HandleError()> _
Public Class infoController
    Inherits System.Web.Mvc.Controller
    Private _db As Repository
    Sub New()
        _db = New Repository

    End Sub

    Sub New(ByVal repository As Repository)
        _db = repository
    End Sub

    Function index(ByVal Search As String, ByVal Page? As Integer) As ActionResult

        Dim y = _db.SearchInfos("")
        Dim jo As New Model.ProgramOutcomes.PdOutcome

        Dim _pagevalue As Integer = 0
        If Page.HasValue Then
            _pagevalue = Page.Value - 1

        End If

        If Not String.IsNullOrEmpty(Search) Then

            Search = Search.Replace("  ", " ")

            Search = Search.Trim

            Dim first As Boolean = True

            For Each s In Search.Split(" ")

                If first Then
                    y = _db.SearchInfos(s)
                Else
                    Dim x = _db.SearchInfos(s).Select(Function(e) e.RegistrarNo).ToList

                    y = y.Where(Function(e) x.Contains(e.RegistrarNo))

                End If

                first = False

            Next

        Else
            y = From x In _db.GetAllInfos _
                Where x.Referrals.Any(Function(e) e.Authorizations.Any(Function(b) b.Services.Any(Function(f) f.AssignedTo.Equals(Myapp.UserId(True))))) _
                Order By x.LastName, x.FirstName _
                Select x

        End If

        ViewData("Search") = Search

        If y.Count = 1 And Not String.IsNullOrEmpty(Search) Then
            Return RedirectToAction("Details", New With {.Permilink = y.First.Permilink})
        Else
            Return View(y.ToPagedList(_pagevalue, 20))

        End If



        Return View()

    End Function
    '
    ' GET: /info/Details/5

    Function Details(ByVal Permilink As String) As ActionResult


        Return View(_db.GetInfoByPermilink(Permilink))


    End Function

    '
    ' GET: /info/Create
    <Authorize(Roles:="ConsumerCreate")> _
    Function Create() As ActionResult

        Return View()
    End Function

    '
    ' POST: /info/Create
    <Authorize(Roles:="ConsumerCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal new_info As Model.Info) As ActionResult

        If Not String.IsNullOrEmpty(new_info.SSN) Then
            Dim Consumersbyssn = From a In _db.GetAllInfos Where a.SSN = new_info.SSN

            If Consumersbyssn.Count > 0 Then
                Throw New SocialSecurityNumberAllreadyAddedToWebistrarException(new_info)
            End If
        End If

        If Not String.IsNullOrEmpty(new_info.REF) Then
            Dim Consumersbyref = From a In _db.GetAllInfos Where a.REF = new_info.REF


            If Consumersbyref.Count > 0 Then
                Throw New ReferaralIdNumberAllreadyAddedToWebistrarException(new_info)
            End If
        End If

        If Not String.IsNullOrEmpty(new_info.RegistrarNo) Then
            Dim Consumersbyref = From a In _db.GetAllInfos Where a.RegistrarNo = new_info.RegistrarNo


            If Consumersbyref.Count > 0 Then
                Throw New ReferaralIdNumberAllreadyAddedToWebistrarException(new_info)
            End If
        End If


        If String.IsNullOrEmpty(new_info.SSN) And String.IsNullOrEmpty(new_info.REF) Then
            Throw New InsufficantIdNumbersException()
        End If

        new_info.Inputedby = Myapp.UserId
        new_info.ED = Date.Now
        new_info.UD = Date.Now

        new_info.Permilink = String.Format("{0}-{1}-{2}", new_info.FirstName.ToLower.Trim, new_info.LastName.ToLower.Trim, new_info.RegistrarNo.ToLower.Trim)

        new_info.Permilink = new_info.Permilink.Replace("'", "")

        new_info.Permilink = new_info.Permilink.Replace(" ", "")

        new_info.Permilink = new_info.Permilink.Replace(",", "")

        new_info.Permilink = HttpContext.Server.UrlEncode(new_info.Permilink)

        _db.add(new_info)

        Return RedirectToAction("Details", New With {.Permilink = new_info.Permilink})

    End Function

    '
    ' GET: /info/Edit/5
    <Authorize(Roles:="ConsumerEdit")> _
    Function Edit(ByVal Permilink As String) As ActionResult
        Dim x = _db.getInfoByPermilink(Permilink)

        Return View(x)
    End Function

    '
    ' POST: /info/Edit/5
    <Authorize(Roles:="ConsumerEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal Permilink As String, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.getInfoByPermilink(Permilink)
        Try

            UpdateModel(x)
            _db.Save()


            Return RedirectToAction("Index")
        Catch

            Return View(x)
        End Try

    End Function

    <Authorize(Roles:="MiscEdit")> _
    <AcceptVerbs(HttpVerbs.Get)> _
    Function AddMisc(ByVal Permilink As String, ByVal rs As String) As ActionResult

        If String.IsNullOrEmpty(rs) Then

            If Request.UrlReferrer Is Nothing Then

            End If

            Return RedirectToAction("AddMisc", New With {.Permilink = Permilink, .rs = If(Not Request.UrlReferrer Is Nothing, Request.UrlReferrer.AbsolutePath, Myapp.BuildUri.RouteUrl(New With {.controller = "info", .action = "details", .permilink = Permilink}))})
        Else
            ViewData("rs") = rs
        End If

        Return View()
    End Function
    <Authorize(Roles:="MiscEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function AddMisc(ByVal Permilink As String, ByVal rs As String, ByVal newMisc As Model.misc) As ActionResult

        newMisc.RegistrarNo = Myapp.GetRegistrarNo(Permilink)
        newMisc.Inputedby = Myapp.UserId
        newMisc.ED = Date.Now
        newMisc.UD = Date.Now

        _db.add(newMisc)

        Return Redirect(rs) 'RedirectToAction("Details", New With {.permilink = Permilink})
    End Function

    <Authorize(Roles:="MiscEdit")> _
    Function Misc(ByVal Permilink As String, ByVal rs As String) As ActionResult


        If String.IsNullOrEmpty(rs) Then

            If Request.UrlReferrer Is Nothing Then

            End If

            Return RedirectToAction("Misc", New With {.Permilink = Permilink, .rs = If(Not Request.UrlReferrer Is Nothing, Request.UrlReferrer.AbsolutePath, Myapp.BuildUri.RouteUrl(New With {.controller = "info", .action = "details", .permilink = Permilink}))})
        Else
            ViewData("rs") = rs
        End If

        Dim _misc = _db.GetMisc(Permilink)




        Return View(_misc)
    End Function

    <Authorize(Roles:="MiscEdit")> _
    Function MiscEdit(ByVal Permilink As String, ByVal rs As String) As ActionResult

        If String.IsNullOrEmpty(rs) Then

            If Request.UrlReferrer Is Nothing Then

            End If

            Return RedirectToAction("MiscEdit", New With {.Permilink = Permilink, .rs = If(Not Request.UrlReferrer Is Nothing, Request.UrlReferrer.AbsolutePath, Myapp.BuildUri.RouteUrl(New With {.controller = "info", .action = "details", .permilink = Permilink}))})
        Else
            ViewData("rs") = rs
        End If


        Dim _misc = _db.GetMisc(Permilink)
        ViewData("rs") = rs

        Return View(_misc)
    End Function

    '
    ' POST: /info/Edit/5
    <Authorize(Roles:="MiscEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function MiscEdit(ByVal Permilink As String, ByVal rs As String, ByVal collection As FormCollection) As ActionResult

        Dim _misc = _db.GetMisc(Permilink)

        _misc.UD = Date.Now
        UpdateModel(_misc)
        _db.Save()

        Return Redirect(rs) 'RedirectToAction("Details", New With {.Permilink = Permilink})



    End Function


    Function getSearchName(ByVal Search As String) As JsonResult

        Dim json As New JsonResult

        json.Data = _db.getSearchName(Search)

        Return json

    End Function



    Function CreateAndEnrollNewConsumer() As ActionResult
        'ModelState.AddModelError("ReportName", "You must name this report")
        'ModelState.AddModelError("SSN", "Bitch wanted me to rehire her")
        Try

            Dim new_info As New Model.Info

            ' TODO: Add insert logic here
            ModelState.SetModelValue("SSN", ValueProvider("SSN"))

           'ModelState.AddModelError("SSN", "Bitch wanted me to rehire her")


            ViewData("message") = "form"

            Return View(New Model.CreateAndEnrollNewConsumers)

            ' Return RedirectToAction("Details", New With {.Permilink = new_info.Permilink})
        Catch ex As Exception
            ViewData("message") = "ex"
            Return View()
        End Try



        'ModelState.AddModelError("", "error")
        Return View()

    End Function



    ''
    '' POST: /info/Create
    '<Authorize(Roles:="ConsumerCreate")> _
    '<AcceptVerbs(HttpVerbs.Post)> _
    'Function Create(ByVal collection As FormCollection) As ActionResult
    '    Try

    '        Dim new_info As New Model.Info

    '        ' TODO: Add insert logic here

    '        ModelState.AddModelError("SSN", "Bitch wanted me to rehire her")


    '        Return View()

    '        ' Return RedirectToAction("Details", New With {.Permilink = new_info.Permilink})
    '    Catch ex As Exception
    '     Return View()
    '    End Try
    'End Function

    ' POST: /info/Create
    <Authorize(Roles:="ConsumerEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function FlagConsumer(ByVal Permilink As String, ByVal collection As FormCollection) As ActionResult

        Dim _misc = _db.getInfoByPermilink(Permilink)

        _misc.UD = Date.Now
        UpdateModel(_misc)
        _db.Save()

        Return RedirectToAction("Details", New With {.Permilink = Permilink})



    End Function

End Class
