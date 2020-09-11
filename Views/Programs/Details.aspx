<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Program)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(Model.ProgramName)%>
</asp:Content>
<asp:Content ContentPlaceHolderID=HeaderContent runat="server" ID="headercontent">
   <script type="text/javascript" language="javascript">
       $(document).ready(function() {

       $("#enableAjax a").click(function() {
               var thref = this.href
               $("#foo").load(thref + " form", function() {
                   $("#foo").dialog();


               }); //end load foo
               return false
           }); //end newc click
       });  //end document ready
    </script>





</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Program</h2>
    <p>
        Name: <%= Html.Encode(Model.ProgramName) %>
    </p>
    <p>
        Description: <%= Html.Encode(Model.ProgramDescription) %>
    </p>
    <div id="enableAjax">
    <p><%=Html.ActionLink("Add Outcome", "addoutcome", New With {.programid = Model.ProgramId})%></p>
    <table>
        <tr>
            <th></th>
            <th>Outcome</th>
        </tr>
        
        
        <%  For Each outcome In Model.SetServiceOutcomesforPrograms%>
            <tr>
                <td><%=Html.ActionLink("Remove", "removeoutcome", New With {.programid = outcome.ProgramId, .outcomeid = outcome.ServiceOutcomeId})%></td>
                <td><%=outcome.ServiceOutcome.ServiceOutcomeName%></td>
            </tr>    
        <% Next%>
    </table>     
    
    <br />
     <%Html.RenderPartial("InstanceList")%>
     
    </div> 
    <p>
        <%=Html.ActionLink("New Instance", "NewInstance", New With {.id = Model.ProgramId})%> |
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ProgramId})%> |
        
    </p>
    <div id="foo" style="display:none;"></div>
</asp:Content>

