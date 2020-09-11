
Namespace Model
    Partial Class Authorization
        Public Function GetBills() As IQueryable(Of Model.Billing.Billing)

            Dim dc As New R2kDoiMvcBillingDataContext

            Dim bills = From a In dc.Billings _
                        Where a.AuthorizationId = Me.AuthorizationID _
                        Select a

            Return bills






        End Function
    End Class
End Namespace