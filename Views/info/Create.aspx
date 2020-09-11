<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add New Consumers</h2>

       <% Using Html.BeginForm()%>

         <fieldset>
            <legend>Fields</legend>
           <p>
                <label for="RegistrarNo">RegistrarNo:</label>
                <%= Html.TextBox("RegistrarNo") %>
                <%= Html.ValidationMessage("RegistrarNo", "*") %>
            </p>
            <p>
                <label for="SSN">SSN:</label>
                <%= Html.TextBox("SSN") %>
                <%= Html.ValidationMessage("SSN", "*") %>
            </p>
            <p>
                <label for="REF">Referal Source Id Number</label>
                <%= Html.TextBox("REF") %>
                <%= Html.ValidationMessage("REF", "*") %>
            </p>
            <p>
                <label for="ConsumerTypeId">Consumer Type</label>
                
                <%=Html.DropDownList("ConsumerTypeId", Model.GetConsumerType(), "[not set]")%>
                <%=Html.ValidationMessage("ConsumerTypeId", "*")%>
            </p>
            <p>
                <label for="LastName">Last Name</label>
                <%= Html.TextBox("LastName") %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="MiddleName">Middle Name</label>
                <%= Html.TextBox("MiddleName") %>
                <%= Html.ValidationMessage("MiddleName", "*") %>
            </p>
            <p>
                <label for="FirstName">First Name</label>
                <%= Html.TextBox("FirstName") %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
             <p>
                <label for="PrefixId">PrefixId:</label>
                <%=Html.DropDownList("PrefixId", Model.GetPrefixes(), "[not set]")%>
                <%= Html.ValidationMessage("ProgramId", "*") %>
            </p>
            <p>
                <label for="SufixId">Sufix:</label>
                
                <%=Html.DropDownList("SufixId", Model.GetSufixes(), "[not set]")%>
                <%=Html.ValidationMessage("SufixId", "*")%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>


    <% End Using %>



</asp:Content>

