  <%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

<%  Using Html.BeginForm%>
<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
     <%=Html.Hidden("rs")%>
     <fieldset>
        <legend>End Date</legend> 
        <p>
           <label for="EndDate">End Date</label>
            <%=Html.TextBox("ServiceEndDate", Nothing, New With {.class = "date"})%><br />
            <label for="Auto">Auto</label>
            <input type=checkbox name="auto" value=<%=viewstate("auto") %> /><br />
        <input type="submit" value="Submit" />
        </p>
    </fieldset>    

    
<% End Using%>
