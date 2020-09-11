Namespace Model
    Partial Class Placement
        'ViewData("JobTypes") = _db.SelectList("JobTypes")
        'ViewData("WageTypes") = _db.SelectList("WageTypes")
        'ViewData("Staffs") = _db.SelectList("Staffs")
        'ViewData("PlacementTypes") = _db.SelectList("PlacementTypes")

        'SelectList("JobTypes") = New SelectList(db.JobTypes, "JobTypeId", "JobType")
        'SelectList("WageTypes") = New SelectList(db.WageTypes, "WageTypeId", "WageType")
        'SelectList("Staffs") = New SelectList(db.RegisteredUsers.Where(Function(e) e.Active = True), "UserId", "UserName")
        'SelectList("PlacementTypes") = New SelectList(db.PlacementTypes, "PlacementTypeId", "PlacementType")

        Public Shared Function GetJobTypes() As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.JobTypes, "JobTypeId", "JobType")
        End Function

        Public Shared Function GetJobTypes(ByVal SelectedValue As Integer) As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.JobTypes, "JobTypeId", "JobType", selectedvalue)
        End Function

        Public Shared Function GetWageTypes() As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.WageTypes, "WageTypeId", "WageType")
        End Function
        Public Shared Function GetWageTypes(ByVal SelectedValue? As Integer) As SelectList
            Dim db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(db.WageTypes, "WageTypeId", "WageType", SelectedValue)
            Else
                Return New SelectList(db.WageTypes, "WageTypeId", "WageType")
            End If

        End Function

        Public Shared Function GetStaffs() As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.RegisteredUsers.Where(Function(e) e.Active = True), "UserId", "UserName")
        End Function
        Public Shared Function GetStaffs(ByVal SelectedValue As Integer) As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.RegisteredUsers.Where(Function(e) e.Active = True).Union(From user In db.RegisteredUsers Where user.UserId = SelectedValue).Distinct, "UserId", "UserName", SelectedValue)
        End Function

        Public Shared Function GetPlacementTypes() As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.PlacementTypes, "PlacementTypeId", "PlacementType")
        End Function
        Public Shared Function GetPlacementTypes(ByVal SelectedValue As Integer) As SelectList
            Dim db As New R2kdoiMVCDataContext

            Return New SelectList(db.PlacementTypes, "PlacementTypeId", "PlacementType", SelectedValue)
        End Function

        Public Shared Function GetEmployementPrep() As SelectList

            Dim AttendanceL As New List(Of SelectListItem)
            Dim Attendanceli As New SelectListItem
            Attendanceli.Text = "Yes"
            Attendanceli.Value = 1
            AttendanceL.Add(Attendanceli)

            Dim Attendanceli2 As New SelectListItem
            Attendanceli2.Text = "No"
            Attendanceli2.Value = 2
            AttendanceL.Add(Attendanceli2)

            Dim AttendanceSL As New SelectList(AttendanceL.AsEnumerable, "Value", "Text")
            Return AttendanceSL

        End Function

        Public Shared Function GetEmployementPrep(ByVal SelectedValue? As Integer) As SelectList

            Dim AttendanceL As New List(Of SelectListItem)

            Dim Attendanceli2 As New SelectListItem
            Attendanceli2.Text = "No"
            Attendanceli2.Value = 2
            AttendanceL.Add(Attendanceli2)

            Dim Attendanceli As New SelectListItem
            Attendanceli.Text = "Yes"
            Attendanceli.Value = 1
            AttendanceL.Add(Attendanceli)

            Dim AttendanceSL As SelectList

            If SelectedValue.HasValue Then
                AttendanceSL = New SelectList(AttendanceL.AsEnumerable, "Value", "Text", SelectedValue)
            Else
                AttendanceSL = New SelectList(AttendanceL.AsEnumerable, "Value", "Text")
            End If

            Return AttendanceSL

        End Function

    End Class
End Namespace
