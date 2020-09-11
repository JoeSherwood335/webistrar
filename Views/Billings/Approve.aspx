<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Approve
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Approve</h2>

    <% Using Html.BeginForm%>
    <fieldset>
        <legend>Infomation</legend>
        <p>
            Send Bill to Finance  
        </p>
        <input type="submit" value="Approve" />
    </fieldset>
    <%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
