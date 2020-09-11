<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.FundingSource)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Invalid
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Html.Encode(ViewData("Source"))%></h2>
    
    <p><%=Html.Encode(ViewData("Message"))%></p>
    
    <p><%=Html.Encode(ViewData("Data"))%></p>

</asp:Content>
