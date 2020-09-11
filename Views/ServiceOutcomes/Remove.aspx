<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.SetServiceOutcomeForProduct)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Remove
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirm</h2>

    Product <%Html.Encode(Model.Product.ProductName)%> <br />
    Service Outcome <%html.Encode(Model.ServiceOutcome.ServiceOutcomeName)  %><br />
    
    <%  Using Html.BeginForm()%>
    
    <%=Html.Hidden("ProductId", Model.ProductId)%>
    <%=Html.Hidden("ServiceOutcomeId", Model.ServiceOutcomeId)%>
    <input type="submit" value="Delete" />
    <%End Using%>
</asp:Content>
