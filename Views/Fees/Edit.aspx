<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Fee)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

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
               
               <% =Html.ActionLink("Edit", "Details", New With {.controller = "Products", .id = Model.ProductId})%>
             
               <%=Html.ValidationMessage("ProductId", "*")%>
            </p>
            <p>
                <label for="UnitPrice">UnitPrice:</label>
                <%=Html.TextBox("UnitPrice")%>
               
                <%= Html.ValidationMessage("UnitPrice", "*") %>
            </p>
            <p>
                <label for="UnitTypeId">UnitType:</label>
                 <%=Html.DropDownList("UnitTypeId", CType(ViewData("UnitTypes"), SelectList))%>
                <%=Html.ValidationMessage("UnitTypeId", "*")%>
            </p>
        </fieldset>
        <fieldset>
            <legend>Minimum</legend>
            <p>
                <label for="MinUnits">Unit(s):</label>
                <%= Html.TextBox("MinUnits") %>
                <%= Html.ValidationMessage("MinUnits", "*") %>
            </p>
            <p>
                <label for="MinUnitTypeId">UnitType:</label>
                
                <%=Html.DropDownList("MinUnitTypeId", CType(ViewData("MinUnitTypes"), SelectList), "[not set]")%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>    

    <% End Using %>


</asp:Content>

