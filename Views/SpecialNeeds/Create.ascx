<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.SpecialNeed)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>

            <p>
                <label for="SpecialNeedName">SpecialNeedName:</label>
                <%= Html.TextBox("SpecialNeedName") %>
                <%= Html.ValidationMessage("SpecialNeedName", "*") %>
            </p>
            <p>
                <label for="SpecialNeedDesc">SpecialNeedDesc:</label>
                <%= Html.TextBox("SpecialNeedDesc") %>
                <%= Html.ValidationMessage("SpecialNeedDesc", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>


