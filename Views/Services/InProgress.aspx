<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Services.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>
<%@ Import Namespace="R2kdoiMVC"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	InProgress
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Dim __o As String%> 
    <h2>InProgress</h2>
    
    
        <%Using Html.BeginForm("InProgress", "Services", FormMethod.Get)%>
    
        <div id="Searchform">
        <%=Html.TextBox("Search", "", New With {.class = "searchBox"})%>
        <% If Not String.IsNullOrEmpty(HttpContext.Current.Request.QueryString("cm")) Then%>
        <%=Html.Hidden("cm", HttpContext.Current.Request.QueryString("cm"))%>
        <% End If%>
        <input type="submit" value="search" />
        <br />
        <br />
        
        </div>    
    
    <%End Using%>
  
 
  
    <table>
        <tr>
            <th><acronym title="Program Status">PS</acronym></th>
            <th><acronym title="Status of last 110">110 Status</acronym></th>
            <th><acronym title="Number of 110 Forms">110s</acronym></th>
            <th></th>
            <th>
                Product
            </th>
            <th>
                <%=Html.acronymColumnName("Consumer", "Consumer", New With {.controller = "Services", .view = "InProgress", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "Name", .Page = ViewData.Model.PageNumber})%>
            </th>
            <th>
                
                <acronym title="Service Start Date">SSD</acronym> 
            </th>
            <th>
                <!--acronym title="Service End Date">SSD</acronym--> 
                <%=Html.acronymColumnName("Service End Date", "SED", New With {.controller = "Services", .view = "InProgress", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "sDates", .Page = ViewData.Model.PageNumber})%>
     
            </th>
            <th>
                <acronym title="Authorization Start Date">ASD</acronym> 
            </th>
            <th>
               <%=Html.acronymColumnName("Authorization End Date", "AED", New With {.controller = "Services", .view = "InProgress", .Search = HttpContext.Current.Request.QueryString("Search"), .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = "aDates", .Page = ViewData.Model.PageNumber})%>
     
                <!--acronym title="Authorization End Date">AED</acronym--> 
            </th>
        </tr>
    
    <%  Html.RenderPartial("ServiceList")%>

</table>
	<div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Services", .action = "InProgress", .cm = HttpContext.Current.Request.QueryString("cm"), .Sort = HttpContext.Current.Request.QueryString("Sort"), .Dir = HttpContext.Current.Request.QueryString("Dir"), .Search = HttpContext.Current.Request.QueryString("Search")})%>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<style type="text/css" >
    table {font-size:smaller;}

</style>
</asp:Content>
