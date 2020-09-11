<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.note)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Notes for <%=html.Encode(Model.FirstName) %> <%=Html.Encode(Model.LastName)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	
	<div id="noteCollection">
	<h2>Notes for <%=html.Encode(Model.FirstName) %> <%=Html.Encode(Model.LastName)%></h2>


<% Using Html.BeginForm()%>
    <fieldset>
        <legend>Filter</legend>
        <%=Html.CheckBox("Show Only Mine")%>
        <input type="submit" value="Filter" />
    </fieldset>


<% end using %>


    <% For Each item In Model.Notes.Where(Function(e) Not String.IsNullOrEmpty(e.Note)).OrderByDescending(Function(e) e.ED)%>
        
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
                    <%=Html.ActionLink(attachment.FileName, "GetAttachments", New With {.filename = attachment.FileName, .id = item.NoteId})%>,                
                <% next %>
                </p>
                <p style="font-size:smaller ;">
                    <a href="<%=item.link %>"><%=item.link %></a>
                    
                </p>
                </div>
            <%end if  %>
            
            
    <% Next%>
    
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<style type="text/css">
.NotShown
{
   border:solid 1px grey;
   	text-align: center;
   	padding:50px;
   	margin: 5px 0px
}
#NotesList, #NotesList li
{
list-style:none ;
margin:0px;
padding:0px;

}
.Shown
    {
	border:solid 1px grey;
   	
   	padding:10px 50px;
   	margin: 5px 0px
	
	}
</style>
</asp:Content>

