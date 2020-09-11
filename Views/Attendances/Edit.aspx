<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Attendance.Attendance)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">

    <style type="text/css">
    

        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>




    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Clock</legend>
            <p>
                <%=Html.TextBox("hour", ViewData("hour"), New With {.style = "width:30px;"})%>
                <%=Html.TextBox("min", ViewData("min"), New With {.style = "width:30px;"})%>
                
                <%=Html.DropDownList("half", R2kdoiMVC.Myapp.GetAMPM)%>

             </p>
            <input type=submit value="Save" />
            </fieldset> 
    <% End Using %>
    
    <%  Using Html.BeginForm("delete", "Attendances", New With {.id = Model.AttendanceId, .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
    
    
        <input type="submit" value="delete" />
    
    
    <%  End Using%>
</asp:Content>



