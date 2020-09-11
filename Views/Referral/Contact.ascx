<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

    <p>
        <%=Html.ActionLink("Create New", "Create", New With {.Controller = "Contact", .Permilink = Model.Info.Permilink})%>
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

    <% For Each item In Model.Info.Contacts%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ContactID, .controller = "Contact"})%>
            </td>
            <td>
                <%=Html.Encode(item.ContactType.ContactType)%>
            </td>
            <td>
                <% If String.IsNullOrEmpty(item.Other) Then%>
                    {self}
                <% Else%>
                    <%= Html.Encode(item.Other) %>
                <% End If%>
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


