Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class UnitTypeRepository
    Implements iUniteTypeRepository


    Private Repository As R2kdoiMVCDataContext

    Sub New()
        Repository = New R2kdoiMVCDataContext
    End Sub

    Public Sub Add(ByVal UnitType As Model.UnitType) Implements iUniteTypeRepository.Add
        Repository.UnitTypes.InsertOnSubmit(UnitType)
        Repository.SubmitChanges()
    End Sub

    Public Function GetAllUnitTypes() As IQueryable(Of Model.UnitType) Implements iUniteTypeRepository.GetAllUnitTypes
        Return Repository.UnitTypes
    End Function

    Public Function GetUnitType(ByVal Id As Short) As Model.UnitType Implements iUniteTypeRepository.GetUnitType
        Return Repository.UnitTypes.SingleOrDefault(Function(e) e.UnitTypeId = Id)
    End Function

    Public Sub Save() Implements iUniteTypeRepository.Save
        Repository.SubmitChanges()
    End Sub
End Class
