<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Time Worked</legend>
            <p>
                <label for="Hours">Hours:</label>
                <%=Html.TextBox("Hours")%> 
            </p>
            <p>
                <label for="Minutes">Minutes:</label>
                <%=Html.TextBox("Minutes")%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>


