<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Program)" %>

   
    <table>
        <tr>
            <th></th>
            <th>
               Location 
            </th>
            <th>
                CostCenter
            </th>
            <th>
                Authorizaton Supervisor
            </th>
            <th>
                Billing Supervisor
            </th>


        </tr>

    <% For Each item In Model.ProgramInstances.Where(Function(e) e.InActive = False)%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Inactive", "EditInstance", New With {.id = item.id})%> |
            </td>            
            <td>
                <%=Html.Encode(item.Location.LocationName)%>
            </td>
            <td>
                <%= Html.Encode(item.CostCenter) %>
            </td>
            <td>
                <%=Html.Encode(item.Supervisor.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.BillingSupervisor.Username)%>
            </td>


        </tr>
    
    <% Next%>

    </table>


