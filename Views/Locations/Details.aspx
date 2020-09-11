<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Location)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            LocationId:
            <%= Html.Encode(Model.LocationId) %>
        </p>
        <p>
            LocationName:
            <%= Html.Encode(Model.LocationName) %>
        </p>
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
            Zip:
            <%= Html.Encode(Model.Zip) %>
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
            MainNumber:
            <%= Html.Encode(Model.MainNumber) %>
        </p>
        <p>
            TTyNumber:
            <%= Html.Encode(Model.TTyNumber) %>
        </p>
        <p>
            FaxNumber:
            <%= Html.Encode(Model.FaxNumber) %>
        </p>
        <p>
            WebAddress:
            <%= Html.Encode(Model.WebAddress) %>
        </p>
    </fieldset>


</asp:Content>

