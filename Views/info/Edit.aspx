<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>
<%-- For other devs: Do not remove below line. --%>

<%-- For other devs: Do not remove above line. --%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=""%>
    <h2>Edit</h2>
       <% If Model.FlagForHr.HasValue Then%>
            <% If Model.FlagForHr.Value Then%>
        
                Flagged by HR Department
        
            <% Else%>
        
                <% Using Html.BeginForm(New With {.controller = "info", .action = "FlagConsumer", .Permilink = Model.Permilink})%>
                    <%=Html.Hidden("RegistrarNo", Model.RegistrarNo)%>
                    <label for="FlagForHr">FlagForHr:</label>
                    <%=Html.Hidden("FlagForHr", True)%>
                    <input type="submit" value="Set Flag for Hr" />
                <% End Using %>
            <% End If%>
            
            <% Else%>
                <% Using Html.BeginForm(New With {.controller = "info", .action = "FlagConsumer", .Permilink = Model.Permilink})%>
                    <%=Html.Hidden("RegistrarNo", Model.RegistrarNo)%>
                    <label for="FlagForHr">FlagForHr:</label>
                    <%=Html.Hidden("FlagForHr", True)%>
                    <input type="submit" value="Set Flag for Hr" />
                <% End Using %>
            
            
        <% End If%>

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
                
                <%=Html.DropDownList("ConsumerTypeId", Model.GetConsumerType(Model.ConsumerTypeId), "[not set]")%>
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
                <label for="FirstName">First Name</label>
                <%= Html.TextBox("FirstName") %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            
             <p>
                <label for="PrefixId">Prefix:</label>
                <%=Html.DropDownList("PrefixId", Model.GetPrefixes(Model.PrefixId), "[Not Selected]")%>
                <%= Html.ValidationMessage("ProgramId", "*") %>
            </p>
            <p>
                <label for="SufixId">Sufix:</label>
                
                <%=Html.DropDownList("SufixId", Model.GetSufixes(Model.SufixId), "[Not Selected]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>


    <% End Using %>



</asp:Content>

