<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Referral)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>



<asp:Content ID="Head1" ContentPlaceHolderID="HeaderContent" runat="server" >

<script type="text/javascript" >
    $(document).ready(function() {
        $.ajaxSetup({ cache: false })
        $('#ReferralSourceId').change(function() {
            //alert("rs Change");
            loadCounslers();
        }); // end referralsourceid change
        $('#ReferralDate').datepicker();
        $('#ServiceRequested').change(function() {
            if ($("#ServiceRequested > option:selected").attr("value") == 4) {
                //$("#ServiceRequestedDDL").Hide();
                //$("#ServiceRequestedText").Show();
                $("#ServiceRequestedDDL").toggle('puff', { percent: 0 }, 500, function() {
                    $("#ServiceRequestedText").toggle('puff', { percent: 0 }, 500);
                }); //end ServiceRequestedDDL

            } // end if

        }); // end servicerequested change
        $("#ServiceRequestedText a").click(function() {
            $("#ServiceRequestedText").toggle('puff', { percent: 0 }, 100, function() {
                $("#ServiceRequestedDDL").toggle('puff', { percent: 0 }, 100);
            }); // end ServiceRequestedText

            $("#ServiceRequested").val('');
        });

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ProgramId">Program:</label>
                <%=Html.DropDownList("ProgramId", Model.GetPrograms, "[Not Set]")%>
                <%= Html.ValidationMessage("ProgramId", "*") %>
            </p>
            <p>
                <label for="AssignedTo">AssignedTo:</label>
                <%=Html.DropDownList("AssignedTo", Model.GetAssignedTo, "[Not Set]")%>
                <%= Html.ValidationMessage("AssignedTo", "*") %>
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
            <div id="ServiceRequestedDDL">
            <p>
                <label for="ServiceRequested">ServiceRequested:</label>
                <%=Html.DropDownList("ServiceRequested", Model.GetCRPServiceRequesteds , "[Not Set]")%>
                <%=Html.ValidationMessage("ServiceRequested", "*")%>
            </p>
            </div>
            <div id="ServiceRequestedText" style="display:none;">
                <p>
                    <label for="Other">Other:</label>
                    <%= Html.TextBox("Other") %><a href="#">Cancel</a>
                    <%= Html.ValidationMessage("Other", "*") %>
              
                </p>
            </div>
            <p>
                <label for="ReferralDate">ReferralDate:</label>
                <%= Html.TextBox("ReferralDate") %>
                <%= Html.ValidationMessage("ReferralDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

<div id="foo" style="display:none;"></div>
        

    <div>
        
    </div>

</asp:Content>

