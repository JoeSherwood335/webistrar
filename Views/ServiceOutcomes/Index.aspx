<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.SetServiceOutcomeForProduct))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <%  Using Html.BeginForm("Index", "ServiceOutcomes", FormMethod.Get)%>
            <%=Html.DropDownList("ProductId", CType(ViewData("Product"), SelectList), "[Not Set]")%><br />
            <input type="submit" value="Show" />
            
     <%   End Using%>
    
    
    <table>
        <tr>
            <th></th>
            <th>
                Product
            </th>
            <th>
                Service Outcome
            </th>
            <th></th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Remove", "Remove", New With {.Id = 0, .ProductId = item.ProductId, .ServiceOutcomeId = item.ServiceOutcomeId})%>
            </td>
            <td>
                <%=Html.Encode(item.Product.ProductName)%>
            </td>
            <td>
                <%=Html.Encode(item.ServiceOutcome.ServiceOutcomeName)%>
            </td>
            <td>
                <%= Html.Encode(item.OrderBy) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

