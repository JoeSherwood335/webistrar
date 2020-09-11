<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	My Permissions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Permissions</h2>
    
    <p>
        username: <%=R2kdoiMVC.Myapp.user(True)%>
    </p>
    <p>
        Profile: <%=R2kdoiMVC.Myapp.GetUserInfo(R2kdoiMVC.Myapp.user(True)).Profile.Name%>
    </p>
    
    <ol>
        <% For Each s In Model%>
            <li><%=s %></li>
        <% Next%>
    </ol>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
