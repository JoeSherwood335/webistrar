<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(Model.GetFullName(R2kdoiMVC.Model.Info.NameTypes.PreFirstMiddleLastSuf)) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <%= Html.Encode(Model.GetFullName(R2kdoiMVC.Model.Info.NameTypes.FirstLastSuf)) %>
    </h2>

    <p>
        <%=Html.ActionLink("Edit", "Edit", New With {.permilink = Model.Permilink})%>
        |
        <%=Html.ActionLink("Programs", "Index", New With {.permilink = Model.Permilink, .controller = "Referral"})%>
        |
        <%=Html.ActionLink("Income", "Index", New With {.permilink = Model.Permilink, .controller = "Income"})%>
        |
        <%=Html.ActionLink("Placement", "Index", New With {.Permilink = Model.Permilink, .controller = "Placements"})%>
        |
        <%=Html.ActionLink("Notes", "Index", New With {.permilink = Model.Permilink, .controller = "Notes"})%>
        |
        <%=Html.ActionLink("New Note", "Create", New With {.permilink = Model.Permilink, .controller = "Notes"})%>
    </p>
       <table>
            <tr>
                <th>RegistrarNo</th>
                <th>SocialSecurity#</th>
                <th>ReferralId#</th>
                <th>RecordType</th> 
            </tr>
            <tr>
                <td><%= Html.Encode(Model.RegistrarNo) %></td>
                <td><%If not string.IsNullOrEmpty(Model.SSN) then  %>
                        ***-**-<%=Html.Encode(Right(Model.SSN, 4))%>
                    <% End If %></td>
                <td><%= Html.Encode(Model.REF) %></td>
                <td><%=Html.Encode(Model.ConsumerType.ConsumerType)%></td>
            </tr>
        </table>
          <fieldset>
            <legend>Address</legend>   
     <% For Each address In Model.Addresses.OrderByDescending(Function(e) e.ed).Take(1)%>   
   
                <p>
                    StreetAddress1:
                    <%=Html.Encode(address.StreetAddress1)%>
                </p>
                <p>
                    StreetAddress2:
                    <%=Html.Encode(address.StreetAddress2)%>
                </p>
                <p>
                    City:
                    <%=Html.Encode(address.City)%>
                </p>
                <p>
                    County:
                    <%=Html.Encode(address.County)%>
                </p>
                <p>
                    State:
                    <%=Html.Encode(address.State)%>
                </p>
                <p>
                    Zip:
                    <%=Html.Encode(address.Zip)%>
                </p>
               
       <p> <%=Html.ActionLink("Edit", "Edit", New With {.controller = "Address", .Permilink = Model.Permilink, .id = address.AddressID})%> | 
    <% Next%> 
        <%=Html.ActionLink("Change", "Create", New With {.controller = "Address", .Permilink = Model.Permilink})%></p>
     <p></p>
    </fieldset>
    <fieldset>
        <legend>Disability</legend>
    
      <table>
        <tr>
            <th></th>
            <th>
                Code
            </th>
            <th>
                Description
            </th>
            <th>
                Type
            </th>
            <th>
                IsSD
            </th>
        </tr>

    <% For Each item In Model.Disabilities%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.DisabilityID, .controller = "Disability"})%> 
            </td>
            <td>
                <%=Html.Encode(item.DisabilityType.Code)%>
            </td>
            <td>
                <%=Html.Encode(item.DisabilityType.Description)%>
            </td>
            <td>
                <%=Html.Encode(item.DisabilityOrderType.DisabilityOrderType)%>
            </td>
            <td>
                <%= Html.Encode(item.SD) %>
            </td>
        </tr>
    
    <% Next%>

    </table>
    
    <p><%=Html.ActionLink("New", "Create", New With {.controller = "Disability", .Permilink = Model.Permilink})%></p>
    </fieldset>    
        
        
    <fieldset>
        <legend>Consumer Descriptor</legend>
         
        <%  Html.RenderPartial("MiscForm")%>
    </fieldset>


    <fieldset>
        <legend>Contact</legend>
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
        
        
          <% For Each item In Model.Contacts%>
    
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
    <p><%=Html.ActionLink("New", "Create", New With {.controller = "Contact", .Permilink = Model.Permilink})%></p>
    </fieldset>    

</asp:Content>

