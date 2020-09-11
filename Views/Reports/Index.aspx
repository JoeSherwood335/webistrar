<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Report))" %>

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
                ReportsId
            </th>
            <th>
                ReferralId
            </th>
            <th>
                ReportTypeId
            </th>
            <th>
                ReportName
            </th>
            <th>
                ReportContent
            </th>
            <th>
                ReportStatusId
            </th>
            <th>
                TimeStamp
            </th>
            <th>
                InputedBy
            </th>
            <th>
                ed
            </th>
            <th>
                ud
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ReportsId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.ReportsId})%>
            </td>
            <td>
                <%= Html.Encode(item.ReportsId) %>
            </td>
            <td>
                <%= Html.Encode(item.ReferralId) %>
            </td>
            <td>
                <%= Html.Encode(item.ReportTypeId) %>
            </td>
            <td>
                <%= Html.Encode(item.ReportName) %>
            </td>
            <td>
                <%= Html.Encode(item.ReportContent) %>
            </td>
            <td>
                <%= Html.Encode(item.ReportStatusId) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.TimeStamp)) %>
            </td>
            <td>
                <%= Html.Encode(item.InputedBy) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ed)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ud)) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

