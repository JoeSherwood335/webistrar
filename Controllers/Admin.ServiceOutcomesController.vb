'Public Class ServiceOutcomesController
'    Inherits System.Web.Mvc.Controller

'    Private _db As iSetServiceOutComeRepository

'    Sub New()
'        _db = New SetServiceOutcomeRepository
'    End Sub
'    '
'    ' GET: /ServiceOutcomes/

'    Function Index(ByVal ProductId? As Short) As ActionResult

'        _db.SetSelectListforCreate()
'        ViewData("Product") = _db.SelectList("Product")
'        If ProductId.HasValue Then
'            Return View(_db.GetServiceOutcomesByProductId(ProductId))
'        Else
'            Return View(_db.GetServiceOutcomesByProductId(0))
'        End If

'    End Function

'    '
'    ' GET: /ServiceOutcomes/Details/5

'    Function Details(ByVal id As Integer) As ActionResult
'        Return View()
'    End Function

'    '
'    ' GET: /ServiceOutcomes/Create

'    Function Create() As ActionResult
'        _db.SetSelectListforCreate()

'        ViewData("Product") = _db.SelectList("Product")
'        ViewData("ServiceOutcome") = _db.SelectList("ServiceOutcome")

'        Return View()
'    End Function

'    '
'    ' POST: /ServiceOutcomes/Create

'    <AcceptVerbs(HttpVerbs.Post)> _
'    Function Create(ByVal NewServiceOutcome As Model.SetServiceOutcomeForProduct) As ActionResult
'        Try
'            _db.Add(NewServiceOutcome)
'            Return RedirectToAction("Index", New With {.ProductId = NewServiceOutcome.ProductId})
'        Catch
'            _db.SetSelectListforCreate()

'            ViewData("Product") = _db.SelectList("Product")
'            ViewData("ServiceOutcome") = _db.SelectList("ServiceOutcome")

'            Return View()
'        End Try
'    End Function

'    Function Remove(ByVal id As Short, ByVal ProductId As Short, ByVal ServiceOutcomeId As Short) As ActionResult

'        '_db.GetServiceOutcome(ProductId, ServiceOutcomeId)


'        Return View(_db.GetServiceOutcome(ProductId, ServiceOutcomeId))

'    End Function

'    <AcceptVerbs(HttpVerbs.Post)> _
'    Function Remove(ByVal DeletedServiceOutcome As Model.SetServiceOutcomeForProduct) As ActionResult
'        Try
'            ' TODO: Add update logic here
'            _db.RemoveServiceOutcome(DeletedServiceOutcome.ProductId, DeletedServiceOutcome.ServiceOutcomeId)

'            Return RedirectToAction("Index", New With {.ProductId = DeletedServiceOutcome.ProductId})
'        Catch ex As Exception
'            Return View()
'        End Try
'    End Function
'End Class
