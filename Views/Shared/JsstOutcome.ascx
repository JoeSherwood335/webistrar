<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.JsstOutcome)" %>

     <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>JSST / PD</legend>
            <p>
                <label for="Following">Following Instructions:</label>
                <%=Html.DropDownList("Following", Model.GetSelectList(Model.Following), "[Not Set]")%>
                <%= Html.ValidationMessage("Following", "*") %>
            </p>
            <p>
                <label for="JobSearch">Job Search:</label>
                <%=Html.DropDownList("JobSearch", Model.GetSelectList(Model.JobSearch), "[Not Set]")%>
                <%= Html.ValidationMessage("JobSearch", "*") %>
            </p>
            <p>
                <label for="TransferrableSkills">Transferrable Skills:</label>
                <%=Html.DropDownList("TransferrableSkills", Model.GetSelectList(Model.TransferrableSkills), "[Not Set]")%>
                <%= Html.ValidationMessage("TransferrableSkills", "*") %>
            </p>
            <p>
                <label for="Assignments">Assignments:</label>
                <%=Html.DropDownList("Assignments", Model.GetSelectList(Model.Assignments), "[Not Set]")%>
                <%= Html.ValidationMessage("Assignments", "*") %>
            </p>
            <p>
                <label for="Applications">Applications:</label>
                <%=Html.DropDownList("Applications", Model.GetSelectList(Model.Applications), "[Not Set]")%>
                <%= Html.ValidationMessage("Applications", "*") %>
            </p>
            <p>
                <label for="Resumes">Resumes:</label>
                <%=Html.DropDownList("Resumes", Model.GetSelectList(Model.Resumes), "[Not Set]")%>
                <%= Html.ValidationMessage("Resumes", "*") %>
            </p>
            <p>
                <label for="CoverLetter">CoverLetter:</label>
                <%=Html.DropDownList("CoverLetter", Model.GetSelectList(Model.CoverLetter), "[Not Set]")%>
                <%= Html.ValidationMessage("CoverLetter", "*") %>
            </p>
            <p>
                <label for="Interviewing">Interviewing:</label>
                <%=Html.DropDownList("Interviewing", Model.GetSelectList(Model.Interviewing), "[Not Set]")%>
                <%= Html.ValidationMessage("Interviewing", "*") %>
            </p>
            <p>
                <label for="Etiquette">Etiquette / Appearance:</label>
                <%=Html.DropDownList("Etiquette", Model.GetSelectList(Model.Etiquette), "[Not Set]")%>
                <%= Html.ValidationMessage("Etiquette", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>


