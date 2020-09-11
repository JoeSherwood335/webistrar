Namespace Model
    Partial Class Authorization

        Public Shared Function getReferalSources() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.FundingSources, "FundingSourceId", "Acronym")
        End Function

        Public Shared Function getReferalSources(ByVal referringCounsler As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim fundingsource = From a In dc.ReferringCounselors _
                                Where a.ReferringCounselorId = referringCounsler _
                                Select a.FundingSourceId


            Return New SelectList(dc.FundingSources, "FundingSourceId", "Acronym", fundingsource.First)
        End Function

        Public Shared Function getReferringCounslers() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.ReferringCounselors, "ReferringCounselorId", "DisplayName")

        End Function

        Public Shared Function getReferringCounslers(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.ReferringCounselors, "ReferringCounselorId", "DisplayName")

        End Function

        Public Shared Function getUnitType() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.UnitTypes, "UnitTypeId", "Unittype")

        End Function

        Public Shared Function getUnitType(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.UnitTypes, "UnitTypeId", "Unittype", SelectedValue)

        End Function

        '       ViewData("referalsources") = New SelectList(referalsources, "FundingSourceId", "Acronym", x.ReferringCounselor.FundingSourceId)
        'ViewData("referalCounslers") = New SelectList(referringCounslers, "ReferringCounselorId", "DisplayName", x.ReferingCounslerId)
        'ViewData("unittype") = New SelectList(db.UnitTypes, "UnitTypeId", "Unittype")
    End Class
End Namespace