<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>

<%  Using Html.BeginForm%>
    <fieldset>
        <legend>Instance</legend>
        <p>
           Make Instance Inactive
        </p>
        <%=Html.Hidden("rs")%>
        <p>
            <input type="submit" value="save" />    
        </p>
    </fieldset>
<%End Using%>