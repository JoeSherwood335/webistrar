Imports MvcPaging

Namespace Controllers

    <HandleError()> _
    Public Class BillingsController
        Inherits System.Web.Mvc.Controller
        Dim db As Repository

        Sub New()
            db = New Repository
        End Sub
        '
        ' GET: /Billings/
        <Authorize(Roles:="BillsView")> _
        Function Index(ByVal Search As String, ByVal Sort As String, ByVal dir As String, ByVal page? As Integer, ByVal sstatus As String) As ActionResult

            Dim pagelist As Integer = 0

            If page.HasValue Then
                pagelist = page.Value - 1

            End If

            If String.IsNullOrEmpty(sstatus) Then
                sstatus = Myapp.ACCRUED
            End If

            Dim userid = Myapp.UserId(True)


            Dim y = From a In db.GetAllBillings Where a.Inputedby = userid
                                    



            y = _GetBillingList(y, Search, Sort)



            Dim ListOfBillings = From a In y _
                Select Status = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First, _
                       statusDate = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First, _
                       ProgramAcronym = a.Program.Acronym, _
                       a.Id, _
                       a.Program.ProgramName, _
                       a.CostCenter, _
                       a.Info.RegistrarNo, _
                       a.Info.LastName, _
                       a.Info.FirstName, _
                       a.Info.Permilink, _
                       a.FundingSource.FullName, _
                       a.FundingSource.Acronym, _
                       a.AuthorizationNo, _
                       a.InputedByRU.Username, _
                       a.DateIssued, _
                       AmountBilled = (Aggregate b In a.BillingDetails Into Sum(b.UnitPrice * b.NumberOfUnits)), _
                       StartDate = (Aggregate b In a.BillingDetails Into Min(b.StartDate)), _
                       EndDate = (Aggregate b In a.BillingDetails Into Max(b.EndDate)), _
                       ProgramSupervisor = a.ProgramSupervisor.Username




            Return View(ListOfBillings.ToPagedList(pagelist, 20))

        End Function

        Function _GetBillingList(ByVal y As System.Linq.IQueryable(Of Model.Billing.Billing), ByVal Search As String, ByVal Sort As String) As System.Linq.IQueryable(Of Model.Billing.Billing)

            Dim EmptyResults As Boolean = True


            If Myapp.IsUserOverwrite Then

                y = y.Where(Function(e) e.Inputedby = Myapp.UserId(True))

                EmptyResults = False
            End If

            If Not String.IsNullOrEmpty(Search) Then

                Search = Search.Replace("  ", " ")

                Search = Search.Trim

                Dim SearchArray As String() = Search.Split(" ")




                For Each s In Search.Split(" ")
                    Dim LSearch As String = s



                    Dim FoundcName = From a In db.GetBillingInfos _
                                         Where a.LastName.Contains(LSearch) Or a.FirstName.Contains(LSearch) _
                                         Select a.RegistrarNo

                    If FoundcName.Count() > 0 Then

                        y = y.Where(Function(e) FoundcName.Contains(e.RegistrarNo))

                        EmptyResults = False

                    End If


                    'Dim FoundSupervisor = From a In db.GetallProgramInstance _
                    '        Where a.Supervisor.Username = LSearch _
                    '        Select a.SupervisorId Take 1





                    Dim FoundRegistrarno = From a In db.GetBillingInfos _
                                         Where a.RegistrarNo = LSearch _
                                         Select a.RegistrarNo

                    If FoundRegistrarno.Count() > 0 Then

                        Dim registerno As String = FoundRegistrarno.First

                        y = y.Where(Function(e) e.RegistrarNo = registerno)

                        EmptyResults = False
                    End If



                    Dim FoundSSN = From a In db.GetBillingInfos _
                                         Where a.SSN = LSearch _
                                         Select a.SSN

                    If FoundSSN.Count() > 0 Then
                        Dim ssn As String = FoundSSN.First
                        y = y.Where(Function(e) ssn = e.Info.SSN)
                        EmptyResults = False
                    End If

                    Dim FoundRef = From a In db.GetBillingInfos _
                     Where a.REF = LSearch _
                     Select a.REF

                    If FoundRef.Count() > 0 Then
                        Dim ssn As String = FoundRef.First
                        y = y.Where(Function(e) ssn = e.Info.REF)
                        EmptyResults = False
                    End If



                    Dim foundFundingSources = From a In db.GetBillingFundingSources _
                                              Where a.Acronym = LSearch _
                                              Select a.FundingSourceId Take 1

                    If foundFundingSources.Count > 0 Then
                        Dim id As Int16 = foundFundingSources.First
                        y = y.Where(Function(e) (e.FundingSourceId = id))
                        EmptyResults = False
                    End If

                    Dim FoundAuthorizations = From a In db.GetAllBillings _
                                              Where a.AuthorizationNo = LSearch _
                                              Select a.Id

                    If FoundAuthorizations.Count > 0 Then
                        y = y.Where(Function(e) FoundAuthorizations.Contains(e.Id))
                        EmptyResults = False
                    End If


                    Dim FoundActions = From a In db.GetAllActions _
                                       Where a.Name = LSearch _
                                       Select a.ActionId

                    If FoundActions.Count > 0 Then
                        Dim id As Int16 = FoundActions.First

                        y = y.Where(Function(e) e.BillingCycles.OrderByDescending(Function(b) b.ActionDate).First.ActionId = id)
                        EmptyResults = False
                    End If


                    If s.ToLower.Contains("imsupervising") Then
                        Dim id = Myapp.UserId
                        y = y.Where(Function(e) e.ProgramSupervisorId = id)
                        EmptyResults = False
                    End If

                Next

                If EmptyResults Then
                    y = y.Where(Function(e) e.ProgramSupervisorId = -1)
                End If
            End If






            If Not String.IsNullOrEmpty(Sort) Then
                If Sort = "Name" Then
                    y = y.OrderBy(Function(e) e.Info.LastName).OrderBy(Function(e) e.Info.FirstName)
                ElseIf Sort = "Status" Then
                    y = y.OrderBy(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First)
                ElseIf Sort = "sDates" Then
                    y = y.OrderBy(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First)
                ElseIf Sort = "iDates" Then
                    y = y.OrderBy(Function(a) a.DateIssued)
                End If
            Else
                y = y.OrderBy(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First)
            End If

            Return y

        End Function
        <Authorize(Roles:="ManagerView")> _
            Function ManagerView(ByVal Search As String, ByVal Sort As String, ByVal dir As String, ByVal Page? As Integer) As ActionResult


            Dim pagelist As Integer = 0

            If Page.HasValue Then
                pagelist = Page.Value - 1

            End If

            'If String.IsNullOrEmpty(sstatus) Then
            '    sstatus = Myapp.ACCRUED
            'End If

            Dim ListOfSubordinateIds = (From a In Myapp.GetSubordinates(Myapp.UserId) _
                    Select a.UserId).ToList

            Dim ListOfMyBills = From a In db.GetAllBillings _
                     Where ListOfSubordinateIds.Contains(a.ProgramSupervisorId) Or ListOfSubordinateIds.Contains(a.BillingManagerId) _
                     Select a


            Dim y = _GetBillingList(ListOfMyBills, Search, Sort)

            If Not String.IsNullOrEmpty(Search) Then

            End If

            y = y.Where(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First = Myapp.BILLED)

            Dim ListofMyBillsView = From a In y _
                                    Select a.Id, _
                                           status = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First, _
                                           statusDate = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First, _
                                           a.Program.ProgramName, _
                                           ProgramAcronym = a.Program.Acronym, _
                                           a.CostCenter, _
                                           a.Info.LastName, _
                                           a.Info.FirstName, _
                                           a.Info.Permilink, _
                                           a.FundingSource.FullName, _
                                           a.FundingSource.Acronym, _
                                           a.AuthorizationNo, _
                                           a.InputedByRU.Username, _
                                           a.DateIssued, _
                                           AmountBilled = (Aggregate b In a.BillingDetails Into Sum(b.UnitPrice * b.NumberOfUnits)).ToString, _
                                           StartDate = (Aggregate b In a.BillingDetails Into Min(b.StartDate)), _
                                           EndDate = (Aggregate b In a.BillingDetails Into Max(b.EndDate)), _
                                           ProgramSupervisor = a.ProgramSupervisor.Username




            Return View(ListofMyBillsView.ToPagedList(pagelist, 20))

        End Function

        <Authorize(Roles:="BillsViewNotAccepted")> _
        Function BillingOfficeView(ByVal Search As String, ByVal Sort As String, ByVal dir As String, ByVal Page? As Integer) As ActionResult
            Dim pagelist As Integer = 0

            If Page.HasValue Then
                pagelist = Page.Value - 1

            End If

            'If String.IsNullOrEmpty(sstatus) Then
            '    sstatus = Myapp.ACCRUED
            'End If

            Dim ListOf110s = From a In db.GetAllBillings

            Dim Filtered110s = _GetBillingList(ListOf110s, Search, Sort)


            Filtered110s = Filtered110s.Where(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First = Myapp.APPROVED)

            Dim ListofNotAccepted110s = From a In Filtered110s _
                                    Select a.Id, _
                                           status = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First, _
                                           statusDate = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First, _
                                           a.Program.ProgramName, _
                                           ProgramAcronym = a.Program.Acronym, _
                                           a.CostCenter, _
                                           a.Info.LastName, _
                                           a.Info.FirstName, _
                                           a.Info.Permilink, _
                                           a.FundingSource.FullName, _
                                           a.FundingSource.Acronym, _
                                           a.AuthorizationNo, _
                                           a.InputedByRU.Username, _
                                           a.DateIssued, _
                                           AmountBilled = (Aggregate b In a.BillingDetails Into Sum(b.UnitPrice * b.NumberOfUnits)).ToString, _
                                           StartDate = (Aggregate b In a.BillingDetails Into Min(b.StartDate)), _
                                           EndDate = (Aggregate b In a.BillingDetails Into Max(b.EndDate)), _
                                           ProgramSupervisor = a.ProgramSupervisor.Username



            Return View(ListofNotAccepted110s.ToPagedList(pagelist, 20))
        End Function

        '
        ' GET: /Billings/Details/5
        <Authorize(Roles:="BillsView")> _
        Function Details(ByVal id As Integer) As ActionResult


            Dim _db As New R2kDoiMvcBillingDataContext

            Dim x = From a In _db.BillingCycles _
                    Where a.BillingId = id And Not a.Action.Name = "Void" _
                    Order By a.ActionDate Descending _
                    Select a.Action.Name Take 1


            If x.Count > 0 Then
                ViewData("Status") = x.First
            End If

            Return View(db.GetBilling(id))
        End Function

        '
        ' GET: /Billings/Create

        <Authorize(Roles:="BillsStart")> _
        Function Start(ByVal id As Integer)
            Return View()
        End Function
        <Authorize(Roles:="BillsStart")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Start(ByVal id As Integer, ByVal collection As FormCollection)
            db.StartBill(id)

            Return RedirectToAction("Details", New With {.id = id})
        End Function
        <Authorize(Roles:="BillsApprove")> _
        Function Approve(ByVal id As Integer)
            Dim x = db.GetBilling(id)

            Return View(x)
        End Function
        <Authorize(Roles:="BillsApprove")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Approve(ByVal id As Integer, ByVal collection As FormCollection)
            db.ApproveBill(id)
            Dim r2k As New R2kdoiMVCDataContext

            r2k.SubmitChanges()

            Return RedirectToAction("ManagerView")
        End Function

        <Authorize(Roles:="BillsVoid")> _
        Function Void(ByVal id As Integer)
            Dim x = db.GetBilling(id)

            Return View(x)
        End Function
        <Authorize(Roles:="BillsVoid")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Void(ByVal id As Integer, ByVal collection As FormCollection)
            db.voidbill(id)
            Dim r2k As New R2kdoiMVCDataContext

            r2k.SubmitChanges()

            Return RedirectToAction("Details", New With {.id = id})
        End Function


        <Authorize(Roles:="BillsBackup")> _
        Function Backup(ByVal id As Integer)
            Dim x = db.GetBilling(id)

            Return View(x)
        End Function
        <Authorize(Roles:="BillsBackup")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Backup(ByVal id As Integer, ByVal collection As FormCollection)
            db.BackupBillingInQ(id)
            Return RedirectToAction("Details", New With {.id = id})
        End Function


        <Authorize(Roles:="BillsAccept")> _
        Function Accept(ByVal id As Integer)
            Dim x = db.GetBilling(id)
            Return View(x)
        End Function
        <Authorize(Roles:="BillsAccept")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Accept(ByVal id As Integer, ByVal collection As FormCollection)
            db.AcceptBill(id)
            Return RedirectToAction("BillingOfficeView") ', New With {.id = id})
        End Function




        <Authorize(Roles:="BillsViewAccepted ")> _
        Function Accepted(ByVal Search As String, ByVal Sort As String, ByVal dir As String, ByVal Page? As Integer) As ActionResult


            Dim pagelist As Integer = 0

            If Page.HasValue Then
                pagelist = Page.Value - 1

            End If

            'If String.IsNullOrEmpty(sstatus) Then
            '    sstatus = Myapp.ACCRUED
            'End If

            Dim ListOf110s = From a In db.GetAllBillings

            Dim Filtered110s = _GetBillingList(ListOf110s, Search, Sort)


            Filtered110s = Filtered110s.Where(Function(a) a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First = Myapp.ACCEPTED)

            Dim ListofNotAccepted110s = From a In Filtered110s _
                                    Select a.Id, _
                                           status = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.Action.Name).First, _
                                           statusDate = a.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Select(Function(e) e.ActionDate).First, _
                                           a.Program.ProgramName, _
                                           ProgramAcronym = a.Program.Acronym, _
                                           a.CostCenter, _
                                           a.Info.LastName, _
                                           a.Info.FirstName, _
                                           a.Info.Permilink, _
                                           a.FundingSource.FullName, _
                                           a.FundingSource.Acronym, _
                                           a.AuthorizationNo, _
                                           a.InputedByRU.Username, _
                                           a.DateIssued, _
                                           AmountBilled = (Aggregate b In a.BillingDetails Into Sum(b.UnitPrice * b.NumberOfUnits)).ToString, _
                                           StartDate = (Aggregate b In a.BillingDetails Into Min(b.StartDate)), _
                                           EndDate = (Aggregate b In a.BillingDetails Into Max(b.EndDate)), _
                                           ProgramSupervisor = a.ProgramSupervisor.Username



            Return View(ListofNotAccepted110s.ToPagedList(pagelist, 20))







        End Function


    End Class




End Namespace