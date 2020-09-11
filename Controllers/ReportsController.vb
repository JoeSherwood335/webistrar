Public Class ReportsController
    Inherits System.Web.Mvc.Controller

    Dim db As iReportsRepository
    Sub New()
        db = New ReportsRepository
    End Sub

    <Authorize(Roles:="ReportsView")> _
    Function Index(ByVal reportId As Integer) As ActionResult
        Return View(db.GetReports.Where(Function(e) e.ReportsId = reportId))
    End Function

    '
    ' GET: /Reports/Details/5
    <Authorize(Roles:="ReportsView")> _
    Function Details(ByVal id As Integer) As ActionResult
        Dim x = db.GetReport(id)

        If x.ReportStatus.ReportStatus = "Draft" And x.InputedBy <> Myapp.UserId Then

            x.ReportContent = "Author still has not published the report!"
        End If

        Return View(x)
    End Function

    '
    ' GET: /Reports/Create
    <Authorize(Roles:="ReportsCreate")> _
    Function Create(ByVal ReferralId As Integer) As ActionResult
        db.SelectListforCreate()

        ViewData("ReportType") = db.SelectList("ReportType")

        Return View()
    End Function

    '
    ' POST: /Reports/Create
    <Authorize(Roles:="ReportsCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal ReferralId As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add insert logic here

            Dim report As New Model.Report
            report.ReportName = "Title of the Report"
            report.ReportContent = ""
            report.TimeStamp = Date.Now
            report.InputedBy = Myapp.UserId
            report.ed = Date.Now
            report.ud = Date.Now
            report.ReportTypeId = collection("ReportTypeId")
            report.ReportStatusId = 1
            report.ReferralId = ReferralId



            db.Add(report)

            Return RedirectToAction("Edit", New With {.id = report.ReportsId})
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Reports/Edit/5
    <Authorize(Roles:="ReportsEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim report = db.GetReport(id)

        ViewData("ReportStatus") = db.SelectList("ReportStatus")





        Return View(report)
    End Function

    '
    ' POST: /Reports/Edit/5
    <Authorize(Roles:="ReportsEdit")> _
    <ValidateInput(False)> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim report = db.GetReport(id)
        UpdateModel(report)
        Try
            ' TODO: Add update logic here
            ModelState.SetModelValue("ReportName", New ValueProviderResult(ValueProvider("ReportName").AttemptedValue, collection("ReportName"), System.Globalization.CultureInfo.CurrentCulture))

            If collection("ReportName") = "Title of the Report" Then
                ModelState.AddModelError("ReportName", "You must name this report")
                ViewData("ReportStatus") = db.SelectList("ReportStatus")
                Return View(report)
            End If

            db.Save()

            Return RedirectToAction("Details", New With {.id = report.ReportsId})

        Catch ex As Exception
            ModelState.AddModelError("", ex)
            ViewData("ReportStatus") = db.SelectList("ReportStatus")
            Return View(report)
        End Try
    End Function
End Class
