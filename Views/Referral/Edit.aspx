<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>
<%=Html.Hidden("rs")%>
         <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ReferralSourceId">Referral Source</label>
                <%=Html.Encode(Model.ReferringCounselor.FundingSource.FullName)%>
            </p>
            <p>
                <label for="ReferingCounslerId">Refering Counsler</label>
                <%=Html.Encode(Model.ReferringCounselor.FirstName )%> <%=Html.Encode(Model.ReferringCounselor.LastName)%> <br />
            </p>
             <p>
                <label for="ProgramId">ProgramId:</label>
                <%=Html.DropDownList("ProgramId", Model.GetPrograms(Model.ProgramId))%>
                <%= Html.ValidationMessage("ProgramId", "*") %>
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                
                <%=Html.DropDownList("AssignedTo", Model.GetAssignedTo(Model.AssignedTo))%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            <p>
                <label for="ServiceRequested">Service Requested</label>
                
                <%=Html.DropDownList("ServiceRequested", Model.GetCRPServiceRequesteds(Model.CRPServiceRequested.ServiceRequestedId))%>
                <%= Html.ValidationMessage("ServiceRequested", "*") %>
            </p>
                       <p>
                <label for="Other">Other:</label>
                <%=Html.TextBox("Other")%>
                <%=Html.ValidationMessage("Other", "*")%>
            </p>
            <p>
                <label for="ReferralDate">ReferralDate:</label>
                <%= Html.TextBox("ReferralDate") %>
                <%= Html.ValidationMessage("ReferralDate", "*") %>
            </p>
            <p>
                   
                <input type="submit" value="Create" />
            </p>
        </fieldset>
        <%End Using%>

    <div>
        
    </div>

</asp:Content>

