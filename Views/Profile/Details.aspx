<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Profile)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Profile</h2>

   <p>
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ProfileId})%> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

    <p>
        Name: <%= Html.Encode(Model.Name) %>
    </p>
    
    <ol>
        <% For Each g In Model.ProfileGroupContainers%>
            <li><%=g.Group.Groupname%></li>
        <% Next%>
    </ol>
    
 

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

