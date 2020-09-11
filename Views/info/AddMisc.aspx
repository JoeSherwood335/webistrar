<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Misc)" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Consumer Descriptor
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <h2>Consumer Descriptor</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
    <p>
        <label for="DOB">
            Date of Birth</label>
        <%= Html.TextBox("DOB") %>
        <%= Html.ValidationMessage("DOB", "*") %>
    </p>
    <p>
        <label for="GenderId">
            Gender</label>
        <%=Html.DropDownList("GenderId", Model.GetGender(), "[not set]", Nothing)%>
        <%= Html.ValidationMessage("GenderId", "*") %>
    </p>
    <p>
        <label for="MaritalStatusId">
            Marital Status</label>
        <%=Html.DropDownList("MaritalStatusId", Model.GetMaritalStatus(), "[not set]", Nothing)%>
        <%= Html.ValidationMessage("MaritalStatusId", "*") %>
    </p>
    <p>
        <label for="TransportationId">
            Transportation</label>
        <%=Html.DropDownList("TransportationId", Model.GetTransportation(), "[not set]", Nothing)%>
        <%= Html.ValidationMessage("TransportationId", "*") %>
    </p>
    <p>
        <label for="PoliceRecordId">
            Police Record</label>
        <%=Html.DropDownList("PoliceRecordId", Model.GetPoliceRecord(), "[not set]", Nothing)%>
        <%=Html.ValidationMessage("PoliceRecordId", "*")%>
    </p>
    <p>
        <label for="SubstanceAbuseHistoryId">
            SubstanceAbuse History</label>
        <%=Html.DropDownList("SubstanceAbuseHistoryId", Model.GetSubstanceAbuse(), "[not set]", Nothing)%>
        <%= Html.ValidationMessage("SubstanceAbuseHistoryId", "*") %>
    </p>
            <p>
            <label for="LengthOfUnemployment">Length Of Unemployment:</label>
            <%=Html.DropDownList("LengthOfUnemployment", Model.GetLenthOfUnemployment, "[not set]", Nothing)%>
            <%= Html.ValidationMessage("LengthOfUnemployment", "*") %>
        </p>
    <fieldset>
        <legend>Race</legend>
        <p>
            <label for="RaceAmeInd">
                American Indian/Alaskan Native</label>
            <%=Html.RadioButton("RaceAmeInd", True)%>Yes<br />
            <%=Html.RadioButton("RaceAmeInd", False)%>No<br />
            <%=Html.RadioButton("RaceAmeInd", "")%>Unknown<br />
            <%= Html.ValidationMessage("RaceAmeInd", "*") %>
        </p>
        <p>
            <label for="RaceAsian">
                Asian</label>
            <%=Html.RadioButton("RaceAsian", True)%>Yes<br />
            <%=Html.RadioButton("RaceAsian", False)%>No<br />
            <%=Html.RadioButton("RaceAsian", "")%>Unknown<br />
            <%= Html.ValidationMessage("RaceAsian", "*") %>
        </p>
        <p>
            <label for="RaceBlack">
                Black/African American</label>
            <%=Html.RadioButton("RaceBlack", True)%>Yes<br />
            <%=Html.RadioButton("RaceBlack", False)%>No<br />
            <%=Html.RadioButton("RaceBlack", "")%>Unknown<br />
            <%= Html.ValidationMessage("RaceBlack", "*") %>
        </p>
        <p>
            <label for="RaceHispanic">
                Hispanic
            </label>
            <%=Html.RadioButton("RaceHispanic", True)%>Yes<br />
            <%=Html.RadioButton("RaceHispanic", False)%>No<br />
            <%=Html.RadioButton("RaceHispanic", "")%>Unknown<br />
            <%= Html.ValidationMessage("RaceHispanic", "*") %>
        </p>
        <p>
            <label for="RacePacific">
                Pacific Islander/Indian Subcontinent</label>
            <%=Html.RadioButton("RacePacific", True)%>Yes<br />
            <%=Html.RadioButton("RacePacific", False)%>No<br />
            <%=Html.RadioButton("RacePacific", "")%>Unknown<br />
            <%= Html.ValidationMessage("RacePacific", "*") %>
        </p>
        <p>
            <label for="RaceWhite">
                White</label>
            <%=Html.RadioButton("RaceWhite", True)%>Yes<br />
            <%=Html.RadioButton("RaceWhite", False)%>No<br />
            <%=Html.RadioButton("RaceWhite", "")%>Unknown<br />
            <%= Html.ValidationMessage("RaceWhite", "*") %>
        </p>
    </fieldset>
    <fieldset>
        <legend>Education</legend>
        <p>
            <label for="EduHSG">High School Graduated:</label>
            <%=Html.CheckBox("EduHSG")%>
            <%= Html.ValidationMessage("EduHSG", "*") %>
        </p>
        <p>
            <label for="EduHSCNoDiploma">High School Completed with No Diploma:</label>
            <%=Html.CheckBox("EduHSCNoDiploma")%>
            <%= Html.ValidationMessage("EduHSCNoDiploma", "*") %>
        </p>
        <p>
            <label for="EduCY">College Years:</label>
            <%=Html.CheckBox("EduCY")%>
            <%= Html.ValidationMessage("EduCY", "*") %>
        </p>
        <p>
            <label for="EduCDorPG">College Graduate or Post Graduate:</label>
            <%=Html.CheckBox("EduCDorPG")%>
            <%= Html.ValidationMessage("EduCDorPG", "*") %>
        </p>
        <p>
            <label for="EduGed">GED:</label>
            <%=Html.CheckBox("EduGed")%>
            <%= Html.ValidationMessage("EduGed", "*") %>
        </p>
        <p>
            <label for="EduSE">Special Education:</label>
            <%=Html.CheckBox("EduSE")%>
            <%= Html.ValidationMessage("EduSE", "*") %>
        </p>
        <p>
            <label for="EduEII">Education in Institution:</label>
            <%=Html.CheckBox("EduEII")%>
            <%= Html.ValidationMessage("EduEII", "*") %>
        </p>
        <p>
            <label for="EduActualGradeCompleted">Actual Grade Completed:</label>
            <%=Html.TextBox("EduActualGradeCompleted")%>
            <%= Html.ValidationMessage("EduActualGradeCompleted", "*") %>
        </p>
    </fieldset>
    
    <fieldset>
        <legend>Children/Dependents</legend>   
            <p>
                <label for="NumberOfChildren">Number Of Children:</label>
                <%= Html.TextBox("NumberOfChildren") %>
                <%= Html.ValidationMessage("NumberOfChildren", "*") %>
            </p>
            <p>
                <label for="NumberOfDependents">Number Of Dependents:</label>
                <%= Html.TextBox("NumberOfDependents") %>
                <%= Html.ValidationMessage("NumberOfDependents", "*") %>
            </p>

    </fieldset>
   
          <fieldset>
        <legend>Special Needs</legend>   
        
 
      <p>Please Save and Close to add Special Needs</p> 
     <!--  -->   
    </fieldset> 
    <!-- <fieldset>
        <legend>Misc</legend>
        <p>
   -------------------------------------------------------------------------------------          <label for="EZone">EZone</label>
            <%=Html.CheckBox("EZone")%>
            <%= Html.ValidationMessage("EZone", "*") %>
        </p>
        <p>
            <label for="WIA">WIA</label>
            <%=Html.CheckBox("WIA")%>
            <%= Html.ValidationMessage("WIA", "*") %>
        </p>

    </fieldset>
    -->
    <fieldset>
        <legend>Do Not Contact By </legend>
        <p>
            <label for="DoNotEmail">
                Do Not Email</label>
            <%=Html.CheckBox("DoNotEmail")%>
            <%= Html.ValidationMessage("DoNotEmail", "*") %>
        </p>
        <p>
            <label for="DoNotMail">
                Do Not Mail</label>
            <%=Html.CheckBox("DoNotMail")%>
            <%= Html.ValidationMessage("DoNotMail", "*") %>
        </p>
        <p>
            <label for="DoNotCall">
                Do Not Call</label>
            <%=Html.CheckBox("DoNotCall")%>
            <%= Html.ValidationMessage("DoNotCall", "*") %>
        </p>
    </fieldset>
    <%=Html.Hidden("rs")%>
    <input type="submit" value="Save" />
    
    <% End Using%>

</asp:Content>









