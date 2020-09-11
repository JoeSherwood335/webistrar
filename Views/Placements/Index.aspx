<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Placements For <%=html.Encode(model.FirstName) %> <%=Html.Encode(Model.LastName)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Placements For <%=html.Encode(model.FirstName) %> <%=Html.Encode(Model.LastName)%></h2>

    <p>
        <!--<%=Html.ActionLink("Add Placement", "Company", New With {.Permilink = Model.Permilink, .controller = "Placements"})%>-->
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Type
            </th>
            <th>
                Staff
            </th>
            <th>
                Company
            </th>
           
        </tr>

    <% For Each item In Model.Placements.Where(Function(e) e.IsPlacement = true)%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.PlacementId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.PlacementId})%>
            </td>
            <td>
                <%=Html.Encode(item.PlacementType.PlacementType)%>
            </td>
            <td>
                <%=Html.Encode(item.RegisteredUser.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.Company.CompanyName)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

