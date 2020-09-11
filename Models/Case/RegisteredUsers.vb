Namespace Model
    Partial Class RegisteredUser
        Public Shared Function GetProfiles() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.Profiles, "ProfileId", "Name")

        End Function

        Public Shared Function GetProfiles(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Return New SelectList(dc.Profiles, "ProfileId", "Name", SelectedValue)

        End Function

        Public Shared Function GetSupervisors() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim SupervisorDDL = From i In dc.RegisteredUsers Where i.Active = True Select i.UserId, i.Username

            Return New SelectList(SupervisorDDL, "UserId", "Username")
        End Function

        Public Shared Function GetSupervisors(ByVal SelectedValue? As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim SupervisorDDL = From i In dc.RegisteredUsers Where i.Active = True Select i.UserId, i.Username

            If SelectedValue.HasValue Then
                Return New SelectList(SupervisorDDL, "UserId", "Username", SelectedValue.Value)
            Else
                Return New SelectList(SupervisorDDL, "UserId", "Username")
            End If

        End Function
    End Class
End Namespace

