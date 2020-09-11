<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(of R2kdoiMVC.Model.Accruel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Accrue Billing
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Accrue Billing</h2>

    <% Using Html.BeginForm()%>

    <%=Html.ValidationSummary("Please Click Back and correct all errors")%>
    
    
    <% If Not Model.Hide Then%>
        <p>Please Click Create to Start the Billing Process...</p>
       
        <input type="submit" value="Create" />
    <% End If%>
    
    <% End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
