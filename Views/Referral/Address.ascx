<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

    <p>
        <%=Html.ActionLink("Change Address", "Create", New With {.Controller = "Address"})%>
    </p>
    
    <table>
        <tr>

            <th>
                StreetAddress1
            </th>
            <th>
                StreetAddress2
            </th>
            <th>
                City
            </th>
            <th>
                County
            </th>
            <th>
                State
            </th>
            <th>
                Zip
            </th>

        </tr>

    <% For Each item In Model.Info.Addresses.OrderByDescending(Function(e) e.ed).Take(1)%>
    
        <tr>
 
            <td>
                <%= Html.Encode(item.StreetAddress1) %>
            </td>
            <td>
                <%= Html.Encode(item.StreetAddress2) %>
            </td>
            <td>
                <%= Html.Encode(item.City) %>
            </td>
            <td>
                <%= Html.Encode(item.County) %>
            </td>
            <td>
                <%= Html.Encode(item.State) %>
            </td>
            <td>
                <%= Html.Encode(item.Zip) %>
            </td>
 
        </tr>
    
    <% Next%>

    </table>


