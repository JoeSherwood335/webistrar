<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    
    
    <table>
        <tr>
            <th></th>

            <th>
                Income Source
            </th>
            <th>
                Amount
            </th>
            <th>
                Type
            </th>
        </tr>

    <% For Each item In Model.Incomes%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.IncomeSourceID})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.IncomeSourceID})%>
            </td>
            <td>
                <%=Html.Encode(item.IncomeSource.IncomeSource)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:c}", item.IncomeSourceAmount))%>
            </td>
            <td>
                <%=Html.Encode(item.IncomeSourceAmountType.IncomeSourceType)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

