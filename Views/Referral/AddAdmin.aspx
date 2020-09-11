<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Services for Administration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Services for Administration </h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>
                <label for="IntakeAssignedTo">Intake AssignedTo:</label>
                

   <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ProgramId">Program:</label>
                <%=Html.DropDownList("ProgramId", Model.GetPrograms())%>
                <%= Html.ValidationMessage("ProgramId", "*") %>
            </p>
            <p>
                <label for="IntakeAssignedTo">Intake AssignedTo:</label>
                <%=Html.DropDownList("IntakeAssignedTo", Model.GetAssignedTo(), "[Not Set]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
            </p>
             <p>
                <label for="TransportationAssignedTo">Transportation AssignedTo:</label>
                <%=Html.DropDownList("TransportationAssignedTo", Model.GetAssignedTo(), "[Not Set]")%>
                <%=Html.ValidationMessage("TransportationAssignedTo", "*")%>
            </p>
            <p>
                <label for="ReferralSourceId">Referral Source:</label>
                <%=Html.DropDownList("ReferralSourceId", Model.GetReferralSources(), "[Not Set]")%>
                <%=Html.ValidationMessage("ReferralSourceId", "*")%>
            </p>
            <p>
                <label for="ReferingCounslerId">ReferingCounsler:</label>
                <%=Html.DropDownList("ReferingCounslerId", Model.GetReferringCounselors(1), "[Not Set]")%><a id="newC" href="#" >New</a>
                
                <!--select name="ReferingCounslerId" id="ReferingCounslerId">
                </select-->
                <%= Html.ValidationMessage("ReferingCounslerId", "*") %>
            </p>
            <%=Html.Hidden("ServiceRequested", 4)%>
            <p>
                <label for="Other">ServiceRequested:</label>
                <%=Html.TextBox("Other", "Administration")%>
                <%= Html.ValidationMessage("Other", "*") %>
            </p>
            <p>
                <label for="ReferralDate">ReferralDate:</label>
                <%= Html.TextBox("ReferralDate") %>
                <%= Html.ValidationMessage("ReferralDate", "*") %>           
            </p>
            <p>
                <label for="AuthorizationNumber">AuthorizationNumber:</label>
                <%= Html.TextBox("AuthorizationNumber") %>
                <%= Html.ValidationMessage("AuthorizationNumber", "*") %>
            
            </p>
            
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
            <td>Intake</td>
            <td ><%=Html.TextBox("IntakeNumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("IntakeUnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("IntakeUnitTypeId", R2kdoiMVC.Model.Service.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("IntakeAmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("IntakeSchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("IntakeSchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>
        <tr>
            <td>Transportation</td>
            <td ><%=Html.TextBox("TransportationNumberOfUnitesAuthorized", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.TextBox("TransportationUnitPrice", Nothing, New With {.style = "width:40px;"})%></td>
            <td><%=Html.DropDownList("TransportationUnitTypeId", R2kdoiMVC.Model.Service.GetUnitType(), "[not set]")%></td>
            <td><%=Html.TextBox("TransportationAmountAuthorized", Nothing, New With {.style = "width:60px;"})%></td>
            <td><%=Html.TextBox("TransportationSchedualStartDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
            <td><%=Html.TextBox("TransportationSchedualEndDate", Nothing, New With {.style = "width:70px;", .class = "datetime"})%></td>
        </tr>
        </table>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>





    <% End Using %>




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
<script type="text/javascript" >
    $(document).ready(function() {
        $.ajaxSetup({ cache: false })
        $('#ReferralSourceId').change(function() {
            //alert("rs Change");
            loadCounslers();
        }); // end referralsourceid change
        $('#ReferralDate').datepicker();
        
        $("#ServiceRequestedDDL").toggle('puff', { percent: 0 }, 500, function() {
            $("#ServiceRequestedText").toggle('puff', { percent: 0 }, 500);
        }); //end ServiceRequestedDDL
       

        $("#newC").click(function() {
            var fs = $("#ReferralSourceId > option:selected").text();
            var rs = $("#ReferralSourceId > option:selected").attr("value");
            var p = $("#ProgramId > option:selected").attr("value");
            var at = $("#AssignedTo > option:selected").attr("value");


            //alert(fs);

            $.cookie("ReferralSourceId", rs);
            $.cookie("ProgramId", p);
            $.cookie("AssignedTo", at);

            $("#foo").load("/fundingsource/" + fs + "/NewCounsler form", function() {
                $("#foo").dialog();


            }); // end load foo





        }); //end newc click

        var b = $.cookie("ReferralSourceId");

        if (b != 'Object') {

            $("select#ReferralSourceId").val(b);

            loadCounslers()

            $.cookie("ReferralSourceId", null);
            //alert(b);
        }

        var c = $.cookie("ProgramId");

        if (c != 'Object') {
            $("select#ProgramId").val(c);
            $.cookie("ProgramId", null);
            //alert(b);
        }

        var d = $.cookie("AssignedTo");

        if (d != 'Object') {
            $("select#AssignedTo").val(d);
            $.cookie("AssignedTo", null);
            //alert(b);
        }
    });       //end document ready

    function loadCounslers() {

        $.getJSON('/Referral/getcounslers/' + $("#ReferralSourceId > option:selected").attr("value"), function(data) {
            var items = '<option value="0">[Not Set]</option>'
            $.each(data, function(i, counsler) {
                items += '<option value="' + counsler.ReferringCounselorId + '">' + counsler.DisplayName + '</option>'
            }); //end each 
            $('#ReferingCounslerId').html(items);
        }); // end getjson
    
    } // end loacsounslers

</script>

</asp:Content>

