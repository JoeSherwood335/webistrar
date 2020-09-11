<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Company)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            id:
            <%= Html.Encode(Model.id) %>
        </p>
        <p>
            CompanyShort:
            <%= Html.Encode(Model.CompanyShort) %>
        </p>
        <p>
            CompanyName:
            <%= Html.Encode(Model.CompanyName) %>
        </p>
        <p>
            Email:
            <%= Html.Encode(Model.Email) %>
        </p>
        <p>
            WebSite:
            <%= Html.Encode(Model.WebSite) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.id})%> |
  
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

