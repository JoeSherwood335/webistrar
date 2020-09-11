<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Billing.Billing)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%="" %>
    <h2>Details</h2>

    


    <fieldset>
        <legend>Bill</legend>
        <p>
            <%If ViewData("status") = R2kdoiMVC.Myapp.Accrued Then%>
                <%=Html.ActionLink("Start", "Start", New With {.id = Model.Id})%>
                 <%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%>
            <%Else%>
                Billed
            <%End If%>
        </p>
        <p>
            Status <%=Html.Encode(ViewData("status"))%>
        </p>
        <p>
            Invoice Number :
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            Program:
            <%=Html.Encode(Model.Program.ProgramName)%>
        </p>
        <p>
            Location:
            <%=Html.Encode(Model.Location.LocationName)%>
        </p>
        <p>
            CostCenter:
            <%= Html.Encode(Model.CostCenter) %>
        </p>
        <p>
            Date Issued:
            <%=Html.Encode(String.Format("{0:d}", Model.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Take(1).Single(Function(e) e.BillingId = Model.Id).ActionDate))%>
        </p>
        <p>
            Funding Source:
            <%=Html.Encode(Model.FundingSource.FullName)%>
        </p>
        <p>
            Referring Counsler:
            <%=Html.Encode(Model.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            AuthorizationNo:
            <%= Html.Encode(Model.AuthorizationNo) %>
        </p>
       </fieldset>
    
   <p><%Html.RenderPartial("BillingDetails")%></p>
    <p>
        Total billed Amount: <%=Html.Encode(String.Format("{0:c}", (Aggregate a In Model.BillingDetails Into Sum(a.NumberOfUnits * a.UnitPrice))))%>
    </p>    
    <p>
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.Id})%> |
      
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

