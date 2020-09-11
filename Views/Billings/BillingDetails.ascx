<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(of R2kdoiMVC.Model.Billing.Billing)" %>

<%=""%>
    <table>
        <tr>
            <th></th>
            <th>
               Product
            </th>
            <th>
                # Of Units
            </th>
            <th>
                Unit Price
            </th>
            <th>
                Type
            </th>
            <th>
                Start
            </th>
            <th>
                End
            </th>
            
        </tr>

    <% For Each item In Model.BillingDetails%>
    
        <tr>
            <td>
            
            </td>
            
            <td>
                <% If item.Product.ParentId.HasValue Then%>
                    <%=Html.ActionLink(String.Format("{0} {1}", item.Product.Product.ProductName, item.Product.ProductName), "Details", New With {.controller = "Services", .id = item.ServiceId})%>
                <% Else%>
                    <%=Html.ActionLink(String.Format("{0}", item.Product.ProductName), "Details", New With {.controller = "Services", .id = item.ServiceId})%>
                <% End If%>

            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.NumberOfUnits)) %>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:c}", item.UnitPrice))%>
            </td>
            <td>
                <%=Html.Encode(item.UnitType.UnitType)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.StartDate))%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.EndDate))%>
            </td>

        </tr>
    
    <% Next%>

    </table>


