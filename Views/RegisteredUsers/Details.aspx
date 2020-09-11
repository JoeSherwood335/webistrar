<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.RegisteredUser)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            UserId:
            <%= Html.Encode(Model.UserId) %>
        </p>
        <p>
            Username:
            <%= Html.Encode(Model.Username) %>
        </p>
        <p>
            Supervisor:
                <%If Model.Supervisor.HasValue Then%>            
                    <%=Html.ActionLink(Model.RegisteredUser.Username, "Details", New With {.id = Model.Supervisor})%> 
                    
                <%Else%>
                <%End If%>
        </p>

    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.UserId})%> |
        
    </p>

</asp:Content>

