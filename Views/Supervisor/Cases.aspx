<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.CasesView))" %>
<%@ import Namespace="R2kdoiMVC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Programs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Programs</h2>
    
    
    
    <%=Myapp.User(True)%>
    
    
    <table>
        <tr>

            <th>
                
            </th>
            <th>
                Program Name
            </th>
            <th>Consumer Name</th>
            <th>Program Status</th>
            <th>Service Status</th>
            <th>Billing Status</th>
        </tr>

    <% For Each item In Model.OrderBy(Function(e) e.LastName)%>
    
        <tr>
        
            <td><%=Html.ActionLink("Program", "Outcome", New With {.controller = "referral", .id = item.ReferralId})%> 
            <%=Html.ActionLink("Transfer", "Transfer", New With {.RegistrarNo = item.RegistrarNo, .CurrentCounsler = Myapp.User(True), .cm = Myapp.User(True)}, New With {.class = "ajak"})%>
            </td>
        
            <td>
                <%=Html.Encode(item.ProgramName)%>
            </td>
            <td>
                <%=Html.ConsumerLink(item.RegistrarNo)%>     
            </td> 
            
            
            
            <td>
                
            </td>
        </tr>
    
    <% Next%>

    </table>
 <div id="foo" style="display :none;"></div> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
  <script type="text/javascript" >
         $(document).ready(function() {
             //$.ajaxSetup({ cache: false });

             $.ajaxSetup({
                 // Disable caching of AJAX responses */ 
                 cache: false
             }); // end ajaxSetup



//             $("#formmenu > ul > li > ul > li > a, a.SelectService").click(function(data) {
             $(".ajak").click(function(data) {

                 //alert(this.href);
                 var thref = this.href;

                 $('#foo').empty();

                 $.ajax({
                     type: 'GET',
                     url: thref,
                     data: '',
                     cashe: false,
                     success: function(data, textStatus, jqXHR) {
                            //alert(data);

                         $('<div />').append(data.replace(/<script(.|\s)*?\/script>/g, "")).find('form').appendTo("#foo");


                         $("#foo").dialog({
                             open: function(event, ui) {

                                

                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog
                     }, // end success
                     error: function(data, textStatus, jqXHR) {

                         $('<div />').append(data.responseText.replace(/<script(.|\s)*?\/script>/g, "")).find("form").appendTo("#foo");

                         $("#foo").dialog({
                             open: function(event, ui) {

                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog

                     } // end error
                 }); // end $.ajax


                 return false
             }); // end newc click
         });                  // end document load 
      </script>

</asp:Content>

