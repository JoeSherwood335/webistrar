Namespace Model
    Partial Class Contact

        Public Shared Function GetContactType() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim ContactTypes = From a In dc.ContactTypes _
                               Select a.ContactType, a.ContactTypeID

            Return New SelectList(ContactTypes, "ContactTypeID", "ContactType")

        End Function

        Public Shared Function GetContactType(ByVal SelectedValue? As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim ContactTypes = From a In dc.ContactTypes _
                               Select a.ContactType, a.ContactTypeID
            If SelectedValue.HasValue Then
                Return New SelectList(ContactTypes, "ContactTypeID", "ContactType")
            Else
                Return New SelectList(ContactTypes, "ContactTypeID", "ContactType", SelectedValue.Value)
            End If
        End Function


        Public Shared Function GetContactInfoType() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim ContactInfoTypes = From a In dc.ContactInfoTypes _
                               Select a.ContactInfoType, a.ContactInfoTypeId

            Return New SelectList(ContactInfoTypes, "ContactInfoTypeId", "ContactInfoType")

            'ViewData("ContactType") = _db.SelectLists("ContactType")
            'ViewData("ContactInfoType") = _db.SelectLists("ContactInfoType")
        End Function

        Public Shared Function GetContactInfoType(ByVal SelectedValue? As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim ContactInfoTypes = From a In dc.ContactInfoTypes _
                               Select a.ContactInfoTypeId, a.ContactInfoType
            If SelectedValue.HasValue Then
                Return New SelectList(ContactInfoTypes, "ContactInfoTypeId", "ContactInfoType", SelectedValue.Value)
            Else
                Return New SelectList(ContactInfoTypes, "ContactInfoTypeId", "ContactInfoType")
            End If
        End Function
    End Class
End Namespace
