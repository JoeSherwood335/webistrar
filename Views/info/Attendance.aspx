<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Attendance.info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Attendance
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Attendance</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                AttendanceId
            </th>
            <th>
                Date
            </th>
            <th>
                ProgramInstanceId
            </th>
            <th>
                RegistrarNo
            </th>
            <th>
                AttendanceTypeId
            </th>
            <th>
                InputedBy
            </th>
            <th>
                Ed
            </th>
        </tr>

    <% For Each item In Model.Attendances.Where(Function(e) e.AttendanceType.AttendanceType <> "Not Set").OrderByDescending(Function(e) e.Date)%>
    
        <tr>
            <td>
                <%=Html.Encode(item.ProgramInstance.Program.ProgramName)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:D}", item.Date))%>
            </td>
            <td>
                <%=Html.Encode(item.AttendanceType.AttendanceType)%>
            </td>
           </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

