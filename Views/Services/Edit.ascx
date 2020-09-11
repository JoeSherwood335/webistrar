<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Service)" %>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

       <fieldset>
            <legend>Edit Service</legend>
              
            <p>
                <label for="ProductId">Service Name:</label>
                <%=Html.DropDownList("ProductId", Model.GetProductsSelectList())%>
                <%=Html.ValidationMessage("ProductId", "*")%>
               
            </p>
            <p>
                <label for="NumberOfUnits">Number Of Units:</label>
                <%= Html.TextBox("NumberOfUnits") %> 
                <%= Html.ValidationMessage("NumberOfUnits", "*") %>
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%=Html.DropDownList("AssignedTo", Model.GetAssignedTo, "[not set]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            <p>
                <label for="ServiceStartDate">Start Date:</label>
                <%=Html.TextBox("ServiceStartDate", String.Format("{0:d}", Model.ServiceStartDate))%>
                <%= Html.ValidationMessage("ServiceStartDate", "*") %>
            </p>
            <p>
                <label for="ServiceEndDate">End Date:</label>
                <%=Html.TextBox("ServiceEndDate", String.Format("{0:d}", Model.ServiceEndDate))%>
                <%= Html.ValidationMessage("ServiceEndDate", "*") %>
            </p>
            <p>
            <%=Html.Hidden("rs")%>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>




