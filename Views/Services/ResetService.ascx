<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

<%  Using Html.BeginForm%>
    <fieldset>
        <legend>Reset Service</legend>
            <%=Html.Hidden("rs")%>
        <p>
            This will take a Completed Service and move it back to InProgress
        
        
            <input type="submit" value="Reset" />    
        </p>
    </fieldset>
<%End Using%>