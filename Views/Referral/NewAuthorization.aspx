<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Authorization)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New Authorization for 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript" >
        $(document).ready(function() {
            $.ajaxSetup({ cache: false })
            $('#ReferralSourceId').change(function() {
                //alert("rs Change");
                $.getJSON('/Referral/getcounslers/' + $("#ReferralSourceId > option:selected").attr("value"), function(data) {
                    var items = '<option value="0">[Not Set]</option>'
                    $.each(data, function(i, counsler) {
                        items += '<option value="' + counsler.ReferringCounselorId + '">' + counsler.DisplayName + '</option>'
                    });
                    $('#FundingCounslerId').html(items);
                });
            });
            $('#AuthorizationDate').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>NewAuthorization</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ReferralSourceId">Funding Source:</label>
                <%=Html.DropDownList("ReferralSourceId", Model.getReferalSources(Model.FundingCounslerId), "[Not Set]")%>
                <%=Html.ValidationMessage("ReferralSourceId", "*")%>
            </p>
            <p>
                <label for="ReferingCounslerId">Counsler:</label>
                <%=Html.DropDownList("FundingCounslerId", Model.getReferringCounslers, "[Not Set]")%>
                <%=Html.ValidationMessage("FundingCounslerId", "*")%>
            </p>
            <p>
                <label for="AuthorizationNumber">AuthorizationNumber:</label>
                <%= Html.TextBox("AuthorizationNumber") %>
                <%= Html.ValidationMessage("AuthorizationNumber", "*") %>
            </p>
            <p>
                <label for="AuthorizationDate">AuthorizationDate:</label>
                <%= Html.TextBox("AuthorizationDate") %>
                <%= Html.ValidationMessage("AuthorizationDate", "*") %>
            </p>
  
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        
    </div>

</asp:Content>



