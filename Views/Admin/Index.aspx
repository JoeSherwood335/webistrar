<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin</h2>
    <ul>
       <li><%=Html.ActionLink("Programs", "Index", "Programs")%></li>       
       <li><%=Html.ActionLink("Funding Source", "Index", "FundingSource")%></li>
       <li><%=Html.ActionLink("Fee", "Index", "Fees")%></li>
       <li><%=Html.ActionLink("Profile", "Index", "Profile")%></li>
       <li><%=Html.ActionLink("Registered Users", "Index", "RegisteredUsers")%></li>
    </ul>
    
    <%= Application("UsersOnline")%>
    
    <ul>
    <% Dim d As Dictionary(Of String, DateTime) = HttpContext.Current.Application("userlist")%>
        <%  Dim list As New List(Of String)(d.Keys)%>
        <% For Each s As String In list%>
        <li><%=s%></li>
        <% Next%>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
