<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Service</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Authorization</legend>
             <p>
                <label for="ServiceTypeId">Service Name:</label>
                <%=Html.TextBox("ServiceName", Model.ServiceName)%>
                <%= Html.ValidationMessage("ServiceTypeId", "*") %>
            </p>
            <p>
                <label for="NumberOfUnitesAuthorized">Units Authorized:</label>
                <%= Html.TextBox("NumberOfUnitesAuthorized") %>
                <%= Html.ValidationMessage("NumberOfUnitesAuthorized", "*") %>
            </p>
            <p>
                <label for="UnitPrice">Unit Price:</label>
                <%=Html.TextBox("UnitPrice")%>
                <%=Html.ValidationMessage("UnitPrice", "*")%>
            </p>
            <p>
                <label for="AmountAuthorized">Amount Authorized:</label>
                <%=Html.TextBox("AmountAuthorized")%>
                <%=Html.ValidationMessage("AmountAuthorized", "*")%>
            </p>
            <p>
                <label for="UnitTypeId">Unit Type:</label>
                <%=Html.DropDownList("UnitTypeId", Model.GetUnitType(Model.UnitTypeId))%>
                <%= Html.ValidationMessage("UnitTypeId", "*") %>
            </p>
            <p>
                <label for="SchedualStartDate">Schedual Start Date:</label>
                <%= Html.TextBox("SchedualStartDate") %>
                <%= Html.ValidationMessage("SchedualStartDate", "*") %>
            </p>
            <p>
                <label for="SchedualEndDate">Schedual End Date:</label>
                <%= Html.TextBox("SchedualEndDate") %>
                <%= Html.ValidationMessage("SchedualEndDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

        <fieldset>
            <legend>BWC</legend>
            <p>
                <lable for="OneUnitOfServiceEquals">Unit of Service Equals</lable>
                <%=Html.TextBox("UnitOfServiceEquals")%>
            </p>
            <p>
                <lable for="UnitAmountAuthorized">Unit Amount Authorized</lable>
                <%=Html.TextBox("UnitAmountAuthorized")%>
            </p>
            <p>
                <lable for="HCPCSCode">HCPCS Code</lable>
                <%=Html.TextBox("HCPCSCode")%>
            </p>
        </fieldset>
        
          <fieldset>
            <legend>Service</legend>
              
            <p>
                <label for="ProductId">Service Name:</label>
                <%=Html.DropDownList("ProductId", Model.GetProductsSelectList())%>
                <%=Html.ValidationMessage("ProductId", "*")%>
               
            </p>
            <p>
                <label for="NumberOfUnits">Number Of Units:</label>
                <%= Html.TextBox("NumberOfUnits") %> <span id="auto"><a href="#">auto</a></span>
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

            </p>
        </fieldset>
    <% End Using %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {

 	
	
		var dates = $( "#SchedualStartDate, #SchedualEndDate" ).datepicker({
			defaultDate: "+1w",
			changeMonth: true,
			numberOfMonths: 1,
			onSelect: function( selectedDate ) {
			var option = this.id == "SchedualStartDate" ? "minDate" : "maxDate",
					instance = $( this ).data( "datepicker" ),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings );
				dates.not( this ).datepicker( "option", option, date );
			} // end onSelect
		}); // end Dates
	
    }); // end document ready 
    </script>
</asp:Content>

