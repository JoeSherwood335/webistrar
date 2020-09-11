<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Manual Billing
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manual Billing</h2>

    <p>
       <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>
    </p>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Manual Billing</legend>
            <p>
                <label for="NumberOfUnits">Number Of Units:</label>
                <%= Html.TextBox("NumberOfUnits") %>
                <%= Html.ValidationMessage("NumberOfUnits", "*") %>
            </p>
            <p>
                <label for="UnitPrice">Unit Price:</label>
                <%=Html.TextBox("UnitPrice")%>
                <%=Html.ValidationMessage("UnitPrice", "*")%>
            </p>            
            <p>
                <label for="ServiceStartDate">Start Date:</label>
                <%= Html.TextBox("ServiceStartDate") %>
                <%= Html.ValidationMessage("ServiceStartDate", "*") %>
            </p>
            <p>
                <label for="ServiceEndDate">End Date:</label>
                <%= Html.TextBox("ServiceEndDate") %>
                <%= Html.ValidationMessage("ServiceEndDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

