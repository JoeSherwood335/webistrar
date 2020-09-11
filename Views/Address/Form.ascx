<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Address)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="StreetAddress1">StreetAddress1:</label>
                <%= Html.TextBox("StreetAddress1") %>
                <%= Html.ValidationMessage("StreetAddress1", "*") %>
            </p>
            <p>
                <label for="StreetAddress2">StreetAddress2:</label>
                <%= Html.TextBox("StreetAddress2") %>
                <%= Html.ValidationMessage("StreetAddress2", "*") %>
            </p>
            <p>
                <label for="City">City:</label>
                <%= Html.TextBox("City") %>
                <%= Html.ValidationMessage("City", "*") %>
            </p>
            <p>
                <label for="County">County:</label>
                <%= Html.TextBox("County") %>
                <%= Html.ValidationMessage("County", "*") %>
            </p>
            <p>
                <label for="State">State:</label>
                <%= Html.TextBox("State") %>
                <%= Html.ValidationMessage("State", "*") %>
            </p>
            <p>
                <label for="Zip">Zip:</label>
                <%= Html.TextBox("Zip") %>
                <%= Html.ValidationMessage("Zip", "*") %>
            </p>
                <%=Html.Hidden("rs")%>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

