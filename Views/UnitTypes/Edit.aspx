<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.UnitType)" %>

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
                <label for="UnitType">UnitType:</label>
                <%= Html.TextBox("UnitType", Model.UnitType) %>
                <%= Html.ValidationMessage("UnitType", "*") %>
            </p>
            <p>
                <label for="Orderby">Orderby:</label>
                <%= Html.TextBox("Orderby", Model.Orderby) %>
                <%= Html.ValidationMessage("Orderby", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>

</asp:Content>

