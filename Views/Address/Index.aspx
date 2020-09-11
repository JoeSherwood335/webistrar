<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Address))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <p><%=Html.ActionLink("Back to Consumer", "Details", New With {.controller = "info", .Permilink = Page.Request("Permilink")})%></p>
    
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                StreetAddress1
            </th>
            <th>
                StreetAddress2
            </th>
            <th>
                City
            </th>
            <th>
                County
            </th>
            <th>
                State
            </th>
            <th>
                Zip
            </th>

        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.AddressID})%> &nbsp;
                <%=Html.ActionLink("Details", "Details", New With {.id = item.AddressID})%>
            </td>
            <td>
                <%= Html.Encode(item.StreetAddress1) %>
            </td>
            <td>
                <%= Html.Encode(item.StreetAddress2) %>
            </td>
            <td>
                <%= Html.Encode(item.City) %>
            </td>
            <td>
                <%= Html.Encode(item.County) %>
            </td>
            <td>
                <%= Html.Encode(item.State) %>
            </td>
            <td>
                <%= Html.Encode(item.Zip) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

