<Authorize()> _
<HandleError()> _
Public Class ReferringCounslersController
    Inherits System.Web.Mvc.Controller

    Dim _db As Repository

    Sub New()
        _db = New Repository
    End Sub

    '
    ' GET: /ReferringCounslers/
    <Authorize(Roles:="ReferringCounslersView")> _
    Function Index(ByVal Acronym As String) As ActionResult
        Return View(_db.GetAllReferringCounslersByFundingCource(Acronym))
    End Function

    '
    '
    ' GET: /ReferringCounslers/Edit/5
    <Authorize(Roles:="ReferringCounslersEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim x = _db.GetReferringCounsler(id)
        Return View(x)
    End Function

    '
    ' POST: /ReferringCounslers/Edit/5
    <Authorize(Roles:="ReferringCounslersEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.GetReferringCounsler(id)


        Try


            UpdateModel(x)
            x.DisplayName = String.Format("{1}, {0}", x.FirstName, x.LastName)
            x.InputedBy = Myapp.UserId
            x.Ud = Date.Now


            _db.Save()


            Return RedirectToAction("Details", New With {.controller = "FundingSource", .Acronym = x.FundingSource.Acronym})
        Catch
            Return View()
        End Try
    End Function

    <Authorize(Roles:="ReferringCounslersDelete")> _
    Function Delete(ByVal id As Integer) As ActionResult
        Dim x = _db.GetReferringCounsler(id)
        Return View(x)
    End Function

    '
    ' POST: /ReferringCounslers/Edit/5
    <Authorize(Roles:="ReferringCounslersDelete")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim x = _db.GetReferringCounsler(id)


        Try


            'UpdateModel(x)

            x.Enabled = False
            'x.DisplayName = String.Format("{1}, {0}", x.FirstName, x.LastName)
            x.InputedBy = Myapp.UserId
            x.Ud = Date.Now


            _db.Save()


            Return RedirectToAction("Details", New With {.controller = "FundingSource", .Acronym = x.FundingSource.Acronym})
        Catch
            Return View()
        End Try
    End Function
End Class