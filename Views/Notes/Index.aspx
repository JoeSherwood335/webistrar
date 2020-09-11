<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.note))" %>
<%@ Import Namespace="R2kdoiMVC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<%  Dim userInfo As R2kdoiMVC.Model.Info = ViewData("Consumer")%>

	Notes for <%=userInfo.GetNameFull%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%  Dim userInfo As R2kdoiMVC.Model.Info = ViewData("Consumer")%>
	
<h2>Notes for <%=userInfo.GetFullName(R2kdoiMVC.Model.Info.NameTypes.FirstLastSuf)%></h2>

<%=Html.ActionLink("Back to Consumer", "Details", New With {.controller = "info", .permilink = userInfo.Permilink})%>

<% Using Html.BeginForm()%>
    <fieldset class="hideprint">
        <legend>Filter</legend>
       <p><label for="ShowOnlyMine">Show Only Mine</label> <%=Html.CheckBox("ShowOnlyMine", (If(Request.Form("ShowOnlyMine"), String.Empty).Contains("true")))%></p>
       
       <p><input type="submit" value="Filter" /></p>
    </fieldset>


<% end using %>

    <% For Each item In Model.OrderBy(Function(e) e.ED)%>
    <%If item.InActive Then%>
                <!--div class="NotShown">
                    Note Removed By Supervisor                    
                </div-->
            <%ElseIf Not item.IsValid Then%>   
                <div class="NotShown">
                    You are not Authorized to see this Note
                </div>             
            <%Else%>
                <div id="note-<%=item.noteid %>" class="Shown">
                <h5><strong><%=item.RegisteredUser.Username%></strong> on <em><%=item.ED.ToShortDateString()%></em></h5> 
                <p>
                    <%=item.Note.Replace(vbCrLf, "</p><p>")%>
                </p>
                <p style="font-size:smaller;">
                <% For Each attachment In item.Attachments%>
                    <%=Html.ActionLink(attachment.FileName, "GetAttachments", New With {.filename = attachment.FileName, .id = item.NoteId}, New With {.class = "showprintinline"})%>,                
                <% next %>
                </p>
                <p style="font-size:smaller ;">
                    <a href="<%=item.link %>" class="showprintinline"><%=item.link %></a>
                    
               </p>
                </div>
            <%end if  %>
    
    <% Next%>

   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

