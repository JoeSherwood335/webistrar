<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Assign Service
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Assign Service</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>
    <fieldset>
        <legend>Program</legend>
        <p>
            Name <%=Html.Encode(Model.Authorization.Referral.ProgramInstance.Program.ProgramName)%>
        </p>
        <p>
            CostCenter <%=Html.Encode(Model.Authorization.Referral.ProgramInstance.CostCenter)%>
        </p>
        <p>
            Location <%=Html.Encode(Model.Authorization.Referral.ProgramInstance.Location.LocationName)%>
        </p>
   </fieldset>
   
    <% Using Html.BeginForm() %>
        <%=Html.Hidden("CostCenter")%>    
        

     
       
        <fieldset>
            <legend>Service</legend>
              
            <p>
                <label for="ProductId">Service Name:</label>
                <%=Html.DropDownList("ProductId", Model.GetProductsSelectList())%>
                <%=Html.ValidationMessage("ProductId", "*")%>
               
            </p>
            <p>
                <label for="NumberOfUnits">Number Of Units:</label>
                <%= Html.TextBox("NumberOfUnits") %> 
                <%= Html.ValidationMessage("NumberOfUnits", "*") %>
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%=Html.DropDownList("AssignedTo", Model.GetAssignedTo, "[not set]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
            <p>
                <label for="ServiceStartDate">Start Date:</label>
                <%=Html.TextBox("ServiceStartDate", String.Format("{0:d}", Model.ServiceStartDate))%>
                <%= Html.ValidationMessage("ServiceStartDate", "*") %>
            </p>
            <p>
                <label for="ServiceEndDate">End Date:</label>
                <%=Html.TextBox("ServiceEndDate", String.Format("{0:d}", Model.ServiceEndDate))%>
                <%= Html.ValidationMessage("ServiceEndDate", "*") %>
            </p>
            <p>
            <%=Html.Hidden("rs")%>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

         <fieldset>
            <legend>BWC</legend>
            <p>
                <label for="OneUnitOfServiceEquals">Unit of Service</label>
                <% If Model.HasDetail("OneUnitOfServiceEquals") Then%>
                <%=Model.GetDetail("OneUnitOfServiceEquals")%>
                <%End If%>
            </p>
            <p>
                <label for="UnitAmountAuthorized">Unit Amount Authorized</label>
                 <% If Model.HasDetail("UnitAmountAuthorized") Then%>
                <%=Model.GetDetail("UnitAmountAuthorized")%>
                <%End If%>
            </p>
            <p>
                <label for="HCPCSCode">HCPCS Code</label>
                <% If Model.HasDetail("HCPCSCode") Then%>
                <%=Model.GetDetail("HCPCSCode")%>
                <%End If%>
            </p>
        </fieldset>

        <fieldset>
            <legend>Authorization</legend>
            <p>
                Authorization Number <%=Model.Authorization.AuthorizationNumber%>
            </p>
            <p>
                Product Name: <%=Model.ServiceName%>
            </p>
            <p>
                Units Authorized: <%=Model.NumberOfUnitesAuthorized%>
            </p>
            <p>
                Amount Authorized: <%=String.Format("{0:c}", Model.AmountAuthorized)%>
            </p>
            <p>
                Schedual Start Date: <%=Model.SchedualStartDate.ToShortDateString%>
            </p>
            <p>
                Schedual End Date: <%=Model.SchedualEndDate.ToShortDateString()%>           
            </p>
        
        </fieldset>
<fieldset>
    <legend>History </legend>
    
    <table>
        <thead>
                <td>Product</td
            <tr>
            <td>Status</td>
                <td>AuthorizationNo</td>
                <td>ServiceName</td>>
                <td>AssignedTo</td>
            </tr>
        </thead>
        <tbody>
        
           
            <%For Each a In Model.Authorization.Referral.Authorizations%>
            <%For Each s In a.Services.ToList%>
            <% If s.ServiceId <> Model.ServiceId And (s.GetStatus = R2kdoiMVC.Model.Service.Statuses.Completed Or s.GetStatus = R2kdoiMVC.Model.Service.Statuses.InProgress) Then%>
            <tr>
                <td><%=s.GetStatus.ToString%></td>
                <td><%=a.AuthorizationNumber%></td>
                <td><%=s.ServiceName%></td>
                <td><%=s.Product.ProductName%></td>
                <td><%=s.RegisteredUser.Username%></td>
            </tr>
            <%End If%>
            <%Next%>
            <%Next%>
            
            
            
        </tbody>
    </table>

</fieldset>

   <fieldset>
        <legend>Referral</legend>
        <p>
            Referral Source <%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.FundingSource.FullName)%>
        </p>
        <p>
            Referring Counsler <%=Html.Encode(Model.Authorization.Referral.ReferringCounselor.DisplayName)%>
        </p>
        <p>
            Assigned To <%=Html.Encode(Model.Authorization.Referral.AssignedToUser.Username)%>
        </p>
        <p>
            <% If Model.Authorization.Referral.ServiceRequested = 4 Then%>
                Service Requested Other-<%=Html.Encode(Model.Authorization.Referral.Other)%>
            <% Else%>
                Service Requested <%=Html.Encode(Model.Authorization.Referral.CRPServiceRequested.ServiceRepuested)%>
            <%End If%>
        </p>
        <p>
            Referral Date <%=Html.Encode(String.Format("{0:d}", Model.Authorization.Referral.ReferralDate))%>
        </p>
        <p>
            Consumer
            <%=Model.Authorization.Referral.Info.Link%>
        </p>
    </fieldset>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript" >

    $(document).ready(function() {

        $("#ServiceStartDate").datepicker();
        $("#ServiceEndDate").datepicker();


        $("fieldset a").click(function() {
        $.getJSON('/R2kdoiMVC2/Services/GetAutoNumberOfUnits/<%=html.encode(model.ServiceId) %>', function(data) {
                var r = data.NumberOfUnits || 0
                if (r!=0) {
                    $('#NumberOfUnits').val(data.NumberOfUnits);
                
                }
            });
            return false
        });
    });


</script>

</asp:Content>

