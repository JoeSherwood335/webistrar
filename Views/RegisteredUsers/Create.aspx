<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.RegisteredUser)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>

            <p>
                <label for="Username">User Name</label>
                <%= Html.TextBox("Username") %>
                <%= Html.ValidationMessage("Username", "*") %>
            </p>
            <p>
                <label for="Supervisor">Supervisor</label>
                <%=Html.DropDownList("Supervisor", Model.GetSupervisors(), "[Not Set]")%>
                <%= Html.ValidationMessage("Supervisor", "*") %>
                
            </p>
            <p>
                <label for="profile">Profile</label>
                <%=Html.DropDownList("ProfileId", Model.GetProfiles(), "[Not Set]")%>
                <%= Html.ValidationMessage("Supervisor", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>

</asp:Content>

