Partial Class Repository

    Private _r2kdoi As R2kdoiMVCDataContext
    Private _selectlist As Dictionary(Of String, SelectList)
    Private _billing As R2kDoiMvcBillingDataContext
    Sub New()

        _r2kdoi = New R2kdoiMVCDataContext
        _selectlist = New Dictionary(Of String, SelectList)
        _billing = New R2kDoiMvcBillingDataContext
    End Sub

    Public Sub Save()

        Console.Write("Total changes: {0}", _r2kdoi.GetChangeSet())
        ' Freeze the console window.
        Try

            For Each a As Object In _r2kdoi.GetChangeSet.Updates
                a.InputedBy = Myapp.UserId
                a.UD = Date.Now
            Next

        Catch ex As Exception

        End Try
        _r2kdoi.SubmitChanges()
        _billing.SubmitChanges()
    End Sub

    Public Property Selectlist(ByVal Name As String) As System.Web.Mvc.SelectList
        Get
            Return _selectlist(Name)
        End Get
        Set(ByVal value As System.Web.Mvc.SelectList)
            _selectlist(Name) = value
        End Set
    End Property


    Public Function GetCompletedOutcomes() As Integer()
        Dim x = From a In _r2kdoi.ServiceOutcomes Where a.Category = "Completed" Select a.ServiceOutcomeId

        Return x.ToArray
    End Function
    Public Function GetCanceledOutcomes() As Integer()
        Dim x = From a In _r2kdoi.ServiceOutcomes Where a.Category = "Cancel" Select a.ServiceOutcomeId

        Return x.ToArray
    End Function
    Public Function GetPennyOutcomes() As Integer()
        Dim x = From a In _r2kdoi.ServiceOutcomes Where a.Category = "Penny" Select a.ServiceOutcomeId

        Return x.ToArray
    End Function
End Class
