<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Service))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Audit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Audit</h2>
<table>
    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.Encode(item.Authorization.Referral.ProgramInstance.Supervisor.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.RegisteredUser.Username)%>
            </td>
            <td>
                <%=Html.Encode(item.Authorization.Referral.Info.GetFullName(R2kdoiMVC.Model.Info.NameTypes.FirstLast))%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

