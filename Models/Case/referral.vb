Namespace Model
    Partial Class Referral

        Public Enum Statuses
            Open = 1
            Closed = 2
        End Enum


        Public Function GetStatus() As Statuses
            If Me.StatusId = 1 Then
                Return Statuses.Open
            Else
                Return Statuses.Closed
            End If
        End Function


        Public Shared Function GetServiceOutcomeLists() As SelectList

            Dim dc As New R2kdoiMVCDataContext

            Dim x = From a In dc.ServiceOutcomes _
                    Where a.Category <> "Penny" And a.Category <> "" _
                    Select a

            Return New SelectList(x, "ServiceOutcomeId", "ServiceOutcomeName")
        End Function

        Public Shared Function GetServiceOutcomeLists(ByVal SelectedValue? As Integer) As SelectList

            Dim dc As New R2kdoiMVCDataContext

            Dim x = From a In dc.ServiceOutcomes _
                    Where a.Category <> "Penny" And a.Category <> "" _
                    Select a

            If SelectedValue.HasValue Then
                Return New SelectList(x, "ServiceOutcomeId", "ServiceOutcomeName", SelectedValue.Value)
            Else
                Return New SelectList(x, "ServiceOutcomeId", "ServiceOutcomeName")
            End If



        End Function

        Public Shared Function GetCRPServiceRequesteds() As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim fs = From a In dc.CRPServiceRequesteds _
                     Order By a.OrderBy _
                     Select a.ServiceRequestedId, a.ServiceRepuested

            Return New SelectList(fs, "ServiceRequestedId", "ServiceRepuested")
        End Function
        Public Shared Function GetCRPServiceRequesteds(ByVal SelectedValue As Integer) As SelectList

            Dim dc As New R2kdoiMVCDataContext
            Dim fs = From a In dc.CRPServiceRequesteds _
                     Order By a.OrderBy _
                     Select a.ServiceRequestedId, a.ServiceRepuested

            Return New SelectList(fs, "ServiceRequestedId", "ServiceRepuested", SelectedValue)
        End Function
        Public Shared Function GetPrograms() As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim programs = From pi In dc.ProgramInstances _
                            Where pi.InActive = False _
                            Order By pi.CostCenter _
                            Select New With {.ProgramName = String.Format("{0} {1} {2}", If(Not pi.InActive, pi.Program.Acronym, "Deleted"), pi.CostCenter, pi.Location.LocationName), .ProgramId = pi.id}
            'Or pi.id = SelectedReferral.ProgramId
            Return New SelectList(programs.AsEnumerable, "ProgramId", "ProgramName")
        End Function
        Public Shared Function GetPrograms(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim programs = From pi In dc.ProgramInstances _
                            Where pi.InActive = False Or pi.id = SelectedValue _
                            Order By pi.CostCenter _
                            Select New With {.ProgramName = String.Format("{0} {1} {2}", If(Not pi.InActive, pi.Program.Acronym, "Deleted"), pi.CostCenter, pi.Location.LocationName), .ProgramId = pi.id}
            'Or pi.id = SelectedReferral.ProgramId
            Return New SelectList(programs.AsEnumerable, "ProgramId", "ProgramName", SelectedValue)
        End Function

        Public Shared Function GetAssignedTo() As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim ru = From a In dc.RegisteredUsers _
                     Where a.Active = True Order By a.Username _
                     Select a.UserId, a.Username

            Return New SelectList(ru, "UserId", "Username")

        End Function
        Public Shared Function GetAssignedTo(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim ru = From a In dc.RegisteredUsers _
                     Where a.Active = True Or a.UserId = SelectedValue Order By a.Username _
                     Select a.UserId, a.Username
            Return New SelectList(ru, "UserId", "Username", SelectedValue)
        End Function
        Public Shared Function GetReferringCounselors(ByVal ReferralSources As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim rc = From a In dc.ReferringCounselors _
                    Where a.Enabled = True Order By a.DisplayName _
                    Select a.ReferringCounselorId, a.DisplayName

            Return New SelectList(rc, "ReferringCounselorId", "DisplayName")

        End Function
        Public Shared Function GetReferringCounselors(ByVal ReferralSources As Integer, ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim rc = From a In dc.ReferringCounselors _
                     Where a.Enabled = True Or a.ReferringCounselorId = SelectedValue Order By a.DisplayName _
                     Select a.ReferringCounselorId, a.DisplayName

            Return New SelectList(rc, "ReferringCounselorId", "DisplayName", SelectedValue)

        End Function

        Public Shared Function GetReferralSources() As SelectList
            Dim dc As New R2kdoiMVCDataContext


            Return New SelectList(dc.FundingSources.Where(Function(e) e.discontinued = False).OrderBy(Function(e) e.FullName), "FundingSourceId", "Acronym")


        End Function
        Public Shared Function GetReferralSources(ByVal ReferingCounslerId As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext


            Dim FundingSourceId As Integer = (From a In dc.ReferringCounselors Where a.ReferringCounselorId = ReferingCounslerId Select a.FundingSource Take 1).Single.FundingSourceId
            Return New SelectList(dc.FundingSources.Where(Function(e) e.discontinued = False).OrderBy(Function(e) e.FullName), "FundingSourceId", "Acronym", FundingSourceId)


        End Function


    End Class




End Namespace