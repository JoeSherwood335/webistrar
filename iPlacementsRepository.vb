Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel



Partial Class Repository



    'Private db As R2kdoiMVCDataContext
    '    Private _SelectList As Dictionary(Of String, SelectList)

 
    Public Sub add(ByVal newPlacement As Model.Placement)
        _r2kdoi.Placements.InsertOnSubmit(newPlacement)
        Save()
    End Sub

    'Public Sub add(ByVal NewCompany As Model.Company)
    '    db.Companies.InsertOnSubmit(NewCompany)
    '    db.SubmitChanges()
    'End Sub

    Public Sub add(ByVal NewSpecialNeedContainer As Model.SpecialNeedsContainer)
        _r2kdoi.SpecialNeedsContainers.InsertOnSubmit(NewSpecialNeedContainer)

        Save()
    End Sub



    Public Sub add(ByVal NewSpecialNeed As Model.SpecialNeed)
        _r2kdoi.SpecialNeeds.InsertOnSubmit(NewSpecialNeed)

        Save()
    End Sub



    Public Function getAllSpecialNeeds(ByVal Registrarno As Integer) As System.Linq.IQueryable(Of Model.SpecialNeedsContainer)


        Dim x = From a In _r2kdoi.SpecialNeedsContainers _
                Where a.RegistrarNo = Registrarno _
                Select a



        Return x


    End Function


    Public Function getSpecialNeeds(ByVal id As Integer) As Model.SpecialNeedsContainer


        Dim x = From a In _r2kdoi.SpecialNeedsContainers _
                Where a.SpecialNeedsContainerId = id _
                Select a



        If x.Count = 0 Then Throw New Exception("GetSpecialNeeds Id not found")


        Return x.SingleOrDefault


    End Function

    Public Function getSpecialNeedlist() As System.Linq.IQueryable(Of Model.SpecialNeed)


        'Dim x = From a In _r2kdoi.SpecialNeeds



        'If x.Count = 0 Then Throw New Exception("getSpecialNeedlist Id not found")


        Return _r2kdoi.SpecialNeeds

    End Function


    Function AddNeedToConsumer(ByVal RegistrarNo As String, ByVal SpecialNeedId As Integer) As Boolean
        Dim a = From x In _r2kdoi.SpecialNeedsContainers _
                Where x.RegistrarNo = RegistrarNo And x.SpecialNeedId = SpecialNeedId _
                Select x

        If a.Count = 0 Then
            Dim p As New Model.SpecialNeedsContainer

            p.RegistrarNo = RegistrarNo

            p.SpecialNeedId = SpecialNeedId

            add(p)

            Save()
        End If


    End Function


    Function DeleteNeedToConsumer(ByVal RegistrarNo As String, ByVal SpecialNeedId As Integer) As Boolean
        Dim a = From x In _r2kdoi.SpecialNeedsContainers _
                Where x.RegistrarNo = RegistrarNo And x.SpecialNeedId = SpecialNeedId _
                Select x

        If a.Count > 0 Then
            _r2kdoi.SpecialNeedsContainers.DeleteOnSubmit(a.First)

            Save()
        End If
    End Function














    Public Function GetPlacement(ByVal id As Integer) As Model.Placement
        Dim placement = _r2kdoi.Placements.Single(Function(e) e.PlacementId = id)


        GetSelectListforEdit(placement)

        Return placement
    End Function
    'Public Function GetCompany(ByVal id As Integer) As Model.Company
    '    Return db.Companies.Single(Function(e) e.id = id)
    'End Function

    Public Sub GetSelectListforCreate()
        Selectlist("JobTypes") = New SelectList(_r2kdoi.JobTypes, "JobTypeId", "JobType")
        Selectlist("WageTypes") = New SelectList(_r2kdoi.WageTypes, "WageTypeId", "WageType")
        Selectlist("Staffs") = New SelectList(_r2kdoi.RegisteredUsers.Where(Function(e) e.Active = True), "UserId", "UserName")
        Selectlist("PlacementTypes") = New SelectList(_r2kdoi.PlacementTypes, "PlacementTypeId", "PlacementType")
    End Sub


    Private Sub GetSelectListforEdit(ByVal x As Model.Placement)
        Selectlist("JobTypes") = New SelectList(_r2kdoi.JobTypes, "JobTypeId", "JobType", x.JobTypeId)
        Selectlist("WageTypes") = New SelectList(_r2kdoi.WageTypes, "WageTypeId", "WageType", x.WageTypeId)
        Selectlist("Staffs") = New SelectList(_r2kdoi.RegisteredUsers.Where(Function(e) e.Active = True), "UserId", "UserName", x.StaffId)
        Selectlist("PlacementTypes") = New SelectList(_r2kdoi.PlacementTypes, "PlacementTypeId", "PlacementType", x.TypeId)
    End Sub




    Public Function GetAllCompanies() As System.Linq.IQueryable(Of Model.Company)
        Return _r2kdoi.Companies
    End Function

    Public Function SearchCompanies(ByVal Search As String) As System.Linq.IQueryable(Of Model.Company)

        If String.IsNullOrEmpty(Search) Then
            Dim results = _r2kdoi.Companies

            Return results
        Else

            Dim results = From x In _r2kdoi.Companies _
                          Where x.CompanyName.Contains(Search) Or _
                                x.CompanyShort.Contains(Search) _
                          Select x



            Return results

        End If
    End Function


End Class
