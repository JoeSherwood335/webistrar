<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of R2kdoiMVC.Model.Service))" %>


    <% For Each item In Model%>
    
        <tr>
        
            <td>
                <% If item.Authorization.Referral.StatusId = 2 Then%>
                        <span style="color:Red"><acronym title="Closed">C</acronym></span> 
                <% Else%>        
                        <span style="color:Green"><acronym title="Open">O</acronym></span> 
                <% End If%>

            </td>
            <td>
                <%=String.Format("{0}", (From a In item.GetBillingsdetails.ToList Order By a.ED Descending Select a.Billing.GetStatus Take 1).SingleorDefault)%>
            </td>
            <td>
                <%=String.Format("{0}", (Aggregate a In item.GetBillingsdetails.ToList Where a.Billing.GetStatus <> R2kdoiMVC.Myapp.VOID Into Count(a.BillingDetailsId)))%>
            </td>
            <td>
                <%=Html.ActionLink("Details", "Details", New With {.id = item.ServiceId})%>
            </td>
            <td>
                <% If item.Product.ParentId.HasValue Then%>
                    
                    <%=Html.Encode(item.Product.Product.ProductName)%>               
                
                <%End If%>
                
                <%=Html.Encode(item.Product.ProductName)%>               
            </td>
            <td>
                <%= item.Authorization.Referral.Info.Link()%>
            </td>
            <td>
                <%If item.ServiceStartDate.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:d}", item.ServiceStartDate))%> 
                <%Else%>
                <div class="SelectService">
                    <%=Html.ActionLink("Start", "StartService", New With {.id = item.ServiceId, .cm = HttpContext.Current.Request.QueryString("cm")})%>
                </div>
                <%End If%>
            </td>
            <td>
                <div class="SelectService">
                <%If item.ServiceEndDate.HasValue Then%>
                    <%=item.ServiceEndDate.Value.ToShortDateString()%> 
                <%Else%>
                
                    <%'Html.ActionLink("End", "EndService", New With {.id = item.ServiceId, .cm = HttpContext.Current.Request.QueryString("cm")})%>
                
                <%End If%>
                </div>
                
            </td>
            <td>
                <%=item.SchedualStartDate.ToShortDateString%>
            </td>
            <td>
                <%=item.SchedualEndDate.ToShortDateString%>
            </td>

        </tr>
    
    <% Next%>

    


