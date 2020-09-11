<Authorize()> _
Public Class UnitTypesController
    Inherits System.Web.Mvc.Controller
    Private _db As iUniteTypeRepository

    Sub New()
        _db = New UnitTypeRepository
    End Sub

    Sub New(ByVal repository)
        _db = repository
    End Sub

    '
    ' GET: /UnitTypes/
    Function Index() As ActionResult
        Return View(_db.GetAllUnitTypes)
    End Function

    '
    ' GET: /UnitTypes/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Return View(_db.GetUnitType(id))
    End Function

    '
    ' GET: /UnitTypes/Create
    <Authorize(Roles:="UnitTypeAdmin")> _
    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /UnitTypes/Create
    <Authorize(Roles:="UnitTypeAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal NewUnitType As Model.UnitType) As ActionResult
        Try
            _db.Add(NewUnitType)



            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /UnitTypes/Edit/5
    <Authorize(Roles:="UnitTypeAdmin")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Return View(_db.GetUnitType(id))
    End Function

    '
    ' POST: /UnitTypes/Edit/5
    <Authorize(Roles:="UnitTypeAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Dim unittype = _db.GetUnitType(id)

            UpdateModel(unittype)

            Return RedirectToAction("Details", New With {.id = id})
        Catch
            Return View()
        End Try
    End Function
End Class
