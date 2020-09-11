Namespace Model
    Partial Class note


        Function IsValid(Optional ByVal overide As Boolean = False) As Boolean
            Dim userinfo As Model.RegisteredUser = Myapp.GetUserInfo(Myapp.User)

            Dim _r2kdoi As New R2kdoiMVCDataContext

            Dim _userid As Integer = Myapp.UserId(Myapp.IsDebug)

            Dim s = (From a In _r2kdoi.GetSubordinates(Myapp.UserId(True)) Select a.UserId).ToList

            
            If Me.InputedBy = _userid Then
                Return True
                'if i am the author
            ElseIf (From a In Me.Info.Referrals Where s.Contains(a.ProgramInstance.SupervisorId) Select a).Count > 0 Then
                'ElseIf (From a In Me.Info.Referrals Where a.StatusId = R2kdoiMVC.Model.Referral.Statuses.Open And a.ProgramInstance.SupervisorId = Myapp.UserId Select a).Count > 0 Then
                Return True
                'if i am the supervisor of 
            ElseIf (From a In Me.Info.Referrals Where a.Authorizations.Any(Function(aut) aut.Services.Any(Function(ser) Not ser.ServiceOutcomeId.HasValue And ser.AssignedTo = _userid)) Select a.ProgramId()).Count() > 0 Then

                Return True
                'if i as a case manager have a service assigened to me that is not completed
            ElseIf (From a In Me.Info.Referrals Where a.Authorizations.Any(Function(aut) aut.Services.Any(Function(ser) s.Contains(ser.AssignedTo))) And a.StatusId = Model.Referral.Statuses.Open Select a.ProgramId()).Count() > 0 Then
                Return True
                'if i have a subordinate and he has an open program 
            ElseIf overide = True Then
                Return True
                'If i want to do do it when ever
            ElseIf userinfo.Profile.Name = "Intake" Or userinfo.Profile.Name = "Admin" Then
                'if current is a member of intake or admin group 
                Return True
            Else
                Return False
            End If

        End Function
        Public Enum Statuses As Integer
            Published = 2
            Draft = 1
        End Enum
            
    End Class
End Namespace
