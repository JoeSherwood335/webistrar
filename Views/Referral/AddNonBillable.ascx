<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Service)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>


    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Authorization</legend>
            <p>
                <label for="ProductId">Service Name:</label>
                <%=Html.DropDownList("ProductId", Model.GetProductsNonBillableSelectList())%>
                <%=Html.ValidationMessage("ProductId", "*")%>
               
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%=Html.DropDownList("AssignedTo", Model.GetAssignedToAll, "[not set]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            <p>
                <label for="NumberOfUnits">Unites Authorized:</label>
                <%=Html.TextBox("NumberOfUnits")%> 
                <%=Html.ValidationMessage("NumberOfUnits", "*")%>
            </p>

            <p>
                <label for="UnitTypeId">Type:</label>
                <%=Html.DropDownList("UnitTypeId", Model.GetUnitType(), "[not set]")%>
                <%= Html.ValidationMessage("UnitTypeId", "*") %>
            </p>
           <p>
                <label for="SchedualStartDate">Schedual Start Date:</label>
                <%= Html.TextBox("SchedualStartDate") %>
                <%= Html.ValidationMessage("SchedualStartDate", "*") %>
            </p>
            <p>
                <label for="SchedualEndDate">Schedual End Date:</label>
                <%= Html.TextBox("SchedualEndDate") %>
                <%= Html.ValidationMessage("SchedualEndDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>


