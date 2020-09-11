Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class LocationsRepository
    Implements iLocationsRepository
    Private _db As R2kdoiMVCDataContext
    Sub New()
        _db = New R2kdoiMVCDataContext

    End Sub

    Public Sub Add(ByVal NewLocations As Model.Location) Implements iLocationsRepository.Add
        _db.Locations.InsertOnSubmit(NewLocations)

    End Sub

    Public Function GetAllLocations() As System.Linq.IQueryable(Of Model.Location) Implements iLocationsRepository.GetAllLocations
        Return _db.Locations
    End Function

    Public Function GetLocation(ByVal id As Integer) As Model.Location Implements iLocationsRepository.GetLocation
        Return _db.Locations.SingleOrDefault(Function(E) E.LocationId = id)

    End Function

    Public Sub Save() Implements iLocationsRepository.Save
        _db.SubmitChanges()
    End Sub
End Class
