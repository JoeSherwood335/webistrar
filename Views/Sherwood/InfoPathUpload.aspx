<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)" %>
<%@ Import Namespace="R2kdoiMVC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	InfoPathUpload
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>InfoPathUpload</h2>

    <fieldset>
        <legend>Fields</legend>
        
            

    
    
       <%  Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(Myapp.GetAttachmentTempPath("r", Model.ReferralId, True))%> 
       <%=d.FullName%> <br />      
          

          
    
    
    <div class="ServiceOutcomes">
    
    <% For Each i In Model.ProgramOutcomes%>
    <fieldset>
    <legend>Service Outcomes</legend>
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
       <% Else%>     
            <% ipo = New R2kdoiMVC.Model.ProgramOutcomes.BlankOutcome%>
       <% End If%>
       <% ipo.ReadXml(i.PoData)%>
       
       
       <%=ipo.Title%>
       <div>
       
       
       <%=ipo.Body%> 
       
       <% For Each x As IO.FileInfo In d.GetFiles%>
           <%=Html.ActionLink(x.Name, "Save", New With {.FullName = x.FullName, .poID = i.PoId})%> <br />
       <% Next%>
       
       <% If Not i.InfoPathData Is Nothing Then%>
            <% Dim edit = String.Format(R2kdoiMVC.Myapp.BuildUri.Action("getInfopath", New With {.controller = "Referral", .permilink = Model.Info.Permilink, .id = i.PoId}))%>
            <a href="<%=edit%>">View Infopath</a>
       <% end if  %>
       </div>

   </fieldset>           
    <% Next%>
    </div>

        
        
        <p>
            ReferralId:
            <%= Html.Encode(Model.ReferralId) %>
        </p>
        <p>
            AssignedTo:
            <%= Html.Encode(Model.AssignedTo) %>
        </p>
        <p>
            ReferingCounslerId:
            <%= Html.Encode(Model.ReferingCounslerId) %>
        </p>
        <p>
            ServiceRequested:
            <%= Html.Encode(Model.ServiceRequested) %>
        </p>
        <p>
            Other:
            <%= Html.Encode(Model.Other) %>
        </p>
        <p>
            ReferralDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ReferralDate)) %>
        </p>
        <p>
            RegistrarNo:
            <%= Html.Encode(Model.RegistrarNo) %>
        </p>
        <p>
            StatusId:
            <%= Html.Encode(Model.StatusId) %>
        </p>
        <p>
            ProgramId:
            <%= Html.Encode(Model.ProgramId) %>
        </p>
        <p>
            ServiceOutcomeId:
            <%= Html.Encode(Model.ServiceOutcomeId) %>
        </p>
        <p>
            InputedBy:
            <%= Html.Encode(Model.InputedBy) %>
        </p>
        <p>
            ED:
            <%= Html.Encode(String.Format("{0:g}", Model.ED)) %>
        </p>
        <p>
            UD:
            <%= Html.Encode(String.Format("{0:g}", Model.UD)) %>
        </p>
        <p>
            OldId:
            <%= Html.Encode(Model.OldId) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ReferralId})%> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

