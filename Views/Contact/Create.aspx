<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Contact)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
    <%=Html.Hidden("rs")%>
        <fieldset>
            <legend>Fields</legend>

            <p>
                <label for="ContactTypeId">Contact Type:</label>
                <%=Html.DropDownList("ContactTypeId", Model.GetContactType(), "[not set]")%>
                <%= Html.ValidationMessage("ContactTypeId", "*") %>
            </p>
            <p>
                <label for="Other">Name:</label>
                <%= Html.TextBox("Other") %>
                <%= Html.ValidationMessage("Other", "*") %>
            </p>
            <p>
                <label for="ContactInfo">Info:</label>
                <%= Html.TextBox("ContactInfo") %>
                <%= Html.ValidationMessage("ContactInfo", "*") %>
            </p>
            <p>
                <label for="ContactInfoTypeId">Type:</label>
                <%=Html.DropDownList("ContactInfoTypeId", Model.GetContactInfoType, "[not set]")%>
                <%= Html.ValidationMessage("ContactInfoTypeId", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

