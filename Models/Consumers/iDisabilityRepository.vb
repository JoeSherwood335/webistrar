Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel


Partial Class Repository

    Public Sub Add(ByVal newDisability As Model.Disability)
        _r2kdoi.Disabilities.InsertOnSubmit(newDisability)
        _r2kdoi.SubmitChanges()
    End Sub

    Public Function getDisabilitiesByInfo(ByVal Permilink As String) As System.Linq.IQueryable(Of Model.Disability)
        Return getInfoByPermilink(Permilink)

    End Function

    Public Function getDisability(ByVal id As Integer) As Model.Disability

        Dim x = _r2kdoi.Disabilities.Where(Function(e) e.DisabilityID = id)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(id, "Disablility")

        End If

        Return x.First

    End Function

    Public Function deleteDisability(ByVal id As Integer) As Boolean
        Dim x = getDisability(id)

        _r2kdoi.Disabilities.DeleteOnSubmit(x)

        Save()

        Return True

    End Function
End Class
