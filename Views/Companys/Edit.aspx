<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Company)" %>

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
                <label for="CompanyShort">CompanyShort:</label>
                <%= Html.TextBox("CompanyShort", Model.CompanyShort) %>
                <%= Html.ValidationMessage("CompanyShort", "*") %>
            </p>
            <p>
                <label for="CompanyName">CompanyName:</label>
                <%= Html.TextBox("CompanyName", Model.CompanyName) %>
                <%= Html.ValidationMessage("CompanyName", "*") %>
            </p>
            <p>
                <label for="Email">Email:</label>
                <%= Html.TextBox("Email", Model.Email) %>
                <%= Html.ValidationMessage("Email", "*") %>
            </p>
            <p>
                <label for="WebSite">WebSite:</label>
                <%= Html.TextBox("WebSite", Model.WebSite) %>
                <%= Html.ValidationMessage("WebSite", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

  

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

