<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Program)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ProgramName">Acronym:</label>
                <%= Html.TextBox("Acronym") %>
                <%= Html.ValidationMessage("Acronym", "*") %>
            </p>
            <p>
                <label for="ProgramName">Program Name:</label>
                <%= Html.TextBox("ProgramName") %>
                <%= Html.ValidationMessage("ProgramName", "*") %>
            </p>
            <p>
                <label for="ProgramDescription">Program Description:</label>
                <%=Html.TextArea("ProgramDescription", New With {.cols = 50, .rows = 25})%>
                <%= Html.ValidationMessage("ProgramDescription", "*") %>
            </p>

            <p>
                <label for="PoTypeId">Po Type:</label>
                <%=Html.DropDownList("PoTypeId", CType(ViewData("ProgramOutcomeTypes"), SelectList), "[not set]")%>
                 <%=Html.ValidationMessage("ProgramOutcomeTypeId", "*")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>




