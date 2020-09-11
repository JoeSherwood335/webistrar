<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.info)" %>
       
    <%=""%>   
    
    <% If Model.Miscs.Count > 0 Then%>   
       
    <% For Each item In Model.Miscs%>
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
                <%=Html.ActionLink("(View More)", "Misc")%>
            </p>
    <% Next%>

    <% Else%>
    
        <%=Html.ActionLink("Add Misc", "AddMisc")%>
    
    <% End If%>




