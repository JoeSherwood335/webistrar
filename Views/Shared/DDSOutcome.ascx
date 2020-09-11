<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="CommunityTrips">Number Of Community Trips:</label>
                <%=Html.DropDownList("CommunityTrips", CType(ViewData("CommunityTripssl"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("CommunityTrips", "*") %>
            </p>
            <p>
                <label for="NumberOfNoneWorkRelatedActivities">Number Of None Work Related Activities:</label>
                <%=Html.DropDownList("NumberOfNoneWorkRelatedActivities", CType(ViewData("NumberOfNoneWorkRelatedActivitiessl"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("NumberOfNoneWorkRelatedActivities", "*") %>
            </p>
            <p>
                <label for="StartDateSpan">StartDate Span:</label>
                <%=Html.TextBox("StartDateSpan")%>
                <%= Html.ValidationMessage("StartDateSpan", "*") %>
            </p>
            <p>
                <label for="DateOfAssessment">Date Of Assessment:</label>
                <%= Html.TextBox("DateOfAssessment") %>
                <%= Html.ValidationMessage("DateOfAssessment", "*") %>
            </p>
            <p>
                <label for="NumberOfDaysScheduled">Number Of Days Scheduled:</label>
                <%= Html.TextBox("NumberOfDaysScheduled") %>
                <%= Html.ValidationMessage("NumberOfDaysScheduled", "*") %>
            </p>
            <p>
                <label for="NumberOfDaysAttended">Number Of Days Attended:</label>
                <%= Html.TextBox("NumberOfDaysAttended") %>
                <%= Html.ValidationMessage("NumberOfDaysAttended", "*") %>
            </p>
            <p>
                <label for="AvgGoalScoreFromFirstQuarter">Avg Goal Score From First Quarter:</label>
                <%= Html.TextBox("AvgGoalScoreFromFirstQuarter") %>
                <%= Html.ValidationMessage("AvgGoalScoreFromFirstQuarter", "*") %>
            </p>
            <p>
                <label for="AvgGoalScorefromForthQuarter">Avg Goal Score From Forth Quarter:</label>
                <%= Html.TextBox("AvgGoalScorefromForthQuarter") %>
                <%= Html.ValidationMessage("AvgGoalScorefromForthQuarter", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



