<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.rIncomeSources))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Income
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Income</h2>
    <p></p>
    <table>
        <tr>
            
            <th>
                Income Source
            </th>
            <th>
                Amount
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink(item.IncomeSource, "Edit", New With {.id = item.IncomeSourceId})%>
            </td>
            <td>
                <% If item.IncomeSource = "None" And item.Amount.HasValue Then%>
                    Has No Income <%=Html.ActionLink("x", "Remove", New With {.id = item.IncomeSourceId})%>
                <% ElseIf item.IncomeSource = "None" And Not item.Amount.HasValue Then%>
                <% ElseIf item.IncomeSource = "Refused to be given" And item.Amount.HasValue Then%>
                    Refused to be given <%=Html.ActionLink("x", "Remove", New With {.id = item.IncomeSourceId})%>
                <% ElseIf item.IncomeSource = "Refused to be given" And Not item.Amount.HasValue Then%>
                        
                <% Else%>
                    <%=Html.Encode(String.Format("{0:C}", If(item.Amount, 0)))%>
                <% End If%>

            </td>
        </tr>
    
    <% Next%>

    </table>
    
    
<p><%=Html.ActionLink("Back to Consumers", "Details", New With {.controller = "Info", .permilink = Model.First.Registrarno})%></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

