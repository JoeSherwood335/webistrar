<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Billing.Billing)" %>
<%@ Import Namespace="R2kdoiMVC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%=""%>
<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<!--link href="http://cable.vgsjob.org/VGSSite/wp-content/themes/vgsjobDefaultV3/style/css/reset.css" rel="stylesheet" type="text/css" /-->
<link href="../../Content/reset.css" rel="stylesheet" type="text/css" />
<link href="../../Content/default.css" rel="stylesheet" type="text/css" />
<link href="../../Content/print.css" rel="stylesheet" type="text/css" media="print" />

</head>

<body style="font-family: Arial, Helvetica, sans-serif ;">
	
	<div id="header-outer-top" >
	
	</div>
	<div id="header-outer">
	<div id="header">
		<div class="left_column">
			<img alt="Vocational Guidance Services" src="<%=myapp.GetServerPath()%>/Content/imgs/logo.png" /><br/>
			<span>Preparing People with Barriers to <br />Employment for a Brighter Future</span>
		</div>
		<div class="right_column">
            <%If Model.GetStatus = R2kdoiMVC.Myapp.Accrued Then%>
                <%=Html.ActionLink("Submit", "Start", New With {.id = Model.Id})%> <%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%>
            <%ElseIf Model.GetStatus = R2kdoiMVC.Myapp.BILLED Then%>
                <%=Html.ActionLink("Approve", "Approve", New With {.id = Model.Id})%> <%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%>

            <%ElseIf Model.GetStatus = R2kdoiMVC.Myapp.APPROVED Then%>
                <%=Html.ActionLink("Accept", "Accept", New With {.id = Model.Id})%> <%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%>

            <%ElseIf Model.GetStatus = R2kdoiMVC.Myapp.ACCEPTED  Then%>
            
              <%=R2kdoiMVC.Myapp.ACCEPTED %>

            <%elseIf R2kdoiMVC.Myapp.CurrentUserInfo.Profile.Name <> "Admin" Then%>
             
            <%=R2kdoiMVC.Myapp.ACCEPTED %> ADMIN:<%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%>

            <%End If%>	
            
             <%If R2kdoiMVC.Myapp.CurrentUserInfo.Profile.Name = "Admin" Or R2kdoiMVC.Myapp.CurrentUserInfo.Profile.Name = "Manager" Then%>
             
                ADMIN:<%=Html.ActionLink("Void", "Void", New With {.id = Model.Id})%> ;<%=Html.ActionLink("Backup", "Backup", New With {.id = Model.Id})%>

            <%End If%>	


            <span>Service Billing</span>
		<div style="clear: both ;width: 100%;margin-top: 1px ;border-top: -1px transparent "></div>	
	</div>
		</div>
	<div id="content-outer"> 
	<div id="content">
		<hr />
		<div class="left_column">
			<fieldset>
				<legend>Requested Service</legend>
				<label>Funding Source: </label><acronym title="<%=Html.Encode(Model.FundingSource.Acronym)%>"><%=Html.Encode(Model.FundingSource.FullName)%></acronym><br />
				<label>Referral Source: </label><acronym title="<%=Html.Encode(Model.ReferringCounselor.FundingSource.Acronym)%>"><%=Html.Encode(Model.ReferringCounselor.FundingSource.FullName)%></acronym><br/>
				<label>Referring Counsler: </label><span><%=Html.Encode(Model.ReferringCounselor.LastName)%>, <%=Html.Encode(Model.ReferringCounselor.FirstName)%> <%=Html.Encode(Model.ReferringCounselor.RepCode )%></span>	
			</fieldset> 
		</div>
		<div class="right_column">
			<fieldset>
				<legend>Serviced at</legend>
				<h3>Vocational Guidance Services</h3>
				<h4>Training Center</h4>
				<address>2235 East 55th<br />Cleveland, Oh 44102</address>
			</fieldset>
		</div>

		<table>
			<thead>	
				<tr>
					<td>Invoice</td>
					<td>Date Issued</td>
					<td>Consumer Name</td>
					<td>Referral</td>
					<td>Authorization</td>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>
						<%= Html.Encode(Model.Id) %>
					</td>
					<td>
						<%=Html.Encode(String.Format("{0:d}", Model.BillingCycles.OrderByDescending(Function(e) e.ActionDate).Take(1).Single(Function(e) e.BillingId = Model.Id).ActionDate))%>
					</td> 
					<td>
						<%=Html.ConsumerLink(Model.RegistrarNo)%>
					</td>
					<td>
						<%=Html.Encode(Model.Info.REF)%> 
					</td>
					<td>
						<%=Html.Encode(Model.AuthorizationNo)%>
					</td>
				</tr>
			</tbody>
			
		</table>
	
		<table style="font-size:xx-small">
			<thead>
				<tr>
					<td style="width:20%;">Service</td>
					<td>Number of Unit</td>
					<td>UnitType</td>
					<td>UnitPrice</td>
					<td>Total</td>			
				</tr>
				<tr>
					<td style="width:20%;">From</td>
					<td style="">to</td>
					<td></td>
					<td colspan="3">Description</td>
				</tr>
			</thead>
			<tbody>
			<% For Each item In Model.BillingDetails%>
			
				<tr>
					<td style="width:20%;"><%=Html.ActionLink(item.ServiceName, "Details", New With {.controller = "services", .id = item.ServiceId}, New With {.class = "servicelink showprintinline"})%></td>
					<td><%=Html.Encode(item.NumberOfUnits)%></td>
					<td><%=Html.Encode(item.UnitType.UnitType)%></td>
					<td><%=Html.Encode(String.Format("{0:c}", item.UnitPrice))%></td>
					<td><%=Html.Encode(String.Format("{0:c}", item.NumberOfUnits * item.UnitPrice))%></td>									
				</tr>
				<tr>
					<td style="width:20%;"><%=Html.Encode(String.Format("{0:d}", item.StartDate))%></td>
					<td style=""><%=Html.Encode(String.Format("{0:d}", item.EndDate))%></td>
					<td></td>
					<td colspan=2 >
					    <% If item.Product.ParentId.HasValue Then%>
					        <%=Html.Encode(item.Product.Product.ProductName)%>
					    <% End If%>
                        <%=Html.Encode(item.Product.ProductName)%></td>
				</tr>
				<tr>
				    <td></td>
				    <td></td>
				    <td></td>
				    <td></td>
				    <td></td>
				</tr>
				<%next %>
			</tbody>
			<tfoot>
				<tr>
					<td></td>
					<td></td>
					<td></td>
					<td>Total:</td>
					<td><%=Html.Encode(String.Format("{0:c}", (Aggregate a In Model.BillingDetails Into Sum(a.NumberOfUnits * a.UnitPrice))))%></td>
				</tr>
			</tfoot>
		</table>		
	Note
	<p>
        <% Html.RenderPartial("ReadNotes")%>
	</p>
		<div style="clear: both ;width: 100%;margin-top: 1px ;border-top: -1px transparent "></div>	
		
		

	</div></div>
	<div id="footer-outer">	
	<div id="footer">
		<div class="left_column" >
			Program Name: <%=Html.Encode(Model.Program.ProgramName)%><br />
			Cost Center: <%=Html.Encode(Model.CostCenter)%><br />
			Supervisor: <% If Model.ProgramSupervisorId.HasValue Then%>	
			                <%=R2kdoiMVC.Myapp.GetUserInfo(Model.ProgramSupervisorId.Value).Username%>
			            <% End If%>
		</div>
		<div class="right_column">
			Approved By : <% If Model.AuthorizationApprovedById.HasValue Then%>			
			                    <%=Html.Encode(R2kdoiMVC.Myapp.GetUserInfo(Model.AuthorizationApprovedById.Value).Username)%>
			              <% End If%>
			
            
			
            
		</div>
		<div style="clear: both ;width: 100%;margin-top: 1px ;border-top: -1px transparent "></div>	
		
	<table>
	    <thead>
	        <tr>
	            <td>Status</td>
	            <td>By</td>
	            <td>Date</td>
	        </tr>
	    </thead>
        <tbody>
        <% For Each cycle In Model.BillingCycles%>
            <tr>
                <td><%=cycle.Action.Name%></td>
                <td><%=cycle.InputedByUser.Username%></td>
                <td><%=cycle.ActionDate.ToShortDateString%></td>            
            </tr>
        <% Next%>
        </tbody>	
	</table>	
		
		
	</div>
	</div>
	<div id="header-outer-bottem" >
	   
	</div>
</body>

</html>
