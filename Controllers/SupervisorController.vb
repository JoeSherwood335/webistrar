<Authorize()> _
<HandleError()> _
Public Class SupervisorController
    Inherits System.Web.Mvc.Controller
    Dim _r2kdoi As R2kdoiMVCDataContext
    Sub New()
        _r2kdoi = New R2kdoiMVCDataContext
    End Sub


    '
    ' GET: /Supervisor/

    Function Index() As ActionResult
        Dim dc As New R2kdoiMVCDataContext
        Dim a = From b In dc.GetSubordinatesView(Myapp.UserId)


        Return View(a)
    End Function


    Function Cases(ByVal name As String) As ActionResult
        Dim dc As New R2kdoiMVCDataContext


        Dim listofOpenPrograms = From a In dc.Services _
                                 Where a.AssignedTo = Myapp.UserId(True) And a.Authorization.Referral.StatusId = Model.Referral.Statuses.Open _
                                 Select New Model.CasesView With {.ProgramName = a.Authorization.Referral.ProgramInstance.Program.ProgramName, _
                                                                     .RegistrarNo = a.Authorization.Referral.Info.RegistrarNo, _
                                                                     .ReferralId = a.Authorization.Referral.ReferralId, _
                                                                     .LastName = a.Authorization.Referral.Info.LastName, _
                                                                     .FirstName = a.Authorization.Referral.Info.FirstName _
                                                                     } Distinct


        Return View(listofOpenPrograms)
    End Function


    Function Transfer(ByVal CurrentCounsler As String, ByVal registrarNo As String) As ActionResult


        Return View()
    End Function
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Transfer(ByVal CurrentCounsler As String, ByVal NewCounsler As String, ByVal registrarNo As String) As ActionResult
        Dim dc As New R2kdoiMVCDataContext



        dc.ReAssignCase(registrarNo, NewCounsler, Myapp.UserId(True))




        Return RedirectToAction("Cases", New With {.cm = CurrentCounsler})
    End Function


    Function Audit() As ActionResult
        Dim a = (From b In _r2kdoi.GetSubordinatesView(Myapp.UserId(True)) _
                Select b.UserId Take 1).ToList





        Dim x = From b In _r2kdoi.Services _
                Where b.Authorization.Referral.StatusId = R2kdoiMVC.Model.Referral.Statuses.Open And a.Contains(b.Authorization.Referral.ProgramInstance.SupervisorId)

        Return View(x)
    End Function


End Class
