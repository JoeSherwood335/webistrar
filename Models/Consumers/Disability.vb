Namespace Model
    Partial Class Disability


        Public Shared Function GetOrderType(ByVal RegistrarNo As String) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim types = From a In dc.Disabilities _
                    Where a.RegistrarNo = RegistrarNo _
                    Select a.TypeId

            Dim availableOrderTypes = From a In dc.DisabilityOrderTypes _
                                 Where Not types.Contains(a.DisabilityOrderTypeID) _
                                 Select a.DisabilityOrderType, a.DisabilityOrderTypeID

            Return New SelectList(availableOrderTypes, "DisabilityOrderTypeID", "DisabilityOrderType")

        End Function

        Public Shared Function GetOrderType(ByVal RegistrarNo As String, ByVal _TypeId As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim types = From a In dc.Disabilities _
                    Where a.RegistrarNo = RegistrarNo _
                    Select a.TypeId

            Dim availableOrderTypes = From a In dc.DisabilityOrderTypes _
                                 Where Not types.Contains(a.DisabilityOrderTypeID) Or _TypeId = a.DisabilityOrderTypeID _
                                 Select a.DisabilityOrderType, a.DisabilityOrderTypeID

            Return New SelectList(availableOrderTypes, "DisabilityOrderTypeID", "DisabilityOrderType", _TypeId)

        End Function

        Public Shared Function GetDisabilityType(ByVal RegistrarNo As String) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Dim availableDisabilityTypes = From a In dc.DisabilityTypes _
                                           Where a.Description <> "Unknown Disability Code" _
                                           Select New With {.id = a.ID, .Description = String.Format("{0},{1}", a.Code, a.Description)}

            Return New SelectList(availableDisabilityTypes, "id", "Description")

        End Function

        Public Shared Function GetDisabilityType(ByVal RegistrarNo As String, ByVal _TypeId As Integer, ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim availableDisabilityTypes = From a In dc.DisabilityTypes _
                                           Where a.Description <> "Unknown Disability Code" Or a.ID = SelectedValue _
                                           Select New With {.id = a.ID, .Description = String.Format("{0},{1}", a.Code, a.Description)}

            Return New SelectList(availableDisabilityTypes, "ID", "Description", SelectedValue)
        End Function

    End Class
End Namespace