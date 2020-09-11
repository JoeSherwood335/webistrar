<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Product)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            ProductId:
            <%= Html.Encode(Model.ProductId) %>
        </p>
        <p>
            ProductName:
            <%= Html.Encode(Model.ProductName) %>
        </p>
        <p>
            ProductDescription:
            <%= Html.Encode(Model.ProductDescription) %>
        </p>
        <p>
            Parent
            <% If Model.ParentId.HasValue Then%>
            <%=Html.Encode(Model.Product.ProductName)%>
            <% End If%>
        </p>
    </fieldset>
    
    
    <p>
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ProductId})%> |
        
    </p>

</asp:Content>

