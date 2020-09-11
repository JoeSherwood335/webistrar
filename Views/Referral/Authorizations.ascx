<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

    <p>
        <%=Html.ActionLink("New Authorization", "NewAuthorization", New With {.id = Model.ReferralId})%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Authorization Number
            </th>
            <th>
                AuthorizationDate
            </th>
        </tr>

    <% For Each item In Model.Authorizations%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Details", "Details", New With {.id = item.AuthorizationID, .controller = "Authorizations"})%>
            </td>
            <td>
                <%= Html.Encode(item.AuthorizationNumber) %>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.AuthorizationDate))%>
            </td>
      
        </tr>
    
    <% Next%>

    </table>


