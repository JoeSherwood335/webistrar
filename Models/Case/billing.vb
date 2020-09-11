Namespace Model.Billing
    Partial Class Billing


        Function GetStatus() As String

            Dim x = From a In Me.BillingCycles _
                    Order By a.ActionDate Descending _
                    Select a.Action.Name Take 1

            If x.Count > 0 Then
                Return x.First
            Else
                Throw New RecordNotFoundException(Me.Id, "billing")
            End If

        End Function
    End Class
End Namespace

Public Class billing

End Class
