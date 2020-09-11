<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.FundingSource))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create", New With {.Acronym = "New"})%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                FundingSourceId
            </th>
            <th>
                Acronym
            </th>
            <th>
                FullName
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
               
                <%=Html.ActionLink("Details", "Details", New With {.Acronym = item.Acronym})%>
            </td>
            <td>
                <%= Html.Encode(item.FundingSourceId) %>
            </td>
            <td>
                <%= Html.Encode(item.Acronym) %>
            </td>
            <td>
                <%= Html.Encode(item.FullName) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

