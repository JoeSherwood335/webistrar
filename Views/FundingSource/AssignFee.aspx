<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.AssignFeesContainer)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AssignFee
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AssignFee</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <%=Html.Hidden("fsid", ViewData("fsid"))%>
            
                <label for="FeeSchedualId">Fee Schedual</label>
                <%=Html.DropDownList("FeeSchedualId", CType(ViewData("FeeSchedual"), SelectList))%>
                <%= Html.ValidationMessage("FeeSchedualId", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>


</asp:Content>

