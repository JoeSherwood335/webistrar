<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.CreateAndEnrollNewConsumers)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create And Enroll New Consumer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create And Enroll New Consumer</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
    
    
       <fieldset>
            <legend>Consumer Data</legend>

            <p>
                <label for="SSN">SSN:</label>
                <%=Html.TextBox("SSN")%>
                <%=Html.ValidationMessage("SSN", "*")%>
            </p>  
              
<%=ViewData("message")%>
           

        </fieldset>

            <p>
                <input type="submit" value="Create" />
            </p>



 <% End Using %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

