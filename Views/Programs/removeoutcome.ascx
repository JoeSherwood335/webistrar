<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.SetServiceOutcomesforProgram)" %>



    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Remove</legend>
            <p>
                <%=Model.Program.ProgramName%>
                <%=Html.Hidden("ProgramId")%>
            </p>
            <p>
                <%=Model.ServiceOutcome.ServiceOutcomeName%>
                <%=Html.Hidden("ServiceOutcomeId")%>
            </p>
            <p>
                <input type="submit" value="Remove" />
            </p>
        </fieldset>

    <% End Using %>



