Imports MvcPaging
<Authorize()> _
Public Class CompanysController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Companys/

    ' Dim r As New 
    Dim r As Repository
    Sub New()
        r = New Repository
    End Sub

    Function Index(ByVal page? As Integer) As ActionResult


        Dim _pagevalue As Integer = 0
        If page.HasValue Then
            _pagevalue = page.Value - 1

        End If



        Return View(r.GetCompanies.ToPagedList(_pagevalue, 20))
    End Function
    Function Detail(ByVal id As Integer) As ActionResult
        Return View(r.GetCompany(id))
    End Function
    <Authorize(Roles:="CompanysAdd")> _
    <AcceptVerbs(HttpVerbs.Get)> _
    Function Add() As ActionResult
        Return View()
    End Function
    <Authorize(Roles:="CompanysAdd")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Add(ByVal newCompany As Model.Company) As ActionResult
        Try
            r.add(newCompany)
            Return RedirectToAction("Detail", New With {.id = newCompany.id})
        Catch ex As Exception
            Return View()
        End Try

    End Function
    <Authorize(Roles:="CompanysEdit")> _
    Function Edit(ByVal id As Integer)
        Return View(r.GetCompany(id))
    End Function
    <Authorize(Roles:="CompanysEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            Dim x = r.GetCompany(id)

            UpdateModel(x)

            r.Save()
            Return RedirectToAction("Detail", New With {.id = x.id})
        Catch ex As Exception
            Return View()
        End Try
    End Function
End Class
