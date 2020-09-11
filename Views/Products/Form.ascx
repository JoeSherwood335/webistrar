<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Product)" %>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ProductName">ProductName:</label>
                <%= Html.TextBox("ProductName") %>
                <%= Html.ValidationMessage("ProductName", "*") %>
                
            </p>
            <p>
                <label for="ProductDescription">ProductDescription:</label>

                <%=Html.TextArea("ProductDescription", New With {.cols = "60", .rows = "10"})%>
                <%= Html.ValidationMessage("ProductDescription", "*") %>
            </p>
            <p>
                <label for="ParentId">Parent</label>
                <%=Html.DropDownList("ParentId", CType(ViewData("Parents"), SelectList),"[Not Set]")%>
                <%= Html.ValidationMessage("ParentId", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



