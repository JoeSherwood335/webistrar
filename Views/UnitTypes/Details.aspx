<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.UnitType)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            UnitType:
            <%= Html.Encode(Model.UnitType) %>
        </p>
        <p>
            Orderby:
            <%= Html.Encode(Model.Orderby) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.UnitTypeId})%> |
        
    </p>

</asp:Content>

