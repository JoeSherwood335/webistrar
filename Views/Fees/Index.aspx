<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Fee))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create", New With {.f = HttpContext.Current.Request.QueryString("FeeSchedual"), .l = HttpContext.Current.Request.QueryString("Location")})%>
    </p>
    <% Using Html.BeginForm("Index", "Fees", Nothing, FormMethod.Get)%>
    
    
    
    <table>
        <tr>
            <th>FundingSources</th>
            <th>Locations</th>
        </tr>
        <tr>
            <td>
            <%=Html.DropDownList("FeeSchedual", CType(ViewData("FeeScheduals"), SelectList))%>
            </td>
            <td>
            <%=Html.DropDownList("Location", CType(ViewData("Locations"), SelectList))%>
            </td>
        </tr>
     </table>
    
    
    
    <input type="submit" value="Filter" />
    
    
    <% End Using%>
    <table>
        <tr>
            <th></th>
            <th>
                Location
            </th>
            <th>
                Name
            </th>
            <th>
            </th>
            <th>
                Unit Price
            </th>
            <th>
                Unit Type
            </th>
           
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.FeeId})%>&nbsp;
                <%=Html.ActionLink("Details", "Details", New With {.id = item.FeeId})%>
            </td>
            <td>
                <%=Html.Encode(item.Location.LocationName)%>
            </td>
            <td colspan="2">
                <%=Html.Encode(item.GetServiceName())%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.UnitPrice)) %>
            </td>
            <td>
                <%=Html.Encode(item.UnitType.UnitType)%>
            </td>
            <td>
                <% If item.MinUnits.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:F}", item.MinUnits.Value))%>
                <% Else%>
                    Auto Calculate not set
                <% End If%>
            </td>
            <td>
                <% If item.MinUnits.HasValue Then%>
                    <% Dim db As New R2kdoiMVC.R2kdoiMVCDataContext%>
                    <% Dim x = From a In db.UnitTypes Where a.UnitTypeId = item.MinUnitTypeId Select a.UnitType%>
                    <%=Html.Encode(x.First)%>
                <% End If%>
            </td>
  
        </tr>
    
    <% Next%>

    </table>
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
</asp:Content>

