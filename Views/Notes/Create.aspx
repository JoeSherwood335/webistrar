 <%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Note)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 Note
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
            <p>
                <%=Html.TextArea("Note", New With {.style = "width:100%;", .rows = 20})%>
                <%= Html.ValidationMessage("Note", "*") %>
            </p>
                <%=Html.Hidden("Link")%>
            <p>
                <input type="submit" value="Save" />
            </p>
                <%=Html.Hidden("rs")%>
            <p>
                <%=Html.Hidden("subject")%>
            </p>
    <% End Using %>
 <form id="ajaxUploadForm" action="<%= Url.Action("AjaxUpload", "Notes")%>" method="post" enctype="multipart/form-data">   
     <fieldset>   
         <legend>Attachments</legend> 
         <div>
         <%=ViewData("filelist")%>  
         </div>
         <label>File to Upload: <input type="file" name="file" />(100MB max size)</label>   
         <input id="ajaxUploadButton" type="submit" value="Attach" />   
     </fieldset>   
 </form>
 
 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript">
     $(function() {
        var options = {
         iframe: true,
         dataType: "json",
         beforeSubmit: function() {
             $("#ajaxUploadForm").block({ message: '<h1><img src="<%=HttpContext.Current.Request.ApplicationPath%>Content/busy.gif" /> Uploading file...</h1>' });
         },
         success: function(result) {
             $("#ajaxUploadForm").unblock();
             $("#ajaxUploadForm").resetForm();
             // $.growlUI(null, result.message);
             $("#filelist").append(result.filename);
             
             var value = $("#Note").text();
             
             if (value == "") 
             {
                $("#Note").text('Attachment');
             }
             
             //var newvalue = value + "\n ---------------------- \n" + result.fname + " \n";
             
             //$("#Note").text(newvalue)
             
             
             //alert(result.message);
         },
         error: function(xhr, textStatus, errorThrown) {
             $("#ajaxUploadForm").unblock();
             $("#ajaxUploadForm").resetForm();
             alert(errorThrown);
             //$.growlUI(null, 'Error uploading file');
         } // end error
     } // end options

        $("#ajaxUploadForm").ajaxForm(options);
     });
</script>  
    <style type="text/css" >
	.ui-button { margin-left: -1px; }
	.ui-button-icon-only .ui-button-text { padding: 0.35em; } 
	.ui-autocomplete-input { margin: 0; padding: 0.48em 0 0.47em 0.45em; }
	</style>
	<script type="text/javascript" >
	
	$(document).ready(function(){
        var inFormOrLink;
        //$('a').live('click', function() { inFormOrLink = true; });
        $('form').bind('submit', function() { 
            inFormOrLink = true; 
         //   alert('submit');
        });

        $(window).bind('beforeunload', function(eventObject) {
            var returnValue = undefined;
                if (! inFormOrLink) {
                        $.getJSON('/Notes/BrowserClose' , function(data) {
                    }); // end getjson
            } // end if 
            return returnValue;
        }); // end beforeunload
    }); // end document ready 

	
	(function( $ ) {
		$.widget( "ui.combobox", {
			_create: function() {
				var self = this,
					select = this.element.hide(),
					selected = select.children( ":selected" ),
					value = selected.val() ? selected.text() : "";
				var input = $( "<input>" )
					.insertAfter( select )
					.val( value )
					.autocomplete({
						delay: 0,
						minLength: 0,
						source: function( request, response ) {
							var matcher = new RegExp( $.ui.autocomplete.escapeRegex(request.term), "i" );
							response( select.children( "option" ).map(function() {
								var text = $( this ).text();
								if ( this.value && ( !request.term || matcher.test(text) ) )
									return {
										label: text.replace(
											new RegExp(
												"(?![^&;]+;)(?!<[^<>]*)(" +
												$.ui.autocomplete.escapeRegex(request.term) +
												")(?![^<>]*>)(?![^&;]+;)", "gi"
											), "<strong>$1</strong>" ),
										value: text,
										option: this
									};
							}) );
						},
						select: function( event, ui ) {
							ui.item.option.selected = true;
							self._trigger( "selected", event, {
								item: ui.item.option
							});
						},
						change: function( event, ui ) {
							if ( !ui.item ) {
								var matcher = new RegExp( "^" + $.ui.autocomplete.escapeRegex( $(this).val() ) + "$", "i" ),
									valid = false;
								select.children( "option" ).each(function() {
									if ( this.value.match( matcher ) ) {
										this.selected = valid = true;
										return false;
									}
								});
								if ( !valid ) {
									// remove invalid value, as it didn't match anything
									//$( this ).val( "" );
									//select.val( "" );
									//return false;
									return true;
								}
							}
						}
					})
					.addClass( "ui-widget ui-widget-content ui-corner-left" );

				input.data( "autocomplete" )._renderItem = function( ul, item ) {
					return $( "<li></li>" )
						.data( "item.autocomplete", item )
						.append( "<a>" + item.label + "</a>" )
						.appendTo( ul );
				};

				$("<button type=\"button\">&nbsp;</button>")
					.attr( "tabIndex", -1 )
					.attr("title", "Show All Items")
					.insertAfter( input )
					.button({
						icons: {
							primary: "ui-icon-triangle-1-s"
						},
						text: false
					})
					.removeClass( "ui-corner-all" )
					.addClass( "ui-corner-right ui-button-icon" )
					.click(function() {
						// close if already visible
						if ( input.autocomplete( "widget" ).is( ":visible" ) ) {
							input.autocomplete( "close" );
							return;
						}

						// pass empty string as value to search for, displaying all results
						input.autocomplete( "search", "" );
						input.focus();
					});
			}
		});
	})( jQuery );

	$(function() {
	    $("#Subject").combobox();
	}); // end ready

	</script>

	<script type="text/javascript" src="http://<%=HttpContext.Current.Request.Url.Host%>:<%=HttpContext.Current.Request.Url.Port%><%=HttpContext.Current.Request.ApplicationPath%>Scripts/jquery.form.js"></script>
	<script type="text/javascript" src="http://<%=HttpContext.Current.Request.Url.Host%>:<%=HttpContext.Current.Request.Url.Port%><%=HttpContext.Current.Request.ApplicationPath%>Scripts/jquery.blockUI.js"></script>

</asp:Content>

