<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Authorizations.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	    Authorizations Under Closed Referals 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Approved Authorizatons</h2>
    
    <p>
        Authorizations Under Open Referals 
    </p>
    
<% Html.RenderPartial("AuthorizationList")%>


	<div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Authorizations", .action = "AuthorizationsByOpenReferrals"})%>
	</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

