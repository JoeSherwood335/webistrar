<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

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
                <label for="ProductId">Service Name:</label>
                <%=Html.DropDownList("ProductId", CType(ViewData("Products"), SelectList))%>
                <%= Html.ValidationMessage("ProductId", "*") %>
            </p>
            <p>
                <label for="NumberOfUnits">Number Of Units:</label>
                <%= Html.TextBox("NumberOfUnits") %>
                <%= Html.ValidationMessage("NumberOfUnits", "*") %>
            </p>

            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%=Html.DropDownList("AssignedTo", CType(ViewData("AssignedTos"), SelectList))%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
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

    <div>
        
    </div>

</asp:Content>

