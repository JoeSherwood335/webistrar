Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iUniteTypeRepository

    Sub Add(ByVal UnitType As Model.UnitType)

    Function GetAllUnitTypes() As IQueryable(Of Model.UnitType)

    Function GetUnitType(ByVal Id As Int16) As Model.UnitType

    Sub Save()




End Interface
