<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.FundingSource)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
          
            <p>
                <label for="Acronym">Acronym:</label>
                <%= Html.TextBox("Acronym") %>
                <%= Html.ValidationMessage("Acronym", "*") %>
            </p>
            <p>
                <label for="FullName">FullName:</label>
                <%= Html.TextBox("FullName") %>
                <%= Html.ValidationMessage("FullName", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

