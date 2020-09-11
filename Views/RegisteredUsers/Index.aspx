<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.RegisteredUser))" %>

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
                Username
            </th>
            <th>
                Supervisor
            </th>
            <th>
                Profile
            </th>
            
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.UserId})%> |
            </td>
            <td>
                <%=Html.Encode(item.UserId)%>, <%= Html.Encode(item.Username) %>
            </td>
            <td>
                <%If item.Supervisor.HasValue Then%>            
                    <%=Html.ActionLink(item.RegisteredUser.Username, "Details", New With {.id = item.Supervisor})%> 
                <%End If%>
            </td>
            <td>
                 <%=Html.Encode(item.Profile.Name)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

