<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>


<%  Using Html.BeginForm()%>
    <fieldset>
        <legend>Details</legend>
        <label for="value"><%= ViewData("name") %></label>
        <%=Html.TextBox("value")%>
    </fieldset>
<% End Using%>