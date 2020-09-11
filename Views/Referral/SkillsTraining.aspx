<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Skills Training Outcome
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Skills Training Outcome</h2>
    <%=Html.ActionLink("Referral", "Complete", New With {.Permilink = ViewData("Permilink"), .id = ViewData("ReferralId")})%>
    <%Html.RenderPartial("stOutcome")%>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
