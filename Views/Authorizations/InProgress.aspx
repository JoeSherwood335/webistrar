<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Authorizations.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	InProgress
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>InProgress</h2>

    <% Html.RenderPartial("AuthorizationList")%>
</asp:Content>
