
Namespace Model
    Partial Class Income



        Public Shared Function getIncomeSources() As SelectList
            Dim _r2kdoi As New R2kdoiMVCDataContext

            Return New SelectList(_r2kdoi.IncomeSources, "IncomeSourceId", "IncomeSource")
        End Function

        Public Shared Function getIncomeSources(ByVal SelectedValue As Integer) As SelectList
            Dim _r2kdoi As New R2kdoiMVCDataContext

            Return New SelectList(_r2kdoi.IncomeSources, "IncomeSourceId", "IncomeSource", SelectedValue)
        End Function

        Public Shared Function getAmmountType() As SelectList
            Dim _r2kdoi As New R2kdoiMVCDataContext

            Return New SelectList(_r2kdoi.IncomeSources, "IncomeSourceTypeID", "IncomeSourceType")
        End Function
        Public Shared Function getAmmountType(ByVal SelectedValue As Integer) As SelectList
            Dim _r2kdoi As New R2kdoiMVCDataContext

            Return New SelectList(_r2kdoi.IncomeSourceAmountTypes, "IncomeSourceTypeID", "IncomeSourceType", SelectedValue)
        End Function
 
    End Class
End Namespace
