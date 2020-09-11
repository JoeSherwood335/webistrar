<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.FundingSource)" %>

    <p>
        <%=Html.ActionLink("New Counsler", "NewCounsler")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                RepCode
            </th>
            <th>
                LastName
            </th>
            <th>
                FirstName
            </th>

        </tr>

    <% For Each item In Model.ReferringCounselors.Where(Function(e) e.Enabled = True).OrderBy(Function(e) e.LastName)%>
    
        <tr>
            <td>
                
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ReferringCounselorId, .controller = "ReferringCounslers"})%>
            </td>
            <td>
                <%= Html.Encode(item.RepCode) %>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
    </tr>
    
    <% Next%>

    </table>


