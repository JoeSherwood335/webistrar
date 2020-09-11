<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancel Service
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cancel Service</h2>
    <%  Using Html.BeginForm()%>
    
       <%=Html.ValidationSummary("Please correct the errors and try again.")%>
        
        <p>
           Date of Cancelation
         </p>  
         <p>  
        <%= Html.TextBox("ServiceStartDate") %>
        </p>
        
        <p>
            Reason for Canceling Services
        </p>
        
        <p>
            <%=Html.DropDownList("ServiceOutcomeId", Model.GetCancelList(Model.ServiceOutcomeId), "[not set]")%>
        </p>
        <p>
             Make Billing: <input name="makebilling" type="checkbox" checked=checked value="true" />
        </p>    
        <input type="submit"  value="Save"/>
        
    
    <%  End Using%>
</asp:Content>


