Partial Class Repository

    Public Function GetCompany(ByVal id As Integer) As Model.Company

        Dim x = From z In _r2kdoi.Companies _
                Where z.id = id _
                Select z
        If x.Count = 0 Then
            Throw New Exception("There are no records")

        End If

        Return x.First


    End Function


    Sub add(ByVal newCompany As Model.Company)
        _r2kdoi.Companies.InsertOnSubmit(newCompany)

        _r2kdoi.SubmitChanges()
    End Sub

    Public Function GetCompanies() As IQueryable(Of Model.Company)
        Return _r2kdoi.Companies
    End Function
End Class
