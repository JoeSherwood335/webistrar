<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Placement)" %>
<%@ Import Namespace="R2kdoiMVC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Placement for <%=String.Format("{0} {1}", Model.Info.FirstName, Model.Info.LastName)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Placement for <%=String.Format("{0} {1}", Model.Info.FirstName, Model.Info.LastName)%></h2>

<fieldset>
    <legend>Program</legend>

    <p>
        Program:
            <%=Model.Referral.ProgramInstance.Program.ProgramName%>
    </p>
    <p>
        Referring Agency 
            <%=Model.Referral.ReferringCounselor.FundingSource.Acronym%>    
    </p>

</fieldset>
<fieldset>
    <legend>Company</legend>
         <p>
            Company:
            <%=Html.Encode(Model.Company.CompanyName)%>
        </p>
 
 </fieldset>
    <fieldset>
        <legend>Placement</legend>
        <p>
            PlacementType:
            <%=Html.Encode(Model.PlacementType.PlacementType)%>
        </p>
        <p>
            Name:
            <%=Html.ConsumerLink(Model.Info.RegistrarNo)%>
        </p>

        <p>
            Staff:
            <%=Html.Encode(Model.RegisteredUser.Username)%>
        </p>

        <p>
            JobTitle:
            <%= Html.Encode(Model.JobTitle) %>
        </p>
        <p>
            Wage:
            <%=Html.Encode(String.Format("{0:C}", Model.Wage))%>
        </p>
        <p>
            Wage Type:
            <% If Model.WageTypeId.HasValue Then%>
            <%=Html.Encode(Model.WageType.WageType)%>
            <% End If%>
        </p>
        <p>
            JobType:
            <% If Model.JobTypeId.HasValue = False then  %>
            <% else %>
                 <%=Html.Encode(Model.JobType.JobType)%>
            <% End If  %>
           
        </p>
        <p>
            Hours Per Week:
            <%= Html.Encode(Model.HoursPerWeek) %>
        </p>
        <p>
            Has Medical:
            <%=Html.CheckDetails(Model.HasMedical)%>
        </p>
        <p>
            Is less then 90 from Employment Prep:
            <%If Model.Is90ofEmploymentPrep = 1 Then%>
                Yes
            <%ElseIf Model.Is90ofEmploymentPrep = 2 Then%>
                No
            <%Else%>
                I Don't Know
            <%End If%>
          </p>
        <p>
            IsPlacement:
            <%=Html.CheckDetails(Model.IsPlacement)%>
        </p>
        <p>
            PlacementDate:
            <%=Html.Encode(String.Format("{0:D}", Model.PlacementDate))%>
        </p>
        <p>
            IsClosure:
            <%=Html.CheckDetails(Model.IsClosure)%>
        </p>
        <p>
            ClosureDate:
            <%=Html.Encode(String.Format("{0:D}", Model.ClosureDate))%>
        </p>

    </fieldset>
    
    <fieldset>
        <legend>Wage Increase</legend>
        <p>
            90 Day Wage Increase:        
        <%If Model.WageIncrease90None.HasValue Then%>
            <%If Model.WageIncrease90None.Value = False Then%>    
                None    
           <%Else%>
                <%If Model.WageIncrease90.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:c}", Model.WageIncrease90))%>
                <%Else%>         
                    <span style="color:Red;">Error</span>
                <%End If%>
            <%End If%>    
        <%End If%>
       </p> 
        <p>
         180 Day Wage Increase:        
         <%If Model.WageIncrease180None.HasValue Then%>
            <%If Model.WageIncrease180None.Value = False Then%>    
                None    
           <%Else%>
                <%If Model.WageIncrease180.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:c}", Model.WageIncrease180))%>
                <%Else%>         
                    <span style="color:Red;">Error</span>
                <%End If%>
            <%End If%>    
        <%End If%>
       </p>        
    </fieldset>
    
        <fieldset>
        <legend>Retention</legend>
        <p>
            90 Retention:        
        <%If Model.Retention90.HasValue Then%>
            <%If Model.Retention90.Value = False Then%>    
                None    
           <%Else%>
                <%If Model.Retention90Date.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:d}", Model.Retention90Date))%>
                <%Else%>         
                    <span style="color:Red;">Error</span>
                <%End If%>
            <%End If%>    
        <%End If%>
       </p> 
        <p>
         180 Retention:        
         <%If Model.Retention180.HasValue Then%>
            <%If Model.Retention180.Value = False Then%>    
                None    
           <%Else%>
                <%If Model.Retention180Date.HasValue Then%>
                    <%=Html.Encode(String.Format("{0:d}", Model.Retention180Date))%>
                <%Else%>         
                    <span style="color:Red;">Error</span>
                <%End If%>
            <%End If%>    
        <%End If%>
       </p>        
    </fieldset>

    <fieldset>
        <legend></legend>
        
        
        
        
        
        
        
    </fieldset>
    
    
    
    <p>
        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.PlacementId})%> |
        <%=Html.ActionLink("Back to Referral", "Outcome", New With {.controller = "Referral", .id = Model.ReferralId})%>
      </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

