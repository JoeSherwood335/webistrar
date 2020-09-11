<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Backup Status in Billing to Previous Level
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Backup</h2>
<% Using Html.BeginForm%>
    <fieldset>
        <legend>Infomation</legend>
        <p>
            Backup Status in Billing to Previous Level
            
        </p>
       <%Html.RenderPartial("ReadNotes")%>
        <input type="submit" value="Backup" />
    </fieldset>
    <%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
