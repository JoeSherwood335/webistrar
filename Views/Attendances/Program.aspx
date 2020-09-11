<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.AttendanceLineClass))" %>
<%@ Import Namespace="R2kdoimvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<%  If Model.Count <> 0 Then%>
    <% Dim DateOfAttendance = CType(ViewData("DateOfAttendance"), DateTime)%>
    Attendance for <%=Html.Encode(Model.First.Instance.Program.ProgramName)%> <%=Html.Encode(Model.First.Instance.CostCenter)%> <%=Html.Encode(Model.First.Instance.Location.LocationName)%>  on <%=Html.Encode(DateOfAttendance.ToLongDateString)%>
<% End If%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">

   <script type="text/javascript" language="javascript">

       function selectAllText(textbox) {
           textbox.focus();
           textbox.select();
       }
       
       
       $(document).ready(function() {
            
           $("td > a").click(function() {
               var thref = this.href
               $("#foo").load(thref + " form", function() {
                   $("#foo").dialog({
                       open: function(event, ui) {
                       // $("#foo input:visible:first").focus(function() { alert("yo"); });
                       $("#foo input:visible:first").select();

              
                       }, // end foo dialog open
                       width: "auto"
                   }); // end foo dialog


               }); //end load foo
               return false
           }); //end newc click
       });    //end document ready
    </script>
    
    
    <style type="text/css">
        table 
        {
            /*width:170px*/
        }
        td, th
        {
            width:80px;	
        }

    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%  If Model.Count <> 0 Then%>

    <% Dim DateOfAttendance = CType(ViewData("DateOfAttendance"), DateTime)%>
   
    <h3><%=Html.Encode(Model.first.Instance.program.ProgramName)%> <%=Html.Encode(Model.first.Instance.CostCenter)%> <%=Html.Encode(Model.First.Instance.Location.LocationName)%></h3>
    <p><%=Html.Encode(DateOfAttendance.ToLongDateString)%></p>

    <table>
        <tr>
            <th>
                Name
            </th>
            <th>IsAbsent</th>
            <th>
                Start
            </th>
            <th>
                Lunch Out
            </th>
            <th>
                Lunch In
            </th>
            <th>
                End
            </th>
            <th>Duration</th>
        </tr>
    <% For Each item In Model.OrderBy(Function(e) e.name)%>
        <tr>

            <td>
                <span><%=Html.ConsumerLink(item.rn)%></span>
            </td>
            <td>
             <% If item.start.HasValue Then%>
                <% elseIf item.IsAbsent Then%>
                    <%=Html.ActionLink(item.AbsentType, "AbsentEdit", New With {.rn = item.rn, .atype = 1, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% Else%>
                    <%=Html.ActionLink("Mark Absent", "Absent", New With {.rn = item.rn, .atype = 1, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% End If%>
            
            </td>
            <td>
                <% If item.start.HasValue Then%>
                    <%=Html.ActionLink(item.start.Value.ToShortTimeString, "Edit", New With {.rn = item.rn, .atype = 1, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% ElseIf item.IsAbsent Then%>
                
                <% Else%>
                    <%=Html.ActionLink("Take", "create", New With {.rn = item.rn, .atype = 1, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% End If%>
            </td>
            <td>
                <% If item.LunchOut.HasValue Then%>
                    
                    <%=Html.ActionLink(item.LunchOut.Value.ToShortTimeString, "Edit", New With {.rn = item.rn, .atype = 2, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                
                <% ElseIf Not item.start.HasValue Then%>
                
                <% ElseIf item.IsAbsent Then%>
                
                <% ElseIf item.start.HasValue and item.EndOfDay.HasValue Then%>
                
                <% Else%>
                    <%=Html.ActionLink("Take", "create", New With {.rn = item.rn, .atype = 2, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% End If%>
            </td>
            <td>
                <% If item.LunchIn.HasValue Then%>
                    <%=Html.ActionLink(item.LunchIn.Value.ToShortTimeString, "Edit", New With {.rn = item.rn, .atype = 3, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% ElseIf item.IsAbsent Then%>    
                <% ElseIf Not item.start.HasValue Then%>
                <% ElseIf Not item.LunchOut.HasValue Then%>
                
                <% Else%>
                    <%=Html.ActionLink("Take", "create", New With {.rn = item.rn, .atype = 3, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% End If%>
            </td>
            <td>
                <% If item.EndOfDay.HasValue Then%>
                    <%=Html.ActionLink(item.EndOfDay.Value.ToShortTimeString, "Edit", New With {.rn = item.rn, .atype = 4, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% ElseIf Not item.start.HasValue Then%>
                <% ElseIf item.IsAbsent Then%>
                <% ElseIf Not item.start.HasValue And Not item.LunchOut.HasValue Then%>
                <% ElseIf item.start.HasValue And item.LunchOut.HasValue And Not item.LunchIn.HasValue Then%>
                <% Else%>
                    <%=Html.ActionLink("Take", "create", New With {.rn = item.rn, .atype = 4, .id = Url.RequestContext.RouteData.Values("id"), .month = Url.RequestContext.RouteData.Values("month"), .day = Url.RequestContext.RouteData.Values("day"), .year = Url.RequestContext.RouteData.Values("year")})%>
                <% End If%>
            </td>
            <% Dim s As Integer%>
            <% Dim ts As TimeSpan%>
            
            <td>
                <% If item.start.HasValue And Not item.LunchOut.HasValue And Not item.LunchIn.HasValue And item.EndOfDay.HasValue Then%>
                    <% s = DateDiff(DateInterval.Minute, item.start.Value, item.EndOfDay.Value)%>
                    <% ts = item.EndOfDay.Value.Subtract(item.start.Value)%>
                <% ElseIf item.start.HasValue And item.LunchOut.HasValue And item.LunchIn.HasValue And item.EndOfDay.HasValue Then%>
                    <% s = DateDiff(DateInterval.Minute, item.start.Value, item.LunchOut.Value) + DateDiff(DateInterval.Minute, item.LunchIn.Value, item.EndOfDay.Value)%>
                    <% ts = item.LunchOut.Value.Subtract(item.start.Value).Add(item.EndOfDay.Value.Subtract(item.LunchIn.Value))%>
                <% ElseIf item.start.HasValue And item.LunchOut.HasValue And Not item.LunchIn.HasValue And Not item.EndOfDay.HasValue Then%>
                    <% s = DateDiff(DateInterval.Minute, item.start.Value, item.LunchOut.Value)%>
                    <% ts = item.LunchOut.Value.Subtract(item.start.Value)%>
                <% ElseIf item.IsAbsent Then%>
                    <% ts = TimeSpan.Zero%>
                <% Else%> 
                    <% ts = TimeSpan.Zero%>
                <% End If%>
                
                <%= ts.Hours%> h <%=ts.Minutes%> m
            </td>
        </tr>
    
    <% Next%>
    </table>
    <div id="foo" style="display:none;"></div>
    <%Else%>
    
    <p>
    
        There are no consumers for this program.
    
    </p>
    <%End If%>


</asp:Content>


