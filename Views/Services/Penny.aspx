<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Accruel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Penny
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Penny</h2>

    <% Using Html.BeginForm()%>

    <%=Html.ValidationSummary("")%>
    
    <% If Not Model.Hide Then%>
               
        <p>Number Of Units: <%=Html.TextBox("NumberOfUnits", Model.NumberOfUnits)%></p>
        <p>Service End Date: <%=Html.TextBox("ServiceEndDate", Model.ServiceEndDate.ToShortDateString)%></p>
        <p>
           Service Outcome: 
             <%=Html.DropDownList("ServiceOutcomeId", Model.service.GetCancelList(Model.service.ServiceOutcomeId), "[not set]")%>
        </p>
       <%=Html.Hidden("NumberOfUnitsBilled", Model.NumberOfUnitsBilled)%>
       
        <input type="submit" value="Create" />
    <% End If%>
    
    <% End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
