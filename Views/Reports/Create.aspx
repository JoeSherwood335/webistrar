<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Report)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

            <p>
            <label for="ReportTypeId">Select Report Type</label><br />
            <%=Html.DropDownList("ReportTypeId", CType(ViewData("ReportType"), SelectList))%>
            <%= Html.ValidationMessage("ReportTypeId", "*") %>
        </p>

        <p>
            <input type="submit" value="Create" />
        </p>

    <% End Using %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

