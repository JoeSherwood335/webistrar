Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iLocationsRepository

    Sub Add(ByVal NewLocations As Model.Location)

    ''' <summary>
    ''' Get All Locations
    ''' </summary>
    Function GetAllLocations() As IQueryable(Of Model.Location)

    Function GetLocation(ByVal id As Integer) As Model.Location

    Sub Save()




End Interface
