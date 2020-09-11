<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Fee)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewPage1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewPage1</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="FeeId">FeeId:</label>
                <%= Html.TextBox("FeeId") %>
                <%= Html.ValidationMessage("FeeId", "*") %>
            </p>
            <p>
                <label for="MainId">MainId:</label>
                <%= Html.TextBox("MainId") %>
                <%= Html.ValidationMessage("MainId", "*") %>
            </p>
            <p>
                <label for="LocationId">LocationId:</label>
                <%= Html.TextBox("LocationId") %>
                <%= Html.ValidationMessage("LocationId", "*") %>
            </p>
            <p>
                <label for="ProductId">ProductId:</label>
                <%= Html.TextBox("ProductId") %>
                <%= Html.ValidationMessage("ProductId", "*") %>
            </p>
            <p>
                <label for="UnitPrice">UnitPrice:</label>
                <%= Html.TextBox("UnitPrice") %>
                <%= Html.ValidationMessage("UnitPrice", "*") %>
            </p>
            <p>
                <label for="UnitTypeId">UnitTypeId:</label>
                <%= Html.TextBox("UnitTypeId") %>
                <%= Html.ValidationMessage("UnitTypeId", "*") %>
            </p>
            <p>
                <label for="MinUnits">MinUnits:</label>
                <%= Html.TextBox("MinUnits") %>
                <%= Html.ValidationMessage("MinUnits", "*") %>
            </p>
            <p>
                <label for="MinUnitTypeId">MinUnitTypeId:</label>
                <%= Html.TextBox("MinUnitTypeId") %>
                <%= Html.ValidationMessage("MinUnitTypeId", "*") %>
            </p>
            <p>
                <label for="InputedBy">InputedBy:</label>
                <%= Html.TextBox("InputedBy") %>
                <%= Html.ValidationMessage("InputedBy", "*") %>
            </p>
            <p>
                <label for="ed">ed:</label>
                <%= Html.TextBox("ed") %>
                <%= Html.ValidationMessage("ed", "*") %>
            </p>
            <p>
                <label for="ud">ud:</label>
                <%= Html.TextBox("ud") %>
                <%= Html.ValidationMessage("ud", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

