Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Partial Class Repository

    Public Function AccruService(ByVal serviceId As Integer) As Model.Billing.Billing

        Dim billingid = _billing.AccrueService(serviceId, Myapp.UserId).First().BillingId

        Return GetBilling(billingid)

    End Function

    Public Function CancelService(ByVal serviceId As Integer, ByVal makebill As Boolean) As Model.Billing.Billing
        Dim makebillI = If(makebill, 1, 0)

        Dim billingid = _billing.CancelService(serviceId, makebill, Myapp.UserId).First.BillingId
        If makebill Then
            Return GetBilling(billingid)
        Else
            Return New Model.Billing.Billing
        End If
    End Function

    Public Function GetBillingInfos() As System.Linq.IQueryable(Of Model.Billing.Info)
        Return _billing.Infos
    End Function


    Public Function GetAllBillings() As System.Linq.IQueryable(Of Model.Billing.Billing)
        Return _billing.Billings

    End Function

    Public Function GetAllActions() As System.Linq.IQueryable(Of Model.Billing.Action)

        Return _billing.Actions
    End Function

    Public Function GetBillingFundingSources() As System.Linq.IQueryable(Of Model.Billing.FundingSource)
        Return _billing.FundingSources


    End Function



    Public Function GetBillingDetails() As System.Linq.IQueryable(Of Model.Billing.BillingDetail)
        Return _billing.BillingDetails
    End Function



    Public Function GetBillingsfromStatus(ByVal status As String) As System.Linq.IQueryable(Of Model.Billing.Billing)


        Dim result As IEnumerable(Of Model.Billing.Billing) = _billing.GetBillsFromStatus(status)


        Return _billing.GetBillsFromStatus(status).ToArray.AsQueryable



    End Function



    Public Function GetBilling(ByVal BillingId As String) As Model.Billing.Billing
        Dim x = _billing.Billings.Where(Function(e) e.Id = BillingId)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(BillingId, "Billing")
        End If
        Return x.First
    End Function

    Public Sub AcceptBill(ByVal BillingId As Integer)
        _billing.AcceptBilling(BillingId, Myapp.UserId)
    End Sub

    Public Sub StartBill(ByVal BillingId As Integer)
        _billing.StartBilling(BillingId, Myapp.UserId)
    End Sub
    Public Sub ApproveBill(ByVal BillingId As Integer)
        _billing.ApproveBilling(BillingId, Myapp.UserId)
    End Sub

    Public Sub voidbill(ByVal BillingId As Integer)
        _billing.VoidBilling(BillingId, Myapp.UserId)
    End Sub

    Public Function PennyBill(ByVal ServiceId As Integer) As Model.Billing.Billing

        Dim billingid = _billing.PennyService(ServiceId, Myapp.UserId).First().BillingId

        Return GetBilling(billingid)

    End Function
End Class