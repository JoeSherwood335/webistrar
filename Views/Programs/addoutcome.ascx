<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.SetServiceOutcomesforProgram)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ServiceOutcomeId">ServiceOutcomeId:</label>
                <%=Html.DropDownList("ServiceOutcomeId", CType(ViewData("ServiceOutcomes"), SelectList), "[not set]")%>
                <%=Html.ValidationMessage("ServiceOutcomeId", "*")%>
            </p>
            <%=Html.Hidden("ProgramId")%>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>




