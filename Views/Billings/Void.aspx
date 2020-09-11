<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Void
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Void</h2>
<% Using Html.BeginForm%>
    <fieldset>
        <legend>Infomation</legend>
        <p>
            Click Void to cancel this bill
            
        </p>
        <p>
            Please Note why your are voiding this bill
         </p>
         <%Html.RenderPartial("ReadNotes")%>
        <input type="submit" value="Void" />
    </fieldset>
    <%End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
