<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Note)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Note for <%= Model.Info.FirstName %> <%=Model.Info.LastName%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Note for <%= Model.Info.FirstName %> <%=Model.Info.LastName%></h2>

    <fieldset>
        <legend><%= Html.Encode(Model.Subject) %></legend>
        <p>
            Note:
            <%=Model.Note.Replace(vbCrLf, "<br />")%>
        </p>
        <p>
           <span style="font-size:x-small; color:#333;"><a href="<%= Html.Encode(Model.Link) %>"><%= Html.Encode(Model.Link) %></a></span>
        </p>
        <p>
           <span style="font-size:xx-small; color:#333;"><%=Html.Encode(String.Format("{0:D}", Model.ED))%></span> 
        </p>
    </fieldset>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

