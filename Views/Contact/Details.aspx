<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Contact)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Html.Encode(Model.Info.FirstName)%> <%=Html.Encode(Model.Info.LastName)%></h2>

    <fieldset>
        <legend>Infomation</legend>
        <p>
            ContactTypeId:
            <%=Html.Encode(Model.ContactType.ContactType)%>
        </p>

        <p>
            ContactInfo:
            <%= Html.Encode(Model.ContactInfo) %>
        </p>
        <p>
            ContactInfoTypeId:
            <%=Html.Encode(Model.ContactInfoType.ContactInfoType)%>
        </p>
        <p>
            Other:
            <%= Html.Encode(Model.Other) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ContactID})%> |
   
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

