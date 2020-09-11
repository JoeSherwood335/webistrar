<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.UnitType))" %>

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
                UnitType
            </th>
            <th>
                Orderby
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.UnitTypeId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.UnitTypeId})%>
            </td>

            <td>
                <%= Html.Encode(item.UnitType) %>
            </td>
            <td>
                <%= Html.Encode(item.Orderby) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

