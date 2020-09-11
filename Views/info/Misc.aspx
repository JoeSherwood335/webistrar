<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Misc)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Consumer Descriptor for <%=Html.Encode(Model.Info.FirstName)%> <%=Html.Encode(Model.Info.LastName)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=""%>
    <h2>Consumer Descriptor</h2>
    <p>
        <%=Html.ActionLink("Back to Consumer", "Details", New With {.Controller = "info"})%>
    </p>
        <p>
        <%=Html.ActionLink("Edit", "MiscEdit", New With {.rs = ViewData("rs")})%> 
    </p>
    <% Dim race As Integer = 0%>
    <fieldset>
           <p>
                Marital Status
                <% If model.MaritalStatusId.HasValue Then%>
                    <%=Html.Encode(model.MaritalStatus.MaritalStatus)%>
                <% Else%>
                
                <% End If%>
            </p>
            <p>
                Transportation 
                <% If model.TransportationId.HasValue Then%>
                    <%=Html.Encode(model.Transportation.Transportation)%>
                <% Else%>
                
                <% End If%>
            </p>
            <p>
                Police Record 
                <% If model.PoliceRecordId.HasValue Then%>
                    <%=Html.Encode(model.PoliceRecordType.PoliceRecordType)%>
                <% Else%>
                
                <% End If%>
            </p>
            <p>
                Substance Abuse 
                <% If model.SubstanceAbuseHistoryId.HasValue Then%>
                    <%=Html.Encode(model.SubstanceAbuse.SubstanceAbuse)%>
                <% Else%>
                
                <% End If%>
            </p>
            
            <p>
                Lenth of Unemployment 
                <% If model.LengthOfUnemployment.HasValue Then%>
                    <%=Html.Encode(model.LenthOfUmemployment.LenthOfUnEmploymentDesc)%>
                <% Else%>
                
                <% End If%>
            
            </p>
            
    </fieldset> 
    
    <fieldset>
        <legend>Education</legend>
       <p>
        <% If Model.EduHSG.HasValue Then%>
            <% If Model.EduHSG.Value Then%>
                <q>High School Graduated</q>
            <% End If%>
        <% Else%>
        
        
        <% End If%>
        
        <% If Model.EduHSCNoDiploma.HasValue Then%>
            <% If Model.EduHSCNoDiploma.Value Then%>
                <q>High School Completed with No Diploma</q>
            <% End If%>
        <% Else%>
        <% End If%>
        
        
        <% If Model.EduCY.HasValue Then%>
            <% If Model.EduCY.Value Then%>
                <q>College Years</q>
            <% End If%>
        <% Else%>
        <% End If%>
        
        <% If Model.EduCDorPG.HasValue Then%>
            <% If Model.EduCDorPG.Value Then%>
                <q>College Graduate or Post Graduate</q>
            <% End If%>
        <% Else%>
        <% End If%>
        
        <% If Model.EduGed.HasValue Then%>
            <% If Model.EduGed.Value Then%>
                <q>GED</q>
            <% End If%>
        <% Else%>
        <% End If%>
        
        <% If Model.EduSE.HasValue Then%>
            <% If Model.EduSE.Value Then%>
                <q>Special Education</q>
            <% End If%>
        <% Else%>
        <% End If%>
        
        <% If Model.EduEII.HasValue Then%>
            <% If Model.EduEII.Value Then%>
                <q>Education in Institution</q>
            <% End If%>
        <% Else%>
        <% End If%>                

        </p>
        <p>
            <% If Model.EduActualGradeCompleted.HasValue Then%>
                Actual Grade Completed: (<%= Html.Encode(Model.EduActualGradeCompleted) %>)
            <% End If%>
        </p>    
    </fieldset>
    
    <fieldset>
        <legend>Race</legend>            
            <p>
                <% If model.RaceAmeInd.HasValue Then%>
                    <% If Model.RaceAmeInd.Value Then%>
                        <q>American Indian</q>         
                    <% Else%>
                        <% race = race + 1%>
                    <% End If%>
                <% Else%>
                    <% race = race + 1%>
                <% End If%>

                <% If Model.RaceAsian.HasValue Then%>
                    <% If Model.RaceAsian.Value Then%>
                        <q>Asian</q>
                    <% Else%>
                        <% race = race + 2%>
                    <% End If%>
                <% Else%>
                    <% race = race + 2%>
                <% End If%>

                <% If Model.RaceBlack.HasValue Then%>
                    <% If Model.RaceBlack.Value Then%>
                        <q>Black</q>         
                    <% Else%>
                        <% race = race + 4%>
                    <% End If%>
                <% Else%>
                    <% race = race + 4%>
                <% End If%>

                <% If Model.RaceHispanic.HasValue Then%>
                    <% If Model.RaceHispanic.Value Then%>
                       <q>Hispanic</q>        
                    <% Else%>
                        <% race = race + 8%>
                    <% End If%>
                <% Else%>
                    <% race = race + 8%>
                <% End If%>

                <% If Model.RacePacific.HasValue Then%>
                    <% If Model.RacePacific.Value Then%>
                        <q>Pacific</q>       
                    <% Else%>
                        <% race = race + 16%>
                    <% End If%>
                <% Else%>
                    <% race = race + 16%>
                <% End If%>

                <% If Model.RaceWhite.HasValue Then%>
                    <% If Model.RaceWhite.Value Then%>
                        <q>White</q>       
                    <% Else%>
                        <% race = race + 32%>
                    <% End If%>
                <% Else%>
                    <% race = race + 32%>
                <% End If%>


               <% If race = 63 Then%>
                        <q>Race not Specified</q> 
               <% End If%>
            </p>
    </fieldset>
    
    <fieldset>
        <legend>Children/Dependents</legend>   
        <p>
                <% If Model.NumberOfChildren.HasValue Then%>
                    <%  Select Model.NumberOfChildren%>
                           <% Case 0%>
                                No Children
                           <% Case 1%>
                                1 Child
                           <% Case Is > 1%>
                                <%=Model.NumberOfChildren%> Children
                    <% End Select%>
                <% Else%>   
                     <q>I dont know how many children they have.</q>
                <% End If%>
                       <br />         
                <% If Model.NumberOfDependents.HasValue Then%>
                    <%  Select Case Model.NumberOfDependents%>
                           <% Case 0%>
                                No Dependents
                           <% Case 1%>
                                1 Dependent
                           <% Case Is > 1%>
                                <%=Model.NumberOfDependents%> Dependents
                    <% End Select%>
                <% Else%>   
                     <q>I dont know how many Dependents they have.</q>
                <% End If%>
                                
         </p>              
    </fieldset>
    
     

        <fieldset>
        <legend>Special Needs</legend>   
         <table>
         <% For Each ned In Model.Info.SpecialNeedsContainers%>
             <tr>       
                <td><%=Html.Encode(ned.SpecialNeed.SpecialNeedName)%></td>
              </tr>
         <% Next%>
        </table>
   
      <p><%=Html.ActionLink("Edit", "Index", New With {.controller = "SpecialNeeds"})%></p> 
     <!--  -->   
    </fieldset> 
    
   <!-- <fieldset>
        <legend>Type</legend>     
            <p>
    
                <% If Model.EZone.HasValue Then%>
                    <% If Model.EZone.Value Then%>
                       <q>EZone</q>
                    <% End If%>
                <% Else%>
                    
                <% End If%> 
    
                <% If Model.WIA.HasValue Then%>
                    <% If Model.WIA.Value Then%>
                       <q>WIA</q>
                    <% End If%>
                <% Else%>
                    
                <% End If%> 
            </p>
    </fieldset>
    -->
    <fieldset>
        <legend>Response</legend>    
         
            <p style="color:Red;">
                <% If Model.DoNotEmail.HasValue Then%>
                    <% If Model.DoNotEmail.Value Then%>
                        <q>Do Not Email</q>
                    <% End If%>
                <% Else%>
                    
                <% End If%> 
                
                <% If Model.DoNotMail.HasValue Then%>
                    <% If Model.DoNotMail.Value Then%>
                        <q>Do Not Mail</q>       
                    <% End If%>
                <% Else%>
                    
                <% End If%>
                
                <% If Model.DoNotCall.HasValue Then%>
                    <% If Model.DoNotCall.Value Then%>
                        <q>Do Not Call</q>       
                    <% End If%>
                <% Else%>
                    
                <% End If%>
            </p>
    </fieldset>
    
    
    


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

