<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramInstance)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
      
            <p>
                <label for="CostCenter">CostCenter:</label>
                <%= Html.TextBox("CostCenter") %>
                <%= Html.ValidationMessage("CostCenter", "*") %>
            </p>
            <p>
                <label for="LocationId">Location:</label>
                <%=Html.DropDownList("LocationId", CType(ViewData("Locations"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("LocationId", "*") %>
            </p>
            <p>
                <label for="SupervisorId">Authorization Supervisor:</label>
                <%=Html.DropDownList("SupervisorId", CType(ViewData("Supervisors"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("SupervisorId", "*") %>
            </p>
            <p>
                <label for="SupervisorId">Billing Supervisor:</label>
                <%=Html.DropDownList("BillingSupervisorId", CType(ViewData("Supervisors"), SelectList), "[not set]")%>
                <%=Html.ValidationMessage("BillingSupervisorId", "*")%>
            </p>
            <p>
                <label for="InActive">InActive:</label>
                <%=Html.CheckBox("InActive")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
    <%Try%>
        <%=Html.ActionLink("Back to List", "Details", New With {.id = Model.ProgramId})%>
    <%Catch%> 
        <%=Html.ActionLink("Back to List", "Index")%>
    <%End Try%>
    </div>


