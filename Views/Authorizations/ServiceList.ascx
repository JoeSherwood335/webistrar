<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Authorization)" %>
    
    <table>
        <tr>
            <th></th>
            
            <th>
                Product
            </th>
           
            <th>
                AssignedTo
            </th>
            <th>
                CostCenter
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Service Outcome
            </th>

        </tr>

    <% For Each item In Model.Services%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Details", "Details", New With {.controller = "Services", .id = CType(item.ServiceId, Int64)})%>
            </td>

            <td>
                <%=Html.Encode(item.Product.ProductName)%>
            </td>

            <td>
                <%=Html.Encode(item.RegisteredUser.Username)%>
            </td>
            <td>
                <%= Html.Encode(item.CostCenter) %>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.ServiceStartDate))%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.ServiceEndDate))%>
            </td>
            <td>
                <% If item.ServiceOutcomeId.HasValue Then%>
                    <%=Html.Encode(item.ServiceOutcome.ServiceOutcomeName)%>
                <% Else%>
                    
                <% End If%>
            </td>
 
        </tr>
    
    <% Next%>

    </table>


