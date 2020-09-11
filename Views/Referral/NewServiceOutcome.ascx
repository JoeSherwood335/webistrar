<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.Referral)" %>

<form>
    <fieldset>
        <legend>New Service Outcome</legend>
        <p>
            <%=Html.ActionLink("Skills Training Outcome", "NewSkillsTraining", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>
        <p>
            <%=Html.ActionLink("Work Eval Outcome", "NewWorkEval", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>        
        <p>
            <%=Html.ActionLink("Work Adjustment Outcome", "NewWorkAdjustment", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>        
        <p>
            <%=Html.ActionLink("JSST/PD Outcome", "NewJSST", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>        
        <p>
            <%=Html.ActionLink("Placement Outcome", "NewPD", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>     
        <p>
            <%=Html.ActionLink("Add DataSheet", "NewDS", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>
        <p>
            <%=Html.ActionLink("Job Coaching Outcome", "Newjc", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>      
        <p>
            <%=Html.ActionLink("Developmental Disabilities Services Outcome", "NewDDS", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>   
    </fieldset>
</form>