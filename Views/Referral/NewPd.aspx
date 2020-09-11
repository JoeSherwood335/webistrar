<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.PdOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New Placement Outcome
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>New Placement Outcome</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="NumberOfInterviews">Number Of Interviews:</label>
                <%= Html.TextBox("NumberOfInterviews") %>
                <%= Html.ValidationMessage("NumberOfInterviews", "*") %>
            </p>
            <p>
                <label for="NumberOfJobCoachingHours">Number Of JobCoaching:</label>
                <%= Html.TextBox("NumberOfJobCoachingHours") %>
                <%= Html.ValidationMessage("NumberOfJobCoachingHours", "*") %>
            </p>
            <p>
                <label for="NumberOfJobRententionHours">Number Of Job Rentention:</label>
                <%= Html.TextBox("NumberOfJobRententionHours") %>
                <%= Html.ValidationMessage("NumberOfJobRententionHours", "*") %>
            </p>
            <p>
                <label for="JobGoal1">JobGoal1:</label>
                <%=Html.TextArea("JobGoal1", New With {.cols = 30, .rows = 5})%>
                <%= Html.ValidationMessage("JobGoal1", "*") %>
            </p>
            <p>
                <label for="JobGoal2">JobGoal2:</label>
                <%=Html.TextArea("JobGoal2", New With {.cols = 30, .rows = 5})%>
                <%= Html.ValidationMessage("JobGoal2", "*") %>
            </p>
            <p>
                <label for="JobGoal3">JobGoal3:</label>
                <%=Html.TextArea("JobGoal3", New With {.cols = 30, .rows = 5})%>
                <%= Html.ValidationMessage("JobGoal3", "*") %>
            </p>
            <p>
                <input type="Submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

