Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iAddressRepository

    Sub Add(ByVal newAddress As Model.Address)

    Function GetAddressesByInfo(ByVal RegistrarNo As String) As IQueryable(Of Model.Address)

    Function GetAddress(ByVal id As Integer) As Model.Address

    Sub save()




End Interface

Public Class AddressRepository
    Implements iAddressRepository

    Private _db As R2kdoiMVCDataContext

    Sub New()
        _db = New R2kdoiMVCDataContext
    End Sub
    Public Sub Add(ByVal newAddress As Model.Address) Implements iAddressRepository.Add
        _db.Addresses.InsertOnSubmit(newAddress)
        _db.SubmitChanges()
    End Sub

    Public Function GetAddress(ByVal id As Integer) As Model.Address Implements iAddressRepository.GetAddress
        Return _db.Addresses.SingleOrDefault(Function(e) e.AddressID = id)
    End Function

    Public Function GetAddressesByInfo(ByVal RegistrarNo As String) As System.Linq.IQueryable(Of Model.Address) Implements iAddressRepository.GetAddressesByInfo
        Return _db.Addresses.Where(Function(e) e.RegistrarNo = RegistrarNo).Select(Function(e) e) 'From x In _db.Addresses Where x.RegistrarNo = RegistrarNo Select x
    End Function

    Public Sub save() Implements iAddressRepository.save
        _db.SubmitChanges()
    End Sub
End Class
