<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Attendance.Attendance)" %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Absent</legend>
            <%=Html.Hidden(Model.AttendanceId)%>
            <p>
                <%=Html.DropDownList("AbsentType", R2kdoiMVC.Model.Attendance.Attendance.GetAbsentType(Model.AttendanceTypeId))%>
             </p>
            <input type="submit" value="Save" />
            </fieldset> 
    <% End Using %>

    <%  Using Html.BeginForm("delete", "Attendances", New With {.id = Model.AttendanceId, .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
    
    
        <input type="submit" value="delete" />
    
    
    <%  End Using%>