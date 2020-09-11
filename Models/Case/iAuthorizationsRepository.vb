Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iAuthorizationsRepository

    Property SelectList(ByVal Name As String) As SelectList

    Sub Add(ByVal NewAuthorization As Model.Authorization)
    Sub Add(ByVal NewService As Model.Service)

    Function GetAuthorizationsByInfo(ByVal RegistrarNo As String) As IQueryable(Of Model.Authorization)

    Function GetAllAuthorizations() As IQueryable(Of Model.Authorization)


    Function GetAuthorization(ByVal id As Integer) As Model.Authorization
    Function GetService(ByVal id As Integer) As Model.Service




    Sub Save()






End Interface

Partial Class Repository





    'Private _SelectList As Dictionary(Of String, SelectList)

    Public Function GetAuthorization(ByVal id As Integer) As Model.Authorization
        Dim x = _r2kdoi.Authorizations.Single(Function(e) e.AuthorizationID = id)


        Return x

    End Function

    Public Function GetAuthorizationsByInfo(ByVal RegistrarNo As String) As System.Linq.IQueryable(Of Model.Authorization)
        Dim x = _r2kdoi.Authorizations.Where(Function(e) e.Referral.RegistrarNo = RegistrarNo)
        '  _db.Authorizations.First.FundingSource
        Return x

    End Function

    Public Function GetAllAuthorizations() As System.Linq.IQueryable(Of Model.Authorization)
        Return _r2kdoi.Authorizations
    End Function

    


    Public Sub AddDetail(ByVal AuthorizationID As Integer, ByVal ServiceName As String, ByVal NumberOfUnits As Integer, ByVal UnitPrice As Double, ByVal UnitType As Integer, ByVal AmountAuthorized As Double, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal type As ServiceType)



        AddDetail(AuthorizationID, ServiceName, NumberOfUnits, UnitPrice, UnitType, AmountAuthorized, StartDate, EndDate, 0, 0, 0, type)


        'If String.IsNullOrEmpty(ServiceName) Then
        '    Throw New InputCantBeBlankException("ServiceName")
        'End If
        'If String.IsNullOrEmpty(NumberOfUnits) Then
        '    Throw New InputCantBeBlankException("NumberOfUnits")
        'End If
        'If String.IsNullOrEmpty(UnitPrice) Then
        '    Throw New InputCantBeBlankException("UnitPrice")
        'End If
        'If String.IsNullOrEmpty(UnitType) Then
        '    Throw New InputCantBeBlankException("UnitType")
        'End If
        'If String.IsNullOrEmpty(AmountAuthorized) Then
        '    Throw New InputCantBeBlankException("AmountAuthorized")
        'End If



        'Dim NewService As New Model.Service
        'NewService.ServiceName = ServiceName
        'NewService.AuthorizationId = AuthorizationID
        'NewService.NumberOfUnitesAuthorized = NumberOfUnits
        'NewService.UnitPrice = UnitPrice
        'NewService.UnitTypeId = UnitType
        'NewService.AmountAuthorized = AmountAuthorized
        'NewService.SchedualEndDate = EndDate
        'NewService.SchedualStartDate = StartDate
        'NewService.ProductId = 2642 'unknown
        'NewService.NumberOfUnits = 0
        'NewService.AssignedTo = 602
        'NewService.CostCenter = "000"
        'NewService.InputedBy = Myapp.UserId
        'NewService.ed = Date.Now
        'NewService.ud = Date.Now

        'NewService.SetDetail("AutoCalc", 1)

        'If type = ServiceType.Secondary Then
        '    NewService.ProductId = Myapp.Settings(ServiceName) 'unknown
        'End If

        ' NewService.SetDetail("type", type)

        ' add(NewService)
    End Sub


    Public Sub AddDetail(ByVal AuthorizationID As Integer, ByVal ServiceName As String, ByVal NumberOfUnits As Integer, ByVal UnitPrice As Double, ByVal UnitType As Integer, ByVal AmountAuthorized As Double, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal UnitOfServiceEquals As String, ByVal UnitAmountAuthorized As String, ByVal HCPCSCode As String, Optional ByVal type As ServiceType = ServiceType.Primary)

        If String.IsNullOrEmpty(ServiceName) Then
            Throw New InputCantBeBlankException("ServiceName")
        End If
        If String.IsNullOrEmpty(NumberOfUnits) Then
            Throw New InputCantBeBlankException("NumberOfUnits")
        End If
        If String.IsNullOrEmpty(UnitPrice) Then
            Throw New InputCantBeBlankException("UnitPrice")
        End If
        If String.IsNullOrEmpty(UnitType) Then
            Throw New InputCantBeBlankException("UnitType")
        End If
        If String.IsNullOrEmpty(AmountAuthorized) Then
            Throw New InputCantBeBlankException("AmountAuthorized")
        End If



        'GetAuthorization(AuthorizationID).Referral.AssignedTo



        Dim NewService As New Model.Service
        NewService.ServiceName = ServiceName
        NewService.AuthorizationId = AuthorizationID
        NewService.NumberOfUnitesAuthorized = NumberOfUnits
        NewService.UnitPrice = UnitPrice
        NewService.UnitTypeId = UnitType
        NewService.AmountAuthorized = AmountAuthorized
        NewService.SchedualEndDate = EndDate
        NewService.SchedualStartDate = StartDate
        NewService.ProductId = 2642 'unknown
        NewService.NumberOfUnits = 0
        NewService.AssignedTo = 602
        NewService.CostCenter = "000"
        NewService.InputedBy = Myapp.UserId
        NewService.ed = Date.Now
        NewService.ud = Date.Now

        NewService.SetDetail("AutoCalc", 1)
        NewService.SetDetail("UnitOfServiceEquals", UnitOfServiceEquals)
        NewService.SetDetail("UnitAmountAuthorized", UnitAmountAuthorized)
        NewService.SetDetail("HCPCSCode", HCPCSCode)
        'If type = ServiceType.Secondary Then
        '    NewService.ProductId = Myapp.Settings(ServiceName) 'unknown
        'End If

        NewService.SetDetail("type", type)

        add(NewService)
    End Sub
    Public Enum ServiceType
        Primary = 1
        Secondary = 2
    End Enum

End Class
