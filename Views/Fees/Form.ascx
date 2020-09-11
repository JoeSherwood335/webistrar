<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.fee)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
           
          
            <p>
                <label for="FundingSourceId">Fee Schedual</label>
                <%=Html.DropDownList("MainId", CType(ViewData("FeeScheduals"), SelectList))%>
                <%=Html.ValidationMessage("MainId", "*")%>
            </p>
            <p>
                <label for="LocationId">Location</label>
                <%=Html.DropDownList("LocationId", CType(ViewData("Locations"), SelectList))%>
                <%= Html.ValidationMessage("LocationId", "*") %>
            </p>
            <p>
                <label for="ProductId">Product</label>
                
               <%=Html.DropDownList("ProductId", CType(ViewData("Products"), SelectList))%><br />
               
               <% =Html.ActionLink("Edit", "Edit", New With {.controller = "Products", .id = Model.ProductId})%>
                <%= Html.ActionLink("New", "Create", New With {.controller = "Products"})%>
               
               <%= Html.ValidationMessage("ProductId", "*") %>
            </p>
            <p>
                <label for="UnitPrice">UnitPrice</label>
                <%=Html.TextBox("UnitPrice")%>
               
                <%= Html.ValidationMessage("UnitPrice", "*") %>
            </p>
            <p>
                <label for="UnitTypeId">Unit Type</label>
                 <%=Html.DropDownList("UnitTypeId", CType(ViewData("UnitTypes"), SelectList))%>
                <%=Html.ValidationMessage("UnitTypeId", "*")%>
            </p>

            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>


