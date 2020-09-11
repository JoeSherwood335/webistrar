<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.PdOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Placement Outcome
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <h2>Edit Placement Outcome</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="NumberOfInterviews">NumberOfInterviews:</label>
                <%= Html.TextBox("NumberOfInterviews", Model.NumberOfInterviews) %>
                <%= Html.ValidationMessage("NumberOfInterviews", "*") %>
            </p>
            <p>
                <label for="NumberOfJobCoachingHours">NumberOfJobCoachingHours:</label>
                <%= Html.TextBox("NumberOfJobCoachingHours", Model.NumberOfJobCoachingHours) %>
                <%= Html.ValidationMessage("NumberOfJobCoachingHours", "*") %>
            </p>
            <p>
                <label for="NumberOfJobRententionHours">NumberOfJobRententionHours:</label>
                <%= Html.TextBox("NumberOfJobRententionHours", Model.NumberOfJobRententionHours) %>
                <%= Html.ValidationMessage("NumberOfJobRententionHours", "*") %>
            </p>
            <p>
                <label for="JobGoal1">JobGoal1:</label>
                <%=Html.TextArea("JobGoal1", Model.JobGoal1, 5, 30, Nothing)%>
                <%= Html.ValidationMessage("JobGoal1", "*") %>
            </p>
            <p>
                <label for="JobGoal2">JobGoal2:</label>
                <%=Html.TextArea("JobGoal2", Model.JobGoal2, 5, 30, Nothing)%>
                <%= Html.ValidationMessage("JobGoal2", "*") %>
            </p>
            <p>
                <label for="JobGoal3">JobGoal3:</label>
                <%=Html.TextArea("JobGoal3", Model.JobGoal3, 5, 30, Nothing)%>
                <%= Html.ValidationMessage("JobGoal3", "*") %>
            </p>
            <p>
                <input type="Submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

