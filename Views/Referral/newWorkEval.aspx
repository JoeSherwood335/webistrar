<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.WeOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	newWorkEval
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <h2>New Workeval Service Outcome</h2>
    
        <%Html.RenderPartial("weOutcome") %>
        
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

