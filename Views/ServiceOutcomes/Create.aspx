<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.SetServiceOutcomeForProduct)" %>

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
                <label for="ProductId">ProductId:</label>
                <%=Html.DropDownList("ProductId", CType(ViewData("Product"), SelectList))%>
                <%= Html.ValidationMessage("ProductId", "*") %>
            </p>
            <p>
                <label for="ServiceOutcomeId">ServiceOutcomeId:</label>
                <%=Html.DropDownList("ServiceOutcomeId", CType(ViewData("ServiceOutcome"), SelectList))%>
                <%= Html.ValidationMessage("ServiceOutcomeId", "*") %>
            </p>
            <p>
                <label for="OrderBy">OrderBy:</label>
                <%= Html.TextBox("OrderBy") %>
                <%= Html.ValidationMessage("OrderBy", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>

</asp:Content>

