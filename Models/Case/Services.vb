Namespace Model
    Partial Class Service


        Private Shared Function GetNonBillableProductsList() As IEnumerable(Of Product)
            Dim dc As New R2kdoiMVCDataContext


            Dim products = From p In dc.Products Where p.ParentId = Myapp.Settings("NonBillableProductId")


            Return products
        End Function


        Private Function GetProductsList() As IEnumerable(Of Product)
            Dim dc As New R2kdoiMVCDataContext
            Dim locationid = Authorization.Referral.ProgramInstance.LocationId

            Dim Feebooks = From a In Authorization.FundingCounselor.FundingSource.AssignFeesContainers _
                           Select a.Main.MainId

            Dim Products = From f In dc.Fees _
                           Where (Feebooks.Contains(f.MainId) And f.LocationId = locationid) Or f.ProductId = ProductId _
                           Select f.Product

            Return Products
        End Function

        Public Function GetProductsSelectList() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim x = (From a In GetProductsList() _
                    Select a.ProductId).Union(From a In dc.Products Where a.ProductId = Me.ProductId Select a.ProductId).ToList

            Dim p = From c In dc.GetFullProductNames _
               Where x.Contains(c.ProductId) _
               Select c.ProductId, c.ProductName Distinct


            Return New SelectList(p, "ProductId", "ProductName", ProductId)
        End Function

        Public Shared Function GetProductsNonBillableSelectList() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            'Dim x = (From a In GetNonBillableProductsList() _
            '        Select a.ProductId)

            Dim p = From c In dc.GetFullProductNames _
               Where c.ParentId = Myapp.Settings("NonBillableProductId") _
               Select c.ProductId, c.ProductName Distinct


            Return New SelectList(p, "ProductId", "ProductName")
        End Function

        Public Shared Function GetAssignedToAll() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim AssignedTos = (From user In dc.GetSubordinates(Myapp.UserId))

            If Myapp.GetUserInfo(Myapp.User).Profile.Name = "Intake" Then
                Return New SelectList(dc.RegisteredUsers.Where(Function(e) e.Active = True).OrderBy(Function(b) b.Username), "UserId", "Username")

            End If

            Return New SelectList(AssignedTos, "UserId", "Username")
        End Function
        Public Function GetAssignedTo() As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim AssignedTos

            If Not Authorization Is Nothing Then

                AssignedTos = (From user In dc.GetSubordinates(Myapp.UserId).Union(From user In dc.RegisteredUsers Where user.UserId = Me.AssignedTo).Distinct Order By user.Username)
            Else
                AssignedTos = (From user In dc.GetSubordinates(Myapp.UserId))
            End If

            Return New SelectList(AssignedTos, "UserId", "Username", Me.AssignedTo)
        End Function


        Public Shared Function GetUnitType() As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Return New SelectList(dc.UnitTypes, "UnitTypeId", "UnitType")
        End Function

        Public Shared Function GetServiceType() As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Return New SelectList(dc.ServiceTypes, "ServiceTypeId", "ServiceType")
        End Function

        Public Shared Function GetUnitType(ByVal SelectedValue As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext
            Return New SelectList(dc.UnitTypes, "UnitTypeId", "UnitType", SelectedValue)
        End Function

        Public Shared Function GetServiceType(ByVal SelectedValue? As Integer) As SelectList

            Dim dc As New R2kdoiMVCDataContext

            If SelectedValue.HasValue Then
                Return New SelectList(dc.ServiceTypes, "ServiceTypeId", "ServiceType", SelectedValue.Value)
            Else
                Return New SelectList(dc.ServiceTypes, "ServiceTypeId", "ServiceType")
            End If
        End Function

        Sub SetDetail(ByVal Name As String, ByVal value As Object)

            If Me.ServiceDetails Is Nothing Then
                Me.ServiceDetails = <details></details>

            End If

            Dim detail = From a In ServiceDetails.Elements _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a Take 1

            If detail.Count = 1 Then
                detail.Single.Value = value

            Else
                Dim newdetail = <detail name=<%= Name %> type=<%= value.GetType.ToString() %>>
                                    <%= value %>
                                </detail>
                ServiceDetails.AddFirst(newdetail)

            End If

            ' forces the datacontext to accept the changes
            Me.ServiceDetails = New XElement(Me.ServiceDetails)

        End Sub
        Function HasDetail() As Boolean
            If Me.ServiceDetails Is Nothing Then
                Return False
            Else
                Return True

            End If
        End Function
        Function HasDetail(ByVal Name As String) As Boolean
            If Me.ServiceDetails Is Nothing Then
                Return False

            End If

            Dim detail = From a In Me.ServiceDetails.Elements _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a Take 1

            If detail.Count = 0 Then
                Return False
            Else
                Return True
            End If



        End Function
        Function GetDetail(ByVal Name As String) As Object

            If Me.ServiceDetails Is Nothing Then
                Me.ServiceDetails = <details></details>

            End If

            Dim detail = From a In Me.ServiceDetails.Elements _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a Take 1


            If detail.Count = 0 Then

                Throw New Exception("Detail Record Not Found")
            End If

            Return detail.First.Value
        End Function
        Public Function GetBillings() As IQueryable(Of Model.Billing.Billing)
            Dim dc As New R2kDoiMvcBillingDataContext

            Dim billings = From a In dc.BillingDetails _
                           Where a.ServiceId = Me.ServiceId _
                           Select a.Billing Distinct

            Return billings


        End Function
        Public Function GetBillingsdetails() As IQueryable(Of Model.Billing.BillingDetail)
            Dim dc As New R2kDoiMvcBillingDataContext

            Dim billings = From a In dc.BillingDetails _
                           Where a.ServiceId = Me.ServiceId _
                           Select a

            Return billings


        End Function

        Public Function GetStatus() As Statuses

            Dim now As Date = Date.Parse(String.Format("{0}/{1}/{2}", Date.Now.Month, Date.Now.Day, Date.Now.Year))
            If ServiceStartDate.HasValue = False Then
                Return Statuses.New

            ElseIf ServiceStartDate.HasValue = True And ServiceEndDate.HasValue = False And ServiceOutcomeId.HasValue = False Then
                If ServiceStartDate > Date.Now Then
                    Return Statuses.Pending
                Else
                    Return Statuses.InProgress
                End If
            ElseIf ServiceStartDate.HasValue = True And ServiceEndDate.HasValue = True And ServiceOutcomeId.HasValue = False Then
                If ServiceStartDate > Date.Now Then
                    Return Statuses.Pending
                Else
                    Return Statuses.InProgress
                End If
            ElseIf ServiceStartDate.HasValue = True And ServiceEndDate.HasValue = True And ServiceOutcomeId.HasValue = True Then
                Return Statuses.Completed
            End If

            Throw New ServiceStatusIsInvalid(Me)
        End Function
        Public Function HasBillingsInStarted() As Boolean

            Dim dc As New R2kDoiMvcBillingDataContext

            Dim billings = (From a In dc.BillingDetails _
                           Where a.ServiceId = Me.ServiceId _
                           Select a.Billing Distinct).ToList


            For Each b In billings
                If b.GetStatus = Myapp.ACCRUED Then
                    Return True
                End If
            Next

            Return False
        End Function


        Public Shared Function GetYesNo() As SelectList

            Dim AttendanceL As New List(Of SelectListItem)

            Dim no As New SelectListItem
            no.Text = "No"
            no.Value = 0
            AttendanceL.Add(no)

            Dim yes As New SelectListItem
            yes.Text = "Yes"
            yes.Value = 1
            AttendanceL.Add(yes)

            Dim AttendanceSL As SelectList

            AttendanceSL = New SelectList(AttendanceL.AsEnumerable, "Value", "Text", 0)
            Return AttendanceSL
        End Function

        Public Shared Function GetYesNo(ByVal SelectedValue? As Integer)

            Dim AttendanceL As New List(Of SelectListItem)

            Dim no As New SelectListItem
            no.Text = "No"
            no.Value = 0
            AttendanceL.Add(no)

            Dim yes As New SelectListItem
            yes.Text = "Yes"
            yes.Value = 1
            AttendanceL.Add(yes)

            Dim AttendanceSL As SelectList

            If SelectedValue.HasValue Then
                AttendanceSL = New SelectList(AttendanceL.AsEnumerable, "Value", "Text", SelectedValue)
            Else
                AttendanceSL = New SelectList(AttendanceL.AsEnumerable, "Value", "Text")
            End If

            Return AttendanceSL
        End Function

        Public Shared Function GetCancelList()
            Dim dc As New R2kdoiMVCDataContext

            Dim cancellist As New ArrayList
            cancellist.Add(6)
            cancellist.Add(8)
            cancellist.Add(11)
            cancellist.Add(14)
            cancellist.Add(15)

            'Dim ServiceOutcomelist = From x In dc.ServiceOutcomes _
            '                 Where cancellist.Contains(x.ServiceOutcomeId) _
            '                 Select x

            Dim ServiceOutcomelist = From x In dc.ServiceOutcomes _
                       Where x.Category = "Cancel" _
                       Select x

            Dim sl As New SelectList(ServiceOutcomelist, "ServiceOutcomeId", "ServiceOutcomeName")


            Return sl
        End Function

        Public Shared Function GetCancelList(ByVal SelectedValue? As Integer) As SelectList
            Dim dc As New R2kdoiMVCDataContext

            Dim sl As SelectList

            If SelectedValue.HasValue Then
                'Dim ServiceOutcomelist = From x In dc.ServiceOutcomes _
                '                         Where SelectedValue.Value = x.ServiceOutcomeId Or x.ServiceOutcomeId = 6 Or x.ServiceOutcomeId = 8 Or x.ServiceOutcomeId = 14 Or x.ServiceOutcomeId = 11 Or x.ServiceOutcomeId = 15 _
                '                         Select x

                Dim ServiceOutcomelist = From x In dc.ServiceOutcomes _
                         Where SelectedValue.Value = x.ServiceOutcomeId Or x.Category = "Cancel" _
                         Select x

                sl = New SelectList(ServiceOutcomelist, "ServiceOutcomeId", "ServiceOutcomeName", SelectedValue.Value)
            Else
                Dim ServiceOutcomelist = From x In dc.ServiceOutcomes _
                                         Where x.Category = "Cancel" _
                                         Select x
                sl = New SelectList(ServiceOutcomelist, "ServiceOutcomeId", "ServiceOutcomeName")
            End If

            Return sl

        End Function

        Public Enum Statuses
            [New] = 1
            Pending = 2
            InProgress = 3
            Completed = 4
        End Enum
    End Class
End Namespace