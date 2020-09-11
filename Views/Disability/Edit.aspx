<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Disability)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>
<%=Html.Hidden("rs")%>
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="DisabilityTypeID">Description:</label>
                <%=Html.DropDownList("DisabilityTypeID", Model.GetDisabilityType(Model.RegistrarNo), "[not set]")%>
                <%=Html.ValidationMessage("DisabilityTypeID", "*")%>
            </p>
            <p>
                <label for="TypeId">Type:</label>
                <%=Html.DropDownList("TypeId", Model.GetOrderType(Model.RegistrarNo, Model.TypeId), "[not set]")%>
                <%= Html.ValidationMessage("TypeId", "*") %>
            </p>
            <p>
                <label for="SD">SeverelyDisabled:</label>
                <%=Html.CheckBox("SD")%>
                <%= Html.ValidationMessage("SD", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>
  <p><%=Html.ActionLink("Delete", "Delete", New With {.controller = "Disability", .rs = ViewData("rs"), .Permilink = Model.Info.Permilink, .id = Model.DisabilityID})%></p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

