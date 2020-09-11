<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.ReferringCounselor))" %>

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
                ReferringCounselorId
            </th>
            <th>
                RepCode
            </th>

            <th>
                LastName
            </th>
            <th>
                FirstName
            </th>
        
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ReferringCounselorId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.ReferringCounselorId})%>
            </td>
            <td>
                <%= Html.Encode(item.RepCode) %>
            </td>
               <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

