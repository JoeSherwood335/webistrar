<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.WeOutcome)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

<% Using Html.BeginForm()%>

        <fieldset>
            <legend>Goal</legend>
            <p>
                <label for="Goal">What is the Vocational Goal</label>
                <%=Html.TextArea("Goal", New With {.cols = 100, .rows = 10})%>
                <%= Html.ValidationMessage("Goal", "*") %>
            </p>
            <p>
                <label for="GoalAccepted">Was Goal Accepted:</label>
                <%=Html.CheckBox("GoalAccepted")%>
                <%= Html.ValidationMessage("GoalAccepted", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>


