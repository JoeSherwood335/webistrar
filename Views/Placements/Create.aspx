<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Placement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="TypeId">Type:</label>
                <%=Html.DropDownList("TypeId", Model.GetPlacementTypes(), "[not set]")%>
                <%= Html.ValidationMessage("TypeId", "*") %>
            </p>
            <p>
                <label for="StaffId">Staff:</label>
                <%=Html.DropDownList("StaffId", Model.GetStaffs(), "[not set]")%>
                <%= Html.ValidationMessage("StaffId", "*") %>
            </p>
            <p>
                <label for="JobTitle">JobTitle:</label>
                <%= Html.TextBox("JobTitle") %>
                <%= Html.ValidationMessage("JobTitle", "*") %>
            </p>
            <p>
                <label for="Wage">Wage:</label>
                <%= Html.TextBox("Wage") %>
                <%= Html.ValidationMessage("Wage", "*") %>
            </p>
            <p>
                <label for="WageTypeId">WageType:</label>
                <%=Html.DropDownList("WageTypeId", Model.GetWageTypes, "[not set]")%>
                <%= Html.ValidationMessage("WageTypeId", "*") %>
            </p>
            <p>
                <label for="JobTypeId">JobType:</label>
                <%=Html.DropDownList("JobTypeId", Model.GetJobTypes, "[not set]")%>
                <%= Html.ValidationMessage("JobTypeId", "*") %>
            </p>
            <p>
                <label for="HoursPerWeek">HoursPerWeek:</label>
                <%= Html.TextBox("HoursPerWeek") %>
                <%= Html.ValidationMessage("HoursPerWeek", "*") %>
            </p>
            <p>
                <label for="HasMedical">HasMedical:</label>
                <%=Html.CheckBox("HasMedical")%>
                <%= Html.ValidationMessage("HasMedical", "*") %>
            </p>
            <p>
                <label for="Is90ofEmploymentPrep">Is less then 90 from Employment Prep:</label>
                <%=Html.DropDownList("Is90ofEmploymentPrep", Model.GetEmployementPrep)%>
                <%= Html.ValidationMessage("Is90ofEmploymentPrep", "*") %>
            </p>
          
            <p>
                <label for="PlacementDate">PlacementDate:</label>
                <%= Html.TextBox("PlacementDate") %>
                <%= Html.ValidationMessage("PlacementDate", "*") %>
            </p>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>




    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript" >
        $(document).ready(function() {
            $("#PlacementDate").datepicker({
                changeMonth: true,
                changeYear: true,
                showOtherMonths: true,
                selectOtherMonths: true
            });

            $("#ClosureDate").datepicker({
                changeMonth: true,
                changeYear: true,
                showOtherMonths: true,
                selectOtherMonths: true
            });

            $("#IsClosure").button();
            $("#IsPlacement").button();
            $("#HasMedical").button();
        });
</script>
</asp:Content>

