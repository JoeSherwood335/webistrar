Namespace Model
    Partial Class misc



        Public Shared Function GetTransportation() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.Transportations, "TransportationId", "Transportation")
        End Function
        Public Shared Function GetTransportation(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.Transportations, "TransportationId", "Transportation", SelectedValue.Value)
            Else
                Return New SelectList(_db.Transportations, "TransportationId", "Transportation")
            End If
        End Function


        Public Shared Function GetPoliceRecord() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.PoliceRecordTypes, "PoliceRecordTypeId", "PoliceRecordType")
        End Function
        Public Shared Function GetPoliceRecord(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.PoliceRecordTypes, "PoliceRecordTypeId", "PoliceRecordType", SelectedValue.Value)
            Else
                Return New SelectList(_db.PoliceRecordTypes, "PoliceRecordTypeId", "PoliceRecordType")
            End If
        End Function

        Public Shared Function GetMaritalStatus() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.MaritalStatus, "MaritalStatusId", "MaritalStatus")
        End Function
        Public Shared Function GetMaritalStatus(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.MaritalStatus, "MaritalStatusId", "MaritalStatus", SelectedValue.Value)
            Else
                Return New SelectList(_db.MaritalStatus, "MaritalStatusId", "MaritalStatus")
            End If
        End Function
        Public Shared Function GetGender() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.Genders, "GenderId", "Gender")
        End Function
        Public Shared Function GetGender(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.Genders, "GenderId", "Gender", SelectedValue.Value)
            Else
                Return New SelectList(_db.Genders, "GenderId", "Gender")
            End If
        End Function
        Public Shared Function GetSubstanceAbuse() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.SubstanceAbuses, "SubstanceAbuseId", "SubstanceAbuse")
        End Function
        Public Shared Function GetSubstanceAbuse(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.SubstanceAbuses, "SubstanceAbuseId", "SubstanceAbuse", SelectedValue.Value)
            Else
                Return New SelectList(_db.SubstanceAbuses, "SubstanceAbuseId", "SubstanceAbuse")
            End If
        End Function
        Public Shared Function GetLenthOfUnemployment() As SelectList
            Dim _db As New R2kdoiMVCDataContext

            Return New SelectList(_db.LenthOfUmemployments, "LenthofUnemploymentId", "LenthOfUnEmploymentDesc")
        End Function
        Public Shared Function GetLenthOfUnemployment(ByVal SelectedValue? As Integer) As SelectList
            Dim _db As New R2kdoiMVCDataContext
            If SelectedValue.HasValue Then
                Return New SelectList(_db.LenthOfUmemployments, "LenthofUnemploymentId", "LenthOfUnEmploymentDesc", SelectedValue.Value)
            Else
                Return New SelectList(_db.LenthOfUmemployments, "LenthofUnemploymentId", "LenthOfUnEmploymentDesc")
            End If
        End Function





        '        SelectLists("Transportation") = New SelectList(_db.Transportations, "TransportationId", "Transportation", _misc.Single().TransportationId)
        'SelectLists("PoliceRecord") = New SelectList((From c In _db.PoliceRecordTypes Order By c.OrderBy Select c.PoliceRecordTypeId, c.PoliceRecordType), "PoliceRecordTypeId", "PoliceRecordType", _misc.Single.TransportationId)
        'SelectLists("MaritalStatus") = New SelectList(_db.MaritalStatus, "MaritalStatusId", "MaritalStatus", _misc.Single.MaritalStatusId)
        'SelectLists("Gender") = New SelectList(_db.Genders, "GenderId", "Gender", _misc.Single.GenderId)
        'SelectLists("SubstanceAbuse") = New SelectList(_db.SubstanceAbuses, "SubstanceAbuseId", "SubstanceAbuse", _misc.Single.SubstanceAbuseHistoryId)

    End Class
End Namespace