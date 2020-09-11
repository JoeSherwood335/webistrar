<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(of R2kdoiMVC.Model.Referral)" %>

       <p>
        <%=Html.ActionLink("Create New", "Create", New With {.controller = "Disability"})%>
    </p>
    
    <table>
        <tr>
            <th></th>

            <th>
                Code
            </th>
            <th>
                Description
            </th>
            <th>
                Type
            </th>
            <th>
                SD
            </th>

        </tr>

    <% For Each item In Model.Info.Disabilities%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.DisabilityID, .controller = "Disability"})%> 
            </td>
            <td>
                <%=Html.Encode(item.DisabilityType.Code)%>
            </td>
            <td>
                <%=Html.Encode(item.DisabilityType.Description)%>
            </td>
            <td>
                <%=Html.Encode(item.DisabilityOrderType.DisabilityOrderType)%>
            </td>
            <td>
                <%= Html.Encode(item.SD) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

