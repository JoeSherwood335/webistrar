Namespace Controllers
    <Authorize()> _
    <HandleError()> _
    Public Class FundingSourceController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /FundingSource/


        Private _repository As iFundingSourceRepository
        Public ReadOnly Property Repository() As iFundingSourceRepository
            Get
                Return _repository
            End Get
        End Property


        Sub New()
            _repository = New FundingSourceRepository
        End Sub

        Sub New(ByVal Repostitory As iFundingSourceRepository)
            _repository = Repostitory
        End Sub

        Function Index() As ActionResult
            ' Dim db As New R2kdoiMVCDataContext


            Return View(Repository.GetAllFundingSources)
        End Function


        Function Details(ByVal Acronym As String) As ActionResult
            Dim _db As New R2kdoiMVCDataContext



            ViewData("FeeScheduals") = New SelectList(_db.Mains, "MainId", "FeeSchedualName")
            Return View(Repository.GetFundingSource(Acronym))
        End Function


        <Authorize(Roles:="FundingSourceAdmin")> _
        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /FundingSource/Create
        <Authorize(Roles:="FundingSourceAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Create(ByVal newFundingSource As Model.FundingSource) As ActionResult
            Try
                ' TODO: Add insert logic here
                'Dim db As New R2kdoiMVCDataContext
                'db.FundingSources.InsertOnSubmit(newFundingSource)
                'db.SubmitChanges()

                Repository.Add(NewFundingSource:=newFundingSource)
                Repository.Save()



                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /FundSource/Edit/5
        <Authorize(Roles:="FundingSourceAdmin")> _
        Function Edit(ByVal Acronym As String) As ActionResult
            'Dim db As New R2kdoiMVCDataContext

            'Dim x = From z In db.FundingSources Where z.FundingSourceId = id Select z


            ' Return db.FundingSources.Where(Function 
            Return View(Repository.GetFundingSource(Acronym))
        End Function

        '
        ' POST: /FundSource/Edit/5
        <Authorize(Roles:="FundingSourceAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Edit(ByVal id As Integer, ByVal uFundingSource As Model.FundingSource) As ActionResult
            Try

                Dim Ofundingsource = Repository.GetFundingSource(id)

                UpdateModel(Ofundingsource)

                Repository.Save()


                Return RedirectToAction("Details", New With {.id = id})
            Catch ex As Exception
                Return RedirectToAction("Invalid", New With {.Source = ex.Source, .Message = ex.Message, .Data = ex.ToString})
            End Try
        End Function

        <Authorize(Roles:="FundingSourceAdmin")> _
        Function DeAssignFee(ByVal fsid As Integer, ByVal feeid As Integer) As ActionResult

            Dim db As New R2kdoiMVCDataContext

            Dim x = db.AssignFeesContainers.Single(Function(e) e.FeeSchedualId = feeid And e.FundingSourceId = fsid)

            db.AssignFeesContainers.DeleteOnSubmit(x)

            db.SubmitChanges()

            Return RedirectToAction("Details", New With {.id = fsid})
        End Function

        <Authorize(Roles:="FundingSourceAdmin")> _
        Function AssignFee(ByVal fsId As Integer) As ActionResult

            Dim db As New R2kdoiMVCDataContext
            Dim x = From a In db.AssignFeesContainers Where a.FundingSourceId = fsId Select a.FeeSchedualId

            Dim y = From a In db.Mains Where Not x.Contains(a.MainId) Select a


            'Dim x = db.AssignFeesContainers.Single(Function(e) e.FeeSchedualId = feeid And e.FundingSourceId = fsid)

            'db.AssignFeesContainers.DeleteOnSubmit(x)

            'db.SubmitChanges()




            ViewData("FeeSchedual") = New SelectList(y, "MainId", "FeeSchedualName")



            ViewData("fsid") = fsId

            Return View()
            'RedirectToAction("Details", New With {.id = fsid})
        End Function
        <Authorize(Roles:="FundingSourceAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function AssignFee(ByVal fsid As Integer, ByVal newAssign As Model.AssignFeesContainer)
            Dim db As New R2kdoiMVCDataContext

            newAssign.FundingSourceId = fsid


            db.AssignFeesContainers.InsertOnSubmit(newAssign)

            db.SubmitChanges()

            Return RedirectToAction("Details", New With {.id = fsid})
        End Function


        ' <Authorize()> _
        <Authorize(Roles:="FundingSourceAdmin")> _
        Function NewCounsler() As ActionResult
            ViewData("rs") = Request.UrlReferrer.AbsolutePath

            Return View()
        End Function
        <Authorize(Roles:="FundingSourceAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function NewCounsler(ByVal Acronym As String, ByVal rs As String, ByVal Counsler As Model.ReferringCounselor) As ActionResult
            Dim db As New R2kdoiMVCDataContext

            Dim FundingSourceId = db.FundingSources.Single(Function(e) e.Acronym = Acronym).FundingSourceId
            Counsler.FundingSourceId = FundingSourceId
            Counsler.DisplayName = String.Format("{1}, {0}", Counsler.FirstName, Counsler.LastName)
            Counsler.InputedBy = Myapp.UserId
            Counsler.ED = Date.Now
            Counsler.Ud = Date.Now
            Counsler.Enabled = True
            db.ReferringCounselors.InsertOnSubmit(Counsler)
            db.SubmitChanges()


            Return Redirect(rs)
            'Return RedirectToAction("Details", New With {.Acronym = Acronym})
        End Function


        Function Invalid(ByVal Source As String, ByVal Message As String, ByVal Data As String) As ActionResult

            ViewData.Add("Source", Source)
            ViewData.Add("Message", Message)
            ViewData.Add("Data", Data)

            Return View()

        End Function
    End Class


End Namespace
