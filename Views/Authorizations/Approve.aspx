<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Authorization)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Approve
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%="" %>
    <h2>Approve</h2>
    
   
    
    <fieldset>
        <legend>Authorizations</legend>
        <p>
           Authorization Number <%=Html.Encode(Model.AuthorizationNumber)%>
        </p>
        <p>
           Authorization Date <%=Html.Encode(Model.AuthorizationDate.ToShortDateString)%>
        </p>
            <p>
                Total Amount Authorized <% If Model.TotalAmoun tAuthorized = Decimal.Zero Then%>
                    <%=Html.Encode(String.Format("{0:c}", (From a In Model.Services Select a.AmountAuthorized).Sum()))%>
                <% Else%>
                    <%=Html.Encode(String.Format("{0:c}", Model.TotalAmountAuthorized))%>
                <% End If%>
            </p>
            <p>
                Number Of Unites Authorized <% If Model.TotalUnitsAuthorized = Decimal.Zero Then%>
                    <%=Html.Encode(String.Format("{0:F}", (From a In Model.Services Select a.NumberOfUnitesAuthorized).Sum()))%>
                <% Else%>
                    <%=Html.Encode(String.Format("{0:F}", Model.TotalUnitsAuthorized))%>
                <% End If%>
            </p>
        <p>
           
        </p>
   </fieldset>
       <fieldset>
        <legend>Program</legend>
        
        <p>
            Referral Source <%=Html.Encode(Model.Referral.ReferringCounselor.FundingSource.FullName)%>
        </p>
        <p>
            Referring Counsler <%=Html.Encode(Model.Referral.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            Assigned To <%=Html.Encode(Model.Referral.AssignedToUser.Username)%>
        </p>
        <p>
            <% If Model.Referral.ServiceRequested = 4 Then%>
            
                Service Requested Other-<%=Html.Encode(Model.Referral.Other)%>
            <% Else%>
                Service Requested <%=Html.Encode(Model.Referral.CRPServiceRequested.ServiceRepuested)%>
            
            <%End If%>
        </p>
        <p>
            Referral Date <%=Html.Encode(String.Format("{0:d}", Model.Referral.ReferralDate))%>
        </p>
        <p>
            Consumer
            <%=Html.ActionLink(Model.Referral.Info.GetFullName, "Details", New With {.permilink = Model.Referral.Info.Permilink, .controller = "info"})%>
        </p>
    </fieldset>
   
   <fieldset>
        <legend>Program</legend>
        <p>
            Name <%=Html.Encode(Model.Referral.ProgramInstance.Program.ProgramName)%>
        </p>
        <p>
            CostCenter <%=Html.Encode(Model.Referral.ProgramInstance.CostCenter)%>
        </p>
        <p>
            Location <%=Html.Encode(Model.Referral.ProgramInstance.Location.LocationName)%>
        </p>
   </fieldset>

<% Html.RenderPartial("AuthorizationDetails")%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
