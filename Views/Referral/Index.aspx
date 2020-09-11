<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Info)" %>
<%@ Import Namespace="R2kdoiMVC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Programs for <%=Model.GetFullName(R2kdoiMVC.Model.Info.NameTypes.FirstLastSuf)%> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<style type="text/css" >
    table {font-size:smaller;}

</style>

<script type="text/javascript" >

  $(function() {

        $( "#tabs" ).tabs();
        
        $(".ServiceOutcomes").accordion({
			autoHeight: false,
			navigation: true,
			collapsible: true
		}); // end accordion

        $(".ServiceProvider").click(function(data) {

                 //alert(this.href);
                 var thref = this.href;

                 $('#foo').empty();

                 $.ajax({
                     type: 'GET',
                     url: thref,
                     data: '',
                     cashe: false,
                     success: function(data, textStatus, jqXHR) {


                         $('<div />').append(data.replace(/<script(.|\s)*?\/script>/g, "")).find('form').appendTo("#foo");


                         $("#foo").dialog({
                             open: function(event, ui) {
                         


                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog
                     }, // end success
                     error: function(data, textStatus, jqXHR) {

                         $('<div />').append(data.responseText.replace(/<script(.|\s)*?\/script>/g, "")).find('form').appendTo("#foo");

                         $("#foo").dialog({
                             open: function(event, ui) {

                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog

                     } // end error
                 }); // end $.ajax


                 return false
             }); // end newc click

  }); //end document ready 

  </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Model.Link%> is enrolled in the following programs</h2>

    <p>
        <%=Html.ActionLink("Enroll this consumer in a new Program", "create")%>
    </p>
    <p>
        <%=Html.ActionLink("Enroll this consumer in a new Program For Admin Services", "AddAdmin")%>
    </p>    

<!-- heading -->


<div id="tabs">
<ul>
    <% For Each item In Model.Referrals%>
    
        <li><a href="#ref-<%=item.referralid %>"><%=item.ProgramInstance.Program.ProgramName%></a></li>
    
    <% Next%>
</ul>
<% For Each item In Model.Referrals%>
        <div id="ref-<%=item.referralid %>">
               <p>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ReferralId})%> | 
                <%=Html.ActionLink("Intake", "Details", New With {.id = item.ReferralId})%> | 
               
                <%If item.GetStatus = R2kdoiMVC.Model.Referral.Statuses.Open Then%>
                    <%=Html.ActionLink("Close", "Close", New With {.id = item.ReferralId}, New With {.class = "ServiceProvider"})%>
                <%Else%>
                    <%=Html.ActionLink("ReOpen", "Open", New With {.id = item.ReferralId}, New With {.class = "ServiceProvider"})%>   
                <%End If%>
                
               </p>
        <fieldset>
        <legend>Program</legend>
              <p>
                <strong>Program Manager</strong> <%=item.ProgramInstance.Supervisor.Username%>
                <strong>Location</strong> <%=item.ProgramInstance.Location.LocationName%>
                <strong>Cost Center</strong> <%=item.ProgramInstance.CostCenter%>
              </p>
              <p>
                <strong>Status</strong>
                <% If item.StatusId = 2 Then%>
                        <span style="color:Red">Closed</span> 
                <% Else%>        
                        <span style="color:Green">Open</span> 
                <% End If%>  
                <strong>Program Outcome</strong>
                <%If item.ServiceOutcomeId.HasValue Then%>
                     <q><%=item.ServiceOutcome.ServiceOutcomeName%></q>
                <%Else%>
                    <q>Not Set</q>
                <%end if  %>
              </p>
         </fieldset> 
      <fieldset>
        <legend>Referral</legend>
        
        <p>
            <strong>Referral Source</strong> <%=Html.Encode(item.ReferringCounselor.FundingSource.FullName)%>
        </p>
        <p>
            <strong>Referring Counsler</strong> <%=Html.Encode(item.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            <strong>Requested Service Provider</strong> <%=Html.Encode(item.AssignedToUser.Username)%>
        </p>
        <p>
            <strong>Service Requested</strong>
            <% If item.ServiceRequested = 4 Then%>
            
                 Other-<%=Html.Encode(item.Other)%>
            <% Else%>
                <%=Html.Encode(item.CRPServiceRequested.ServiceRepuested)%>
            
            <%End If%>
        </p>
        <p>
            <strong>Referral Date</strong> <%=Html.Encode(String.Format("{0:d}", item.ReferralDate))%>
        </p>
        
        
        
    </fieldset>
    
    
    
    <fieldset>
    <legend>Authorization</legend>
    <p><%=Html.ActionLink("Add None Billable Service", "AddNonBillable", New With {.id = item.ReferralId}, New With {.class = "ServiceProvider"})%></p>
    <div class="ServiceOutcomes">
    <%For Each authorization In item.Authorizations%>
        <h3>
            <a href='#'><strong>Number</strong> <%=authorization.AuthorizationNumber%>  </a>
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
            <p>            
                <strong>Service Provider</strong> 
                    <%=Html.ActionLink(Service.RegisteredUser.Username, "ReAssignService", New With {.id = Service.ServiceId}, New With {.class = "ServiceProvider"})%>
                <strong>SchedualStartDate</strong>  
                    <%=Service.SchedualStartDate.ToShortDateString%> 
                <strong>SchedualEndDate</strong> 
                    <%=Service.SchedualEndDate.ToShortDateString%> 
                <strong>Status</strong> 
                    <%=Service.GetStatus.ToString%> 
            </p>
        <%Next%>
        </div>
    <%Next%>
    </div>
</fieldset>    
    
<fieldset>
    <legend>Service Outcomes</legend>
    
    <p><%=Html.ActionLink("Add Service Outcomes", "NewServiceOutcome", New With {.id = item.ReferralId}, New With {.class = "ServiceProvider"})%></p>
    
    <div class="ServiceOutcomes">
    <% For Each i In item.ProgramOutcomes%>
       <% Dim ipo As Model.ProgramOutcomes.iProgramOutcome%>
     
       <% If i.PoTypeId.Equals(1) Then%> 
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.StOutcome%>
       <% ElseIf i.PoTypeId.Equals(2) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WeOutcome%>
       <% ElseIf i.PoTypeId.Equals(3) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WaOutcome%>
       <% ElseIf i.PoTypeId.Equals(5) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.JsstOutcome%>
       <% ElseIf Myapp.GetPoType(i.PoData) = "pd" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.PdOutcome%>
       <% ElseIf Myapp.GetPoType(i.PoData) = "jc" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.JCOutcome%>
       <% ElseIf Myapp.GetPoType(i.PoData) = "dds" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome%>     
       <% Else%>     
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.BlankOutcome%>
       <% End If%>
       <% ipo.ReadXml(i.PoData)%>
       
       
       <h3><a href="#"><%=ipo.Title%></a></h3>
       <div>
       <%=ipo.Body%>
       
       
       <%=ipo.EditLink(item.Info.Permilink, i.PoId)%> 
       <%=Html.ActionLink("Print", "PrintProgramOutcome", New With {.id = i.PoId}, New With {.target = "_blank"})%>
       <% If Not i.InfoPathData Is Nothing Then%>

 
            <% Dim edit = String.Format(R2kdoiMVC.Myapp.BuildUri.Action("getInfopath", New With {.permilink = item.Info.Permilink, .id = i.PoId}))%>
            <a href="<%=edit%>">View Infopath</a>
       <% end if  %>
       </div>

             
    <% Next%>
    </div>
</fieldset>    
    
        <fieldset>
        <legend>Placement</legend>
                
        <p><%=Html.ActionLink("Add Placement", "Company", New With {.controller = "Placements", .ReferralId = item.ReferralId, .permilink = item.Info.Permilink}, New With {.target = "_blank"})%></p>
        
        <table>
            <tr>
                <th></th>
                <th>Company</th>
                <th>Type</th>    
            </tr>
            <% For Each placement In item.Placements.Where(Function(e) e.IsPlacement = True)%>
            <tr>
                <td><%=Html.ActionLink("Details", "Details", New With {.controller = "Placements", .id = placement.PlacementId, .permilink = placement.Info.Permilink}, New With {.target = "_blank"})%></td>            
                <td><%=placement.Company.CompanyName%></td>
                <td><%=placement.PlacementType.PlacementType%></td>
                
            </tr>
            <%Next%>
        </table>
    
    </fieldset>
    
    </div>
  
<% Next%>

</div>


<div id="foo" style="display :none;"></div> 

</asp:Content>

