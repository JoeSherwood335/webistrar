<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Contact))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contacts for <%=Html.Encode(Model.First.Info.FirstName)%> <%=Html.Encode(Model.First.Info.LastName)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Contacts for <%=Html.Encode(Model.First.Info.FirstName)%> <%=Html.Encode(Model.First.Info.LastName)%></h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
 
            <th>
                Type
            </th>
            <th>
                Other
            </th>
            <th>
                Info
            </th>
            <th>
                Info Type
            </th>

        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ContactID})%> |
            </td>
            <td>
                <%=Html.Encode(item.ContactType.ContactType)%>
            </td>
            <td>
                <%= Html.Encode(item.Other) %>
            </td>
            <td>
                <%= Html.Encode(item.ContactInfo) %>
            </td>
            <td>
                <%=Html.Encode(item.ContactInfoType.ContactInfoType)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

