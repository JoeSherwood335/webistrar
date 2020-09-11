<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Attendance.Attendance)" %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Absent</legend>
            <p>
                <%=Html.DropDownList("AbsentType", R2kdoiMVC.Model.Attendance.Attendance.GetAbsentType())%>
             </p>
            <input type=submit value="Save" />
            </fieldset> 
    <% End Using %>


