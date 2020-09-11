Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

'Public Interface iInfoRepository

'    Property SelectLists(ByVal Name As String) As SelectList

'    Sub Add(ByVal newInfo As Model.Info)
'    Sub Add(ByVal newMisc As Model.Misc)


'    Function SearchInfos(ByVal Search As String) As IQueryable(Of Model.Info)

'    Function GetAllInfos() As IQueryable(Of Model.Info)

'    Function GetInfo(ByVal registrarNo As String) As Model.Info

'    Sub Save()

'    Function GetInfoByPermilink(ByVal RegistarNo As String) As Model.Info

'    Sub SetSelectionListforCreate()
'    Function getSearchName(ByVal Search As String) As IEnumerable(Of Model.SearchTermsResult)

'End Interface

Partial Class Repository


    'Private _db As R2kdoiMVCDataContext
    'Private _selectlist As System.Collections.Generic.Dictionary(Of String, System.Web.Mvc.SelectList)
    'Sub New()
    '    _db = New R2kdoiMVCDataContext
    '    _selectlist = New System.Collections.Generic.Dictionary(Of String, System.Web.Mvc.SelectList)
    'End Sub

    Public Sub Add(ByVal newInfo As Model.Info)
        _r2kdoi.Infos.InsertOnSubmit(newInfo)

        _r2kdoi.SubmitChanges()
    End Sub

    Public Sub Add(ByVal newMisc As Model.Misc)
        _r2kdoi.Miscs.InsertOnSubmit(newMisc)

        _r2kdoi.SubmitChanges()
    End Sub

    Public Function GetAllInfos() As System.Linq.IQueryable(Of Model.Info)
        Return _r2kdoi.Infos

    End Function

    Public Function GetInfo(ByVal RegistrarNo As String) As Model.Info
        Dim x = _r2kdoi.Infos.Where(Function(e) e.RegistrarNo = RegistrarNo)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(RegistrarNo, "Consumer")
        End If


        Return x.First

    End Function
    Function getInfoByPermilink(ByVal Permilink As String) As Model.Info
        Dim x = _r2kdoi.Infos.Where(Function(e) e.Permilink = Permilink)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(Permilink, "Consumer")
        End If

        Return x.First

    End Function

    Public Function SearchInfos(ByVal Search As String) As System.Linq.IQueryable(Of Model.Info)

        If String.IsNullOrEmpty(Search) Then
            Dim results1 = From x In _r2kdoi.Infos _
                           Where x.RegistrarNo = "" _
                           Select x
            Return results1
        End If

        Dim results = From x In _r2kdoi.Infos _
                      Where x.LastName.Contains(Search) Or _
                            x.FirstName.Contains(Search) Or _
                            x.RegistrarNo.Contains(Search) Or _
                            x.SSN.Contains(Search) Or _
                            x.REF.Contains(Search) Or _
                                x.Referrals.Any(Function(e) _
                                    e.Authorizations.Any(Function(c) _
                                        c.AuthorizationNumber.Contains(Search) Or _
                                        c.FundingCounselor.FundingSource.Acronym = Search Or _
                                        c.FundingCounselor.FirstName = Search Or _
                                        c.FundingCounselor.LastName = Search)) _
                      Order By x.ED Descending _
                      Select x




        Return results


        'End If
    End Function

    Function getSearchName(ByVal Search As String) As IEnumerable(Of Model.SearchTermsResult)
        Dim db As New R2kdoiMVCDataContext
        Return db.SearchTerms(Search)
    End Function


    Public Function GetMisc(ByVal Permilink As String) As Model.misc
        Return getInfoByPermilink(Permilink).Miscs.First
    End Function

    Public Function GetAllIncomeSources() As IQueryable(Of Model.IncomeSource)

        Return _r2kdoi.IncomeSources

    End Function

    Public Sub Add(ByVal newincome As Model.Income)
        _r2kdoi.Incomes.InsertOnSubmit(newincome)

        _r2kdoi.SubmitChanges()
    End Sub

    Public Function GetIncome(ByVal IncomeId As Integer) As Model.Income
        Dim y = _r2kdoi.Incomes.Where(Function(e) e.IncomeId = IncomeId)
       
        If y.Count = 0 Then
            Throw New RecordNotFoundException(IncomeId, "Income")
        End If

        Return y.First
    End Function
    Public Function GetIncome(ByVal Permilink As String, ByVal IncomeSourceId As Integer) As Model.Income
        'Dim x = _r2kdoi.Incomes.Where(Function(e) e.IncomeId = id)
        'Dim x = _r2kdoi.Infos.Where(Function(e) e.Permilink = Permilink)
        Dim x = getInfoByPermilink(Permilink)

        Dim y = From a In x.Incomes _
                Where a.IncomeSourceId = IncomeSourceId _
                Select a

        If y.Count = 0 Then
            Throw New RecordNotFoundException(IncomeSourceId, "Income")
        End If

        Return y.First
    End Function

    Public Sub Delete(ByVal income As Model.Income)

        _r2kdoi.Incomes.DeleteOnSubmit(income)

        _r2kdoi.SubmitChanges()

    End Sub

End Class
