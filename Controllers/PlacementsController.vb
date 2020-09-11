Imports MvcPaging
<Authorize()> _
<HandleError()> _
Public Class PlacementsController
    Inherits System.Web.Mvc.Controller

    Private _db As Repository

    Sub New()
        _db = New Repository
    End Sub


    '
    ' GET: /Placements/
    <Authorize(Roles:="PlacementsView")> _
    Function Index(ByVal Permilink As String) As ActionResult

        Return View(_db.GetInfo(Myapp.GetRegistrarNo(Permilink)))
    End Function



    <Authorize(Roles:="PlacementsCreate")> _
    Function Create(ByVal Permilink As String, ByVal Search As String, ByVal id As Integer, ByVal ReferralId? As Integer) As ActionResult

        Return View()
    End Function

    <Authorize(Roles:="PlacementsCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal Permilink As String, ByVal Search As String, ByVal id As Integer, ByVal newPlacement As Model.Placement) As ActionResult

        Try

            If newPlacement.Wage.HasValue And Not newPlacement.WageTypeId.HasValue Then
                ModelState.AddModelError("WageTypeId", "Must Set Wage Type")
                Throw New Exception()
            End If
            newPlacement.IsPlacement = True
            newPlacement.InputedBy = Myapp.UserId
            newPlacement.Ed = Date.Now
            newPlacement.Ud = Date.Now
            newPlacement.CompanyId = id
            newPlacement.RegistrarNo = Myapp.GetRegistrarNo(Permilink)

            _db.add(newPlacement)

            Return RedirectToAction("Outcome", New With {.controller = "Referral", .id = newPlacement.ReferralId})

        Catch ex As Exception

            Return View()
        End Try

    End Function


    Function Company(ByVal Permilink As String, ByVal Search As String, ByVal Page? As Integer, ByVal ReferralId? As Integer) As ActionResult

        Dim _pagevalue As Integer = 0
        If Page.HasValue Then
            _pagevalue = Page.Value - 1

        End If


        Dim y = _db.SearchCompanies("")

        If Not String.IsNullOrEmpty(Search) Then

            Search = Search.Replace("  ", " ")

            Search = Search.Trim

            Dim first As Boolean = True

            For Each s In Search.Split(" ")

                If first Then
                    y = _db.SearchCompanies(s)
                Else
                    Dim x = _db.SearchCompanies(s).Select(Function(e) e.id).ToList

                    y = y.Where(Function(e) x.Contains(e.id))

                End If

                first = False

            Next
        End If
        ViewData("Permilink") = Permilink
        ViewData("Search") = Search
        ViewData("ReferralId") = ReferralId

        Return View(y.ToPagedList(_pagevalue, 20))

    End Function

    <Authorize(Roles:="PlacementsView")> _
    Function Details(ByVal id As Integer) As ActionResult
        Return View(_db.GetPlacement(id))
    End Function


    <Authorize(Roles:="PlacementsEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Return View(_db.GetPlacement(id))
    End Function

    <Authorize(Roles:="PlacementsEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.GetPlacement(id)
        'Try
        If Not String.IsNullOrEmpty(collection("Wage")) And String.IsNullOrEmpty(collection("WageTypeId")) Then
            ModelState.AddModelError("WageTypeId", "Must Set Wage Type")
        End If

        UpdateModel(x)

        If x.Retention90Date.HasValue Then


            '  x.Retention90 = True





            If DateDiff(DateInterval.Day, x.PlacementDate, x.Retention90Date.Value) < 0 Then
                Throw New Exception("Retention Date Cant be before Placement date")
            End If

            If DateDiff(DateInterval.Day, x.PlacementDate, x.Retention90Date.Value) < 90 Then
                Throw New Exception(String.Format("Retention Date must be greater then 90 days of placement date '{0}' to '{1}' is {2} days", x.PlacementDate, x.Retention90Date.Value, DateDiff(DateInterval.Day, x.PlacementDate, x.Retention90Date.Value)))
            End If



        End If

        If x.Retention180Date.HasValue Then

            '' x.Retention180 = True

            If DateDiff(DateInterval.Day, x.PlacementDate, x.Retention180Date.Value) < 0 Then
                Throw New Exception("Retention Date Cant be before Placement date")
            End If


            If DateDiff(DateInterval.Day, x.PlacementDate, x.Retention180Date.Value) < 180 Then
                Throw New Exception("Retention Date must be greater then 180 days of placement date")
            End If
        End If


        If x.Retention180Date.HasValue Then

            x.Retention180 = True
        Else
            x.Retention180 = False
        End If


        If x.Retention90Date.HasValue Then

            x.Retention90 = True
        Else
            x.Retention90 = False
        End If



        x.InputedBy = Myapp.UserId
        x.Ud = Date.Now

        _db.Save()

        Return RedirectToAction("Outcome", New With {.controller = "Referral", .id = x.ReferralId})
        'Catch ex As Exception
        '    'Return View(x)
        'End Try
    End Function



    <Authorize(Roles:="PlacementsCreate")> _
    Function CreateCompany(ByVal Permilink As String, ByVal ReferralId? As Integer) As ActionResult

        Return View()
    End Function

    <Authorize(Roles:="PlacementsCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function CreateCompany(ByVal Permilink As String, ByVal ReferralId? As Integer, ByVal Company As Model.Company) As ActionResult


        _db.add(newCompany:=Company)




        Return RedirectToAction("Create", New With {.id = Company.id, .Permilink = Permilink, .ReferralId = ReferralId.Value})


    End Function



End Class
