<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.JCOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Job Coaching
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Job Coaching</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="WorkIndependently">Work Independently:</label>
                <%=Html.DropDownList("WorkIndependently", CType(ViewData("WorkIndependentlyl"), SelectList))%>
                <%=Html.ValidationMessage("WorkIndependently", "*")%>
            </p>
            <p>
                <label for="TravelIndependently">Travel Independently:</label>
                <%=Html.DropDownList("TravelIndependently", CType(ViewData("TravelIndependentlyl"), SelectList))%>
                <%= Html.ValidationMessage("TravelIndependently", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

