<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Service
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
   <fieldset>
            <legend>Add Service</legend>
      <table>
        <tr>
            <th>Name</th>
            <th >Units Authorized</th>
            <th>Price</th>
            <th>Type</th>
            <th>Amount</th>
            <th>Start Date</th>
            <th>End Date</th>
        </tr>
        <tr>
            <td><%=Html.TextBox("ServiceName")%></td>
            <td ><%=Html.TextBox("NumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("UnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("UnitTypeId", Model.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("AmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("SchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("SchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>
        <tr>
            <td>Mileage</td>
            <td ><%=Html.TextBox("MileageNumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("MileageUnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("MileageUnitTypeId", Model.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("MileageAmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("MileageSchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("MileageSchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>
        <tr>
            <td>ReportWriting</td>
            <td ><%=Html.TextBox("ReportWritingNumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("ReportWritingUnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("ReportWritingUnitTypeId", Model.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("ReportWritingAmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("ReportWritingSchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("ReportWritingSchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>
        <tr>
            <td>WageAddon</td>
            <td ><%=Html.TextBox("WageAddonNumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("WageAddonUnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("WageAddonUnitTypeId", Model.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("WageAddonAmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("WageAddonSchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("WageAddonSchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>



      </table>
      
      
      <input type="submit" value="Save" />
          
        
   
        
        
    <% End Using %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript" >
    $(document).ready(function() {

 	
	
		var dates = $( ".datetime" ).datepicker({
			defaultDate: "+1w",
			changeMonth: true,
			numberOfMonths: 1
    		}); // end Dates
	
    }); // end document ready 


</script>
</asp:Content>

