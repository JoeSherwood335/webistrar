<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

<%  Using Html.BeginForm%>

<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <fieldset>
        <legend>Start Service</legend>
        <p>
            Enter Date to Start Services
        </p>
        <%=Html.Hidden("rs")%>
        <p>
            <label for="StartDate">Start Date</label>
            <%=Html.TextBox("ServiceStartDate", Nothing, New With {.class = "date"})%>
            <%=Html.ValidationMessage("StartDate", "*")%>
            <input type="submit" value="save" />    
        </p>
    </fieldset>
<%End Using%>
