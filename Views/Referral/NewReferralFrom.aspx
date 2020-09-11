<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.ReferringCounselor))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New Referral From
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>NewReferralFrom</h2>
    <%="" %> 
    <p>
    <% If Not ViewData("acr") Is Nothing Then%>
        <% =Html.ActionLink("New Counsler", "NewCounsler", New With {.Controller = "FundingSource", .Acronym = ViewData("acr")})%>
    <% End If%>
    </p>
    
    
    <%Using Html.BeginForm("NewReferralFrom", "Referral", FormMethod.Get)%>
    
    
        <%=Html.DropDownList("FSId", CType(ViewData("FundingSource"), SelectList))%>
    
    
        <input type="submit" value="search" />
    
    <%End Using%>
    <table>
        <tr>
            <th></th>
            <th>
                RepCode
            </th>
           <th>
                LastName
            </th>
            <th>
                FirstName
            </th>
            <th>
                FundingSource
            </th>
         
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("New", "Create", New With {.RcId = item.ReferringCounselorId})%>
            </td>
              <td>
                <%= Html.Encode(item.RepCode) %>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
            <td>
                <%=Html.Encode(item.FundingSource.Acronym)%>
            </td>
          
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

