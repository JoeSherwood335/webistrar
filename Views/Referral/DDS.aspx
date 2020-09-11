<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Developmental Disabilities Services
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Developmental Disabilities Services</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Html.RenderPartial("DDSOutcome")%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
 <script type="text/javascript" >
         $(document).ready(function() {
             $(".Calander").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 showOtherMonths: true,
                 selectOtherMonths: true
             }); // end datepicker
          }); // end doc ready 
  </script>

</asp:Content>

