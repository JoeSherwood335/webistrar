<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 Accept Billing
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Accept</h2>
    <%Using Html.BeginForm()%>
        <fieldset>
            <legend>Infomation</legend>
            <p>
        
                Accept Billing
    
    
            </p>
            
            <%Html.RenderPartial("ReadNotes")%>
        </fieldset> 
        <input type="submit" value="Accept" />
    <%end using  %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>