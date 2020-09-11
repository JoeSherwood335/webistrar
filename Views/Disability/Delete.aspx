<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Disability)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete Disability
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Delete Disability</legend>
        
        <p>
            <%=Html.Encode(Model.Info.FirstName)%> <%=Html.Encode(Model.Info.LastName)%>
        </p>
        <p>
           <%=Html.Encode(Model.DisabilityType.Code)%> <%=Html.Encode(Model.DisabilityType.Description)%>
        </p>
        <p>
            Type:
            <%=Html.Encode(Model.DisabilityOrderType.DisabilityOrderType)%>
        </p>
        <p>
            SD:
            <%= Html.Encode(Model.SD) %>
        </p>
        
        <% Using Html.BeginForm()%>
            <input type="submit" value="Delete" />
        <% end using %>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

