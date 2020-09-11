<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

        <%Using Html.BeginForm("Close", "Referral", New With {.id = Model.ReferralId, .permilink = Model.Info.Permilink}, FormMethod.Post)%>
           <fieldset>
                <legend>Outcome</legend>
                <p><input type='submit' value="Close" /></p>
                <%=Html.Hidden("status","open") %>
                <p>
                    <label for="ServiceOutcomeId">Program Outcome</label><br />
                    <%=Html.DropDownList("ServiceOutcomeId", Model.GetServiceOutcomeLists(Model.ServiceOutcomeId), "[not set]")%>
                </p>
           </fieldset>
       <%End Using %>