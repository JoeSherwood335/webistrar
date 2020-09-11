<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	StartService
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>StartService</h2>
<%  Using Html.BeginForm%>

<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <fieldset>
        <legend>Start Service</legend>
        <%=Html.Hidden("rs")%>
        <p>
            <label for="StartDate">Start Date</label>
            <%=Html.TextBox("ServiceStartDate", Nothing, New With {.class = "date"})%>
            <%=Html.ValidationMessage("StartDate", "*")%>
            <input type="submit" value="save" />    
        </p>
    </fieldset>
<%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
