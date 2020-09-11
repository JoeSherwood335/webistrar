<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of R2kdoiMVC.Model.vAlert))" %>
  

    <p>
        <%=Html.ActionLink("Ignore All", "ResetAll", New With {.returnpath = ViewData("returnpath")})%>
    </p>
    
    <table>
        <tr>
            <th></th>
               <th>
                Subject
            </th>
            <th>
                Message
            </th>
            <th>
            </th>
            <th>
            </th>

            <th>
                Submited
            </th>

        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("View", "Details", New With {.Id = item.Subject, .returnpath = ViewData("returnpath")})%> <%=Html.ActionLink("Ignore", "Reset", New With {.Id = item.Subject, .returnpath = ViewData("returnpath")})%>
            </td>

            <td>
                <%= Html.Encode(item.Subject) %>
            </td>
            <td colspan=3>
                <%= Html.Encode(item.Message) %>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.Submited))%>
            </td>

        </tr>
    
    <% Next%>

    </table>

