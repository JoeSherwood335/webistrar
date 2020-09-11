<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>




   

        <%Using Html.BeginForm("Open", "Referral", New With {.id = Model.ReferralId, .permilink = Model.Info.Permilink}, FormMethod.Post)%>
            <fieldset>
                <legend>Program Outcome</legend>
                
                <%=Html.Hidden("status","Closed") %>
               <p>Referral is Closed with the Outcome of  
                <%If Model.ServiceOutcomeId.HasValue Then%>
                     <q><%=Model.ServiceOutcome.ServiceOutcomeName%></q>
                <%Else%>
                    <q>Not Set</q>
                <%end if  %>
                </p>
                <p><input type='submit' value="ReOpen" /></p>
            </fieldset>
        <%End Using %> 