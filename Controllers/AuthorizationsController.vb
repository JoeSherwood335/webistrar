Imports MvcPaging


<HandleError()> _
<Authorize()> _
Public Class AuthorizationsController
    Inherits System.Web.Mvc.Controller
    Dim _db As Repository
    Sub New()
        _db = New Repository

    End Sub
    <Authorize(Roles:="AuthorizationsList")> _
    Function Index() As ActionResult
        Return RedirectToAction("NewAuthorizations")
    End Function
    <Authorize(Roles:="AuthorizationsList")> _
    Function NewAuthorizations(ByVal page? As Integer) As ActionResult

        Dim y = (From a In Myapp.GetSubordinates(Myapp.UserId(False)) _
                Select a.UserId).ToList

        Dim x = _db.GetAllAuthorizations.Where(Function(e) Not e.ApproveById.HasValue And y.Contains(e.Referral.ProgramInstance.SupervisorId)).OrderByDescending(Function(e) e.AuthorizationDate)
        Dim _pagevalue As Integer = 0

        If page.HasValue Then
            _pagevalue = page.Value - 1

        End If

        Return View(x.ToPagedList(_pagevalue, 20))
    End Function
    <Authorize(Roles:="AuthorizationsList")> _
    <Authorize()> _
    Function Approved(ByVal page? As Integer) As ActionResult

        Dim y = (From a In Myapp.GetSubordinates(Myapp.UserId(False)) _
                Select a.UserId).ToList()

        Dim _pagevalue As Integer = 0
        If page.HasValue Then
            _pagevalue = page.Value - 1

        End If
        Dim x = _db.GetAllAuthorizations.Where(Function(e) e.ApproveById.HasValue And y.Contains(e.Referral.ProgramInstance.SupervisorId)).OrderByDescending(Function(e) e.AuthorizationDate).ToPagedList(_pagevalue, 20)


        Return View(x)
    End Function
    <Authorize(Roles:="AuthorizationsList")> _
    <Authorize()> _
    Function AuthorizationsByOpenReferrals(ByVal page? As Integer) As ActionResult
        Dim y = (From a In Myapp.GetSubordinates(Myapp.UserId(False)) _
        Select a.UserId).ToList()

        Dim _pagevalue As Integer = 0
        If page.HasValue Then
            _pagevalue = page.Value - 1

        End If

        Dim x = _db.GetAllAuthorizations.Where(Function(e) e.ApproveById.HasValue And y.Contains(e.Referral.ProgramInstance.SupervisorId) And e.Referral.StatusId = 1).OrderByDescending(Function(e) e.AuthorizationDate).ToPagedList(_pagevalue, 20)

        Return View(x)
    End Function
    <Authorize(Roles:="AuthorizationsList")> _
<Authorize()> _
Function AuthorizationsByClosedReferrals(ByVal page? As Integer) As ActionResult
        Dim y = (From a In Myapp.GetSubordinates(Myapp.UserId(False)) _
        Select a.UserId).ToList()

        Dim _pagevalue As Integer = 0
        If page.HasValue Then
            _pagevalue = page.Value - 1

        End If

        Dim x = _db.GetAllAuthorizations.Where(Function(e) e.ApproveById.HasValue And y.Contains(e.Referral.ProgramInstance.SupervisorId) And e.Referral.StatusId = 2).OrderByDescending(Function(e) e.AuthorizationDate).ToPagedList(_pagevalue, 20)

        Return View(x)
    End Function
    <Authorize(Roles:="AuthorizationsApprove")> _
    Function Approve(ByVal id As Integer)

        Dim x = _db.GetAuthorization(id)

        Return RedirectToAction("Details", New With {.id = x.AuthorizationID})
        'Return View(_db.GetAuthorization(id))

    End Function
    <Authorize(Roles:="AuthorizationsApprove")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Approve(ByVal id As Integer, ByVal approvedAuthorization As Model.Authorization)

        Dim x = _db.GetAuthorization(id)


        For Each s As Model.Service In x.Services
            If s.RegisteredUser.Username = "Unknown" Then
                Throw New Exception("One or More Services Not Assigned")
            End If

        Next

        x.ApproveById = Myapp.UserId(False)

        x.ApprovedByDate = Date.Now

        _db.Save()

        Return RedirectToAction("Details", New With {.id = x.AuthorizationID})
    End Function
    <Authorize(Roles:="AuthorizationsView")> _
    Function Details(ByVal id As Integer) As ActionResult

        Dim billingdc As New R2kDoiMvcBillingDataContext

        Dim x = Aggregate a In Myapp.GetBillingInfoFromAuthorization(id) _
                Into Sum(a.ammountBilled)

        'Dim y = Aggregate a In Myapp.GetBillingInfoFromAuthorization(id) _
        '        Into Count(a.InvoiceNumber)

        ViewData("AmountBilled") = x


        Return View(_db.GetAuthorization(id))
    End Function
    <Authorize(Roles:="AuthorizationsEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim x = _db.GetAuthorization(id)

        '     ViewData("Unittypes") = _db.SelectList("Unittype")
        ViewData("Edit") = True
        Return View(x)
    End Function
    <Authorize(Roles:="AuthorizationsEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.GetAuthorization(id)
        Try
            ' TODO: Add update logic here


            Dim ShouldSendMail As Boolean = Not x.ApproveById.HasValue

            UpdateModel(x)

            _db.Save()

            Dim sendEmail As Mail.iSendMail = New Mail.AuthorizationSendMail(x)

            'If ShouldSendMail Then
            '    sendEmail.Send()
            'End If

            Return RedirectToAction("Details", New With {.id = id})

        Catch

            ViewData("Edit") = True
            Return View(collection)
        End Try
    End Function
    <Authorize(Roles:="AuthorizationsAddDetails")> _
    Function AddDetail(ByVal id As Integer) As ActionResult


        Dim authorization = _db.GetAuthorization(id)

        If authorization.Referral.StatusId <> 1 Then
            Throw New ReferralIsClosedException(authorization)
        End If
        Return View()
    End Function
    <Authorize(Roles:="AuthorizationsAddDetails")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function AddDetail(ByVal id As Integer, ByVal WageAddonUnitsAuthorized As String, ByVal WageSchedualStartDate As String, ByVal WageSchedualEndDate As String, ByVal ReportWritingSchedualEndDate As String, ByVal ReportWritingSchedualStartDate As String, ByVal ReportWritingAuthorized As String, ByVal MileageAmountAuthorized As String, ByVal MileageUnitesAuthorized As String, ByVal MileageSchedualStartDate As String, ByVal MileageSchedualEndDate As String, ByVal UnitOfServiceEquals As String, ByVal UnitAmountAuthorized As String, ByVal HCPCSCode As String, ByVal newService As Model.Service) As ActionResult


        newService.AuthorizationId = id

        newService.ProductId = 2642
        newService.NumberOfUnits = 0
        newService.AssignedTo = 602
        newService.CostCenter = "000"
        newService.InputedBy = Myapp.UserId(False)
        newService.ed = Date.Now
        newService.ud = Date.Now

        'ReportWritingAuthorized
        'MileageUnitesAuthorized
        'WageAddonUnitsAuthorized

        'ViewData("UnitOfServiceEquals") = newService.GetDetail("UnitOfServiceEquals")
        'ViewData("TotalAmountAuthorized") = newService.GetDetail("TotalAmountAuthorized")
        'ViewData("HCPCSCode") = newService.GetDetail("HCPCSCode")

        newService.SetDetail("AutoCalc", 1)

        newService.SetDetail("UnitOfServiceEquals", UnitOfServiceEquals)
        newService.SetDetail("UnitAmountAuthorized", UnitAmountAuthorized)
        newService.SetDetail("HCPCSCode", HCPCSCode)

        _db.Add(newService)


        Return RedirectToAction("Edit", New With {.id = id})
    End Function
    <Authorize(Roles:="AuthorizationsAddDetails")> _
    Function AddDetails(ByVal id As Integer) As ActionResult


        Dim authorization = _db.GetAuthorization(id)

        If authorization.Referral.StatusId <> 1 Then
            Throw New ReferralIsClosedException(authorization)
        End If
        Return View()
    End Function
    <Authorize(Roles:="AuthorizationsAddDetails")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function AddDetails(ByVal id As Integer, _
                        ByVal ServiceName As String, _
                        ByVal NumberOfUnitesAuthorized As String, _
                        ByVal UnitPrice As String, _
                        ByVal UnitTypeId As String, _
                        ByVal AmountAuthorized As String, _
                        ByVal SchedualStartDate As String, _
                        ByVal SchedualEndDate As String, _
                        ByVal MileageNumberOfUnitesAuthorized As String, _
                        ByVal MileageUnitPrice As String, _
                        ByVal MileageUnitTypeId As String, _
                        ByVal MileageAmountAuthorized As String, _
                        ByVal MileageSchedualStartDate As String, _
                        ByVal MileageSchedualEndDate As String, _
                        ByVal ReportWritingNumberOfUnitesAuthorized As String, _
                        ByVal ReportWritingUnitPrice As String, _
                        ByVal ReportWritingUnitTypeId As String, _
                        ByVal ReportWritingAmountAuthorized As String, _
                        ByVal ReportWritingSchedualStartDate As String, _
                        ByVal ReportWritingSchedualEndDate As String, _
                        ByVal WageAddonNumberOfUnitesAuthorized As String, _
                        ByVal WageAddonUnitPrice As String, _
                        ByVal WageAddonUnitTypeId As String, _
                        ByVal WageAddonAmountAuthorized As String, _
                        ByVal WageAddonSchedualStartDate As String, _
                        ByVal WageAddonSchedualEndDate As String) As ActionResult


        _db.AddDetail(id, ServiceName, NumberOfUnitesAuthorized, AmountAuthorized, UnitTypeId, AmountAuthorized, SchedualStartDate, SchedualEndDate, Repository.ServiceType.Primary)
        
        If Not String.IsNullOrEmpty(MileageNumberOfUnitesAuthorized) Then
            _db.AddDetail(id, "Mileage", MileageNumberOfUnitesAuthorized, MileageAmountAuthorized, MileageUnitTypeId, MileageAmountAuthorized, MileageSchedualStartDate, MileageSchedualEndDate, Repository.ServiceType.Secondary)
        End If

        If Not String.IsNullOrEmpty(ReportWritingNumberOfUnitesAuthorized) Then
            _db.AddDetail(id, "ReportWriting", ReportWritingNumberOfUnitesAuthorized, ReportWritingAmountAuthorized, ReportWritingUnitTypeId, ReportWritingAmountAuthorized, ReportWritingSchedualStartDate, ReportWritingSchedualEndDate, Repository.ServiceType.Secondary)
        End If

        If Not String.IsNullOrEmpty(WageAddonNumberOfUnitesAuthorized) Then
            _db.AddDetail(id, "WageAddon", WageAddonNumberOfUnitesAuthorized, WageAddonAmountAuthorized, WageAddonUnitTypeId, WageAddonAmountAuthorized, WageAddonSchedualStartDate, WageAddonSchedualEndDate, Repository.ServiceType.Secondary)
        End If

        Return RedirectToAction("Edit", New With {.id = id})
    End Function
    <Authorize(Roles:="AuthorizationsEditDetails")> _
    Function EditDetails(ByVal id As Integer) As ActionResult
        Dim x = _db.GetService(id)

        'ViewData("Unittypes") = _db.SelectList("Unittype")
        'ViewData("ServiceTypes") = _db.SelectList("ServiceType")

        If x.HasDetail("") Then

        End If
        ViewData("UnitOfServiceEquals") = If(x.HasDetail("UnitOfServiceEquals"), x.GetDetail("UnitOfServiceEquals"), "")
        ViewData("UnitAmountAuthorized") = If(x.HasDetail("UnitAmountAuthorized"), x.GetDetail("UnitAmountAuthorized"), "")
        ViewData("HCPCSCode") = If(x.HasDetail("HCPCSCode"), x.GetDetail("HCPCSCode"), "")
        Return View(x)
    End Function
    <Authorize(Roles:="AuthorizationsEditDetails")> _
    <AcceptVerbs(HttpVerbs.Post)> _
   Function EditDetails(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.GetService(id)
        Try
            ' TODO: Add update logic here

            x.SetDetail("UnitOfServiceEquals", collection("UnitOfServiceEquals"))
            x.SetDetail("UnitAmountAuthorized", collection("UnitAmountAuthorized"))
            x.SetDetail("HCPCSCode", collection("HCPCSCode"))

            UpdateModel(x)

            _db.Save()


            Return RedirectToAction("Edit", New With {.id = x.AuthorizationId})
        Catch

            Return View(collection)
        End Try
    End Function
    <Authorize(Roles:="AuthorizationsView")> _
    Function Email(ByVal id As Integer) As ActionResult
        Dim a = _db.GetAuthorization(id)
        Dim sendemail As Mail.iSendMail = New Mail.AuthorizationSendMail(a)

        ' sendemail.Send()
        Return Redirect(Request.UrlReferrer.AbsolutePath)
    End Function


End Class
