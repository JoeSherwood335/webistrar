Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel


Partial Class Repository

    Private _db As R2kdoiMVCDataContext
    ''    Private _selectlist As Dictionary(Of String, SelectList)


  

    Public Sub Add(ByVal NewReferringCounsler As Model.ReferringCounselor)
        _r2kdoi.ReferringCounselors.InsertOnSubmit(NewReferringCounsler)
        Save()
    End Sub

    Public Function GetAllReferringCounslers() As System.Linq.IQueryable(Of Model.ReferringCounselor)
        Return _r2kdoi.ReferringCounselors
    End Function

    Public Function GetAllReferringCounslersByFundingCource(ByVal FundingSourceId As Integer) As System.Linq.IQueryable(Of Model.ReferringCounselor)
        Return _r2kdoi.ReferringCounselors.Where(Function(e) e.FundingSourceId = FundingSourceId)

    End Function


    Public Function GetAllReferringCounslersByFundingCource(ByVal Acronym As String) As System.Linq.IQueryable(Of Model.ReferringCounselor)
        Return _r2kdoi.ReferringCounselors.Where(Function(e) e.FundingSource.Acronym = Acronym)

    End Function

    Public Function GetReferringCounsler(ByVal Id As String) As Model.ReferringCounselor
        Dim x = _r2kdoi.ReferringCounselors.Single(Function(e) e.ReferringCounselorId = Id)

        'SetSelectListforEdit(x)
        Return x

    End Function



    ''' <summary>
    ''' Sets the Selectlist for Edit form
    ''' </summary>
    Public Sub SetSelectListforCreate()

    End Sub

    Private Sub SetSelectListforEdit(ByVal SelectedItem As Model.ReferringCounselor)

    End Sub


End Class
