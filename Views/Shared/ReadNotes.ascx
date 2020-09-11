<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>


<%=""%>
    <% 
        Dim db As New R2kdoiMVC.R2kdoiMVCDataContext
        
        Dim notes = From a In db.Notes _
                    Where a.Link = Request.Path _
                    Order By a.UD Descending _
                    Select a
    %>    
<%  Dim override As Boolean = False%>
    <% If Not Model Is Nothing Then%>
        <%    Select Case Model.GetType.ToString %>
        <%       Case Is = "R2kdoiMVC.Model.Authorization"%>
                        <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .Permilink = Model.Referral.Info.Permilink})%>     
        <%       Case Is = "R2kdoiMVC.Model.Service"%>
                        <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .Permilink = Model.Authorization.Referral.Info.Permilink})%>        
        <%       Case Is = "R2kdoiMVC.Model.Info" %>
                        <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .Permilink = Model.Permilink})%>
        <%       Case Is = "R2kdoiMVC.Model.Referral"%>
                        <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .Permilink = Model.info.Permilink})%>                                 
        <%       Case Is = "R2kdoiMVC.Model.Billing.Billing"%>
                       <% If HttpContext.Current.Request.Url.AbsolutePath.Contains("Void") Or Model.getstatus() = R2kdoiMVC.Myapp.ACCRUED Then%> 
                            <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .Permilink = Model.Info.Permilink, .title = "Billing"})%>    
                            <%'i know it's a hack  %>
                        <% End If%>
                   
                    <%  override = True%>
        <%       Case Else%>
        
        <%    End Select%>
    <% Else%>
        <%=Html.ActionLink("Add Note", "Create", New With {.controller = "Notes", .permilink = ViewData("Permilink")})%>

    <% End If%>

    <ol>
    <% For Each item In notes.OrderByDescending(Function(e) e.ED)%>
        <li>
            <!--p><strong><%=Html.Encode(item.Subject)%></strong><br /><em><%=item.UD.ToShortDateString%></em> by <%=item.RegisteredUser.Username%></p-->
   
            <%If item.InActive Then%>
                <!--div class="NotShown">
                    Note Removed By Supervisor                    
                </div-->
            <%ElseIf Not item.IsValid(override) Then%>   
                    You are not Authorized to see this Note
            <%Else%>
                <p>
                    <%=item.Note.Replace(vbCrLf, "<br />")%>
                </p>
            <%end if  %>
            
            
            <p>
                <% For Each attachment In item.Attachments%>
                    <%=Html.ActionLink(attachment.FileName, "GetAttachments", New With {.controller = "Notes", .filename = attachment.FileName, .id = item.NoteId}, New With {.class = "showprintinline"})%>,                
                <% next %>
            </p>
        </li>
    <% Next%>
    </ol>
    
    
 
    


