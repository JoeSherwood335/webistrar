<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Location)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="LocationId">LocationId:</label>
                <%= Html.TextBox("LocationId", Model.LocationId) %>
                <%= Html.ValidationMessage("LocationId", "*") %>
            </p>
            <p>
                <label for="LocationName">LocationName:</label>
                <%= Html.TextBox("LocationName", Model.LocationName) %>
                <%= Html.ValidationMessage("LocationName", "*") %>
            </p>
            <p>
                <label for="StreetAddress1">StreetAddress1:</label>
                <%= Html.TextBox("StreetAddress1", Model.StreetAddress1) %>
                <%= Html.ValidationMessage("StreetAddress1", "*") %>
            </p>
            <p>
                <label for="StreetAddress2">StreetAddress2:</label>
                <%= Html.TextBox("StreetAddress2", Model.StreetAddress2) %>
                <%= Html.ValidationMessage("StreetAddress2", "*") %>
            </p>
            <p>
                <label for="City">City:</label>
                <%= Html.TextBox("City", Model.City) %>
                <%= Html.ValidationMessage("City", "*") %>
            </p>
            <p>
                <label for="Zip">Zip:</label>
                <%= Html.TextBox("Zip", Model.Zip) %>
                <%= Html.ValidationMessage("Zip", "*") %>
            </p>
            <p>
                <label for="County">County:</label>
                <%= Html.TextBox("County", Model.County) %>
                <%= Html.ValidationMessage("County", "*") %>
            </p>
            <p>
                <label for="State">State:</label>
                <%= Html.TextBox("State", Model.State) %>
                <%= Html.ValidationMessage("State", "*") %>
            </p>
            <p>
                <label for="MainNumber">MainNumber:</label>
                <%= Html.TextBox("MainNumber", Model.MainNumber) %>
                <%= Html.ValidationMessage("MainNumber", "*") %>
            </p>
            <p>
                <label for="TTyNumber">TTyNumber:</label>
                <%= Html.TextBox("TTyNumber", Model.TTyNumber) %>
                <%= Html.ValidationMessage("TTyNumber", "*") %>
            </p>
            <p>
                <label for="FaxNumber">FaxNumber:</label>
                <%= Html.TextBox("FaxNumber", Model.FaxNumber) %>
                <%= Html.ValidationMessage("FaxNumber", "*") %>
            </p>
            <p>
                <label for="WebAddress">WebAddress:</label>
                <%= Html.TextBox("WebAddress", Model.WebAddress) %>
                <%= Html.ValidationMessage("WebAddress", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

