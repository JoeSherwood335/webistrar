<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Companies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Companies</h2>

    <p>
        <%=Html.ActionLink("Add New Company", "CreateCompany", new with{.ReferralId = ViewData("ReferralId")})%>
    </p>
    
    
    <%Using Html.BeginForm("Company", "Placements", FormMethod.Get)%>
    
    
        <%=Html.TextBox("Search", "", New With {.style = "Width:300px"})%>
        
        <%if not viewdata("ReferralId") is nothing then  %>
            <%=Html.Hidden("ReferralId")%>
        <% End If%>
        
        <input type="submit" value="search" />
    
    <%End Using%>
    
    <table>
        <tr>
            <th></th>
            <th>
                CompanyShort
            </th>
            <th>
                CompanyName
            </th>
            <th>
                Email
            </th>
            <th>
                WebSite
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Select", "Create", New With {.id = item.id, .Permilink = ViewData("Permilink"), .ReferralId = ViewData("ReferralId")})%>
            </td>
            <td>
                <%= Html.Encode(item.CompanyShort) %>
            </td>
            <td>
                <%= Html.Encode(item.CompanyName) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
            <td>
                <%= Html.Encode(item.WebSite) %>
            </td>
        </tr>
    
    <% Next%>

    </table>
    
    <div class="pager">
        <%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "Placements", .action = "Company", .Permilink = ViewData("Permilink"), .Search = ViewData("Search"), .ReferralId = ViewData("ReferralId")})%>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

