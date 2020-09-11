<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.fee)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>
    
    <%Using Html.BeginForm()%>
        <p>Please review before Deleteing</p>
        <p>
            <%=Model.Main.FeeSchedualName%>
        </p>

        <p>
            <%=Model.Product.GetServiceName%>
        </p>
        <%=Html.Hidden("FeeId", Model.FeeId)%>
        <input type="submit" value="Confirm" />
    <% End Using%>
    
    
</asp:Content>
