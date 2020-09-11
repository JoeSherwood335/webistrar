<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcPaging"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Webistrar
</asp:Content>
<asp:Content ID="headercontent" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">
	     .ui-autocomplete-loading { background: white url('images/ui-anim_basic_16x16.gif') right center no-repeat; }
	     .searchBox
	     {
	    	width:300px;
	    	padding:0.4em 1em; 
	     }
	    
	     .ui-autocomplete
	     {
	        width:200px;
	     
	     }
	     .ui-autocomplete li
	     {
	        list-style:none; 	
	    
	     }
       	 .ui-autocomplete-category {
	     	font-weight: bold;
		    padding: .2em .4em;
		    margin: .8em 0 .2em;
		    line-height: 1.5;
	     }
         form
         {
            margin:10px 0px;
            	
         }
    </style>
    <script type="text/javascript">
        $(function() {
            $("#Search").focus();

            function log(message) {
                $("<div/>").text(message).prependTo("#log");
                $("#log").attr("scrollTop", 0);
            }

            $.widget("custom.catcomplete", $.ui.autocomplete, {
                _renderMenu: function(ul, items) {
                    var self = this,
				currentCategory = "";
                    $.each(items, function(index, item) {
                        if (item.category != currentCategory) {
                            ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
                            currentCategory = item.category;
                        }
                        self._renderItem(ul, item);
                    });
                }
            });

            $("#Search").catcomplete({
                source: function(request, response) {
                    $.getJSON("/Info/getSearchName"
                            , {search: request.term}
                            , response);
                    },
                minLength: 2
            });
        });

//,
//                select: function(event, ui) {
//                        alert(ui.category);
//                 }
        //request.term 
		

	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <%Using Html.BeginForm("Index", "Info", FormMethod.Get)%>
    
        <div id="Searchform">
        <%=Html.TextBox("Search", "", New With {.class = "searchBox"})%><input type="submit" value="search" />
        </div>    
    
    <%End Using%>
    <table>
        <tr>
            <th></th>
            <th>
                Registrar No
            </th>
            <th>
                REF
            </th>
            <th>
                LastName
            </th>

            <th>
                FirstName
            </th>
            <th>
                DOB
            </th>

            
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.permilink = item.Permilink})%> |
                <%=Html.ActionLink("Details", "Details", New With {.permilink = item.Permilink})%>
            </td>
            <td>
                <%= Html.Encode(item.RegistrarNo) %>
            </td>
            <td>
                <%= Html.Encode(item.REF) %>
            </td>
      
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
            <td>
                <% For Each a In item.miscs%>
                
                <%=Html.Encode(String.Format("{0:d}", a.dob))%>
                <%Next%>
            </td>
            
        </tr>
    
    <% Next%>




    </table>
	<div class="pager">
		<%=Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, New With {.controller = "info", .action = "index", .Search = ViewData("Search")})%>
	</div>
</asp:Content>

