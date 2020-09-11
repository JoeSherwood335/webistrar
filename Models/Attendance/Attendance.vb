Namespace Model.Attendance
    Partial Class Attendance

        Public Shared Function GetAbsentType() As SelectList
            Dim dc As New r2kdoiMvcAttendanceDataContext

            Dim AssignedTos = (From a In dc.AttendanceTypes Where a.IsAbsent > 0)

            Return New SelectList(AssignedTos, "AttendanceTypeId", "AttendanceType")


        End Function


        Public Shared Function GetAbsentType(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New r2kdoiMvcAttendanceDataContext

            Dim AssignedTos = (From a In dc.AttendanceTypes Where a.IsAbsent > 0)

        
            Return New SelectList(AssignedTos, "AttendanceTypeId", "AttendanceType", SelectedValue)
        
        End Function
    End Class
End Namespace
