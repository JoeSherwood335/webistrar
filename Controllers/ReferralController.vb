Imports <xmlns="http://schemas.microsoft.com/office/infopath/2003/myXSD/2011-07-27T15:16:27">
Namespace Controllers


    <HandleError()> _
    <Authorize()> _
    Public Class ReferralController
        Inherits System.Web.Mvc.Controller

        Dim _db As Repository
        Dim _notes As NotesRepository
        Sub New()
            _db = New Repository
            _notes = New NotesRepository
        End Sub
        <Authorize(Roles:="ReferralView")> _
        Function Index(ByVal Permilink As String) As ActionResult

            Return View(_db.getInfoByPermilink(Permilink))

        End Function

        <Authorize(Roles:="ReferralView")> _
        Function Details(ByVal id As Integer) As ActionResult

            Return View(_db.GetReferral(id))

        End Function

        <Authorize(Roles:="ReferralEnroll")> _
        Function Create(ByVal Permilink As String) As ActionResult

            Dim user As Model.Info = _db.getInfoByPermilink(Permilink)

            If user.FlagForHr Then
                Throw New Exception("See I.S. about adding a referral for this consumer")
            End If

            Dim referrals = From a In _db.GetAllReferrals _
                Where a.Info.Permilink = Permilink And a.StatusId = Model.Referral.Statuses.Open

            Dim ignore As String = HttpContext.Request.QueryString("ignore")


            'If referrals.Count > 0 And String.IsNullOrEmpty(ignore) Then
            '    Throw New YouAllreadyHaveAProgramOpenException(referrals.First.Info)
            'End If

            Dim s As String = Response.Cookies("ReferralSourceId").Value

            Return View()
        End Function
        <Authorize(Roles:="ReferralEnroll")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Create(ByVal Permilink As String, ByVal NewReferral As Model.Referral) As ActionResult


            Dim user As Model.Info = _db.getInfoByPermilink(Permilink)

            If user.FlagForHr Then
                Throw New Exception("See I.S. about adding a referral for this consumer")
            End If

            Try
                NewReferral.StatusId = 1
                NewReferral.InputedBy = Myapp.UserId
                NewReferral.ED = Date.Now
                NewReferral.UD = Date.Now


                NewReferral.RegistrarNo = Myapp.GetRegistrarNo(Permilink)




                For Each referral In user.Referrals
                    If referral.ProgramId = NewReferral.ProgramId And referral.StatusId = 1 Then

                        Throw New YouAllreadyHaveAProgramOpenException(user)
                    End If



                Next


                ' TODO: Add insert logic here
                _db.add(NewReferral)

                Return RedirectToAction("Details", New With {.id = NewReferral.ReferralId})
            Catch ex As Exception

                Return View(NewReferral)
            End Try
        End Function
        <Authorize(Roles:="ReferralEnroll")> _
        Function AddAdmin(ByVal Permilink As String) As ActionResult

            Dim referrals = From a In _db.GetAllReferrals _
                Where a.Info.Permilink = Permilink And a.StatusId = Model.Referral.Statuses.Open

            Dim ignore As String = HttpContext.Request.QueryString("ignore")


            If referrals.Count > 0 And String.IsNullOrEmpty(ignore) Then
                'Throw New YouAllreadyHaveAProgramOpenException(referrals.First.Info)
            End If


            'Dim ab As New Model.Referral

            'ab.AssignedTo = R2kdoiMVC.Myapp.Settings("AdminAssignedTo")

            'ab.ProgramId = R2kdoiMVC.Myapp.Settings("AdminProgram")


            Return View()
        End Function
        <Authorize(Roles:="ReferralEnroll")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function AddAdmin(ByVal Permilink As String, _
                           ByVal AuthorizationNumber As String, _
                           ByVal IntakeNumberOfUnitesAuthorized As String, _
                        ByVal IntakeAssignedTo As String, _
                        ByVal TransportationAssignedTo As String, _
                        ByVal Intake As String, _
                        ByVal IntakeUnitPrice As String, _
                        ByVal IntakeUnitTypeId As String, _
                        ByVal IntakeAmountAuthorized As String, _
                        ByVal IntakeSchedualStartDate As String, _
                        ByVal IntakeSchedualEndDate As String, _
                        ByVal TransportationNumberOfUnitesAuthorized As String, _
                        ByVal TransportationUnitPrice As String, _
                        ByVal TransportationUnitTypeId As String, _
                        ByVal TransportationAmountAuthorized As String, _
                        ByVal TransportationSchedualStartDate As String, _
                        ByVal TransportationSchedualEndDate As String, _
                        ByVal NewReferral As Model.Referral) As ActionResult

            Try
                _db.BeginTransaction()

                Dim r As Model.Referral

                Dim referrals = From a In _db.GetAllReferrals _
                         Where a.Info.Permilink = Permilink And _
                         a.StatusId = Model.Referral.Statuses.Open And _
                         a.ProgramId = R2kdoiMVC.Myapp.Settings("AdminProgram") _
                         Order By a.ED Descending Take 1

                Dim ignore As String = HttpContext.Request.QueryString("ignore")

                If referrals.Count > 0 Then
                    'Throw New YouAllreadyHaveAProgramOpenException(referrals.First.Info)
                    r = referrals.Single

                Else
                    NewReferral.AssignedTo = 154
                    NewReferral.StatusId = 1
                    NewReferral.InputedBy = Myapp.UserId
                    NewReferral.ED = Date.Now
                    NewReferral.UD = Date.Now

                    NewReferral.RegistrarNo = Myapp.GetRegistrarNo(Permilink)


                    r = NewReferral
                    _db.add(r)
                End If

                If String.IsNullOrEmpty(IntakeNumberOfUnitesAuthorized) And String.IsNullOrEmpty(TransportationNumberOfUnitesAuthorized) Then
                    Throw New Exception("intake and transportation are both Zero")
                End If

                If r.Info.FlagForHr Then
                    Throw New Exception("See I.S. about adding a referral for this consumer")
                End If


                Dim authorization As New Model.Authorization

                authorization.ReferralId = r.ReferralId
                authorization.AuthorizationDate = r.ReferralDate

                If String.IsNullOrEmpty(AuthorizationNumber) Then
                    Throw New Exception("AuthorizationNumber can not be blank")
                End If

                authorization.AuthorizationNumber = AuthorizationNumber
                authorization.FundingCounslerId = r.ReferingCounslerId


                authorization.ApproveById = Myapp.Settings("SystemAdminId")
                authorization.ApprovedByDate = Date.Now

                authorization.InputedBy = Myapp.UserId
                authorization.UD = Date.Now
                authorization.ED = Date.Now
                _db.add(authorization)



                If Not String.IsNullOrEmpty(IntakeNumberOfUnitesAuthorized) Then

                    If String.IsNullOrEmpty(IntakeAssignedTo) Then
                        Throw New Exception("Intake Assignedto not Assign")
                    End If

                    _db.AddDetail(authorization.AuthorizationID, "Intake", IntakeNumberOfUnitesAuthorized, IntakeUnitPrice, IntakeUnitTypeId, IntakeAmountAuthorized, IntakeSchedualStartDate, IntakeSchedualEndDate, Repository.ServiceType.Secondary)



                    Dim x = (From a In _db.GetServices Where a.AuthorizationId = authorization.AuthorizationID And a.ServiceName = "Intake" Take 1).Single


                    x.AssignedTo = IntakeAssignedTo
                    x.ProductId = Myapp.Settings("IntakeId")

                    _db.Save()
                End If

                If Not String.IsNullOrEmpty(TransportationNumberOfUnitesAuthorized) Then

                    If String.IsNullOrEmpty(TransportationAssignedTo) Then
                        Throw New Exception("Transportation Assignedto not Assign")
                    End If

                    _db.AddDetail(authorization.AuthorizationID, "Transportation", TransportationNumberOfUnitesAuthorized, TransportationUnitPrice, TransportationUnitTypeId, TransportationAmountAuthorized, TransportationSchedualStartDate, TransportationSchedualEndDate, Repository.ServiceType.Secondary)


                    Dim t = (From a In _db.GetServices Where a.AuthorizationId = authorization.AuthorizationID And a.ServiceName = "Transportation" Take 1).Single

                    t.AssignedTo = TransportationAssignedTo
                    t.ProductId = Myapp.Settings("TransportationId") '

                    _db.Save()
                End If
                _db.CommitTransaction()

                Return RedirectToAction("Details", New With {.id = r.ReferralId})


            Catch ex As Exception

                _db.RollbackTransaction()

                Throw ex


            End Try


        End Function
        <Authorize(Roles:="ReferralEdit")> _
        Function Edit(ByVal id As Integer) As ActionResult
            Dim x = _db.GetReferral(id)
            Return View(x)
        End Function
        <Authorize(Roles:="ReferralEdit")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here
                Dim x = _db.GetReferral(id)



                UpdateModel(x)


                x.InputedBy = Myapp.UserId
                x.UD = Date.Now


                _db.Save()

                Return RedirectToAction("Details", New With {.id = id})
            Catch
                Return View()
            End Try
        End Function
        <Authorize(Roles:="AuthorizationsCreate")> _
        Function NewAuthorization(ByVal Id As Integer) As ActionResult
            Dim authorization As New Model.Authorization

            Dim x = _db.GetReferral(Id)
            ViewData("FullName") = x.Info.GetFullName
            If x.Info.FlagForHr Then
                Throw New Exception("See I.S. about adding a referral for this consumer")
            End If
            If x.StatusId <> 1 Then
                Throw New ReferralIsClosedException(x)
            End If

            authorization.AuthorizationDate = Date.Now
            authorization.FundingCounslerId = x.ReferingCounslerId

            Return View(authorization)
        End Function
        <Authorize(Roles:="AuthorizationsCreate")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewAuthorization(ByVal id As Integer, ByVal NewAutho As Model.Authorization)
            Try
                NewAutho.ReferralId = id

                NewAutho.InputedBy = Myapp.UserId
                NewAutho.ED = Date.Now
                NewAutho.UD = Date.Now


                _db.add(NewAutho)
                Return RedirectToAction("Edit", New With {.id = NewAutho.AuthorizationID, .controller = "Authorizations"})
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="AddNonBillable")> _
        Function AddNonBillable(ByVal Id As Integer) As ActionResult
            Dim authorization As New Model.Authorization

            Dim x = _db.GetReferral(Id)
            ' ViewData("FullName") = x.Info.GetFullName

            If x.Info.FlagForHr Then
                Throw New Exception("See I.S. about adding a referral for this consumer")
            End If

            If x.StatusId <> 1 Then
                Throw New ReferralIsClosedException(x)
            End If

            'authorization.AuthorizationDate = Date.Now
            'authorization.FundingCounslerId = x.ReferingCounslerId
            ' Dim newservice As New Model.Service
            Return View()
        End Function
        <Authorize(Roles:="AddNonBillable")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function AddNonBillable(ByVal id As Integer, ByVal collection As FormCollection)
            Try
                _db.BeginTransaction()

                Dim r = _db.GetReferral(id)

                Dim NonBillableAuthorization As New Model.Authorization
                Dim unitprice As Double = 0
                Dim ammountauthorized As Double = 0
                NonBillableAuthorization.ReferralId = id
                NonBillableAuthorization.FundingCounslerId = Myapp.Settings("NonBillableFundingSourceId")
                NonBillableAuthorization.AuthorizationNumber = String.Format("NonBill{0}{1}{2}{3}{4}", Date.Now.Year, Date.Now.Month, Date.Now.Day, Date.Now.Hour, Date.Now.Minute)
                NonBillableAuthorization.AuthorizationDate = Date.Now
                NonBillableAuthorization.InputedBy = Myapp.UserId
                NonBillableAuthorization.ED = Date.Now
                NonBillableAuthorization.UD = Date.Now

                NonBillableAuthorization.AuthorizationDate = Date.Now
                NonBillableAuthorization.FundingCounslerId = r.ReferingCounslerId
                NonBillableAuthorization.ApproveById = Myapp.UserId(False)

                NonBillableAuthorization.ApprovedByDate = Date.Now

                _db.add(NonBillableAuthorization)

                Dim nonBillableService As New Model.Service




                _db.AddDetail(NonBillableAuthorization.AuthorizationID, "NonBillable", collection("NumberOfUnits"), unitprice, collection("UnitTypeId"), ammountauthorized, collection("SchedualStartDate"), collection("SchedualEndDate"), Repository.ServiceType.Secondary)



                Dim x = (From a In _db.GetServices Where a.AuthorizationId = NonBillableAuthorization.AuthorizationID And a.ServiceName = "NonBillable" Take 1).Single


                x.AssignedTo = collection("AssignedTo")
                x.ProductId = collection("ProductId")

                _db.Save()


                _db.CommitTransaction()

                Dim conpath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Referral", .action = "Index", .Permilink = x.Authorization.Referral.Info.Permilink})
                Return Redirect(String.Format("{0}{1}#ref-{2}", Myapp.GetServerPath, conpath, x.Authorization.Referral.ReferralId))

                Return RedirectToAction("Details", New With {.id = r.ReferralId})


            Catch ex As Exception

                _db.RollbackTransaction()

                Throw ex


            End Try
        End Function
        <AcceptVerbs(HttpVerbs.Get)> _
        Function Outcome(ByVal Permilink As String, ByVal id As Integer) As ActionResult


            Dim referral = _db.GetReferral(id)



            ' ViewData("ServiceOutcomes") = _db.SelectList("ServiceOutcomes")

            'ViewData("Status") = If(referral.StatusId = 1, True, False)


            Dim conpath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Referral", .action = "Index", .Permilink = referral.Info.Permilink})

            Return Redirect(String.Format("{0}{1}#ref-{2}", Myapp.GetServerPath, conpath, id))


            'Return View(referral)

        End Function
        <AcceptVerbs(HttpVerbs.Get)> _
        Function Complete(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Return RedirectToAction("Outcome", New With {.Permilink = Permilink, .id = id})

        End Function
        <Authorize(Roles:="ReferralReOpen")> _
        Function Open(ByVal id As Integer) As ActionResult


            Dim r = _db.GetReferral(id)
            Return View(r)

        End Function
        <Authorize(Roles:="ReferralReOpen")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Open(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim referral = _db.GetReferral(id)

            referral.StatusId = 1


            referral.ServiceOutcomeId = Nothing

            _db.Save()

            Myapp.AddNote(referral.Info.RegistrarNo, "General", String.Format("Referral Reopened for Program {0}", referral.ProgramInstance.Program.ProgramName, collection("Status")))

            Return RedirectToAction("Outcome", New With {.Permilink = referral.Info.Permilink, .id = id})
        End Function
        Function NewServiceOutcome(ByVal id As Integer)

            Dim r = _db.GetReferral(id)
            Return View(r)
        End Function
        <Authorize(Roles:="ReferralClose")> _
        Function Close(ByVal Permilink As String, ByVal id As Integer) As ActionResult

            Dim r = _db.GetReferral(id)
            Return View(r)
        End Function
        <Authorize(Roles:="ReferralClose")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Close(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult

            Dim referral = _db.GetReferral(id)


            ModelState.SetModelValue("ServiceOutcomeId", New ValueProviderResult(ValueProvider("ServiceOutcomeId").AttemptedValue, collection("ServiceOutcomeId"), System.Globalization.CultureInfo.CurrentCulture))
            Dim HasModelErrors As Boolean = False
            Dim CanceledOutcomes = _db.GetCanceledOutcomes()

            If Not String.IsNullOrEmpty(collection("ServiceOutcomeId")) Then
                referral.ServiceOutcomeId = collection("ServiceOutcomeId")
            End If

            referral.StatusId = 2

            ' Dim auth = referral.Authorizations.ToList


            'http://localhost:49380/Consumer/laura-buckhold-212522/Referral/Outcome/5076

            If String.IsNullOrEmpty(collection("ServiceOutcomeId")) Then
                Throw New Exception("Please set Program Outcome to close Referral")

            ElseIf referral.ProgramOutcomes.Count = 0 And Not CanceledOutcomes.Contains(referral.ServiceOutcomeId) Then
                Throw New Exception("You must complete at least one Service Outcome to close this Referral")

            ElseIf referral.Authorizations.ToList.Where(Function(e) e.Services.Any(Function(s) s.GetStatus <> Model.Service.Statuses.Completed)).Count > 0 Then
                'ModelState.AddModelError("", "You still have None Completed Services attached to this Referral")
                Throw New ServiceNotCompletedException(referral)

            Else
                Dim X = From A In referral.Authorizations
                For Each a As Model.Authorization In X
                    Dim y = From s In a.Services _
                            Where s.ServiceOutcome.Category = "Completed"

                    If y.Count() > 0 Then

                        _db.Validate(referral.RegistrarNo)
                    End If
                Next




                If String.IsNullOrEmpty(Permilink) Then
                    Permilink = referral.Info.Permilink
                End If

                _db.Save()

                Myapp.AddNote(referral.RegistrarNo, "General", String.Format("Closing Program {0} with the outcome of {1}", referral.ProgramInstance.Program.ProgramName, referral.ServiceOutcome.ServiceOutcomeName, collection("Status")))

                Return RedirectToAction("Outcome", New With {.id = id, .Permilink = Permilink})

            End If



        End Function
        <Authorize(Roles:="ReAssignService")> _
        Function ReAssignService(ByVal Id As Integer) As ActionResult



            Dim s = _db.GetService(Id)

            If s.GetStatus = Model.Service.Statuses.Completed Then
                Throw New ServiceNotUpdateableException(s)
            End If

            If s.Authorization.Referral.StatusId = 2 Then
                Throw New ReferralIsClosedException(s)
            End If



            Return View(s)
        End Function
        <Authorize(Roles:="ReAssignService")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function ReAssignService(ByVal Id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim s = _db.GetService(Id)

            UpdateModel(s)

            s.ud = DateTime.Now

            _db.Save()

            Dim conpath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Referral", .action = "Index", .Permilink = s.Authorization.Referral.Info.Permilink})

            Return Redirect(String.Format("{0}{1}#ref-{2}", Myapp.GetServerPath, conpath, s.Authorization.Referral.ReferralId))

        End Function
        <Authorize(Roles:="ProgramOutcomeST")> _
        Function NewSkillsTraining(ByVal Permilink As String, ByVal id As Integer, ByVal type As String) As ActionResult
            Try


                Dim st As New Model.ProgramOutcomes.StOutcome

                For Each a In Model.ProgramOutcomes.StOutcome.GetSelectList(Nothing)
                    ViewData(a.Key) = a.Value
                Next

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeST")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewSkillsTraining(ByVal Permilink As String, ByVal id As Integer, ByVal newStOutcome As Model.ProgramOutcomes.StOutcome) As ActionResult
            Try
                'Dim po = _db.GetProgramOutcome(id)

                Dim po As New Model.ProgramOutcome

                po.PoData = newStOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 1

                _db.add(po)

                _db.Save()

                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception

                For Each a In Model.ProgramOutcomes.StOutcome.GetSelectList(Nothing)
                    ViewData(a.Key) = a.Value
                Next
                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeST")> _
        Function SkillsTraining(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim st As New Model.ProgramOutcomes.StOutcome

                ViewData("Permilink") = Permilink
                ViewData("ReferralId") = po.ReferralId

                If Not po.PoData Is Nothing Then
                    st.ReadXml(po.PoData)
                End If

                For Each a In Model.ProgramOutcomes.StOutcome.GetSelectList(st.ProgramOutcome)
                    ViewData(a.Key) = a.Value
                Next

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeST")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function SkillsTraining(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim stpo As New Model.ProgramOutcomes.StOutcome

                UpdateModel(stpo)

                po.PoData = stpo.toXml(Myapp.User)

                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function
        <Authorize(Roles:="ProgramOutcomeWE")> _
        Function NewWorkEval(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try


                Dim st As New Model.ProgramOutcomes.WeOutcome

                'For Each a In Model.ProgramOutcomes.WeOutcome.GetSelectList(Nothing)
                '    ViewData(a.Key) = a.Value
                'Next

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWE")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function newWorkEval(ByVal Permilink As String, ByVal id As Integer, ByVal newweOutcome As Model.ProgramOutcomes.WeOutcome) As ActionResult
            Try
                'Dim po = _db.GetProgramOutcome(id)

                Dim po As New Model.ProgramOutcome

                po.PoData = newweOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 2

                _db.add(po)

                _db.Save()



                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception

                For Each a In Model.ProgramOutcomes.StOutcome.GetSelectList(Nothing)
                    ViewData(a.Key) = a.Value
                Next
                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWE")> _
        Function WorkEval(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim st As New Model.ProgramOutcomes.WeOutcome
                If Not po.PoData Is Nothing Then
                    st.readXml(po.PoData)
                End If
                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWE")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function WorkEval(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim stpo As New Model.ProgramOutcomes.WeOutcome

                UpdateModel(stpo)

                po.PoData = stpo.toXml(Myapp.User)

                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        Function NewWorkAdjustment(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try


                Dim st As New Model.ProgramOutcomes.WaOutcome

                For Each a In Model.ProgramOutcomes.WaOutcome.GetSelectList()
                    ViewData(a.Key) = a.Value
                Next

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewWorkAdjustment(ByVal Permilink As String, ByVal id As Integer, ByVal newweOutcome As Model.ProgramOutcomes.WaOutcome) As ActionResult
            Try
                Dim po As New Model.ProgramOutcome

                po.PoData = newweOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 3

                _db.add(po)

                _db.Save()



                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception

                For Each a In Model.ProgramOutcomes.WaOutcome.GetSelectList(Nothing)
                    ViewData(a.Key) = a.Value
                Next
                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        Function WorkAdjustment(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim st As New Model.ProgramOutcomes.WaOutcome
                If Not po.PoData Is Nothing Then
                    st.ReadXml(po.PoData)
                End If
                For Each a In Model.ProgramOutcomes.WaOutcome.GetSelectList(st)
                    ViewData(a.Key) = a.Value
                Next
                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function WorkAdjustment(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim stpo As New Model.ProgramOutcomes.WaOutcome

                UpdateModel(stpo)

                po.PoData = stpo.toXml(Myapp.User)
                po.ud = Date.Now
                po.InputedBy = Myapp.UserId
                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function
        <Authorize(Roles:="ProgramOutcomeJSST")> _
        Function NewJSST(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim st As New Model.ProgramOutcomes.JsstOutcome

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeJSST")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewJSST(ByVal Permilink As String, ByVal id As Integer, ByVal newweOutcome As Model.ProgramOutcomes.JsstOutcome) As ActionResult
            Try
                Dim po As New Model.ProgramOutcome

                po.PoData = newweOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 5

                _db.add(po)

                _db.Save()



                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception


                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeJSST")> _
        Function JSSt(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim st As New Model.ProgramOutcomes.JsstOutcome
                If Not po.PoData Is Nothing Then
                    st.ReadXml(po.PoData)
                End If
                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeJSST")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function JSSt(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim stpo As New Model.ProgramOutcomes.JsstOutcome

                UpdateModel(stpo)

                po.PoData = stpo.toXml(Myapp.User)
                po.ud = Date.Now
                po.InputedBy = Myapp.UserId
                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        Function Pd(ByVal Permilink As String, ByVal id As Integer)
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim st As New Model.ProgramOutcomes.PdOutcome
                If Not po.PoData Is Nothing Then
                    st.ReadXml(po.PoData)
                End If
                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        <AcceptVerbs(HttpVerbs.Post)> _
      Function pd(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim stpo As New Model.ProgramOutcomes.PdOutcome

                UpdateModel(stpo)

                po.PoData = stpo.toXml(Myapp.User)
                po.ud = Date.Now
                po.InputedBy = Myapp.UserId
                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        Function NewPd(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim st As New Model.ProgramOutcomes.PdOutcome

                Return View(st)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        <AcceptVerbs(HttpVerbs.Post)> _
      Function NewPd(ByVal Permilink As String, ByVal id As Integer, ByVal newPdOutcome As Model.ProgramOutcomes.PdOutcome) As ActionResult
            Try
                Dim po As New Model.ProgramOutcome

                po.PoData = newPdOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 6

                _db.add(po)

                _db.Save()



                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception


                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeDS")> _
        Function NewDS(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try

                Dim d As New System.IO.DirectoryInfo(Myapp.GetAttachmentTempPath("r", id))

                Dim x = <ul id="filelist">
                            <%= From a In d.GetFiles _
                                Select <li><%= System.IO.Path.GetFileName(a.FullName) %></li> %>
                        </ul>

                ViewData("filelist") = x.ToString

                Return View()
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeDS")> _
        <AcceptVerbs(HttpVerbs.Post)> _
      Function NewDS(ByVal Permilink As String, ByVal id As Integer, ByVal NewDSOutcome As Model.ProgramOutcomes.dsOutcome) As ActionResult

            Dim po As New Model.ProgramOutcome

            po.PoData = NewDSOutcome.toXml(Myapp.User)

            po.ReferralId = id
            po.InputedBy = Myapp.UserId
            po.Ed = Date.Now
            po.ud = Date.Now
            po.PoTypeId = 7

            'Dim noteid = Myapp.AddNote(Myapp.GetRegistrarNo(Permilink), "Datasheet", "PE for ds", New IO.DirectoryInfo(Myapp.GetAttachmentTempPath("r", id)))
            'po.PoData.Add(New XElement("noteid", noteid))

            _db.add(po)

            _db.Save()


            Dim xdoc As XDocument
            Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(Myapp.GetAttachmentTempPath("r", id))

            'If d.GetFiles.Count() > 1 Or d.GetFiles.Where(Function(e) e.Extension <> ".xml").Count >= 1 Then
            '    Throw New Exception("Invalid ")
            'End If



            Dim f As IO.FileInfo = d.GetFiles.Single(Function(e) e.Extension = ".xml")
            Dim destPath = String.Format("{0}\{1}.old", d.FullName, f.Name)
            f.MoveTo(destPath)

            Dim t As New IO.StreamReader(f.FullName)

            Dim s As String = t.ReadToEnd


            f = Nothing
            d = Nothing

            t.Close()
            t.Dispose()
            t = Nothing

            _db.addInfopathtoProgramOutcome(s, po.PoId)

            Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})

        End Function
        Function PrintProgramOutcome(ByVal id As Integer) As ActionResult

            Dim x = _db.GetProgramOutcome(id)


            Return View(x)




        End Function
        Function getInfopath(ByVal id) As InfoPathResult
            Dim po As Model.ProgramOutcome = _db.GetProgramOutcome(id)


            Dim ar As New InfoPathResult

            ar.Data = po.InfoPathData.ToString
            'po.SetDetail("EditBy", Myapp.user)
            '_db.Save()
            ar.FileName = "InfoPath.xml"

            Return ar


        End Function
        Function getcounslers(ByVal id As Integer) As JsonResult

            Return _db.getCounslers(id)
        End Function
        <AcceptVerbs(HttpVerbs.Post)> _
        Function AjaxUpload(ByVal rid As Integer, ByVal file As HttpPostedFileBase)

            Dim f As New FileUploadJsonResult

            Dim newpath As String = String.Format("{0}\{1}", Myapp.GetAttachmentTempPath("r", rid), System.IO.Path.GetFileName(file.FileName))


            file.SaveAs(newpath)


            Dim l As System.Xml.Linq.XDocument = XDocument.Load(newpath)

            'Dim [my1] As System.Xml.Linq.XNamespace

            Dim success = l.<GoalPlan>.<currentMonthyAvgSuccessRate>.Value
            Dim month = l.<GoalPlan>.<month>.Value
            Dim year = l.<GoalPlan>.<year>.Value



            f.Data = New With { _
                                .filename = String.Format("<li>{0}</li>", System.IO.Path.GetFileName(file.FileName)) _
                                , .message = String.Format("{0} uploaded successfully", System.IO.Path.GetFileName(file.FileName)) _
                                , .success = success, .month = month, .year = year _
                              }



            l = Nothing

            Return f
        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        Function Newjc(ByVal Permilink As String, ByVal id As Integer) As ActionResult

            Dim st As New Model.ProgramOutcomes.JCOutcome

            ViewData("WorkIndependentlyl") = st.WorkIndependentlyListSelectList()
            ViewData("TravelIndependentlyl") = st.TravelIndependentlyListSelectList()

            Return View(st)

        End Function
        <Authorize(Roles:="ProgramOutcomePD")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Newjc(ByVal Permilink As String, ByVal id As Integer, ByVal newjcOutcome As Model.ProgramOutcomes.JCOutcome) As ActionResult
            Dim po As New Model.ProgramOutcome

            po.PoData = newjcOutcome.toXml(Myapp.User)

            po.ReferralId = id
            po.InputedBy = Myapp.UserId
            po.Ed = Date.Now
            po.ud = Date.Now
            po.PoTypeId = 9

            _db.add(po)

            _db.Save()

            Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})

        End Function
        <Authorize(Roles:="ProgramOutcome")> _
       Function jc(ByVal Permilink As String, ByVal id As Integer) As ActionResult

            Dim po = _db.GetProgramOutcome(id)

            Dim st As New Model.ProgramOutcomes.JCOutcome

            If Not po.PoData Is Nothing Then
                st.ReadXml(po.PoData)
            End If

            ViewData("WorkIndependentlyl") = st.WorkIndependentlyListSelectList(st.WorkIndependently)
            ViewData("TravelIndependentlyl") = st.TravelIndependentlyListSelectList(st.TravelIndependently)

            Return View(st)

        End Function
        <Authorize(Roles:="ProgramOutcome")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function jc(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)

            Dim stpo As New Model.ProgramOutcomes.JCOutcome

            UpdateModel(stpo)

            po.PoData = stpo.toXml(Myapp.User)

            _db.Save()

            Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})

        End Function





        <Authorize(Roles:="ProgramOutcomeWA")> _
Function NewDDS(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try


                Dim DDS As New Model.ProgramOutcomes.ddsOutcome



                ViewData("CommunityTripssl") = DDS.GetSelectList(Nothing)
                ViewData("NumberOfNoneWorkRelatedActivitiessl") = DDS.GetSelectList(Nothing)


                Return View(DDS)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewDDS(ByVal Permilink As String, ByVal id As Integer, ByVal newweOutcome As Model.ProgramOutcomes.ddsOutcome) As ActionResult
            Try
                Dim po As New Model.ProgramOutcome

                po.PoData = newweOutcome.toXml(Myapp.User)

                po.ReferralId = id
                po.InputedBy = Myapp.UserId
                po.Ed = Date.Now
                po.ud = Date.Now
                po.PoTypeId = 7

                _db.add(po)

                _db.Save()



                Return RedirectToAction("Complete", New With {.Permilink = Permilink, .id = id})
            Catch ex As Exception
                Dim dds As New Model.ProgramOutcomes.ddsOutcome


                ViewData("CommunityTripssl") = dds.GetSelectList(newweOutcome.CommunityTrips)
                ViewData("NumberOfNoneWorkRelatedActivitiessl") = dds.GetSelectList(newweOutcome.NumberOfNoneWorkRelatedActivities)




                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        Function DDS(ByVal Permilink As String, ByVal id As Integer) As ActionResult
            Try
                Dim po = _db.GetProgramOutcome(id)

                Dim DDSe As New Model.ProgramOutcomes.ddsOutcome

                If Not po.PoData Is Nothing Then
                    DDSe.ReadXml(po.PoData)
                End If

                ViewData("CommunityTripssl") = DDSe.GetSelectList(DDSe.CommunityTrips)
                ViewData("NumberOfNoneWorkRelatedActivitiessl") = DDSe.GetSelectList(DDSe.NumberOfNoneWorkRelatedActivities)


                Return View(DDSe)
            Catch ex As Exception

                Return View()
            End Try
        End Function
        <Authorize(Roles:="ProgramOutcomeWA")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function DDs(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim po = _db.GetProgramOutcome(id)
            Try

                Dim DDSe As New Model.ProgramOutcomes.ddsOutcome

                UpdateModel(DDSe)

                po.PoData = DDSe.toXml(Myapp.User)
                po.ud = Date.Now
                po.InputedBy = Myapp.UserId
                _db.Save()

                Return RedirectToAction("Complete", New With {.permilink = po.Referral.Info.Permilink, .id = po.ReferralId})
            Catch ex As Exception

                Return View()
            End Try

        End Function


    End Class
End Namespace
