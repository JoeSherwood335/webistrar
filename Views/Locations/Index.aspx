<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Location))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                LocationId
            </th>
            <th>
                LocationName
            </th>
            <th>
                StreetAddress1
            </th>

            <th>
                MainNumber
            </th>
       
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.LocationId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.LocationId})%>
            </td>
            <td>
                <%= Html.Encode(item.LocationId) %>
            </td>
            <td>
                <%= Html.Encode(item.LocationName) %>
            </td>
            <td>
                <%= Html.Encode(item.StreetAddress1) %>
            </td>

            <td>
                <%= Html.Encode(item.MainNumber) %>
            </td>

        </tr>
    
    <% Next%>

    </table>

</asp:Content>

