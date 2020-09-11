<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ActiveUsers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ActiveUsers</h2>

<table>
<thead>
    <th>UserName</th>
</thead>
<% For Each User As MembershipUser In Membership.GetAllUsers%>
<tr>
<td><%=User.UserName%></td>
<td><%=User.LastLoginDate()%></td>
<td><%Html.ActionLink("DeleteActiveUs%></td>

</tr>
<% Next %>
</table>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
