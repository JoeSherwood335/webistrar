<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>
       
    <%=""%>   
    
    <% If Model.Info.Miscs.Count > 0 Then%>   
       
    <% For Each item In Model.Info.Miscs%>
            <p>
                
            </p>
            <p>
                 Date Of Birth: <%=Html.Encode(String.Format("{0:d}", item.DOB))%>
            </p>
            <p>
                Gender:         
                <% If item.GenderId.HasValue Then%>
                    <%=Html.Encode(item.Gender.Gender)%>
                <% Else%>
                    Unknown               
                <% End If%>    
            </p>
            <p>
                <%=Html.ActionLink("(View More)", "Misc", New With {.Permilink = Model.Info.Permilink, .controller = "Info"})%>
            </p>
    <% Next%>

    <% Else%>
    
        <%=Html.ActionLink("Add Descriptor", "AddMisc", New With {.Permilink = Model.Info.Permilink, .controller = "Info"})%>
    
    <% End If%>




