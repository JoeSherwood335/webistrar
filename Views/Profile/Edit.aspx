<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.profile)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Profile</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Profile</legend>
             <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

        
        <fieldset>
            <legend>Groups</legend> 
            <%For Each s In Model.GetAllGroups%>
              <label for="<%=s %>"><%=s %></label>  <input name="groups" type="checkbox"  id="<%=s %>" value="<%=s %>" <%=If(Model.ProfileGroupContainers.Where(Function(a) a.Group.Groupname = s).Count > 0, "Checked=""checked""", "")%>/> 
              
            <% Next%>
        </fieldset> 
        
        
    <% End Using %>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        $("input:checkbox").button();
    });

</script>
</asp:Content>

