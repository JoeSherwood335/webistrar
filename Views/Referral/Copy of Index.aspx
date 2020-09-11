<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Referrals for <%=Model.FirstName %> <%=Model.LastName%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<style type="text/css" >
    table {font-size:smaller;}

</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Referrals for <%=Model.FirstName %> <%=Model.LastName%></h2>

    <p>
        <%=Html.ActionLink("Enroll this consumer in a new Program", "create")%>
    </p>
    <p>
        <%=Html.ActionLink("Enroll this consumer in a new Program For Admin Services", "AddAdmin")%>
    </p>    
    <table>
        <tr>
            <th></th>
            <th> Service Requested</th>
            <th> Status </th>
            <th> Program </th>
            <th> Supervisor </th>
            <th> CostCenter </th>
            <th> Location </th>
            <th> Referral Source </th>
            <th> AssignedTo </th>
            <th> Refering Counsler </th>
            <th> Referral Date </th>
            
        </tr>

    <% For Each item In Model.Referrals%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ReferralId})%> | <%=Html.ActionLink("Details", "Details", New With {.id = item.ReferralId})%> | <%=Html.ActionLink("Program", "Outcome", New With {.id = item.ReferralId})%>
            </td>
            <td>
            <% If item.ServiceRequested = 4 Then%>
            
                Other-<%=Html.Encode(item.Other)%>
                
            <% Else%>

                <%=Html.Encode(item.CRPServiceRequested.ServiceRepuested)%>
                
            <%End If%>
            </td>
            <td>
            
            
                <% If item.StatusId = 1 Then%>
                    Open
                <% else %>
                    Closed
                <% End If%>
            </td>
            <td>
                <%=Html.Encode(item.ProgramInstance.Program.ProgramName)%>
            </td>
            <td>
                <%=Html.Encode(item.ProgramInstance.Supervisor.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.ProgramInstance.CostCenter)%>
            </td>
             <td>
                <%=Html.Encode(item.ProgramInstance.Location.LocationName)%>
            </td>
            <td>
                <acronym title="<%=Html.Encode(item.ReferringCounselor.FundingSource.FullName)%>"><%=Html.Encode(item.ReferringCounselor.FundingSource.Acronym)%></acronym>
            </td>
            <td>
                <%=Html.Encode(item.AssignedToUser.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.ReferringCounselor.DisplayName)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.ReferralDate))%>
            </td>

        </tr>
    
    <% Next%>

    </table>

</asp:Content>

