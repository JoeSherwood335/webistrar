Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Partial Class Repository


    Public Sub BeginTransaction()
        _r2kdoi.Connection.Open()

        _r2kdoi.Transaction = _r2kdoi.Connection.BeginTransaction

    End Sub





    Public Sub CommitTransaction()
        _r2kdoi.Transaction.Commit()
    End Sub


    Public Sub RollbackTransaction()
        _r2kdoi.Transaction.Rollback()
    End Sub

    Public Sub Add(ByVal NewReferral As Model.Referral)
        _r2kdoi.Referrals.InsertOnSubmit(NewReferral)
        _r2kdoi.SubmitChanges()

    End Sub
    Public Sub Add(ByVal NewAuthorization As Model.Authorization)
        _r2kdoi.Authorizations.InsertOnSubmit(NewAuthorization)
        _r2kdoi.SubmitChanges()


        Dim username = NewAuthorization.Referral.ProgramInstance.Supervisor.Username

        'Dim user = Myapp.GetUserInfo(username)

        ' Dim user = Membership.GetUser(username)

    
    End Sub
    Public Sub Add(ByVal NewOutcome As Model.ProgramOutcome)
        _r2kdoi.ProgramOutcomes.InsertOnSubmit(NewOutcome)
        _r2kdoi.SubmitChanges()
    End Sub

    Public Function GetAllReferrals() As System.Linq.IQueryable(Of Model.Referral)
        Return _r2kdoi.Referrals

    End Function

    Public Function Validate(ByVal registrarno As String) As Boolean

        _r2kdoi.ValidateConsumer(registrarno)
    End Function


    Public Function GetReferral(ByVal ReferralId As String) As Model.Referral
        Dim x = _r2kdoi.Referrals.Single(Function(e) e.ReferralId = ReferralId)

        Return x
    End Function

    Public Function GetProgramOutcome(ByVal Id As Integer) As Model.ProgramOutcome
        Dim x = _r2kdoi.ProgramOutcomes.Single(Function(e) e.PoId = Id)

        Return x
    End Function

    Public Function GetReferralsByInfo(ByVal Permilink As String) As System.Linq.IQueryable(Of Model.Referral)
        Return _r2kdoi.Referrals.Where(Function(e) e.Info.Permilink = Permilink)

    End Function

    Public Function getCounslers(ByVal FundingSourceId As Integer) As Object
        Dim json As New JsonResult

        Dim rs = From r In _r2kdoi.ReferringCounselors _
                 Where r.FundingSourceId = FundingSourceId And r.Enabled = True _
                 Order By r.LastName, r.FirstName _
                 Select r.ReferringCounselorId, r.DisplayName


        json.Data = rs

        Return json
    End Function

    Public Sub addInfopathtoProgramOutcome(ByVal infopathdata As String, ByVal poid As Integer)

        _r2kdoi.AddInfopathtoProgramOutcome(infopathdata.Replace("UTF-8", "UTF-16"), poid)
    End Sub
End Class
