<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcome)" %>
<%@ Import Namespace="R2kdoiMVC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 Program Outome for <%=Model.Referral.ProgramInstance.Program.Acronym%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <% Dim ipo As Model.ProgramOutcomes.iProgramOutcome%>
     
       <% If model.PoTypeId.Equals(1) Then%> 
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.StOutcome%>
       <% ElseIf model.PoTypeId.Equals(2) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WeOutcome%>
       <% ElseIf model.PoTypeId.Equals(3) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.WaOutcome%>
       <% ElseIf model.PoTypeId.Equals(5) Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.JsstOutcome%>
       <% ElseIf Myapp.GetPoType(model.PoData) = "pd" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.PdOutcome%>
       <% ElseIf Myapp.GetPoType(Model.PoData) = "jc" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.JCOutcome%>     
       <% ElseIf Myapp.GetPoType(Model.PoData) = "dds" Then%>
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.ddsOutcome%>     
       <% Else%>     
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.BlankOutcome%>
       <% End If%>
       <% ipo.ReadXml(model.PoData)%>
       <h2>Program Outcome</h2>
       <p>
        <%=Html.ActionLink("Back", "Outcome", New With {.Controller = "Referral", .id = Model.ReferralId})%>
       </p>
       <fieldset>  
       <p>
       <strong>Name</strong>
        <%=Model.Referral.Info.GetFullName%>
       </p>
       <p>
       <strong>Outcome</strong>
        <%If Model.Referral.ServiceOutcomeId.HasValue Then%>
            <%=Model.Referral.ServiceOutcome.ServiceOutcomeName%>
        <% Else%>
            [Not Set]
        <%End If%>
       </p>              
    
       <p>
       <strong>Location</strong>
        <%=Model.Referral.ProgramInstance.Location.LocationName%>
       </p>
       
       <p><strong>Type</strong>
         <%=ipo.Title%></p>
       <p><%=ipo.Body%></p>
       </fieldset>
       
        <% If Not model.InfoPathData Is Nothing Then%>
        <% end if  %>
</asp:Content>
