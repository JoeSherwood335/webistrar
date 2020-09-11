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

    Public Function GetServices(ByVal Search As String) As System.Linq.IQueryable(Of Model.Service)
        ' Dim x = From a In _db.Services Where a.Authorization.AuthorizationID = id Select a



        If String.IsNullOrEmpty(Search) Then
            Dim results1 = From x In _r2kdoi.Services _
                           Where x.ServiceId = 0 _
                           Select x
            Return results1
        End If

        Dim results = From x In _r2kdoi.Services _
                      Where x.Authorization.Referral.Info.LastName.Contains(Search) Or _
                            x.Authorization.Referral.Info.FirstName.Contains(Search) Or _
                            x.Authorization.Referral.Info.RegistrarNo.Contains(Search) Or _
                            x.Authorization.Referral.Info.SSN.Contains(Search) Or _
                            x.Authorization.Referral.Info.REF.Contains(Search) Or _
                            x.Authorization.AuthorizationNumber.Contains(Search) Or _
                            x.Authorization.FundingCounselor.FundingSource.Acronym = Search Or _
                            x.Authorization.FundingCounselor.FirstName = Search Or _
                            x.Authorization.FundingCounselor.LastName = Search _
                      Order By x.ed Descending _
                      Select x




        Return results



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
