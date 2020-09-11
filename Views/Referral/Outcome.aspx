<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)"  %>
<%@ Import Namespace="R2kdoiMVC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="header" ContentPlaceHolderID="HeaderContent" runat="server">

<style type="text/css">

div#Status
{
	margin:10px
}

#ServiceOutcomes p
{
clear:both ;	
	
}
#ServiceOutcomes strong
{
    float: left;
    Width:200px;
}


</style>


<script type="text/javascript">
    $(function() {
        $("#Status").buttonset();
        $(".ServiceOutcomes").accordion({
			autoHeight: false,
			navigation: true,
			collapsible: true
		});//accordion
        
    }); //$ 
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%=""%>
    
    <h2>
        Referral for Program <%=Model.ProgramInstance.Program.ProgramName%>
    </h2>
    <p>
        <%=Model.ProgramInstance.Location.LocationName%>
    </p>
    
    
      <fieldset>
        <legend>Referral</legend>
        
        <p>
            Referral Source <%=Html.Encode(Model.ReferringCounselor.FundingSource.FullName)%>
        </p>
        <p>
            Referring Counsler <%=Html.Encode(Model.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            Assigned To <%=Html.Encode(Model.AssignedToUser.Username)%>
        </p>
        <p>
            <% If Model.ServiceRequested = 4 Then%>
            
                Service Requested Other-<%=Html.Encode(Model.Other)%>
            <% Else%>
                Service Requested <%=Html.Encode(Model.CRPServiceRequested.ServiceRepuested)%>
            
            <%End If%>
        </p>
        <p>
            Referral Date <%=Html.Encode(String.Format("{0:d}", Model.ReferralDate))%>
        </p>
        <p>
            Consumer
            <%=Html.ActionLink(Model.Info.FirstName & " " & Model.Info.LastName, "Details", New With {.permilink = Model.Info.Permilink, .controller = "info"})%>
        </p>
        
        
        
    </fieldset>
    
    
    
    
    <%=Html.ValidationSummary()%>
    <%If Model.GetStatus = R2kdoiMVC.Model.referral.Statuses.Open Then%>
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
 <%Else%>
        <%Using Html.BeginForm("Open", "Referral", New With {.id = Model.ReferralId, .permilink = Model.Info.Permilink}, FormMethod.Post)%>
            <fieldset>
                <legend>Program Outcome</legend>
                <p><input type='submit' value="ReOpen" /></p>
                <%=Html.Hidden("status","Closed") %>
               <p>Referral is Closed with the Outcome of  
                <%If Model.ServiceOutcomeId.HasValue Then%>
                     <q><%=Model.ServiceOutcome.ServiceOutcomeName%></q>
                <%Else%>
                    <q>Not Set</q>
                <%end if  %>
                </p>
            </fieldset>
        <%End Using %>    
 <%End If%>
<fieldset>
    <legend>Services</legend>
    
    <div class="ServiceOutcomes">
    <%For Each authorization In Model.Authorizations%>
        <h3>
            <a href='#'><%=authorization.AuthorizationNumber%></a>
        </h3>
        <div>
        <%For Each Service In authorization.Services%>
            <p>
                <strong>ServiceType</strong> 
                    <%=Html.ActionLink(Service.ServiceName, "Details", New With {.controller = "services", .id = Service.ServiceId}, New With {.class = "servicelink"})%>
                <strong>StartDate</strong>  
                    <%If Service.ServiceStartDate.HasValue Then%>
                        <%= Service.ServiceStartDate.Value.ToShortDateString %> 
                    <%Else%>
                        [not set] 
                    <%End If%>
                <strong>EndDate</strong> 
                    <%If Service.ServiceEndDate.HasValue Then%>
                        <%=Service.ServiceEndDate.Value.ToShortDateString%> 
                    <%Else%>
                        [not set] 
                    <%End If%>
                <strong>Outcome</strong> 
                    <%If Service.ServiceOutcomeId.HasValue Then%>
                        <%=Service.ServiceOutcome.ServiceOutcomeName%> 
                    <%Else%>
                        [not set] 
                    <%End If%>
                   
            </p>
        <%Next%>
        </div>
    <%Next%>
    </div>
</fieldset>    
    
<fieldset>
    <legend>Service Outcomes</legend>
    <div class="ServiceOutcomes">
    <% For Each item In Model.ProgramOutcomes%>
       <% Dim ipo As Model.ProgramOutcomes.iProgramOutcome%>
     
       <% If item.PoTypeId.Equals(1) Then%> 
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.StOutcome%>
       <% ElseIf item.PoTypeId.Equals(2) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WeOutcome%>
       <% ElseIf item.PoTypeId.Equals(3) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WaOutcome%>
       <% ElseIf item.PoTypeId.Equals(5) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.JsstOutcome%>
       <% ElseIf Myapp.GetPoType(item.PoData) = "pd" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.PdOutcome%>
       <% ElseIf Myapp.GetPoType(item.PoData) = "dds" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome%>     
       <% Else%>     
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.BlankOutcome%>
       <% End If%>
       <% ipo.ReadXml(item.PoData)%>
       
       
       <h3><a href="#"><%=ipo.Title%></a></h3>
       <div>
       <%=ipo.Body%>
       
       
       <%=ipo.EditLink(Model.Info.Permilink, item.PoId)%> 
       <%=Html.ActionLink("Print", "PrintProgramOutcome", New With {.id = item.PoId}, New With {.target = "_blank"})%>
       <% If Not item.InfoPathData Is Nothing Then%>

 
            <% Dim edit = String.Format(R2kdoiMVC.Myapp.BuildUri.Action("getInfopath", New With {.permilink = Model.Info.Permilink, .id = item.PoId}))%>
            <a href="<%=edit%>">View Infopath</a>
       <% end if  %>
       </div>

             
    <% Next%>
    </div>
</fieldset>    

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
            <%=Html.ActionLink("Add New DataSheet", "NewDS", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>
             
        <p>
            <%=Html.ActionLink("Add New DataSheet", "NewDS", New With {.permilink = Model.Info.Permilink, .id = Model.ReferralId})%>   
        </p>
              
    </fieldset>
    
   <fieldset>
        <legend>Note</legend>
    
        <%Html.RenderPartial("ReadNotes")%>
    
    </fieldset>
    
    
    <fieldset>
        <legend>Placement</legend>
        
        <p><%=Html.ActionLink("Add Placement", "Company", New With {.controller = "Placements", .ReferralId = Model.ReferralId, .permilink = Model.Info.Permilink}, New With {.target = "_blank"})%></p>
        
        <table>
            <tr>
                <th>Company</th>
                <th>Type</th>    
            </tr>
            <% For Each placement In Model.Placements%>
            <tr>
                <td><%=Html.ActionLink("Details", "Details", New With {.controller = "Placements", .id = placement.PlacementId, .permilink = placement.Info.Permilink}, New With {.target = "_blank"})%></td>            
                <td><%=placement.Company.CompanyName%></td>
                <td><%=placement.PlacementType.PlacementType%></td>
                
            </tr>
            <%Next%>
        </table>
    
    </fieldset>

    <%'If ViewData("potype") = "we" Then%>
        <%'Html.RenderPartial("weOutcome")%>
    <%'ElseIf ViewData("potype") = "wa" Then%>
        <%'Html.RenderPartial("waOutcome")%>
    <%'ElseIf ViewData("potype") = "st" Then%>
         <%'Html.RenderPartial("stOutcome")%>
    <%'End If%>
    
    

</asp:Content>

