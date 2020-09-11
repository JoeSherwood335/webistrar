<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Placement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Placement 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
    
    <script type="text/javascript" >
    $(document).ready(function(){
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
        $("#Retention180Date").datepicker({
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true
        });
        $("#Retention90Date").datepicker({
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true
        });
        
        $("#IsClosure").button();
        $("#IsPlacement").button();
        $("#HasMedical").button();
        $("#WageIncrease90None").button();
        $("#WageIncrease180None").button();
        $("#Retention90").button();
        $("#Retention180").button();
        
        
        
        
        
    });
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <h2>Edit Placement</h2>

 

    <fieldset>
        <legend>Company</legend>
        <p>
            CompanyName: <%=model.Company.CompanyName %>
        </p>
        <p>
            WebSite: <%=model.company.WebSite%>
        </p>
    </fieldset>    

    <fieldset>
        <legend>Consumer</legend>
        <p>
            registrarNo: <%= model.Info.RegistrarNo%>
        </p>
        <p>
            Name: <%=Html.ActionLink(String.Format("{0} {1}", model.info.FirstName, model.info.LastName), "Details", New With {.permilink = Model.info.Permilink, .controller = "Info"})%>
        </p>        
        
    </fieldset>
    
<%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Placement</legend>
            <p>
                <label for="TypeId">Type:</label>
                <%=Html.DropDownList("TypeId", Model.GetJobTypes(Model.TypeId) , "[Not Set]")%>
                <%= Html.ValidationMessage("TypeId", "*") %>
            </p>
            <p>
                <label for="StaffId">Staff:</label>
                <%=Html.DropDownList("StaffId", Model.GetStaffs(Model.StaffId), "[Not Set]")%>
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
                <label for="WageTypeId">Wage Type:</label>
                <%=Html.DropDownList("WageTypeId",Model.GetWageTypes(Model.WageTypeId), "[Not Set]")%>
                <%= Html.ValidationMessage("WageTypeId", "*") %>
            </p>
            <p>
                <label for="JobTypeId">Job Type:</label>
                <%=Html.DropDownList("JobTypeId", Model.GetJobTypes(Model.JobTypeId) , "[Not Set]")%>
                <%= Html.ValidationMessage("JobTypeId", "*") %>
            </p>
            <p>
                <label for="HoursPerWeek">Hours Per Week:</label>
                <%= Html.TextBox("HoursPerWeek") %>
                <%= Html.ValidationMessage("HoursPerWeek", "*") %>
            </p>
            <p>
                <label for="HasMedical">Medical:</label>
                <%=Html.CheckBox("HasMedical")%>
                <%= Html.ValidationMessage("HasMedical", "*") %>
            </p>
            <p>
                <label for="Is90ofEmploymentPrep">Is less then 90 from Employment Prep:</label>
                <%=Html.DropDownList("Is90ofEmploymentPrep", Model.GetEmployementPrep(Model.Is90ofEmploymentPrep))%>
                <%= Html.ValidationMessage("Is90ofEmploymentPrep", "*") %>
            </p>
            <p>
                <label for="IsPlacement">Mark Record as Placement</label>
                <%=Html.CheckBox("IsPlacement")%>
                <%= Html.ValidationMessage("IsPlacement", "*") %>
            </p>
            <p>
                <label for="PlacementDate">PlacementDate:</label>
                <%= Html.TextBox("PlacementDate") %>
                <%= Html.ValidationMessage("PlacementDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
        
        
        
        
<fieldset>
    <legend>Follow Up</legend>
                <p>
                <label for="WageIncrease90None">Has a 90 Day Wage Increase</label>
                <%=Html.CheckBox("WageIncrease90None")%>
                <%=Html.ValidationMessage("WageIncrease90None", "*")%>
            </p>
            <p>
                <label for="WageIncrease90">Wage 90 Day Increase:</label>
                <%=Html.TextBox("WageIncrease90")%>
                <%=Html.ValidationMessage("WageIncrease90", "*")%>
            </p>
            <p>
                <label for="WageIncrease180None">Has a 90 Day Wage Increase</label>
                <%=Html.CheckBox("WageIncrease180None")%>
                <%=Html.ValidationMessage("WageIncrease180None", "*")%>
            </p>
            <p>
                <label for="WageIncrease180">Wage 180 Day Increase:</label>
                <%=Html.TextBox("WageIncrease180")%>
                <%=Html.ValidationMessage("WageIncrease180", "*")%>
            </p>
             <p>
                <label for="Retention90">Has been in the Job for 90 Days</label>
                <%=Html.CheckBox("Retention90")%>
                <%=Html.ValidationMessage("Retention90", "*")%>
            </p>
            <p>
                <label for="WageIncrease90">Date of 90 Days:</label>
                <%=Html.TextBox("Retention90Date")%>
                <%=Html.ValidationMessage("Retention90Date", "*")%>
            </p>
            <p>
                <label for="Retention180">Has been in the Job for 180 Days</label>
                <%=Html.CheckBox("Retention180")%>
                <%=Html.ValidationMessage("Retention180", "*")%>
            </p>
            <p>
                <label for="WageIncrease180">Date of 180 Days:</label>
                <%=Html.TextBox("Retention180Date")%>
                <%=Html.ValidationMessage("Retention180Date", "*")%>
            </p>
</fieldset>
            <p>
                <input type="submit" value="Save" />
            </p>-

    <% End Using %>
    
    
    </asp:Content>



