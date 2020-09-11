Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iContactRepository

    Sub Add(ByVal NewContact As Model.Contact)

    Function GetContactsByInfo(ByVal permilink As String) As IQueryable(Of Model.Contact)

    Function GetContact(ByVal id As Integer) As Model.Contact

    Sub Save()
    Property SelectLists(ByVal Name As String) As SelectList
    Sub SetSelectionListforCreate()
    Function GetRegistrarNofromPermilink(ByVal permilink As String) As String

End Interface

Public Class ContactRepository
    Implements iContactRepository



    Private _db As R2kdoiMVCDataContext
    Private _selectlist As System.Collections.Generic.Dictionary(Of String, System.Web.Mvc.SelectList)
    Sub New()
        _db = New R2kdoiMVCDataContext
        _selectlist = New System.Collections.Generic.Dictionary(Of String, System.Web.Mvc.SelectList)
    End Sub

    Public Sub Add(ByVal NewContact As Model.Contact) Implements iContactRepository.Add
        _db.Contacts.InsertOnSubmit(NewContact)
        _db.SubmitChanges()
    End Sub

    Public Function GetContact(ByVal id As Integer) As Model.Contact Implements iContactRepository.GetContact
        Dim x = _db.Contacts.SingleOrDefault(Function(e) e.ContactID = id)
        SetSelectionListforSingle(x)
        Return x
    End Function

    Public Function GetContactsByInfo(ByVal permilink As String) As System.Linq.IQueryable(Of Model.Contact) Implements iContactRepository.GetContactsByInfo
        'Return _db.Contacts.Where(Function(e) e.RegistrarNo = RegistrarNo).Select(Function(e) e)
        Dim x = From a In _db.Contacts _
                Where a.Info.Permilink = permilink _
                Select a

        Return x

    End Function

    Public Sub Save() Implements iContactRepository.Save
        _db.SubmitChanges()
    End Sub




    Public Property SelectLists(ByVal Name As String) As System.Web.Mvc.SelectList Implements iContactRepository.SelectLists
        Get
            Return _selectlist(Name)

        End Get
        Set(ByVal value As System.Web.Mvc.SelectList)


            _selectlist(Name) = value
        End Set

    End Property



    Public Sub SetSelectionListforCreate() Implements iContactRepository.SetSelectionListforCreate
        SelectLists("ContactInfoType") = New SelectList(_db.ContactInfoTypes, "ContactInfoTypeId", "ContactInfoType")
        SelectLists("ContactType") = New SelectList(_db.ContactTypes, "ContactTypeID", "ContactType")


        ' _db.Contacts.First.ContactTypes.ContactType()
    End Sub


    Private Sub SetSelectionListforSingle(ByVal x As Model.Contact)
        SelectLists("ContactInfoType") = New SelectList(_db.ContactInfoTypes, "ContactInfoTypeId", "ContactInfoType", x.ContactInfoTypeId)
        SelectLists("ContactType") = New SelectList(_db.ContactTypes, "ContactTypeID", "ContactType", x.ContactTypeId)

    End Sub

    Public Function GetRegistrarNofromPermilink(ByVal Permilink As String) As String Implements iContactRepository.GetRegistrarNofromPermilink
        Return _db.GetRegistrarNoFromPermilink(Permilink)

    End Function
End Class


