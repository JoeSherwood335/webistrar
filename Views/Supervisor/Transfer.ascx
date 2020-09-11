<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.TranspherClass)" %>


    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
                <%=Html.Hidden("RegistrarNo")%>
                <%=Html.Hidden("CurrentCounsler")%>
               <%=Html.Hidden("ProgramSupervisor")%>
            <p>
                <label for="NewCounsler">NewCounsler:</label>
                <%=Html.DropDownList("NewCounsler", Model.GetNewCounslers, "[not set]")%>
               </p>
                
           <input type="submit" value="Transfer" />
           </fieldset>

    <% End Using %>



