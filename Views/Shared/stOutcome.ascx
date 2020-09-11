<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.StOutcome)" %>
<%@ Import Namespace="R2kdoiMVC" %>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <!--p>
                <label for="PracticeName">PracticeName:</label>
                <%= Html.TextBox("PracticeName") %>
                <%= Html.ValidationMessage("PracticeName", "*") %>
            </p-->
            <p>
                <label for="PracticeScore">Pre TestScore:</label>
                <%= Html.TextBox("PracticeScore") %>
                <%= Html.ValidationMessage("PracticeScore", "*") %>
            </p>
            <!--p>
                <label for="MainName">Post TestScore:</label>
                <%= Html.TextBox("MainName") %>
                <%= Html.ValidationMessage("MainName", "*") %>
            </p-->
            <p>
                <label for="MainScore">Post TestScore:</label>
                <%= Html.TextBox("MainScore") %>
                <%= Html.ValidationMessage("MainScore", "*") %>
            </p>
            <p>
                <label for="SatFor3rdPartyCert">Completed 3rd Party Certification:</label>
                <%=Html.TextBox("SatFor3rdPartyCert")%>
                <%=Html.ValidationMessage("SatFor3rdPartyCert", "*")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>


