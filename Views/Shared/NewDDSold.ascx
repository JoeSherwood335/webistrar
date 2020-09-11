<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="CommunityTrips">CommunityTrips:</label>
                <%= Html.TextBox("CommunityTrips") %>
                <%= Html.ValidationMessage("CommunityTrips", "*") %>
            </p>
            <p>
                <label for="NumberOfNoneWorkRelatedActivities">NumberOfNoneWorkRelatedActivities:</label>
                <%= Html.TextBox("NumberOfNoneWorkRelatedActivities") %>
                <%= Html.ValidationMessage("NumberOfNoneWorkRelatedActivities", "*") %>
            </p>
            <p>
                <label for="StartDateSpan">StartDateSpan:</label>
                <%= Html.TextBox("StartDateSpan") %>
                <%= Html.ValidationMessage("StartDateSpan", "*") %>
            </p>
            <p>
                <label for="DateOfAssessment">DateOfAssessment:</label>
                <%= Html.TextBox("DateOfAssessment") %>
                <%= Html.ValidationMessage("DateOfAssessment", "*") %>
            </p>
            <p>
                <label for="NumberOfDaysScheduled">NumberOfDaysScheduled:</label>
                <%= Html.TextBox("NumberOfDaysScheduled") %>
                <%= Html.ValidationMessage("NumberOfDaysScheduled", "*") %>
            </p>
            <p>
                <label for="NumberOfDaysAttended">NumberOfDaysAttended:</label>
                <%= Html.TextBox("NumberOfDaysAttended") %>
                <%= Html.ValidationMessage("NumberOfDaysAttended", "*") %>
            </p>
            <p>
                <label for="AvgGoalScoreFromFirstQuarter">AvgGoalScoreFromFirstQuarter:</label>
                <%= Html.TextBox("AvgGoalScoreFromFirstQuarter") %>
                <%= Html.ValidationMessage("AvgGoalScoreFromFirstQuarter", "*") %>
            </p>
            <p>
                <label for="AvgGoalScorefromForthQuarter">AvgGoalScorefromForthQuarter:</label>
                <%= Html.TextBox("AvgGoalScorefromForthQuarter") %>
                <%= Html.ValidationMessage("AvgGoalScorefromForthQuarter", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>


