Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel



Partial Public Class Repository

    Public Sub Add(ByVal NewService As Model.Service)
        _r2kdoi.Services.InsertOnSubmit(NewService)
        _r2kdoi.SubmitChanges()
    End Sub


    Public Function GetService(ByVal id As Int32) As Model.Service


        Dim x = _r2kdoi.Services.Where(Function(e) e.ServiceId = id)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(id, "Service")
        End If

        Return x.First

    End Function

    Public Function GetServices() As System.Linq.IQueryable(Of Model.Service)
        ' Dim x = From a In _db.Services Where a.Authorization.AuthorizationID = id Select a

        Return _r2kdoi.Services
    End Function

    

    Public Function GetProductIdfromServiceOutcomeId(ByVal ServiceOutcomeId As Integer)
        Dim x = From a In _r2kdoi.Products Join b In _r2kdoi.ServiceOutcomes On a.ProductName Equals b.ServiceOutcomeName _
                Where b.ServiceOutcomeId = ServiceOutcomeId _
                Select a.ProductId

        If x.Count = 0 Then
            Throw New RecordNotFoundException(ServiceOutcomeId, "GetProductIdfromServiceOutcomeId")
        End If

        Return x.First

    End Function


End Class
