<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Address)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>
<p><%=Html.ActionLink("Back to Consumer", "Details", New With {.Controller = "info"})%></p>
    
    <fieldset>
        <legend>Fields</legend>
        <p>
            StreetAddress1:
            <%= Html.Encode(Model.StreetAddress1) %>
        </p>
        <p>
            StreetAddress2:
            <%= Html.Encode(Model.StreetAddress2) %>
        </p>
        <p>
            City:
            <%= Html.Encode(Model.City) %>
        </p>
        <p>
            County:
            <%= Html.Encode(Model.County) %>
        </p>
        <p>
            State:
            <%= Html.Encode(Model.State) %>
        </p>
        <p>
            Zip:
            <%= Html.Encode(Model.Zip) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.AddressID})%> |
       
    </p>

</asp:Content>

