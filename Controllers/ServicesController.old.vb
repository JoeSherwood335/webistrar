Imports MvcPaging
<Authorize()> _
<HandleError()> _
Public Class ServicesController
    Inherits System.Web.Mvc.Controller
    Dim _dc As Repository
    Sub New()
        _dc = New Repository

    End Sub
    <Authorize(Roles:="ServiceView")> _
    Function Index() As ActionResult
        Return RedirectToAction("InProgress")
    End Function
    <Authorize(Roles:="ServiceView")> _
    Function Details(ByVal id As Int64) As ActionResult


        Dim b As New R2kDoiMvcBillingDataContext
        Dim billedamount = From a In b.BillingDetails _
                           Where a.ServiceId = id _
                           And Not (From bi In a.Billing.BillingCycles Where bi.Action.Name = "Voided").Any _
                           Select a.NumberOfUnits * a.UnitPrice



        If billedamount.Count > 0 Then
            ViewData("billedamount") = billedamount.Sum
        End If



        ' Dim joe As New Object

        Return View(_dc.GetService(id))
    End Function
    <Authorize(Roles:="ServiceEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult


        If Not Request.UrlReferrer Is Nothing Then
            ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Else
            ViewData("rs") = Url.RouteUrl(New With {.controller = "Services", .action = "Details", .id = id})
        End If


        Dim x = _dc.GetService(id)





        Return View(x)
    End Function
    <Authorize(Roles:="ServiceEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _dc.GetService(id)

        x.ud = Date.Now

        UpdateModel(x)

        'x.SetDetail("UnitOfServiceEquals", collection("UnitOfServiceEquals"))
        'x.SetDetail("TotalAmountAuthorized", collection("TotalAmountAuthorized"))
        'x.SetDetail("HCPCSCode", collection("HCPCSCode"))

        _dc.Save()

        Return Redirect(collection("rs")) 'RedirectToAction("Details", New With {.id = x.ServiceId})

    End Function
    <Authorize(Roles:="ServiceAssign")> _
    Function AssignService(ByVal id As Integer) As ActionResult


        If Not Request.UrlReferrer Is Nothing Then
            ViewData("rs") = Request.UrlReferrer.AbsolutePath
        Else
            ViewData("rs") = Url.RouteUrl(New With {.controller = "Services", .action = "Details", .id = id})
        End If


        Dim x = _dc.GetService(id)

        Return View(x)
    End Function
    <Authorize(Roles:="ServiceAssign")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function AssignService(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _dc.GetService(id)
        Try
            x.ud = Date.Now

            UpdateModel(x)

            Dim isendmail As Mail.iSendMail = New Mail.ServicesSendMail(x)

            isendmail.Send()

            _dc.Save()
            Return Redirect(collection("rs")) 'RedirectToAction("Details", New With {.id = x.ServiceId})
        Catch
            Return View(x)
        End Try
    End Function
    <Authorize(Roles:="ServiceView")> _
    Function NewServices(ByVal Page? As Integer) As ActionResult

        Dim MyServices = From a In _dc.GetServices _
                Where a.AssignedTo = Myapp.UserId(True) _
                Select a

        Dim MyNewServices = From a In MyServices.ToList _
                            Where a.GetStatus = Model.Service.Statuses.New _
                            Select a

        Dim _pageValue As Integer = 0

        If Page.HasValue Then
            _pageValue = Page - 1
        End If

        Return View(MyNewServices.OrderBy(Function(e) e.ed).ToPagedList(_pageValue, 20))
    End Function
    <Authorize(Roles:="ServiceView")> _
    Function Pending(ByVal Page? As Integer) As ActionResult

        Dim MyServices = From a In _dc.GetServices _
                Where a.AssignedTo = Myapp.UserId(True) _
                Select a

        Dim MyPendingServices = From a In MyServices.ToList _
                    Where a.GetStatus = Model.Service.Statuses.Pending _
                    Select a

        Dim _pageValue As Integer = 0

        If Page.HasValue Then
            _pageValue = Page - 1
        End If

        Return View(MyPendingServices.OrderBy(Function(e) e.ed).ToPagedList(_pageValue, 20))
    End Function
    <Authorize(Roles:="ServiceView")> _
    Function InProgress(ByVal Page? As Integer) As ActionResult

        Dim MyServices = From a In _dc.GetServices _
                Where a.AssignedTo = Myapp.UserId(True) _
                Select a

        Dim MyInProgressServices = From a In MyServices.ToList _
                            Where a.GetStatus = Model.Service.Statuses.InProgress _
                            Select a
        Dim _pageValue As Integer = 0

        If Page.HasValue Then
            _pageValue = Page - 1
        End If

        Return View(MyInProgressServices.OrderBy(Function(e) e.ed).ToPagedList(_pageValue, 20))
    End Function
    <Authorize(Roles:="ServiceView")> _
    Function Completed(ByVal Page? As Integer) As ActionResult


        Dim MyServices = From a In _dc.GetServices _
        Where a.AssignedTo = Myapp.UserId(True) _
        Select a

        Dim MyCompletedServices = From a In MyServices.ToList _
                            Where a.GetStatus = Model.Service.Statuses.Completed _
                            Select a

        'Return View(MyInProgressServices)
        Dim _pageValue As Integer = 0

        If Page.HasValue Then
            _pageValue = Page - 1
        End If

        Return View(MyCompletedServices.OrderByDescending(Function(e) e.ServiceEndDate).ToPagedList(_pageValue, 20))
    End Function
    <Authorize(Roles:="ServiceStart")> _
    Function StartService(ByVal id As Integer) As ActionResult
        If Not Request.UrlReferrer Is Nothing Then
            ViewData("rs") = String.Format("{1}?cm={0}", Myapp.user(True), Request.UrlReferrer.AbsolutePath)
        Else
            ViewData("rs") = Url.RouteUrl(New With {.controller = "Services", .action = "Details", .id = id, .cm = Myapp.user(True)})
        End If

        Dim x = _dc.GetService(id)
        If x.ServiceEndDate.HasValue Then
            ViewData("ServiceStartDate") = x.ServiceStartDate.Value.ToShortDateString
        End If
        Return View()
    End Function
    <Authorize(Roles:="ServiceStart")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function StartService(ByVal id As Integer, ByVal Collections As FormCollection) As ActionResult
        Try

            Dim x = _dc.GetService(id)

            x.ServiceStartDate = Collections("ServiceStartDate")

            _dc.Save()

            Return Redirect(Collections("rs"))
        Catch ex As Exception

            Return View()
        End Try

    End Function
    <Authorize(Roles:="ServiceEnd")> _
    Function EndService(ByVal id As Integer, ByVal cm As String) As ActionResult
        If Not Request.UrlReferrer Is Nothing Then

            ViewData("rs") = Request.UrlReferrer.AbsolutePath

            If Not String.IsNullOrEmpty(cm) Then
                ViewData("rs") = String.Format("{1}?cm={0}", cm, ViewData("rs"))
            End If
        Else
            ViewData("rs") = Url.RouteUrl(New With {.controller = "Services", .action = "Details", .id = id, .cm = Request.QueryString("cm")})
        End If


        Dim x = _dc.GetService(id)

        If x.ServiceEndDate.HasValue Then
            ViewData("ServiceEndDate") = x.ServiceEndDate.Value.ToShortDateString
        End If

        Return View()
    End Function
    <Authorize(Roles:="ServiceEnd")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function EndService(ByVal id As Integer, ByVal Collections As FormCollection) As ActionResult


        Dim x = _dc.GetService(id)
        If String.IsNullOrEmpty(Collections("ServiceEndDate")) Then
            x.ServiceEndDate = Nothing

            'x.NumberOfUnits = 0
        Else
            x.ServiceEndDate = Collections("ServiceEndDate")

        End If

        '_dc.Save()

        Dim y = _getAutoNumberOfUnits(x.ServiceId)

        If y And Collections("auto") = "on" Then
            x.NumberOfUnits = y '_getAutoNumberOfUnits(x.ServiceId)
        End If

        _dc.Save()

        Return Redirect(Collections("rs"))

    End Function
    Private Function _getAutoNumberOfUnits(ByVal id? As Integer) As Decimal?
        Dim dc As New R2kdoiMVCDataContext

        Dim service = _dc.GetService(id.Value)

        'Dim FeeSchedualIds = From fs In dc.FundingSources, asfc In fs.AssignFeesContainers _
        '                    Where fs.FundingSourceId = service.Authorization.FundingCounselor.FundingSource.FundingSourceId _
        '                    Select asfc.FeeSchedualId

        Dim FeeSchedualIds = From x In dc.AssignFeesContainers _
                  Where x.FundingSourceId = service.Authorization.FundingCounselor.FundingSource.FundingSourceId _
                  Select x.FeeSchedualId


        Dim fee = From fees In dc.Fees _
                  Where FeeSchedualIds.Contains(fees.MainId) And fees.LocationId = service.Authorization.Referral.ProgramInstance.LocationId And fees.ProductId = service.ProductId _
                  Select fees.UnitPrice, fees.MinUnits, fees.MinUnitTypeId, fees.UnitType.UnitType Take 1


        If fee.Count = 0 Then
            Return Nothing
        End If


        If fee.First.MinUnits.HasValue = Nothing Then
            Return Nothing
        ElseIf fee.First.UnitType = "Weeks" Then

            Dim ts = From a In dc.vCalendars _
                     Where a.isWeekday And (a.dt >= service.ServiceStartDate And a.dt <= service.ServiceEndDate) _
                     Select a.dt

            Dim NumberOfDaysInService As Integer = ts.Count 'DateDiff(DateInterval.Weekday, service.ServiceStartDate.Value, service.ServiceEndDate.Value, Microsoft.VisualBasic.FirstDayOfWeek.Monday)
            Dim MinimumNumberOfDayFor1Unit = fee.First.MinUnits


            Dim NumberOfUnits As Decimal = Math.Round((NumberOfDaysInService / 5) - 0.5, 0, MidpointRounding.AwayFromZero)

            NumberOfUnits += If((NumberOfDaysInService Mod 5) >= MinimumNumberOfDayFor1Unit, 1, 0)

            Return NumberOfUnits
        ElseIf fee.First.MinUnitTypeId = 7 Then ' hour
            If service.HasDetail("TimeWorked") Then
                Dim TimeWorked = service.GetDetail("TimeWorked")


                Dim Units As Decimal = Math.Round((TimeWorked / (fee.First.MinUnits * 60)) - 0.5, 0, MidpointRounding.AwayFromZero)

                'TimeWorked
                Return Units
            Else
                Return Nothing
            End If

        ElseIf fee.First.MinUnitTypeId = 8 Then 'min
            If service.HasDetail("TimeWorked") Then
                Dim TimeWorked = service.GetDetail("TimeWorked")


                Dim Units As Decimal = Math.Round((TimeWorked / (fee.First.MinUnits)) - 0.5, 0, MidpointRounding.AwayFromZero)

                'TimeWorked
                Return Units
            Else
                Return Nothing
            End If


        End If

    End Function
    Function GetAutoNumberOfUnits(ByVal id? As Integer)
        Dim json As New JsonResult

        Dim x = _getAutoNumberOfUnits(id)


        If x.HasValue Then
            json.Data = New With {.NumberOfUnits = x}
        End If

        Return json

    End Function
    <Authorize(Roles:="TimeWorked")> _
    <AcceptVerbs(HttpVerbs.Get)> _
    Function TimeWorked(ByVal id As Integer) As ActionResult

        Dim service = _dc.GetService(id)
        If service.HasDetail("TimeWorked") Then

            Dim m = service.GetDetail("TimeWorked")


            Dim x = (m - (m Mod 60)) / 60
            ViewData("Hours") = x


            ViewData("Minutes") = m Mod 60

        End If

        Return View()
    End Function
    <Authorize(Roles:="TimeWorked")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function TimeWorked(ByVal id As Integer, ByVal hours? As Integer, ByVal Minutes? As Integer) As ActionResult

        Dim service = _dc.GetService(id)

        Dim m As Integer

        If hours.HasValue Then
            m = hours * 60
        End If

        If Minutes.HasValue Then
            m += Minutes
        End If

        service.SetDetail("TimeWorked", m)
        Try
            _dc.Save()
            Return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath)
        Catch ex As Exception
            Return View()
        End Try

    End Function
    <Authorize(Roles:="ServiceEdit")> _
    <AcceptVerbs(HttpVerbs.Get)> _
    Function SetDetails(ByVal id As Integer, ByVal Name As String) As ActionResult

        ViewData("name") = Name
        Dim service = _dc.GetService(id)
        If service.HasDetail("TimeWorked") Then

            Dim m = service.GetDetail("TimeWorked")

            ViewData("value") = m

        End If

        Return View()
    End Function
    <Authorize(Roles:="ServiceEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function SetDetails(ByVal id As Integer, ByVal Name As String, ByVal Value As String) As ActionResult

        Dim service = _dc.GetService(id)
        service.SetDetail(Name, Value)

        _dc.Save()

        Return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath)

    End Function
    <Authorize(Roles:="ServiceComplete")> _
    Function Complete(ByVal id As Integer) As ActionResult

        Dim x = _dc.GetService(id)

        ViewData("hide") = False

        If x.ServiceOutcomeId.HasValue = True Then
            Throw New ServiceAllReadyCompletedOrCanceledException(x)


        End If

        Dim dc As New R2kDoiMvcBillingDataContext

        Dim c = Aggregate a In dc.BillingDetails.ToList _
                Where Myapp.GetBillingStatus(a.BillingId) = Myapp.Accrued And a.ServiceId = x.ServiceId _
                Into Count(a.BillingId)

        If Not x.ServiceEndDate.HasValue Then
            Throw New NullServiceEndDateException(x)
        End If

        If Not x.ServiceStartDate.HasValue Then
            Throw New NullServiceStartDateException(x)
        End If

        If c > 0 Then
            Throw New BillsInAcrueException(x)

        End If

        'If x.GetBillings.Where(Function(e) e.GetStatus = "Billed").Count > 0 Then

        'End If

        Return View(x)

    End Function
    <Authorize(Roles:="ServiceComplete")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Complete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _dc.GetService(id)

        x.SetDetail("CompletedOn", Myapp.Now)
        x.SetDetail("Completedby", Myapp.user)

        x.ud = Date.Now
        'UpdateModel(x)
        x.ServiceOutcomeId = 7

        _dc.Save()

        Return RedirectToAction("Details", New With {.id = id})

    End Function
    <Authorize(Roles:="ServiceCancel")> _
    Function Cancel(ByVal id As Integer) As ActionResult
        Dim x = _dc.GetService(id)

        ViewData("hide") = False

        If x.ServiceOutcomeId.HasValue = True Then

            Throw New ServiceAllReadyCompletedOrCanceledException(x)
        End If

        Dim dc As New R2kDoiMvcBillingDataContext

        Dim b = Aggregate a In dc.BillingDetails.ToList _
                Where Myapp.GetBillingStatus(a.BillingId) = Myapp.Accrued And a.ServiceId = x.ServiceId _
                Into Count(a.BillingId)

        If b > 0 Then
            Throw New BillsInAcrueException(x)
        End If

        Return View(x)
    End Function
    <Authorize(Roles:="ServiceCancel")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Cancel(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _dc.GetService(id)

        Dim c = From a In _dc.GetBillingDetails _
                Where a.ServiceId = id _
                Select a

        Dim NumberOfUnitsAllreadyBilled = Aggregate a In c.ToList _
                Where a.Billing.GetStatus <> "Voided" _
                Into Sum(a.NumberOfUnits)

        If NumberOfUnitsAllreadyBilled >= x.NumberOfUnitesAuthorized Then
            Throw New ServiceAllReadyBilledInFull(x)
        End If

        x.SetDetail("CanceledOn", Myapp.Now)
        x.SetDetail("Canceledby", Myapp.user)
        x.SetDetail("ProductId", _dc.GetProductIdfromServiceOutcomeId(collection("ServiceOutcomeId")))
        x.SetDetail("ServiceOutcomeId", collection("ServiceOutcomeId"))

        x.NumberOfUnits = x.NumberOfUnitesAuthorized - NumberOfUnitsAllreadyBilled

        x.ud = Date.Now

        ' UpdateModel(x)

        _dc.Save()


        Dim makebilling As Boolean = If(collection("MakeBilling"), "False")

        Dim b = _dc.CancelService(id, makebilling)

        If b.Id > 0 Then ' if there is makebill is false open service 

            Return RedirectToAction("Details", New With {.id = b.Id, .controller = "Billings"})
        Else
            Return RedirectToAction("Details", New With {.id = x.ServiceId})
        End If



    End Function
    <Authorize(Roles:="ServiceAccrue")> _
    Function Accrue(ByVal id As Integer)
        ViewData("Message") = "Please Click Create to Start a billing"


        Dim r2kbilling As New R2kDoiMvcBillingDataContext
        Dim r2k As New R2kdoiMVCDataContext

        Dim service = _dc.GetService(id)

        Dim Billsofthisservice = From x In r2kbilling.BillingDetails _
                                 Where x.ServiceId = service.ServiceId _
                                 Select x.BillingId, x.UnitPrice, x.NumberOfUnits

        Dim AmountAllReadyBilled = Aggregate x In Billsofthisservice.ToList _
                                   Where Myapp.GetBillingStatus(x.BillingId) <> Myapp.VOID _
                                   Into Sum(x.UnitPrice * x.NumberOfUnits)

        Dim UnitsAllReadyBilled = Aggregate x In Billsofthisservice.ToList _
                                  Where Myapp.GetBillingStatus(x.BillingId) <> Myapp.VOID _
                                  Into Sum(x.NumberOfUnits)



        If AmountAllReadyBilled >= service.AmountAuthorized Then
            ModelState.AddModelError("", "Authorization Service Allready Billed in Full")
        End If

        If service.NumberOfUnitesAuthorized < service.NumberOfUnits Then
            ModelState.AddModelError("", "Number of Units  Allready Billed in Full")
        End If

        If Not service.ServiceEndDate.HasValue Then
            Throw New NullServiceEndDateException(service)

        End If

        If service.Authorization.ApproveById.HasValue = False Then
            Throw New AuthorizationNotApprovedException(service)

        End If

        If service.NumberOfUnits = 0 Then
            Throw New NumberOfUnitsCantBeZeroException(service)

        End If

        If Not service.ServiceStartDate.HasValue Then
            Throw New NullServiceStartDateException(service)

        End If

        'If Not service.SchedualStartDate.HasValue Then
        '    Throw New AuthorizationServiceStartdateisNullException(service)

        'End If

        'If Not service.SchedualEndDate.HasValue Then
        '    Throw New AuthorizationServiceEndDateisNullException(service)

        'End If

        If service.SchedualEndDate < service.ServiceEndDate Then
            Throw New ServiceEndDateGreaterThanSchedualEndDateException(service)

        End If

        If service.SchedualStartDate > service.ServiceStartDate Then
            Throw New ServiceStartDateLessThanSchedualStartDateException(service)

        End If


        Dim a As New Model.Accruel(id)
        a.NumberOfUnits = service.NumberOfUnits - UnitsAllReadyBilled
        a.ServiceEndDate = service.ServiceEndDate
        a.NumberOfUnitsBilled = UnitsAllReadyBilled

        Return View(a)

    End Function
    <Authorize(Roles:="ServiceAccrue")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Accrue(ByVal id As Integer, ByVal collection As FormCollection)
        Dim service = _dc.GetService(id)
        Dim unitstobill = CDbl(collection("NumberOfUnits")) + CDbl(collection("NumberOfUnitsBilled"))

        'If CDbl(unitstobill) > service.NumberOfUnits Then
        '    Throw New Exception("Billing NumberofUnits exceded Services")
        'End If

        'If CDate(collection("ServiceEndDate")) > service.ServiceEndDate Then
        '    Throw New Exception("Billing ServicesEndDate exceded Services")
        'End If

        service.ud = Date.Now

        service.SetDetail("NumberOfUnits", unitstobill)
        service.SetDetail("ServiceEndDate", collection("ServiceEndDate"))
        service.SetDetail("ProductId", service.ProductId)

        _dc.Save()
        Dim x = _dc.AccruService(id)

        Return RedirectToAction("Details", New With {.id = x.Id, .controller = "Billings"})

    End Function
    <Authorize(Roles:="ServicePenny")> _
    Function Penny(ByVal id As Integer)
        ViewData("Message") = "Please Click Create to Start a Penny Billing"


        Dim service = _dc.GetService(id)

        Dim r2kbilling As New R2kDoiMvcBillingDataContext
        Dim r2k As New R2kdoiMVCDataContext

        Dim Billsofthisservice = From x In r2kbilling.BillingDetails _
                                 Where x.ServiceId = service.ServiceId _
                                 Select x.BillingId, x.UnitPrice, x.NumberOfUnits

        Dim AmountAllReadyBilled = Aggregate x In Billsofthisservice.ToList _
                                   Where Myapp.GetBillingStatus(x.BillingId) = Myapp.BILLED _
                                   Into Sum(x.UnitPrice * x.NumberOfUnits)

        Dim UnitsAllReadyBilled = Aggregate x In Billsofthisservice.ToList _
                                   Where Myapp.GetBillingStatus(x.BillingId) <> Myapp.VOID _
                                   Into Sum(x.NumberOfUnits)

        If AmountAllReadyBilled >= service.AmountAuthorized Then
            ModelState.AddModelError("", "Authorization Service Allready Billed in Full")
        End If


        ' Throw New Exception("Test Exception")

        If Not service.ServiceEndDate.HasValue Then
            Throw New NullServiceEndDateException(service)

        End If

        If service.NumberOfUnits = UnitsAllReadyBilled Then
            Throw New AllUnitsOfServiceHasAllreadyBeenBilledException(service)

        End If

        If service.NumberOfUnits = 0 Then
            Throw New NumberOfUnitsCantBeZeroException(service)

        End If

        If Not service.ServiceStartDate.HasValue Then
            Throw New NullServiceStartDateException(service)

        End If

        If service.SchedualEndDate < service.ServiceEndDate Then
            Throw New ServiceEndDateGreaterThanSchedualEndDateException(service)

        End If

        If service.SchedualStartDate > service.ServiceStartDate Then
            Throw New ServiceStartDateLessThanSchedualStartDateException(service)

        End If
        Dim a As New Model.Accruel(id)
        a.NumberOfUnits = service.NumberOfUnits - UnitsAllReadyBilled
        a.ServiceEndDate = service.ServiceEndDate
        a.NumberOfUnitsBilled = UnitsAllReadyBilled

        Return View(a)

    End Function
    <Authorize(Roles:="ServicePenny")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Penny(ByVal id As Integer, ByVal collection As FormCollection)
        Dim service = _dc.GetService(id)
        Dim unitstobill = CDbl(collection("NumberOfUnits")) + CDbl(collection("NumberOfUnitsBilled"))
        If CDbl(unitstobill) > service.NumberOfUnits Then
            Throw New Exception("Billing NumberofUnits exceded Services")
        End If

        If CDbl(collection("NumberOfUnits")) = 0 Then
            Throw New Exception("it can't be zero")
        End If

        If CDate(collection("ServiceEndDate")) > service.ServiceEndDate Then
            Throw New Exception("Billing ServicesEndDate exceded Services")
        End If

        If CDate(collection("ServiceEndDate")) > service.SchedualEndDate Then
            Throw New Exception("Billing ServicesEndDate exceded Authorization")
        End If

        service.ud = Date.Now

        service.SetDetail("NumberOfUnits", unitstobill)
        service.SetDetail("ServiceEndDate", collection("ServiceEndDate"))
        service.SetDetail("ProductId", _dc.GetProductIdfromServiceOutcomeId(collection("ServiceOutcomeId")))

        _dc.Save()
        Dim x = _dc.PennyBill(id)

        Return RedirectToAction("Details", New With {.id = x.Id, .controller = "Billings"})

    End Function
    <Authorize(Roles:="ServiceManual")> _
    Function Manual(ByVal id As Integer)


        Return View()
    End Function
    <Authorize(Roles:="ServiceManual")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Manual(ByVal id As Integer, ByVal collection As FormCollection)
        Dim service = _dc.GetService(id)

        Dim x = _dc.GetService(id)



        If String.IsNullOrEmpty(collection("NumberOfUnits")) Then
            ModelState.SetModelValue("NumberOfUnits", ValueProvider("NumberOfUnits"))
            ModelState.AddModelError("NumberOfUnits", "Number of Units Can't be Null")
        End If

        If String.IsNullOrEmpty(collection("UnitPrice")) Then
            ModelState.SetModelValue("UnitPrice", ValueProvider("UnitPrice"))
            ModelState.AddModelError("UnitPrice", "UnitPrice Can't be Null")
        End If

        If String.IsNullOrEmpty(collection("ServiceStartDate")) Then
            ModelState.SetModelValue("ServiceStartDate", ValueProvider("ServiceStartDate"))
            ModelState.AddModelError("ServiceStartDate", "Start Date Can't be Null")
        End If

        If String.IsNullOrEmpty(collection("ServiceEndDate")) Then
            ModelState.SetModelValue("ServiceEndDate", ValueProvider("ServiceEndDate"))
            ModelState.AddModelError("ServiceEndDate", "End Date Can't be Null")
        End If

        If Not ModelState.IsValid Then
            Return View()
        End If

        Dim numberofunites As Decimal = CDec(collection("NumberOfUnits"))
        Dim UnitPrice As Decimal = CDec(collection("UnitPrice"))
        Dim ServiceStartDate As Date = CDate(collection("ServiceStartDate"))
        Dim ServiceEndDate As Date = CDate(collection("ServiceEndDate"))

        Dim billing As Model.Billing.Billing = Myapp.ManualBill(x, numberofunites, UnitPrice, ServiceStartDate, ServiceEndDate)

        Return RedirectToAction("Details", New With {.id = billing.Id, .controller = "Billings"})

    End Function


End Class
