Public Class ProgramsController
    Inherits System.Web.Mvc.Controller


    Dim db As Repository

    Sub New()
        db = New Repository
    End Sub
    '
    ' GET: /Programs/

    Function Index(ByVal Locations? As Integer) As ActionResult
        'db.CreateSelectListforCreate()
        'ViewData("Locations") = db.Selectlist("Locations")
        Return View(db.GetAllPrograms.Where(Function(e) e.InActive = False).OrderBy(Function(e) e.ProgramName))

    End Function

    '
    ' GET: /Programs/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Return View(db.GetProgram(id))
    End Function

    '
    ' GET: /Programs/Create
    <Authorize(Roles:="ProgramAdmin")> _
    Function Create() As ActionResult

        db.CreateSelectListforCreate()

        ViewData("ProgramOutcomeTypes") = db.Selectlist("ProgramOutcomeTypes")

        Return View()
    End Function

    '
    ' POST: /Programs/Create
    <Authorize(Roles:="ProgramAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal newprogram As Model.Program) As ActionResult
        Try
            ' TODO: Add insert logic here

            db.Add(newprogram)

            Return RedirectToAction("Details", New With {.id = newprogram.ProgramId})
        Catch ex As Exception
            db.CreateSelectListforCreate()
            ViewData("ProgramOutcomeTypes") = db.Selectlist("ProgramOutcomeTypes")
            Return View()
        End Try
    End Function

    '
    ' GET: /Programs/Edit/5
    <Authorize(Roles:="ProgramAdmin")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim x = db.GetProgram(id)
        ViewData("ProgramOutcomeTypes") = db.Selectlist("ProgramOutcomeTypes")
        Return View(x)
    End Function

    '
    ' POST: /Programs/Edit/5
    <Authorize(Roles:="ProgramAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult

        Dim x = db.GetProgram(id)
        Try
            ' TODO: Add update logic here

            UpdateModel(x)

            db.Save()
            Return RedirectToAction("Index")
        Catch
            ViewData("Locations") = db.Selectlist("Locations")
            ViewData("Supervisors") = db.Selectlist("Supervisors")
            Return View()
        End Try
    End Function

    <Authorize(Roles:="ProgramAdmin")> _
    Function NewInstance(ByVal id As Integer) As ActionResult
        db.CreateSelectListforCreate()
        ViewData("Locations") = db.Selectlist("Locations")
        ViewData("Supervisors") = db.Selectlist("Supervisors")
        Dim wa As New Model.ProgramInstance
        wa.ProgramId = id
        Return View(wa)
    End Function

    <Authorize(Roles:="ProgramAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function NewInstance(ByVal id As Integer, ByVal instance As Model.ProgramInstance) As ActionResult
        Try

            instance.InstanceName = " "
            instance.ProgramId = id


            db.Add(instance)

            Return RedirectToAction("Details", New With {.id = id})

        Catch ex As Exception
            db.CreateSelectListforCreate()
            ViewData("Locations") = db.Selectlist("Locations")
            ViewData("Supervisors") = db.Selectlist("Supervisors")
            Return View()
        End Try


    End Function

    <Authorize(Roles:="ProgramAdmin")> _
    Function EditInstance(ByVal id As Integer) As ActionResult
        Dim x = db.GetProgramInstance(id)


        ViewData("Locations") = db.Selectlist("Locations")
        ViewData("Supervisors") = db.Selectlist("Supervisors")

        Return View(x)
    End Function

    <Authorize(Roles:="ProgramAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function EditInstance(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = db.GetProgramInstance(id)

        Try
            'UpdateModel(x)

            x.InActive = True

            db.Save()
            Return RedirectToAction("Details", New With {.id = x.ProgramId})

        Catch ex As Exception
            ViewData("Locations") = db.Selectlist("Locations")
            ViewData("Supervisors") = db.Selectlist("Supervisors")

            Return View()
        End Try

    End Function
    <Authorize(Roles:="ProgramAdmin")> _
    Function removeoutcome(ByVal ProgramId As Integer, ByVal outcomeid As Integer) As ActionResult

        Dim a = From x In db.GetProgram(ProgramId).SetServiceOutcomesforPrograms _
                Where x.ServiceOutcomeId = outcomeid _
                Select x




        'ViewData("ServiceOutcomes") = db.SelectlistforServiceOutcomes(ProgramId).Item("ServiceOutcomes")

        Return View(a.Single)
    End Function

    '
    ' POST: /Programs/Create
    <Authorize(Roles:="ProgramAdmin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function removeoutcome(ByVal newpo As Model.SetServiceOutcomesforProgram) As ActionResult
        Try
            ' TODO: Add insert logic here

            db.Remove(newpo)

            Return RedirectToAction("Details", New With {.id = newpo.ProgramId})
        Catch ex As Exception

            ModelState.AddModelError("", ex.Message)


            Return View()
        End Try
    End Function

    Function addoutcome(ByVal ProgramId As Integer) As ActionResult



        ViewData("ServiceOutcomes") = db.SelectlistforServiceOutcomes(ProgramId).Item("ServiceOutcomes")

        Return View()
    End Function

    '
    ' POST: /Programs/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Function addoutcome(ByVal newpo As Model.SetServiceOutcomesforProgram) As ActionResult
        Try
            ' TODO: Add insert logic here

            db.Add(newpo)

            Return RedirectToAction("Details", New With {.id = newpo.ProgramId})
        Catch

            ViewData("ServiceOutcomes") = db.SelectlistforServiceOutcomes(newpo.ProgramId).Item("ServiceOutcomes")
            Return View()
        End Try
    End Function
End Class
