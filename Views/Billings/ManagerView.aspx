<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/billing.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>
<%@ Import Namespace="R2kdoiMVC"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Manager View
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manager View</h2>

    

    
        <%Using Html.BeginForm("ManagerView", "Billings", FormMethod.Get)%>
    
        <div id="Searchform">
        <%=Html.TextBox("Search", "", New With {.class = "searchBox"})%>
        <% If Not String.IsNullOrEmpty(HttpContext.Current.Request.QueryString("cm")) Then%>
        <%=Html.Hidden("cm", HttpContext.Current.Request.QueryString("cm"))%>
        <% End If%>
        <input type="submit" value="search" />
        <br />
        <br />
        
        </div>    
    
    
    <table>
                <tr>
            <th></th>
             <th>Status</th>
             <th><%=Html.acronymColumnName("Date of Last Status Changed", "statusDate", New With {.controller = "Billings", .view = "ManagerView", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "sDates", .Page = ViewData.Model.PageNumber})%></th>
             
            <th>Staff Name </th>
            <th>Invoice #</th>
            <th><%=Html.acronymColumnName("Consumer Name", "Consumer", New With {.controller = "Billings", .view = "ManagerView", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "Name", .Page = ViewData.Model.PageNumber})%></th>
            <th>Program</th>
            <th>Cost Center</th>
            <th>Funding Source</th>
            <th>AuthorizationNo</th>
            <th>AmmountBilled</th>
            <th>Start</th>
            <th>End</th>
            <th>ProgramSupervisor</th>
            <th><%=Html.acronymColumnName("Date Issued", "DI", New With {.controller = "Billings", .view = "ManagerView", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "iDates", .Page = ViewData.Model.PageNumber})%></th>
         
        
        </tr>
        <%Html.RenderPartial("BillingList")%>
	    </table>
	
	<div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Billings", .action = "ManagerView", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = HttpContext.Current.Request.QueryString("Sort")})%>
	</div>
	<%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<style type="text/css" >
    table {font-size:smaller;}

</style>
</asp:Content>
