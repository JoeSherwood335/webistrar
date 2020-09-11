<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of System.Web.Mvc.HandleErrorInfo)" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">


<form>
    <h2>
        Sorry, an error occurred while processing your request.
    </h2>
    
    
    <p>
       Controller: <%=Html.Encode(Model.ControllerName)%>
    </p>
    <p>
        Action: <%=Html.Encode(Model.ActionName)%>
    </p>
    <p>
        Message: <q><%=Html.Encode(Model.Exception.Message)%></q>
   </p>
   <p>
        <%=Html.Encode(Model.Exception.GetType)%>
   </p>
 </form>
</asp:Content>
