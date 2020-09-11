<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.FundingSource)" %>

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
                <label for="Acronym">Acronym:</label>
                <%= Html.TextBox("Acronym", Model.Acronym) %>
                <%= Html.ValidationMessage("Acronym", "*") %>
            </p>
            <p>
                <label for="FullName">FullName:</label>
                <%= Html.TextBox("FullName", Model.FullName) %>
                <%= Html.ValidationMessage("FullName", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>


</asp:Content>

