<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    If Request.IsAuthenticated Then
%>
<%
    If R2kdoiMVC.Myapp.HasAlert Then
%>
    <script type="text/javascript" >
        $(document).ready(function(){
            // $( "input:submit").button();
                $("#foo").load("http://<%=Request.ServerVariables("SERVER_NAME")%>:<%=Request.ServerVariables("SERVER_PORT")%>/alert?returnpath=<%=Request.Url.AbsolutePath %>", function() {
                    $("#foo").dialog({
                        open: function(event, ui) {
                    } // end foo dialog open
                }).dialog( "option", "width", 750 ).dialog({ position: { my: "center", at: "center", of: window } }); // end foo dialog
                                 
                
                
            }); // end foo load 
            return false
        });// end document ready
    
    
    </script>


<div id="foo" style="display:none;"></div>


    <%        
    End If
%>
  
    <%        
    End If
%>
