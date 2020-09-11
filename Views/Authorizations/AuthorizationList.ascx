<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of R2kdoiMVC.Model.Authorization))" %>
<%=""%>
 <table>
        <tr>
            <th></th>
            <th>
                Referral
            </th>
            <th>Consumer</th>
            <th>Program</th>
            <th>Manager</th>
            <th>
                 Number
            </th>
            <th>
                 Date
            </th>
            <th>
                 Counsler
            </th>
            <th>
                Amount 
            </th>
            <th>
                Units 
            </th>


        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%If Not item.ApproveById.HasValue Then%>
                    <%=Html.ActionLink("Approve", "Details", New With {.id = item.AuthorizationID})%>
                <% Else%>
                    <%=Html.ActionLink("Details", "Details", New With {.id = item.AuthorizationID})%>
                <%End If  %>            
            </td>
            <td>
                <%=Html.ActionLink("Referral", "Details", New With {.Permilink = item.Referral.Info.Permilink, .id = item.ReferralId, .controller = "Referral"})%>
            
            </td>
            <td>
                <%=item.Referral.Info.Link%>
            </td>
            <td>
                <%=Html.Encode(item.Referral.ProgramInstance.Program.Acronym)%>
            </td>
            <td>
                <%=Html.Encode(item.Referral.ProgramInstance.Supervisor.Username)%>
            </td>
            <td>
                <%= Html.Encode(item.AuthorizationNumber) %>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.AuthorizationDate))%>
            </td>
            <td>
                <%=Html.Encode(item.FundingCounselor.DisplayName)%>
            </td>
            <td>
                <% If item.TotalAmountAuthorized = Decimal.Zero Then%>
                    <%=Html.Encode(String.Format("{0:c}", (From a In item.Services Select a.AmountAuthorized).Sum()))%>
                <% Else%>
                    <%=Html.Encode(String.Format("{0:c}", item.TotalAmountAuthorized))%>
                <% End If%>
            </td>
            <td>
                <% If item.TotalUnitsAuthorized = Decimal.Zero Then%>
                    <%=Html.Encode(String.Format("{0:F}", (From a In item.Services Select a.NumberOfUnitesAuthorized).Sum()))%>
                <% Else%>
                    <%=Html.Encode(String.Format("{0:F}", item.TotalUnitsAuthorized))%>
                <% End If%>
            </td>

 
        </tr>
    
    <% Next%>

    </table>


