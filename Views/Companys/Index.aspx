<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MVCPaging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Add")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                CompanyShort
            </th>
            <th>
                CompanyName
            </th>
            <th>
                Email
            </th>
            <th>
                WebSite
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.id})%> |
                <%=Html.ActionLink("Details", "Detail", New With {.id = item.id})%>
            </td>
            <td>
                <%= Html.Encode(item.id) %>
            </td>
            <td>
                <%= Html.Encode(item.CompanyShort) %>
            </td>
            <td>
                <%= Html.Encode(item.CompanyName) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
            <td>
                <%= Html.Encode(item.WebSite) %>
            </td>
        </tr>
    
    <% Next%>

    </table>
<div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Companys", .action = "index"})%>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

