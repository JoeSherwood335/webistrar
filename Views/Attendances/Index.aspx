<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Attendance.ProgramInstance))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Attendance
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript" >
    $(function() {
        $("#DateOfAttendance").change(function() {
            $("form").submit();
        });
    });
</script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=""%>
   <%Using Html.BeginForm("Index", "Attendances", FormMethod.Get)%>
       <p><%=Html.DropDownList("DateOfAttendance", CType(ViewData("ListOfDates"), SelectList))%></p>
       <input type=submit value="go" />
    <%End Using%>
    
    <% Dim DateOfAttendance As DateTime = ViewData("DateOfAttendance")%>
    <table>
        <tr>
            <th></th>
            <th>
                Program
            </th>
            <th>
                CostCenter
            </th>
            <th>
                Location
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Take", "Program", New With {.id = item.id , .year = DateOfAttendance.Year, .month = DateOfAttendance.Month, .day = DateOfAttendance.Day}) %>
            </td>
            <td>
                <%=Html.Encode(item.Program.ProgramName)%>
            </td>
            <td>
                <%= Html.Encode(item.CostCenter) %>
            </td>
            <td>
                <%=Html.Encode(item.Location.LocationName)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>


