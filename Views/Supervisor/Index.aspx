<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Services.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.GetSubordinatesViewResult))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Supervisors View
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Supervisors View</h2>

    
    <table>
    
        <tr>
            <th colspan=1>    </th>
            <th colspan=1>
                Programs
            </th>
            <th colspan=4>
                Services(open enrolles)
            </th>


        </tr>
        <tr>
            <th>
                Staff
            </th>            
            <th>
                <abbr title="Number of Open Programs">Enrolled</abbr>
            </th>
            <th>
                New
            </th>
            <th>
                Pending 
            </th>
            <th>
                InProgress
            </th>
            <th>
                Completed
            </th>
        </tr>

    <% For Each item In Model.OrderBy(Function(e) e.UserName)%>
    
        <tr>
            <td>
                <%= Html.Encode(item.UserName) %>
            </td>
            <td>
                <%=Html.ActionLink(item.NumofOpenReferrals, "Cases", New With {.cm = item.UserName})%>
            </td>
            <td>
                <%=Html.ActionLink(item.NewServices, "NewServices", New With {.controller = "Services", .cm = item.UserName})%>
            </td>
            <td>
                <%=Html.ActionLink(item.PendingServices, "Pending", New With {.controller = "Services", .cm = item.UserName})%>
            </td>
            <td>
                <%=Html.ActionLink(item.InProgressServices, "InProgress", New With {.controller = "Services", .cm = item.UserName})%>
            </td>
            <td>
                <%=Html.ActionLink(item.CompletedServices, "Completed", New With {.controller = "Services", .cm = item.UserName})%>
            </td>


        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

