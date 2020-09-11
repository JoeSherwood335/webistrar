<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Start
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Start</h2>


    <% Using Html.BeginForm%>
    <fieldset>
        <legend>Infomation</legend>
        <p>
           Submit this bill to your Supervisor 
        </p>    
            <input type="submit" value="Start" />
    </fieldset>
    <%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

