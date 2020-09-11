'Imports System.Web
'Imports System.Web.Services
'Imports System.Web.Services.Protocols
'Imports System.ComponentModel

'Public Interface iSetServiceOutComeRepository

'    Sub Add(ByVal newServiceOutcome As Model.SetServiceOutcomeForProduct)

'    Function GetServiceOutcomesByProductId(ByVal ProductId As Int16) As IQueryable(Of Model.SetServiceOutcomeForProduct)

'    Function GetServiceOutcome(ByVal ProductId As Int16, ByVal ServiceOutcomeId As Int16) As Model.SetServiceOutcomeForProduct

'    Sub RemoveServiceOutcome(ByVal ProductId As Short, ByVal ServiceOutcomeId As Short)

'    Sub SetSelectListforCreate()

'    Property SelectList(ByVal name As String) As SelectList

'    Sub save()

'End Interface

'Public Class SetServiceOutcomeRepository
'    Implements iSetServiceOutComeRepository




'    Private _db As R2kdoiMVCDataContext
'    Private _SelectList As Dictionary(Of String, SelectList)
'    Sub New()
'        _db = New R2kdoiMVCDataContext
'        _SelectList = New Dictionary(Of String, SelectList)
'    End Sub

'    Public Sub Add(ByVal newServiceOutcome As Model.SetServiceOutcomeForProduct) Implements iSetServiceOutComeRepository.Add
'        _db.SetServiceOutcomeForProducts.InsertOnSubmit(newServiceOutcome)
'        Save()

'    End Sub

'    Public Function GetServiceOutcome(ByVal ProductId As Short, ByVal ServiceOutcomeId As Short) As Model.SetServiceOutcomeForProduct Implements iSetServiceOutComeRepository.GetServiceOutcome
'        Dim x = _db.SetServiceOutcomeForProducts.Single(Function(e) e.ProductId = ProductId And e.ServiceOutcomeId = ServiceOutcomeId)
'        SetSelectListforEdit(ProductId, ServiceOutcomeId)
'        Return x
'    End Function

'    Public Function GetServiceOutcomesByProductId(ByVal ProductId As Short) As IQueryable(Of Model.SetServiceOutcomeForProduct) Implements iSetServiceOutComeRepository.GetServiceOutcomesByProductId
'        Dim x = _db.SetServiceOutcomeForProducts.Where(Function(e) e.ProductId = ProductId)
'        Return x


'    End Function

'    Public Sub RemoveServiceOutcome(ByVal ProductId As Short, ByVal ServiceOutcomeId As Short) Implements iSetServiceOutComeRepository.RemoveServiceOutcome
'        Dim x = From e In _db.SetServiceOutcomeForProducts Where e.ProductId = ProductId And e.ServiceOutcomeId = ServiceOutcomeId _
'                Select e
'        _db.SetServiceOutcomeForProducts.DeleteAllOnSubmit(x)
'        Save()

'    End Sub

'    Private Sub SetSelectListforEdit(ByVal ProductId As Short, ByVal ServiceOutcomeId As Short)
'        SelectList("Product") = New SelectList(_db.GetFullProductNames.Where(Function(e) e.Discontinued = 0), "ProductId", "ProductName", ProductId)
'        SelectList("ServiceOutcome") = New SelectList(_db.ServiceOutcomes, "ServiceOutcomeId", "ServiceOutcomeName", ServiceOutcomeId)

'        'Dim x = _db.SetServiceOutcomeForProducts.Concat




'    End Sub




'    Public Property SelectList(ByVal Name As String) As System.Web.Mvc.SelectList Implements iSetServiceOutComeRepository.SelectList
'        Get
'            Return _SelectList(Name)
'        End Get
'        Set(ByVal value As System.Web.Mvc.SelectList)
'            _SelectList(Name) = value
'        End Set
'    End Property


'    Public Sub SetSelectListforCreate() Implements iSetServiceOutComeRepository.SetSelectListforCreate
'        SelectList("Product") = New SelectList(_db.GetFullProductNames.Where(Function(e) e.Discontinued = 0), "ProductId", "ProductName")
'        SelectList("ServiceOutcome") = New SelectList(_db.ServiceOutcomes, "ServiceOutcomeId", "ServiceOutcomeName")
'        'Dim x = From a In _db.ServiceOutcomes Where  a.SetServiceOutcomeForProducts IsNot a.
'    End Sub

'    Public Sub Save() Implements iSetServiceOutComeRepository.save
'        _db.SubmitChanges()
'    End Sub
'End Class
