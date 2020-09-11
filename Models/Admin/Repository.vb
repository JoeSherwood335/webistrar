Partial Class Repository


    Public Sub add(ByVal newProfile As Model.Profile)
        _r2kdoi.Profiles.InsertOnSubmit(newProfile)
        Save()
    End Sub

    Public Sub add(ByVal newProfileGroup As Model.ProfileGroupContainer)
        _r2kdoi.ProfileGroupContainers.InsertOnSubmit(newProfileGroup)
        Save()
    End Sub

    Function getProfile(ByVal id As Integer) As Model.Profile
        Dim profile = From a In _r2kdoi.Profiles _
                      Where a.ProfileId = id _
                      Select a

        If profile.Count = 0 Then
            Throw New RecordNotFoundException(id, "Profile")
        End If

        Return profile.First


    End Function

    Function getProfile(ByVal name As String) As Model.Profile
        Dim profile = From a In _r2kdoi.Profiles _
                      Where a.Name = name _
                      Select a

        If profile.Count = 0 Then
            Throw New RecordNotFoundException(name, "Profile")
        End If

        Return profile.First

    End Function

    Function getGroup(ByVal id As Integer) As Model.Group
        Dim profile = From a In _r2kdoi.Groups _
                      Where a.GroupId = id _
                      Select a

        If profile.Count = 0 Then
            Throw New RecordNotFoundException(id, "Group")
        End If

        Return profile.First

    End Function

    Function getGroup(ByVal name As String) As Model.Group
        Dim profile = From a In _r2kdoi.Groups _
                      Where a.Groupname = name _
                      Select a

        If profile.Count = 0 Then
            Throw New RecordNotFoundException(name, "Group")
        End If

        Return profile.First

    End Function

    Function getAllProfiles() As IQueryable(Of Model.profile)

        Return _r2kdoi.Profiles

    End Function

    Function getAllGroups() As IQueryable(Of Model.Group)

        Return _r2kdoi.Groups

    End Function


    Function AddGroupToProfile(ByVal ProfileId As Integer, ByVal GroupID As Integer) As Boolean
        Dim a = From x In _r2kdoi.ProfileGroupContainers _
                Where x.GroupId = GroupID And x.ProfileId = ProfileId _
                Select x

        If a.Count = 0 Then
            Dim p As New Model.ProfileGroupContainer

            p.ProfileId = ProfileId

            p.GroupId = GroupID

            add(p)

            Save()
        End If
        
        
    End Function


    Function DeleteGroupFromProfile(ByVal ProfileId As Integer, ByVal GroupID As Integer) As Boolean
        Dim a = From x In _r2kdoi.ProfileGroupContainers _
                Where x.GroupId = GroupID And x.ProfileId = ProfileId _
                Select x

        If a.Count > 0 Then
            _r2kdoi.ProfileGroupContainers.DeleteOnSubmit(a.First)

            Save()
        End If
    End Function

    Function DeleteGroupFromProfile(ByVal ProfileId As Integer, ByVal group As Model.Group) As Boolean

        DeleteGroupFromProfile(ProfileId, group.GroupId)
    End Function

    Function DeleteGroupFromProfile(ByVal Profile As Model.profile, ByVal group As Model.Group) As Boolean

        DeleteGroupFromProfile(Profile.ProfileId, group.GroupId)
    End Function
    Function GetAllAlerts() As IQueryable(Of Model.vAlert)
        Return _r2kdoi.vAlerts
    End Function

    Function GetMyAlerts() As IQueryable(Of Model.vAlert)

        Dim x = From a In _r2kdoi.vAlerts _
                Where a.ToName = Myapp.User(True)



        Return x
    End Function

    Sub AddAlert(ByVal fromid, ByVal toid, ByVal subject, ByVal message, ByVal link)
        _r2kdoi.SetAlert(fromid, toid, subject, message, link)
    End Sub

    Sub Reset(ByVal AlertID As Integer)
        _r2kdoi.ResetAlert(AlertID)
    End Sub

    Sub ResetAllAlert(ByVal Name As String)
        _r2kdoi.ResetAllAlert(Name)
    End Sub

    Function HasAlert(ByVal name As String) As Boolean
        _r2kdoi.HasAlert(name)
    End Function


    Sub BackupBillingInQ(ByVal billingID As Integer)
        _billing.BackupStatusOnBilling(billingID)


    End Sub






End Class
