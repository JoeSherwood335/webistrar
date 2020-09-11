<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Created
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Created</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ServiceId">ServiceId:</label>
                <%= Html.TextBox("ServiceId") %>
                <%= Html.ValidationMessage("ServiceId", "*") %>
            </p>
            <p>
                <label for="AuthorizationId">AuthorizationId:</label>
                <%= Html.TextBox("AuthorizationId") %>
                <%= Html.ValidationMessage("AuthorizationId", "*") %>
            </p>
            <p>
                <label for="ServiceName">ServiceName:</label>
                <%= Html.TextBox("ServiceName") %>
                <%= Html.ValidationMessage("ServiceName", "*") %>
            </p>
            <p>
                <label for="NumberOfUnitesAuthorized">NumberOfUnitesAuthorized:</label>
                <%= Html.TextBox("NumberOfUnitesAuthorized") %>
                <%= Html.ValidationMessage("NumberOfUnitesAuthorized", "*") %>
            </p>
            <p>
                <label for="AmountAuthorized">AmountAuthorized:</label>
                <%= Html.TextBox("AmountAuthorized") %>
                <%= Html.ValidationMessage("AmountAuthorized", "*") %>
            </p>
            <p>
                <label for="ProductId">ProductId:</label>
                <%= Html.TextBox("ProductId") %>
                <%= Html.ValidationMessage("ProductId", "*") %>
            </p>
            <p>
                <label for="NumberOfUnits">NumberOfUnits:</label>
                <%= Html.TextBox("NumberOfUnits") %>
                <%= Html.ValidationMessage("NumberOfUnits", "*") %>
            </p>
            <p>
                <label for="UnitTypeId">UnitTypeId:</label>
                <%= Html.TextBox("UnitTypeId") %>
                <%= Html.ValidationMessage("UnitTypeId", "*") %>
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%= Html.TextBox("AssignedTo") %>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            <p>
                <label for="CostCenter">CostCenter:</label>
                <%= Html.TextBox("CostCenter") %>
                <%= Html.ValidationMessage("CostCenter", "*") %>
            </p>
            <p>
                <label for="ServiceStartDate">ServiceStartDate:</label>
                <%= Html.TextBox("ServiceStartDate") %>
                <%= Html.ValidationMessage("ServiceStartDate", "*") %>
            </p>
            <p>
                <label for="ServiceEndDate">ServiceEndDate:</label>
                <%= Html.TextBox("ServiceEndDate") %>
                <%= Html.ValidationMessage("ServiceEndDate", "*") %>
            </p>
            <p>
                <label for="SchedualStartDate">SchedualStartDate:</label>
                <%= Html.TextBox("SchedualStartDate") %>
                <%= Html.ValidationMessage("SchedualStartDate", "*") %>
            </p>
            <p>
                <label for="SchedualEndDate">SchedualEndDate:</label>
                <%= Html.TextBox("SchedualEndDate") %>
                <%= Html.ValidationMessage("SchedualEndDate", "*") %>
            </p>
            <p>
                <label for="ServiceOutcomeId">ServiceOutcomeId:</label>
                <%= Html.TextBox("ServiceOutcomeId") %>
                <%= Html.ValidationMessage("ServiceOutcomeId", "*") %>
            </p>
            <p>
                <label for="InputedBy">InputedBy:</label>
                <%= Html.TextBox("InputedBy") %>
                <%= Html.ValidationMessage("InputedBy", "*") %>
            </p>
            <p>
                <label for="ed">ed:</label>
                <%= Html.TextBox("ed") %>
                <%= Html.ValidationMessage("ed", "*") %>
            </p>
            <p>
                <label for="ud">ud:</label>
                <%= Html.TextBox("ud") %>
                <%= Html.ValidationMessage("ud", "*") %>
            </p>
            <p>
                <label for="HasMileage">HasMileage:</label>
                <%= Html.TextBox("HasMileage") %>
                <%= Html.ValidationMessage("HasMileage", "*") %>
            </p>
            <p>
                <label for="MileageUnitesAuthorized">MileageUnitesAuthorized:</label>
                <%= Html.TextBox("MileageUnitesAuthorized") %>
                <%= Html.ValidationMessage("MileageUnitesAuthorized", "*") %>
            </p>
            <p>
                <label for="IsMileageDateDiffServiceDate">IsMileageDateDiffServiceDate:</label>
                <%= Html.TextBox("IsMileageDateDiffServiceDate") %>
                <%= Html.ValidationMessage("IsMileageDateDiffServiceDate", "*") %>
            </p>
            <p>
                <label for="MileageSchedualStartDate">MileageSchedualStartDate:</label>
                <%= Html.TextBox("MileageSchedualStartDate") %>
                <%= Html.ValidationMessage("MileageSchedualStartDate", "*") %>
            </p>
            <p>
                <label for="MileageSchedualEndDate">MileageSchedualEndDate:</label>
                <%= Html.TextBox("MileageSchedualEndDate") %>
                <%= Html.ValidationMessage("MileageSchedualEndDate", "*") %>
            </p>
            <p>
                <label for="HasReportWriting">HasReportWriting:</label>
                <%= Html.TextBox("HasReportWriting") %>
                <%= Html.ValidationMessage("HasReportWriting", "*") %>
            </p>
            <p>
                <label for="ReportWritingAuthorized">ReportWritingAuthorized:</label>
                <%= Html.TextBox("ReportWritingAuthorized") %>
                <%= Html.ValidationMessage("ReportWritingAuthorized", "*") %>
            </p>
            <p>
                <label for="ReportWritingDiffServiceDate">ReportWritingDiffServiceDate:</label>
                <%= Html.TextBox("ReportWritingDiffServiceDate") %>
                <%= Html.ValidationMessage("ReportWritingDiffServiceDate", "*") %>
            </p>
            <p>
                <label for="ReportWritingSchedualStartDate">ReportWritingSchedualStartDate:</label>
                <%= Html.TextBox("ReportWritingSchedualStartDate") %>
                <%= Html.ValidationMessage("ReportWritingSchedualStartDate", "*") %>
            </p>
            <p>
                <label for="ReportWritingSchedualEndDate">ReportWritingSchedualEndDate:</label>
                <%= Html.TextBox("ReportWritingSchedualEndDate") %>
                <%= Html.ValidationMessage("ReportWritingSchedualEndDate", "*") %>
            </p>
            <p>
                <label for="HasWageAddon">HasWageAddon:</label>
                <%= Html.TextBox("HasWageAddon") %>
                <%= Html.ValidationMessage("HasWageAddon", "*") %>
            </p>
            <p>
                <label for="WageAddonUnitsAuthorized">WageAddonUnitsAuthorized:</label>
                <%= Html.TextBox("WageAddonUnitsAuthorized") %>
                <%= Html.ValidationMessage("WageAddonUnitsAuthorized", "*") %>
            </p>
            <p>
                <label for="isWageAddonUnitDiffServcieDate">isWageAddonUnitDiffServcieDate:</label>
                <%= Html.TextBox("isWageAddonUnitDiffServcieDate") %>
                <%= Html.ValidationMessage("isWageAddonUnitDiffServcieDate", "*") %>
            </p>
            <p>
                <label for="WageSchedualStartDate">WageSchedualStartDate:</label>
                <%= Html.TextBox("WageSchedualStartDate") %>
                <%= Html.ValidationMessage("WageSchedualStartDate", "*") %>
            </p>
            <p>
                <label for="WageSchedualEndDate">WageSchedualEndDate:</label>
                <%= Html.TextBox("WageSchedualEndDate") %>
                <%= Html.ValidationMessage("WageSchedualEndDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

