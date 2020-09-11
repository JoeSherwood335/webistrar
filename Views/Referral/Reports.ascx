<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

    <p>
        <%=Html.ActionLink("New Report", "Create", New With {.controller = "Reports", .ReferralId = Model.ReferralId}, New With {.target = "_blank"})%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Type
            </th>
            <th>
                Name
            </th>
        </tr>

    <% For Each item In Model.Reports%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.controller = "Reports", .id = item.ReportsId}, New With {.target = "_blank"})%> |
                <%=Html.ActionLink("Details", "Details", New With {.controller = "Reports", .id = item.ReportsId}, New With {.target = "_blank"})%>
            </td>
            <td>
                <%=Html.Encode(item.ReportType.ReportType)%>
            </td>
            <td>
                <%= Html.Encode(item.ReportName) %>
            </td>
        </tr>
    
    <% Next%>

    </table>


