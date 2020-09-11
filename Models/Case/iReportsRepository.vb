Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iReportsRepository

    Property SelectList(ByVal name As String) As SelectList

    Sub Add(ByVal NewReport As Model.Report)

    ''' <summary>
    ''' 
    ''' </summary>
    Function GetReport(ByVal Id As Integer) As Model.Report

    Function GetReports() As IQueryable(Of Model.Report)

    Sub Save()

    Sub SelectListforCreate()



End Interface

Public Class ReportsRepository
    Implements iReportsRepository
    Private _SelectList As Dictionary(Of String, SelectList)

    Private db As R2kdoiMVCDataContext

    Sub New()
        _SelectList = New Dictionary(Of String, SelectList)
        db = New R2kdoiMVCDataContext
    End Sub


    Public Sub Add(ByVal NewReport As Model.Report) Implements iReportsRepository.Add
        db.Reports.InsertOnSubmit(NewReport)

        db.SubmitChanges()
    End Sub

    Public Function GetReport(ByVal Id As Integer) As Model.Report Implements iReportsRepository.GetReport
        'Dim report = From a In db.Reports _
        '             Where a.ReportsId = Id _
        '             Select a Take 1
        SelectListforEdit(db.Reports.Single(Function(e) e.ReportsId = Id))
        Return db.Reports.Single(Function(e) e.ReportsId = Id)

    End Function

    Public Function GetReports() As System.Linq.IQueryable(Of Model.Report) Implements iReportsRepository.GetReports
        Return db.Reports
    End Function

    Public Sub Save() Implements iReportsRepository.Save
        db.SubmitChanges()
    End Sub



    Public Sub SelectListforCreate() Implements iReportsRepository.SelectListforCreate
        SelectList("ReportType") = New SelectList(db.ReportTypes, "ReportTypeId", "ReportType")
        SelectList("ReportStatus") = New SelectList(db.ReportStatus, "ReportStatusId", "ReportStatus")
    End Sub

    Private Sub SelectListforEdit(ByVal x As Model.Report)
        SelectList("ReportType") = New SelectList(db.ReportTypes, "ReportTypeId", "ReportType", x.ReportTypeId)
        SelectList("ReportStatus") = New SelectList(db.ReportStatus, "ReportStatusId", "ReportStatus", x.ReportStatusId)
    End Sub

    Public Property SelectList(ByVal Name As String) As System.Web.Mvc.SelectList Implements iReportsRepository.SelectList
        Get
            Return _SelectList(Name)
        End Get
        Set(ByVal value As System.Web.Mvc.SelectList)
            _SelectList(Name) = value
        End Set
    End Property
End Class
