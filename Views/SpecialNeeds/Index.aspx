<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.rSpecialNeeds))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Special Needs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Special Needs List</h2>

    <p>
        <div class="AjaxForm"><%=Html.ActionLink("Add Special Need", "Create")%></div>
    </p>
    

    <p>
        <%=ViewData("rs")%>
    </p>

    <% Using Html.BeginForm() %>
    
    
    
    <table>
        <tr>
            <th>Names</th>
        </tr>

    <% For Each item In Model%>
    
        <tr>

            <td>
                <label for="<%=item.SpecialNeed %>"><%=item.SpecialNeed%></label>  <input name="groups" type="checkbox"  id="<%=item.SpecialNeed %>" value="<%=item.SpecialNeed %>" <%=If(item.NumberOfSN > 0, "Checked=""checked""", "")%>/> 
            </td>
        </tr>
    <% Next%>
    </table>
         <input type="submit" value="Save and Return" />
    <% End Using %>
<div id="foo"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">

<style type="text/css">
     /*.SelectService { display:inline ;}*/
     .ui-datepicker {z-index:10100;} 
     </style>
     <script type="text/javascript" >
         $(document).ready(function() {
             //$.ajaxSetup({ cache: false });

             $.ajaxSetup({
                 // Disable caching of AJAX responses */ 
                 cache: false
             }); // end ajaxSetup



//             $("#formmenu > ul > li > ul > li > a, a.SelectService").click(function(data) {
             $(".AjaxForm a").click(function(data) {

                 alert(this.href);
                 var thref = this.href;

                 $('#foo').empty();

                 $.ajax({
                     type: 'GET',
                     url: thref,
                     data: '',
                     cashe: false,
                     success: function(data, textStatus, jqXHR) {


                         $('<div />').append(data.replace(/<script(.|\s)*?\/script>/g, "")).find('form').appendTo("#foo");


                         $("#foo").dialog({
                             open: function(event, ui) {

                                
                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog
                     }, // end success
                     error: function(data, textStatus, jqXHR) {

                         $('<div />').append(data.responseText.replace(/<script(.|\s)*?\/script>/g, "")).appendTo("#foo");

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



