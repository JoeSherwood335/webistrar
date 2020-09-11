Namespace Controllers

    <Authorize()> _
    Public Class LocationsController
        Inherits System.Web.Mvc.Controller

        Private _db As iLocationsRepository

        Sub New()
            _db = New LocationsRepository

        End Sub

        Sub New(ByVal repository As iLocationsRepository)
            _db = repository
        End Sub
        '
        ' GET: /Locations/

        Function Index() As ActionResult
            Return View(_db.GetAllLocations)
        End Function

        '
        ' GET: /Locations/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Return View(_db.GetLocation(id))
        End Function

        '
        ' GET: /Locations/Create
        <Authorize(Roles:="LocationAdmin")> _
        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Locations/Create
        <Authorize(Roles:="LocationAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Create(ByVal newlocation As Model.Location) As ActionResult
            Try

                _db.Add(newlocation)
                _db.Save()

                ' TODO: Add insert logic here
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Locations/Edit/5
        <Authorize(Roles:="LocationAdmin")> _
        Function Edit(ByVal id As Integer) As ActionResult
            Return View(_db.GetLocation(id))
        End Function

        '
        ' POST: /Locations/Edit/5
        <Authorize(Roles:="LocationAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Dim location As Model.Location = _db.GetLocation(id)

                UpdateModel(location)


                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace