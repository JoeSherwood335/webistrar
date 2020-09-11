<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Authorizations.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Authorization)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    New Authorizations
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" >

    $(document).ready(function() {

    $("#AuthorizationDate").datepicker();
    });



</script>
    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            
                
            <%=Html.Hidden("ReferralId")%>
            <%=Html.Hidden("FundingCounslerId")%>       
            
            
            <p>
                <label for="AuthorizationNumber">Authorization Number</label>
                <%= Html.TextBox("AuthorizationNumber") %>
                <%= Html.ValidationMessage("AuthorizationNumber", "*") %>
            </p>
            <p>
                <label for="AuthorizationDate">Authorization Date</label>
                <%= Html.TextBox("AuthorizationDate") %>
                <%= Html.ValidationMessage("AuthorizationDate", "*") %>
            </p>

            <p>
                <label for="TotalAmountAuthorized">Total Amount Authorized</label>
                <%= Html.TextBox("TotalAmountAuthorized") %>
                <%= Html.ValidationMessage("TotalAmountAuthorized", "*") %>
            </p>
            <p>
                <label for="TotalUnitsAuthorized">Total Units Authorized</label>
                <%= Html.TextBox("TotalUnitsAuthorized") %>
                <%= Html.ValidationMessage("TotalUnitsAuthorized", "*") %>
            </p>
            <p>
                <label for="UnitTypeId">UnitType</label>
                <%=Html.DropDownList("UnitTypeId", CType(ViewData("Unittypes"), SelectList))%>
                <%= Html.ValidationMessage("UnitTypeId", "*") %>
            </p>
          
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>


</asp:Content>

