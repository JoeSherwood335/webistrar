<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Authorization)" %>

<%=""%>
    <table>
        <tr>
            <th></th>
            <th>ServiceName</th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
        </tr>
        <tr>
            <th></th>
            <th>SchedualStartDate</th>
            <th>SchedualEndDate</th>
            <th>NumberOfUnits</th>
            <th>UnitType</th>
            <th>UnitPrice</th>
            <th>Amount</th>
        </tr>
    <% For Each item In Model.Services%>
         <tr>
            <td>
                <% If If(ViewData("Edit"), False) Then%>
                    <%=Html.ActionLink("Edit", "EditDetails", New With {.id = item.ServiceId})%>
                <% Else%> 
                    <%=Html.ActionLink("Assign", "AssignService", New With {.id = item.ServiceId, .controller = "Services"})%>
                <% End If%>
            </td>
            <td colspan="6">
                <%=Html.Encode(item.ServiceName)%>
            </td>
         </tr>
         <tr>
            <td><%=Html.ActionLink("View", "Details", New With {.id = item.ServiceId, .controller = "Services"})%></td>
            <td><%=Html.Encode(String.Format("{0:d}", item.SchedualStartDate))%></td>
            <td><%=Html.Encode(String.Format("{0:d}", item.SchedualEndDate))%></td>
            <td><%=Html.Encode(item.NumberOfUnitesAuthorized)%></td>
            <td><%=Html.Encode(item.UnitType.UnitType)%></td>
            <td><%=Html.Encode(String.Format("{0:c}", item.UnitPrice))%></td>
            <td><%=Html.Encode(String.Format("{0:c}", item.AmountAuthorized))%></td>
        </tr>
    <% Next%>
    </table>
    
    
