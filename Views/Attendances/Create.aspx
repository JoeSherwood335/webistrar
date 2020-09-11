<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Attendance.Attendance)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Clock</legend>
            <p>
                <input type=text name="hour" style="width:30px;" /> <input type=text name="min" style="width:30px;" /> 
                <select name="half">
                    <option value="AM" selected="true">AM</option>
                    <option value="PM">PM</option>
                </select>
             </p>
            <input type=submit value="Save" />
            </fieldset> 
    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

