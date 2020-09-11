<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Service ID
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Authorization</legend>

            <p>
                <label for="ServiceName">Service Name:</label>
                <%=Html.TextBox("ServiceName")%>
                <%=Html.ValidationMessage("ServiceName", "*")%>
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
                <label for="UnitTypeId">UnitType:</label>
                <%=Html.DropDownList("UnitTypeId", Model.GetUnitType(), "[not set]")%>
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
                <input type="submit" value="Create" />
            </p>
        </fieldset>
         <fieldset>
            <legend>BWC</legend>
            <p>
                <label for="OneUnitOfServiceEquals">Unit of Service</label>
                <%=Html.TextBox("UnitOfServiceEquals")%>
            </p>
            <p>
                <label for="UnitAmountAuthorized">Unit Amount Authorized</label>
                <%=Html.TextBox("UnitAmountAuthorized")%>
            </p>
            <p>
                <label for="HCPCSCode">HCPCS Code</label>
                <%=Html.TextBox("HCPCSCode")%>
            </p>
        </fieldset>
        
        
    <% End Using %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript" >
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

