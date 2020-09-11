Partial Class Repository

    Public Sub Add(ByVal NewService As Model.Service) Implements iServicesRepository.Add
        _db.Services.InsertOnSubmit(NewService)
        _db.SubmitChanges()
    End Sub


    Public Function GetService(ByVal id As Int32) As Model.Service Implements iServicesRepository.GetService


        Dim x = _db.Services.Single(Function(e) e.ServiceId = id)
        SetSelectlistforEdit(x)
        Return x

    End Function

    Public Function GetServices() As System.Linq.IQueryable(Of Model.Service) Implements iServicesRepository.GetAllServices
        ' Dim x = From a In _db.Services Where a.Authorization.AuthorizationID = id Select a

        Return _db.Services
    End Function



    Public Sub Save() Implements iServicesRepository.Save

        _db.SubmitChanges()

    End Sub

    Private Sub SetSelectlistforEdit(ByVal service As Model.Service)
        Dim authorization = _db.Authorizations.Single(Function(e) e.AuthorizationID = service.AuthorizationId)

        'Dim products = (From product In _db.Products _
        '       Where product.Fees.Any(Function(e) e.Main.AssignFeesContainers.Any(Function(a) a.FundingSourceId = authorization.FundingCounselor.FundingSourceId)) _
        '       Select product.ProductId).ToList

        Dim f = From x In _db.GetProductsforList _
                Where x.Discontinued = 0 _
                Select New With {.ProductName = x.ProductName, .ProductId = x.ProductId}


        'Dim Units = From Unit In _db.UnitTypes _
        '            Select Unit

        Dim AssignedTos = From user In _db.GetSubordinates(authorization.Referral.AssignedTo) _
                          Select user

        'Dim outcomes = From Outcome In _db.ServiceOutcomes _
        '               Select Outcome


        SelectList("Products") = New SelectList(f, "ProductId", "ProductName", service.ProductId)
        'Selectlist("Units") = New SelectList(products, "UnitTypeId", "UnitType")
        SelectList("AssignedTos") = New SelectList(AssignedTos, "UserId", "Username", service.InputedBy)
        ' Selectlist("Outcomes") = New SelectList(outcomes, "ServiceOutcomeId", "ServiceOutcomeName")

    End Sub

    Public Sub SetSelectlistforCreate(ByVal AuthorizationID As Integer) Implements iServicesRepository.SetSelectlistforCreate
        Dim authorization = _db.Authorizations.Single(Function(e) e.AuthorizationID = AuthorizationID)


        'Where product.Fees.Any(Function(e) e.Main.AssignFeesContainers.Any(Function(a) a.FundingSourceId = authorization.FundingCounselor.FundingSourceId)) _


        Dim f = From x In _db.GetProductsforList _
                Where x.Discontinued = 0 _
                Select New With {.ProductName = x.ProductName, .ProductId = x.ProductId}



        'Dim Units = From Unit In _db.UnitTypes _
        '            Select Unit

        Dim AssignedTos = From user In _db.GetSubordinates(authorization.Referral.AssignedTo) _
                          Select user

        'Dim outcomes = From Outcome In _db.ServiceOutcomes _
        '               Select Outcome


        SelectList("Products") = New SelectList(f, "ProductId", "ProductName")
        'Selectlist("Units") = New SelectList(products, "UnitTypeId", "UnitType")
        SelectList("AssignedTos") = New SelectList(AssignedTos, "UserId", "Username")
        ' Selectlist("Outcomes") = New SelectList(outcomes, "ServiceOutcomeId", "ServiceOutcomeName")

    End Sub


End Class
