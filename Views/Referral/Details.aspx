<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Html.Encode(Model.ReferralId)%> Referral for <%=Html.Encode(String.Format("{0} {1}", Model.ProgramInstance.Program.ProgramName, Model.ProgramInstance.Location.LocationName))%>
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=""%>
    <h2><%=Html.Encode(Model.ProgramInstance.Program.ProgramName)%></h2>
    
    <%If Model.StatusId <> 2 Then%>
        <%=Html.ActionLink("Open", "Complete", New With {.id = Model.ReferralId})%> |
    <%Else%>
        <%=Html.ActionLink("Closed", "Complete", New With {.id = Model.ReferralId})%>
    <%End If%>
        
    <%=Html.ActionLink("Edit Referral", "Edit", New With {.id = Model.ReferralId})%> |


   <fieldset>
        <legend>Referral</legend>
        
        <p>
            Referral Source <%=Html.Encode(Model.ReferringCounselor.FundingSource.FullName)%>
        </p>
        <p>
            Referring Counsler <%=Html.Encode(Model.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            Assigned To <%=Html.Encode(Model.AssignedToUser.Username)%>
        </p>
        <p>
            <% If Model.ServiceRequested = 4 Then%>
                Service Requested Other-<%=Html.Encode(Model.Other)%>
            <% Else%>
                Service Requested <%=Html.Encode(Model.CRPServiceRequested.ServiceRepuested)%>
            <%End If%>
        </p>
        <p>
            Referral Date <%=Html.Encode(String.Format("{0:d}", Model.ReferralDate))%>
        </p>
        <p>
            Consumer
            <%=Html.ActionLink(Model.Info.FirstName & " " & Model.Info.LastName, "Details", New With {.permilink = Model.Info.Permilink, .controller = "info"})%>
        </p>
    </fieldset>

   <fieldset>
        <legend>Program</legend>
        <p>
            Name <%=Html.Encode(Model.ProgramInstance.Program.ProgramName)%>
        </p>
        <p>
            CostCenter <%=Html.Encode(Model.ProgramInstance.CostCenter)%>
        </p>
        <p>
            Location <%=Html.Encode(Model.ProgramInstance.Location.LocationName)%>
        </p>
   </fieldset>
    <fieldset>
        <legend>Address</legend>
        <%Html.RenderPartial("Address")%>    
    </fieldset>
    <fieldset>
        <legend>Contacts</legend>    
        <%Html.RenderPartial("Contact")%>
    </fieldset>
    <fieldset>
        <legend>Disabilities</legend>
        <%Html.RenderPartial("Disability")%>
    </fieldset>
    <fieldset>
        <legend>Consumer Descriptor</legend>
        <%  Html.RenderPartial("MiscForm")%>
    </fieldset>
    <fieldset>
        <legend>Authorizations</legend>
        <%Html.RenderPartial("Authorizations")%>
   </fieldset>
</asp:Content>

