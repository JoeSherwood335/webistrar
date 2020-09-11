Partial Class Repository

    Function GetAllPrograms() As IQueryable(Of Model.Program)

        Return _r2kdoi.Programs

    End Function

    Function GetProgram(ByVal id As Integer) As Model.Program
        Dim x = _r2kdoi.Programs.Single(Function(e) e.ProgramId = id)
        CreateSelectlistforEdit(x)
        Return x

    End Function
    Function GetProgramInstance(ByVal id As Integer) As Model.ProgramInstance
        Dim x = _r2kdoi.ProgramInstances.Single(Function(e) e.id = id)
        CreateSelectlistforEdit(x)
        Return x
    End Function
    Function GetallProgramInstance() As IQueryable(Of Model.ProgramInstance)
        Return _r2kdoi.ProgramInstances
    End Function


    Sub Add(ByVal newProgram As Model.Program)
        _r2kdoi.Programs.InsertOnSubmit(newProgram)
        _r2kdoi.SubmitChanges()
    End Sub
    Sub Add(ByVal op As Model.SetServiceOutcomesforProgram)
        _r2kdoi.SetServiceOutcomesforPrograms.InsertOnSubmit(op)
        _r2kdoi.SubmitChanges()
    End Sub
    Sub Add(ByVal newInstance As Model.ProgramInstance)
        _r2kdoi.ProgramInstances.InsertOnSubmit(newInstance)
        _r2kdoi.SubmitChanges()

    End Sub

    Sub Remove(ByVal po As Model.SetServiceOutcomesforProgram)

        Dim x = From a In _r2kdoi.SetServiceOutcomesforPrograms _
                Where a.ServiceOutcomeId = po.ServiceOutcomeId And a.ProgramId = po.ProgramId _
                Select a

        _r2kdoi.SetServiceOutcomesforPrograms.DeleteOnSubmit(x.Single)
        _r2kdoi.SubmitChanges()
    End Sub


    Function SelectlistforServiceOutcomes(ByVal programid As Integer) As Dictionary(Of String, SelectList)
        Dim x = From a In _r2kdoi.SetServiceOutcomesforPrograms _
                Where a.ProgramId = programid _
                Select a.ServiceOutcomeId Distinct


        Dim list As New Dictionary(Of String, SelectList)
        list.Item("ServiceOutcomes") = New SelectList(_r2kdoi.ServiceOutcomes.Where(Function(e) Not x.Contains(e.ServiceOutcomeId)), "ServiceOutcomeId", "ServiceOutcomeName")


        Return list
    End Function

    Public Sub CreateSelectListforCreate()
        Selectlist("Locations") = New SelectList(_r2kdoi.Locations, "LocationId", "LocationName")
        Selectlist("Supervisors") = New SelectList(_r2kdoi.RegisteredUsers.Where(Function(e) e.Active = True).OrderBy(Function(e) e.Username), "UserId", "Username")
        'Selectlist("ProgramOutcomeTypes") = New SelectList(db.ProgramOutcomes, "ProgramOutcomeTypeId", "ProgramOutcomeName")
        Selectlist("ProgramOutcomeTypes") = New SelectList(_r2kdoi.PoTypes, "PoTypeId", "Name")

    End Sub


    Private Sub CreateSelectlistforEdit(ByVal x As Model.Program)
        Selectlist("ProgramOutcomeTypes") = New SelectList(_r2kdoi.PoTypes, "PoTypeId", "Name", x.PoTypeId)
    End Sub

    Private Sub CreateSelectlistforEdit(ByVal x As Model.ProgramInstance)
        Selectlist("Locations") = New SelectList(_r2kdoi.Locations, "LocationId", "LocationName", x.LocationId)
        Selectlist("Supervisors") = New SelectList(_r2kdoi.RegisteredUsers.Where(Function(e) e.Active = True Or e.UserId = x.SupervisorId), "UserId", "Username", x.SupervisorId)
    End Sub

End Class
