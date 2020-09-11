<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Disability)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Disability</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
<%=Html.Hidden("rs")%>
        <fieldset>
            <legend>Add Disability</legend>
            <p>
                <label for="DisabilityTypeID">Description:</label>
                <%=Html.DropDownList("DisabilityTypeID", Model.GetDisabilityType(ViewData("RegistrarNo")), "[not set]")%>
                <%=Html.ValidationMessage("DisabilityTypeID", "*")%>
            </p>
            <p>
                <label for="TypeId">Type:</label>
                <%=Html.DropDownList("TypeId", Model.GetOrderType(ViewData("RegistrarNo")), "[not set]")%>
                <%= Html.ValidationMessage("TypeId", "*") %>
            </p>
            <p>
                <label for="SD">SeverelyDisabled:</label>
                <%=Html.CheckBox("SD", False)%>
                <%= Html.ValidationMessage("SD", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

