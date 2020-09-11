Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class FundingSourceRepository
    Implements iFundingSourceRepository

    Private _db As R2kdoiMVCDataContext

    Sub New()
        _db = New R2kdoiMVCDataContext

    End Sub

    Public Sub Add(ByVal NewFundingSource As Model.FundingSource) Implements iFundingSourceRepository.Add
        _db.FundingSources.InsertOnSubmit(NewFundingSource)
    End Sub

    Public Function GetAllFundingSources() As System.Linq.IQueryable(Of Model.FundingSource) Implements iFundingSourceRepository.GetAllFundingSources
        Return _db.FundingSources
    End Function

    Public Function GetFundingSource(ByVal Acronym As String) As Model.FundingSource Implements iFundingSourceRepository.GetFundingSource
        Return (From a In _db.FundingSources Where a.Acronym = Acronym Select a).Single


    End Function

    Public Function GetFundingSource(ByVal id As Long) As Model.FundingSource Implements iFundingSourceRepository.GetFundingSource
        Return (From a In _db.FundingSources Where a.FundingSourceId = id Select a).Single
    End Function

    Public Sub Save() Implements iFundingSourceRepository.Save
        _db.SubmitChanges()
    End Sub



End Class
