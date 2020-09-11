<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Authorizations.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NewAuthorizations
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>New Authorizations</h2>

    
    <%=""%>
    
  
    <% Html.RenderPartial("AuthorizationList")%>

        <div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Authorizations", .action = "NewAuthorizations"})%>
	</div>
</asp:Content>

