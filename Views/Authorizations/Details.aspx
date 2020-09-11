<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Authorization)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Authorization <%=Html.Encode(Model.AuthorizationNumber)%> from <%=Html.Encode(Model.FundingCounselor.FundingSource.Acronym)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Authorization</h2>
    <p>
        
        <%=Html.ActionLink("Referral", "Details", New With {.permilink = Model.Referral.Info.Permilink, .id = Model.Referral.ReferralId, .controller = "referral"})%> 
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.AuthorizationID})%>
    </p>
    <%If Not Model.ApproveById.HasValue Then%>
    
        <%Using Html.BeginForm("Approve", "Authorizations", New With {.id = Model.AuthorizationID})%>
          
            <input type="submit" value="Approve" />
        <%End Using%>
    
    <%Else%>
    
          
    <%End If  %>


    <p><%=Html.Encode(Model.FundingCounselor.FundingSource.FullName)%></p>
    <p><%=Html.Encode(Model.FundingCounselor.DisplayName)%></p>
    <fieldset>
        <legend>Program</legend>
        <p>
            Program <%=Html.Encode(Model.Referral.ProgramInstance.Program.ProgramName)%>
        </p>
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
            <%=Html.ActionLink(Model.Referral.Info.FirstName & " " & Model.Referral.Info.LastName, "Details", New With {.permilink = Model.Referral.Info.Permilink, .controller = "info"})%>
        </p>
    </fieldset>
    <fieldset>
        <legend>Authorization</legend>
        <p>
           Authorization Number <%=Html.Encode(Model.AuthorizationNumber)%>
        </p>
        <p>
           Authorization Date <%=Html.Encode(Model.AuthorizationDate.ToShortDateString)%>
        </p>
        <p>
            Amount Billed: <%=Html.Encode(String.Format("{0:c}", ViewData("AmountBilled")))%>        
        </p>
        
   </fieldset>
   <fieldset>
        <legend>Details</legend>
         <% Html.RenderPartial("AuthorizationDetails")%>
    </fieldset>
    <fieldset>
        <legend>Notes</legend>
        <% Html.RenderPartial("ReadNotes")%>
    </fieldset>
    <fieldset>
        <legend>Bills</legend>
        <ul>
            <% For Each bill As R2kdoiMVC.Model.Billing.Billing  In model.GetBills  %>
                <li>
                    <%=Html.ActionLink(bill.GetStatus, "Details", New With {.id = bill.Id, .controller = "billings"}, New With {.target = "_blank"})%>&nbsp;                   
                    <%=String.Format("{0:c}", (Aggregate a In bill.BillingDetails Into Sum(a.UnitPrice * a.NumberOfUnits)))%>&nbsp;                         
                    <%=String.Format("{0:d}", (Aggregate a In bill.BillingDetails Into Min(a.StartDate)))%>&nbsp;                         
                    <%=String.Format("{0:d}", (Aggregate a In bill.BillingDetails Into Max(a.EndDate)))%>&nbsp;
                </li>
             <% next %>
           </ul>        
    </fieldset>
      </asp:Content>

