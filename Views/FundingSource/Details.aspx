<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.FundingSource)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Acronym
            <%= Html.Encode(Model.Acronym) %>
        </p>
        <p>
            FullName
            <%= Html.Encode(Model.FullName) %>
        </p>
    </fieldset>
    
    
     <%  Html.RenderPartial("AssignFeebook")%>
    
     <%  Html.RenderPartial("ReferringCounslers")%>
     
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.FundingSourceId})%> |

    </p>

</asp:Content>

