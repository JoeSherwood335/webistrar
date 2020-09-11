<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Note)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Inactive
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inactive</h2>

    <%=Html.ValidationSummary()%>
    
    <fieldset>
        <legend><%= Html.Encode(Model.Subject)%></legend>
        <p>
            Note:
            <%=Model.Note%>
        </p>
     </fieldset>
    
        <% Using Html.BeginForm()%>
            <input type="submit" value="Mark InActive" />
        <% End Using%>

    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

