<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Service Agreement
</asp:Content>

<asp:Content ID="headercontent" ContentPlaceHolderID="HeaderContent" runat="server">
     <style type="text/css">
     /*.SelectService { display:inline ;}*/
     .ui-datepicker {z-index:10100;} 
     </style>
     <script type="text/javascript" >
         $(document).ready(function() {
             //$.ajaxSetup({ cache: false });

             $.ajaxSetup({
                 // Disable caching of AJAX responses */ 
                 cache: false
             }); // end ajaxSetup



//             $("#formmenu > ul > li > ul > li > a, a.SelectService").click(function(data) {
             $("#formmenu .window a, a.SelectService").click(function(data) {

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

                                 $("#ServiceStartDate").datepicker({
                                     changeMonth: true,
                                     changeYear: true,
                                     showOtherMonths: true,
                                     selectOtherMonths: true
                                 });

                                 $("#ServiceEndDate").datepicker({
                                     changeMonth: true,
                                     changeYear: true,
                                     showOtherMonths: true,
                                     selectOtherMonths: true
                                 });


                                 $("#auto a").click(function() {
                                     $.getJSON('/Services/GetAutoNumberOfUnits/<%=html.encode(model.ServiceId) %>', function(data) {
                                         var r = data.NumberOfUnits || 0
                                         if (r != 0) {
                                             $('#NumberOfUnits').val(data.NumberOfUnits);

                                         } // end if 
                                     }); // end getJSON
                                     return false
                                 }); // end auto a click


                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog
                     }, // end success
                     error: function(data, textStatus, jqXHR) {

                         $('<div />').append(data.responseText.replace(/<script(.|\s)*?\/script>/g, "")).appendTo("#foo");

                         $("#foo").dialog({
                             open: function(event, ui) {

                             }, // end foo dialog open
                             width: "auto"
                         }); // end foo dialog

                     } // end error
                 }); // end $.ajax


                 return false
             }); // end newc click
         });                  // end document load 
      </script>
 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=""%>
    <h2>Service Agreement for Program:<%=Html.Encode(Model.Authorization.Referral.ProgramInstance.Program.Acronym)%> <%=Html.Encode(Model.Authorization.Referral.ProgramInstance.Program.ProgramName)%></h2>
    <div id="formmenu" >
       <ul>
            <li id="services" class="window" ><a href="#">Service</a>
                    <ul>
                        <li><%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ServiceId})%></li>
                        <li><%=Html.ActionLink("TimeWorked", "TimeWorked", New With {.id = Model.ServiceId})%></li>
                    </ul>
                </li>
                <% If Model.GetStatus = R2kdoiMVC.Model.Service.Statuses.InProgress Then%>            
                <li id="billing"  class="window"><a href="#">110</a>
                    <ul>
                    <% If Not Model.HasBillingsInStarted Then%>
                        <li><%=Html.ActionLink("Create", "Accrue", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Billing"})%></li>
                        <li><%=Html.ActionLink("Manual", "Manual", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Billing"})%></li>
                        <% Else%>
                        <li><%=Html.ActionLink("Append", "Accrue", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Billing"})%></li>
                        <li><%=Html.ActionLink("add Manual", "Manual", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Billing"})%></li>
                        <% End If%>
                    </ul>
                </li>
                <li id="status" class="window"><a href="#">Status</a>
                    <ul>
                        <li><%=Html.ActionLink("Complete", "Complete", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Cancel"})%></li>
                        <li><%=Html.ActionLink("Cancel", "Cancel", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Cancel"})%> </li>
                    </ul>
                </li> 
                <% End If%>   
                <%If (R2kdoiMVC.Myapp.CurrentUserInfo.Profile.Name = "Manager" Or R2kdoiMVC.Myapp.CurrentUserInfo.Profile.Name = "Admin") And Model.GetStatus = R2kdoiMVC.Model.Service.Statuses.Completed Then%>
                <li id="status" class="window"><a href="#">Status</a>
                    <ul>
                        <li><%=Html.ActionLink("Reset", "ResetService", New With {.id = Model.ServiceId}, New With {.target = "_blank", .title = "Cancel"})%></li>
                    </ul>
                </li> 
                <%End If%>	
                
                         
                <li id="referral" ><a href="#">Program</a>
                    <ul>
                        <li><%=Html.ActionLink("Details", "Outcome", New With {.id = Model.Authorization.ReferralId, .controller = "referral"})%> </li>
                        
                    </ul>
                </li>
            </ul>
    </div>
    
    <br style="clear:both;"/>
    <fieldset>
        <legend>Consumer</legend>
        <p>
           Registrar No: <%=Html.Encode(Model.Authorization.Referral.Info.RegistrarNo )%> Name: <%=Model.Authorization.Referral.Info.Link%>
        </p>
    </fieldset>
    
     <fieldset>
        <legend>Service</legend>
        <p>Status <%=Model.GetStatus.ToString%></p>
        <p>
            Product:
                <% If Model.Product.ParentId.HasValue Then%>
                    <%=Html.Encode(Model.Product.Product.ProductName)%>               
                <% End If%>
                <%=Html.Encode(Model.Product.ProductName)%>  
        </p>
        <p>
            Number Of Units:
            <%= Html.Encode(Model.NumberOfUnits) %> <%=Html.Encode(Model.UnitType.UnitType)%>
        </p>
        <p>
            AssignedTo:
            <%=Html.Encode(Model.RegisteredUser.Username)%>
        </p>
        <p>
            Start Date:
                <%If Model.ServiceOutcomeId.HasValue Then%>
                    <%=Model.ServiceStartDate.Value.ToShortDateString%>
                <%Else%>      
                    <%If Model.ServiceStartDate.HasValue Then%>
                        <%=Html.Encode(String.Format("{0:d}", Model.ServiceStartDate))%> 
                    <%Else%>
                        <%=Html.ActionLink("Start", "StartService", New With {.id = Model.ServiceId}, New With {.class = "SelectService", .cm = HttpContext.Current.Request.QueryString("cm")})%>
                    <%End If%>
                <%End If%>
        </p>
        <p>
            End Date:
                <%If Model.ServiceOutcomeId.HasValue Then%>
                  
                    <%=Model.ServiceEndDate.Value.ToShortDateString%>
                <%Else%>                
                    <%If Model.ServiceStartDate.HasValue Then%>
                
                        <%If Model.ServiceEndDate.HasValue Then%>
                            <%=Html.ActionLink(Model.ServiceEndDate.Value.ToShortDateString, "EndService", New With {.id = Model.ServiceId}, New With {.class = "SelectService", .cm = HttpContext.Current.Request.QueryString("cm")})%> 
                        <%Else%>
                            <%=Html.ActionLink("End", "EndService", New With {.id = Model.ServiceId}, New With {.class = "SelectService", .cm = HttpContext.Current.Request.QueryString("cm")})%>
                        <%End If%>
                    <%End If%>

                <%End If%>
        </p>
        <p>
            Billed Amount: <%=Html.Encode(String.Format("{0:c}", ViewData("billedamount")))%>
        </p>
    </fieldset>
    

    <fieldset>
            <legend>Referral</legend>
            <p>
                Source:  <acronym title="<%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.FundingSource.FullName)%>"><%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.FundingSource.Acronym)%></acronym>
            </p>
            
            <p>
                Status:  
                <%If Model.Authorization.Referral.StatusId <> 2 Then%>
                    <span>Open</span>
                <%Else%>
                    <span>Closed</span>
                <%End If%>
            </p>
       </fieldset>

    <fieldset>
        <legend>Authorization</legend>
        <p>
           Number <%=Html.ActionLink(Model.Authorization.AuthorizationNumber, "Details", New With {.id = Model.AuthorizationId, .controller = "Authorizations"}, New With {.target = "_blank", .class = "showprintinline"})%>
        </p>
        <p>
           Date <%=Html.Encode(Model.Authorization.AuthorizationDate.ToShortDateString)%>
        </p>
        <p>
           FundingSource <acronym title="<%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.FundingSource.FullName)%>"><%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.FundingSource.Acronym)%></acronym>
        </p>
        <p>
            Service Requested <%=Model.ServiceName%>
        </p>
        <p>
            Unites Authorized <%= Model.NumberOfUnitesAuthorized%> 
        </p>
        <p>
            Unit Price <%=String.Format("{0:c}", Model.UnitPrice)%>
        </p>
        <p>
            Amount Authorized <%=String.Format("{0:c}", Model.AmountAuthorized)%>
        </p>
        
        <p>
            StartDate <%=String.Format("{0:d}", Model.SchedualStartDate)%>
        </p>
        <p>
             EndDate <%=String.Format("{0:d}", Model.SchedualEndDate)%>
        </p>
                
    </fieldset>

    <fieldset>
        <legend>Bills</legend>
        <ol>
            <% For Each bill In Model.GetBillings%>
                <li>
                    <%=Html.ActionLink(bill.GetStatus, "Details", New With {.id = bill.Id, .controller = "billings"}, New With {.target = "_blank", .class = "showprintinline"})%>&nbsp;                   
                    <%=String.Format("{0:c}", (Aggregate a In bill.BillingDetails Where a.ServiceId = Model.ServiceId Into Sum(a.UnitPrice * a.NumberOfUnits)))%>&nbsp;                         
                    <%=String.Format("{0:d}", (Aggregate a In bill.BillingDetails Where a.ServiceId = Model.ServiceId Into Min(a.StartDate)))%>&nbsp;                         
                    <%=String.Format("{0:d}", (Aggregate a In bill.BillingDetails Where a.ServiceId = Model.ServiceId Into Max(a.EndDate)))%>&nbsp;
                </li>
            <% Next%>
        </ol>
    </fieldset>

    <div id="foo" style="display :none;"></div> 

</asp:Content>

