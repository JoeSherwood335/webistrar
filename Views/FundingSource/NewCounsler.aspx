<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ReferringCounselor)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New Counsler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>NewCounsler</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="RepCode">RepCode:</label>
                <%= Html.TextBox("RepCode") %>
                <%= Html.ValidationMessage("RepCode", "*") %>
            </p>
            <p>
                <label for="LastName">LastName:</label>
                <%= Html.TextBox("LastName") %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="FirstName">FirstName:</label>
                <%= Html.TextBox("FirstName") %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            <p>
                <%=Html.Hidden("rs")%>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

