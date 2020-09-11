<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Info)" %>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>
             <%=Html.Hidden("RegistrarNo", Model.RegistrarNo)%>
           
                <label for="FlagForHr">FlagForHr:</label>
                <%=Html.Hidden("FlagForHr", True)%>
                <input type="submit" value="Set Flag for Hr" />

    <% End Using %>




